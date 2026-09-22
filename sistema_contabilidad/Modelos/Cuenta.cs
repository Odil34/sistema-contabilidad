namespace sistema_contabilidad.Modelos
{
    public class Cuenta
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string CodigoPadre { get; set; }
        public string NombrePadre { get; set; }
        public bool EsDetalle { get; set; }

        public int Tipo => string.IsNullOrEmpty(Codigo) ? 0 : Codigo[0] - '0';

        public string TipoNombre => Tipo switch
        {
            1 => "Activo",
            2 => "Pasivo",
            3 => "Capital",
            4 => "Costos y Gastos",
            5 => "Ingresos",
            _ => "Sin clasificar"
        };

        public string Naturaleza => (Tipo == 1 || Tipo == 4) ? "Deudora" : "Acreedora";

        public string DescripcionSeleccion => string.IsNullOrEmpty(NombrePadre)
            ? $"{Codigo} - {Nombre}"
            : $"{Codigo} - {Nombre}   ({NombrePadre})";

        public override string ToString() => $"{Codigo} - {Nombre}";
    }
}
