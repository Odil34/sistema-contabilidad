using System.Data;
using Microsoft.Data.SqlClient;
using sistema_contabilidad.Modelos;

namespace sistema_contabilidad.Datos
{
    public class ReporteDAL
    {
        public List<SaldoCuenta> ObtenerSaldos(DateTime hasta, bool soloConMovimiento = true)
        {
            var lista = new List<SaldoCuenta>();
            using var con = ConexionBD.ObtenerConexion();
            using var cmd = new SqlCommand(
                @"SELECT c.Codigo, c.Nombre, c.Naturaleza, c.Tipo,
                         ISNULL(SUM(d.Debe), 0)  AS TotalDebe,
                         ISNULL(SUM(d.Haber), 0) AS TotalHaber
                  FROM dbo.Cuentas c
                  LEFT JOIN dbo.AsientoDetalle d ON d.CodigoCuenta = c.Codigo
                  LEFT JOIN dbo.Asientos a ON a.IdAsiento = d.IdAsiento AND a.Fecha <= @hasta
                  WHERE c.EsDetalle = 1
                  GROUP BY c.Codigo, c.Nombre, c.Naturaleza, c.Tipo
                  ORDER BY c.Codigo", con);
            cmd.Parameters.AddWithValue("@hasta", hasta.Date);
            using var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                var s = new SaldoCuenta
                {
                    Codigo = dr.GetString(0),
                    Nombre = dr.GetString(1),
                    Naturaleza = dr.GetString(2),
                    Tipo = dr.GetInt32(3),
                    TotalDebe = dr.GetDecimal(4),
                    TotalHaber = dr.GetDecimal(5)
                };
                if (soloConMovimiento && s.TotalDebe == 0 && s.TotalHaber == 0)
                    continue;
                lista.Add(s);
            }
            return lista;
        }

        public DataTable ObtenerMovimientosCuenta(string codigo, DateTime desde, DateTime hasta)
        {
            var cuenta = new CuentaDAL().ListarTodas().Find(c => c.Codigo == codigo);
            bool deudora = cuenta == null || cuenta.Naturaleza == "Deudora";

            var tabla = new DataTable();
            tabla.Columns.Add("Fecha", typeof(DateTime));
            tabla.Columns.Add("N°", typeof(int));
            tabla.Columns.Add("Concepto", typeof(string));
            tabla.Columns.Add("Debe", typeof(decimal));
            tabla.Columns.Add("Haber", typeof(decimal));
            tabla.Columns.Add("Saldo", typeof(decimal));

            using var con = ConexionBD.ObtenerConexion();
            using var cmd = new SqlCommand(
                @"SELECT a.Fecha, a.Numero, ISNULL(d.Concepto, a.Concepto) AS Concepto, d.Debe, d.Haber
                  FROM dbo.AsientoDetalle d
                  INNER JOIN dbo.Asientos a ON a.IdAsiento = d.IdAsiento
                  WHERE d.CodigoCuenta = @cod AND a.Fecha BETWEEN @desde AND @hasta
                  ORDER BY a.Fecha, a.Numero, d.IdDetalle", con);
            cmd.Parameters.AddWithValue("@cod", codigo);
            cmd.Parameters.AddWithValue("@desde", desde.Date);
            cmd.Parameters.AddWithValue("@hasta", hasta.Date);

            decimal saldo = 0;
            using var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                decimal debe = dr.GetDecimal(3);
                decimal haber = dr.GetDecimal(4);
                saldo += deudora ? (debe - haber) : (haber - debe);
                tabla.Rows.Add(dr.GetDateTime(0), dr.GetInt32(1), dr.GetString(2), debe, haber, saldo);
            }
            return tabla;
        }
    }
}
