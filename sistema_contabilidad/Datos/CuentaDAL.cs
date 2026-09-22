using System.Data;
using Microsoft.Data.SqlClient;
using sistema_contabilidad.Modelos;

namespace sistema_contabilidad.Datos
{
    /// <summary>Acceso a datos del catálogo de cuentas.</summary>
    public class CuentaDAL
    {
        /// <summary>Devuelve todas las cuentas del catálogo ordenadas por código.</summary>
        public List<Cuenta> ListarTodas()
        {
            var lista = new List<Cuenta>();
            using var con = ConexionBD.ObtenerConexion();
            using var cmd = new SqlCommand(
                "SELECT Codigo, Nombre, CodigoPadre, EsDetalle FROM dbo.Cuentas ORDER BY Codigo", con);
            using var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(new Cuenta
                {
                    Codigo = dr.GetString(0),
                    Nombre = dr.GetString(1),
                    CodigoPadre = dr.IsDBNull(2) ? null : dr.GetString(2),
                    EsDetalle = dr.GetBoolean(3)
                });
            }
            return lista;
        }

        /// <summary>Devuelve solo las cuentas de detalle (las que admiten movimientos).</summary>
        public List<Cuenta> ListarDetalle()
        {
            var lista = new List<Cuenta>();
            using var con = ConexionBD.ObtenerConexion();
            using var cmd = new SqlCommand(
                "SELECT Codigo, Nombre, CodigoPadre, EsDetalle FROM dbo.Cuentas WHERE EsDetalle = 1 ORDER BY Codigo", con);
            using var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(new Cuenta
                {
                    Codigo = dr.GetString(0),
                    Nombre = dr.GetString(1),
                    CodigoPadre = dr.IsDBNull(2) ? null : dr.GetString(2),
                    EsDetalle = dr.GetBoolean(3)
                });
            }
            return lista;
        }

        /// <summary>Carga el catálogo dentro de un DataTable (para grillas de solo lectura).</summary>
        public DataTable ObtenerTabla()
        {
            var tabla = new DataTable();
            using var con = ConexionBD.ObtenerConexion();
            using var cmd = new SqlCommand(
                @"SELECT Codigo, Nombre,
                         CASE Tipo WHEN 1 THEN 'Activo' WHEN 2 THEN 'Pasivo' WHEN 3 THEN 'Capital'
                                   WHEN 4 THEN 'Costos y Gastos' WHEN 5 THEN 'Ingresos' ELSE 'Otro' END AS Clasificacion,
                         Naturaleza,
                         CASE WHEN EsDetalle = 1 THEN 'Sí' ELSE 'No' END AS Detalle
                  FROM dbo.Cuentas ORDER BY Codigo", con);
            using var da = new SqlDataAdapter(cmd);
            da.Fill(tabla);
            return tabla;
        }
    }
}
