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
    public partial class agregarControladora : Form
    {
  
        public agregarControladora()
        {
            InitializeComponent();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private MySqlConnection conexionBD;
        private void agregarControladora_Load(object sender, EventArgs e)
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

        private void rjButton1_Click(object sender, EventArgs e)
        {
            string sql = "INSERT INTO controladoras (ip,tipo) VALUES('" + textBox1.Text + "','" + comboBox1.Text + "')";
            MySqlCommand comando = new MySqlCommand(sql, conexionBD);
            comando.ExecuteNonQuery();
            MessageBox.Show("Controladora Registrada");

            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
