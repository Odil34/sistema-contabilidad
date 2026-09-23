using sistema_contabilidad.Datos;
using sistema_contabilidad.Modelos;

namespace sistema_contabilidad.Formularios
{
    public partial class FrmLiquidacionIva : Form
    {
        private readonly ReporteDAL _reporteDAL = new ReporteDAL();

        public FrmLiquidacionIva()
        {
            InitializeComponent();
        }

        private void FrmLiquidacionIva_Load(object sender, EventArgs e)
        {
            dtpHasta.Value = DateTime.Today;
            Calcular();
        }

        private void Calcular()
        {
            List<SaldoCuenta> saldos = _reporteDAL.ObtenerSaldos(dtpHasta.Value, soloConMovimiento: false);

            decimal debito = SaldoDe(saldos, "210301");
            decimal credito = SaldoDe(saldos, "110401");
            decimal remanente = SaldoDe(saldos, "110402");

            lblDebito.Text = debito.ToString("N2");
            lblCredito.Text = credito.ToString("N2");
            lblRemanente.Text = remanente.ToString("N2");

            decimal resultado = debito - credito - remanente;

            if (resultado > 0)
            {
                lblResultadoCap.Text = "IVA a pagar:";
                lblResultado.Text = resultado.ToString("N2");
                lblResultado.ForeColor = Color.FromArgb(150, 40, 40);
                lblRecomendacion.Text =
                    "El IVA Débito supera al Crédito Fiscal. Debe registrarse un IVA por pagar " +
                    $"(cta. 210302) por {resultado:N2} y enterarlo a la administración tributaria en el plazo legal.";
            }
            else if (resultado < 0)
            {
                lblResultadoCap.Text = "Remanente:";
                lblResultado.Text = Math.Abs(resultado).ToString("N2");
                lblResultado.ForeColor = Color.FromArgb(39, 128, 73);
                lblRecomendacion.Text =
                    "El Crédito Fiscal supera al Débito. Queda un remanente a favor " +
                    $"(cta. 110402) por {Math.Abs(resultado):N2} que se aplica al próximo periodo.";
            }
            else
            {
                lblResultadoCap.Text = "Resultado:";
                lblResultado.Text = "0.00";
                lblResultado.ForeColor = Color.FromArgb(33, 71, 115);
                lblRecomendacion.Text = "El IVA Débito y el Crédito Fiscal se compensan exactamente: no hay impuesto a pagar ni remanente.";
            }
        }

        private static decimal SaldoDe(List<SaldoCuenta> saldos, string codigo)
        {
            var c = saldos.FirstOrDefault(s => s.Codigo == codigo);
            return c?.Saldo ?? 0m;
        }

        private void btnCalcular_Click(object sender, EventArgs e) => Calcular();
    }
}
