using System.Data;
using sistema_contabilidad.Modelos;

namespace sistema_contabilidad.Datos
{
    public class ReporteDAL
    {
        public List<SaldoCuenta> ObtenerSaldos(DateTime hasta, bool soloConMovimiento = true)
        {
            var lista = new List<SaldoCuenta>();
            using var con = Db.Abrir();
            using var cmd = Db.Cmd(
                @"SELECT c.Codigo, c.Nombre, c.Naturaleza, c.Tipo, c.CodigoPadre, COALESCE(p.Nombre, ''),
                         COALESCE(SUM(d.Debe), 0)  AS TotalDebe,
                         COALESCE(SUM(d.Haber), 0) AS TotalHaber
                  FROM Cuentas c
                  LEFT JOIN Cuentas p ON p.Codigo = c.CodigoPadre
                  LEFT JOIN AsientoDetalle d ON d.CodigoCuenta = c.Codigo
                  LEFT JOIN Asientos a ON a.IdAsiento = d.IdAsiento AND a.Fecha <= @hasta
                  WHERE c.EsDetalle = 1
                  GROUP BY c.Codigo, c.Nombre, c.Naturaleza, c.Tipo, c.CodigoPadre, p.Nombre
                  ORDER BY c.Codigo", con);
            Db.P(cmd, "@hasta", Db.Fecha(hasta));

            using var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string padreNom = Db.Str(dr, 5);
                var s = new SaldoCuenta
                {
                    Codigo = Db.Str(dr, 0),
                    Nombre = Db.Str(dr, 1),
                    Naturaleza = Db.Str(dr, 2),
                    Tipo = Db.Int(dr, 3),
                    CodigoPadre = Db.Str(dr, 4),
                    NombrePadre = string.IsNullOrEmpty(padreNom) ? null : padreNom,
                    TotalDebe = Db.Dec(dr, 6),
                    TotalHaber = Db.Dec(dr, 7)
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

            using var con = Db.Abrir();
            using var cmd = Db.Cmd(
                @"SELECT a.Fecha, a.Numero, COALESCE(d.Concepto, a.Concepto) AS Concepto, d.Debe, d.Haber
                  FROM AsientoDetalle d
                  INNER JOIN Asientos a ON a.IdAsiento = d.IdAsiento
                  WHERE d.CodigoCuenta = @cod AND a.Fecha BETWEEN @desde AND @hasta
                  ORDER BY a.Fecha, a.Numero, d.IdDetalle", con);
            Db.P(cmd, "@cod", codigo);
            Db.P(cmd, "@desde", Db.Fecha(desde));
            Db.P(cmd, "@hasta", Db.Fecha(hasta));

            decimal saldo = 0;
            using var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                decimal debe = Db.Dec(dr, 3);
                decimal haber = Db.Dec(dr, 4);
                saldo += deudora ? (debe - haber) : (haber - debe);
                tabla.Rows.Add(Db.Fecha(dr, 0), Db.Int(dr, 1), Db.Str(dr, 2), debe, haber, saldo);
            }
            return tabla;
        }
    }
}
