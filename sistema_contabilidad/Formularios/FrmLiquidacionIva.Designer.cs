namespace sistema_contabilidad.Formularios
{
    partial class FrmLiquidacionIva
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            panelEncabezado = new Panel();
            lblTitulo = new Label();
            panelControles = new Panel();
            lblHasta = new Label();
            dtpHasta = new DateTimePicker();
            btnCalcular = new Button();
            grpDetalle = new GroupBox();
            lblDebitoCap = new Label();
            lblDebito = new Label();
            lblCreditoCap = new Label();
            lblCredito = new Label();
            lblRemanenteCap = new Label();
            lblRemanente = new Label();
            lblLinea = new Label();
            lblResultadoCap = new Label();
            lblResultado = new Label();
            lblRecomendacion = new Label();
            panelEncabezado.SuspendLayout();
            panelControles.SuspendLayout();
            grpDetalle.SuspendLayout();
            SuspendLayout();
            panelEncabezado.BackColor = Color.FromArgb(33, 71, 115);
            panelEncabezado.Controls.Add(lblTitulo);
            panelEncabezado.Dock = DockStyle.Top;
            panelEncabezado.Location = new Point(0, 0);
            panelEncabezado.Name = "panelEncabezado";
            panelEncabezado.Size = new Size(620, 55);
            panelEncabezado.TabIndex = 0;
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(16, 12);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(224, 28);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Liquidación de IVA";
            panelControles.Controls.Add(lblHasta);
            panelControles.Controls.Add(dtpHasta);
            panelControles.Controls.Add(btnCalcular);
            panelControles.Dock = DockStyle.Top;
            panelControles.Location = new Point(0, 55);
            panelControles.Name = "panelControles";
            panelControles.Padding = new Padding(10, 8, 10, 8);
            panelControles.Size = new Size(620, 48);
            panelControles.TabIndex = 1;
            lblHasta.AutoSize = true;
            lblHasta.Location = new Point(12, 14);
            lblHasta.Name = "lblHasta";
            lblHasta.Size = new Size(110, 20);
            lblHasta.TabIndex = 0;
            lblHasta.Text = "Periodo hasta:";
            dtpHasta.Format = DateTimePickerFormat.Short;
            dtpHasta.Location = new Point(128, 10);
            dtpHasta.Name = "dtpHasta";
            dtpHasta.Size = new Size(140, 27);
            dtpHasta.TabIndex = 1;
            btnCalcular.BackColor = Color.FromArgb(33, 71, 115);
            btnCalcular.FlatStyle = FlatStyle.Flat;
            btnCalcular.ForeColor = Color.White;
            btnCalcular.Location = new Point(283, 8);
            btnCalcular.Name = "btnCalcular";
            btnCalcular.Size = new Size(130, 30);
            btnCalcular.TabIndex = 2;
            btnCalcular.Text = "Calcular";
            btnCalcular.UseVisualStyleBackColor = false;
            btnCalcular.Click += btnCalcular_Click;
            grpDetalle.Controls.Add(lblDebitoCap);
            grpDetalle.Controls.Add(lblDebito);
            grpDetalle.Controls.Add(lblCreditoCap);
            grpDetalle.Controls.Add(lblCredito);
            grpDetalle.Controls.Add(lblRemanenteCap);
            grpDetalle.Controls.Add(lblRemanente);
            grpDetalle.Controls.Add(lblLinea);
            grpDetalle.Controls.Add(lblResultadoCap);
            grpDetalle.Controls.Add(lblResultado);
            grpDetalle.Controls.Add(lblRecomendacion);
            grpDetalle.Location = new Point(20, 120);
            grpDetalle.Name = "grpDetalle";
            grpDetalle.Padding = new Padding(15);
            grpDetalle.Size = new Size(580, 320);
            grpDetalle.TabIndex = 2;
            grpDetalle.TabStop = false;
            grpDetalle.Text = "Determinación del impuesto del periodo";
            lblDebitoCap.AutoSize = true;
            lblDebitoCap.Location = new Point(25, 45);
            lblDebitoCap.Name = "lblDebitoCap";
            lblDebitoCap.Size = new Size(322, 20);
            lblDebitoCap.TabIndex = 0;
            lblDebitoCap.Text = "IVA Débito Fiscal (ventas) — cta. 210301:";
            lblDebito.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDebito.Location = new Point(360, 43);
            lblDebito.Name = "lblDebito";
            lblDebito.Size = new Size(180, 25);
            lblDebito.TabIndex = 1;
            lblDebito.Text = "0.00";
            lblDebito.TextAlign = ContentAlignment.MiddleRight;
            lblCreditoCap.AutoSize = true;
            lblCreditoCap.Location = new Point(25, 85);
            lblCreditoCap.Name = "lblCreditoCap";
            lblCreditoCap.Size = new Size(340, 20);
            lblCreditoCap.TabIndex = 2;
            lblCreditoCap.Text = "IVA Crédito Fiscal (compras) — cta. 110401:";
            lblCredito.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblCredito.Location = new Point(360, 83);
            lblCredito.Name = "lblCredito";
            lblCredito.Size = new Size(180, 25);
            lblCredito.TabIndex = 3;
            lblCredito.Text = "0.00";
            lblCredito.TextAlign = ContentAlignment.MiddleRight;
            lblRemanenteCap.AutoSize = true;
            lblRemanenteCap.Location = new Point(25, 125);
            lblRemanenteCap.Name = "lblRemanenteCap";
            lblRemanenteCap.Size = new Size(330, 20);
            lblRemanenteCap.TabIndex = 4;
            lblRemanenteCap.Text = "(-) Remanente a favor anterior — cta. 110402:";
            lblRemanente.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblRemanente.Location = new Point(360, 123);
            lblRemanente.Name = "lblRemanente";
            lblRemanente.Size = new Size(180, 25);
            lblRemanente.TabIndex = 5;
            lblRemanente.Text = "0.00";
            lblRemanente.TextAlign = ContentAlignment.MiddleRight;
            lblLinea.BorderStyle = BorderStyle.Fixed3D;
            lblLinea.Location = new Point(25, 160);
            lblLinea.Name = "lblLinea";
            lblLinea.Size = new Size(515, 2);
            lblLinea.TabIndex = 6;
            lblResultadoCap.AutoSize = true;
            lblResultadoCap.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblResultadoCap.Location = new Point(25, 175);
            lblResultadoCap.Name = "lblResultadoCap";
            lblResultadoCap.Size = new Size(120, 25);
            lblResultadoCap.TabIndex = 7;
            lblResultadoCap.Text = "Resultado:";
            lblResultado.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblResultado.ForeColor = Color.FromArgb(33, 71, 115);
            lblResultado.Location = new Point(300, 173);
            lblResultado.Name = "lblResultado";
            lblResultado.Size = new Size(240, 28);
            lblResultado.TabIndex = 8;
            lblResultado.Text = "0.00";
            lblResultado.TextAlign = ContentAlignment.MiddleRight;
            lblRecomendacion.Location = new Point(25, 215);
            lblRecomendacion.Name = "lblRecomendacion";
            lblRecomendacion.Size = new Size(515, 85);
            lblRecomendacion.TabIndex = 9;
            lblRecomendacion.Text = "";
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(620, 470);
            Controls.Add(grpDetalle);
            Controls.Add(panelControles);
            Controls.Add(panelEncabezado);
            Name = "FrmLiquidacionIva";
            Text = "Liquidación de IVA";
            Load += FrmLiquidacionIva_Load;
            panelEncabezado.ResumeLayout(false);
            panelEncabezado.PerformLayout();
            panelControles.ResumeLayout(false);
            panelControles.PerformLayout();
            grpDetalle.ResumeLayout(false);
            grpDetalle.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelEncabezado;
        private Label lblTitulo;
        private Panel panelControles;
        private Label lblHasta;
        private DateTimePicker dtpHasta;
        private Button btnCalcular;
        private GroupBox grpDetalle;
        private Label lblDebitoCap;
        private Label lblDebito;
        private Label lblCreditoCap;
        private Label lblCredito;
        private Label lblRemanenteCap;
        private Label lblRemanente;
        private Label lblLinea;
        private Label lblResultadoCap;
        private Label lblResultado;
        private Label lblRecomendacion;
    }
}
