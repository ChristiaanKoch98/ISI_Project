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
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Forms
{
    public partial class CommunicationsPlanDocumentForm : Form
    {
        VersionControl<CommunicationsPlanModel> versionControl;
        CommunicationsPlanModel newCommunicationsPlanModel;
        CommunicationsPlanModel currentCommunicationsPlanModel;
        Color TABLE_HEADER_COLOR = Color.FromArgb(73, 173, 252);
        ProjectModel projectModel = new ProjectModel();

        public CommunicationsPlanDocumentForm()
        {
            InitializeComponent();
        }

        private void txtStakeholderList_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtScope_TextChanged(object sender, EventArgs e)
        {

        }

        private void CommunicationsPlanDocumentForm_Load(object sender, EventArgs e)
        {
            loadDocument();
            
        }

        private void loadDocument()
        {
            dgvDocumentHistory.Columns.Add("colVersion", "Version");
            dgvDocumentHistory.Columns.Add("colIssueDate", "Issue date");
            dgvDocumentHistory.Columns.Add("colChanges", "Changes");

            dgvDocumentApprovals.Columns.Add("colRole", "Role");
            dgvDocumentApprovals.Columns.Add("colName", "Name");
            dgvDocumentApprovals.Columns.Add("colSignature", "Signature");
            dgvDocumentApprovals.Columns.Add("colDateApproved", "Date approved");

            dgvStakeholderRequirements.Columns.Add("colStakeName", "Stakeholder Name");
            dgvStakeholderRequirements.Columns.Add("colStakeRole", "Stakeholder Role");
            dgvStakeholderRequirements.Columns.Add("colStakeOrg", "Stakeholder organization");
            dgvStakeholderRequirements.Columns.Add("colInfoReq", "Information required"); 

            dgvDocumentInformation.Columns.Add("colDocID", "Document ID");
            dgvDocumentInformation.Columns.Add("colDocOwner", "Stakeholder Document owner");
            dgvDocumentInformation.Columns.Add("colIssueDate", "Issue date");
            dgvDocumentInformation.Columns.Add("colLastSaveDate", "Last save date");
            dgvDocumentInformation.Columns.Add("colFileName", "File Name");

            string json = JsonHelper.loadDocument(Settings.Default.ProjectID, "CommunicationPlan");
            List<string[]> documentInfo = new List<string[]>();
            newCommunicationsPlanModel = new CommunicationsPlanModel();
            currentCommunicationsPlanModel = new CommunicationsPlanModel();

            string jsonWord = JsonHelper.loadProjectInfo(Settings.Default.Username);
            List<ProjectModel> projectListModel = JsonConvert.DeserializeObject<List<ProjectModel>>(jsonWord);
            projectModel = projectModel.getProjectModel(Settings.Default.ProjectID, projectListModel);

            if (json != "")
            {
                versionControl = JsonConvert.DeserializeObject<VersionControl<CommunicationsPlanModel>>(json);
                newCommunicationsPlanModel = JsonConvert.DeserializeObject<CommunicationsPlanModel>(versionControl.getLatest(versionControl.DocumentModels));
                currentCommunicationsPlanModel = JsonConvert.DeserializeObject<CommunicationsPlanModel>(versionControl.getLatest(versionControl.DocumentModels));

                documentInfo.Add(new string[] { "Document ID", currentCommunicationsPlanModel.DocumentID });
                documentInfo.Add(new string[] { "Document Owner", currentCommunicationsPlanModel.DocumentOwner });
                documentInfo.Add(new string[] { "Issue Date", currentCommunicationsPlanModel.IssueDate });
                documentInfo.Add(new string[] { "Last Save Date", currentCommunicationsPlanModel.LastSavedDate });
                documentInfo.Add(new string[] { "File Name", currentCommunicationsPlanModel.FileName });

                foreach (var row in documentInfo)
                {
                    dgvDocumentInformation.Rows.Add(row);
                }
                dgvDocumentInformation.AllowUserToAddRows = false;

                foreach (var row in currentCommunicationsPlanModel.DocumentHistories)
                {
                    dgvDocumentHistory.Rows.Add(new string[] { row.Version, row.IssueDate, row.Changes });
                }

                foreach (var row in currentCommunicationsPlanModel.DocumentApprovals)
                {
                    dgvDocumentApprovals.Rows.Add(new string[] { row.Role, row.Name, row.Signature, row.DateApproved });
                }

                foreach (var row in currentCommunicationsPlanModel.StakeholderReq)
                {
                    dgvStakeholderRequirements.Rows.Add(new string[] { row.StakeholderName, row.StakeholderRole, row.StakeholderOrganization, row.InformationRequirement });
                }


                txtActivities.Text = currentCommunicationsPlanModel.Activities;
                txtCommunicationsProcess.Text = currentCommunicationsPlanModel.ComProcess;
                txtRoles.Text = currentCommunicationsPlanModel.Roles;
                txtDocuments.Text = currentCommunicationsPlanModel.Documents;
                txtStakeholderList.Text = currentCommunicationsPlanModel.StakeholderList;
                txtAssumptions.Text = currentCommunicationsPlanModel.Assumptions;
            }
            else
            {
                versionControl = new VersionControl<CommunicationsPlanModel>();
                versionControl.DocumentModels = new List<VersionControl<CommunicationsPlanModel>.DocumentModel>();
                documentInfo.Add(new string[] { "Document ID", "" });
                documentInfo.Add(new string[] { "Document Owner", "" });
                documentInfo.Add(new string[] { "Issue Date", "" });
                documentInfo.Add(new string[] { "Last Save Date", "" });
                documentInfo.Add(new string[] { "File Name", "" });
                newCommunicationsPlanModel = new CommunicationsPlanModel();
                foreach (var row in documentInfo)
                {
                    dgvDocumentInformation.Rows.Add(row);
                }
                dgvDocumentInformation.AllowUserToAddRows = false;
            } 
        }

        private void saveDocument()
        {
            newCommunicationsPlanModel.DocumentID = dgvDocumentInformation.Rows[0].Cells[1].Value.ToString();
            newCommunicationsPlanModel.DocumentOwner = dgvDocumentInformation.Rows[1].Cells[1].Value.ToString();
            newCommunicationsPlanModel.IssueDate = dgvDocumentInformation.Rows[2].Cells[1].Value.ToString();
            newCommunicationsPlanModel.LastSavedDate = dgvDocumentInformation.Rows[3].Cells[1].Value.ToString();
            newCommunicationsPlanModel.FileName = dgvDocumentInformation.Rows[4].Cells[1].Value.ToString();

            List<CommunicationsPlanModel.DocumentHistory> documentHistories = new List<CommunicationsPlanModel.DocumentHistory>();

            int versionRowsCount = dgvDocumentHistory.Rows.Count;

            for (int i = 0; i < versionRowsCount - 1; i++)
            {
                CommunicationsPlanModel.DocumentHistory documentHistoryModel = new CommunicationsPlanModel.DocumentHistory();
                var version = dgvDocumentHistory.Rows[i].Cells[0].Value?.ToString() ?? "";
                var issueDate = dgvDocumentHistory.Rows[i].Cells[1].Value?.ToString() ?? "";
                var changes = dgvDocumentHistory.Rows[i].Cells[2].Value?.ToString() ?? "";
                documentHistoryModel.Version = version;
                documentHistoryModel.IssueDate = issueDate;
                documentHistoryModel.Changes = changes;
                documentHistories.Add(documentHistoryModel);
            }
            newCommunicationsPlanModel.DocumentHistories = documentHistories;

            List<CommunicationsPlanModel.DocumentApproval> documentApprovalsModel = new List<CommunicationsPlanModel.DocumentApproval>();

            int approvalRowsCount = dgvDocumentApprovals.Rows.Count;

            for (int i = 0; i < approvalRowsCount - 1; i++)
            {
                CommunicationsPlanModel.DocumentApproval documentApproval = new CommunicationsPlanModel.DocumentApproval();
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
            newCommunicationsPlanModel.DocumentApprovals = documentApprovalsModel;

            List<CommunicationsPlanModel.Stakeholder> Stake = new List<CommunicationsPlanModel.Stakeholder>();

            int stakeRowsCount = dgvStakeholderRequirements.Rows.Count;

            for (int i = 0; i < stakeRowsCount - 1; i++)
            {
                CommunicationsPlanModel.Stakeholder Stakereq = new CommunicationsPlanModel.Stakeholder();
                var StakeName = dgvStakeholderRequirements.Rows[i].Cells[0].Value?.ToString() ?? "";
                var StakeRole = dgvStakeholderRequirements.Rows[i].Cells[1].Value?.ToString() ?? "";
                var Organization = dgvStakeholderRequirements.Rows[i].Cells[2].Value?.ToString() ?? "";
                var Requirement = dgvStakeholderRequirements.Rows[i].Cells[3].Value?.ToString() ?? "";

                Stakereq.StakeholderName = StakeName;
                Stakereq.StakeholderRole = StakeRole;
                Stakereq.StakeholderOrganization = Organization;
                Stakereq.InformationRequirement = Requirement;

                Stake.Add(Stakereq);
            }
            newCommunicationsPlanModel.StakeholderReq = Stake;

            newCommunicationsPlanModel.Activities = txtActivities.Text;
            newCommunicationsPlanModel.Assumptions = txtAssumptions.Text;
            newCommunicationsPlanModel.ComProcess = txtCommunicationsProcess.Text;
            newCommunicationsPlanModel.Roles = txtRoles.Text;
            newCommunicationsPlanModel.Documents = txtDocuments.Text;
            newCommunicationsPlanModel.StakeholderList = txtStakeholderList.Text;

            List<VersionControl<CommunicationsPlanModel>.DocumentModel> documentModels = versionControl.DocumentModels;

            if (!versionControl.isEqual(currentCommunicationsPlanModel, newCommunicationsPlanModel))
            {
                VersionControl<CommunicationsPlanModel>.DocumentModel documentModel = new VersionControl<CommunicationsPlanModel>.DocumentModel(newCommunicationsPlanModel, DateTime.Now, VersionControl<ProjectModel>.generateID());

                documentModels.Add(documentModel);

                versionControl.DocumentModels = documentModels;

                string json = JsonConvert.SerializeObject(versionControl);
                JsonHelper.saveDocument(json, Settings.Default.ProjectID, "CommunicationPlan");
                MessageBox.Show("Communication plan saved successfully", "save", MessageBoxButtons.OK);
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
                        document.InsertParagraph("Communication Plan \nFor " + projectModel.ProjectName)
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
                        documentInfoTable.Rows[1].Cells[1].Paragraphs[0].Append(currentCommunicationsPlanModel.DocumentID);

                        documentInfoTable.Rows[2].Cells[0].Paragraphs[0].Append("Document Owner");
                        documentInfoTable.Rows[2].Cells[1].Paragraphs[0].Append(currentCommunicationsPlanModel.DocumentOwner);

                        documentInfoTable.Rows[3].Cells[0].Paragraphs[0].Append("Issue Date");
                        documentInfoTable.Rows[3].Cells[1].Paragraphs[0].Append(currentCommunicationsPlanModel.IssueDate);

                        documentInfoTable.Rows[4].Cells[0].Paragraphs[0].Append("Last Saved Date");
                        documentInfoTable.Rows[4].Cells[1].Paragraphs[0].Append(currentCommunicationsPlanModel.LastSavedDate);

                        documentInfoTable.Rows[5].Cells[0].Paragraphs[0].Append("File Name");
                        documentInfoTable.Rows[5].Cells[1].Paragraphs[0].Append(currentCommunicationsPlanModel.FileName);
                        documentInfoTable.SetWidths(new float[] { 493, 1094 });
                        document.InsertTable(documentInfoTable);

                        document.InsertParagraph("\nDocument History\n")
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(14d).Alignment = Alignment.left;

                        var documentHistoryTable = document.AddTable(currentCommunicationsPlanModel.DocumentHistories.Count + 1, 3);
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
                        for (int i = 1; i < currentCommunicationsPlanModel.DocumentHistories.Count + 1; i++)
                        {
                            documentHistoryTable.Rows[i].Cells[0].Paragraphs[0].Append(currentCommunicationsPlanModel.DocumentHistories[i - 1].Version);
                            documentHistoryTable.Rows[i].Cells[1].Paragraphs[0].Append(currentCommunicationsPlanModel.DocumentHistories[i - 1].IssueDate);
                            documentHistoryTable.Rows[i].Cells[2].Paragraphs[0].Append(currentCommunicationsPlanModel.DocumentHistories[i - 1].Changes);

                        }

                        documentHistoryTable.SetWidths(new float[] { 190, 303, 1094 });
                        document.InsertTable(documentHistoryTable);

                        document.InsertParagraph("\nDocument Approvals\n")
                           .Font("Arial")
                           .Bold(true)
                           .FontSize(14d).Alignment = Alignment.left;

                        var documentApprovalTable = document.AddTable(currentCommunicationsPlanModel.DocumentApprovals.Count + 1, 4);
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

                        for (int i = 1; i < currentCommunicationsPlanModel.DocumentApprovals.Count + 1; i++)
                        {
                            documentApprovalTable.Rows[i].Cells[0].Paragraphs[0].Append(currentCommunicationsPlanModel.DocumentApprovals[i - 1].Role);
                            documentApprovalTable.Rows[i].Cells[1].Paragraphs[0].Append(currentCommunicationsPlanModel.DocumentApprovals[i - 1].Name);
                            documentApprovalTable.Rows[i].Cells[2].Paragraphs[0].Append(currentCommunicationsPlanModel.DocumentApprovals[i - 1].Signature);
                            documentApprovalTable.Rows[i].Cells[3].Paragraphs[0].Append(currentCommunicationsPlanModel.DocumentApprovals[i - 1].DateApproved);
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
                        var CommunicationReqHeading = document.InsertParagraph("1 Communication requirement")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        CommunicationReqHeading.StyleId = "Heading1";

                        var CommunicationReqSubHeading = CommunicationReqHeading.InsertParagraphAfterSelf("1.1 Communication requirement")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        CommunicationReqSubHeading.StyleId = "Heading2";

                        var documentStakeholderReq = document.AddTable(currentCommunicationsPlanModel.StakeholderReq.Count + 1, 4);
                        documentStakeholderReq.Rows[0].Cells[0].Paragraphs[0].Append("Stakeholder Name")
                            .Bold(true)
                            .Color(Color.White);
                        documentStakeholderReq.Rows[0].Cells[1].Paragraphs[0].Append("Stakeholder Role")
                            .Bold(true)
                            .Color(Color.White);
                        documentStakeholderReq.Rows[0].Cells[2].Paragraphs[0].Append("Stakeholder organization")
                            .Bold(true)
                            .Color(Color.White);
                        documentStakeholderReq.Rows[0].Cells[3].Paragraphs[0].Append("Information required")
                           .Bold(true)
                           .Color(Color.White);

                        documentStakeholderReq.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        documentStakeholderReq.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        documentStakeholderReq.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;
                        documentStakeholderReq.Rows[0].Cells[3].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < currentCommunicationsPlanModel.StakeholderReq.Count + 1; i++)
                        {
                            documentStakeholderReq.Rows[i].Cells[0].Paragraphs[0].Append(currentCommunicationsPlanModel.StakeholderReq[i - 1].StakeholderName);
                            documentStakeholderReq.Rows[i].Cells[1].Paragraphs[0].Append(currentCommunicationsPlanModel.StakeholderReq[i - 1].StakeholderRole);
                            documentStakeholderReq.Rows[i].Cells[2].Paragraphs[0].Append(currentCommunicationsPlanModel.StakeholderReq[i - 1].StakeholderOrganization);
                            documentStakeholderReq.Rows[i].Cells[3].Paragraphs[0].Append(currentCommunicationsPlanModel.StakeholderReq[i - 1].InformationRequirement);
                        }

                        documentStakeholderReq.SetWidths(new float[] { 394, 762, 419, 762 });
                        document.InsertTable(documentStakeholderReq);


                        var CommunicationPlanHeading = document.InsertParagraph("2 Communications Plan")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        CommunicationReqHeading.StyleId = "Heading1";

                        var ComPlanHeading = document.InsertParagraph("2.1 Assumption")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        document.InsertParagraph(currentCommunicationsPlanModel.Assumptions)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;


                        ComPlanHeading.StyleId = "Heading2";

                        var CommunicationProcessHeading = document.InsertParagraph("3 Communications Process")
                           .Bold()
                           .FontSize(14d)
                           .Color(Color.Black)
                           .Bold(true)
                           .Font("Arial");

                        CommunicationReqHeading.StyleId = "Heading1";

                        var ProcessHeading = document.InsertParagraph("3.1 Communications Process")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        document.InsertParagraph(currentCommunicationsPlanModel.ComProcess)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;


                        ProcessHeading.StyleId = "Heading2";

                        var ActivitiesHeading = document.InsertParagraph("3.2 Activities")
                           .Bold()
                           .FontSize(12d)
                           .Color(Color.Black)
                           .Bold(true)
                           .Font("Arial");

                        document.InsertParagraph(currentCommunicationsPlanModel.Activities)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;


                        ActivitiesHeading.StyleId = "Heading2";

                        var RolesHeading = document.InsertParagraph("3.3 Roles")
                           .Bold()
                           .FontSize(12d)
                           .Color(Color.Black)
                           .Bold(true)
                           .Font("Arial");

                        document.InsertParagraph(currentCommunicationsPlanModel.Roles)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;


                        RolesHeading.StyleId = "Heading2";

                        var DocumentsHeading = document.InsertParagraph("3.4 Documents")
                          .Bold()
                          .FontSize(12d)
                          .Color(Color.Black)
                          .Bold(true)
                          .Font("Arial");

                        document.InsertParagraph(currentCommunicationsPlanModel.Roles)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;


                        RolesHeading.StyleId = "Heading2";
                        
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

        private void button2_Click(object sender, EventArgs e)
        {
            saveDocument();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            exportToWord();
        }
    }
}
