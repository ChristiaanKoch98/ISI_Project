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

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Forms
{
    public partial class FeasibiltyStudyDocumentForm : Form
    {
        VersionControl<FeasibilityStudyModel> versionControl;
        FeasibilityStudyModel newFeasibilityStudyModel;
        FeasibilityStudyModel currentFeasibilityStudyModel;

        FeasibilityStudyModel feasibility;
        public FeasibiltyStudyDocumentForm()
        {
            InitializeComponent();
            feasibility = new FeasibilityStudyModel();
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
                var Score1 = Ranking_Scores_dgv.Rows[i].Cells[0].Value?.ToString() ?? "";
                var Weight1 = Ranking_Scores_dgv.Rows[i].Cells[1].Value?.ToString() ?? "";
                var Total1 = Ranking_Scores_dgv.Rows[i].Cells[2].Value?.ToString() ?? "";

                var Score2 = Ranking_Scores_dgv.Rows[i].Cells[3].Value?.ToString() ?? "";
                var Weight2 = Ranking_Scores_dgv.Rows[i].Cells[4].Value?.ToString() ?? "";
                var Total2 = Ranking_Scores_dgv.Rows[i].Cells[5].Value?.ToString() ?? "";

                var Score3 = Ranking_Scores_dgv.Rows[i].Cells[6].Value?.ToString() ?? "";
                var Weight3 = Ranking_Scores_dgv.Rows[i].Cells[7].Value?.ToString() ?? "";
                var Total3 = Ranking_Scores_dgv.Rows[i].Cells[8].Value?.ToString() ?? "";

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
                MessageBox.Show("Feasibility study form saved successfully", "save", MessageBoxButtons.OK);
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
    }
}
