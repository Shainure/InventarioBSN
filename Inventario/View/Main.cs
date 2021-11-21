using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Inventario.View;

namespace Inventario
{
    public partial class Main : Form
    {

        //Constructor
        public Main()
        {
            InitializeComponent();

            //Properties.Settings.Default.Reset();

            FillThemeSelector();
            SelectThemeColor();

            //Center the tittle (INVENTARIO BSN)
            this.lblTitulo.Left = (this.pnHeader.Width - lblTitulo.Width) / 2;
            this.lblTitulo.Top = ((this.pnHeader.Height - this.pnHeader2.Height) - lblTitulo.Height) / 2;

            this.lblDate.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy");
            lblDate.Left = (this.pnHeader2.Width - lblDate.Width);            
        }

        #region -> Methods: Theme selector / Colors

        private void FillThemeSelector()
        {
            this.cbThemeSelector.Items.Clear();            
            foreach (var item in Themes.ColorList)
                this.cbThemeSelector.Items.Add(item);
        }

        //Select  color (Color)
        private void SelectThemeColor()
        {
            int colorIndex = Properties.Settings.Default.ThemeSelected;

            this.cbThemeSelector.SelectedIndex = colorIndex;
            string colorCode = Themes.ColorList[colorIndex];

            System.Drawing.Color color = ColorTranslator.FromHtml(colorCode);

            this.pnHeader.BackColor = color;            

            //If: theme is default (Essity pink color)
            if (Properties.Settings.Default.ThemeSelected == 0)
            {
                // Secondary color: Essity Blue
                this.pnHeader2.BackColor = ColorTranslator.FromHtml("#00005A");
            }
            else
            {
                //Value in decimals (0.1, 0.05, -0.1, 0.3) (percentages)
                // value < 0 = darker, value > 0 = lighter
                this.pnHeader2.BackColor = Themes.ChangeColorBrightness(color, -0.2);
            }
        }

        private void cbThemeSelector_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            if (e.Index >= 0)
            {
                Color color = ColorTranslator.FromHtml(Themes.ColorList[e.Index]);

                var rectangle = new Rectangle(e.Bounds.Left + 1, e.Bounds.Top + 1,
                    85, e.Bounds.Height - 2);

                using (var b = new SolidBrush(color))
                    e.Graphics.FillRectangle(b, rectangle);

                e.Graphics.DrawRectangle(Pens.Black, rectangle);

            }
        }

        private void cbThemeSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ThemeSelected = this.cbThemeSelector.SelectedIndex;
            Properties.Settings.Default.Save();
            SelectThemeColor();
        }


        #endregion

        private void NumConteo(object sender, KeyEventArgs e)
        {

        }

        private void NumCheckConteo(object sender, KeyPressEventArgs e)
        {

        }

        private void numTarjeta(object sender, KeyEventArgs e)
        {

        }

        private void NumCheck(object sender, KeyPressEventArgs e)
        {

        }

        private void EnterCheck(object sender, KeyEventArgs e)
        {

        }



        #region -> Buttons (Bottom)

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnClean_Click(object sender, EventArgs e)
        {

        }

        ///  ///  ///  ///  ///  ///  ///  ///

        private void btnConsolidate_Click(object sender, EventArgs e)
        {

        }
        private void btnReports_Click(object sender, EventArgs e)
        {
            this.Hide();
            var reports = new Reports();
            reports.Closed += (s, args) => this.Close();
            reports.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion

        
    }
}