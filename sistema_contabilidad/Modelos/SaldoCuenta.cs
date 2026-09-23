namespace sistema_contabilidad.Modelos
{
    public class SaldoCuenta
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string CodigoPadre { get; set; }
        public string NombrePadre { get; set; }
        public string Naturaleza { get; set; }
        public int Tipo { get; set; }
        public decimal TotalDebe { get; set; }
        public decimal TotalHaber { get; set; }

        public decimal Saldo => Naturaleza == "Deudora"
            ? TotalDebe - TotalHaber
            : TotalHaber - TotalDebe;

        public string TipoSaldo
        {
            get
            {
                decimal neto = TotalDebe - TotalHaber;
                if (neto > 0) return "Deudor";
                if (neto < 0) return "Acreedor";
                return "-";
            }
        }

        public decimal SaldoDeudor => (TotalDebe - TotalHaber) > 0 ? TotalDebe - TotalHaber : 0;
        public decimal SaldoAcreedor => (TotalHaber - TotalDebe) > 0 ? TotalHaber - TotalDebe : 0;

        public string CodigoGrupo => string.IsNullOrEmpty(CodigoPadre) ? Codigo : CodigoPadre;
        public string NombreGrupo => string.IsNullOrEmpty(NombrePadre) ? Nombre : NombrePadre;
    }
}
