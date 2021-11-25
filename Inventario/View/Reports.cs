using Inventario.Controller;
using Inventario.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Inventario.View
{
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();
            SelectThemeColor();

            //Center the tittle 
            this.lblTittle.Left = (this.pnHeader.Width - lblTittle.Width) / 2;
            this.lblTittle.Top = ((this.pnHeader.Height - this.pnHeader2.Height) - lblTittle.Height) / 2;

            //Set Date label
            this.lblDate.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy");
            lblDate.Left = (this.pnHeader2.Width - lblDate.Width);

            //Load buttons
            LoadButtons();
        }


        #region -> Private Methods: Load reports Buttons

        private void LoadButtons()
        {
            //Get report list from XML
            List<ReportModel> reportsList = ReadXmlData.GetReportList();

            foreach (var item in reportsList)
            {
                //Create new button and initialize
                Button button = new Button
                {
                    Text = item.RptTitulo,
                    Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0))),
                    Margin = new Padding(15, 15, 15, 0),
                    Size = new Size(430, 40),
                    UseVisualStyleBackColor = true,
                    Tag = item      //Set the report object (with data) as Tag property on the button
                };

                //Asign event to the button
                button.Click += new EventHandler(ButtonClick);

                //Add button to the FlowLayoutPanel
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
            GenerateReport.ExcelReport(rpt);
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

        //Back to main menu
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            var main = new Main();
            main.Closed += (s, args) => this.Close();
            main.Show();
        }

        //Close program
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion

    }
}
