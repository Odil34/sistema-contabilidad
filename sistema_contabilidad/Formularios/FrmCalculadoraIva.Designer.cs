namespace sistema_contabilidad.Formularios
{
    partial class FrmCalculadoraIva
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
            lblMonto = new Label();
            txtMonto = new TextBox();
            lblModo = new Label();
            cboModo = new ComboBox();
            btnCalcular = new Button();
            grpResultado = new GroupBox();
            lblBaseCap = new Label();
            lblBase = new Label();
            lblIvaCap = new Label();
            lblIva = new Label();
            lblTotalCap = new Label();
            lblTotal = new Label();
            panelEncabezado.SuspendLayout();
            grpResultado.SuspendLayout();
            SuspendLayout();
            panelEncabezado.BackColor = Color.FromArgb(33, 71, 115);
            panelEncabezado.Controls.Add(lblTitulo);
            panelEncabezado.Dock = DockStyle.Top;
            panelEncabezado.Location = new Point(0, 0);
            panelEncabezado.Name = "panelEncabezado";
            panelEncabezado.Size = new Size(420, 55);
            panelEncabezado.TabIndex = 0;
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(16, 12);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(200, 25);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Calculadora de IVA (13%)";
            lblMonto.AutoSize = true;
            lblMonto.Location = new Point(20, 75);
            lblMonto.Name = "lblMonto";
            lblMonto.Size = new Size(58, 20);
            lblMonto.TabIndex = 1;
            lblMonto.Text = "Monto:";
            txtMonto.Location = new Point(120, 71);
            txtMonto.Name = "txtMonto";
            txtMonto.Size = new Size(270, 27);
            txtMonto.TabIndex = 0;
            txtMonto.Text = "0.00";
            txtMonto.TextAlign = HorizontalAlignment.Right;
            lblModo.AutoSize = true;
            lblModo.Location = new Point(20, 115);
            lblModo.Name = "lblModo";
            lblModo.Size = new Size(46, 20);
            lblModo.TabIndex = 2;
            lblModo.Text = "Modo:";
            cboModo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboModo.FormattingEnabled = true;
            cboModo.Location = new Point(120, 111);
            cboModo.Name = "cboModo";
            cboModo.Size = new Size(270, 28);
            cboModo.TabIndex = 1;
            btnCalcular.BackColor = Color.FromArgb(33, 71, 115);
            btnCalcular.FlatStyle = FlatStyle.Flat;
            btnCalcular.ForeColor = Color.White;
            btnCalcular.Location = new Point(120, 151);
            btnCalcular.Name = "btnCalcular";
            btnCalcular.Size = new Size(270, 34);
            btnCalcular.TabIndex = 2;
            btnCalcular.Text = "Calcular";
            btnCalcular.UseVisualStyleBackColor = false;
            btnCalcular.Click += btnCalcular_Click;
            grpResultado.Controls.Add(lblBaseCap);
            grpResultado.Controls.Add(lblBase);
            grpResultado.Controls.Add(lblIvaCap);
            grpResultado.Controls.Add(lblIva);
            grpResultado.Controls.Add(lblTotalCap);
            grpResultado.Controls.Add(lblTotal);
            grpResultado.Location = new Point(20, 200);
            grpResultado.Name = "grpResultado";
            grpResultado.Size = new Size(370, 130);
            grpResultado.TabIndex = 3;
            grpResultado.TabStop = false;
            grpResultado.Text = "Resultado";
            lblBaseCap.AutoSize = true;
            lblBaseCap.Location = new Point(20, 30);
            lblBaseCap.Name = "lblBaseCap";
            lblBaseCap.Size = new Size(120, 20);
            lblBaseCap.TabIndex = 0;
            lblBaseCap.Text = "Base (sin IVA):";
            lblBase.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblBase.Location = new Point(190, 28);
            lblBase.Name = "lblBase";
            lblBase.Size = new Size(160, 25);
            lblBase.TabIndex = 1;
            lblBase.Text = "0.00";
            lblBase.TextAlign = ContentAlignment.MiddleRight;
            lblIvaCap.AutoSize = true;
            lblIvaCap.Location = new Point(20, 60);
            lblIvaCap.Name = "lblIvaCap";
            lblIvaCap.Size = new Size(78, 20);
            lblIvaCap.TabIndex = 2;
            lblIvaCap.Text = "IVA (13%):";
            lblIva.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblIva.ForeColor = Color.FromArgb(33, 71, 115);
            lblIva.Location = new Point(190, 58);
            lblIva.Name = "lblIva";
            lblIva.Size = new Size(160, 25);
            lblIva.TabIndex = 3;
            lblIva.Text = "0.00";
            lblIva.TextAlign = ContentAlignment.MiddleRight;
            lblTotalCap.AutoSize = true;
            lblTotalCap.Location = new Point(20, 92);
            lblTotalCap.Name = "lblTotalCap";
            lblTotalCap.Size = new Size(120, 20);
            lblTotalCap.TabIndex = 4;
            lblTotalCap.Text = "Total (con IVA):";
            lblTotal.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTotal.Location = new Point(190, 90);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(160, 25);
            lblTotal.TabIndex = 5;
            lblTotal.Text = "0.00";
            lblTotal.TextAlign = ContentAlignment.MiddleRight;
            AcceptButton = btnCalcular;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(420, 350);
            Controls.Add(grpResultado);
            Controls.Add(btnCalcular);
            Controls.Add(cboModo);
            Controls.Add(lblModo);
            Controls.Add(txtMonto);
            Controls.Add(lblMonto);
            Controls.Add(panelEncabezado);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmCalculadoraIva";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Calculadora de IVA";
            Load += FrmCalculadoraIva_Load;
            panelEncabezado.ResumeLayout(false);
            panelEncabezado.PerformLayout();
            grpResultado.ResumeLayout(false);
            grpResultado.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelEncabezado;
        private Label lblTitulo;
        private Label lblMonto;
        private TextBox txtMonto;
        private Label lblModo;
        private ComboBox cboModo;
        private Button btnCalcular;
        private GroupBox grpResultado;
        private Label lblBaseCap;
        private Label lblBase;
        private Label lblIvaCap;
        private Label lblIva;
        private Label lblTotalCap;
        private Label lblTotal;
    }
}
