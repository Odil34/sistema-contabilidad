using System.IO;
using Microsoft.Data.SqlClient;
using sistema_contabilidad.Modelos;
using sistema_contabilidad.Seguridad;

namespace sistema_contabilidad.Datos
{
    public static class InicializadorBD
    {
        public static void Inicializar()
        {
            try
            {
                Db.EsSqlServer = true;
                EjecutarConReintentos(() =>
                {
                    CrearBaseDatosSqlServer();
                    CrearTablasSqlServer();
                });
            }
            catch (Exception)
            {
                Db.UsarSqlite();
                CrearTablasSqlite();
            }

            SembrarCatalogo();
            SembrarSeguridad();
        }

        private static void EjecutarConReintentos(Action accion, int intentos = 3)
        {
            for (int i = 1; ; i++)
            {
                try
                {
                    accion();
                    return;
                }
                catch (SqlException) when (i < intentos)
                {
                    System.Threading.Thread.Sleep(1200);
                }
            }
        }

        private static void CrearBaseDatosSqlServer()
        {
            string db = ConexionBD.NombreBaseDatos;

            using var con = new SqlConnection(ConexionBD.CadenaConexionMaestra);
            con.Open();

            object dbId;
            using (var check = new SqlCommand("SELECT DB_ID(@n)", con))
            {
                check.Parameters.AddWithValue("@n", db);
                dbId = check.ExecuteScalar();
            }
            if (dbId != null && dbId != DBNull.Value) return;

            string dataPath;
            using (var c = new SqlCommand(
                "SELECT CAST(SERVERPROPERTY('InstanceDefaultDataPath') AS nvarchar(500))", con))
            {
                dataPath = c.ExecuteScalar() as string;
            }
            string mdf = string.IsNullOrEmpty(dataPath) ? null : Path.Combine(dataPath, db + ".mdf");
            string ldf = string.IsNullOrEmpty(dataPath) ? null : Path.Combine(dataPath, db + "_log.ldf");

            if (mdf != null && File.Exists(mdf))
            {
                try
                {
                    EjecutarSql(con, $"CREATE DATABASE [{db}] ON (FILENAME = N'{mdf}') FOR ATTACH_REBUILD_LOG;");
                    return;
                }
                catch (SqlException)
                {
                    TryDelete(mdf);
                    TryDelete(ldf);
                }
            }

            try
            {
                EjecutarSql(con, $"CREATE DATABASE [{db}];");
            }
            catch (SqlException) when (mdf != null && File.Exists(mdf))
            {
                EjecutarSql(con, $"CREATE DATABASE [{db}] ON (FILENAME = N'{mdf}') FOR ATTACH_REBUILD_LOG;");
            }
        }

        private static void CrearTablasSqlServer()
        {
            using var con = ConexionBD.ObtenerConexion();
            string sql = @"
IF OBJECT_ID('dbo.Cuentas', 'U') IS NULL
CREATE TABLE dbo.Cuentas (
    Codigo NVARCHAR(10) NOT NULL PRIMARY KEY, Nombre NVARCHAR(150) NOT NULL,
    CodigoPadre NVARCHAR(10) NULL, Tipo INT NOT NULL, Naturaleza NVARCHAR(10) NOT NULL,
    EsDetalle BIT NOT NULL DEFAULT 1);

IF OBJECT_ID('dbo.Asientos', 'U') IS NULL
CREATE TABLE dbo.Asientos (
    IdAsiento INT IDENTITY(1,1) PRIMARY KEY, Numero INT NOT NULL, Fecha DATE NOT NULL,
    Concepto NVARCHAR(300) NOT NULL, FechaRegistro DATETIME NOT NULL DEFAULT GETDATE());

IF OBJECT_ID('dbo.AsientoDetalle', 'U') IS NULL
CREATE TABLE dbo.AsientoDetalle (
    IdDetalle INT IDENTITY(1,1) PRIMARY KEY, IdAsiento INT NOT NULL, CodigoCuenta NVARCHAR(10) NOT NULL,
    Concepto NVARCHAR(300) NULL, Debe DECIMAL(18,2) NOT NULL DEFAULT 0, Haber DECIMAL(18,2) NOT NULL DEFAULT 0,
    CONSTRAINT FK_Detalle_Asiento FOREIGN KEY (IdAsiento) REFERENCES dbo.Asientos(IdAsiento) ON DELETE CASCADE,
    CONSTRAINT FK_Detalle_Cuenta FOREIGN KEY (CodigoCuenta) REFERENCES dbo.Cuentas(Codigo));

IF OBJECT_ID('dbo.Roles', 'U') IS NULL
CREATE TABLE dbo.Roles (
    IdRol INT IDENTITY(1,1) PRIMARY KEY, Nombre NVARCHAR(50) NOT NULL UNIQUE, Descripcion NVARCHAR(200) NULL);

IF OBJECT_ID('dbo.Usuarios', 'U') IS NULL
CREATE TABLE dbo.Usuarios (
    IdUsuario INT IDENTITY(1,1) PRIMARY KEY, NombreUsuario NVARCHAR(50) NOT NULL UNIQUE,
    NombreCompleto NVARCHAR(150) NULL, ClaveHash NVARCHAR(200) NOT NULL, Salt NVARCHAR(100) NOT NULL,
    IdRol INT NOT NULL, Activo BIT NOT NULL DEFAULT 1, FechaCreacion DATETIME NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_Usuario_Rol FOREIGN KEY (IdRol) REFERENCES dbo.Roles(IdRol));";
            using var cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
        }

