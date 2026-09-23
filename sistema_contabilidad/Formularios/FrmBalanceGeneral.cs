using sistema_contabilidad.Datos;
using sistema_contabilidad.Modelos;
using sistema_contabilidad.Utilidades;

namespace sistema_contabilidad.Formularios
{
    public partial class FrmBalanceGeneral : Form
    {
        private readonly ReporteDAL _reporteDAL = new ReporteDAL();

        public FrmBalanceGeneral()
        {
            InitializeComponent();
        }

        private void FrmBalanceGeneral_Load(object sender, EventArgs e)
        {
            dtpHasta.Value = DateTime.Today;
            GenerarReporte();
        }

        private void GenerarReporte()
        {
            List<SaldoCuenta> saldos = _reporteDAL.ObtenerSaldos(dtpHasta.Value);
            var activos = saldos.Where(s => s.Tipo == 1).ToList();
            var pasivos = saldos.Where(s => s.Tipo == 2).ToList();
            var capital = saldos.Where(s => s.Tipo == 3).ToList();

            decimal utilidad = saldos.Where(s => s.Tipo == 5).Sum(s => s.Saldo)
                             - saldos.Where(s => s.Tipo == 4).Sum(s => s.Saldo);

            var t = EstiloReporte.CrearTabla();

            EstiloReporte.Agregar(t, "ACTIVO (código 1)", null, EstiloReporte.Encabezado);
            decimal totalActivo = ReporteFinanciero.AgregarGrupo(t, activos);
            EstiloReporte.Agregar(t, "TOTAL ACTIVO", totalActivo, EstiloReporte.Total);

            EstiloReporte.Agregar(t, "", null);
            EstiloReporte.Agregar(t, "PASIVO (código 2)", null, EstiloReporte.Encabezado);
            decimal totalPasivo = ReporteFinanciero.AgregarGrupo(t, pasivos);
            EstiloReporte.Agregar(t, "Total Pasivo", totalPasivo, EstiloReporte.Total);

            EstiloReporte.Agregar(t, "", null);
            EstiloReporte.Agregar(t, "CAPITAL CONTABLE (código 3)", null, EstiloReporte.Encabezado);
            decimal totalCapitalContable = ReporteFinanciero.AgregarGrupo(t, capital);
            string etqUtil = utilidad >= 0 ? "Utilidad del ejercicio" : "Pérdida del ejercicio";
            EstiloReporte.Agregar(t, etqUtil, utilidad, EstiloReporte.Grupo);
            decimal totalCapital = totalCapitalContable + utilidad;
            EstiloReporte.Agregar(t, "Total Capital", totalCapital, EstiloReporte.Total);

            decimal totalPasivoCapital = totalPasivo + totalCapital;
            EstiloReporte.Agregar(t, "", null);
            EstiloReporte.Agregar(t, "TOTAL PASIVO + CAPITAL", totalPasivoCapital, EstiloReporte.Resultado);

            dgvReporte.DataSource = t;
            EstiloReporte.Formatear(dgvReporte);

            decimal diferencia = totalActivo - totalPasivoCapital;
            bool cuadra = Math.Abs(diferencia) < 0.01m;
            lblCuadre.Text = cuadra
                ? $"✔ Balance cuadrado:  Activo {totalActivo:N2}  =  Pasivo + Capital {totalPasivoCapital:N2}"
                : $"✘ Balance descuadrado.  Activo {totalActivo:N2}  vs  Pasivo + Capital {totalPasivoCapital:N2}   (Dif: {diferencia:N2})";
            lblCuadre.ForeColor = cuadra
                ? Color.FromArgb(39, 128, 73)
                : Color.FromArgb(150, 40, 40);
        }

        private void btnActualizar_Click(object sender, EventArgs e) => GenerarReporte();

        private void btnExportar_Click(object sender, EventArgs e) =>
            ExportadorReporte.ExportarCsv(dgvReporte, "Balance_General");
    }
}
