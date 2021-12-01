using System;
namespace Inventario
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.pnHeader = new System.Windows.Forms.Panel();
            this.pnHeader2 = new System.Windows.Forms.Panel();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblTittle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbThemeSelector = new System.Windows.Forms.ComboBox();
            this.pnMain = new System.Windows.Forms.Panel();
            this.pnMisc = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.btnResetSettings = new System.Windows.Forms.Button();
            this.cbDataRows = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnConsolidate = new System.Windows.Forms.Button();
            this.btnClean = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnConteo = new System.Windows.Forms.Panel();
            this.flpConteo = new System.Windows.Forms.FlowLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.tbTotal = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.pnTabla = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.tbUbicacion = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbLote = new System.Windows.Forms.TextBox();
            this.tbBodega = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbDesc = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbNart = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pnTarjeta = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.tbConteo = new System.Windows.Forms.TextBox();
            this.tbTarjeta = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pnHeader.SuspendLayout();
            this.pnHeader2.SuspendLayout();
            this.pnMain.SuspendLayout();
            this.pnMisc.SuspendLayout();
            this.pnConteo.SuspendLayout();
            this.pnTabla.SuspendLayout();
            this.pnTarjeta.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnHeader
            // 
            this.pnHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.pnHeader.Controls.Add(this.pnHeader2);
            this.pnHeader.Controls.Add(this.lblTittle);
            this.pnHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnHeader.Location = new System.Drawing.Point(0, 0);
            this.pnHeader.Name = "pnHeader";
            this.pnHeader.Size = new System.Drawing.Size(911, 100);
            this.pnHeader.TabIndex = 0;
            // 
            // pnHeader2
            // 
            this.pnHeader2.BackColor = System.Drawing.Color.DimGray;
            this.pnHeader2.Controls.Add(this.lblDate);
            this.pnHeader2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnHeader2.Location = new System.Drawing.Point(0, 80);
            this.pnHeader2.Name = "pnHeader2";
            this.pnHeader2.Size = new System.Drawing.Size(911, 20);
            this.pnHeader2.TabIndex = 3;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Consolas", 10F);
            this.lblDate.ForeColor = System.Drawing.Color.White;
            this.lblDate.Location = new System.Drawing.Point(3, 2);
            this.lblDate.Margin = new System.Windows.Forms.Padding(0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.lblDate.Size = new System.Drawing.Size(45, 17);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "Date";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTittle
            // 
            this.lblTittle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTittle.AutoSize = true;
            this.lblTittle.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTittle.ForeColor = System.Drawing.Color.White;
            this.lblTittle.Location = new System.Drawing.Point(3, 9);
            this.lblTittle.Name = "lblTittle";
            this.lblTittle.Size = new System.Drawing.Size(371, 46);
            this.lblTittle.TabIndex = 2;
            this.lblTittle.Text = "INVENTARIO BSN";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(14, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tema:";
            // 
            // cbThemeSelector
            // 
            this.cbThemeSelector.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbThemeSelector.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbThemeSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbThemeSelector.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbThemeSelector.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cbThemeSelector.FormattingEnabled = true;
            this.cbThemeSelector.IntegralHeight = false;
            this.cbThemeSelector.Location = new System.Drawing.Point(18, 37);
            this.cbThemeSelector.MaxDropDownItems = 10;
            this.cbThemeSelector.Name = "cbThemeSelector";
            this.cbThemeSelector.Size = new System.Drawing.Size(110, 21);
            this.cbThemeSelector.TabIndex = 0;
            this.cbThemeSelector.TabStop = false;
            this.cbThemeSelector.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cbThemeSelector_DrawItem);
            this.cbThemeSelector.SelectedIndexChanged += new System.EventHandler(this.cbThemeSelector_SelectedIndexChanged);
            // 
            // pnMain
            // 
            this.pnMain.BackColor = System.Drawing.Color.LightGray;
            this.pnMain.Controls.Add(this.pnMisc);
            this.pnMain.Controls.Add(this.btnClose);
            this.pnMain.Controls.Add(this.btnReports);
            this.pnMain.Controls.Add(this.btnConsolidate);
            this.pnMain.Controls.Add(this.btnClean);
            this.pnMain.Controls.Add(this.btnSave);
            this.pnMain.Controls.Add(this.pnConteo);
            this.pnMain.Controls.Add(this.pnTabla);
            this.pnMain.Controls.Add(this.pnTarjeta);
            this.pnMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnMain.Location = new System.Drawing.Point(0, 100);
            this.pnMain.Name = "pnMain";
            this.pnMain.Size = new System.Drawing.Size(911, 361);
            this.pnMain.TabIndex = 0;
            // 
            // pnMisc
            // 
            this.pnMisc.BackColor = System.Drawing.Color.Transparent;
            this.pnMisc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnMisc.Controls.Add(this.label14);
            this.pnMisc.Controls.Add(this.btnResetSettings);
            this.pnMisc.Controls.Add(this.cbDataRows);
            this.pnMisc.Controls.Add(this.label13);
            this.pnMisc.Controls.Add(this.label1);
            this.pnMisc.Controls.Add(this.cbThemeSelector);
            this.pnMisc.Location = new System.Drawing.Point(460, 10);
            this.pnMisc.Name = "pnMisc";
            this.pnMisc.Size = new System.Drawing.Size(440, 70);
            this.pnMisc.TabIndex = 8;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(382, 12);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 21);
            this.label14.TabIndex = 8;
            this.label14.Text = "Reset";
            // 
            // btnResetSettings
            // 
            this.btnResetSettings.BackgroundImage = global::Inventario.Properties.Resources.check;
            this.btnResetSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnResetSettings.FlatAppearance.BorderSize = 0;
            this.btnResetSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetSettings.Location = new System.Drawing.Point(393, 31);
            this.btnResetSettings.Name = "btnResetSettings";
            this.btnResetSettings.Size = new System.Drawing.Size(30, 30);
            this.btnResetSettings.TabIndex = 7;
            this.btnResetSettings.UseVisualStyleBackColor = true;
            this.btnResetSettings.Click += new System.EventHandler(this.btnResetSettings_Click);
            // 
            // cbDataRows
            // 
            this.cbDataRows.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDataRows.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbDataRows.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDataRows.FormattingEnabled = true;
            this.cbDataRows.Location = new System.Drawing.Point(154, 34);
            this.cbDataRows.Name = "cbDataRows";
            this.cbDataRows.Size = new System.Drawing.Size(63, 24);
            this.cbDataRows.TabIndex = 6;
            this.cbDataRows.DropDownClosed += new System.EventHandler(this.cbDataRows_DropDownClosed);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(150, 13);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(45, 21);
            this.label13.TabIndex = 4;
            this.label13.Text = "Filas:";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(770, 292);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(130, 50);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Cerrar";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnReports
            // 
            this.btnReports.Enabled = false;
            this.btnReports.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReports.Location = new System.Drawing.Point(615, 292);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(130, 50);
            this.btnReports.TabIndex = 5;
            this.btnReports.Text = "Reportes";
            this.btnReports.UseVisualStyleBackColor = true;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // btnConsolidate
            // 
            this.btnConsolidate.Enabled = false;
            this.btnConsolidate.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsolidate.Location = new System.Drawing.Point(460, 292);
            this.btnConsolidate.Name = "btnConsolidate";
            this.btnConsolidate.Size = new System.Drawing.Size(130, 50);
            this.btnConsolidate.TabIndex = 4;
            this.btnConsolidate.Text = "Consolidar";
            this.btnConsolidate.UseVisualStyleBackColor = true;
            this.btnConsolidate.Click += new System.EventHandler(this.btnConsolidate_Click);
            // 
            // btnClean
            // 
            this.btnClean.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClean.Image = global::Inventario.Properties.Resources.clean;
            this.btnClean.Location = new System.Drawing.Point(244, 292);
            this.btnClean.Name = "btnClean";
            this.btnClean.Size = new System.Drawing.Size(150, 50);
            this.btnClean.TabIndex = 3;
            this.btnClean.Text = " Limpiar";
            this.btnClean.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClean.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClean.UseVisualStyleBackColor = true;
            this.btnClean.Click += new System.EventHandler(this.btnClean_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::Inventario.Properties.Resources.save;
            this.btnSave.Location = new System.Drawing.Point(53, 292);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(150, 50);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = " Grabar";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pnConteo
            // 
            this.pnConteo.AutoScroll = true;
            this.pnConteo.BackColor = System.Drawing.Color.Transparent;
            this.pnConteo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnConteo.Controls.Add(this.flpConteo);
            this.pnConteo.Controls.Add(this.label5);
            this.pnConteo.Controls.Add(this.tbTotal);
            this.pnConteo.Controls.Add(this.label4);
            this.pnConteo.Controls.Add(this.label6);
            this.pnConteo.Controls.Add(this.label11);
            this.pnConteo.Location = new System.Drawing.Point(10, 90);
            this.pnConteo.Name = "pnConteo";
            this.pnConteo.Size = new System.Drawing.Size(441, 184);
            this.pnConteo.TabIndex = 1;
            // 
            // flpConteo
            // 
            this.flpConteo.AutoScroll = true;
            this.flpConteo.Location = new System.Drawing.Point(16, 31);
            this.flpConteo.Margin = new System.Windows.Forms.Padding(0);
            this.flpConteo.Name = "flpConteo";
            this.flpConteo.Size = new System.Drawing.Size(415, 118);
            this.flpConteo.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(193, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Cantidad total: ";
            // 
            // tbTotal
            // 
            this.tbTotal.Enabled = false;
            this.tbTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTotal.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tbTotal.Location = new System.Drawing.Point(315, 152);
            this.tbTotal.Name = "tbTotal";
            this.tbTotal.Size = new System.Drawing.Size(100, 22);
            this.tbTotal.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(150, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 18);
            this.label4.TabIndex = 12;
            this.label4.Text = "Cajas x tendidos";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(293, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 18);
            this.label6.TabIndex = 13;
            this.label6.Text = "Und. x caja";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(39, 6);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 18);
            this.label11.TabIndex = 11;
            this.label11.Text = "Tendidos";
            // 
            // pnTabla
            // 
            this.pnTabla.BackColor = System.Drawing.Color.Transparent;
            this.pnTabla.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnTabla.Controls.Add(this.label9);
            this.pnTabla.Controls.Add(this.tbUbicacion);
            this.pnTabla.Controls.Add(this.label12);
            this.pnTabla.Controls.Add(this.tbLote);
            this.pnTabla.Controls.Add(this.tbBodega);
            this.pnTabla.Controls.Add(this.label10);
            this.pnTabla.Controls.Add(this.tbDesc);
            this.pnTabla.Controls.Add(this.label8);
            this.pnTabla.Controls.Add(this.tbNart);
            this.pnTabla.Controls.Add(this.label7);
            this.pnTabla.Location = new System.Drawing.Point(460, 90);
            this.pnTabla.Name = "pnTabla";
            this.pnTabla.Size = new System.Drawing.Size(440, 184);
            this.pnTabla.TabIndex = 7;
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
            // tbUbicacion
            // 
            this.tbUbicacion.Enabled = false;
            this.tbUbicacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUbicacion.Location = new System.Drawing.Point(123, 148);
            this.tbUbicacion.Name = "tbUbicacion";
            this.tbUbicacion.Size = new System.Drawing.Size(303, 22);
            this.tbUbicacion.TabIndex = 4;
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
            this.tbLote.Size = new System.Drawing.Size(303, 22);
            this.tbLote.TabIndex = 2;
            // 
            // tbBodega
            // 
            this.tbBodega.Enabled = false;
            this.tbBodega.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbBodega.Location = new System.Drawing.Point(123, 120);
            this.tbBodega.Name = "tbBodega";
            this.tbBodega.Size = new System.Drawing.Size(303, 22);
            this.tbBodega.TabIndex = 3;
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
            this.tbDesc.Size = new System.Drawing.Size(303, 47);
            this.tbDesc.TabIndex = 1;
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
            this.tbNart.Size = new System.Drawing.Size(303, 22);
            this.tbNart.TabIndex = 0;
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
            // pnTarjeta
            // 
            this.pnTarjeta.BackColor = System.Drawing.Color.Transparent;
            this.pnTarjeta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnTarjeta.Controls.Add(this.label2);
            this.pnTarjeta.Controls.Add(this.tbConteo);
            this.pnTarjeta.Controls.Add(this.tbTarjeta);
            this.pnTarjeta.Controls.Add(this.label3);
            this.pnTarjeta.Location = new System.Drawing.Point(10, 10);
            this.pnTarjeta.Name = "pnTarjeta";
            this.pnTarjeta.Size = new System.Drawing.Size(441, 70);
            this.pnTarjeta.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(19, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "No. Tarjeta";
            // 
            // tbConteo
            // 
            this.tbConteo.Enabled = false;
            this.tbConteo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbConteo.Location = new System.Drawing.Point(161, 37);
            this.tbConteo.MaxLength = 1;
            this.tbConteo.Name = "tbConteo";
            this.tbConteo.Size = new System.Drawing.Size(100, 22);
            this.tbConteo.TabIndex = 1;
            this.tbConteo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CheckConteoValue);
            this.tbConteo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AllowConteo3);
            // 
            // tbTarjeta
            // 
            this.tbTarjeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTarjeta.Location = new System.Drawing.Point(23, 37);
            this.tbTarjeta.Name = "tbTarjeta";
            this.tbTarjeta.Size = new System.Drawing.Size(100, 22);
            this.tbTarjeta.TabIndex = 0;
            this.tbTarjeta.TextChanged += new System.EventHandler(this.CardChanged);
            this.tbTarjeta.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CheckCardNumber);
            this.tbTarjeta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyNumberInput);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(157, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "No. Conteo";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(911, 461);
            this.Controls.Add(this.pnMain);
            this.Controls.Add(this.pnHeader);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(927, 500);
            this.MinimumSize = new System.Drawing.Size(927, 500);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Conteos Inventario BSN Medical";
            this.pnHeader.ResumeLayout(false);
            this.pnHeader.PerformLayout();
            this.pnHeader2.ResumeLayout(false);
            this.pnHeader2.PerformLayout();
            this.pnMain.ResumeLayout(false);
            this.pnMisc.ResumeLayout(false);
            this.pnMisc.PerformLayout();
            this.pnConteo.ResumeLayout(false);
            this.pnConteo.PerformLayout();
            this.pnTabla.ResumeLayout(false);
            this.pnTabla.PerformLayout();
            this.pnTarjeta.ResumeLayout(false);
            this.pnTarjeta.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnHeader;
        private System.Windows.Forms.Label lblTittle;
        private System.Windows.Forms.Panel pnHeader2;
        private System.Windows.Forms.Panel pnMain;
        private System.Windows.Forms.ComboBox cbThemeSelector;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnTarjeta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbConteo;
        private System.Windows.Forms.TextBox tbTarjeta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnTabla;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbUbicacion;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbLote;
        private System.Windows.Forms.TextBox tbBodega;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbDesc;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbNart;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel pnConteo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbTotal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnConsolidate;
        private System.Windows.Forms.Button btnClean;
        private System.Windows.Forms.Panel pnMisc;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.FlowLayoutPanel flpConteo;
        private System.Windows.Forms.ComboBox cbDataRows;
        private System.Windows.Forms.Button btnResetSettings;
        private System.Windows.Forms.Label label14;
    }
}

