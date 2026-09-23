using sistema_contabilidad.Datos;
using sistema_contabilidad.Modelos;
using sistema_contabilidad.Seguridad;

namespace sistema_contabilidad.Formularios
{
    public partial class FrmLogin : Form
    {
        private readonly UsuarioDAL _usuarioDAL = new UsuarioDAL();

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            string usuario = txtUsuario.Text.Trim();
            string clave = txtClave.Text;

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(clave))
            {
                lblError.Text = "Ingrese usuario y contraseña.";
                return;
            }

            try
            {
                Usuario autenticado = _usuarioDAL.Autenticar(usuario, clave);
                if (autenticado == null)
                {
                    lblError.Text = "Usuario o contraseña incorrectos, o usuario inactivo.";
                    txtClave.Clear();
                    txtClave.Focus();
                    return;
                }

                Sesion.Actual = autenticado;
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                lblError.Text = "Error al validar: " + ex.Message;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
