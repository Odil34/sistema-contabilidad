namespace sistema_contabilidad.Modelos
{
    public class Rol
    {
        public const string Administrador = "Administrador";
        public const string Contador = "Contador";
        public const string Consulta = "Consulta";

        public int IdRol { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public override string ToString() => Nombre;
    }
}
