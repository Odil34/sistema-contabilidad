using System.Configuration;
using Microsoft.Data.SqlClient;

namespace sistema_contabilidad.Datos
{
    /// <summary>
    /// Centraliza la cadena de conexión y la creación de conexiones a SQL Server.
    /// </summary>
    public static class ConexionBD
    {
        private const string NombreConexion = "SistemaContabilidad";

        /// <summary>Cadena de conexión hacia la base de datos (leída de App.config).</summary>
        public static string CadenaConexion
        {
            get
            {
                var cfg = ConfigurationManager.ConnectionStrings[NombreConexion];
                if (cfg != null && !string.IsNullOrWhiteSpace(cfg.ConnectionString))
                    return cfg.ConnectionString;

                // Respaldo por si App.config no está disponible.
                return @"Server=(localdb)\MSSQLLocalDB;Database=SistemaContabilidadDB;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=True";
            }
        }

        /// <summary>Cadena de conexión hacia la base maestra (para crear la base si no existe).</summary>
        public static string CadenaConexionMaestra
        {
            get
            {
                var builder = new SqlConnectionStringBuilder(CadenaConexion) { InitialCatalog = "master" };
                return builder.ConnectionString;
            }
        }

        /// <summary>Nombre de la base de datos configurada.</summary>
        public static string NombreBaseDatos
        {
            get
            {
                var builder = new SqlConnectionStringBuilder(CadenaConexion);
                return string.IsNullOrEmpty(builder.InitialCatalog) ? "SistemaContabilidadDB" : builder.InitialCatalog;
            }
        }

        /// <summary>Devuelve una conexión abierta lista para usarse.</summary>
        public static SqlConnection ObtenerConexion()
        {
            var conexion = new SqlConnection(CadenaConexion);
            conexion.Open();
            return conexion;
        }
    }
}
