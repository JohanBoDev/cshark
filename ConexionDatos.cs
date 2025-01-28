using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRS
{
    internal class ConexionDatos
    {

        private static string servidorRemoto, usuarioRemoto, contrasenaRemoto, nombreBDRemoto;

        static ConexionDatos()
        {
            string[] lineas = File.ReadAllLines(@"C:\VRS\configuracion\configuracion.txt");

            foreach (string linea in lineas)
            {
                if (linea.StartsWith("ServidorRemoto="))
                    servidorRemoto = linea.Split('=')[1];
                else if (linea.StartsWith("UsuarioRemoto="))
                    usuarioRemoto = linea.Split('=')[1];
                else if (linea.StartsWith("ContrasenaRemoto="))
                    contrasenaRemoto = linea.Split('=')[1];
                else if (linea.StartsWith("NombreBDRemoto="))
                    nombreBDRemoto = linea.Split('=')[1];
            }
        }

        public static MySqlConnection ConexionServer()
        {
            string connectionStringRemoto = $"Server={servidorRemoto};Database={nombreBDRemoto};User ID={usuarioRemoto};Password={contrasenaRemoto};";

            MySqlConnection cn = new MySqlConnection(connectionStringRemoto);
            try
            {
                cn.Open();
                return cn;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }
        

    }
}
