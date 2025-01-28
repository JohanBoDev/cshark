using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QRCoder;

namespace VRS
{
    public partial class impresion : Form
    {
        string cedula, nombre, apellidos, pais, oficina, autorizado, empresa, observaciones;

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void impresion_Load(object sender, EventArgs e)
        {
            string strRutaFotos = @"C:\VRS\Fotos\";
            string strRutaNoHayFoto = @"C:\VRS\Fotos\OIP.jpg";
            string RutaFinalFotos1 = strRutaFotos + cedula.Trim() + ".jpg";

            Image img = null;

            if (File.Exists(RutaFinalFotos1))
            {
                // Redimensionar la imagen antes de cargarla
                try
                {
                    img = ResizeImage(RutaFinalFotos1, 200, 200); // Cambia el tamaño si es necesario
                    rjCircularPictureBox3.Image = img;
                }
                catch (OutOfMemoryException ex)
                {
                    // Manejo de la excepción si no se puede cargar la imagen
                    MessageBox.Show("Error al cargar la imagen: " + ex.Message);
                    rjCircularPictureBox3.Image = Image.FromFile(strRutaNoHayFoto);
                }
            }
            else
            {
                rjCircularPictureBox3.Image = Image.FromFile(strRutaNoHayFoto);
            }

            rjCircularPictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        // Función para redimensionar la imagen
        private Image ResizeImage(string filePath, int width, int height)
        {
            Image originalImage = Image.FromFile(filePath);
            Image resizedImage = new Bitmap(originalImage, new Size(width, height));
            return resizedImage;
        }


        string cadena, dia, mes, año;
        public string fecha;
        string[] fecha2;
        ulong id,qr;
        public impresion(string ce,string nom, string ape,string pa , string ofi , string auto , string empre , string obser)
        {
            InitializeComponent();
            cedula = ce;
            nombre = nom;
            apellidos = ape;
            pais = pa;
            oficina = ofi;
            autorizado = auto;
            empresa = empre;
            observaciones = obser;

            cadena = DateTime.Now.ToString("dd/MM/yyyy");

            char[] quitar = { '/' };
            fecha2 = cadena.Split(quitar);
            dia = (fecha2[0]);
            mes = (fecha2[1]);
            año = (fecha2[2]);

            id = Convert.ToUInt64(cedula);
            if (mes == "1")
            {
                qr = (id * Convert.ToUInt64(dia));
                
            }
            if (mes == "2")
            {
                ulong suma = Convert.ToUInt64(dia) + 31;
                qr = (id * suma);
               
               
            }
            if (mes == "3")
            {
                ulong suma = Convert.ToUInt64(dia) + 59;
                qr = (id * suma);
               
                
            }
            if (mes == "4")
            {
                ulong suma = Convert.ToUInt64(dia) + 90;
                qr = (id * suma);
                
            }
            if (mes == "5")
            {
                ulong suma = Convert.ToUInt64(dia) + 120;
                qr = (id * suma);
                
            }
            if (mes == "6")
            {
                ulong suma = Convert.ToUInt64(dia) + 151;
                qr = (id * suma);
                
            }
            if (mes == "7")
            {
                ulong suma = Convert.ToUInt64(dia) + 181;
                qr = (id * suma);
                
            }
            if (mes == "8")
            {
                ulong suma = Convert.ToUInt64(dia) + 212;
                qr = (id * suma);
                
            }
            if (mes == "9")
            {
                ulong suma = Convert.ToUInt64(dia) + 243;
                qr = (id * suma);
                
            }

            if (mes == "01")
            {
                qr = (id * Convert.ToUInt64(dia));
                
            }
            if (mes == "02")
            {
                ulong suma = Convert.ToUInt64(dia) + 31;
                qr = (id * suma);
                
            }
            if (mes == "03")
            {
                ulong suma = Convert.ToUInt64(dia) + 59;
                qr = (id * suma);
                
            }
            if (mes == "04")
            {
                ulong suma = Convert.ToUInt64(dia) + 90;
                qr = (id * suma);
               
            }
            if (mes == "05")
            {
                ulong suma = Convert.ToUInt64(dia) + 120;
                qr = (id * suma);
                
            }
            if (mes == "06")
            {
                ulong suma = Convert.ToUInt64(dia) + 151;
                qr = (id * suma);
               
            }
            if (mes == "07")
            {
                ulong suma = Convert.ToUInt64(dia) + 181;
                qr = (id * suma);
               
            }
            if (mes == "08")
            {
                ulong suma = Convert.ToUInt64(dia) + 212;
                qr = (id * suma);
                
            }
            if (mes == "09")
            {
                ulong suma = Convert.ToUInt64(dia) + 243;
                qr = (id * suma);
                
            }
            if (mes == "10")
            {
                ulong suma = Convert.ToUInt64(dia) + 273;
                qr = (id * suma);
                
            }
            if (mes == "11")
            {
                ulong suma = Convert.ToUInt64(dia) + 304;
                qr = (id * suma);
                
            }
            if (mes == "12")
            {
                ulong suma = Convert.ToUInt64(dia) + 334;
                qr = (id * suma);
                
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            printDocument1 = new PrintDocument();
            PrinterSettings ps = new PrinterSettings();
            printDocument1.PrinterSettings = ps;
            printDocument1.PrintPage += Imprimir2;
            printDocument1.Print();
        }

        private void Imprimir2(object sender, PrintPageEventArgs e)
        {
            string hora = DateTime.Now.ToString("HH:mm:ss");
            string fecha = DateTime.Now.ToShortDateString();
            string fecha1 = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

            // Definir fuentes
            Font tipotexto = new Font("Arial", 11, FontStyle.Bold);
            Font tipotexto1 = new Font("Arial", 7);
            Font tipotexto2 = new Font("Arial", 7, FontStyle.Bold);
            Font tipotexto3 = new Font("Arial", 7);
            Font font2 = new Font("Consolas", 11, FontStyle.Regular, GraphicsUnit.Point);

            // Centrar información
            StringFormat centrado = new StringFormat { Alignment = StringAlignment.Center };
            StringFormat justificado = new StringFormat { Trimming = StringTrimming.Word, Alignment = StringAlignment.Near };

            // Calcular posiciones para el cuadro
            int cuadroWidth = 200;
            int cuadroHeight = 500;
            int cuadroX = 15;
            int cuadroY = 15;
            SizeF tamañoTexto = e.Graphics.MeasureString("VISITANTE EDIFICIO", tipotexto);
            SizeF tamañoTexto2 = e.Graphics.MeasureString("CITY BUSINESS", tipotexto);

            // Calcular la posición centrada
            float textoX = cuadroX + (cuadroWidth - tamañoTexto.Width) / 2; // Centrar el primer texto
            float textoY = cuadroY;

            // Dibujar el título superior
            e.Graphics.DrawString("VISITANTE EDIFICIO", tipotexto, Brushes.Black, new PointF(textoX, textoY));
            e.Graphics.DrawString("CITY BUSINESS", tipotexto, Brushes.Black, new PointF(textoX, textoY + tamañoTexto.Height));

            // Ajustar separación entre el título y la tabla
            int separacionTabla = 40; // Reducido para que se vea más justo

            // Calcular posiciones para la tabla
            int tablaX = cuadroX;
            int tablaY = cuadroY + separacionTabla + (int)(tamañoTexto.Height * 2); // Añadir la altura del título
            int lineHeight = 25; // Reducido para un diseño más compacto

            // Dibujar la tabla
            e.Graphics.DrawString("Cédula:", tipotexto1, Brushes.Black, new Rectangle(tablaX, tablaY, 100, lineHeight));
            e.Graphics.DrawString(cedula, tipotexto1, Brushes.Black, new Rectangle(tablaX + 100, tablaY, 150, lineHeight));

            e.Graphics.DrawString("Nombre:", tipotexto1, Brushes.Black, new Rectangle(tablaX, tablaY + lineHeight, 100, lineHeight));
            e.Graphics.DrawString(nombre, tipotexto1, Brushes.Black, new Rectangle(tablaX + 100, tablaY + lineHeight, 150, lineHeight));

            e.Graphics.DrawString("Apellidos:", tipotexto1, Brushes.Black, new Rectangle(tablaX, tablaY + 2 * lineHeight, 100, lineHeight));
            e.Graphics.DrawString(apellidos, tipotexto1, Brushes.Black, new Rectangle(tablaX + 100, tablaY + 2 * lineHeight, 150, lineHeight));

            e.Graphics.DrawString("Observación:", tipotexto1, Brushes.Black, new Rectangle(tablaX, tablaY + 3 * lineHeight, 100, lineHeight));
            e.Graphics.DrawString(observaciones, tipotexto1, Brushes.Black, new Rectangle(tablaX + 100, tablaY + 3 * lineHeight, 150, lineHeight), justificado);

            e.Graphics.DrawString("Oficina:", tipotexto1, Brushes.Black, new Rectangle(tablaX, tablaY + 4 * lineHeight, 100, lineHeight));
            e.Graphics.DrawString(oficina, tipotexto1, Brushes.Black, new Rectangle(tablaX + 100, tablaY + 4 * lineHeight, 150, lineHeight));

            e.Graphics.DrawString("Fecha:", tipotexto1, Brushes.Black, new Rectangle(tablaX, tablaY + 5 * lineHeight, 100, lineHeight));
            e.Graphics.DrawString(fecha1, tipotexto1, Brushes.Black, new Rectangle(tablaX + 100, tablaY + 5 * lineHeight, 150, lineHeight));

            int qrTextHeight = 6 * lineHeight;
            int qrY = tablaY + qrTextHeight;

            // Generar código QR
            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            {
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(qr.ToString(), QRCodeGenerator.ECCLevel.Q);
                using (QRCode qrCode = new QRCode(qrCodeData))
                {
                    using (Bitmap qrCodeImage = qrCode.GetGraphic(20))
                    {
                        int qrWidth = 130;
                        int qrX = cuadroX + (cuadroWidth - qrWidth) / 2;

                        e.Graphics.DrawImage(qrCodeImage, new Rectangle(qrX, qrY, qrWidth, qrWidth));
                    }
                }
            }

            e.Graphics.DrawString("Este ticket únicamente es válido el día " + fecha, tipotexto2, Brushes.Black, new Rectangle(cuadroX, cuadroY + cuadroHeight - 40, cuadroWidth, 0), centrado);

            e.Graphics.DrawString("Observaciones: " + observaciones, tipotexto3, Brushes.Black, new Rectangle(cuadroX, cuadroY + cuadroHeight, cuadroWidth, 0), justificado);

            this.Close();
        }
    }
}
