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
    public partial class FinacialPlanDocumentForm : Form
    {
        VersionControl<FinancialPlanModel> versionControl;
        FinancialPlanModel newFinancialPlanModel;
        FinancialPlanModel currentFinancialPlanModel;

        Color TABLE_HEADER_COLOR = Color.FromArgb(73, 173, 252);
        Color TABLE_SUBHEADER_COLOR = Color.FromArgb(255, 255, 0);

        public FinacialPlanDocumentForm()
        {
            InitializeComponent();
        }

        private void btnSaveAssumptions_Click(object sender, EventArgs e)
        {
            string assumptions = txtAssumptions.Text;
        }

        private void btnSaveConstraints_Click(object sender, EventArgs e)
        {
            string constraints = txtConstraints.Text;
        }

        private void btnSaveActivitiesRolesDocuments_Click(object sender, EventArgs e)
        {
            string activies = txtActivities.Text;
            string roles = txtRoles.Text;
            string documents = txtDocuments.Text;
        }

        private void btnSaveProjectName_Click(object sender, EventArgs e)
        {
            string projectName = txtProjectName.Text;
            SaveDocument();
        }

        //Back-End
        public void SaveDocument()
        {
            newFinancialPlanModel.schedule = new FinancialPlanModel.DocumentSchedule();
            newFinancialPlanModel.schedule.expenses = new List<FinancialPlanModel.DocumentSchedule.Expense>();

            newFinancialPlanModel.documentID = dataGridViewDocumentInformation.Rows[0].Cells[1].Value.ToString();
            newFinancialPlanModel.documentOwner = dataGridViewDocumentInformation.Rows[1].Cells[1].Value.ToString();
            newFinancialPlanModel.issueDate = dataGridViewDocumentInformation.Rows[2].Cells[1].Value.ToString();
            newFinancialPlanModel.lastSavedDate = dataGridViewDocumentInformation.Rows[3].Cells[1].Value.ToString();
            newFinancialPlanModel.fileName = dataGridViewDocumentInformation.Rows[4].Cells[1].Value.ToString();

            List<FinancialPlanModel.DocumentHistory> documentHistories = new List<FinancialPlanModel.DocumentHistory>();

            int versionRowCount = dataGridViewDocumentHistory.Rows.Count - 1;

            for (int i = 0; i < versionRowCount; i++)
            {
                FinancialPlanModel.DocumentHistory documentHistory = new FinancialPlanModel.DocumentHistory();
                var tempVersion = dataGridViewDocumentHistory.Rows[i].Cells[0].Value?.ToString() ?? "";
                var tempIssueDate = dataGridViewDocumentHistory.Rows[i].Cells[1].Value?.ToString() ?? "";
                var tempChanges = dataGridViewDocumentHistory.Rows[i].Cells[2].Value?.ToString() ?? "";
                documentHistory.version = tempVersion;
                documentHistory.issueDate = tempIssueDate;
                documentHistory.changes = tempChanges;
                documentHistories.Add(documentHistory);
            }
            newFinancialPlanModel.documentHistories = documentHistories;

            List<FinancialPlanModel.DocumentApprovals> documentApprovals = new List<FinancialPlanModel.DocumentApprovals>();

            int approvalRowsCount = dataGridViewDocumentApprovals.Rows.Count - 1;

            for (int i = 0; i < approvalRowsCount; i++)
            {
                FinancialPlanModel.DocumentApprovals documentApproval = new FinancialPlanModel.DocumentApprovals();
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
            newFinancialPlanModel.documentApprovals = documentApprovals;

            List<FinancialPlanModel.DocumentLabor> documentLabors = new List<FinancialPlanModel.DocumentLabor>();

            int labourCount = dataGridViewLabour.Rows.Count - 1;

            for (int i = 0; i < labourCount; i++)
            {
                FinancialPlanModel.DocumentLabor documentLabor = new FinancialPlanModel.DocumentLabor();
                var tempRole = dataGridViewLabour.Rows[i].Cells[0].Value?.ToString() ?? "";
                var tempUnitCost = dataGridViewLabour.Rows[i].Cells[1].Value?.ToString() ?? "";
                documentLabor.role = tempRole;
                documentLabor.unitCost = tempUnitCost;

                documentLabors.Add(documentLabor);
            }
            newFinancialPlanModel.documentLabors = documentLabors;

            List<FinancialPlanModel.DocumentEquipment> documentEquipments = new List<FinancialPlanModel.DocumentEquipment>();

            int equipmentCount = dataGridViewEquipment.Rows.Count - 1;

            for (int i = 0; i < equipmentCount; i++)
            {
                FinancialPlanModel.DocumentEquipment documentEquipment = new FinancialPlanModel.DocumentEquipment();
                var tempEquipment = dataGridViewEquipment.Rows[i].Cells[0].Value?.ToString() ?? "";
                var tempUnitCost = dataGridViewEquipment.Rows[i].Cells[1].Value?.ToString() ?? "";
                documentEquipment.equipment = tempEquipment;
                documentEquipment.unitCost = tempUnitCost;

                documentEquipments.Add(documentEquipment);
            }
            newFinancialPlanModel.documentEquipments = documentEquipments;

            List<FinancialPlanModel.DocumentMaterial> documentMaterials = new List<FinancialPlanModel.DocumentMaterial>();

            int materialCount = dataGridViewMaterials.Rows.Count - 1;

            for (int i = 0; i < materialCount; i++)
            {
                FinancialPlanModel.DocumentMaterial documentMaterial = new FinancialPlanModel.DocumentMaterial();
                var tempMat = dataGridViewMaterials.Rows[i].Cells[0].Value?.ToString() ?? "";
                var tempUnitCost = dataGridViewMaterials.Rows[i].Cells[1].Value?.ToString() ?? "";
                documentMaterial.material = tempMat;
                documentMaterial.unitCost = tempUnitCost;

                documentMaterials.Add(documentMaterial);
            }
            newFinancialPlanModel.documentMaterials = documentMaterials;

            List<FinancialPlanModel.DocumentSupplier> documentSuppliers = new List<FinancialPlanModel.DocumentSupplier>();

            int supplierCount = dataGridViewSuppliers.Rows.Count - 1;

            for (int i = 0; i < supplierCount; i++)
            {
                FinancialPlanModel.DocumentSupplier documentSupplier = new FinancialPlanModel.DocumentSupplier();
                var tempDeliverable = dataGridViewSuppliers.Rows[i].Cells[0].Value?.ToString() ?? "";
                var tempUnitCost = dataGridViewSuppliers.Rows[i].Cells[1].Value?.ToString() ?? "";
                documentSupplier.deliverableItem = tempDeliverable;
                documentSupplier.unitCost = tempUnitCost;

                documentSuppliers.Add(documentSupplier);
            }
            newFinancialPlanModel.documentSuppliers = documentSuppliers;

            List<FinancialPlanModel.DocumentAdministration> documentAdministrations = new List<FinancialPlanModel.DocumentAdministration>();

            int adminCount = dataGridViewAdmin.Rows.Count - 1;

            for (int i = 0; i < adminCount; i++)
            {
                FinancialPlanModel.DocumentAdministration documentAdministration = new FinancialPlanModel.DocumentAdministration();
                var tempAdminItem = dataGridViewAdmin.Rows[i].Cells[0].Value?.ToString() ?? "";
                var tempUnitCost = dataGridViewAdmin.Rows[i].Cells[1].Value?.ToString() ?? "";
                documentAdministration.administrativeItem = tempAdminItem;
                documentAdministration.unitCost = tempUnitCost;

                documentAdministrations.Add(documentAdministration);
            }
            newFinancialPlanModel.documentAdministrations = documentAdministrations;

            List<FinancialPlanModel.DocumentOther> documentOthers = new List<FinancialPlanModel.DocumentOther>();

            int otherCount = dataGridViewOther.Rows.Count - 1;

            for (int i = 0; i < otherCount; i++)
            {
                FinancialPlanModel.DocumentOther documentOther = new FinancialPlanModel.DocumentOther();
                var tempOther = dataGridViewOther.Rows[i].Cells[0].Value?.ToString() ?? "";
                var tempUnitCost = dataGridViewOther.Rows[i].Cells[1].Value?.ToString() ?? "";
                documentOther.otherExpenseItem = tempOther;
                documentOther.unitCost = tempUnitCost;

                documentOthers.Add(documentOther);
            }
            newFinancialPlanModel.documentOthers = documentOthers;

            List<FinancialPlanModel.DocumentSchedule.Expense> expenses = new List<FinancialPlanModel.DocumentSchedule.Expense>();

            int scheduleCount = dataGridView1.Rows.Count - 1;

            for (int i = 0; i < scheduleCount; i++)
            {
                FinancialPlanModel.DocumentSchedule.Expense expense = new FinancialPlanModel.DocumentSchedule.Expense();
                expense.expenseType = dataGridView1.Rows[i].Cells[0].Value?.ToString() ?? "";

                for (int j = 0; j < 12; j++)
                {
                    expense.expensePerMonth[j] = dataGridView1.Rows[i].Cells[j + 1].Value?.ToString() ?? "";
                }

                expenses.Add(expense);
            }
            newFinancialPlanModel.schedule.expenses = expenses;

            newFinancialPlanModel.assumptions = txtAssumptions.Text;
            newFinancialPlanModel.constraints = txtConstraints.Text;

            newFinancialPlanModel.financialActivities = txtActivities.Text;
            newFinancialPlanModel.financialDocuments = txtDocuments.Text;
            newFinancialPlanModel.financialRoles = txtRoles.Text;

            List<VersionControl<FinancialPlanModel>.DocumentModel> documentModels = versionControl.DocumentModels;

            if (!versionControl.isEqual(currentFinancialPlanModel, newFinancialPlanModel))
            {
                VersionControl<FinancialPlanModel>.DocumentModel documentModel = new VersionControl<FinancialPlanModel>.DocumentModel(newFinancialPlanModel, DateTime.Now, VersionControl<ProjectModel>.generateID());

                documentModels.Add(documentModel);
                versionControl.DocumentModels = documentModels;
                currentFinancialPlanModel = JsonConvert.DeserializeObject<FinancialPlanModel>(JsonConvert.SerializeObject(newFinancialPlanModel));

                string json = JsonConvert.SerializeObject(versionControl);
                JsonHelper.saveDocument(json, Settings.Default.ProjectID, "FinancialPlan");
                MessageBox.Show("Financial plan saved successfully", "save", MessageBoxButtons.OK);
            }
        }

        public void loadDocument()
        {
            string json = JsonHelper.loadDocument(Settings.Default.ProjectID, "FinancialPlan");
            List<string[]> documentInfo = new List<string[]>();
            newFinancialPlanModel = new FinancialPlanModel();
            currentFinancialPlanModel = new FinancialPlanModel();
            if (json != "")
            {
                versionControl = JsonConvert.DeserializeObject<VersionControl<FinancialPlanModel>>(json);
                newFinancialPlanModel = JsonConvert.DeserializeObject<FinancialPlanModel>(versionControl.getLatest(versionControl.DocumentModels));
                currentFinancialPlanModel = JsonConvert.DeserializeObject<FinancialPlanModel>(versionControl.getLatest(versionControl.DocumentModels));

                documentInfo.Add(new string[] { "Document ID", currentFinancialPlanModel.documentID });
                documentInfo.Add(new string[] { "Document Owner", currentFinancialPlanModel.documentOwner });
                documentInfo.Add(new string[] { "Issue Date", currentFinancialPlanModel.issueDate });
                documentInfo.Add(new string[] { "Last Save Date", currentFinancialPlanModel.lastSavedDate });
                documentInfo.Add(new string[] { "File Name", currentFinancialPlanModel.fileName });

                foreach (var row in documentInfo)
                {
                    dataGridViewDocumentInformation.Rows.Add(row);
                }
                dataGridViewDocumentInformation.AllowUserToAddRows = false;

                foreach (var row in currentFinancialPlanModel.documentHistories)
                {
                    dataGridViewDocumentHistory.Rows.Add(new string[] { row.version, row.issueDate, row.changes });
                }

                foreach (var row in currentFinancialPlanModel.documentApprovals)
                {
                    dataGridViewDocumentApprovals.Rows.Add(new String[] { row.role, row.name, row.changes, row.date });
                }

                foreach (var row in currentFinancialPlanModel.documentLabors)
                {
                    dataGridViewLabour.Rows.Add(new String[] { row.role, row.unitCost });
                }

                foreach (var row in currentFinancialPlanModel.documentEquipments)
                {
                    dataGridViewEquipment.Rows.Add(new String[] { row.equipment, row.unitCost });
                }

                foreach (var row in currentFinancialPlanModel.documentMaterials)
                {
                    dataGridViewMaterials.Rows.Add(new String[] { row.material, row.unitCost });
                }

                foreach (var row in currentFinancialPlanModel.documentSuppliers)
                {
                    dataGridViewSuppliers.Rows.Add(new String[] { row.deliverableItem, row.unitCost });
                }

                foreach (var row in currentFinancialPlanModel.documentAdministrations)
                {
                    dataGridViewAdmin.Rows.Add(new String[] { row.administrativeItem, row.unitCost });
                }

                foreach (var row in currentFinancialPlanModel.documentOthers)
                {
                    dataGridViewOther.Rows.Add(new String[] { row.otherExpenseItem, row.unitCost });
                }

                foreach (var row in currentFinancialPlanModel.schedule.expenses)
                {
                    dataGridView1.Rows.Add(new String[] {
                        row.expenseType,
                        row.expensePerMonth[0],
                        row.expensePerMonth[1],
                        row.expensePerMonth[2],
                        row.expensePerMonth[3],
                        row.expensePerMonth[4],
                        row.expensePerMonth[5],
                        row.expensePerMonth[6],
                        row.expensePerMonth[7],
                        row.expensePerMonth[8],
                        row.expensePerMonth[9],
                        row.expensePerMonth[10],
                        row.expensePerMonth[11],
                    });
                }

                txtAssumptions.Text = newFinancialPlanModel.assumptions;
                txtConstraints.Text = newFinancialPlanModel.constraints;

                txtActivities.Text = newFinancialPlanModel.financialActivities;
                txtDocuments.Text = newFinancialPlanModel.financialDocuments;
                txtRoles.Text = newFinancialPlanModel.financialRoles;
            }
            else
            {
                versionControl = new VersionControl<FinancialPlanModel>();
                versionControl.DocumentModels = new List<VersionControl<FinancialPlanModel>.DocumentModel>();
                documentInfo.Add(new string[] { "Document ID", "" });
                documentInfo.Add(new string[] { "Document Owner", "" });
                documentInfo.Add(new string[] { "Issue Date", "" });
                documentInfo.Add(new string[] { "Last Save Date", "" });
                documentInfo.Add(new string[] { "File Name", "" });
                newFinancialPlanModel = new FinancialPlanModel();
                foreach (var row in documentInfo)
                {
                    dataGridViewDocumentInformation.Rows.Add(row);
                }
                dataGridViewDocumentInformation.AllowUserToAddRows = false;
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

                        document.InsertParagraph("Financial Plan \nFor " + txtProjectName.Text)
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
                        documentInfoTable.Rows[1].Cells[1].Paragraphs[0].Append(currentFinancialPlanModel.documentID);

                        documentInfoTable.Rows[2].Cells[0].Paragraphs[0].Append("Document Owner");
                        documentInfoTable.Rows[2].Cells[1].Paragraphs[0].Append(currentFinancialPlanModel.documentOwner);

                        documentInfoTable.Rows[3].Cells[0].Paragraphs[0].Append("Issue Date");
                        documentInfoTable.Rows[3].Cells[1].Paragraphs[0].Append(currentFinancialPlanModel.issueDate);

                        documentInfoTable.Rows[4].Cells[0].Paragraphs[0].Append("Last Saved Date");
                        documentInfoTable.Rows[4].Cells[1].Paragraphs[0].Append(currentFinancialPlanModel.lastSavedDate);

                        documentInfoTable.Rows[5].Cells[0].Paragraphs[0].Append("File Name");
                        documentInfoTable.Rows[5].Cells[1].Paragraphs[0].Append(currentFinancialPlanModel.fileName);
                        documentInfoTable.SetWidths(new float[] { 493, 1094 });
                        document.InsertTable(documentInfoTable);

                        document.InsertParagraph("\nDocument History\n")
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(14d).Alignment = Alignment.left;

                        var documentHistoryTable = document.AddTable(currentFinancialPlanModel.documentHistories.Count + 1, 3);
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
                        for (int i = 1; i < currentFinancialPlanModel.documentHistories.Count + 1; i++)
                        {
                            documentHistoryTable.Rows[i].Cells[0].Paragraphs[0].Append(currentFinancialPlanModel.documentHistories[i - 1].version);
                            documentHistoryTable.Rows[i].Cells[1].Paragraphs[0].Append(currentFinancialPlanModel.documentHistories[i - 1].issueDate);
                            documentHistoryTable.Rows[i].Cells[2].Paragraphs[0].Append(currentFinancialPlanModel.documentHistories[i - 1].changes);

                        }

                        documentHistoryTable.SetWidths(new float[] { 190, 303, 1094 });
                        document.InsertTable(documentHistoryTable);

                        document.InsertParagraph("\nDocument Approvals\n")
                           .Font("Arial")
                           .Bold(true)
                           .FontSize(14d).Alignment = Alignment.left;

                        var documentApprovalTable = document.AddTable(currentFinancialPlanModel.documentApprovals.Count + 1, 4);
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

                        for (int i = 1; i < currentFinancialPlanModel.documentApprovals.Count + 1; i++)
                        {
                            documentApprovalTable.Rows[i].Cells[0].Paragraphs[0].Append(currentFinancialPlanModel.documentApprovals[i - 1].role);
                            documentApprovalTable.Rows[i].Cells[1].Paragraphs[0].Append(currentFinancialPlanModel.documentApprovals[i - 1].name);
                            documentApprovalTable.Rows[i].Cells[2].Paragraphs[0].Append(currentFinancialPlanModel.documentApprovals[i - 1].changes);
                            documentApprovalTable.Rows[i].Cells[3].Paragraphs[0].Append(currentFinancialPlanModel.documentApprovals[i - 1].date);
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

                        #region Fincancial Expenses
                        var financialCritHeading = document.InsertParagraph("1 Financial Expenses")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        financialCritHeading.StyleId = "Heading1";

                        #region Labor
                        var laborSubHeading = document.InsertParagraph("1.1 Labor")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        laborSubHeading.StyleId = "Heading2";

                        var documentLaborTable = document.AddTable(currentFinancialPlanModel.documentLabors.Count + 1, 2);
                        documentLaborTable.Rows[0].Cells[0].Paragraphs[0].Append("Role")
                            .Bold(true)
                            .Color(Color.White);
                        documentLaborTable.Rows[0].Cells[1].Paragraphs[0].Append("Unit cost")
                            .Bold(true)
                            .Color(Color.White);

                        documentLaborTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        documentLaborTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < currentFinancialPlanModel.documentLabors.Count + 1; i++)
                        {
                            documentLaborTable.Rows[i].Cells[0].Paragraphs[0].Append(currentFinancialPlanModel.documentLabors[i - 1].role);
                            documentLaborTable.Rows[i].Cells[1].Paragraphs[0].Append(currentFinancialPlanModel.documentLabors[i - 1].unitCost);
                        }

                        documentLaborTable.SetWidths(new float[] { 762, 419 });
                        document.InsertTable(documentLaborTable);
                        #endregion

                        #region Equipment
                        var equipmentSubHeading = document.InsertParagraph("1.2 Equipment")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        equipmentSubHeading.StyleId = "Heading2";

                        var documentEquipmentTable = document.AddTable(currentFinancialPlanModel.documentEquipments.Count + 1, 2);
                        documentEquipmentTable.Rows[0].Cells[0].Paragraphs[0].Append("Equipment")
                            .Bold(true)
                            .Color(Color.White);
                        documentEquipmentTable.Rows[0].Cells[1].Paragraphs[0].Append("Unit cost")
                            .Bold(true)
                            .Color(Color.White);

                        documentEquipmentTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        documentEquipmentTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < currentFinancialPlanModel.documentEquipments.Count + 1; i++)
                        {
                            documentEquipmentTable.Rows[i].Cells[0].Paragraphs[0].Append(currentFinancialPlanModel.documentEquipments[i - 1].equipment);
                            documentEquipmentTable.Rows[i].Cells[1].Paragraphs[0].Append(currentFinancialPlanModel.documentEquipments[i - 1].unitCost);
                        }

                        documentEquipmentTable.SetWidths(new float[] { 762, 419 });
                        document.InsertTable(documentEquipmentTable);
                        #endregion

                        #region Materials
                        var materialsSubHeading = document.InsertParagraph("1.3 Materials")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        materialsSubHeading.StyleId = "Heading2";

                        var documentMaterialsTable = document.AddTable(currentFinancialPlanModel.documentMaterials.Count + 1, 2);
                        documentMaterialsTable.Rows[0].Cells[0].Paragraphs[0].Append("Material")
                            .Bold(true)
                            .Color(Color.White);
                        documentMaterialsTable.Rows[0].Cells[1].Paragraphs[0].Append("Unit cost")
                            .Bold(true)
                            .Color(Color.White);

                        documentMaterialsTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        documentMaterialsTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < currentFinancialPlanModel.documentMaterials.Count + 1; i++)
                        {
                            documentMaterialsTable.Rows[i].Cells[0].Paragraphs[0].Append(currentFinancialPlanModel.documentMaterials[i - 1].material);
                            documentMaterialsTable.Rows[i].Cells[1].Paragraphs[0].Append(currentFinancialPlanModel.documentMaterials[i - 1].unitCost);
                        }

                        documentMaterialsTable.SetWidths(new float[] { 762, 419 });
                        document.InsertTable(documentMaterialsTable);
                        #endregion

                        #region Suppliers
                        var suppliersSubHeading = document.InsertParagraph("1.4 Suppliers")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        suppliersSubHeading.StyleId = "Heading2";

                        var documentSuppliersTable = document.AddTable(currentFinancialPlanModel.documentSuppliers.Count + 1, 2);
                        documentSuppliersTable.Rows[0].Cells[0].Paragraphs[0].Append("Deliverable Item")
                            .Bold(true)
                            .Color(Color.White);
                        documentSuppliersTable.Rows[0].Cells[1].Paragraphs[0].Append("Unit cost")
                            .Bold(true)
                            .Color(Color.White);

                        documentSuppliersTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        documentSuppliersTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < currentFinancialPlanModel.documentSuppliers.Count + 1; i++)
                        {
                            documentSuppliersTable.Rows[i].Cells[0].Paragraphs[0].Append(currentFinancialPlanModel.documentSuppliers[i - 1].deliverableItem);
                            documentSuppliersTable.Rows[i].Cells[1].Paragraphs[0].Append(currentFinancialPlanModel.documentSuppliers[i - 1].unitCost);
                        }

                        documentSuppliersTable.SetWidths(new float[] { 762, 419 });
                        document.InsertTable(documentSuppliersTable);
                        #endregion

                        #region Administration
                        var adminSubHeading = document.InsertParagraph("1.5 Administration")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        adminSubHeading.StyleId = "Heading2";

                        var documentAdminTable = document.AddTable(currentFinancialPlanModel.documentAdministrations.Count + 1, 2);
                        documentAdminTable.Rows[0].Cells[0].Paragraphs[0].Append("Administrative Item")
                            .Bold(true)
                            .Color(Color.White);
                        documentAdminTable.Rows[0].Cells[1].Paragraphs[0].Append("Unit cost")
                            .Bold(true)
                            .Color(Color.White);

                        documentAdminTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        documentAdminTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < currentFinancialPlanModel.documentAdministrations.Count + 1; i++)
                        {
                            documentAdminTable.Rows[i].Cells[0].Paragraphs[0].Append(currentFinancialPlanModel.documentAdministrations[i - 1].administrativeItem);
                            documentAdminTable.Rows[i].Cells[1].Paragraphs[0].Append(currentFinancialPlanModel.documentAdministrations[i - 1].unitCost);
                        }

                        documentAdminTable.SetWidths(new float[] { 762, 419 });
                        document.InsertTable(documentAdminTable);
                        #endregion

                        #region Other
                        var otherSubHeading = document.InsertParagraph("1.6 Other")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        otherSubHeading.StyleId = "Heading2";

                        var documentOtherTable = document.AddTable(currentFinancialPlanModel.documentOthers.Count + 1, 2);
                        documentOtherTable.Rows[0].Cells[0].Paragraphs[0].Append("Other Expense Item")
                            .Bold(true)
                            .Color(Color.White);
                        documentOtherTable.Rows[0].Cells[1].Paragraphs[0].Append("Unit cost")
                            .Bold(true)
                            .Color(Color.White);

                        documentOtherTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        documentOtherTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < currentFinancialPlanModel.documentOthers.Count + 1; i++)
                        {
                            documentOtherTable.Rows[i].Cells[0].Paragraphs[0].Append(currentFinancialPlanModel.documentOthers[i - 1].otherExpenseItem);
                            documentOtherTable.Rows[i].Cells[1].Paragraphs[0].Append(currentFinancialPlanModel.documentOthers[i - 1].unitCost);
                        }

                        documentOtherTable.SetWidths(new float[] { 762, 419 });
                        document.InsertTable(documentOtherTable);
                        #endregion
                        #endregion

                        #region Financial Plan
                        var finanPlanHeading = document.InsertParagraph("2 Financial Plan")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        finanPlanHeading.StyleId = "Heading1";

                        #region Schedule
                        var scheduleSubHeading = document.InsertParagraph("2.1 Schedule")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        scheduleSubHeading.StyleId = "Heading2";

                        var documentScheduleTable = document.AddTable(currentFinancialPlanModel.schedule.expenses.Count + 2, 13);

                        documentScheduleTable.Rows[0].MergeCells(1, 12);

                        documentScheduleTable.Rows[0].Cells[1].Paragraphs[0].Append("Months")
                            .Bold(true)
                            .Color(Color.White);

                        documentScheduleTable.Rows[1].Cells[0].Paragraphs[0].Append("Type")
                            .Bold(true)
                            .Color(Color.Black);
                        documentScheduleTable.Rows[1].Cells[1].Paragraphs[0].Append("Jan")
                            .Bold(true)
                            .Color(Color.Black);
                        documentScheduleTable.Rows[1].Cells[2].Paragraphs[0].Append("Feb")
                            .Bold(true)
                            .Color(Color.Black);
                        documentScheduleTable.Rows[1].Cells[3].Paragraphs[0].Append("Mar")
                            .Bold(true)
                            .Color(Color.Black);
                        documentScheduleTable.Rows[1].Cells[4].Paragraphs[0].Append("Apr")
                            .Bold(true)
                            .Color(Color.Black);
                        documentScheduleTable.Rows[1].Cells[5].Paragraphs[0].Append("May")
                            .Bold(true)
                            .Color(Color.Black);
                        documentScheduleTable.Rows[1].Cells[6].Paragraphs[0].Append("Jun")
                            .Bold(true)
                            .Color(Color.Black);
                        documentScheduleTable.Rows[1].Cells[7].Paragraphs[0].Append("Jul")
                            .Bold(true)
                            .Color(Color.Black);
                        documentScheduleTable.Rows[1].Cells[8].Paragraphs[0].Append("Aug")
                            .Bold(true)
                            .Color(Color.Black);
                        documentScheduleTable.Rows[1].Cells[9].Paragraphs[0].Append("Sept")
                            .Bold(true)
                            .Color(Color.Black);
                        documentScheduleTable.Rows[1].Cells[10].Paragraphs[0].Append("Oct")
                            .Bold(true)
                            .Color(Color.Black);
                        documentScheduleTable.Rows[1].Cells[11].Paragraphs[0].Append("Nov")
                            .Bold(true)
                            .Color(Color.Black);
                        documentScheduleTable.Rows[1].Cells[12].Paragraphs[0].Append("Dec")
                            .Bold(true)
                            .Color(Color.Black);

                        documentScheduleTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;

                        documentScheduleTable.Rows[1].Cells[0].FillColor = TABLE_SUBHEADER_COLOR;
                        documentScheduleTable.Rows[1].Cells[1].FillColor = TABLE_SUBHEADER_COLOR;
                        documentScheduleTable.Rows[1].Cells[2].FillColor = TABLE_SUBHEADER_COLOR;
                        documentScheduleTable.Rows[1].Cells[3].FillColor = TABLE_SUBHEADER_COLOR;
                        documentScheduleTable.Rows[1].Cells[4].FillColor = TABLE_SUBHEADER_COLOR;
                        documentScheduleTable.Rows[1].Cells[5].FillColor = TABLE_SUBHEADER_COLOR;
                        documentScheduleTable.Rows[1].Cells[6].FillColor = TABLE_SUBHEADER_COLOR;
                        documentScheduleTable.Rows[1].Cells[7].FillColor = TABLE_SUBHEADER_COLOR;
                        documentScheduleTable.Rows[1].Cells[8].FillColor = TABLE_SUBHEADER_COLOR;
                        documentScheduleTable.Rows[1].Cells[9].FillColor = TABLE_SUBHEADER_COLOR;
                        documentScheduleTable.Rows[1].Cells[10].FillColor = TABLE_SUBHEADER_COLOR;
                        documentScheduleTable.Rows[1].Cells[11].FillColor = TABLE_SUBHEADER_COLOR;
                        documentScheduleTable.Rows[1].Cells[12].FillColor = TABLE_SUBHEADER_COLOR;

                        for (int i = 2; i < currentFinancialPlanModel.schedule.expenses.Count + 2; i++)
                        {
                            documentScheduleTable.Rows[i].Cells[0].Paragraphs[0].Append(currentFinancialPlanModel.schedule.expenses[i - 2].expenseType);
                            documentScheduleTable.Rows[i].Cells[1].Paragraphs[0].Append(currentFinancialPlanModel.schedule.expenses[i - 2].expensePerMonth[0]);
                            documentScheduleTable.Rows[i].Cells[2].Paragraphs[0].Append(currentFinancialPlanModel.schedule.expenses[i - 2].expensePerMonth[1]);
                            documentScheduleTable.Rows[i].Cells[3].Paragraphs[0].Append(currentFinancialPlanModel.schedule.expenses[i - 2].expensePerMonth[2]);
                            documentScheduleTable.Rows[i].Cells[4].Paragraphs[0].Append(currentFinancialPlanModel.schedule.expenses[i - 2].expensePerMonth[3]);
                            documentScheduleTable.Rows[i].Cells[5].Paragraphs[0].Append(currentFinancialPlanModel.schedule.expenses[i - 2].expensePerMonth[4]);
                            documentScheduleTable.Rows[i].Cells[6].Paragraphs[0].Append(currentFinancialPlanModel.schedule.expenses[i - 2].expensePerMonth[5]);
                            documentScheduleTable.Rows[i].Cells[7].Paragraphs[0].Append(currentFinancialPlanModel.schedule.expenses[i - 2].expensePerMonth[6]);
                            documentScheduleTable.Rows[i].Cells[8].Paragraphs[0].Append(currentFinancialPlanModel.schedule.expenses[i - 2].expensePerMonth[7]);
                            documentScheduleTable.Rows[i].Cells[9].Paragraphs[0].Append(currentFinancialPlanModel.schedule.expenses[i - 2].expensePerMonth[8]);
                            documentScheduleTable.Rows[i].Cells[10].Paragraphs[0].Append(currentFinancialPlanModel.schedule.expenses[i - 2].expensePerMonth[9]);
                            documentScheduleTable.Rows[i].Cells[11].Paragraphs[0].Append(currentFinancialPlanModel.schedule.expenses[i - 2].expensePerMonth[10]);
                            documentScheduleTable.Rows[i].Cells[12].Paragraphs[0].Append(currentFinancialPlanModel.schedule.expenses[i - 2].expensePerMonth[11]);
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

                        document.InsertParagraph(String.Join(",\n", currentFinancialPlanModel.assumptions))
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

                        document.InsertParagraph(String.Join(",\n", currentFinancialPlanModel.constraints))
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;


                        constraintsSubHeading.StyleId = "Heading2";
                        #endregion
                        #endregion

                        #region Financial Process
                        var acceptanceProcessHeading = document.InsertParagraph("3 Financial Process")
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

                        document.InsertParagraph(String.Join(",\n", currentFinancialPlanModel.financialActivities))
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

                        document.InsertParagraph(String.Join(",\n", currentFinancialPlanModel.financialRoles))
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

                        document.InsertParagraph(String.Join(",\n", currentFinancialPlanModel.financialDocuments))
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

        private void dataGridViewOther_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabControlFinancialExpense_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FinacialPlanDocumentForm_Load(object sender, EventArgs e)
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

            dataGridViewLabour.Columns.Add("Role2", "Role");
            dataGridViewLabour.Columns.Add("UnitCost", "Unit Cost");

            dataGridViewEquipment.Columns.Add("Equipment", "Equipment");
            dataGridViewEquipment.Columns.Add("UnitCost1", "Unit Cost");

            dataGridViewMaterials.Columns.Add("Material", "Material");
            dataGridViewMaterials.Columns.Add("UnitCost2", "Unit Cost");

            dataGridViewSuppliers.Columns.Add("DeliverableItem", "Deliverable Item");
            dataGridViewSuppliers.Columns.Add("UnitCost3", "Unit Cost");

            dataGridViewAdmin.Columns.Add("Administrative", "Administrative Item");
            dataGridViewAdmin.Columns.Add("UnitCost4", "Unit Cost");

            dataGridViewOther.Columns.Add("Othexpensetem", "Other Expense Item");
            dataGridViewOther.Columns.Add("UnitCost5", "Unit Cost");

            dataGridView1.Columns.Add("ExpenseT", "Expense Type");
            dataGridView1.Columns.Add("Jan", "Jan");
            dataGridView1.Columns.Add("Feb", "Feb");
            dataGridView1.Columns.Add("Mar", "Mar");
            dataGridView1.Columns.Add("Apr", "Apr");
            dataGridView1.Columns.Add("May", "May");
            dataGridView1.Columns.Add("Jun", "Jun");
            dataGridView1.Columns.Add("Jul", "Jul");
            dataGridView1.Columns.Add("Aug", "Aug");
            dataGridView1.Columns.Add("Sept", "Sept");
            dataGridView1.Columns.Add("Oct", "Oct");
            dataGridView1.Columns.Add("Nov", "Nov");
            dataGridView1.Columns.Add("Dec", "Dec");
            dataGridView1.Columns.Add("Total", "Total");
            loadDocument();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            exportToWord();
        }

        private void tabPageFinancialExpenses_Click(object sender, EventArgs e)
        {

        }
    }
}
