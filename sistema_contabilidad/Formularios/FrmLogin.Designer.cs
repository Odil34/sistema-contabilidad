namespace sistema_contabilidad.Formularios
{
    partial class FrmLogin
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
            panelHeader = new Panel();
            lblSubtitulo = new Label();
            lblTitulo = new Label();
            lblUsuario = new Label();
            txtUsuario = new TextBox();
            lblClave = new Label();
            txtClave = new TextBox();
            lblError = new Label();
            btnIngresar = new Button();
            btnCancelar = new Button();
            lblHint = new Label();
            panelHeader.SuspendLayout();
            SuspendLayout();
            panelHeader.BackColor = Color.FromArgb(33, 71, 115);
            panelHeader.Controls.Add(lblSubtitulo);
            panelHeader.Controls.Add(lblTitulo);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(400, 80);
            panelHeader.TabIndex = 0;
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(20, 14);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(266, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Sistema de Contabilidad";
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Font = new Font("Segoe UI", 10F);
            lblSubtitulo.ForeColor = Color.Gainsboro;
            lblSubtitulo.Location = new Point(22, 48);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(101, 19);
            lblSubtitulo.TabIndex = 1;
            lblSubtitulo.Text = "Iniciar sesión";
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new Point(30, 105);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(62, 20);
            lblUsuario.TabIndex = 1;
            lblUsuario.Text = "Usuario:";
            txtUsuario.Location = new Point(30, 128);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(340, 27);
            txtUsuario.TabIndex = 0;
            lblClave.AutoSize = true;
            lblClave.Location = new Point(30, 165);
            lblClave.Name = "lblClave";
            lblClave.Size = new Size(85, 20);
            lblClave.TabIndex = 3;
            lblClave.Text = "Contraseña:";
            txtClave.Location = new Point(30, 188);
            txtClave.Name = "txtClave";
            txtClave.PasswordChar = '●';
            txtClave.Size = new Size(340, 27);
            txtClave.TabIndex = 1;
            lblError.AutoSize = true;
            lblError.ForeColor = Color.FromArgb(150, 40, 40);
            lblError.Location = new Point(30, 222);
            lblError.Name = "lblError";
            lblError.Size = new Size(0, 20);
            lblError.TabIndex = 5;
            btnIngresar.BackColor = Color.FromArgb(33, 71, 115);
            btnIngresar.FlatStyle = FlatStyle.Flat;
            btnIngresar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnIngresar.ForeColor = Color.White;
            btnIngresar.Location = new Point(30, 250);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(220, 40);
            btnIngresar.TabIndex = 2;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = false;
            btnIngresar.Click += btnIngresar_Click;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Location = new Point(260, 250);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(110, 40);
            btnCancelar.TabIndex = 3;
            btnCancelar.Text = "Salir";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            lblHint.ForeColor = Color.Gray;
            lblHint.Location = new Point(30, 300);
            lblHint.Name = "lblHint";
            lblHint.Size = new Size(340, 40);
            lblHint.TabIndex = 7;
            lblHint.Text = "Usuario inicial: admin / admin123";
            AcceptButton = btnIngresar;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancelar;
            ClientSize = new Size(400, 350);
            Controls.Add(lblHint);
            Controls.Add(btnCancelar);
            Controls.Add(btnIngresar);
            Controls.Add(lblError);
            Controls.Add(txtClave);
            Controls.Add(lblClave);
            Controls.Add(txtUsuario);
            Controls.Add(lblUsuario);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Iniciar sesión";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelHeader;
        private Label lblTitulo;
        private Label lblSubtitulo;
        private Label lblUsuario;
        private TextBox txtUsuario;
        private Label lblClave;
        private TextBox txtClave;
        private Label lblError;
        private Button btnIngresar;
        private Button btnCancelar;
        private Label lblHint;
    }
}
