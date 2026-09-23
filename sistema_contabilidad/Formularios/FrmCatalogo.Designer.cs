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
            panelBusqueda = new Panel();
            lblBuscar = new Label();
            txtBuscar = new TextBox();
            dgvCuentas = new DataGridView();
            panelInferior = new Panel();
            lblResumen = new Label();
            panelEncabezado.SuspendLayout();
            panelBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCuentas).BeginInit();
            panelInferior.SuspendLayout();
            SuspendLayout();
            panelEncabezado.BackColor = Color.FromArgb(33, 71, 115);
            panelEncabezado.Controls.Add(lblTitulo);
            panelEncabezado.Dock = DockStyle.Top;
            panelEncabezado.Location = new Point(0, 0);
            panelEncabezado.Name = "panelEncabezado";
            panelEncabezado.Size = new Size(800, 55);
            panelEncabezado.TabIndex = 0;
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(16, 12);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(297, 28);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Catálogo de Cuentas Contables";
            panelBusqueda.Controls.Add(lblBuscar);
            panelBusqueda.Controls.Add(txtBuscar);
            panelBusqueda.Dock = DockStyle.Top;
            panelBusqueda.Location = new Point(0, 55);
            panelBusqueda.Name = "panelBusqueda";
            panelBusqueda.Padding = new Padding(10, 8, 10, 8);
            panelBusqueda.Size = new Size(800, 46);
            panelBusqueda.TabIndex = 1;
            lblBuscar.AutoSize = true;
            lblBuscar.Location = new Point(12, 12);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(180, 20);
            lblBuscar.TabIndex = 0;
            lblBuscar.Text = "Buscar (código o nombre):";
            txtBuscar.Location = new Point(200, 9);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(300, 27);
            txtBuscar.TabIndex = 1;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            dgvCuentas.AllowUserToAddRows = false;
            dgvCuentas.AllowUserToDeleteRows = false;
            dgvCuentas.BackgroundColor = Color.White;
            dgvCuentas.BorderStyle = BorderStyle.None;
            dgvCuentas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCuentas.Dock = DockStyle.Fill;
            dgvCuentas.Location = new Point(0, 101);
            dgvCuentas.Name = "dgvCuentas";
            dgvCuentas.ReadOnly = true;
            dgvCuentas.RowHeadersVisible = false;
            dgvCuentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCuentas.Size = new Size(800, 422);
            dgvCuentas.TabIndex = 2;
            panelInferior.Controls.Add(lblResumen);
            panelInferior.Dock = DockStyle.Bottom;
            panelInferior.Location = new Point(0, 523);
            panelInferior.Name = "panelInferior";
            panelInferior.Padding = new Padding(10, 8, 10, 8);
            panelInferior.Size = new Size(800, 40);
            panelInferior.TabIndex = 3;
            lblResumen.AutoSize = true;
            lblResumen.Location = new Point(12, 10);
            lblResumen.Name = "lblResumen";
            lblResumen.Size = new Size(61, 20);
            lblResumen.TabIndex = 0;
            lblResumen.Text = "Cuentas";
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 563);
            Controls.Add(dgvCuentas);
            Controls.Add(panelInferior);
            Controls.Add(panelBusqueda);
            Controls.Add(panelEncabezado);
            Name = "FrmCatalogo";
            Text = "Catálogo de Cuentas";
            Load += FrmCatalogo_Load;
            panelEncabezado.ResumeLayout(false);
            panelEncabezado.PerformLayout();
            panelBusqueda.ResumeLayout(false);
            panelBusqueda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCuentas).EndInit();
            panelInferior.ResumeLayout(false);
            panelInferior.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelEncabezado;
        private Label lblTitulo;
        private Panel panelBusqueda;
        private Label lblBuscar;
        private TextBox txtBuscar;
        private DataGridView dgvCuentas;
        private Panel panelInferior;
        private Label lblResumen;
    }
}