        private static void CrearTablasSqlite()
        {
            using var con = Db.Abrir();
            string sql = @"
CREATE TABLE IF NOT EXISTS Cuentas (
    Codigo TEXT PRIMARY KEY, Nombre TEXT NOT NULL, CodigoPadre TEXT NULL,
    Tipo INTEGER NOT NULL, Naturaleza TEXT NOT NULL, EsDetalle INTEGER NOT NULL DEFAULT 1);

CREATE TABLE IF NOT EXISTS Asientos (
    IdAsiento INTEGER PRIMARY KEY AUTOINCREMENT, Numero INTEGER NOT NULL, Fecha TEXT NOT NULL,
    Concepto TEXT NOT NULL, FechaRegistro TEXT NOT NULL DEFAULT (datetime('now')));

CREATE TABLE IF NOT EXISTS AsientoDetalle (
    IdDetalle INTEGER PRIMARY KEY AUTOINCREMENT, IdAsiento INTEGER NOT NULL, CodigoCuenta TEXT NOT NULL,
    Concepto TEXT NULL, Debe NUMERIC NOT NULL DEFAULT 0, Haber NUMERIC NOT NULL DEFAULT 0,
    FOREIGN KEY (IdAsiento) REFERENCES Asientos(IdAsiento) ON DELETE CASCADE,
    FOREIGN KEY (CodigoCuenta) REFERENCES Cuentas(Codigo));

CREATE TABLE IF NOT EXISTS Roles (
    IdRol INTEGER PRIMARY KEY AUTOINCREMENT, Nombre TEXT NOT NULL UNIQUE, Descripcion TEXT NULL);

CREATE TABLE IF NOT EXISTS Usuarios (
    IdUsuario INTEGER PRIMARY KEY AUTOINCREMENT, NombreUsuario TEXT NOT NULL UNIQUE, NombreCompleto TEXT NULL,
    ClaveHash TEXT NOT NULL, Salt TEXT NOT NULL, IdRol INTEGER NOT NULL, Activo INTEGER NOT NULL DEFAULT 1,
    FechaCreacion TEXT NOT NULL DEFAULT (datetime('now')),
    FOREIGN KEY (IdRol) REFERENCES Roles(IdRol));";
            using var cmd = Db.Cmd(sql, con);
            cmd.ExecuteNonQuery();
        }

        private static void SembrarCatalogo()
        {
            using var con = Db.Abrir();
            using (var check = Db.Cmd("SELECT COUNT(*) FROM Cuentas", con))
            {
                if (Convert.ToInt32(check.ExecuteScalar()) > 0) return;
            }

            foreach (var c in CatalogoSemilla())
            {
                int tipo = c.codigo[0] - '0';
                string naturaleza = (tipo == 1 || tipo == 4) ? "Deudora" : "Acreedora";
                using var cmd = Db.Cmd(
                    "INSERT INTO Cuentas (Codigo, Nombre, CodigoPadre, Tipo, Naturaleza, EsDetalle) VALUES (@cod, @nom, @padre, @tipo, @nat, @det)", con);
                Db.P(cmd, "@cod", c.codigo);
                Db.P(cmd, "@nom", c.nombre);
                Db.P(cmd, "@padre", c.padre);
                Db.P(cmd, "@tipo", tipo);
                Db.P(cmd, "@nat", naturaleza);
                Db.P(cmd, "@det", c.detalle ? 1 : 0);
                cmd.ExecuteNonQuery();
            }
        }

