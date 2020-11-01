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
    }
}
