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
using Xceed.Words.NET;
using Xceed.Document.NET;

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Forms
{
    public partial class AcceptancePlanDocumentForm : Form
    {
        VersionControl<AcceptancePlanModel> versionControl;
        AcceptancePlanModel newAcceptancePlanModel;
        AcceptancePlanModel currentAcceptancePlanModel;
        ProjectModel projectModel = new ProjectModel();
        Color TABLE_HEADER_COLOR = Color.FromArgb(73, 173, 252);
        Color TABLE_SUBHEADER_COLOR = Color.FromArgb(255, 255, 0);

        public AcceptancePlanDocumentForm()
        {
            InitializeComponent();
        }

        private void AcceptancePlanDocumentForm_Load(object sender, EventArgs e)
        {
            dataGridViewCriteria.Columns.Add("miName1", "Milestone Name");
            dataGridViewCriteria.Columns.Add("AcceptanceCriteria", "Acceptance Criteria");
            dataGridViewCriteria.Columns.Add("AcceptanceStandards", "Acceptance Standards");

            dataGridViewSchedule.Columns.Add("milestone1", "Milestone");
            dataGridViewSchedule.Columns.Add("Deliverables", "Deliverables");
            dataGridViewSchedule.Columns.Add("MilDate", "Milestone Date");
            dataGridViewSchedule.Columns.Add("ReviewMethod", "Review Method");
            dataGridViewSchedule.Columns.Add("ReviewMethod", "Reviewers");
            dataGridViewSchedule.Columns.Add("AccDate", "Acceptance Date");

            string json = JsonHelper.loadProjectInfo(Settings.Default.Username);
            List<ProjectModel> projectListModel = JsonConvert.DeserializeObject<List<ProjectModel>>(json);
            projectModel = projectModel.getProjectModel(Settings.Default.ProjectID, projectListModel);
            txtProjectName.Text = projectModel.ProjectName;


            loadDocument();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveDocument();
        }

        private void btnExportToWord_Click(object sender, EventArgs e)
        {
            exportToWord();
        }

        private void btnCompanyOverview_Click(object sender, EventArgs e)
        {
            string addAssumptions = txtAssumptions.Text;
            listBoxAssumptions.Items.Add(addAssumptions);
            txtAssumptions.Clear();
        }

        private void btnConstraints_Click(object sender, EventArgs e)
        {
            string addConstraints = txtConstraints.Text;
            listBoxConstraints.Items.Add(addConstraints);
            txtConstraints.Clear();
        }

        private void btnActivities_Click(object sender, EventArgs e)
        {
            string activities = txtActivities.Text;
            listBoxActivities.Items.Add(activities);
            txtActivities.Clear();
        }

        private void btnRoles_Click(object sender, EventArgs e)
        {
            string roles = txtRoles.Text;
            listBoxRoles.Items.Add(roles);
            txtRoles.Clear();
        }

        private void btnDocuments_Click(object sender, EventArgs e)
        {
            string documents = txtDocuments.Text;
            listBoxDocuments.Items.Add(documents);
            txtRoles.Clear();
        }


        //Back-End
        public void SaveDocument()
        {
            newAcceptancePlanModel.documentID = dataGridViewDocumentInformation.Rows[0].Cells[1].Value.ToString();
            newAcceptancePlanModel.documentOwner = dataGridViewDocumentInformation.Rows[1].Cells[1].Value.ToString();
            newAcceptancePlanModel.issueDate = dataGridViewDocumentInformation.Rows[2].Cells[1].Value.ToString();
            newAcceptancePlanModel.lastSavedDate = dataGridViewDocumentInformation.Rows[3].Cells[1].Value.ToString();
            newAcceptancePlanModel.fileName = dataGridViewDocumentInformation.Rows[4].Cells[1].Value.ToString();

            List<AcceptancePlanModel.DocumentHistory> documentHistories = new List<AcceptancePlanModel.DocumentHistory>();

            int versionRowCount = dataGridViewDocumentHistory.Rows.Count-1;

            for (int i = 0; i < versionRowCount; i++)
            {
                AcceptancePlanModel.DocumentHistory documentHistory = new AcceptancePlanModel.DocumentHistory();
                var tempVersion = dataGridViewDocumentHistory.Rows[i].Cells[0].Value?.ToString() ?? "";
                var tempIssueDate = dataGridViewDocumentHistory.Rows[i].Cells[1].Value?.ToString() ?? "";
                var tempChanges = dataGridViewDocumentHistory.Rows[i].Cells[2].Value?.ToString() ?? "";
                documentHistory.version = tempVersion;
                documentHistory.issueDate = tempIssueDate;
                documentHistory.changes = tempChanges;
                documentHistories.Add(documentHistory);
            }
            newAcceptancePlanModel.documentHistories = documentHistories;

            List<AcceptancePlanModel.DocumentApprovals> documentApprovals = new List<AcceptancePlanModel.DocumentApprovals>();

            int approvalRowsCount = dataGridViewDocumentApprovals.Rows.Count-1;

            for (int i = 0; i < approvalRowsCount; i++)
            {
                AcceptancePlanModel.DocumentApprovals documentApproval = new AcceptancePlanModel.DocumentApprovals();
                var tempRole = dataGridViewDocumentApprovals.Rows[i].Cells[0].Value?.ToString() ?? "";
                var tempName = dataGridViewDocumentApprovals.Rows[i].Cells[1].Value?.ToString() ?? "";
                var tempChanges = dataGridViewDocumentApprovals.Rows[i].Cells[2].Value?.ToString() ?? "";
                var tempDate = dataGridViewDocumentApprovals.Rows[i].Cells[3].Value?.ToString() ?? "";
                documentApproval.role = tempRole;
                documentApproval.name = tempName;
                documentApproval.changes = tempChanges;
                documentApproval.date = tempDate;

                documentApprovals.Add(documentApproval);
            }
            newAcceptancePlanModel.documentApprovals = documentApprovals;

            List<AcceptancePlanModel.DocumentMilestones> documentMilestones = new List<AcceptancePlanModel.DocumentMilestones>();

            int milstonesRowCount = dataGridViewMilestones.Rows.Count - 1;

            for (int i = 0; i < milstonesRowCount; i++)
            {
                AcceptancePlanModel.DocumentMilestones documentMilestone = new AcceptancePlanModel.DocumentMilestones();
                var tempName = dataGridViewMilestones.Rows[i].Cells[0].Value?.ToString() ?? "";
                var tempDesc = dataGridViewMilestones.Rows[i].Cells[1].Value?.ToString() ?? "";
                var tempDate = dataGridViewMilestones.Rows[i].Cells[2].Value?.ToString() ?? "";
                documentMilestone.name = tempName;
                documentMilestone.description = tempDesc;
                documentMilestone.date = tempDate;

                documentMilestones.Add(documentMilestone);
            }
            newAcceptancePlanModel.documentMilestones = documentMilestones;

            List<AcceptancePlanModel.DocumentCriteria> documentCriterias = new List<AcceptancePlanModel.DocumentCriteria>();

            int criteriaRowCount = dataGridViewCriteria.Rows.Count - 1;

            for (int i = 0; i < criteriaRowCount; i++)
            {
                AcceptancePlanModel.DocumentCriteria documentCriteria = new AcceptancePlanModel.DocumentCriteria();
                var tempName = dataGridViewCriteria.Rows[i].Cells[0].Value?.ToString() ?? "";
                var tempCrit = dataGridViewCriteria.Rows[i].Cells[1].Value?.ToString() ?? "";
                var tempAccStand = dataGridViewCriteria.Rows[i].Cells[2].Value?.ToString() ?? "";
                documentCriteria.name = tempName;
                documentCriteria.criteria = tempCrit;
                documentCriteria.acceptanceStandards = tempAccStand;

                documentCriterias.Add(documentCriteria);
            }
            newAcceptancePlanModel.documentCriterias = documentCriterias;

            List<AcceptancePlanModel.DocumentSchedule> documentSchedules = new List<AcceptancePlanModel.DocumentSchedule>();

            int scheduleRowCount = dataGridViewSchedule.Rows.Count - 1;

            for (int i = 0; i < scheduleRowCount; i++)
            {
                AcceptancePlanModel.DocumentSchedule documentSchedule = new AcceptancePlanModel.DocumentSchedule();
                var tempMilestone = dataGridViewSchedule.Rows[i].Cells[0].Value?.ToString() ?? "";
                var tempDeliver = dataGridViewSchedule.Rows[i].Cells[1].Value?.ToString() ?? "";
                var tempMilestoneDate = dataGridViewSchedule.Rows[i].Cells[2].Value?.ToString() ?? "";
                var tempReviewMethod = dataGridViewSchedule.Rows[i].Cells[3].Value?.ToString() ?? "";
                var tempReviewers = dataGridViewSchedule.Rows[i].Cells[4].Value?.ToString() ?? "";
                var tempAcceptanceDate = dataGridViewSchedule.Rows[i].Cells[5].Value?.ToString() ?? "";
                documentSchedule.milestone = tempMilestone;
                documentSchedule.deliverables = tempDeliver;
                documentSchedule.milestoneDate = tempMilestoneDate;
                documentSchedule.reviewMethod = tempReviewMethod;
                documentSchedule.reviewers = tempReviewers;
                documentSchedule.acceptanceDate = tempAcceptanceDate;

                documentSchedules.Add(documentSchedule);
            }
            newAcceptancePlanModel.documentSchedules = documentSchedules;

            newAcceptancePlanModel.assumptions = ReadAllFromList(listBoxAssumptions);
            newAcceptancePlanModel.constraints = ReadAllFromList(listBoxConstraints);
            newAcceptancePlanModel.activites = ReadAllFromList(listBoxActivities);
            newAcceptancePlanModel.roles = ReadAllFromList(listBoxRoles);
            newAcceptancePlanModel.documents = ReadAllFromList(listBoxDocuments);

            List<VersionControl<AcceptancePlanModel>.DocumentModel> documentModels = versionControl.DocumentModels;

            if (!versionControl.isEqual(currentAcceptancePlanModel, newAcceptancePlanModel))
            {
                VersionControl<AcceptancePlanModel>.DocumentModel documentModel = new VersionControl<AcceptancePlanModel>.DocumentModel(newAcceptancePlanModel, DateTime.Now, VersionControl<ProjectModel>.generateID());

                documentModels.Add(documentModel);
                versionControl.DocumentModels = documentModels;
                currentAcceptancePlanModel = JsonConvert.DeserializeObject<AcceptancePlanModel>(JsonConvert.SerializeObject(newAcceptancePlanModel));
                string json = JsonConvert.SerializeObject(versionControl);
                JsonHelper.saveDocument(json, Settings.Default.ProjectID, "AcceptancePlan");
                MessageBox.Show("Acceptance plan saved successfully", "save", MessageBoxButtons.OK);
            }
        }

        public void loadDocument()
        {
            string json = JsonHelper.loadDocument(Settings.Default.ProjectID, "AcceptancePlan");
            List<string[]> documentInfo = new List<string[]>();
            newAcceptancePlanModel = new AcceptancePlanModel();
            currentAcceptancePlanModel = new AcceptancePlanModel();
            if (json != "")
            {
                versionControl = JsonConvert.DeserializeObject<VersionControl<AcceptancePlanModel>>(json);
                newAcceptancePlanModel = JsonConvert.DeserializeObject<AcceptancePlanModel>(versionControl.getLatest(versionControl.DocumentModels));
                currentAcceptancePlanModel = JsonConvert.DeserializeObject<AcceptancePlanModel>(versionControl.getLatest(versionControl.DocumentModels));

                documentInfo.Add(new string[] { "Document ID", currentAcceptancePlanModel.documentID });
                documentInfo.Add(new string[] { "Document Owner", currentAcceptancePlanModel.documentOwner });
                documentInfo.Add(new string[] { "Issue Date", currentAcceptancePlanModel.issueDate });
                documentInfo.Add(new string[] { "Last Save Date", currentAcceptancePlanModel.lastSavedDate });
                documentInfo.Add(new string[] { "File Name", currentAcceptancePlanModel.fileName });

                foreach (var row in documentInfo)
                {
                    dataGridViewDocumentInformation.Rows.Add(row);
                }
                dataGridViewDocumentInformation.AllowUserToAddRows = false;

                foreach (var row in currentAcceptancePlanModel.documentHistories)
                {
                    dataGridViewDocumentHistory.Rows.Add(new string[] { row.version, row.issueDate, row.changes });
                }

                foreach (var row in currentAcceptancePlanModel.documentApprovals)
                {
                    dataGridViewDocumentApprovals.Rows.Add(new String[] { row.role, row.name, row.changes, row.date });
                }

                foreach (var row in currentAcceptancePlanModel.documentMilestones)
                {
                    dataGridViewMilestones.Rows.Add(new String[] { row.name, row.description, row.date });
                }

                foreach (var row in currentAcceptancePlanModel.documentCriterias)
                {
                    dataGridViewCriteria.Rows.Add(new String[] { row.name, row.criteria, row.acceptanceStandards });
                }

                foreach (var row in currentAcceptancePlanModel.documentSchedules)
                {
                    dataGridViewSchedule.Rows.Add(new String[] { row.milestone, row.deliverables, row.milestoneDate, row.reviewMethod, row.reviewers, row.acceptanceDate });
                }

                WriteAllToList(listBoxActivities, currentAcceptancePlanModel.activites);
                WriteAllToList(listBoxAssumptions, currentAcceptancePlanModel.assumptions);
                WriteAllToList(listBoxConstraints, currentAcceptancePlanModel.constraints);
                WriteAllToList(listBoxDocuments, currentAcceptancePlanModel.documents);
                WriteAllToList(listBoxRoles, currentAcceptancePlanModel.roles);
            }
            else
            {
                versionControl = new VersionControl<AcceptancePlanModel>();
                versionControl.DocumentModels = new List<VersionControl<AcceptancePlanModel>.DocumentModel>();
                documentInfo.Add(new string[] { "Document ID", "" });
                documentInfo.Add(new string[] { "Document Owner", "" });
                documentInfo.Add(new string[] { "Issue Date", "" });
                documentInfo.Add(new string[] { "Last Save Date", "" });
                documentInfo.Add(new string[] { "File Name", "" });
                newAcceptancePlanModel = new AcceptancePlanModel();
                foreach (var row in documentInfo)
                {
                    dataGridViewDocumentInformation.Rows.Add(row);
                }
                dataGridViewDocumentInformation.AllowUserToAddRows = false;
            }
        }

        List<string> ReadAllFromList(ListBox listBox)
        {
            List<string> tempList = new List<string>();
            foreach (var li in listBox.Items) 
            {
                tempList.Add(li.ToString());
            }

            return tempList;
        }

        void WriteAllToList(ListBox listBox, List<string> items)
        {
            listBox.Items.Clear();

            if (items == null)
            {
                return;
            }

            foreach(string item in items)
            {
                listBox.Items.Add(item);
            }
        }

        private void btn_Export_Click(object sender, EventArgs e)
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
                        #region Heading
                        for (int i = 0; i < 11; i++)
                        {
                            document.InsertParagraph("")
                                .Font("Arial")
                                .Bold(true)
                                .FontSize(22d).Alignment = Alignment.left;
                        }

                        document.InsertParagraph("Acceptance Plan \nFor " + txtProjectName.Text)
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
                        #endregion

                        #region Document basics
                        var documentInfoTable = document.AddTable(6, 2);
                        documentInfoTable.Rows[0].Cells[0].Paragraphs[0].Append("").Bold(true).Color(Color.White);
                        documentInfoTable.Rows[0].Cells[1].Paragraphs[0].Append("Information").Bold(true).Color(Color.White);
                        documentInfoTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        documentInfoTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;

                        documentInfoTable.Rows[1].Cells[0].Paragraphs[0].Append("Document ID");
                        documentInfoTable.Rows[1].Cells[1].Paragraphs[0].Append(currentAcceptancePlanModel.documentID);

                        documentInfoTable.Rows[2].Cells[0].Paragraphs[0].Append("Document Owner");
                        documentInfoTable.Rows[2].Cells[1].Paragraphs[0].Append(currentAcceptancePlanModel.documentOwner);

                        documentInfoTable.Rows[3].Cells[0].Paragraphs[0].Append("Issue Date");
                        documentInfoTable.Rows[3].Cells[1].Paragraphs[0].Append(currentAcceptancePlanModel.issueDate);

                        documentInfoTable.Rows[4].Cells[0].Paragraphs[0].Append("Last Saved Date");
                        documentInfoTable.Rows[4].Cells[1].Paragraphs[0].Append(currentAcceptancePlanModel.lastSavedDate);

                        documentInfoTable.Rows[5].Cells[0].Paragraphs[0].Append("File Name");
                        documentInfoTable.Rows[5].Cells[1].Paragraphs[0].Append(currentAcceptancePlanModel.fileName);
                        documentInfoTable.SetWidths(new float[] { 493, 1094 });
                        document.InsertTable(documentInfoTable);

                        document.InsertParagraph("\nDocument History\n")
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(14d).Alignment = Alignment.left;

                        var documentHistoryTable = document.AddTable(currentAcceptancePlanModel.documentHistories.Count + 1, 3);
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
                        for (int i = 1; i < currentAcceptancePlanModel.documentHistories.Count + 1; i++)
                        {
                            documentHistoryTable.Rows[i].Cells[0].Paragraphs[0].Append(currentAcceptancePlanModel.documentHistories[i - 1].version);
                            documentHistoryTable.Rows[i].Cells[1].Paragraphs[0].Append(currentAcceptancePlanModel.documentHistories[i - 1].issueDate);
                            documentHistoryTable.Rows[i].Cells[2].Paragraphs[0].Append(currentAcceptancePlanModel.documentHistories[i - 1].changes);

                        }

                        documentHistoryTable.SetWidths(new float[] { 190, 303, 1094 });
                        document.InsertTable(documentHistoryTable);

                        document.InsertParagraph("\nDocument Approvals\n")
                           .Font("Arial")
                           .Bold(true)
                           .FontSize(14d).Alignment = Alignment.left;

                        var documentApprovalTable = document.AddTable(currentAcceptancePlanModel.documentApprovals.Count + 1, 4);
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

                        for (int i = 1; i < currentAcceptancePlanModel.documentApprovals.Count + 1; i++)
                        {
                            documentApprovalTable.Rows[i].Cells[0].Paragraphs[0].Append(currentAcceptancePlanModel.documentApprovals[i - 1].role);
                            documentApprovalTable.Rows[i].Cells[1].Paragraphs[0].Append(currentAcceptancePlanModel.documentApprovals[i - 1].name);
                            documentApprovalTable.Rows[i].Cells[2].Paragraphs[0].Append(currentAcceptancePlanModel.documentApprovals[i - 1].changes);
                            documentApprovalTable.Rows[i].Cells[3].Paragraphs[0].Append(currentAcceptancePlanModel.documentApprovals[i - 1].date);
                        }
                        documentApprovalTable.SetWidths(new float[] { 493, 332, 508, 254 });
                        document.InsertTable(documentApprovalTable);
                        document.InsertParagraph().InsertPageBreakAfterSelf();

                        var p = document.InsertParagraph();
                        var title = p.InsertParagraphBeforeSelf("Table of contents").Bold().FontSize(20);

                        var tocSwitches = new Dictionary<TableOfContentsSwitches, string>()
                        {
                            { TableOfContentsSwitches.O, "1-3"},
                            { TableOfContentsSwitches.U, ""},
                            { TableOfContentsSwitches.Z, ""},
                            { TableOfContentsSwitches.H, ""}
                        };

                        document.InsertTableOfContents(p, "", tocSwitches);
                        document.InsertParagraph().InsertPageBreakAfterSelf();
                        #endregion

                        #region Acceptance Criteria
                        var acceptanceCritHeading = document.InsertParagraph("1 Acceptance Criteria")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        acceptanceCritHeading.StyleId = "Heading1";

                        #region Milestones
                        var milestonesSubHeading = acceptanceCritHeading.InsertParagraphAfterSelf("1.1 Milestones")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        milestonesSubHeading.StyleId = "Heading2";

                        var documentMilestoneTable = document.AddTable(currentAcceptancePlanModel.documentMilestones.Count + 1, 3);
                        documentMilestoneTable.Rows[0].Cells[0].Paragraphs[0].Append("Milestone Name")
                            .Bold(true)
                            .Color(Color.White);
                        documentMilestoneTable.Rows[0].Cells[1].Paragraphs[0].Append("Milestone Description")
                            .Bold(true)
                            .Color(Color.White);
                        documentMilestoneTable.Rows[0].Cells[2].Paragraphs[0].Append("Milestone Date")
                            .Bold(true)
                            .Color(Color.White);

                        documentMilestoneTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        documentMilestoneTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        documentMilestoneTable.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < currentAcceptancePlanModel.documentMilestones.Count + 1; i++)
                        {
                            documentMilestoneTable.Rows[i].Cells[0].Paragraphs[0].Append(currentAcceptancePlanModel.documentMilestones[i - 1].name);
                            documentMilestoneTable.Rows[i].Cells[1].Paragraphs[0].Append(currentAcceptancePlanModel.documentMilestones[i - 1].description);
                            documentMilestoneTable.Rows[i].Cells[2].Paragraphs[0].Append(currentAcceptancePlanModel.documentMilestones[i - 1].date);
                        }

                        documentMilestoneTable.SetWidths(new float[] { 394, 762, 419 });
                        document.InsertTable(documentMilestoneTable);
                        #endregion

                        #region Criteria
                        var criteriaSubHeading = document.InsertParagraph("1.2 Criteria")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        criteriaSubHeading.StyleId = "Heading2";

                        var documentCriteriaTable = document.AddTable(currentAcceptancePlanModel.documentCriterias.Count + 1, 3);
                        documentCriteriaTable.Rows[0].Cells[0].Paragraphs[0].Append("Milestone Name")
                            .Bold(true)
                            .Color(Color.White);
                        documentCriteriaTable.Rows[0].Cells[1].Paragraphs[0].Append("Acceptance Criteria")
                            .Bold(true)
                            .Color(Color.White);
                        documentCriteriaTable.Rows[0].Cells[2].Paragraphs[0].Append("Acceptance Standards")
                            .Bold(true)
                            .Color(Color.White);

                        documentCriteriaTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        documentCriteriaTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        documentCriteriaTable.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < currentAcceptancePlanModel.documentCriterias.Count + 1; i++)
                        {
                            documentCriteriaTable.Rows[i].Cells[0].Paragraphs[0].Append(currentAcceptancePlanModel.documentCriterias[i - 1].name);
                            documentCriteriaTable.Rows[i].Cells[1].Paragraphs[0].Append(currentAcceptancePlanModel.documentCriterias[i - 1].criteria);
                            documentCriteriaTable.Rows[i].Cells[2].Paragraphs[0].Append(currentAcceptancePlanModel.documentCriterias[i - 1].acceptanceStandards);
                        }

                        documentCriteriaTable.SetWidths(new float[] { 394, 762, 419 });
                        document.InsertTable(documentCriteriaTable);
                        #endregion
                        #endregion

                        #region Acceptance Plan
                        var acceptancePlanHeading = document.InsertParagraph("2 Acceptance Plan")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        acceptancePlanHeading.StyleId = "Heading1";

                        #region Schedule
                        var scheduleSubHeading = acceptancePlanHeading.InsertParagraphAfterSelf("2.1 Schedule")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        scheduleSubHeading.StyleId = "Heading2";
                        var documentScheduleTable = document.AddTable(currentAcceptancePlanModel.documentSchedules.Count + 2, 6);

                        documentScheduleTable.Rows[0].MergeCells(0, 2);
                        documentScheduleTable.Rows[0].MergeCells(1, 3);

                        documentScheduleTable.Rows[0].Cells[0].Paragraphs[0].Append("Milestone")
                            .Bold(true)
                            .Color(Color.White);
                        documentScheduleTable.Rows[0].Cells[1].Paragraphs[0].Append("Acceptance Tests")
                            .Bold(true)
                            .Color(Color.White);

                        documentScheduleTable.Rows[1].Cells[0].Paragraphs[0].Append("Milestone")
                            .Bold(true)
                            .Color(Color.Black);
                        documentScheduleTable.Rows[1].Cells[1].Paragraphs[0].Append("Deliverables")
                            .Bold(true)
                            .Color(Color.Black);
                        documentScheduleTable.Rows[1].Cells[2].Paragraphs[0].Append("Date")
                            .Bold(true)
                            .Color(Color.Black);
                        documentScheduleTable.Rows[1].Cells[3].Paragraphs[0].Append("Review Method")
                            .Bold(true)
                            .Color(Color.Black);
                        documentScheduleTable.Rows[1].Cells[4].Paragraphs[0].Append("Reviewers")
                            .Bold(true)
                            .Color(Color.Black);
                        documentScheduleTable.Rows[1].Cells[5].Paragraphs[0].Append("Date")
                            .Bold(true)
                            .Color(Color.Black);

                        documentScheduleTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        documentScheduleTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;

                        documentScheduleTable.Rows[1].Cells[0].FillColor = TABLE_SUBHEADER_COLOR;
                        documentScheduleTable.Rows[1].Cells[1].FillColor = TABLE_SUBHEADER_COLOR;
                        documentScheduleTable.Rows[1].Cells[2].FillColor = TABLE_SUBHEADER_COLOR;
                        documentScheduleTable.Rows[1].Cells[3].FillColor = TABLE_SUBHEADER_COLOR;
                        documentScheduleTable.Rows[1].Cells[4].FillColor = TABLE_SUBHEADER_COLOR;
                        documentScheduleTable.Rows[1].Cells[5].FillColor = TABLE_SUBHEADER_COLOR;

                        for (int i = 2; i < currentAcceptancePlanModel.documentSchedules.Count + 2; i++)
                        {
                            documentScheduleTable.Rows[i].Cells[0].Paragraphs[0].Append(currentAcceptancePlanModel.documentSchedules[i - 2].milestone);
                            documentScheduleTable.Rows[i].Cells[1].Paragraphs[0].Append(currentAcceptancePlanModel.documentSchedules[i - 2].deliverables);
                            documentScheduleTable.Rows[i].Cells[2].Paragraphs[0].Append(currentAcceptancePlanModel.documentSchedules[i - 2].milestoneDate);
                            documentScheduleTable.Rows[i].Cells[3].Paragraphs[0].Append(currentAcceptancePlanModel.documentSchedules[i - 2].reviewMethod);
                            documentScheduleTable.Rows[i].Cells[4].Paragraphs[0].Append(currentAcceptancePlanModel.documentSchedules[i - 2].reviewers);
                            documentScheduleTable.Rows[i].Cells[5].Paragraphs[0].Append(currentAcceptancePlanModel.documentSchedules[i - 2].acceptanceDate);
                        }

                        document.InsertTable(documentScheduleTable);
                        #endregion

                        #region Assumptions
                        var assumptionsSubHeading = document.InsertParagraph("2.2 Assumptions")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        document.InsertParagraph(String.Join(",\n", currentAcceptancePlanModel.assumptions))
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;


                        assumptionsSubHeading.StyleId = "Heading2";
                        #endregion

                        #region Constraints
                        var constraintsSubHeading = document.InsertParagraph("2.3 Constraints")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        document.InsertParagraph(String.Join(",\n", currentAcceptancePlanModel.constraints))
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;


                        constraintsSubHeading.StyleId = "Heading2";
                        #endregion
                        #endregion

                        #region Acceptance Process
                        var acceptanceProcessHeading = document.InsertParagraph("3 Acceptance Process")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        acceptanceProcessHeading.StyleId = "Heading1";

                        #region Activities
                        var activitiestSubHeading = document.InsertParagraph("3.1 Activities")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        document.InsertParagraph(String.Join(",\n", currentAcceptancePlanModel.activites))
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        activitiestSubHeading.StyleId = "Heading2";
                        #endregion

                        #region Roles
                        var rolesSubHeading = document.InsertParagraph("3.2 Roles")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        document.InsertParagraph(String.Join(",\n", currentAcceptancePlanModel.roles))
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        rolesSubHeading.StyleId = "Heading2";
                        #endregion

                        #region Documents
                        var documentsSubHeading = document.InsertParagraph("3.3 Documents")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        document.InsertParagraph(String.Join(",\n", currentAcceptancePlanModel.documents))
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        documentsSubHeading.StyleId = "Heading2";
                        #endregion
                        #endregion

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

        private void txtAssumptions_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
