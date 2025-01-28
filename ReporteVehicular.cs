using ClosedXML.Excel;
using DocumentFormat.OpenXml.ExtendedProperties;
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
using System.Windows.Forms.DataVisualization.Charting;

namespace VRS
{
    public partial class ReporteVehicular : Form
    {
        string fecha_inicial, fecha_final;
        private MySqlConnection conexionBD;

        int QueryConsulta = 0;
        string queryReport = "";
        string tableReport = "reportes_vehicular";
        string table = "Reportes_entrada_salida";
        string nombreExport = "";
        string name, profile;
        public ReporteVehicular(string nombre, string perfil)
        {
            name = nombre;
            profile = perfil;
            InitializeComponent();

            conexionBD = ConexionDatos.ConexionServer();
            if (conexionBD == null || conexionBD.State != ConnectionState.Open)
            {
                MessageBox.Show("No se pudo establecer la conexión a la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            //-----------------------fecha inicial--------------

            DateTime fechaSeleccionada = rjDatePicker1.Value;
            fechaSeleccionada = new DateTime(fechaSeleccionada.Year, fechaSeleccionada.Month, fechaSeleccionada.Day, 0, 0, 0);
            string hora = HoraInicio.Text + ":" + MinutosInicio.Text + ":00";
            fecha_inicial = fechaSeleccionada.ToString("yyyy-MM-dd") + " " + hora;

            //---------------------fecha final-------------

            DateTime fechaSeleccionada1 = rjDatePicker2.Value;
            fechaSeleccionada1 = new DateTime(fechaSeleccionada1.Year, fechaSeleccionada1.Month, fechaSeleccionada1.Day, 0, 0, 0);
            string hora1 = HoraFin.Text + ":" + MinutosFin.Text + ":00";
            fecha_final = fechaSeleccionada1.ToString("yyyy-MM-dd") + " " + hora1;
            PanelDate.Visible = false;

            
            //ejecutar los metodos al dar click
            consulta(fecha_inicial, fecha_final);
            totalRegistros();
            PopulateColumnComboBox(); // Actualizar las columnas dinámicamente


        }
        private void PopulateColumnComboBox()
        {
            CbColumnas.Items.Clear(); // Limpiar el ComboBox

            if (Data.DataSource is DataTable dataTable)
            {
                foreach (DataColumn column in dataTable.Columns)
                {
                    CbColumnas.Items.Add(column.ColumnName);
                }
            }

            if (CbColumnas.Items.Count > 0)
            {
                CbColumnas.SelectedIndex = 0; // Seleccionar la primera columna por defecto
            }
        }

        private void rjButton2_Click(object sender, EventArgs e)
        {
            //Entradas
            QueryConsulta = 1;
            queryReport = $"SELECT cedula, nombre,apellido, oficina, placa, tipo, fecha as fecha_entrada, ubicacion_controladora as entrada FROM {tableReport} WHERE fecha BETWEEN @inicio AND @fin AND controladora = 1 ORDER BY fecha DESC ";

            PanelDate.Visible = true;
            panelData.Visible = false;
            Panelsection.Visible = false;
        }

        private void rjButton3_Click(object sender, EventArgs e)
        {
            //Salidas
            QueryConsulta = 2;
            queryReport = $"SELECT cedula, nombre, apellido, oficina, placa, tipo, fecha as fecha_salida, ubicacion_controladora as salida FROM {tableReport} WHERE fecha BETWEEN @inicio AND @fin AND controladora = 2 ORDER BY fecha DESC ";
            PanelDate.Visible = true;
            panelData.Visible = false;
            Panelsection.Visible = false;
        }

        private void rjButton5_Click(object sender, EventArgs e)
        {
            //Entradas y salidas
            QueryConsulta = 3;
            queryReport = $"SELECT nombre, apellido, oficina, placa, tipo, fecha_entrada, fecha_salida, ubicacion_controladora FROM {table} WHERE fecha_entrada BETWEEN @inicio AND @fin ORDER BY fecha_entrada DESC";
            PanelDate.Visible = true;
            panelData.Visible = false;
            Panelsection.Visible = false;
        }

        private void rjButton4_Click(object sender, EventArgs e)
        {
            Form Formulario = new menuCofiguracion(name, profile);
            panelData.Visible = false;
            PanelDate.Visible = false;
            Formulario.Show();
            Visible = false;
            this.Hide();
        }

        private void consulta(string fecha_inicio, string fecha_final)
        {

            string query = queryReport;
            try
            {
                DataTable dataTable = new DataTable();

                using (MySqlCommand command = new MySqlCommand(query, conexionBD))
                {
                    //enviar parametros a la consulta
                    command.Parameters.AddWithValue("@inicio", fecha_inicio);
                    command.Parameters.AddWithValue("@fin", fecha_final);

                    using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command))
                    {
                        // Fill the DataTable with data from the database
                        dataAdapter.Fill(dataTable);
                    }
                }

                Data.DataSource = dataTable;
                panelData.Visible = true;
                PanelDate.Visible = false;

            }catch(Exception e){

                MessageBox.Show("Error en el proceso: "+e);

            }
        }

        private void totalRegistros()
        {
            int totalFilas = Data.RowCount - 1;
            total.Text = totalFilas.ToString();
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            ExportarDataGridViewAClosedXML(Data);
        }

        private void rjButton7_Click(object sender, EventArgs e)
        {
            //Form Formulario = new menuCofiguracion();
            //panelData.Visible = false;
            //PanelDate.Visible = false;
            //Formulario.Show();
            //Visible = false;
            //this.Hide();

            panelData.Visible = false;
            PanelDate.Visible = false;
            Panelsection.Visible = true;

        }

