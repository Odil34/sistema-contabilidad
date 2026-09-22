namespace sistema_contabilidad.Formularios
{
    partial class FrmDashboard
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
            lblSubtitulo = new Label();
            lblTitulo = new Label();
            pnlCuentas = new Panel();
            lblCuentas = new Label();
            lblCuentasCap = new Label();
            pnlDetalle = new Panel();
            lblDetalle = new Label();
            lblDetalleCap = new Label();
            pnlAsientos = new Panel();
            lblAsientos = new Label();
            lblAsientosCap = new Label();
            pnlMovimientos = new Panel();
            lblMovimientos = new Label();
            lblMovimientosCap = new Label();
            btnActualizar = new Button();
            lblNota = new Label();
            panelEncabezado.SuspendLayout();
            pnlCuentas.SuspendLayout();
            pnlDetalle.SuspendLayout();
            pnlAsientos.SuspendLayout();
            pnlMovimientos.SuspendLayout();
            SuspendLayout();
            //
            // panelEncabezado
            //
            panelEncabezado.BackColor = Color.FromArgb(33, 71, 115);
            panelEncabezado.Controls.Add(lblSubtitulo);
            panelEncabezado.Controls.Add(lblTitulo);
            panelEncabezado.Dock = DockStyle.Top;
            panelEncabezado.Location = new Point(0, 0);
            panelEncabezado.Name = "panelEncabezado";
            panelEncabezado.Size = new Size(960, 80);
            panelEncabezado.TabIndex = 0;
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(20, 14);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(316, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Panel de Control (Dashboard)";
            //
            // lblSubtitulo
            //
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Font = new Font("Segoe UI", 10F);
            lblSubtitulo.ForeColor = Color.Gainsboro;
            lblSubtitulo.Location = new Point(22, 50);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(268, 19);
            lblSubtitulo.TabIndex = 1;
            lblSubtitulo.Text = "Resumen general del sistema contable";
            //
            // pnlCuentas
            //
            pnlCuentas.BackColor = Color.FromArgb(238, 243, 249);
            pnlCuentas.Controls.Add(lblCuentas);
            pnlCuentas.Controls.Add(lblCuentasCap);
            pnlCuentas.Location = new Point(20, 110);
            pnlCuentas.Name = "pnlCuentas";
            pnlCuentas.Size = new Size(215, 120);
            pnlCuentas.TabIndex = 1;
            //
            // lblCuentas
            //
            lblCuentas.AutoSize = true;
            lblCuentas.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            lblCuentas.ForeColor = Color.FromArgb(33, 71, 115);
            lblCuentas.Location = new Point(15, 20);
            lblCuentas.Name = "lblCuentas";
            lblCuentas.Size = new Size(52, 62);
            lblCuentas.TabIndex = 0;
            lblCuentas.Text = "0";
            //
            // lblCuentasCap
            //
            lblCuentasCap.AutoSize = true;
            lblCuentasCap.Font = new Font("Segoe UI", 10F);
            lblCuentasCap.ForeColor = Color.FromArgb(70, 70, 70);
            lblCuentasCap.Location = new Point(18, 88);
            lblCuentasCap.Name = "lblCuentasCap";
            lblCuentasCap.Size = new Size(139, 19);
            lblCuentasCap.TabIndex = 1;
            lblCuentasCap.Text = "Cuentas en el catálogo";
            //
            // pnlDetalle
            //
            pnlDetalle.BackColor = Color.FromArgb(238, 243, 249);
            pnlDetalle.Controls.Add(lblDetalle);
            pnlDetalle.Controls.Add(lblDetalleCap);
            pnlDetalle.Location = new Point(250, 110);
            pnlDetalle.Name = "pnlDetalle";
            pnlDetalle.Size = new Size(215, 120);
            pnlDetalle.TabIndex = 2;
            //
            // lblDetalle
            //
            lblDetalle.AutoSize = true;
            lblDetalle.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            lblDetalle.ForeColor = Color.FromArgb(39, 128, 73);
            lblDetalle.Location = new Point(15, 20);
            lblDetalle.Name = "lblDetalle";
            lblDetalle.Size = new Size(52, 62);
            lblDetalle.TabIndex = 0;
            lblDetalle.Text = "0";
            //
            // lblDetalleCap
            //
            lblDetalleCap.AutoSize = true;
            lblDetalleCap.Font = new Font("Segoe UI", 10F);
            lblDetalleCap.ForeColor = Color.FromArgb(70, 70, 70);
            lblDetalleCap.Location = new Point(18, 88);
            lblDetalleCap.Name = "lblDetalleCap";
            lblDetalleCap.Size = new Size(126, 19);
            lblDetalleCap.TabIndex = 1;
            lblDetalleCap.Text = "Cuentas de detalle";
            //
            // pnlAsientos
            //
            pnlAsientos.BackColor = Color.FromArgb(238, 243, 249);
            pnlAsientos.Controls.Add(lblAsientos);
            pnlAsientos.Controls.Add(lblAsientosCap);
            pnlAsientos.Location = new Point(480, 110);
            pnlAsientos.Name = "pnlAsientos";
            pnlAsientos.Size = new Size(215, 120);
            pnlAsientos.TabIndex = 3;
            //
            // lblAsientos
            //
            lblAsientos.AutoSize = true;
            lblAsientos.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            lblAsientos.ForeColor = Color.FromArgb(196, 145, 20);
            lblAsientos.Location = new Point(15, 20);
            lblAsientos.Name = "lblAsientos";
            lblAsientos.Size = new Size(52, 62);
            lblAsientos.TabIndex = 0;
            lblAsientos.Text = "0";
            //
            // lblAsientosCap
            //
            lblAsientosCap.AutoSize = true;
            lblAsientosCap.Font = new Font("Segoe UI", 10F);
            lblAsientosCap.ForeColor = Color.FromArgb(70, 70, 70);
            lblAsientosCap.Location = new Point(18, 88);
            lblAsientosCap.Name = "lblAsientosCap";
            lblAsientosCap.Size = new Size(137, 19);
            lblAsientosCap.TabIndex = 1;
            lblAsientosCap.Text = "Asientos registrados";
            //
            // pnlMovimientos
            //
            pnlMovimientos.BackColor = Color.FromArgb(238, 243, 249);
            pnlMovimientos.Controls.Add(lblMovimientos);
            pnlMovimientos.Controls.Add(lblMovimientosCap);
            pnlMovimientos.Location = new Point(710, 110);
            pnlMovimientos.Name = "pnlMovimientos";
            pnlMovimientos.Size = new Size(215, 120);
            pnlMovimientos.TabIndex = 4;
            //
            // lblMovimientos
            //
            lblMovimientos.AutoSize = true;
            lblMovimientos.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            lblMovimientos.ForeColor = Color.FromArgb(120, 60, 120);
            lblMovimientos.Location = new Point(15, 20);
            lblMovimientos.Name = "lblMovimientos";
            lblMovimientos.Size = new Size(52, 62);
            lblMovimientos.TabIndex = 0;
            lblMovimientos.Text = "0";
            //
            // lblMovimientosCap
            //
            lblMovimientosCap.AutoSize = true;
            lblMovimientosCap.Font = new Font("Segoe UI", 10F);
            lblMovimientosCap.ForeColor = Color.FromArgb(70, 70, 70);
            lblMovimientosCap.Location = new Point(18, 88);
            lblMovimientosCap.Name = "lblMovimientosCap";
            lblMovimientosCap.Size = new Size(150, 19);
            lblMovimientosCap.TabIndex = 1;
            lblMovimientosCap.Text = "Movimientos contables";
            //
            // btnActualizar
            //
            btnActualizar.BackColor = Color.FromArgb(33, 71, 115);
            btnActualizar.FlatStyle = FlatStyle.Flat;
            btnActualizar.ForeColor = Color.White;
            btnActualizar.Location = new Point(20, 250);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(150, 34);
            btnActualizar.TabIndex = 5;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = false;
            btnActualizar.Click += btnActualizar_Click;
            //
            // lblNota
            //
            lblNota.AutoSize = true;
            lblNota.ForeColor = Color.Gray;
            lblNota.Location = new Point(20, 300);
            lblNota.Name = "lblNota";
            lblNota.Size = new Size(283, 20);
            lblNota.TabIndex = 6;
            lblNota.Text = "Use el menú superior para abrir los módulos.";
            //
            // FrmDashboard
            //
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(960, 560);
            Controls.Add(lblNota);
            Controls.Add(btnActualizar);
            Controls.Add(pnlMovimientos);
            Controls.Add(pnlAsientos);
            Controls.Add(pnlDetalle);
            Controls.Add(pnlCuentas);
            Controls.Add(panelEncabezado);
            Name = "FrmDashboard";
            Text = "Dashboard";
            Load += FrmDashboard_Load;
            panelEncabezado.ResumeLayout(false);
            panelEncabezado.PerformLayout();
            pnlCuentas.ResumeLayout(false);
            pnlCuentas.PerformLayout();
            pnlDetalle.ResumeLayout(false);
            pnlDetalle.PerformLayout();
            pnlAsientos.ResumeLayout(false);
            pnlAsientos.PerformLayout();
            pnlMovimientos.ResumeLayout(false);
            pnlMovimientos.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelEncabezado;
        private Label lblTitulo;
        private Label lblSubtitulo;
        private Panel pnlCuentas;
        private Label lblCuentas;
        private Label lblCuentasCap;
        private Panel pnlDetalle;
        private Label lblDetalle;
        private Label lblDetalleCap;
        private Panel pnlAsientos;
        private Label lblAsientos;
        private Label lblAsientosCap;
        private Panel pnlMovimientos;
        private Label lblMovimientos;
        private Label lblMovimientosCap;
        private Button btnActualizar;
        private Label lblNota;
    }
}
