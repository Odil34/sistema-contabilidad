using System.Data;
using sistema_contabilidad.Modelos;
using sistema_contabilidad.Seguridad;

namespace sistema_contabilidad.Datos
{
    public class UsuarioDAL
    {
        public Usuario Autenticar(string nombreUsuario, string clave)
        {
            using var con = Db.Abrir();
            using var cmd = Db.Cmd(
                @"SELECT u.IdUsuario, u.NombreUsuario, u.NombreCompleto, u.ClaveHash, u.Salt,
                         u.IdRol, r.Nombre, u.Activo
                  FROM Usuarios u
                  INNER JOIN Roles r ON r.IdRol = u.IdRol
                  WHERE u.NombreUsuario = @u", con);
            Db.P(cmd, "@u", nombreUsuario);

            using var dr = cmd.ExecuteReader();
            if (!dr.Read()) return null;

            bool activo = Db.Bool(dr, 7);
            if (!activo) return null;

            string hash = Db.Str(dr, 3);
            string salt = Db.Str(dr, 4);
            if (!Hash.Verificar(clave, salt, hash)) return null;

            return new Usuario
            {
                IdUsuario = Db.Int(dr, 0),
                NombreUsuario = Db.Str(dr, 1),
                NombreCompleto = Db.Str(dr, 2) ?? "",
                IdRol = Db.Int(dr, 5),
                Rol = Db.Str(dr, 6),
                Activo = activo
            };
        }

        public List<Rol> ListarRoles()
        {
            var lista = new List<Rol>();
            using var con = Db.Abrir();
            using var cmd = Db.Cmd("SELECT IdRol, Nombre, Descripcion FROM Roles ORDER BY IdRol", con);
            using var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(new Rol
                {
                    IdRol = Db.Int(dr, 0),
                    Nombre = Db.Str(dr, 1),
                    Descripcion = Db.Str(dr, 2) ?? ""
                });
            }
            return lista;
        }

        public DataTable ObtenerTabla()
        {
            using var con = Db.Abrir();
            using var cmd = Db.Cmd(
                @"SELECT u.IdUsuario AS [Id], u.NombreUsuario AS [Usuario], u.NombreCompleto AS [Nombre completo],
                         r.Nombre AS [Rol], CASE WHEN u.Activo = 1 THEN 'Activo' ELSE 'Inactivo' END AS [Estado]
                  FROM Usuarios u
                  INNER JOIN Roles r ON r.IdRol = u.IdRol
                  ORDER BY u.NombreUsuario", con);
            return Db.Tabla(cmd);
        }

        public bool Existe(string nombreUsuario)
        {
            using var con = Db.Abrir();
            using var cmd = Db.Cmd("SELECT COUNT(*) FROM Usuarios WHERE NombreUsuario = @u", con);
            Db.P(cmd, "@u", nombreUsuario);
            return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        }

        public void Crear(string nombreUsuario, string nombreCompleto, string clave, int idRol)
        {
            string salt = Hash.GenerarSalt();
            string hash = Hash.Calcular(clave, salt);

            using var con = Db.Abrir();
            using var cmd = Db.Cmd(
                @"INSERT INTO Usuarios (NombreUsuario, NombreCompleto, ClaveHash, Salt, IdRol, Activo)
                  VALUES (@u, @n, @h, @s, @r, 1)", con);
            Db.P(cmd, "@u", nombreUsuario);
            Db.P(cmd, "@n", nombreCompleto);
            Db.P(cmd, "@h", hash);
            Db.P(cmd, "@s", salt);
            Db.P(cmd, "@r", idRol);
            cmd.ExecuteNonQuery();
        }

        public void CambiarEstado(int idUsuario, bool activo)
        {
            using var con = Db.Abrir();
            using var cmd = Db.Cmd("UPDATE Usuarios SET Activo = @a WHERE IdUsuario = @id", con);
            Db.P(cmd, "@a", activo ? 1 : 0);
            Db.P(cmd, "@id", idUsuario);
            cmd.ExecuteNonQuery();
        }

        public void CambiarClave(int idUsuario, string nuevaClave)
        {
            string salt = Hash.GenerarSalt();
            string hash = Hash.Calcular(nuevaClave, salt);
            using var con = Db.Abrir();
            using var cmd = Db.Cmd("UPDATE Usuarios SET ClaveHash = @h, Salt = @s WHERE IdUsuario = @id", con);
            Db.P(cmd, "@h", hash);
            Db.P(cmd, "@s", salt);
            Db.P(cmd, "@id", idUsuario);
            cmd.ExecuteNonQuery();
        }
    }
}
