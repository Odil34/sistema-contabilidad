using sistema_contabilidad.Datos;

namespace sistema_contabilidad
{
    internal static class Program
    {
      
[STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Crea la base de datos, las tablas y el catálogo la primera vez que se ejecuta.
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

            Application.Run(new FrmPrincipal());
        }
    }
}