        private static void SembrarSeguridad()
        {
            using var con = Db.Abrir();

            using (var check = Db.Cmd("SELECT COUNT(*) FROM Roles", con))
            {
                if (Convert.ToInt32(check.ExecuteScalar()) == 0)
                {
                    var roles = new (string nombre, string desc)[]
                    {
                        (Rol.Administrador, "Acceso total, incluida la gestión de usuarios."),
                        (Rol.Contador,      "Registra asientos y consulta todos los reportes; sin gestión de usuarios."),
                        (Rol.Consulta,      "Solo lectura de reportes y estados financieros.")
                    };
                    foreach (var r in roles)
                    {
                        using var cmd = Db.Cmd("INSERT INTO Roles (Nombre, Descripcion) VALUES (@n, @d)", con);
                        Db.P(cmd, "@n", r.nombre);
                        Db.P(cmd, "@d", r.desc);
                        cmd.ExecuteNonQuery();
                    }
                }
            }

            using (var check = Db.Cmd("SELECT COUNT(*) FROM Usuarios", con))
            {
                if (Convert.ToInt32(check.ExecuteScalar()) == 0)
                {
                    CrearUsuario(con, "admin", "Administrador del Sistema", "admin123", Rol.Administrador);
                    CrearUsuario(con, "contador", "Contador General", "conta123", Rol.Contador);
                    CrearUsuario(con, "consulta", "Usuario de Consulta", "consulta123", Rol.Consulta);
                }
            }
        }

        private static void CrearUsuario(System.Data.Common.DbConnection con, string usuario, string nombre, string clave, string rol)
        {
            string salt = Hash.GenerarSalt();
            string hash = Hash.Calcular(clave, salt);
            using var cmd = Db.Cmd(
                @"INSERT INTO Usuarios (NombreUsuario, NombreCompleto, ClaveHash, Salt, IdRol, Activo)
                  SELECT @u, @n, @h, @s, IdRol, 1 FROM Roles WHERE Nombre = @r", con);
            Db.P(cmd, "@u", usuario);
            Db.P(cmd, "@n", nombre);
            Db.P(cmd, "@h", hash);
            Db.P(cmd, "@s", salt);
            Db.P(cmd, "@r", rol);
            cmd.ExecuteNonQuery();
        }

        private static void EjecutarSql(SqlConnection con, string sql)
        {
            using var cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
        }

        private static void TryDelete(string ruta)
        {
            try { if (File.Exists(ruta)) File.Delete(ruta); }
            catch { }
        }

        private static IEnumerable<(string codigo, string nombre, string padre, bool detalle)> CatalogoSemilla()
        {
            return new (string, string, string, bool)[]
            {
                ("1101", "Efectivo y Equivalente",          null,   false),
                ("110101", "Caja",                          "1101", true),
                ("110102", "Banco",                         "1101", true),
                ("1102", "Cuentas por Cobrar",              null,   false),
                ("110201", "Clientes",                      "1102", true),
                ("1103", "Inventarios",                     null,   true),
                ("1104", "IVA / Impuestos por Cobrar",      null,   false),
                ("110401", "IVA Crédito Fiscal",            "1104", true),
                ("110402", "IVA Remanente Fiscal",          "1104", true),
                ("1105", "Gasto por Pago Anticipado",       null,   false),
                ("110501", "Alquiler",                      "1105", true),
                ("1201", "Propiedad, Planta y Equipo",      null,   false),
                ("120101", "Mobiliario y Equipo de Oficina","1201", true),
                ("120102", "Equipo de Transporte",          "1201", true),
                ("2101", "Cuentas por Pagar",               null,   false),
                ("210101", "Acreedores Varios",             "2101", true),
                ("210102", "Proveedores",                   "2101", true),
                ("2102", "Préstamos Bancarios",             null,   true),
                ("2103", "IVA / Impuestos por Pagar",       null,   false),
                ("210301", "IVA Débito Fiscal",             "2103", true),
                ("210302", "IVA por Pagar",                 "2103", true),
                ("3101", "Capital Social",                  null,   true),
                ("4101", "Compras",                         null,   true),
                ("4102", "Gasto de Compra",                 null,   true),
                ("4103", "Devolución sobre Venta",          null,   true),
                ("4201", "Gasto Administrativo",            null,   false),
                ("420101", "Cheque",                        "4201", true),
                ("4202", "Gasto de Venta",                  null,   false),
                ("420201", "Facturas",                      "4202", true),
                ("4301", "Gasto Financiero",                null,   false),
                ("430101", "Comisión",                      "4301", true),
                ("5101", "Ventas",                          null,   true),
                ("5102", "Devolución sobre Compra",         null,   true),
            };
        }
    }
}
