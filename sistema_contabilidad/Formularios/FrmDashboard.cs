using sistema_contabilidad.Datos;

namespace sistema_contabilidad.Formularios
{
    /// <summary>
    /// Dashboard: muestra un resumen general (indicadores) para que la ventana principal
    /// no se vea vacía. Los números se leen en vivo de la base de datos.
    /// </summary>
    public partial class FrmDashboard : Form
    {
        private readonly DashboardDAL _dashboardDAL = new DashboardDAL();

        public FrmDashboard()
        {
            InitializeComponent();
        }

        private void FrmDashboard_Load(object sender, EventArgs e)
        {
            CargarIndicadores();
        }

        private void CargarIndicadores()
        {
            ResumenDashboard r = _dashboardDAL.ObtenerResumen();
            lblCuentas.Text = r.TotalCuentas.ToString();
            lblDetalle.Text = r.CuentasDetalle.ToString();
            lblAsientos.Text = r.TotalAsientos.ToString();
            lblMovimientos.Text = r.TotalMovimientos.ToString();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarIndicadores();
        }
    }
}
