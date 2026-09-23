using sistema_contabilidad.Modelos;

namespace sistema_contabilidad.Seguridad
{
    public static class Sesion
    {
        public static Usuario Actual { get; set; }

        public static void Cerrar() => Actual = null;
    }
}
