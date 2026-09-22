using System.Globalization;

namespace sistema_contabilidad.Formularios
{
    public partial class FrmCalculadoraIva : Form
    {
        private const decimal Tasa = 0.13m;

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

            decimal baseImponible, iva, total;

            if (cboModo.SelectedIndex == 0)
            {
                baseImponible = monto;
                iva = Math.Round(monto * Tasa, 2);
                total = baseImponible + iva;
            }
            else
            {
                baseImponible = Math.Round(monto / (1 + Tasa), 2);
                iva = Math.Round(monto - baseImponible, 2);
                total = monto;
            }

            lblBase.Text = baseImponible.ToString("N2");
            lblIva.Text = iva.ToString("N2");
            lblTotal.Text = total.ToString("N2");
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
