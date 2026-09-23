using sistema_contabilidad.Datos;
using sistema_contabilidad.Modelos;
using sistema_contabilidad.Utilidades;

namespace sistema_contabilidad.Formularios
{
    public partial class FrmEstadoResultados : Form
    {
        private readonly ReporteDAL _reporteDAL = new ReporteDAL();

        public FrmEstadoResultados()
        {
            InitializeComponent();
        }

        private void FrmEstadoResultados_Load(object sender, EventArgs e)
        {
            dtpHasta.Value = DateTime.Today;
            GenerarReporte();
        }

        private void GenerarReporte()
        {
            List<SaldoCuenta> saldos = _reporteDAL.ObtenerSaldos(dtpHasta.Value);
            var ingresos = saldos.Where(s => s.Tipo == 5).ToList();
            var costosGastos = saldos.Where(s => s.Tipo == 4).ToList();

            var t = EstiloReporte.CrearTabla();

            EstiloReporte.Agregar(t, "INGRESOS (código 5)", null, EstiloReporte.Encabezado);
            decimal totalIngresos = ReporteFinanciero.AgregarGrupo(t, ingresos);
            EstiloReporte.Agregar(t, "Total Ingresos", totalIngresos, EstiloReporte.Total);

            EstiloReporte.Agregar(t, "", null);
            EstiloReporte.Agregar(t, "COSTOS Y GASTOS (código 4)", null, EstiloReporte.Encabezado);
            decimal totalCostosGastos = ReporteFinanciero.AgregarGrupo(t, costosGastos);
            EstiloReporte.Agregar(t, "Total Costos y Gastos", totalCostosGastos, EstiloReporte.Total);

            decimal utilidad = totalIngresos - totalCostosGastos;
            EstiloReporte.Agregar(t, "", null);
            string etiqueta = utilidad >= 0 ? "UTILIDAD DEL EJERCICIO" : "PÉRDIDA DEL EJERCICIO";
            EstiloReporte.Agregar(t, etiqueta, utilidad, EstiloReporte.Resultado);

            dgvReporte.DataSource = t;
            EstiloReporte.Formatear(dgvReporte);

            lblResultado.Text = $"{etiqueta}:   {utilidad:N2}";
            lblResultado.ForeColor = utilidad >= 0
                ? Color.FromArgb(39, 128, 73)
                : Color.FromArgb(150, 40, 40);
        }

        private void btnActualizar_Click(object sender, EventArgs e) => GenerarReporte();

        private void btnExportar_Click(object sender, EventArgs e) =>
            ExportadorReporte.ExportarCsv(dgvReporte, "Estado_Resultados");
    }
}
