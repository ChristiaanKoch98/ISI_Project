using ProjectManagementToolkit.Classes;
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
using ProjectManagementToolkit.Utility;
using ProjectManagementToolkit.Properties;
using Xceed.Words.NET;
using Xceed.Document.NET;

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Forms
{
    public partial class CostManagementProcessDocumentForm : Form
    {
        VersionControl<CostManagementProcessModel> versionControl;
        CostManagementProcessModel newCostManagementProcessModel;
        CostManagementProcessModel currentCostManagementProcessModel;

        Color TABLE_HEADER_COLOR = Color.FromArgb(73, 173, 252);
        CostManagementProcessModel costManagementProcessModel = new CostManagementProcessModel();

        public CostManagementProcessDocumentForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveDocument();
        }

        public void SaveDocument()
        {
            newCostManagementProcessModel.CostManagementProcess = Cost_Management_Process_tbx.Text;

            List<Information> informations = new List<Information>();
            Information information = new Information();
            var DocumentID = Document_Information_dgv.Rows[0].Cells[1].Value.ToString();
            var DocumentOwner = Document_Information_dgv.Rows[1].Cells[1].Value.ToString();
            var IssueDate = Document_Information_dgv.Rows[2].Cells[1].Value.ToString();
            var LastSavedDate = Document_Information_dgv.Rows[3].Cells[1].Value.ToString();
            var FileName = Document_Information_dgv.Rows[4].Cells[1].Value.ToString();

            information.DocumentID = DocumentID;
            information.DocumentOwner = DocumentOwner;
            information.IssueDate = IssueDate;
            information.LastSavedDate = LastSavedDate;
            information.FileName = FileName;
            newCostManagementProcessModel.Information = information;

            List<History> histories = new List<History>();
            int Document_HistoryRowCount = Document_History_dgv.RowCount;
            for (int i = 0; i < Document_HistoryRowCount - 1; i++)
            {
                History history = new History();
                var Version = Document_History_dgv.Rows[i].Cells[0].Value?.ToString() ?? "";
                var IsDate = Document_History_dgv.Rows[i].Cells[1].Value?.ToString() ?? "";
                var Changes = Document_History_dgv.Rows[i].Cells[2].Value?.ToString() ?? "";
                history.Version = Version;
                history.IssueDate = IsDate;
                history.Changes = Changes;
                histories.Add(history);
            }
            newCostManagementProcessModel.Histories = histories;

            List<Approval> approvals = new List<Approval>();
            int approvalCount = Document_Approvals_dgv.RowCount;
            for (int i = 0; i < Document_HistoryRowCount - 1; i++)
            {
                Approval approval = new Approval();
                var Role = Document_Approvals_dgv.Rows[i].Cells[0].Value?.ToString() ?? "";
                var Name = Document_Approvals_dgv.Rows[i].Cells[1].Value?.ToString() ?? "";
                var Signature = Document_Approvals_dgv.Rows[i].Cells[2].Value?.ToString() ?? "";
                var Date = Document_Approvals_dgv.Rows[i].Cells[3].Value?.ToString() ?? "";

                approval.Name = Name;
                approval.Role = Role;
                approval.Signature = Signature;
                approval.Date = Date;

                approvals.Add(approval);
            }
            newCostManagementProcessModel.Approvals = approvals;

            newCostManagementProcessModel.Overview = Overview_tbx.Text;
            newCostManagementProcessModel.DocumentExpense = Document_Expense_tbx.Text;
            newCostManagementProcessModel.ApproveExpense = Approve_Expense_tbx.Text;
            newCostManagementProcessModel.UpdateExpense = Update_Project_Plan_tbx.Text;
            newCostManagementProcessModel.TeamMembers = Team_Member_tbx.Text;
            newCostManagementProcessModel.ProjectAdmin = Project_Administrator_tbx.Text;
            newCostManagementProcessModel.ProjectManager = Project_Manager_tbx.Text;

            newCostManagementProcessModel.ExpenseForm = Expense_Form_tbx.Text;
            newCostManagementProcessModel.ExpenseRegister = Expense_Register_tbx.Text;

            List<VersionControl<CostManagementProcessModel>.DocumentModel> documentModels = versionControl.DocumentModels;

            //MessageBox.Show(JsonConvert.SerializeObject(newCostManagementProcessModel), "save", MessageBoxButtons.OK);


            if (!versionControl.isEqual(currentCostManagementProcessModel, newCostManagementProcessModel))
            {
                VersionControl<CostManagementProcessModel>.DocumentModel documentModel = new VersionControl<CostManagementProcessModel>.DocumentModel(newCostManagementProcessModel, DateTime.Now, VersionControl<CostManagementProcessModel>.generateID());

                documentModels.Add(documentModel);

                versionControl.DocumentModels = documentModels;

                string json = JsonConvert.SerializeObject(versionControl);
                JsonHelper.saveDocument(json, Settings.Default.ProjectID, "CostManagementProcess");
                MessageBox.Show("Risk plan saved successfully", "save", MessageBoxButtons.OK);
            }
        }

        public void LoadDocument()
        {
            string json = JsonHelper.loadDocument(Settings.Default.ProjectID, "CostManagementProcess");
            List<string[]> documentInfo = new List<string[]>();
            newCostManagementProcessModel = new CostManagementProcessModel();
            currentCostManagementProcessModel = new CostManagementProcessModel();
            if (json != "")
            {
                versionControl = JsonConvert.DeserializeObject<VersionControl<CostManagementProcessModel>>(json);
                newCostManagementProcessModel = JsonConvert.DeserializeObject<CostManagementProcessModel>(versionControl.getLatest(versionControl.DocumentModels));
                currentCostManagementProcessModel = JsonConvert.DeserializeObject<CostManagementProcessModel>(versionControl.getLatest(versionControl.DocumentModels));

                Information information = currentCostManagementProcessModel.Information;
                documentInfo.Add(new string[] { "Document ID", information.DocumentID });
                documentInfo.Add(new string[] { "Document Owner", information.DocumentOwner });
                documentInfo.Add(new string[] { "Issue Date", information.IssueDate });
                documentInfo.Add(new string[] { "Last Save Date", information.LastSavedDate });
                documentInfo.Add(new string[] { "File Name", information.FileName });

                foreach (var row in documentInfo)
                {
                    Document_Information_dgv.Rows.Add(row);
                }
                Document_Information_dgv.AllowUserToAddRows = false;

                foreach (var row in currentCostManagementProcessModel.Histories)
                {
                    Document_History_dgv.Rows.Add(new string[] { row.Version, row.IssueDate, row.Changes });
                }

                foreach (var row in currentCostManagementProcessModel.Approvals)
                {
                    Document_Approvals_dgv.Rows.Add(new string[] { row.Role, row.Name, row.Signature, row.Date });
                }

                Cost_Management_Process_tbx.Text = currentCostManagementProcessModel.CostManagementProcess;
                Overview_tbx.Text = currentCostManagementProcessModel.Overview;
                Document_Expense_tbx.Text = currentCostManagementProcessModel.DocumentExpense;
                Approve_Expense_tbx.Text = currentCostManagementProcessModel.ApproveExpense;
                Update_Project_Plan_tbx.Text = currentCostManagementProcessModel.UpdateExpense;
                Team_Member_tbx.Text = currentCostManagementProcessModel.TeamMembers;
                Project_Administrator_tbx.Text = currentCostManagementProcessModel.ProjectAdmin;
                Project_Manager_tbx.Text = currentCostManagementProcessModel.ProjectManager;
                Expense_Form_tbx.Text = currentCostManagementProcessModel.ExpenseForm;
                Expense_Register_tbx.Text = currentCostManagementProcessModel.ExpenseRegister;
            }
            else
            {
                versionControl = new VersionControl<CostManagementProcessModel>();
                versionControl.DocumentModels = new List<VersionControl<CostManagementProcessModel>.DocumentModel>();
                newCostManagementProcessModel = new CostManagementProcessModel();
                documentInfo.Add(new string[] { "Document ID", "" });
                documentInfo.Add(new string[] { "Document Owner", "" });
                documentInfo.Add(new string[] { "Issue Date", "" });
                documentInfo.Add(new string[] { "Last Save Date", "" });
                documentInfo.Add(new string[] { "File Name", "" });

                foreach (var row in documentInfo)
                {
                    Document_Information_dgv.Rows.Add(row);
                }
                Document_Information_dgv.AllowUserToAddRows = false;
            }
        }

        public void ExportToWord()
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

                        document.InsertParagraph("Risk Plan \nFor " + currentCostManagementProcessModel.CostManagementProcess)
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

                        var Document_Information = document.AddTable(6, 2);
                        Document_Information.Rows[0].Cells[0].Paragraphs[0].Append("").Bold(true).Color(Color.White);
                        Document_Information.Rows[0].Cells[1].Paragraphs[0].Append("Information").Bold(true).Color(Color.White);
                        Document_Information.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        Document_Information.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;

                        Document_Information.Rows[1].Cells[0].Paragraphs[0].Append("Document ID");
                        Document_Information.Rows[1].Cells[1].Paragraphs[0].Append(currentCostManagementProcessModel.Information.DocumentID);

                        Document_Information.Rows[2].Cells[0].Paragraphs[0].Append("Document Owner");
                        Document_Information.Rows[2].Cells[1].Paragraphs[0].Append(currentCostManagementProcessModel.Information.DocumentOwner);

                        Document_Information.Rows[3].Cells[0].Paragraphs[0].Append("Issue Date");
                        Document_Information.Rows[3].Cells[1].Paragraphs[0].Append(currentCostManagementProcessModel.Information.IssueDate);

                        Document_Information.Rows[4].Cells[0].Paragraphs[0].Append("Last Saved Date");
                        Document_Information.Rows[4].Cells[1].Paragraphs[0].Append(currentCostManagementProcessModel.Information.LastSavedDate);

                        Document_Information.Rows[5].Cells[0].Paragraphs[0].Append("File Name");
                        Document_Information.Rows[5].Cells[1].Paragraphs[0].Append(currentCostManagementProcessModel.Information.FileName);
                        Document_Information.SetWidths(new float[] { 493, 1094 });
                        document.InsertTable(Document_Information);

                        document.InsertParagraph("\nDocument History\n")
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(14d).Alignment = Alignment.left;

                        var documentHistoryTable = document.AddTable(currentCostManagementProcessModel.Histories.Count + 1, 3);
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

                        for (int i = 1; i < currentCostManagementProcessModel.Histories.Count + 1; i++)
                        {
                            documentHistoryTable.Rows[i].Cells[0].Paragraphs[0].Append(currentCostManagementProcessModel.Histories[i - 1].Version);
                            documentHistoryTable.Rows[i].Cells[1].Paragraphs[0].Append(currentCostManagementProcessModel.Histories[i - 1].IssueDate);
                            documentHistoryTable.Rows[i].Cells[2].Paragraphs[0].Append(currentCostManagementProcessModel.Histories[i - 1].Changes);

                        }

                        documentHistoryTable.SetWidths(new float[] { 190, 303, 1094 });
                        document.InsertTable(documentHistoryTable);

                        document.InsertParagraph("\nDocument Approvals\n")
                           .Font("Arial")
                           .Bold(true)
                           .FontSize(14d).Alignment = Alignment.left;

                        var documentApprovalTable = document.AddTable(currentCostManagementProcessModel.Approvals.Count + 1, 4);
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

                        for (int i = 1; i < currentCostManagementProcessModel.Approvals.Count + 1; i++)
                        {
                            documentApprovalTable.Rows[i].Cells[0].Paragraphs[0].Append(currentCostManagementProcessModel.Approvals[i - 1].Role);
                            documentApprovalTable.Rows[i].Cells[1].Paragraphs[0].Append(currentCostManagementProcessModel.Approvals[i - 1].Name);
                            documentApprovalTable.Rows[i].Cells[2].Paragraphs[0].Append(currentCostManagementProcessModel.Approvals[i - 1].Signature);
                            documentApprovalTable.Rows[i].Cells[3].Paragraphs[0].Append(currentCostManagementProcessModel.Approvals[i - 1].Date);
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
                        var costManagementProcess = document.InsertParagraph("1 Cost Management Process")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");
                        costManagementProcess.StyleId = "Heading1";

                        var overviewSubHeading = costManagementProcess.InsertParagraphAfterSelf("1.1 Overview")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        overviewSubHeading.StyleId = "Heading2";

                        var documentExpenseSubHeading = document.InsertParagraph("1.2 DocumentExpense")
                                .Bold()
                                .FontSize(12d)
                                .Color(Color.Black)
                                .Bold(true)
                                .Font("Arial");

                        document.InsertParagraph(currentCostManagementProcessModel.DocumentExpense)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;


                        documentExpenseSubHeading.StyleId = "Heading2";

                        var approveExpenseSubHeading = document.InsertParagraph("1.3 Approve Expense")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        document.InsertParagraph(currentCostManagementProcessModel.ApproveExpense)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        approveExpenseSubHeading.StyleId = "Heading2";

                        var updateProjectPlanSubHeading = document.InsertParagraph("1.4 Update Project Plan")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        updateProjectPlanSubHeading.StyleId = "Heading2";

                        var costManagementRolesHeading = document.InsertParagraph("2 Cost Management Roles")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        costManagementRolesHeading.StyleId = "Heading1";

                        var teamMemberSubheading = document.InsertParagraph("2.1 Team Members")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        document.InsertParagraph(currentCostManagementProcessModel.TeamMembers)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        teamMemberSubheading.StyleId = "Heading2";

                        var projectadminSubheading = document.InsertParagraph("2.2 Project Administrator")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        document.InsertParagraph(currentCostManagementProcessModel.ProjectAdmin)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        projectadminSubheading.StyleId = "Heading2";

                        var projectManagerSubheading = document.InsertParagraph("2.3 Project Manager")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        document.InsertParagraph(currentCostManagementProcessModel.ProjectManager)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        projectManagerSubheading.StyleId = "Heading2";


                        var costManagementDocsHeading = document.InsertParagraph("3 Cost Management Documents")
                                                   .Bold()
                                                   .FontSize(12d)
                                                   .Color(Color.Black)
                                                   .Bold(true)
                                                   .Font("Arial");

                        costManagementDocsHeading.StyleId = "Heading1";

                        var expenseFormSubheading = document.InsertParagraph("3.1 Expense Form")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        document.InsertParagraph(currentCostManagementProcessModel.ExpenseForm)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        expenseFormSubheading.StyleId = "Heading2";

                        var expenseRegisterSubheading = document.InsertParagraph("3.2 Expense Register")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        document.InsertParagraph(currentCostManagementProcessModel.ExpenseRegister)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        expenseRegisterSubheading.StyleId = "Heading2";

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

        private void btnExportToWord_Click(object sender, EventArgs e)
        {
            ExportToWord();
        }

        private void CostManagementProcessDocumentForm_Load(object sender, EventArgs e)
        {
            LoadDocument();
        }
    }
}