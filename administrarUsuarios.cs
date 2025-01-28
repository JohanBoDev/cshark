using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VRS
{
    public partial class administrarUsuarios : Form
    {
        string name, profile;
        public administrarUsuarios(string nombre, string perfil)
        {
            name = nombre;
            profile = perfil;
            InitializeComponent();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Form Formulario = new menuCofiguracion(name, profile);
            Formulario.Show();
            Visible = false;
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) ||
                    string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox4.Text) ||
                    string.IsNullOrEmpty(textBox5.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos antes de guardar.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                string sql = "INSERT INTO usuarios (Nombres, Apellidos, Identificacion, Perfil, Usuario,Contraseña) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "'" +
                                   ",'" + comboBox1.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')";
                
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                comando.ExecuteNonQuery();
                MessageBox.Show("Usuario Registrado");
                textBox3.Clear();
                textBox1.Clear();
                textBox2.Clear();
                comboBox1.Text = "Operador";
                textBox4.Clear();
                textBox5.Clear();
            }
        }
        private MySqlConnection conexionBD;
        private void administrarUsuarios_Load(object sender, EventArgs e)
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
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
