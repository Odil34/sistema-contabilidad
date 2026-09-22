namespace sistema_contabilidad
{
    partial class FrmPrincipal
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
            menuPrincipal = new MenuStrip();
            menuArchivo = new ToolStripMenuItem();
            menuSalir = new ToolStripMenuItem();
            menuCatalogo = new ToolStripMenuItem();
            menuCatalogoCuentas = new ToolStripMenuItem();
            menuVer = new ToolStripMenuItem();
            menuDashboard = new ToolStripMenuItem();
            menuAyuda = new ToolStripMenuItem();
            menuAcercaDe = new ToolStripMenuItem();
            barraEstado = new StatusStrip();
            lblEstado = new ToolStripStatusLabel();
            lblFecha = new ToolStripStatusLabel();
            menuPrincipal.SuspendLayout();
            barraEstado.SuspendLayout();
            SuspendLayout();
            //
            // menuPrincipal
            //
            menuPrincipal.ImageScalingSize = new Size(20, 20);
            menuPrincipal.Items.AddRange(new ToolStripItem[] { menuArchivo, menuCatalogo, menuVer, menuAyuda });
            menuPrincipal.Location = new Point(0, 0);
            menuPrincipal.Name = "menuPrincipal";
            menuPrincipal.Padding = new Padding(6, 3, 0, 3);
            menuPrincipal.Size = new Size(984, 30);
            menuPrincipal.TabIndex = 0;
            //
            // menuArchivo
            //
            menuArchivo.DropDownItems.AddRange(new ToolStripItem[] { menuSalir });
            menuArchivo.Name = "menuArchivo";
            menuArchivo.Size = new Size(73, 24);
            menuArchivo.Text = "&Archivo";
            //
            // menuSalir
            //
            menuSalir.Name = "menuSalir";
            menuSalir.Size = new Size(224, 26);
            menuSalir.Text = "&Salir";
            menuSalir.Click += menuSalir_Click;
            //
            // menuCatalogo
            //
            menuCatalogo.DropDownItems.AddRange(new ToolStripItem[] { menuCatalogoCuentas });
            menuCatalogo.Name = "menuCatalogo";
            menuCatalogo.Size = new Size(83, 24);
            menuCatalogo.Text = "&Catálogo";
            //
            // menuCatalogoCuentas
            //
            menuCatalogoCuentas.Name = "menuCatalogoCuentas";
            menuCatalogoCuentas.Size = new Size(240, 26);
            menuCatalogoCuentas.Text = "Catálogo de &Cuentas";
            menuCatalogoCuentas.Click += menuCatalogoCuentas_Click;
            //
            // menuVer
            //
            menuVer.DropDownItems.AddRange(new ToolStripItem[] { menuDashboard });
            menuVer.Name = "menuVer";
            menuVer.Size = new Size(45, 24);
            menuVer.Text = "&Ver";
            //
            // menuDashboard
            //
            menuDashboard.Name = "menuDashboard";
            menuDashboard.Size = new Size(240, 26);
            menuDashboard.Text = "&Dashboard";
            menuDashboard.Click += menuDashboard_Click;
            //
            // menuAyuda
            //
            menuAyuda.DropDownItems.AddRange(new ToolStripItem[] { menuAcercaDe });
            menuAyuda.Name = "menuAyuda";
            menuAyuda.Size = new Size(66, 24);
            menuAyuda.Text = "A&yuda";
            //
            // menuAcercaDe
            //
            menuAcercaDe.Name = "menuAcercaDe";
            menuAcercaDe.Size = new Size(224, 26);
            menuAcercaDe.Text = "&Acerca de...";
            menuAcercaDe.Click += menuAcercaDe_Click;
            //
            // barraEstado
            //
            barraEstado.ImageScalingSize = new Size(20, 20);
            barraEstado.Items.AddRange(new ToolStripItem[] { lblEstado, lblFecha });
            barraEstado.Location = new Point(0, 639);
            barraEstado.Name = "barraEstado";
            barraEstado.Padding = new Padding(1, 0, 16, 0);
            barraEstado.Size = new Size(984, 22);
            barraEstado.TabIndex = 1;
            //
            // lblEstado
            //
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(151, 16);
            lblEstado.Spring = true;
            lblEstado.Text = "Listo";
            lblEstado.TextAlign = ContentAlignment.MiddleLeft;
            //
            // lblFecha
            //
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(39, 16);
            lblFecha.Text = "Fecha";
            //
            // FrmPrincipal
            //
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 661);
            Controls.Add(barraEstado);
            Controls.Add(menuPrincipal);
            IsMdiContainer = true;
            MainMenuStrip = menuPrincipal;
            Name = "FrmPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sistema de Contabilidad";
            WindowState = FormWindowState.Maximized;
            Load += FrmPrincipal_Load;
            menuPrincipal.ResumeLayout(false);
            menuPrincipal.PerformLayout();
            barraEstado.ResumeLayout(false);
            barraEstado.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuPrincipal;
        private ToolStripMenuItem menuArchivo;
        private ToolStripMenuItem menuSalir;
        private ToolStripMenuItem menuCatalogo;
        private ToolStripMenuItem menuCatalogoCuentas;
        private ToolStripMenuItem menuVer;
        private ToolStripMenuItem menuDashboard;
        private ToolStripMenuItem menuAyuda;
        private ToolStripMenuItem menuAcercaDe;
        private StatusStrip barraEstado;
        private ToolStripStatusLabel lblEstado;
        private ToolStripStatusLabel lblFecha;
    }
}
