using System.Data;
using sistema_contabilidad.Datos;
using sistema_contabilidad.Modelos;

namespace sistema_contabilidad.Formularios
{
    public partial class FrmLibroMayor : Form
    {
        private readonly ReporteDAL _reporteDAL = new ReporteDAL();
        private DataTable _tablaMayor;

        public FrmLibroMayor()
        {
            InitializeComponent();
        }

        private void FrmLibroMayor_Load(object sender, EventArgs e)
        {
            dtpHasta.Value = DateTime.Today;
            CargarMayor();
        }

        private void CargarMayor()
        {
            List<SaldoCuenta> saldos = _reporteDAL.ObtenerSaldos(dtpHasta.Value);

            var tabla = new DataTable();
            tabla.Columns.Add("Código", typeof(string));
            tabla.Columns.Add("Cuenta", typeof(string));
            tabla.Columns.Add("Debe", typeof(decimal));
            tabla.Columns.Add("Haber", typeof(decimal));
            tabla.Columns.Add("Saldo", typeof(decimal));
            tabla.Columns.Add("Naturaleza", typeof(string));

            foreach (var s in saldos)
                tabla.Rows.Add(s.Codigo, s.Nombre, s.TotalDebe, s.TotalHaber, s.Saldo, s.TipoSaldo);

            _tablaMayor = tabla;
            dgvMayor.DataSource = tabla;
            FormatearGrilla(dgvMayor);
            dgvMayor.Columns["Cuenta"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            AplicarFiltro();

            if (saldos.Count == 0)
                lblMovTitulo.Text = "No hay movimientos registrados";
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e) => AplicarFiltro();

        private void AplicarFiltro()
        {
            if (_tablaMayor == null) return;
            string texto = txtBuscar.Text.Replace("'", "''").Trim();
            _tablaMayor.DefaultView.RowFilter = string.IsNullOrEmpty(texto)
                ? ""
                : $"[Código] LIKE '%{texto}%' OR [Cuenta] LIKE '%{texto}%'";
        }

        private void dgvMayor_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMayor.CurrentRow == null || dgvMayor.CurrentRow.IsNewRow) return;

            string codigo = dgvMayor.CurrentRow.Cells["Código"].Value?.ToString();
            string nombre = dgvMayor.CurrentRow.Cells["Cuenta"].Value?.ToString();
            if (string.IsNullOrEmpty(codigo)) return;

            lblMovTitulo.Text = $"Detalle: {codigo} - {nombre}";
            var mov = _reporteDAL.ObtenerMovimientosCuenta(codigo, new DateTime(1900, 1, 1), dtpHasta.Value);
            dgvMovimientos.DataSource = mov;
            FormatearGrilla(dgvMovimientos);
            if (dgvMovimientos.Columns.Contains("Concepto"))
                dgvMovimientos.Columns["Concepto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarMayor();
        }

        private static void FormatearGrilla(DataGridView grid)
        {
            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 71, 115);
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font(grid.Font, FontStyle.Bold);
            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 243, 249);

            foreach (DataGridViewColumn col in grid.Columns)
            {
                if (col.ValueType == typeof(decimal))
                {
                    col.DefaultCellStyle.Format = "N2";
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
        }
    }
}
