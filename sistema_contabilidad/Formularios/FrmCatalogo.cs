using sistema_contabilidad.Datos;

namespace sistema_contabilidad.Formularios
{
    /// <summary>Muestra el catálogo de cuentas contables (solo lectura).</summary>
    public partial class FrmCatalogo : Form
    {
        private readonly CuentaDAL _cuentaDAL = new CuentaDAL();

        public FrmCatalogo()
        {
            InitializeComponent();
        }

        private void FrmCatalogo_Load(object sender, EventArgs e)
        {
            CargarCatalogo();
        }

        private void CargarCatalogo()
        {
            var tabla = _cuentaDAL.ObtenerTabla();
            dgvCuentas.DataSource = tabla;

            if (dgvCuentas.Columns.Count > 0)
            {
                dgvCuentas.Columns["Codigo"].HeaderText = "Código";
                dgvCuentas.Columns["Codigo"].Width = 90;
                dgvCuentas.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvCuentas.EnableHeadersVisualStyles = false;
                dgvCuentas.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 71, 115);
                dgvCuentas.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgvCuentas.ColumnHeadersDefaultCellStyle.Font = new Font(dgvCuentas.Font, FontStyle.Bold);
                dgvCuentas.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 243, 249);
            }

            lblResumen.Text = $"Total de cuentas: {tabla.Rows.Count}";
        }
    }
}
