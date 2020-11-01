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
    public partial class RiskPlanDocumentForm : Form
    {
        RiskPlanModel riskPlanModel;
        public RiskPlanDocumentForm()
        {
            InitializeComponent();
            riskPlanModel = new RiskPlanModel();
        }

        private void Enter_btn_Click(object sender, EventArgs e)
        {
            if (Project_Name_tbx.Text.Length > 0)
            {
                riskPlanModel.ProjectName = Project_Name_tbx.Text;
            }
        }

        private void Risk_Identification_btn_Click(object sender, EventArgs e)
        {
            if (Categories_tbx.Text.Length > 0)
            {
                riskPlanModel.Categories = Categories_tbx.Text;

                foreach (DataGridView row in Risks_dgv.Rows)
                {
                    foreach (var column in row.Columns)
                    {
                        riskPlanModel.Risks  += column;
                    }
                }
            }
        }

        private void Risk_Plan_btn_Click(object sender, EventArgs e)
        {
            if (Assumptions_tbx.Text.Length > 0 && Constraints_tbx.Text.Length > 0)
            {
                riskPlanModel.Assumptions = Assumptions_tbx.Text;
                riskPlanModel.Constraints = Constraints_tbx.Text;

                foreach (DataGridView row in Schedule_dgv.Rows)
                {
                    foreach (var column in row.Columns)
                    {
                        riskPlanModel.Schedule += column;
                    }
                }
            }
        }

        private void Risk_Process_btn_Click(object sender, EventArgs e)
        {
            if (Activities_tbx.Text.Length > 0 && Roles_tbx.Text.Length > 0 && Documents_tbx.Text.Length > 0)
            {
                riskPlanModel.Activities = Activities_tbx.Text;
                riskPlanModel.Roles = Roles_tbx.Text;
                riskPlanModel.Documents = Documents_tbx.Text;
            }
        }

        private void Appendix_btn_Click(object sender, EventArgs e)
        {
            if (Appendix_tbx.Text.Length > 0)
            {
                riskPlanModel.Appendix = Appendix_tbx.Text;
            }
        }
    }
}
