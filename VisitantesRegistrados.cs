using AForge.Controls;
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
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ClosedXML.Excel;

namespace VRS
{
    public partial class VisitantesRegistrados : Form
    {
        public VisitantesRegistrados(string nombre, string perfil)
        {
            name = nombre;
            perfil = profile;
            InitializeComponent();
        }
        string fecha_inical, fecha_final, name, profile;
        private void BtnAgregar_Click(object sender, EventArgs e)
        {
           

                //-----------------------fecha inicial--------------
            DateTime fechaSeleccionada = rjDatePicker1.Value;
            fechaSeleccionada = new DateTime(fechaSeleccionada.Year, fechaSeleccionada.Month, fechaSeleccionada.Day, 0, 0, 0);

            string hora = HoraInicio.Text + ":" + MinutosInicio.Text + ":00";

            fecha_inical = fechaSeleccionada.ToString("yyyy-MM-dd") + " " + hora;

            //---------------------fecha final-------------
            DateTime fechaSeleccionada1 = rjDatePicker2.Value;
            fechaSeleccionada1 = new DateTime(fechaSeleccionada1.Year, fechaSeleccionada1.Month, fechaSeleccionada1.Day, 0, 0, 0);

            string hora1 = HoraFin.Text + ":" + MinutosFin.Text + ":00";

            fecha_final = fechaSeleccionada1.ToString("yyyy-MM-dd") + " " + hora1;


            Consulta(fecha_inical, fecha_final);
            
        }
        private MySqlConnection conexionBD;

