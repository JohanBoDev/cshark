using ClosedXML.Excel;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace VRS
{
    public partial class ReporteFuncionarios : Form
    {
        private MySqlConnection conexionBD;
        private DataTable dataTable = new DataTable();
        string name, profile;

        public ReporteFuncionarios(string nombre, string perfil)
        {
            name = nombre;
            profile = perfil;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Consulta();
            totalRegistros();
        }

        private void ReporteFuncionarios_Load(object sender, EventArgs e)
        {
            conexionBD = ConexionDatos.ConexionServer();
            if (conexionBD == null || conexionBD.State != ConnectionState.Open)
            {
                MessageBox.Show("No se pudo establecer la conexión a la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
        }

        public void Consulta()
        {
            string tabla = "funcionarios";
            string queryDataGrid = $"SELECT * FROM {tabla}";

            try
            {
                // Create a DataTable to hold the query results
                DataTable dataTable = new DataTable();

                using (MySqlCommand cmdDataGrid = new MySqlCommand(queryDataGrid, conexionBD))
                {
                    using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmdDataGrid))
                    {
                        // Fill the DataTable with data from the database
                        dataAdapter.Fill(dataTable);
                    }
                }
                Data.DataSource = dataTable;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al consultar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void rjButton7_Click(object sender, EventArgs e)
        {
             
            Form Formulario = new menuCofiguracion(name, profile);
            Formulario.Show();
            Visible = false;
            this.Hide();
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            
            ExportarDataGridViewAClosedXML(Data);
            
        }

        private void totalRegistros()
        {
            //MessageBox.Show("entra");
            string tabla = "funcionarios";
            string queryDataGrid = $"SELECT count(*) FROM {tabla}";
            try
            {
             
                using (MySqlCommand cmdDataGrid = new MySqlCommand(queryDataGrid, conexionBD))
                {
                    ConfigurarDataGridView();
                    int totalRegistros = Convert.ToInt32(cmdDataGrid.ExecuteScalar());
                    total.Text = totalRegistros.ToString();
                 }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al consultar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                    FileName = "ReportesPlacaRegistradas"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    workbook.SaveAs(saveFileDialog.FileName);
                }
            }

            MessageBox.Show("Exportación exitosa.");
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


        private void ConfigurarDataGridView()
        {
            Data.Columns["id"].Visible = true;
            Data.Columns["cedula"].Visible = true;
            Data.Columns["nombre"].Visible = true;
            Data.Columns["apellido"].Visible = true;
            Data.Columns["oficina"].Visible = true;
            Data.Columns["tipo1"].Visible = true;
            Data.Columns["placa1"].Visible = true;
            Data.Columns["tipo2"].Visible = true;
            Data.Columns["placa2"].Visible = true;
            Data.Columns["tipo3"].Visible = true;
            Data.Columns["placa3"].Visible = true;
            Data.Columns["tipo4"].Visible = true;
            Data.Columns["placa4"].Visible = true;
            Data.Columns["fecha"].Visible = true;
            Data.Columns["permitido_entrada"].Visible = true;
            Data.Columns["creado_por"].Visible = true;

            Data.Columns["id"].HeaderText = "#";
            Data.Columns["cedula"].HeaderText = "Cédula";
            Data.Columns["nombre"].HeaderText = "Nombre";
            Data.Columns["apellido"].HeaderText = "Apellido";
            Data.Columns["oficina"].HeaderText = "Oficina";
            Data.Columns["tipo1"].HeaderText = "Tipo 1";
            Data.Columns["placa1"].HeaderText = "Placa 1";
            Data.Columns["tipo2"].HeaderText = "Tipo 2";
            Data.Columns["placa2"].HeaderText = "Placa 2";
            Data.Columns["tipo3"].HeaderText = "Tipo 3";
            Data.Columns["placa3"].HeaderText = "Placa 3";
            Data.Columns["tipo4"].HeaderText = "Tipo 4";
            Data.Columns["placa4"].HeaderText = "Placa 4";
            Data.Columns["fecha"].HeaderText = "Fecha";
            Data.Columns["permitido_entrada"].HeaderText = "Entrada Permitida";
            Data.Columns["creado_por"].HeaderText = "creado";
        

            CbColumnas.Items.Clear();
            foreach (DataGridViewColumn columna in Data.Columns)
            {
                if (columna.Visible)
                {
                    CbColumnas.Items.Add(columna.HeaderText);
                }
            }
        }

        Dictionary<string, string> mapColumnaNombreReal = new Dictionary<string, string>()
        {
            { "Cédula", "cedula" },
            { "Nombre", "nombre" },
            { "Apellido", "apellido" },
            { "Oficina", "oficina" },
            { "Tipo 1", "tipo1" },
            { "Placa 1", "placa1" },
            { "Tipo 2", "tipo2" },
            { "Placa 2", "placa2" },
            { "Tipo 3", "tipo3" },
            { "Placa 3", "placa3" },
            { "Tipo 4", "tipo4" },
            { "Placa 4", "placa4" },
            { "Fecha", "fecha" },
            { "Entrada Permitida", "permitido_entrada" },
            { "creado", "creado_por" }
        };

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ApplyDataGridViewFilter();
            int totalFilas = Data.RowCount  - 1;
            total.Text = totalFilas.ToString();
        }

      
    }
}
