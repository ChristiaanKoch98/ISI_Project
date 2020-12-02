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
    public partial class AcceptanceManagementProcessDocumentForm : Form
    {

        VersionControl<AcceptanceManagementProcessModel> versionControl;
        AcceptanceManagementProcessModel newAcceptanceManagementProcessModel;
        AcceptanceManagementProcessModel currentAcceptanceManagementProcessModel;

        Color TABLE_HEADER_COLOR = Color.FromArgb(73, 173, 252);
        ProjectModel projectModel = new ProjectModel();



        public void saveDocument()
        {
            newAcceptanceManagementProcessModel.DocumentID = dataGridView1.Rows[0].Cells[1].Value.ToString();
            newAcceptanceManagementProcessModel.DocumentOwner = dataGridView1.Rows[1].Cells[1].Value.ToString();
            newAcceptanceManagementProcessModel.IssueDate = dataGridView1.Rows[2].Cells[1].Value.ToString();
            newAcceptanceManagementProcessModel.LastSavedDate = dataGridView1.Rows[3].Cells[1].Value.ToString();
            newAcceptanceManagementProcessModel.FileName = dataGridView1.Rows[4].Cells[1].Value.ToString();

            List<AcceptanceManagementProcessModel.DocumentHistory> documentHistories = new List<AcceptanceManagementProcessModel.DocumentHistory>();

            int versionRowsCount = dataGridView2.Rows.Count;

            for (int i = 0; i < versionRowsCount - 1; i++)
            {
                AcceptanceManagementProcessModel.DocumentHistory documentHistoryModel = new AcceptanceManagementProcessModel.DocumentHistory();
                var version = dataGridView2.Rows[i].Cells[0].Value?.ToString() ?? "";
                var issueDate = dataGridView2.Rows[i].Cells[1].Value?.ToString() ?? "";
                var changes = dataGridView2.Rows[i].Cells[2].Value?.ToString() ?? "";
                documentHistoryModel.Version = version;
                documentHistoryModel.IssueDate = issueDate;
                documentHistoryModel.Changes = changes;
                documentHistories.Add(documentHistoryModel);
            }
            newAcceptanceManagementProcessModel.DocumentHistories = documentHistories;

            List<AcceptanceManagementProcessModel.DocumentApproval> documentApprovalsModel = new List<AcceptanceManagementProcessModel.DocumentApproval>();

            int approvalRowsCount = dataGridView3.Rows.Count;

            for (int i = 0; i < approvalRowsCount - 1; i++)
            {
                AcceptanceManagementProcessModel.DocumentApproval documentApproval = new AcceptanceManagementProcessModel.DocumentApproval();
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
            newAcceptanceManagementProcessModel.DocumentApprovals = documentApprovalsModel;



            newAcceptanceManagementProcessModel.ProjectName = txtProjectName.Text;

            newAcceptanceManagementProcessModel.AcceptanceprocessDescription = txtacceptanceprocessDescription.Text;

            newAcceptanceManagementProcessModel.AcceptanceprocessOverview = txtacceptanceprocessOverview.Text;

            newAcceptanceManagementProcessModel.AcceptanceprocessCompleteDeliverable = txtacceptanceprocessCompleteDeliverable.Text;

            newAcceptanceManagementProcessModel.AcceptanceprocessCompleteAcceptanceTest = txtacceptanceprocessCompleteAcceptanceTest.Text;

            newAcceptanceManagementProcessModel.AcceptanceprocessAcceptDeliverable = txtacceptanceprocessAcceptDeliverable.Text;

            newAcceptanceManagementProcessModel.AcceptancerolesDescription = txtacceptancerolesDescription.Text;

            newAcceptanceManagementProcessModel.AcceptancerolesProjectManager = txtacceptancerolesProjectManager.Text;

            newAcceptanceManagementProcessModel.AcceptancerolesCustomer = txtacceptancerolesCustomer.Text;

            newAcceptanceManagementProcessModel.AcceptancedocumentsDescription = txtacceptancedocumentsDescription.Text;

            newAcceptanceManagementProcessModel.AcceptancedocumentsAcceptanceForm = txtacceptancedocumentsAcceptanceForm.Text;

            newAcceptanceManagementProcessModel.AcceptancedocumentsAcceptanceRegister = txtacceptancedocumentsAcceptanceRegister.Text;



            List<VersionControl<AcceptanceManagementProcessModel>.DocumentModel> documentModels = versionControl.DocumentModels;

            if (!versionControl.isEqual(currentAcceptanceManagementProcessModel, newAcceptanceManagementProcessModel))
            {
                VersionControl<AcceptanceManagementProcessModel>.DocumentModel documentModel = new VersionControl<AcceptanceManagementProcessModel>.DocumentModel(newAcceptanceManagementProcessModel, DateTime.Now, VersionControl<ProjectModel>.generateID());

                documentModels.Add(documentModel);

                versionControl.DocumentModels = documentModels;

                string json = JsonConvert.SerializeObject(versionControl);
                JsonHelper.saveDocument(json, Settings.Default.ProjectID, "AcceptanceManagementProcess");
                MessageBox.Show("Acceptance Management Process saved successfully", "save", MessageBoxButtons.OK);
            }

        }




        private void loadDocument()
        {
            string json = JsonHelper.loadDocument(Settings.Default.ProjectID, "AcceptanceManagementProcess");
            List<string[]> documentInfo = new List<string[]>();
            newAcceptanceManagementProcessModel = new AcceptanceManagementProcessModel();
            currentAcceptanceManagementProcessModel = new AcceptanceManagementProcessModel();
            if (json != "")
            {
                versionControl = JsonConvert.DeserializeObject<VersionControl<AcceptanceManagementProcessModel>>(json);
                newAcceptanceManagementProcessModel = JsonConvert.DeserializeObject<AcceptanceManagementProcessModel>(versionControl.getLatest(versionControl.DocumentModels));
                currentAcceptanceManagementProcessModel = JsonConvert.DeserializeObject<AcceptanceManagementProcessModel>(versionControl.getLatest(versionControl.DocumentModels));

                documentInfo.Add(new string[] { "Document ID", currentAcceptanceManagementProcessModel.DocumentID });
                documentInfo.Add(new string[] { "Document Owner", currentAcceptanceManagementProcessModel.DocumentOwner });
                documentInfo.Add(new string[] { "Issue Date", currentAcceptanceManagementProcessModel.IssueDate });
                documentInfo.Add(new string[] { "Last Save Date", currentAcceptanceManagementProcessModel.LastSavedDate });
                documentInfo.Add(new string[] { "File Name", currentAcceptanceManagementProcessModel.FileName });

                foreach (var row in documentInfo)
                {
                    dataGridView1.Rows.Add(row);
                }
                dataGridView1.AllowUserToAddRows = false;

                foreach (var row in currentAcceptanceManagementProcessModel.DocumentHistories)
                {
                    dataGridView2.Rows.Add(new string[] { row.Version, row.IssueDate, row.Changes });
                }

                foreach (var row in currentAcceptanceManagementProcessModel.DocumentApprovals)
                {
                    dataGridView3.Rows.Add(new string[] { row.Role, row.Name, "", row.DateApproved });
                }



                txtProjectName.Text = currentAcceptanceManagementProcessModel.ProjectName  ;

                txtacceptanceprocessDescription.Text = currentAcceptanceManagementProcessModel.AcceptanceprocessDescription  ;

                txtacceptanceprocessOverview.Text = currentAcceptanceManagementProcessModel.AcceptanceprocessOverview  ;

                txtacceptanceprocessCompleteDeliverable.Text = currentAcceptanceManagementProcessModel.AcceptanceprocessCompleteDeliverable  ;

                txtacceptanceprocessCompleteAcceptanceTest.Text = currentAcceptanceManagementProcessModel.AcceptanceprocessCompleteAcceptanceTest  ;

                txtacceptanceprocessAcceptDeliverable.Text = currentAcceptanceManagementProcessModel.AcceptanceprocessAcceptDeliverable  ;

                txtacceptancerolesDescription.Text = currentAcceptanceManagementProcessModel.AcceptancerolesDescription  ;

                txtacceptancerolesProjectManager.Text = currentAcceptanceManagementProcessModel.AcceptancerolesProjectManager  ;

                txtacceptancerolesCustomer.Text = currentAcceptanceManagementProcessModel.AcceptancerolesCustomer  ;

                txtacceptancedocumentsDescription.Text = currentAcceptanceManagementProcessModel.AcceptancedocumentsDescription  ;

                txtacceptancedocumentsAcceptanceForm.Text = currentAcceptanceManagementProcessModel.AcceptancedocumentsAcceptanceForm  ;

                txtacceptancedocumentsAcceptanceRegister.Text = currentAcceptanceManagementProcessModel.AcceptancedocumentsAcceptanceRegister  ;
            }
            else
            {
                versionControl = new VersionControl<AcceptanceManagementProcessModel>();
                versionControl.DocumentModels = new List<VersionControl<AcceptanceManagementProcessModel>.DocumentModel>();
                documentInfo.Add(new string[] { "Document ID", "" });
                documentInfo.Add(new string[] { "Document Owner", "" });
                documentInfo.Add(new string[] { "Issue Date", "" });
                documentInfo.Add(new string[] { "Last Save Date", "" });
                documentInfo.Add(new string[] { "File Name", "" });
                newAcceptanceManagementProcessModel = new AcceptanceManagementProcessModel();
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
                        document.InsertParagraph("Acceptance Management Process \nFor " + projectModel.ProjectName)
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
                        documentInfoTable.Rows[1].Cells[1].Paragraphs[0].Append(currentAcceptanceManagementProcessModel.DocumentID);

                        documentInfoTable.Rows[2].Cells[0].Paragraphs[0].Append("Document Owner");
                        documentInfoTable.Rows[2].Cells[1].Paragraphs[0].Append(currentAcceptanceManagementProcessModel.DocumentOwner);

                        documentInfoTable.Rows[3].Cells[0].Paragraphs[0].Append("Issue Date");
                        documentInfoTable.Rows[3].Cells[1].Paragraphs[0].Append(currentAcceptanceManagementProcessModel.IssueDate);

                        documentInfoTable.Rows[4].Cells[0].Paragraphs[0].Append("Last Saved Date");
                        documentInfoTable.Rows[4].Cells[1].Paragraphs[0].Append(currentAcceptanceManagementProcessModel.LastSavedDate);

                        documentInfoTable.Rows[5].Cells[0].Paragraphs[0].Append("File Name");
                        documentInfoTable.Rows[5].Cells[1].Paragraphs[0].Append(currentAcceptanceManagementProcessModel.FileName);
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
                        var documentHistoryTable = document.AddTable(currentAcceptanceManagementProcessModel.DocumentHistories.Count + 1, 3);
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
                        for (int i = 1; i < currentAcceptanceManagementProcessModel.DocumentHistories.Count + 1; i++)
                        {
                            documentHistoryTable.Rows[i].Cells[0].Paragraphs[0].Append(currentAcceptanceManagementProcessModel.DocumentHistories[i - 1].Version);
                            documentHistoryTable.Rows[i].Cells[1].Paragraphs[0].Append(currentAcceptanceManagementProcessModel.DocumentHistories[i - 1].IssueDate);
                            documentHistoryTable.Rows[i].Cells[2].Paragraphs[0].Append(currentAcceptanceManagementProcessModel.DocumentHistories[i - 1].Changes);

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
                        var documentApprovalTable = document.AddTable(currentAcceptanceManagementProcessModel.DocumentApprovals.Count + 1, 4);
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

                        for (int i = 1; i < currentAcceptanceManagementProcessModel.DocumentApprovals.Count + 1; i++)
                        {
                            documentApprovalTable.Rows[i].Cells[0].Paragraphs[0].Append(currentAcceptanceManagementProcessModel.DocumentApprovals[i - 1].Role);
                            documentApprovalTable.Rows[i].Cells[1].Paragraphs[0].Append(currentAcceptanceManagementProcessModel.DocumentApprovals[i - 1].Name);
                            documentApprovalTable.Rows[i].Cells[2].Paragraphs[0].Append(currentAcceptanceManagementProcessModel.DocumentApprovals[i - 1].Signature);
                            documentApprovalTable.Rows[i].Cells[3].Paragraphs[0].Append(currentAcceptanceManagementProcessModel.DocumentApprovals[i - 1].DateApproved);
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





                        // Code for a heading 1
 
                         var AcceptanceProcessHeading = document.InsertParagraph("1 Acceptance Process")
                             .Bold()
                             .FontSize(14d)
                             .Color(Color.Black)
                             .Bold(true)
                             .Font("Arial");

                        AcceptanceProcessHeading.StyleId = "Heading1";
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
                        document.InsertParagraph(currentAcceptanceManagementProcessModel.AcceptanceprocessOverview)
                               .FontSize(11d)
                               .Color(Color.Black)
                               .Font("Arial").Alignment = Alignment.left;
                        //Code for a sentence


                        //Code for a heading 2
                        var CompleteDeliverableAchievedHeading = document.InsertParagraph("1.2 Complete Deliverable")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        CompleteDeliverableAchievedHeading.StyleId = "Heading2";
                        //Code for a heading 2


                        //Code for a sentence
                        document.InsertParagraph(currentAcceptanceManagementProcessModel.AcceptanceprocessCompleteDeliverable)
                               .FontSize(11d)
                               .Color(Color.Black)
                               .Font("Arial").Alignment = Alignment.left;
                        //Code for a sentence


                        //Code for a heading 2
                        var CompleteAcceptanceTestHeading = document.InsertParagraph("1.3 Complete Acceptance Test")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        CompleteAcceptanceTestHeading.StyleId = "Heading2";
                        //Code for a heading 2


                        //Code for a sentence
                        document.InsertParagraph(currentAcceptanceManagementProcessModel.AcceptanceprocessCompleteAcceptanceTest)
                               .FontSize(11d)
                               .Color(Color.Black)
                               .Font("Arial").Alignment = Alignment.left;
                        //Code for a sentence


                        //Code for a heading 2
                        var AcceptDeliverableHeading = document.InsertParagraph("1.4 Accept Deliverable")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        AcceptDeliverableHeading.StyleId = "Heading2";
                        //Code for a heading 2


                        //Code for a sentence
                        document.InsertParagraph(currentAcceptanceManagementProcessModel.AcceptanceprocessAcceptDeliverable)
                               .FontSize(11d)
                               .Color(Color.Black)
                               .Font("Arial").Alignment = Alignment.left;
                        //Code for a sentence





                        // Code for a heading 1

                        var AcceptanceRolesHeading = document.InsertParagraph("2 Acceptance Roles")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        AcceptanceRolesHeading.StyleId = "Heading1";
                        //Code for a heading 1


                        //Code for a heading 2
                        var ProjectManagerHeading = document.InsertParagraph("2.1 Project Manager")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        ProjectManagerHeading.StyleId = "Heading2";
                        //Code for a heading 2


                        //Code for a sentence
                        document.InsertParagraph(currentAcceptanceManagementProcessModel.AcceptancerolesProjectManager)
                               .FontSize(11d)
                               .Color(Color.Black)
                               .Font("Arial").Alignment = Alignment.left;
                        //Code for a sentence


                        //Code for a heading 2
                        var CustomerHeading = document.InsertParagraph("2.2 Customer")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        CustomerHeading.StyleId = "Heading2";
                        //Code for a heading 2


                        //Code for a sentence
                        document.InsertParagraph(currentAcceptanceManagementProcessModel.AcceptancerolesCustomer)
                               .FontSize(11d)
                               .Color(Color.Black)
                               .Font("Arial").Alignment = Alignment.left;
                        //Code for a sentence




                        // Code for a heading 1

                        var AcceptanceDocumentsHeading = document.InsertParagraph("3 Acceptance Documents")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        AcceptanceDocumentsHeading.StyleId = "Heading1";
                        //Code for a heading 1


                        //Code for a heading 2
                        var AcceptanceFormHeading = document.InsertParagraph("3.1 Acceptance Form")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        AcceptanceFormHeading.StyleId = "Heading2";
                        //Code for a heading 2


                        //Code for a sentence
                        document.InsertParagraph(currentAcceptanceManagementProcessModel.AcceptancedocumentsAcceptanceForm)
                               .FontSize(11d)
                               .Color(Color.Black)
                               .Font("Arial").Alignment = Alignment.left;
                        //Code for a sentence


                        //Code for a heading 2
                        var AcceptanceRegisterHeading = document.InsertParagraph("3.2 Acceptance Register")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        AcceptanceRegisterHeading.StyleId = "Heading2";
                        //Code for a heading 2


                        //Code for a sentence
                        document.InsertParagraph(currentAcceptanceManagementProcessModel.AcceptancedocumentsAcceptanceRegister)
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







        public AcceptanceManagementProcessDocumentForm()
        {
            InitializeComponent();
        }

        private void txtEnvirAnalysis_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBusinessOppurtunity_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBusinessProblemDescription_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveDocument();
        }

        private void AcceptanceManagementProcessDocumentForm_Load(object sender, EventArgs e)
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

        private void AcceptanceManagementProcessDocumentForm_Load(object sender, EventArgs e)
        {

        }
    }
}
