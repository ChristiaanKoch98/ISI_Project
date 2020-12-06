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
using Xceed.Words.NET;
using Xceed.Document.NET;

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Forms
{
    public partial class ProjectStatusReportDocumentForm : Form
    {
        VersionControl<ProjectStatusReportModel> versionControl;
        ProjectStatusReportModel newProjectStatusReportModel;
        ProjectStatusReportModel currentProjectStatusReportModel;
        Color TABLE_HEADER_COLOR = Color.FromArgb(73, 173, 252);
        ProjectModel projectModel = new ProjectModel();

        public ProjectStatusReportDocumentForm()
        {
            InitializeComponent();
        }

        private void ProjectStatusReportDocumentForm_Load(object sender, EventArgs e)
        {
            
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

            string jsonWord = JsonHelper.loadProjectInfo(Settings.Default.Username);
            List<ProjectModel> projectListModel = JsonConvert.DeserializeObject<List<ProjectModel>>(jsonWord);
            projectModel = projectModel.getProjectModel(Settings.Default.ProjectID, projectListModel);

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
                txtReportPreperationDate.Text = currentProjectStatusReportModel.PrepDate;
                txtProjectRecipients.Text = currentProjectStatusReportModel.Recipients;

                txtReportingPeriod.Text = currentProjectStatusReportModel.RepPeriod;
                txtProjectSchedule.Text = currentProjectStatusReportModel.proSchedule;
                txtProjectDeliverables.Text = currentProjectStatusReportModel.ProjectDeliverables;
                txtProjectIssues.Text = currentProjectStatusReportModel.textProjectIssues;

                txtProjectDescription.Text = currentProjectStatusReportModel.ProjectDescription;
                txtOverallStatus.Text = currentProjectStatusReportModel.OverallStatus;
                txtProjectExpenses.Text = currentProjectStatusReportModel.ProEx;
                txtProjectRisks.Text = currentProjectStatusReportModel.ProjectRisks;
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

                foreach (var row in currentProjectStatusReportModel.NProjIssues)
                {
                    dgvProjectIssues.Rows.Add(new string[] { row.Issues, row.Impact, row.Summary });
                }


            }
            else
            {
                versionControl = new VersionControl<ProjectStatusReportModel>();
                versionControl.DocumentModels = new List<VersionControl<ProjectStatusReportModel>.DocumentModel>();
                documentInfo.Add(new string[] { "Document ID", "" });
                documentInfo.Add(new string[] { "Document Owner", "" });
                documentInfo.Add(new string[] { "Issue Date", "" });
                documentInfo.Add(new string[] { "Last Save Date", "" });
                documentInfo.Add(new string[] { "File Name", "" });
                newProjectStatusReportModel = new ProjectStatusReportModel();
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

            for (int i = 0; i < effortRowsCount - 1; i++)
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

            for (int i = 0; i < quaRowsCount - 1; i++)
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

            for (int i = 0; i < risRowsCount - 1; i++)
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

            List<ProjectStatusReportModel.ProjectIssues> ProjIss = new List<ProjectStatusReportModel.ProjectIssues>();

            int issRowsCount = dgvProjectIssues.Rows.Count;

            for (int i = 0; i < issRowsCount - 1; i++)
            {
                ProjectStatusReportModel.ProjectIssues ProjectISS = new ProjectStatusReportModel.ProjectIssues();
                var Iss = dgvProjectIssues.Rows[i].Cells[0].Value?.ToString() ?? "";
                var Imp = dgvProjectIssues.Rows[i].Cells[1].Value?.ToString() ?? "";
                var Sum = dgvProjectIssues.Rows[i].Cells[2].Value?.ToString() ?? "";

                ProjectISS.Issues = Iss;
                ProjectISS.Impact = Imp;
                ProjectISS.Summary = Sum;

                ProjIss.Add(ProjectISS);
            }
            newProjectStatusReportModel.NProjIssues = ProjIss;

            newProjectStatusReportModel.ProjectName = txtProjectName2.Text;
            newProjectStatusReportModel.ProjectID = txtProjectID.Text;
            newProjectStatusReportModel.ProjectManager = txtProjectManager.Text;
            newProjectStatusReportModel.ProjectSponsor = txtProjectSponsor.Text;
            newProjectStatusReportModel.ReportPreparedBy = txtReportPreparedBy.Text;
            newProjectStatusReportModel.PrepDate = txtReportPreperationDate.Text;
            newProjectStatusReportModel.PreperationPeriod = txtReportingPeriod.Text;
            newProjectStatusReportModel.ESProjectSchedule = txtProjectSchedule.Text;
            newProjectStatusReportModel.Recipients = txtProjectRecipients.Text;
            newProjectStatusReportModel.RepPeriod = txtReportingPeriod.Text;
            newProjectStatusReportModel.proSchedule = txtProjectSchedule.Text;
            newProjectStatusReportModel.ProjectDeliverables = txtProjectDeliverables.Text;
            newProjectStatusReportModel.textProjectIssues = txtProjectIssues.Text;
            newProjectStatusReportModel.ProEx = txtProjectExpenses.Text;

            newProjectStatusReportModel.ProjectDescription = txtProjectDescription.Text;
            newProjectStatusReportModel.OverallStatus = txtOverallStatus.Text;
            newProjectStatusReportModel.ProjectRisks = txtProjectRisks.Text;
            newProjectStatusReportModel.ProjectChanges = txtProjectChanges.Text;

            List<VersionControl<ProjectStatusReportModel>.DocumentModel> documentModels = versionControl.DocumentModels;


            if (!versionControl.isEqual(currentProjectStatusReportModel, newProjectStatusReportModel))
            {
                VersionControl<ProjectStatusReportModel>.DocumentModel documentModel = new VersionControl<ProjectStatusReportModel>.DocumentModel(newProjectStatusReportModel, DateTime.Now, VersionControl<ProjectModel>.generateID());

                documentModels.Add(documentModel);

                versionControl.DocumentModels = documentModels;

                string json = JsonConvert.SerializeObject(versionControl);
                currentProjectStatusReportModel = JsonConvert.DeserializeObject<ProjectStatusReportModel>(JsonConvert.SerializeObject(newProjectStatusReportModel));
                JsonHelper.saveDocument(json, Settings.Default.ProjectID, "ProjectStatusReport");
                MessageBox.Show("Project status report saved successfully", "save", MessageBoxButtons.OK);
            }
        }

        private void exportToWord()
        {
            string path;
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                saveFileDialog.Filter = "Word 97-2003 Documents (*.doc)|*.doc|Word 2007 Documents (*.docx)|*.docx";
                saveFileDialog.FilterIndex = 2;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    path = saveFileDialog.FileName;
                    using (var document = DocX.Create(path))
                    {
                        document.InsertParagraph("Project status report \nFor " + projectModel.ProjectName)
                           .Font("Arial")
                           .Bold(true)
                           .FontSize(22d).Alignment = Alignment.left;
                        document.InsertSectionPageBreak();

                        var p = document.InsertParagraph();
                        var title = p.InsertParagraphBeforeSelf("Table of Contents").Bold().FontSize(20);

                        var tocSwitches = new Dictionary<TableOfContentsSwitches, string>()
                        {
                            { TableOfContentsSwitches.O, "1-3"},
                            { TableOfContentsSwitches.U, ""},
                            { TableOfContentsSwitches.Z, ""},
                            { TableOfContentsSwitches.H, ""}
                        };

                        document.InsertTableOfContents(p, "", tocSwitches);

                        document.InsertParagraph().InsertPageBreakAfterSelf();
                        var CommunicationReqHeading = document.InsertParagraph("1 Project details")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        CommunicationReqHeading.StyleId = "Heading1";

                        var ComPlanHeading = document.InsertParagraph("1.1 Project name")
                     .Bold()
                     .FontSize(12d)
                     .Color(Color.Black)
                     .Bold(true)
                     .Font("Arial");

                     document.InsertParagraph(currentProjectStatusReportModel.ProjectName)
                          .FontSize(11d)
                          .Color(Color.Black)
                          .Font("Arial").Alignment = Alignment.left;


                        ComPlanHeading.StyleId = "Heading2";

                        var projIDHeading = document.InsertParagraph("1.2 Project ID")
                         .Bold()
                         .FontSize(12d)
                         .Color(Color.Black)
                         .Bold(true)
                         .Font("Arial");

                        document.InsertParagraph(currentProjectStatusReportModel.ProjectID)
                             .FontSize(11d)
                             .Color(Color.Black)
                             .Font("Arial").Alignment = Alignment.left;


                        projIDHeading.StyleId = "Heading2";

                        var promanagerHeading = document.InsertParagraph("1.3 Project manager")
                         .Bold()
                         .FontSize(12d)
                         .Color(Color.Black)
                         .Bold(true)
                         .Font("Arial");

                        document.InsertParagraph(currentProjectStatusReportModel.ProjectManager)
                             .FontSize(11d)
                             .Color(Color.Black)
                             .Font("Arial").Alignment = Alignment.left;


                        promanagerHeading.StyleId = "Heading2";

                        var sponsorHeading = document.InsertParagraph("1.4 Project sponsor")
                         .Bold()
                         .FontSize(12d)
                         .Color(Color.Black)
                         .Bold(true)
                         .Font("Arial");

                        document.InsertParagraph(currentProjectStatusReportModel.ProjectSponsor)
                             .FontSize(11d)
                             .Color(Color.Black)
                             .Font("Arial").Alignment = Alignment.left;


                        sponsorHeading.StyleId = "Heading2";

                        var reportHeading = document.InsertParagraph("1.5 Report prepared by")
                        .Bold()
                        .FontSize(12d)
                        .Color(Color.Black)
                        .Bold(true)
                        .Font("Arial");

                        document.InsertParagraph(currentProjectStatusReportModel.ReportPreparedBy)
                             .FontSize(11d)
                             .Color(Color.Black)
                             .Font("Arial").Alignment = Alignment.left;


                        sponsorHeading.StyleId = "Heading2";

                        var prepdateHeading = document.InsertParagraph("1.6 Report preperation date")
                        .Bold()
                        .FontSize(12d)
                        .Color(Color.Black)
                        .Bold(true)
                        .Font("Arial");

                        document.InsertParagraph(currentProjectStatusReportModel.PrepDate)
                             .FontSize(11d)
                             .Color(Color.Black)
                             .Font("Arial").Alignment = Alignment.left;


                        prepdateHeading.StyleId = "Heading2";

                        var rperHeading = document.InsertParagraph("1.7 Reporting Period")
                        .Bold()
                        .FontSize(12d)
                        .Color(Color.Black)
                        .Bold(true)
                        .Font("Arial");

                        document.InsertParagraph(currentProjectStatusReportModel.PreperationPeriod)
                             .FontSize(11d)
                             .Color(Color.Black)
                             .Font("Arial").Alignment = Alignment.left;


                        rperHeading.StyleId = "Heading2";

                        var recHeading = document.InsertParagraph("1.8 Reporting Recipients")
                        .Bold()
                        .FontSize(12d)
                        .Color(Color.Black)
                        .Bold(true)
                        .Font("Arial");

                        document.InsertParagraph(currentProjectStatusReportModel.Recipients)
                             .FontSize(11d)
                             .Color(Color.Black)
                             .Font("Arial").Alignment = Alignment.left;


                        recHeading.StyleId = "Heading2";

                        document.InsertParagraph().InsertPageBreakAfterSelf();
                        var ExecutiveSummaryHead = document.InsertParagraph("2 Executive summary")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        ExecutiveSummaryHead.StyleId = "Heading1";

                        
                        var desHeading = document.InsertParagraph("2.1 Project description")
                     .Bold()
                     .FontSize(12d)
                     .Color(Color.Black)
                     .Bold(true)
                     .Font("Arial");

                        document.InsertParagraph(currentProjectStatusReportModel.ProjectDescription)
                             .FontSize(11d)
                             .Color(Color.Black)
                             .Font("Arial").Alignment = Alignment.left;


                        desHeading.StyleId = "Heading2";

                        var oStatHeading = document.InsertParagraph("2.2 Overall status")
                         .Bold()
                         .FontSize(12d)
                         .Color(Color.Black)
                         .Bold(true)
                         .Font("Arial");

                        document.InsertParagraph(currentProjectStatusReportModel.OverallStatus)
                             .FontSize(11d)
                             .Color(Color.Black)
                             .Font("Arial").Alignment = Alignment.left;


                        oStatHeading.StyleId = "Heading2";

                        var scheHeading = document.InsertParagraph("2.3 Project schedule")
                         .Bold()
                         .FontSize(12d)
                         .Color(Color.Black)
                         .Bold(true)
                         .Font("Arial");

                        document.InsertParagraph(currentProjectStatusReportModel.proSchedule)
                             .FontSize(11d)
                             .Color(Color.Black)
                             .Font("Arial").Alignment = Alignment.left;


                        scheHeading.StyleId = "Heading2";

                        var expensesHeading = document.InsertParagraph("2.4 Project expenses")
                         .Bold()
                         .FontSize(12d)
                         .Color(Color.Black)
                         .Bold(true)
                         .Font("Arial");

                        document.InsertParagraph(currentProjectStatusReportModel.ProEx)
                             .FontSize(11d)
                             .Color(Color.Black)
                             .Font("Arial").Alignment = Alignment.left;


                        expensesHeading.StyleId = "Heading2"; 

                        var delivHeading = document.InsertParagraph("2.5 Project Deliverables")
                        .Bold()
                        .FontSize(12d)
                        .Color(Color.Black)
                        .Bold(true)
                        .Font("Arial");

                        document.InsertParagraph(currentProjectStatusReportModel.ProjectDeliverables)
                             .FontSize(11d)
                             .Color(Color.Black)
                             .Font("Arial").Alignment = Alignment.left;


                        delivHeading.StyleId = "Heading2";

                        var riskHeading = document.InsertParagraph("2.6 Project risks")
                        .Bold()
                        .FontSize(12d)
                        .Color(Color.Black)
                        .Bold(true)
                        .Font("Arial");

                        document.InsertParagraph(currentProjectStatusReportModel.ProjectRisks)
                             .FontSize(11d)
                             .Color(Color.Black)
                             .Font("Arial").Alignment = Alignment.left;


                        riskHeading.StyleId = "Heading2";

                        var issuesHeading = document.InsertParagraph("2.7 Reporting Issues")
                        .Bold()
                        .FontSize(12d)
                        .Color(Color.Black)
                        .Bold(true)
                        .Font("Arial");

                        document.InsertParagraph(currentProjectStatusReportModel.textProjectIssues)
                             .FontSize(11d)
                             .Color(Color.Black)
                             .Font("Arial").Alignment = Alignment.left;


                        issuesHeading.StyleId = "Heading2";

                        var changesHeading = document.InsertParagraph("2.8 Reporting Changes")
                        .Bold()
                        .FontSize(12d)
                        .Color(Color.Black)
                        .Bold(true)
                        .Font("Arial");

                        document.InsertParagraph(currentProjectStatusReportModel.ProjectChanges)
                             .FontSize(11d)
                             .Color(Color.Black)
                             .Font("Arial").Alignment = Alignment.left;


                        changesHeading.StyleId = "Heading2";

                        var statusHeading = document.InsertParagraph("3 Detailed status report")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        statusHeading.StyleId = "Heading1";

                        var scheSubHeading = document.InsertParagraph("3.1 Project Schedule")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        scheSubHeading.StyleId = "Heading2";

                        var scheDoc = document.AddTable(currentProjectStatusReportModel.ProSchedule.Count + 1, 7);
                        scheDoc.Rows[0].Cells[0].Paragraphs[0].Append("Deliverable")
                            .Bold(true)
                            .Color(Color.White);
                        scheDoc.Rows[0].Cells[1].Paragraphs[0].Append("ScheduledCompletionDate")
                            .Bold(true)
                            .Color(Color.White);
                        scheDoc.Rows[0].Cells[2].Paragraphs[0].Append("ActualCompletionDate")
                            .Bold(true)
                            .Color(Color.White);
                        scheDoc.Rows[0].Cells[3].Paragraphs[0].Append("ActualVariance")
                            .Bold(true)
                            .Color(Color.White);
                        scheDoc.Rows[0].Cells[4].Paragraphs[0].Append("ForecastCompletionDate")
                            .Bold(true)
                            .Color(Color.White);
                        scheDoc.Rows[0].Cells[5].Paragraphs[0].Append("ForecastVariance")
                            .Bold(true)
                            .Color(Color.White);
                        scheDoc.Rows[0].Cells[6].Paragraphs[0].Append("Summary")
                            .Bold(true)
                            .Color(Color.White);

                        scheDoc.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        scheDoc.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        scheDoc.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;
                        scheDoc.Rows[0].Cells[3].FillColor = TABLE_HEADER_COLOR;
                        scheDoc.Rows[0].Cells[4].FillColor = TABLE_HEADER_COLOR;
                        scheDoc.Rows[0].Cells[5].FillColor = TABLE_HEADER_COLOR;
                        scheDoc.Rows[0].Cells[6].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < currentProjectStatusReportModel.ProSchedule.Count + 1; i++)
                        {
                            scheDoc.Rows[i].Cells[0].Paragraphs[0].Append(currentProjectStatusReportModel.ProSchedule[i - 1].Deliverable);
                            scheDoc.Rows[i].Cells[1].Paragraphs[0].Append(currentProjectStatusReportModel.ProSchedule[i - 1].ScheduledCompletionDate);
                            scheDoc.Rows[i].Cells[2].Paragraphs[0].Append(currentProjectStatusReportModel.ProSchedule[i - 1].ActualCompletionDate);
                            scheDoc.Rows[i].Cells[3].Paragraphs[0].Append(currentProjectStatusReportModel.ProSchedule[i - 1].ActualVariance);
                            scheDoc.Rows[i].Cells[4].Paragraphs[0].Append(currentProjectStatusReportModel.ProSchedule[i - 1].ForecastCompletionDate);
                            scheDoc.Rows[i].Cells[5].Paragraphs[0].Append(currentProjectStatusReportModel.ProSchedule[i - 1].ForecastVariance);
                            scheDoc.Rows[i].Cells[6].Paragraphs[0].Append(currentProjectStatusReportModel.ProSchedule[i - 1].Summary);
                          
                        }
                        scheDoc.SetWidths(new float[] { 394, 762, 762, 762, 762, 762, 762 });
                        document.InsertTable(scheDoc);

                        var expsSubHeading = document.InsertParagraph("3.2 Project Expenses")
                           .Bold()
                           .FontSize(14d)
                           .Color(Color.Black)
                           .Bold(true)
                           .Font("Arial");

                        expsSubHeading.StyleId = "Heading2";

                        var expDoc = document.AddTable(currentProjectStatusReportModel.ProjExpenses.Count + 1, 7);
                        expDoc.Rows[0].Cells[0].Paragraphs[0].Append("ExpenseType")
                            .Bold(true)
                            .Color(Color.White);
                        expDoc.Rows[0].Cells[1].Paragraphs[0].Append("BudgetedExpenditure")
                            .Bold(true)
                            .Color(Color.White);
                        expDoc.Rows[0].Cells[2].Paragraphs[0].Append("ActualExpenditure")
                            .Bold(true)
                            .Color(Color.White);
                        expDoc.Rows[0].Cells[3].Paragraphs[0].Append("ActualVariance")
                            .Bold(true)
                            .Color(Color.White);
                        expDoc.Rows[0].Cells[4].Paragraphs[0].Append("ForecastExpenditure")
                            .Bold(true)
                            .Color(Color.White);
                        expDoc.Rows[0].Cells[5].Paragraphs[0].Append("ForecastVariance")
                            .Bold(true)
                            .Color(Color.White);
                        expDoc.Rows[0].Cells[6].Paragraphs[0].Append("Summary")
                            .Bold(true)
                            .Color(Color.White);

                        expDoc.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        expDoc.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        expDoc.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;
                        expDoc.Rows[0].Cells[3].FillColor = TABLE_HEADER_COLOR;
                        expDoc.Rows[0].Cells[4].FillColor = TABLE_HEADER_COLOR;
                        expDoc.Rows[0].Cells[5].FillColor = TABLE_HEADER_COLOR;
                        expDoc.Rows[0].Cells[6].FillColor = TABLE_HEADER_COLOR;
                        
                        for (int i = 1; i < currentProjectStatusReportModel.ProjExpenses.Count + 1; i++)
                        {
                            expDoc.Rows[i].Cells[0].Paragraphs[0].Append(currentProjectStatusReportModel.ProjExpenses[i - 1].ExpenseType);
                            expDoc.Rows[i].Cells[1].Paragraphs[0].Append(currentProjectStatusReportModel.ProjExpenses[i - 1].BudgetedExpenditure);
                            expDoc.Rows[i].Cells[2].Paragraphs[0].Append(currentProjectStatusReportModel.ProjExpenses[i - 1].ActualExpenditure);
                            expDoc.Rows[i].Cells[3].Paragraphs[0].Append(currentProjectStatusReportModel.ProjExpenses[i - 1].ActualVariance);
                            expDoc.Rows[i].Cells[4].Paragraphs[0].Append(currentProjectStatusReportModel.ProjExpenses[i - 1].ForecastExpenditure);
                            expDoc.Rows[i].Cells[5].Paragraphs[0].Append(currentProjectStatusReportModel.ProjExpenses[i - 1].ForecastVariance);
                            expDoc.Rows[i].Cells[6].Paragraphs[0].Append(currentProjectStatusReportModel.ProjExpenses[i - 1].Summary);

                        }
                        expDoc.SetWidths(new float[] { 394, 762, 762, 762, 762, 762, 762 });
                        document.InsertTable(expDoc);

                        var effSubHeading = document.InsertParagraph("3.3 Project Effort")
                           .Bold()
                           .FontSize(14d)
                           .Color(Color.Black)
                           .Bold(true)
                           .Font("Arial");

                        expsSubHeading.StyleId = "Heading2";

                        var effDoc = document.AddTable(currentProjectStatusReportModel.ProjEffort.Count + 1, 7);
                        effDoc.Rows[0].Cells[0].Paragraphs[0].Append("Activities")
                            .Bold(true)
                            .Color(Color.White);
                        effDoc.Rows[0].Cells[1].Paragraphs[0].Append("BudgetedEffort")
                            .Bold(true)
                            .Color(Color.White);
                        effDoc.Rows[0].Cells[2].Paragraphs[0].Append("ActualEffort")
                            .Bold(true)
                            .Color(Color.White);
                        effDoc.Rows[0].Cells[3].Paragraphs[0].Append("ActualVariance")
                            .Bold(true)
                            .Color(Color.White);
                        effDoc.Rows[0].Cells[4].Paragraphs[0].Append("ForecastEffort")
                            .Bold(true)
                            .Color(Color.White);
                        effDoc.Rows[0].Cells[5].Paragraphs[0].Append("ForecastVariance")
                            .Bold(true)
                            .Color(Color.White);
                        effDoc.Rows[0].Cells[6].Paragraphs[0].Append("Summary")
                            .Bold(true)
                            .Color(Color.White);

                        effDoc.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        effDoc.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        effDoc.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;
                        effDoc.Rows[0].Cells[3].FillColor = TABLE_HEADER_COLOR;
                        effDoc.Rows[0].Cells[4].FillColor = TABLE_HEADER_COLOR;
                        effDoc.Rows[0].Cells[5].FillColor = TABLE_HEADER_COLOR;
                        effDoc.Rows[0].Cells[6].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < currentProjectStatusReportModel.ProjEffort.Count + 1; i++)
                        {
                            effDoc.Rows[i].Cells[0].Paragraphs[0].Append(currentProjectStatusReportModel.ProjEffort[i - 1].Activities);
                            effDoc.Rows[i].Cells[1].Paragraphs[0].Append(currentProjectStatusReportModel.ProjEffort[i - 1].BudgetedEffort);
                            effDoc.Rows[i].Cells[2].Paragraphs[0].Append(currentProjectStatusReportModel.ProjEffort[i - 1].ActualEffort);
                            effDoc.Rows[i].Cells[3].Paragraphs[0].Append(currentProjectStatusReportModel.ProjEffort[i - 1].ActualVariance);
                            effDoc.Rows[i].Cells[4].Paragraphs[0].Append(currentProjectStatusReportModel.ProjEffort[i - 1].ForecastEffort);
                            effDoc.Rows[i].Cells[5].Paragraphs[0].Append(currentProjectStatusReportModel.ProjEffort[i - 1].ForecastVariance);
                            effDoc.Rows[i].Cells[6].Paragraphs[0].Append(currentProjectStatusReportModel.ProjEffort[i - 1].Summary);

                        }
                        effDoc.SetWidths(new float[] { 394, 762, 762, 762, 762, 762, 762 });
                        document.InsertTable(effDoc);

                        var proqSubHeading = document.InsertParagraph("3.4 Project Quality")
                           .Bold()
                           .FontSize(14d)
                           .Color(Color.Black)
                           .Bold(true)
                           .Font("Arial");

                        expsSubHeading.StyleId = "Heading2";

                        var prqSubHeading = document.AddTable(currentProjectStatusReportModel.ProjQuality.Count + 1, 5);
                        prqSubHeading.Rows[0].Cells[0].Paragraphs[0].Append("Deliverables")
                            .Bold(true)
                            .Color(Color.White);
                        prqSubHeading.Rows[0].Cells[1].Paragraphs[0].Append("QualityTarget")
                            .Bold(true)
                            .Color(Color.White);
                        prqSubHeading.Rows[0].Cells[2].Paragraphs[0].Append("QualityAchieved")
                            .Bold(true)
                            .Color(Color.White);
                        prqSubHeading.Rows[0].Cells[3].Paragraphs[0].Append("QualityVariance")
                            .Bold(true)
                            .Color(Color.White);
                        prqSubHeading.Rows[0].Cells[4].Paragraphs[0].Append("Summary")
                           .Bold(true)
                           .Color(Color.White);


                        prqSubHeading.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        prqSubHeading.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        prqSubHeading.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;
                        prqSubHeading.Rows[0].Cells[3].FillColor = TABLE_HEADER_COLOR;
                        prqSubHeading.Rows[0].Cells[4].FillColor = TABLE_HEADER_COLOR;


                        for (int i = 1; i < currentProjectStatusReportModel.ProjQuality.Count + 1; i++)
                        {
                            prqSubHeading.Rows[i].Cells[0].Paragraphs[0].Append(currentProjectStatusReportModel.ProjQuality[i - 1].Deliverables);
                            prqSubHeading.Rows[i].Cells[1].Paragraphs[0].Append(currentProjectStatusReportModel.ProjQuality[i - 1].QualityTarget);
                            prqSubHeading.Rows[i].Cells[2].Paragraphs[0].Append(currentProjectStatusReportModel.ProjQuality[i - 1].QualityAchieved);
                            prqSubHeading.Rows[i].Cells[3].Paragraphs[0].Append(currentProjectStatusReportModel.ProjQuality[i - 1].QualityVariance);
                            prqSubHeading.Rows[i].Cells[4].Paragraphs[0].Append(currentProjectStatusReportModel.ProjQuality[i - 1].Summary);

                        }
                        prqSubHeading.SetWidths(new float[] { 394, 762, 762, 762, 762 });
                        document.InsertTable(prqSubHeading);

                        var riskSubHeading = document.InsertParagraph("3.5 Project Risks")
                           .Bold()
                           .FontSize(14d)
                           .Color(Color.Black)
                           .Bold(true)
                           .Font("Arial");

                        riskSubHeading.StyleId = "Heading2";

                        var riSubHeading = document.AddTable(currentProjectStatusReportModel.ProjRisk.Count + 1, 4);
                        riSubHeading.Rows[0].Cells[0].Paragraphs[0].Append("Risks")
                            .Bold(true)
                            .Color(Color.White);
                        riSubHeading.Rows[0].Cells[1].Paragraphs[0].Append("Likelihood")
                            .Bold(true)
                            .Color(Color.White);
                        riSubHeading.Rows[0].Cells[2].Paragraphs[0].Append("Impact")
                            .Bold(true)
                            .Color(Color.White);
                        riSubHeading.Rows[0].Cells[3].Paragraphs[0].Append("Summary")
                            .Bold(true)
                            .Color(Color.White);
                       


                        riSubHeading.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        riSubHeading.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        riSubHeading.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;
                        riSubHeading.Rows[0].Cells[3].FillColor = TABLE_HEADER_COLOR;
                       


                        for (int i = 1; i < currentProjectStatusReportModel.ProjRisk.Count + 1; i++)
                        {
                            riSubHeading.Rows[i].Cells[0].Paragraphs[0].Append(currentProjectStatusReportModel.ProjRisk[i - 1].Risks);
                            riSubHeading.Rows[i].Cells[1].Paragraphs[0].Append(currentProjectStatusReportModel.ProjRisk[i - 1].Likelihood);
                            riSubHeading.Rows[i].Cells[2].Paragraphs[0].Append(currentProjectStatusReportModel.ProjRisk[i - 1].Impact);
                            riSubHeading.Rows[i].Cells[3].Paragraphs[0].Append(currentProjectStatusReportModel.ProjRisk[i - 1].Summary);
                        }
                        riSubHeading.SetWidths(new float[] { 394, 762, 762, 762 });
                        document.InsertTable(riSubHeading);

                        var issSubHeading = document.InsertParagraph("3.6 Project Issues")
                           .Bold()
                           .FontSize(14d)
                           .Color(Color.Black)
                           .Bold(true)
                           .Font("Arial");

                        issSubHeading.StyleId = "Heading2";

                        var issuesSubHeading = document.AddTable(currentProjectStatusReportModel.NProjIssues.Count + 1, 3);
                        issuesSubHeading.Rows[0].Cells[0].Paragraphs[0].Append("Risks")
                            .Bold(true)
                            .Color(Color.White);
                        issuesSubHeading.Rows[0].Cells[1].Paragraphs[0].Append("Likelihood")
                            .Bold(true)
                            .Color(Color.White);
                        issuesSubHeading.Rows[0].Cells[2].Paragraphs[0].Append("Impact")
                            .Bold(true)
                            .Color(Color.White);

                        issuesSubHeading.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        issuesSubHeading.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        issuesSubHeading.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < currentProjectStatusReportModel.NProjIssues.Count + 1; i++)
                        {
                            issuesSubHeading.Rows[i].Cells[0].Paragraphs[0].Append(currentProjectStatusReportModel.NProjIssues[i - 1].Issues);
                            issuesSubHeading.Rows[i].Cells[1].Paragraphs[0].Append(currentProjectStatusReportModel.NProjIssues[i - 1].Impact);
                            issuesSubHeading.Rows[i].Cells[2].Paragraphs[0].Append(currentProjectStatusReportModel.NProjIssues[i - 1].Summary);
                        }
                        issuesSubHeading.SetWidths(new float[] { 394, 762, 762 });
                        document.InsertTable(issuesSubHeading);

                        try
                        {
                            document.Save();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("The selected File is open.", "Close File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            } 
        } 


        private void txtProjectDescription_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void tabExecutiveSummary_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void ProjectStatusReportDocumentForm_Load_1(object sender, EventArgs e)
        {
            string jsoni = JsonHelper.loadProjectInfo(Settings.Default.Username);
            List<ProjectModel> projectListModel = JsonConvert.DeserializeObject<List<ProjectModel>>(jsoni);
            projectModel = projectModel.getProjectModel(Settings.Default.ProjectID, projectListModel);
            txtProjectName.Text = projectModel.ProjectName;

            loadDocument();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveDocument();
        }

        private void btnExportWord_Click(object sender, EventArgs e)
        {
            exportToWord();
        }
    }
}
