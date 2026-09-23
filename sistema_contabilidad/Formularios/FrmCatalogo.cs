using System.Data;
using sistema_contabilidad.Datos;

namespace sistema_contabilidad.Formularios
{
    public partial class FrmCatalogo : Form
    {
        private readonly CuentaDAL _cuentaDAL = new CuentaDAL();
        private DataTable _tabla;

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
            _tabla = _cuentaDAL.ObtenerTabla();
            dgvCuentas.DataSource = _tabla;

            if (dgvCuentas.Columns.Count > 0)
            {
                dgvCuentas.Columns["Código"].Width = 90;
                dgvCuentas.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvCuentas.Columns["Nivel"].Width = 90;
                dgvCuentas.EnableHeadersVisualStyles = false;
                dgvCuentas.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 71, 115);
                dgvCuentas.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgvCuentas.ColumnHeadersDefaultCellStyle.Font = new Font(dgvCuentas.Font, FontStyle.Bold);
            }

            PintarPrincipales();
            lblResumen.Text = $"Total de cuentas: {_tabla.Rows.Count}   (las cuentas Principales aparecen resaltadas)";
        }

        private void PintarPrincipales()
        {
            foreach (DataGridViewRow fila in dgvCuentas.Rows)
            {
                if (fila.Cells["Nivel"].Value?.ToString() == "Principal")
                {
                    fila.DefaultCellStyle.BackColor = Color.FromArgb(219, 229, 241);
                    fila.DefaultCellStyle.Font = new Font(dgvCuentas.Font, FontStyle.Bold);
                }
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (_tabla == null) return;

            string texto = txtBuscar.Text.Replace("'", "''").Trim();
            _tabla.DefaultView.RowFilter = string.IsNullOrEmpty(texto)
                ? ""
                : $"[Código] LIKE '%{texto}%' OR [Nombre] LIKE '%{texto}%' OR [Cuenta Principal] LIKE '%{texto}%'";

            PintarPrincipales();
        }
    }
}
