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
    public partial class RequestForInformationDocumentForm : Form
    {
        VersionControl<RequestForInformationModel> versionControl;
        RequestForInformationModel newRequestForInformationModel;
        RequestForInformationModel currentRequestForInformationModel;
        ProjectModel projectModel = new ProjectModel();
        Color TABLE_HEADER_COLOR = Color.FromArgb(73, 173, 252);

        public RequestForInformationDocumentForm()
        {
            InitializeComponent();
        }

        private void btnSaveProjectNameRequestForInfo_Click(object sender, EventArgs e)
        {
            string ProjectName = txtProjectName.Text;
            SaveDocument();
        }

        private void RequestForInformationDocumentForm_Load(object sender, EventArgs e)
        {
            string jsoni = JsonHelper.loadProjectInfo(Settings.Default.Username);
            List<ProjectModel> projectListModel = JsonConvert.DeserializeObject<List<ProjectModel>>(jsoni);
            projectModel = projectModel.getProjectModel(Settings.Default.ProjectID, projectListModel);
            txtProjectName.Text = projectModel.ProjectName;

            loadDocument();
        }

        private void btnSaveIntroductionInfo_Click(object sender, EventArgs e)
        {
            string OverviewIntroduction = txtOverview.Text;
            string Purpose = txtPurpose.Text;
            string Acknowledgment = txtAcknowledgement.Text;
            string Recipiants = txtRecipiants.Text;
            string Process = txtProcess.Text;
            string Rules = txtRules.Text;
            string Questions = txtQuestions.Text;
        }

        private void btnCompanyOverview_Click(object sender, EventArgs e)
        {
            string CompanyOverview = txtCompanyOverview.Text;
            listBoxCompanyOverview.Items.Add(txtCompanyOverview.Text);
            txtCompanyOverview.Clear();
        }

        private void btnCompanyOffering_Click(object sender, EventArgs e)
        {
            string CompanyOffering = txtCompanyOffering.Text;
            listBoxCompanyOffering.Items.Add(txtCompanyOffering.Text);
            txtCompanyOffering.Clear();
        }

        private void btnMethod_Click(object sender, EventArgs e)
        {
            string method = txtMethod.Text;
            listBoxMethods.Items.Add(txtMethod.Text);
            txtMethod.Clear();
        }

        private void btnTimeframes_Click(object sender, EventArgs e)
        {
            string timeframes = txtTimeframes.Text;
            listBoxTimeframes.Items.Add(txtTimeframes.Text);
            txtTimeframes.Clear();
        }

        private void btnPricing_Click(object sender, EventArgs e)
        {
            string pricing = txtPricing.Text;
            listBoxPricing.Items.Add(txtPricing.Text);
            txtPricing.Clear();
        }

        private void btnConfidentiality_Click(object sender, EventArgs e)
        {
            string confidentiality = txtConfidentiality.Text;
            listBoxConfidentiality.Items.Add(txtConfidentiality.Text);
            txtConfidentiality.Clear();
        }

        private void btnDocumentation_Click(object sender, EventArgs e)
        {
            string documentation = txtDocumentation.Text;
            listBoxDocumentation.Items.Add(txtDocumentation.Text);
            txtDocumentation.Clear();
        }

        //Back-End
        public void SaveDocument()
        {
            newRequestForInformationModel.documentID = dataGridViewDocumentInformation.Rows[0].Cells[1].Value.ToString();
            newRequestForInformationModel.documentOwner = dataGridViewDocumentInformation.Rows[1].Cells[1].Value.ToString();
            newRequestForInformationModel.issueDate = dataGridViewDocumentInformation.Rows[2].Cells[1].Value.ToString();
            newRequestForInformationModel.lastSavedDate = dataGridViewDocumentInformation.Rows[3].Cells[1].Value.ToString();
            newRequestForInformationModel.fileName = dataGridViewDocumentInformation.Rows[4].Cells[1].Value.ToString();

            List<RequestForInformationModel.DocumentHistory> documentHistories = new List<RequestForInformationModel.DocumentHistory>();

            int versionRowCount = dataGridViewDocumentHistory.Rows.Count-1;

            for (int i = 0; i < versionRowCount; i++)
            {
                RequestForInformationModel.DocumentHistory documentHistory = new RequestForInformationModel.DocumentHistory();
                var tempVersion = dataGridViewDocumentHistory.Rows[i].Cells[0].Value?.ToString() ?? "";
                var tempIssueDate = dataGridViewDocumentHistory.Rows[i].Cells[1].Value?.ToString() ?? "";
                var tempChanges = dataGridViewDocumentHistory.Rows[i].Cells[2].Value?.ToString() ?? "";
                documentHistory.version = tempVersion;
                documentHistory.issueDate = tempIssueDate;
                documentHistory.changes = tempChanges;
                documentHistories.Add(documentHistory);
            }
            newRequestForInformationModel.documentHistories = documentHistories;

            List<RequestForInformationModel.DocumentApprovals> documentApprovals = new List<RequestForInformationModel.DocumentApprovals>();

            int approvalRowsCount = dataGridViewDocumentApprovals.Rows.Count-1;

            for (int i = 0; i < approvalRowsCount; i++)
            {
                RequestForInformationModel.DocumentApprovals documentApproval = new RequestForInformationModel.DocumentApprovals();
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
            newRequestForInformationModel.documentApprovals = documentApprovals;

            newRequestForInformationModel.introOverview = txtOverview.Text;
            newRequestForInformationModel.introPurpose = txtPurpose.Text;
            newRequestForInformationModel.introAcknowledgement = txtAcknowledgement.Text;
            newRequestForInformationModel.introRecipients = txtRecipiants.Text;
            newRequestForInformationModel.introProcess = txtProcess.Text;
            newRequestForInformationModel.introRules = txtRules.Text;
            newRequestForInformationModel.introQuestions = txtQuestions.Text;

            newRequestForInformationModel.companyOverview = ReadAllFromList(listBoxCompanyOverview);
            newRequestForInformationModel.companyOffering = ReadAllFromList(listBoxCompanyOffering);

            newRequestForInformationModel.approachMethod = ReadAllFromList(listBoxMethods);
            newRequestForInformationModel.approachTimeframes = ReadAllFromList(listBoxTimeframes);
            newRequestForInformationModel.approachPricing = ReadAllFromList(listBoxPricing);

            newRequestForInformationModel.otherConfidentiality = ReadAllFromList(listBoxConfidentiality);
            newRequestForInformationModel.otherDocumentation = ReadAllFromList(listBoxDocumentation);

            List<VersionControl<RequestForInformationModel>.DocumentModel> documentModels = versionControl.DocumentModels;

            if (!versionControl.isEqual(currentRequestForInformationModel, newRequestForInformationModel))
            {
                VersionControl<RequestForInformationModel>.DocumentModel documentModel = new VersionControl<RequestForInformationModel>.DocumentModel(newRequestForInformationModel, DateTime.Now, VersionControl<ProjectModel>.generateID());

                documentModels.Add(documentModel);
                versionControl.DocumentModels = documentModels;

                string json = JsonConvert.SerializeObject(versionControl);
                currentRequestForInformationModel = JsonConvert.DeserializeObject<RequestForInformationModel>(JsonConvert.SerializeObject(newRequestForInformationModel));
                JsonHelper.saveDocument(json, Settings.Default.ProjectID, "RequestForInformation");
                MessageBox.Show("Request for information saved successfully", "save", MessageBoxButtons.OK);
            }
        }

        public void loadDocument()
        {
            string json = JsonHelper.loadDocument(Settings.Default.ProjectID, "RequestForInformation");
            List<string[]> documentInfo = new List<string[]>();
            newRequestForInformationModel = new RequestForInformationModel();
            currentRequestForInformationModel = new RequestForInformationModel();
            if (json != "")
            {
                versionControl = JsonConvert.DeserializeObject<VersionControl<RequestForInformationModel>>(json);
                newRequestForInformationModel = JsonConvert.DeserializeObject<RequestForInformationModel>(versionControl.getLatest(versionControl.DocumentModels));
                currentRequestForInformationModel = JsonConvert.DeserializeObject<RequestForInformationModel>(versionControl.getLatest(versionControl.DocumentModels));

                documentInfo.Add(new string[] { "Document ID", currentRequestForInformationModel.documentID });
                documentInfo.Add(new string[] { "Document Owner", currentRequestForInformationModel.documentOwner });
                documentInfo.Add(new string[] { "Issue Date", currentRequestForInformationModel.issueDate });
                documentInfo.Add(new string[] { "Last Save Date", currentRequestForInformationModel.lastSavedDate });
                documentInfo.Add(new string[] { "File Name", currentRequestForInformationModel.fileName });

                foreach (var row in documentInfo)
                {
                    dataGridViewDocumentInformation.Rows.Add(row);
                }
                dataGridViewDocumentInformation.AllowUserToAddRows = false;

                foreach (var row in currentRequestForInformationModel.documentHistories)
                {
                    dataGridViewDocumentHistory.Rows.Add(new string[] { row.version, row.issueDate, row.changes });
                }

                foreach (var row in currentRequestForInformationModel.documentApprovals)
                {
                    dataGridViewDocumentApprovals.Rows.Add(new String[] { row.role, row.name, row.changes, row.date });
                }

                WriteAllToList(listBoxCompanyOverview, currentRequestForInformationModel.companyOverview);
                WriteAllToList(listBoxCompanyOffering, currentRequestForInformationModel.companyOffering);

                WriteAllToList(listBoxMethods, currentRequestForInformationModel.approachMethod);
                WriteAllToList(listBoxTimeframes, currentRequestForInformationModel.approachTimeframes);
                WriteAllToList(listBoxPricing, currentRequestForInformationModel.approachPricing);

                WriteAllToList(listBoxConfidentiality, currentRequestForInformationModel.otherConfidentiality);
                WriteAllToList(listBoxDocumentation, currentRequestForInformationModel.otherDocumentation);

                txtOverview.Text = currentRequestForInformationModel.introOverview;
                txtPurpose.Text = currentRequestForInformationModel.introPurpose;
                txtAcknowledgement.Text = currentRequestForInformationModel.introAcknowledgement;
                txtRecipiants.Text = currentRequestForInformationModel.introRecipients;
                txtProcess.Text = currentRequestForInformationModel.introProcess;
                txtRules.Text = currentRequestForInformationModel.introRules;
                txtQuestions.Text = currentRequestForInformationModel.introQuestions;
            }
            else
            {
                versionControl = new VersionControl<RequestForInformationModel>();
                versionControl.DocumentModels = new List<VersionControl<RequestForInformationModel>.DocumentModel>();
                documentInfo.Add(new string[] { "Document ID", "" });
                documentInfo.Add(new string[] { "Document Owner", "" });
                documentInfo.Add(new string[] { "Issue Date", "" });
                documentInfo.Add(new string[] { "Last Save Date", "" });
                documentInfo.Add(new string[] { "File Name", "" });
                newRequestForInformationModel = new RequestForInformationModel();
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

       

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveDocument();
        }

        private void btnExportToWord_Click(object sender, EventArgs e)
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

                        document.InsertParagraph("Request for information Plan \nFor " + txtProjectName.Text)
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
                        documentInfoTable.Rows[1].Cells[1].Paragraphs[0].Append(currentRequestForInformationModel.documentID);

                        documentInfoTable.Rows[2].Cells[0].Paragraphs[0].Append("Document Owner");
                        documentInfoTable.Rows[2].Cells[1].Paragraphs[0].Append(currentRequestForInformationModel.documentOwner);

                        documentInfoTable.Rows[3].Cells[0].Paragraphs[0].Append("Issue Date");
                        documentInfoTable.Rows[3].Cells[1].Paragraphs[0].Append(currentRequestForInformationModel.issueDate);

                        documentInfoTable.Rows[4].Cells[0].Paragraphs[0].Append("Last Saved Date");
                        documentInfoTable.Rows[4].Cells[1].Paragraphs[0].Append(currentRequestForInformationModel.lastSavedDate);

                        documentInfoTable.Rows[5].Cells[0].Paragraphs[0].Append("File Name");
                        documentInfoTable.Rows[5].Cells[1].Paragraphs[0].Append(currentRequestForInformationModel.fileName);
                        documentInfoTable.SetWidths(new float[] { 493, 1094 });
                        document.InsertTable(documentInfoTable);

                        document.InsertParagraph("\nDocument History\n")
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(14d).Alignment = Alignment.left;

                        var documentHistoryTable = document.AddTable(currentRequestForInformationModel.documentHistories.Count + 1, 3);
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
                        for (int i = 1; i < currentRequestForInformationModel.documentHistories.Count + 1; i++)
                        {
                            documentHistoryTable.Rows[i].Cells[0].Paragraphs[0].Append(currentRequestForInformationModel.documentHistories[i - 1].version);
                            documentHistoryTable.Rows[i].Cells[1].Paragraphs[0].Append(currentRequestForInformationModel.documentHistories[i - 1].issueDate);
                            documentHistoryTable.Rows[i].Cells[2].Paragraphs[0].Append(currentRequestForInformationModel.documentHistories[i - 1].changes);

                        }

                        documentHistoryTable.SetWidths(new float[] { 190, 303, 1094 });
                        document.InsertTable(documentHistoryTable);

                        document.InsertParagraph("\nDocument Approvals\n")
                           .Font("Arial")
                           .Bold(true)
                           .FontSize(14d).Alignment = Alignment.left;

                        var documentApprovalTable = document.AddTable(currentRequestForInformationModel.documentApprovals.Count + 1, 4);
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

                        for (int i = 1; i < currentRequestForInformationModel.documentApprovals.Count + 1; i++)
                        {
                            documentApprovalTable.Rows[i].Cells[0].Paragraphs[0].Append(currentRequestForInformationModel.documentApprovals[i - 1].role);
                            documentApprovalTable.Rows[i].Cells[1].Paragraphs[0].Append(currentRequestForInformationModel.documentApprovals[i - 1].name);
                            documentApprovalTable.Rows[i].Cells[2].Paragraphs[0].Append(currentRequestForInformationModel.documentApprovals[i - 1].changes);
                            documentApprovalTable.Rows[i].Cells[3].Paragraphs[0].Append(currentRequestForInformationModel.documentApprovals[i - 1].date);
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

                        #region Introduction
                        var introductionHeading = document.InsertParagraph("1 Introduction")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        introductionHeading.StyleId = "Heading1";

                        var overviewSubHeading = document.InsertParagraph("1.1 Overview")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        document.InsertParagraph(String.Join(",\n", currentRequestForInformationModel.introOverview))
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        overviewSubHeading.StyleId = "Heading2";


                        var purposeSubHeading = document.InsertParagraph("1.2 Purpose")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        document.InsertParagraph(String.Join(",\n", currentRequestForInformationModel.introPurpose))
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        purposeSubHeading.StyleId = "Heading2";


                        var ackSubHeading = document.InsertParagraph("1.3 Acknowledgement")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        document.InsertParagraph(String.Join(",\n", currentRequestForInformationModel.introAcknowledgement))
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        ackSubHeading.StyleId = "Heading2";


                        var recipientsSubHeading = document.InsertParagraph("1.4 Recipients")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        document.InsertParagraph(String.Join(",\n", currentRequestForInformationModel.introRecipients))
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        recipientsSubHeading.StyleId = "Heading2";


                        var processSubHeading = document.InsertParagraph("1.5 Process")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        document.InsertParagraph(String.Join(",\n", currentRequestForInformationModel.introProcess))
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        processSubHeading.StyleId = "Heading2";


                        var rulesSubHeading = document.InsertParagraph("1.6 Rules")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        document.InsertParagraph(String.Join(",\n", currentRequestForInformationModel.introRules))
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        rulesSubHeading.StyleId = "Heading2";


                        var questionsSubHeading = document.InsertParagraph("1.7 Questions")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        document.InsertParagraph(String.Join(",\n", currentRequestForInformationModel.introQuestions))
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        questionsSubHeading.StyleId = "Heading2";
                        #endregion

                        #region Company
                        var companyHeading = document.InsertParagraph("2 Company")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        companyHeading.StyleId = "Heading1";

                        var overSubHeading = document.InsertParagraph("2.1 Overview")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        document.InsertParagraph(String.Join(",\n", currentRequestForInformationModel.companyOverview))
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        overSubHeading.StyleId = "Heading2";


                        var offeringSubHeading = document.InsertParagraph("2.2 Offering")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        document.InsertParagraph(String.Join(",\n", currentRequestForInformationModel.companyOffering))
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        offeringSubHeading.StyleId = "Heading2";
                        #endregion

                        #region Approach
                        var approachHeading = document.InsertParagraph("3 Approach")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        approachHeading.StyleId = "Heading1";

                        var methodSubHeading = document.InsertParagraph("3.1 Method")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        document.InsertParagraph(String.Join(",\n", currentRequestForInformationModel.approachMethod))
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        methodSubHeading.StyleId = "Heading2";


                        var timeframesSubHeading = document.InsertParagraph("3.2 Timeframes")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        document.InsertParagraph(String.Join(",\n", currentRequestForInformationModel.approachTimeframes))
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        timeframesSubHeading.StyleId = "Heading2";

                        var pricingSubHeading = document.InsertParagraph("3.3 Pricing")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        document.InsertParagraph(String.Join(",\n", currentRequestForInformationModel.approachPricing))
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        pricingSubHeading.StyleId = "Heading2";
                        #endregion

                        #region Other
                        var otherHeading = document.InsertParagraph("4 Other")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        otherHeading.StyleId = "Heading1";

                        var confSubHeading = document.InsertParagraph("4.1 Confidentiality")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        document.InsertParagraph(String.Join(",\n", currentRequestForInformationModel.otherConfidentiality))
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        confSubHeading.StyleId = "Heading2";


                        var documentationSubHeading = document.InsertParagraph("4.2 Documentation")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        document.InsertParagraph(String.Join(",\n", currentRequestForInformationModel.otherDocumentation))
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        documentationSubHeading.StyleId = "Heading2";
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
