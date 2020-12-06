using Newtonsoft.Json;
using ProjectManagementToolkit.MPMM.MPMM_Document_Models;
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

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Forms
{
    public partial class ExpenseRegister : Form
    {
        VersionControl<ProjectManagementToolkit.MPMM.MPMM_Document_Models.ExpenseRegister> versionControl;
        ProjectManagementToolkit.MPMM.MPMM_Document_Models.ExpenseRegister newExpenseRegisterModel;
        ProjectManagementToolkit.MPMM.MPMM_Document_Models.ExpenseRegister currentExpenseRegisterModel;
        Color TABLE_HEADER_COLOR = Color.FromArgb(73, 173, 252);
        ProjectModel projectModel = new ProjectModel();
        public ExpenseRegister()
        {
            InitializeComponent();
        }

        private void btnEnterData_Click(object sender, EventArgs e)
        {
            
        }

        private void ExpenseRegister_Load(object sender, EventArgs e)
        {
            string json = JsonHelper.loadDocument(Settings.Default.ProjectID, "ExpenseRegister");
            newExpenseRegisterModel = new ProjectManagementToolkit.MPMM.MPMM_Document_Models.ExpenseRegister();
            currentExpenseRegisterModel = new ProjectManagementToolkit.MPMM.MPMM_Document_Models.ExpenseRegister();

            if (json != "")
            {
                versionControl = JsonConvert.DeserializeObject<VersionControl<ProjectManagementToolkit.MPMM.MPMM_Document_Models.ExpenseRegister>>(json);
                newExpenseRegisterModel = JsonConvert.DeserializeObject<ProjectManagementToolkit.MPMM.MPMM_Document_Models.ExpenseRegister>(versionControl.getLatest(versionControl.DocumentModels));
                currentExpenseRegisterModel = JsonConvert.DeserializeObject<ProjectManagementToolkit.MPMM.MPMM_Document_Models.ExpenseRegister>(versionControl.getLatest(versionControl.DocumentModels));

                foreach (var row in currentExpenseRegisterModel.ExpenseEntries)
                {
                    dataGridViewExpenseRegister.Rows.Add(new string[] { row.ActivityID.ToString(), row.ActivityDescription, row.TaskId.ToString(),
                    row.TaskDescription,row.ExpenseID.ToString(),row.ExpenseType,row.ExpenseDescription,row.ExpenseAmount,row.ApprovalStatus,row.ApprovalDate,row.Approver
                    ,row.PaymentStatus,row.PaymentDate,row.Payee,row.Method});
                }
            }
            else
            {
                versionControl = new VersionControl<ProjectManagementToolkit.MPMM.MPMM_Document_Models.ExpenseRegister>();
                versionControl.DocumentModels = new List<VersionControl<ProjectManagementToolkit.MPMM.MPMM_Document_Models.ExpenseRegister>.DocumentModel>();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            List<ProjectManagementToolkit.MPMM.MPMM_Document_Models.ExpenseRegister.ExpenseEntry> expenseEntries = new List<ProjectManagementToolkit.MPMM.MPMM_Document_Models.ExpenseRegister.ExpenseEntry>();
            int expenseEntryCount = dataGridViewExpenseRegister.Rows.Count;

            for (int i = 0; i < expenseEntryCount - 1; i++)
            {
                ProjectManagementToolkit.MPMM.MPMM_Document_Models.ExpenseRegister.ExpenseEntry expenseEntry = new ProjectManagementToolkit.MPMM.MPMM_Document_Models.ExpenseRegister.ExpenseEntry();
                var activityid = dataGridViewExpenseRegister.Rows[i].Cells[0].Value?.ToString() ?? "";
                var activitydescription = dataGridViewExpenseRegister.Rows[i].Cells[1].Value?.ToString() ?? "";
                var taskid = dataGridViewExpenseRegister.Rows[i].Cells[2].Value?.ToString() ?? "";
                var taskdescription = dataGridViewExpenseRegister.Rows[i].Cells[3].Value?.ToString() ?? "";
                var expenseid = dataGridViewExpenseRegister.Rows[i].Cells[4].Value?.ToString() ?? "";
                var expensetype = dataGridViewExpenseRegister.Rows[i].Cells[5].Value?.ToString() ?? "";
                var expensedescription = dataGridViewExpenseRegister.Rows[i].Cells[6].Value?.ToString() ?? "";
                var expenseamount = dataGridViewExpenseRegister.Rows[i].Cells[7].Value?.ToString() ?? "";
                var approvalstatus = dataGridViewExpenseRegister.Rows[i].Cells[8].Value?.ToString() ?? "";
                var approvaldate = dataGridViewExpenseRegister.Rows[i].Cells[9].Value?.ToString() ?? "";
                var approver = dataGridViewExpenseRegister.Rows[i].Cells[10].Value?.ToString() ?? "";
                var paymentstatus = dataGridViewExpenseRegister.Rows[i].Cells[11].Value?.ToString() ?? "";
                var paymentdate = dataGridViewExpenseRegister.Rows[i].Cells[12].Value?.ToString() ?? "";
                var payee = dataGridViewExpenseRegister.Rows[i].Cells[13].Value?.ToString() ?? "";
                var method = dataGridViewExpenseRegister.Rows[i].Cells[14].Value?.ToString() ?? "";

                expenseEntry.ActivityID = int.Parse(activityid);
                expenseEntry.ActivityDescription = activitydescription;
                expenseEntry.TaskId = int.Parse(taskid);
                expenseEntry.TaskDescription = taskdescription;
                expenseEntry.ExpenseID = int.Parse(expenseid);
                expenseEntry.ExpenseType = expensetype;
                expenseEntry.ExpenseDescription = expensedescription;
                expenseEntry.ExpenseAmount = expenseamount;
                expenseEntry.ApprovalStatus = approvalstatus;
                expenseEntry.ApprovalDate = approvaldate;
                expenseEntry.Approver = approver;
                expenseEntry.PaymentStatus = paymentstatus;
                expenseEntry.PaymentDate = paymentdate;
                expenseEntry.Payee = payee;
                expenseEntry.Method = method;
                expenseEntries.Add(expenseEntry);
            }

            newExpenseRegisterModel.ExpenseEntries = expenseEntries;
            List<VersionControl<ProjectManagementToolkit.MPMM.MPMM_Document_Models.ExpenseRegister>.DocumentModel> documentModels = versionControl.DocumentModels;

            if (!versionControl.isEqual(currentExpenseRegisterModel, newExpenseRegisterModel))
            {
                VersionControl<ProjectManagementToolkit.MPMM.MPMM_Document_Models.ExpenseRegister>.DocumentModel documentModel = new VersionControl<ProjectManagementToolkit.MPMM.MPMM_Document_Models.ExpenseRegister>.DocumentModel(newExpenseRegisterModel, DateTime.Now, VersionControl<ProjectManagementToolkit.MPMM.MPMM_Document_Models.ExpenseRegister>.generateID());

                documentModels.Add(documentModel);
                string json = JsonConvert.SerializeObject(versionControl);
                currentExpenseRegisterModel = JsonConvert.DeserializeObject<ProjectManagementToolkit.MPMM.MPMM_Document_Models.ExpenseRegister>(JsonConvert.SerializeObject(newExpenseRegisterModel));
                JsonHelper.saveDocument(json, Settings.Default.ProjectID, "ExpenseRegister");
                MessageBox.Show("Expense Register saved successfully", "save", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("No changes were made.", "save", MessageBoxButtons.OK);
            }
        }
    }
}
