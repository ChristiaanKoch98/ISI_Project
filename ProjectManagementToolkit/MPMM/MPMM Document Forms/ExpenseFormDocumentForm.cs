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
using Xceed.Document.NET;
using Xceed.Words.NET;

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

        Color TABLE_HEADER_COLOR = Color.FromArgb(73, 173, 252);
        ProjectModel projectModel = new ProjectModel();



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

        private void exportToWord()
        {
            string path;
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                saveFileDialog.Filter = "Word 97-2003 Documents (*.doc)|*.doc|Word 2007 Documents (*.docx)|*.docx";
                saveFileDialog.FilterIndex = 2;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    path = saveFileDialog.FileName;
                    using (var document = DocX.Create(path))
                    {
                        for (int i = 0; i < 11; i++)
                        {
                            document.InsertParagraph("")
                                .Font("Arial")
                                .Bold(true)
                                .FontSize(22d).Alignment = Alignment.left;
                        }

                        //Code for the Front page
                        document.InsertParagraph("Expense Form \nFor " + projectModel.ProjectName)
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(22d).Alignment = Alignment.left;
                        document.InsertSectionPageBreak();
                        //Code for the Front page


                        //Code for the title of a page
                        document.InsertParagraph("Expense Form\n")
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(14d).Alignment = Alignment.left;
                        //Code for the title of a page


                        //Code for a space
                        document.InsertParagraph("")
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(14d).Alignment = Alignment.left;
                        //Code for a space


                        //Code for a table
                        var projectDetailsTable = document.AddTable(2, 1);
                        projectDetailsTable.Rows[0].Cells[0].Paragraphs[0].Append("PROJECT DETAILS").Bold(true).Color(Color.White);
                        projectDetailsTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;

                        projectDetailsTable.Rows[1].Cells[0].Paragraphs[0].Append(currentExpenseFormModel.ProjectDetails);

                        projectDetailsTable.SetWidthsPercentage(new float[] { 100});
                        document.InsertTable(projectDetailsTable);
                        //Code for a table


                        //Code for a space
                        document.InsertParagraph("")
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(14d).Alignment = Alignment.left;
                        //Code for a space




                        //Code for a table
                        var exspenseDetailsTableTable = document.AddTable(currentExpenseFormModel.ExpenseDetails.Count + 2, 8);
                        exspenseDetailsTableTable.Rows[0].Cells[0].Paragraphs[0].Append("EXPENSE DETAILS").Bold(true).Color(Color.White);
                        exspenseDetailsTableTable.Rows[0].Cells[1].Paragraphs[0].Append("").Bold(true).Color(Color.White);
                        exspenseDetailsTableTable.Rows[0].Cells[2].Paragraphs[0].Append("").Bold(true).Color(Color.White);
                        exspenseDetailsTableTable.Rows[0].Cells[3].Paragraphs[0].Append("").Bold(true).Color(Color.White);
                        exspenseDetailsTableTable.Rows[0].Cells[4].Paragraphs[0].Append("").Bold(true).Color(Color.White);
                        exspenseDetailsTableTable.Rows[0].Cells[5].Paragraphs[0].Append("").Bold(true).Color(Color.White);
                        exspenseDetailsTableTable.Rows[0].Cells[6].Paragraphs[0].Append("").Bold(true).Color(Color.White);
                        exspenseDetailsTableTable.Rows[0].Cells[7].Paragraphs[0].Append("").Bold(true).Color(Color.White);


                        exspenseDetailsTableTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        exspenseDetailsTableTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        exspenseDetailsTableTable.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;
                        exspenseDetailsTableTable.Rows[0].Cells[3].FillColor = TABLE_HEADER_COLOR;
                        exspenseDetailsTableTable.Rows[0].Cells[4].FillColor = TABLE_HEADER_COLOR;
                        exspenseDetailsTableTable.Rows[0].Cells[5].FillColor = TABLE_HEADER_COLOR;
                        exspenseDetailsTableTable.Rows[0].Cells[6].FillColor = TABLE_HEADER_COLOR;
                        exspenseDetailsTableTable.Rows[0].Cells[7].FillColor = TABLE_HEADER_COLOR;

                        exspenseDetailsTableTable.Rows[1].Cells[0].Paragraphs[0].Append("Activity ID");
                        exspenseDetailsTableTable.Rows[1].Cells[1].Paragraphs[0].Append("Task ID");
                        exspenseDetailsTableTable.Rows[1].Cells[2].Paragraphs[0].Append("Expense Date");
                        exspenseDetailsTableTable.Rows[1].Cells[3].Paragraphs[0].Append("Expense Type");
                        exspenseDetailsTableTable.Rows[1].Cells[4].Paragraphs[0].Append("Expense Description");
                        exspenseDetailsTableTable.Rows[1].Cells[5].Paragraphs[0].Append("Expense Amount");
                        exspenseDetailsTableTable.Rows[1].Cells[6].Paragraphs[0].Append("Payee Name");
                        exspenseDetailsTableTable.Rows[1].Cells[7].Paragraphs[0].Append("Invoice Number");

                        for (int i = 1; i < currentExpenseFormModel.ExpenseDetails.Count + 1; i++)
                        {
                            exspenseDetailsTableTable.Rows[i + 1].Cells[0].Paragraphs[0].Append(currentExpenseFormModel.ExpenseDetails[i - 1].ActivityID);
                            exspenseDetailsTableTable.Rows[i + 1].Cells[1].Paragraphs[0].Append(currentExpenseFormModel.ExpenseDetails[i - 1].TaskID);
                            exspenseDetailsTableTable.Rows[i + 1].Cells[2].Paragraphs[0].Append(currentExpenseFormModel.ExpenseDetails[i - 1].ExpenseDate);
                            exspenseDetailsTableTable.Rows[i + 1].Cells[3].Paragraphs[0].Append(currentExpenseFormModel.ExpenseDetails[i - 1].ExpenseType);
                            exspenseDetailsTableTable.Rows[i + 1].Cells[4].Paragraphs[0].Append(currentExpenseFormModel.ExpenseDetails[i - 1].ExpenseDescription);
                            exspenseDetailsTableTable.Rows[i + 1].Cells[5].Paragraphs[0].Append(currentExpenseFormModel.ExpenseDetails[i - 1].ExpenseAmount);
                            exspenseDetailsTableTable.Rows[i + 1].Cells[6].Paragraphs[0].Append(currentExpenseFormModel.ExpenseDetails[i - 1].PayeeName);
                            exspenseDetailsTableTable.Rows[i + 1].Cells[7].Paragraphs[0].Append(currentExpenseFormModel.ExpenseDetails[i - 1].InvoiceNumber);
                        }


                        exspenseDetailsTableTable.SetWidthsPercentage(new float[] { 12 });
                        document.InsertTable(exspenseDetailsTableTable);
                        //Code for a table


                        //Code for a space
                        document.InsertParagraph("")
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(14d).Alignment = Alignment.left;
                        //Code for a space


                        //Code for a table
                        var approvalDetailsTable = document.AddTable(2, 1);
                        approvalDetailsTable.Rows[0].Cells[0].Paragraphs[0].Append("APPROVAL DETAILS").Bold(true).Color(Color.White);
                        approvalDetailsTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;

                        approvalDetailsTable.Rows[1].Cells[0].Paragraphs[0].Append(currentExpenseFormModel.ProjectDetails);

                        approvalDetailsTable.SetWidthsPercentage(new float[] { 100});
                        document.InsertTable(approvalDetailsTable);
                        //Code for a table


                        //Code for saving
                        try
                        {
                            document.Save();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("The selected File is open.", "Close File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        //Code for saving
                    }
                }
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
            string json = JsonHelper.loadProjectInfo(Settings.Default.Username);
            List<ProjectModel> projectListModel = JsonConvert.DeserializeObject<List<ProjectModel>>(json);
            projectModel = projectModel.getProjectModel(Settings.Default.ProjectID, projectListModel);
        }

        private void btnExportWord_Click(object sender, EventArgs e)
        {
            exportToWord();
        }
    }
}
