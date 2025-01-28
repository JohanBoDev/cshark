using AForge.Video.DirectShow;
using AForge.Video;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using RJCodeAdvance.RJControls;

namespace VRS
{
    public partial class PanelCentral : Form, IDisposable
    {

         // Esto asegura que el texto se alinee a la izquierda
        public FilterInfoCollection MisDispositivos;
        public VideoCaptureDevice MyWebCam;
        public bool HayDispositivos;


        private FilterInfoCollection videoDevices;  // Dispositivos de video disponibles
        private VideoCaptureDevice videoSource;     // Dispositivo de captura
        private Bitmap currentFrame;               // Fotograma actual
        private bool isCameraRunning = false;      // Controla el estado de la cámara

        string estado_registro;

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Application.Exit();
        }
       
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            serialPort1.Write(dataOUT);
            var SEND_DATA = serialPort1.ReadExisting();
            if (rjRadioButton1.Checked == true)
            {
                try
                {
                    try
                    {
                        //---------------Quitar letras de toda la cadena------------------
                        char[] quitar = { '\'', 'Q', 'W', 'E', 'R', 'T', 'Y', 'U', 'I', 'O', 'P', 'A', 'S', 'D', 'F', 'G', 'H', 'J', 'K', 'L', 'Z', 'X', 'C', 'V', 'B', 'N', 'M' };
                        data = SEND_DATA.Split(quitar);
                        //--------------Cedula Numero 1------------
                        cc_data = (data[4]);
                        cedula = cc_data.Substring(18, 10);
                    }
                    catch
                    {
                        try
                        {
                            //---------------Quitar letras de toda la cadena------------------
                            char[] quitar = { ' ', 'Q', 'W', 'E', 'R', 'T', 'Y', 'U', 'I', 'O', 'P', 'A', 'S', 'D', 'F', 'G', 'H', 'J', 'K', 'L', 'Z', 'X', 'C', 'V', 'B', 'N', 'M' };
                            data = SEND_DATA.Split(quitar);
                            //--------------Cedula Numero 2 ------------
                            cc_data = (data[16]);
                            cedula = cc_data.Substring(8, 10);
                        }
                        catch
                        {

                        }
                    }

                    Invoke(new MethodInvoker(() =>
                    {
                        txtCedula.Texts = cedula;
                        txtPais.Texts = "COL";
                        txtNombre.Focus();
                    }));
                }
                catch
                {

                }

            }

            //-----------cedula digital--------------------

