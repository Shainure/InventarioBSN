using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Wordprocessing;

namespace Inventario
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
            date.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy");
        }

        private void NumCheck(object sender, KeyPressEventArgs e)
        {
            Char chr = e.KeyChar;
            if (!Char.IsDigit(chr) && chr != 8)
            {
                e.Handled = true;
            }
        }

        private void EnterCheck(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int total = 0;
                if (!String.IsNullOrEmpty(tb11.Text) && !String.IsNullOrEmpty(tb12.Text) && !String.IsNullOrEmpty(tb13.Text))
                {
                    total += int.Parse(tb11.Text) * int.Parse(tb12.Text) * int.Parse(tb13.Text);
                }
                if (!String.IsNullOrEmpty(tb21.Text) && !String.IsNullOrEmpty(tb22.Text) && !String.IsNullOrEmpty(tb23.Text))
                {
                    total += int.Parse(tb21.Text) * int.Parse(tb22.Text) * int.Parse(tb23.Text);
                }
                if (!String.IsNullOrEmpty(tb31.Text) && !String.IsNullOrEmpty(tb32.Text) && !String.IsNullOrEmpty(tb33.Text))
                {
                    total += int.Parse(tb31.Text) * int.Parse(tb32.Text) * int.Parse(tb33.Text);
                }
                if (!String.IsNullOrEmpty(tb41.Text) && !String.IsNullOrEmpty(tb42.Text) && !String.IsNullOrEmpty(tb43.Text))
                {
                    total += int.Parse(tb41.Text) * int.Parse(tb42.Text) * int.Parse(tb43.Text);
                }
                if (!String.IsNullOrEmpty(tb51.Text) && !String.IsNullOrEmpty(tb52.Text) && !String.IsNullOrEmpty(tb53.Text))
                {
                    total += int.Parse(tb51.Text) * int.Parse(tb52.Text) * int.Parse(tb53.Text);
                }

                tbTotal.Text = total.ToString();
                SendKeys.Send("{TAB}");
            }
        }

        private void NumCheckConteo(object sender, KeyPressEventArgs e)
        {
            Char chr = e.KeyChar;
            int num = e.KeyChar;

            if ((!Char.IsDigit(chr) && chr != 8) || (num == 48 || num > 51))
            {
                e.Handled = true;
            }
        }

        private void numTarjeta(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (String.IsNullOrEmpty(tbTarjeta.Text))
                {
                    MessageBox.Show("Debe ingresar el número de tarjeta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbTarjeta.Focus();
                }
                else
                {
                    DataBaseConnection db = new DataBaseConnection();
                    string selectQuery = "SELECT ci.codigo_prod, tbn.descripcion, ci.lote, ci.bodega, ci.ubicacion FROM tbconteosinventario ci " +
                            "INNER JOIN tbnart tbn ON ci.codigo_prod = tbn.codigo_prod WHERE numero_tarjeta = " + tbTarjeta.Text;

                    SqlDataReader sdr = db.SqlCommand(selectQuery, false);

                    if (sdr.Read())
                    {
                        tbNart.Text = Convert.ToString(sdr["codigo_prod"]);
                        tbLote.Text = Convert.ToString(sdr["lote"]);
                        tbBodega.Text = Convert.ToString(sdr["bodega"]);
                        tbUbic.Text = Convert.ToString(sdr["ubicacion"]);
                        tbDesc.Text = Convert.ToString(sdr["descripcion"]);
                        tbConteo.Enabled = true;
                        SendKeys.Send("{TAB}");
                    }
                    else
                    {
                        MessageBox.Show("¡Tarjeta no encontrada!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    db.CloseConnection();
                }
            }
        }

        private void NumConteo(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (String.IsNullOrEmpty(tbTarjeta.Text) || String.IsNullOrEmpty(tbConteo.Text))
                {
                    MessageBox.Show("Debe ingresar el número de tarjeta y conteo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbConteo.Focus();
                }
                else
                {
                    DataBaseConnection db = new DataBaseConnection();
                    string selectQuery = "select cant_conteo" + tbConteo.Text + " from tbconteosinventario where numero_tarjeta= " + tbTarjeta.Text;
                    SqlDataReader reader = db.SqlCommand(selectQuery, false);

                    if (reader.Read())
                    {
                        string aux = "cant_conteo" + tbConteo.Text;     //Para sacar el número de conteo
                        if (Convert.ToInt32(reader[aux]) != -1)
                        {
                            MessageBox.Show("Esta tarjeta ya fue grabada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        SendKeys.Send("{TAB}");
                    }
                    else
                    {
                        MessageBox.Show("Error en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    db.CloseConnection();
                }
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea guardar el registro?", "Aviso",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                if (String.IsNullOrEmpty(tbTarjeta.Text) || String.IsNullOrEmpty(tbConteo.Text) || String.IsNullOrEmpty(tbTotal.Text) || int.Parse(tbTotal.Text) == 0)
                {
                    MessageBox.Show("Datos incompletos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DataBaseConnection db = new DataBaseConnection();
                    string updateQuery = "UPDATE tbconteosinventario SET cant_conteo" + tbConteo.Text + " = " + tbTotal.Text + ", estado=1 WHERE numero_tarjeta=" + tbTarjeta.Text;

                    try
                    {
                        SqlDataReader reader = db.SqlCommand(updateQuery, false);
                        db.CloseConnection();
                        MessageBox.Show("La tarjeta #" + (tbTarjeta.Text) + " requiere tercer conteo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        limpiar();
                    }
                    catch
                    {
                        MessageBox.Show("No se pudo guardar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void limpiar()
        {
            tbTarjeta.Text = "";
            tbConteo.Text = "";
            tb11.Text = "";
            tb12.Text = "";
            tb13.Text = "";
            tb21.Text = "";
            tb22.Text = "";
            tb23.Text = "";
            tb31.Text = "";
            tb32.Text = "";
            tb33.Text = "";
            tb41.Text = "";
            tb42.Text = "";
            tb43.Text = "";
            tb51.Text = "";
            tb52.Text = "";
            tb53.Text = "";
            tbNart.Text = "";
            tbDesc.Text = "";
            tbLote.Text = "";
            tbBodega.Text = "";
            tbUbic.Text = "";
            tbTotal.Text = "";
            tbConteo.Enabled = false;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataBaseConnection db = new DataBaseConnection();

            if (db.CheckConnection())
            {
                MessageBox.Show("¡Funcionó esta cosa!", "Conexión exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("¡Explotó esta vaina!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
            tbTarjeta.Focus();
        }

        private void btnConsolidar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea consolidar los registros?", "Confirmación",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                DataBaseConnection info = new DataBaseConnection();
                int filas = info.ConsolidarConteo();
                MessageBox.Show("Se consolidaron " + filas + " tarjetas en total.", "Conteo consolidado",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            this.Hide();
            var reportes = new ReportesMenu();
            reportes.Closed += (s, args) => this.Close();
            reportes.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //DataBaseConnection.SqlCommand("rpt_test");

            //using (SqlConnection connection = new SqlConnection(@"Data Source=TEST\SQLEXPRESS;Initial Catalog = DBI; Persist Security Info=True;User ID = TestLogin; Password=12345"))
            //using (SqlCommand cmd = new SqlCommand("rpt_test", connection) { CommandType = CommandType.StoredProcedure})
            /*{
                //cmd.Parameters.AddWithValue("numTarj", firstName);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            MessageBox.Show("{0}\t{1}\n" + Convert.ToString(reader.GetInt32(0)) + "\t" + reader.GetString(1));
                        }
                    }
                    else
                    {
                        Console.WriteLine("Explotó");
                    }
                    reader.Close();
                }
            }*/
        }
    }
}