using sistema_contabilidad.Datos;
using sistema_contabilidad.Formularios;
using sistema_contabilidad.Seguridad;

namespace sistema_contabilidad
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            try
            {
                InicializadorBD.Inicializar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo conectar o crear la base de datos SQL Server.\n\n" +
                    "Verifique la cadena de conexión en el archivo de configuración (App.config).\n\n" +
                    "Detalle: " + ex.Message,
                    "Error de base de datos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            while (true)
            {
                using (var login = new FrmLogin())
                {
                    if (login.ShowDialog() != DialogResult.OK || Sesion.Actual == null)
                        return;
                }

                var principal = new FrmPrincipal();
                Application.Run(principal);

                if (!principal.CerrarSesionSolicitada)
                    break;

                Sesion.Cerrar();
            }
        }
    }
}
