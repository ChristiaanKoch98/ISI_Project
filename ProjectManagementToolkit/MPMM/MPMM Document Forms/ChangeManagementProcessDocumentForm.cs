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
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Forms
{
    public partial class ChangeManagementProcessDocumentForm : Form
    {
        VersionControl<ChangeManagementProcessModel> versionControl;
        ChangeManagementProcessModel newChangeManagementProcessModel;
        ChangeManagementProcessModel currentChangeManagementProcessModel;
        Color TABLE_HEADER_COLOR = Color.FromArgb(73, 173, 252);
        ProjectModel projectModel = new ProjectModel();
        public ChangeManagementProcessDocumentForm()
        {
            InitializeComponent();
        }

        private void ChangeManagementProcessDocumentForm_Load(object sender, EventArgs e)
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

        private void btnExport_Click(object sender, EventArgs e)
        {
            exportToWord();
        }

        public void saveDocument()
        {
            newChangeManagementProcessModel.DocumentID = dataGridViewDocumentInformation.Rows[0].Cells[1].Value.ToString();
            newChangeManagementProcessModel.DocumentOwner = dataGridViewDocumentInformation.Rows[1].Cells[1].Value.ToString();
            newChangeManagementProcessModel.IssueDate = dataGridViewDocumentInformation.Rows[2].Cells[1].Value.ToString();
            newChangeManagementProcessModel.LastSavedDate = dataGridViewDocumentInformation.Rows[3].Cells[1].Value.ToString();
            newChangeManagementProcessModel.FileName = dataGridViewDocumentInformation.Rows[4].Cells[1].Value.ToString();

            newChangeManagementProcessModel.DocumentHistories = new List<ChangeManagementProcessModel.DocumentHistory>();
            int historyCount = dataGridViewDocumentHistory.Rows.Count;
            for (int i = 0; i < historyCount - 1; i++)
            {
                var version = dataGridViewDocumentHistory.Rows[i].Cells[0].Value?.ToString() ?? "";
                var issueDate = dataGridViewDocumentHistory.Rows[i].Cells[1].Value?.ToString() ?? "";
                var changes = dataGridViewDocumentHistory.Rows[i].Cells[2].Value?.ToString() ?? "";

                newChangeManagementProcessModel.DocumentHistories
                    .Add(new ChangeManagementProcessModel.DocumentHistory(version, issueDate, changes));
            }

            newChangeManagementProcessModel.DocumentApprovals = new List<ChangeManagementProcessModel.DocumentApproval>();
            int approvalRowsCount = dataGridViewDocumentApprovals.Rows.Count;

            for (int i = 0; i < approvalRowsCount - 1; i++)
            {
                var role = dataGridViewDocumentApprovals.Rows[i].Cells[0].Value?.ToString() ?? "";
                var name = dataGridViewDocumentApprovals.Rows[i].Cells[1].Value?.ToString() ?? "";
                var signature = dataGridViewDocumentApprovals.Rows[i].Cells[2].Value?.ToString() ?? "";
                var date = dataGridViewDocumentApprovals.Rows[i].Cells[3].Value?.ToString() ?? "";

                newChangeManagementProcessModel.DocumentApprovals
                    .Add(new ChangeManagementProcessModel.DocumentApproval(role, name, signature, date));
            }

            newChangeManagementProcessModel.ChangeProcessDescription = txtChangeProcess.Text;
            newChangeManagementProcessModel.ChangeProcessOverview = txtOverview.Text;
            newChangeManagementProcessModel.ChangeProcessIdentifyChange = txtIdentifyChange.Text;
            newChangeManagementProcessModel.ChangeProcessReviewChange = txtReviewChange.Text;
            newChangeManagementProcessModel.ChangeProcessApproveChange = txtApproveChange.Text;
            newChangeManagementProcessModel.ChangeProcessImplementChange = txtImplementChange.Text;

            newChangeManagementProcessModel.ChangeRolesDescription = txtChangeRoles.Text;
            newChangeManagementProcessModel.ChangeRolesTeamMember = txtTeamMember.Text;
            newChangeManagementProcessModel.ChangeRolesProjectManager = txtProjectManager.Text;
            newChangeManagementProcessModel.ChangeRolesProjectBoard = txtProjectBoard.Text;

            newChangeManagementProcessModel.ChangeDocumentDescription = txtChangeDocuments.Text;
            newChangeManagementProcessModel.ChangeDocumentChangeRequestForm = txtChangeRequestForm.Text;
            newChangeManagementProcessModel.ChangeDocumentChangeRegister = txtChangeRegister.Text;


            List<VersionControl<ChangeManagementProcessModel>.DocumentModel> documentModels = versionControl.DocumentModels;

            if (!versionControl.isEqual(currentChangeManagementProcessModel, newChangeManagementProcessModel))
            {
                versionControl.DocumentModels.Add(new VersionControl<ChangeManagementProcessModel>
                    .DocumentModel(newChangeManagementProcessModel, DateTime.Now, VersionControl<ChangeManagementProcessModel>.generateID()));
                string json = JsonConvert.SerializeObject(versionControl);
                currentChangeManagementProcessModel = JsonConvert.DeserializeObject<ChangeManagementProcessModel>(JsonConvert.SerializeObject(newChangeManagementProcessModel));
                JsonHelper.saveDocument(json, Settings.Default.ProjectID, "ChangeManagementProcess");
                MessageBox.Show("Change Management Process saved successfully", "save", MessageBoxButtons.OK);

            }
            else
            {
                MessageBox.Show("No changes was made!", "save", MessageBoxButtons.OK);
            }


        }

        private void loadDocument()
        {
            string json = JsonHelper.loadDocument(Settings.Default.ProjectID, "ChangeManagementProcess");
            List<string[]> documentInfo = new List<string[]>();
            newChangeManagementProcessModel = new ChangeManagementProcessModel();
            currentChangeManagementProcessModel = new ChangeManagementProcessModel();
            if (json != "")
            {
                versionControl = JsonConvert.DeserializeObject<VersionControl<ChangeManagementProcessModel>>(json);
                newChangeManagementProcessModel = JsonConvert.DeserializeObject<ChangeManagementProcessModel>(versionControl.getLatest(versionControl.DocumentModels));
                currentChangeManagementProcessModel = JsonConvert.DeserializeObject<ChangeManagementProcessModel>(versionControl.getLatest(versionControl.DocumentModels));

                documentInfo.Add(new string[] { "Document ID", currentChangeManagementProcessModel.DocumentID });
                documentInfo.Add(new string[] { "Document Owner", currentChangeManagementProcessModel.DocumentOwner });
                documentInfo.Add(new string[] { "Issue Date", currentChangeManagementProcessModel.IssueDate });
                documentInfo.Add(new string[] { "Last Save Date", currentChangeManagementProcessModel.LastSavedDate });
                documentInfo.Add(new string[] { "File Name", currentChangeManagementProcessModel.FileName });

                foreach (var row in documentInfo)
                {
                    dataGridViewDocumentInformation.Rows.Add(row);
                }
                dataGridViewDocumentInformation.AllowUserToAddRows = false;

                foreach (var row in currentChangeManagementProcessModel.DocumentHistories)
                {
                    dataGridViewDocumentHistory.Rows.Add(new string[] { row.Version, row.IssueDate, row.Changes });
                }

                foreach (var row in currentChangeManagementProcessModel.DocumentApprovals)
                {
                    dataGridViewDocumentApprovals.Rows.Add(new string[] { row.Role, row.Name, "", row.DateApproved });
                }

                txtChangeManagementProcessProjectName.Text = projectModel.ProjectName;

                txtChangeProcess.Text = currentChangeManagementProcessModel.ChangeProcessDescription;
                txtOverview.Text = currentChangeManagementProcessModel.ChangeProcessOverview;
                txtIdentifyChange.Text = currentChangeManagementProcessModel.ChangeProcessIdentifyChange;
                txtReviewChange.Text = currentChangeManagementProcessModel.ChangeProcessReviewChange;
                txtApproveChange.Text = currentChangeManagementProcessModel.ChangeProcessApproveChange;
                txtImplementChange.Text = currentChangeManagementProcessModel.ChangeProcessImplementChange;

                txtChangeRoles.Text = currentChangeManagementProcessModel.ChangeRolesDescription;
                txtTeamMember.Text = currentChangeManagementProcessModel.ChangeRolesTeamMember;
                txtProjectManager.Text = currentChangeManagementProcessModel.ChangeRolesProjectManager;
                txtProjectBoard.Text = currentChangeManagementProcessModel.ChangeRolesProjectBoard;

                txtChangeDocuments.Text = currentChangeManagementProcessModel.ChangeDocumentDescription;
                txtChangeRequestForm.Text = currentChangeManagementProcessModel.ChangeDocumentChangeRequestForm;
                txtChangeRegister.Text = currentChangeManagementProcessModel.ChangeDocumentChangeRegister;

            }
            else
            {
                versionControl = new VersionControl<ChangeManagementProcessModel>();
                versionControl.DocumentModels = new List<VersionControl<ChangeManagementProcessModel>.DocumentModel>();
                documentInfo.Add(new string[] { "Document ID", "" });
                documentInfo.Add(new string[] { "Document Owner", "" });
                documentInfo.Add(new string[] { "Issue Date", "" });
                documentInfo.Add(new string[] { "Last Save Date", "" });
                documentInfo.Add(new string[] { "File Name", "" });
                foreach (var row in documentInfo)
                {
                    dataGridViewDocumentInformation.Rows.Add(row);
                }
                dataGridViewDocumentInformation.AllowUserToAddRows = false;
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

                        document.InsertParagraph("Communications Management Process \nFor " + projectModel.ProjectName)
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
                        documentInfoTable.Rows[1].Cells[1].Paragraphs[0].Append(currentChangeManagementProcessModel.DocumentID);

                        documentInfoTable.Rows[2].Cells[0].Paragraphs[0].Append("Document Owner");
                        documentInfoTable.Rows[2].Cells[1].Paragraphs[0].Append(currentChangeManagementProcessModel.DocumentOwner);

                        documentInfoTable.Rows[3].Cells[0].Paragraphs[0].Append("Issue Date");
                        documentInfoTable.Rows[3].Cells[1].Paragraphs[0].Append(currentChangeManagementProcessModel.IssueDate);

                        documentInfoTable.Rows[4].Cells[0].Paragraphs[0].Append("Last Saved Date");
                        documentInfoTable.Rows[4].Cells[1].Paragraphs[0].Append(currentChangeManagementProcessModel.LastSavedDate);

                        documentInfoTable.Rows[5].Cells[0].Paragraphs[0].Append("File Name");
                        documentInfoTable.Rows[5].Cells[1].Paragraphs[0].Append(currentChangeManagementProcessModel.FileName);
                        documentInfoTable.SetWidths(new float[] { 493, 1094 });
                        document.InsertTable(documentInfoTable);

                        document.InsertParagraph("\nDocument History\n")
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(14d).Alignment = Alignment.left;

                        var documentHistoryTable = document.AddTable(currentChangeManagementProcessModel.DocumentHistories.Count + 1, 3);
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
                        for (int i = 1; i < currentChangeManagementProcessModel.DocumentHistories.Count + 1; i++)
                        {
                            documentHistoryTable.Rows[i].Cells[0].Paragraphs[0].Append(currentChangeManagementProcessModel.DocumentHistories[i - 1].Version);
                            documentHistoryTable.Rows[i].Cells[1].Paragraphs[0].Append(currentChangeManagementProcessModel.DocumentHistories[i - 1].IssueDate);
                            documentHistoryTable.Rows[i].Cells[2].Paragraphs[0].Append(currentChangeManagementProcessModel.DocumentHistories[i - 1].Changes);

                        }

                        documentHistoryTable.SetWidths(new float[] { 190, 303, 1094 });
                        document.InsertTable(documentHistoryTable);

                        document.InsertParagraph("\nDocument Approvals\n")
                           .Font("Arial")
                           .Bold(true)
                           .FontSize(14d).Alignment = Alignment.left;

                        var documentApprovalTable = document.AddTable(currentChangeManagementProcessModel.DocumentApprovals.Count + 1, 4);
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

                        for (int i = 1; i < currentChangeManagementProcessModel.DocumentApprovals.Count + 1; i++)
                        {
                            documentApprovalTable.Rows[i].Cells[0].Paragraphs[0].Append(currentChangeManagementProcessModel.DocumentApprovals[i - 1].Role);
                            documentApprovalTable.Rows[i].Cells[1].Paragraphs[0].Append(currentChangeManagementProcessModel.DocumentApprovals[i - 1].Name);
                            documentApprovalTable.Rows[i].Cells[2].Paragraphs[0].Append(currentChangeManagementProcessModel.DocumentApprovals[i - 1].Signature);
                            documentApprovalTable.Rows[i].Cells[3].Paragraphs[0].Append(currentChangeManagementProcessModel.DocumentApprovals[i - 1].DateApproved);
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

                        var ChangeProcessHeading = document.InsertParagraph("1\tChange Process")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        ChangeProcessHeading.StyleId = "Heading1";

                        document.InsertParagraph(currentChangeManagementProcessModel.ChangeProcessDescription)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        var overview = document.InsertParagraph("1.1\tOverview")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        overview.StyleId = "Heading2";

                        document.InsertParagraph(currentChangeManagementProcessModel.ChangeProcessOverview)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        var identifyChange = document.InsertParagraph("1.2\tIdentify Change")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        identifyChange.StyleId = "Heading2";

                        document.InsertParagraph(currentChangeManagementProcessModel.ChangeProcessIdentifyChange)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        var reviewChange = document.InsertParagraph("1.3\tReview Change")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        reviewChange.StyleId = "Heading2";

                        document.InsertParagraph(currentChangeManagementProcessModel.ChangeProcessReviewChange)
                           .FontSize(11d)
                           .Color(Color.Black)
                           .Font("Arial").Alignment = Alignment.left;

                        var approveChange = document.InsertParagraph("1.4\tApprove Change")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        approveChange.StyleId = "Heading2";

                        document.InsertParagraph(currentChangeManagementProcessModel.ChangeProcessApproveChange)
                           .FontSize(11d)
                           .Color(Color.Black)
                           .Font("Arial").Alignment = Alignment.left;

                        var implementChange = document.InsertParagraph("1.5\tImplement Change")
                           .Bold()
                           .FontSize(12d)
                           .Color(Color.Black)
                           .Bold(true)
                           .Font("Arial");

                        implementChange.StyleId = "Heading2";

                        document.InsertParagraph(currentChangeManagementProcessModel.ChangeProcessImplementChange)
                           .FontSize(11d)
                           .Color(Color.Black)
                           .Font("Arial").Alignment = Alignment.left;

                        var ChangeRoles = document.InsertParagraph("2\tChange Roles")
                           .Bold()
                           .FontSize(14d)
                           .Color(Color.Black)
                           .Bold(true)
                           .Font("Arial");

                        ChangeRoles.StyleId = "Heading1";

                        document.InsertParagraph(currentChangeManagementProcessModel.ChangeRolesDescription)
                          .FontSize(11d)
                          .Color(Color.Black)
                          .Font("Arial").Alignment = Alignment.left;


                        var teamMember = document.InsertParagraph("2.1\tTeam  Member")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        teamMember.StyleId = "Heading2";

                        document.InsertParagraph(currentChangeManagementProcessModel.ChangeRolesTeamMember)
                          .FontSize(11d)
                          .Color(Color.Black)
                          .Font("Arial").Alignment = Alignment.left;

                        var projectManager = document.InsertParagraph("2.2\tProject Manager")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        projectManager.StyleId = "Heading2";

                        document.InsertParagraph(currentChangeManagementProcessModel.ChangeRolesProjectManager)
                          .FontSize(11d)
                          .Color(Color.Black)
                          .Font("Arial").Alignment = Alignment.left;

                        var projectBoard = document.InsertParagraph("2.3\tProject Board")
                          .Bold()
                          .FontSize(12d)
                          .Color(Color.Black)
                          .Bold(true)
                          .Font("Arial");

                        projectBoard.StyleId = "Heading2";

                        document.InsertParagraph(currentChangeManagementProcessModel.ChangeRolesProjectBoard)
                          .FontSize(11d)
                          .Color(Color.Black)
                          .Font("Arial").Alignment = Alignment.left;

                        var ChangeDocuments = document.InsertParagraph("3\tChange Documents")
                          .Bold()
                          .FontSize(14d)
                          .Color(Color.Black)
                          .Bold(true)
                          .Font("Arial");

                        ChangeDocuments.StyleId = "Heading1";

                        document.InsertParagraph(currentChangeManagementProcessModel.ChangeDocumentDescription)
                          .FontSize(11d)
                          .Color(Color.Black)
                          .Font("Arial").Alignment = Alignment.left;

                        var changeRequest = document.InsertParagraph("3.1\tChange Request Form")
                          .Bold()
                          .FontSize(12d)
                          .Color(Color.Black)
                          .Bold(true)
                          .Font("Arial");

                        changeRequest.StyleId = "Heading2";

                        document.InsertParagraph(currentChangeManagementProcessModel.ChangeDocumentChangeRequestForm)
                          .FontSize(11d)
                          .Color(Color.Black)
                          .Font("Arial").Alignment = Alignment.left;

                        var changeRegister = document.InsertParagraph("3.2\tChange Register")
                         .Bold()
                         .FontSize(12d)
                         .Color(Color.Black)
                         .Bold(true)
                         .Font("Arial");

                        changeRegister.StyleId = "Heading2";

                        document.InsertParagraph(currentChangeManagementProcessModel.ChangeDocumentChangeRegister)
                          .FontSize(11d)
                          .Color(Color.Black)
                          .Font("Arial").Alignment = Alignment.left;

                        try
                        {
                            document.Save();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("The selected File is open.", "Close File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                }

            }


        }

      
    }
}