        private void VisitantesRegistrados_Load(object sender, EventArgs e)
        {
            conexionBD = ConexionDatos.ConexionServer();
            if (conexionBD != null)
            {
               
            }
            else
            {

                MessageBox.Show("No se pudo establecer la conexión a la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        public void Consulta(string fechainicio, string fechafin)
        {
            panel1.Visible = true;

            string tabla = "vistatntes_registrados";

            string queryDataGrid = $"SELECT * FROM {tabla} WHERE fecha BETWEEN @fechaInicio AND @fechaFin";
            MySqlCommand cmdDataGrid = new MySqlCommand(queryDataGrid, conexionBD);

            string queryChart = $"SELECT fecha, COUNT(*) AS `cantidad` " +
                                $"FROM {tabla} " +
                                $"WHERE fecha BETWEEN @fechaInicio AND @fechaFin " +
                                "GROUP BY fecha " +
                                "ORDER BY fecha";
            MySqlCommand cmdChart = new MySqlCommand(queryChart, conexionBD);

            try
            {
                cmdDataGrid.Parameters.AddWithValue("@fechaInicio", DateTime.Parse(fechainicio));
                cmdDataGrid.Parameters.AddWithValue("@fechaFin", DateTime.Parse(fechafin));
                cmdChart.Parameters.AddWithValue("@fechaInicio", DateTime.Parse(fechainicio));
                cmdChart.Parameters.AddWithValue("@fechaFin", DateTime.Parse(fechafin));

                MySqlDataAdapter dataAdapterDataGrid = new MySqlDataAdapter(cmdDataGrid);
                DataTable dataTableDataGrid = new DataTable();
                dataAdapterDataGrid.Fill(dataTableDataGrid);

                if (dataTableDataGrid.Rows.Count > 0)
                {
                    dataGridDatos.DataSource = dataTableDataGrid;

                   
                    ConfigurarDataGridView();

                    label23.Text = dataTableDataGrid.Rows.Count.ToString();
                }
                else
                {
                    LimpiarDataGridView();

                    label23.Text = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al consultar datos: {ex.Message}");
            }
        }

        private void ConfigurarDataGridView()
        {
            dataGridDatos.Columns["id"].Visible = true;
            dataGridDatos.Columns["cedula"].Visible = true;
            dataGridDatos.Columns["nombres"].Visible = true;
            dataGridDatos.Columns["apellidos"].Visible = true;
            dataGridDatos.Columns["autoriza"].Visible = true;
            dataGridDatos.Columns["oficina"].Visible = true;
            dataGridDatos.Columns["Empresa"].Visible = true;
            dataGridDatos.Columns["Observaciones"].Visible = true;
            dataGridDatos.Columns["fecha"].Visible = true;

            dataGridDatos.Columns["id"].HeaderText = "#";
            dataGridDatos.Columns["cedula"].HeaderText = "Cedula";
            dataGridDatos.Columns["nombres"].HeaderText = "Nombres";
            dataGridDatos.Columns["apellidos"].HeaderText = "Apellidos";
            dataGridDatos.Columns["autoriza"].HeaderText = "Autoriza";
            dataGridDatos.Columns["oficina"].HeaderText = "Oficina";
            dataGridDatos.Columns["Empresa"].HeaderText = "Empresa";
            dataGridDatos.Columns["Observaciones"].HeaderText = "Observaciones";
            dataGridDatos.Columns["fecha"].HeaderText = "Fecha";

            CbColumnas.Items.Clear();
            foreach (DataGridViewColumn columna in dataGridDatos.Columns)
            {
                if (columna.Visible)
                {
                    CbColumnas.Items.Add(columna.HeaderText);
                }
            }
        }

        private void rjButton5_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            ExportarDataGridViewAClosedXML(dataGridDatos);
        }
        private void ExportarDataGridViewAClosedXML(DataGridView dataGridView)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Datos");

                // Crear encabezados solo para columnas visibles
                int colIndex = 1;
                for (int j = 0; j < dataGridView.Columns.Count; j++)
                {
                    if (dataGridView.Columns[j].Visible)
                    {
                        worksheet.Cell(1, colIndex).Value = dataGridView.Columns[j].HeaderText;
                        colIndex++;
                    }
                }

                // Agregar datos solo para columnas visibles
                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    colIndex = 1;
                    for (int j = 0; j < dataGridView.Columns.Count; j++)
                    {
                        if (dataGridView.Columns[j].Visible)
                        {
                            object cellValue = dataGridView.Rows[i].Cells[j].Value;
                            worksheet.Cell(i + 2, colIndex).Value = cellValue != null ? cellValue.ToString() : string.Empty;
                            colIndex++;
                        }
                    }
                }

                // Guardar el archivo de Excel
                var saveFileDialog = new SaveFileDialog
                {
                    Filter = "Archivos Excel (*.xlsx)|*.xlsx|Todos los archivos (*.*)|*.*",
                    FileName = "ReporteRegistros"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    workbook.SaveAs(saveFileDialog.FileName);
                }
            }

            MessageBox.Show("Exportación exitosa.");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ApplyDataGridViewFilter();
        }
        private void ApplyDataGridViewFilter()
        {
            try
            {
                string filtro = textBox1.Text.Trim().ToLower(); // Obtener el texto del textBox1 y limpiar espacios al inicio y final

                // Obtener la columna seleccionada en CbColumnas
                if (CbColumnas.SelectedItem != null && !string.IsNullOrEmpty(filtro))
                {
                    string columnaSeleccionada = CbColumnas.SelectedItem.ToString();

                    // Verificar si la columna seleccionada tiene un mapeo al nombre real en la tabla
                    if (mapColumnaNombreReal.ContainsKey(columnaSeleccionada))
                    {
                        string columnaReal = mapColumnaNombreReal[columnaSeleccionada];

                        // Verificar si hay un DataSource asignado y es del tipo adecuado
                        if (dataGridDatos.DataSource is DataTable dataTable)
                        {
                            // Construir el filtro para el DataView del DataTable
                            string filtroColumna = $"CONVERT([{columnaReal}], 'System.String') LIKE '%{filtro}%'";

                            // Aplicar el filtro al DataView del DataTable
                            dataTable.DefaultView.RowFilter = filtroColumna;
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se pudo encontrar la columna seleccionada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (string.IsNullOrEmpty(filtro)) // Si no hay filtro, limpiar el filtro
                {
                    if (dataGridDatos.DataSource is DataTable dataTable)
                    {
                        dataTable.DefaultView.RowFilter = string.Empty; // Elimina cualquier filtro
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al aplicar el filtro: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rjButton7_Click(object sender, EventArgs e)
        {
            Form Formulario = new menuCofiguracion(name, profile);
            Formulario.Show();
            Visible = false;
            this.Hide();
        }

        private void LimpiarDataGridView()
        {
            dataGridDatos.DataSource = null;
            dataGridDatos.Rows.Clear();
            dataGridDatos.Columns.Clear();
            dataGridDatos.Columns.Add("NoDataColumn", "No hay datos");
        }

        Dictionary<string, string> mapColumnaNombreReal = new Dictionary<string, string>()
        {
            { "Cedula", "cedula" },
            { "Nombres", "nombres" },
            { "Apellidos", "apellidos" },
            { "Autoriza", "autoriza" },
            { "Oficina", "oficina" },
            { "Empresa", "Empresa" },
            { "Observaciones", "Observaciones" },
            { "Fecha", "fecha" }
        };



    }
}
