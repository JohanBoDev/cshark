using System;
using System.Threading;
using System.Windows.Forms;

namespace VRS
{
    internal static class Program
    {
        // Declaramos el mutex
        private static Mutex mutex = null;

        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            const string appName = "VRS";
            bool nuevaInstancia;

            // Creamos un nuevo mutex y verificamos si ya existe una instancia
            mutex = new Mutex(true, appName, out nuevaInstancia);

            if (!nuevaInstancia)
            {
                MessageBox.Show("La aplicación ya se está ejecutando.");
                return;
            }

            try
            {
                // Activar los estilos visuales y la compatibilidad con el texto
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                // Ejecutar el formulario principal
                Application.Run(new Form1());
            }
            catch (Exception ex)
            {
                // Manejo de excepciones en caso de error al iniciar la aplicación
                MessageBox.Show("Error al iniciar la aplicación: " + ex.Message);
            }
            finally
            {
                // Liberar el mutex cuando la aplicación termine
                if (mutex != null)
                {
                    mutex.ReleaseMutex();
                }
            }
        }
    }
}
