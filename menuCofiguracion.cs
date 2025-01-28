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
    public partial class menuCofiguracion : Form
    {
        public menuCofiguracion(string nombre, string funcionario)
        {
            name = nombre;
            profile = funcionario;
            InitializeComponent();
            
        }
        string name, profile;
        private void button19_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form Formulario = new administrarUsuarios(name, profile);
            Formulario.Show();
            Visible = false;
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form Formulario = new administrarControladoras();
            Formulario.Show();
            Visible = false;
            this.Hide();
        }

        private void menuCofiguracion_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form Formulario = new administrarOficinas(name, profile);
            Formulario.Show();
            Visible = false;
            this.Hide();
        }

        private void rjButton7_Click(object sender, EventArgs e)
        {
            Form Formulario = new PanelCentral(name, profile);
            Formulario.Show();
            Visible = false;
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form Formulario = new VisitantesRegistrados(name, profile);
            Formulario.Show();
            Visible = false;
            this.Hide();
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form Formulario = new reporteIngresos(name, profile);
            Formulario.Show();
            Visible = false;
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form Formulario = new ReporteFuncionarios(name, profile);
            Formulario.Show();
            Visible = false;
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {

            Form formularioVehiculos = new ReporteVehicular(name, profile);
            formularioVehiculos.Show();
            Visible = false;
            this.Hide();


        }
    }
}
