namespace sistema_contabilidad.Formularios
{
    partial class FrmCatalogo
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
            dgvCuentas = new DataGridView();
            panelInferior = new Panel();
            lblResumen = new Label();
            panelEncabezado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCuentas).BeginInit();
            panelInferior.SuspendLayout();
            SuspendLayout();
            //
            // panelEncabezado
            //
            panelEncabezado.BackColor = Color.FromArgb(33, 71, 115);
            panelEncabezado.Controls.Add(lblTitulo);
            panelEncabezado.Dock = DockStyle.Top;
            panelEncabezado.Location = new Point(0, 0);
            panelEncabezado.Name = "panelEncabezado";
            panelEncabezado.Size = new Size(800, 55);
            panelEncabezado.TabIndex = 0;
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(16, 12);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(297, 28);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Catálogo de Cuentas Contables";
            //
            // dgvCuentas
            //
            dgvCuentas.AllowUserToAddRows = false;
            dgvCuentas.AllowUserToDeleteRows = false;
            dgvCuentas.BackgroundColor = Color.White;
            dgvCuentas.BorderStyle = BorderStyle.None;
            dgvCuentas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCuentas.Dock = DockStyle.Fill;
            dgvCuentas.Location = new Point(0, 55);
            dgvCuentas.Name = "dgvCuentas";
            dgvCuentas.ReadOnly = true;
            dgvCuentas.RowHeadersVisible = false;
            dgvCuentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCuentas.Size = new Size(800, 385);
            dgvCuentas.TabIndex = 1;
            //
            // panelInferior
            //
            panelInferior.Controls.Add(lblResumen);
            panelInferior.Dock = DockStyle.Bottom;
            panelInferior.Location = new Point(0, 440);
            panelInferior.Name = "panelInferior";
            panelInferior.Padding = new Padding(10, 8, 10, 8);
            panelInferior.Size = new Size(800, 40);
            panelInferior.TabIndex = 2;
            //
            // lblResumen
            //
            lblResumen.AutoSize = true;
            lblResumen.Location = new Point(12, 10);
            lblResumen.Name = "lblResumen";
            lblResumen.Size = new Size(50, 20);
            lblResumen.TabIndex = 0;
            lblResumen.Text = "Cuentas";
            //
            // FrmCatalogo
            //
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 480);
            Controls.Add(dgvCuentas);
            Controls.Add(panelInferior);
            Controls.Add(panelEncabezado);
            Name = "FrmCatalogo";
            Text = "Catálogo de Cuentas";
            Load += FrmCatalogo_Load;
            panelEncabezado.ResumeLayout(false);
            panelEncabezado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCuentas).EndInit();
            panelInferior.ResumeLayout(false);
            panelInferior.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelEncabezado;
        private Label lblTitulo;
        private DataGridView dgvCuentas;
        private Panel panelInferior;
        private Label lblResumen;
    }
}
