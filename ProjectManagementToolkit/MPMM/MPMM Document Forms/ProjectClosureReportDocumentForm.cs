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
    public partial class ProjectClosureReportDocumentForm : Form
    {
        VersionControl<ProjectClosureReportModel> versionControl;
        ProjectClosureReportModel newProjectClosureReportModel;
        ProjectClosureReportModel currentProjectClosureReportModel;
        Color TABLE_HEADER_COLOR = Color.FromArgb(73, 173, 252);
        ProjectModel projectModel = new ProjectModel();
        public ProjectClosureReportDocumentForm()
        {
            InitializeComponent();
        }

        private void ProjectClosureReportDocumentForm_Load(object sender, EventArgs e)
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

        private void saveDocument()
        {
            newProjectClosureReportModel.DocumentID = dataGridViewDocumentInformation.Rows[0].Cells[1].Value.ToString();
            newProjectClosureReportModel.DocumentOwner = dataGridViewDocumentInformation.Rows[1].Cells[1].Value.ToString();
            newProjectClosureReportModel.IssueDate = dataGridViewDocumentInformation.Rows[2].Cells[1].Value.ToString();
            newProjectClosureReportModel.LastSavedDate = dataGridViewDocumentInformation.Rows[3].Cells[1].Value.ToString();
            newProjectClosureReportModel.FileName = dataGridViewDocumentInformation.Rows[4].Cells[1].Value.ToString();

            int versionRowsCount = dataGridViewDocumentHistory.Rows.Count;
            newProjectClosureReportModel.DocumentHistories = new List<ProjectClosureReportModel.DocumentHistory>();
            for (int i = 0; i < versionRowsCount - 1; i++)
            {
                var version = dataGridViewDocumentHistory.Rows[i].Cells[0].Value?.ToString() ?? "";
                var issueDate = dataGridViewDocumentHistory.Rows[i].Cells[1].Value?.ToString() ?? "";
                var changes = dataGridViewDocumentHistory.Rows[i].Cells[2].Value?.ToString() ?? "";

                newProjectClosureReportModel.DocumentHistories
                    .Add(new ProjectClosureReportModel.DocumentHistory(version, issueDate, changes));
            }

            int approvalRowsCount = dataGridViewDocumentApprovals.Rows.Count;
            newProjectClosureReportModel.DocumentApprovals = new List<ProjectClosureReportModel.DocumentApproval>();
            for (int i = 0; i < approvalRowsCount - 1; i++)
            {
                var role = dataGridViewDocumentApprovals.Rows[i].Cells[0].Value?.ToString() ?? "";
                var name = dataGridViewDocumentApprovals.Rows[i].Cells[1].Value?.ToString() ?? "";
                var signature = dataGridViewDocumentApprovals.Rows[i].Cells[2].Value?.ToString() ?? "";
                var date = dataGridViewDocumentApprovals.Rows[i].Cells[3].Value?.ToString() ?? "";
                newProjectClosureReportModel.DocumentApprovals
                    .Add(new ProjectClosureReportModel.DocumentApproval(role, name, signature, date));
            }

            newProjectClosureReportModel.ProjectCompletionDescription = txtProjectCompletion.Text;


            int completionCritCount = dataGridViewCompletionCriteria.Rows.Count;
            newProjectClosureReportModel.CompletionCriterion = new List<ProjectClosureReportModel.CompletionCriteria>();
            for (int i = 0; i < completionCritCount - 1; i++)
            {
                var category = dataGridViewCompletionCriteria.Rows[i].Cells[0].Value?.ToString() ?? "";
                var criteria = dataGridViewCompletionCriteria.Rows[i].Cells[1].Value?.ToString() ?? "";
                var satisfied = dataGridViewCompletionCriteria.Rows[i].Cells[2].Value?.ToString() ?? "";

                newProjectClosureReportModel.CompletionCriterion
                    .Add(new ProjectClosureReportModel.CompletionCriteria(category,criteria,satisfied));
            }

            int outstandingItemsCount = dataGridViewOutstandingItems.Rows.Count;
            newProjectClosureReportModel.OutstandingItems = new List<ProjectClosureReportModel.OutstandingItem>();
            for (int i = 0; i < outstandingItemsCount - 1; i++)
            {
                var item = dataGridViewOutstandingItems.Rows[i].Cells[0].Value?.ToString() ?? "";
                var action = dataGridViewOutstandingItems.Rows[i].Cells[1].Value?.ToString() ?? "";
                var date = dataGridViewOutstandingItems.Rows[i].Cells[2].Value?.ToString() ?? "";

                newProjectClosureReportModel.OutstandingItems
                    .Add(new ProjectClosureReportModel.OutstandingItem(item,action,date));
            }

            newProjectClosureReportModel.ProjectClosureDescription = txtProjectClosure.Text;

            int deliverablesCount = dataGridViewDeliverables.Rows.Count;
            newProjectClosureReportModel.Deliverables = new List<ProjectClosureReportModel.Deliverable>();
            for (int i = 0; i < deliverablesCount - 1; i++)
            {
                var deliverable = dataGridViewDeliverables.Rows[i].Cells[0].Value?.ToString() ?? "";
                var action = dataGridViewDeliverables.Rows[i].Cells[1].Value?.ToString() ?? "";
                var date = dataGridViewDeliverables.Rows[i].Cells[2].Value?.ToString() ?? "";

                newProjectClosureReportModel.Deliverables
                    .Add(new ProjectClosureReportModel.Deliverable(deliverable,action,date));
            }

            int documentationCount = dataGridViewDocumentation.Rows.Count;
            newProjectClosureReportModel.Documentations = new List<ProjectClosureReportModel.Documentation>();
            for (int i = 0; i < documentationCount - 1; i++)
            {
                var documemt = dataGridViewDocumentation.Rows[i].Cells[0].Value?.ToString() ?? "";
                var action = dataGridViewDocumentation.Rows[i].Cells[1].Value?.ToString() ?? "";
                var date = dataGridViewDocumentation.Rows[i].Cells[2].Value?.ToString() ?? "";

                newProjectClosureReportModel.Documentations
                    .Add(new ProjectClosureReportModel.Documentation(documemt, action, date));
            }

            int supplierCount = dataGridViewSippliers.Rows.Count;
            newProjectClosureReportModel.Suppliers = new List<ProjectClosureReportModel.Supplier>();
            for (int i = 0; i < supplierCount - 1; i++)
            {
                var contract = dataGridViewSippliers.Rows[i].Cells[0].Value?.ToString() ?? "";
                var action = dataGridViewSippliers.Rows[i].Cells[1].Value?.ToString() ?? "";
                var date = dataGridViewSippliers.Rows[i].Cells[2].Value?.ToString() ?? "";

                newProjectClosureReportModel.Suppliers
                    .Add(new ProjectClosureReportModel.Supplier(contract, action, date));
            }

            int resourceCount = dataGridViewResources.Rows.Count;
            newProjectClosureReportModel.Resources = new List<ProjectClosureReportModel.Resource>();
            for (int i = 0; i < resourceCount - 1; i++)
            {
                var resource = dataGridViewResources.Rows[i].Cells[0].Value?.ToString() ?? "";
                var action = dataGridViewResources.Rows[i].Cells[1].Value?.ToString() ?? "";
                var date = dataGridViewResources.Rows[i].Cells[2].Value?.ToString() ?? "";

                newProjectClosureReportModel.Resources
                    .Add(new ProjectClosureReportModel.Resource(resource, action, date));
            }

            int commiCount = dataGridViewCommunications.Rows.Count;
            newProjectClosureReportModel.Communications = new List<ProjectClosureReportModel.Communication>();
            for (int i = 0; i < commiCount - 1; i++)
            {
                var communication = dataGridViewCommunications.Rows[i].Cells[0].Value?.ToString() ?? "";
                var action = dataGridViewCommunications.Rows[i].Cells[1].Value?.ToString() ?? "";
                var method = dataGridViewCommunications.Rows[i].Cells[2].Value?.ToString() ?? "";
                var date = dataGridViewCommunications.Rows[i].Cells[3].Value?.ToString() ?? "";

                newProjectClosureReportModel.Communications
                    .Add(new ProjectClosureReportModel.Communication(communication, action,method, date));
            }

            newProjectClosureReportModel.ApprovalRole = "...";
            newProjectClosureReportModel.ApprovalName = txtName.Text;
            newProjectClosureReportModel.ApprovalDate = txtDate.Text;
            newProjectClosureReportModel.ApprovalRole = txtSignature.Text;

            List<VersionControl<ProjectClosureReportModel>.DocumentModel> documentModels = versionControl.DocumentModels;
            if (!versionControl.isEqual(currentProjectClosureReportModel, newProjectClosureReportModel))
            {
                VersionControl<ProjectClosureReportModel>.DocumentModel documentModel = new VersionControl<ProjectClosureReportModel>
                    .DocumentModel(newProjectClosureReportModel, DateTime.Now, VersionControl<ProjectClosureReportModel>.generateID());
                documentModels.Add(documentModel);

                string json = JsonConvert.SerializeObject(versionControl);
                currentProjectClosureReportModel = JsonConvert.DeserializeObject<ProjectClosureReportModel>(JsonConvert.SerializeObject(newProjectClosureReportModel));
                JsonHelper.saveDocument(json, Settings.Default.ProjectID, "ProjectClosureReport");
                MessageBox.Show("Project Closure Form saved successfully", "save", MessageBoxButtons.OK);

            }
            else
            {
                MessageBox.Show("No changes was made!", "save", MessageBoxButtons.OK);
            }


        }
        private void loadDocument()
        {
            string json = JsonHelper.loadDocument(Settings.Default.ProjectID, "ProjectClosureReport");
            List<string[]> documentInfo = new List<string[]>();
            newProjectClosureReportModel = new ProjectClosureReportModel();
            currentProjectClosureReportModel = new ProjectClosureReportModel();

            if (json != "")
            {
                versionControl = JsonConvert.DeserializeObject<VersionControl<ProjectClosureReportModel>>(json);
                newProjectClosureReportModel = JsonConvert.DeserializeObject<ProjectClosureReportModel>(versionControl.getLatest(versionControl.DocumentModels));
                currentProjectClosureReportModel = JsonConvert.DeserializeObject<ProjectClosureReportModel>(versionControl.getLatest(versionControl.DocumentModels));

                documentInfo.Add(new string[] { "Document ID", currentProjectClosureReportModel.DocumentID });
                documentInfo.Add(new string[] { "Document Owner", currentProjectClosureReportModel.DocumentOwner });
                documentInfo.Add(new string[] { "Issue Date", currentProjectClosureReportModel.IssueDate });
                documentInfo.Add(new string[] { "Last Save Date", currentProjectClosureReportModel.LastSavedDate });
                documentInfo.Add(new string[] { "File Name", currentProjectClosureReportModel.FileName });

                foreach (var row in documentInfo)
                {
                    dataGridViewDocumentInformation.Rows.Add(row);
                }
                dataGridViewDocumentInformation.AllowUserToAddRows = false;

                foreach (var row in currentProjectClosureReportModel.DocumentHistories)
                {
                    dataGridViewDocumentHistory.Rows.Add(new string[] { row.Version, row.IssueDate, row.Changes });
                }

                foreach (var row in currentProjectClosureReportModel.DocumentApprovals)
                {
                    dataGridViewDocumentApprovals.Rows.Add(new string[] { row.Role, row.Name, row.Signature,row.DateApproved });
                }

                txtProjectCompletion.Text = currentProjectClosureReportModel.ProjectCompletionDescription;

                foreach(var row in currentProjectClosureReportModel.CompletionCriterion)
                {
                    dataGridViewCompletionCriteria.Rows.Add(new string[] { row.CompletionCategory, row.completionCriteria, row.Satisfied});
                }

                foreach (var row in currentProjectClosureReportModel.OutstandingItems)
                {
                    dataGridViewOutstandingItems.Rows.Add(new string[] { row.outstandingItem, row.ActionRequired, row.CompletionDate });
                }

                txtProjectClosure.Text = newProjectClosureReportModel.ProjectClosureDescription;

                foreach (var row in currentProjectClosureReportModel.Deliverables)
                {
                    dataGridViewDeliverables.Rows.Add(new string[] { row.ProjectDeliverable, row.ActionRequired, row.CompletionDate });
                }

                foreach (var row in currentProjectClosureReportModel.Documentations)
                {
                    dataGridViewDocumentation.Rows.Add(new string[] { row.ProjectDocument, row.ActionRequired, row.CompletionDate });
                }

                foreach (var row in currentProjectClosureReportModel.Suppliers)
                {
                    dataGridViewSippliers.Rows.Add(new string[] { row.SupplierContract, row.ActionRequired, row.CompletionDate });
                }

                foreach (var row in currentProjectClosureReportModel.Resources)
                {
                    dataGridViewResources.Rows.Add(new string[] { row.ProjectResource, row.ActionRequired, row.CompletionDate });
                }

                foreach (var row in currentProjectClosureReportModel.Communications)
                {
                    dataGridViewCommunications.Rows.Add(new string[] { row.Audience, row.Message, row.Method,row.CommunicationDate });
                }

                txtName.Text = newProjectClosureReportModel.ApprovalName;
                txtDate.Text = newProjectClosureReportModel.ApprovalDate;
                txtSignature.Text = newProjectClosureReportModel.ApprovalSignature; 


            }
            else
            {
                versionControl = new VersionControl<ProjectClosureReportModel>();
                versionControl.DocumentModels = new List<VersionControl<ProjectClosureReportModel>.DocumentModel>();
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
                        document.InsertParagraph("Project Closure Report\nFor " + projectModel.ProjectName)
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
                        documentInfoTable.Rows[1].Cells[1].Paragraphs[0].Append(currentProjectClosureReportModel.DocumentID);

                        documentInfoTable.Rows[2].Cells[0].Paragraphs[0].Append("Document Owner");
                        documentInfoTable.Rows[2].Cells[1].Paragraphs[0].Append(currentProjectClosureReportModel.DocumentOwner);

                        documentInfoTable.Rows[3].Cells[0].Paragraphs[0].Append("Issue Date");
                        documentInfoTable.Rows[3].Cells[1].Paragraphs[0].Append(currentProjectClosureReportModel.IssueDate);

                        documentInfoTable.Rows[4].Cells[0].Paragraphs[0].Append("Last Saved Date");
                        documentInfoTable.Rows[4].Cells[1].Paragraphs[0].Append(currentProjectClosureReportModel.LastSavedDate);

                        documentInfoTable.Rows[5].Cells[0].Paragraphs[0].Append("File Name");
                        documentInfoTable.Rows[5].Cells[1].Paragraphs[0].Append(currentProjectClosureReportModel.FileName);
                        documentInfoTable.SetWidths(new float[] { 493, 1094 });
                        document.InsertTable(documentInfoTable);

                        document.InsertParagraph("\nDocument History\n")
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(14d).Alignment = Alignment.left;

                        var documentHistoryTable = document.AddTable(currentProjectClosureReportModel.DocumentHistories.Count + 1, 3);
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
                        for (int i = 1; i < currentProjectClosureReportModel.DocumentHistories.Count + 1; i++)
                        {
                            documentHistoryTable.Rows[i].Cells[0].Paragraphs[0].Append(currentProjectClosureReportModel.DocumentHistories[i - 1].Version);
                            documentHistoryTable.Rows[i].Cells[1].Paragraphs[0].Append(currentProjectClosureReportModel.DocumentHistories[i - 1].IssueDate);
                            documentHistoryTable.Rows[i].Cells[2].Paragraphs[0].Append(currentProjectClosureReportModel.DocumentHistories[i - 1].Changes);

                        }

                        documentHistoryTable.SetWidths(new float[] { 190, 303, 1094 });
                        document.InsertTable(documentHistoryTable);

                        document.InsertParagraph("\nDocument Approvals\n")
                           .Font("Arial")
                           .Bold(true)
                           .FontSize(14d).Alignment = Alignment.left;

                        var documentApprovalTable = document.AddTable(currentProjectClosureReportModel.DocumentApprovals.Count + 1, 4);
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

                        for (int i = 1; i < currentProjectClosureReportModel.DocumentApprovals.Count + 1; i++)
                        {
                            documentApprovalTable.Rows[i].Cells[0].Paragraphs[0].Append(currentProjectClosureReportModel.DocumentApprovals[i - 1].Role);
                            documentApprovalTable.Rows[i].Cells[1].Paragraphs[0].Append(currentProjectClosureReportModel.DocumentApprovals[i - 1].Name);
                            documentApprovalTable.Rows[i].Cells[2].Paragraphs[0].Append(currentProjectClosureReportModel.DocumentApprovals[i - 1].Signature);
                            documentApprovalTable.Rows[i].Cells[3].Paragraphs[0].Append(currentProjectClosureReportModel.DocumentApprovals[i - 1].DateApproved);
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

                        var Introduction = document.InsertParagraph("1\tProject Completion")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");
                        Introduction.StyleId = "Heading1";

                        document.InsertParagraph(currentProjectClosureReportModel.ProjectCompletionDescription)
                           .FontSize(11d)
                           .Color(Color.Black)
                           .Font("Arial").Alignment = Alignment.left;

                        var CompletionCriteria = document.InsertParagraph("1.1\tCompletion Criteria")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");
                        CompletionCriteria.StyleId = "Heading2";

                        var completionCriteriaTable = document.AddTable(currentProjectClosureReportModel.CompletionCriterion.Count + 1, 3);
                        completionCriteriaTable.Rows[0].Cells[0].Paragraphs[0].Append("Completion Category")
                           .Bold(true)
                           .Color(Color.White);
                        completionCriteriaTable.Rows[0].Cells[1].Paragraphs[0].Append("Completion Criteria")
                            .Bold(true)
                            .Color(Color.White);
                        completionCriteriaTable.Rows[0].Cells[2].Paragraphs[0].Append("Satisfied?")
                           .Bold(true)
                           .Color(Color.White);

                        completionCriteriaTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        completionCriteriaTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        completionCriteriaTable.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < currentProjectClosureReportModel.CompletionCriterion.Count + 1; i++)
                        {
                            completionCriteriaTable.Rows[i].Cells[0].Paragraphs[0].Append(currentProjectClosureReportModel.CompletionCriterion[i - 1].CompletionCategory);
                            completionCriteriaTable.Rows[i].Cells[1].Paragraphs[0].Append(currentProjectClosureReportModel.CompletionCriterion[i - 1].completionCriteria);
                            completionCriteriaTable.Rows[i].Cells[2].Paragraphs[0].Append(currentProjectClosureReportModel.CompletionCriterion[i - 1].Satisfied);
                        }

                        completionCriteriaTable.SetWidths(new float[] { 449, 783, 356});
                        document.InsertTable(completionCriteriaTable);

                        var outstandingItems = document.InsertParagraph("1.2\tOutstanding Items")
                           .Bold()
                           .FontSize(12d)
                           .Color(Color.Black)
                           .Bold(true)
                           .Font("Arial");
                        outstandingItems.StyleId = "Heading2";

                        var outstandingItemsTable = document.AddTable(currentProjectClosureReportModel.OutstandingItems.Count + 1, 3);
                        outstandingItemsTable.Rows[0].Cells[0].Paragraphs[0].Append("Completion Category")
                           .Bold(true)
                           .Color(Color.White);
                        outstandingItemsTable.Rows[0].Cells[1].Paragraphs[0].Append("Completion Criteria")
                            .Bold(true)
                            .Color(Color.White);
                        outstandingItemsTable.Rows[0].Cells[2].Paragraphs[0].Append("Satisfied?")
                           .Bold(true)
                           .Color(Color.White);

                        outstandingItemsTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        outstandingItemsTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        outstandingItemsTable.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < currentProjectClosureReportModel.OutstandingItems.Count + 1; i++)
                        {
                            outstandingItemsTable.Rows[i].Cells[0].Paragraphs[0].Append(currentProjectClosureReportModel.OutstandingItems[i - 1].outstandingItem);
                            outstandingItemsTable.Rows[i].Cells[1].Paragraphs[0].Append(currentProjectClosureReportModel.OutstandingItems[i - 1].ActionRequired);
                            outstandingItemsTable.Rows[i].Cells[2].Paragraphs[0].Append(currentProjectClosureReportModel.OutstandingItems[i - 1].CompletionDate);
                        }

                        outstandingItemsTable.SetWidths(new float[] { 449, 783, 356 });
                        document.InsertTable(outstandingItemsTable);



                        var ProjectClosue = document.InsertParagraph("2\tProject Closure")
                           .Bold()
                           .FontSize(14d)
                           .Color(Color.Black)
                           .Bold(true)
                           .Font("Arial");
                        ProjectClosue.StyleId = "Heading1";

                        document.InsertParagraph(currentProjectClosureReportModel.ProjectClosureDescription)
                           .FontSize(11d)
                           .Color(Color.Black)
                           .Font("Arial").Alignment = Alignment.left;

                        var Deliverables = document.InsertParagraph("2.1\tDeliverables")
                           .Bold()
                           .FontSize(12d)
                           .Color(Color.Black)
                           .Bold(true)
                           .Font("Arial");
                        Deliverables.StyleId = "Heading2";

                        var deliverablesTable = document.AddTable(currentProjectClosureReportModel.Deliverables.Count + 1, 3);

                        deliverablesTable.Rows[0].Cells[0].Paragraphs[0].Append("Project Deliverable")
                           .Bold(true)
                           .Color(Color.White);
                        deliverablesTable.Rows[0].Cells[1].Paragraphs[0].Append("Action Required")
                            .Bold(true)
                            .Color(Color.White);
                        deliverablesTable.Rows[0].Cells[2].Paragraphs[0].Append("Completion Date")
                           .Bold(true)
                           .Color(Color.White);

                        deliverablesTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        deliverablesTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        deliverablesTable.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < currentProjectClosureReportModel.Deliverables.Count + 1; i++)
                        {
                            deliverablesTable.Rows[i].Cells[0].Paragraphs[0].Append(currentProjectClosureReportModel.Deliverables[i - 1].ProjectDeliverable);
                            deliverablesTable.Rows[i].Cells[1].Paragraphs[0].Append(currentProjectClosureReportModel.Deliverables[i - 1].ActionRequired);
                            deliverablesTable.Rows[i].Cells[2].Paragraphs[0].Append(currentProjectClosureReportModel.Deliverables[i - 1].CompletionDate);
                        }

                        deliverablesTable.SetWidths(new float[] { 449, 783, 356 });
                        document.InsertTable(deliverablesTable);

                        var Documentation = document.InsertParagraph("2.2\tDocumentation")
                          .Bold()
                          .FontSize(12d)
                          .Color(Color.Black)
                          .Bold(true)
                          .Font("Arial");
                        Documentation.StyleId = "Heading2";

                        var DocumentationTable = document.AddTable(currentProjectClosureReportModel.Documentations.Count + 1, 3);

                        DocumentationTable.Rows[0].Cells[0].Paragraphs[0].Append("Project Document")
                           .Bold(true)
                           .Color(Color.White);
                        DocumentationTable.Rows[0].Cells[1].Paragraphs[0].Append("Action Required")
                            .Bold(true)
                            .Color(Color.White);
                        DocumentationTable.Rows[0].Cells[2].Paragraphs[0].Append("Completion Date")
                           .Bold(true)
                           .Color(Color.White);

                        DocumentationTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        DocumentationTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        DocumentationTable.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < currentProjectClosureReportModel.Documentations.Count + 1; i++)
                        {
                            DocumentationTable.Rows[i].Cells[0].Paragraphs[0].Append(currentProjectClosureReportModel.Documentations[i - 1].ProjectDocument);
                            DocumentationTable.Rows[i].Cells[1].Paragraphs[0].Append(currentProjectClosureReportModel.Documentations[i - 1].ActionRequired);
                            DocumentationTable.Rows[i].Cells[2].Paragraphs[0].Append(currentProjectClosureReportModel.Documentations[i - 1].CompletionDate);
                        }
                        DocumentationTable.SetWidths(new float[] { 449, 783, 356 });
                        document.InsertTable(DocumentationTable);

                        var Suppliers = document.InsertParagraph("2.3\tSuppliers")
                       .Bold()
                       .FontSize(12d)
                       .Color(Color.Black)
                       .Bold(true)
                       .Font("Arial");
                        Suppliers.StyleId = "Heading2";

                        var SuppliersTable = document.AddTable(currentProjectClosureReportModel.Suppliers.Count + 1, 3);

                        SuppliersTable.Rows[0].Cells[0].Paragraphs[0].Append("Supplier Contract")
                           .Bold(true)
                           .Color(Color.White);
                        SuppliersTable.Rows[0].Cells[1].Paragraphs[0].Append("Action Required")
                            .Bold(true)
                            .Color(Color.White);
                        SuppliersTable.Rows[0].Cells[2].Paragraphs[0].Append("Completion Date")
                           .Bold(true)
                           .Color(Color.White);

                        SuppliersTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        SuppliersTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        SuppliersTable.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < currentProjectClosureReportModel.Suppliers.Count + 1; i++)
                        {
                            SuppliersTable.Rows[i].Cells[0].Paragraphs[0].Append(currentProjectClosureReportModel.Suppliers[i - 1].SupplierContract);
                            SuppliersTable.Rows[i].Cells[1].Paragraphs[0].Append(currentProjectClosureReportModel.Suppliers[i - 1].ActionRequired);
                            SuppliersTable.Rows[i].Cells[2].Paragraphs[0].Append(currentProjectClosureReportModel.Suppliers[i - 1].CompletionDate);
                        }

                        SuppliersTable.SetWidths(new float[] { 449, 783, 356 });
                        document.InsertTable(SuppliersTable);

                        var Resources = document.InsertParagraph("2.4\tResources")
                          .Bold()
                          .FontSize(12d)
                          .Color(Color.Black)
                          .Bold(true)
                          .Font("Arial");
                        Suppliers.StyleId = "Heading2";

                        var ResourcesTable = document.AddTable(currentProjectClosureReportModel.Resources.Count + 1, 3);

                        ResourcesTable.Rows[0].Cells[0].Paragraphs[0].Append("Project Resource")
                           .Bold(true)
                           .Color(Color.White);
                        ResourcesTable.Rows[0].Cells[1].Paragraphs[0].Append("Action Required")
                            .Bold(true)
                            .Color(Color.White);
                        ResourcesTable.Rows[0].Cells[2].Paragraphs[0].Append("Completion Date")
                           .Bold(true)
                           .Color(Color.White);

                        ResourcesTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        ResourcesTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        ResourcesTable.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < currentProjectClosureReportModel.Resources.Count + 1; i++)
                        {
                            ResourcesTable.Rows[i].Cells[0].Paragraphs[0].Append(currentProjectClosureReportModel.Resources[i - 1].ProjectResource);
                            ResourcesTable.Rows[i].Cells[1].Paragraphs[0].Append(currentProjectClosureReportModel.Resources[i - 1].ActionRequired);
                            ResourcesTable.Rows[i].Cells[2].Paragraphs[0].Append(currentProjectClosureReportModel.Resources[i - 1].CompletionDate);
                        }
                        ResourcesTable.SetWidths(new float[] { 449, 783, 356 });
                        document.InsertTable(ResourcesTable);

                        var Comm = document.InsertParagraph("2.5\tCommunications")
                          .Bold()
                          .FontSize(12d)
                          .Color(Color.Black)
                          .Bold(true)
                          .Font("Arial");
                        Comm.StyleId = "Heading2";

                        var CommunicationsTable = document.AddTable(currentProjectClosureReportModel.Communications.Count + 1, 4);

                        CommunicationsTable.Rows[0].Cells[0].Paragraphs[0].Append("Audience")
                           .Bold(true)
                           .Color(Color.White);
                        CommunicationsTable.Rows[0].Cells[1].Paragraphs[0].Append("Message")
                            .Bold(true)
                            .Color(Color.White);
                        CommunicationsTable.Rows[0].Cells[2].Paragraphs[0].Append("Method")
                           .Bold(true)
                           .Color(Color.White);

                        CommunicationsTable.Rows[0].Cells[3].Paragraphs[0].Append("Date ")
                           .Bold(true)
                           .Color(Color.White);

                        CommunicationsTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        CommunicationsTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        CommunicationsTable.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;
                        CommunicationsTable.Rows[0].Cells[3].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < currentProjectClosureReportModel.Communications.Count + 1; i++)
                        {
                            CommunicationsTable.Rows[i].Cells[0].Paragraphs[0].Append(currentProjectClosureReportModel.Communications[i - 1].Audience);
                            CommunicationsTable.Rows[i].Cells[1].Paragraphs[0].Append(currentProjectClosureReportModel.Communications[i - 1].Message);
                            CommunicationsTable.Rows[i].Cells[2].Paragraphs[0].Append(currentProjectClosureReportModel.Communications[i - 1].Method);
                            CommunicationsTable.Rows[i].Cells[3].Paragraphs[0].Append(currentProjectClosureReportModel.Communications[i - 1].CommunicationDate);
                        }

                        CommunicationsTable.SetWidths(new float[] { 351, 428, 411, 389});
                        document.InsertTable(CommunicationsTable);

                        var approval = document.InsertParagraph("3\tApproval")
                          .Bold()
                          .FontSize(14d)
                          .Color(Color.Black)
                          .Bold(true)
                          .Font("Arial");
                        approval.StyleId = "Heading1";

                        string buildApproval = $"Name:\t__________________\n\n"
                            + "Role:\tProject Sponsor\n\n"
                            + "Signature:\t__________________\n\n"
                            + "Date:\t___/___/___\n\n"
                            + "By signing this document, I grant formal approval to close this project and complete the handover activities described.";
                        document.InsertParagraph(buildApproval)
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