            if (rjRadioButton2.Checked == true)
            {
                try
                {
                    //---------------------numero de cedula digital----------------
                    char[] quitar = { '<' };
                    try
                    {
                        data = SEND_DATA.Split(quitar);

                        cc_data = (data[10]);
                        char[] quitar1 = { 'C', 'O', 'L' };
                        data1 = cc_data.Split(quitar1);
                        cedula = (data1[3]);
                        //------------------sacar nombres y apellidos------------------
                        val_apellidos = (data[13]);
                        if (val_apellidos != "")
                        {
                            char[] quitar2 = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
                            data2 = val_apellidos.Split(quitar2);
                            apellido1 = (data2[1]);
                            apellido2 = (data[14]);
                            nombre1 = (data[16]);
                            nombre2 = (data[17]);
                        }
                        else
                        {
                            val_apellidos = (data[11]);
                            char[] quitar2 = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
                            data2 = val_apellidos.Split(quitar2);
                            apellido1 = (data2[1]);
                            apellido2 = (data[12]);
                            nombre1 = (data[14]);
                            nombre2 = (data[15]);
                        }
                    }
                    catch
                    {

                    }
                    Invoke(new MethodInvoker(() =>
                    {
                        txtCedula.Texts = cedula;
                        txtNombre.Texts = $"{nombre1} {nombre2}";
                        txtApellidos.Texts = $"{apellido1} {apellido2}";
                        txtPais.Texts = "COL";

                        txtCedula.Enabled = false;
                        txtNombre.Enabled = true;
                        txtApellidos.Enabled = true;
                        txtPais.Enabled = true;
                    }));
                }
                catch
                {

                }

            }
            //------------pasaporte---------------
            else
            {
                try
                {
                    if (rjRadioButton3.Checked == true)
                    {

                        char[] quitar = { '<' };
                        data = SEND_DATA.Split(quitar);
                        string cedula1 = (data[10]);
                        if (cedula1 != "")
                        {
                            cedula = cedula1.Substring(0, 10);
                            string data_ape = (data[1]);
                            pais = data_ape.Substring(0, 3);
                            apellido2 = (data[2]);
                            nombre1 = (data[4]);
                            nombre2 = (data[5]);
                            //  MostrarPais(pais);
                        }
                        else
                        {
                            cedula = (data[13]);
                            if (cedula != "")
                            {
                                cedula = (data[13]);
                            }
                            else
                            {
                                cedula = (data[14]);
                            }
                            apellido1 = (data[0]);
                            apellido2 = (data[1]);
                            nombre1 = (data[3]);
                            nombre2 = (data[4]);
                        }


                    }
                }
                catch
                {

                }

            }
            //-----------------------Tarjeta de identidad------
            if (rjRadioButton4.Checked == true)
            {
                try
                {

                    var regexPattern = @"(?<=\0)[A-Z0-9]+(?=\0)";

                    var matches = Regex.Matches(SEND_DATA, regexPattern);

                    //for (int i = 0; i < matches.Count; i++)
                    //{
                    //    MessageBox.Show($"Match {i}: {matches[i].Value}");
                    //}

                    string numero = matches[0].Value;
                    string apellido1 = matches[1].Value;
                    string apellido2 = matches[2].Value;
                    string nombre1 = matches[3].Value;
                    string nombre2 = matches.Count > 4 ? matches[4].Value : " ";
                    string nombre2_valido;

                    if (EsSoloLetras(nombre2))
                    {
                        nombre2_valido = nombre2;
                    }
                    else
                    {
                        nombre2_valido = "";
                    }
                    if (numero.Length > 10)
                    {
                        numero = numero.Substring(numero.Length - 10);
                    }
                    Invoke(new MethodInvoker(() =>
                    {
                        txtCedula.Texts = numero;
                        txtNombre.Texts = $"{nombre1} {nombre2_valido}";
                        txtApellidos.Texts = $"{apellido1} {apellido2}";
                        txtPais.Texts = "COL";
                        txtCedula.Enabled = false;
                        txtNombre.Enabled = true;
                        txtApellidos.Enabled = true;
                        txtPais.Enabled = true;

                    }));
                }
                catch
                {

                }
            }
            //----------licencia de conduccion------
            if (rjRadioButton5.Checked == true)
            {
                try
                {
                    char[] quitar = { ' ' };
                    data = SEND_DATA.Split(quitar);
                    string numero = (data[0]);
                    numero = numero.Substring(0, numero.Length - 2);
                    string apellido1 = (data[13]);
                    string apellido2 = (data[33]);
                    string nombre1 = (data[52]);
                    string nombre2 = "";
                    Invoke(new MethodInvoker(() =>
                    {
                        txtCedula.Texts = numero;
                        txtNombre.Texts = $"{nombre1} {nombre2}";
                        txtApellidos.Texts = $"{apellido1} {apellido2}";
                        txtPais.Texts = "COL";
                        txtCedula.Enabled = false;
                        txtNombre.Enabled = true;
                        txtApellidos.Enabled = true;
                        txtPais.Enabled = true;

                    }));
                }
                catch
                {

                }
            }
        }
        public static bool EsSoloLetras(string input)
        {
            return Regex.IsMatch(input, @"^[a-zA-Z]+$");
        }

        int estado_foto = 0;


        string dataOUT = "";
        string[] data;
        string[] data1;
        string[] data2;
        string cc_data;
        string cedula, nombre1, nombre2, apellido1, apellido2, pais, val_apellidos;

        private void rjButton2_Click(object sender, EventArgs e)
        {
            // Alternar entre iniciar y detener la cámara
            if (isCameraRunning)
            {
                //MessageBox.Show("detener: "+isCameraRunning);
                detenerCamara();  // Detener la cámara si está activa
                isCameraRunning = false;

            }
            else
            {
                //MessageBox.Show("activar: " + isCameraRunning);
                activarCamara();  // Iniciar la cámara si está inactiva
                isCameraRunning = true;
            }
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            string cedulaOriginal = txtCedula.Texts.Trim(); // Obtener el texto sin ceros a la izquierda
            string cedulaSinCeros = cedulaOriginal.TrimStart('0'); // Eliminar ceros a la izquierda
            string cedulaFinal;
            if (cedulaSinCeros.Length < 10)
            {
                // Si tiene menos de 10 dígitos, completar con ceros a la izquierda
                cedulaFinal = cedulaSinCeros.PadLeft(10, '0');
            }
            else if (cedulaSinCeros.Length > 10)
            {
                // Si tiene más de 10 dígitos, tomar solo los últimos 10
                cedulaFinal = cedulaSinCeros.Substring(cedulaSinCeros.Length - 10);
            }
            else
            {
                // Si ya tiene exactamente 10 dígitos
                cedulaFinal = cedulaSinCeros;
            }
            // Ahora cedulaFinal tiene siempre 10 dígitos
            if (rjToggleButton1.Checked == true)
            {
                estado_registro = "2";
            }
            else
            {
                estado_registro = "0";
            }
            try
            {
                if (label83.Text == "Guardar")
            {
                    if (comboBox1.SelectedItem == null || comboBox1.Text == "Selecciona la oficina" ||
                        string.IsNullOrEmpty(txtCedula.Texts) ||
                        string.IsNullOrEmpty(txtNombre.Texts) ||
                        string.IsNullOrEmpty(rjTextBox1.Texts) ||
                        string.IsNullOrEmpty(txtApellidos.Texts))
                    {
                        MessageBox.Show("Por favor, complete todos los campos antes de guardar.", "Campos incompletos");
                        return;
                    }
                    else
                {

                    if (estado_foto == 1)
                    {
                        string fecha1 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                        string sql1 = "INSERT INTO transacciones_creacion (cedula, nombres, apellidos, autoriza, oficina, Empresa, Observaciones, fecha, pais, AUTORIZA_SEGUIR) " +
                                      "VALUES (@cedula, @nombres, @apellidos, @autoriza, @oficina, @empresa, @observaciones, @fecha, @pais, @a)";

                        using (MySqlCommand comando = new MySqlCommand(sql1, conexionBD))
                        {
                            comando.Parameters.AddWithValue("@cedula", cedulaFinal);
                            comando.Parameters.AddWithValue("@nombres", txtNombre.Texts.Trim());
                            comando.Parameters.AddWithValue("@apellidos", txtApellidos.Texts.Trim());
                            comando.Parameters.AddWithValue("@autoriza", rjTextBox1.Texts);
                            comando.Parameters.AddWithValue("@oficina", comboBox1.Text.Trim());
                            comando.Parameters.AddWithValue("@empresa", txtEmpresa.Texts.Trim());
                            comando.Parameters.AddWithValue("@observaciones", txtObservaciones.Texts.Trim());
                            comando.Parameters.AddWithValue("@fecha", fecha1);
                            comando.Parameters.AddWithValue("@pais", txtPais.Texts.Trim());
                            comando.Parameters.AddWithValue("@a", $"{nombreFunci}");
                            comando.ExecuteNonQuery();
                        }

                        string sql2 = "INSERT INTO vistatntes_registrados (cedula, nombres, apellidos, autoriza, oficina, Empresa, Observaciones, fecha, AUTORIZA_SEGUIR ) " +
                                      "VALUES (@cedula, @nombres, @apellidos, @autoriza, @oficina, @empresa, @observaciones, @fecha, @autoriza1)";

                        using (MySqlCommand comando2 = new MySqlCommand(sql2, conexionBD))
                        {
                            comando2.Parameters.AddWithValue("@cedula", cedulaFinal);
                            comando2.Parameters.AddWithValue("@nombres", txtNombre.Texts.Trim());
                            comando2.Parameters.AddWithValue("@apellidos", txtApellidos.Texts.Trim());
                            comando2.Parameters.AddWithValue("@autoriza", rjTextBox1.Texts);
                            comando2.Parameters.AddWithValue("@oficina", comboBox1.Text.Trim());
                            comando2.Parameters.AddWithValue("@empresa", txtEmpresa.Texts.Trim());
                            comando2.Parameters.AddWithValue("@observaciones", txtObservaciones.Texts.Trim());
                            comando2.Parameters.AddWithValue("@fecha", fecha1);
                            comando2.Parameters.AddWithValue("@autoriza1",nombreFunci);
                            comando2.ExecuteNonQuery();
                        }

                        string sql3 = "INSERT INTO entradas (identificacion, nombre, apellidos, estado, torre) " +
                                      "VALUES (@identificacion, @nombre, @apellidos, @estado, @torre)";

                        using (MySqlCommand comando3 = new MySqlCommand(sql3, conexionBD))
                        {
                            comando3.Parameters.AddWithValue("@identificacion", cedulaFinal);
                            comando3.Parameters.AddWithValue("@nombre", txtNombre.Texts.Trim());
                            comando3.Parameters.AddWithValue("@apellidos", txtApellidos.Texts.Trim());
                            comando3.Parameters.AddWithValue("@estado", estado_registro);
                            comando3.Parameters.AddWithValue("@torre", "1");
                            comando3.ExecuteNonQuery();
                        }

                        string sql4 = "INSERT INTO salidas (identificacion, nombre, apellidos, estado, torre) " +
                                      "VALUES (@identificacion, @nombre, @apellidos, @estado, @torre)";

                        using (MySqlCommand comando4 = new MySqlCommand(sql4, conexionBD))
                        {
                            comando4.Parameters.AddWithValue("@identificacion", cedulaFinal);
                            comando4.Parameters.AddWithValue("@nombre", txtNombre.Texts.Trim());
                            comando4.Parameters.AddWithValue("@apellidos", txtApellidos.Texts.Trim());
                            comando4.Parameters.AddWithValue("@estado", estado_registro);
                            comando4.Parameters.AddWithValue("@torre", "1");
                            comando4.ExecuteNonQuery();
                        }
                            Form Formulario = new impresion(cedulaFinal, txtNombre.Texts, txtApellidos.Texts, txtPais.Texts, comboBox1.Text, rjTextBox1.Texts, txtEmpresa.Texts, txtObservaciones.Texts);
                            Formulario.Show();
                            //MessageBox.Show("¡Registro insertado con éxito!");
                            cleanAll();
                            if (rjCircularPictureBox2.Image != null)
                            {
                                rjCircularPictureBox2.Image.Dispose();
                                rjCircularPictureBox2.Image = null;
                            }

                            if (rjCircularPictureBox3.Image != null)
                            {
                                rjCircularPictureBox3.Image.Dispose();
                                rjCircularPictureBox3.Image = null;
                            }

                        }
                    else
                    {
                        MessageBox.Show("Se necesita un registro de foto!");
                    }
                }
            }
            else if (label83.Text == "Guardar cambios")
            {
                    if (comboBox1.SelectedItem == null || comboBox1.Text == "Selecciona la oficina" ||
                           string.IsNullOrEmpty(txtCedula.Texts) ||
                           string.IsNullOrEmpty(txtNombre.Texts) ||
                           string.IsNullOrEmpty(rjTextBox1.Texts) ||
                           string.IsNullOrEmpty(txtApellidos.Texts))
                    {
                        MessageBox.Show("Por favor, complete todos los campos antes de guardar.", "Campos incompletos");
                        return;
                    }
                    else
                {
                    string selectEntradas = "SELECT * FROM entradas WHERE identificacion = @cedula";
                    using (MySqlCommand readerEntradas = new MySqlCommand(selectEntradas, conexionBD))
                    {
                        readerEntradas.Parameters.AddWithValue("@cedula", cedulaFinal);

                        using (MySqlDataReader reader = readerEntradas.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                // Cerrar el reader antes de ejecutar otros comandos
                                reader.Close();


                                string fecha1 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                string sqlUpdate = "UPDATE transacciones_creacion SET " +
                                                   "nombres = @nombres, apellidos = @apellidos, autoriza = @autoriza, oficina = @oficina, " +
                                                   "Empresa = @empresa, Observaciones = @observaciones, fecha = @fecha, AUTORIZA_SEGUIR = @a " +
                                                   "WHERE cedula = @cedula";

                                using (MySqlCommand comandoUpdate = new MySqlCommand(sqlUpdate, conexionBD))
                                {
                                    comandoUpdate.Parameters.AddWithValue("@nombres", txtNombre.Texts.Trim());
                                    comandoUpdate.Parameters.AddWithValue("@apellidos", txtApellidos.Texts.Trim());
                                    comandoUpdate.Parameters.AddWithValue("@autoriza", rjTextBox1.Texts);
                                    comandoUpdate.Parameters.AddWithValue("@oficina", comboBox1.Text.Trim());
                                    comandoUpdate.Parameters.AddWithValue("@empresa", txtEmpresa.Texts.Trim());
                                    comandoUpdate.Parameters.AddWithValue("@observaciones", txtObservaciones.Texts.Trim());
                                    comandoUpdate.Parameters.AddWithValue("@fecha", fecha1);
                                    comandoUpdate.Parameters.AddWithValue("@a", nombreFunci);
                                    comandoUpdate.Parameters.AddWithValue("@cedula", cedulaFinal);
                                    comandoUpdate.ExecuteNonQuery();
                                }

                                string sql2 = "INSERT INTO vistatntes_registrados (cedula, nombres, apellidos, autoriza, oficina, Empresa, Observaciones, fecha, AUTORIZA_SEGUIR) " +
                                              "VALUES (@cedula, @nombres, @apellidos, @autoriza, @oficina, @empresa, @observaciones, @fecha, @autoriza1)";

                                using (MySqlCommand comando2 = new MySqlCommand(sql2, conexionBD))
                                {
                                    comando2.Parameters.AddWithValue("@cedula", cedulaFinal);
                                    comando2.Parameters.AddWithValue("@nombres", txtNombre.Texts.Trim());
                                    comando2.Parameters.AddWithValue("@apellidos", txtApellidos.Texts.Trim());
                                    comando2.Parameters.AddWithValue("@autoriza", rjTextBox1.Texts);
                                    comando2.Parameters.AddWithValue("@oficina", comboBox1.Text.Trim());
                                    comando2.Parameters.AddWithValue("@empresa", txtEmpresa.Texts.Trim());
                                    comando2.Parameters.AddWithValue("@observaciones", txtObservaciones.Texts.Trim());
                                    comando2.Parameters.AddWithValue("@fecha", fecha1);
                                    comando2.Parameters.AddWithValue("@autoriza1", nombreFunci);
                                    comando2.ExecuteNonQuery();
                                }

                                string updateQuery = "UPDATE entradas " +
                                                     "SET nombre = @nombre, apellidos = @apellidos, estado = @estado, torre = @torre, fecha_hora = @fecha " +
                                                     "WHERE identificacion = @identificacion";

                                using (MySqlCommand command = new MySqlCommand(updateQuery, conexionBD))
                                {
                                    command.Parameters.AddWithValue("@nombre", txtNombre.Texts.Trim());
                                    command.Parameters.AddWithValue("@apellidos", txtApellidos.Texts.Trim());
                                    command.Parameters.AddWithValue("@estado", estado_registro);
                                    command.Parameters.AddWithValue("@torre", "1");
                                    command.Parameters.AddWithValue("@fecha", fecha1);
                                    command.Parameters.AddWithValue("@identificacion", cedulaFinal);
                                    command.ExecuteNonQuery();
                                }

                                string updateQuery2 = "UPDATE salidas " +
                                "SET nombre = @nombre, apellidos = @apellidos, estado = @estado, torre = @torre, fecha_hora = @fecha " +
                                "WHERE identificacion = @identificacion";

                                string selectQuery = "SELECT COUNT(*) FROM salidas WHERE identificacion = @identificacion";

                                using (MySqlCommand selectCommand = new MySqlCommand(selectQuery, conexionBD))
                                {
                                    selectCommand.Parameters.AddWithValue("@identificacion", cedulaFinal);

                                    int recordCount = Convert.ToInt32(selectCommand.ExecuteScalar());

                                    if (recordCount > 0)
                                    {
                                        // Si el registro existe, realiza la actualización
                                        using (MySqlCommand updateCommand = new MySqlCommand(updateQuery2, conexionBD))
                                        {
                                            updateCommand.Parameters.AddWithValue("@nombre", txtNombre.Texts.Trim());
                                            updateCommand.Parameters.AddWithValue("@apellidos", txtApellidos.Texts.Trim());
                                            updateCommand.Parameters.AddWithValue("@estado", estado_registro);
                                            updateCommand.Parameters.AddWithValue("@torre", "1");
                                            updateCommand.Parameters.AddWithValue("@fecha", fecha1);
                                            updateCommand.Parameters.AddWithValue("@identificacion", cedulaFinal);
                                            updateCommand.ExecuteNonQuery();

                                        }
                                    }
                                    else
                                    {
                                        // Si el registro no existe, realiza la inserción
                                        string insertQuery = "INSERT INTO salidas (identificacion, nombre, apellidos, estado, torre, fecha_hora) " +
                                                             "VALUES (@identificacion, @nombre, @apellidos, @estado, @torre, @fecha)";
                                        using (MySqlCommand insertCommand = new MySqlCommand(insertQuery, conexionBD))
                                        {
                                            insertCommand.Parameters.AddWithValue("@identificacion", cedulaFinal);
                                            insertCommand.Parameters.AddWithValue("@nombre", txtNombre.Texts.Trim());
                                            insertCommand.Parameters.AddWithValue("@apellidos", txtApellidos.Texts.Trim());
                                            insertCommand.Parameters.AddWithValue("@estado", estado_registro);
                                            insertCommand.Parameters.AddWithValue("@torre", "1");
                                            insertCommand.Parameters.AddWithValue("@fecha", fecha1);
                                            insertCommand.ExecuteNonQuery();
                                        }
                                    }
                                }
                                Form Formulario = new impresion(cedulaFinal, txtNombre.Texts, txtApellidos.Texts, txtPais.Texts, comboBox1.Text, rjTextBox1.Texts, txtEmpresa.Texts, txtObservaciones.Texts);
                                Formulario.Show();
                                //_ = MessageBox.Show("¡Registro actualizado con éxito!");
                                    cleanAll();
                                    if (rjCircularPictureBox2.Image != null)
                                    {
                                        rjCircularPictureBox2.Image.Dispose();
                                        rjCircularPictureBox2.Image = null;
                                    }
                                    if (rjCircularPictureBox3.Image != null)
                                    {
                                        rjCircularPictureBox3.Image.Dispose();
                                        rjCircularPictureBox3.Image = null;
                                    }
                                }
                            else
                            {
                                reader.Close(); // Cerrar el reader antes de ejecutar otros comandos

                                if (estado_foto == 1)
                                {
                                    string fecha1 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                    string sqlUpdate = "UPDATE transacciones_creacion SET " +
                                                       "nombres = @nombres, apellidos = @apellidos, autoriza = @autoriza, oficina = @oficina, " +
                                                       "Empresa = @empresa, Observaciones = @observaciones, fecha = @fecha, AUTORIZA_SEGUIR = @a" +
                                                       "WHERE cedula = @cedula";

                                    using (MySqlCommand comandoUpdate = new MySqlCommand(sqlUpdate, conexionBD))
                                    {
                                        comandoUpdate.Parameters.AddWithValue("@nombres", txtNombre.Texts.Trim());
                                        comandoUpdate.Parameters.AddWithValue("@apellidos", txtApellidos.Texts.Trim());
                                        comandoUpdate.Parameters.AddWithValue("@autoriza", rjTextBox1.Texts);
                                        comandoUpdate.Parameters.AddWithValue("@oficina", comboBox1.Text.Trim());
                                        comandoUpdate.Parameters.AddWithValue("@empresa", txtEmpresa.Texts.Trim());
                                        comandoUpdate.Parameters.AddWithValue("@observaciones", txtObservaciones.Texts.Trim());
                                        comandoUpdate.Parameters.AddWithValue("@fecha", fecha1);
                                        comandoUpdate.Parameters.AddWithValue("@a", nombreFunci);
                                        comandoUpdate.Parameters.AddWithValue("@cedula", cedulaFinal);
                                        comandoUpdate.ExecuteNonQuery();
                                    }

                                    string sql2 = "INSERT INTO vistatntes_registrados (cedula, nombres, apellidos, autoriza, oficina, Empresa, Observaciones, fecha, AUTORIZA_SEGUIR) " +
                                                  "VALUES (@cedula, @nombres, @apellidos, @autoriza, @oficina, @empresa, @observaciones, @fecha, @autoriza1)";

                                    using (MySqlCommand comando2 = new MySqlCommand(sql2, conexionBD))
                                    {
                                        comando2.Parameters.AddWithValue("@cedula", cedulaFinal);
                                        comando2.Parameters.AddWithValue("@nombres", txtNombre.Texts.Trim());
                                        comando2.Parameters.AddWithValue("@apellidos", txtApellidos.Texts.Trim());
                                        comando2.Parameters.AddWithValue("@autoriza", rjTextBox1.Texts);
                                        comando2.Parameters.AddWithValue("@oficina", comboBox1.Text.Trim());
                                        comando2.Parameters.AddWithValue("@empresa", txtEmpresa.Texts.Trim());
                                        comando2.Parameters.AddWithValue("@observaciones", txtObservaciones.Texts.Trim());
                                        comando2.Parameters.AddWithValue("@fecha", fecha1);
                                        comando2.Parameters.AddWithValue("@autoriza1", nombreFunci);
                                        comando2.ExecuteNonQuery();
                                    }
                                    string sql3 = "INSERT INTO entradas (identificacion, nombre, apellidos, estado, torre) " +
                                                  "VALUES (@identificacion, @nombre, @apellidos, @estado, @torre)";
                                    using (MySqlCommand comando3 = new MySqlCommand(sql3, conexionBD))
                                    {
                                        comando3.Parameters.AddWithValue("@identificacion", cedulaFinal);
                                        comando3.Parameters.AddWithValue("@nombre", txtNombre.Texts.Trim());
                                        comando3.Parameters.AddWithValue("@apellidos", txtApellidos.Texts.Trim());
                                        comando3.Parameters.AddWithValue("@estado", estado_registro);
                                        comando3.Parameters.AddWithValue("@torre", "1");
                                        comando3.ExecuteNonQuery();
                                    }
                                    string sql4 = "INSERT INTO salidas (identificacion, nombre, apellidos, estado, torre) " +
                                                  "VALUES (@identificacion, @nombre, @apellidos, @estado, @torre)";
                                    using (MySqlCommand comando4 = new MySqlCommand(sql4, conexionBD))
                                    {
                                        comando4.Parameters.AddWithValue("@identificacion", cedulaFinal);
                                        comando4.Parameters.AddWithValue("@nombre", txtNombre.Texts.Trim());
                                        comando4.Parameters.AddWithValue("@apellidos", txtApellidos.Texts.Trim());
                                        comando4.Parameters.AddWithValue("@estado", estado_registro);
                                        comando4.Parameters.AddWithValue("@torre", "1");
                                        comando4.ExecuteNonQuery();
                                    }
                                        Form Formulario = new impresion(cedulaFinal, txtNombre.Texts, txtApellidos.Texts, txtPais.Texts, comboBox1.Text, rjTextBox1.Texts, txtEmpresa.Texts, txtObservaciones.Texts);
                                        Formulario.Show();
                                        MessageBox.Show("¡Registro actualizado con éxito!");
                                        cleanAll();
                                        if (rjCircularPictureBox2.Image != null)
                                        {
                                            rjCircularPictureBox2.Image.Dispose();
                                            rjCircularPictureBox2.Image = null;
                                        }
                                        if (rjCircularPictureBox3.Image != null)
                                        {
                                            rjCircularPictureBox3.Image.Dispose();
                                            rjCircularPictureBox3.Image = null;
                                        }

                                    }
                                else
                                {
                                    MessageBox.Show("Se necesita un registro de foto!");
                                }
                            }
                        }
                    }

                }
            }
        }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el registro: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
}


        private void Clear()
        {
            try
            {

                TimerStopCam.Stop();
                TimerStopCam.Start();
                txtCedula.Texts = "";
                txtNombre.Texts = "";
                txtApellidos.Texts = "";
                txtPais.Texts = "";
                // Verifica si el elemento ya existe en el ComboBox
                if (!comboBox1.Items.Contains("Selecciona la oficina"))
                {
                    comboBox1.Items.Insert(0, "Selecciona la oficina"); // Agrega si no existe
                }

                comboBox1.SelectedIndex = 0; // Selecciona "Selecciona la oficina"
                comboBox1.DropDownStyle = ComboBoxStyle.DropDownList; // Asegura que sea un ComboBox sin edición

                txtEmpresa.Texts = "";
                txtObservaciones.Texts = "";
                rjTextBox1.Texts = "";
                label83.Text = "Guardar";
                rjButton3.Enabled = false;
                rjButton2.Enabled = true;
                txtCedula.Enabled = true;
                txtNombre.Enabled = true;
                txtApellidos.Enabled = true;
                txtPais.Enabled = true;
                txtEmpresa.Enabled = true;
                rjTextBox1.Enabled = true;
                if (rjCircularPictureBox2.Image != null)
                {
                    rjCircularPictureBox2.Image.Dispose();
                    rjCircularPictureBox2.Image = null;
                }
                if (rjCircularPictureBox3.Image != null)
                {
                    rjCircularPictureBox3.Image.Dispose();
                    rjCircularPictureBox3.Image = null;
                }
            }
            catch
            {

            }
        }


        private void rjButton3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro que quiere eliminar el registro?", "¡Eliminar!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string cedulaToDelete = txtCedula.Texts;

                // Validar si el campo no está vacío
                if (string.IsNullOrWhiteSpace(cedulaToDelete))
                {
                    MessageBox.Show("Por favor, ingrese una cédula válida.", "Advertencia");
                    return;
                }

                string sqlDelete = "DELETE FROM transacciones_creacion WHERE cedula = @cedula";

                try
                {
                    // Abrir conexión si está cerrada
                    if (conexionBD.State == ConnectionState.Closed)
                    {
                        conexionBD.Open();
                    }

                    // Usar parámetros para evitar SQL Injection
                    using (MySqlCommand comandoDelete = new MySqlCommand(sqlDelete, conexionBD))
                    {
                        comandoDelete.Parameters.AddWithValue("@cedula", cedulaToDelete);
                        int rowsAffected = comandoDelete.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("¡Registro eliminado con éxito!", "Éxito");
                            string strrutafotos = @"c:\vrs\fotos\";
                            string rutafinalfotos1 = Path.Combine(strrutafotos, txtCedula.Texts.Trim() + ".jpg");

                            try
                            {
                                if (File.Exists(rutafinalfotos1)) // Verificar si el archivo existe
                                {
                                    File.Delete(rutafinalfotos1); // Eliminar el archivo
                                    //MessageBox.Show($"El archivo {rutafinalfotos1} ha sido eliminado con éxito.", "Éxito");
                                }
                                else
                                {
                                    //MessageBox.Show($"El archivo {rutafinalfotos1} no existe.", "Información");
                                }
                            }
                            catch 
                            {
                                //MessageBox.Show($"Error al intentar eliminar el archivo: {ex.Message}", "Error");
                            }
                        }
                        else
                        {
                            MessageBox.Show("No se encontró un registro con esa cédula.", "Advertencia");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar el registro: {ex.Message}", "Error");
                }
                finally
                {
                    // No cerrar la conexión si estaba abierta antes
                    if (conexionBD.State == ConnectionState.Open)
                    {
                        // Puedes registrar un log aquí si es necesario.
                    }
                }

                Clear();
            }
            else
            {
                MessageBox.Show("Operación cancelada por el usuario.", "Cancelado");
            }
        }

        private void rjCircularPictureBox2_Click(object sender, EventArgs e)
        {
            if (txtCedula.Texts.Length > 3)
            {
                newPicture();
                updatePhoto();
            }
            else
            {
                MessageBox.Show("!Error al capturar la foto, el documento deber ser un número valido¡");
            }
        }

        private void rjButton7_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Close();
            }
            catch
            {}
            Form Formulario = new Form1();
            Formulario.Show();
            Visible = false;
            this.Hide();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Close();
            }
            catch
            {}
            Form Formulario = new login_administrador(nombreFunci, profile);
            Formulario.Show();
            Visible = false;
            this.Hide();
        }


        private void rjRadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            // Verifica si el elemento ya existe en el ComboBox
            if (!comboBox1.Items.Contains("Selecciona la oficina"))
            {
                comboBox1.Items.Insert(0, "Selecciona la oficina"); // Agrega si no existe
            }

            comboBox1.SelectedIndex = 0; // Selecciona "Selecciona la oficina"
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList; // Asegura que sea un ComboBox sin edición

            Clear();
            label7.Text = "No. pasaporte:";
        }

        private void rjRadioButton4_CheckedChanged(object sender, EventArgs e)
        {
            // Verifica si el elemento ya existe en el ComboBox
            if (!comboBox1.Items.Contains("Selecciona la oficina"))
            {
                comboBox1.Items.Insert(0, "Selecciona la oficina"); // Agrega si no existe
            }

            comboBox1.SelectedIndex = 0; // Selecciona "Selecciona la oficina"
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList; // Asegura que sea un ComboBox sin edición


            Clear();
            label7.Text = "No. tarjeta:";
        }

        private void rjRadioButton5_CheckedChanged(object sender, EventArgs e)
        {
            // Verifica si el elemento ya existe en el ComboBox
            if (!comboBox1.Items.Contains("Selecciona la oficina"))
            {
                comboBox1.Items.Insert(0, "Selecciona la oficina"); // Agrega si no existe
            }

            comboBox1.SelectedIndex = 0; // Selecciona "Selecciona la oficina"
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList; // Asegura que sea un ComboBox sin edición

            Clear();
            label7.Text = "No. licencia:";
        }


        private void rjRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            // Verifica si el elemento ya existe en el ComboBox
            if (!comboBox1.Items.Contains("Selecciona la oficina"))
            {
                comboBox1.Items.Insert(0, "Selecciona la oficina"); // Agrega si no existe
            }

            comboBox1.SelectedIndex = 0; // Selecciona "Selecciona la oficina"
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList; // Asegura que sea un ComboBox sin edición


            Clear();
            label7.Text = "No. cédula:";
        }

        private void rjRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            // Verifica si el elemento ya existe en el ComboBox
            if (!comboBox1.Items.Contains("Selecciona la oficina"))
            {
                comboBox1.Items.Insert(0, "Selecciona la oficina"); // Agrega si no existe
            }

            comboBox1.SelectedIndex = 0; // Selecciona "Selecciona la oficina"
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList; // Asegura que sea un ComboBox sin edición


            Clear();
            label7.Text = "No. cédula:";
        }

        // Maneja el evento TextChanged para realizar validaciones adicionales
        private void txtCedula_TextChanged(object sender, EventArgs e)
        {
            validar();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        string nombreFunci = "", profile;
        private MySqlConnection conexionBD;

        public PanelCentral(string nombreFuncionario, string perfil)
        {
            profile = perfil;
            nombreFunci = nombreFuncionario;
            InitializeComponent();

            try
            {
                // Verifica si el elemento ya existe en el ComboBox
                if (!comboBox1.Items.Contains("Selecciona la oficina"))
                {
                    comboBox1.Items.Insert(0, "Selecciona la oficina"); // Agrega si no existe
                }

                comboBox1.SelectedIndex = 0; // Selecciona "Selecciona la oficina"
                comboBox1.DropDownStyle = ComboBoxStyle.DropDownList; // Asegura que sea un ComboBox sin edición

            }
            catch
            {

            }
            conexionBD = ConexionDatos.ConexionServer();
            try
            {
                serialPort1.PortName = "COM11";
                serialPort1.Open();

            }
            catch{}

            try
            {

                if (profile == "Administrador")
                {
                    button3.Visible = true;
                    label4.Visible = true;
                }
                else
                {
                    button3.Visible = false;
                    label4.Visible = false;
                }
            }
            catch
            {

            }
        }

        private void PanelCentral_Load(object sender, EventArgs e)
        {
            
            try
            {
                string consulta = "SELECT oficina FROM oficinas";
                MySqlCommand comando = new MySqlCommand(consulta, conexionBD);
                using (MySqlDataReader lector = comando.ExecuteReader())
                {
                    comboBox1.Items.Clear();
                    while (lector.Read())
                    {
                        string valor = lector.GetString("oficina");
                        comboBox1.Items.Add(valor);
                    }
                }
                if (!comboBox1.Items.Contains("Selecciona la oficina"))
                {
                    comboBox1.Items.Insert(0, "Selecciona la oficina"); // Agrega si no existe
                }

                comboBox1.SelectedIndex = 0; // Selecciona "Selecciona la oficina"
                comboBox1.DropDownStyle = ComboBoxStyle.DropDownList; // Asegura que sea un ComboBox sin edición
            }
            catch { }
            try
            {
                serialPort1.PortName = "COM5";
                serialPort1.Open();
            }
            catch { }
        }


        private void detenerCamara()
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                try
                {
                    // Detener la cámara y desasociar el evento
                    videoSource.SignalToStop();
                    videoSource.WaitForStop();
                    videoSource.NewFrame -= videoSource_NewFrame;
                    videoSource = null;

                    // Liberar imágenes y asignar null
                    if (rjCircularPictureBox2.Image != null)
                    {
                        rjCircularPictureBox2.Image.Dispose();
                        rjCircularPictureBox2.Image = null;
                    }

                    if (rjCircularPictureBox3.Image != null)
                    {
                        rjCircularPictureBox3.Image.Dispose();
                        rjCircularPictureBox3.Image = null;
                    }

                    // Cambiar el texto del botón para indicar que la cámara está detenida
                    label12.Text = "Activar cámara";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al detener la cámara: " + ex.Message);
                }
            }
        }
        private void activarCamara()
        {
            // Detectar dispositivos de video (cámaras)
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (videoDevices.Count == 0)
            {
                MessageBox.Show("No se encontró ninguna cámara.");
                return;
            }
            videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
            videoSource.NewFrame += new NewFrameEventHandler(videoSource_NewFrame);
            try
            {
                videoSource.Start();
                label12.Text = "Detener cámara";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al activar la cámara: " + ex.Message);
            }
        }

        private void txtCedula__TextChanged(object sender, EventArgs e)
        {

            //txtApellidos.Text = txtCedula.Text.Trim();
          
           validar();
        }
        private void txtCedula_KeyDown(object sender, KeyEventArgs e)
        {
            // Detecta si se presionan las teclas Ctrl + V
            if (e.Control && e.KeyCode == Keys.V)
            {
                e.SuppressKeyPress = true; // Evita que se procese la combinación
                e.Handled = true; // Prevenir comportamientos no deseados
                return;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                Int32.Parse(txtCedula.Texts);

            }
            catch
            {
                txtCedula.Texts = "";
            }
            try
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(txtApellidos.Texts, @"\d"))
                {
                    txtApellidos.Texts = ""; // Borra el contenido si contiene números
                }
                if (System.Text.RegularExpressions.Regex.IsMatch(txtNombre.Texts, @"\d"))
                {
                    txtNombre.Texts = ""; // Borra el contenido si contiene números
                }
            }
            catch
            { }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(txtApellidos.Texts, @"\d"))
                {
                    txtApellidos.Texts = ""; // Borra el contenido si contiene números
                }
                if (System.Text.RegularExpressions.Regex.IsMatch(txtNombre.Texts, @"\d"))
                {
                    txtNombre.Texts = ""; // Borra el contenido si contiene números
                }
            }
            catch
            {
                // Manejar posibles errores si es necesario
            }
        }


        // Maneja el evento KeyPress para bloquear espacios
        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true; // Bloquear espacios
                MessageBox.Show("No se permiten espacios en este campo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Detecta si se presiona Ctrl
            if (ModifierKeys.HasFlag(Keys.Control) && e.KeyChar == 22) // 22 es el código ASCII de Ctrl + V
            {
                e.Handled = true; // Cancela la acción de pegar
            }
        }


        private void TimerStopCam_Tick(object sender, EventArgs e)
        {
            if (label12.Text != "Activar cámara")
            {
                detenerCamara();
            }
        }

        private void videoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            if (currentFrame != null)
            {
                currentFrame.Dispose();
            }
            currentFrame = (Bitmap)eventArgs.Frame.Clone();
            rjCircularPictureBox2.Image = currentFrame;
        }

        public void validar()
        {
            string strrutafotos = @"c:\vrs\fotos\";
            string strrutanohayfoto = @"c:\vrs\fotos\oip.jpg";
            string rutafinalfotos1 = strrutafotos + txtCedula.Texts.Trim() + ".jpg";

            // Método seguro para cargar la imagen
            Image LoadImageSafely(string path)
            {
                try
                {
                    if (File.Exists(path)) // Verificar si el archivo existe
                    {
                        // Cargar la imagen desde el archivo
                        using (var img = Image.FromFile(path))
                        {
                            return new Bitmap(img); // Clonar la imagen para evitar problemas de bloqueo
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Manejar errores de acceso al archivo
                    Console.WriteLine($"Error al cargar la imagen: {ex.Message}");
                }
                return null;
            }

            // Cargar la imagen
            Image imagetoload = LoadImageSafely(rutafinalfotos1);
            if (imagetoload != null)
            {
                // Liberar la imagen anterior si existe
                if (rjCircularPictureBox3.Image != null)
                {
                    rjCircularPictureBox3.Image.Dispose();
                }

                // Asignar la nueva imagen
                rjCircularPictureBox3.Image = imagetoload;
                estado_foto = 1;
            }
            else
            {
                // Cargar la imagen predeterminada si no se encontró la principal
                imagetoload = LoadImageSafely(strrutanohayfoto);
                if (imagetoload != null)
                {
                    if (rjCircularPictureBox3.Image != null)
                    {
                        rjCircularPictureBox3.Image.Dispose();
                    }

                    rjCircularPictureBox3.Image = imagetoload;
                }
                estado_foto = 0;
            }


            //-----------------Encontrar el último registro--------------------
            string sql = "SELECT * FROM transacciones_creacion WHERE cedula = @cedula ORDER BY id DESC";
            MySqlCommand comando2 = new MySqlCommand(sql, conexionBD);
            comando2.Parameters.AddWithValue("@cedula", txtCedula.Texts);

            DataTable dt2 = new DataTable();
            new MySqlDataAdapter(comando2).Fill(dt2);

            if (dt2.Rows.Count > 0)
            {
                DataRow row = dt2.Rows[0];
                label83.Text = "Guardar cambios";
                txtCedula.Enabled = txtNombre.Enabled = txtApellidos.Enabled = txtPais.Enabled = txtEmpresa.Enabled  = false;
                rjTextBox1.Enabled = true;
                rjButton3.Enabled = true;
                txtCedula.Texts = row["cedula"].ToString();
                txtNombre.Texts = row["nombres"].ToString();
                txtApellidos.Texts = row["apellidos"].ToString();
                comboBox1.Text = row["oficina"].ToString();
                txtEmpresa.Texts = row["Empresa"].ToString();
                txtObservaciones.Texts = row["Observaciones"].ToString();
                txtPais.Texts = row["pais"].ToString();
                rjTextBox1.Texts = row["autoriza"].ToString();

                var b = true;
                switch (b == true)
                {
                    case var _ when string.IsNullOrWhiteSpace(txtCedula.Texts):
                        txtCedula.Enabled = true;
                        break;
                    case var _ when string.IsNullOrWhiteSpace(txtNombre.Texts):
                        txtNombre.Enabled = true;
                        break;
                    case var _ when string.IsNullOrWhiteSpace(txtApellidos.Texts):
                        txtApellidos.Enabled = true;
                        break;
                    case var _ when string.IsNullOrWhiteSpace(txtPais.Texts):
                        txtPais.Enabled = true;
                        break;
                    case var _ when string.IsNullOrWhiteSpace(txtEmpresa.Texts):
                        txtEmpresa.Enabled = true;
                        break;
                    case var _ when string.IsNullOrWhiteSpace(rjTextBox1.Texts):
                        rjTextBox1.Enabled = false;
                        break;
                    case var _ when string.IsNullOrWhiteSpace(comboBox1.Text):
                        comboBox1.Enabled = true;
                        break;
                    case var _ when string.IsNullOrWhiteSpace(txtObservaciones.Texts):
                        txtObservaciones.Enabled = true;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                label83.Text = "Guardar";
                txtCedula.Enabled = txtNombre.Enabled = txtApellidos.Enabled = txtPais.Enabled = true;
                rjButton3.Enabled = false;
            }
        }

        private void newPicture()
        {
            if (rjCircularPictureBox2.Image != null)
            {
                try
                {
                    // Liberar recursos si ya existe una imagen asignada
                    if (rjCircularPictureBox3.Image != null)
                    {
                        rjCircularPictureBox3.Image.Dispose();
                        rjCircularPictureBox3.Image = null; // Asegurarse de que no quede referencia
                    }

                    // Clonar la imagen de rjCircularPictureBox2 y asignarla a rjCircularPictureBox3
                    rjCircularPictureBox3.Image = (Image)rjCircularPictureBox2.Image.Clone();

                    // Comprobar si la imagen se asignó correctamente
                    if (rjCircularPictureBox3.Image == null)
                    {
                        MessageBox.Show("Ha ocurrido un problema con la foto¡");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al copiar la imagen: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("!Ha ocurrido un problema con el video, asegúrese de que la cámara este conectada¡");
            }
        }
        private void updatePhoto()
        {
            // Verificar y ajustar el contenido del txtCedula
            if (!string.IsNullOrEmpty(txtCedula.Texts))
            {
                // Si tiene más de 10 caracteres, quitar ceros a la izquierda y truncar a 10 caracteres
                if (txtCedula.Texts.Length > 10)
                {
                    txtCedula.Texts = txtCedula.Texts.TrimStart('0');
                    txtCedula.Texts = txtCedula.Texts.Length > 10
                        ? txtCedula.Texts.Substring(0, 10)
                        : txtCedula.Texts;
                }
                // Si tiene menos de 10 caracteres, completar con ceros a la izquierda
                else if (txtCedula.Texts.Length < 10)
                {
                    txtCedula.Texts = txtCedula.Texts.PadLeft(10, '0');
                }
            }
            else
            {
                MessageBox.Show("El campo de cédula está vacío.");
                return;
            }
            // Validar que existe una imagen en rjCircularPictureBox3
            if (rjCircularPictureBox3.Image != null)
            {
                string directoryPath = @"C:\VRS\Fotos\";
                string filePath = directoryPath + txtCedula.Texts + ".jpg";
                try
                {
                    // Asegurarse de que la imagen anterior esté liberada antes de eliminar
                    GC.Collect(); // Forzar recolección de basura para cerrar referencias no manejadas
                    GC.WaitForPendingFinalizers();
                    // Si el archivo ya existe, lo eliminamos
                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                    }
                    // Guardar la imagen en el archivo
                    rjCircularPictureBox3.Image.Save(filePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                    estado_foto = 1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar la foto: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("¡No hay imagen para guardar!");
            }
        }

        //private void impresion_Load(object sender, EventArgs e)
        //{
        //    string strRutaFotos = @"C:\VRS\Fotos\";
        //    string strRutaNoHayFoto = @"C:\VRS\Fotos\OIP.jpg";
        //    string RutaFinalFotos1 = strRutaFotos + cedula.Trim() + ".jpg";

        //    Image img = null;

        //    if (File.Exists(RutaFinalFotos1))
        //    {
        //        // Redimensionar la imagen antes de cargarla
        //        try
        //        {
        //            img = ResizeImage(RutaFinalFotos1, 200, 200); // Cambia el tamaño si es necesario
        //            rjCircularPictureBox3.Image = img;
        //        }
        //        catch (OutOfMemoryException ex)
        //        {
        //            // Manejo de la excepción si no se puede cargar la imagen
        //            MessageBox.Show("Error al cargar la imagen: " + ex.Message);
        //            rjCircularPictureBox3.Image = Image.FromFile(strRutaNoHayFoto);
        //        }
        //    }
        //    else
        //    {
        //        rjCircularPictureBox3.Image = Image.FromFile(strRutaNoHayFoto);
        //    }

        //    rjCircularPictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
        //}

        //// Función para redimensionar la imagen
        //private Image ResizeImage(string filePath, int width, int height)
        //{
        //    using (Image originalImage = Image.FromFile(filePath))
        //    {
        //        Image resizedImage = new Bitmap(originalImage, new Size(width, height));
        //        return resizedImage;
        //    }
        //}


        //private Image LoadImageFromPath(string path)
        //{
        //    using (var pathHandler = new PathHandler(path))
        //    {
        //        return pathHandler.GetImage();
        //    }
        //}
        private void cleanAll()
        {
            txtCedula.Enabled = true;
            txtCedula.Texts = "";
            txtNombre.Enabled = true;
            txtNombre.Texts = "";
            txtApellidos.Enabled = true;
            txtApellidos.Texts = "";
            txtPais.Enabled = true;
            txtPais.Texts = "";
            // Verifica si el elemento ya existe en el ComboBox
            if (!comboBox1.Items.Contains("Selecciona la oficina"))
            {
                comboBox1.Items.Insert(0, "Selecciona la oficina"); // Agrega si no existe
            }

            comboBox1.SelectedIndex = 0; // Selecciona "Selecciona la oficina"
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList; // Asegura que sea un ComboBox sin edición

            txtEmpresa.Enabled = true;
            txtEmpresa.Texts = "";
            txtObservaciones.Enabled = true;
            txtObservaciones.Texts = "";
            rjTextBox1.Texts = "";
            rjTextBox1.Enabled = true;
            TimerStopCam.Stop();
            TimerStopCam.Start();

        }
    }
}
