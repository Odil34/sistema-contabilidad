using System.Data;
using sistema_contabilidad.Datos;
using sistema_contabilidad.Utilidades;

namespace sistema_contabilidad.Formularios
{
    public partial class FrmConsultaDiario : Form
    {
        private readonly AsientoDAL _asientoDAL = new AsientoDAL();
        private DataTable _tabla;

        public FrmConsultaDiario()
        {
            InitializeComponent();
        }

        private void FrmConsultaDiario_Load(object sender, EventArgs e)
        {
            dtpDesde.Value = new DateTime(DateTime.Today.Year, 1, 1);
            dtpHasta.Value = DateTime.Today;
            Cargar();
        }

        private void Cargar()
        {
            _tabla = _asientoDAL.ObtenerLibroDiario(dtpDesde.Value, dtpHasta.Value);
            dgvDiario.DataSource = _tabla;

            dgvDiario.EnableHeadersVisualStyles = false;
            dgvDiario.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 71, 115);
            dgvDiario.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvDiario.ColumnHeadersDefaultCellStyle.Font = new Font(dgvDiario.Font, FontStyle.Bold);
            dgvDiario.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 243, 249);
            if (dgvDiario.Columns.Contains("Cuenta"))
                dgvDiario.Columns["Cuenta"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            foreach (DataGridViewColumn col in dgvDiario.Columns)
            {
                if (col.ValueType == typeof(decimal))
                {
                    col.DefaultCellStyle.Format = "N2";
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }

            AplicarFiltro();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e) => AplicarFiltro();

        private void AplicarFiltro()
        {
            if (_tabla == null) return;
            string texto = txtBuscar.Text.Replace("'", "''").Trim();
            _tabla.DefaultView.RowFilter = string.IsNullOrEmpty(texto)
                ? ""
                : $"[Código] LIKE '%{texto}%' OR [Cuenta] LIKE '%{texto}%' OR [Concepto] LIKE '%{texto}%' OR CONVERT([N° Asiento], 'System.String') LIKE '%{texto}%'";

            ActualizarTotales();
        }

        private void ActualizarTotales()
        {
            decimal debe = 0, haber = 0;
            foreach (DataRowView fila in _tabla.DefaultView)
            {
                debe += Convert.ToDecimal(fila["Debe"]);
                haber += Convert.ToDecimal(fila["Haber"]);
            }
            lblTotales.Text = $"Movimientos: {_tabla.DefaultView.Count}    Total Debe: {debe:N2}    Total Haber: {haber:N2}";
        }

        private void btnActualizar_Click(object sender, EventArgs e) => Cargar();

        private void btnExportar_Click(object sender, EventArgs e) =>
            ExportadorReporte.ExportarCsv(dgvDiario, "Libro_Diario");
    }
}
