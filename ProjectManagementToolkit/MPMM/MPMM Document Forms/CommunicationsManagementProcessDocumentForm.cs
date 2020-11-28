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
    public partial class CommunicationsManagementProcessDocumentForm : Form
    {
        VersionControl<CommunicationsManagementProcessModel> versionControl;
        CommunicationsManagementProcessModel newCommunicationsManagementProcessModel;
        CommunicationsManagementProcessModel currentCommunicationsManagementProcessModel;
        Color TABLE_HEADER_COLOR = Color.FromArgb(73, 173, 252);
        ProjectModel projectModel = new ProjectModel();
        public CommunicationsManagementProcessDocumentForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveDocument();
        }

        private void CommunicationsManagementProcessDocumentForm_Load(object sender, EventArgs e)
        {
            loadDocument();
            string json = JsonHelper.loadProjectInfo(Settings.Default.Username);
            List<ProjectModel> projectListModel = JsonConvert.DeserializeObject<List<ProjectModel>>(json);
            projectModel = projectModel.getProjectModel(Settings.Default.ProjectID, projectListModel);
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            exportToWord();
        }
        public void saveDocument()
        {
            newCommunicationsManagementProcessModel.DocumentID = documentInformation.Rows[0].Cells[1].Value.ToString();
            newCommunicationsManagementProcessModel.DocumentOwner = documentInformation.Rows[1].Cells[1].Value.ToString();
            newCommunicationsManagementProcessModel.IssueDate = documentInformation.Rows[2].Cells[1].Value.ToString();
            newCommunicationsManagementProcessModel.LastSavedDate = documentInformation.Rows[3].Cells[1].Value.ToString();
            newCommunicationsManagementProcessModel.FileName = documentInformation.Rows[4].Cells[1].Value.ToString();

            newCommunicationsManagementProcessModel.DocumentHistories = new List<CommunicationsManagementProcessModel.DocumentHistory>();
            int historyCount = documentHistory.Rows.Count;
            for (int i = 0; i < historyCount - 1; i++)
            {
                var version = documentHistory.Rows[i].Cells[0].Value?.ToString() ?? "";
                var issueDate = documentHistory.Rows[i].Cells[1].Value?.ToString() ?? "";
                var changes = documentHistory.Rows[i].Cells[2].Value?.ToString() ?? "";

                newCommunicationsManagementProcessModel.DocumentHistories
                    .Add(new CommunicationsManagementProcessModel.DocumentHistory(version, issueDate, changes));
            }

            newCommunicationsManagementProcessModel.DocumentApprovals = new List<CommunicationsManagementProcessModel.DocumentApproval>();
            int approvalRowsCount = documentApprovals.Rows.Count;
            for (int i = 0; i < approvalRowsCount - 1; i++)
            {
                var role = documentApprovals.Rows[i].Cells[0].Value?.ToString() ?? "";
                var name = documentApprovals.Rows[i].Cells[1].Value?.ToString() ?? "";
                var signature = documentApprovals.Rows[i].Cells[2].Value?.ToString() ?? "";
                var date = documentApprovals.Rows[i].Cells[3].Value?.ToString() ?? "";

                newCommunicationsManagementProcessModel.DocumentApprovals
                    .Add(new CommunicationsManagementProcessModel.DocumentApproval(role,name,signature,date));
            }

            newCommunicationsManagementProcessModel.CommunicationsDocumentsIntro = txtIntro.Text;
            newCommunicationsManagementProcessModel.Overview = txtOverview.Text;
            newCommunicationsManagementProcessModel.CreateMessage = createMessage.Text;
            newCommunicationsManagementProcessModel.CommunicateMessage = communicateMessage.Text;
            newCommunicationsManagementProcessModel.CommunicationsTeam = communicationsTeam.Text;
            newCommunicationsManagementProcessModel.ProjectManagerResponsibilities = projectManager.Text;
            newCommunicationsManagementProcessModel.ProjectStatusReport = projectStatusReport.Text;
            newCommunicationsManagementProcessModel.CommunicationsRegister = communicationsRegister.Text;

            List<VersionControl<CommunicationsManagementProcessModel>.DocumentModel> documentModels = versionControl.DocumentModels;

            if (!versionControl.isEqual(currentCommunicationsManagementProcessModel, newCommunicationsManagementProcessModel))
            {
                VersionControl<CommunicationsManagementProcessModel>.DocumentModel documentModel = new VersionControl<CommunicationsManagementProcessModel>
                    .DocumentModel(newCommunicationsManagementProcessModel, DateTime.Now, VersionControl<CommunicationsManagementProcessModel>.generateID());

                documentModels.Add(documentModel);

                versionControl.DocumentModels = documentModels;
                string json = JsonConvert.SerializeObject(versionControl);
                currentCommunicationsManagementProcessModel = JsonConvert.DeserializeObject<CommunicationsManagementProcessModel>(JsonConvert.SerializeObject(newCommunicationsManagementProcessModel));
                JsonHelper.saveDocument(json, Settings.Default.ProjectID, "CommunicationsManagementProcess");
                MessageBox.Show("Communications Management Process saved successfully", "save", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("No changes was made!", "save", MessageBoxButtons.OK);
            }
        }
        private void loadDocument()
        {
            string json = JsonHelper.loadDocument(Settings.Default.ProjectID, "CommunicationsManagementProcess");
            List<string[]> documentInfo = new List<string[]>();
            newCommunicationsManagementProcessModel = new CommunicationsManagementProcessModel();
            currentCommunicationsManagementProcessModel = new CommunicationsManagementProcessModel();
            if (json != "")
            {
                versionControl = JsonConvert.DeserializeObject<VersionControl<CommunicationsManagementProcessModel>>(json);
                newCommunicationsManagementProcessModel = JsonConvert.DeserializeObject<CommunicationsManagementProcessModel>(versionControl.getLatest(versionControl.DocumentModels));
                currentCommunicationsManagementProcessModel = JsonConvert.DeserializeObject<CommunicationsManagementProcessModel>(versionControl.getLatest(versionControl.DocumentModels));

                documentInfo.Add(new string[] { "Document ID", currentCommunicationsManagementProcessModel.DocumentID });
                documentInfo.Add(new string[] { "Document Owner", currentCommunicationsManagementProcessModel.DocumentOwner });
                documentInfo.Add(new string[] { "Issue Date", currentCommunicationsManagementProcessModel.IssueDate });
                documentInfo.Add(new string[] { "Last Save Date", currentCommunicationsManagementProcessModel.LastSavedDate });
                documentInfo.Add(new string[] { "File Name", currentCommunicationsManagementProcessModel.FileName });

                foreach (var row in documentInfo)
                {
                    documentInformation.Rows.Add(row);
                }
                documentInformation.AllowUserToAddRows = false;

                foreach (var row in currentCommunicationsManagementProcessModel.DocumentHistories)
                {
                    documentHistory.Rows.Add(new string[] { row.Version, row.IssueDate, row.Changes });
                }

                foreach (var row in currentCommunicationsManagementProcessModel.DocumentApprovals)
                {
                    documentApprovals.Rows.Add(new string[] { row.Role, row.Name, "", row.DateApproved });
                }

                txtOverview.Text = currentCommunicationsManagementProcessModel.Overview;
                txtIntro.Text = currentCommunicationsManagementProcessModel.CommunicationsDocumentsIntro;
                createMessage.Text = currentCommunicationsManagementProcessModel.CreateMessage;
                communicateMessage.Text = currentCommunicationsManagementProcessModel.CommunicateMessage;
                communicationsTeam.Text = currentCommunicationsManagementProcessModel.CommunicationsTeam;
                projectManager.Text = currentCommunicationsManagementProcessModel.ProjectManagerResponsibilities;
                projectStatusReport.Text = currentCommunicationsManagementProcessModel.ProjectStatusReport;
                communicationsRegister.Text = currentCommunicationsManagementProcessModel.CommunicationsRegister;

            }
            else
            {
                versionControl = new VersionControl<CommunicationsManagementProcessModel>();
                versionControl.DocumentModels = new List<VersionControl<CommunicationsManagementProcessModel>.DocumentModel>();
                documentInfo.Add(new string[] { "Document ID", "" });
                documentInfo.Add(new string[] { "Document Owner", "" });
                documentInfo.Add(new string[] { "Issue Date", "" });
                documentInfo.Add(new string[] { "Last Save Date", "" });
                documentInfo.Add(new string[] { "File Name", "" });
                foreach (var row in documentInfo)
                {
                    documentInformation.Rows.Add(row);
                }
                documentInformation.AllowUserToAddRows = false;
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
                        documentInfoTable.Rows[1].Cells[1].Paragraphs[0].Append(currentCommunicationsManagementProcessModel.DocumentID);

                        documentInfoTable.Rows[2].Cells[0].Paragraphs[0].Append("Document Owner");
                        documentInfoTable.Rows[2].Cells[1].Paragraphs[0].Append(currentCommunicationsManagementProcessModel.DocumentOwner);

                        documentInfoTable.Rows[3].Cells[0].Paragraphs[0].Append("Issue Date");
                        documentInfoTable.Rows[3].Cells[1].Paragraphs[0].Append(currentCommunicationsManagementProcessModel.IssueDate);

                        documentInfoTable.Rows[4].Cells[0].Paragraphs[0].Append("Last Saved Date");
                        documentInfoTable.Rows[4].Cells[1].Paragraphs[0].Append(currentCommunicationsManagementProcessModel.LastSavedDate);

                        documentInfoTable.Rows[5].Cells[0].Paragraphs[0].Append("File Name");
                        documentInfoTable.Rows[5].Cells[1].Paragraphs[0].Append(currentCommunicationsManagementProcessModel.FileName);
                        documentInfoTable.SetWidths(new float[] { 493, 1094 });
                        document.InsertTable(documentInfoTable);

                        document.InsertParagraph("\nDocument History\n")
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(14d).Alignment = Alignment.left;

                        var documentHistoryTable = document.AddTable(currentCommunicationsManagementProcessModel.DocumentHistories.Count + 1, 3);
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
                        for (int i = 1; i < currentCommunicationsManagementProcessModel.DocumentHistories.Count + 1; i++)
                        {
                            documentHistoryTable.Rows[i].Cells[0].Paragraphs[0].Append(currentCommunicationsManagementProcessModel.DocumentHistories[i - 1].Version);
                            documentHistoryTable.Rows[i].Cells[1].Paragraphs[0].Append(currentCommunicationsManagementProcessModel.DocumentHistories[i - 1].IssueDate);
                            documentHistoryTable.Rows[i].Cells[2].Paragraphs[0].Append(currentCommunicationsManagementProcessModel.DocumentHistories[i - 1].Changes);

                        }

                        documentHistoryTable.SetWidths(new float[] { 190, 303, 1094 });
                        document.InsertTable(documentHistoryTable);

                        document.InsertParagraph("\nDocument Approvals\n")
                           .Font("Arial")
                           .Bold(true)
                           .FontSize(14d).Alignment = Alignment.left;

                        var documentApprovalTable = document.AddTable(currentCommunicationsManagementProcessModel.DocumentApprovals.Count + 1, 4);
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

                        for (int i = 1; i < currentCommunicationsManagementProcessModel.DocumentApprovals.Count + 1; i++)
                        {
                            documentApprovalTable.Rows[i].Cells[0].Paragraphs[0].Append(currentCommunicationsManagementProcessModel.DocumentApprovals[i - 1].Role);
                            documentApprovalTable.Rows[i].Cells[1].Paragraphs[0].Append(currentCommunicationsManagementProcessModel.DocumentApprovals[i - 1].Name);
                            documentApprovalTable.Rows[i].Cells[2].Paragraphs[0].Append(currentCommunicationsManagementProcessModel.DocumentApprovals[i - 1].Signature);
                            documentApprovalTable.Rows[i].Cells[3].Paragraphs[0].Append(currentCommunicationsManagementProcessModel.DocumentApprovals[i - 1].DateApproved);
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

                        var CommunicationsProcessHeading = document.InsertParagraph("1\tCommunications Process")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        CommunicationsProcessHeading.StyleId = "Heading1";
                        document.InsertParagraph(currentCommunicationsManagementProcessModel.CommunicationsDocumentsIntro)
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
                        document.InsertParagraph(currentCommunicationsManagementProcessModel.Overview)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        var createMessage = document.InsertParagraph("1.2\tCreate Message")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        createMessage.StyleId = "Heading2";
                        document.InsertParagraph(currentCommunicationsManagementProcessModel.CreateMessage)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        var comMessage = document.InsertParagraph("1.3\tCommunicate Message")
                           .Bold()
                           .FontSize(12d)
                           .Color(Color.Black)
                           .Bold(true)
                           .Font("Arial");

                        comMessage.StyleId = "Heading2";

                        document.InsertParagraph(currentCommunicationsManagementProcessModel.CommunicateMessage)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        var comRoles = document.InsertParagraph("2\tCommunications Roles")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        comRoles.StyleId = "Heading1";

                        var comTeams = document.InsertParagraph("2.1\tCommunications Team")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        comTeams.StyleId = "Heading2";
                        document.InsertParagraph(currentCommunicationsManagementProcessModel.CommunicationsTeam)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        var projectMan = document.InsertParagraph("2.2\tProject Manager")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        projectMan.StyleId = "Heading2";

                        document.InsertParagraph(currentCommunicationsManagementProcessModel.ProjectManagerResponsibilities)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        var comDocs = document.InsertParagraph("3\tCommunications Documents")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        comDocs.StyleId = "Heading1";

                        var statusReport = document.InsertParagraph("3.1\tProject Status Report")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        statusReport.StyleId = "Heading2";

                        document.InsertParagraph(currentCommunicationsManagementProcessModel.ProjectStatusReport)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        var comReg = document.InsertParagraph("3.2\tCommunications Register")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        comReg.StyleId = "Heading2";

                        document.InsertParagraph(currentCommunicationsManagementProcessModel.CommunicationsRegister)
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
