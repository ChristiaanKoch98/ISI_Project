using ProjectManagementToolkit.Classes;
using ProjectManagementToolkit.Properties;
using ProjectManagementToolkit.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Xceed.Words.NET;
using Xceed.Document.NET;

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Forms
{
    public partial class RiskPlanForm : Form
    {
        VersionControl<RiskPlanModel> versionControl;
        RiskPlanModel newRiskPlanModel;
        RiskPlanModel currentRiskPlanModel;

        Color TABLE_HEADER_COLOR = Color.FromArgb(73, 173, 252);
        RiskPlanModel riskModel = new RiskPlanModel();


        public RiskPlanForm()
        {
            InitializeComponent();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveDocument();
        }

        private void btnExportToWord_Click(object sender, EventArgs e)
        {
            ExportToWord();
        }

        private void saveDocument()
        {
            newRiskPlanModel.ProjectName = Project_Name_tbx.Text;

            List<Information> informations = new List<Information>();
            Information information = new Information();
            var DocumentID = Document_Information_dgv.Rows[0].Cells[1].Value.ToString();
            var DocumentOwner = Document_Information_dgv.Rows[1].Cells[1].Value.ToString();
            var IssueDate = Document_Information_dgv.Rows[2].Cells[1].Value.ToString();
            var LastSavedDate = Document_Information_dgv.Rows[3].Cells[1].Value.ToString();
            var FileName = Document_Information_dgv.Rows[4].Cells[1].Value.ToString();

            information.DocumentID = DocumentID;
            information.DocumentOwner = DocumentOwner;
            information.IssueDate = IssueDate;
            information.LastSavedDate = LastSavedDate;
            information.FileName = FileName;
            newRiskPlanModel.Information = information;

            List<History> histories = new List<History>();
            int Document_HistoryRowCount = Document_History_dgv.RowCount;
            for (int i = 0; i < Document_HistoryRowCount - 1; i++)
            {
                History history = new History();
                var Version = Document_History_dgv.Rows[i].Cells[0].Value?.ToString() ?? "";
                var IsDate = Document_History_dgv.Rows[i].Cells[1].Value?.ToString() ?? "";
                var Changes = Document_History_dgv.Rows[i].Cells[2].Value?.ToString() ?? "";
                history.Version = Version;
                history.IssueDate = IsDate;
                history.Changes = Changes;
                histories.Add(history);
            }
            newRiskPlanModel.Histories = histories;

            List<Approval> approvals = new List<Approval>();
            int approvalCount = Document_Approvals_dgv.RowCount;
            for (int i = 0; i < Document_HistoryRowCount - 1; i++)
            {
                Approval approval = new Approval();
                var Role = Document_Approvals_dgv.Rows[i].Cells[0].Value?.ToString() ?? "";
                var Name = Document_Approvals_dgv.Rows[i].Cells[1].Value?.ToString() ?? "";
                var Signature = Document_Approvals_dgv.Rows[i].Cells[2].Value?.ToString() ?? "";
                var Date = Document_Approvals_dgv.Rows[i].Cells[3].Value?.ToString() ?? "";

                approval.Name = Name;
                approval.Role = Role;
                approval.Signature = Signature;
                approval.Date = Date;

                approvals.Add(approval);
            }
            newRiskPlanModel.Approvals = approvals;

            newRiskPlanModel.Categories = Categories_tbx.Text;

            List<Risk> risks = new List<Risk>();
            int riskCount = Risks_dgv.RowCount;
            for (int i = 0; i < riskCount - 1; i++)
            {
                Risk risk = new Risk();
                var RiskCategory = Risks_dgv.Rows[i].Cells[0].Value?.ToString() ?? "";
                var RiskDescription = Risks_dgv.Rows[i].Cells[1].Value?.ToString() ?? "";
                var ID = Risks_dgv.Rows[i].Cells[2].Value?.ToString() ?? "";

                risk.RiskCategory = RiskCategory;
                risk.RiskDescription = RiskDescription;
                risk.ID = ID;

                risks.Add(risk);
            }
            newRiskPlanModel.Risks = risks;

            List<Likelihood> likelihoods = new List<Likelihood>();
            int LikelihoodrowCount = Likelihood_dgv.RowCount;
            for (int i = 0; i < LikelihoodrowCount - 1; i++)
            {
                Likelihood likelihood = new Likelihood();
                var Title = Likelihood_dgv.Rows[i].Cells[0].Value?.ToString() ?? "";
                var Score = Likelihood_dgv.Rows[i].Cells[1].Value?.ToString() ?? "";
                var Description = Likelihood_dgv.Rows[i].Cells[2].Value?.ToString() ?? "";
                likelihood.Title = Title;
                likelihood.Score = Score;
                likelihood.Description = Description;

                likelihoods.Add(likelihood);
            }
            newRiskPlanModel.Likelihoods = likelihoods;

            List<Impact> impacts = new List<Impact>();
            int impactrowCount = Impact_dgv.RowCount;
            for (int i = 0; i < impactrowCount - 1; i++)
            {
                Impact impact = new Impact();
                var Title = Impact_dgv.Rows[i].Cells[0].Value?.ToString() ?? "";
                var Score = Impact_dgv.Rows[i].Cells[1].Value?.ToString() ?? "";
                var Description = Impact_dgv.Rows[i].Cells[2].Value?.ToString() ?? "";

                impact.Title = Title;
                impact.Score = Score;
                impact.Description = Description;

                impacts.Add(impact);
            }
            newRiskPlanModel.Impacts = impacts;

            List<Priority> priorities = new List<Priority>();
            int PriorityrowCount = Priority_dgv.RowCount;
            for (int i = 0; i < PriorityrowCount - 1; i++)
            {
                Priority priority = new Priority();
                var ID = Priority_dgv.Rows[i].Cells[0].Value?.ToString() ?? "";
                var LikelihoodScore = Priority_dgv.Rows[i].Cells[1].Value?.ToString() ?? "";
                var ImpactScore = Priority_dgv.Rows[i].Cells[2].Value?.ToString() ?? "";
                var PriorityScore = Priority_dgv.Rows[i].Cells[3].Value?.ToString() ?? "";
                var PriorityRating = Priority_dgv.Rows[i].Cells[4].Value?.ToString() ?? "";


                priority.ID = ID;
                priority.LikelihoodScore = LikelihoodScore;
                priority.ImpactScore = ImpactScore;
                priority.PriorityScore = PriorityScore;
                priority.PriorityRating = PriorityRating;

                priorities.Add(priority);
            }
            newRiskPlanModel.Priorities = priorities;

            List<Schedule> schedules = new List<Schedule>();
            int SchedulerowCount = Schedule_dgv.RowCount;
            for (int i = 0; i < SchedulerowCount - 1; i++)
            {
                Schedule schedule = new Schedule();
                var Rating = Schedule_dgv.Rows[i].Cells[0].Value?.ToString() ?? "";
                var ID = Schedule_dgv.Rows[i].Cells[1].Value?.ToString() ?? "";
                var PrevalantiveActions = Schedule_dgv.Rows[i].Cells[2].Value?.ToString() ?? "";
                var ActionResource1 = Schedule_dgv.Rows[i].Cells[3].Value?.ToString() ?? "";
                var ActionDate1 = Schedule_dgv.Rows[i].Cells[4].Value?.ToString() ?? "";
                var ContingentActions = Schedule_dgv.Rows[i].Cells[5].Value?.ToString() ?? "";
                var ActionResource2 = Schedule_dgv.Rows[i].Cells[6].Value?.ToString() ?? "";
                var ActionDate2 = Schedule_dgv.Rows[i].Cells[7].Value?.ToString() ?? "";

                schedule.Rating = Rating;
                schedule.ID = ID;
                schedule.PrevalantiveActions = PrevalantiveActions;
                schedule.ActionResource1 = ActionResource1;
                schedule.ActionDate1 = ActionDate1;
                schedule.ContingentActions = ContingentActions;
                schedule.ActionResource2 = ActionResource2;
                schedule.ActionDate2 = ActionDate2;

                schedules.Add(schedule);
            }
            newRiskPlanModel.Schedules = schedules;

            newRiskPlanModel.Assumptions = Assumptions_tbx.Text;
            newRiskPlanModel.Constraints = Constraints_tbx.Text;
            newRiskPlanModel.Activities = Activities_tbx.Text;
            newRiskPlanModel.Roles = Roles_tbx.Text;
            newRiskPlanModel.Documents = Documents_tbx.Text;
            newRiskPlanModel.Appendix = Appendix_tbx.Text;

            List<VersionControl<RiskPlanModel>.DocumentModel> documentModels = versionControl.DocumentModels;

            //MessageBox.Show(JsonConvert.SerializeObject(newRiskPlanModel), "save", MessageBoxButtons.OK);

            if (!versionControl.isEqual(currentRiskPlanModel, newRiskPlanModel))
            {
                VersionControl<RiskPlanModel>.DocumentModel documentModel = new VersionControl<RiskPlanModel>.DocumentModel(newRiskPlanModel, DateTime.Now, VersionControl<RiskPlanModel>.generateID());

                documentModels.Add(documentModel);

                versionControl.DocumentModels = documentModels;

                string json = JsonConvert.SerializeObject(versionControl);
                JsonHelper.saveDocument(json, Settings.Default.ProjectID, "RiskPlan");
                MessageBox.Show("Risk plan saved successfully", "save", MessageBoxButtons.OK);
            }
        }

        private void loadDocument()
        {
            string json = JsonHelper.loadDocument(Settings.Default.ProjectID, "RiskPlan");
            List<string[]> documentInfo = new List<string[]>();
            newRiskPlanModel = new RiskPlanModel();
            currentRiskPlanModel = new RiskPlanModel();

            if (json != "")
            {
                versionControl = JsonConvert.DeserializeObject<VersionControl<RiskPlanModel>>(json);
                newRiskPlanModel = JsonConvert.DeserializeObject<RiskPlanModel>(versionControl.getLatest(versionControl.DocumentModels));
                currentRiskPlanModel = JsonConvert.DeserializeObject<RiskPlanModel>(versionControl.getLatest(versionControl.DocumentModels));

                Information information = currentRiskPlanModel.Information;
                documentInfo.Add(new string[] { "Document ID", information.DocumentID });
                documentInfo.Add(new string[] { "Document Owner", information.DocumentOwner });
                documentInfo.Add(new string[] { "Issue Date", information.IssueDate });
                documentInfo.Add(new string[] { "Last Save Date", information.LastSavedDate });
                documentInfo.Add(new string[] { "File Name", information.FileName });

                foreach (var row in documentInfo)
                {
                    Document_Information_dgv.Rows.Add(row);
                }
                Document_Information_dgv.AllowUserToAddRows = false;

                foreach (var row in currentRiskPlanModel.Histories)
                {
                    Document_History_dgv.Rows.Add(new string[] { row.Version, row.IssueDate, row.Changes });
                }

                foreach (var row in currentRiskPlanModel.Approvals)
                {
                    Document_Approvals_dgv.Rows.Add(new string[] { row.Role, row.Name, row.Signature, row.Date });
                }

                foreach (var row in currentRiskPlanModel.Risks)
                {
                    Risks_dgv.Rows.Add(new string[] { row.RiskCategory, row.RiskDescription, row.ID });
                }

                foreach (var row in currentRiskPlanModel.Likelihoods)
                {
                    Likelihood_dgv.Rows.Add(new string[] { row.Title, row.Description, row.Score });
                }

                foreach (var row in currentRiskPlanModel.Priorities)
                {
                    Priority_dgv.Rows.Add(new string[] { row.ID, row.LikelihoodScore, row.ImpactScore, row.PriorityScore, row.PriorityRating });
                }

                foreach (var row in currentRiskPlanModel.Impacts)
                {
                    Impact_dgv.Rows.Add(new string[] { row.Title, row.Score, row.Description });
                }

                foreach (var row in currentRiskPlanModel.Schedules)
                {
                    Schedule_dgv.Rows.Add(new string[] { row.Rating, row.ID, row.PrevalantiveActions, row.ActionResource1, row.ActionDate1, row.ContingentActions, row.ActionResource2, row.ActionDate2 });
                }

                Project_Name_tbx.Text = currentRiskPlanModel.ProjectName;
                Categories_tbx.Text = currentRiskPlanModel.Categories;
                Constraints_tbx.Text = currentRiskPlanModel.Constraints;
                Assumptions_tbx.Text = currentRiskPlanModel.Constraints;
                Roles_tbx.Text = currentRiskPlanModel.Roles;
                Activities_tbx.Text = currentRiskPlanModel.Activities;
                Documents_tbx.Text = currentRiskPlanModel.Documents;
                Appendix_tbx.Text = currentRiskPlanModel.Appendix;

            }
            else
            {
                versionControl = new VersionControl<RiskPlanModel>();
                versionControl.DocumentModels = new List<VersionControl<RiskPlanModel>.DocumentModel>();
                newRiskPlanModel = new RiskPlanModel();
                documentInfo.Add(new string[] { "Document ID", "" });
                documentInfo.Add(new string[] { "Document Owner", "" });
                documentInfo.Add(new string[] { "Issue Date", "" });
                documentInfo.Add(new string[] { "Last Save Date", "" });
                documentInfo.Add(new string[] { "File Name", "" });

                foreach (var row in documentInfo)
                {
                    Document_Information_dgv.Rows.Add(row);
                }
                Document_Information_dgv.AllowUserToAddRows = false;
            }
        }

        private void RiskPlanDocumentForm_Load(object sender, EventArgs e)
        {
            loadDocument();
        }

        private void ExportToWord()
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
                        for (int i = 0; i < 11; i++)
                        {
                            document.InsertParagraph("")
                                .Font("Arial")
                                .Bold(true)
                                .FontSize(22d).Alignment = Alignment.left;
                        }

                        document.InsertParagraph("Risk Plan \nFor " + currentRiskPlanModel.ProjectName)
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(22d).Alignment = Alignment.left;
                        document.InsertSectionPageBreak();
                        document.InsertParagraph("Document Control\n")
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(14d).Alignment = Alignment.left;
                        document.InsertParagraph("")
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(14d).Alignment = Alignment.left;
                        document.InsertParagraph("Document Information\n")
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(14d).Alignment = Alignment.left;

                        var Document_Information = document.AddTable(6, 2);
                        Document_Information.Rows[0].Cells[0].Paragraphs[0].Append("").Bold(true).Color(Color.White);
                        Document_Information.Rows[0].Cells[1].Paragraphs[0].Append("Information").Bold(true).Color(Color.White);
                        Document_Information.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        Document_Information.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;

                        Document_Information.Rows[1].Cells[0].Paragraphs[0].Append("Document ID");
                        Document_Information.Rows[1].Cells[1].Paragraphs[0].Append(currentRiskPlanModel.Information.DocumentID);

                        Document_Information.Rows[2].Cells[0].Paragraphs[0].Append("Document Owner");
                        Document_Information.Rows[2].Cells[1].Paragraphs[0].Append(currentRiskPlanModel.Information.DocumentOwner);

                        Document_Information.Rows[3].Cells[0].Paragraphs[0].Append("Issue Date");
                        Document_Information.Rows[3].Cells[1].Paragraphs[0].Append(currentRiskPlanModel.Information.IssueDate);

                        Document_Information.Rows[4].Cells[0].Paragraphs[0].Append("Last Saved Date");
                        Document_Information.Rows[4].Cells[1].Paragraphs[0].Append(currentRiskPlanModel.Information.LastSavedDate);

                        Document_Information.Rows[5].Cells[0].Paragraphs[0].Append("File Name");
                        Document_Information.Rows[5].Cells[1].Paragraphs[0].Append(currentRiskPlanModel.Information.FileName);
                        Document_Information.SetWidths(new float[] { 493, 1094 });
                        document.InsertTable(Document_Information);

                        document.InsertParagraph("\nDocument History\n")
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(14d).Alignment = Alignment.left;

                        var documentHistoryTable = document.AddTable(currentRiskPlanModel.Histories.Count + 1, 3);
                        documentHistoryTable.Rows[0].Cells[0].Paragraphs[0].Append("Version")
                            .Bold(true)
                            .Color(Color.White);
                        documentHistoryTable.Rows[0].Cells[1].Paragraphs[0].Append("Issue Date")
                            .Bold(true)
                            .Color(Color.White);
                        documentHistoryTable.Rows[0].Cells[2].Paragraphs[0].Append("Changes")
                            .Bold(true)
                            .Color(Color.White);

                        documentHistoryTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        documentHistoryTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        documentHistoryTable.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < currentRiskPlanModel.Histories.Count + 1; i++)
                        {
                            documentHistoryTable.Rows[i].Cells[0].Paragraphs[0].Append(currentRiskPlanModel.Histories[i - 1].Version);
                            documentHistoryTable.Rows[i].Cells[1].Paragraphs[0].Append(currentRiskPlanModel.Histories[i - 1].IssueDate);
                            documentHistoryTable.Rows[i].Cells[2].Paragraphs[0].Append(currentRiskPlanModel.Histories[i - 1].Changes);

                        }

                        documentHistoryTable.SetWidths(new float[] { 190, 303, 1094 });
                        document.InsertTable(documentHistoryTable);

                        document.InsertParagraph("\nDocument Approvals\n")
                           .Font("Arial")
                           .Bold(true)
                           .FontSize(14d).Alignment = Alignment.left;

                        var documentApprovalTable = document.AddTable(currentRiskPlanModel.Approvals.Count + 1, 4);
                        documentApprovalTable.Rows[0].Cells[0].Paragraphs[0].Append("Role")
                            .Bold(true)
                            .Color(Color.White);
                        documentApprovalTable.Rows[0].Cells[1].Paragraphs[0].Append("Name")
                            .Bold(true)
                            .Color(Color.White);
                        documentApprovalTable.Rows[0].Cells[2].Paragraphs[0].Append("Signature")
                            .Bold(true)
                            .Color(Color.White);
                        documentApprovalTable.Rows[0].Cells[3].Paragraphs[0].Append("Date")
                            .Bold(true)
                            .Color(Color.White);
                        documentApprovalTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        documentApprovalTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        documentApprovalTable.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;
                        documentApprovalTable.Rows[0].Cells[3].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < currentRiskPlanModel.Approvals.Count + 1; i++)
                        {
                            documentApprovalTable.Rows[i].Cells[0].Paragraphs[0].Append(currentRiskPlanModel.Approvals[i - 1].Role);
                            documentApprovalTable.Rows[i].Cells[1].Paragraphs[0].Append(currentRiskPlanModel.Approvals[i - 1].Name);
                            documentApprovalTable.Rows[i].Cells[2].Paragraphs[0].Append(currentRiskPlanModel.Approvals[i - 1].Signature);
                            documentApprovalTable.Rows[i].Cells[3].Paragraphs[0].Append(currentRiskPlanModel.Approvals[i - 1].Date);
                        }
                        documentApprovalTable.SetWidths(new float[] { 493, 332, 508, 254 });
                        document.InsertTable(documentApprovalTable);
                        document.InsertParagraph().InsertPageBreakAfterSelf();

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

                        var RiskIdentification = document.InsertParagraph("1 Risk Identification")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");
                        RiskIdentification.StyleId = "Heading1";

                        var CategoriesHeading = RiskIdentification.InsertParagraphAfterSelf("1.1 Categories")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");
                        CategoriesHeading.StyleId = "Heading2";

                        document.InsertParagraph(currentRiskPlanModel.Categories)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        var RisksHeading = document.InsertParagraph("1.2 Risks")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");
                        RisksHeading.StyleId = "Heading2";

                        var documentRisksTable = document.AddTable(currentRiskPlanModel.Risks.Count + 1, 3);
                        documentRisksTable.Rows[0].Cells[0].Paragraphs[0].Append("Risk Category")
                            .Bold(true)
                            .Color(Color.White);
                        documentRisksTable.Rows[0].Cells[1].Paragraphs[0].Append("Risk Description")
                            .Bold(true)
                            .Color(Color.White);
                        documentRisksTable.Rows[0].Cells[2].Paragraphs[0].Append("ID")
                            .Bold(true)
                            .Color(Color.White);

                        documentRisksTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        documentRisksTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        documentRisksTable.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < currentRiskPlanModel.Risks.Count + 1; i++)
                        {
                            documentRisksTable.Rows[i].Cells[0].Paragraphs[0].Append(currentRiskPlanModel.Risks[i - 1].RiskCategory);
                            documentRisksTable.Rows[i].Cells[1].Paragraphs[0].Append(currentRiskPlanModel.Risks[i - 1].RiskDescription);
                            documentRisksTable.Rows[i].Cells[2].Paragraphs[0].Append(currentRiskPlanModel.Risks[i - 1].ID);

                        }

                        documentRisksTable.SetWidths(new float[] { 190, 303, 1094 });
                        document.InsertTable(documentRisksTable);


                        var RiskQuantification = document.InsertParagraph("2 Risk Quantification")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");
                        RiskQuantification.StyleId = "Heading1";

                        var Likelihood = document.InsertParagraph("2.1 Likelihood")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");
                        Likelihood.StyleId = "Heading2";

                        var documentLikelihoodTable = document.AddTable(currentRiskPlanModel.Likelihoods.Count + 1, 3);
                        documentLikelihoodTable.Rows[0].Cells[0].Paragraphs[0].Append("Title")
                            .Bold(true)
                            .Color(Color.White);
                        documentLikelihoodTable.Rows[0].Cells[1].Paragraphs[0].Append("Score")
                            .Bold(true)
                            .Color(Color.White);
                        documentLikelihoodTable.Rows[0].Cells[2].Paragraphs[0].Append("Description")
                            .Bold(true)
                            .Color(Color.White);

                        documentLikelihoodTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        documentLikelihoodTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        documentLikelihoodTable.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < currentRiskPlanModel.Likelihoods.Count + 1; i++)
                        {
                            documentLikelihoodTable.Rows[i].Cells[0].Paragraphs[0].Append(currentRiskPlanModel.Likelihoods[i - 1].Title);
                            documentLikelihoodTable.Rows[i].Cells[1].Paragraphs[0].Append(currentRiskPlanModel.Likelihoods[i - 1].Score);
                            documentLikelihoodTable.Rows[i].Cells[2].Paragraphs[0].Append(currentRiskPlanModel.Likelihoods[i - 1].Description);

                        }

                        documentLikelihoodTable.SetWidths(new float[] { 190, 303, 1094 });
                        document.InsertTable(documentLikelihoodTable);

                        var Impact = document.InsertParagraph("2.2 Impact")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");
                        Impact.StyleId = "Heading2";
                        var documentImpactsTable = document.AddTable(currentRiskPlanModel.Impacts.Count + 1, 3);
                        documentImpactsTable.Rows[0].Cells[0].Paragraphs[0].Append("Title")
                            .Bold(true)
                            .Color(Color.White);
                        documentImpactsTable.Rows[0].Cells[1].Paragraphs[0].Append("Score")
                            .Bold(true)
                            .Color(Color.White);
                        documentImpactsTable.Rows[0].Cells[2].Paragraphs[0].Append("Description")
                            .Bold(true)
                            .Color(Color.White);

                        documentImpactsTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        documentImpactsTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        documentImpactsTable.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < currentRiskPlanModel.Impacts.Count + 1; i++)
                        {
                            documentImpactsTable.Rows[i].Cells[0].Paragraphs[0].Append(currentRiskPlanModel.Impacts[i - 1].Title);
                            documentImpactsTable.Rows[i].Cells[1].Paragraphs[0].Append(currentRiskPlanModel.Impacts[i - 1].Score);
                            documentImpactsTable.Rows[i].Cells[2].Paragraphs[0].Append(currentRiskPlanModel.Impacts[i - 1].Description);

                        }

                        documentImpactsTable.SetWidths(new float[] { 190, 303, 1094 });
                        document.InsertTable(documentImpactsTable);

                        var Priority = document.InsertParagraph("2.3 Priority")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");
                        Priority.StyleId = "Heading2";
                        var documentPriorityTable = document.AddTable(currentRiskPlanModel.Priorities.Count + 1, 5);
                        documentPriorityTable.Rows[0].Cells[0].Paragraphs[0].Append("Risk ID")
                            .Bold(true)
                            .Color(Color.White);
                        documentPriorityTable.Rows[0].Cells[1].Paragraphs[0].Append("Likelihood Score")
                            .Bold(true)
                            .Color(Color.White);
                        documentPriorityTable.Rows[0].Cells[2].Paragraphs[0].Append("Impact Score")
                            .Bold(true)
                            .Color(Color.White);
                        documentPriorityTable.Rows[0].Cells[3].Paragraphs[0].Append("Priority Score")
                           .Bold(true)
                           .Color(Color.White);
                        documentPriorityTable.Rows[0].Cells[4].Paragraphs[0].Append("Priority Rating")
                           .Bold(true)
                           .Color(Color.White);

                        documentPriorityTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        documentPriorityTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        documentPriorityTable.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;
                        documentPriorityTable.Rows[0].Cells[3].FillColor = TABLE_HEADER_COLOR;
                        documentPriorityTable.Rows[0].Cells[4].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < currentRiskPlanModel.Priorities.Count + 1; i++)
                        {
                            documentPriorityTable.Rows[i].Cells[0].Paragraphs[0].Append(currentRiskPlanModel.Priorities[i - 1].ID);
                            documentPriorityTable.Rows[i].Cells[1].Paragraphs[0].Append(currentRiskPlanModel.Priorities[i - 1].LikelihoodScore);
                            documentPriorityTable.Rows[i].Cells[2].Paragraphs[0].Append(currentRiskPlanModel.Priorities[i - 1].ImpactScore);
                            documentPriorityTable.Rows[i].Cells[3].Paragraphs[0].Append(currentRiskPlanModel.Priorities[i - 1].PriorityScore);
                            documentPriorityTable.Rows[i].Cells[4].Paragraphs[0].Append(currentRiskPlanModel.Priorities[i - 1].PriorityRating);

                        }

                        //documentPriorityTable.SetWidths(new float[] { 190, 303, 1094 });
                        document.InsertTable(documentPriorityTable);

                        var RiskPlan = document.InsertParagraph("3 Risk Plan")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");
                        RiskPlan.StyleId = "Heading1";

                        var Schedule = document.InsertParagraph("3.1 Schedule")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");
                        Schedule.StyleId = "Heading2";

                        var documentScheduleyTable = document.AddTable(currentRiskPlanModel.Schedules.Count + 1, 8);
                        documentScheduleyTable.Rows[0].Cells[0].Paragraphs[0].Append("Risk Rating")
                            .Bold(true)
                            .Color(Color.White);
                        documentScheduleyTable.Rows[0].Cells[1].Paragraphs[0].Append("Risk ID")
                            .Bold(true)
                            .Color(Color.White);
                        documentScheduleyTable.Rows[0].Cells[2].Paragraphs[0].Append("Prevalantive Actions")
                            .Bold(true)
                            .Color(Color.White);
                        documentScheduleyTable.Rows[0].Cells[3].Paragraphs[0].Append("Action Resource")
                           .Bold(true)
                           .Color(Color.White);
                        documentScheduleyTable.Rows[0].Cells[4].Paragraphs[0].Append("Action Date")
                           .Bold(true)
                           .Color(Color.White);
                        documentScheduleyTable.Rows[0].Cells[5].Paragraphs[0].Append("Contingent Actions")
                            .Bold(true)
                            .Color(Color.White);
                        documentScheduleyTable.Rows[0].Cells[6].Paragraphs[0].Append("Action Resource")
                           .Bold(true)
                           .Color(Color.White);
                        documentScheduleyTable.Rows[0].Cells[7].Paragraphs[0].Append("Action Date")
                           .Bold(true)
                           .Color(Color.White);

                        documentScheduleyTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        documentScheduleyTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        documentScheduleyTable.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;
                        documentScheduleyTable.Rows[0].Cells[3].FillColor = TABLE_HEADER_COLOR;
                        documentScheduleyTable.Rows[0].Cells[4].FillColor = TABLE_HEADER_COLOR;
                        documentScheduleyTable.Rows[0].Cells[5].FillColor = TABLE_HEADER_COLOR;
                        documentScheduleyTable.Rows[0].Cells[6].FillColor = TABLE_HEADER_COLOR;
                        documentScheduleyTable.Rows[0].Cells[7].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < currentRiskPlanModel.Schedules.Count + 1; i++)
                        {
                            documentScheduleyTable.Rows[i].Cells[0].Paragraphs[0].Append(currentRiskPlanModel.Schedules[i - 1].Rating);
                            documentScheduleyTable.Rows[i].Cells[1].Paragraphs[0].Append(currentRiskPlanModel.Schedules[i - 1].ID);
                            documentScheduleyTable.Rows[i].Cells[2].Paragraphs[0].Append(currentRiskPlanModel.Schedules[i - 1].PrevalantiveActions);
                            documentScheduleyTable.Rows[i].Cells[3].Paragraphs[0].Append(currentRiskPlanModel.Schedules[i - 1].ActionResource1);
                            documentScheduleyTable.Rows[i].Cells[4].Paragraphs[0].Append(currentRiskPlanModel.Schedules[i - 1].ActionDate1);
                            documentScheduleyTable.Rows[i].Cells[5].Paragraphs[0].Append(currentRiskPlanModel.Schedules[i - 1].ContingentActions);
                            documentScheduleyTable.Rows[i].Cells[6].Paragraphs[0].Append(currentRiskPlanModel.Schedules[i - 1].ActionResource2);
                            documentScheduleyTable.Rows[i].Cells[7].Paragraphs[0].Append(currentRiskPlanModel.Schedules[i - 1].ActionDate2);
                        }

                        //documentScheduleyTable.SetWidths(new float[] { 190, 303, 1094 });
                        document.InsertTable(documentScheduleyTable);

                        var assumptions = document.InsertParagraph("3.2 Assumptions")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");
                        assumptions.StyleId = "Heading2";
                        document.InsertParagraph(currentRiskPlanModel.Assumptions)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        var Constraints = document.InsertParagraph("3.3 Constraints")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");
                        Constraints.StyleId = "Heading2";

                        document.InsertParagraph(currentRiskPlanModel.Constraints)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        var RiskProcess = document.InsertParagraph("4 Risk Process")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");
                        RiskProcess.StyleId = "Heading1";

                        var activities = document.InsertParagraph("4.1 Activities")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");
                        activities.StyleId = "Heading2";

                        document.InsertParagraph(currentRiskPlanModel.Activities)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        var RolesHeading = document.InsertParagraph("4.2 Roles")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");
                        RolesHeading.StyleId = "Heading2";
                        document.InsertParagraph(currentRiskPlanModel.Roles)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        var DocumentsHeading = document.InsertParagraph("4.3 Documents")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");
                        DocumentsHeading.StyleId = "Heading2";
                        document.InsertParagraph(currentRiskPlanModel.Documents)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        var appendixHeading = document.InsertParagraph("5 Appendix")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");
                        appendixHeading.StyleId = "Heading1";
                        document.InsertParagraph(currentRiskPlanModel.Appendix)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

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
                //------------------------------------------------------------
                //-------------------------------------------------------------
            }

        }
    }
}

        