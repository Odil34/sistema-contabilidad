namespace sistema_contabilidad.Datos
{
    public class ResumenDashboard
    {
        public int TotalCuentas { get; set; }
        public int CuentasDetalle { get; set; }
        public int TotalAsientos { get; set; }
        public int TotalMovimientos { get; set; }
    }

    public class DashboardDAL
    {
        public ResumenDashboard ObtenerResumen()
        {
            using var con = Db.Abrir();
            using var cmd = Db.Cmd(
                @"SELECT
                    (SELECT COUNT(*) FROM Cuentas),
                    (SELECT COUNT(*) FROM Cuentas WHERE EsDetalle = 1),
                    (SELECT COUNT(*) FROM Asientos),
                    (SELECT COUNT(*) FROM AsientoDetalle)", con);
            using var dr = cmd.ExecuteReader();
            dr.Read();
            return new ResumenDashboard
            {
                TotalCuentas = Db.Int(dr, 0),
                CuentasDetalle = Db.Int(dr, 1),
                TotalAsientos = Db.Int(dr, 2),
                TotalMovimientos = Db.Int(dr, 3)
            };
        }
    }
}
