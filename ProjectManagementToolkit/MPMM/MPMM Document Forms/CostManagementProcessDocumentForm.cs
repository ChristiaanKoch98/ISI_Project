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
    public partial class CostManagementProcessDocumentForm : Form
    {
        CostManagementProcessModel costManagementProcess;
        public CostManagementProcessDocumentForm()
        {
            InitializeComponent();
            costManagementProcess = new CostManagementProcessModel();

            List<string[]> rows1 = new List<string[]>();
            rows1.Add(new string[] { "Document ID", "" });
            rows1.Add(new string[] { "Document Owner", "" });
            rows1.Add(new string[] { "Issue Date", "" });
            rows1.Add(new string[] { "Last Save Date", "" });
            rows1.Add(new string[] { "File Name", "" });
            foreach (var row in rows1)
            {
                Document_Information_dgv.Rows.Add(row);
            }
            Document_Information_dgv.AllowUserToAddRows = false;

            List<string[]> rows2 = new List<string[]>();
            rows2.Add(new string[] { "Project Sponsor", "" });
            rows2.Add(new string[] { "Project Review Group", "" });
            rows2.Add(new string[] { "Project Manager", "" });
            rows2.Add(new string[] { "Quality Manager", "" });
            rows2.Add(new string[] { "Procument Manager", "" });
            rows2.Add(new string[] { "Communications Manager", "" });
            rows2.Add(new string[] { "Project Office Manager", "" });
            foreach (var row in rows2)
            {
                Document_Approvals_dgv.Rows.Add(row);
            }
            Document_Approvals_dgv.AllowUserToAddRows = false;
        }


        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void Enter_btn_Click(object sender, EventArgs e)
        {
            if (Cost_Management_Process_tbx.Text.Length > 0)
            {
                costManagementProcess.DocumentManagementProcess = Cost_Management_Process_tbx.Text;
            }
        }

        private void Cost_Management_Roles_Click(object sender, EventArgs e)
        {
            if (Overview_tbx.Text.Length > 0 && Document_Expense_tbx.Text.Length > 0 &&
               Approve_Expense_tbx.Text.Length > 0 && Update_Project_Plan_tbx.Text.Length > 0)
            {
                costManagementProcess.Overview = Overview_tbx.Text;
                costManagementProcess.DocumentExpense = Document_Expense_tbx.Text;
                costManagementProcess.ApproveExpense = Approve_Expense_tbx.Text;
                costManagementProcess.UpdateExpense = Update_Project_Plan_tbx.Text;
            }
        }

        private void Cost_Management_Roles_btn_Click(object sender, EventArgs e)
        {
            if (Team_Member_tbx.Text.Length > 0 && Project_Administrator_tbx.Text.Length > 0 &&
               Project_Manager_tbx.Text.Length > 0)
            {
                costManagementProcess.TeamMembers = new List<string>();
                foreach (var member in Team_Member_tbx.Text)
                {
                    //costManagementProcess.TeamMembers.Add(member);  ListBox Control In place of Textbox here...
                }
                costManagementProcess.ProjectAdmin = Project_Administrator_tbx.Text;
                costManagementProcess.ProjectManager = Project_Manager_tbx.Text;
            }
        }

        private void Cost_Management_Documents_btn_Click(object sender, EventArgs e)
        {
            if (Expense_Form_tbx.Text.Length > 0 && Expense_Register_tbx.Text.Length > 0)
            {
                costManagementProcess.ExpenseForm = Expense_Form_tbx.Text;
                costManagementProcess.ExpenseRegister = Expense_Register_tbx.Text;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Information information = new Information();
            information.DocumentID = Document_Information_dgv.Rows[0].Cells[1].Value.ToString();
            information.DocumentOwner = Document_Information_dgv.Rows[1].Cells[1].Value.ToString();
            information.IssueDate = Document_Information_dgv.Rows[2].Cells[1].Value.ToString();
            information.LastSavedDate = Document_Information_dgv.Rows[3].Cells[1].Value.ToString();
            information.FileName = Document_Information_dgv.Rows[4].Cells[1].Value.ToString();

            List<History> histories = new List<History>();
            int Document_HistoryRowCount = Document_History_dgv.RowCount;
            for (int i = 0; i < Document_HistoryRowCount - 1; i++)
            {
                History history = new History();
                var Version = Document_History_dgv.Rows[i].Cells[0].Value?.ToString() ?? "";
                var IssueDate = Document_History_dgv.Rows[i].Cells[1].Value?.ToString() ?? "";
                var Changes = Document_History_dgv.Rows[i].Cells[2].Value?.ToString() ?? "";
                history.Version = Version;
                history.IssueDate = IssueDate;
                history.Changes = Changes;
                histories.Add(history);
            }

            Approvals approvals = new Approvals();
            approvals.ProjectSponsor = Document_Approvals_dgv.Rows[0].Cells[1].Value.ToString();
            approvals.ProjectReviewGroup = Document_Approvals_dgv.Rows[1].Cells[1].Value.ToString();
            approvals.ProjectManager = Document_Approvals_dgv.Rows[2].Cells[1].Value.ToString();
            approvals.QualityManager = Document_Approvals_dgv.Rows[3].Cells[1].Value.ToString();
            approvals.ProcumentManager = Document_Approvals_dgv.Rows[4].Cells[1].Value.ToString();
            approvals.CommunicationsManager = Document_Approvals_dgv.Rows[5].Cells[1].Value.ToString();
            approvals.ProjectOfficeManager = Document_Approvals_dgv.Rows[6].Cells[1].Value.ToString();
        }
    }
}