        private void ExportarDataGridViewAClosedXML(DataGridView dataGridView)
        {
         

            // Configurar el nombre del archivo según la consulta
            if (QueryConsulta == 1)
            {
                nombreExport = "Reporte-Entradas";
            }
            else if (QueryConsulta == 2)
            {
                nombreExport = "Reporte-Salidas";
            }
            else
            {
                nombreExport = "IngresosSalidasVehicular";
            }

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Datos");

                // Crear encabezados sólo para columnas visibles
                int colIndex = 1;
                for (int j = 0; j < dataGridView.Columns.Count; j++)
                {
                    if (dataGridView.Columns[j].Visible)
                    {
                        worksheet.Cell(1, colIndex).Value = dataGridView.Columns[j].HeaderText;
                        colIndex++;
                    }
                }

                // Agregar datos sólo para columnas visibles
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
                    FileName = nombreExport
                };

                // Mostrar cuadro de diálogo y verificar si se guarda el archivo
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    workbook.SaveAs(saveFileDialog.FileName);
                    MessageBox.Show("Exportación exitosa.");
                }
                else{
                    MessageBox.Show("Exportación cancelada.");
                }
            }
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //filtrar los datos de table
            ApplyDataGridViewFilter();
            totalRegistros();
        }

        Dictionary<string, string> mapColumnaNombreReal = new Dictionary<string, string>()
        {
            { "cedula", "cedula" },
            { "nombre", "nombre" },
            { "apellido", "apellido" },
            { "oficina", "oficina" },
            { "placa", "placa" },
            { "tipo", "tipo" },
            { "fecha_entrada", "fecha_entrada" },
            { "fecha_salida", "fecha_salida" },
            { "ubicacion_controladora", "ubicacion_controladora" },
        };


        Dictionary<string, string> mapColumnaNombreRealEntradas = new Dictionary<string, string>()
        {
            { "cedula", "cedula" },
            { "nombre", "nombre" },
            { "apellido", "apellido" },
            { "oficina", "oficina" },
            { "placa", "placa" },
            { "tipo", "tipo" },
            { "fecha_entrada", "fecha_entrada" },
            { "entrada", "entrada" },
        };

        Dictionary<string, string> mapColumnaNombreRealSalidas = new Dictionary<string, string>()
        {
            { "cedula", "cedula" },
            { "nombre", "nombre" },
            { "apellido", "apellido" },
            { "oficina", "oficina" },
            { "placa", "placa" },
            { "tipo", "tipo" },
            { "fecha_salida", "fecha_salida" },
            { "salida", "salida" },
        };

        private void rjButton4_Click_1(object sender, EventArgs e)
        {
            Form Formulario = new menuCofiguracion(name, profile);
            panelData.Visible = false;
            PanelDate.Visible = false;
            Panelsection.Visible = false;
            Formulario.Show();
            Visible = false;
            this.Hide();
        }

        private void rjButton7_Click_1(object sender, EventArgs e)
        {
            Panelsection.Visible = true;
            panelData.Visible = false;
            PanelDate.Visible = false;
        }

        private void rjButton3_Click_1(object sender, EventArgs e)
        {
            //Salidas
            QueryConsulta = 2;
            queryReport = $"SELECT cedula, nombre, apellido, oficina, placa, tipo, fecha as fecha_salida, ubicacion_controladora as salida FROM {tableReport} WHERE fecha BETWEEN @inicio AND @fin AND controladora = 2 ORDER BY fecha DESC ";
            PanelDate.Visible = true;
            panelData.Visible = false;
            Panelsection.Visible = false;
        }

        private void rjButton5_Click_1(object sender, EventArgs e)
        {
            //Entradas y salidas
            QueryConsulta = 3;
            queryReport = $"SELECT nombre, apellido, oficina, placa, tipo, fecha_entrada, fecha_salida, ubicacion_controladora FROM {table} WHERE fecha_entrada BETWEEN @inicio AND @fin ORDER BY fecha_entrada DESC";
            PanelDate.Visible = true;
            panelData.Visible = false;
            Panelsection.Visible = false;
        }

        private void rjButton1_Click_1(object sender, EventArgs e)
        {
            ExportarDataGridViewAClosedXML(Data);
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

                   switch (QueryConsulta)
                    {

                        case 1:
                            // Verificar si la columna seleccionada tiene un mapeo al nombre real en la tabla
                            if (mapColumnaNombreRealEntradas.ContainsKey(columnaSeleccionada))
                            {
                                string columnaReal = mapColumnaNombreRealEntradas[columnaSeleccionada];

                                // Verificar si hay un DataSource asignado y es del tipo adecuado
                                if (Data.DataSource is DataTable dataTable)
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
                        break;
                        case 2:
                            // Verificar si la columna seleccionada tiene un mapeo al nombre real en la tabla
                            if (mapColumnaNombreRealSalidas.ContainsKey(columnaSeleccionada))
                            {
                                string columnaReal = mapColumnaNombreRealSalidas[columnaSeleccionada];

                                // Verificar si hay un DataSource asignado y es del tipo adecuado
                                if (Data.DataSource is DataTable dataTable)
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
                            break;
                        case 3:
                                // Verificar si la columna seleccionada tiene un mapeo al nombre real en la tabla
                                if (mapColumnaNombreReal.ContainsKey(columnaSeleccionada))
                                {
                                    string columnaReal = mapColumnaNombreReal[columnaSeleccionada];

                                    // Verificar si hay un DataSource asignado y es del tipo adecuado
                                    if (Data.DataSource is DataTable dataTable)
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
                        break;
                        default:
                            MessageBox.Show("Error en el tipo de reporte");
                         break;

                    }
                }
                else if (string.IsNullOrEmpty(filtro)) // Si no hay filtro, limpiar el filtro
                {
                    if (Data.DataSource is DataTable dataTable)
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

    }
}
