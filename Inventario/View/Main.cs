using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Inventario.Controller;
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
            DataTextBoxRows();

            //Center the tittle (INVENTARIO BSN)
            this.lblTitulo.Left = (this.pnHeader.Width - lblTitulo.Width) / 2;
            this.lblTitulo.Top = ((this.pnHeader.Height - this.pnHeader2.Height) - lblTitulo.Height) / 2;

            this.lblDate.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy");
            lblDate.Left = (this.pnHeader2.Width - lblDate.Width);            
        }



        #region -> Methods: Settings mettods

        #region -> Generate text boxes (data input)
        private void DataTextBoxRows()
        {
            this.cbDataRows.Items.Clear();
            for (int i = 3; i <= 10; i++)
            {
                this.cbDataRows.Items.Add(i);
            }
            this.cbDataRows.SelectedItem = Properties.Settings.Default.DataRows;
        }

        private void cbDataRows_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.DataRows = Convert.ToInt32(this.cbDataRows.SelectedItem);
            Properties.Settings.Default.Save();
        }

        #endregion

        #region -> Theme selector / Colors

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

        #endregion

        #region -> TextBox Events

        //Check if input is a number: All boxes (except "No. Conteo")
        private void OnlyNumberInput(object sender, KeyPressEventArgs e)
        {
            Char chr = e.KeyChar;                       //Converts the key entered to char
            if (!Char.IsDigit(chr) && chr != 8)         // if char is not a number -> 
            {
                //System.Media.SystemSounds.Hand.Play();  //Play error sound
                e.Handled = true;                       //Remove key entered
            }
        }

        //Press tab (move to the next TextBox) on Enter key
        private void TabOnEnterKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        //If the card number changed, clean conteo Number to restart
        private void CardChanged(object sender, EventArgs e)
        {
            tbConteo.Text = string.Empty;
            tbConteo.Enabled = false;
        }

        //Check if the card number exist on the DB
        private void CheckCardNumber(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (String.IsNullOrEmpty(tbTarjeta.Text))
                {
                    MessageBox.Show("Debe ingresar el número de tarjeta.", "Inventario BSN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbTarjeta.Focus();
                }
                else
                {
                    var x = Validations.ConsultCard("0", tbTarjeta.Text);
                    if (x.Rows.Count > 0)
                    {
                        tbNart.Text = Convert.ToString(x.Rows[0][0]);
                        tbDesc.Text = Convert.ToString(x.Rows[0][1]);
                        tbLote.Text = Convert.ToString(x.Rows[0][2]);
                        tbBodega.Text = Convert.ToString(x.Rows[0][3]);
                        tbUbicacion.Text = Convert.ToString(x.Rows[0][4]);
                        tbConteo.Enabled = true;
                        tbConteo.Focus();
                    }
                    else
                    {
                        MessageBox.Show($"Tarjeta #{tbTarjeta.Text} no encontrada", "Inventario BSN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        CleanControls();
                    }
                }
            }
        }

        //Calculate the total
        private void ConteoTbTextChanged(object sender, EventArgs e)
        {
            int total = 0;
            int columnSize = 3;

            var conteoTextBoxes = flpConteo.Controls.OfType<TextBox>()
                .Where(c => c.Tag != null);

            for (int i = 0; i < conteoTextBoxes.Count()/columnSize; i++)
            {
                var sum = 1;
                var currentTb = conteoTextBoxes
                    .Where(c => c.Tag != null && c.Tag.Equals($"{i}"))
                    .OrderBy(c => c.TabIndex);
                foreach (var item in currentTb)
                {
                    if (String.IsNullOrEmpty(item.Text))
                    {
                        sum = 0;
                        break; 
                    }
                    sum *= Convert.ToInt32(item.Text);
                }
                total += sum;
            }
            tbTotal.Text = Convert.ToString(total);
        }

        #endregion

        #region -> Buttons (Bottom)

        //Methods
        private void CleanControls()
        {
            tbTarjeta.Text = String.Empty;
            tbConteo.Text = String.Empty;

            foreach (var c in flpConteo.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Text = String.Empty;
                    ((TextBox)c).Enabled = false;
                }
            }

            foreach (var c in pnTabla.Controls)
                if (c is TextBox) ((TextBox)c).Text = String.Empty;

            tbConteo.Enabled = false;
        }

        //Events

        private void btnSave_Click(object sender, EventArgs e)
        {
            #region -> Error handling (Empty or 0) 
            bool showError = false;
            string errorMsg = string.Empty;
            if (String.IsNullOrEmpty(tbTarjeta.Text) ||  int.Parse(tbTarjeta.Text) <= 0)
            {
                errorMsg += $"\r\nFalta el número de tarjeta o número incorrecto: {tbTarjeta.Text}";
                showError = true;
            }
            if (String.IsNullOrEmpty(tbConteo.Text) ||  int.Parse(tbConteo.Text) <= 0)
            {
                errorMsg += $"\r\nFalta el número de conteo o número incorrecto: {tbConteo.Text}";
                showError = true;
            }
            if (String.IsNullOrEmpty(tbTotal.Text) ||  int.Parse(tbTotal.Text) <= 0)
            {
                errorMsg += $"\r\nFalta el conteo total o número incorrecto: {tbTotal.Text}";
                showError = true;
            }
            if (showError)
            {
                MessageBox.Show("Datos incompletos." + Environment.NewLine + errorMsg,
                    "Inventario BSN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion

            int rows = SaveData.SaveCard("3", tbTarjeta.Text, tbConteo.Text, tbTotal.Text);            
            if (rows == 1)
            {
                if (tbConteo.Text != "3")
                {
                    //Check if conteo3 is needed
                    bool RequestConteo3 = Validations.RequestConteo3("1", tbTarjeta.Text);
                    //Alert message
                    if (RequestConteo3)
                        MessageBox.Show($"La tarjeta #{tbTarjeta.Text} requiere tercer conteo.", "Inventario BSN",
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }                

                if (tbConteo.Text.Equals("3"))
                {
                    string CompareConteo3 = Validations.ValidateConteo3("1", tbTarjeta.Text);
                    if (CompareConteo3 != null)
                    {
                        MessageBox.Show(CompareConteo3, "Inventario BSN",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }                

                CleanControls();
                tbTarjeta.Focus();
            }
            else
            {
                string newLine = Environment.NewLine;
                StringBuilder sb = new StringBuilder();
                sb.Append($"No se pudo guardar la tarjeta. {newLine}");
                sb.Append($"Información:{newLine}");
                sb.Append($"Número de tarjeta: {tbTarjeta.Text} {newLine}");
                sb.Append($"Número de conteo: {tbConteo.Text} {newLine}");
                sb.Append($"Total del conteo: {tbTotal.Text}");
                MessageBox.Show(sb.ToString(), "Inventario BSN",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);            
            }

        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            CleanControls();
            tbTarjeta.Focus();
        }

        ///  ///  ///  ///  ///  ///  ///  ///

        private void btnConsolidate_Click(object sender, EventArgs e)
        {
            var confirmation = MessageBox.Show("¿Desea consolidar los registros?", "Inventario BSN",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1);

            if (confirmation == System.Windows.Forms.DialogResult.Yes)
            {
                int filas = SaveData.Consolidate("4");
                MessageBox.Show("Se consolidaron " + filas + " tarjetas en total.", "Inventario BSN",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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

        ///  ///  ///  ///  ///  ///  ///  ///
        private void btnResetSettings_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reset();
            SelectThemeColor();
            DataTextBoxRows();
        }


        #endregion

        private void AllowConteo3(object sender, KeyPressEventArgs e)
        {
            Char chr = e.KeyChar;
            int num = e.KeyChar;
            //8 = backspace, 48 = 0, 51 = 3

            bool AllowConteo3 = Validations.AllowConteo3("1", tbTarjeta.Text);
            if (AllowConteo3)
            {
                if ((!Char.IsDigit(chr) && chr != 8) || (num == 48 || num > 51))
                {
                    e.Handled = true;
                }
            }
            else
            {
                if ((!Char.IsDigit(chr) && chr != 8) || (num == 48 || num > 50))
                {
                    e.Handled = true;
                    if (tbConteo.Text.Equals("3"))
                    {
                        MessageBox.Show($"Tarjeta #{tbTarjeta.Text} no puede tener conteo 3. \r\nFalta conteo 1 o 2",
                            "Inventario BSN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void CheckConteoValue(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!String.IsNullOrEmpty(tbConteo.Text))
                {
                    int conteoValue = Validations.CheckConteoValue("2", tbTarjeta.Text, tbConteo.Text);
                    if (conteoValue != -1)
                    {
                        MessageBox.Show($"¡La tarjeta #{tbTarjeta.Text} ya fue grabada!\r\n" +
                            $"Valor actual: {conteoValue}",
                            "Inventario BSN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    EnableInputFields();
                    SendKeys.Send("{TAB}");
                }                
            }
        }

        private void EnableInputFields()
        {
            foreach (var c in flpConteo.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Enabled = true;                    
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool RequestConteo3 = Validations.RequestConteo3("1", tbTarjeta.Text);
        }
    }
}