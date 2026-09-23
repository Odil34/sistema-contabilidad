using System.Globalization;

namespace sistema_contabilidad.Formularios
{
    public partial class FrmCalculadoraIva : Form
    {
        private const decimal Tasa = 0.13m;

        private decimal _base;
        private decimal _iva;
        private decimal _total;

        public decimal? ValorElegido { get; private set; }

        public FrmCalculadoraIva()
        {
            InitializeComponent();
        }

        private void FrmCalculadoraIva_Load(object sender, EventArgs e)
        {
            cboModo.Items.Add("Más IVA (se agrega el 13%)");
            cboModo.Items.Add("IVA incluido (el monto ya trae el 13%)");
            cboModo.SelectedIndex = 0;
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            decimal monto = ParsearMonto(txtMonto.Text);
            if (monto <= 0)
            {
                MessageBox.Show("Ingrese un monto mayor a cero.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboModo.SelectedIndex == 0)
            {
                _base = monto;
                _iva = Math.Round(monto * Tasa, 2);
                _total = _base + _iva;
            }
            else
            {
                _base = Math.Round(monto / (1 + Tasa), 2);
                _iva = Math.Round(monto - _base, 2);
                _total = monto;
            }

            lblBase.Text = _base.ToString("N2");
            lblIva.Text = _iva.ToString("N2");
            lblTotal.Text = _total.ToString("N2");

            btnUsarBase.Enabled = true;
            btnUsarIva.Enabled = true;
            btnUsarTotal.Enabled = true;
        }

        private void btnUsarBase_Click(object sender, EventArgs e) => Devolver(_base);

        private void btnUsarIva_Click(object sender, EventArgs e) => Devolver(_iva);

        private void btnUsarTotal_Click(object sender, EventArgs e) => Devolver(_total);

        private void Devolver(decimal valor)
        {
            ValorElegido = valor;
            DialogResult = DialogResult.OK;
            Close();
        }

        private static decimal ParsearMonto(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto)) return 0;
            texto = texto.Trim().Replace(",", ".");
            return decimal.TryParse(texto, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal valor)
                ? valor
                : 0;
        }
    }
}
