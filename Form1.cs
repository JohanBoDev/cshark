using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VRS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void txtusuario_Enter(object sender, EventArgs e)
        {

            if (txtusuario.Text == "User")
            {
                txtusuario.Text = "";

            }
        }

        private void txtusuario_Leave(object sender, EventArgs e)
        {
            if (txtusuario.Text == "")
            {
                txtusuario.Text = "User";
            }
        }

        private void txtcontraseña_Enter(object sender, EventArgs e)
        {

            if (txtcontraseña.Text == "Password")
            {
                txtcontraseña.Text = "";
                txtcontraseña.UseSystemPasswordChar = true;

            }
        }

        private void txtcontraseña_Leave(object sender, EventArgs e)
        {
            if (txtcontraseña.Text == "")
            {
                txtcontraseña.Text = "Password";
                txtcontraseña.UseSystemPasswordChar = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loguear(txtusuario.Text, txtcontraseña.Text);
        }
        //string usu, con, val_usu, val_con, nombre, apellidos, identificacion, perfil;

        private MySqlConnection conexionBD;

        private void Form1_Load(object sender, EventArgs e)
        {
            txtusuario.Focus();
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

        public void loguear(string usuario, string contra)
        {

            if (conexionBD == null)
            {

                return;
            }

            string usu = usuario;
            string con = contra;

            string sql = "SELECT * FROM usuarios WHERE usuario=@usuario";
            MySqlCommand comando2 = new MySqlCommand(sql, conexionBD);
            comando2.Parameters.AddWithValue("@usuario", usu);
            MySqlDataAdapter sda2 = new MySqlDataAdapter(comando2);
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);

            if (dt2.Rows.Count > 0)
            {
                DataRow row = dt2.Rows[0];
                string nombre = row["Nombres"].ToString();
                string apellidos = row["Apellidos"].ToString();
                string identificacion = row["Identificacion"].ToString();
                string perfil = row["Perfil"].ToString();
                string val_usu = row["Usuario"].ToString();
                string val_con = row["Contraseña"].ToString();

                string funcionario = $"{nombre} {apellidos}";
                if (val_usu == usu && val_con == con)
                {
                    Form Formulario = new PanelCentral(funcionario, perfil);
                    Formulario.Show();
                    Visible = false;
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Usuario y/o Contraseña Incorrecta");
                }
            }
            else
            {
                MessageBox.Show("Usuario y/o Contraseña Incorrecta");
            }


        }
    }
}
