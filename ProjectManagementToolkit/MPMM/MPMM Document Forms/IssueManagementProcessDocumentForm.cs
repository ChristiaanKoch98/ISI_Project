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
    public partial class IssueManagementProcessDocumentForm : Form
    {
        VersionControl<IssueManagementProcessModel> versionControl;
        IssueManagementProcessModel newIssueManagementProcessModel;
        IssueManagementProcessModel currentIssueManagementProcessModel;
        Color TABLE_HEADER_COLOR = Color.FromArgb(73, 173, 252);
        ProjectModel projectModel = new ProjectModel();

        public IssueManagementProcessDocumentForm()
        {
            InitializeComponent();
        }

        private void IssueManagementProcessDocumentForm_Load(object sender, EventArgs e)
        {
            loadDocument();
            string json = JsonHelper.loadProjectInfo(Settings.Default.Username);
            List<ProjectModel> projectListModel = JsonConvert.DeserializeObject<List<ProjectModel>>(json);
            projectModel = projectModel.getProjectModel(Settings.Default.ProjectID, projectListModel);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveDocument();
        }


        public void saveDocument()
        {
            newIssueManagementProcessModel.DocumentID = DocumentInfoGrid.Rows[0].Cells[1].Value.ToString();
            newIssueManagementProcessModel.DocumentOwner = DocumentInfoGrid.Rows[1].Cells[1].Value.ToString();
            newIssueManagementProcessModel.IssueDate = DocumentInfoGrid.Rows[2].Cells[1].Value.ToString();
            newIssueManagementProcessModel.LastSavedDate = DocumentInfoGrid.Rows[3].Cells[1].Value.ToString();
            newIssueManagementProcessModel.FileName = DocumentInfoGrid.Rows[4].Cells[1].Value.ToString();

            List<IssueManagementProcessModel.DocumentHistory> documentHistories = new List<IssueManagementProcessModel.DocumentHistory>();

            int versionRowsCount = docHistDataGrid.Rows.Count;

            for (int i = 0; i < versionRowsCount - 1; i++)
            {
                IssueManagementProcessModel.DocumentHistory documentHistoryModel = new IssueManagementProcessModel.DocumentHistory();
                var version = docHistDataGrid.Rows[i].Cells[0].Value?.ToString() ?? "";
                var issueDate = docHistDataGrid.Rows[i].Cells[1].Value?.ToString() ?? "";
                var changes = docHistDataGrid.Rows[i].Cells[2].Value?.ToString() ?? "";
                documentHistoryModel.Version = version;
                documentHistoryModel.IssueDate = issueDate;
                documentHistoryModel.Changes = changes;
                documentHistories.Add(documentHistoryModel);
            }
            newIssueManagementProcessModel.DocumentHistories = documentHistories;

            List<IssueManagementProcessModel.DocumentApproval> documentApprovalsModel = new List<IssueManagementProcessModel.DocumentApproval>();

            int approvalRowsCount = docApprovalsDataGrid.Rows.Count;

            for (int i = 0; i < approvalRowsCount - 1; i++)
            {
                IssueManagementProcessModel.DocumentApproval documentApproval = new IssueManagementProcessModel.DocumentApproval();
                var role = docApprovalsDataGrid.Rows[i].Cells[0].Value?.ToString() ?? "";
                var name = docApprovalsDataGrid.Rows[i].Cells[1].Value?.ToString() ?? "";
                var signature = docApprovalsDataGrid.Rows[i].Cells[2].Value?.ToString() ?? "";
                var date = docApprovalsDataGrid.Rows[i].Cells[3].Value?.ToString() ?? "";
                documentApproval.Role = role;
                documentApproval.Name = name;
                documentApproval.Signature = signature;
                documentApproval.DateApproved = date;

                documentApprovalsModel.Add(documentApproval);
            }
            newIssueManagementProcessModel.DocumentApprovals = documentApprovalsModel;

            newIssueManagementProcessModel.Overview = overviewTextBox.Text;
            newIssueManagementProcessModel.RaiseIssue = raiseIssueLabel.Text;
            newIssueManagementProcessModel.ReviewIssue = reviewIssueLabel.Text;
            newIssueManagementProcessModel.IssueAction = assgnActTextBox.Text;
            newIssueManagementProcessModel.TeamMember = textBox1.Text;
            newIssueManagementProcessModel.ProjectManager = textBox2.Text;
            newIssueManagementProcessModel.ProjectBoard = textBox3.Text;
            newIssueManagementProcessModel.IssueForm = issueFormTextBox.Text;
            newIssueManagementProcessModel.IssueRegister = issueRegisterTextBox.Text;

            List<VersionControl<IssueManagementProcessModel>.DocumentModel> documentModels = versionControl.DocumentModels;


            if (!versionControl.isEqual(currentIssueManagementProcessModel, newIssueManagementProcessModel))
            {
                VersionControl<IssueManagementProcessModel>.DocumentModel documentModel = new VersionControl<IssueManagementProcessModel>.DocumentModel(newIssueManagementProcessModel, DateTime.Now, VersionControl<ProjectModel>.generateID());

                documentModels.Add(documentModel);

                versionControl.DocumentModels = documentModels;

                string json = JsonConvert.SerializeObject(versionControl);
                JsonHelper.saveDocument(json, Settings.Default.ProjectID, "IssueManagementProcess");
                MessageBox.Show("Issue Management Process Document saved successfully", "save", MessageBoxButtons.OK);
            }

        }

        private void loadDocument()
        {
            string json = JsonHelper.loadDocument(Settings.Default.ProjectID, "IssueManagementProcess");
            List<string[]> documentInfo = new List<string[]>();
            newIssueManagementProcessModel = new IssueManagementProcessModel();
            currentIssueManagementProcessModel = new IssueManagementProcessModel();
            if (json != "")
            {
                versionControl = JsonConvert.DeserializeObject<VersionControl<IssueManagementProcessModel>>(json);
                newIssueManagementProcessModel = JsonConvert.DeserializeObject<IssueManagementProcessModel>(versionControl.getLatest(versionControl.DocumentModels));
                currentIssueManagementProcessModel = JsonConvert.DeserializeObject<IssueManagementProcessModel>(versionControl.getLatest(versionControl.DocumentModels));

                documentInfo.Add(new string[] { "Document ID", currentIssueManagementProcessModel.DocumentID });
                documentInfo.Add(new string[] { "Document Owner", currentIssueManagementProcessModel.DocumentOwner });
                documentInfo.Add(new string[] { "Issue Date", currentIssueManagementProcessModel.IssueDate });
                documentInfo.Add(new string[] { "Last Save Date", currentIssueManagementProcessModel.LastSavedDate });
                documentInfo.Add(new string[] { "File Name", currentIssueManagementProcessModel.FileName });

                foreach (var row in documentInfo)
                {
                    DocumentInfoGrid.Rows.Add(row);
                }
                DocumentInfoGrid.AllowUserToAddRows = false;

                foreach (var row in currentIssueManagementProcessModel.DocumentHistories)
                {
                    docHistDataGrid.Rows.Add(new string[] { row.Version, row.IssueDate, row.Changes });
                }

                foreach (var row in currentIssueManagementProcessModel.DocumentApprovals)
                {
                    docApprovalsDataGrid.Rows.Add(new string[] { row.Role, row.Name, "", row.DateApproved });
                }

                overviewTextBox.Text = currentIssueManagementProcessModel.Overview;
                raiseIssueLabel.Text = currentIssueManagementProcessModel.RaiseIssue;
                reviewIssueLabel.Text = currentIssueManagementProcessModel.ReviewIssue;
                assgnActTextBox.Text = currentIssueManagementProcessModel.IssueAction;
                textBox1.Text = currentIssueManagementProcessModel.TeamMember;
                textBox2.Text = currentIssueManagementProcessModel.ProjectManager;
                textBox3.Text = currentIssueManagementProcessModel.ProjectBoard;
                issueFormTextBox.Text = currentIssueManagementProcessModel.IssueForm;
                issueRegisterTextBox.Text = currentIssueManagementProcessModel.IssueRegister;
            }
            else
            {
                versionControl = new VersionControl<IssueManagementProcessModel>();
                versionControl.DocumentModels = new List<VersionControl<IssueManagementProcessModel>.DocumentModel>();
                documentInfo.Add(new string[] { "Document ID", "" });
                documentInfo.Add(new string[] { "Document Owner", "" });
                documentInfo.Add(new string[] { "Issue Date", "" });
                documentInfo.Add(new string[] { "Last Save Date", "" });
                documentInfo.Add(new string[] { "File Name", "" });
                newIssueManagementProcessModel = new IssueManagementProcessModel();
                foreach (var row in documentInfo)
                {
                    DocumentInfoGrid.Rows.Add(row);
                }
                DocumentInfoGrid.AllowUserToAddRows = false;

            }
        }

        private void btnExportIssueManagememnt_Click(object sender, EventArgs e)
        {
            exportToWord();
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
                        document.InsertParagraph("Issue Management Form \nFor " + projectModel.ProjectName)
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(22d).Alignment = Alignment.left;
                        document.InsertSectionPageBreak();
                        document.InsertParagraph("Document Control\n")
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(14d).Alignment = Alignment.left;
                        document.InsertParagraph("")
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(14d).Alignment = Alignment.left;
                        document.InsertParagraph("Document Information\n")
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(14d).Alignment = Alignment.left;

                        var documentInfoTable = document.AddTable(6, 2);
                        documentInfoTable.Rows[0].Cells[0].Paragraphs[0].Append("").Bold(true).Color(Color.White);
                        documentInfoTable.Rows[0].Cells[1].Paragraphs[0].Append("Information").Bold(true).Color(Color.White);
                        documentInfoTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        documentInfoTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;

                        documentInfoTable.Rows[1].Cells[0].Paragraphs[0].Append("Document ID");
                        documentInfoTable.Rows[1].Cells[1].Paragraphs[0].Append(currentIssueManagementProcessModel.DocumentID);

                        documentInfoTable.Rows[2].Cells[0].Paragraphs[0].Append("Document Owner");
                        documentInfoTable.Rows[2].Cells[1].Paragraphs[0].Append(currentIssueManagementProcessModel.DocumentOwner);

                        documentInfoTable.Rows[3].Cells[0].Paragraphs[0].Append("Issue Date");
                        documentInfoTable.Rows[3].Cells[1].Paragraphs[0].Append(currentIssueManagementProcessModel.IssueDate);

                        documentInfoTable.Rows[4].Cells[0].Paragraphs[0].Append("Last Saved Date");
                        documentInfoTable.Rows[4].Cells[1].Paragraphs[0].Append(currentIssueManagementProcessModel.LastSavedDate);

                        documentInfoTable.Rows[5].Cells[0].Paragraphs[0].Append("File Name");
                        documentInfoTable.Rows[5].Cells[1].Paragraphs[0].Append(currentIssueManagementProcessModel.FileName);
                        documentInfoTable.SetWidths(new float[] { 493, 1094 });
                        document.InsertTable(documentInfoTable);


                        //Document Histories
                        document.InsertParagraph("\nDocument History\n")
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(14d).Alignment = Alignment.left;

                        var documentHistoryTable = document.AddTable(currentIssueManagementProcessModel.DocumentHistories.Count + 1, 3);
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
                        for (int i = 1; i < currentIssueManagementProcessModel.DocumentHistories.Count + 1; i++)
                        {
                            documentHistoryTable.Rows[i].Cells[0].Paragraphs[0].Append(currentIssueManagementProcessModel.DocumentHistories[i - 1].Version);
                            documentHistoryTable.Rows[i].Cells[1].Paragraphs[0].Append(currentIssueManagementProcessModel.DocumentHistories[i - 1].IssueDate);
                            documentHistoryTable.Rows[i].Cells[2].Paragraphs[0].Append(currentIssueManagementProcessModel.DocumentHistories[i - 1].Changes);

                        }

                        documentHistoryTable.SetWidths(new float[] { 190, 303, 1094 });
                        document.InsertTable(documentHistoryTable);


                        //Document approvals
                        document.InsertParagraph("\nDocument Approvals\n")
                           .Font("Arial")
                           .Bold(true)
                           .FontSize(14d).Alignment = Alignment.left;

                        var documentApprovalTable = document.AddTable(currentIssueManagementProcessModel.DocumentApprovals.Count + 1, 4);
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

                        for (int i = 1; i < currentIssueManagementProcessModel.DocumentApprovals.Count + 1; i++)
                        {
                            documentApprovalTable.Rows[i].Cells[0].Paragraphs[0].Append(currentIssueManagementProcessModel.DocumentApprovals[i - 1].Role);
                            documentApprovalTable.Rows[i].Cells[1].Paragraphs[0].Append(currentIssueManagementProcessModel.DocumentApprovals[i - 1].Name);
                            documentApprovalTable.Rows[i].Cells[2].Paragraphs[0].Append(currentIssueManagementProcessModel.DocumentApprovals[i - 1].Signature);
                            documentApprovalTable.Rows[i].Cells[3].Paragraphs[0].Append(currentIssueManagementProcessModel.DocumentApprovals[i - 1].DateApproved);
                        }
                        documentApprovalTable.SetWidths(new float[] { 493, 332, 508, 254 });
                        document.InsertTable(documentApprovalTable);
                        document.InsertParagraph().InsertPageBreakAfterSelf();


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
                        document.InsertParagraph().InsertPageBreakAfterSelf();

                        //Issue Process/////
                        var introductionSubheading = document.InsertParagraph("1. Issue Process")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        introductionSubheading.StyleId = "Heading1";

                        //Overview
                        var overviewSubHeading = document.InsertParagraph("1.1 Overview")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        document.InsertParagraph(currentIssueManagementProcessModel.Overview)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        overviewSubHeading.StyleId = "Heading2";

                        //Raise Issue
                        var raiseIssueSubHeading = document.InsertParagraph("1.2 Raise Issue")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        document.InsertParagraph(currentIssueManagementProcessModel.RaiseIssue)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        raiseIssueSubHeading.StyleId = "Heading2";

                        //Review Issue 
                        var rreviewIssueSubHeading = document.InsertParagraph("1.3 Review Issue")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        document.InsertParagraph(currentIssueManagementProcessModel.ReviewIssue)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        rreviewIssueSubHeading.StyleId = "Heading2";

                        //Assign issue acction
                        var assignSubHeading = document.InsertParagraph("1.4 Assign issue action")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        document.InsertParagraph(currentIssueManagementProcessModel.IssueAction)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        assignSubHeading.StyleId = "Heading2";

                        //Issue Roles////////////////
                        var iissueRolesSubheading = document.InsertParagraph("2. Issue Roles")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        iissueRolesSubheading.StyleId = "Heading1";

                        //Team member
                        var teamMemberSubHeading = document.InsertParagraph("2.1 Team member")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        document.InsertParagraph(currentIssueManagementProcessModel.TeamMember)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        teamMemberSubHeading.StyleId = "Heading2";

                        //Project manager
                        var projectmanagerSubHeading = document.InsertParagraph("2.2 Project Manager")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        document.InsertParagraph(currentIssueManagementProcessModel.ProjectManager)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        projectmanagerSubHeading.StyleId = "Heading2";

                        //Project Board
                        var projectBoardSubHeading = document.InsertParagraph("2.3 Project board")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        document.InsertParagraph(currentIssueManagementProcessModel.ProjectBoard)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        projectBoardSubHeading.StyleId = "Heading2";

                        //Issue Document/////////////
                        var issueDocumentSubheading = document.InsertParagraph("3. Issue Document")
                           .Bold()
                           .FontSize(14d)
                           .Color(Color.Black)
                           .Bold(true)
                           .Font("Arial");

                        issueDocumentSubheading.StyleId = "Heading1";

                        //Issue form
                        var issueFormSubHeading = document.InsertParagraph("3.1 Issue Form")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        document.InsertParagraph(currentIssueManagementProcessModel.IssueForm)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        issueFormSubHeading.StyleId = "Heading2";

                        //Issue Register
                        var issueResisterSubHeading = document.InsertParagraph("3.2 Issue Register")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        document.InsertParagraph(currentIssueManagementProcessModel.IssueRegister)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        issueResisterSubHeading.StyleId = "Heading2";







                        //Save Document
                        try
                        {
                            document.Save();
                        }
                        catch
                        {
                            MessageBox.Show("The selected File is open.", "Close File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

       
    }
}
