namespace sistema_contabilidad.Modelos
{
    public class Asiento
    {
        public int IdAsiento { get; set; }
        public int Numero { get; set; }
        public DateTime Fecha { get; set; }
        public string Concepto { get; set; }
        public List<AsientoDetalle> Detalles { get; set; } = new List<AsientoDetalle>();

        public decimal TotalDebe => Detalles.Sum(d => d.Debe);
        public decimal TotalHaber => Detalles.Sum(d => d.Haber);
        public bool CumplePartidaDoble => TotalDebe == TotalHaber && TotalDebe > 0;
    }

    public class AsientoDetalle
    {
        public int IdDetalle { get; set; }
        public int IdAsiento { get; set; }
        public string CodigoCuenta { get; set; }
        public string NombreCuenta { get; set; }
        public string Concepto { get; set; }
        public decimal Debe { get; set; }
        public decimal Haber { get; set; }
    }
}
