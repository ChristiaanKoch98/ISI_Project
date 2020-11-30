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

    public partial class StatementOfWorkDocumentForm : Form
    {
        VersionControl<StatementOfWorkModel> versionControl;
        StatementOfWorkModel newStatementOfWorkModel;
        StatementOfWorkModel currentStatementOfWorkModel;
        Color TABLE_HEADER_COLOR = Color.FromArgb(73, 173, 252);
        ProjectModel projectModel = new ProjectModel();

        public StatementOfWorkDocumentForm()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void StatementOfWorkDocumentForm_Load(object sender, EventArgs e)
        {
            loadDocument();
            string json = JsonHelper.loadProjectInfo(Settings.Default.Username);
            List<ProjectModel> projectListModel = JsonConvert.DeserializeObject<List<ProjectModel>>(json);
            projectModel = projectModel.getProjectModel(Settings.Default.ProjectID, projectListModel);
        }

        private void btnStatementSave_Click(object sender, EventArgs e)
        {
            
        }



        public void saveDocument()
        {
            newStatementOfWorkModel.DocumentID = docInfoGridData.Rows[0].Cells[1].Value.ToString();
            newStatementOfWorkModel.DocumentOwner = docInfoGridData.Rows[1].Cells[1].Value.ToString();
            newStatementOfWorkModel.IssueDate = docInfoGridData.Rows[2].Cells[1].Value.ToString();
            newStatementOfWorkModel.LastSavedDate = docInfoGridData.Rows[3].Cells[1].Value.ToString();
            newStatementOfWorkModel.FileName = docInfoGridData.Rows[4].Cells[1].Value.ToString();

            List<StatementOfWorkModel.DocumentHistory> documentHistories = new List<StatementOfWorkModel.DocumentHistory>();

            int versionRowsCount = dataGridViewDocHistory.Rows.Count;

            for (int i = 0; i < versionRowsCount - 1; i++)
            {
                StatementOfWorkModel.DocumentHistory documentHistoryModel = new StatementOfWorkModel.DocumentHistory();
                var version = dataGridViewDocHistory.Rows[i].Cells[0].Value?.ToString() ?? "";
                var issueDate = dataGridViewDocHistory.Rows[i].Cells[1].Value?.ToString() ?? "";
                var changes = dataGridViewDocHistory.Rows[i].Cells[2].Value?.ToString() ?? "";
                documentHistoryModel.Version = version;
                documentHistoryModel.IssueDate = issueDate;
                documentHistoryModel.Changes = changes;
                documentHistories.Add(documentHistoryModel);
            }
            newStatementOfWorkModel.DocumentHistories = documentHistories;

            List<StatementOfWorkModel.DocumentApproval> documentApprovalsModel = new List<StatementOfWorkModel.DocumentApproval>();

            int approvalRowsCount = dataGridViewDocApprovals.Rows.Count;

            for (int i = 0; i < approvalRowsCount - 1; i++)
            {
                StatementOfWorkModel.DocumentApproval documentApproval = new StatementOfWorkModel.DocumentApproval();
                var role = dataGridViewDocApprovals.Rows[i].Cells[0].Value?.ToString() ?? "";
                var name = dataGridViewDocApprovals.Rows[i].Cells[1].Value?.ToString() ?? "";
                var signature = dataGridViewDocApprovals.Rows[i].Cells[2].Value?.ToString() ?? "";
                var date = dataGridViewDocApprovals.Rows[i].Cells[3].Value?.ToString() ?? "";
                documentApproval.Role = role;
                documentApproval.Name = name;
                documentApproval.Signature = signature;
                documentApproval.DateApproved = date;

                documentApprovalsModel.Add(documentApproval);
            }
            newStatementOfWorkModel.DocumentApprovals = documentApprovalsModel;

            List<StatementOfWorkModel.ScopeOfWork> scopeOfWorkModel = new List<StatementOfWorkModel.ScopeOfWork>();

            int scopeRowsCount = dataGridView4.Rows.Count;

            for (int i = 0; i < approvalRowsCount - 1; i++)
            {
                StatementOfWorkModel.ScopeOfWork scopeOfWork = new StatementOfWorkModel.ScopeOfWork();
                var itemTitle = dataGridView4.Rows[i].Cells[0].Value?.ToString() ?? "";
                var itemDescription = dataGridView4.Rows[i].Cells[1].Value?.ToString() ?? "";
                var itemQuantity = dataGridView4.Rows[i].Cells[2].Value?.ToString() ?? "";
                scopeOfWork.ItemTitle = itemTitle;
                scopeOfWork.ItemDescription = itemDescription;
                scopeOfWork.ItemQuantity = itemQuantity;

                scopeOfWorkModel.Add(scopeOfWork);
            }
            newStatementOfWorkModel.ScopeOfWorks = scopeOfWorkModel;

            newStatementOfWorkModel.Introduction = txtIntroduction.Text;


            newStatementOfWorkModel.Objectives = txtObjectives.Text;

            newStatementOfWorkModel.SupplierResponsibilities = txtSupplierResponsibilities.Text;

            newStatementOfWorkModel.ProjectResponsibilities = txtProjectResponsibilities.Text;

            newStatementOfWorkModel.AcceptanceTerms = txtAcceptanceTerms.Text;

            newStatementOfWorkModel.PaymentTerms = txtPaymentTerms.Text;

            newStatementOfWorkModel.Confidentiality = txtConfidentiality.Text;

            newStatementOfWorkModel.OtherTerms = txtOtherTerms.Text;


            List<VersionControl<StatementOfWorkModel>.DocumentModel> documentModels = versionControl.DocumentModels;


            if (!versionControl.isEqual(currentStatementOfWorkModel, newStatementOfWorkModel))
            {
                VersionControl<StatementOfWorkModel>.DocumentModel documentModel = new VersionControl<StatementOfWorkModel>.DocumentModel(newStatementOfWorkModel, DateTime.Now, VersionControl<ProjectModel>.generateID());

                documentModels.Add(documentModel);

                versionControl.DocumentModels = documentModels;

                string json = JsonConvert.SerializeObject(versionControl);
                JsonHelper.saveDocument(json, Settings.Default.ProjectID, "StatementOfWork");
                MessageBox.Show("Statement of Work saved successfully", "save", MessageBoxButtons.OK);
            }
        }

        public void loadDocument()
        {
            string json = JsonHelper.loadDocument(Settings.Default.ProjectID, "StatementOfWork");
            List<string[]> documentInfo = new List<string[]>();
            newStatementOfWorkModel = new StatementOfWorkModel();
            currentStatementOfWorkModel = new StatementOfWorkModel();
            if (json != "")
            {
                versionControl = JsonConvert.DeserializeObject<VersionControl<StatementOfWorkModel>>(json);
                newStatementOfWorkModel = JsonConvert.DeserializeObject<StatementOfWorkModel>(versionControl.getLatest(versionControl.DocumentModels));
                currentStatementOfWorkModel = JsonConvert.DeserializeObject<StatementOfWorkModel>(versionControl.getLatest(versionControl.DocumentModels));

                documentInfo.Add(new string[] { "Document ID", currentStatementOfWorkModel.DocumentID });
                documentInfo.Add(new string[] { "Document Owner", currentStatementOfWorkModel.DocumentOwner });
                documentInfo.Add(new string[] { "Issue Date", currentStatementOfWorkModel.IssueDate });
                documentInfo.Add(new string[] { "Last Save Date", currentStatementOfWorkModel.LastSavedDate });
                documentInfo.Add(new string[] { "File Name", currentStatementOfWorkModel.FileName });

                foreach (var row in documentInfo)
                {
                    docInfoGridData.Rows.Add(row);
                }
                docInfoGridData.AllowUserToAddRows = false;

                foreach (var row in currentStatementOfWorkModel.DocumentHistories)
                {
                    dataGridViewDocHistory.Rows.Add(new string[] { row.Version, row.IssueDate, row.Changes });
                }

                foreach (var row in currentStatementOfWorkModel.DocumentApprovals)
                {
                    dataGridViewDocApprovals.Rows.Add(new string[] { row.Role, row.Name, "", row.DateApproved });
                }

                txtIntroduction.Text = currentStatementOfWorkModel.Introduction;

                txtObjectives.Text = currentStatementOfWorkModel.Objectives;

                foreach (var row in currentStatementOfWorkModel.ScopeOfWorks)
                {
                    dataGridView4.Rows.Add(new string[] { row.ItemTitle, row.ItemDescription, row.ItemQuantity });
                }


                txtSupplierResponsibilities.Text = currentStatementOfWorkModel.SupplierResponsibilities;

                txtProjectResponsibilities.Text = currentStatementOfWorkModel.ProjectResponsibilities;

                txtAcceptanceTerms.Text = currentStatementOfWorkModel.AcceptanceTerms;

                txtPaymentTerms.Text = currentStatementOfWorkModel.PaymentTerms;

                txtConfidentiality.Text = currentStatementOfWorkModel.Confidentiality;

                txtOtherTerms.Text = currentStatementOfWorkModel.OtherTerms;
            }
            else
            {
                versionControl = new VersionControl<StatementOfWorkModel>();
                versionControl.DocumentModels = new List<VersionControl<StatementOfWorkModel>.DocumentModel>();
                documentInfo.Add(new string[] { "Document ID", "" });
                documentInfo.Add(new string[] { "Document Owner", "" });
                documentInfo.Add(new string[] { "Issue Date", "" });
                documentInfo.Add(new string[] { "Last Save Date", "" });
                documentInfo.Add(new string[] { "File Name", "" });
                newStatementOfWorkModel = new StatementOfWorkModel();
                foreach (var row in documentInfo)
                {
                    docInfoGridData.Rows.Add(row);
                }
                docInfoGridData.AllowUserToAddRows = false;
            }
        }

        private void btnResourceSave_Click(object sender, EventArgs e)
        {

        }

        private void btnSaveProjectName_Click(object sender, EventArgs e)
        {

        }

        private void btnSaveIntro_Click(object sender, EventArgs e)
        {

        }

        private void btnExportStatementOfWork_Click(object sender, EventArgs e)
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
                        for (int i = 0; i < 11; i++)
                        {
                            document.InsertParagraph("")
                                .Font("Arial")
                                .Bold(true)
                                .FontSize(22d).Alignment = Alignment.left;
                        }
                        document.InsertParagraph("Statement of Work \nFor " + projectModel.ProjectName)
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
                        documentInfoTable.Rows[1].Cells[1].Paragraphs[0].Append(currentStatementOfWorkModel.DocumentID);

                        documentInfoTable.Rows[2].Cells[0].Paragraphs[0].Append("Document Owner");
                        documentInfoTable.Rows[2].Cells[1].Paragraphs[0].Append(currentStatementOfWorkModel.DocumentOwner);

                        documentInfoTable.Rows[3].Cells[0].Paragraphs[0].Append("Issue Date");
                        documentInfoTable.Rows[3].Cells[1].Paragraphs[0].Append(currentStatementOfWorkModel.IssueDate);

                        documentInfoTable.Rows[4].Cells[0].Paragraphs[0].Append("Last Saved Date");
                        documentInfoTable.Rows[4].Cells[1].Paragraphs[0].Append(currentStatementOfWorkModel.LastSavedDate);

                        documentInfoTable.Rows[5].Cells[0].Paragraphs[0].Append("File Name");
                        documentInfoTable.Rows[5].Cells[1].Paragraphs[0].Append(currentStatementOfWorkModel.FileName);
                        documentInfoTable.SetWidths(new float[] { 493, 1094 });
                        document.InsertTable(documentInfoTable);


                        //Document Histories
                        document.InsertParagraph("\nDocument History\n")
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(14d).Alignment = Alignment.left;

                        var documentHistoryTable = document.AddTable(currentStatementOfWorkModel.DocumentHistories.Count + 1, 3);
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
                        for (int i = 1; i < currentStatementOfWorkModel.DocumentHistories.Count + 1; i++)
                        {
                            documentHistoryTable.Rows[i].Cells[0].Paragraphs[0].Append(currentStatementOfWorkModel.DocumentHistories[i - 1].Version);
                            documentHistoryTable.Rows[i].Cells[1].Paragraphs[0].Append(currentStatementOfWorkModel.DocumentHistories[i - 1].IssueDate);
                            documentHistoryTable.Rows[i].Cells[2].Paragraphs[0].Append(currentStatementOfWorkModel.DocumentHistories[i - 1].Changes);

                        }

                        documentHistoryTable.SetWidths(new float[] { 190, 303, 1094 });
                        document.InsertTable(documentHistoryTable);


                        //Document approvals
                        document.InsertParagraph("\nDocument Approvals\n")
                           .Font("Arial")
                           .Bold(true)
                           .FontSize(14d).Alignment = Alignment.left;

                        var documentApprovalTable = document.AddTable(currentStatementOfWorkModel.DocumentApprovals.Count + 1, 4);
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

                        for (int i = 1; i < currentStatementOfWorkModel.DocumentApprovals.Count + 1; i++)
                        {
                            documentApprovalTable.Rows[i].Cells[0].Paragraphs[0].Append(currentStatementOfWorkModel.DocumentApprovals[i - 1].Role);
                            documentApprovalTable.Rows[i].Cells[1].Paragraphs[0].Append(currentStatementOfWorkModel.DocumentApprovals[i - 1].Name);
                            documentApprovalTable.Rows[i].Cells[2].Paragraphs[0].Append(currentStatementOfWorkModel.DocumentApprovals[i - 1].Signature);
                            documentApprovalTable.Rows[i].Cells[3].Paragraphs[0].Append(currentStatementOfWorkModel.DocumentApprovals[i - 1].DateApproved);
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

                        ////Introduction
                        var introductionSubheading = document.InsertParagraph("1. Introduction")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        document.InsertParagraph(currentStatementOfWorkModel.Introduction)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        introductionSubheading.StyleId = "Heading1";

                        //Objectives
                        var objectivesSubheading = document.InsertParagraph("2. Objectives")
                           .Bold()
                           .FontSize(14d)
                           .Color(Color.Black)
                           .Bold(true)
                           .Font("Arial");

                        document.InsertParagraph(currentStatementOfWorkModel.Objectives)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        objectivesSubheading.StyleId = "Heading1";


                        //Scope of work
                        document.InsertParagraph("\n3. Scope Of Work\n")
                           .Font("Arial")
                           .Bold(true)
                           .FontSize(14d).Alignment = Alignment.left;

                        var scopeOfWOrkTable = document.AddTable(currentStatementOfWorkModel.ScopeOfWorks.Count + 1, 3);
                        scopeOfWOrkTable.Rows[0].Cells[0].Paragraphs[0].Append("Item Title")
                            .Bold(true)
                            .Color(Color.White);
                        scopeOfWOrkTable.Rows[0].Cells[1].Paragraphs[0].Append("Item Description")
                            .Bold(true)
                            .Color(Color.White);
                        scopeOfWOrkTable.Rows[0].Cells[2].Paragraphs[0].Append("Item Quantity")
                            .Bold(true)
                            .Color(Color.White);
                        scopeOfWOrkTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        scopeOfWOrkTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        scopeOfWOrkTable.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < currentStatementOfWorkModel.ScopeOfWorks.Count + 1; i++)
                        {
                            scopeOfWOrkTable.Rows[i].Cells[0].Paragraphs[0].Append(currentStatementOfWorkModel.ScopeOfWorks[i - 1].ItemTitle);
                            scopeOfWOrkTable.Rows[i].Cells[1].Paragraphs[0].Append(currentStatementOfWorkModel.ScopeOfWorks[i - 1].ItemDescription);
                            scopeOfWOrkTable.Rows[i].Cells[2].Paragraphs[0].Append(currentStatementOfWorkModel.ScopeOfWorks[i - 1].ItemQuantity);
                        }
                        scopeOfWOrkTable.SetWidths(new float[] { 450, 400, 508 });
                        document.InsertTable(scopeOfWOrkTable);
                        

                        //Responsibilities
                        var responsibilitiesHeading = document.InsertParagraph("4. Responsibilities")
                           .Bold()
                           .FontSize(14d)
                           .Color(Color.Black)
                           .Bold(true)
                           .Font("Arial");


                        responsibilitiesHeading.StyleId = "Heading1";

                        var suplierSubHeading = document.InsertParagraph("4.1 Supplier Responsibilities")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        suplierSubHeading.StyleId = "Heading2";

                        document.InsertParagraph(currentStatementOfWorkModel.SupplierResponsibilities)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        var projectSubHeading = document.InsertParagraph("4.2 Project Responsibilities")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        projectSubHeading.StyleId = "Heading2";

                        document.InsertParagraph(currentStatementOfWorkModel.ProjectResponsibilities)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        //Terms of Supply                   
                        var termsHeading = document.InsertParagraph("5. Terms of Supply")
                           .Bold()
                           .FontSize(14d)
                           .Color(Color.Black)
                           .Bold(true)
                           .Font("Arial");

                        termsHeading.StyleId = "Heading1";

                        var acceptanceSubHeading = document.InsertParagraph("5.1 Acceptance terms")
                           .Bold()
                           .FontSize(12d)
                           .Color(Color.Black)
                           .Bold(true)
                           .Font("Arial");

                        document.InsertParagraph(currentStatementOfWorkModel.AcceptanceTerms)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        acceptanceSubHeading.StyleId = "Heading2";

                        

                        var payementSubHeading = document.InsertParagraph("5.2 Payment terms")
                           .Bold()
                           .FontSize(12d)
                           .Color(Color.Black)
                           .Bold(true)
                           .Font("Arial");

                        document.InsertParagraph(currentStatementOfWorkModel.PaymentTerms)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        payementSubHeading.StyleId = "Heading2";

                        

                        var confidentialitySubHeading = document.InsertParagraph("5.3 Confidentiality")
                           .Bold()
                           .FontSize(12d)
                           .Color(Color.Black)
                           .Bold(true)
                           .Font("Arial");

                        document.InsertParagraph(currentStatementOfWorkModel.Confidentiality)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        confidentialitySubHeading.StyleId = "Heading2";

                        

                        var otherSubHeading = document.InsertParagraph("5.4 Other terms")
                           .Bold()
                           .FontSize(12d)
                           .Color(Color.Black)
                           .Bold(true)
                           .Font("Arial");

                        document.InsertParagraph(currentStatementOfWorkModel.OtherTerms)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        otherSubHeading.StyleId = "Heading2";

                        


                        try
                        {
                            document.Save();
                        }
                        catch 
                        {
                            MessageBox.Show("The selected File is open.", "Close File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }


        }

        private void btnStatementSave_Click_1(object sender, EventArgs e)
        {
            saveDocument();
        }
    }
}
