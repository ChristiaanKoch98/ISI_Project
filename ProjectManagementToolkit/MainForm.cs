using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectManagementToolkit
{
    public partial class MainForm : Form
    {
        private const FormWindowState MAXIMIZED = FormWindowState.Maximized;

        public MainForm()
        {
            InitializeComponent();
        }

        private void governanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Governance governance = new Governance();
            governance.Show();
            governance.MdiParent = this;
        }

      

        private void assetAndInventoryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Asset_and_Inventory assInv = new Asset_and_Inventory();
            assInv.Show();
            assInv.MdiParent = this;
        }

        private void informationTechnologyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IT_Management itMan = new IT_Management();
            itMan.Show();
            itMan.MdiParent = this;
        }

        private void academicAndTrainingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Academic_and_Training acTran = new Academic_and_Training();
            acTran.Show();
            acTran.MdiParent = this;
        }

        private void humanResourcesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Human_Resources hr = new Human_Resources();
            hr.Show();
            hr.MdiParent = this;
        }

        private void marketingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Marketing marketing = new Marketing();
            marketing.Show();
            marketing.MdiParent = this;
        }
    }
}
