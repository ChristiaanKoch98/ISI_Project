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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Enter_btn_Click(object sender, EventArgs e)
        {
            if (Project_Name_tbx.Text.Length > 0)
            {
                feasibility.ProjectName = Project_Name_tbx.Text;
                newFeasibilityStudyModel.ProjectName = feasibility.ProjectName;

            }
        }

        private void Executive_Summary_btn_Click(object sender, EventArgs e)
        {
            if (Executive_Summary_tbx.Text.Length > 0)
            {
                feasibility.ExecutiveSummary = Executive_Summary_tbx.Text;
                newFeasibilityStudyModel.ExecutiveSummary = feasibility.ExecutiveSummary;
            }
        }

        private void Problem_Statement_btn_Click(object sender, EventArgs e)
        {
            if (Business_Environment_tbx.Text.Length > 0 && Business_Problem_tbx.Text.Length > 0 && Business_Opportunity_tbx.Text.Length > 0)
            {
                feasibility.BusinessEnvironment = Business_Environment_tbx.Text;
                feasibility.BusinessProblem = Business_Problem_tbx.Text;
                feasibility.BusinessOpportunity = Business_Opportunity_tbx.Text;

                newFeasibilityStudyModel.BusinessEnvironment = feasibility.BusinessEnvironment;
                newFeasibilityStudyModel.BusinessProblem = feasibility.BusinessProblem;
                feasibility.BusinessOpportunity = feasibility.BusinessOpportunity;
            }
        }

        private void Requirements_Statement_btn_Click(object sender, EventArgs e)
        {
            if (Business_Drivers_tbx.Text.Length > 0)
            {
                feasibility.BusinessDrivers = Business_Drivers_tbx.Text;
                newFeasibilityStudyModel.BusinessDrivers = feasibility.BusinessDrivers;


                List<BusinessRequirements> list = new List<BusinessRequirements>();
                int rowCount = Business_Requirements_dgv.RowCount;
                for (int i = 0; i < rowCount - 1; i++)
                {
                    BusinessRequirements business = new BusinessRequirements();
                    var businessProblem = Business_Requirements_dgv.Rows[i].Cells[0].Value?.ToString() ?? "";
                    var projectRequirement = Business_Requirements_dgv.Rows[i].Cells[1].Value?.ToString() ?? "";
                    business.BusinessProblem = businessProblem;
                    business.ProjectRequirement = projectRequirement;
                    list.Add(business);

                }
            }

        }

        private void Feasibility_Assessment_btn_Click(object sender, EventArgs e)
        {
            if (Potential_Solutions_tbx.Text.Length > 0)
            {
                feasibility.PotentialSolution = Potential_Solutions_tbx.Text;
                newFeasibilityStudyModel.PotentialSolution = feasibility.PotentialSolution;
            }
        }

        private void Solution_1_btn_Click(object sender, EventArgs e)
        {
            if (Description_tbx.Text.Length > 0 && Assessment_tbx.Text.Length > 0 && Assumptions_tbx.Text.Length > 0)
            {
                feasibility.Solution1Description = Description_tbx.Text;
                feasibility.Solution1Assessment = Assessment_tbx.Text;
                feasibility.Solution1Assumption = Assumptions_tbx.Text;

                newFeasibilityStudyModel.Solution1Description = feasibility.Solution1Description;
                newFeasibilityStudyModel.Solution1Assessment = feasibility.Solution1Assessment;
                newFeasibilityStudyModel.Solution1Assumption = feasibility.Solution1Assumption;

                List<Solution1> results = new List<Solution1>();
                int ResultsrowCount = Results_dgv.RowCount;
                for (int i = 0; i < ResultsrowCount - 1; i++)
                {
                    Solution1 solution1 = new Solution1();
                    var Solution = Results_dgv.Rows[i].Cells[0].Value?.ToString() ?? "";
                    var FeasibilityScore = Results_dgv.Rows[i].Cells[1].Value?.ToString() ?? "";
                    var AssessmentMethod = Results_dgv.Rows[i].Cells[2].Value?.ToString() ?? "";
                    solution1.Solution = Solution;
                    solution1.FeasibilityScore = FeasibilityScore;
                    solution1.AssessmentMethod = AssessmentMethod;
                    results.Add(solution1);
                }
                newFeasibilityStudyModel.solution1 = results;

                List<Solution1> risks = new List<Solution1>();
                int RisksrowCount = Risks_dgv.RowCount;
                for (int i = 0; i < RisksrowCount - 1; i++)
                {
                    Solution1 solution1 = new Solution1();
                    var RiskDescription = Risks_dgv.Rows[i].Cells[0].Value?.ToString() ?? "";
                    var RiskLikelihood = Risks_dgv.Rows[i].Cells[1].Value?.ToString() ?? "";
                    var RiskImpact = Risks_dgv.Rows[i].Cells[2].Value?.ToString() ?? "";
                    var ActionRequiredToMinRisk = Risks_dgv.Rows[i].Cells[3].Value?.ToString() ?? "";
                    solution1.RiskDescription = RiskDescription;
                    solution1.RiskLikelihood = RiskLikelihood;
                    solution1.RiskImpact = RiskImpact;
                    solution1.ActionRequiredToMinRisk = ActionRequiredToMinRisk;
                    risks.Add(solution1);
                }
                newFeasibilityStudyModel.solution1 = risks;

                List<Solution1> issues = new List<Solution1>();
                int IssuesrowCount = Issues_dgv.RowCount;
                for (int i = 0; i < ResultsrowCount - 1; i++)
                {
                    Solution1 solution1 = new Solution1();
                    var IssueDescription = Issues_dgv.Rows[i].Cells[0].Value?.ToString() ?? "";
                    var IssuePriority = Issues_dgv.Rows[i].Cells[1].Value?.ToString() ?? "";
                    var ActionRequiredToResolveRisk = Issues_dgv.Rows[i].Cells[2].Value?.ToString() ?? "";
                    solution1.IssueDescription = IssueDescription;
                    solution1.IssuePriority = IssuePriority;
                    solution1.ActionRequiredToResolveRisk = ActionRequiredToResolveRisk;
                    issues.Add(solution1);
                }
                newFeasibilityStudyModel.solution1 = issues;
            }
        }

        private void Solution_2_btn_Click(object sender, EventArgs e)
        {
            if (Description2_tbx.Text.Length > 0 && Assessment2_tbx.Text.Length > 0 && Assumptions2_tbx.Text.Length > 0)
            {
                feasibility.Solution2Description = Description2_tbx.Text;
                feasibility.Solution2Assessment = Assessment2_tbx.Text;
                feasibility.Solution2Assumption = Assumptions2_tbx.Text;

                newFeasibilityStudyModel.Solution2Description = feasibility.Solution1Description;
                newFeasibilityStudyModel.Solution2Assessment = feasibility.Solution1Assessment;
                newFeasibilityStudyModel.Solution2Assumption = feasibility.Solution1Assumption;

                List<Solution2> results = new List<Solution2>();
                int ResultsrowCount = Results_dgv.RowCount;
                for (int i = 0; i < ResultsrowCount - 1; i++)
                {
                    Solution2 solution2 = new Solution2();
                    var Solution = Results_dgv.Rows[i].Cells[0].Value?.ToString() ?? "";
                    var FeasibilityScore = Results_dgv.Rows[i].Cells[1].Value?.ToString() ?? "";
                    var AssessmentMethod = Results_dgv.Rows[i].Cells[2].Value?.ToString() ?? "";
                    solution2.Solution = Solution;
                    solution2.FeasibilityScore = FeasibilityScore;
                    solution2.AssessmentMethod = AssessmentMethod;
                    results.Add(solution2);
                }

                newFeasibilityStudyModel.solution2 = results;

                List<Solution2> risks = new List<Solution2>();
                int RisksrowCount = Risks_dgv.RowCount;
                for (int i = 0; i < RisksrowCount - 1; i++)
                {
                    Solution2 solution2 = new Solution2();
                    var RiskDescription = Risks_dgv.Rows[i].Cells[0].Value?.ToString() ?? "";
                    var RiskLikelihood = Risks_dgv.Rows[i].Cells[1].Value?.ToString() ?? "";
                    var RiskImpact = Risks_dgv.Rows[i].Cells[2].Value?.ToString() ?? "";
                    var ActionRequiredToMinRisk = Risks_dgv.Rows[i].Cells[3].Value?.ToString() ?? "";
                    solution2.RiskDescription = RiskDescription;
                    solution2.RiskLikelihood = RiskLikelihood;
                    solution2.RiskImpact = RiskImpact;
                    solution2.ActionRequiredToMinRisk = ActionRequiredToMinRisk;
                    risks.Add(solution2);
                }
                newFeasibilityStudyModel.solution2 = risks;

                List<Solution2> issues = new List<Solution2>();
                int IssuesrowCount = Issues_dgv.RowCount;
                for (int i = 0; i < ResultsrowCount - 1; i++)
                {
                    Solution2 solution2 = new Solution2();
                    var IssueDescription = Issues_dgv.Rows[i].Cells[0].Value?.ToString() ?? "";
                    var IssuePriority = Issues_dgv.Rows[i].Cells[1].Value?.ToString() ?? "";
                    var ActionRequiredToResolveRisk = Issues_dgv.Rows[i].Cells[2].Value?.ToString() ?? "";
                    solution2.IssueDescription = IssueDescription;
                    solution2.IssuePriority = IssuePriority;
                    solution2.ActionRequiredToResolveRisk = ActionRequiredToResolveRisk;
                    issues.Add(solution2);
                }
                newFeasibilityStudyModel.solution2 = issues;
            }
        }

        private void Solution_3_btn_Click(object sender, EventArgs e)
        {
            if (Description3_tbx.Text.Length > 0 && Assessment3_tbx.Text.Length > 0 && Assumptions3_tbx.Text.Length > 0)
            {
                feasibility.Solution3Description = Description3_tbx.Text;
                feasibility.Solution3Assessment = Assessment3_tbx.Text;
                feasibility.Solution3Assumption = Assumptions3_tbx.Text;

                newFeasibilityStudyModel.Solution3Description = feasibility.Solution1Description;
                newFeasibilityStudyModel.Solution3Assessment = feasibility.Solution1Assessment;
                newFeasibilityStudyModel.Solution3Assumption = feasibility.Solution1Assumption;

                List<Solution3> results = new List<Solution3>();
                int ResultsrowCount = Results_dgv.RowCount;
                for (int i = 0; i < ResultsrowCount - 1; i++)
                {
                    Solution3 solution3 = new Solution3();
                    var Solution = Results_dgv.Rows[i].Cells[0].Value?.ToString() ?? "";
                    var FeasibilityScore = Results_dgv.Rows[i].Cells[1].Value?.ToString() ?? "";
                    var AssessmentMethod = Results_dgv.Rows[i].Cells[2].Value?.ToString() ?? "";
                    solution3.Solution = Solution;
                    solution3.FeasibilityScore = FeasibilityScore;
                    solution3.AssessmentMethod = AssessmentMethod;
                    results.Add(solution3);
                }
                newFeasibilityStudyModel.solution3 = results;

                List<Solution3> risks = new List<Solution3>();
                int RisksrowCount = Risks_dgv.RowCount;
                for (int i = 0; i < RisksrowCount - 1; i++)
                {
                    Solution3 solution3 = new Solution3();
                    var RiskDescription = Risks_dgv.Rows[i].Cells[0].Value?.ToString() ?? "";
                    var RiskLikelihood = Risks_dgv.Rows[i].Cells[1].Value?.ToString() ?? "";
                    var RiskImpact = Risks_dgv.Rows[i].Cells[2].Value?.ToString() ?? "";
                    var ActionRequiredToMinRisk = Risks_dgv.Rows[i].Cells[3].Value?.ToString() ?? "";
                    solution3.RiskDescription = RiskDescription;
                    solution3.RiskLikelihood = RiskLikelihood;
                    solution3.RiskImpact = RiskImpact;
                    solution3.ActionRequiredToMinRisk = ActionRequiredToMinRisk;
                    risks.Add(solution3);
                }
                newFeasibilityStudyModel.solution3 = risks;

                List<Solution3> issues = new List<Solution3>();
                int IssuesrowCount = Issues_dgv.RowCount;
                for (int i = 0; i < ResultsrowCount - 1; i++)
                {
                    Solution3 solution3 = new Solution3();
                    var IssueDescription = Issues_dgv.Rows[i].Cells[0].Value?.ToString() ?? "";
                    var IssuePriority = Issues_dgv.Rows[i].Cells[1].Value?.ToString() ?? "";
                    var ActionRequiredToResolveRisk = Issues_dgv.Rows[i].Cells[2].Value?.ToString() ?? "";
                    solution3.IssueDescription = IssueDescription;
                    solution3.IssuePriority = IssuePriority;
                    solution3.ActionRequiredToResolveRisk = ActionRequiredToResolveRisk;
                    issues.Add(solution3);
                }
                newFeasibilityStudyModel.solution3 = issues;
            }
        }

        private void Feasibility_Ranking_btn_Click(object sender, EventArgs e)
        {
            if (Ranking_Criteria_tbx.Text.Length > 0)
            {
                feasibility.RankingCriteria = Ranking_Criteria_tbx.Text;
                newFeasibilityStudyModel.RankingCriteria = feasibility.RankingCriteria;


                List<Solution1> ranking1 = new List<Solution1>();
                List<Solution2> ranking2 = new List<Solution2>();
                List<Solution3> ranking3 = new List<Solution3>();
                List<object> feasibilityStudyModels = new List<object>();
                int Ranking_Scores = Ranking_Scores_dgv.RowCount;
                for (int i = 0; i < Ranking_Scores - 1; i++)
                {
                    Solution1 solution1 = new Solution1();
                    Solution2 solution2 = new Solution2();
                    Solution3 solution3 = new Solution3();
                    var Score1 = Ranking_Scores_dgv.Rows[i].Cells[0].Value?.ToString() ?? "";
                    var Weight1 = Ranking_Scores_dgv.Rows[i].Cells[1].Value?.ToString() ?? "";
                    var Total1 = Ranking_Scores_dgv.Rows[i].Cells[2].Value?.ToString() ?? "";

                    var Score2 = Ranking_Scores_dgv.Rows[i].Cells[3].Value?.ToString() ?? "";
                    var Weight2 = Ranking_Scores_dgv.Rows[i].Cells[4].Value?.ToString() ?? "";
                    var Total2 = Ranking_Scores_dgv.Rows[i].Cells[5].Value?.ToString() ?? "";

                    var Score3 = Ranking_Scores_dgv.Rows[i].Cells[6].Value?.ToString() ?? "";
                    var Weight3 = Ranking_Scores_dgv.Rows[i].Cells[7].Value?.ToString() ?? "";
                    var Total3 = Ranking_Scores_dgv.Rows[i].Cells[8].Value?.ToString() ?? "";
                    solution1.Score1 = Score1;
                    solution1.Weight1 = Weight1;
                    solution1.Total1 = Total1;

                    solution2.Score2 = Score2;
                    solution2.Weight2 = Weight2;
                    solution2.Total2 = Total2;

                    solution3.Score3 = Score3;
                    solution3.Weight3 = Weight3;
                    solution3.Total3 = Total3;

                    ranking1.Add(solution1);
                    ranking2.Add(solution2);
                    ranking3.Add(solution3);

                    feasibilityStudyModels.Add(ranking1);
                    feasibilityStudyModels.Add(ranking2);
                    feasibilityStudyModels.Add(ranking3);
                }
                newFeasibilityStudyModel.models = feasibilityStudyModels;
            }
        }

        private void Feasibility_Result_btn_Click(object sender, EventArgs e)
        {
            if (Feasibility_Result_tbx.Text.Length > 0)
            {
                feasibility.FeasibilityResults = Feasibility_Result_tbx.Text;
                newFeasibilityStudyModel.FeasibilityResults = feasibility.FeasibilityResults;
            }
        }

        private void Appendix_btn_Click(object sender, EventArgs e)
        {
            if (Supporting_Documentation_btn.Text.Length > 0)
            {
                feasibility.SupportingDocumentation = Supporting_Documentation_btn.Text;
                newFeasibilityStudyModel.SupportingDocumentation = feasibility.SupportingDocumentation;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveDocument();
        }

        public void SaveDocument()
        {
            List<VersionControl<FeasibilityStudyModel>.DocumentModel> documentModels = versionControl.DocumentModels;


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

                foreach (var row in currentFeasibilityStudyModel.solution1)
                {
                    Results_dgv.Rows.Add(new string[] { row.Solution, row.FeasibilityScore, row.AssessmentMethod });
                    Risks_dgv.Rows.Add(new string[] { row.RiskDescription, row.RiskLikelihood, row.RiskImpact });
                    Issues_dgv.Rows.Add(new string[] { row.IssueDescription, row.IssuePriority, row.ActionRequiredToResolveRisk });

                }

                foreach (var row in currentFeasibilityStudyModel.solution2)
                {
                    Results2_dgv.Rows.Add(new string[] { row.Solution, row.FeasibilityScore, row.AssessmentMethod });
                    Risks2_dgv.Rows.Add(new string[] { row.RiskDescription, row.RiskLikelihood, row.RiskImpact });
                    Issues2_dgv.Rows.Add(new string[] { row.IssueDescription, row.IssuePriority, row.ActionRequiredToResolveRisk });

                }

                foreach (var row in currentFeasibilityStudyModel.solution3)
                {
                    Results3_dgv.Rows.Add(new string[] { row.Solution, row.FeasibilityScore, row.AssessmentMethod });
                    Risks3_dgv.Rows.Add(new string[] { row.RiskDescription, row.RiskLikelihood, row.RiskImpact });
                    Issues3_dgv.Rows.Add(new string[] { row.IssueDescription, row.IssuePriority, row.ActionRequiredToResolveRisk });

                }

                currentFeasibilityStudyModel.ProjectName = feasibility.ProjectName;
                currentFeasibilityStudyModel.ExecutiveSummary = feasibility.ExecutiveSummary;
                currentFeasibilityStudyModel.BusinessEnvironment = feasibility.BusinessEnvironment;
                currentFeasibilityStudyModel.BusinessProblem = feasibility.BusinessProblem;
                currentFeasibilityStudyModel.BusinessOpportunity = feasibility.BusinessOpportunity;
                currentFeasibilityStudyModel.BusinessDrivers = feasibility.BusinessDrivers;

                currentFeasibilityStudyModel.PotentialSolution = feasibility.PotentialSolution;
                currentFeasibilityStudyModel.Solution1Description = feasibility.Solution1Description;
                currentFeasibilityStudyModel.Solution1Assessment = feasibility.Solution1Assessment;
                currentFeasibilityStudyModel.Solution1Assumption = feasibility.Solution1Assumption;
                currentFeasibilityStudyModel.Solution2Description = feasibility.Solution1Description;

                currentFeasibilityStudyModel.Solution2Assessment = feasibility.Solution1Assessment;
                currentFeasibilityStudyModel.Solution2Assumption = feasibility.Solution1Assumption;
                currentFeasibilityStudyModel.Solution3Description = feasibility.Solution1Description;
                currentFeasibilityStudyModel.Solution3Assessment = feasibility.Solution1Assessment;
                currentFeasibilityStudyModel.Solution3Assumption = feasibility.Solution1Assumption;

                currentFeasibilityStudyModel.RankingCriteria = feasibility.RankingCriteria;
                currentFeasibilityStudyModel.FeasibilityResults = feasibility.FeasibilityResults;
                currentFeasibilityStudyModel.SupportingDocumentation = feasibility.SupportingDocumentation;
            }
        }
    }
}
