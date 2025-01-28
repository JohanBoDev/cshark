using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Renci.SshNet;
using RJCodeAdvance.RJControls;
using MySql.Data.MySqlClient;

namespace VRS
{
    public partial class administrarControladoras : Form
    {
        

        public administrarControladoras()
        {
            InitializeComponent();
        }
        string tipocontroller;
        private void button19_Click(object sender, EventArgs e)
        {
            Form Formulario = new menuCofiguracion("1","1");
            Formulario.Show();
            Visible = false;
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form Formulario = new agregarControladora();
            Formulario.Show();
        }

        private MySqlConnection conexionBD;

        private void administrarControladoras_Load(object sender, EventArgs e)
        {
            conexionBD = ConexionDatos.ConexionServer();
            if (conexionBD != null)
            {

            }
            else
            {
                MessageBox.Show("No se pudo establecer la conexión a la base de datos.");
                this.Close();
            }

            string selectQuery = "select * from controladoras";

            MySqlCommand command = new MySqlCommand(selectQuery, conexionBD);

            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader.GetString("ip"));
                comboBox1.SelectedValue = "ip";
                tipocontroller =  reader.GetString("tipo");
                
            }
        }

        string user, pass, host;

        private void rjButton3_Click(object sender, EventArgs e)
        {
            rjButton4.Enabled = true;
            rjButton2.Enabled = false;
            rjButton3.Enabled = false;
            label4.Visible = false;

            string fecha = DateTime.Now.ToString("yyyy-MM-dd");
            string hora = DateTime.Now.ToString("HH:mm:ss");
            string data = "sudo date -s'" + fecha + " " + hora + "'";
            using (var client = new SshClient(host, user, pass))
            {

                try
                {
                    client.Connect();
                    var output = client.RunCommand(data);
                    var output1 = client.RunCommand("sudo reboot");
                }
                catch
                {

                }
                rjToggleButton1.Checked = false;
                client.Disconnect();

            }
        }

        private void rjButton4_Click(object sender, EventArgs e)
        {
            label4.Visible = false;

            user = "pi";
            pass = "0000";
            host = comboBox1.Text;
            if (comboBox1.Text != "Seleccione la IP")
            {
                using (var client = new SshClient(host, user, pass))
                {
                    try
                    {
                        client.Connect();

                        rjToggleButton1.Checked = true;
                        rjButton2.Enabled = true;
                        rjButton3.Enabled = true;
                        rjButton4.Enabled = true;
                        label4.Visible = true;
                        label4.Text = tipocontroller;
                    }
                    catch
                    {
                        rjToggleButton1.Checked = false;
                        rjButton2.Enabled = false;
                        rjButton3.Enabled = false;
                        rjButton4.Enabled = false;
                        label4.Visible = false;
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una IP valida");
            }
        }

        private void rjButton2_Click(object sender, EventArgs e)
        {
            rjButton4.Enabled = true;
            rjButton2.Enabled = false;
            rjButton3.Enabled = false;
            label4.Visible = false;
            using (var client = new SshClient(host, user, pass))
            {

                try
                {
                    client.Connect();
                    var output = client.RunCommand("sudo reboot");
                    
                }
                catch
                {

                }
                rjToggleButton1.Checked = false;
                client.Disconnect();

            }
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            try
            {

                user = "pi";
                pass = "0000";
                host = comboBox1.Text;
                if (comboBox1.Text != "Seleccione la IP")
                {
                    using (var client = new SshClient(host, user, pass))
                    {
                        try
                        {
                            client.Connect();

                            rjToggleButton1.Checked = true;
                            rjButton2.Enabled = true;
                            rjButton3.Enabled = true;
                            try
                            {
                                rjButton4.Enabled = true;
                                label4.Text = tipocontroller.ToString();
                            }
                            catch
                            {

                            }
                        }
                        catch
                        {
                            rjToggleButton1.Checked = false;
                            rjButton2.Enabled = false;
                            rjButton3.Enabled = false;
                            rjButton4.Enabled = false;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione una IP valida");
                }
            }
            catch
            {
                MessageBox.Show("Error!, por favor vuelva a intentar");
            }
        }
    }
}
