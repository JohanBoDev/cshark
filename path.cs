using System;
using System.IO;
using System.Drawing;
using System.Windows;

namespace VRS
{
    public class PathHandler : IDisposable
    {
        private FileStream _pathStream;
        private bool _disposed = false;

        // Constructor que acepta una ruta de archivo
        public PathHandler(string path)
        {
            // Abre el archivo en modo de solo lectura
            if (File.Exists(path))
            {
                _pathStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            }
            else
            {
                _pathStream = null;
            }
        }

        // Devuelve la imagen si se ha abierto el archivo correctamente
        public Image GetImage()
        {
            if (_pathStream != null && _pathStream.CanRead && _pathStream.Length > 0)
            {
                _pathStream.Position = 0;
                try
                {
                    return Image.FromStream(_pathStream);
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show("El stream no contiene una imagen válida: " + ex.Message);
                    return null;
                }
            }
            return null;
        }


        // Implementación de Dispose para liberar los recursos
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Método privado para liberar recursos
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                // Aquí liberamos recursos gestionados, como el archivo
                if (_pathStream != null)
                {
                    _pathStream.Close();
                    _pathStream = null;
                }
            }

            // Aquí liberamos recursos no gestionados si los hubiera

            _disposed = true;
        }
    }
}
