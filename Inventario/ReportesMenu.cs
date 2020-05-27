using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventario
{
    public partial class ReportesMenu : Form
    {
        public ReportesMenu()
        {
            InitializeComponent();
        }

        private void BtnConsolidar_Click(object sender, EventArgs e)
        {
            Reportes nuevoReporte = new Reportes();

            if (rbTarjetasConteo.Checked == true)
                nuevoReporte.ExpTarjetasConteos();

            else if (rbConsolidadoConteo.Checked == true)
                nuevoReporte.ExpConsolidadoNart();
            else if (rbDiferencia.Checked == true)
                nuevoReporte.ExpConteoVsCierre();

        }



        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
            var menu = new MainMenu();
            menu.Closed += (s, args) => this.Close();
            menu.Show();
        }
    }
}
