using System;
namespace Inventario
{
    partial class MainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.titulo = new System.Windows.Forms.Label();
            this.tbConteo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbTarjeta = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.date = new System.Windows.Forms.Label();
            this.tb11 = new System.Windows.Forms.TextBox();
            this.Conteo = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.tbTotal = new System.Windows.Forms.TextBox();
            this.tb53 = new System.Windows.Forms.TextBox();
            this.tb52 = new System.Windows.Forms.TextBox();
            this.tb51 = new System.Windows.Forms.TextBox();
            this.tb43 = new System.Windows.Forms.TextBox();
            this.tb42 = new System.Windows.Forms.TextBox();
            this.tb41 = new System.Windows.Forms.TextBox();
            this.tb33 = new System.Windows.Forms.TextBox();
            this.tb32 = new System.Windows.Forms.TextBox();
            this.tb31 = new System.Windows.Forms.TextBox();
            this.tb23 = new System.Windows.Forms.TextBox();
            this.tb22 = new System.Windows.Forms.TextBox();
            this.tb21 = new System.Windows.Forms.TextBox();
            this.tb13 = new System.Windows.Forms.TextBox();
            this.tb12 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.tbUbic = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbLote = new System.Windows.Forms.TextBox();
            this.tbBodega = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbDesc = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbNart = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnConsolidar = new System.Windows.Forms.Button();
            this.btnReportes = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.conectionCheck = new System.Windows.Forms.Button();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Conteo.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // titulo
            // 
            this.titulo.AutoSize = true;
            this.titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.titulo.Location = new System.Drawing.Point(237, 9);
            this.titulo.Name = "titulo";
            this.titulo.Size = new System.Drawing.Size(331, 42);
            this.titulo.TabIndex = 0;
            this.titulo.Text = "INVENTARIO BSN";
            this.titulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbConteo
            // 
            this.tbConteo.Enabled = false;
            this.tbConteo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbConteo.Location = new System.Drawing.Point(161, 37);
            this.tbConteo.MaxLength = 1;
            this.tbConteo.Name = "tbConteo";
            this.tbConteo.Size = new System.Drawing.Size(100, 22);
            this.tbConteo.TabIndex = 2;
            this.tbConteo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NumConteo);
            this.tbConteo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumCheckConteo);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(19, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "No. Tarjeta";
            // 
            // tbTarjeta
            // 
            this.tbTarjeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTarjeta.Location = new System.Drawing.Point(23, 37);
            this.tbTarjeta.Name = "tbTarjeta";
            this.tbTarjeta.Size = new System.Drawing.Size(100, 22);
            this.tbTarjeta.TabIndex = 1;
            this.tbTarjeta.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numTarjeta);
            this.tbTarjeta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumCheck);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(157, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "No. Conteo";
            // 
            // date
            // 
            this.date.AutoSize = true;
            this.date.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date.ForeColor = System.Drawing.Color.White;
            this.date.Location = new System.Drawing.Point(712, 69);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(35, 15);
            this.date.TabIndex = 0;
            this.date.Text = "Date";
            this.date.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tb11
            // 
            this.tb11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb11.Location = new System.Drawing.Point(23, 33);
            this.tb11.Name = "tb11";
            this.tb11.Size = new System.Drawing.Size(100, 22);
            this.tb11.TabIndex = 3;
            this.tb11.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterCheck);
            this.tb11.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumCheck);
            // 
            // Conteo
            // 
            this.Conteo.BackColor = System.Drawing.Color.Transparent;
            this.Conteo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Conteo.Controls.Add(this.label5);
            this.Conteo.Controls.Add(this.tbTotal);
            this.Conteo.Controls.Add(this.tb53);
            this.Conteo.Controls.Add(this.tb52);
            this.Conteo.Controls.Add(this.tb51);
            this.Conteo.Controls.Add(this.tb43);
            this.Conteo.Controls.Add(this.tb42);
            this.Conteo.Controls.Add(this.tb41);
            this.Conteo.Controls.Add(this.tb33);
            this.Conteo.Controls.Add(this.tb32);
            this.Conteo.Controls.Add(this.tb31);
            this.Conteo.Controls.Add(this.tb23);
            this.Conteo.Controls.Add(this.tb22);
            this.Conteo.Controls.Add(this.tb21);
            this.Conteo.Controls.Add(this.tb13);
            this.Conteo.Controls.Add(this.tb12);
            this.Conteo.Controls.Add(this.label4);
            this.Conteo.Controls.Add(this.label3);
            this.Conteo.Controls.Add(this.label6);
            this.Conteo.Controls.Add(this.tb11);
            this.Conteo.Location = new System.Drawing.Point(12, 145);
            this.Conteo.Name = "Conteo";
            this.Conteo.Size = new System.Drawing.Size(441, 229);
            this.Conteo.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(201, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 18);
            this.label5.TabIndex = 29;
            this.label5.Text = "Cantidad total: ";
            // 
            // tbTotal
            // 
            this.tbTotal.Enabled = false;
            this.tbTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTotal.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tbTotal.Location = new System.Drawing.Point(313, 187);
            this.tbTotal.Name = "tbTotal";
            this.tbTotal.Size = new System.Drawing.Size(100, 22);
            this.tbTotal.TabIndex = 19;
            // 
            // tb53
            // 
            this.tb53.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb53.Location = new System.Drawing.Point(315, 145);
            this.tb53.Name = "tb53";
            this.tb53.Size = new System.Drawing.Size(100, 22);
            this.tb53.TabIndex = 17;
            this.tb53.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterCheck);
            this.tb53.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumCheck);
            // 
            // tb52
            // 
            this.tb52.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb52.Location = new System.Drawing.Point(161, 145);
            this.tb52.Name = "tb52";
            this.tb52.Size = new System.Drawing.Size(100, 22);
            this.tb52.TabIndex = 16;
            this.tb52.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterCheck);
            this.tb52.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumCheck);
            // 
            // tb51
            // 
            this.tb51.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb51.Location = new System.Drawing.Point(23, 145);
            this.tb51.Name = "tb51";
            this.tb51.Size = new System.Drawing.Size(100, 22);
            this.tb51.TabIndex = 15;
            this.tb51.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterCheck);
            this.tb51.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumCheck);
            // 
            // tb43
            // 
            this.tb43.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb43.Location = new System.Drawing.Point(315, 117);
            this.tb43.Name = "tb43";
            this.tb43.Size = new System.Drawing.Size(100, 22);
            this.tb43.TabIndex = 14;
            this.tb43.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterCheck);
            this.tb43.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumCheck);
            // 
            // tb42
            // 
            this.tb42.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb42.Location = new System.Drawing.Point(161, 117);
            this.tb42.Name = "tb42";
            this.tb42.Size = new System.Drawing.Size(100, 22);
            this.tb42.TabIndex = 13;
            this.tb42.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterCheck);
            this.tb42.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumCheck);
            // 
            // tb41
            // 
            this.tb41.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb41.Location = new System.Drawing.Point(23, 117);
            this.tb41.Name = "tb41";
            this.tb41.Size = new System.Drawing.Size(100, 22);
            this.tb41.TabIndex = 12;
            this.tb41.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterCheck);
            this.tb41.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumCheck);
            // 
            // tb33
            // 
            this.tb33.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb33.Location = new System.Drawing.Point(315, 89);
            this.tb33.Name = "tb33";
            this.tb33.Size = new System.Drawing.Size(100, 22);
            this.tb33.TabIndex = 11;
            this.tb33.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterCheck);
            this.tb33.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumCheck);
            // 
            // tb32
            // 
            this.tb32.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb32.Location = new System.Drawing.Point(161, 89);
            this.tb32.Name = "tb32";
            this.tb32.Size = new System.Drawing.Size(100, 22);
            this.tb32.TabIndex = 10;
            this.tb32.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterCheck);
            this.tb32.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumCheck);
            // 
            // tb31
            // 
            this.tb31.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb31.Location = new System.Drawing.Point(23, 89);
            this.tb31.Name = "tb31";
            this.tb31.Size = new System.Drawing.Size(100, 22);
            this.tb31.TabIndex = 9;
            this.tb31.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterCheck);
            this.tb31.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumCheck);
            // 
            // tb23
            // 
            this.tb23.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb23.Location = new System.Drawing.Point(315, 61);
            this.tb23.Name = "tb23";
            this.tb23.Size = new System.Drawing.Size(100, 22);
            this.tb23.TabIndex = 8;
            this.tb23.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterCheck);
            this.tb23.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumCheck);
            // 
            // tb22
            // 
            this.tb22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb22.Location = new System.Drawing.Point(161, 61);
            this.tb22.Name = "tb22";
            this.tb22.Size = new System.Drawing.Size(100, 22);
            this.tb22.TabIndex = 7;
            this.tb22.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterCheck);
            this.tb22.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumCheck);
            // 
            // tb21
            // 
            this.tb21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb21.Location = new System.Drawing.Point(23, 61);
            this.tb21.Name = "tb21";
            this.tb21.Size = new System.Drawing.Size(100, 22);
            this.tb21.TabIndex = 6;
            this.tb21.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterCheck);
            this.tb21.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumCheck);
            // 
            // tb13
            // 
            this.tb13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb13.Location = new System.Drawing.Point(315, 33);
            this.tb13.Name = "tb13";
            this.tb13.Size = new System.Drawing.Size(100, 22);
            this.tb13.TabIndex = 5;
            this.tb13.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterCheck);
            this.tb13.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumCheck);
            // 
            // tb12
            // 
            this.tb12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb12.Location = new System.Drawing.Point(161, 33);
            this.tb12.Name = "tb12";
            this.tb12.Size = new System.Drawing.Size(100, 22);
            this.tb12.TabIndex = 4;
            this.tb12.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterCheck);
            this.tb12.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumCheck);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(153, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 18);
            this.label4.TabIndex = 13;
            this.label4.Text = "Cajas x tendidos";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(310, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 18);
            this.label3.TabIndex = 12;
            this.label3.Text = "Und. x tendidos";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(39, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 18);
            this.label6.TabIndex = 11;
            this.label6.Text = "Tendidos";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tbConteo);
            this.panel1.Controls.Add(this.tbTarjeta);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(12, 69);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(441, 70);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.tbUbic);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.tbLote);
            this.panel2.Controls.Add(this.tbBodega);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.tbDesc);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.tbNart);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Location = new System.Drawing.Point(459, 145);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(441, 229);
            this.panel2.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(15, 96);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 18);
            this.label9.TabIndex = 41;
            this.label9.Text = "Lote:";
            // 
            // tbUbic
            // 
            this.tbUbic.Enabled = false;
            this.tbUbic.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUbic.Location = new System.Drawing.Point(123, 148);
            this.tbUbic.Name = "tbUbic";
            this.tbUbic.Size = new System.Drawing.Size(164, 22);
            this.tbUbic.TabIndex = 24;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(15, 152);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(78, 18);
            this.label12.TabIndex = 40;
            this.label12.Text = "Ubicación:";
            // 
            // tbLote
            // 
            this.tbLote.Enabled = false;
            this.tbLote.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLote.Location = new System.Drawing.Point(123, 92);
            this.tbLote.Name = "tbLote";
            this.tbLote.Size = new System.Drawing.Size(164, 22);
            this.tbLote.TabIndex = 23;
            // 
            // tbBodega
            // 
            this.tbBodega.Enabled = false;
            this.tbBodega.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbBodega.Location = new System.Drawing.Point(123, 120);
            this.tbBodega.Name = "tbBodega";
            this.tbBodega.Size = new System.Drawing.Size(164, 22);
            this.tbBodega.TabIndex = 22;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(15, 124);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 18);
            this.label10.TabIndex = 36;
            this.label10.Text = "Bodega:";
            // 
            // tbDesc
            // 
            this.tbDesc.Enabled = false;
            this.tbDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDesc.Location = new System.Drawing.Point(123, 36);
            this.tbDesc.Multiline = true;
            this.tbDesc.Name = "tbDesc";
            this.tbDesc.Size = new System.Drawing.Size(313, 47);
            this.tbDesc.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(15, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 18);
            this.label8.TabIndex = 32;
            this.label8.Text = "Descripción:";
            // 
            // tbNart
            // 
            this.tbNart.Enabled = false;
            this.tbNart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNart.Location = new System.Drawing.Point(123, 8);
            this.tbNart.Name = "tbNart";
            this.tbNart.Size = new System.Drawing.Size(164, 22);
            this.tbNart.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(15, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 18);
            this.label7.TabIndex = 30;
            this.label7.Text = "Nart: ";
            // 
            // btnConsolidar
            // 
            this.btnConsolidar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsolidar.Location = new System.Drawing.Point(478, 392);
            this.btnConsolidar.Name = "btnConsolidar";
            this.btnConsolidar.Size = new System.Drawing.Size(121, 49);
            this.btnConsolidar.TabIndex = 25;
            this.btnConsolidar.Text = "Consolidar";
            this.btnConsolidar.UseVisualStyleBackColor = true;
            this.btnConsolidar.Click += new System.EventHandler(this.btnConsolidar_Click);
            // 
            // btnReportes
            // 
            this.btnReportes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportes.Location = new System.Drawing.Point(620, 392);
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Size = new System.Drawing.Size(121, 49);
            this.btnReportes.TabIndex = 26;
            this.btnReportes.Text = "Reportes";
            this.btnReportes.UseVisualStyleBackColor = true;
            this.btnReportes.Click += new System.EventHandler(this.btnReportes_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.Location = new System.Drawing.Point(761, 392);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(121, 49);
            this.btnCerrar.TabIndex = 27;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Image = global::Inventario.Properties.Resources.clean;
            this.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnLimpiar.Location = new System.Drawing.Point(244, 392);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(151, 49);
            this.btnLimpiar.TabIndex = 30;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // conectionCheck
            // 
            this.conectionCheck.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.conectionCheck.BackgroundImage = global::Inventario.Properties.Resources.check;
            this.conectionCheck.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.conectionCheck.Cursor = System.Windows.Forms.Cursors.Hand;
            this.conectionCheck.FlatAppearance.BorderSize = 0;
            this.conectionCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.conectionCheck.ForeColor = System.Drawing.Color.Transparent;
            this.conectionCheck.Location = new System.Drawing.Point(12, 12);
            this.conectionCheck.Name = "conectionCheck";
            this.conectionCheck.Size = new System.Drawing.Size(30, 30);
            this.conectionCheck.TabIndex = 29;
            this.conectionCheck.UseVisualStyleBackColor = false;
            this.conectionCheck.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGrabar.Image = global::Inventario.Properties.Resources.save;
            this.btnGrabar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGrabar.Location = new System.Drawing.Point(55, 392);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(151, 49);
            this.btnGrabar.TabIndex = 18;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(492, 80);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 31;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(911, 461);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.conectionCheck);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnReportes);
            this.Controls.Add(this.btnConsolidar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Conteo);
            this.Controls.Add(this.titulo);
            this.Controls.Add(this.date);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(927, 500);
            this.MinimumSize = new System.Drawing.Size(927, 500);
            this.Name = "MainMenu";
            this.Text = "Conteos Inventario BSN Medical";
            this.Conteo.ResumeLayout(false);
            this.Conteo.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titulo;
        private System.Windows.Forms.TextBox tbConteo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbTarjeta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label date;
        private System.Windows.Forms.TextBox tb11;
        private System.Windows.Forms.Panel Conteo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tb13;
        private System.Windows.Forms.TextBox tb12;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbTotal;
        private System.Windows.Forms.TextBox tb53;
        private System.Windows.Forms.TextBox tb52;
        private System.Windows.Forms.TextBox tb51;
        private System.Windows.Forms.TextBox tb43;
        private System.Windows.Forms.TextBox tb42;
        private System.Windows.Forms.TextBox tb41;
        private System.Windows.Forms.TextBox tb33;
        private System.Windows.Forms.TextBox tb32;
        private System.Windows.Forms.TextBox tb31;
        private System.Windows.Forms.TextBox tb23;
        private System.Windows.Forms.TextBox tb22;
        private System.Windows.Forms.TextBox tb21;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox tbUbic;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbLote;
        private System.Windows.Forms.TextBox tbBodega;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbDesc;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbNart;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.Button btnConsolidar;
        private System.Windows.Forms.Button btnReportes;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button conectionCheck;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button button1;
    }
}

