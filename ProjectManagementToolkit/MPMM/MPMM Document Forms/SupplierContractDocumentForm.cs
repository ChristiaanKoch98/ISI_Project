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
    public partial class SupplierContractDocumentForm : Form
    {
        VersionControl<SupplierContractModel> versionControl;
        SupplierContractModel newSupplierContractModel;
        SupplierContractModel currentSupplierContractModel;
        Color TABLE_HEADER_COLOR = Color.FromArgb(73, 173, 252);
        ProjectModel projectModel = new ProjectModel();
        public SupplierContractDocumentForm()
        {
            InitializeComponent();
        }

        private void SupplierContractDocumentForm_Load(object sender, EventArgs e)
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
            newSupplierContractModel.DocumentID = dgvDocumentInformation.Rows[0].Cells[1].Value.ToString();
            newSupplierContractModel.DocumentOwner = dgvDocumentInformation.Rows[1].Cells[1].Value.ToString();
            newSupplierContractModel.IssueDate = dgvDocumentInformation.Rows[2].Cells[1].Value.ToString();
            newSupplierContractModel.LastSavedDate = dgvDocumentInformation.Rows[3].Cells[1].Value.ToString();
            newSupplierContractModel.FileName = dgvDocumentInformation.Rows[4].Cells[1].Value.ToString();

            List<SupplierContractModel.DocumentHistory> documentHistories = new List<SupplierContractModel.DocumentHistory>();

            int versionRowsCount = dgvDocumentHistory.Rows.Count;
            newSupplierContractModel.DocumentHistories = new List<SupplierContractModel.DocumentHistory>();

            for (int i = 0; i < versionRowsCount - 1; i++)
            {
                var version = dgvDocumentHistory.Rows[i].Cells[0].Value?.ToString() ?? "";
                var issueDate = dgvDocumentHistory.Rows[i].Cells[1].Value?.ToString() ?? "";
                var changes = dgvDocumentHistory.Rows[i].Cells[2].Value?.ToString() ?? "";

                newSupplierContractModel.DocumentHistories
                    .Add(new SupplierContractModel.DocumentHistory(version,issueDate,changes));
            }

            int approvalRowsCount = dgvDocumentApprovals.Rows.Count;
            newSupplierContractModel.DocumentApprovals = new List<SupplierContractModel.DocumentApproval>();
            for (int i = 0; i < approvalRowsCount - 1; i++)
            {
                var role = dgvDocumentApprovals.Rows[i].Cells[0].Value?.ToString() ?? "";
                var name = dgvDocumentApprovals.Rows[i].Cells[1].Value?.ToString() ?? "";
                var signature = dgvDocumentApprovals.Rows[i].Cells[2].Value?.ToString() ?? "";
                var date = dgvDocumentApprovals.Rows[i].Cells[3].Value?.ToString() ?? "";
                newSupplierContractModel.DocumentApprovals
                    .Add(new SupplierContractModel.DocumentApproval(role,name,signature,date));
            }

            newSupplierContractModel.Purpose = purpose.Text;
            newSupplierContractModel.Recipients = recipients.Text;

            int definitionsRowsCount = dgvDefinitions.Rows.Count;
            newSupplierContractModel.Definitions = new List<SupplierContractModel.Definition>();
            for (int i = 0; i < definitionsRowsCount - 1; i++)
            {
                var term = dgvDefinitions.Rows[i].Cells[0].Value?.ToString() ?? "";
                var definition = dgvDefinitions.Rows[i].Cells[1].Value?.ToString() ?? "";

                newSupplierContractModel.Definitions
                    .Add(new SupplierContractModel.Definition(term,definition));
            }

            int procurementItemsCount = dgvProcurementItems.Rows.Count;
            newSupplierContractModel.ProcurementItems = new List<SupplierContractModel.ProcurementItem>();
            for (int i = 0; i < procurementItemsCount - 1; i++)
            {
                var itemName = dgvProcurementItems.Rows[i].Cells[0].Value?.ToString() ?? "";
                var itemDescription = dgvProcurementItems.Rows[i].Cells[1].Value?.ToString() ?? "";
                var itemQuantity = dgvProcurementItems.Rows[i].Cells[2].Value?.ToString() ?? "";
                var itemPrice = dgvProcurementItems.Rows[i].Cells[3].Value?.ToString() ?? "";

                newSupplierContractModel.ProcurementItems
                    .Add(new SupplierContractModel.ProcurementItem(itemName,itemDescription,itemQuantity,itemPrice));
            }

            newSupplierContractModel.Project = project.Text;
            newSupplierContractModel.Supplier = supplier.Text;

            int reviewCriteriaCount = dgvReviewCriteriaIntro.Rows.Count;
            newSupplierContractModel.ReviewCriterion = new List<SupplierContractModel.ReviewCriteria>();
            for (int i = 0; i < reviewCriteriaCount - 1; i++)
            { 
                var criteria = dgvReviewCriteriaIntro.Rows[i].Cells[0].Value?.ToString() ?? "";
                var description = dgvReviewCriteriaIntro.Rows[i].Cells[1].Value?.ToString() ?? "";

                newSupplierContractModel.ReviewCriterion
                    .Add(new SupplierContractModel.ReviewCriteria(criteria,description));
            }

            newSupplierContractModel.ReviewProcess = reviewProcess.Text;
            newSupplierContractModel.Payment = payment.Text;
            newSupplierContractModel.Invoicing = invoicing.Text;
            newSupplierContractModel.Confidentiality = confidentiality.Text;
            newSupplierContractModel.Termination = termination.Text;
            newSupplierContractModel.Disputes = disputes.Text;
            newSupplierContractModel.Indemnity = indemnity.Text;
            newSupplierContractModel.Law = law.Text;
            newSupplierContractModel.Agreement = agreement.Text;

            List<VersionControl<SupplierContractModel>.DocumentModel> documentModels = versionControl.DocumentModels;
            if (!versionControl.isEqual(currentSupplierContractModel, newSupplierContractModel))
            {
                VersionControl<SupplierContractModel>.DocumentModel documentModel = new VersionControl<SupplierContractModel>
                    .DocumentModel(newSupplierContractModel, DateTime.Now, VersionControl<SupplierContractModel>.generateID());
                documentModels.Add(documentModel);

                string json = JsonConvert.SerializeObject(versionControl);
                currentSupplierContractModel = JsonConvert.DeserializeObject<SupplierContractModel>(JsonConvert.SerializeObject(newSupplierContractModel));
                JsonHelper.saveDocument(json, Settings.Default.ProjectID, "SupplierContract");
                MessageBox.Show("Suplier Contract saved successfully", "save", MessageBoxButtons.OK);

            }
            else
            {
                MessageBox.Show("No changes was made!", "save", MessageBoxButtons.OK);
            }


        }

        private void loadDocument()
        {
            string json = JsonHelper.loadDocument(Settings.Default.ProjectID, "SupplierContract");
            List<string[]> documentInfo = new List<string[]>();
            newSupplierContractModel = new SupplierContractModel();
            currentSupplierContractModel = new SupplierContractModel();

            if (json != "")
            {
                versionControl = JsonConvert.DeserializeObject<VersionControl<SupplierContractModel>>(json);
                newSupplierContractModel = JsonConvert.DeserializeObject<SupplierContractModel>(versionControl.getLatest(versionControl.DocumentModels));
                currentSupplierContractModel = JsonConvert.DeserializeObject<SupplierContractModel>(versionControl.getLatest(versionControl.DocumentModels));

                documentInfo.Add(new string[] { "Document ID", currentSupplierContractModel.DocumentID });
                documentInfo.Add(new string[] { "Document Owner", currentSupplierContractModel.DocumentOwner });
                documentInfo.Add(new string[] { "Issue Date", currentSupplierContractModel.IssueDate });
                documentInfo.Add(new string[] { "Last Save Date", currentSupplierContractModel.LastSavedDate });
                documentInfo.Add(new string[] { "File Name", currentSupplierContractModel.FileName });

                foreach (var row in documentInfo)
                {
                    dgvDocumentInformation.Rows.Add(row);
                }
                dgvDocumentInformation.AllowUserToAddRows = false;

                foreach (var row in currentSupplierContractModel.DocumentHistories)
                {
                    dgvDocumentHistory.Rows.Add(new string[] { row.Version, row.IssueDate, row.Changes });
                }

                foreach (var row in currentSupplierContractModel.DocumentApprovals)
                {
                    dgvDocumentApprovals.Rows.Add(new string[] { row.Role, row.Name, "", row.DateApproved });
                }

                purpose.Text = currentSupplierContractModel.Purpose;
                recipients.Text = currentSupplierContractModel.Recipients;

                foreach (var row in currentSupplierContractModel.Definitions)
                {
                    dgvDefinitions.Rows.Add(new string[] { row.Term, row.definition });
                }

                foreach (var row in currentSupplierContractModel.ProcurementItems) 
                {
                    dgvProcurementItems.Rows.Add(new string[] { row.ItemName, row.ItemDescription, row.ItemQuantity, row.ItemPrice });
                }

                supplier.Text = newSupplierContractModel.Supplier;
                project.Text = newSupplierContractModel.Project;

                foreach (var row in currentSupplierContractModel.ReviewCriterion)
                {
                    dgvReviewCriteriaIntro.Rows.Add(new string[] { row.Criteria, row.Description});
                }

                reviewProcess.Text = currentSupplierContractModel.ReviewProcess;

                payment.Text = currentSupplierContractModel.Payment;
                termination.Text = currentSupplierContractModel.Termination;
                law.Text = currentSupplierContractModel.Law;
                invoicing.Text = currentSupplierContractModel.Invoicing;
                disputes.Text = currentSupplierContractModel.Disputes;
                agreement.Text = currentSupplierContractModel.Agreement;
                confidentiality.Text = currentSupplierContractModel.Confidentiality;
                indemnity.Text = currentSupplierContractModel.Indemnity;

            }
            else
            {
                versionControl = new VersionControl<SupplierContractModel>();
                versionControl.DocumentModels = new List<VersionControl<SupplierContractModel>.DocumentModel>();
                documentInfo.Add(new string[] { "Document ID", "" });
                documentInfo.Add(new string[] { "Document Owner", "" });
                documentInfo.Add(new string[] { "Issue Date", "" });
                documentInfo.Add(new string[] { "Last Save Date", "" });
                documentInfo.Add(new string[] { "File Name", "" });
                foreach (var row in documentInfo)
                {
                    dgvDocumentInformation.Rows.Add(row);
                }
                dgvDocumentInformation.AllowUserToAddRows = false;
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
                        document.InsertParagraph("Supplier Contract \nFor " + projectModel.ProjectName)
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
                        documentInfoTable.Rows[0].Cells[0].Paragraphs[0].Append("Type").Bold(true).Color(Color.White);
                        documentInfoTable.Rows[0].Cells[1].Paragraphs[0].Append("Information").Bold(true).Color(Color.White);
                        documentInfoTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        documentInfoTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;

                        documentInfoTable.Rows[1].Cells[0].Paragraphs[0].Append("Document ID");
                        documentInfoTable.Rows[1].Cells[1].Paragraphs[0].Append(currentSupplierContractModel.DocumentID);

                        documentInfoTable.Rows[2].Cells[0].Paragraphs[0].Append("Document Owner");
                        documentInfoTable.Rows[2].Cells[1].Paragraphs[0].Append(currentSupplierContractModel.DocumentOwner);

                        documentInfoTable.Rows[3].Cells[0].Paragraphs[0].Append("Issue Date");
                        documentInfoTable.Rows[3].Cells[1].Paragraphs[0].Append(currentSupplierContractModel.IssueDate);

                        documentInfoTable.Rows[4].Cells[0].Paragraphs[0].Append("Last Saved Date");
                        documentInfoTable.Rows[4].Cells[1].Paragraphs[0].Append(currentSupplierContractModel.LastSavedDate);

                        documentInfoTable.Rows[5].Cells[0].Paragraphs[0].Append("File Name");
                        documentInfoTable.Rows[5].Cells[1].Paragraphs[0].Append(currentSupplierContractModel.FileName);
                        documentInfoTable.SetWidths(new float[] { 493, 1094 });
                        document.InsertTable(documentInfoTable);

                        document.InsertParagraph("\nDocument History\n")
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(14d).Alignment = Alignment.left;

                        var documentHistoryTable = document.AddTable(currentSupplierContractModel.DocumentHistories.Count + 1, 3);
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
                        for (int i = 1; i < currentSupplierContractModel.DocumentHistories.Count + 1; i++)
                        {
                            documentHistoryTable.Rows[i].Cells[0].Paragraphs[0].Append(currentSupplierContractModel.DocumentHistories[i - 1].Version);
                            documentHistoryTable.Rows[i].Cells[1].Paragraphs[0].Append(currentSupplierContractModel.DocumentHistories[i - 1].IssueDate);
                            documentHistoryTable.Rows[i].Cells[2].Paragraphs[0].Append(currentSupplierContractModel.DocumentHistories[i - 1].Changes);

                        }

                        documentHistoryTable.SetWidths(new float[] { 190, 303, 1094 });
                        document.InsertTable(documentHistoryTable);

                        document.InsertParagraph("\nDocument Approvals\n")
                           .Font("Arial")
                           .Bold(true)
                           .FontSize(14d).Alignment = Alignment.left;

                        var documentApprovalTable = document.AddTable(currentSupplierContractModel.DocumentApprovals.Count + 1, 4);
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

                        for (int i = 1; i < currentSupplierContractModel.DocumentApprovals.Count + 1; i++)
                        {
                            documentApprovalTable.Rows[i].Cells[0].Paragraphs[0].Append(currentSupplierContractModel.DocumentApprovals[i - 1].Role);
                            documentApprovalTable.Rows[i].Cells[1].Paragraphs[0].Append(currentSupplierContractModel.DocumentApprovals[i - 1].Name);
                            documentApprovalTable.Rows[i].Cells[2].Paragraphs[0].Append(currentSupplierContractModel.DocumentApprovals[i - 1].Signature);
                            documentApprovalTable.Rows[i].Cells[3].Paragraphs[0].Append(currentSupplierContractModel.DocumentApprovals[i - 1].DateApproved);
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

                        var Introduction = document.InsertParagraph("1\tIntroduction")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");
                        Introduction.StyleId = "Heading1";

                        var Purpose = document.InsertParagraph("1.1\tPurpose")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        document.InsertParagraph(currentSupplierContractModel.Purpose)
                           .FontSize(11d)
                           .Color(Color.Black)
                           .Font("Arial").Alignment = Alignment.left;

                        Purpose.StyleId = "Heading2";



                        var Recipients = document.InsertParagraph("1.2\tRecipients")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        Recipients.StyleId = "Heading2";

                        document.InsertParagraph(currentSupplierContractModel.Recipients)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        var Definitions = document.InsertParagraph("1.3\tDefinitions")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        Definitions.StyleId = "Heading2";

                        var definitionsTable = document.AddTable(currentSupplierContractModel.Definitions.Count + 1, 2);
                        definitionsTable.Rows[0].Cells[0].Paragraphs[0].Append("Term")
                           .Bold(true)
                           .Color(Color.White);
                        definitionsTable.Rows[0].Cells[1].Paragraphs[0].Append("Definition")
                            .Bold(true)
                            .Color(Color.White);

                        definitionsTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        definitionsTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < currentSupplierContractModel.Definitions.Count + 1; i++)
                        {
                            definitionsTable.Rows[i].Cells[0].Paragraphs[0].Append(currentSupplierContractModel.Definitions[i - 1].Term);
                            definitionsTable.Rows[i].Cells[1].Paragraphs[0].Append(currentSupplierContractModel.Definitions[i - 1].definition);
                        }

                        definitionsTable.SetWidths(new float[] { 232, 1398 });
                        document.InsertTable(definitionsTable);


                        var ScopeOfWork = document.InsertParagraph("2\tScope of Work")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");
                        ScopeOfWork.StyleId = "Heading1";

                        var procurementItemsDocument = document.InsertParagraph("2.1\tProcurement Items")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        procurementItemsDocument.StyleId = "Heading2";

                        var procurementItemsTable = document.AddTable(currentSupplierContractModel.ProcurementItems.Count + 1, 4);
                        procurementItemsTable.Rows[0].Cells[0].Paragraphs[0].Append("Item Name")
                            .Bold(true)
                            .Color(Color.White);
                        procurementItemsTable.Rows[0].Cells[1].Paragraphs[0].Append("Item Description")
                            .Bold(true)
                            .Color(Color.White);
                        procurementItemsTable.Rows[0].Cells[2].Paragraphs[0].Append("Item Quantity")
                            .Bold(true)
                            .Color(Color.White);
                        procurementItemsTable.Rows[0].Cells[3].Paragraphs[0].Append("Item Price")
                            .Bold(true)
                            .Color(Color.White);


                        procurementItemsTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        procurementItemsTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        procurementItemsTable.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;
                        procurementItemsTable.Rows[0].Cells[3].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < currentSupplierContractModel.ProcurementItems.Count + 1; i++)
                        {
                            procurementItemsTable.Rows[i].Cells[0].Paragraphs[0].Append(currentSupplierContractModel.ProcurementItems[i - 1].ItemName);
                            procurementItemsTable.Rows[i].Cells[1].Paragraphs[0].Append(currentSupplierContractModel.ProcurementItems[i - 1].ItemDescription);
                            procurementItemsTable.Rows[i].Cells[2].Paragraphs[0].Append(currentSupplierContractModel.ProcurementItems[i - 1].ItemQuantity);
                            procurementItemsTable.Rows[i].Cells[3].Paragraphs[0].Append(currentSupplierContractModel.ProcurementItems[i - 1].ItemPrice);
                        }

                        procurementItemsTable.SetWidths(new float[] { 330, 686, 309, 288 });
                        document.InsertTable(procurementItemsTable);

                        var DeliverySchedule = document.InsertParagraph("2.2\tDelivery Schedule")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        DeliverySchedule.StyleId = "Heading2";

                        var Responsibilities = document.InsertParagraph("3\tResponsibilities")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");
                        Responsibilities.StyleId = "Heading1";

                        var Supplier = document.InsertParagraph("3.1\tSupplier")
                          .Bold()
                          .FontSize(12d)
                          .Color(Color.Black)
                          .Bold(true)
                          .Font("Arial");

                        Supplier.StyleId = "Heading2";

                        document.InsertParagraph(currentSupplierContractModel.Supplier)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;


                        var Project = document.InsertParagraph("3.2\tProject")
                          .Bold()
                          .FontSize(12d)
                          .Color(Color.Black)
                          .Bold(true)
                          .Font("Arial");

                        Project.StyleId = "Heading2";

                        document.InsertParagraph(currentSupplierContractModel.Project)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        var Performance = document.InsertParagraph("4\tPerformance")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");
                        Performance.StyleId = "Heading1";

                        var ReviewCriteria = document.InsertParagraph("4.1\tReview Criteria")
                          .Bold()
                          .FontSize(12d)
                          .Color(Color.Black)
                          .Bold(true)
                          .Font("Arial");

                        ReviewCriteria.StyleId = "Heading2";

                        var reviewCriterionTable = document.AddTable(currentSupplierContractModel.ReviewCriterion.Count + 1, 2);

                        reviewCriterionTable.Rows[0].Cells[0].Paragraphs[0].Append("Criteria")
                            .Bold(true)
                            .Color(Color.White);
                        reviewCriterionTable.Rows[0].Cells[1].Paragraphs[0].Append("Description")
                            .Bold(true)
                            .Color(Color.White);

                        reviewCriterionTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        reviewCriterionTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < currentSupplierContractModel.ReviewCriterion.Count + 1; i++)
                        {
                            reviewCriterionTable.Rows[i].Cells[0].Paragraphs[0].Append(currentSupplierContractModel.ReviewCriterion[i - 1].Criteria);
                            reviewCriterionTable.Rows[i].Cells[1].Paragraphs[0].Append(currentSupplierContractModel.ReviewCriterion[i - 1].Description);
                        }

                        reviewCriterionTable.SetWidths(new float[] { 321, 1334 });
                        document.InsertTable(reviewCriterionTable);

                        var ReviewProcess = document.InsertParagraph("4.2\tReview Process")
                          .Bold()
                          .FontSize(12d)
                          .Color(Color.Black)
                          .Bold(true)
                          .Font("Arial");

                        ReviewProcess.StyleId = "Heading2";

                        document.InsertParagraph(currentSupplierContractModel.ReviewProcess)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;


                        var TermsandConditions = document.InsertParagraph("5\tTerms and Conditions")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");
                        TermsandConditions.StyleId = "Heading1";

                        var Payment = document.InsertParagraph("5.1\tPayment")
                          .Bold()
                          .FontSize(12d)
                          .Color(Color.Black)
                          .Bold(true)
                          .Font("Arial");

                        Payment.StyleId = "Heading2";

                        document.InsertParagraph(currentSupplierContractModel.Payment)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        var Invoicing = document.InsertParagraph("5.2\tInvoicing")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        Invoicing.StyleId = "Heading2";

                        document.InsertParagraph(currentSupplierContractModel.Invoicing)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        var Confidentiality = document.InsertParagraph("5.3\tConfidentiality")
                             .Bold()
                             .FontSize(12d)
                             .Color(Color.Black)
                             .Bold(true)
                             .Font("Arial");
                        Confidentiality.StyleId = "Heading2";

                        document.InsertParagraph(currentSupplierContractModel.Confidentiality)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        var Termination = document.InsertParagraph("5.4\tTermination")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");
                        Termination.StyleId = "Heading2";

                        document.InsertParagraph(currentSupplierContractModel.Termination)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        var Disputes = document.InsertParagraph("5.5\tDisputes")
                           .Bold()
                           .FontSize(12d)
                           .Color(Color.Black)
                           .Bold(true)
                           .Font("Arial");
                        Disputes.StyleId = "Heading2";

                        document.InsertParagraph(currentSupplierContractModel.Disputes)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        var Indemnity = document.InsertParagraph("5.6\tIndemnity")
                          .Bold()
                          .FontSize(12d)
                          .Color(Color.Black)
                          .Bold(true)
                          .Font("Arial");
                        Indemnity.StyleId = "Heading2";

                        document.InsertParagraph(currentSupplierContractModel.Indemnity)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        var Law = document.InsertParagraph("5.7\tLaw")
                          .Bold()
                          .FontSize(12d)
                          .Color(Color.Black)
                          .Bold(true)
                          .Font("Arial");
                        Law.StyleId = "Heading2";

                        document.InsertParagraph(currentSupplierContractModel.Law)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        var Agreement = document.InsertParagraph("5.8\tAgreement")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");
                        Agreement.StyleId = "Heading2";

                        document.InsertParagraph(currentSupplierContractModel.Agreement)
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
