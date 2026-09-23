namespace sistema_contabilidad.Modelos
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string NombreCompleto { get; set; }
        public int IdRol { get; set; }
        public string Rol { get; set; }
        public bool Activo { get; set; }

        public bool EsAdministrador => Rol == Modelos.Rol.Administrador;
        public bool PuedeRegistrar => Rol == Modelos.Rol.Administrador || Rol == Modelos.Rol.Contador;
        public bool PuedeGestionarUsuarios => Rol == Modelos.Rol.Administrador;
    }
}
