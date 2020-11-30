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
    public partial class QualityManagementProcessDocumentForm : Form
    {

        VersionControl<QualityManagementProcessModel> versionControl;
        QualityManagementProcessModel newQualityManagementProcessModel;
        QualityManagementProcessModel currentQualityManagementProcessModel;

        Color TABLE_HEADER_COLOR = Color.FromArgb(73, 173, 252);
        ProjectModel projectModel = new ProjectModel();



        public void saveDocument()
        {
            newQualityManagementProcessModel.DocumentID = dataGridView1.Rows[0].Cells[1].Value.ToString();
            newQualityManagementProcessModel.DocumentOwner = dataGridView1.Rows[1].Cells[1].Value.ToString();
            newQualityManagementProcessModel.IssueDate = dataGridView1.Rows[2].Cells[1].Value.ToString();
            newQualityManagementProcessModel.LastSavedDate = dataGridView1.Rows[3].Cells[1].Value.ToString();
            newQualityManagementProcessModel.FileName = dataGridView1.Rows[4].Cells[1].Value.ToString();

            List<QualityManagementProcessModel.DocumentHistory> documentHistories = new List<QualityManagementProcessModel.DocumentHistory>();

            int versionRowsCount = dataGridView2.Rows.Count;

            for (int i = 0; i < versionRowsCount - 1; i++)
            {
                QualityManagementProcessModel.DocumentHistory documentHistoryModel = new QualityManagementProcessModel.DocumentHistory();
                var version = dataGridView2.Rows[i].Cells[0].Value?.ToString() ?? "";
                var issueDate = dataGridView2.Rows[i].Cells[1].Value?.ToString() ?? "";
                var changes = dataGridView2.Rows[i].Cells[2].Value?.ToString() ?? "";
                documentHistoryModel.Version = version;
                documentHistoryModel.IssueDate = issueDate;
                documentHistoryModel.Changes = changes;
                documentHistories.Add(documentHistoryModel);
            }
            newQualityManagementProcessModel.DocumentHistories = documentHistories;

            List<QualityManagementProcessModel.DocumentApproval> documentApprovalsModel = new List<QualityManagementProcessModel.DocumentApproval>();

            int approvalRowsCount = dataGridView3.Rows.Count;

            for (int i = 0; i < approvalRowsCount - 1; i++)
            {
                QualityManagementProcessModel.DocumentApproval documentApproval = new QualityManagementProcessModel.DocumentApproval();
                var role = dataGridView3.Rows[i].Cells[0].Value?.ToString() ?? "";
                var name = dataGridView3.Rows[i].Cells[1].Value?.ToString() ?? "";
                var signature = dataGridView3.Rows[i].Cells[2].Value?.ToString() ?? "";
                var date = dataGridView3.Rows[i].Cells[3].Value?.ToString() ?? "";
                documentApproval.Role = role;
                documentApproval.Name = name;
                documentApproval.Signature = signature;
                documentApproval.DateApproved = date;

                documentApprovalsModel.Add(documentApproval);
            }
            newQualityManagementProcessModel.DocumentApprovals = documentApprovalsModel;



            newQualityManagementProcessModel.QualityprocessDescription = txtqualityprocessDescription.Text;

            newQualityManagementProcessModel.QualityprocessOverview = txtqualityprocessOverview.Text;

            newQualityManagementProcessModel.QualityprocessMeasureQualityAchieved = txtqualityprocessMeasureQualityAchieved.Text;

            newQualityManagementProcessModel.QualityprocessEnhanceQualityAchieved = txtqualityprocessEnhanceQualityAchieved.Text;

            newQualityManagementProcessModel.QualitymanagementrolesDescription = txtqualitymanagementrolesDescription.Text;

            newQualityManagementProcessModel.QualitymanagementrolesQualityManager = txtqualitymanagementrolesQualityManager.Text;

            newQualityManagementProcessModel.QualitymanagementrolesProjectManager = txtqualitymanagementrolesProjectManager.Text;

            newQualityManagementProcessModel.QualitymanagementdocumentsDescription = txtqualitymanagementdocumentsDescription.Text;

            newQualityManagementProcessModel.QualitymanagementdocumentsQualityRegister = txtqualitymanagementdocumentsQualityRegister.Text;

            newQualityManagementProcessModel.QualitymanagementdocumentsQualityReviewForm = txtqualitymanagementdocumentsQualityReviewForm.Text;



            List<VersionControl<QualityManagementProcessModel>.DocumentModel> documentModels = versionControl.DocumentModels;

            if (!versionControl.isEqual(currentQualityManagementProcessModel, newQualityManagementProcessModel))
            {
                VersionControl<QualityManagementProcessModel>.DocumentModel documentModel = new VersionControl<QualityManagementProcessModel>.DocumentModel(newQualityManagementProcessModel, DateTime.Now, VersionControl<ProjectModel>.generateID());

                documentModels.Add(documentModel);

                versionControl.DocumentModels = documentModels;

                string json = JsonConvert.SerializeObject(versionControl);
                JsonHelper.saveDocument(json, Settings.Default.ProjectID, "QualityManagement");
                MessageBox.Show("Quality Management Process saved successfully", "save", MessageBoxButtons.OK);
            }

        }



        private void loadDocument()
        {
            string json = JsonHelper.loadDocument(Settings.Default.ProjectID, "QualityManagement");
            List<string[]> documentInfo = new List<string[]>();
            newQualityManagementProcessModel = new QualityManagementProcessModel();
            currentQualityManagementProcessModel = new QualityManagementProcessModel();
            if (json != "")
            {
                versionControl = JsonConvert.DeserializeObject<VersionControl<QualityManagementProcessModel>>(json);
                newQualityManagementProcessModel = JsonConvert.DeserializeObject<QualityManagementProcessModel>(versionControl.getLatest(versionControl.DocumentModels));
                currentQualityManagementProcessModel = JsonConvert.DeserializeObject<QualityManagementProcessModel>(versionControl.getLatest(versionControl.DocumentModels));

                documentInfo.Add(new string[] { "Document ID", currentQualityManagementProcessModel.DocumentID });
                documentInfo.Add(new string[] { "Document Owner", currentQualityManagementProcessModel.DocumentOwner });
                documentInfo.Add(new string[] { "Issue Date", currentQualityManagementProcessModel.IssueDate });
                documentInfo.Add(new string[] { "Last Save Date", currentQualityManagementProcessModel.LastSavedDate });
                documentInfo.Add(new string[] { "File Name", currentQualityManagementProcessModel.FileName });

                foreach (var row in documentInfo)
                {
                    dataGridView1.Rows.Add(row);
                }
                dataGridView1.AllowUserToAddRows = false;

                foreach (var row in currentQualityManagementProcessModel.DocumentHistories)
                {
                    dataGridView2.Rows.Add(new string[] { row.Version, row.IssueDate, row.Changes });
                }

                foreach (var row in currentQualityManagementProcessModel.DocumentApprovals)
                {
                    dataGridView3.Rows.Add(new string[] { row.Role, row.Name, "", row.DateApproved });
                }



                txtqualityprocessDescription.Text = currentQualityManagementProcessModel.QualityprocessDescription  ;

                txtqualityprocessOverview.Text = currentQualityManagementProcessModel.QualityprocessOverview  ;

                txtqualityprocessMeasureQualityAchieved.Text = currentQualityManagementProcessModel.QualityprocessMeasureQualityAchieved  ;

                txtqualityprocessEnhanceQualityAchieved.Text = currentQualityManagementProcessModel.QualityprocessEnhanceQualityAchieved  ;

                txtqualitymanagementrolesDescription.Text = currentQualityManagementProcessModel.QualitymanagementrolesDescription  ;

                txtqualitymanagementrolesQualityManager.Text = currentQualityManagementProcessModel.QualitymanagementrolesQualityManager  ;

                txtqualitymanagementrolesProjectManager.Text = currentQualityManagementProcessModel.QualitymanagementrolesProjectManager  ;

                txtqualitymanagementdocumentsDescription.Text = currentQualityManagementProcessModel.QualitymanagementdocumentsDescription  ;

                txtqualitymanagementdocumentsQualityRegister.Text = currentQualityManagementProcessModel.QualitymanagementdocumentsQualityRegister  ;

                txtqualitymanagementdocumentsQualityReviewForm.Text = currentQualityManagementProcessModel.QualitymanagementdocumentsQualityReviewForm  ;
            }
            else
            {
                versionControl = new VersionControl<QualityManagementProcessModel>();
                versionControl.DocumentModels = new List<VersionControl<QualityManagementProcessModel>.DocumentModel>();
                documentInfo.Add(new string[] { "Document ID", "" });
                documentInfo.Add(new string[] { "Document Owner", "" });
                documentInfo.Add(new string[] { "Issue Date", "" });
                documentInfo.Add(new string[] { "Last Save Date", "" });
                documentInfo.Add(new string[] { "File Name", "" });
                newQualityManagementProcessModel = new QualityManagementProcessModel();
                foreach (var row in documentInfo)
                {
                    dataGridView1.Rows.Add(row);
                }
                dataGridView1.AllowUserToAddRows = false;
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
                        document.InsertParagraph("Quality Management Process \nFor " + projectModel.ProjectName)
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(22d).Alignment = Alignment.left;
                        document.InsertSectionPageBreak();
                        //Code for the Front page


                        //Code for the title of a page
                        document.InsertParagraph("Document Control\n")
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


                        //Code of a sentence
                        document.InsertParagraph("Document Information\n")
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(14d).Alignment = Alignment.left;
                        //Code of a sentence


                        //Code for a table
                        var documentInfoTable = document.AddTable(6, 2);
                        documentInfoTable.Rows[0].Cells[0].Paragraphs[0].Append("").Bold(true).Color(Color.White);
                        documentInfoTable.Rows[0].Cells[1].Paragraphs[0].Append("Information").Bold(true).Color(Color.White);
                        documentInfoTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        documentInfoTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;

                        documentInfoTable.Rows[1].Cells[0].Paragraphs[0].Append("Document ID");
                        documentInfoTable.Rows[1].Cells[1].Paragraphs[0].Append(currentQualityManagementProcessModel.DocumentID);

                        documentInfoTable.Rows[2].Cells[0].Paragraphs[0].Append("Document Owner");
                        documentInfoTable.Rows[2].Cells[1].Paragraphs[0].Append(currentQualityManagementProcessModel.DocumentOwner);

                        documentInfoTable.Rows[3].Cells[0].Paragraphs[0].Append("Issue Date");
                        documentInfoTable.Rows[3].Cells[1].Paragraphs[0].Append(currentQualityManagementProcessModel.IssueDate);

                        documentInfoTable.Rows[4].Cells[0].Paragraphs[0].Append("Last Saved Date");
                        documentInfoTable.Rows[4].Cells[1].Paragraphs[0].Append(currentQualityManagementProcessModel.LastSavedDate);

                        documentInfoTable.Rows[5].Cells[0].Paragraphs[0].Append("File Name");
                        documentInfoTable.Rows[5].Cells[1].Paragraphs[0].Append(currentQualityManagementProcessModel.FileName);
                        documentInfoTable.SetWidths(new float[] { 493, 1094 });
                        document.InsertTable(documentInfoTable);
                        //Code for a table


                        //Code of a sentence
                        document.InsertParagraph("\nDocument History\n")
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(14d).Alignment = Alignment.left;
                        //Code of a sentence


                        //Code for a table
                        var documentHistoryTable = document.AddTable(currentQualityManagementProcessModel.DocumentHistories.Count + 1, 3);
                        documentHistoryTable.Rows[0].Cells[0].Paragraphs[0].Append("Version")
                            .Bold(true)
                            .Color(Color.White);
                        documentHistoryTable.Rows[0].Cells[1].Paragraphs[0].Append("Issue Date")
                            .Bold(true)
                            .Color(Color.White);
                        documentHistoryTable.Rows[0].Cells[2].Paragraphs[0].Append("Changes")
                            .Bold(true)
                            .Color(Color.White);
                        documentHistoryTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        documentHistoryTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        documentHistoryTable.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;
                        for (int i = 1; i < currentQualityManagementProcessModel.DocumentHistories.Count + 1; i++)
                        {
                            documentHistoryTable.Rows[i].Cells[0].Paragraphs[0].Append(currentQualityManagementProcessModel.DocumentHistories[i - 1].Version);
                            documentHistoryTable.Rows[i].Cells[1].Paragraphs[0].Append(currentQualityManagementProcessModel.DocumentHistories[i - 1].IssueDate);
                            documentHistoryTable.Rows[i].Cells[2].Paragraphs[0].Append(currentQualityManagementProcessModel.DocumentHistories[i - 1].Changes);

                        }

                        documentHistoryTable.SetWidths(new float[] { 190, 303, 1094 });
                        document.InsertTable(documentHistoryTable);
                        //Code for a table


                        //Code of a sentence
                        document.InsertParagraph("\nDocument Approvals\n")
                           .Font("Arial")
                           .Bold(true)
                           .FontSize(14d).Alignment = Alignment.left;
                        //Code of a sentence


                        //Code for a table
                        var documentApprovalTable = document.AddTable(currentQualityManagementProcessModel.DocumentApprovals.Count + 1, 4);
                        documentApprovalTable.Rows[0].Cells[0].Paragraphs[0].Append("Role")
                            .Bold(true)
                            .Color(Color.White);
                        documentApprovalTable.Rows[0].Cells[1].Paragraphs[0].Append("Name")
                            .Bold(true)
                            .Color(Color.White);
                        documentApprovalTable.Rows[0].Cells[2].Paragraphs[0].Append("Signature")
                            .Bold(true)
                            .Color(Color.White);
                        documentApprovalTable.Rows[0].Cells[3].Paragraphs[0].Append("Date")
                            .Bold(true)
                            .Color(Color.White);
                        documentApprovalTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        documentApprovalTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        documentApprovalTable.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;
                        documentApprovalTable.Rows[0].Cells[3].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < currentQualityManagementProcessModel.DocumentApprovals.Count + 1; i++)
                        {
                            documentApprovalTable.Rows[i].Cells[0].Paragraphs[0].Append(currentQualityManagementProcessModel.DocumentApprovals[i - 1].Role);
                            documentApprovalTable.Rows[i].Cells[1].Paragraphs[0].Append(currentQualityManagementProcessModel.DocumentApprovals[i - 1].Name);
                            documentApprovalTable.Rows[i].Cells[2].Paragraphs[0].Append(currentQualityManagementProcessModel.DocumentApprovals[i - 1].Signature);
                            documentApprovalTable.Rows[i].Cells[3].Paragraphs[0].Append(currentQualityManagementProcessModel.DocumentApprovals[i - 1].DateApproved);
                        }
                        documentApprovalTable.SetWidths(new float[] { 493, 332, 508, 254 });
                        document.InsertTable(documentApprovalTable);
                        //Code for a table


                        //Code for a page break
                        document.InsertParagraph().InsertPageBreakAfterSelf();
                        //Code for a page break


                        //Code for a table of contents
                        var p = document.InsertParagraph();
                        var title = p.InsertParagraphBeforeSelf("Table of Contents").Bold().FontSize(20);

                        var tocSwitches = new Dictionary<TableOfContentsSwitches, string>()
                        {
                            { TableOfContentsSwitches.O, "1-3"},
                            { TableOfContentsSwitches.U, ""},
                            { TableOfContentsSwitches.Z, ""},
                            { TableOfContentsSwitches.H, ""}
                        };

                        document.InsertTableOfContents(p, "", tocSwitches);
                        //Code for a table of contents


                        //Code for a page break
                        document.InsertParagraph().InsertPageBreakAfterSelf();
                        //Code for a page break


                        //Code for a heading 1
                        var QualityProcessHeading = document.InsertParagraph("1 Quality Process")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        QualityProcessHeading.StyleId = "Heading1";
                        //Code for a heading 1


                        //Code for a heading 2
                        var OverviewSubHeading = document.InsertParagraph("1.1 Overview")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        OverviewSubHeading.StyleId = "Heading2";
                        //Code for a heading 2


                        //Code for a sentence
                        document.InsertParagraph(currentQualityManagementProcessModel.QualityprocessOverview)
                               .FontSize(11d)
                               .Color(Color.Black)
                               .Font("Arial").Alignment = Alignment.left;
                        //Code for a sentence


                        //Code for a heading 2
                        var MeasureQualityAchievedHeading = document.InsertParagraph("1.2 Measure Quality Achieved")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        MeasureQualityAchievedHeading.StyleId = "Heading2";
                        //Code for a heading 2


                        //Code for a sentence
                        document.InsertParagraph(currentQualityManagementProcessModel.QualityprocessMeasureQualityAchieved)
                               .FontSize(11d)
                               .Color(Color.Black)
                               .Font("Arial").Alignment = Alignment.left;
                        //Code for a sentence


                        //Code for a heading 2
                        var EnhanceQualityAchievedHeading = document.InsertParagraph("1.3 Enhance Quality Achieved")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        EnhanceQualityAchievedHeading.StyleId = "Heading2";
                        //Code for a heading 2


                        //Code for a sentence
                        document.InsertParagraph(currentQualityManagementProcessModel.QualityprocessEnhanceQualityAchieved)
                               .FontSize(11d)
                               .Color(Color.Black)
                               .Font("Arial").Alignment = Alignment.left;
                        //Code for a sentence




                        //Code for a heading 1
                        var QualityManagementRolesHeading = document.InsertParagraph("2 Quality Management Roles")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        QualityManagementRolesHeading.StyleId = "Heading1";
                        //Code for a heading 1


                        //Code for a heading 2
                        var QualityManagerHeading = document.InsertParagraph("2.1 Quality Manager")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        QualityManagerHeading.StyleId = "Heading2";
                        //Code for a heading 2


                        //Code for a sentence
                        document.InsertParagraph(currentQualityManagementProcessModel.QualitymanagementrolesQualityManager)
                               .FontSize(11d)
                               .Color(Color.Black)
                               .Font("Arial").Alignment = Alignment.left;
                        //Code for a sentence


                        //Code for a heading 2
                        var ProjectManagerHeading = document.InsertParagraph("2.2 Project Manager")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        ProjectManagerHeading.StyleId = "Heading2";
                        //Code for a heading 2


                        //Code for a sentence
                        document.InsertParagraph(currentQualityManagementProcessModel.QualitymanagementrolesProjectManager)
                               .FontSize(11d)
                               .Color(Color.Black)
                               .Font("Arial").Alignment = Alignment.left;
                        //Code for a sentence




                        //Code for a heading 1
                        var QualityManagementDocumentsHeading = document.InsertParagraph("3 Quality Management Documents")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        QualityManagementDocumentsHeading.StyleId = "Heading1";
                        //Code for a heading 1


                        //Code for a heading 2
                        var QualityRegisterHeading = document.InsertParagraph("3.1 Quality Register")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        QualityRegisterHeading.StyleId = "Heading2";
                        //Code for a heading 2


                        //Code for a sentence
                        document.InsertParagraph(currentQualityManagementProcessModel.QualitymanagementdocumentsQualityRegister)
                               .FontSize(11d)
                               .Color(Color.Black)
                               .Font("Arial").Alignment = Alignment.left;
                        //Code for a sentence


                        //Code for a heading 2
                        var QualityReviewFormHeading = document.InsertParagraph("3.2 Quality Review Form")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        QualityReviewFormHeading.StyleId = "Heading2";
                        //Code for a heading 2


                        //Code for a sentence
                        document.InsertParagraph(currentQualityManagementProcessModel.QualitymanagementdocumentsQualityReviewForm)
                               .FontSize(11d)
                               .Color(Color.Black)
                               .Font("Arial").Alignment = Alignment.left;
                        //Code for a sentence



                                               
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



        public QualityManagementProcessDocumentForm()
        {
            InitializeComponent();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtExecutiveSummary_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveDocument();
        }

        private void QualityManagementProcessDocumentForm_Load(object sender, EventArgs e)
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
