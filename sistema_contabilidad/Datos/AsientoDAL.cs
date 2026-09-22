using System.Data;
using Microsoft.Data.SqlClient;
using sistema_contabilidad.Modelos;

namespace sistema_contabilidad.Datos
{
    public class AsientoDAL
    {
        public int SiguienteNumero()
        {
            using var con = ConexionBD.ObtenerConexion();
            using var cmd = new SqlCommand("SELECT ISNULL(MAX(Numero), 0) + 1 FROM dbo.Asientos", con);
            return (int)cmd.ExecuteScalar();
        }

        public int Guardar(Asiento asiento)
        {
            if (!asiento.CumplePartidaDoble)
                throw new InvalidOperationException(
                    "El asiento no cumple la partida doble: el total del Debe debe ser igual al total del Haber.");

            using var con = ConexionBD.ObtenerConexion();
            using var tran = con.BeginTransaction();
            try
            {
                var cmdCab = new SqlCommand(
                    @"INSERT INTO dbo.Asientos (Numero, Fecha, Concepto)
                      VALUES (@num, @fecha, @concepto);
                      SELECT CAST(SCOPE_IDENTITY() AS INT);", con, tran);
                cmdCab.Parameters.AddWithValue("@num", asiento.Numero);
                cmdCab.Parameters.AddWithValue("@fecha", asiento.Fecha.Date);
                cmdCab.Parameters.AddWithValue("@concepto", asiento.Concepto ?? "");
                int idAsiento = (int)cmdCab.ExecuteScalar();

                foreach (var d in asiento.Detalles)
                {
                    var cmdDet = new SqlCommand(
                        @"INSERT INTO dbo.AsientoDetalle (IdAsiento, CodigoCuenta, Concepto, Debe, Haber)
                          VALUES (@id, @cod, @con, @debe, @haber);", con, tran);
                    cmdDet.Parameters.AddWithValue("@id", idAsiento);
                    cmdDet.Parameters.AddWithValue("@cod", d.CodigoCuenta);
                    cmdDet.Parameters.AddWithValue("@con", (object)d.Concepto ?? DBNull.Value);
                    cmdDet.Parameters.AddWithValue("@debe", d.Debe);
                    cmdDet.Parameters.AddWithValue("@haber", d.Haber);
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
            using var con = ConexionBD.ObtenerConexion();
            using var cmd = new SqlCommand("DELETE FROM dbo.Asientos WHERE IdAsiento = @id", con);
            cmd.Parameters.AddWithValue("@id", idAsiento);
            cmd.ExecuteNonQuery();
        }

        public DataTable ObtenerLibroDiario(DateTime desde, DateTime hasta)
        {
            var tabla = new DataTable();
            using var con = ConexionBD.ObtenerConexion();
            using var cmd = new SqlCommand(
                @"SELECT a.Numero AS [N° Asiento], a.Fecha, d.CodigoCuenta AS [Código],
                         c.Nombre AS [Cuenta], ISNULL(d.Concepto, a.Concepto) AS [Concepto],
                         d.Debe, d.Haber
                  FROM dbo.Asientos a
                  INNER JOIN dbo.AsientoDetalle d ON d.IdAsiento = a.IdAsiento
                  INNER JOIN dbo.Cuentas c ON c.Codigo = d.CodigoCuenta
                  WHERE a.Fecha BETWEEN @desde AND @hasta
                  ORDER BY a.Fecha, a.Numero, d.IdDetalle", con);
            cmd.Parameters.AddWithValue("@desde", desde.Date);
            cmd.Parameters.AddWithValue("@hasta", hasta.Date);
            using var da = new SqlDataAdapter(cmd);
            da.Fill(tabla);
            return tabla;
        }

        public DataTable ListarAsientos(DateTime desde, DateTime hasta)
        {
            var tabla = new DataTable();
            using var con = ConexionBD.ObtenerConexion();
            using var cmd = new SqlCommand(
                @"SELECT a.IdAsiento, a.Numero AS [N°], a.Fecha, a.Concepto,
                         SUM(d.Debe) AS [Total Debe], SUM(d.Haber) AS [Total Haber]
                  FROM dbo.Asientos a
                  INNER JOIN dbo.AsientoDetalle d ON d.IdAsiento = a.IdAsiento
                  WHERE a.Fecha BETWEEN @desde AND @hasta
                  GROUP BY a.IdAsiento, a.Numero, a.Fecha, a.Concepto
                  ORDER BY a.Numero", con);
            cmd.Parameters.AddWithValue("@desde", desde.Date);
            cmd.Parameters.AddWithValue("@hasta", hasta.Date);
            using var da = new SqlDataAdapter(cmd);
            da.Fill(tabla);
            return tabla;
        }
    }
}
