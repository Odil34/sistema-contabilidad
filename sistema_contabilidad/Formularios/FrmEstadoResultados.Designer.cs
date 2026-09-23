namespace sistema_contabilidad.Formularios
{
    partial class FrmEstadoResultados
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
            panelResultado = new Panel();
            lblResultado = new Label();
            panelEncabezado.SuspendLayout();
            panelControles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReporte).BeginInit();
            panelResultado.SuspendLayout();
            SuspendLayout();
            panelEncabezado.BackColor = Color.FromArgb(33, 71, 115);
            panelEncabezado.Controls.Add(lblTitulo);
            panelEncabezado.Dock = DockStyle.Top;
            panelEncabezado.Location = new Point(0, 0);
            panelEncabezado.Name = "panelEncabezado";
            panelEncabezado.Size = new Size(760, 55);
            panelEncabezado.TabIndex = 0;
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(16, 12);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(245, 28);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Estado de Resultados";
            panelControles.Controls.Add(lblHasta);
            panelControles.Controls.Add(dtpHasta);
            panelControles.Controls.Add(btnActualizar);
            panelControles.Controls.Add(btnExportar);
            panelControles.Dock = DockStyle.Top;
            panelControles.Location = new Point(0, 55);
            panelControles.Name = "panelControles";
            panelControles.Padding = new Padding(10, 8, 10, 8);
            panelControles.Size = new Size(760, 48);
            panelControles.TabIndex = 1;
            lblHasta.AutoSize = true;
            lblHasta.Location = new Point(12, 14);
            lblHasta.Name = "lblHasta";
            lblHasta.Size = new Size(93, 20);
            lblHasta.TabIndex = 0;
            lblHasta.Text = "Al corte de:";
            dtpHasta.Format = DateTimePickerFormat.Short;
            dtpHasta.Location = new Point(111, 10);
            dtpHasta.Name = "dtpHasta";
            dtpHasta.Size = new Size(140, 27);
            dtpHasta.TabIndex = 1;
            btnActualizar.BackColor = Color.FromArgb(33, 71, 115);
            btnActualizar.FlatStyle = FlatStyle.Flat;
            btnActualizar.ForeColor = Color.White;
            btnActualizar.Location = new Point(266, 8);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(110, 30);
            btnActualizar.TabIndex = 2;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = false;
            btnActualizar.Click += btnActualizar_Click;
            btnExportar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExportar.FlatStyle = FlatStyle.Flat;
            btnExportar.Location = new Point(622, 8);
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
            dgvReporte.Size = new Size(760, 379);
            dgvReporte.TabIndex = 2;
            panelResultado.BackColor = Color.FromArgb(238, 243, 249);
            panelResultado.Controls.Add(lblResultado);
            panelResultado.Dock = DockStyle.Bottom;
            panelResultado.Location = new Point(0, 482);
            panelResultado.Name = "panelResultado";
            panelResultado.Size = new Size(760, 55);
            panelResultado.TabIndex = 3;
            lblResultado.Dock = DockStyle.Fill;
            lblResultado.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblResultado.Location = new Point(0, 0);
            lblResultado.Name = "lblResultado";
            lblResultado.Padding = new Padding(16, 0, 16, 0);
            lblResultado.Size = new Size(760, 55);
            lblResultado.TabIndex = 0;
            lblResultado.Text = "Resultado del ejercicio";
            lblResultado.TextAlign = ContentAlignment.MiddleLeft;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(760, 537);
            Controls.Add(dgvReporte);
            Controls.Add(panelResultado);
            Controls.Add(panelControles);
            Controls.Add(panelEncabezado);
            Name = "FrmEstadoResultados";
            Text = "Estado de Resultados";
            Load += FrmEstadoResultados_Load;
            panelEncabezado.ResumeLayout(false);
            panelEncabezado.PerformLayout();
            panelControles.ResumeLayout(false);
            panelControles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReporte).EndInit();
            panelResultado.ResumeLayout(false);
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
        private Panel panelResultado;
        private Label lblResultado;
    }
}
