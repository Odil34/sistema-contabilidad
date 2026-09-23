using System.Data;
using Microsoft.Data.SqlClient;
using sistema_contabilidad.Modelos;
using sistema_contabilidad.Seguridad;

namespace sistema_contabilidad.Datos
{
    public class UsuarioDAL
    {
        public Usuario Autenticar(string nombreUsuario, string clave)
        {
            using var con = ConexionBD.ObtenerConexion();
            using var cmd = new SqlCommand(
                @"SELECT u.IdUsuario, u.NombreUsuario, u.NombreCompleto, u.ClaveHash, u.Salt,
                         u.IdRol, r.Nombre AS Rol, u.Activo
                  FROM dbo.Usuarios u
                  INNER JOIN dbo.Roles r ON r.IdRol = u.IdRol
                  WHERE u.NombreUsuario = @u", con);
            cmd.Parameters.AddWithValue("@u", nombreUsuario);

            using var dr = cmd.ExecuteReader();
            if (!dr.Read()) return null;

            bool activo = dr.GetBoolean(dr.GetOrdinal("Activo"));
            if (!activo) return null;

            string hash = dr.GetString(dr.GetOrdinal("ClaveHash"));
            string salt = dr.GetString(dr.GetOrdinal("Salt"));
            if (!Hash.Verificar(clave, salt, hash)) return null;

            return new Usuario
            {
                IdUsuario = dr.GetInt32(dr.GetOrdinal("IdUsuario")),
                NombreUsuario = dr.GetString(dr.GetOrdinal("NombreUsuario")),
                NombreCompleto = dr.IsDBNull(dr.GetOrdinal("NombreCompleto")) ? "" : dr.GetString(dr.GetOrdinal("NombreCompleto")),
                IdRol = dr.GetInt32(dr.GetOrdinal("IdRol")),
                Rol = dr.GetString(dr.GetOrdinal("Rol")),
                Activo = activo
            };
        }

        public List<Rol> ListarRoles()
        {
            var lista = new List<Rol>();
            using var con = ConexionBD.ObtenerConexion();
            using var cmd = new SqlCommand("SELECT IdRol, Nombre, Descripcion FROM dbo.Roles ORDER BY IdRol", con);
            using var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(new Rol
                {
                    IdRol = dr.GetInt32(0),
                    Nombre = dr.GetString(1),
                    Descripcion = dr.IsDBNull(2) ? "" : dr.GetString(2)
                });
            }
            return lista;
        }

        public DataTable ObtenerTabla()
        {
            var tabla = new DataTable();
            using var con = ConexionBD.ObtenerConexion();
            using var cmd = new SqlCommand(
                @"SELECT u.IdUsuario AS [Id], u.NombreUsuario AS [Usuario], u.NombreCompleto AS [Nombre completo],
                         r.Nombre AS [Rol], CASE WHEN u.Activo = 1 THEN 'Activo' ELSE 'Inactivo' END AS [Estado]
                  FROM dbo.Usuarios u
                  INNER JOIN dbo.Roles r ON r.IdRol = u.IdRol
                  ORDER BY u.NombreUsuario", con);
            using var da = new SqlDataAdapter(cmd);
            da.Fill(tabla);
            return tabla;
        }

        public bool Existe(string nombreUsuario)
        {
            using var con = ConexionBD.ObtenerConexion();
            using var cmd = new SqlCommand("SELECT COUNT(*) FROM dbo.Usuarios WHERE NombreUsuario = @u", con);
            cmd.Parameters.AddWithValue("@u", nombreUsuario);
            return (int)cmd.ExecuteScalar() > 0;
        }

        public void Crear(string nombreUsuario, string nombreCompleto, string clave, int idRol)
        {
            string salt = Hash.GenerarSalt();
            string hash = Hash.Calcular(clave, salt);

            using var con = ConexionBD.ObtenerConexion();
            using var cmd = new SqlCommand(
                @"INSERT INTO dbo.Usuarios (NombreUsuario, NombreCompleto, ClaveHash, Salt, IdRol, Activo)
                  VALUES (@u, @n, @h, @s, @r, 1);", con);
            cmd.Parameters.AddWithValue("@u", nombreUsuario);
            cmd.Parameters.AddWithValue("@n", (object)nombreCompleto ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@h", hash);
            cmd.Parameters.AddWithValue("@s", salt);
            cmd.Parameters.AddWithValue("@r", idRol);
            cmd.ExecuteNonQuery();
        }

        public void CambiarEstado(int idUsuario, bool activo)
        {
            using var con = ConexionBD.ObtenerConexion();
            using var cmd = new SqlCommand("UPDATE dbo.Usuarios SET Activo = @a WHERE IdUsuario = @id", con);
            cmd.Parameters.AddWithValue("@a", activo);
            cmd.Parameters.AddWithValue("@id", idUsuario);
            cmd.ExecuteNonQuery();
        }

        public void CambiarClave(int idUsuario, string nuevaClave)
        {
            string salt = Hash.GenerarSalt();
            string hash = Hash.Calcular(nuevaClave, salt);
            using var con = ConexionBD.ObtenerConexion();
            using var cmd = new SqlCommand(
                "UPDATE dbo.Usuarios SET ClaveHash = @h, Salt = @s WHERE IdUsuario = @id", con);
            cmd.Parameters.AddWithValue("@h", hash);
            cmd.Parameters.AddWithValue("@s", salt);
            cmd.Parameters.AddWithValue("@id", idUsuario);
            cmd.ExecuteNonQuery();
        }
    }
}
