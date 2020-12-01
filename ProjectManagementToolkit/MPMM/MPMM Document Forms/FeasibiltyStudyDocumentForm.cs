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
    public partial class FeasibiltyStudyDocumentForm : Form
    {
        VersionControl<FeasibilityStudyModel> versionControl;
        FeasibilityStudyModel newFeasibilityStudyModel;
        FeasibilityStudyModel currentFeasibilityStudyModel;

        Color TABLE_HEADER_COLOR = Color.FromArgb(73, 173, 252);
        FeasibilityStudyModel feasibilityModel = new FeasibilityStudyModel();

        public FeasibiltyStudyDocumentForm()
        {
            InitializeComponent();
            LoadDocument();
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveDocument();
        }

        public void SaveDocument()
        {
            newFeasibilityStudyModel.ProjectName = Project_Name_tbx.Text;

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
            newFeasibilityStudyModel.Information = information;

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
            newFeasibilityStudyModel.Histories = histories;

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
            newFeasibilityStudyModel.Approvals = approvals;

            newFeasibilityStudyModel.ExecutiveSummary = Executive_Summary_tbx.Text;
            newFeasibilityStudyModel.BusinessEnvironment = Business_Environment_tbx.Text;
            newFeasibilityStudyModel.BusinessProblem = Business_Problem_tbx.Text;
            newFeasibilityStudyModel.BusinessOpportunity = Business_Opportunity_tbx.Text;
            newFeasibilityStudyModel.BusinessDrivers = Business_Drivers_tbx.Text;

            newFeasibilityStudyModel.PotentialSolution = Potential_Solutions_tbx.Text;
            newFeasibilityStudyModel.Solution1Description = Description_tbx.Text;
            newFeasibilityStudyModel.Solution1Assessment = Assessment_tbx.Text;
            newFeasibilityStudyModel.Solution1Assumption = Assumptions_tbx.Text;

            List<Result1> results1 = new List<Result1>();
            int ResultsrowCount1 = Results_dgv.RowCount;
            for (int i = 0; i < ResultsrowCount1 - 1; i++)
            {
                Result1 solution1 = new Result1();
                var Solution = Results_dgv.Rows[i].Cells[0].Value?.ToString() ?? "";
                var FeasibilityScore = Results_dgv.Rows[i].Cells[1].Value?.ToString() ?? "";
                var AssessmentMethod = Results_dgv.Rows[i].Cells[2].Value?.ToString() ?? "";
                solution1.Solution = Solution;
                solution1.FeasibilityScore = FeasibilityScore;
                solution1.AssessmentMethod = AssessmentMethod;
                results1.Add(solution1);
            }
            newFeasibilityStudyModel.Results1 = results1;

            List<Risk1> risks1 = new List<Risk1>();
            int RisksrowCount1 = Risks_dgv.RowCount;
            for (int i = 0; i < RisksrowCount1 - 1; i++)
            {
                Risk1 solution1 = new Risk1();
                var RiskDescription = Risks_dgv.Rows[i].Cells[0].Value?.ToString() ?? "";
                var RiskLikelihood = Risks_dgv.Rows[i].Cells[1].Value?.ToString() ?? "";
                var RiskImpact = Risks_dgv.Rows[i].Cells[2].Value?.ToString() ?? "";
                var ActionRequiredToMinRisk = Risks_dgv.Rows[i].Cells[3].Value?.ToString() ?? "";
                solution1.RiskDescription = RiskDescription;
                solution1.RiskLikelihood = RiskLikelihood;
                solution1.RiskImpact = RiskImpact;
                solution1.ActionRequiredToMinRisk = ActionRequiredToMinRisk;
                risks1.Add(solution1);
            }
            newFeasibilityStudyModel.Risks1 = risks1;

            List<Issue1> issues1 = new List<Issue1>();
            int IssuesrowCount1 = Issues_dgv.RowCount;
            for (int i = 0; i < ResultsrowCount1 - 1; i++)
            {
                Issue1 solution1 = new Issue1();
                var IssueDescription = Issues_dgv.Rows[i].Cells[0].Value?.ToString() ?? "";
                var IssuePriority = Issues_dgv.Rows[i].Cells[1].Value?.ToString() ?? "";
                var ActionRequiredToResolveRisk = Issues_dgv.Rows[i].Cells[2].Value?.ToString() ?? "";
                solution1.IssueDescription = IssueDescription;
                solution1.IssuePriority = IssuePriority;
                solution1.ActionRequiredToResolveRisk = ActionRequiredToResolveRisk;
                issues1.Add(solution1);
            }
            newFeasibilityStudyModel.Issues1 = issues1;

            newFeasibilityStudyModel.Solution2Description = Description2_tbx.Text;
            newFeasibilityStudyModel.Solution2Assessment = Assessment2_tbx.Text;
            newFeasibilityStudyModel.Solution2Assumption = Assumptions2_tbx.Text;

            List<Result2> results2 = new List<Result2>();
            int ResultsrowCount2 = Results_dgv.RowCount;
            for (int i = 0; i < ResultsrowCount2 - 1; i++)
            {
                Result2 solution2 = new Result2();
                var Solution = Results_dgv.Rows[i].Cells[0].Value?.ToString() ?? "";
                var FeasibilityScore = Results_dgv.Rows[i].Cells[1].Value?.ToString() ?? "";
                var AssessmentMethod = Results_dgv.Rows[i].Cells[2].Value?.ToString() ?? "";
                solution2.Solution = Solution;
                solution2.FeasibilityScore = FeasibilityScore;
                solution2.AssessmentMethod = AssessmentMethod;
                results2.Add(solution2);
            }
            newFeasibilityStudyModel.Results2 = results2;

            List<Risk2> risks2 = new List<Risk2>();
            int RisksrowCount2 = Risks_dgv.RowCount;
            for (int i = 0; i < RisksrowCount2 - 1; i++)
            {
                Risk2 solution2 = new Risk2();
                var RiskDescription = Risks_dgv.Rows[i].Cells[0].Value?.ToString() ?? "";
                var RiskLikelihood = Risks_dgv.Rows[i].Cells[1].Value?.ToString() ?? "";
                var RiskImpact = Risks_dgv.Rows[i].Cells[2].Value?.ToString() ?? "";
                var ActionRequiredToMinRisk = Risks_dgv.Rows[i].Cells[3].Value?.ToString() ?? "";
                solution2.RiskDescription = RiskDescription;
                solution2.RiskLikelihood = RiskLikelihood;
                solution2.RiskImpact = RiskImpact;
                solution2.ActionRequiredToMinRisk = ActionRequiredToMinRisk;
                risks2.Add(solution2);
            }
            newFeasibilityStudyModel.Risks2 = risks2;

            List<Issue2> issues2 = new List<Issue2>();
            int IssuesrowCount2 = Issues_dgv.RowCount;
            for (int i = 0; i < ResultsrowCount2 - 1; i++)
            {
                Issue2 solution2 = new Issue2();
                var IssueDescription = Issues_dgv.Rows[i].Cells[0].Value?.ToString() ?? "";
                var IssuePriority = Issues_dgv.Rows[i].Cells[1].Value?.ToString() ?? "";
                var ActionRequiredToResolveRisk = Issues_dgv.Rows[i].Cells[2].Value?.ToString() ?? "";
                solution2.IssueDescription = IssueDescription;
                solution2.IssuePriority = IssuePriority;
                solution2.ActionRequiredToResolveRisk = ActionRequiredToResolveRisk;
                issues2.Add(solution2);
            }
            newFeasibilityStudyModel.Issues2 = issues2;

            List<BusinessRequirements> requirements = new List<BusinessRequirements>();
            int rowCount = Business_Requirements_dgv.RowCount;
            for (int i = 0; i < rowCount - 1; i++)
            {
                BusinessRequirements business = new BusinessRequirements();
                var businessProblem = Business_Requirements_dgv.Rows[i].Cells[0].Value?.ToString() ?? "";
                var projectRequirement = Business_Requirements_dgv.Rows[i].Cells[1].Value?.ToString() ?? "";
                business.BusinessProblem = businessProblem;
                business.ProjectRequirement = projectRequirement;
                requirements.Add(business);
            }
            newFeasibilityStudyModel.Requirements = requirements;

            newFeasibilityStudyModel.Solution3Description = Description3_tbx.Text;
            newFeasibilityStudyModel.Solution3Assessment = Assessment3_tbx.Text;
            newFeasibilityStudyModel.Solution3Assumption = Assumptions3_tbx.Text;

            List<Result3> results3 = new List<Result3>();
            int ResultsrowCount3 = Results_dgv.RowCount;
            for (int i = 0; i < ResultsrowCount3 - 1; i++)
            {
                Result3 solution3 = new Result3();
                var Solution = Results_dgv.Rows[i].Cells[0].Value?.ToString() ?? "";
                var FeasibilityScore = Results_dgv.Rows[i].Cells[1].Value?.ToString() ?? "";
                var AssessmentMethod = Results_dgv.Rows[i].Cells[2].Value?.ToString() ?? "";
                solution3.Solution = Solution;
                solution3.FeasibilityScore = FeasibilityScore;
                solution3.AssessmentMethod = AssessmentMethod;
                results3.Add(solution3);
            }
            newFeasibilityStudyModel.Results3 = results3;

            List<Risk3> risks3 = new List<Risk3>();
            int RisksrowCount3 = Risks_dgv.RowCount;
            for (int i = 0; i < RisksrowCount3 - 1; i++)
            {
                Risk3 solution3 = new Risk3();
                var RiskDescription = Risks_dgv.Rows[i].Cells[0].Value?.ToString() ?? "";
                var RiskLikelihood = Risks_dgv.Rows[i].Cells[1].Value?.ToString() ?? "";
                var RiskImpact = Risks_dgv.Rows[i].Cells[2].Value?.ToString() ?? "";
                var ActionRequiredToMinRisk = Risks_dgv.Rows[i].Cells[3].Value?.ToString() ?? "";
                solution3.RiskDescription = RiskDescription;
                solution3.RiskLikelihood = RiskLikelihood;
                solution3.RiskImpact = RiskImpact;
                solution3.ActionRequiredToMinRisk = ActionRequiredToMinRisk;
                risks3.Add(solution3);
            }
            newFeasibilityStudyModel.Risks3 = risks3;

            List<Issue3> issues3 = new List<Issue3>();
            int IssuesrowCount3 = Issues_dgv.RowCount;
            for (int i = 0; i < ResultsrowCount3 - 1; i++)
            {
                Issue3 solution3 = new Issue3();
                var IssueDescription = Issues_dgv.Rows[i].Cells[0].Value?.ToString() ?? "";
                var IssuePriority = Issues_dgv.Rows[i].Cells[1].Value?.ToString() ?? "";
                var ActionRequiredToResolveRisk = Issues_dgv.Rows[i].Cells[2].Value?.ToString() ?? "";
                solution3.IssueDescription = IssueDescription;
                solution3.IssuePriority = IssuePriority;
                solution3.ActionRequiredToResolveRisk = ActionRequiredToResolveRisk;
                issues3.Add(solution3);
            }
            newFeasibilityStudyModel.Issues3 = issues3;

            newFeasibilityStudyModel.RankingCriteria = Ranking_Criteria_tbx.Text;

            List<RankingScore> rankingScores = new List<RankingScore>();

            int Ranking_Scores = Ranking_Scores_dgv.RowCount;
            for (int i = 0; i < Ranking_Scores - 1; i++)
            {
                RankingScore rankingScore = new RankingScore();
                var Criteria = Ranking_Scores_dgv.Rows[i].Cells[0].Value?.ToString() ?? "";
                var Score1 = Ranking_Scores_dgv.Rows[i].Cells[1].Value?.ToString() ?? "";
                var Weight1 = Ranking_Scores_dgv.Rows[i].Cells[2].Value?.ToString() ?? "";
                var Total1 = Ranking_Scores_dgv.Rows[i].Cells[3].Value?.ToString() ?? "";

                var Score2 = Ranking_Scores_dgv.Rows[i].Cells[4].Value?.ToString() ?? "";
                var Weight2 = Ranking_Scores_dgv.Rows[i].Cells[5].Value?.ToString() ?? "";
                var Total2 = Ranking_Scores_dgv.Rows[i].Cells[6].Value?.ToString() ?? "";

                var Score3 = Ranking_Scores_dgv.Rows[i].Cells[7].Value?.ToString() ?? "";
                var Weight3 = Ranking_Scores_dgv.Rows[i].Cells[8].Value?.ToString() ?? "";
                var Total3 = Ranking_Scores_dgv.Rows[i].Cells[9].Value?.ToString() ?? "";

                rankingScore.Criteria = Criteria;
                rankingScore.Score1 = Score1;
                rankingScore.Weight1 = Weight1;
                rankingScore.Total1 = Total1;
               
                rankingScore.Score2 = Score2;
                rankingScore.Weight2 = Weight2;
                rankingScore.Total2 = Total2;
            
                rankingScore.Score3 = Score3;
                rankingScore.Weight3 = Weight3;
                rankingScore.Total3 = Total3;

                rankingScores.Add(rankingScore);
            }
            newFeasibilityStudyModel.RankingScores = rankingScores;

            newFeasibilityStudyModel.FeasibilityResults = Feasibility_Result_tbx.Text;
            newFeasibilityStudyModel.SupportingDocumentation = Supporting_Documentation_btn.Text;

            List<VersionControl<FeasibilityStudyModel>.DocumentModel> documentModels = versionControl.DocumentModels;
            MessageBox.Show(JsonConvert.SerializeObject(newFeasibilityStudyModel), "save", MessageBoxButtons.OK);

            if (!versionControl.isEqual(currentFeasibilityStudyModel, newFeasibilityStudyModel))
            {
                VersionControl<FeasibilityStudyModel>.DocumentModel documentModel = new VersionControl<FeasibilityStudyModel>.DocumentModel(newFeasibilityStudyModel, DateTime.Now, VersionControl<FeasibilityStudyModel>.generateID());
                documentModels.Add(documentModel);
                versionControl.DocumentModels = documentModels;

                string json = JsonConvert.SerializeObject(versionControl);
                JsonHelper.saveDocument(json, Settings.Default.ProjectID, "FeasibilityStudy");
                //MessageBox.Show("Feasibility study form saved successfully", "save", MessageBoxButtons.OK);
            }
        }

        public void LoadDocument()
        {
            string json = JsonHelper.loadDocument(Settings.Default.ProjectID, "FeasibilityStudy");
            List<string[]> documentInfo = new List<string[]>();
            newFeasibilityStudyModel = new FeasibilityStudyModel();
            currentFeasibilityStudyModel = new FeasibilityStudyModel();
            if (json != "")
            {
                versionControl = JsonConvert.DeserializeObject<VersionControl<FeasibilityStudyModel>>(json);
                newFeasibilityStudyModel = JsonConvert.DeserializeObject<FeasibilityStudyModel>(versionControl.getLatest(versionControl.DocumentModels));
                currentFeasibilityStudyModel = JsonConvert.DeserializeObject<FeasibilityStudyModel>(versionControl.getLatest(versionControl.DocumentModels));

                Information information = currentFeasibilityStudyModel.Information;
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

                foreach (var row in currentFeasibilityStudyModel.Histories)
                {
                    Document_History_dgv.Rows.Add(new string[] { row.Version, row.IssueDate, row.Changes });
                }

                foreach (var row in currentFeasibilityStudyModel.Approvals)
                {
                    Document_Approvals_dgv.Rows.Add(new string[] { row.Role, row.Name, row.Signature, row.Date });
                }

                foreach (var row in currentFeasibilityStudyModel.Results1)
                {
                    Results_dgv.Rows.Add(new string[] { row.Solution, row.FeasibilityScore, row.AssessmentMethod });
                 
                }
                foreach (var row in currentFeasibilityStudyModel.Risks1)
                {
                   
                    Risks_dgv.Rows.Add(new string[] { row.RiskDescription, row.RiskLikelihood, row.RiskImpact });
                   
                }
                foreach (var row in currentFeasibilityStudyModel.Issues1)
                {
                    Issues_dgv.Rows.Add(new string[] { row.IssueDescription, row.IssuePriority, row.ActionRequiredToResolveRisk });
                }

                foreach (var row in currentFeasibilityStudyModel.Results2)
                {
                    Results2_dgv.Rows.Add(new string[] { row.Solution, row.FeasibilityScore, row.AssessmentMethod });

                }
                foreach (var row in currentFeasibilityStudyModel.Risks2)
                {

                    Risks2_dgv.Rows.Add(new string[] { row.RiskDescription, row.RiskLikelihood, row.RiskImpact });

                }
                foreach (var row in currentFeasibilityStudyModel.Issues2)
                {
                    Issues2_dgv.Rows.Add(new string[] { row.IssueDescription, row.IssuePriority, row.ActionRequiredToResolveRisk });
                }

                foreach (var row in currentFeasibilityStudyModel.Results3)
                {
                    Results3_dgv.Rows.Add(new string[] { row.Solution, row.FeasibilityScore, row.AssessmentMethod });

                }
                foreach (var row in currentFeasibilityStudyModel.Risks3)
                {

                    Risks3_dgv.Rows.Add(new string[] { row.RiskDescription, row.RiskLikelihood, row.RiskImpact });

                }
                foreach (var row in currentFeasibilityStudyModel.Issues3)
                {
                    Issues3_dgv.Rows.Add(new string[] { row.IssueDescription, row.IssuePriority, row.ActionRequiredToResolveRisk });
                }
                foreach (var row in currentFeasibilityStudyModel.Requirements)
                {
                   Business_Requirements_dgv.Rows.Add(new string[] { row.BusinessProblem, row.ProjectRequirement });
                }
                foreach (var row in currentFeasibilityStudyModel.RankingScores)
                {
                    Ranking_Scores_dgv.Rows.Add(new string[] { row.Criteria, row.Score1, row.Weight1, row.Total1, row.Score2, row.Weight2, row.Total2, row.Score3, row.Weight3, row.Total3 });
                }

                Project_Name_tbx.Text = currentFeasibilityStudyModel.ProjectName;
                Executive_Summary_tbx.Text = currentFeasibilityStudyModel.ExecutiveSummary;
                Business_Environment_tbx.Text = currentFeasibilityStudyModel.BusinessEnvironment;
                Business_Problem_tbx.Text = currentFeasibilityStudyModel.BusinessProblem;
                Business_Opportunity_tbx.Text = currentFeasibilityStudyModel.BusinessOpportunity;
                Business_Drivers_tbx.Text = currentFeasibilityStudyModel.BusinessDrivers;

                Potential_Solutions_tbx.Text = currentFeasibilityStudyModel.PotentialSolution;
                Description_tbx.Text = currentFeasibilityStudyModel.Solution1Description;
                Assessment_tbx.Text = currentFeasibilityStudyModel.Solution1Assessment;
                Assumptions_tbx.Text = currentFeasibilityStudyModel.Solution1Assumption;
                Description2_tbx.Text = currentFeasibilityStudyModel.Solution2Description;
                Assessment2_tbx.Text = currentFeasibilityStudyModel.Solution2Assessment;
                Assumptions2_tbx.Text = currentFeasibilityStudyModel.Solution2Assumption;
                Description3_tbx.Text = currentFeasibilityStudyModel.Solution3Description;
                Assessment3_tbx.Text = currentFeasibilityStudyModel.Solution3Assessment;
                Assumptions3_tbx.Text = currentFeasibilityStudyModel.Solution3Assumption;
                Feasibility_Result_tbx.Text = currentFeasibilityStudyModel.FeasibilityResults;
                Supporting_Documentation_btn.Text = currentFeasibilityStudyModel.SupportingDocumentation;
                Ranking_Criteria_tbx.Text = currentFeasibilityStudyModel.RankingCriteria;
            }
            else
            {
                versionControl = new VersionControl<FeasibilityStudyModel>();
                versionControl.DocumentModels = new List<VersionControl<FeasibilityStudyModel>.DocumentModel>();
                newFeasibilityStudyModel = new FeasibilityStudyModel();
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

        private void Risks_dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnExportToWord_Click(object sender, EventArgs e)
        {
            ExportToWord();
        }

        public void ExportToWord()
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

                        document.InsertParagraph("Feasibility Study \nFor " + currentFeasibilityStudyModel.ProjectName)
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
                        Document_Information.Rows[1].Cells[1].Paragraphs[0].Append(currentFeasibilityStudyModel.Information.DocumentID);

                        Document_Information.Rows[2].Cells[0].Paragraphs[0].Append("Document Owner");
                        Document_Information.Rows[2].Cells[1].Paragraphs[0].Append(currentFeasibilityStudyModel.Information.DocumentOwner);

                        Document_Information.Rows[3].Cells[0].Paragraphs[0].Append("Issue Date");
                        Document_Information.Rows[3].Cells[1].Paragraphs[0].Append(currentFeasibilityStudyModel.Information.IssueDate);

                        Document_Information.Rows[4].Cells[0].Paragraphs[0].Append("Last Saved Date");
                        Document_Information.Rows[4].Cells[1].Paragraphs[0].Append(currentFeasibilityStudyModel.Information.LastSavedDate);

                        Document_Information.Rows[5].Cells[0].Paragraphs[0].Append("File Name");
                        Document_Information.Rows[5].Cells[1].Paragraphs[0].Append(currentFeasibilityStudyModel.Information.FileName);
                        Document_Information.SetWidths(new float[] { 493, 1094 });
                        document.InsertTable(Document_Information);

                        document.InsertParagraph("\nDocument History\n")
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(14d).Alignment = Alignment.left;

                        var documentHistoryTable = document.AddTable(currentFeasibilityStudyModel.Histories.Count + 1, 3);
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

                        for (int i = 1; i < currentFeasibilityStudyModel.Histories.Count + 1; i++)
                        {
                            documentHistoryTable.Rows[i].Cells[0].Paragraphs[0].Append(currentFeasibilityStudyModel.Histories[i - 1].Version);
                            documentHistoryTable.Rows[i].Cells[1].Paragraphs[0].Append(currentFeasibilityStudyModel.Histories[i - 1].IssueDate);
                            documentHistoryTable.Rows[i].Cells[2].Paragraphs[0].Append(currentFeasibilityStudyModel.Histories[i - 1].Changes);

                        }

                        documentHistoryTable.SetWidths(new float[] { 190, 303, 1094 });
                        document.InsertTable(documentHistoryTable);

                        document.InsertParagraph("\nDocument Approvals\n")
                           .Font("Arial")
                           .Bold(true)
                           .FontSize(14d).Alignment = Alignment.left;

                        var documentApprovalTable = document.AddTable(currentFeasibilityStudyModel.Approvals.Count + 1, 4);
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

                        for (int i = 1; i < currentFeasibilityStudyModel.Approvals.Count + 1; i++)
                        {
                            documentApprovalTable.Rows[i].Cells[0].Paragraphs[0].Append(currentFeasibilityStudyModel.Approvals[i - 1].Role);
                            documentApprovalTable.Rows[i].Cells[1].Paragraphs[0].Append(currentFeasibilityStudyModel.Approvals[i - 1].Name);
                            documentApprovalTable.Rows[i].Cells[2].Paragraphs[0].Append(currentFeasibilityStudyModel.Approvals[i - 1].Signature);
                            documentApprovalTable.Rows[i].Cells[3].Paragraphs[0].Append(currentFeasibilityStudyModel.Approvals[i - 1].Date);
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

                        var executiveSummary = document.InsertParagraph("1 Executive Summary")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");
                        executiveSummary.StyleId = "Heading1";

                        document.InsertParagraph(currentFeasibilityStudyModel.ExecutiveSummary)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;



                        var problemStatement = document.InsertParagraph("2 Problem statement")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");
                        problemStatement.StyleId = "Heading1";

                        var bunisessEnvironmentSubHeading = document.InsertParagraph("2.1 Business Environment")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        document.InsertParagraph(currentFeasibilityStudyModel.BusinessEnvironment)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        bunisessEnvironmentSubHeading.StyleId = "Heading2";

                        var businessProblemSubHeading = document.InsertParagraph("2.2 Business problem")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");
                        document.InsertParagraph($"Business Problem\n\n{currentFeasibilityStudyModel.BusinessProblem}\n\n" +
                            $"Business Opportunity\n\n{currentFeasibilityStudyModel.BusinessOpportunity}\n")
                           .FontSize(11d)
                           .Color(Color.Black)
                           .Font("Arial").Alignment = Alignment.left;

                        businessProblemSubHeading.StyleId = "Heading2";

                        var requirementStatementHeading = document.InsertParagraph("3 Requirement Statement")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        requirementStatementHeading.StyleId = "Heading1";

                        var businessDriversSubheading = document.InsertParagraph("3.1 Business Drivers")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        document.InsertParagraph(currentFeasibilityStudyModel.BusinessDrivers)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        businessDriversSubheading.StyleId = "Heading2";

                        var businessRequirementsSubheading = document.InsertParagraph("3.2 Business Requirements")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");
                        
                        businessRequirementsSubheading.StyleId = "Heading2";

                        var businessRequirementsTable = document.AddTable(currentFeasibilityStudyModel.Requirements.Count + 1, 2);
                        businessRequirementsTable.Rows[0].Cells[0].Paragraphs[0].Append("Business Problem or Opportunity")
                            .Bold(true)
                            .Color(Color.White);
                        businessRequirementsTable.Rows[0].Cells[1].Paragraphs[0].Append("Project Requirements")
                            .Bold(true)
                            .Color(Color.White);

                        businessRequirementsTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        businessRequirementsTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                       

                        for (int i = 1; i < currentFeasibilityStudyModel.Requirements.Count + 1; i++)
                        {
                            businessRequirementsTable.Rows[i].Cells[0].Paragraphs[0].Append(currentFeasibilityStudyModel.Requirements[i - 1].BusinessProblem);
                            businessRequirementsTable.Rows[i].Cells[1].Paragraphs[0].Append(currentFeasibilityStudyModel.Requirements[i - 1].ProjectRequirement);
                        }

                        //businessRequirementsTable.SetWidths(new float[] { 190, 303, 1094 });
                        document.InsertTable(businessRequirementsTable);


                        var feasibilityAssessmentHeading = document.InsertParagraph("4 Feasibility Assessment")
                                                   .Bold()
                                                   .FontSize(12d)
                                                   .Color(Color.Black)
                                                   .Bold(true)
                                                   .Font("Arial");

                        feasibilityAssessmentHeading.StyleId = "Heading1";

                        var expenseFormSubheading = document.InsertParagraph("4.1 Potential Solutions")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        document.InsertParagraph(currentFeasibilityStudyModel.PotentialSolution)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        expenseFormSubheading.StyleId = "Heading2";


                        var solution1SubHeading = document.InsertParagraph("4.2 Solution 1")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");
                        solution1SubHeading.StyleId = "Heading2";


                        var description1SubHeading = document.InsertParagraph("4.2.1 Description")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        document.InsertParagraph(currentFeasibilityStudyModel.Solution1Description)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        description1SubHeading.StyleId = "Heading3";

                        var assessment1SubHeading = document.InsertParagraph("4.2.2 Assessment")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        document.InsertParagraph(currentFeasibilityStudyModel.Solution1Assessment)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        assessment1SubHeading.StyleId = "Heading3";

                        var results1SubHeading = document.InsertParagraph("4.2.3 Results")
                           .Bold()
                           .FontSize(12d)
                           .Color(Color.Black)
                           .Bold(true)
                           .Font("Arial");
                        results1SubHeading.StyleId = "Heading3";

                        var results1Table = document.AddTable(currentFeasibilityStudyModel.Results1.Count + 1, 3);
                        results1Table.Rows[0].Cells[0].Paragraphs[0].Append("Solution")
                            .Bold(true)
                            .Color(Color.White);
                        results1Table.Rows[0].Cells[1].Paragraphs[0].Append("Feasibility Score")
                            .Bold(true)
                            .Color(Color.White);
                        results1Table.Rows[0].Cells[2].Paragraphs[0].Append("Assessment Method")
                            .Bold(true)
                            .Color(Color.White);

                        results1Table.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        results1Table.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        results1Table.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < currentFeasibilityStudyModel.Results1.Count + 1; i++)
                        {
                            results1Table.Rows[i].Cells[0].Paragraphs[0].Append(currentFeasibilityStudyModel.Results1[i - 1].Solution);
                            results1Table.Rows[i].Cells[1].Paragraphs[0].Append(currentFeasibilityStudyModel.Results1[i - 1].FeasibilityScore);
                            results1Table.Rows[i].Cells[2].Paragraphs[0].Append(currentFeasibilityStudyModel.Results1[i - 1].AssessmentMethod);

                        }

                        //results1Table.SetWidths(new float[] { 190, 303, 1094 });
                        document.InsertTable(results1Table);

                        var risks1SubHeading = document.InsertParagraph("4.2.4 Risks")
                          .Bold()
                          .FontSize(12d)
                          .Color(Color.Black)
                          .Bold(true)
                          .Font("Arial");
                        risks1SubHeading.StyleId = "Heading3";

                        var risks1Table = document.AddTable(currentFeasibilityStudyModel.Risks1.Count + 1, 4);
                        risks1Table.Rows[0].Cells[0].Paragraphs[0].Append("Risk Description")
                            .Bold(true)
                            .Color(Color.White);
                        risks1Table.Rows[0].Cells[1].Paragraphs[0].Append("Risks Likelihood")
                            .Bold(true)
                            .Color(Color.White);
                        risks1Table.Rows[0].Cells[2].Paragraphs[0].Append("Risk Impact")
                            .Bold(true)
                            .Color(Color.White);
                        risks1Table.Rows[0].Cells[3].Paragraphs[0].Append("Actions Required to Mitigate Risk")
                            .Bold(true)
                            .Color(Color.White);

                        risks1Table.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        risks1Table.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        risks1Table.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;
                        risks1Table.Rows[0].Cells[3].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < currentFeasibilityStudyModel.Risks1.Count + 1; i++)
                        {
                            risks1Table.Rows[i].Cells[0].Paragraphs[0].Append(currentFeasibilityStudyModel.Risks1[i - 1].RiskDescription);
                            risks1Table.Rows[i].Cells[1].Paragraphs[0].Append(currentFeasibilityStudyModel.Risks1[i - 1].RiskLikelihood);
                            risks1Table.Rows[i].Cells[2].Paragraphs[0].Append(currentFeasibilityStudyModel.Risks1[i - 1].RiskImpact);
                            risks1Table.Rows[i].Cells[3].Paragraphs[0].Append(currentFeasibilityStudyModel.Risks1[i - 1].ActionRequiredToMinRisk);

                        }

                        //risks1Table.SetWidths(new float[] { 190, 303, 1094 });
                        document.InsertTable(risks1Table);

                        var issues1SubHeading = document.InsertParagraph("4.2.5 Issues")
                           .Bold()
                           .FontSize(12d)
                           .Color(Color.Black)
                           .Bold(true)
                           .Font("Arial");
                        issues1SubHeading.StyleId = "Heading3";

                        var issues1Table = document.AddTable(currentFeasibilityStudyModel.Issues1.Count + 1, 3);
                        issues1Table.Rows[0].Cells[0].Paragraphs[0].Append("Issue Description")
                            .Bold(true)
                            .Color(Color.White);
                        issues1Table.Rows[0].Cells[1].Paragraphs[0].Append("Issue Priority")
                            .Bold(true)
                            .Color(Color.White);
                        issues1Table.Rows[0].Cells[2].Paragraphs[0].Append("Actions Required to Resolve Issue")
                            .Bold(true)
                            .Color(Color.White);

                        issues1Table.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        issues1Table.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        issues1Table.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < currentFeasibilityStudyModel.Issues1.Count + 1; i++)
                        {
                            issues1Table.Rows[i].Cells[0].Paragraphs[0].Append(currentFeasibilityStudyModel.Issues1[i - 1].IssueDescription);
                            issues1Table.Rows[i].Cells[1].Paragraphs[0].Append(currentFeasibilityStudyModel.Issues1[i - 1].IssuePriority);
                            issues1Table.Rows[i].Cells[2].Paragraphs[0].Append(currentFeasibilityStudyModel.Issues1[i - 1].ActionRequiredToResolveRisk);

                        }

                        //issues1Table.SetWidths(new float[] { 190, 303, 1094 });
                        document.InsertTable(issues1Table);

                        var assumptions1SubHeading = document.InsertParagraph("4.2.6 Assumptions")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        document.InsertParagraph(currentFeasibilityStudyModel.Solution1Assumption)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        assumptions1SubHeading.StyleId = "Heading3";
                        //------------------------------------------------------------------------------------------------------------------------

                        var solution2SubHeading = document.InsertParagraph("4.3 Solution 2")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");
                        solution2SubHeading.StyleId = "Heading2";


                        var description2SubHeading = document.InsertParagraph("4.3.1 Description")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        document.InsertParagraph(currentFeasibilityStudyModel.Solution2Description)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        description2SubHeading.StyleId = "Heading3";

                        var assessment2SubHeading = document.InsertParagraph("4.3.2 Assessment")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        document.InsertParagraph(currentFeasibilityStudyModel.Solution2Assessment)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        assessment2SubHeading.StyleId = "Heading3";

                        var results2SubHeading = document.InsertParagraph("4.3.3 Results")
                           .Bold()
                           .FontSize(12d)
                           .Color(Color.Black)
                           .Bold(true)
                           .Font("Arial");
                        results2SubHeading.StyleId = "Heading3";

                        var results2Table = document.AddTable(currentFeasibilityStudyModel.Results2.Count + 1, 3);
                        results2Table.Rows[0].Cells[0].Paragraphs[0].Append("Solution")
                            .Bold(true)
                            .Color(Color.White);
                        results2Table.Rows[0].Cells[1].Paragraphs[0].Append("Feasibility Score")
                            .Bold(true)
                            .Color(Color.White);
                        results2Table.Rows[0].Cells[2].Paragraphs[0].Append("Assessment Method")
                            .Bold(true)
                            .Color(Color.White);

                        results2Table.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        results2Table.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        results2Table.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < currentFeasibilityStudyModel.Results2.Count + 1; i++)
                        {
                            results2Table.Rows[i].Cells[0].Paragraphs[0].Append(currentFeasibilityStudyModel.Results2[i - 1].Solution);
                            results2Table.Rows[i].Cells[1].Paragraphs[0].Append(currentFeasibilityStudyModel.Results2[i - 1].FeasibilityScore);
                            results2Table.Rows[i].Cells[2].Paragraphs[0].Append(currentFeasibilityStudyModel.Results2[i - 1].AssessmentMethod);

                        }

                        //results2Table.SetWidths(new float[] { 190, 303, 1094 });
                        document.InsertTable(results2Table);

                        var risks2SubHeading = document.InsertParagraph("4.3.4 Risks")
                          .Bold()
                          .FontSize(12d)
                          .Color(Color.Black)
                          .Bold(true)
                          .Font("Arial");
                        risks1SubHeading.StyleId = "Heading3";

                        var risks2Table = document.AddTable(currentFeasibilityStudyModel.Risks2.Count + 1, 4);
                        risks2Table.Rows[0].Cells[0].Paragraphs[0].Append("Risk Description")
                            .Bold(true)
                            .Color(Color.White);
                        risks2Table.Rows[0].Cells[1].Paragraphs[0].Append("Risks Likelihood")
                            .Bold(true)
                            .Color(Color.White);
                        risks2Table.Rows[0].Cells[2].Paragraphs[0].Append("Risk Impact")
                            .Bold(true)
                            .Color(Color.White);
                        risks2Table.Rows[0].Cells[3].Paragraphs[0].Append("Actions Required to Mitigate Risk")
                            .Bold(true)
                            .Color(Color.White);

                        risks2Table.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        risks2Table.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        risks2Table.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;
                        risks2Table.Rows[0].Cells[3].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < currentFeasibilityStudyModel.Risks2.Count + 1; i++)
                        {
                            risks2Table.Rows[i].Cells[0].Paragraphs[0].Append(currentFeasibilityStudyModel.Risks2[i - 1].RiskDescription);
                            risks2Table.Rows[i].Cells[1].Paragraphs[0].Append(currentFeasibilityStudyModel.Risks2[i - 1].RiskLikelihood);
                            risks2Table.Rows[i].Cells[2].Paragraphs[0].Append(currentFeasibilityStudyModel.Risks2[i - 1].RiskImpact);
                            risks2Table.Rows[i].Cells[3].Paragraphs[0].Append(currentFeasibilityStudyModel.Risks2[i - 1].ActionRequiredToMinRisk);

                        }

                        //risks2Table.SetWidths(new float[] { 190, 303, 1094 });
                        document.InsertTable(risks2Table);

                        var issues2SubHeading = document.InsertParagraph("4.3.5 Issues")
                           .Bold()
                           .FontSize(12d)
                           .Color(Color.Black)
                           .Bold(true)
                           .Font("Arial");
                        issues2SubHeading.StyleId = "Heading3";

                        var issues2Table = document.AddTable(currentFeasibilityStudyModel.Issues2.Count + 1, 3);
                        issues2Table.Rows[0].Cells[0].Paragraphs[0].Append("Issue Description")
                            .Bold(true)
                            .Color(Color.White);
                        issues2Table.Rows[0].Cells[1].Paragraphs[0].Append("Issue Priority")
                            .Bold(true)
                            .Color(Color.White);
                        issues2Table.Rows[0].Cells[2].Paragraphs[0].Append("Actions Required to Resolve Issue")
                            .Bold(true)
                            .Color(Color.White);

                        issues2Table.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        issues2Table.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        issues2Table.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < currentFeasibilityStudyModel.Issues1.Count + 1; i++)
                        {
                            issues2Table.Rows[i].Cells[0].Paragraphs[0].Append(currentFeasibilityStudyModel.Issues2[i - 1].IssueDescription);
                            issues2Table.Rows[i].Cells[1].Paragraphs[0].Append(currentFeasibilityStudyModel.Issues2[i - 1].IssuePriority);
                            issues2Table.Rows[i].Cells[2].Paragraphs[0].Append(currentFeasibilityStudyModel.Issues2[i - 1].ActionRequiredToResolveRisk);

                        }

                        //issues2Table.SetWidths(new float[] { 190, 303, 1094 });
                        document.InsertTable(issues2Table);

                        var assumptions2SubHeading = document.InsertParagraph("4.2.6 Assumptions")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        document.InsertParagraph(currentFeasibilityStudyModel.Solution2Assumption)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        assumptions2SubHeading.StyleId = "Heading3";
                        //---------------------------------------------------------------------------------------------------------------------------------

                        var solution3SubHeading = document.InsertParagraph("4.4 Solution 2")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");
                        solution3SubHeading.StyleId = "Heading2";


                        var description3SubHeading = document.InsertParagraph("4.4.1 Description")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        document.InsertParagraph(currentFeasibilityStudyModel.Solution3Description)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        description3SubHeading.StyleId = "Heading3";

                        var assessment3SubHeading = document.InsertParagraph("4.4.2 Assessment")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        document.InsertParagraph(currentFeasibilityStudyModel.Solution3Assessment)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        assessment3SubHeading.StyleId = "Heading3";

                        var results3SubHeading = document.InsertParagraph("4.4.3 Results")
                           .Bold()
                           .FontSize(12d)
                           .Color(Color.Black)
                           .Bold(true)
                           .Font("Arial");
                        results3SubHeading.StyleId = "Heading3";

                        var results3Table = document.AddTable(currentFeasibilityStudyModel.Results3.Count + 1, 3);
                        results3Table.Rows[0].Cells[0].Paragraphs[0].Append("Solution")
                            .Bold(true)
                            .Color(Color.White);
                        results3Table.Rows[0].Cells[1].Paragraphs[0].Append("Feasibility Score")
                            .Bold(true)
                            .Color(Color.White);
                        results3Table.Rows[0].Cells[2].Paragraphs[0].Append("Assessment Method")
                            .Bold(true)
                            .Color(Color.White);

                        results3Table.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        results3Table.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        results3Table.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < currentFeasibilityStudyModel.Results3.Count + 1; i++)
                        {
                            results3Table.Rows[i].Cells[0].Paragraphs[0].Append(currentFeasibilityStudyModel.Results3[i - 1].Solution);
                            results3Table.Rows[i].Cells[1].Paragraphs[0].Append(currentFeasibilityStudyModel.Results3[i - 1].FeasibilityScore);
                            results3Table.Rows[i].Cells[2].Paragraphs[0].Append(currentFeasibilityStudyModel.Results3[i - 1].AssessmentMethod);

                        }

                        //results3Table.SetWidths(new float[] { 190, 303, 1094 });
                        document.InsertTable(results3Table);

                        var risks3SubHeading = document.InsertParagraph("4.4.4 Risks")
                          .Bold()
                          .FontSize(12d)
                          .Color(Color.Black)
                          .Bold(true)
                          .Font("Arial");
                        risks3SubHeading.StyleId = "Heading3";

                        var risks3Table = document.AddTable(currentFeasibilityStudyModel.Risks3.Count + 1, 4);
                        risks3Table.Rows[0].Cells[0].Paragraphs[0].Append("Risk Description")
                            .Bold(true)
                            .Color(Color.White);
                        risks3Table.Rows[0].Cells[1].Paragraphs[0].Append("Risks Likelihood")
                            .Bold(true)
                            .Color(Color.White);
                        risks3Table.Rows[0].Cells[2].Paragraphs[0].Append("Risk Impact")
                            .Bold(true)
                            .Color(Color.White);
                        risks3Table.Rows[0].Cells[3].Paragraphs[0].Append("Actions Required to Mitigate Risk")
                            .Bold(true)
                            .Color(Color.White);

                        risks3Table.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        risks3Table.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        risks3Table.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;
                        risks3Table.Rows[0].Cells[3].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < currentFeasibilityStudyModel.Risks3.Count + 1; i++)
                        {
                            risks3Table.Rows[i].Cells[0].Paragraphs[0].Append(currentFeasibilityStudyModel.Risks3[i - 1].RiskDescription);
                            risks3Table.Rows[i].Cells[1].Paragraphs[0].Append(currentFeasibilityStudyModel.Risks3[i - 1].RiskLikelihood);
                            risks3Table.Rows[i].Cells[2].Paragraphs[0].Append(currentFeasibilityStudyModel.Risks3[i - 1].RiskImpact);
                            risks3Table.Rows[i].Cells[3].Paragraphs[0].Append(currentFeasibilityStudyModel.Risks3[i - 1].ActionRequiredToMinRisk);

                        }

                        //risks3Table.SetWidths(new float[] { 190, 303, 1094 });
                        document.InsertTable(risks3Table);

                        var issues3SubHeading = document.InsertParagraph("4.4.5 Issues")
                           .Bold()
                           .FontSize(12d)
                           .Color(Color.Black)
                           .Bold(true)
                           .Font("Arial");
                        issues3SubHeading.StyleId = "Heading3";

                        var issues3Table = document.AddTable(currentFeasibilityStudyModel.Issues3.Count + 1, 3);
                        issues3Table.Rows[0].Cells[0].Paragraphs[0].Append("Issue Description")
                            .Bold(true)
                            .Color(Color.White);
                        issues3Table.Rows[0].Cells[1].Paragraphs[0].Append("Issue Priority")
                            .Bold(true)
                            .Color(Color.White);
                        issues3Table.Rows[0].Cells[2].Paragraphs[0].Append("Actions Required to Resolve Issue")
                            .Bold(true)
                            .Color(Color.White);

                        issues3Table.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        issues3Table.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        issues3Table.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < currentFeasibilityStudyModel.Issues3.Count + 1; i++)
                        {
                            issues3Table.Rows[i].Cells[0].Paragraphs[0].Append(currentFeasibilityStudyModel.Issues3[i - 1].IssueDescription);
                            issues3Table.Rows[i].Cells[1].Paragraphs[0].Append(currentFeasibilityStudyModel.Issues3[i - 1].IssuePriority);
                            issues3Table.Rows[i].Cells[2].Paragraphs[0].Append(currentFeasibilityStudyModel.Issues3[i - 1].ActionRequiredToResolveRisk);

                        }

                        //issues3Table.SetWidths(new float[] { 190, 303, 1094 });
                        document.InsertTable(issues3Table);

                        var assumptions3SubHeading = document.InsertParagraph("4.2.6 Assumptions")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        document.InsertParagraph(currentFeasibilityStudyModel.Solution3Assumption)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        assumptions3SubHeading.StyleId = "Heading3";

                        var feasibilityRankingHeading = document.InsertParagraph("5 Feasibility Ranking")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        feasibilityRankingHeading.StyleId = "Heading1";

                        var rankingCriteriaSubHeading = document.InsertParagraph("5.1 Ranking Criteria")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        document.InsertParagraph(currentFeasibilityStudyModel.RankingCriteria)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        rankingCriteriaSubHeading.StyleId = "Heading2";

                        //---------------------------------------------------------------------------------------------------------------------

                        var rankingScoresSubHeading = document.InsertParagraph("5.2 Ranking Scores")
                           .Bold()
                           .FontSize(12d)
                           .Color(Color.Black)
                           .Bold(true)
                           .Font("Arial");
                        rankingScoresSubHeading.StyleId = "Heading2";

                        var rankingScoresTable = document.AddTable(currentFeasibilityStudyModel.RankingScores.Count + 1, 10);
                        rankingScoresTable.Rows[0].Cells[0].Paragraphs[0].Append("Criteria")
                            .Bold(true)
                            .Color(Color.White);
                        rankingScoresTable.Rows[0].Cells[1].Paragraphs[0].Append("Score")
                            .Bold(true)
                            .Color(Color.White);
                        rankingScoresTable.Rows[0].Cells[2].Paragraphs[0].Append("Weight")
                            .Bold(true)
                            .Color(Color.White);
                        rankingScoresTable.Rows[0].Cells[3].Paragraphs[0].Append("Total")
                            .Bold(true)
                            .Color(Color.White);
                        rankingScoresTable.Rows[0].Cells[4].Paragraphs[0].Append("Score")
                            .Bold(true)
                            .Color(Color.White);
                        rankingScoresTable.Rows[0].Cells[5].Paragraphs[0].Append("Weight")
                            .Bold(true)
                            .Color(Color.White);
                        rankingScoresTable.Rows[0].Cells[6].Paragraphs[0].Append("Total")
                            .Bold(true)
                            .Color(Color.White);
                        rankingScoresTable.Rows[0].Cells[7].Paragraphs[0].Append("Score")
                            .Bold(true)
                            .Color(Color.White);
                        rankingScoresTable.Rows[0].Cells[8].Paragraphs[0].Append("Weight")
                            .Bold(true)
                            .Color(Color.White);
                        rankingScoresTable.Rows[0].Cells[9].Paragraphs[0].Append("Total")
                            .Bold(true)
                            .Color(Color.White);
                        
                        rankingScoresTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        rankingScoresTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        rankingScoresTable.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;
                        rankingScoresTable.Rows[0].Cells[3].FillColor = TABLE_HEADER_COLOR;
                        rankingScoresTable.Rows[0].Cells[4].FillColor = TABLE_HEADER_COLOR;
                        rankingScoresTable.Rows[0].Cells[5].FillColor = TABLE_HEADER_COLOR;
                        rankingScoresTable.Rows[0].Cells[6].FillColor = TABLE_HEADER_COLOR;
                        rankingScoresTable.Rows[0].Cells[7].FillColor = TABLE_HEADER_COLOR;
                        rankingScoresTable.Rows[0].Cells[8].FillColor = TABLE_HEADER_COLOR;
                        rankingScoresTable.Rows[0].Cells[9].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < currentFeasibilityStudyModel.RankingScores.Count + 1; i++)
                        {
                            rankingScoresTable.Rows[i].Cells[0].Paragraphs[0].Append(currentFeasibilityStudyModel.RankingScores[i - 1].Criteria);
                            rankingScoresTable.Rows[i].Cells[1].Paragraphs[0].Append(currentFeasibilityStudyModel.RankingScores[i - 1].Score1);
                            rankingScoresTable.Rows[i].Cells[2].Paragraphs[0].Append(currentFeasibilityStudyModel.RankingScores[i - 1].Weight1);
                            rankingScoresTable.Rows[i].Cells[3].Paragraphs[0].Append(currentFeasibilityStudyModel.RankingScores[i - 1].Total1);
                            rankingScoresTable.Rows[i].Cells[4].Paragraphs[0].Append(currentFeasibilityStudyModel.RankingScores[i - 1].Score2);
                            rankingScoresTable.Rows[i].Cells[5].Paragraphs[0].Append(currentFeasibilityStudyModel.RankingScores[i - 1].Weight2);
                            rankingScoresTable.Rows[i].Cells[6].Paragraphs[0].Append(currentFeasibilityStudyModel.RankingScores[i - 1].Total2);
                            rankingScoresTable.Rows[i].Cells[7].Paragraphs[0].Append(currentFeasibilityStudyModel.RankingScores[i - 1].Score3);
                            rankingScoresTable.Rows[i].Cells[8].Paragraphs[0].Append(currentFeasibilityStudyModel.RankingScores[i - 1].Weight3);
                            rankingScoresTable.Rows[i].Cells[9].Paragraphs[0].Append(currentFeasibilityStudyModel.RankingScores[i - 1].Total3);
                        }

                        //rankingScoresTable.SetWidths(new float[] { 190, 303, 1094 });
                        document.InsertTable(rankingScoresTable);

                        var feasibilityResultsHeading = document.InsertParagraph("6 Feasibility Results")
                           .Bold()
                           .FontSize(12d)
                           .Color(Color.Black)
                           .Bold(true)
                           .Font("Arial");
                        feasibilityResultsHeading.StyleId = "Heading1";

                        document.InsertParagraph(currentFeasibilityStudyModel.FeasibilityResults)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        var appendixHeading = document.InsertParagraph("7 Appendix")
                           .Bold()
                           .FontSize(12d)
                           .Color(Color.Black)
                           .Bold(true)
                           .Font("Arial");
                        appendixHeading.StyleId = "Heading1";

                        var supportDocSubHeading = document.InsertParagraph("7.1 Supporting Documentation")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        document.InsertParagraph(currentFeasibilityStudyModel.SupportingDocumentation)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        supportDocSubHeading.StyleId = "Heading2";

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
    }
}
