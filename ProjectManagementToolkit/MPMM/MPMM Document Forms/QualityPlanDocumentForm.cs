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
    public partial class QualityPlanDocumentForm : Form
    {
        VersionControl<QualityPlanModel> versionControl;
        QualityPlanModel newQualityPlanModel;
        QualityPlanModel currentQualityPlanModel;
        ProjectModel projectModel = new ProjectModel();
        Color TABLE_HEADER_COLOR = Color.FromArgb(73, 173, 252);
        Color TABLE_SUBHEADER_COLOR = Color.FromArgb(255, 255, 0);

        public QualityPlanDocumentForm()
        {
            InitializeComponent();
        }

        private void btnSaveProjectName_Click(object sender, EventArgs e)
        {
            string projectName = txtProjectName.Text;
            SaveDocument();
        }

        private void QualityPlanDocumentForm_Load(object sender, EventArgs e)
        {
            loadDocument();
        }

        private void btnAddAssumptions_Click(object sender, EventArgs e)
        {
            string addAssumptions = txtAssumptions.Text;
            listBoxAssumptions.Items.Add(addAssumptions);
            txtAssumptions.Clear();
        }

        private void btnAddConstraints_Click(object sender, EventArgs e)
        {
            string addConstraints = txtConstraints.Text;
            listBoxConstraints.Items.Add(addConstraints);
            txtConstraints.Clear();
        }

        private void btnQualityActivities_Click(object sender, EventArgs e)
        {
            string addQualityAct = txtQualityActivities.Text;
            listBoxQualityActivities.Items.Add(addQualityAct);
            txtQualityActivities.Clear();
        }

        private void btnQualityRoles_Click(object sender, EventArgs e)
        {
            string addQualityRoles = txtQualityRoles.Text;
            listBoxQualityRoles.Items.Add(addQualityRoles);
            txtQualityRoles.Clear();
        }

        private void btnQualityDocuments_Click(object sender, EventArgs e)
        {
            string addQualityDocs = txtQualityDocuments.Text;
            listBoxQualityDocuments.Items.Add(addQualityDocs);
            txtQualityDocuments.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveDocument();
        }

        private void btnExportToWord_Click(object sender, EventArgs e)
        {
            exportToWord();
        }

        private void QualityPlanDocumentForm_Load_1(object sender, EventArgs e)
        {
            string jsoni = JsonHelper.loadProjectInfo(Settings.Default.Username);
            List<ProjectModel> projectListModel = JsonConvert.DeserializeObject<List<ProjectModel>>(jsoni);
            projectModel = projectModel.getProjectModel(Settings.Default.ProjectID, projectListModel);
            txtProjectName.Text = projectModel.ProjectName;

            loadDocument();
        }

        //Back-End
        public void SaveDocument()
        {
            newQualityPlanModel.documentID = dataGridViewDocumentInformation.Rows[0].Cells[1].Value.ToString();
            newQualityPlanModel.documentOwner = dataGridViewDocumentInformation.Rows[1].Cells[1].Value.ToString();
            newQualityPlanModel.issueDate = dataGridViewDocumentInformation.Rows[2].Cells[1].Value.ToString();
            newQualityPlanModel.lastSavedDate = dataGridViewDocumentInformation.Rows[3].Cells[1].Value.ToString();
            newQualityPlanModel.fileName = dataGridViewDocumentInformation.Rows[4].Cells[1].Value.ToString();

            List<QualityPlanModel.DocumentHistory> documentHistories = new List<QualityPlanModel.DocumentHistory>();

            int versionRowCount = dataGridViewDocumentHistory.Rows.Count-1;

            for (int i = 0; i < versionRowCount; i++)
            {
                QualityPlanModel.DocumentHistory documentHistory = new QualityPlanModel.DocumentHistory();
                var tempVersion = dataGridViewDocumentHistory.Rows[i].Cells[0].Value?.ToString() ?? "";
                var tempIssueDate = dataGridViewDocumentHistory.Rows[i].Cells[1].Value?.ToString() ?? "";
                var tempChanges = dataGridViewDocumentHistory.Rows[i].Cells[2].Value?.ToString() ?? "";
                documentHistory.version = tempVersion;
                documentHistory.issueDate = tempIssueDate;
                documentHistory.changes = tempChanges;
                documentHistories.Add(documentHistory);
            }
            newQualityPlanModel.documentHistories = documentHistories;

            List<QualityPlanModel.DocumentApprovals> documentApprovals = new List<QualityPlanModel.DocumentApprovals>();

            int approvalRowsCount = dataGridViewDocumentApprovals.Rows.Count-1;

            for (int i = 0; i < approvalRowsCount; i++)
            {
                QualityPlanModel.DocumentApprovals documentApproval = new QualityPlanModel.DocumentApprovals();
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
            newQualityPlanModel.documentApprovals = documentApprovals;

            List<QualityPlanModel.DocumentQualityTargets> documentQualityTargets = new List<QualityPlanModel.DocumentQualityTargets>();

            int qualTargetCount = dataGridViewQualityTargets.Rows.Count-1;

            for (int i = 0; i < qualTargetCount; i++)
            {
                QualityPlanModel.DocumentQualityTargets documentQualityTarget = new QualityPlanModel.DocumentQualityTargets();
                var tempRequirements = dataGridViewQualityTargets.Rows[i].Cells[0].Value?.ToString() ?? "";
                var tempDeliverable = dataGridViewQualityTargets.Rows[i].Cells[1].Value?.ToString() ?? "";
                var tempCriteria = dataGridViewQualityTargets.Rows[i].Cells[2].Value?.ToString() ?? "";
                var tempStandards = dataGridViewQualityTargets.Rows[i].Cells[3].Value?.ToString() ?? "";
                documentQualityTarget.requirement = tempRequirements;
                documentQualityTarget.deliverable = tempDeliverable;
                documentQualityTarget.criteria = tempCriteria;
                documentQualityTarget.standards = tempStandards;

                documentQualityTargets.Add(documentQualityTarget);
            }
            newQualityPlanModel.documentQualityTargets = documentQualityTargets;

            List<QualityPlanModel.DocumentQualityAssurance> documentQualityAssurances = new List<QualityPlanModel.DocumentQualityAssurance>();

            int qualAssuranceCount = dataGridViewQAP.Rows.Count-1;

            for (int i = 0; i < qualAssuranceCount; i++)
            {
                QualityPlanModel.DocumentQualityAssurance documentQualityAssurance = new QualityPlanModel.DocumentQualityAssurance();
                var tempTechnique = dataGridViewQAP.Rows[i].Cells[0].Value?.ToString() ?? "";
                var tempDescription = dataGridViewQAP.Rows[i].Cells[1].Value?.ToString() ?? "";
                var tempFrequency = dataGridViewQAP.Rows[i].Cells[2].Value?.ToString() ?? "";
                documentQualityAssurance.technique = tempTechnique;
                documentQualityAssurance.description = tempDescription;
                documentQualityAssurance.frequency = tempFrequency;

                documentQualityAssurances.Add(documentQualityAssurance);
            }
            newQualityPlanModel.documentQualityAssurances = documentQualityAssurances;

            List<QualityPlanModel.DocumentQualityControl> documentQualityControls = new List<QualityPlanModel.DocumentQualityControl>();

            int qualControlCount = dataGridViewQCP.Rows.Count;

            for (int i = 0; i < qualControlCount; i++)
            {
                QualityPlanModel.DocumentQualityControl documentQualityControl = new QualityPlanModel.DocumentQualityControl();
                var tempTechnique = dataGridViewQCP.Rows[i].Cells[0].Value?.ToString() ?? "";
                var tempDescription = dataGridViewQCP.Rows[i].Cells[1].Value?.ToString() ?? "";
                var tempFrequency = dataGridViewQCP.Rows[i].Cells[2].Value?.ToString() ?? "";
                documentQualityControl.technique = tempTechnique;
                documentQualityControl.description = tempDescription;
                documentQualityControl.frequency = tempFrequency;

                documentQualityControls.Add(documentQualityControl);
            }
            newQualityPlanModel.documentQualityControls = documentQualityControls;

            newQualityPlanModel.assumptions = ReadAllFromList(listBoxAssumptions);
            newQualityPlanModel.constraints = ReadAllFromList(listBoxConstraints);

            newQualityPlanModel.activites = ReadAllFromList(listBoxQualityActivities);
            newQualityPlanModel.roles = ReadAllFromList(listBoxQualityRoles);
            newQualityPlanModel.documents = ReadAllFromList(listBoxQualityDocuments);

            List<VersionControl<QualityPlanModel>.DocumentModel> documentModels = versionControl.DocumentModels;

            if (!versionControl.isEqual(currentQualityPlanModel, newQualityPlanModel))
            {
                VersionControl<QualityPlanModel>.DocumentModel documentModel = new VersionControl<QualityPlanModel>.DocumentModel(newQualityPlanModel, DateTime.Now, VersionControl<ProjectModel>.generateID());

                documentModels.Add(documentModel);
                versionControl.DocumentModels = documentModels;
                currentQualityPlanModel = JsonConvert.DeserializeObject<QualityPlanModel>(JsonConvert.SerializeObject(newQualityPlanModel));
                string json = JsonConvert.SerializeObject(versionControl);
                JsonHelper.saveDocument(json, Settings.Default.ProjectID, "QualityPlan");
                MessageBox.Show("Quality plan saved successfully", "save", MessageBoxButtons.OK);
            }
        }

        public void loadDocument()
        {
            string json = JsonHelper.loadDocument(Settings.Default.ProjectID, "QualityPlan");
            List<string[]> documentInfo = new List<string[]>();
            newQualityPlanModel = new QualityPlanModel();
            currentQualityPlanModel = new QualityPlanModel();
            if (json != "")
            {
                versionControl = JsonConvert.DeserializeObject<VersionControl<QualityPlanModel>>(json);
                newQualityPlanModel = JsonConvert.DeserializeObject<QualityPlanModel>(versionControl.getLatest(versionControl.DocumentModels));
                currentQualityPlanModel = JsonConvert.DeserializeObject<QualityPlanModel>(versionControl.getLatest(versionControl.DocumentModels));

                documentInfo.Add(new string[] { "Document ID", currentQualityPlanModel.documentID });
                documentInfo.Add(new string[] { "Document Owner", currentQualityPlanModel.documentOwner });
                documentInfo.Add(new string[] { "Issue Date", currentQualityPlanModel.issueDate });
                documentInfo.Add(new string[] { "Last Save Date", currentQualityPlanModel.lastSavedDate });
                documentInfo.Add(new string[] { "File Name", currentQualityPlanModel.fileName });

                foreach (var row in documentInfo)
                {
                    dataGridViewDocumentInformation.Rows.Add(row);
                }
                dataGridViewDocumentInformation.AllowUserToAddRows = false;

                foreach (var row in currentQualityPlanModel.documentHistories)
                {
                    dataGridViewDocumentHistory.Rows.Add(new string[] { row.version, row.issueDate, row.changes });
                }

                foreach (var row in currentQualityPlanModel.documentApprovals)
                {
                    dataGridViewDocumentApprovals.Rows.Add(new String[] { row.role, row.name, row.changes, row.date });
                }

                foreach (var row in currentQualityPlanModel.documentQualityTargets)
                {
                    dataGridViewQualityTargets.Rows.Add(new String[] { row.requirement, row.deliverable, row.criteria, row.standards });
                }

                foreach (var row in currentQualityPlanModel.documentQualityAssurances)
                {
                    dataGridViewQAP.Rows.Add(new String[] { row.technique, row.description, row.frequency });
                }

                foreach (var row in currentQualityPlanModel.documentQualityControls)
                {
                    dataGridViewQCP.Rows.Add(new String[] { row.technique, row.description, row.frequency });
                }

                WriteAllToList(listBoxAssumptions, currentQualityPlanModel.assumptions);
                WriteAllToList(listBoxConstraints, currentQualityPlanModel.constraints);

                WriteAllToList(listBoxQualityActivities, currentQualityPlanModel.activites);
                WriteAllToList(listBoxQualityRoles, currentQualityPlanModel.roles);
                WriteAllToList(listBoxQualityDocuments, currentQualityPlanModel.documents);
            }
            else
            {
                versionControl = new VersionControl<QualityPlanModel>();
                versionControl.DocumentModels = new List<VersionControl<QualityPlanModel>.DocumentModel>();
                documentInfo.Add(new string[] { "Document ID", "" });
                documentInfo.Add(new string[] { "Document Owner", "" });
                documentInfo.Add(new string[] { "Issue Date", "" });
                documentInfo.Add(new string[] { "Last Save Date", "" });
                documentInfo.Add(new string[] { "File Name", "" });
                newQualityPlanModel = new QualityPlanModel();
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

            foreach (string item in items)
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

                        document.InsertParagraph("Quality Plan \nFor " + txtProjectName.Text)
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
                        documentInfoTable.Rows[1].Cells[1].Paragraphs[0].Append(currentQualityPlanModel.documentID);

                        documentInfoTable.Rows[2].Cells[0].Paragraphs[0].Append("Document Owner");
                        documentInfoTable.Rows[2].Cells[1].Paragraphs[0].Append(currentQualityPlanModel.documentOwner);

                        documentInfoTable.Rows[3].Cells[0].Paragraphs[0].Append("Issue Date");
                        documentInfoTable.Rows[3].Cells[1].Paragraphs[0].Append(currentQualityPlanModel.issueDate);

                        documentInfoTable.Rows[4].Cells[0].Paragraphs[0].Append("Last Saved Date");
                        documentInfoTable.Rows[4].Cells[1].Paragraphs[0].Append(currentQualityPlanModel.lastSavedDate);

                        documentInfoTable.Rows[5].Cells[0].Paragraphs[0].Append("File Name");
                        documentInfoTable.Rows[5].Cells[1].Paragraphs[0].Append(currentQualityPlanModel.fileName);
                        documentInfoTable.SetWidths(new float[] { 493, 1094 });
                        document.InsertTable(documentInfoTable);

                        document.InsertParagraph("\nDocument History\n")
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(14d).Alignment = Alignment.left;

                        var documentHistoryTable = document.AddTable(currentQualityPlanModel.documentHistories.Count + 1, 3);
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
                        for (int i = 1; i < currentQualityPlanModel.documentHistories.Count + 1; i++)
                        {
                            documentHistoryTable.Rows[i].Cells[0].Paragraphs[0].Append(currentQualityPlanModel.documentHistories[i - 1].version);
                            documentHistoryTable.Rows[i].Cells[1].Paragraphs[0].Append(currentQualityPlanModel.documentHistories[i - 1].issueDate);
                            documentHistoryTable.Rows[i].Cells[2].Paragraphs[0].Append(currentQualityPlanModel.documentHistories[i - 1].changes);

                        }

                        documentHistoryTable.SetWidths(new float[] { 190, 303, 1094 });
                        document.InsertTable(documentHistoryTable);

                        document.InsertParagraph("\nDocument Approvals\n")
                           .Font("Arial")
                           .Bold(true)
                           .FontSize(14d).Alignment = Alignment.left;

                        var documentApprovalTable = document.AddTable(currentQualityPlanModel.documentApprovals.Count + 1, 4);
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

                        for (int i = 1; i < currentQualityPlanModel.documentApprovals.Count + 1; i++)
                        {
                            documentApprovalTable.Rows[i].Cells[0].Paragraphs[0].Append(currentQualityPlanModel.documentApprovals[i - 1].role);
                            documentApprovalTable.Rows[i].Cells[1].Paragraphs[0].Append(currentQualityPlanModel.documentApprovals[i - 1].name);
                            documentApprovalTable.Rows[i].Cells[2].Paragraphs[0].Append(currentQualityPlanModel.documentApprovals[i - 1].changes);
                            documentApprovalTable.Rows[i].Cells[3].Paragraphs[0].Append(currentQualityPlanModel.documentApprovals[i - 1].date);
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

                        #region Quality Targets
                        var qualityTargetsHeading = document.InsertParagraph("1 Quality Targets")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        qualityTargetsHeading.StyleId = "Heading1";

                        var documentQualityTargetTable = document.AddTable(currentQualityPlanModel.documentQualityTargets.Count + 2, 4);

                        documentQualityTargetTable.Rows[0].MergeCells(0, 3);

                        documentQualityTargetTable.Rows[0].Cells[0].Paragraphs[0].Append("Quality Targets")
                            .Bold(true)
                            .Color(Color.White);

                        documentQualityTargetTable.Rows[1].Cells[0].Paragraphs[0].Append("Requirements")
                            .Bold(true)
                            .Color(Color.Black);
                        documentQualityTargetTable.Rows[1].Cells[1].Paragraphs[0].Append("Deliverable")
                            .Bold(true)
                            .Color(Color.Black);
                        documentQualityTargetTable.Rows[1].Cells[2].Paragraphs[0].Append("Quality Criteria")
                            .Bold(true)
                            .Color(Color.Black);
                        documentQualityTargetTable.Rows[1].Cells[3].Paragraphs[0].Append("Quality Standards")
                            .Bold(true)
                            .Color(Color.Black);

                        documentQualityTargetTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;

                        documentQualityTargetTable.Rows[1].Cells[0].FillColor = TABLE_SUBHEADER_COLOR;
                        documentQualityTargetTable.Rows[1].Cells[1].FillColor = TABLE_SUBHEADER_COLOR;
                        documentQualityTargetTable.Rows[1].Cells[2].FillColor = TABLE_SUBHEADER_COLOR;
                        documentQualityTargetTable.Rows[1].Cells[3].FillColor = TABLE_SUBHEADER_COLOR;

                        for (int i = 2; i < currentQualityPlanModel.documentQualityTargets.Count + 2; i++)
                        {
                            documentQualityTargetTable.Rows[i].Cells[0].Paragraphs[0].Append(currentQualityPlanModel.documentQualityTargets[i - 2].requirement);
                            documentQualityTargetTable.Rows[i].Cells[1].Paragraphs[0].Append(currentQualityPlanModel.documentQualityTargets[i - 2].deliverable);
                            documentQualityTargetTable.Rows[i].Cells[2].Paragraphs[0].Append(currentQualityPlanModel.documentQualityTargets[i - 2].criteria);
                            documentQualityTargetTable.Rows[i].Cells[3].Paragraphs[0].Append(currentQualityPlanModel.documentQualityTargets[i - 2].standards);
                        }

                        document.InsertTable(documentQualityTargetTable);
                        #endregion

                        #region Quality Plan
                        var qualityPlanHeading = document.InsertParagraph("2 Quality Plan")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        qualityPlanHeading.StyleId = "Heading1";

                        #region Quality Assurance
                        var qualityAssSubHeading = qualityPlanHeading.InsertParagraphAfterSelf("2.1 Quality Assurance Plan")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        qualityAssSubHeading.StyleId = "Heading2";

                        var documentQualityAss = document.AddTable(currentQualityPlanModel.documentQualityAssurances.Count + 2, 3);

                        documentQualityAss.Rows[0].MergeCells(0, 2);

                        documentQualityAss.Rows[0].Cells[0].Paragraphs[0].Append("Quality Assurance Plan")
                            .Bold(true)
                            .Color(Color.White);

                        documentQualityAss.Rows[1].Cells[0].Paragraphs[0].Append("Technique")
                            .Bold(true)
                            .Color(Color.Black);
                        documentQualityAss.Rows[1].Cells[1].Paragraphs[0].Append("Description")
                            .Bold(true)
                            .Color(Color.Black);
                        documentQualityAss.Rows[1].Cells[2].Paragraphs[0].Append("Frequency")
                            .Bold(true)
                            .Color(Color.Black);

                        documentQualityAss.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;

                        documentQualityAss.Rows[1].Cells[0].FillColor = TABLE_SUBHEADER_COLOR;
                        documentQualityAss.Rows[1].Cells[1].FillColor = TABLE_SUBHEADER_COLOR;
                        documentQualityAss.Rows[1].Cells[2].FillColor = TABLE_SUBHEADER_COLOR;

                        for (int i = 2; i < currentQualityPlanModel.documentQualityAssurances.Count + 2; i++)
                        {
                            documentQualityAss.Rows[i].Cells[0].Paragraphs[0].Append(currentQualityPlanModel.documentQualityAssurances[i - 2].technique);
                            documentQualityAss.Rows[i].Cells[1].Paragraphs[0].Append(currentQualityPlanModel.documentQualityAssurances[i - 2].description);
                            documentQualityAss.Rows[i].Cells[2].Paragraphs[0].Append(currentQualityPlanModel.documentQualityAssurances[i - 2].frequency);
                        }

                        document.InsertTable(documentQualityAss);
                        #endregion

                        #region Quality Control Plan
                        var qualControlSubHeading = document.InsertParagraph("2.2 Quality Control Plan")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        qualControlSubHeading.StyleId = "Heading2";

                        var documentQualityCon = document.AddTable(currentQualityPlanModel.documentQualityControls.Count + 2, 3);

                        documentQualityCon.Rows[0].MergeCells(0, 2);

                        documentQualityCon.Rows[0].Cells[0].Paragraphs[0].Append("Quality Control Plan")
                            .Bold(true)
                            .Color(Color.White);

                        documentQualityCon.Rows[1].Cells[0].Paragraphs[0].Append("Technique")
                            .Bold(true)
                            .Color(Color.Black);
                        documentQualityCon.Rows[1].Cells[1].Paragraphs[0].Append("Description")
                            .Bold(true)
                            .Color(Color.Black);
                        documentQualityCon.Rows[1].Cells[2].Paragraphs[0].Append("Frequency")
                            .Bold(true)
                            .Color(Color.Black);

                        documentQualityCon.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;

                        documentQualityCon.Rows[1].Cells[0].FillColor = TABLE_SUBHEADER_COLOR;
                        documentQualityCon.Rows[1].Cells[1].FillColor = TABLE_SUBHEADER_COLOR;
                        documentQualityCon.Rows[1].Cells[2].FillColor = TABLE_SUBHEADER_COLOR;

                        for (int i = 2; i < currentQualityPlanModel.documentQualityControls.Count + 2; i++)
                        {
                            documentQualityCon.Rows[i].Cells[0].Paragraphs[0].Append(currentQualityPlanModel.documentQualityControls[i - 2].technique);
                            documentQualityCon.Rows[i].Cells[1].Paragraphs[0].Append(currentQualityPlanModel.documentQualityControls[i - 2].description);
                            documentQualityCon.Rows[i].Cells[2].Paragraphs[0].Append(currentQualityPlanModel.documentQualityControls[i - 2].frequency);
                        }

                        document.InsertTable(documentQualityCon);
                        #endregion

                        #region Assumptions
                        var assumptionsSubHeading = document.InsertParagraph("2.3 Assumptions")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        document.InsertParagraph(String.Join(",\n", currentQualityPlanModel.assumptions))
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;


                        assumptionsSubHeading.StyleId = "Heading2";
                        #endregion

                        #region Constraints
                        var constraintsSubHeading = document.InsertParagraph("2.4 Constraints")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        document.InsertParagraph(String.Join(",\n", currentQualityPlanModel.constraints))
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;


                        constraintsSubHeading.StyleId = "Heading2";
                        #endregion
                        #endregion

                        #region Quality Process
                        var qualityProcessHeading = document.InsertParagraph("3 Quality Process")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        qualityProcessHeading.StyleId = "Heading1";

                        var activitiesSubHeading = document.InsertParagraph("3.1 Activities")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        document.InsertParagraph(String.Join(",\n", currentQualityPlanModel.activites))
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;


                        activitiesSubHeading.StyleId = "Heading2";

                        var rolesSubHeading = document.InsertParagraph("3.2 Roles")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        document.InsertParagraph(String.Join(",\n", currentQualityPlanModel.roles))
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;


                        rolesSubHeading.StyleId = "Heading2";

                        var documentsSubHeading = document.InsertParagraph("3.3 Documents")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        document.InsertParagraph(String.Join(",\n", currentQualityPlanModel.documents))
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;


                        documentsSubHeading.StyleId = "Heading2";
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
    }
}
