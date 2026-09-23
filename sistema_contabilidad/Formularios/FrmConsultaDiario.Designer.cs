namespace sistema_contabilidad.Formularios
{
    partial class FrmConsultaDiario
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
            lblDesde = new Label();
            dtpDesde = new DateTimePicker();
            lblHasta = new Label();
            dtpHasta = new DateTimePicker();
            btnActualizar = new Button();
            lblBuscar = new Label();
            txtBuscar = new TextBox();
            btnExportar = new Button();
            dgvDiario = new DataGridView();
            panelTotales = new Panel();
            lblTotales = new Label();
            panelEncabezado.SuspendLayout();
            panelControles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDiario).BeginInit();
            panelTotales.SuspendLayout();
            SuspendLayout();
            panelEncabezado.BackColor = Color.FromArgb(33, 71, 115);
            panelEncabezado.Controls.Add(lblTitulo);
            panelEncabezado.Dock = DockStyle.Top;
            panelEncabezado.Location = new Point(0, 0);
            panelEncabezado.Name = "panelEncabezado";
            panelEncabezado.Size = new Size(940, 55);
            panelEncabezado.TabIndex = 0;
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(16, 12);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(330, 28);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Consulta del Libro Diario";
            panelControles.Controls.Add(lblDesde);
            panelControles.Controls.Add(dtpDesde);
            panelControles.Controls.Add(lblHasta);
            panelControles.Controls.Add(dtpHasta);
            panelControles.Controls.Add(btnActualizar);
            panelControles.Controls.Add(lblBuscar);
            panelControles.Controls.Add(txtBuscar);
            panelControles.Controls.Add(btnExportar);
            panelControles.Dock = DockStyle.Top;
            panelControles.Location = new Point(0, 55);
            panelControles.Name = "panelControles";
            panelControles.Padding = new Padding(10, 8, 10, 8);
            panelControles.Size = new Size(940, 84);
            panelControles.TabIndex = 1;
            lblDesde.AutoSize = true;
            lblDesde.Location = new Point(12, 14);
            lblDesde.Name = "lblDesde";
            lblDesde.Size = new Size(52, 20);
            lblDesde.TabIndex = 0;
            lblDesde.Text = "Desde:";
            dtpDesde.Format = DateTimePickerFormat.Short;
            dtpDesde.Location = new Point(70, 10);
            dtpDesde.Name = "dtpDesde";
            dtpDesde.Size = new Size(140, 27);
            dtpDesde.TabIndex = 1;
            lblHasta.AutoSize = true;
            lblHasta.Location = new Point(230, 14);
            lblHasta.Name = "lblHasta";
            lblHasta.Size = new Size(51, 20);
            lblHasta.TabIndex = 2;
            lblHasta.Text = "Hasta:";
            dtpHasta.Format = DateTimePickerFormat.Short;
            dtpHasta.Location = new Point(287, 10);
            dtpHasta.Name = "dtpHasta";
            dtpHasta.Size = new Size(140, 27);
            dtpHasta.TabIndex = 3;
            btnActualizar.BackColor = Color.FromArgb(33, 71, 115);
            btnActualizar.FlatStyle = FlatStyle.Flat;
            btnActualizar.ForeColor = Color.White;
            btnActualizar.Location = new Point(445, 8);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(110, 30);
            btnActualizar.TabIndex = 4;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = false;
            btnActualizar.Click += btnActualizar_Click;
            lblBuscar.AutoSize = true;
            lblBuscar.Location = new Point(12, 52);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(230, 20);
            lblBuscar.TabIndex = 5;
            lblBuscar.Text = "Buscar (cuenta, concepto o N°):";
            txtBuscar.Location = new Point(248, 48);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(400, 27);
            txtBuscar.TabIndex = 6;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            btnExportar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExportar.FlatStyle = FlatStyle.Flat;
            btnExportar.Location = new Point(802, 8);
            btnExportar.Name = "btnExportar";
            btnExportar.Size = new Size(126, 30);
            btnExportar.TabIndex = 7;
            btnExportar.Text = "Exportar a CSV";
            btnExportar.UseVisualStyleBackColor = true;
            btnExportar.Click += btnExportar_Click;
            dgvDiario.AllowUserToAddRows = false;
            dgvDiario.AllowUserToDeleteRows = false;
            dgvDiario.BackgroundColor = Color.White;
            dgvDiario.BorderStyle = BorderStyle.None;
            dgvDiario.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDiario.Dock = DockStyle.Fill;
            dgvDiario.Location = new Point(0, 139);
            dgvDiario.Name = "dgvDiario";
            dgvDiario.ReadOnly = true;
            dgvDiario.RowHeadersVisible = false;
            dgvDiario.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDiario.Size = new Size(940, 391);
            dgvDiario.TabIndex = 2;
            panelTotales.BackColor = Color.FromArgb(238, 243, 249);
            panelTotales.Controls.Add(lblTotales);
            panelTotales.Dock = DockStyle.Bottom;
            panelTotales.Location = new Point(0, 530);
            panelTotales.Name = "panelTotales";
            panelTotales.Size = new Size(940, 45);
            panelTotales.TabIndex = 3;
            lblTotales.AutoSize = true;
            lblTotales.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTotales.Location = new Point(16, 12);
            lblTotales.Name = "lblTotales";
            lblTotales.Size = new Size(66, 23);
            lblTotales.TabIndex = 0;
            lblTotales.Text = "Totales";
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(940, 575);
            Controls.Add(dgvDiario);
            Controls.Add(panelTotales);
            Controls.Add(panelControles);
            Controls.Add(panelEncabezado);
            Name = "FrmConsultaDiario";
            Text = "Consulta del Libro Diario";
            Load += FrmConsultaDiario_Load;
            panelEncabezado.ResumeLayout(false);
            panelEncabezado.PerformLayout();
            panelControles.ResumeLayout(false);
            panelControles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDiario).EndInit();
            panelTotales.ResumeLayout(false);
            panelTotales.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelEncabezado;
        private Label lblTitulo;
        private Panel panelControles;
        private Label lblDesde;
        private DateTimePicker dtpDesde;
        private Label lblHasta;
        private DateTimePicker dtpHasta;
        private Button btnActualizar;
        private Label lblBuscar;
        private TextBox txtBuscar;
        private Button btnExportar;
        private DataGridView dgvDiario;
        private Panel panelTotales;
        private Label lblTotales;
    }
}
