namespace sistema_contabilidad.Formularios
{
    partial class FrmBalanceComprobacion
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
            btnActualizar = new Button();
            btnExportar = new Button();
            dgvReporte = new DataGridView();
            panelTotales = new Panel();
            lblTotales = new Label();
            lblEstadoCuadre = new Label();
            panelEncabezado.SuspendLayout();
            panelControles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReporte).BeginInit();
            panelTotales.SuspendLayout();
            SuspendLayout();
            panelEncabezado.BackColor = Color.FromArgb(33, 71, 115);
            panelEncabezado.Controls.Add(lblTitulo);
            panelEncabezado.Dock = DockStyle.Top;
            panelEncabezado.Location = new Point(0, 0);
            panelEncabezado.Name = "panelEncabezado";
            panelEncabezado.Size = new Size(900, 55);
            panelEncabezado.TabIndex = 0;
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(16, 12);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(280, 28);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Balance de Comprobación";
            panelControles.Controls.Add(lblHasta);
            panelControles.Controls.Add(dtpHasta);
            panelControles.Controls.Add(btnActualizar);
            panelControles.Controls.Add(btnExportar);
            panelControles.Dock = DockStyle.Top;
            panelControles.Location = new Point(0, 55);
            panelControles.Name = "panelControles";
            panelControles.Padding = new Padding(10, 8, 10, 8);
            panelControles.Size = new Size(900, 48);
            panelControles.TabIndex = 1;
            lblHasta.AutoSize = true;
            lblHasta.Location = new Point(12, 14);
            lblHasta.Name = "lblHasta";
            lblHasta.Size = new Size(112, 20);
            lblHasta.TabIndex = 0;
            lblHasta.Text = "Saldos a la fecha:";
            dtpHasta.Format = DateTimePickerFormat.Short;
            dtpHasta.Location = new Point(130, 10);
            dtpHasta.Name = "dtpHasta";
            dtpHasta.Size = new Size(140, 27);
            dtpHasta.TabIndex = 1;
            btnActualizar.BackColor = Color.FromArgb(33, 71, 115);
            btnActualizar.FlatStyle = FlatStyle.Flat;
            btnActualizar.ForeColor = Color.White;
            btnActualizar.Location = new Point(285, 8);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(110, 30);
            btnActualizar.TabIndex = 2;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = false;
            btnActualizar.Click += btnActualizar_Click;
            btnExportar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExportar.FlatStyle = FlatStyle.Flat;
            btnExportar.Location = new Point(762, 8);
            btnExportar.Name = "btnExportar";
            btnExportar.Size = new Size(126, 30);
            btnExportar.TabIndex = 3;
            btnExportar.Text = "Exportar a CSV";
            btnExportar.UseVisualStyleBackColor = true;
            btnExportar.Click += btnExportar_Click;
            dgvReporte.AllowUserToAddRows = false;
            dgvReporte.AllowUserToDeleteRows = false;
            dgvReporte.BackgroundColor = Color.White;
            dgvReporte.BorderStyle = BorderStyle.None;
            dgvReporte.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReporte.Dock = DockStyle.Fill;
            dgvReporte.Location = new Point(0, 103);
            dgvReporte.Name = "dgvReporte";
            dgvReporte.ReadOnly = true;
            dgvReporte.RowHeadersVisible = false;
            dgvReporte.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReporte.Size = new Size(900, 379);
            dgvReporte.TabIndex = 2;
            panelTotales.BackColor = Color.FromArgb(238, 243, 249);
            panelTotales.Controls.Add(lblTotales);
            panelTotales.Controls.Add(lblEstadoCuadre);
            panelTotales.Dock = DockStyle.Bottom;
            panelTotales.Location = new Point(0, 482);
            panelTotales.Name = "panelTotales";
            panelTotales.Size = new Size(900, 60);
            panelTotales.TabIndex = 3;
            lblTotales.AutoSize = true;
            lblTotales.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTotales.Location = new Point(16, 10);
            lblTotales.Name = "lblTotales";
            lblTotales.Size = new Size(66, 23);
            lblTotales.TabIndex = 0;
            lblTotales.Text = "Totales";
            lblEstadoCuadre.AutoSize = true;
            lblEstadoCuadre.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblEstadoCuadre.Location = new Point(16, 33);
            lblEstadoCuadre.Name = "lblEstadoCuadre";
            lblEstadoCuadre.Size = new Size(60, 23);
            lblEstadoCuadre.TabIndex = 1;
            lblEstadoCuadre.Text = "Estado";
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 542);
            Controls.Add(dgvReporte);
            Controls.Add(panelTotales);
            Controls.Add(panelControles);
            Controls.Add(panelEncabezado);
            Name = "FrmBalanceComprobacion";
            Text = "Balance de Comprobación";
            Load += FrmBalanceComprobacion_Load;
            panelEncabezado.ResumeLayout(false);
            panelEncabezado.PerformLayout();
            panelControles.ResumeLayout(false);
            panelControles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReporte).EndInit();
            panelTotales.ResumeLayout(false);
            panelTotales.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelEncabezado;
        private Label lblTitulo;
        private Panel panelControles;
        private Label lblHasta;
        private DateTimePicker dtpHasta;
        private Button btnActualizar;
        private Button btnExportar;
        private DataGridView dgvReporte;
        private Panel panelTotales;
        private Label lblTotales;
        private Label lblEstadoCuadre;
    }
}
