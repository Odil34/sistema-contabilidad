namespace sistema_contabilidad.Modelos
{
    /// <summary>
    /// Representa una cuenta del catálogo contable.
    /// El primer dígito del código determina el tipo de cuenta:
    /// 1 = Activo, 2 = Pasivo, 3 = Capital, 4 = Costos y Gastos, 5 = Ingresos.
    /// </summary>
    public class Cuenta
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string CodigoPadre { get; set; }
        public bool EsDetalle { get; set; }

        /// <summary>Primer dígito del código (1..5).</summary>
        public int Tipo => string.IsNullOrEmpty(Codigo) ? 0 : Codigo[0] - '0';

        /// <summary>Nombre del tipo de cuenta según el primer dígito.</summary>
        public string TipoNombre => Tipo switch
        {
            1 => "Activo",
            2 => "Pasivo",
            3 => "Capital",
            4 => "Costos y Gastos",
            5 => "Ingresos",
            _ => "Sin clasificar"
        };

        /// <summary>
        /// Naturaleza contable de la cuenta.
        /// Activo y Costos/Gastos => Deudora. Pasivo, Capital e Ingresos => Acreedora.
        /// </summary>
        public string Naturaleza => (Tipo == 1 || Tipo == 4) ? "Deudora" : "Acreedora";

        public override string ToString() => $"{Codigo} - {Nombre}";
    }
}
