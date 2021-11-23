using Inventario.Controller;
using Inventario.Model;
using Inventario.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventario.View
{
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();
            SelectThemeColor();

            //Center the tittle (INVENTARIO BSN)
            this.lblTitulo.Left = (this.pnHeader.Width - lblTitulo.Width) / 2;
            this.lblTitulo.Top = ((this.pnHeader.Height - this.pnHeader2.Height) - lblTitulo.Height) / 2;

            //Set Date label
            this.lblDate.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy");
            lblDate.Left = (this.pnHeader2.Width - lblDate.Width);
            
            //Load buttons
            LoadButtons();            
        }


        #region -> Private Methods: Load reports Buttons

        private void LoadButtons()
        {
            List<ReportModel> reportsList = ReadXmlData.GetReportList();

            foreach (var item in reportsList)
            {
                Button button = new Button
                {
                    Text = item.RptTitulo,
                    Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0))),
                    Margin = new Padding(15, 15, 15, 0),
                    Size = new Size(430, 40),
                    UseVisualStyleBackColor = true,
                    Tag = item
                };
                button.Click += new EventHandler(ButtonClick);
                this.flowLyPn.Controls.Add(button);
            }

            //FlowLayoutPanel Size
            int flpSize = (reportsList.Count * (40+15)) + 15;
            this.flowLyPn.Height = flpSize;

            //Set form size and max/min size
            int formSize = flpSize + this.pnHeader.Height + flowLyPn.Top
                + btnClose.Height + (btnClose.Margin.Bottom*2);

            this.ClientSize = new Size(this.ClientSize.Width, formSize);
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;

            //Set buttons locations
            this.btnBack.Top = (this.pnContent.Height - this.btnClose.Height - this.btnClose.Margin.Bottom);
            this.btnClose.Top = (this.pnContent.Height - this.btnClose.Height - this.btnClose.Margin.Bottom);
        }


        void ButtonClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            ReportModel rpt = (ReportModel)btn.Tag;

            Console.WriteLine(rpt.NombrePagina);
            Console.WriteLine(rpt.RptTitulo);
            Console.WriteLine(rpt.ProcedureQuery);
            Console.WriteLine(rpt.Totales);
            Console.WriteLine("------------------");
        }

        #endregion


        #region ->  Select theme color

        //Select  color (Color)
        private void SelectThemeColor()
        {
            int colorIndex = Properties.Settings.Default.ThemeSelected;

            string colorCode = Themes.ColorList[colorIndex];

            System.Drawing.Color color = ColorTranslator.FromHtml(colorCode);

            this.pnHeader.BackColor = color;

            Color secondaryColor = new Color();

            //If: theme is default (Essity pink color)
            if (Properties.Settings.Default.ThemeSelected == 0)
            {
                // Secondary color: Essity Blue
                secondaryColor = ColorTranslator.FromHtml("#00005A");
            }
            else
            {
                //Value in decimals (0.1, 0.05, -0.1, 0.3) (percentages)
                // value < 0 = darker, value > 0 = lighter
                secondaryColor = Themes.ChangeColorBrightness(color, -0.2);
            }
            
            this.pnHeader2.BackColor = secondaryColor;            
        }


        #endregion


        #region -> Form Buttons

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            var main = new Main();
            main.Closed += (s, args) => this.Close();
            main.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            //GenerateReport rpt = new GenerateReport();
            //rpt.ExcelReport(null);

            //var x = ReadXmlData.GetSelectQuery("0", "5");
            var x = Validations.ConsultCard("0", "5");
        }
    }
}
