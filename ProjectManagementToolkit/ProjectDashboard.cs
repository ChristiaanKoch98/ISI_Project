using Newtonsoft.Json;
using ProjectManagementToolkit.Properties;
using ProjectManagementToolkit.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectManagementToolkit
{
    public partial class ProjectDashboard : Form
    {
        ProjectModel projectModel = new ProjectModel();
        public ProjectDashboard()
        {
            InitializeComponent();
        }

        private void ProjectDashboard_Load(object sender, EventArgs e)
        {
            string json = JsonHelper.loadProjectInfo(Settings.Default.Username);
            List<ProjectModel> projectListModel = JsonConvert.DeserializeObject<List<ProjectModel>>(json);
            projectModel = projectModel.getProjectModel(Settings.Default.ProjectID, projectListModel);

            List<string> localDocuments = getLocalDocuments();
            
            lblProjectName.Text = projectModel.ProjectName;

            List<string> initiationDocuments = new List<string>();
            initiationDocuments.Add("BusinessCase");
            initiationDocuments.Add("FeasibilityStudy");
            initiationDocuments.Add("ProjectCharter");
            initiationDocuments.Add("JobDescription");
            initiationDocuments.Add("ProjectOfficeCheckList");
            initiationDocuments.Add("PhaseReviewFormInitiation");
            initiationDocuments.Add("TermOfReferenceDocument");

            lblInitiationProgress.Text = "Progress: ";
            pbarInitiation.Value = 0;
            pbarInitiation.Maximum = initiationDocuments.Count;
            double initationProgressVal = 0;
            for (int i = 0; i < initiationDocuments.Count; i++)
            {
                dgvInitiation.Rows.Add();
                dgvInitiation.Rows[i].Cells[0].Value = initiationDocuments[i];
                if (localDocuments.Contains(initiationDocuments[i]))
                {
                    initationProgressVal++;
                    dgvInitiation.Rows[i].Cells[1].Value = true;
                    pbarInitiation.Value = (int)initationProgressVal;
                    double initationPercentage = ((initationProgressVal) / initiationDocuments.Count) * 100;
                    lblInitiationProgress.Text = "Progress: " + Math.Round(initationPercentage,2) + "%";
                }
                else
                {
                    dgvInitiation.Rows[i].Cells[1].Value = false;
                }
            }

            List<string> planningDocuments = new List<string>();
            planningDocuments.Add("ProjectPlan");
            planningDocuments.Add("ResourcePlan");
            planningDocuments.Add("FinancialPlan");
            planningDocuments.Add("QualityPlan");
            planningDocuments.Add("RiskPlan");
            planningDocuments.Add("AcceptancePlan");
            planningDocuments.Add("CommunicationPlan");
            planningDocuments.Add("ProcurementPlan");
            planningDocuments.Add("SelectionProcess");
            planningDocuments.Add("StatementOfWork");
            planningDocuments.Add("RequestForInformation");
            planningDocuments.Add("SupplierContract");
            planningDocuments.Add("RequestForProposal");
            planningDocuments.Add("PhaseReviewPlanning");

            lblPlanningProgress.Text = "Progress: ";
            pbarPlanning.Value = 0;
            pbarPlanning.Maximum = planningDocuments.Count;
            double planningProgressVal = 0;
            for (int i = 0; i < planningDocuments.Count; i++)
            {
                dgvPlanning.Rows.Add();
                dgvPlanning.Rows[i].Cells[0].Value = planningDocuments[i];
                if (localDocuments.Contains(planningDocuments[i]))
                {
                    planningProgressVal++;
                    dgvPlanning.Rows[i].Cells[1].Value = true;
                    pbarPlanning.Value = (int)planningProgressVal;
                    double planningPercentage = ((planningProgressVal) / planningDocuments.Count) * 100;
                    lblPlanningProgress.Text = "Progress: " + Math.Round(planningPercentage, 2) + "%";
                }
                else
                {
                    dgvPlanning.Rows[i].Cells[1].Value = false;
                }
            }

            List<string> executionDocuments = new List<string>();
            executionDocuments.Add("BuildDeliverables");
            executionDocuments.Add("MonitorAndControl");
            executionDocuments.Add("TimeMangement");
            executionDocuments.Add("TimeSheet");
            executionDocuments.Add("TimeSheetRegister");
            executionDocuments.Add("CostManagementProcess");
            executionDocuments.Add("ExpenseForm");
            executionDocuments.Add("QualityManagement");
            executionDocuments.Add("QualityReviewPlan");
            executionDocuments.Add("ChangeManagementProcess");
            executionDocuments.Add("ChangeRequestForm");
            executionDocuments.Add("RiskManagamentProcess");
            executionDocuments.Add("RiskForm");
            executionDocuments.Add("IssueManagementProcess");
            executionDocuments.Add("IssueForm");
            executionDocuments.Add("PurchaseOrder");
            executionDocuments.Add("AcceptanceManagementProcess");
            executionDocuments.Add("AcceptanceForm");
            executionDocuments.Add("CommunicationsManagementProcess");
            executionDocuments.Add("ProjectStatusReport");
            executionDocuments.Add("PhaseReviewExe");

            lblExecutionProgress.Text = "Progress: ";
            pbarExecution.Value = 0;
            pbarExecution.Maximum = executionDocuments.Count;
            double executionProgressVal = 0;
            for (int i = 0; i < executionDocuments.Count; i++)
            {
                dgvExecution.Rows.Add();
                dgvExecution.Rows[i].Cells[0].Value = executionDocuments[i];
                if (localDocuments.Contains(executionDocuments[i]))
                {
                    executionProgressVal++;
                    dgvExecution.Rows[i].Cells[1].Value = true;
                    pbarExecution.Value = (int)executionProgressVal;
                    double executionPercentage = ((executionProgressVal) / executionDocuments.Count) * 100;
                    lblExecutionProgress.Text = "Progress: " + Math.Round(executionPercentage, 2) + "%";
                }
                else
                {
                    dgvExecution.Rows[i].Cells[1].Value = false;
                }
            }

            List<string> closingDocuments = new List<string>();
            closingDocuments.Add("ProjectClosureReport");
            closingDocuments.Add("PostImplementationReview");

            lblClosingProgress.Text = "Progress: ";
            pbarClosing.Value = 0;
            pbarClosing.Maximum = closingDocuments.Count;
            double closingProgressVal = 0;
            for (int i = 0; i < closingDocuments.Count; i++)
            {
                dgvClosing.Rows.Add();
                dgvClosing.Rows[i].Cells[0].Value = closingDocuments[i];
                if (localDocuments.Contains(closingDocuments[i]))
                {
                    closingProgressVal++;
                    dgvClosing.Rows[i].Cells[1].Value = true;
                    pbarClosing.Value = (int)closingProgressVal;
                    double closingPercentage = ((closingProgressVal) / closingDocuments.Count) * 100;
                    lblClosingProgress.Text = "Progress: " + Math.Round(closingPercentage, 2) + "%";
                }
                else
                {
                    dgvClosing.Rows[i].Cells[1].Value = false;
                }
            }

            double overallProgressVal = (initationProgressVal + planningProgressVal + executionProgressVal + closingProgressVal);
            pbarOverall.Value = (int)overallProgressVal;
            pbarOverall.Maximum = initiationDocuments.Count + planningDocuments.Count + executionDocuments.Count + closingDocuments.Count;
            double overallPercentage = ((closingProgressVal) / pbarOverall.Maximum) * 100;
            lblOverallProgress.Text = "Overall Progress: " + Math.Round(overallPercentage, 2) + "%";
        }

        private List<string> getLocalDocuments()
        {
            List<string> localDocuments = new List<string>();
            string projectPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ProjectManagementToolkit", Settings.Default.ProjectID);

            if (Directory.Exists(projectPath))
            {
                foreach (string documentPath in Directory.GetFiles(projectPath))
                {
                    string documentName = Path.GetFileNameWithoutExtension(documentPath);
                    localDocuments.Add(documentName);
                }
            }
            else
            {
                return null;
            }

            return localDocuments;
        }
    }
}
