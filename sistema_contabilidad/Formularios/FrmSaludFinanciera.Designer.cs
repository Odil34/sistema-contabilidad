namespace sistema_contabilidad.Formularios
{
    partial class FrmSaludFinanciera
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
            btnAnalizar = new Button();
            panelScore = new Panel();
            lblNivel = new Label();
            lblScore = new Label();
            lblScoreDesc = new Label();
            panelReco = new Panel();
            lblRecoTitulo = new Label();
            txtRecomendaciones = new TextBox();
            dgvIndicadores = new DataGridView();
            panelEncabezado.SuspendLayout();
            panelControles.SuspendLayout();
            panelScore.SuspendLayout();
            panelReco.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvIndicadores).BeginInit();
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
            lblTitulo.Size = new Size(447, 28);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Panel de Salud Financiera  ·  Indicadores y Diagnóstico";
            panelControles.Controls.Add(lblHasta);
            panelControles.Controls.Add(dtpHasta);
            panelControles.Controls.Add(btnAnalizar);
            panelControles.Dock = DockStyle.Top;
            panelControles.Location = new Point(0, 55);
            panelControles.Name = "panelControles";
            panelControles.Padding = new Padding(10, 8, 10, 8);
            panelControles.Size = new Size(900, 48);
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
            btnAnalizar.BackColor = Color.FromArgb(33, 71, 115);
            btnAnalizar.FlatStyle = FlatStyle.Flat;
            btnAnalizar.ForeColor = Color.White;
            btnAnalizar.Location = new Point(266, 8);
            btnAnalizar.Name = "btnAnalizar";
            btnAnalizar.Size = new Size(150, 30);
            btnAnalizar.TabIndex = 2;
            btnAnalizar.Text = "Analizar";
            btnAnalizar.UseVisualStyleBackColor = false;
            btnAnalizar.Click += btnAnalizar_Click;
            panelScore.BackColor = Color.FromArgb(90, 90, 90);
            panelScore.Controls.Add(lblNivel);
            panelScore.Controls.Add(lblScore);
            panelScore.Controls.Add(lblScoreDesc);
            panelScore.Dock = DockStyle.Top;
            panelScore.Location = new Point(0, 103);
            panelScore.Name = "panelScore";
            panelScore.Size = new Size(900, 95);
            panelScore.TabIndex = 2;
            lblNivel.AutoSize = true;
            lblNivel.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblNivel.ForeColor = Color.White;
            lblNivel.Location = new Point(16, 18);
            lblNivel.Name = "lblNivel";
            lblNivel.Size = new Size(180, 46);
            lblNivel.TabIndex = 0;
            lblNivel.Text = "SALUD";
            lblScore.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblScore.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            lblScore.ForeColor = Color.White;
            lblScore.Location = new Point(680, 15);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(200, 55);
            lblScore.TabIndex = 1;
            lblScore.Text = "0%";
            lblScore.TextAlign = ContentAlignment.MiddleRight;
            lblScoreDesc.AutoSize = true;
            lblScoreDesc.Font = new Font("Segoe UI", 9F);
            lblScoreDesc.ForeColor = Color.White;
            lblScoreDesc.Location = new Point(18, 64);
            lblScoreDesc.Name = "lblScoreDesc";
            lblScoreDesc.Size = new Size(310, 20);
            lblScoreDesc.TabIndex = 2;
            lblScoreDesc.Text = "Índice global de salud financiera de la empresa";
            panelReco.BackColor = Color.FromArgb(238, 243, 249);
            panelReco.Controls.Add(txtRecomendaciones);
            panelReco.Controls.Add(lblRecoTitulo);
            panelReco.Dock = DockStyle.Bottom;
            panelReco.Location = new Point(0, 443);
            panelReco.Name = "panelReco";
            panelReco.Padding = new Padding(10, 6, 10, 10);
            panelReco.Size = new Size(900, 157);
            panelReco.TabIndex = 4;
            lblRecoTitulo.Dock = DockStyle.Top;
            lblRecoTitulo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblRecoTitulo.ForeColor = Color.FromArgb(33, 71, 115);
            lblRecoTitulo.Location = new Point(10, 6);
            lblRecoTitulo.Name = "lblRecoTitulo";
            lblRecoTitulo.Size = new Size(880, 26);
            lblRecoTitulo.TabIndex = 0;
            lblRecoTitulo.Text = "Recomendaciones automáticas";
            txtRecomendaciones.BackColor = Color.White;
            txtRecomendaciones.BorderStyle = BorderStyle.FixedSingle;
            txtRecomendaciones.Dock = DockStyle.Fill;
            txtRecomendaciones.Location = new Point(10, 32);
            txtRecomendaciones.Multiline = true;
            txtRecomendaciones.Name = "txtRecomendaciones";
            txtRecomendaciones.ReadOnly = true;
            txtRecomendaciones.ScrollBars = ScrollBars.Vertical;
            txtRecomendaciones.Size = new Size(880, 115);
            txtRecomendaciones.TabIndex = 1;
            dgvIndicadores.AllowUserToAddRows = false;
            dgvIndicadores.AllowUserToDeleteRows = false;
            dgvIndicadores.BackgroundColor = Color.White;
            dgvIndicadores.BorderStyle = BorderStyle.None;
            dgvIndicadores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvIndicadores.Dock = DockStyle.Fill;
            dgvIndicadores.Location = new Point(0, 198);
            dgvIndicadores.Name = "dgvIndicadores";
            dgvIndicadores.ReadOnly = true;
            dgvIndicadores.RowHeadersVisible = false;
            dgvIndicadores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvIndicadores.Size = new Size(900, 245);
            dgvIndicadores.TabIndex = 3;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(900, 600);
            Controls.Add(dgvIndicadores);
            Controls.Add(panelReco);
            Controls.Add(panelScore);
            Controls.Add(panelControles);
            Controls.Add(panelEncabezado);
            Name = "FrmSaludFinanciera";
            Text = "Panel de Salud Financiera";
            Load += FrmSaludFinanciera_Load;
            panelEncabezado.ResumeLayout(false);
            panelEncabezado.PerformLayout();
            panelControles.ResumeLayout(false);
            panelControles.PerformLayout();
            panelScore.ResumeLayout(false);
            panelScore.PerformLayout();
            panelReco.ResumeLayout(false);
            panelReco.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvIndicadores).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelEncabezado;
        private Label lblTitulo;
        private Panel panelControles;
        private Label lblHasta;
        private DateTimePicker dtpHasta;
        private Button btnAnalizar;
        private Panel panelScore;
        private Label lblNivel;
        private Label lblScore;
        private Label lblScoreDesc;
        private Panel panelReco;
        private Label lblRecoTitulo;
        private TextBox txtRecomendaciones;
        private DataGridView dgvIndicadores;
    }
}
