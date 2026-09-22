using Microsoft.Data.SqlClient;

namespace sistema_contabilidad.Datos
{
    /// <summary>Indicadores resumidos que se muestran en el dashboard de la ventana principal.</summary>
    public class ResumenDashboard
    {
        public int TotalCuentas { get; set; }
        public int CuentasDetalle { get; set; }
        public int TotalAsientos { get; set; }
        public int TotalMovimientos { get; set; }
    }

    /// <summary>Acceso a datos para los indicadores del dashboard.</summary>
    public class DashboardDAL
    {
        public ResumenDashboard ObtenerResumen()
        {
            using var con = ConexionBD.ObtenerConexion();
            using var cmd = new SqlCommand(
                @"SELECT
                    (SELECT COUNT(*) FROM dbo.Cuentas),
                    (SELECT COUNT(*) FROM dbo.Cuentas WHERE EsDetalle = 1),
                    (SELECT COUNT(*) FROM dbo.Asientos),
                    (SELECT COUNT(*) FROM dbo.AsientoDetalle);", con);
            using var dr = cmd.ExecuteReader();
            dr.Read();
            return new ResumenDashboard
            {
                TotalCuentas = dr.GetInt32(0),
                CuentasDetalle = dr.GetInt32(1),
                TotalAsientos = dr.GetInt32(2),
                TotalMovimientos = dr.GetInt32(3)
            };
        }
    }
}
