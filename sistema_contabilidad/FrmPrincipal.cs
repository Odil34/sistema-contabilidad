using sistema_contabilidad.Formularios;
using sistema_contabilidad.Seguridad;

namespace sistema_contabilidad
{
    public partial class FrmPrincipal : Form
    {
        public bool CerrarSesionSolicitada { get; private set; }

        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            var u = Sesion.Actual;
            menuLibroDiario.Enabled = u.PuedeRegistrar;
            menuUsuarios.Enabled = u.PuedeGestionarUsuarios;
            Text = $"Sistema de Contabilidad  —  {u.Rol}";

            lblEstado.Text = $"Usuario: {u.NombreUsuario}  ·  Rol: {u.Rol}  |  Base: {Datos.ConexionBD.NombreBaseDatos}";
            lblFecha.Text = DateTime.Now.ToString("dddd, dd 'de' MMMM 'de' yyyy");
            AbrirHijo<FrmDashboard>();
        }

        private void AbrirHijo<T>() where T : Form, new()
        {
            foreach (Form abierto in MdiChildren)
            {
                if (abierto is T)
                {
                    abierto.WindowState = FormWindowState.Maximized;
                    abierto.Activate();
                    return;
                }
            }

            var hijo = new T { MdiParent = this };
            hijo.WindowState = FormWindowState.Maximized;
            hijo.Show();
            lblEstado.Text = "Módulo abierto: " + hijo.Text;
        }

        private void menuCatalogoCuentas_Click(object sender, EventArgs e) => AbrirHijo<FrmCatalogo>();

        private void menuLibroDiario_Click(object sender, EventArgs e) => AbrirHijo<FrmLibroDiario>();

        private void menuLibroMayor_Click(object sender, EventArgs e) => AbrirHijo<FrmLibroMayor>();

        private void menuBalanceComprobacion_Click(object sender, EventArgs e) => AbrirHijo<FrmBalanceComprobacion>();

        private void menuBalanceGeneral_Click(object sender, EventArgs e) => AbrirHijo<FrmBalanceGeneral>();

        private void menuEstadoResultados_Click(object sender, EventArgs e) => AbrirHijo<FrmEstadoResultados>();

        private void menuDashboard_Click(object sender, EventArgs e) => AbrirHijo<FrmDashboard>();

        private void menuUsuarios_Click(object sender, EventArgs e)
        {
            if (!Sesion.Actual.PuedeGestionarUsuarios)
            {
                MessageBox.Show("No tiene permisos para gestionar usuarios.", "Acceso denegado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            AbrirHijo<FrmUsuarios>();
        }

        private void menuCerrarSesion_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea cerrar la sesión actual?", "Cerrar sesión",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CerrarSesionSolicitada = true;
                Close();
            }
        }

        private void menuAcercaDe_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Sistema de Contabilidad v1.0\n\n" +
                "Módulos: Seguridad (usuarios y roles), Libro Diario (partida doble),\n" +
                "Mayorización, Estados Financieros y Salud Financiera.\n\n" +
                "Desarrollado con C# Windows Forms (MDI) y SQL Server.",
                "Acerca de", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void menuSalir_Click(object sender, EventArgs e) => Application.Exit();
    }
}
