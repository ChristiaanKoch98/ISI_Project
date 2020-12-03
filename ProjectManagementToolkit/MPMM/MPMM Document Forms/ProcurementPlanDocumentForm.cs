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
    public partial class ProcurementPlanDocumentForm : Form
    {
        VersionControl<ProcurementPlanModel> versionControl;
        ProcurementPlanModel newProcurementPlanModel;
        ProcurementPlanModel currentProcurementPlanModel;

        Color TABLE_HEADER_COLOR = Color.FromArgb(73, 173, 252);

        public ProcurementPlanDocumentForm()
        {
            InitializeComponent();
        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ProcurementPlanDocumentForm_Load(object sender, EventArgs e)
        {
            dataGridViewDocumentInformation.Columns.Add("type", "Type");
            dataGridViewDocumentInformation.Columns.Add("info", "Information");

            dataGridViewDocumentHistory.Columns.Add("Version", "Version");
            dataGridViewDocumentHistory.Columns.Add("IssueDate", "Issue Date");
            dataGridViewDocumentHistory.Columns.Add("Changes", "Changes");

            dataGridViewDocumentApprovals.Columns.Add("Role1", "Role");
            dataGridViewDocumentApprovals.Columns.Add("Name1", "Name");
            dataGridViewDocumentApprovals.Columns.Add("Signature1", "Signature");
            dataGridViewDocumentApprovals.Columns.Add("Date1", "Date");

            dataGridViewRequirements.Columns.Add("Item1", "Item");
            dataGridViewRequirements.Columns.Add("Description1", "Description");
            dataGridViewRequirements.Columns.Add("Justification1", "Justification");
            dataGridViewRequirements.Columns.Add("Quantity1", "Quantity");
            dataGridViewRequirements.Columns.Add("Budget1", "Budget");

            dataGridViewMarketResearch.Columns.Add("Item2", "Item");
            dataGridViewMarketResearch.Columns.Add("Supplier", "Supplier");
            dataGridViewMarketResearch.Columns.Add("Offering", "Offering");
            dataGridViewMarketResearch.Columns.Add("Price", "Price");
            dataGridViewMarketResearch.Columns.Add("Availability", "Availability");

            loadDocument();
        }

        private void btnAddAssumptions_Click(object sender, EventArgs e)
        {
            string addAssumptions = txtAssumptions.Text;
            listBoxAssumptions.Items.Add(addAssumptions);
        }

        private void btnAddConstraints_Click(object sender, EventArgs e)
        {
            string addConstraints = txtConstraints.Text;
            listBoxConstraints.Items.Add(addConstraints);
        }

        private void btnTenderActivities_Click(object sender, EventArgs e)
        {
            string tenderActivities = txtTenderActivities.Text;
            listBoxTenderActivities.Items.Add(tenderActivities);
        }

        private void btnTenderRoles_Click(object sender, EventArgs e)
        {
            string tenderRoles = txtTenderRoles.Text;
            listBoxTenderRoles.Items.Add(tenderRoles);
        }

        private void btnTenderDocuments_Click(object sender, EventArgs e)
        {
            string tenderDocuments = txtTenderDocuments.Text;
            listBoxTenderDocuments.Items.Add(tenderDocuments);
        }

        private void btnProcessActivities_Click(object sender, EventArgs e)
        {
            string processActivities = txtProcessActivities.Text;
            listBoxProcessActivities.Items.Add(processActivities);
        }

        private void btnProcessRoles_Click(object sender, EventArgs e)
        {
            string processRoles = txtProcessRoles.Text;
            listBoxProcessRoles.Items.Add(processRoles);
        }

        private void btnProcessDocuments_Click(object sender, EventArgs e)
        {
            string processDocuments = txtProcessDocuments.Text;
            listBoxProcessDocuments.Items.Add(processDocuments);
        }

        private void btnSaveProjectName_Click_1(object sender, EventArgs e)
        {
            SaveDocument();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            exportToWord();
        }

        public void SaveDocument()
        {
            newProcurementPlanModel.documentID = dataGridViewDocumentInformation.Rows[0].Cells[1].Value.ToString();
            newProcurementPlanModel.documentOwner = dataGridViewDocumentInformation.Rows[1].Cells[1].Value.ToString();
            newProcurementPlanModel.issueDate = dataGridViewDocumentInformation.Rows[2].Cells[1].Value.ToString();
            newProcurementPlanModel.lastSavedDate = dataGridViewDocumentInformation.Rows[3].Cells[1].Value.ToString();
            newProcurementPlanModel.fileName = dataGridViewDocumentInformation.Rows[4].Cells[1].Value.ToString();

            List<ProcurementPlanModel.DocumentHistory> documentHistories = new List<ProcurementPlanModel.DocumentHistory>();

            int versionRowCount = dataGridViewDocumentHistory.Rows.Count-1;

            for (int i = 0; i < versionRowCount; i++)
            {
                ProcurementPlanModel.DocumentHistory documentHistory = new ProcurementPlanModel.DocumentHistory();
                var tempVersion = dataGridViewDocumentHistory.Rows[i].Cells[0].Value?.ToString() ?? "";
                var tempIssueDate = dataGridViewDocumentHistory.Rows[i].Cells[1].Value?.ToString() ?? "";
                var tempChanges = dataGridViewDocumentHistory.Rows[i].Cells[2].Value?.ToString() ?? "";
                documentHistory.version = tempVersion;
                documentHistory.issueDate = tempIssueDate;
                documentHistory.changes = tempChanges;
                documentHistories.Add(documentHistory);
            }
            newProcurementPlanModel.documentHistories = documentHistories;

            List<ProcurementPlanModel.DocumentApprovals> documentApprovals = new List<ProcurementPlanModel.DocumentApprovals>();

            int approvalRowsCount = dataGridViewDocumentApprovals.Rows.Count-1;

            for (int i = 0; i < approvalRowsCount; i++)
            {
                ProcurementPlanModel.DocumentApprovals documentApproval = new ProcurementPlanModel.DocumentApprovals();
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
            newProcurementPlanModel.documentApprovals = documentApprovals;

            List<ProcurementPlanModel.DocumentRequirements> documentRequirements = new List<ProcurementPlanModel.DocumentRequirements>();

            int requirementsCount = dataGridViewRequirements.Rows.Count-1;

            for (int i = 0; i < requirementsCount; i++)
            {
                ProcurementPlanModel.DocumentRequirements documentRequirement = new ProcurementPlanModel.DocumentRequirements();
                var tempItem = dataGridViewRequirements.Rows[i].Cells[0].Value?.ToString() ?? "";
                var tempDescription = dataGridViewRequirements.Rows[i].Cells[1].Value?.ToString() ?? "";
                var tempJustification = dataGridViewRequirements.Rows[i].Cells[2].Value?.ToString() ?? "";
                var tempQuantity = dataGridViewRequirements.Rows[i].Cells[3].Value?.ToString() ?? "";
                var tempBudget = dataGridViewRequirements.Rows[i].Cells[4].Value?.ToString() ?? "";
                documentRequirement.item = tempItem;
                documentRequirement.description = tempDescription;
                documentRequirement.justification = tempJustification;
                documentRequirement.quantity = tempQuantity;
                documentRequirement.budget = tempBudget;

                documentRequirements.Add(documentRequirement);
            }
            newProcurementPlanModel.documentRequirements = documentRequirements;

            List<ProcurementPlanModel.DocumentMarketResearch> documentMarketResearches = new List<ProcurementPlanModel.DocumentMarketResearch>();

            int researchCount = dataGridViewMarketResearch.Rows.Count-1;

            for (int i = 0; i < researchCount; i++)
            {
                ProcurementPlanModel.DocumentMarketResearch documentMarketResearch = new ProcurementPlanModel.DocumentMarketResearch();
                var tempItem = dataGridViewMarketResearch.Rows[i].Cells[0].Value?.ToString() ?? "";
                var tempSupplier = dataGridViewMarketResearch.Rows[i].Cells[1].Value?.ToString() ?? "";
                var tempOffering = dataGridViewMarketResearch.Rows[i].Cells[2].Value?.ToString() ?? "";
                var tempPrice = dataGridViewMarketResearch.Rows[i].Cells[3].Value?.ToString() ?? "";
                var tempAvailability = dataGridViewMarketResearch.Rows[i].Cells[4].Value?.ToString() ?? "";
                documentMarketResearch.item = tempItem;
                documentMarketResearch.supplier = tempSupplier;
                documentMarketResearch.offering = tempOffering;
                documentMarketResearch.price = tempPrice;
                documentMarketResearch.availability = tempAvailability;

                documentMarketResearches.Add(documentMarketResearch);
            }
            newProcurementPlanModel.documentMarketResearch = documentMarketResearches;

            newProcurementPlanModel.assumptions = ReadAllFromList(listBoxAssumptions);
            newProcurementPlanModel.constraints = ReadAllFromList(listBoxConstraints);

            newProcurementPlanModel.tenderActivities = ReadAllFromList(listBoxTenderActivities);
            newProcurementPlanModel.tenderRoles = ReadAllFromList(listBoxTenderRoles);
            newProcurementPlanModel.tenderDocuments = ReadAllFromList(listBoxTenderDocuments);

            newProcurementPlanModel.procurementActivities = ReadAllFromList(listBoxProcessActivities);
            newProcurementPlanModel.procurementRoles = ReadAllFromList(listBoxProcessRoles);
            newProcurementPlanModel.procurementDocuments = ReadAllFromList(listBoxProcessDocuments);

            List<VersionControl<ProcurementPlanModel>.DocumentModel> documentModels = versionControl.DocumentModels;

            if (!versionControl.isEqual(currentProcurementPlanModel, newProcurementPlanModel))
            {
                VersionControl<ProcurementPlanModel>.DocumentModel documentModel = new VersionControl<ProcurementPlanModel>.DocumentModel(newProcurementPlanModel, DateTime.Now, VersionControl<ProjectModel>.generateID());

                documentModels.Add(documentModel);
                versionControl.DocumentModels = documentModels;

                string json = JsonConvert.SerializeObject(versionControl);
                JsonHelper.saveDocument(json, Settings.Default.ProjectID, "ProcurementPlan");
                MessageBox.Show("Procurement Plan saved successfully", "save", MessageBoxButtons.OK);
            }
        }

        public void loadDocument()
        {
            string json = JsonHelper.loadDocument(Settings.Default.ProjectID, "ProcurementPlan");
            List<string[]> documentInfo = new List<string[]>();
            newProcurementPlanModel = new ProcurementPlanModel();
            currentProcurementPlanModel = new ProcurementPlanModel();
            if (json != "")
            {
                versionControl = JsonConvert.DeserializeObject<VersionControl<ProcurementPlanModel>>(json);
                newProcurementPlanModel = JsonConvert.DeserializeObject<ProcurementPlanModel>(versionControl.getLatest(versionControl.DocumentModels));
                currentProcurementPlanModel = JsonConvert.DeserializeObject<ProcurementPlanModel>(versionControl.getLatest(versionControl.DocumentModels));

                documentInfo.Add(new string[] { "Document ID", currentProcurementPlanModel.documentID });
                documentInfo.Add(new string[] { "Document Owner", currentProcurementPlanModel.documentOwner });
                documentInfo.Add(new string[] { "Issue Date", currentProcurementPlanModel.issueDate });
                documentInfo.Add(new string[] { "Last Save Date", currentProcurementPlanModel.lastSavedDate });
                documentInfo.Add(new string[] { "File Name", currentProcurementPlanModel.fileName });

                foreach (var row in documentInfo)
                {
                    dataGridViewDocumentInformation.Rows.Add(row);
                }
                dataGridViewDocumentInformation.AllowUserToAddRows = false;

                foreach (var row in currentProcurementPlanModel.documentHistories)
                {
                    dataGridViewDocumentHistory.Rows.Add(new string[] { row.version, row.issueDate, row.changes });
                }

                foreach (var row in currentProcurementPlanModel.documentApprovals)
                {
                    dataGridViewDocumentApprovals.Rows.Add(new String[] { row.role, row.name, row.changes, row.date });
                }

                foreach (var row in currentProcurementPlanModel.documentRequirements)
                {
                    dataGridViewRequirements.Rows.Add(new String[] { row.item, row.description, row.justification, row.quantity, row.budget });
                }

                foreach (var row in currentProcurementPlanModel.documentMarketResearch)
                {
                    dataGridViewMarketResearch.Rows.Add(new String[] { row.item, row.supplier, row.offering, row.price, row.availability });
                }

                WriteAllToList(listBoxAssumptions, currentProcurementPlanModel.assumptions);
                WriteAllToList(listBoxConstraints, currentProcurementPlanModel.constraints);

                WriteAllToList(listBoxTenderActivities, currentProcurementPlanModel.tenderActivities);
                WriteAllToList(listBoxTenderRoles, currentProcurementPlanModel.tenderRoles);
                WriteAllToList(listBoxTenderDocuments, currentProcurementPlanModel.tenderDocuments);

                WriteAllToList(listBoxProcessActivities, currentProcurementPlanModel.procurementActivities);
                WriteAllToList(listBoxProcessRoles, currentProcurementPlanModel.procurementRoles);
                WriteAllToList(listBoxProcessDocuments, currentProcurementPlanModel.procurementDocuments);
            }
            else
            {
                versionControl = new VersionControl<ProcurementPlanModel>();
                versionControl.DocumentModels = new List<VersionControl<ProcurementPlanModel>.DocumentModel>();
                documentInfo.Add(new string[] { "Document ID", "" });
                documentInfo.Add(new string[] { "Document Owner", "" });
                documentInfo.Add(new string[] { "Issue Date", "" });
                documentInfo.Add(new string[] { "Last Save Date", "" });
                documentInfo.Add(new string[] { "File Name", "" });
                newProcurementPlanModel = new ProcurementPlanModel();
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

                        document.InsertParagraph("Procurement Plan \nFor " + txtProjectName.Text)
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
                        documentInfoTable.Rows[1].Cells[1].Paragraphs[0].Append(currentProcurementPlanModel.documentID);

                        documentInfoTable.Rows[2].Cells[0].Paragraphs[0].Append("Document Owner");
                        documentInfoTable.Rows[2].Cells[1].Paragraphs[0].Append(currentProcurementPlanModel.documentOwner);

                        documentInfoTable.Rows[3].Cells[0].Paragraphs[0].Append("Issue Date");
                        documentInfoTable.Rows[3].Cells[1].Paragraphs[0].Append(currentProcurementPlanModel.issueDate);

                        documentInfoTable.Rows[4].Cells[0].Paragraphs[0].Append("Last Saved Date");
                        documentInfoTable.Rows[4].Cells[1].Paragraphs[0].Append(currentProcurementPlanModel.lastSavedDate);

                        documentInfoTable.Rows[5].Cells[0].Paragraphs[0].Append("File Name");
                        documentInfoTable.Rows[5].Cells[1].Paragraphs[0].Append(currentProcurementPlanModel.fileName);
                        documentInfoTable.SetWidths(new float[] { 493, 1094 });
                        document.InsertTable(documentInfoTable);

                        document.InsertParagraph("\nDocument History\n")
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(14d).Alignment = Alignment.left;

                        var documentHistoryTable = document.AddTable(currentProcurementPlanModel.documentHistories.Count + 1, 3);
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
                        for (int i = 1; i < currentProcurementPlanModel.documentHistories.Count + 1; i++)
                        {
                            documentHistoryTable.Rows[i].Cells[0].Paragraphs[0].Append(currentProcurementPlanModel.documentHistories[i - 1].version);
                            documentHistoryTable.Rows[i].Cells[1].Paragraphs[0].Append(currentProcurementPlanModel.documentHistories[i - 1].issueDate);
                            documentHistoryTable.Rows[i].Cells[2].Paragraphs[0].Append(currentProcurementPlanModel.documentHistories[i - 1].changes);

                        }

                        documentHistoryTable.SetWidths(new float[] { 190, 303, 1094 });
                        document.InsertTable(documentHistoryTable);

                        document.InsertParagraph("\nDocument Approvals\n")
                           .Font("Arial")
                           .Bold(true)
                           .FontSize(14d).Alignment = Alignment.left;

                        var documentApprovalTable = document.AddTable(currentProcurementPlanModel.documentApprovals.Count + 1, 4);
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

                        for (int i = 1; i < currentProcurementPlanModel.documentApprovals.Count + 1; i++)
                        {
                            documentApprovalTable.Rows[i].Cells[0].Paragraphs[0].Append(currentProcurementPlanModel.documentApprovals[i - 1].role);
                            documentApprovalTable.Rows[i].Cells[1].Paragraphs[0].Append(currentProcurementPlanModel.documentApprovals[i - 1].name);
                            documentApprovalTable.Rows[i].Cells[2].Paragraphs[0].Append(currentProcurementPlanModel.documentApprovals[i - 1].changes);
                            documentApprovalTable.Rows[i].Cells[3].Paragraphs[0].Append(currentProcurementPlanModel.documentApprovals[i - 1].date);
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

                        #region Procurement Requirements
                        var procReqHeading = document.InsertParagraph("1 Procurement Requirements")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        procReqHeading.StyleId = "Heading1";

                        #region Requirements
                        var requirementsSubHeading = document.InsertParagraph("1.1 Requirements")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        requirementsSubHeading.StyleId = "Heading2";

                        var documentRequirementsTable = document.AddTable(currentProcurementPlanModel.documentRequirements.Count + 1, 5);

                        documentRequirementsTable.Rows[0].Cells[0].Paragraphs[0].Append("Item")
                            .Bold(true)
                            .Color(Color.White);
                        documentRequirementsTable.Rows[0].Cells[1].Paragraphs[0].Append("Description")
                            .Bold(true)
                            .Color(Color.White);
                        documentRequirementsTable.Rows[0].Cells[2].Paragraphs[0].Append("Justification")
                            .Bold(true)
                            .Color(Color.White);
                        documentRequirementsTable.Rows[0].Cells[3].Paragraphs[0].Append("Quantity")
                            .Bold(true)
                            .Color(Color.White);
                        documentRequirementsTable.Rows[0].Cells[4].Paragraphs[0].Append("Budget")
                            .Bold(true)
                            .Color(Color.White);

                        documentRequirementsTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        documentRequirementsTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        documentRequirementsTable.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;
                        documentRequirementsTable.Rows[0].Cells[3].FillColor = TABLE_HEADER_COLOR;
                        documentRequirementsTable.Rows[0].Cells[4].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < currentProcurementPlanModel.documentRequirements.Count + 1; i++)
                        {
                            documentRequirementsTable.Rows[i].Cells[0].Paragraphs[0].Append(currentProcurementPlanModel.documentRequirements[i - 1].item);
                            documentRequirementsTable.Rows[i].Cells[1].Paragraphs[0].Append(currentProcurementPlanModel.documentRequirements[i - 1].description);
                            documentRequirementsTable.Rows[i].Cells[2].Paragraphs[0].Append(currentProcurementPlanModel.documentRequirements[i - 1].justification);
                            documentRequirementsTable.Rows[i].Cells[3].Paragraphs[0].Append(currentProcurementPlanModel.documentRequirements[i - 1].quantity);
                            documentRequirementsTable.Rows[i].Cells[4].Paragraphs[0].Append(currentProcurementPlanModel.documentRequirements[i - 1].budget);
                        }

                        document.InsertTable(documentRequirementsTable);
                        #endregion

                        #region Market Research
                        var researchSubHeading = document.InsertParagraph("1.2 Market Research")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        researchSubHeading.StyleId = "Heading2";

                        var documentResearchTable = document.AddTable(currentProcurementPlanModel.documentMarketResearch.Count + 1, 5);

                        documentResearchTable.Rows[0].Cells[0].Paragraphs[0].Append("Item")
                            .Bold(true)
                            .Color(Color.White);
                        documentResearchTable.Rows[0].Cells[1].Paragraphs[0].Append("Supplier")
                            .Bold(true)
                            .Color(Color.White);
                        documentResearchTable.Rows[0].Cells[2].Paragraphs[0].Append("Offering")
                            .Bold(true)
                            .Color(Color.White);
                        documentResearchTable.Rows[0].Cells[3].Paragraphs[0].Append("Price")
                            .Bold(true)
                            .Color(Color.White);
                        documentResearchTable.Rows[0].Cells[4].Paragraphs[0].Append("Availability")
                            .Bold(true)
                            .Color(Color.White);

                        documentResearchTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        documentResearchTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        documentResearchTable.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;
                        documentResearchTable.Rows[0].Cells[3].FillColor = TABLE_HEADER_COLOR;
                        documentResearchTable.Rows[0].Cells[4].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < currentProcurementPlanModel.documentMarketResearch.Count + 1; i++)
                        {
                            documentResearchTable.Rows[i].Cells[0].Paragraphs[0].Append(currentProcurementPlanModel.documentMarketResearch[i - 1].item);
                            documentResearchTable.Rows[i].Cells[1].Paragraphs[0].Append(currentProcurementPlanModel.documentMarketResearch[i - 1].supplier);
                            documentResearchTable.Rows[i].Cells[2].Paragraphs[0].Append(currentProcurementPlanModel.documentMarketResearch[i - 1].offering);
                            documentResearchTable.Rows[i].Cells[3].Paragraphs[0].Append(currentProcurementPlanModel.documentMarketResearch[i - 1].price);
                            documentResearchTable.Rows[i].Cells[4].Paragraphs[0].Append(currentProcurementPlanModel.documentMarketResearch[i - 1].availability);
                        }

                        document.InsertTable(documentResearchTable);
                        #endregion
                        #endregion

                        #region Procurement Plan
                        var procPlanHeading = document.InsertParagraph("2 Procurement Plan")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        procPlanHeading.StyleId = "Heading1";

                        #region Schedule
                        var scheduleSubHeading = document.InsertParagraph("2.1 Schedule")
                           .Bold()
                           .FontSize(12d)
                           .Color(Color.Black)
                           .Bold(true)
                           .Font("Arial");

                        document.InsertParagraph(String.Join(",\n", "ADD SCHEDULE PLAN HERE"))
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        scheduleSubHeading.StyleId = "Heading2";
                        #endregion

                        var assumptionsSubHeading = document.InsertParagraph("2.2 Assumptions")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        document.InsertParagraph(String.Join(",\n", currentProcurementPlanModel.assumptions))
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        assumptionsSubHeading.StyleId = "Heading2";


                        var constraintsSubHeading = document.InsertParagraph("2.3 Constraints")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        document.InsertParagraph(String.Join(",\n", currentProcurementPlanModel.constraints))
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        constraintsSubHeading.StyleId = "Heading2";
                        #endregion

                        #region Tender Process
                        var tenderProcHeading = document.InsertParagraph("3 Tender Process")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        tenderProcHeading.StyleId = "Heading1";


                        var activitiesSubHeading = document.InsertParagraph("3.1 Activities")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        document.InsertParagraph(String.Join(",\n", currentProcurementPlanModel.tenderActivities))
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

                        document.InsertParagraph(String.Join(",\n", currentProcurementPlanModel.tenderRoles))
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

                        document.InsertParagraph(String.Join(",\n", currentProcurementPlanModel.tenderDocuments))
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        documentsSubHeading.StyleId = "Heading2";
                        #endregion

                        #region Procurement Process
                        var procProcHeading = document.InsertParagraph("4 Procurement Process")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        procProcHeading.StyleId = "Heading1";


                        var procActivitiesSubHeading = document.InsertParagraph("4.1 Activities")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        document.InsertParagraph(String.Join(",\n", currentProcurementPlanModel.procurementActivities))
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        procActivitiesSubHeading.StyleId = "Heading2";


                        var procRolesSubHeading = document.InsertParagraph("4.2 Roles")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        document.InsertParagraph(String.Join(",\n", currentProcurementPlanModel.procurementRoles))
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        procRolesSubHeading.StyleId = "Heading2";


                        var procDocumentsSubHeading = document.InsertParagraph("4.3 Documents")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        document.InsertParagraph(String.Join(",\n", currentProcurementPlanModel.procurementDocuments))
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        procDocumentsSubHeading.StyleId = "Heading2";
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
