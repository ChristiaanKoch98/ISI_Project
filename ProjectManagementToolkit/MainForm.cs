using Newtonsoft.Json;
using ProjectManagementToolkit.MPMM.MPMM_Document_Forms;
using ProjectManagementToolkit.Properties;
using ProjectManagementToolkit.Utility;
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

            string json = JsonHelper.loadProjectInfo();
            List<ProjectModel> projectListModel = JsonConvert.DeserializeObject<List<ProjectModel>>(json);
            ProjectModel projectModel = new ProjectModel();
            projectModel = projectModel.getProjectModel(Settings.Default.ProjectID, projectListModel);
            DialogResult result;
            if (projectModel.LastDateTimeSynced.Year == 1)
            {
                result = MessageBox.Show("Do you want to sync with the server for the first time?", "Sync Now", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    MessageBox.Show("Sync With server is completed");
                    //add sync method here
                    projectModel.LastDateTimeSynced = DateTime.Now;
                    projectListModel = projectModel.updateProjectList(projectListModel,projectModel);
                    json = JsonConvert.SerializeObject(projectListModel);
                    JsonHelper.saveProjectInfo(json);

                }
            }
            else
            {
                if (projectModel.LastDateTimeSynced < DateTime.Today)
                {
                    result = MessageBox.Show("Do you want to sync with server now?", "Sync Now", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        MessageBox.Show("Sync With server is completed");
                        //add sync method here
                        projectModel.LastDateTimeSynced = DateTime.Now;
                        projectListModel = projectModel.updateProjectList(projectListModel, projectModel);
                        json = JsonConvert.SerializeObject(projectListModel);
                        JsonHelper.saveProjectInfo(json);
                    }
                }
            }
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

        private void projectManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PLSM_ProcessGroupingGovernance_Interfaces plsm = new PLSM_ProcessGroupingGovernance_Interfaces();
            plsm.Show();
            plsm.MdiParent = this;
        }

        private void pLSMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProjectManagement projMan = new frmProjectManagement();
            projMan.Show();
            projMan.MdiParent = this;
        }

        private void contactsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Contacts contacts = new Contacts();
            contacts.Show();
            contacts.MdiParent = this;
        }

        private void tEMPStatementOfWorkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MPMM.MPMM_Document_Forms.StatementOfWorkDocumentForm stateOfWork = new MPMM.MPMM_Document_Forms.StatementOfWorkDocumentForm();
            stateOfWork.Show();
            stateOfWork.MdiParent = this;
        }

     

        private void MainForm_Load(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                MdiClient client = control as MdiClient;
                if (!(client == null))
                {
                    client.BackColor = Color.FromArgb(34, 36, 49);
                    break;
                }
            }
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void generalManagementToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            GeneralManagement generalManagement = new GeneralManagement();
            generalManagement.Show();
            generalManagement.MdiParent = this;
        }

        private void assetAndInventoryToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            Asset_and_Inventory asset_And_Inventory = new Asset_and_Inventory();
            asset_And_Inventory.Show();
            asset_And_Inventory.MdiParent = this;
        }

        private void informationTechnologyToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            IT_Management iT_Management = new IT_Management();
            iT_Management.Show();
            iT_Management.MdiParent = this;
        }

        private void projectSelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProjectSelection projectSelection = new ProjectSelection();
            Settings.Default.ProjectID = "";
            projectSelection.Show();
            this.Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
