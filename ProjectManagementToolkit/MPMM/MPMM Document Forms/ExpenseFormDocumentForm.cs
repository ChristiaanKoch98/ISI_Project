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
            List<ExpenseFormModel.ProjectDetail> projectDetail = new List<ExpenseFormModel.ProjectDetail>();

            int projectInformationRowsCount = projectInformation.Rows.Count;

            for (int i = 0; i < projectInformationRowsCount - 1; i++)
            {
                ExpenseFormModel.ProjectDetail projectDetailModel = new ExpenseFormModel.ProjectDetail();
                var projectName = documentInformation.Rows[i].Cells[0].Value?.ToString() ?? "";
                var projectManager = documentInformation.Rows[i].Cells[1].Value?.ToString() ?? "";
                var teamMember = documentInformation.Rows[i].Cells[2].Value?.ToString() ?? "";

                projectDetailModel.ProjectName = projectName;
                projectDetailModel.ProjectManager = projectManager;
                projectDetailModel.TeamMember = teamMember;

                projectDetail.Add(projectDetailModel);
            }
            newExpenseFormModel.ProjectDetails = projectDetail;





            List<ExpenseFormModel.ExpenseDetail> expenseDetail = new List<ExpenseFormModel.ExpenseDetail>();

            int documentInformationRowsCount = documentInformation.Rows.Count;

            for (int i = 0; i < documentInformationRowsCount - 1; i++)
            {
                ExpenseFormModel.ExpenseDetail expenseDetailModel = new ExpenseFormModel.ExpenseDetail();
                var activityID = documentInformation.Rows[i].Cells[0].Value?.ToString() ?? "";
                var taskID = documentInformation.Rows[i].Cells[1].Value?.ToString() ?? "";
                var expenseDate = documentInformation.Rows[i].Cells[2].Value?.ToString() ?? "";
                var expenseType = documentInformation.Rows[i].Cells[3].Value?.ToString() ?? "";
                var expenseDescription = documentInformation.Rows[i].Cells[4].Value?.ToString() ?? "";
                var expenseAmount = documentInformation.Rows[i].Cells[5].Value?.ToString() ?? "";
                var payeeName = documentInformation.Rows[i].Cells[6].Value?.ToString() ?? "";
                var invoiceNumber = documentInformation.Rows[i].Cells[7].Value?.ToString() ?? "";

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







            List<ExpenseFormModel.SubmittedBy> submittedBy = new List<ExpenseFormModel.SubmittedBy>();

            int submittedByRowsCount = submitedBy.Rows.Count;

            for (int i = 0; i < submittedByRowsCount - 1; i++)
            {
                ExpenseFormModel.SubmittedBy submittedByModel = new ExpenseFormModel.SubmittedBy();
                var name = submitedBy.Rows[i].Cells[0].Value?.ToString() ?? "";
                var Signature = submitedBy.Rows[i].Cells[1].Value?.ToString() ?? "";
                var date = submitedBy.Rows[i].Cells[2].Value?.ToString() ?? "";

                submittedByModel.Name = name;
                submittedByModel.Signature = Signature;
                submittedByModel.Date = date;

                submittedBy.Add(submittedByModel);
            }
            newExpenseFormModel.SubmittedByDetails = submittedBy;




            List<ExpenseFormModel.ApprovedBy> approvedBy = new List<ExpenseFormModel.ApprovedBy>();

            int approvedByRowsCount = approvedByGV.Rows.Count;

            for (int i = 0; i < approvedByRowsCount - 1; i++)
            {
                ExpenseFormModel.ApprovedBy approvedByModel = new ExpenseFormModel.ApprovedBy();
                var name = approvedByGV.Rows[i].Cells[0].Value?.ToString() ?? "";
                var Signature = approvedByGV.Rows[i].Cells[1].Value?.ToString() ?? "";
                var date = approvedByGV.Rows[i].Cells[2].Value?.ToString() ?? "";

                approvedByModel.Name = name;
                approvedByModel.Signature = Signature;
                approvedByModel.Date = date;

                approvedBy.Add(approvedByModel);
            }
            newExpenseFormModel.ApprovedByDetails = approvedBy;





            newExpenseFormModel.ApprovalDetails = txtexecutivesummaryDescription.Text;


            List<VersionControl<ExpenseFormModel>.DocumentModel> documentModels = versionControl.DocumentModels;


            if (!versionControl.isEqual(currentExpenseFormModel, newExpenseFormModel))
            {
                VersionControl<ExpenseFormModel>.DocumentModel documentModel = new VersionControl<ExpenseFormModel>.DocumentModel(newExpenseFormModel, DateTime.Now, VersionControl<ProjectModel>.generateID());

                documentModels.Add(documentModel);

                versionControl.DocumentModels = documentModels;

                string json = JsonConvert.SerializeObject(versionControl);
                currentExpenseFormModel = JsonConvert.DeserializeObject<ExpenseFormModel>(JsonConvert.SerializeObject(newExpenseFormModel));
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

                    foreach (var row in currentExpenseFormModel.ProjectDetails)
                    {
                        projectInformation.Rows.Add(new string[] { row.ProjectName, row.ProjectManager, row.TeamMember });
                    }


                foreach (var row in currentExpenseFormModel.ExpenseDetails)
                    {
                        documentInformation.Rows.Add(new string[] { row.ActivityID, row.TaskID, row.ExpenseDate, row.ExpenseType, row.ExpenseDescription, row.ExpenseAmount, row.PayeeName, row.InvoiceNumber});
                    }


                    foreach (var row in currentExpenseFormModel.SubmittedByDetails)
                    {
                        submitedBy.Rows.Add(new string[] { row.Name, row.Signature, row.Date });
                    }


                    foreach (var row in currentExpenseFormModel.ApprovedByDetails)
                    {
                        approvedByGV.Rows.Add(new string[] { row.Name, row.Signature, row.Date });
                    }

                    txtexecutivesummaryDescription.Text = currentExpenseFormModel.ApprovalDetails;
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



                        //Code for a sentence
                        document.InsertParagraph("PROJECT DETAILS")
                               .FontSize(11d)
                               .Color(Color.Black)
                               .Font("Arial").Alignment = Alignment.left;
                        //Code for a sentence




                        //Code for a table
                        var projectDetailsTableTable = document.AddTable(currentExpenseFormModel.ProjectDetails.Count + 2, 3);
                        projectDetailsTableTable.Rows[0].Cells[0].Paragraphs[0].Append("Project Name").Bold(true).Color(Color.White);
                        projectDetailsTableTable.Rows[0].Cells[1].Paragraphs[0].Append("Project Manager").Bold(true).Color(Color.White);
                        projectDetailsTableTable.Rows[0].Cells[2].Paragraphs[0].Append("Team Member").Bold(true).Color(Color.White);


                        projectDetailsTableTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        projectDetailsTableTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        projectDetailsTableTable.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;


                        for (int i = 1; i < currentExpenseFormModel.ProjectDetails.Count + 1; i++)
                        {
                            projectDetailsTableTable.Rows[i].Cells[0].Paragraphs[0].Append(currentExpenseFormModel.ProjectDetails[i - 1].ProjectName);
                            projectDetailsTableTable.Rows[i].Cells[1].Paragraphs[0].Append(currentExpenseFormModel.ProjectDetails[i - 1].ProjectManager);
                            projectDetailsTableTable.Rows[i].Cells[2].Paragraphs[0].Append(currentExpenseFormModel.ProjectDetails[i - 1].TeamMember);
                        }


                        projectDetailsTableTable.SetWidths(new float[] { 300, 300, 300});
                        document.InsertTable(projectDetailsTableTable);
                        //Code for a table







                        //Code for a space
                        document.InsertParagraph("")
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(14d).Alignment = Alignment.left;
                        //Code for a space



                        //Code for a sentence
                        document.InsertParagraph("EXPENSE DETAILS")
                               .FontSize(11d)
                               .Color(Color.Black)
                               .Font("Arial").Alignment = Alignment.left;
                        //Code for a sentence


                        //Code for a table
                        var exspenseDetailsTableTable = document.AddTable(currentExpenseFormModel.ExpenseDetails.Count + 2, 8);
                        exspenseDetailsTableTable.Rows[0].Cells[0].Paragraphs[0].Append("Activity ID").Bold(true).Color(Color.White); ;
                        exspenseDetailsTableTable.Rows[0].Cells[1].Paragraphs[0].Append("Task ID").Bold(true).Color(Color.White); ;
                        exspenseDetailsTableTable.Rows[0].Cells[2].Paragraphs[0].Append("Expense Date").Bold(true).Color(Color.White); ;
                        exspenseDetailsTableTable.Rows[0].Cells[3].Paragraphs[0].Append("Expense Type").Bold(true).Color(Color.White); ;
                        exspenseDetailsTableTable.Rows[0].Cells[4].Paragraphs[0].Append("Expense Description").Bold(true).Color(Color.White); ;
                        exspenseDetailsTableTable.Rows[0].Cells[5].Paragraphs[0].Append("Expense Amount").Bold(true).Color(Color.White); ;
                        exspenseDetailsTableTable.Rows[0].Cells[6].Paragraphs[0].Append("Payee Name").Bold(true).Color(Color.White); ;
                        exspenseDetailsTableTable.Rows[0].Cells[7].Paragraphs[0].Append("Invoice Number").Bold(true).Color(Color.White); ;


                        exspenseDetailsTableTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        exspenseDetailsTableTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        exspenseDetailsTableTable.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;
                        exspenseDetailsTableTable.Rows[0].Cells[3].FillColor = TABLE_HEADER_COLOR;
                        exspenseDetailsTableTable.Rows[0].Cells[4].FillColor = TABLE_HEADER_COLOR;
                        exspenseDetailsTableTable.Rows[0].Cells[5].FillColor = TABLE_HEADER_COLOR;
                        exspenseDetailsTableTable.Rows[0].Cells[6].FillColor = TABLE_HEADER_COLOR;
                        exspenseDetailsTableTable.Rows[0].Cells[7].FillColor = TABLE_HEADER_COLOR;



                        for (int i = 1; i < currentExpenseFormModel.ExpenseDetails.Count + 1; i++)
                        {
                            exspenseDetailsTableTable.Rows[i].Cells[0].Paragraphs[0].Append(currentExpenseFormModel.ExpenseDetails[i - 1].ActivityID);
                            exspenseDetailsTableTable.Rows[i].Cells[1].Paragraphs[0].Append(currentExpenseFormModel.ExpenseDetails[i - 1].TaskID);
                            exspenseDetailsTableTable.Rows[i].Cells[2].Paragraphs[0].Append(currentExpenseFormModel.ExpenseDetails[i - 1].ExpenseDate);
                            exspenseDetailsTableTable.Rows[i].Cells[3].Paragraphs[0].Append(currentExpenseFormModel.ExpenseDetails[i - 1].ExpenseType);
                            exspenseDetailsTableTable.Rows[i].Cells[4].Paragraphs[0].Append(currentExpenseFormModel.ExpenseDetails[i - 1].ExpenseDescription);
                            exspenseDetailsTableTable.Rows[i].Cells[5].Paragraphs[0].Append(currentExpenseFormModel.ExpenseDetails[i - 1].ExpenseAmount);
                            exspenseDetailsTableTable.Rows[i].Cells[6].Paragraphs[0].Append(currentExpenseFormModel.ExpenseDetails[i - 1].PayeeName);
                            exspenseDetailsTableTable.Rows[i].Cells[7].Paragraphs[0].Append(currentExpenseFormModel.ExpenseDetails[i - 1].InvoiceNumber);
                        }


                        exspenseDetailsTableTable.SetWidths(new float[] { 100, 100, 100, 112, 112, 112, 112, 112 });
                        document.InsertTable(exspenseDetailsTableTable);
                        //Code for a table


                        //Code for a space
                        document.InsertParagraph("")
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(14d).Alignment = Alignment.left;
                        //Code for a space



                        //Code for a sentence
                        document.InsertParagraph("SUBMITTED BY")
                               .FontSize(11d)
                               .Color(Color.Black)
                               .Font("Arial").Alignment = Alignment.left;
                        //Code for a sentence



                        //Code for a table
                        var submittedByTable = document.AddTable(currentExpenseFormModel.SubmittedByDetails.Count + 2, 3);
                        submittedByTable.Rows[0].Cells[0].Paragraphs[0].Append("Name").Bold(true).Color(Color.White); ;
                        submittedByTable.Rows[0].Cells[1].Paragraphs[0].Append("Signature").Bold(true).Color(Color.White); ;
                        submittedByTable.Rows[0].Cells[2].Paragraphs[0].Append("Date").Bold(true).Color(Color.White); ;


                        submittedByTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        submittedByTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        submittedByTable.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;





                        for (int i = 1; i < currentExpenseFormModel.SubmittedByDetails.Count + 1; i++)
                        {
                            submittedByTable.Rows[i].Cells[0].Paragraphs[0].Append(currentExpenseFormModel.SubmittedByDetails[i - 1].Name);
                            submittedByTable.Rows[i].Cells[1].Paragraphs[0].Append(currentExpenseFormModel.SubmittedByDetails[i - 1].Signature);
                            submittedByTable.Rows[i].Cells[2].Paragraphs[0].Append(currentExpenseFormModel.SubmittedByDetails[i - 1].Date);
                        }


                        submittedByTable.SetWidths(new float[] { 300, 300, 300 });
                        document.InsertTable(submittedByTable);
                        //Code for a table



                        //Code for a space
                        document.InsertParagraph("")
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(14d).Alignment = Alignment.left;
                        //Code for a space




                        //Code for a sentence
                        document.InsertParagraph("APPROVED BY")
                               .FontSize(11d)
                               .Color(Color.Black)
                               .Font("Arial").Alignment = Alignment.left;
                        //Code for a sentence



                        //Code for a table
                        var approvedByTable = document.AddTable(currentExpenseFormModel.ApprovedByDetails.Count + 2, 3);

                        approvedByTable.Rows[0].Cells[0].Paragraphs[0].Append("Name").Bold(true).Color(Color.White); ;
                        approvedByTable.Rows[0].Cells[1].Paragraphs[0].Append("Signature").Bold(true).Color(Color.White); ;
                        approvedByTable.Rows[0].Cells[2].Paragraphs[0].Append("Date").Bold(true).Color(Color.White); ;


                        approvedByTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        approvedByTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        approvedByTable.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;




                        for (int i = 1; i < currentExpenseFormModel.ApprovedByDetails.Count + 1; i++)
                        {
                            approvedByTable.Rows[i].Cells[0].Paragraphs[0].Append(currentExpenseFormModel.ApprovedByDetails[i - 1].Name);
                            approvedByTable.Rows[i].Cells[1].Paragraphs[0].Append(currentExpenseFormModel.ApprovedByDetails[i - 1].Signature);
                            approvedByTable.Rows[i].Cells[2].Paragraphs[0].Append(currentExpenseFormModel.ApprovedByDetails[i - 1].Date);
                        }


                        approvedByTable.SetWidths(new float[] { 300, 300, 300 });
                        document.InsertTable(approvedByTable);
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
            
        }

        private void ExpenseFormDocumentForm_Load(object sender, EventArgs e)
        {
            
        }

        private void btnExportWord_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            saveDocument();
        }

        private void btnExportWord_Click_1(object sender, EventArgs e)
        {
            exportToWord();
        }

        private void ExpenseFormDocumentForm_Load_1(object sender, EventArgs e)
        {
            loadDocument();
            string json = JsonHelper.loadProjectInfo(Settings.Default.Username);
            List<ProjectModel> projectListModel = JsonConvert.DeserializeObject<List<ProjectModel>>(json);
            projectModel = projectModel.getProjectModel(Settings.Default.ProjectID, projectListModel);
        }
    }
}
