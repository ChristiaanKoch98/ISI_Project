using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectManagementToolkit.MPMM.MPMM_Document_Models;
using ProjectManagementToolkit.Utility;
using ProjectManagementToolkit.Properties;
using Newtonsoft.Json;
using MoreLinq;
using Xceed.Words.NET;
using Xceed.Document.NET;

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Forms
{
    public partial class RiskManagementProcessDocumentForm : Form
    {
        VersionControl<RiskManagmentProcessModel> versionControl;
        RiskManagmentProcessModel newRiskManagmentProcessModel;
        RiskManagmentProcessModel currentRiskManagmentProcessModel;
        Color TABLE_HEADER_COLOR = Color.FromArgb(73, 173, 252);
        ProjectModel projectModel = new ProjectModel();
        public RiskManagementProcessDocumentForm()
        {
            InitializeComponent();
        }

        private void RiskManagementProcessDocumentForm_Load(object sender, EventArgs e)
        {
            loadDocument();
        }

        private void loadDocument()
        {
            dgvDocumentInformation.Columns.Add("colType", "Type");
            dgvDocumentInformation.Columns.Add("colInformation", "Information");

            dgvDocumentHistory.Columns.Add("colVersion", "Version");
            dgvDocumentHistory.Columns.Add("colIssueDate", "Issue date");
            dgvDocumentHistory.Columns.Add("colChanges", "Changes");

            dgvDocumentApprovals.Columns.Add("colRole", "Role");
            dgvDocumentApprovals.Columns.Add("colName", "Name");
            dgvDocumentApprovals.Columns.Add("colSignature", "Signature");
            dgvDocumentApprovals.Columns.Add("colDateApproved", "Date approved");

            string json = JsonHelper.loadDocument(Settings.Default.ProjectID, "RiskManagamentProcess");
            List<string[]> documentInfo = new List<string[]>();
            newRiskManagmentProcessModel = new RiskManagmentProcessModel();
            currentRiskManagmentProcessModel = new RiskManagmentProcessModel();

            string jsonWord = JsonHelper.loadProjectInfo(Settings.Default.Username);
            List<ProjectModel> projectListModel = JsonConvert.DeserializeObject<List<ProjectModel>>(jsonWord);
            projectModel = projectModel.getProjectModel(Settings.Default.ProjectID, projectListModel);

            if (json != "")
            {
                versionControl = JsonConvert.DeserializeObject<VersionControl<RiskManagmentProcessModel>>(json);
                newRiskManagmentProcessModel = JsonConvert.DeserializeObject<RiskManagmentProcessModel>(versionControl.getLatest(versionControl.DocumentModels));
                currentRiskManagmentProcessModel = JsonConvert.DeserializeObject<RiskManagmentProcessModel>(versionControl.getLatest(versionControl.DocumentModels));

                documentInfo.Add(new string[] { "Document ID", currentRiskManagmentProcessModel.DocumentID });
                documentInfo.Add(new string[] { "Document Owner", currentRiskManagmentProcessModel.DocumentOwner });
                documentInfo.Add(new string[] { "Issue Date", currentRiskManagmentProcessModel.IssueDate });
                documentInfo.Add(new string[] { "Last Save Date", currentRiskManagmentProcessModel.LastSavedDate });
                documentInfo.Add(new string[] { "File Name", currentRiskManagmentProcessModel.FileName });

                foreach (var row in documentInfo)
                {
                    dgvDocumentInformation.Rows.Add(row);
                }
                dgvDocumentInformation.AllowUserToAddRows = false;

                foreach (var row in currentRiskManagmentProcessModel.DocumentHistories)
                {
                    dgvDocumentHistory.Rows.Add(new string[] { row.Version, row.IssueDate, row.Changes });
                }

                foreach (var row in currentRiskManagmentProcessModel.DocumentApprovals)
                {
                    dgvDocumentApprovals.Rows.Add(new string[] { row.Role, row.Name, row.Signature, row.DateApproved });
                }


                txtIdentifyRisk.Text = currentRiskManagmentProcessModel.IdentifyRisk;
                txtReviewRisk.Text = currentRiskManagmentProcessModel.ReviewRisk;
                txtAssignRiskActions.Text = currentRiskManagmentProcessModel.AssignRisk;

                txtTeamMember.Text = currentRiskManagmentProcessModel.TeamMember;
                txtProjectManager.Text = currentRiskManagmentProcessModel.ProjectManager;
                txtProjectBoard.Text = currentRiskManagmentProcessModel.ProjectBoard;

                txtRiskForm.Text = currentRiskManagmentProcessModel.RiskForm;
                txtRiskRegister.Text = currentRiskManagmentProcessModel.RiskRegister;
            }
            else
            {
                versionControl = new VersionControl<RiskManagmentProcessModel>();
                versionControl.DocumentModels = new List<VersionControl<RiskManagmentProcessModel>.DocumentModel>();
                documentInfo.Add(new string[] { "Document ID", "" });
                documentInfo.Add(new string[] { "Document Owner", "" });
                documentInfo.Add(new string[] { "Issue Date", "" });
                documentInfo.Add(new string[] { "Last Save Date", "" });
                documentInfo.Add(new string[] { "File Name", "" });
                newRiskManagmentProcessModel = new RiskManagmentProcessModel();

                foreach (var row in documentInfo)
                {
                    dgvDocumentInformation.Rows.Add(row);
                }
                dgvDocumentInformation.AllowUserToAddRows = false;
            }
        }

        private void saveDocument()
        {
            newRiskManagmentProcessModel.IdentifyRisk = txtIdentifyRisk.Text;
            newRiskManagmentProcessModel.ReviewRisk = txtReviewRisk.Text;
            newRiskManagmentProcessModel.AssignRisk = txtAssignRiskActions.Text;

            newRiskManagmentProcessModel.TeamMember = txtTeamMember.Text;
            newRiskManagmentProcessModel.ProjectManager = txtProjectManager.Text;
            newRiskManagmentProcessModel.ProjectBoard = txtProjectBoard.Text;

            newRiskManagmentProcessModel.RiskForm = txtRiskForm.Text;
            newRiskManagmentProcessModel.RiskRegister = txtRiskRegister.Text;

            newRiskManagmentProcessModel.DocumentID = dgvDocumentInformation.Rows[0].Cells[1].Value.ToString();
            newRiskManagmentProcessModel.DocumentOwner = dgvDocumentInformation.Rows[1].Cells[1].Value.ToString();
            newRiskManagmentProcessModel.IssueDate = dgvDocumentInformation.Rows[2].Cells[1].Value.ToString();
            newRiskManagmentProcessModel.LastSavedDate = dgvDocumentInformation.Rows[3].Cells[1].Value.ToString();
            newRiskManagmentProcessModel.FileName = dgvDocumentInformation.Rows[4].Cells[1].Value.ToString();



            List<RiskManagmentProcessModel.DocumentHistory> documentHistories = new List<RiskManagmentProcessModel.DocumentHistory>();

            int versionRowsCount = dgvDocumentHistory.Rows.Count;

            for (int i = 0; i < versionRowsCount - 1; i++)
            {
                RiskManagmentProcessModel.DocumentHistory documentHistoryModel = new RiskManagmentProcessModel.DocumentHistory();
                var version = dgvDocumentHistory.Rows[i].Cells[0].Value?.ToString() ?? "";
                var issueDate = dgvDocumentHistory.Rows[i].Cells[1].Value?.ToString() ?? "";
                var changes = dgvDocumentHistory.Rows[i].Cells[2].Value?.ToString() ?? "";
                documentHistoryModel.Version = version;
                documentHistoryModel.IssueDate = issueDate;
                documentHistoryModel.Changes = changes;
                documentHistories.Add(documentHistoryModel);
            }
            newRiskManagmentProcessModel.DocumentHistories = documentHistories;

            List<RiskManagmentProcessModel.DocumentApproval> documentApprovalsModel = new List<RiskManagmentProcessModel.DocumentApproval>();

            int approvalRowsCount = dgvDocumentApprovals.Rows.Count;

            for (int i = 0; i < approvalRowsCount - 1; i++)
            {
                RiskManagmentProcessModel.DocumentApproval documentApproval = new RiskManagmentProcessModel.DocumentApproval();
                var role = dgvDocumentApprovals.Rows[i].Cells[0].Value?.ToString() ?? "";
                var name = dgvDocumentApprovals.Rows[i].Cells[1].Value?.ToString() ?? "";
                var signature = dgvDocumentApprovals.Rows[i].Cells[2].Value?.ToString() ?? "";
                var date = dgvDocumentApprovals.Rows[i].Cells[3].Value?.ToString() ?? "";
                documentApproval.Role = role;
                documentApproval.Name = name;
                documentApproval.Signature = signature;
                documentApproval.DateApproved = date;

                documentApprovalsModel.Add(documentApproval);
            }
        
            newRiskManagmentProcessModel.DocumentApprovals = documentApprovalsModel;

            List<VersionControl<RiskManagmentProcessModel>.DocumentModel> documentModels = versionControl.DocumentModels;
            if (!versionControl.isEqual(currentRiskManagmentProcessModel, newRiskManagmentProcessModel))
            {
                VersionControl<RiskManagmentProcessModel>.DocumentModel documentModel = new VersionControl<RiskManagmentProcessModel>.DocumentModel(newRiskManagmentProcessModel, DateTime.Now, VersionControl<ProjectModel>.generateID());

                documentModels.Add(documentModel);

                versionControl.DocumentModels = documentModels;

                string json = JsonConvert.SerializeObject(versionControl);
                currentRiskManagmentProcessModel = JsonConvert.DeserializeObject<RiskManagmentProcessModel>(JsonConvert.SerializeObject(newRiskManagmentProcessModel));

                JsonHelper.saveDocument(json, Settings.Default.ProjectID, "RiskManagamentProcess");
                MessageBox.Show("Risk management saved successfully", "save", MessageBoxButtons.OK);
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
                        document.InsertParagraph("Risk managment plan \nFor " + projectModel.ProjectName)
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
                        documentInfoTable.Rows[1].Cells[1].Paragraphs[0].Append(currentRiskManagmentProcessModel.DocumentID);

                        documentInfoTable.Rows[2].Cells[0].Paragraphs[0].Append("Document Owner");
                        documentInfoTable.Rows[2].Cells[1].Paragraphs[0].Append(currentRiskManagmentProcessModel.DocumentOwner);

                        documentInfoTable.Rows[3].Cells[0].Paragraphs[0].Append("Issue Date");
                        documentInfoTable.Rows[3].Cells[1].Paragraphs[0].Append(currentRiskManagmentProcessModel.IssueDate);

                        documentInfoTable.Rows[4].Cells[0].Paragraphs[0].Append("Last Saved Date");
                        documentInfoTable.Rows[4].Cells[1].Paragraphs[0].Append(currentRiskManagmentProcessModel.LastSavedDate);

                        documentInfoTable.Rows[5].Cells[0].Paragraphs[0].Append("File Name");
                        documentInfoTable.Rows[5].Cells[1].Paragraphs[0].Append(currentRiskManagmentProcessModel.FileName);
                        documentInfoTable.SetWidths(new float[] { 493, 1094 });
                        document.InsertTable(documentInfoTable);

                        document.InsertParagraph("\nDocument History\n")
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(14d).Alignment = Alignment.left;

                        var documentHistoryTable = document.AddTable(currentRiskManagmentProcessModel.DocumentHistories.Count + 1, 3);
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
                        for (int i = 1; i < currentRiskManagmentProcessModel.DocumentHistories.Count + 1; i++)
                        {
                            documentHistoryTable.Rows[i].Cells[0].Paragraphs[0].Append(currentRiskManagmentProcessModel.DocumentHistories[i - 1].Version);
                            documentHistoryTable.Rows[i].Cells[1].Paragraphs[0].Append(currentRiskManagmentProcessModel.DocumentHistories[i - 1].IssueDate);
                            documentHistoryTable.Rows[i].Cells[2].Paragraphs[0].Append(currentRiskManagmentProcessModel.DocumentHistories[i - 1].Changes);

                        }

                        documentHistoryTable.SetWidths(new float[] { 190, 303, 1094 });
                        document.InsertTable(documentHistoryTable);

                        document.InsertParagraph("\nDocument Approvals\n")
                           .Font("Arial")
                           .Bold(true)
                           .FontSize(14d).Alignment = Alignment.left;

                        var documentApprovalTable = document.AddTable(currentRiskManagmentProcessModel.DocumentApprovals.Count + 1, 4);
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

                        for (int i = 1; i < currentRiskManagmentProcessModel.DocumentApprovals.Count + 1; i++)
                        {
                            documentApprovalTable.Rows[i].Cells[0].Paragraphs[0].Append(currentRiskManagmentProcessModel.DocumentApprovals[i - 1].Role);
                            documentApprovalTable.Rows[i].Cells[1].Paragraphs[0].Append(currentRiskManagmentProcessModel.DocumentApprovals[i - 1].Name);
                            documentApprovalTable.Rows[i].Cells[2].Paragraphs[0].Append(currentRiskManagmentProcessModel.DocumentApprovals[i - 1].Signature);
                            documentApprovalTable.Rows[i].Cells[3].Paragraphs[0].Append(currentRiskManagmentProcessModel.DocumentApprovals[i - 1].DateApproved);
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

                        var riskHeading = document.InsertParagraph("1 Risk process")
                           .Bold()
                           .FontSize(14d)
                           .Color(Color.Black)
                           .Bold(true)
                           .Font("Arial");

                        riskHeading.StyleId = "Heading1";

                        var idrHeading = document.InsertParagraph("1.1 Identify risk")
                     .Bold()
                     .FontSize(12d)
                     .Color(Color.Black)
                     .Bold(true)
                     .Font("Arial");

                        document.InsertParagraph(currentRiskManagmentProcessModel.IdentifyRisk)
                             .FontSize(11d)
                             .Color(Color.Black)
                             .Font("Arial").Alignment = Alignment.left;


                        idrHeading.StyleId = "Heading2";

                        var reHeading = document.InsertParagraph("1.2 Review risk")
                     .Bold()
                     .FontSize(12d)
                     .Color(Color.Black)
                     .Bold(true)
                     .Font("Arial");

                        document.InsertParagraph(currentRiskManagmentProcessModel.ReviewRisk)
                             .FontSize(11d)
                             .Color(Color.Black)
                             .Font("Arial").Alignment = Alignment.left;


                        reHeading.StyleId = "Heading2";

                        var ractionHeading = document.InsertParagraph("1.3 Assign risk Action")
                    .Bold()
                    .FontSize(12d)
                    .Color(Color.Black)
                    .Bold(true)
                    .Font("Arial");

                        document.InsertParagraph(currentRiskManagmentProcessModel.AssignRisk)
                             .FontSize(11d)
                             .Color(Color.Black)
                             .Font("Arial").Alignment = Alignment.left;


                        ractionHeading.StyleId = "Heading2";

                        var rrolesHeading = document.InsertParagraph("2 Risk Roles")
                           .Bold()
                           .FontSize(14d)
                           .Color(Color.Black)
                           .Bold(true)
                           .Font("Arial");

                        rrolesHeading.StyleId = "Heading1";

                        var tmHeading = document.InsertParagraph("2.1 Team member")
                     .Bold()
                     .FontSize(12d)
                     .Color(Color.Black)
                     .Bold(true)
                     .Font("Arial");

                        document.InsertParagraph(currentRiskManagmentProcessModel.TeamMember)
                             .FontSize(11d)
                             .Color(Color.Black)
                             .Font("Arial").Alignment = Alignment.left;


                        tmHeading.StyleId = "Heading2";

                        var pmHeading = document.InsertParagraph("2.2 Project Manager")
                     .Bold()
                     .FontSize(12d)
                     .Color(Color.Black)
                     .Bold(true)
                     .Font("Arial");

                        document.InsertParagraph(currentRiskManagmentProcessModel.ProjectManager)
                             .FontSize(11d)
                             .Color(Color.Black)
                             .Font("Arial").Alignment = Alignment.left;


                        pmHeading.StyleId = "Heading2";

                        var boardHeading = document.InsertParagraph("2.3 Project Board")
                    .Bold()
                    .FontSize(12d)
                    .Color(Color.Black)
                    .Bold(true)
                    .Font("Arial");

                        document.InsertParagraph(currentRiskManagmentProcessModel.ProjectBoard)
                             .FontSize(11d)
                             .Color(Color.Black)
                             .Font("Arial").Alignment = Alignment.left;


                        boardHeading.StyleId = "Heading2";

                        var rdHeading = document.InsertParagraph("3 Risk documents")
                           .Bold()
                           .FontSize(14d)
                           .Color(Color.Black)
                           .Bold(true)
                           .Font("Arial");

                        rrolesHeading.StyleId = "Heading1";

                        var rfHeading = document.InsertParagraph("3.1 Risk Form")
                     .Bold()
                     .FontSize(12d)
                     .Color(Color.Black)
                     .Bold(true)
                     .Font("Arial");

                        document.InsertParagraph(currentRiskManagmentProcessModel.RiskForm)
                             .FontSize(11d)
                             .Color(Color.Black)
                             .Font("Arial").Alignment = Alignment.left;


                        rfHeading.StyleId = "Heading2";

                        var rregHeading = document.InsertParagraph("3.2 Risk register")
                     .Bold()
                     .FontSize(12d)
                     .Color(Color.Black)
                     .Bold(true)
                     .Font("Arial");

                        document.InsertParagraph(currentRiskManagmentProcessModel.RiskRegister)
                             .FontSize(11d)
                             .Color(Color.Black)
                             .Font("Arial").Alignment = Alignment.left;


                        rregHeading.StyleId = "Heading2";

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

        private void button1_Click(object sender, EventArgs e)
        {
            saveDocument();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            exportToWord();
        }
    }
}
