using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectManagementToolkit.MPMM.MPMM_Document_Models;
using ProjectManagementToolkit.Utility;
using ProjectManagementToolkit.Properties;
using Newtonsoft.Json;
using MoreLinq;

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Forms
{
    public partial class ProjectStatusReportDocumentForm : Form
    {
        VersionControl<ProjectStatusReportModel> versionControl;
        ProjectStatusReportModel newProjectStatusReportModel;
        ProjectStatusReportModel currentProjectStatusReportModel;

        public ProjectStatusReportDocumentForm()
        {
            InitializeComponent();
        }

        private void ProjectStatusReportDocumentForm_Load(object sender, EventArgs e)
        {
            loadDocument();
        }

        private void loadDocument()
        {
            dgvProjectSchedule.Columns.Add("colDeliverable", "Deliverable");
            dgvProjectSchedule.Columns.Add("colScheduledCompletionDate", "Scheduled Completion Date");
            dgvProjectSchedule.Columns.Add("colActualCompletionDate", "Actual Completion Date");
            dgvProjectSchedule.Columns.Add("colActualVariance", "Actual Variance");
            dgvProjectSchedule.Columns.Add("colForecastCompletionDate", "Forecast Completion Date");
            dgvProjectSchedule.Columns.Add("colForecastVariance", "Forecast Variance");
            dgvProjectSchedule.Columns.Add("colSummary", "Summary");

            dgvProjectExpense.Columns.Add("colExpenseType", "Expense Type");
            dgvProjectExpense.Columns.Add("colBudgetedExpenditure", "Budgeted Expenditure");
            dgvProjectExpense.Columns.Add("colActualExpenditure", "Actual Expenditure");
            dgvProjectExpense.Columns.Add("colPEActualVariance", "Actual Variance");
            dgvProjectExpense.Columns.Add("colForecastExpenditure", "Forecast Expenditure");
            dgvProjectExpense.Columns.Add("colPEForecastVariance", "Forecast Variance");
            dgvProjectExpense.Columns.Add("colPESummary", "Summary");

            dgvProjectEffort.Columns.Add("colActivities", "Activities");
            dgvProjectEffort.Columns.Add("colBudgetedEffort", "BudgetedEffort");
            dgvProjectEffort.Columns.Add("colActualEffort", "ActualEffort");
            dgvProjectEffort.Columns.Add("colPEFActualVariance", "Actual Variance");
            dgvProjectEffort.Columns.Add("colForecastEffort", "ForecastEffort");
            dgvProjectEffort.Columns.Add("colPEFForecastVariance", "Forecast Variance");
            dgvProjectEffort.Columns.Add("colPEFSummary", "Summary");

            dgvProjectQuality.Columns.Add("colDeliverables", "Deliverables");
            dgvProjectQuality.Columns.Add("colQualityTarget", "Quality Target");
            dgvProjectQuality.Columns.Add("colQualityAchieved", "Quality Achieved");
            dgvProjectQuality.Columns.Add("colQualityVariance", "Quality Variance");
            dgvProjectQuality.Columns.Add("colSummary", "Summary");

            dgvProjectRisk.Columns.Add("colRisks", "Risks");
            dgvProjectRisk.Columns.Add("colLikelihood", "Likelihood");
            dgvProjectRisk.Columns.Add("colImpact", "Impact");
            dgvProjectRisk.Columns.Add("colSummary", "Summary");

            dgvProjectIssues.Columns.Add("colIssues", "Issues");
            dgvProjectIssues.Columns.Add("colImpact", "Impact");
            dgvProjectIssues.Columns.Add("colSummary", "Summary");






            string json = JsonHelper.loadDocument(Settings.Default.ProjectID, "ProjectStatusReport");
            List<string[]> documentInfo = new List<string[]>();
            newProjectStatusReportModel = new ProjectStatusReportModel();
            currentProjectStatusReportModel = new ProjectStatusReportModel();
            if (json != "")
            {
                versionControl = JsonConvert.DeserializeObject<VersionControl<ProjectStatusReportModel>>(json);
                newProjectStatusReportModel = JsonConvert.DeserializeObject<ProjectStatusReportModel>(versionControl.getLatest(versionControl.DocumentModels));
                currentProjectStatusReportModel = JsonConvert.DeserializeObject<ProjectStatusReportModel>(versionControl.getLatest(versionControl.DocumentModels));

                txtProjectName2.Text = currentProjectStatusReportModel.ProjectName;
                txtProjectID.Text = currentProjectStatusReportModel.ProjectID;
                txtProjectManager.Text = currentProjectStatusReportModel.ProjectManager;
                txtProjectSponsor.Text = currentProjectStatusReportModel.ProjectSponsor;
                txtReportPreparedBy.Text = currentProjectStatusReportModel.ReportPreparedBy;
                txtReportPreperationDate.Text = currentProjectStatusReportModel.ReportPreparedBy;
                //txtReportingPeriod.Text = currentProjectStatusReportModel.ReportingPeriod;
                txtProjectRecipients.Text = currentProjectStatusReportModel.Recipients;

                txtProjectDescription.Text = currentProjectStatusReportModel.ProjectDescription;
                txtOverallStatus.Text = currentProjectStatusReportModel.OverallStatus;
                //txtProjectSchedule.Text = currentProjectStatusReportModel.ProjectSchedule;
                txtProjectExpenses.Text = currentProjectStatusReportModel.ProjectDeliverables;
                txtProjectRisks.Text = currentProjectStatusReportModel.ProjectRisks;
                //txtProjectIssues.Text = currentProjectStatusReportModel.ProjectIssues;
                txtProjectChanges.Text = currentProjectStatusReportModel.ProjectChanges;

                foreach (var row in currentProjectStatusReportModel.ProSchedule)
                {
                    dgvProjectSchedule.Rows.Add(new string[] { row.Deliverable, row.ScheduledCompletionDate, row.ActualCompletionDate, row.ActualVariance, row.ForecastCompletionDate, row.ForecastVariance, row.Summary });
                }

                foreach (var row in currentProjectStatusReportModel.ProjExpenses)
                {
                    dgvProjectExpense.Rows.Add(new string[] { row.ExpenseType, row.BudgetedExpenditure, row.ActualExpenditure, row.ActualVariance, row.ForecastExpenditure, row.ForecastVariance, row.Summary });
                }

                foreach (var row in currentProjectStatusReportModel.ProjEffort)
                {
                    dgvProjectEffort.Rows.Add(new string[] { row.Activities, row.BudgetedEffort, row.ActualEffort, row.ActualVariance, row.ForecastEffort, row.ForecastVariance, row.Summary });
                }

                foreach (var row in currentProjectStatusReportModel.ProjQuality)
                {
                    dgvProjectQuality.Rows.Add(new string[] { row.Deliverables, row.QualityTarget, row.QualityAchieved, row.QualityVariance, row.Summary});
                }

                foreach (var row in currentProjectStatusReportModel.ProjRisk)
                {
                    dgvProjectRisk.Rows.Add(new string[] { row.Risks, row.Likelihood, row.Impact, row.Summary });
                }

                foreach (var row in currentProjectStatusReportModel.ProjIssues)
                {
                    dgvProjectIssues.Rows.Add(new string[] { row.Issues, row.Impact, row.Summary });
                }


            }
            else
            {
      
            }
        }

        public void saveDocument()
        {
            List<ProjectStatusReportModel.ProjectSchedule> ProjSchedules = new List<ProjectStatusReportModel.ProjectSchedule>();

            int versionRowsCount = dgvProjectSchedule.Rows.Count;

            for (int i = 0; i < versionRowsCount - 1; i++)
            {
                ProjectStatusReportModel.ProjectSchedule ProjectScheduleMod = new ProjectStatusReportModel.ProjectSchedule();
                var Deliverable = dgvProjectSchedule.Rows[i].Cells[0].Value?.ToString() ?? "";
                var ScheduledCompletionDate = dgvProjectSchedule.Rows[i].Cells[1].Value?.ToString() ?? "";
                var ActualCompletionDate = dgvProjectSchedule.Rows[i].Cells[2].Value?.ToString() ?? "";
                var ActualVariance = dgvProjectSchedule.Rows[i].Cells[3].Value?.ToString() ?? "";
                var ForecastCompletionDate = dgvProjectSchedule.Rows[i].Cells[4].Value?.ToString() ?? "";
                var ForecastVariance = dgvProjectSchedule.Rows[i].Cells[5].Value?.ToString() ?? "";
                var Summary = dgvProjectSchedule.Rows[i].Cells[6].Value?.ToString() ?? "";

                ProjectScheduleMod.Deliverable = Deliverable;
                ProjectScheduleMod.ScheduledCompletionDate = ScheduledCompletionDate;
                ProjectScheduleMod.ActualCompletionDate = ActualCompletionDate;
                ProjectScheduleMod.ActualVariance = ActualVariance;
                ProjectScheduleMod.ForecastCompletionDate = ForecastCompletionDate;
                ProjectScheduleMod.ForecastVariance = ForecastVariance;
                ProjectScheduleMod.Summary = Summary;

                ProjSchedules.Add(ProjectScheduleMod);
            }
            newProjectStatusReportModel.ProSchedule = ProjSchedules;


            List<ProjectStatusReportModel.ProjectExpenses> ProjExp = new List<ProjectStatusReportModel.ProjectExpenses>();

            int expensesRowsCount = dgvProjectExpense.Rows.Count;

            for (int i = 0; i < expensesRowsCount - 1; i++)
            {
                ProjectStatusReportModel.ProjectExpenses ProjectExps = new ProjectStatusReportModel.ProjectExpenses();
                var ExpenseType = dgvProjectExpense.Rows[i].Cells[0].Value?.ToString() ?? "";
                var BudgetedExpenditure = dgvProjectExpense.Rows[i].Cells[1].Value?.ToString() ?? "";
                var ActualExpenditure = dgvProjectExpense.Rows[i].Cells[2].Value?.ToString() ?? "";
                var ActualVariance = dgvProjectExpense.Rows[i].Cells[3].Value?.ToString() ?? "";
                var ForecastExpenditure = dgvProjectExpense.Rows[i].Cells[4].Value?.ToString() ?? "";
                var ForecastVariance = dgvProjectExpense.Rows[i].Cells[5].Value?.ToString() ?? "";
                var Summary = dgvProjectExpense.Rows[i].Cells[6].Value?.ToString() ?? "";

                ProjectExps.ExpenseType = ExpenseType;
                ProjectExps.BudgetedExpenditure = BudgetedExpenditure;
                ProjectExps.ActualExpenditure = ActualExpenditure;
                ProjectExps.ActualVariance = ActualVariance;
                ProjectExps.ForecastExpenditure = ForecastExpenditure;
                ProjectExps.ForecastVariance = ForecastVariance;
                ProjectExps.Summary = Summary;

                ProjExp.Add(ProjectExps);
            }
            newProjectStatusReportModel.ProjExpenses = ProjExp;

            List<ProjectStatusReportModel.ProjectEffort> ProjEffort = new List<ProjectStatusReportModel.ProjectEffort>();

            int effortRowsCount = dgvProjectEffort.Rows.Count;

            for (int i = 0; i < expensesRowsCount - 1; i++)
            {
                ProjectStatusReportModel.ProjectEffort ProjectEff = new ProjectStatusReportModel.ProjectEffort();
                var Activities = dgvProjectEffort.Rows[i].Cells[0].Value?.ToString() ?? "";
                var BudgetedEffort = dgvProjectEffort.Rows[i].Cells[1].Value?.ToString() ?? "";
                var ActualEffort = dgvProjectEffort.Rows[i].Cells[2].Value?.ToString() ?? "";
                var ActualVariance = dgvProjectEffort.Rows[i].Cells[3].Value?.ToString() ?? "";
                var ForecastEffort = dgvProjectEffort.Rows[i].Cells[4].Value?.ToString() ?? "";
                var ForecastVariance = dgvProjectEffort.Rows[i].Cells[5].Value?.ToString() ?? "";
                var Summary = dgvProjectEffort.Rows[i].Cells[6].Value?.ToString() ?? "";

                ProjectEff.Activities = Activities;
                ProjectEff.BudgetedEffort = BudgetedEffort;
                ProjectEff.ActualEffort = ActualEffort;
                ProjectEff.ActualVariance = ActualVariance;
                ProjectEff.ForecastEffort = ForecastEffort;
                ProjectEff.ForecastVariance = ForecastVariance;
                ProjectEff.Summary = Summary;

                ProjEffort.Add(ProjectEff);
            }
            newProjectStatusReportModel.ProjEffort = ProjEffort;

            List<ProjectStatusReportModel.ProjectQuality> ProjQuality = new List<ProjectStatusReportModel.ProjectQuality>();

            int quaRowsCount = dgvProjectQuality.Rows.Count;

            for (int i = 0; i < expensesRowsCount - 1; i++)
            {
                ProjectStatusReportModel.ProjectQuality ProjectQua = new ProjectStatusReportModel.ProjectQuality();
                var Deliverables = dgvProjectQuality.Rows[i].Cells[0].Value?.ToString() ?? "";
                var QualityTarget = dgvProjectQuality.Rows[i].Cells[1].Value?.ToString() ?? "";
                var QualityAchieved = dgvProjectQuality.Rows[i].Cells[2].Value?.ToString() ?? "";
                var QualityVariance = dgvProjectQuality.Rows[i].Cells[3].Value?.ToString() ?? "";
                var Summary = dgvProjectQuality.Rows[i].Cells[4].Value?.ToString() ?? "";

                ProjectQua.Deliverables = Deliverables;
                ProjectQua.QualityTarget = QualityTarget;
                ProjectQua.QualityAchieved = QualityAchieved;
                ProjectQua.QualityVariance = QualityVariance;
                ProjectQua.Summary = Summary;

                ProjQuality.Add(ProjectQua);
            }
            newProjectStatusReportModel.ProjQuality = ProjQuality;

            List<ProjectStatusReportModel.ProjectRisk> ProjRisk = new List<ProjectStatusReportModel.ProjectRisk>();

            int risRowsCount = dgvProjectRisk.Rows.Count;

            for (int i = 0; i < expensesRowsCount - 1; i++)
            {
                ProjectStatusReportModel.ProjectRisk ProjectRis = new ProjectStatusReportModel.ProjectRisk();
                var Risks = dgvProjectRisk.Rows[i].Cells[0].Value?.ToString() ?? "";
                var Likelihood = dgvProjectRisk.Rows[i].Cells[1].Value?.ToString() ?? "";
                var Impact = dgvProjectRisk.Rows[i].Cells[2].Value?.ToString() ?? "";
                var Summary = dgvProjectRisk.Rows[i].Cells[3].Value?.ToString() ?? "";

                ProjectRis.Risks = Risks;
                ProjectRis.Likelihood = Likelihood;
                ProjectRis.Impact = Impact;
                ProjectRis.Summary = Summary;

                ProjRisk.Add(ProjectRis);
            }
            newProjectStatusReportModel.ProjRisk = ProjRisk;

            List<ProjectStatusReportModel.ProjectIssues> ProjIssues = new List<ProjectStatusReportModel.ProjectIssues>();

            int issRowsCount = dgvProjectIssues.Rows.Count;

            for (int i = 0; i < expensesRowsCount - 1; i++)
            {
                ProjectStatusReportModel.ProjectIssues ProjectISS = new ProjectStatusReportModel.ProjectIssues();
                var Issues = dgvProjectIssues.Rows[i].Cells[0].Value?.ToString() ?? "";
                var Impact = dgvProjectIssues.Rows[i].Cells[1].Value?.ToString() ?? "";
                var Summary = dgvProjectIssues.Rows[i].Cells[2].Value?.ToString() ?? "";

                ProjectISS.Issues = Issues;
                ProjectISS.Impact = Impact;
                ProjectISS.Summary = Summary;

                ProjIssues.Add(ProjectISS);
            }
            newProjectStatusReportModel.ProjIssues = ProjIssues;

            newProjectStatusReportModel.ProjectName = txtProjectName2.Text;
            newProjectStatusReportModel.ProjectID = txtProjectID.Text;
            newProjectStatusReportModel.ProjectManager = txtProjectManager.Text;
            newProjectStatusReportModel.ProjectSponsor = txtProjectSponsor.Text;
            newProjectStatusReportModel.ReportPreparedBy = txtReportPreparedBy.Text;
            newProjectStatusReportModel.ReportPreparedBy = txtReportPreperationDate.Text;
            newProjectStatusReportModel.Recipients = txtProjectRecipients.Text;

            newProjectStatusReportModel.ProjectDescription = txtProjectDescription.Text;
            newProjectStatusReportModel.OverallStatus = txtOverallStatus.Text;
            newProjectStatusReportModel.ProjectDeliverables = txtProjectExpenses.Text;
            newProjectStatusReportModel.ProjectRisks = txtProjectRisks.Text;
            newProjectStatusReportModel.ProjectChanges = txtProjectChanges.Text;

            List<VersionControl<ProjectStatusReportModel>.DocumentModel> documentModels = versionControl.DocumentModels;


            if (!versionControl.isEqual(currentProjectStatusReportModel, newProjectStatusReportModel))
            {
                VersionControl<ProjectStatusReportModel>.DocumentModel documentModel = new VersionControl<ProjectStatusReportModel>.DocumentModel(newProjectStatusReportModel, DateTime.Now, VersionControl<ProjectModel>.generateID());

                documentModels.Add(documentModel);

                versionControl.DocumentModels = documentModels;

                string json = JsonConvert.SerializeObject(versionControl);
                JsonHelper.saveDocument(json, Settings.Default.ProjectID, "ProjectStatusReport");
                MessageBox.Show("Project status report saved successfully", "save", MessageBoxButtons.OK);
            }
        }

        private void txtProjectDescription_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveDocument();
        }
    }
}
