using ProjectManagementToolkit.MPMM.MPMM_Document_Models;
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
using System.Runtime.InteropServices;
using ProjectManagementToolkit.Utility;
using ProjectManagementToolkit.Properties;

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Forms
{
    public partial class ExpenseFormDocumentForm : Form
    {
/// <summary>
/// ///////////////////////////////////////////////////////////////////Zander Added Code
/// </summary>
        VersionControl<ExpenseFormModel> versionControl;
        ExpenseFormModel newExpenseFormModel;
        ExpenseFormModel currentExpenseFormModel;





        public void saveDocument()
        {
            newExpenseFormModel.ProjectDetails = txtprojectdetailsContent.Text;


            List<ExpenseFormModel.ExpenseDetail> expenseDetail = new List<ExpenseFormModel.ExpenseDetail>();

            int dataGridView2RowsCount = dataGridView2.Rows.Count;

            for (int i = 0; i < dataGridView2RowsCount - 1; i++)
            {
                ExpenseFormModel.ExpenseDetail expenseDetailModel = new ExpenseFormModel.ExpenseDetail();
                var activityID = dataGridView2.Rows[i].Cells[0].Value?.ToString() ?? "";
                var taskID = dataGridView2.Rows[i].Cells[1].Value?.ToString() ?? "";
                var expenseDate = dataGridView2.Rows[i].Cells[2].Value?.ToString() ?? "";
                var expenseType = dataGridView2.Rows[i].Cells[3].Value?.ToString() ?? "";
                var expenseDescription = dataGridView2.Rows[i].Cells[4].Value?.ToString() ?? "";
                var expenseAmount = dataGridView2.Rows[i].Cells[5].Value?.ToString() ?? "";
                var payeeName = dataGridView2.Rows[i].Cells[6].Value?.ToString() ?? "";
                var invoiceNumber = dataGridView2.Rows[i].Cells[7].Value?.ToString() ?? "";

                expenseDetailModel.ActivityID = activityID;
                expenseDetailModel.TaskID = taskID;
                expenseDetailModel.ExpenseDate = expenseDate;
                expenseDetailModel.ExpenseType = expenseType;
                expenseDetailModel.ExpenseDescription = expenseDescription;
                expenseDetailModel.ExpenseAmount = expenseAmount;
                expenseDetailModel.PayeeName = payeeName;
                expenseDetailModel.InvoiceNumber = invoiceNumber;

                expenseDetail.Add(expenseDetailModel);
            }
            newExpenseFormModel.ExpenseDetails = expenseDetail;


            newExpenseFormModel.Approvaldetails = txtapprovaldetails.Text;


            List<VersionControl<ExpenseFormModel>.DocumentModel> documentModels = versionControl.DocumentModels;


            if (!versionControl.isEqual(currentExpenseFormModel, newExpenseFormModel))
            {
                VersionControl<ExpenseFormModel>.DocumentModel documentModel = new VersionControl<ExpenseFormModel>.DocumentModel(newExpenseFormModel, DateTime.Now, VersionControl<ProjectModel>.generateID());

                documentModels.Add(documentModel);

                versionControl.DocumentModels = documentModels;

                string json = JsonConvert.SerializeObject(versionControl);
                JsonHelper.saveDocument(json, Settings.Default.ProjectID, "ExpenseForm");
                MessageBox.Show("Expense form saved successfully", "save", MessageBoxButtons.OK);
            }
        }



            private void loadDocument()
            {
                string json = JsonHelper.loadDocument(Settings.Default.ProjectID, "ExpenseForm");
                List<string[]> documentInfo = new List<string[]>();
                newExpenseFormModel = new ExpenseFormModel();
                currentExpenseFormModel = new ExpenseFormModel();
                if (json != "")
                {
                    versionControl = JsonConvert.DeserializeObject<VersionControl<ExpenseFormModel>>(json);
                    newExpenseFormModel = JsonConvert.DeserializeObject<ExpenseFormModel>(versionControl.getLatest(versionControl.DocumentModels));
                    currentExpenseFormModel = JsonConvert.DeserializeObject<ExpenseFormModel>(versionControl.getLatest(versionControl.DocumentModels));

                    txtprojectdetailsContent.Text = currentExpenseFormModel.ProjectDetails;

                    foreach (var row in currentExpenseFormModel.ExpenseDetails)
                    {
                        dataGridView2.Rows.Add(new string[] { row.ActivityID, row.TaskID, row.ExpenseDate, row.ExpenseType, row.ExpenseDescription, row.ExpenseAmount, row.PayeeName, row.InvoiceNumber});
                    }
                }
                else
                {
                    versionControl = new VersionControl<ExpenseFormModel>();
                    versionControl.DocumentModels = new List<VersionControl<ExpenseFormModel>.DocumentModel>();
                    newExpenseFormModel = new ExpenseFormModel();
                }
            }

        public ExpenseFormDocumentForm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void txtProjectName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveDocument();
        }

        private void ExpenseFormDocumentForm_Load(object sender, EventArgs e)
        {
            loadDocument();
        }
    }
}
