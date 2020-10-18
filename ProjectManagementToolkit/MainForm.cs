using ProjectManagementToolKit;
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

        private void policiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Policies_and_Procedures polProForm = new Policies_and_Procedures();
            polProForm.Show();
            polProForm.MdiParent = this;
        }

        private void generalManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GeneralManagement genManForm = new GeneralManagement();
            genManForm.Show();
            genManForm.MdiParent = this;
        }

        private void inventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InventoryAndSales invForm = new InventoryAndSales();
            invForm.Show();
            invForm.MdiParent = this;
        }

        private void financesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Finances financesForm = new Finances();
            financesForm.Show();
            financesForm.MdiParent = this;

        }

        private void eventsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Events eventsForm = new Events();
            eventsForm.Show();
            eventsForm.MdiParent = this;
        }
    }
}
