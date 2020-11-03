using ProjectManagementToolkit.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Forms
{
    public partial class FeasibiltyStudyDocumentForm : Form
    {
        FeasibilityStudyModel feasibility;
        public FeasibiltyStudyDocumentForm()
        {
            InitializeComponent();
            feasibility = new FeasibilityStudyModel();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Enter_btn_Click(object sender, EventArgs e)
        {
            if (Project_Name_tbx.Text.Length > 0)
            {
                feasibility.ProjectName = Project_Name_tbx.Text;
            }
        }

        private void Executive_Summary_btn_Click(object sender, EventArgs e)
        {
            if (Executive_Summary_tbx.Text.Length > 0)
            {
                feasibility.ExecutiveSummary = Executive_Summary_tbx.Text;
            }
        }

        private void Problem_Statement_btn_Click(object sender, EventArgs e)
        {
            if (Business_Environment_tbx.Text.Length > 0 && Business_Problem_tbx.Text.Length > 0 && Business_Opportunity_tbx.Text.Length > 0)
            {
                feasibility.BusinessEnvironment = Business_Environment_tbx.Text;
                feasibility.BusinessProblem = Business_Problem_tbx.Text;
                feasibility.BusinessOpportunity = Business_Opportunity_tbx.Text;
            }
        }

        private void Requirements_Statement_btn_Click(object sender, EventArgs e)
        {
            if (Business_Drivers_tbx.Text.Length > 0)
            {
                feasibility.BusinessDrivers = Business_Drivers_tbx.Text;

               
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
            }
        }

        private void Solution_1_btn_Click(object sender, EventArgs e)
        {
            if (Description_tbx.Text.Length > 0 && Assessment_tbx.Text.Length > 0 && Assumptions_tbx.Text.Length > 0)
            {
                feasibility.Solution1Description = Description_tbx.Text;
                feasibility.Solution1Assessment = Assessment_tbx.Text;
                feasibility.Solution1Assumption = Assumptions_tbx.Text;

                List<Solution3> results = new List<Solution3>();
                int ResultsrowCount = Results_dgv.RowCount;
                for (int i = 0; i < ResultsrowCount - 1; i++)
                {
                    Solution3 solution1 = new Solution3();
                    var Solution = Results_dgv.Rows[i].Cells[0].Value?.ToString() ?? "";
                    var FeasibilityScore = Results_dgv.Rows[i].Cells[1].Value?.ToString() ?? "";
                    var AssessmentMethod = Results_dgv.Rows[i].Cells[2].Value?.ToString() ?? "";
                    solution1.Solution = Solution;
                    solution1.FeasibilityScore = FeasibilityScore;
                    solution1.AssessmentMethod = AssessmentMethod;
                    results.Add(solution1);
                }

                List<Solution3> risks = new List<Solution3>();
                int RisksrowCount = Risks_dgv.RowCount;
                for (int i = 0; i < RisksrowCount - 1; i++)
                {
                    Solution3 solution1 = new Solution3();
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

                List<Solution3> issues = new List<Solution3>();
                int IssuesrowCount = Issues_dgv.RowCount;
                for (int i = 0; i < ResultsrowCount - 1; i++)
                {
                    Solution3 solution1 = new Solution3();
                    var IssueDescription = Issues_dgv.Rows[i].Cells[0].Value?.ToString() ?? "";
                    var IssuePriority = Issues_dgv.Rows[i].Cells[1].Value?.ToString() ?? "";
                    var ActionRequiredToResolveRisk = Issues_dgv.Rows[i].Cells[2].Value?.ToString() ?? "";
                    solution1.IssueDescription = IssueDescription;
                    solution1.IssuePriority = IssuePriority;
                    solution1.ActionRequiredToResolveRisk = ActionRequiredToResolveRisk;
                    issues.Add(solution1);
                }
            }
        }

        private void Solution_2_btn_Click(object sender, EventArgs e)
        {
            if (Description2_tbx.Text.Length > 0 && Assessment2_tbx.Text.Length > 0 && Assumptions2_tbx.Text.Length > 0)
            {
                feasibility.Solution2Description = Description2_tbx.Text;
                feasibility.Solution2Assessment = Assessment2_tbx.Text;
                feasibility.Solution2Assumption = Assumptions2_tbx.Text;

                List<Solution3> results = new List<Solution3>();
                int ResultsrowCount = Results_dgv.RowCount;
                for (int i = 0; i < ResultsrowCount - 1; i++)
                {
                    Solution3 solution2 = new Solution3();
                    var Solution = Results_dgv.Rows[i].Cells[0].Value?.ToString() ?? "";
                    var FeasibilityScore = Results_dgv.Rows[i].Cells[1].Value?.ToString() ?? "";
                    var AssessmentMethod = Results_dgv.Rows[i].Cells[2].Value?.ToString() ?? "";
                    solution2.Solution = Solution;
                    solution2.FeasibilityScore = FeasibilityScore;
                    solution2.AssessmentMethod = AssessmentMethod;
                    results.Add(solution2);
                }

                List<Solution3> risks = new List<Solution3>();
                int RisksrowCount = Risks_dgv.RowCount;
                for (int i = 0; i < RisksrowCount - 1; i++)
                {
                    Solution3 solution1 = new Solution3();
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

                List<Solution3> issues = new List<Solution3>();
                int IssuesrowCount = Issues_dgv.RowCount;
                for (int i = 0; i < ResultsrowCount - 1; i++)
                {
                    Solution3 solution1 = new Solution3();
                    var IssueDescription = Issues_dgv.Rows[i].Cells[0].Value?.ToString() ?? "";
                    var IssuePriority = Issues_dgv.Rows[i].Cells[1].Value?.ToString() ?? "";
                    var ActionRequiredToResolveRisk = Issues_dgv.Rows[i].Cells[2].Value?.ToString() ?? "";
                    solution1.IssueDescription = IssueDescription;
                    solution1.IssuePriority = IssuePriority;
                    solution1.ActionRequiredToResolveRisk = ActionRequiredToResolveRisk;
                    issues.Add(solution1);
                }
            }
        }

        private void Solution_3_btn_Click(object sender, EventArgs e)
        {
            if (Description3_tbx.Text.Length > 0 && Assessment3_tbx.Text.Length > 0 && Assumptions3_tbx.Text.Length > 0)
            {
                feasibility.Solution3Description = Description3_tbx.Text;
                feasibility.Solution3Assessment = Assessment3_tbx.Text;
                feasibility.Solution3Assumption = Assumptions3_tbx.Text;

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

                List<Solution3> risks = new List<Solution3>();
                int RisksrowCount = Risks_dgv.RowCount;
                for (int i = 0; i < RisksrowCount - 1; i++)
                {
                    Solution3 solution1 = new Solution3();
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

                List<Solution3> issues = new List<Solution3>();
                int IssuesrowCount = Issues_dgv.RowCount;
                for (int i = 0; i < ResultsrowCount - 1; i++)
                {
                    Solution3 solution1 = new Solution3();
                    var IssueDescription = Issues_dgv.Rows[i].Cells[0].Value?.ToString() ?? "";
                    var IssuePriority = Issues_dgv.Rows[i].Cells[1].Value?.ToString() ?? "";
                    var ActionRequiredToResolveRisk = Issues_dgv.Rows[i].Cells[2].Value?.ToString() ?? "";
                    solution1.IssueDescription = IssueDescription;
                    solution1.IssuePriority = IssuePriority;
                    solution1.ActionRequiredToResolveRisk = ActionRequiredToResolveRisk;
                    issues.Add(solution1);
                }
            }
        }

        private void Feasibility_Ranking_btn_Click(object sender, EventArgs e)
        {
            if (Ranking_Criteria_tbx.Text.Length > 0)
            {
                feasibility.RankingCriteria = Ranking_Criteria_tbx.Text;

                foreach (DataGridView row in Ranking_Scores_dgv.Rows)
                {
                    foreach (var column in row.Columns)
                    {
                        feasibility.RankingScores += column;
                    }
                }
            }
        }

        private void Feasibility_Result_btn_Click(object sender, EventArgs e)
        {
            if (Feasibility_Result_tbx.Text.Length > 0)
            {
                feasibility.FeasibilityResults = Feasibility_Result_tbx.Text;
            }
        }

        private void Appendix_btn_Click(object sender, EventArgs e)
        {
            if (Supporting_Documentation_btn.Text.Length > 0)
            {
                feasibility.SupportingDocumentation = Supporting_Documentation_btn.Text;
            }
        }
    }
}
