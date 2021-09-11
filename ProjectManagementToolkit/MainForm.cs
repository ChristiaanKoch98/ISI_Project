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
using System.Diagnostics;
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
                    client.BackColor = Color.FromArgb(209, 237, 242);
                    break;
                }
            }

            foreach (ToolStripMenuItem item in menuStrip1.Items)
            {
                item.BackColor = Color.FromArgb(73, 173, 252);
                item.ForeColor = Color.FromArgb(32, 32, 32);
                foreach (ToolStripMenuItem children in item.DropDownItems)
                {
                    children.BackColor = Color.FromArgb(73, 173, 252);
                    children.ForeColor = Color.FromArgb(32, 32, 32);
                    foreach (ToolStripMenuItem child in children.DropDownItems)
                    {
                        child.BackColor = Color.FromArgb(73, 173, 252);
                        child.ForeColor = Color.FromArgb(32, 32, 32);
                        foreach (ToolStripMenuItem InnerChild in child.DropDownItems)
                        {
                            InnerChild.BackColor = Color.FromArgb(73, 173, 252);
                            InnerChild.ForeColor = Color.FromArgb(32, 32, 32);
                        }
                    }
                }
            }

            ToolStripLabel toolStripLabel = new ToolStripLabel();
            toolStripLabel.Text = "Project ID: ";
            toolStripLabel.BackColor = Color.FromArgb(73, 173, 252);
            menuStrip1.Items.Add(toolStripLabel);

            ToolStripTextBox txtProjectID = new ToolStripTextBox();
            txtProjectID.Text = Settings.Default.ProjectID;
            txtProjectID.AutoSize = false;
            Size size = TextRenderer.MeasureText(txtProjectID.Text, txtProjectID.Font);
            txtProjectID.Width = size.Width+10;
            txtProjectID.ReadOnly = true;
            txtProjectID.Padding = new Padding(5);
            menuStrip1.Items.Add(txtProjectID);

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

        private void syncToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SyncForm syncForm = new SyncForm();
            syncForm.Show();
            syncForm.MdiParent = this;
        }

        private void printFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (PrintDialog pd = new PrintDialog())
            {
                pd.ShowDialog();
                using (OpenFileDialog of = new OpenFileDialog())
                {
                    if (of.ShowDialog() == DialogResult.Yes)
                    {
                        ProcessStartInfo info = new ProcessStartInfo(of.FileName);
                        info.Verb = "PrintTo";
                        info.Arguments = pd.PrinterSettings.PrinterName;
                        info.CreateNoWindow = true;
                        info.WindowStyle = ProcessWindowStyle.Hidden;
                        Process.Start(info);
                    }

                }

            }
         }

        private void issueRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IssueRegisterForm issueRegisterForm = new IssueRegisterForm();
            issueRegisterForm.Show();
            issueRegisterForm.MdiParent = this;

        }

        private void developABusinessCaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BusinessCaseDocumentForm businessCaseDocumentForm = new BusinessCaseDocumentForm();
            businessCaseDocumentForm.Show();
            businessCaseDocumentForm.MdiParent = this;
        }

        private void undertakeAFeasibilityStudyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FeasibiltyStudyDocumentForm feasibiltyStudyDocumentForm = new FeasibiltyStudyDocumentForm();
            feasibiltyStudyDocumentForm.Show();
            feasibiltyStudyDocumentForm.MdiParent = this;
        }

        private void establishTheProjectChaterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProjectCharterForm projectCharterForm = new ProjectCharterForm();
            projectCharterForm.Show();
            projectCharterForm.MdiParent = this;
        }

        private void appointAProjectTeamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JobDescriptionDocumentForm jobDescriptionDocumentForm = new JobDescriptionDocumentForm();
            jobDescriptionDocumentForm.Show();
            jobDescriptionDocumentForm.MdiParent = this;
        }

        private void setupAProjectOfficeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProjectOfficeChecklistDocumentForm projectOfficeChecklistDocumentForm = new ProjectOfficeChecklistDocumentForm();
            projectOfficeChecklistDocumentForm.Show();
            projectOfficeChecklistDocumentForm.MdiParent = this;
        }

        private void termsOfReferenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TermOfReferenceDocumentForm termOfReferenceDocumentForm = new TermOfReferenceDocumentForm();
            termOfReferenceDocumentForm.Show();
            termOfReferenceDocumentForm.MdiParent = this;
        }

        private void peformPhaseReviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PhaseReviewFormInitiationDocumentForm phaseReviewFormInitiationDocumentForm = new PhaseReviewFormInitiationDocumentForm();
            phaseReviewFormInitiationDocumentForm.Show();
            phaseReviewFormInitiationDocumentForm.MdiParent = this;
        }

        private void createAProjectPlanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProjectPlanDocumentForm projectPlanDocumentForm = new ProjectPlanDocumentForm();
            projectPlanDocumentForm.Show();
            projectPlanDocumentForm.MdiParent = this;
        }

        private void createAResourcePlanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResourcePlanDocumentForm resourcePlanDocumentForm = new ResourcePlanDocumentForm();
            resourcePlanDocumentForm.Show();
            resourcePlanDocumentForm.MdiParent = this;
        }

        private void createAFinancialPlanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FinacialPlanDocumentForm finacialPlanDocumentForm = new FinacialPlanDocumentForm();
            finacialPlanDocumentForm.Show();
            finacialPlanDocumentForm.MdiParent = this;
        }

        private void createAQualityPlanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QualityPlanDocumentForm qualityPlanDocumentForm = new QualityPlanDocumentForm();
            qualityPlanDocumentForm.Show();
            qualityPlanDocumentForm.MdiParent = this;
        }

        private void createARiskPlanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RiskPlanForm riskPlanForm = new RiskPlanForm();
            riskPlanForm.Show();
            riskPlanForm.MdiParent = this;
        }

        private void createAnAcceptancePlanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AcceptancePlanDocumentForm acceptancePlanDocumentForm = new AcceptancePlanDocumentForm();
            acceptancePlanDocumentForm.Show();
            acceptancePlanDocumentForm.MdiParent = this;
        }

        private void createACommunicationPlanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommunicationsPlanDocumentForm communicationsPlanDocumentForm = new CommunicationsPlanDocumentForm();
            communicationsPlanDocumentForm.Show();
            communicationsPlanDocumentForm.MdiParent = this;
        }

        private void createAProcurementPlanToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            ProcurementPlanDocumentForm procurementPlanDocumentForm = new ProcurementPlanDocumentForm();
            procurementPlanDocumentForm.Show();
            procurementPlanDocumentForm.MdiParent = this;
        }

        private void defineTheSelectionProcessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectionProcess selectionProcess = new SelectionProcess();
            selectionProcess.Show();
            selectionProcess.MdiParent = this;

        }

        private void issueAStatementOfWorkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StatementOfWorkDocumentForm statementOfWorkDocumentForm = new StatementOfWorkDocumentForm();
            statementOfWorkDocumentForm.Show();
            statementOfWorkDocumentForm.MdiParent = this;
        }

        private void issueARequestForInfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RequestForInformationDocumentForm requestForInformationDocumentForm = new RequestForInformationDocumentForm();
            requestForInformationDocumentForm.Show();
            requestForInformationDocumentForm.MdiParent = this;
        }

        private void crearteSupplierContractToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SupplierContractDocumentForm supplierContractDocumentForm = new SupplierContractDocumentForm();
            supplierContractDocumentForm.Show();
            supplierContractDocumentForm.MdiParent = this;
        }

        private void issueARequestForProposalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RequestForInformationDocumentForm requestForInformationDocumentForm = new RequestForInformationDocumentForm();
            requestForInformationDocumentForm.Show();
            requestForInformationDocumentForm.MdiParent = this;
        }

        private void performPhaseReviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PhaseReviewFormPlanningDocumentForm phaseReviewFormPlanningDocumentForm = new PhaseReviewFormPlanningDocumentForm();
            phaseReviewFormPlanningDocumentForm.Show();
            phaseReviewFormPlanningDocumentForm.MdiParent = this;
        }

        private void buildDeliverablesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GeneralGuideForBuildingDeliverables generalGuideForBuildingDeliverables = new GeneralGuideForBuildingDeliverables();
            generalGuideForBuildingDeliverables.Show();
            generalGuideForBuildingDeliverables.MdiParent = this;
        }

        private void monitorControlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GeneralGuideForMonitorandControl generalGuideForMonitorandControl = new GeneralGuideForMonitorandControl();
            generalGuideForMonitorandControl.Show();
            generalGuideForMonitorandControl.MdiParent = this;
        }

        private void timeManagementProcessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TimeMangementProcessDocumentForm timeMangementProcessDocumentForm = new TimeMangementProcessDocumentForm();
            timeMangementProcessDocumentForm.Show();
            timeMangementProcessDocumentForm.MdiParent = this;
        }

        private void timesheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TimesheetFormDocumentForm timesheetForm = new TimesheetFormDocumentForm();
            timesheetForm.Show();
            timesheetForm.MdiParent = this;
        }

        private void timesheetRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TimesheetRegister timesheetRegister = new TimesheetRegister();
            timesheetRegister.Show();
            timesheetRegister.MdiParent = this;
        }

        private void costManagementProcessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CostManagementProcessDocumentForm costManagementProcessDocumentForm = new CostManagementProcessDocumentForm();
            costManagementProcessDocumentForm.Show();
            costManagementProcessDocumentForm.MdiParent = this;
        }

        private void expenseFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExpenseFormDocumentForm expenseFormDocumentForm = new ExpenseFormDocumentForm();
            expenseFormDocumentForm.Show();
            expenseFormDocumentForm.MdiParent = this;
        }

        private void expenseRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExpenseRegister expenseRegister = new ExpenseRegister();
            expenseRegister.Show();
            expenseRegister.MdiParent = this;
        }

        private void qualityManagementProcessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QualityManagementProcessDocumentForm qualityManagementProcessDocument = new QualityManagementProcessDocumentForm();
            qualityManagementProcessDocument.Show();
            qualityManagementProcessDocument.MdiParent = this;
        }

        private void qaulityReviewFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QualityReviewPlanDocumentForm qualityReviewPlan = new QualityReviewPlanDocumentForm();
            qualityReviewPlan.Show();
            qualityReviewPlan.MdiParent = this;
        }

        private void qualityRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QualityRegister qualityRegister = new QualityRegister();
            qualityRegister.Show();
            qualityRegister.MdiParent = this;
        }

        private void changeManagementProcessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeManagementProcessDocumentForm changeManagementProcess = new ChangeManagementProcessDocumentForm();
            changeManagementProcess.Show();
            changeManagementProcess.MdiParent = this;
        }

        private void changeRequestFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeRequestFormDocumentForm changeRequestForm = new ChangeRequestFormDocumentForm();
            changeRequestForm.Show();
            changeRequestForm.MdiParent = this;
        }

        private void changeRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeRegister changeRegister = new ChangeRegister();
            changeRegister.Show();
            changeRegister.MdiParent = this;
        }

        private void riskManagementProcessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RiskManagementProcessDocumentForm riskManagementProcessDocumentForm = new RiskManagementProcessDocumentForm();
            riskManagementProcessDocumentForm.Show();
            riskManagementProcessDocumentForm.MdiParent = this;
        }

        private void riskFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RiskFormDocumentForm riskFormDocumentForm = new RiskFormDocumentForm();
            riskFormDocumentForm.Show();
            riskFormDocumentForm.MdiParent = this;
        }

        private void riskRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RiskRegisterForm riskRegister = new RiskRegisterForm();
            riskRegister.Show();
            riskRegister.MdiParent = this;
        }

        private void issueManagementProcessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IssueManagementProcessDocumentForm issueManagementProcessDocumentForm = new IssueManagementProcessDocumentForm();
            issueManagementProcessDocumentForm.Show();
            issueManagementProcessDocumentForm.MdiParent = this;
        }

        private void issueFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IssueFormDocumentForm issueForm = new IssueFormDocumentForm();
            issueForm.Show();
            issueForm.MdiParent = this;
        }

        private void purchaseOrderFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PurchaseOrderFormDocumentForm purchaseOrderFormDocumentForm = new PurchaseOrderFormDocumentForm();
            purchaseOrderFormDocumentForm.Show();
            purchaseOrderFormDocumentForm.MdiParent = this;
        }

        private void procurementRegisterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ProcurementRegister procurementRegister = new ProcurementRegister();
            procurementRegister.Show();
            procurementRegister.MdiParent = this;
        }

        private void acceptanceManagementProcessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AcceptanceManagementProcessDocumentForm acceptanceManagementProcessDocument = new AcceptanceManagementProcessDocumentForm();
            acceptanceManagementProcessDocument.Show();
            acceptanceManagementProcessDocument.MdiParent = this;
        }

        private void acceptanceFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AcceptanceFormDocumentForm acceptanceFormDocumentForm = new AcceptanceFormDocumentForm();
            acceptanceFormDocumentForm.Show();
            acceptanceFormDocumentForm.MdiParent = this;
        }

        private void acceptanceRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AcceptanceRegister acceptanceRegister = new AcceptanceRegister();
            acceptanceRegister.Show();
            acceptanceRegister.MdiParent = this;
        }

        private void communicationsManagementProcesssToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommunicationsManagementProcessDocumentForm communicationsManagementProcess = new CommunicationsManagementProcessDocumentForm();
            communicationsManagementProcess.Show();
            communicationsManagementProcess.MdiParent = this;
        }

        private void projectStatusReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProjectStatusReportDocumentForm projectStatusReport = new ProjectStatusReportDocumentForm();
            projectStatusReport.Show();
            projectStatusReport.MdiParent = this;
        }

        private void communicationsRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommunicationsRegister communicationsRegister = new CommunicationsRegister();
            communicationsRegister.Show();
            communicationsRegister.MdiParent = this;
        }

        private void executionPhaseReviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PhaseReviewFormExecutionDocumentForm phaseReviewFormExecutionDocumentForm = new PhaseReviewFormExecutionDocumentForm();
            phaseReviewFormExecutionDocumentForm.Show();
            phaseReviewFormExecutionDocumentForm.MdiParent = this;
        }

        private void performProjectClosureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProjectClosureReportDocumentForm projectClosureReportDocumentForm = new ProjectClosureReportDocumentForm();
            projectClosureReportDocumentForm.Show();
            projectClosureReportDocumentForm.MdiParent = this;
        }

        private void reviewProjectCompletionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PostImplementationReviewDocumentForm postImplementationReviewDocumentForm= new PostImplementationReviewDocumentForm();
            postImplementationReviewDocumentForm.Show();
            postImplementationReviewDocumentForm.MdiParent = this;
        }

        private void projectDashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProjectDashboard form = new ProjectDashboard();
            form.Show();
            form.MdiParent = this;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void wordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string tempString = System.Windows.Forms.Application.StartupPath;
            tempString = tempString.Remove(tempString.LastIndexOf('\\'));
            tempString = tempString.Remove(tempString.LastIndexOf('\\'));
            System.Diagnostics.Process.Start($@"{tempString}\MPMM\Template Excel Sheets\User_Manual Project Management Toolkit.docx");
        }

        private void pDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string tempString = System.Windows.Forms.Application.StartupPath;
            tempString = tempString.Remove(tempString.LastIndexOf('\\'));
            tempString = tempString.Remove(tempString.LastIndexOf('\\'));
            System.Diagnostics.Process.Start($@"{tempString}\MPMM\Template Excel Sheets\User_Manual Project Management Toolkit.pdf");
        }

        private void projectManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProjectManagement projectManagement = new frmProjectManagement("tbp_Report_Center");
            projectManagement.Show();
            projectManagement.MdiParent = this;
        }
    }
}
