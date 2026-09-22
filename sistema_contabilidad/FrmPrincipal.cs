using sistema_contabilidad.Formularios;

namespace sistema_contabilidad
{
    /// <summary>
    /// Ventana principal (contenedor MDI). Al abrir muestra el dashboard y desde su menú
    /// se abren los demás módulos como formularios hijos.
    /// </summary>
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            lblEstado.Text = "Base de datos: " + Datos.ConexionBD.NombreBaseDatos + "  |  Conectado";
            lblFecha.Text = DateTime.Now.ToString("dddd, dd 'de' MMMM 'de' yyyy");

            // Abre el dashboard automáticamente para que la ventana no se vea vacía.
            AbrirHijo<FrmDashboard>();
        }

        /// <summary>
        /// Abre un formulario hijo dentro del MDI. Si ya está abierto, solo lo activa
        /// (patrón de instancia única) para no duplicar ventanas.
        /// </summary>
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

        private void menuDashboard_Click(object sender, EventArgs e) => AbrirHijo<FrmDashboard>();

        private void menuAcercaDe_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Sistema de Contabilidad v1.0\n\n" +
                "Desarrollado con C# Windows Forms (MDI) y SQL Server.",
                "Acerca de", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void menuSalir_Click(object sender, EventArgs e) => Close();
    }
}
