using RealEstateManagement.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RealEstateManagement
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Customer fCostumer = new Customer() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, AutoScroll = true, AutoSize = true };
            this.pnlStage.Controls.Clear();
            this.pnlStage.Controls.Add(fCostumer);
            fCostumer.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Salesperson fSalesperson = new Salesperson() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, AutoScroll = true, AutoSize = true };
            this.pnlStage.Controls.Clear();
            this.pnlStage.Controls.Add(fSalesperson);
            fSalesperson.Show();

        }

        private void btnRegRealEstate_Click(object sender, EventArgs e)
        {
            Realty frealty = new Realty() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, AutoScroll = true, AutoSize = true };
            this.pnlStage.Controls.Clear();
            this.pnlStage.Controls.Add(frealty);
            frealty.Show();
        }

        private void btnProjects_Click(object sender, EventArgs e)
        {

            string x = Guid.NewGuid().ToString();
            MessageBox.Show(x);
        }
    }
}
