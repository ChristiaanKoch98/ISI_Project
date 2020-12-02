using Newtonsoft.Json;
using ProjectManagementToolkit.MPMM;
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

            foreach (ToolStripMenuItem item in menuStrip1.Items)
            {
                item.BackColor = Color.FromArgb(141, 143, 149);
                item.ForeColor = Color.FromArgb(32, 32, 32);
                foreach (ToolStripMenuItem children in item.DropDownItems)
                {
                    children.BackColor = Color.FromArgb(128,128,128);
                    children.ForeColor = Color.FromArgb(32, 32, 32);
                    foreach (ToolStripMenuItem child in children.DropDownItems)
                    {
                        child.BackColor = Color.FromArgb(128, 128, 128);
                        child.ForeColor = Color.FromArgb(32, 32, 32);
                        foreach (ToolStripMenuItem InnerChild in child.DropDownItems)
                        {
                            InnerChild.BackColor = Color.FromArgb(128, 128, 128);
                            InnerChild.ForeColor = Color.FromArgb(32, 32, 32);
                        }
                    }
                }
            }

            string json = JsonHelper.loadProjectInfo(Settings.Default.Username);
            List<ProjectModel> projectListModel = JsonConvert.DeserializeObject<List<ProjectModel>>(json);
            ProjectModel projectModel = new ProjectModel();
            projectModel = projectModel.getProjectModel(Settings.Default.ProjectID, projectListModel);
            DialogResult result;
            if (projectModel.LastDateTimeSynced.Year == 1)
            {
                result = MessageBox.Show("Do you want to sync with the server for the first time?", "Sync Now", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    //add sync method here
                    SyncForm syncForm = new SyncForm();
                    syncForm.Show();
                    syncForm.MdiParent = this;
                    projectModel.LastDateTimeSynced = DateTime.Now;
                    projectListModel = projectModel.updateProjectList(projectListModel, projectModel);
                    json = JsonConvert.SerializeObject(projectListModel);
                    JsonHelper.saveProjectInfo(json, Settings.Default.Username);

                }
            }
            else
            {
                if (projectModel.LastDateTimeSynced < DateTime.Today)
                {
                    result = MessageBox.Show("Do you want to sync with server now?", "Sync Now", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        //add sync method here
                        SyncForm syncForm = new SyncForm();
                        syncForm.Show();
                        syncForm.MdiParent = this;
                        projectModel.LastDateTimeSynced = DateTime.Now;
                        projectListModel = projectModel.updateProjectList(projectListModel, projectModel);
                        json = JsonConvert.SerializeObject(projectListModel);
                        JsonHelper.saveProjectInfo(json, Settings.Default.Username);
                    }
                }
            }
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

        private void templateToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void templateToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FeasibiltyStudyDocumentForm feasibiltyStudyDocumentForm = new FeasibiltyStudyDocumentForm();
            feasibiltyStudyDocumentForm.Show();
            feasibiltyStudyDocumentForm.MdiParent = this;
        }

        private void templateToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            JobDescriptionDocumentForm jobDescriptionDocumentForm = new JobDescriptionDocumentForm();
            jobDescriptionDocumentForm.Show();
            jobDescriptionDocumentForm.MdiParent = this;
        }

        private void checklistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProjectOfficeChecklistDocumentForm form = new ProjectOfficeChecklistDocumentForm();
            form.Show();
            form.MdiParent = this;
        }

        private void reviewFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PhaseReviewFormInitiationDocumentForm form = new PhaseReviewFormInitiationDocumentForm();
            form.Show();
            form.MdiParent = this;
        }

        private void templateToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            ProjectPlanDocumentForm projectPlanDocumentForm = new ProjectPlanDocumentForm();
            projectPlanDocumentForm.Show();
            projectPlanDocumentForm.MdiParent = this;
        }

        private void templateToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            ResourcePlanDocumentForm form = new ResourcePlanDocumentForm();
            form.Show();
            form.MdiParent = this;
        }

        private void templateToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            FinacialPlanDocumentForm form = new FinacialPlanDocumentForm();
            form.Show();
            form.MdiParent = this;
        }

        private void templateToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            QualityPlanDocumentForm form = new QualityPlanDocumentForm();
            form.Show();
            form.MdiParent = this;
        }

        private void templateToolStripMenuItem8_Click(object sender, EventArgs e)
        {
            RiskPlanDocumentForm form = new RiskPlanDocumentForm();
            form.Show();
            form.MdiParent = this;
        }

        private void templateToolStripMenuItem9_Click(object sender, EventArgs e)
        {
            AcceptancePlanDocumentForm form = new AcceptancePlanDocumentForm();
            form.Show();
            form.MdiParent = this;
        }

        private void templateToolStripMenuItem10_Click(object sender, EventArgs e)
        {
            CommunicationsPlanDocumentForm form = new CommunicationsPlanDocumentForm();
            form.Show();
            form.MdiParent = this;
        }

        private void templateToolStripMenuItem11_Click(object sender, EventArgs e)
        {
            ProcurementPlanDocumentForm form = new ProcurementPlanDocumentForm();
            form.Show();
            form.MdiParent = this;
        }

        private void exampleToolStripMenuItem15_Click(object sender, EventArgs e)
        {
            StatementOfWorkDocumentForm form = new StatementOfWorkDocumentForm();
            form.Show();
            form.MdiParent = this;
        }

        private void templateToolStripMenuItem14_Click(object sender, EventArgs e)
        {
            RequestForInformationDocumentForm form = new RequestForInformationDocumentForm();
            form.Show();
            form.MdiParent = this;
        }

        private void templateToolStripMenuItem16_Click(object sender, EventArgs e)
        {
            SupplierContractDocumentForm form = new SupplierContractDocumentForm();
            form.Show();
            form.MdiParent = this;
        }

        private void templateToolStripMenuItem15_Click(object sender, EventArgs e)
        {
            RequestForProposalDocumentForm form = new RequestForProposalDocumentForm();
            form.Show();
            form.MdiParent = this;
        }

        private void timeManagementProcessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TimeMangementProcessDocumentForm form = new TimeMangementProcessDocumentForm();
            form.Show();
            form.MdiParent = this;
        }

        private void timesheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TimesheetFormDocumentForm form = new TimesheetFormDocumentForm();
            form.Show();
            form.MdiParent = this;
        }

        private void costManagementProcessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CostManagementProcessDocumentForm form = new CostManagementProcessDocumentForm();
            form.Show();
            form.MdiParent = this;
        }

        private void expenseFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExpenseFormDocumentForm form = new ExpenseFormDocumentForm();
            form.Show();
            form.MdiParent = this;
        }

        private void qualityManagementProcessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QualityManagementProcessDocumentForm form = new QualityManagementProcessDocumentForm();
            form.Show();
            form.MdiParent = this;
        }

        private void qaulityReviewFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QualityReviewPlanDocumentForm form = new QualityReviewPlanDocumentForm();
            form.Show();
            form.MdiParent = this;
        }

        private void changeManagementProcessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeManagementProcessDocumentForm form = new ChangeManagementProcessDocumentForm();
            form.Show();
            form.MdiParent = this;
        }

        private void changeRequestFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeRequestFormDocumentForm form = new ChangeRequestFormDocumentForm();
            form.Show();
            form.MdiParent = this;
        }

        private void changeRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void riskManagementProcessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RiskManagementProcessDocumentForm form = new RiskManagementProcessDocumentForm();
            form.Show();
            form.MdiParent = this;
        }

        private void riskFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RiskFormDocumentForm form = new RiskFormDocumentForm();
            form.Show();
            form.MdiParent = this;
        }

        private void issueManagementProcessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IssueManagementProcessDocumentForm form = new IssueManagementProcessDocumentForm();
            form.Show();
            form.MdiParent = this;
        }

        private void issueFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IssueFormDocumentForm form = new IssueFormDocumentForm();
            form.Show();
            form.MdiParent = this;
        }

        private void procurementRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void purchaseOrderFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PurchaseOrderFormDocumentForm form = new PurchaseOrderFormDocumentForm();
            form.Show();
            form.MdiParent = this;
        }

        private void acceptanceManagementProcessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AcceptanceManagementProcessDocumentForm form = new AcceptanceManagementProcessDocumentForm();
            form.Show();
            form.MdiParent = this;
        }

        private void acceptanceFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AcceptanceFormDocumentForm form = new AcceptanceFormDocumentForm();
            form.Show();
            form.MdiParent = this;
        }

        private void communicationsManagementProcesssToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommunicationsManagementProcessDocumentForm form = new CommunicationsManagementProcessDocumentForm();
            form.Show();
            form.MdiParent = this;
        }

        private void projectStatusReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProjectStatusReportDocumentForm form = new ProjectStatusReportDocumentForm();
            form.Show();
            form.MdiParent = this;
        }

        private void reviewFormToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            PhaseReviewFormExecutionDocumentForm form = new PhaseReviewFormExecutionDocumentForm();
            form.Show();
            form.MdiParent = this;
        }

        private void templateToolStripMenuItem17_Click(object sender, EventArgs e)
        {
            ProjectClosureReportDocumentForm form = new ProjectClosureReportDocumentForm();
            form.Show();
            form.MdiParent = this;
        }

        private void templateToolStripMenuItem18_Click(object sender, EventArgs e)
        {
            PostImplementationReviewDocumentForm form = new PostImplementationReviewDocumentForm();
            form.Show();
            form.MdiParent = this;
        }

        private void reviewFormToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PhaseReviewFormPlanningDocumentForm form = new PhaseReviewFormPlanningDocumentForm();
            form.Show();
            form.MdiParent = this;
        }

        private void exampleToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ProjectCharterForm form = new ProjectCharterForm();
            form.Show();
            form.MdiParent = this;
        }
    }
}
