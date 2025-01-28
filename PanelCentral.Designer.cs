using System.Windows.Forms;
using System;

namespace VRS
{
    partial class PanelCentral
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PanelCentral));
            this.BarraTitulo = new System.Windows.Forms.Panel();
            this.btnMinimizar = new System.Windows.Forms.PictureBox();
            this.btnCerrar = new System.Windows.Forms.PictureBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.rjButton7 = new RJCodeAdvance.RJControls.RJButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btncerrarturno = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rjRadioButton5 = new RJCodeAdvance.RJControls.RJRadioButton();
            this.rjRadioButton4 = new RJCodeAdvance.RJControls.RJRadioButton();
            this.rjRadioButton3 = new RJCodeAdvance.RJControls.RJRadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.rjRadioButton2 = new RJCodeAdvance.RJControls.RJRadioButton();
            this.rjRadioButton1 = new RJCodeAdvance.RJControls.RJRadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtPais = new RJCodeAdvance.RJControls.RJTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtApellidos = new RJCodeAdvance.RJControls.RJTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNombre = new RJCodeAdvance.RJControls.RJTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCedula = new RJCodeAdvance.RJControls.RJTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.rjTextBox1 = new RJCodeAdvance.RJControls.RJTextBox();
            this.lblautoriza = new System.Windows.Forms.Label();
            this.rjToggleButton1 = new RJCodeAdvance.RJControls.RJToggleButton();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.txtObservaciones = new RJCodeAdvance.RJControls.RJTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtEmpresa = new RJCodeAdvance.RJControls.RJTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.rjCircularPictureBox3 = new RJCodeAdvance.RJControls.RJCircularPictureBox();
            this.label13 = new System.Windows.Forms.Label();
            this.rjCircularPictureBox2 = new RJCodeAdvance.RJControls.RJCircularPictureBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.rjButton3 = new RJCodeAdvance.RJControls.RJButton();
            this.label83 = new System.Windows.Forms.Label();
            this.rjButton1 = new RJCodeAdvance.RJControls.RJButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.TimerStopCam = new System.Windows.Forms.Timer(this.components);
            this.label23 = new System.Windows.Forms.Label();
            this.rjButton2 = new RJCodeAdvance.RJControls.RJButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.BarraTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rjCircularPictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rjCircularPictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // BarraTitulo
            // 
            this.BarraTitulo.BackColor = System.Drawing.Color.DarkGray;
            this.BarraTitulo.Controls.Add(this.btnMinimizar);
            this.BarraTitulo.Controls.Add(this.btnCerrar);
            this.BarraTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.BarraTitulo.Location = new System.Drawing.Point(0, 0);
            this.BarraTitulo.Margin = new System.Windows.Forms.Padding(2);
            this.BarraTitulo.Name = "BarraTitulo";
            this.BarraTitulo.Size = new System.Drawing.Size(1512, 28);
            this.BarraTitulo.TabIndex = 2;
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimizar.Image = ((System.Drawing.Image)(resources.GetObject("btnMinimizar.Image")));
            this.btnMinimizar.Location = new System.Drawing.Point(1457, 2);
            this.btnMinimizar.Margin = new System.Windows.Forms.Padding(2);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(19, 21);
            this.btnMinimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMinimizar.TabIndex = 1;
            this.btnMinimizar.TabStop = false;
            this.btnMinimizar.Click += new System.EventHandler(this.btnMinimizar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
            this.btnCerrar.Location = new System.Drawing.Point(1481, 2);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(26, 21);
            this.btnCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCerrar.TabIndex = 0;
            this.btnCerrar.TabStop = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.rjButton7);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.btncerrarturno);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel2.Location = new System.Drawing.Point(0, 28);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(208, 760);
            this.panel2.TabIndex = 3;
            // 
            // rjButton7
            // 
            this.rjButton7.BackColor = System.Drawing.Color.Crimson;
            this.rjButton7.BackgroundColor = System.Drawing.Color.Crimson;
            this.rjButton7.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton7.BorderRadius = 10;
            this.rjButton7.BorderSize = 0;
            this.rjButton7.FlatAppearance.BorderSize = 0;
            this.rjButton7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton7.Font = new System.Drawing.Font("Cambria", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rjButton7.ForeColor = System.Drawing.Color.White;
            this.rjButton7.Location = new System.Drawing.Point(26, 933);
            this.rjButton7.Name = "rjButton7";
            this.rjButton7.Size = new System.Drawing.Size(153, 53);
            this.rjButton7.TabIndex = 635;
            this.rjButton7.Text = "Volver al inicio";
            this.rjButton7.TextColor = System.Drawing.Color.White;
            this.rjButton7.UseVisualStyleBackColor = false;
            this.rjButton7.Click += new System.EventHandler(this.rjButton7_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(7, 5);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(193, 86);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 610;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 137);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 32);
            this.label1.TabIndex = 8;
            this.label1.Text = "Tomar los datos de un \r\nvisitante";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label4.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(26, 250);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(164, 32);
            this.label4.TabIndex = 7;
            this.label4.Text = "Configuración del\r\nsistema";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btncerrarturno
            // 
            this.btncerrarturno.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btncerrarturno.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btncerrarturno.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btncerrarturno.FlatAppearance.BorderSize = 0;
            this.btncerrarturno.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btncerrarturno.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btncerrarturno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncerrarturno.Font = new System.Drawing.Font("Cambria", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncerrarturno.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btncerrarturno.Location = new System.Drawing.Point(26, 108);
            this.btncerrarturno.Margin = new System.Windows.Forms.Padding(2);
            this.btncerrarturno.Name = "btncerrarturno";
            this.btncerrarturno.Size = new System.Drawing.Size(164, 76);
            this.btncerrarturno.TabIndex = 10;
            this.btncerrarturno.Text = "Crear visitante";
            this.btncerrarturno.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btncerrarturno.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Cambria", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.Location = new System.Drawing.Point(26, 218);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(164, 76);
            this.button3.TabIndex = 13;
            this.button3.Text = "Administrador";
            this.button3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.rjRadioButton5);
            this.groupBox1.Controls.Add(this.rjRadioButton4);
            this.groupBox1.Controls.Add(this.rjRadioButton3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.rjRadioButton2);
            this.groupBox1.Controls.Add(this.rjRadioButton1);
            this.groupBox1.Location = new System.Drawing.Point(241, 104);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(1053, 120);
            this.groupBox1.TabIndex = 661;
            this.groupBox1.TabStop = false;
            // 
            // rjRadioButton5
            // 
            this.rjRadioButton5.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.rjRadioButton5.Font = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rjRadioButton5.Location = new System.Drawing.Point(814, 76);
            this.rjRadioButton5.Margin = new System.Windows.Forms.Padding(2);
            this.rjRadioButton5.MinimumSize = new System.Drawing.Size(0, 17);
            this.rjRadioButton5.Name = "rjRadioButton5";
            this.rjRadioButton5.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.rjRadioButton5.Size = new System.Drawing.Size(235, 26);
            this.rjRadioButton5.TabIndex = 639;
            this.rjRadioButton5.TabStop = true;
            this.rjRadioButton5.Text = "Licencia de conducción";
            this.rjRadioButton5.UnCheckedColor = System.Drawing.Color.Gray;
            this.rjRadioButton5.UseVisualStyleBackColor = true;
            this.rjRadioButton5.CheckedChanged += new System.EventHandler(this.rjRadioButton5_CheckedChanged);
            // 
            // rjRadioButton4
            // 
            this.rjRadioButton4.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.rjRadioButton4.Font = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rjRadioButton4.Location = new System.Drawing.Point(592, 76);
            this.rjRadioButton4.Margin = new System.Windows.Forms.Padding(2);
            this.rjRadioButton4.MinimumSize = new System.Drawing.Size(0, 17);
            this.rjRadioButton4.Name = "rjRadioButton4";
            this.rjRadioButton4.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.rjRadioButton4.Size = new System.Drawing.Size(207, 26);
            this.rjRadioButton4.TabIndex = 638;
            this.rjRadioButton4.TabStop = true;
            this.rjRadioButton4.Text = "Tarjeta identidad";
            this.rjRadioButton4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rjRadioButton4.UnCheckedColor = System.Drawing.Color.Gray;
            this.rjRadioButton4.UseVisualStyleBackColor = true;
            this.rjRadioButton4.CheckedChanged += new System.EventHandler(this.rjRadioButton4_CheckedChanged);
            // 
            // rjRadioButton3
            // 
            this.rjRadioButton3.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.rjRadioButton3.Font = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rjRadioButton3.Location = new System.Drawing.Point(433, 76);
            this.rjRadioButton3.Margin = new System.Windows.Forms.Padding(2);
            this.rjRadioButton3.MinimumSize = new System.Drawing.Size(0, 17);
            this.rjRadioButton3.Name = "rjRadioButton3";
            this.rjRadioButton3.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.rjRadioButton3.Size = new System.Drawing.Size(140, 26);
            this.rjRadioButton3.TabIndex = 637;
            this.rjRadioButton3.TabStop = true;
            this.rjRadioButton3.Text = "Pasaporte";
            this.rjRadioButton3.UnCheckedColor = System.Drawing.Color.Gray;
            this.rjRadioButton3.UseVisualStyleBackColor = true;
            this.rjRadioButton3.CheckedChanged += new System.EventHandler(this.rjRadioButton3_CheckedChanged);
            // 
            // label5
            // 
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("Cambria", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(4, 15);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(1045, 32);
            this.label5.TabIndex = 633;
            this.label5.Text = "SELECCIONE EL TIPO DE DOCUMENTO";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rjRadioButton2
            // 
            this.rjRadioButton2.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.rjRadioButton2.Font = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rjRadioButton2.Location = new System.Drawing.Point(218, 76);
            this.rjRadioButton2.Margin = new System.Windows.Forms.Padding(2);
            this.rjRadioButton2.MinimumSize = new System.Drawing.Size(0, 17);
            this.rjRadioButton2.Name = "rjRadioButton2";
            this.rjRadioButton2.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.rjRadioButton2.Size = new System.Drawing.Size(181, 26);
            this.rjRadioButton2.TabIndex = 636;
            this.rjRadioButton2.TabStop = true;
            this.rjRadioButton2.Text = "Cédula digital";
            this.rjRadioButton2.UnCheckedColor = System.Drawing.Color.Gray;
            this.rjRadioButton2.UseVisualStyleBackColor = true;
            this.rjRadioButton2.CheckedChanged += new System.EventHandler(this.rjRadioButton2_CheckedChanged);
            // 
            // rjRadioButton1
            // 
            this.rjRadioButton1.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.rjRadioButton1.Font = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rjRadioButton1.Location = new System.Drawing.Point(16, 76);
            this.rjRadioButton1.Margin = new System.Windows.Forms.Padding(2);
            this.rjRadioButton1.MinimumSize = new System.Drawing.Size(0, 17);
            this.rjRadioButton1.Name = "rjRadioButton1";
            this.rjRadioButton1.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.rjRadioButton1.Size = new System.Drawing.Size(188, 26);
            this.rjRadioButton1.TabIndex = 635;
            this.rjRadioButton1.TabStop = true;
            this.rjRadioButton1.Text = "Cédula antigua";
            this.rjRadioButton1.UnCheckedColor = System.Drawing.Color.Gray;
            this.rjRadioButton1.UseVisualStyleBackColor = true;
            this.rjRadioButton1.CheckedChanged += new System.EventHandler(this.rjRadioButton1_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox2.Controls.Add(this.txtPais);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtApellidos);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtNombre);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtCedula);
            this.groupBox2.Location = new System.Drawing.Point(241, 228);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(470, 243);
            this.groupBox2.TabIndex = 662;
            this.groupBox2.TabStop = false;
            // 
            // txtPais
            // 
            this.txtPais.BackColor = System.Drawing.SystemColors.Window;
            this.txtPais.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPais.BorderFocusColor = System.Drawing.Color.WhiteSmoke;
            this.txtPais.BorderRadius = 0;
            this.txtPais.BorderSize = 1;
            this.txtPais.Font = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPais.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtPais.Location = new System.Drawing.Point(149, 181);
            this.txtPais.Margin = new System.Windows.Forms.Padding(4);
            this.txtPais.Multiline = false;
            this.txtPais.Name = "txtPais";
            this.txtPais.Padding = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.txtPais.PasswordChar = false;
            this.txtPais.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtPais.PlaceholderText = "";
            this.txtPais.Size = new System.Drawing.Size(304, 40);
            this.txtPais.TabIndex = 640;
            this.txtPais.Texts = "";
            this.txtPais.UnderlinedStyle = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(4, 194);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 27);
            this.label6.TabIndex = 639;
            this.label6.Text = "País:";
            // 
            // txtApellidos
            // 
            this.txtApellidos.BackColor = System.Drawing.SystemColors.Window;
            this.txtApellidos.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtApellidos.BorderFocusColor = System.Drawing.Color.WhiteSmoke;
            this.txtApellidos.BorderRadius = 0;
            this.txtApellidos.BorderSize = 1;
            this.txtApellidos.Font = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApellidos.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtApellidos.Location = new System.Drawing.Point(149, 129);
            this.txtApellidos.Margin = new System.Windows.Forms.Padding(4);
            this.txtApellidos.Multiline = false;
            this.txtApellidos.Name = "txtApellidos";
            this.txtApellidos.Padding = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.txtApellidos.PasswordChar = false;
            this.txtApellidos.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtApellidos.PlaceholderText = "";
            this.txtApellidos.Size = new System.Drawing.Size(304, 40);
            this.txtApellidos.TabIndex = 638;
            this.txtApellidos.Texts = "";
            this.txtApellidos.UnderlinedStyle = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 142);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 27);
            this.label3.TabIndex = 637;
            this.label3.Text = "Apellidos:";
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.SystemColors.Window;
            this.txtNombre.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtNombre.BorderFocusColor = System.Drawing.Color.WhiteSmoke;
            this.txtNombre.BorderRadius = 0;
            this.txtNombre.BorderSize = 1;
            this.txtNombre.Font = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtNombre.Location = new System.Drawing.Point(149, 83);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombre.Multiline = false;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Padding = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.txtNombre.PasswordChar = false;
            this.txtNombre.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtNombre.PlaceholderText = "";
            this.txtNombre.Size = new System.Drawing.Size(304, 40);
            this.txtNombre.TabIndex = 636;
            this.txtNombre.Texts = "";
            this.txtNombre.UnderlinedStyle = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 87);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 27);
            this.label2.TabIndex = 635;
            this.label2.Text = "Nombre:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(4, 44);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 27);
            this.label7.TabIndex = 634;
            this.label7.Text = "No. cédula:";
            // 
            // txtCedula
            // 
            this.txtCedula.BackColor = System.Drawing.SystemColors.Window;
            this.txtCedula.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtCedula.BorderFocusColor = System.Drawing.Color.WhiteSmoke;
            this.txtCedula.BorderRadius = 0;
            this.txtCedula.BorderSize = 1;
            this.txtCedula.Font = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCedula.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtCedula.Location = new System.Drawing.Point(149, 37);
            this.txtCedula.Margin = new System.Windows.Forms.Padding(4);
            this.txtCedula.Multiline = false;
            this.txtCedula.Name = "txtCedula";
            this.txtCedula.Padding = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.txtCedula.PasswordChar = false;
            this.txtCedula.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtCedula.PlaceholderText = "";
            this.txtCedula.Size = new System.Drawing.Size(304, 40);
            this.txtCedula.TabIndex = 0;
            this.txtCedula.Texts = "";
            this.txtCedula.UnderlinedStyle = false;
            this.txtCedula._TextChanged += new System.EventHandler(this.txtCedula__TextChanged);
            this.txtCedula.TextChanged += new System.EventHandler(this.txtCedula_TextChanged);
            this.txtCedula.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCedula_KeyDown);
            this.txtCedula.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCedula_KeyPress);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox3.AutoSize = true;
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.rjTextBox1);
            this.groupBox3.Controls.Add(this.lblautoriza);
            this.groupBox3.Controls.Add(this.rjToggleButton1);
            this.groupBox3.Controls.Add(this.comboBox1);
            this.groupBox3.Controls.Add(this.txtObservaciones);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txtEmpresa);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Location = new System.Drawing.Point(736, 228);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(558, 292);
            this.groupBox3.TabIndex = 663;
            this.groupBox3.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(18, 238);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(192, 27);
            this.label10.TabIndex = 685;
            this.label10.Text = "Acceso todo el día:";
            // 
            // rjTextBox1
            // 
            this.rjTextBox1.BackColor = System.Drawing.SystemColors.Window;
            this.rjTextBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rjTextBox1.BorderFocusColor = System.Drawing.Color.WhiteSmoke;
            this.rjTextBox1.BorderRadius = 0;
            this.rjTextBox1.BorderSize = 1;
            this.rjTextBox1.Font = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rjTextBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rjTextBox1.Location = new System.Drawing.Point(179, 129);
            this.rjTextBox1.Margin = new System.Windows.Forms.Padding(4);
            this.rjTextBox1.Multiline = false;
            this.rjTextBox1.Name = "rjTextBox1";
            this.rjTextBox1.Padding = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.rjTextBox1.PasswordChar = false;
            this.rjTextBox1.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.rjTextBox1.PlaceholderText = "";
            this.rjTextBox1.Size = new System.Drawing.Size(304, 40);
            this.rjTextBox1.TabIndex = 649;
            this.rjTextBox1.Texts = "";
            this.rjTextBox1.UnderlinedStyle = false;
            // 
            // lblautoriza
            // 
            this.lblautoriza.AutoSize = true;
            this.lblautoriza.Font = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblautoriza.Location = new System.Drawing.Point(18, 132);
            this.lblautoriza.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblautoriza.Name = "lblautoriza";
            this.lblautoriza.Size = new System.Drawing.Size(102, 27);
            this.lblautoriza.TabIndex = 648;
            this.lblautoriza.Text = "Autoriza:";
            // 
            // rjToggleButton1
            // 
            this.rjToggleButton1.AutoSize = true;
            this.rjToggleButton1.Location = new System.Drawing.Point(218, 238);
            this.rjToggleButton1.MinimumSize = new System.Drawing.Size(45, 22);
            this.rjToggleButton1.Name = "rjToggleButton1";
            this.rjToggleButton1.OffBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.rjToggleButton1.OffToggleColor = System.Drawing.Color.Gainsboro;
            this.rjToggleButton1.OnBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.rjToggleButton1.OnToggleColor = System.Drawing.Color.WhiteSmoke;
            this.rjToggleButton1.Size = new System.Drawing.Size(45, 22);
            this.rjToggleButton1.TabIndex = 651;
            this.rjToggleButton1.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.White;
            this.comboBox1.Font = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(179, 25);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(304, 35);
            this.comboBox1.TabIndex = 647;
            this.comboBox1.Text = "Selecciona la oficina";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.BackColor = System.Drawing.SystemColors.Window;
            this.txtObservaciones.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtObservaciones.BorderFocusColor = System.Drawing.Color.WhiteSmoke;
            this.txtObservaciones.BorderRadius = 0;
            this.txtObservaciones.BorderSize = 1;
            this.txtObservaciones.Font = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservaciones.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtObservaciones.Location = new System.Drawing.Point(178, 181);
            this.txtObservaciones.Margin = new System.Windows.Forms.Padding(4);
            this.txtObservaciones.Multiline = false;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Padding = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.txtObservaciones.PasswordChar = false;
            this.txtObservaciones.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtObservaciones.PlaceholderText = "";
            this.txtObservaciones.Size = new System.Drawing.Size(304, 40);
            this.txtObservaciones.TabIndex = 646;
            this.txtObservaciones.Texts = "";
            this.txtObservaciones.UnderlinedStyle = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(17, 187);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(162, 27);
            this.label9.TabIndex = 645;
            this.label9.Text = "Observaciones:";
            // 
            // txtEmpresa
            // 
            this.txtEmpresa.BackColor = System.Drawing.SystemColors.Window;
            this.txtEmpresa.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtEmpresa.BorderFocusColor = System.Drawing.Color.WhiteSmoke;
            this.txtEmpresa.BorderRadius = 0;
            this.txtEmpresa.BorderSize = 1;
            this.txtEmpresa.Font = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmpresa.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtEmpresa.Location = new System.Drawing.Point(178, 67);
            this.txtEmpresa.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmpresa.Multiline = false;
            this.txtEmpresa.Name = "txtEmpresa";
            this.txtEmpresa.Padding = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.txtEmpresa.PasswordChar = false;
            this.txtEmpresa.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtEmpresa.PlaceholderText = "";
            this.txtEmpresa.Size = new System.Drawing.Size(304, 40);
            this.txtEmpresa.TabIndex = 644;
            this.txtEmpresa.Texts = "";
            this.txtEmpresa.UnderlinedStyle = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(17, 75);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 27);
            this.label8.TabIndex = 642;
            this.label8.Text = "Empresa:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(17, 28);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(86, 27);
            this.label11.TabIndex = 635;
            this.label11.Text = "Oficina:";
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label14.Location = new System.Drawing.Point(943, 893);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(49, 23);
            this.label14.TabIndex = 667;
            this.label14.Text = "Foto";
            // 
            // rjCircularPictureBox3
            // 
            this.rjCircularPictureBox3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rjCircularPictureBox3.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.rjCircularPictureBox3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rjCircularPictureBox3.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rjCircularPictureBox3.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.rjCircularPictureBox3.BorderSize = 2;
            this.rjCircularPictureBox3.GradientAngle = 50F;
            this.rjCircularPictureBox3.Location = new System.Drawing.Point(512, 475);
            this.rjCircularPictureBox3.Margin = new System.Windows.Forms.Padding(2);
            this.rjCircularPictureBox3.Name = "rjCircularPictureBox3";
            this.rjCircularPictureBox3.Size = new System.Drawing.Size(199, 199);
            this.rjCircularPictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.rjCircularPictureBox3.TabIndex = 666;
            this.rjCircularPictureBox3.TabStop = false;
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label13.Location = new System.Drawing.Point(651, 893);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(63, 23);
            this.label13.TabIndex = 665;
            this.label13.Text = "Video";
            // 
            // rjCircularPictureBox2
            // 
            this.rjCircularPictureBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rjCircularPictureBox2.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.rjCircularPictureBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rjCircularPictureBox2.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rjCircularPictureBox2.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.rjCircularPictureBox2.BorderSize = 2;
            this.rjCircularPictureBox2.GradientAngle = 50F;
            this.rjCircularPictureBox2.Location = new System.Drawing.Point(241, 475);
            this.rjCircularPictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.rjCircularPictureBox2.Name = "rjCircularPictureBox2";
            this.rjCircularPictureBox2.Size = new System.Drawing.Size(204, 204);
            this.rjCircularPictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.rjCircularPictureBox2.TabIndex = 664;
            this.rjCircularPictureBox2.TabStop = false;
            this.rjCircularPictureBox2.Click += new System.EventHandler(this.rjCircularPictureBox2_Click);
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label16.Location = new System.Drawing.Point(1426, 883);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(149, 23);
            this.label16.TabIndex = 677;
            this.label16.Text = "Apagar cámara";
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label15.Location = new System.Drawing.Point(1269, 883);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(148, 23);
            this.label15.TabIndex = 675;
            this.label15.Text = "Activar cámara";
            // 
            // label19
            // 
            this.label19.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label19.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label19.Location = new System.Drawing.Point(1135, 641);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(124, 19);
            this.label19.TabIndex = 671;
            this.label19.Text = "Borrar";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rjButton3
            // 
            this.rjButton3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rjButton3.BackColor = System.Drawing.Color.Crimson;
            this.rjButton3.BackgroundColor = System.Drawing.Color.Crimson;
            this.rjButton3.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton3.BorderRadius = 20;
            this.rjButton3.BorderSize = 0;
            this.rjButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rjButton3.Enabled = false;
            this.rjButton3.FlatAppearance.BorderSize = 0;
            this.rjButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton3.Font = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rjButton3.ForeColor = System.Drawing.Color.Black;
            this.rjButton3.Image = ((System.Drawing.Image)(resources.GetObject("rjButton3.Image")));
            this.rjButton3.Location = new System.Drawing.Point(1135, 541);
            this.rjButton3.Margin = new System.Windows.Forms.Padding(2);
            this.rjButton3.Name = "rjButton3";
            this.rjButton3.Size = new System.Drawing.Size(124, 87);
            this.rjButton3.TabIndex = 670;
            this.rjButton3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.rjButton3.TextColor = System.Drawing.Color.Black;
            this.rjButton3.UseVisualStyleBackColor = false;
            this.rjButton3.Click += new System.EventHandler(this.rjButton3_Click);
            // 
            // label83
            // 
            this.label83.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label83.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label83.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label83.Location = new System.Drawing.Point(950, 640);
            this.label83.Name = "label83";
            this.label83.Size = new System.Drawing.Size(158, 20);
            this.label83.TabIndex = 669;
            this.label83.Text = "Guardar";
            this.label83.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rjButton1
            // 
            this.rjButton1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rjButton1.BackColor = System.Drawing.Color.SeaGreen;
            this.rjButton1.BackgroundColor = System.Drawing.Color.SeaGreen;
            this.rjButton1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton1.BorderRadius = 20;
            this.rjButton1.BorderSize = 0;
            this.rjButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rjButton1.FlatAppearance.BorderSize = 0;
            this.rjButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton1.Font = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rjButton1.ForeColor = System.Drawing.Color.Black;
            this.rjButton1.Image = ((System.Drawing.Image)(resources.GetObject("rjButton1.Image")));
            this.rjButton1.Location = new System.Drawing.Point(965, 541);
            this.rjButton1.Margin = new System.Windows.Forms.Padding(2);
            this.rjButton1.Name = "rjButton1";
            this.rjButton1.Size = new System.Drawing.Size(124, 87);
            this.rjButton1.TabIndex = 668;
            this.rjButton1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.rjButton1.TextColor = System.Drawing.Color.Black;
            this.rjButton1.UseVisualStyleBackColor = false;
            this.rjButton1.Click += new System.EventHandler(this.rjButton1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(-404, 32);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(28, 151);
            this.dataGridView1.TabIndex = 678;
            this.dataGridView1.Visible = false;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(250, 51);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 24);
            this.comboBox2.TabIndex = 679;
            this.comboBox2.Visible = false;
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(756, 640);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(188, 20);
            this.label12.TabIndex = 680;
            this.label12.Text = "Activar cámara";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label21
            // 
            this.label21.Font = new System.Drawing.Font("Cambria", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(241, 41);
            this.label21.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(1053, 58);
            this.label21.TabIndex = 640;
            this.label21.Text = "REGISTRAR NUEVO VISITANTE";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label22
            // 
            this.label22.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label22.Location = new System.Drawing.Point(590, 681);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(61, 23);
            this.label22.TabIndex = 682;
            this.label22.Text = "FOTO";
            // 
            // TimerStopCam
            // 
            this.TimerStopCam.Enabled = true;
            this.TimerStopCam.Interval = 300000;
            this.TimerStopCam.Tick += new System.EventHandler(this.TimerStopCam_Tick);
            // 
            // label23
            // 
            this.label23.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label23.Location = new System.Drawing.Point(315, 681);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(70, 23);
            this.label23.TabIndex = 683;
            this.label23.Text = "VIDEO";
            // 
            // rjButton2
            // 
            this.rjButton2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rjButton2.BackColor = System.Drawing.Color.SteelBlue;
            this.rjButton2.BackgroundColor = System.Drawing.Color.SteelBlue;
            this.rjButton2.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton2.BorderRadius = 20;
            this.rjButton2.BorderSize = 0;
            this.rjButton2.CausesValidation = false;
            this.rjButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rjButton2.FlatAppearance.BorderSize = 0;
            this.rjButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton2.Font = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rjButton2.ForeColor = System.Drawing.Color.Black;
            this.rjButton2.Image = ((System.Drawing.Image)(resources.GetObject("rjButton2.Image")));
            this.rjButton2.Location = new System.Drawing.Point(790, 541);
            this.rjButton2.Margin = new System.Windows.Forms.Padding(2);
            this.rjButton2.Name = "rjButton2";
            this.rjButton2.Size = new System.Drawing.Size(124, 87);
            this.rjButton2.TabIndex = 674;
            this.rjButton2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.rjButton2.TextColor = System.Drawing.Color.Black;
            this.rjButton2.UseVisualStyleBackColor = false;
            this.rjButton2.Click += new System.EventHandler(this.rjButton2_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // PanelCentral
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1512, 791);
            this.Controls.Add(this.rjButton2);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.rjButton3);
            this.Controls.Add(this.label83);
            this.Controls.Add(this.rjButton1);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.rjCircularPictureBox3);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.rjCircularPictureBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.BarraTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PanelCentral";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PanelCentral";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PanelCentral_Load);
            this.BarraTitulo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rjCircularPictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rjCircularPictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel BarraTitulo;
        private System.Windows.Forms.PictureBox btnMinimizar;
        private System.Windows.Forms.PictureBox btnCerrar;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btncerrarturno;
        private System.Windows.Forms.Button button3;
        private RJCodeAdvance.RJControls.RJButton rjButton7;
        private System.Windows.Forms.GroupBox groupBox1;
        private RJCodeAdvance.RJControls.RJRadioButton rjRadioButton3;
        private System.Windows.Forms.Label label5;
        private RJCodeAdvance.RJControls.RJRadioButton rjRadioButton2;
        private RJCodeAdvance.RJControls.RJRadioButton rjRadioButton1;
        private RJCodeAdvance.RJControls.RJRadioButton rjRadioButton5;
        private RJCodeAdvance.RJControls.RJRadioButton rjRadioButton4;
        private System.Windows.Forms.GroupBox groupBox2;
        private RJCodeAdvance.RJControls.RJTextBox txtPais;
        private System.Windows.Forms.Label label6;
        private RJCodeAdvance.RJControls.RJTextBox txtApellidos;
        private System.Windows.Forms.Label label3;
        private RJCodeAdvance.RJControls.RJTextBox txtNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private RJCodeAdvance.RJControls.RJTextBox txtCedula;
        private System.Windows.Forms.GroupBox groupBox3;
        private RJCodeAdvance.RJControls.RJToggleButton rjToggleButton1;
        private System.Windows.Forms.ComboBox comboBox1;
        private RJCodeAdvance.RJControls.RJTextBox txtObservaciones;
        private System.Windows.Forms.Label label9;
        private RJCodeAdvance.RJControls.RJTextBox txtEmpresa;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label14;
        private RJCodeAdvance.RJControls.RJCircularPictureBox rjCircularPictureBox3;
        private System.Windows.Forms.Label label13;
        private RJCodeAdvance.RJControls.RJCircularPictureBox rjCircularPictureBox2;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label19;
        private RJCodeAdvance.RJControls.RJButton rjButton3;
        private System.Windows.Forms.Label label83;
        private RJCodeAdvance.RJControls.RJButton rjButton1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Timer TimerStopCam;
        private RJCodeAdvance.RJControls.RJTextBox rjTextBox1;
        private Label lblautoriza;
        private Label label10;
        private Label label23;
        private RJCodeAdvance.RJControls.RJButton rjButton2;
        private Timer timer1;
    }
}