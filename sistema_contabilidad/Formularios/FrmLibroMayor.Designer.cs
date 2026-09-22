namespace sistema_contabilidad.Formularios
{
    partial class FrmLibroMayor
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
            splitContainer = new SplitContainer();
            dgvMayor = new DataGridView();
            lblMovTitulo = new Label();
            dgvMovimientos = new DataGridView();
            panelEncabezado.SuspendLayout();
            panelControles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMayor).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvMovimientos).BeginInit();
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
            lblTitulo.Size = new Size(371, 28);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Libro Mayor - Mayorización Automática";
            panelControles.Controls.Add(lblHasta);
            panelControles.Controls.Add(dtpHasta);
            panelControles.Controls.Add(btnActualizar);
            panelControles.Dock = DockStyle.Top;
            panelControles.Location = new Point(0, 55);
            panelControles.Name = "panelControles";
            panelControles.Padding = new Padding(10, 8, 10, 8);
            panelControles.Size = new Size(940, 48);
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
            splitContainer.Dock = DockStyle.Fill;
            splitContainer.Location = new Point(0, 103);
            splitContainer.Name = "splitContainer";
            splitContainer.Panel1.Controls.Add(dgvMayor);
            splitContainer.Panel2.Controls.Add(dgvMovimientos);
            splitContainer.Panel2.Controls.Add(lblMovTitulo);
            splitContainer.Size = new Size(940, 472);
            splitContainer.SplitterDistance = 480;
            splitContainer.TabIndex = 2;
            dgvMayor.AllowUserToAddRows = false;
            dgvMayor.AllowUserToDeleteRows = false;
            dgvMayor.BackgroundColor = Color.White;
            dgvMayor.BorderStyle = BorderStyle.None;
            dgvMayor.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMayor.Dock = DockStyle.Fill;
            dgvMayor.Location = new Point(0, 0);
            dgvMayor.Name = "dgvMayor";
            dgvMayor.ReadOnly = true;
            dgvMayor.RowHeadersVisible = false;
            dgvMayor.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMayor.Size = new Size(480, 472);
            dgvMayor.TabIndex = 0;
            dgvMayor.SelectionChanged += dgvMayor_SelectionChanged;
            lblMovTitulo.BackColor = Color.FromArgb(238, 243, 249);
            lblMovTitulo.Dock = DockStyle.Top;
            lblMovTitulo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblMovTitulo.ForeColor = Color.FromArgb(33, 71, 115);
            lblMovTitulo.Location = new Point(0, 0);
            lblMovTitulo.Name = "lblMovTitulo";
            lblMovTitulo.Padding = new Padding(8, 6, 0, 0);
            lblMovTitulo.Size = new Size(456, 32);
            lblMovTitulo.TabIndex = 1;
            lblMovTitulo.Text = "Seleccione una cuenta para ver su detalle";
            dgvMovimientos.AllowUserToAddRows = false;
            dgvMovimientos.AllowUserToDeleteRows = false;
            dgvMovimientos.BackgroundColor = Color.White;
            dgvMovimientos.BorderStyle = BorderStyle.None;
            dgvMovimientos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMovimientos.Dock = DockStyle.Fill;
            dgvMovimientos.Location = new Point(0, 32);
            dgvMovimientos.Name = "dgvMovimientos";
            dgvMovimientos.ReadOnly = true;
            dgvMovimientos.RowHeadersVisible = false;
            dgvMovimientos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMovimientos.Size = new Size(456, 440);
            dgvMovimientos.TabIndex = 0;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(940, 575);
            Controls.Add(splitContainer);
            Controls.Add(panelControles);
            Controls.Add(panelEncabezado);
            Name = "FrmLibroMayor";
            Text = "Libro Mayor";
            Load += FrmLibroMayor_Load;
            panelEncabezado.ResumeLayout(false);
            panelEncabezado.PerformLayout();
            panelControles.ResumeLayout(false);
            panelControles.PerformLayout();
            splitContainer.Panel1.ResumeLayout(false);
            splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
            splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMayor).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvMovimientos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelEncabezado;
        private Label lblTitulo;
        private Panel panelControles;
        private Label lblHasta;
        private DateTimePicker dtpHasta;
        private Button btnActualizar;
        private SplitContainer splitContainer;
        private DataGridView dgvMayor;
        private Label lblMovTitulo;
        private DataGridView dgvMovimientos;
    }
}
