using System.IO;
using Microsoft.Data.SqlClient;

namespace sistema_contabilidad.Datos
{
    /// <summary>
    /// Crea la base de datos, las tablas y siembra el catálogo la primera vez que se ejecuta.
    /// Así el sistema funciona apenas se abre, sin pasos manuales de SQL (útil al compartir el .exe).
    /// </summary>
    public static class InicializadorBD
    {
        public static void Inicializar()
        {
            CrearBaseDatos();
            CrearTablas();
            SembrarCatalogo();
        }

        private static void CrearBaseDatos()
        {
            string db = ConexionBD.NombreBaseDatos;

            using var con = new SqlConnection(ConexionBD.CadenaConexionMaestra);
            con.Open();

            // Si la base ya está registrada, no hay nada que hacer.
            object dbId;
            using (var check = new SqlCommand("SELECT DB_ID(@n)", con))
            {
                check.Parameters.AddWithValue("@n", db);
                dbId = check.ExecuteScalar();
            }
            if (dbId != null && dbId != DBNull.Value) return;

            // Ruta por defecto de la instancia (donde el motor crea sus archivos de forma fiable).
            string dataPath;
            using (var c = new SqlCommand(
                "SELECT CAST(SERVERPROPERTY('InstanceDefaultDataPath') AS nvarchar(500))", con))
            {
                dataPath = c.ExecuteScalar() as string;
            }
            string mdf = string.IsNullOrEmpty(dataPath) ? null : Path.Combine(dataPath, db + ".mdf");
            string ldf = string.IsNullOrEmpty(dataPath) ? null : Path.Combine(dataPath, db + "_log.ldf");

            // Si quedó un archivo de una ejecución anterior, se adjunta en lugar de fallar.
            if (mdf != null && File.Exists(mdf))
            {
                try
                {
                    Ejecutar(con, $"CREATE DATABASE [{db}] ON (FILENAME = N'{mdf}') FOR ATTACH_REBUILD_LOG;");
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
                Ejecutar(con, $"CREATE DATABASE [{db}];");
            }
            catch (SqlException) when (mdf != null && File.Exists(mdf))
            {
                Ejecutar(con, $"CREATE DATABASE [{db}] ON (FILENAME = N'{mdf}') FOR ATTACH_REBUILD_LOG;");
            }
        }

        private static void CrearTablas()
        {
            using var con = ConexionBD.ObtenerConexion();

            string sql = @"
IF OBJECT_ID('dbo.Cuentas', 'U') IS NULL
CREATE TABLE dbo.Cuentas (
    Codigo       NVARCHAR(10)  NOT NULL PRIMARY KEY,
    Nombre       NVARCHAR(150) NOT NULL,
    CodigoPadre  NVARCHAR(10)  NULL,
    Tipo         INT           NOT NULL,
    Naturaleza   NVARCHAR(10)  NOT NULL,
    EsDetalle    BIT           NOT NULL DEFAULT 1
);

IF OBJECT_ID('dbo.Asientos', 'U') IS NULL
CREATE TABLE dbo.Asientos (
    IdAsiento     INT           IDENTITY(1,1) PRIMARY KEY,
    Numero        INT           NOT NULL,
    Fecha         DATE          NOT NULL,
    Concepto      NVARCHAR(300) NOT NULL,
    FechaRegistro DATETIME      NOT NULL DEFAULT GETDATE()
);

IF OBJECT_ID('dbo.AsientoDetalle', 'U') IS NULL
CREATE TABLE dbo.AsientoDetalle (
    IdDetalle    INT           IDENTITY(1,1) PRIMARY KEY,
    IdAsiento    INT           NOT NULL,
    CodigoCuenta NVARCHAR(10)  NOT NULL,
    Concepto     NVARCHAR(300) NULL,
    Debe         DECIMAL(18,2) NOT NULL DEFAULT 0,
    Haber        DECIMAL(18,2) NOT NULL DEFAULT 0,
    CONSTRAINT FK_Detalle_Asiento FOREIGN KEY (IdAsiento)
        REFERENCES dbo.Asientos(IdAsiento) ON DELETE CASCADE,
    CONSTRAINT FK_Detalle_Cuenta FOREIGN KEY (CodigoCuenta)
        REFERENCES dbo.Cuentas(Codigo)
);";

            using var cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
        }

        private static void SembrarCatalogo()
        {
            using var con = ConexionBD.ObtenerConexion();

            using (var check = new SqlCommand("SELECT COUNT(*) FROM dbo.Cuentas", con))
            {
                if ((int)check.ExecuteScalar() > 0) return;
            }

            foreach (var c in CatalogoSemilla())
            {
                int tipo = c.codigo[0] - '0';
                string naturaleza = (tipo == 1 || tipo == 4) ? "Deudora" : "Acreedora";
                using var cmd = new SqlCommand(
                    @"INSERT INTO dbo.Cuentas (Codigo, Nombre, CodigoPadre, Tipo, Naturaleza, EsDetalle)
                      VALUES (@cod, @nom, @padre, @tipo, @nat, @det);", con);
                cmd.Parameters.AddWithValue("@cod", c.codigo);
                cmd.Parameters.AddWithValue("@nom", c.nombre);
                cmd.Parameters.AddWithValue("@padre", (object)c.padre ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@tipo", tipo);
                cmd.Parameters.AddWithValue("@nat", naturaleza);
                cmd.Parameters.AddWithValue("@det", c.detalle);
                cmd.ExecuteNonQuery();
            }
        }

        private static void Ejecutar(SqlConnection con, string sql)
        {
            using var cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
        }

        private static void TryDelete(string ruta)
        {
            try { if (File.Exists(ruta)) File.Delete(ruta); }
            catch { /* si está bloqueado, el CREATE informará el problema */ }
        }

        /// <summary>
        /// Catálogo de cuentas tomado del archivo "Cuentas conta.xlsx".
        /// Clasificación por primer dígito: 1 Activo, 2 Pasivo, 3 Capital, 4 Costos/Gastos, 5 Ingresos.
        /// </summary>
        private static IEnumerable<(string codigo, string nombre, string padre, bool detalle)> CatalogoSemilla()
        {
            return new (string, string, string, bool)[]
            {
                // ===== 1 ACTIVO =====
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

                // ===== 2 PASIVO =====
                ("2101", "Cuentas por Pagar",               null,   false),
                ("210101", "Acreedores Varios",             "2101", true),
                ("210102", "Proveedores",                   "2101", true),
                ("2102", "Préstamos Bancarios",             null,   true),
                ("2103", "IVA / Impuestos por Pagar",       null,   false),
                ("210301", "IVA Débito Fiscal",             "2103", true),
                ("210302", "IVA por Pagar",                 "2103", true),

                // ===== 3 CAPITAL =====
                ("3101", "Capital Social",                  null,   true),

                // ===== 4 COSTOS Y GASTOS =====
                ("4101", "Compras",                         null,   true),
                ("4102", "Gasto de Compra",                 null,   true),
                ("4103", "Devolución sobre Venta",          null,   true),
                ("4201", "Gasto Administrativo",            null,   false),
                ("420101", "Cheque",                        "4201", true),
                ("4202", "Gasto de Venta",                  null,   false),
                ("420201", "Facturas",                      "4202", true),
                ("4301", "Gasto Financiero",                null,   false),
                ("430101", "Comisión",                      "4301", true),

                // ===== 5 INGRESOS =====
                ("5101", "Ventas",                          null,   true),
                ("5102", "Devolución sobre Compra",         null,   true),
            };
        }
    }
}
