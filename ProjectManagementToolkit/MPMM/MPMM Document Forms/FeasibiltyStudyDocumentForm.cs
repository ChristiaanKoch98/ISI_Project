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

                foreach (DataGridView row in Business_Requirements_dgv .Rows)
                {
                    foreach (var column in row.Columns)
                    {
                        feasibility.BusinessRequirements += column;
                    }
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

                foreach (DataGridView row in Results_dgv.Rows)
                {
                    foreach (var column in row.Columns)
                    {
                        feasibility.Results += column;
                    }
                }
                foreach (DataGridView row in Risks_dgv.Rows)
                {
                    foreach (var column in row.Columns)
                    {
                        feasibility.Risks += column;
                    }
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

                foreach (DataGridView row in Results2_dgv.Rows)
                {
                    foreach (var column in row.Columns)
                    {
                        feasibility.Results2 += column;
                    }
                }
                foreach (DataGridView row in Risks2_dgv.Rows)
                {
                    foreach (var column in row.Columns)
                    {
                        feasibility.Risks2 += column;
                    }
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

                foreach (DataGridView row in Results3_dgv.Rows)
                {
                    foreach (var column in row.Columns)
                    {
                        feasibility.Results3 += column;
                    }
                }
                foreach (DataGridView row in Risks3_dgv.Rows)
                {
                    foreach (var column in row.Columns)
                    {
                        feasibility.Risks3 += column;
                    }
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
