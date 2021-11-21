
namespace Inventario.View
{
    partial class Reports
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Reports));
            this.pnHeader = new System.Windows.Forms.Panel();
            this.pnHeader2 = new System.Windows.Forms.Panel();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.flowLyPn = new System.Windows.Forms.FlowLayoutPanel();
            this.pnContent = new System.Windows.Forms.Panel();
            this.pnHeader.SuspendLayout();
            this.pnHeader2.SuspendLayout();
            this.flowLyPn.SuspendLayout();
            this.pnContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnHeader
            // 
            this.pnHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.pnHeader.Controls.Add(this.pnHeader2);
            this.pnHeader.Controls.Add(this.lblTitulo);
            this.pnHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnHeader.Location = new System.Drawing.Point(0, 0);
            this.pnHeader.Name = "pnHeader";
            this.pnHeader.Size = new System.Drawing.Size(484, 100);
            this.pnHeader.TabIndex = 1;
            // 
            // pnHeader2
            // 
            this.pnHeader2.BackColor = System.Drawing.Color.DimGray;
            this.pnHeader2.Controls.Add(this.lblDate);
            this.pnHeader2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnHeader2.Location = new System.Drawing.Point(0, 80);
            this.pnHeader2.Name = "pnHeader2";
            this.pnHeader2.Size = new System.Drawing.Size(484, 20);
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
            // lblTitulo
            // 
            this.lblTitulo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(12, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(249, 46);
            this.lblTitulo.TabIndex = 2;
            this.lblTitulo.Text = "REPORTES";
            // 
            // btnBack
            // 
            this.btnBack.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnBack.Font = new System.Drawing.Font("Century Gothic", 14.25F);
            this.btnBack.Location = new System.Drawing.Point(67, 131);
            this.btnBack.Margin = new System.Windows.Forms.Padding(15);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(150, 50);
            this.btnBack.TabIndex = 2;
            this.btnBack.Text = "Volver";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnClose.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(268, 131);
            this.btnClose.Margin = new System.Windows.Forms.Padding(15);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(150, 50);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Cerrar";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(15, 15);
            this.button1.Margin = new System.Windows.Forms.Padding(15, 15, 15, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(430, 40);
            this.button1.TabIndex = 8;
            this.button1.Text = "example Btn";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            // 
            // flowLyPn
            // 
            this.flowLyPn.AutoSize = true;
            this.flowLyPn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.flowLyPn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLyPn.Controls.Add(this.button1);
            this.flowLyPn.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLyPn.Location = new System.Drawing.Point(10, 10);
            this.flowLyPn.Margin = new System.Windows.Forms.Padding(10);
            this.flowLyPn.Name = "flowLyPn";
            this.flowLyPn.Size = new System.Drawing.Size(462, 105);
            this.flowLyPn.TabIndex = 9;
            // 
            // pnContent
            // 
            this.pnContent.Controls.Add(this.flowLyPn);
            this.pnContent.Controls.Add(this.btnClose);
            this.pnContent.Controls.Add(this.btnBack);
            this.pnContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnContent.Location = new System.Drawing.Point(0, 100);
            this.pnContent.Name = "pnContent";
            this.pnContent.Size = new System.Drawing.Size(484, 203);
            this.pnContent.TabIndex = 10;
            // 
            // Reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 303);
            this.Controls.Add(this.pnContent);
            this.Controls.Add(this.pnHeader);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Reports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Reportes";
            this.pnHeader.ResumeLayout(false);
            this.pnHeader.PerformLayout();
            this.pnHeader2.ResumeLayout(false);
            this.pnHeader2.PerformLayout();
            this.flowLyPn.ResumeLayout(false);
            this.pnContent.ResumeLayout(false);
            this.pnContent.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnHeader;
        private System.Windows.Forms.Panel pnHeader2;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FlowLayoutPanel flowLyPn;
        private System.Windows.Forms.Panel pnContent;
    }
}