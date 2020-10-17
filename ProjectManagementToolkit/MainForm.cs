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
            Governance governanceForm = new Governance();
            governanceForm.Show();
            governanceForm.MdiParent = this;
        }

      

        private void assetAndInventoryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Asset_and_Inventory assInvForm = new Asset_and_Inventory();
            assInvForm.Show();
            assInvForm.MdiParent = this;
        }

        private void informationTechnologyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IT_Management itManForm = new IT_Management();
            itManForm.Show();
            itManForm.MdiParent = this;
        }

        private void academicAndTrainingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Academic_and_Training acTranForm = new Academic_and_Training();
            acTranForm.Show();
            acTranForm.MdiParent = this;
        }

        private void humanResourcesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Human_Resources hrForm = new Human_Resources();
            hrForm.Show();
            hrForm.MdiParent = this;
        }

        private void marketingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Marketing marketingForm = new Marketing();
            marketingForm.Show();
            marketingForm.MdiParent = this;
        }

        private void processesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Processes processesForm = new Processes();
            processesForm.Show();
            processesForm.MdiParent = this;
        }
    }
}
