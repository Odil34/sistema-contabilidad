using System.Data;
using sistema_contabilidad.Datos;
using sistema_contabilidad.Modelos;
using sistema_contabilidad.Utilidades;

namespace sistema_contabilidad.Formularios
{
    public partial class FrmBalanceComprobacion : Form
    {
        private readonly ReporteDAL _reporteDAL = new ReporteDAL();

        public FrmBalanceComprobacion()
        {
            InitializeComponent();
        }

        private void FrmBalanceComprobacion_Load(object sender, EventArgs e)
        {
            dtpHasta.Value = DateTime.Today;
            CargarBalance();
        }

        private void CargarBalance()
        {
            List<SaldoCuenta> saldos = _reporteDAL.ObtenerSaldos(dtpHasta.Value);

            var tabla = new DataTable();
            tabla.Columns.Add("Código", typeof(string));
            tabla.Columns.Add("Cuenta", typeof(string));
            tabla.Columns.Add("Debe", typeof(decimal));
            tabla.Columns.Add("Haber", typeof(decimal));
            tabla.Columns.Add("Saldo Deudor", typeof(decimal));
            tabla.Columns.Add("Saldo Acreedor", typeof(decimal));

            decimal tDebe = 0, tHaber = 0, tDeudor = 0, tAcreedor = 0;
            foreach (var s in saldos)
            {
                tabla.Rows.Add(s.Codigo, s.Nombre, s.TotalDebe, s.TotalHaber, s.SaldoDeudor, s.SaldoAcreedor);
                tDebe += s.TotalDebe;
                tHaber += s.TotalHaber;
                tDeudor += s.SaldoDeudor;
                tAcreedor += s.SaldoAcreedor;
            }

            dgvReporte.DataSource = tabla;
            FormatearGrilla(dgvReporte);
            dgvReporte.Columns["Cuenta"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            lblTotales.Text =
                $"Totales →  Debe: {tDebe:N2}    Haber: {tHaber:N2}    " +
                $"Saldo Deudor: {tDeudor:N2}    Saldo Acreedor: {tAcreedor:N2}";

            bool cuadra = tDeudor == tAcreedor;
            lblEstadoCuadre.Text = cuadra
                ? "✔ El balance CUADRA (saldos deudores = saldos acreedores)."
                : $"✘ El balance NO cuadra. Diferencia: {(tDeudor - tAcreedor):N2}";
            lblEstadoCuadre.ForeColor = cuadra
                ? Color.FromArgb(39, 128, 73)
                : Color.FromArgb(150, 40, 40);
        }

        private void btnActualizar_Click(object sender, EventArgs e) => CargarBalance();

        private void btnExportar_Click(object sender, EventArgs e) =>
            ExportadorReporte.ExportarCsv(dgvReporte, "Balance_Comprobacion");

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
