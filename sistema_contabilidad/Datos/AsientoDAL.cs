using System.Data;
using sistema_contabilidad.Modelos;

namespace sistema_contabilidad.Datos
{
    public class AsientoDAL
    {
        public int SiguienteNumero()
        {
            using var con = Db.Abrir();
            using var cmd = Db.Cmd("SELECT COALESCE(MAX(Numero), 0) + 1 FROM Asientos", con);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public int Guardar(Asiento asiento)
        {
            if (!asiento.CumplePartidaDoble)
                throw new InvalidOperationException(
                    "El asiento no cumple la partida doble: el total del Debe debe ser igual al total del Haber.");

            using var con = Db.Abrir();
            using var tran = con.BeginTransaction();
            try
            {
                string idExpr = Db.EsSqlServer ? "SELECT CAST(SCOPE_IDENTITY() AS INT);" : "SELECT last_insert_rowid();";
                var cmdCab = Db.Cmd(
                    "INSERT INTO Asientos (Numero, Fecha, Concepto) VALUES (@num, @fecha, @concepto); " + idExpr, con, tran);
                Db.P(cmdCab, "@num", asiento.Numero);
                Db.P(cmdCab, "@fecha", Db.Fecha(asiento.Fecha));
                Db.P(cmdCab, "@concepto", asiento.Concepto ?? "");
                int idAsiento = Convert.ToInt32(cmdCab.ExecuteScalar());

                foreach (var d in asiento.Detalles)
                {
                    var cmdDet = Db.Cmd(
                        "INSERT INTO AsientoDetalle (IdAsiento, CodigoCuenta, Concepto, Debe, Haber) VALUES (@id, @cod, @con, @debe, @haber)", con, tran);
                    Db.P(cmdDet, "@id", idAsiento);
                    Db.P(cmdDet, "@cod", d.CodigoCuenta);
                    Db.P(cmdDet, "@con", d.Concepto);
                    Db.P(cmdDet, "@debe", d.Debe);
                    Db.P(cmdDet, "@haber", d.Haber);
                    cmdDet.ExecuteNonQuery();
                }

                tran.Commit();
                return idAsiento;
            }
            catch
            {
                tran.Rollback();
                throw;
            }
        }

        public void Eliminar(int idAsiento)
        {
            using var con = Db.Abrir();
            using var cmd = Db.Cmd("DELETE FROM Asientos WHERE IdAsiento = @id", con);
            Db.P(cmd, "@id", idAsiento);
            cmd.ExecuteNonQuery();
        }

        public DataTable ObtenerLibroDiario(DateTime desde, DateTime hasta)
        {
            using var con = Db.Abrir();
            using var cmd = Db.Cmd(
                @"SELECT a.Numero AS [N° Asiento], a.Fecha AS [Fecha], d.CodigoCuenta AS [Código],
                         c.Nombre AS [Cuenta], COALESCE(d.Concepto, a.Concepto) AS [Concepto],
                         d.Debe AS [Debe], d.Haber AS [Haber]
                  FROM Asientos a
                  INNER JOIN AsientoDetalle d ON d.IdAsiento = a.IdAsiento
                  INNER JOIN Cuentas c ON c.Codigo = d.CodigoCuenta
                  WHERE a.Fecha BETWEEN @desde AND @hasta
                  ORDER BY a.Fecha, a.Numero, d.IdDetalle", con);
            Db.P(cmd, "@desde", Db.Fecha(desde));
            Db.P(cmd, "@hasta", Db.Fecha(hasta));
            return Db.Tabla(cmd);
        }

        public DataTable ListarAsientos(DateTime desde, DateTime hasta)
        {
            using var con = Db.Abrir();
            using var cmd = Db.Cmd(
                @"SELECT a.IdAsiento AS [IdAsiento], a.Numero AS [N°], a.Fecha AS [Fecha], a.Concepto AS [Concepto],
                         SUM(d.Debe) AS [Total Debe], SUM(d.Haber) AS [Total Haber]
                  FROM Asientos a
                  INNER JOIN AsientoDetalle d ON d.IdAsiento = a.IdAsiento
                  WHERE a.Fecha BETWEEN @desde AND @hasta
                  GROUP BY a.IdAsiento, a.Numero, a.Fecha, a.Concepto
                  ORDER BY a.Numero", con);
            Db.P(cmd, "@desde", Db.Fecha(desde));
            Db.P(cmd, "@hasta", Db.Fecha(hasta));
            return Db.Tabla(cmd);
        }
    }
}
