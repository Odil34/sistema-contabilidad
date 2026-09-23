namespace sistema_contabilidad.Formularios
{
    partial class FrmUsuarios
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
            grpNuevo = new GroupBox();
            lblUsuarioCap = new Label();
            txtUsuario = new TextBox();
            lblNombreCap = new Label();
            txtNombre = new TextBox();
            lblClaveCap = new Label();
            txtClave = new TextBox();
            lblRolCap = new Label();
            cboRol = new ComboBox();
            btnCrear = new Button();
            dgvUsuarios = new DataGridView();
            panelAcciones = new Panel();
            btnActivar = new Button();
            btnDesactivar = new Button();
            btnResetClave = new Button();
            panelEncabezado.SuspendLayout();
            grpNuevo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            panelAcciones.SuspendLayout();
            SuspendLayout();
            panelEncabezado.BackColor = Color.FromArgb(33, 71, 115);
            panelEncabezado.Controls.Add(lblTitulo);
            panelEncabezado.Dock = DockStyle.Top;
            panelEncabezado.Location = new Point(0, 0);
            panelEncabezado.Name = "panelEncabezado";
            panelEncabezado.Size = new Size(820, 55);
            panelEncabezado.TabIndex = 0;
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(16, 12);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(273, 28);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Gestión de Usuarios y Roles";
            grpNuevo.Controls.Add(lblUsuarioCap);
            grpNuevo.Controls.Add(txtUsuario);
            grpNuevo.Controls.Add(lblNombreCap);
            grpNuevo.Controls.Add(txtNombre);
            grpNuevo.Controls.Add(lblClaveCap);
            grpNuevo.Controls.Add(txtClave);
            grpNuevo.Controls.Add(lblRolCap);
            grpNuevo.Controls.Add(cboRol);
            grpNuevo.Controls.Add(btnCrear);
            grpNuevo.Dock = DockStyle.Top;
            grpNuevo.Location = new Point(0, 55);
            grpNuevo.Name = "grpNuevo";
            grpNuevo.Padding = new Padding(10);
            grpNuevo.Size = new Size(820, 115);
            grpNuevo.TabIndex = 1;
            grpNuevo.TabStop = false;
            grpNuevo.Text = "Nuevo usuario";
            lblUsuarioCap.AutoSize = true;
            lblUsuarioCap.Location = new Point(15, 33);
            lblUsuarioCap.Name = "lblUsuarioCap";
            lblUsuarioCap.Size = new Size(62, 20);
            lblUsuarioCap.TabIndex = 0;
            lblUsuarioCap.Text = "Usuario:";
            txtUsuario.Location = new Point(83, 29);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(160, 27);
            txtUsuario.TabIndex = 1;
            lblNombreCap.AutoSize = true;
            lblNombreCap.Location = new Point(260, 33);
            lblNombreCap.Name = "lblNombreCap";
            lblNombreCap.Size = new Size(64, 20);
            lblNombreCap.TabIndex = 2;
            lblNombreCap.Text = "Nombre:";
            txtNombre.Location = new Point(330, 29);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(250, 27);
            txtNombre.TabIndex = 3;
            lblClaveCap.AutoSize = true;
            lblClaveCap.Location = new Point(15, 73);
            lblClaveCap.Name = "lblClaveCap";
            lblClaveCap.Size = new Size(85, 20);
            lblClaveCap.TabIndex = 4;
            lblClaveCap.Text = "Contraseña:";
            txtClave.Location = new Point(106, 69);
            txtClave.Name = "txtClave";
            txtClave.PasswordChar = '●';
            txtClave.Size = new Size(137, 27);
            txtClave.TabIndex = 5;
            lblRolCap.AutoSize = true;
            lblRolCap.Location = new Point(260, 73);
            lblRolCap.Name = "lblRolCap";
            lblRolCap.Size = new Size(35, 20);
            lblRolCap.TabIndex = 6;
            lblRolCap.Text = "Rol:";
            cboRol.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRol.FormattingEnabled = true;
            cboRol.Location = new Point(330, 69);
            cboRol.Name = "cboRol";
            cboRol.Size = new Size(200, 28);
            cboRol.TabIndex = 7;
            btnCrear.BackColor = Color.FromArgb(39, 128, 73);
            btnCrear.FlatStyle = FlatStyle.Flat;
            btnCrear.ForeColor = Color.White;
            btnCrear.Location = new Point(620, 64);
            btnCrear.Name = "btnCrear";
            btnCrear.Size = new Size(150, 34);
            btnCrear.TabIndex = 8;
            btnCrear.Text = "Crear usuario";
            btnCrear.UseVisualStyleBackColor = false;
            btnCrear.Click += btnCrear_Click;
            dgvUsuarios.AllowUserToAddRows = false;
            dgvUsuarios.AllowUserToDeleteRows = false;
            dgvUsuarios.BackgroundColor = Color.White;
            dgvUsuarios.BorderStyle = BorderStyle.None;
            dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsuarios.Dock = DockStyle.Fill;
            dgvUsuarios.Location = new Point(0, 170);
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.ReadOnly = true;
            dgvUsuarios.RowHeadersVisible = false;
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.Size = new Size(820, 325);
            dgvUsuarios.TabIndex = 2;
            panelAcciones.BackColor = Color.FromArgb(238, 243, 249);
            panelAcciones.Controls.Add(btnActivar);
            panelAcciones.Controls.Add(btnDesactivar);
            panelAcciones.Controls.Add(btnResetClave);
            panelAcciones.Dock = DockStyle.Bottom;
            panelAcciones.Location = new Point(0, 495);
            panelAcciones.Name = "panelAcciones";
            panelAcciones.Padding = new Padding(10, 8, 10, 8);
            panelAcciones.Size = new Size(820, 50);
            panelAcciones.TabIndex = 3;
            btnActivar.FlatStyle = FlatStyle.Flat;
            btnActivar.Location = new Point(16, 8);
            btnActivar.Name = "btnActivar";
            btnActivar.Size = new Size(120, 32);
            btnActivar.TabIndex = 0;
            btnActivar.Text = "Activar";
            btnActivar.UseVisualStyleBackColor = true;
            btnActivar.Click += btnActivar_Click;
            btnDesactivar.FlatStyle = FlatStyle.Flat;
            btnDesactivar.Location = new Point(145, 8);
            btnDesactivar.Name = "btnDesactivar";
            btnDesactivar.Size = new Size(120, 32);
            btnDesactivar.TabIndex = 1;
            btnDesactivar.Text = "Desactivar";
            btnDesactivar.UseVisualStyleBackColor = true;
            btnDesactivar.Click += btnDesactivar_Click;
            btnResetClave.FlatStyle = FlatStyle.Flat;
            btnResetClave.Location = new Point(285, 8);
            btnResetClave.Name = "btnResetClave";
            btnResetClave.Size = new Size(180, 32);
            btnResetClave.TabIndex = 2;
            btnResetClave.Text = "Restablecer contraseña";
            btnResetClave.UseVisualStyleBackColor = true;
            btnResetClave.Click += btnResetClave_Click;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(820, 545);
            Controls.Add(dgvUsuarios);
            Controls.Add(panelAcciones);
            Controls.Add(grpNuevo);
            Controls.Add(panelEncabezado);
            Name = "FrmUsuarios";
            Text = "Gestión de Usuarios";
            Load += FrmUsuarios_Load;
            panelEncabezado.ResumeLayout(false);
            panelEncabezado.PerformLayout();
            grpNuevo.ResumeLayout(false);
            grpNuevo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            panelAcciones.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelEncabezado;
        private Label lblTitulo;
        private GroupBox grpNuevo;
        private Label lblUsuarioCap;
        private TextBox txtUsuario;
        private Label lblNombreCap;
        private TextBox txtNombre;
        private Label lblClaveCap;
        private TextBox txtClave;
        private Label lblRolCap;
        private ComboBox cboRol;
        private Button btnCrear;
        private DataGridView dgvUsuarios;
        private Panel panelAcciones;
        private Button btnActivar;
        private Button btnDesactivar;
        private Button btnResetClave;
    }
}
