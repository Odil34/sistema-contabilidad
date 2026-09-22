using sistema_contabilidad.Datos;

namespace sistema_contabilidad.Formularios
{
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
                dgvCuentas.Columns["Código"].Width = 90;
                dgvCuentas.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvCuentas.Columns["Nivel"].Width = 90;
                dgvCuentas.EnableHeadersVisualStyles = false;
                dgvCuentas.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 71, 115);
                dgvCuentas.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgvCuentas.ColumnHeadersDefaultCellStyle.Font = new Font(dgvCuentas.Font, FontStyle.Bold);

                foreach (DataGridViewRow fila in dgvCuentas.Rows)
                {
                    if (fila.Cells["Nivel"].Value?.ToString() == "Principal")
                    {
                        fila.DefaultCellStyle.BackColor = Color.FromArgb(219, 229, 241);
                        fila.DefaultCellStyle.Font = new Font(dgvCuentas.Font, FontStyle.Bold);
                    }
                }
            }

            lblResumen.Text = $"Total de cuentas: {tabla.Rows.Count}   (las cuentas Principales aparecen resaltadas y sus subcuentas indentadas)";
        }
    }
}
