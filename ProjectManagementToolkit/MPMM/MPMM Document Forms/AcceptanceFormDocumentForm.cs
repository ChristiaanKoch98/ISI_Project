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
        }

        private void CUSTOMER_APPROVAL_btn_Click(object sender, EventArgs e)
        {
            if (Supporting_Documentation_tbx.Text.Length > 0)
                acceptanceFormModel.SupportingDocumentation = Supporting_Documentation_tbx.Text;
        }
    }
}
