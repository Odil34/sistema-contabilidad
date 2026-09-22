using System.Data;
using Microsoft.Data.SqlClient;
using sistema_contabilidad.Modelos;

namespace sistema_contabilidad.Datos
{
    public class CuentaDAL
    {
        public List<Cuenta> ListarTodas()
        {
            var lista = new List<Cuenta>();
            using var con = ConexionBD.ObtenerConexion();
            using var cmd = new SqlCommand(
                @"SELECT c.Codigo, c.Nombre, c.CodigoPadre, c.EsDetalle, ISNULL(p.Nombre, '')
                  FROM dbo.Cuentas c
                  LEFT JOIN dbo.Cuentas p ON p.Codigo = c.CodigoPadre
                  ORDER BY c.Codigo", con);
            using var dr = cmd.ExecuteReader();
            while (dr.Read())
                lista.Add(Mapear(dr));
            return lista;
        }

        public List<Cuenta> ListarDetalle()
        {
            var lista = new List<Cuenta>();
            using var con = ConexionBD.ObtenerConexion();
            using var cmd = new SqlCommand(
                @"SELECT c.Codigo, c.Nombre, c.CodigoPadre, c.EsDetalle, ISNULL(p.Nombre, '')
                  FROM dbo.Cuentas c
                  LEFT JOIN dbo.Cuentas p ON p.Codigo = c.CodigoPadre
                  WHERE c.EsDetalle = 1
                  ORDER BY c.Codigo", con);
            using var dr = cmd.ExecuteReader();
            while (dr.Read())
                lista.Add(Mapear(dr));
            return lista;
        }

        public DataTable ObtenerTabla()
        {
            var tabla = new DataTable();
            using var con = ConexionBD.ObtenerConexion();
            using var cmd = new SqlCommand(
                @"SELECT c.Codigo AS [Código],
                         CASE WHEN c.CodigoPadre IS NOT NULL THEN '      ' + c.Nombre ELSE c.Nombre END AS [Nombre],
                         CASE WHEN c.CodigoPadre IS NULL THEN 'Principal' ELSE 'Subcuenta' END AS [Nivel],
                         ISNULL(p.Nombre, '') AS [Cuenta Principal],
                         CASE c.Tipo WHEN 1 THEN 'Activo' WHEN 2 THEN 'Pasivo' WHEN 3 THEN 'Capital'
                                     WHEN 4 THEN 'Costos y Gastos' WHEN 5 THEN 'Ingresos' ELSE 'Otro' END AS [Clasificación],
                         c.Naturaleza AS [Naturaleza]
                  FROM dbo.Cuentas c
                  LEFT JOIN dbo.Cuentas p ON p.Codigo = c.CodigoPadre
                  ORDER BY c.Codigo", con);
            using var da = new SqlDataAdapter(cmd);
            da.Fill(tabla);
            return tabla;
        }

        private static Cuenta Mapear(SqlDataReader dr)
        {
            string padre = dr.GetString(4);
            return new Cuenta
            {
                Codigo = dr.GetString(0),
                Nombre = dr.GetString(1),
                CodigoPadre = dr.IsDBNull(2) ? null : dr.GetString(2),
                EsDetalle = dr.GetBoolean(3),
                NombrePadre = string.IsNullOrEmpty(padre) ? null : padre
            };
        }
    }
}
