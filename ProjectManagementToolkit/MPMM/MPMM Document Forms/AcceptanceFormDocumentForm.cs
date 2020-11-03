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
    public partial class AcceptanceFormDocumentForm : Form
    {
        AcceptanceFormModel acceptanceFormModel;
        public AcceptanceFormDocumentForm()
        {
            InitializeComponent();
            acceptanceFormModel = new AcceptanceFormModel();
        }

        private void PROJECT_DETAILS_btn_Click(object sender, EventArgs e)
        {
            if (Project_Name_tbx.Text.Length > 0 && Project_Manager_tbx.Text.Length > 0)
            {
                acceptanceFormModel.ProjectName = Project_Name_tbx.Text;
                acceptanceFormModel.ProjectManager = Project_Manager_tbx.Text;
            }
        }

        private void Enter_btn_Click(object sender, EventArgs e)
        {
            if (Acceptance_Form_Name_tbx.Text.Length > 0)
                acceptanceFormModel.AcceptanceFormFor = Acceptance_Form_Name_tbx.Text;
        }

        private void ACCEPTANCE_DETAILS_btn_Click(object sender, EventArgs e)
        {
            if ((Acceptance_ID_tbx.Text = Requested_By_tbx.Text = Date_Requested_tbx.Text = Description_tbx.Text).Length > 0)
            {
                acceptanceFormModel.AcceptanceId = int.Parse(Acceptance_ID_tbx.Text);
                acceptanceFormModel.RequestedBy = Requested_By_tbx.Text;
                acceptanceFormModel.DateRequired = Date_Requested_tbx.Text;
                acceptanceFormModel.Description = Description_tbx.Text;
            }
        }

        private void ACCEPTANCE_CRITERIA_btn_Click(object sender, EventArgs e)
        {
            if (Criteria_tbx.Text.Length > 0 && Standards_tbx.Text.Length > 0)
            {
                acceptanceFormModel.Criteria = Criteria_tbx.Text;
                acceptanceFormModel.Standards = Standards_tbx.Text;
            }
        }

        private void ACCEPTANCE_RESULTS_btn_Click(object sender, EventArgs e)
        {
            foreach (DataGridView row in ACCEPTANCE_RESULTS_dgv.Rows)
            {
                foreach (var column in row.Columns)
                {
                    acceptanceFormModel.AcceptanceResults += column;
                }
            }
            List<ChildAcceptanceFormModel> list = new List<ChildAcceptanceFormModel>();
            int ResultsrowCount = ACCEPTANCE_RESULTS_dgv.RowCount;
            for (int i = 0; i < ResultsrowCount - 1; i++)
            {
                ChildAcceptanceFormModel acceptanceFormModel = new ChildAcceptanceFormModel();
                var Acceptance = ACCEPTANCE_RESULTS_dgv.Rows[i].Cells[0].Value?.ToString() ?? "";
                var Method = ACCEPTANCE_RESULTS_dgv.Rows[i].Cells[1].Value?.ToString() ?? "";
                var Reviewer = ACCEPTANCE_RESULTS_dgv.Rows[i].Cells[2].Value?.ToString() ?? "";
                var Date = ACCEPTANCE_RESULTS_dgv.Rows[i].Cells[3].Value?.ToString() ?? "";
                var Result = ACCEPTANCE_RESULTS_dgv.Rows[i].Cells[4].Value?.ToString() ?? "";

                acceptanceFormModel.Acceptance = Acceptance;
                acceptanceFormModel.Method = Method;
                acceptanceFormModel.Reviewer = Reviewer;
                acceptanceFormModel.Date = Date;
                acceptanceFormModel.Result = Result;
                list.Add(acceptanceFormModel);
            }
    }

        private void CUSTOMER_APPROVAL_btn_Click(object sender, EventArgs e)
        {
            if (Supporting_Documentation_tbx.Text.Length > 0)
                acceptanceFormModel.SupportingDocumentation = Supporting_Documentation_tbx.Text;
        }
    }
}
