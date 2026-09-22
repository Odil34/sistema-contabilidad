using System.Data;
using System.Globalization;
using sistema_contabilidad.Datos;
using sistema_contabilidad.Modelos;

namespace sistema_contabilidad.Formularios
{
    public partial class FrmLibroDiario : Form
    {
        private readonly CuentaDAL _cuentaDAL = new CuentaDAL();
        private readonly AsientoDAL _asientoDAL = new AsientoDAL();
        private DataTable _detalle;

        public FrmLibroDiario()
        {
            InitializeComponent();
        }

        private void FrmLibroDiario_Load(object sender, EventArgs e)
        {
            cboCuenta.DisplayMember = "DescripcionSeleccion";
            cboCuenta.DataSource = _cuentaDAL.ListarDetalle();
            PrepararGrilla();
            NuevoAsiento();
        }

        private void btnCalcIva_Click(object sender, EventArgs e)
        {
            using var calc = new FrmCalculadoraIva();
            calc.ShowDialog(this);
        }

        private void PrepararGrilla()
        {
            _detalle = new DataTable();
            _detalle.Columns.Add("Código", typeof(string));
            _detalle.Columns.Add("Cuenta", typeof(string));
            _detalle.Columns.Add("Concepto", typeof(string));
            _detalle.Columns.Add("Debe", typeof(decimal));
            _detalle.Columns.Add("Haber", typeof(decimal));

            dgvDetalle.DataSource = _detalle;
            dgvDetalle.Columns["Código"].Width = 90;
            dgvDetalle.Columns["Cuenta"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvDetalle.Columns["Debe"].DefaultCellStyle.Format = "N2";
            dgvDetalle.Columns["Haber"].DefaultCellStyle.Format = "N2";
            dgvDetalle.Columns["Debe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDetalle.Columns["Haber"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDetalle.EnableHeadersVisualStyles = false;
            dgvDetalle.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 71, 115);
            dgvDetalle.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvDetalle.ColumnHeadersDefaultCellStyle.Font = new Font(dgvDetalle.Font, FontStyle.Bold);
        }

        private void NuevoAsiento()
        {
            _detalle.Rows.Clear();
            lblNumero.Text = _asientoDAL.SiguienteNumero().ToString();
            dtpFecha.Value = DateTime.Today;
            txtConcepto.Clear();
            LimpiarLinea();
            ActualizarTotales();
        }

        private void LimpiarLinea()
        {
            if (cboCuenta.Items.Count > 0) cboCuenta.SelectedIndex = 0;
            txtConceptoLinea.Clear();
            txtDebe.Text = "0.00";
            txtHaber.Text = "0.00";
        }

        private void btnAgregarLinea_Click(object sender, EventArgs e)
        {
            if (cboCuenta.SelectedItem is not Cuenta cuenta)
            {
                MessageBox.Show("Seleccione una cuenta.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal debe = ParsearMonto(txtDebe.Text);
            decimal haber = ParsearMonto(txtHaber.Text);

            if (debe < 0 || haber < 0)
            {
                MessageBox.Show("Los montos no pueden ser negativos.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (debe == 0 && haber == 0)
            {
                MessageBox.Show("Ingrese un valor en el Debe o en el Haber.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (debe > 0 && haber > 0)
            {
                MessageBox.Show("Un movimiento no puede tener Debe y Haber a la vez.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _detalle.Rows.Add(cuenta.Codigo, cuenta.Nombre,
                string.IsNullOrWhiteSpace(txtConceptoLinea.Text) ? txtConcepto.Text : txtConceptoLinea.Text,
                debe, haber);

            LimpiarLinea();
            ActualizarTotales();
            cboCuenta.Focus();
        }

        private void btnQuitarLinea_Click(object sender, EventArgs e)
        {
            if (dgvDetalle.CurrentRow == null || dgvDetalle.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Seleccione la línea que desea quitar.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            _detalle.Rows.RemoveAt(dgvDetalle.CurrentRow.Index);
            ActualizarTotales();
        }

        private void ActualizarTotales()
        {
            decimal totalDebe = 0, totalHaber = 0;
            foreach (DataRow fila in _detalle.Rows)
            {
                totalDebe += fila.Field<decimal>("Debe");
                totalHaber += fila.Field<decimal>("Haber");
            }
            decimal diferencia = totalDebe - totalHaber;

            lblTotDebe.Text = totalDebe.ToString("N2");
            lblTotHaber.Text = totalHaber.ToString("N2");
            lblDiferencia.Text = diferencia.ToString("N2");

            bool cuadra = diferencia == 0 && totalDebe > 0;
            lblDiferencia.ForeColor = cuadra
                ? Color.FromArgb(39, 128, 73)
                : Color.FromArgb(150, 40, 40);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (_detalle.Rows.Count < 2)
            {
                MessageBox.Show("Un asiento debe tener al menos dos movimientos.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var asiento = new Asiento
            {
                Numero = int.Parse(lblNumero.Text),
                Fecha = dtpFecha.Value.Date,
                Concepto = txtConcepto.Text.Trim()
            };
            foreach (DataRow fila in _detalle.Rows)
            {
                asiento.Detalles.Add(new AsientoDetalle
                {
                    CodigoCuenta = fila.Field<string>("Código"),
                    Concepto = fila.Field<string>("Concepto"),
                    Debe = fila.Field<decimal>("Debe"),
                    Haber = fila.Field<decimal>("Haber")
                });
            }

            if (!asiento.CumplePartidaDoble)
            {
                MessageBox.Show(
                    "No se puede guardar: el asiento NO cumple la partida doble.\n\n" +
                    $"Total Debe:  {asiento.TotalDebe:N2}\n" +
                    $"Total Haber: {asiento.TotalHaber:N2}\n" +
                    $"Diferencia:  {(asiento.TotalDebe - asiento.TotalHaber):N2}\n\n" +
                    "El total del Debe debe ser igual al total del Haber.",
                    "Partida doble no cumplida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(asiento.Concepto))
            {
                MessageBox.Show("Ingrese el concepto general del asiento.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConcepto.Focus();
                return;
            }

            try
            {
                _asientoDAL.Guardar(asiento);
                MessageBox.Show(
                    $"Asiento N° {asiento.Numero} guardado correctamente.\n" +
                    "La mayorización se actualizó automáticamente.",
                    "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                NuevoAsiento();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el asiento:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            NuevoAsiento();
        }

        private static decimal ParsearMonto(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto)) return 0;
            texto = texto.Trim().Replace(",", ".");
            return decimal.TryParse(texto, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal valor)
                ? Math.Round(valor, 2)
                : 0;
        }
    }
}
