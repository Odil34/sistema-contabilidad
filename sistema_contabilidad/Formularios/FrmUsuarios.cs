using sistema_contabilidad.Datos;
using sistema_contabilidad.Modelos;
using sistema_contabilidad.Seguridad;

namespace sistema_contabilidad.Formularios
{
    public partial class FrmUsuarios : Form
    {
        private readonly UsuarioDAL _usuarioDAL = new UsuarioDAL();

        public FrmUsuarios()
        {
            InitializeComponent();
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            cboRol.DataSource = _usuarioDAL.ListarRoles();
            CargarUsuarios();
        }

        private void CargarUsuarios()
        {
            dgvUsuarios.DataSource = _usuarioDAL.ObtenerTabla();
            if (dgvUsuarios.Columns.Contains("Id"))
                dgvUsuarios.Columns["Id"].Visible = false;

            dgvUsuarios.EnableHeadersVisualStyles = false;
            dgvUsuarios.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 71, 115);
            dgvUsuarios.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvUsuarios.ColumnHeadersDefaultCellStyle.Font = new Font(dgvUsuarios.Font, FontStyle.Bold);
            dgvUsuarios.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 243, 249);
            if (dgvUsuarios.Columns.Contains("Nombre completo"))
                dgvUsuarios.Columns["Nombre completo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string nombre = txtNombre.Text.Trim();
            string clave = txtClave.Text;

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(clave))
            {
                MessageBox.Show("El usuario y la contraseña son obligatorios.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (clave.Length < 5)
            {
                MessageBox.Show("La contraseña debe tener al menos 5 caracteres.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cboRol.SelectedItem is not Rol rol)
            {
                MessageBox.Show("Seleccione un rol.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (_usuarioDAL.Existe(usuario))
            {
                MessageBox.Show("Ya existe un usuario con ese nombre.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _usuarioDAL.Crear(usuario, nombre, clave, rol.IdRol);
                MessageBox.Show("Usuario creado correctamente.", "Usuarios",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUsuario.Clear();
                txtNombre.Clear();
                txtClave.Clear();
                CargarUsuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear el usuario:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActivar_Click(object sender, EventArgs e) => CambiarEstado(true);

        private void btnDesactivar_Click(object sender, EventArgs e) => CambiarEstado(false);

        private void CambiarEstado(bool activo)
        {
            if (!TryObtenerSeleccion(out int id, out string usuario)) return;

            if (!activo && usuario == Sesion.Actual.NombreUsuario)
            {
                MessageBox.Show("No puede desactivar su propio usuario mientras está en sesión.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _usuarioDAL.CambiarEstado(id, activo);
            CargarUsuarios();
        }

        private void btnResetClave_Click(object sender, EventArgs e)
        {
            if (!TryObtenerSeleccion(out int id, out string usuario)) return;

            string nueva = txtClave.Text;
            if (string.IsNullOrEmpty(nueva) || nueva.Length < 5)
            {
                MessageBox.Show(
                    "Escriba la nueva contraseña (mínimo 5 caracteres) en el campo 'Contraseña' y vuelva a intentar.",
                    "Restablecer contraseña", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _usuarioDAL.CambiarClave(id, nueva);
            txtClave.Clear();
            MessageBox.Show($"Contraseña de '{usuario}' restablecida.", "Usuarios",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool TryObtenerSeleccion(out int id, out string usuario)
        {
            id = 0; usuario = null;
            if (dgvUsuarios.CurrentRow == null || dgvUsuarios.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Seleccione un usuario de la lista.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            id = Convert.ToInt32(dgvUsuarios.CurrentRow.Cells["Id"].Value);
            usuario = dgvUsuarios.CurrentRow.Cells["Usuario"].Value?.ToString();
            return true;
        }
    }
}
