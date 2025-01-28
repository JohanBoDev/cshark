using ClosedXML.Excel;
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
    public partial class reporteIngresos : Form
    {
        string name, profile;
        public reporteIngresos(string nombre, string perfil)
        {
            name = nombre;
            profile = perfil;
            InitializeComponent();
        }

        string fecha_inical, fecha_final;
        private void BtnAgregar_Click(object sender, EventArgs e)
        {
           


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
        public void Consulta(string fechainicio, string fechafin)
        {
            panel1.Visible = true;

            MessageBox.Show(ComboFiltro.Text);

            string tabla = "transacciones_entradasalida";

            string queryDataGrid = $"SELECT * FROM {tabla} WHERE Fecha BETWEEN @fechaInicio AND @fechaFin";

            if (ComboFiltro.Text == "Entrada")
            {
                queryDataGrid += " AND Controlador = 1";
            }


            if (ComboFiltro.Text == "Salida")
            {
                queryDataGrid += " AND Controlador = 2";
            }
            MySqlCommand cmdDataGrid = new MySqlCommand(queryDataGrid, conexionBD);

            string queryChart = $"SELECT Fecha, COUNT(*) AS `cantidad` " +
                                $"FROM {tabla} " +
                                $"WHERE Fecha BETWEEN @fechaInicio AND @fechaFin " +
                                "GROUP BY Fecha " +
                                "ORDER BY Fecha";
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
            // Set visibility and header text for new columns
            dataGridDatos.Columns["TransanccionesID"].Visible = true;
            dataGridDatos.Columns["Cedula"].Visible = true;
            dataGridDatos.Columns["Nombre"].Visible = true;
            dataGridDatos.Columns["Perfil"].Visible = true;
            dataGridDatos.Columns["Controlador"].Visible = true;
            dataGridDatos.Columns["Fecha"].Visible = true;
            dataGridDatos.Columns["Oficina"].Visible = true;
            dataGridDatos.Columns["numero"].Visible = true;

            dataGridDatos.Columns["TransanccionesID"].HeaderText = "ID";
            dataGridDatos.Columns["Cedula"].HeaderText = "Cédula";
            dataGridDatos.Columns["Nombre"].HeaderText = "Nombre";
            dataGridDatos.Columns["Perfil"].HeaderText = "Perfil";
            dataGridDatos.Columns["Controlador"].HeaderText = "Controlador";
            dataGridDatos.Columns["Fecha"].HeaderText = "Fecha";
            dataGridDatos.Columns["Oficina"].HeaderText = "Oficina";
            dataGridDatos.Columns["numero"].HeaderText = "Número";

            // Update ComboBox with visible column headers
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
                    FileName = "ReporteEntradas-Salidas"
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

        private MySqlConnection conexionBD;

        private void reporteIngresos_Load(object sender, EventArgs e)
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

        private void rjButton7_Click(object sender, EventArgs e)
        {
            Form Formulario = new menuCofiguracion(name, profile);
            Formulario.Show();
            Visible = false;
            this.Hide();
        }

        private void rjButton1_Click_1(object sender, EventArgs e)
        {
            ExportarDataGridViewAClosedXML(dataGridDatos);
        }

        private void rjButton5_Click_1(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void LimpiarDataGridView()
        {
            dataGridDatos.DataSource = null;
            dataGridDatos.Rows.Clear();
            dataGridDatos.Columns.Clear();
            dataGridDatos.Columns.Add("NoDataColumn", "No hay datos");
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            ApplyDataGridViewFilter();
        }

        private void CbColumnas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        Dictionary<string, string> mapColumnaNombreReal = new Dictionary<string, string>()
        {
            { "ID", "TransanccionesID" },
            { "Cédula", "Cedula" },
            { "Nombre", "Nombre" },
            { "Perfil", "Perfil" },
            { "Controlador", "Controlador" },
            { "Fecha", "Fecha" },
            { "Oficina", "oficina" },
            { "Número", "numero" }
        };


    }
}
