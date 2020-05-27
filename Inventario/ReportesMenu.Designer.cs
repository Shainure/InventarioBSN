namespace Inventario
{
    partial class ReportesMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportesMenu));
            this.gbReportes = new System.Windows.Forms.GroupBox();
            this.rbFaltante = new System.Windows.Forms.RadioButton();
            this.rbTotalConteoFoto = new System.Windows.Forms.RadioButton();
            this.rbFotoCierre = new System.Windows.Forms.RadioButton();
            this.rbNartDigitados = new System.Windows.Forms.RadioButton();
            this.rbDiferencia = new System.Windows.Forms.RadioButton();
            this.rbConsolidadoConteo = new System.Windows.Forms.RadioButton();
            this.rbTarjetasConteo = new System.Windows.Forms.RadioButton();
            this.titulo = new System.Windows.Forms.Label();
            this.btnConsolidar = new System.Windows.Forms.Button();
            this.BtnConteo = new System.Windows.Forms.Button();
            this.BtnCerrar = new System.Windows.Forms.Button();
            this.gbReportes.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbReportes
            // 
            this.gbReportes.Controls.Add(this.rbFaltante);
            this.gbReportes.Controls.Add(this.rbTotalConteoFoto);
            this.gbReportes.Controls.Add(this.rbFotoCierre);
            this.gbReportes.Controls.Add(this.rbNartDigitados);
            this.gbReportes.Controls.Add(this.rbDiferencia);
            this.gbReportes.Controls.Add(this.rbConsolidadoConteo);
            this.gbReportes.Controls.Add(this.rbTarjetasConteo);
            this.gbReportes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbReportes.Location = new System.Drawing.Point(33, 61);
            this.gbReportes.Name = "gbReportes";
            this.gbReportes.Size = new System.Drawing.Size(410, 254);
            this.gbReportes.TabIndex = 0;
            this.gbReportes.TabStop = false;
            this.gbReportes.Text = "Seleccione una opción";
            // 
            // rbFaltante
            // 
            this.rbFaltante.AutoSize = true;
            this.rbFaltante.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbFaltante.Location = new System.Drawing.Point(18, 205);
            this.rbFaltante.Name = "rbFaltante";
            this.rbFaltante.Size = new System.Drawing.Size(209, 22);
            this.rbFaltante.TabIndex = 7;
            this.rbFaltante.Text = "Tarjetas con conteo faltante";
            this.rbFaltante.UseVisualStyleBackColor = true;
            // 
            // rbTotalConteoFoto
            // 
            this.rbTotalConteoFoto.AutoSize = true;
            this.rbTotalConteoFoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbTotalConteoFoto.Location = new System.Drawing.Point(18, 177);
            this.rbTotalConteoFoto.Name = "rbTotalConteoFoto";
            this.rbTotalConteoFoto.Size = new System.Drawing.Size(191, 22);
            this.rbTotalConteoFoto.TabIndex = 6;
            this.rbTotalConteoFoto.Text = "Total conteo y foto cierre";
            this.rbTotalConteoFoto.UseVisualStyleBackColor = true;
            // 
            // rbFotoCierre
            // 
            this.rbFotoCierre.AutoSize = true;
            this.rbFotoCierre.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbFotoCierre.Location = new System.Drawing.Point(18, 149);
            this.rbFotoCierre.Name = "rbFotoCierre";
            this.rbFotoCierre.Size = new System.Drawing.Size(217, 22);
            this.rbFotoCierre.TabIndex = 5;
            this.rbFotoCierre.Text = "Narts foto cierre no digitados";
            this.rbFotoCierre.UseVisualStyleBackColor = true;
            // 
            // rbNartDigitados
            // 
            this.rbNartDigitados.AutoSize = true;
            this.rbNartDigitados.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbNartDigitados.Location = new System.Drawing.Point(18, 121);
            this.rbNartDigitados.Name = "rbNartDigitados";
            this.rbNartDigitados.Size = new System.Drawing.Size(277, 22);
            this.rbNartDigitados.TabIndex = 4;
            this.rbNartDigitados.Text = "Narts digitados no están en foto cierre";
            this.rbNartDigitados.UseVisualStyleBackColor = true;
            // 
            // rbDiferencia
            // 
            this.rbDiferencia.AutoSize = true;
            this.rbDiferencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDiferencia.Location = new System.Drawing.Point(18, 93);
            this.rbDiferencia.Name = "rbDiferencia";
            this.rbDiferencia.Size = new System.Drawing.Size(232, 22);
            this.rbDiferencia.TabIndex = 3;
            this.rbDiferencia.Text = "Diferencia conteo vs foto cierre";
            this.rbDiferencia.UseVisualStyleBackColor = true;
            // 
            // rbConsolidadoConteo
            // 
            this.rbConsolidadoConteo.AutoSize = true;
            this.rbConsolidadoConteo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbConsolidadoConteo.Location = new System.Drawing.Point(18, 65);
            this.rbConsolidadoConteo.Name = "rbConsolidadoConteo";
            this.rbConsolidadoConteo.Size = new System.Drawing.Size(160, 22);
            this.rbConsolidadoConteo.TabIndex = 2;
            this.rbConsolidadoConteo.Text = "Consolidado conteo";
            this.rbConsolidadoConteo.UseVisualStyleBackColor = true;
            // 
            // rbTarjetasConteo
            // 
            this.rbTarjetasConteo.AutoSize = true;
            this.rbTarjetasConteo.Checked = true;
            this.rbTarjetasConteo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbTarjetasConteo.Location = new System.Drawing.Point(18, 37);
            this.rbTarjetasConteo.Name = "rbTarjetasConteo";
            this.rbTarjetasConteo.Size = new System.Drawing.Size(129, 22);
            this.rbTarjetasConteo.TabIndex = 1;
            this.rbTarjetasConteo.TabStop = true;
            this.rbTarjetasConteo.Text = "Tarjetas conteo";
            this.rbTarjetasConteo.UseVisualStyleBackColor = true;
            // 
            // titulo
            // 
            this.titulo.AutoSize = true;
            this.titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.titulo.Location = new System.Drawing.Point(112, 9);
            this.titulo.Name = "titulo";
            this.titulo.Size = new System.Drawing.Size(252, 31);
            this.titulo.TabIndex = 1;
            this.titulo.Text = "Reportes Inventario";
            this.titulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnConsolidar
            // 
            this.btnConsolidar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsolidar.Location = new System.Drawing.Point(33, 344);
            this.btnConsolidar.Name = "btnConsolidar";
            this.btnConsolidar.Size = new System.Drawing.Size(121, 49);
            this.btnConsolidar.TabIndex = 8;
            this.btnConsolidar.Text = "Consultar";
            this.btnConsolidar.UseVisualStyleBackColor = true;
            this.btnConsolidar.Click += new System.EventHandler(this.BtnConsolidar_Click);
            // 
            // BtnConteo
            // 
            this.BtnConteo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnConteo.Location = new System.Drawing.Point(177, 344);
            this.BtnConteo.Name = "BtnConteo";
            this.BtnConteo.Size = new System.Drawing.Size(121, 49);
            this.BtnConteo.TabIndex = 9;
            this.BtnConteo.Text = "Conteo";
            this.BtnConteo.UseVisualStyleBackColor = true;
            // 
            // BtnCerrar
            // 
            this.BtnCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCerrar.Location = new System.Drawing.Point(321, 344);
            this.BtnCerrar.Name = "BtnCerrar";
            this.BtnCerrar.Size = new System.Drawing.Size(121, 49);
            this.BtnCerrar.TabIndex = 10;
            this.BtnCerrar.Text = "Cerrar";
            this.BtnCerrar.UseVisualStyleBackColor = true;
            this.BtnCerrar.Click += new System.EventHandler(this.BtnCerrar_Click);
            // 
            // ReportesMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(482, 414);
            this.Controls.Add(this.BtnCerrar);
            this.Controls.Add(this.BtnConteo);
            this.Controls.Add(this.btnConsolidar);
            this.Controls.Add(this.titulo);
            this.Controls.Add(this.gbReportes);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReportesMenu";
            this.Text = "ReportesMenu";
            this.gbReportes.ResumeLayout(false);
            this.gbReportes.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbReportes;
        private System.Windows.Forms.Label titulo;
        private System.Windows.Forms.RadioButton rbFaltante;
        private System.Windows.Forms.RadioButton rbTotalConteoFoto;
        private System.Windows.Forms.RadioButton rbFotoCierre;
        private System.Windows.Forms.RadioButton rbNartDigitados;
        private System.Windows.Forms.RadioButton rbDiferencia;
        private System.Windows.Forms.RadioButton rbConsolidadoConteo;
        private System.Windows.Forms.RadioButton rbTarjetasConteo;
        private System.Windows.Forms.Button btnConsolidar;
        private System.Windows.Forms.Button BtnConteo;
        private System.Windows.Forms.Button BtnCerrar;
    }
}