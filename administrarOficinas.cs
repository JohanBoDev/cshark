using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace VRS
{
    public partial class administrarOficinas : Form
    {
        private MySqlConnection conexionBD;
        string name, profile;
        public administrarOficinas(string nombre, string apellido)
        {
            name = nombre;
            profile = apellido;
            InitializeComponent();
        }

        private void administrarOficinas_Load(object sender, EventArgs e)
        {
            conexionBD = ConexionDatos.ConexionServer();
            if (conexionBD != null)
            {
                CargarOficinas();
            }
            else
            {

                MessageBox.Show("No se pudo establecer la conexión a la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        public void CargarOficinas()
        {
            string sql5 = "SELECT * FROM oficinas";

            MySqlCommand comando5 = new MySqlCommand(sql5, conexionBD);
            MySqlDataAdapter sda5 = new MySqlDataAdapter(comando5);
            DataTable dt5 = new DataTable();
            sda5.Fill(dt5);

            DgvOficinas.DataSource = dt5;
            DgvOficinas.Columns[0].Visible = true;
            DgvOficinas.Columns[1].Visible = true;
            DgvOficinas.Columns[2].Visible = false;
           

            DgvOficinas.Columns[0].HeaderText = "#";
            DgvOficinas.Columns[1].HeaderText = "Oficina";

        }

        private void rjButton7_Click(object sender, EventArgs e)
        {
            Form Formulario = new menuCofiguracion(name, profile);
            Formulario.Show();
            Visible = false;
            this.Hide();
        }

        private void rjButton4_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            CargarOficinas();
        }

        private void rjButton3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtOficina.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos antes de guardar.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
         
                string sqlCheck = "SELECT COUNT(*) FROM oficinas WHERE oficina = @oficina";
                MySqlCommand comandoCheck = new MySqlCommand(sqlCheck, conexionBD);
                comandoCheck.Parameters.AddWithValue("@oficina", TxtOficina.Text);
                int count = Convert.ToInt32(comandoCheck.ExecuteScalar());

                if (count > 0)
                {
                    MessageBox.Show("La oficina ya está registrada.", "Oficina duplicada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                   
                    string sqlInsert = "INSERT INTO oficinas (oficina) VALUES(@oficina)";
                    MySqlCommand comandoInsert = new MySqlCommand(sqlInsert, conexionBD);
                    comandoInsert.Parameters.AddWithValue("@oficina", TxtOficina.Text);
                    comandoInsert.ExecuteNonQuery();

                    MessageBox.Show("Oficina registrada correctamente", "Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TxtOficina.Clear();
                }
            }

        }

        private void BtnBloqueo_Click(object sender, EventArgs e)
        {
            TxtOficina.Focus();
            panel1.Visible = true;
        }
        string id_oficina, nombre_oficina;

        private void rjButton1_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            CargarOficinas();
        }

        private void rjButton2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro que quiere eliminar la oficina?", "¡Eliminar!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
              
                string sqlDelete = "DELETE FROM oficinas WHERE id = '" + id_oficina + "'";
                MySqlCommand comandoDelete = new MySqlCommand(sqlDelete, conexionBD);
                comandoDelete.ExecuteNonQuery();

                try
                {
                    conexionBD.Open();
                    MySqlCommand comando25 = new MySqlCommand(sqlDelete, conexionBD);
                    comando25.ExecuteNonQuery();
                    conexionBD.Close();
                }
                catch
                {
                    conexionBD.Close();
                }
                MessageBox.Show("¡Oficina eliminada con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                panel2.Visible = false;
                CargarOficinas();
            }
            else
            {
                // User clicked "No," do nothing or handle accordingly
                MessageBox.Show("Operación cancelada por el usuario.", "Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void rjButton5_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos antes de guardar.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                string sqlCheck = "SELECT COUNT(*) FROM oficinas WHERE oficina = @oficina";
                MySqlCommand comandoCheck = new MySqlCommand(sqlCheck, conexionBD);
                comandoCheck.Parameters.AddWithValue("@oficina", textBox1.Text);
                int count = Convert.ToInt32(comandoCheck.ExecuteScalar());

                if (count > 0)
                {
                    MessageBox.Show("La oficina ya está registrada.", "Oficina duplicada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    string fecha1 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    string sqlUpdate = "UPDATE oficinas SET " +
                        "oficina = '" + textBox1.Text.Trim() + "', " +
                        "fecha_hora = '" + fecha1.Trim() + "' " +
                        "WHERE id = '" + id_oficina + "'";
                    MySqlCommand comandoUpdate = new MySqlCommand(sqlUpdate, conexionBD);
                    comandoUpdate.ExecuteNonQuery();

                    MessageBox.Show("Oficina actualizada correctamente", "Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    panel2.Visible = false;
                    CargarOficinas();
                }
            }
        }

        private void DgvOficinas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id_oficina = DgvOficinas.Rows[DgvOficinas.CurrentRow.Index].Cells[0].Value.ToString();
             nombre_oficina = DgvOficinas.Rows[DgvOficinas.CurrentRow.Index].Cells[1].Value.ToString();
            textBox1.Text = nombre_oficina;

           
            panel2.Visible = true;


        }
    }
}
