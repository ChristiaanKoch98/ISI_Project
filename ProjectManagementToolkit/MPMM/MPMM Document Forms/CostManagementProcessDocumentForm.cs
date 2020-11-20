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

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Forms
{
    public partial class CostManagementProcessDocumentForm : Form
    {
        VersionControl<CostManagementProcessModel> versionControl;
        CostManagementProcessModel newCostManagementProcessModel;
        CostManagementProcessModel currentCostManagementProcessModel;

        CostManagementProcessModel costManagementProcess;
        public CostManagementProcessDocumentForm()
        {
            InitializeComponent();
            costManagementProcess = new CostManagementProcessModel();

            List<string[]> rows1 = new List<string[]>();
            rows1.Add(new string[] { "Document ID", "" });
            rows1.Add(new string[] { "Document Owner", "" });
            rows1.Add(new string[] { "Issue Date", "" });
            rows1.Add(new string[] { "Last Save Date", "" });
            rows1.Add(new string[] { "File Name", "" });
            foreach (var row in rows1)
            {
                Document_Information_dgv.Rows.Add(row);
            }
            Document_Information_dgv.AllowUserToAddRows = false;

            List<string[]> rows2 = new List<string[]>();
            rows2.Add(new string[] { "Project Sponsor", "" });
            rows2.Add(new string[] { "Project Review Group", "" });
            rows2.Add(new string[] { "Project Manager", "" });
            rows2.Add(new string[] { "Quality Manager", "" });
            rows2.Add(new string[] { "Procument Manager", "" });
            rows2.Add(new string[] { "Communications Manager", "" });
            rows2.Add(new string[] { "Project Office Manager", "" });
            foreach (var row in rows2)
            {
                Document_Approvals_dgv.Rows.Add(row);
            }
            Document_Approvals_dgv.AllowUserToAddRows = false;
            LoadDocument();
        }


        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void Enter_btn_Click(object sender, EventArgs e)
        {
            if (Cost_Management_Process_tbx.Text.Length > 0)
            {
                costManagementProcess.DocumentManagementProcess = Cost_Management_Process_tbx.Text;
                newCostManagementProcessModel.DocumentManagementProcess = costManagementProcess.DocumentManagementProcess;
            }
        }

        private void Cost_Management_Roles_Click(object sender, EventArgs e)
        {
            if (Overview_tbx.Text.Length > 0 && Document_Expense_tbx.Text.Length > 0 &&
               Approve_Expense_tbx.Text.Length > 0 && Update_Project_Plan_tbx.Text.Length > 0)
            {
                costManagementProcess.Overview = Overview_tbx.Text;
                costManagementProcess.DocumentExpense = Document_Expense_tbx.Text;
                costManagementProcess.ApproveExpense = Approve_Expense_tbx.Text;
                costManagementProcess.UpdateExpense = Update_Project_Plan_tbx.Text;

                newCostManagementProcessModel.Overview = costManagementProcess.Overview;
                newCostManagementProcessModel.DocumentExpense = costManagementProcess.DocumentExpense;
                newCostManagementProcessModel.ApproveExpense = costManagementProcess.ApproveExpense;
                newCostManagementProcessModel.UpdateExpense = costManagementProcess.UpdateExpense;
            }
        }

        private void Cost_Management_Roles_btn_Click(object sender, EventArgs e)
        {
            if (Team_Member_tbx.Text.Length > 0 && Project_Administrator_tbx.Text.Length > 0 &&
               Project_Manager_tbx.Text.Length > 0)
            {
                costManagementProcess.TeamMembers = new List<string>();
                foreach (var member in Team_Member_tbx.Text)
                {
                    //costManagementProcess.TeamMembers.Add(member);  ListBox Control In place of Textbox here...
                }
                costManagementProcess.ProjectAdmin = Project_Administrator_tbx.Text;
                costManagementProcess.ProjectManager = Project_Manager_tbx.Text;

                newCostManagementProcessModel.ProjectAdmin = costManagementProcess.ProjectAdmin;
                newCostManagementProcessModel.ProjectManager = costManagementProcess.ProjectManager;
            }
        }

        private void Cost_Management_Documents_btn_Click(object sender, EventArgs e)
        {
            if (Expense_Form_tbx.Text.Length > 0 && Expense_Register_tbx.Text.Length > 0)
            {
                costManagementProcess.ExpenseForm = Expense_Form_tbx.Text;
                costManagementProcess.ExpenseRegister = Expense_Register_tbx.Text;

                newCostManagementProcessModel.ExpenseForm = costManagementProcess.ExpenseForm;
                newCostManagementProcessModel.ExpenseRegister = costManagementProcess.ExpenseRegister;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Information> informations = new List<Information>();
            int Document_infoRowCount = Document_Information_dgv.RowCount;
            for (int i = 0; i < Document_infoRowCount - 1; i++)
            {

                Information information = new Information();
                var DocumentID = Document_Information_dgv.Rows[i].Cells[0].Value.ToString();
                var DocumentOwner = Document_Information_dgv.Rows[i].Cells[1].Value.ToString();
                var IssueDate = Document_Information_dgv.Rows[i].Cells[2].Value.ToString();
                var LastSavedDate = Document_Information_dgv.Rows[i].Cells[3].Value.ToString();
                var FileName = Document_Information_dgv.Rows[i].Cells[4].Value.ToString();

                information.DocumentID = DocumentID;
                information.DocumentOwner = DocumentOwner;
                information.IssueDate = IssueDate;
                information.LastSavedDate = LastSavedDate;
                information.FileName = FileName;
                informations.Add(information);
            }
            newCostManagementProcessModel.informations = informations;

            List<History> histories = new List<History>();
            int Document_HistoryRowCount = Document_History_dgv.RowCount;
            for (int i = 0; i < Document_HistoryRowCount - 1; i++)
            {
                History history = new History();
                var Version = Document_History_dgv.Rows[i].Cells[0].Value?.ToString() ?? "";
                var IssueDate = Document_History_dgv.Rows[i].Cells[1].Value?.ToString() ?? "";
                var Changes = Document_History_dgv.Rows[i].Cells[2].Value?.ToString() ?? "";
                history.Version = Version;
                history.IssueDate = IssueDate;
                history.Changes = Changes;
                histories.Add(history);
            }
            newCostManagementProcessModel.histories = histories;

            List<Approvals> approvals = new List<Approvals>();
            int approvalCount = Document_Approvals_dgv.RowCount;
            for (int i = 0; i < Document_HistoryRowCount - 1; i++)
            {
                Approvals approval = new Approvals();
                var Name = Document_Approvals_dgv.Rows[i].Cells[0].Value?.ToString() ?? "";
                var Signature = Document_Approvals_dgv.Rows[i].Cells[1].Value?.ToString() ?? "";
                var Date = Document_Approvals_dgv.Rows[i].Cells[2].Value?.ToString() ?? "";


                approval.Name = Name;
                approval.Signature = Signature;
                approval.Date = Date;

            }
            newCostManagementProcessModel.approvals = approvals;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveDocument();
        }

        public void SaveDocument()
        {
            List<VersionControl<CostManagementProcessModel>.DocumentModel> documentModels = versionControl.DocumentModels;


            if (!versionControl.isEqual(currentCostManagementProcessModel, newCostManagementProcessModel))
            {
                VersionControl<CostManagementProcessModel>.DocumentModel documentModel = new VersionControl<CostManagementProcessModel>.DocumentModel(newCostManagementProcessModel, DateTime.Now, VersionControl<CostManagementProcessModel>.generateID());

                documentModels.Add(documentModel);

                versionControl.DocumentModels = documentModels;

                string json = JsonConvert.SerializeObject(versionControl);
                JsonHelper.saveDocument(json, Settings.Default.ProjectID, "ProjectPlan");
                MessageBox.Show("Cost management process form saved successfully", "save", MessageBoxButtons.OK);
            }
        }

        public void LoadDocument()
        {
            string json = JsonHelper.loadDocument(Settings.Default.ProjectID, "RiskPlan");
            List<string[]> documentInfo = new List<string[]>();
            newCostManagementProcessModel = new CostManagementProcessModel();
            currentCostManagementProcessModel = new CostManagementProcessModel();
            if (json != "")
            {
                versionControl = JsonConvert.DeserializeObject<VersionControl<CostManagementProcessModel>>(json);
                newCostManagementProcessModel = JsonConvert.DeserializeObject<CostManagementProcessModel>(versionControl.getLatest(versionControl.DocumentModels));
                currentCostManagementProcessModel = JsonConvert.DeserializeObject<CostManagementProcessModel>(versionControl.getLatest(versionControl.DocumentModels));

                documentInfo.Add(new string[] { "Document ID", currentCostManagementProcessModel.Info.DocumentID });
                documentInfo.Add(new string[] { "Document Owner", currentCostManagementProcessModel.Info.DocumentOwner });
                documentInfo.Add(new string[] { "Issue Date", currentCostManagementProcessModel.Info.IssueDate });
                documentInfo.Add(new string[] { "Last Save Date", currentCostManagementProcessModel.Info.LastSavedDate });
                documentInfo.Add(new string[] { "File Name", currentCostManagementProcessModel.Info.FileName });

                documentInfo.Add(new string[] { "Project Sponsor", currentCostManagementProcessModel.Approval.ProjectSponsor });
                documentInfo.Add(new string[] { "Project Review Group", currentCostManagementProcessModel.Approval.ProjectReviewGroup });
                documentInfo.Add(new string[] { "Project Manager", currentCostManagementProcessModel.Approval.ProjectManager });
                documentInfo.Add(new string[] { "Quality Manager", currentCostManagementProcessModel.Approval.QualityManager });
                documentInfo.Add(new string[] { "Procument Manager", currentCostManagementProcessModel.Approval.ProcumentManager });
                documentInfo.Add(new string[] { "Communications Manager", currentCostManagementProcessModel.Approval.CommunicationsManager });
                documentInfo.Add(new string[] { "Project Office Manager", currentCostManagementProcessModel.Approval.ProjectOfficeManager });

                foreach (var row in documentInfo)
                {
                    Document_Information_dgv.Rows.Add(row);
                }

                foreach (var row in currentCostManagementProcessModel.histories)
                {
                    Document_History_dgv.Rows.Add(new string[] { row.Version, row.IssueDate, row.Changes });
                }

                foreach (var row in currentCostManagementProcessModel.approvals)
                {
                    Document_Approvals_dgv.Rows.Add(new string[] { row.Name, row.Signature, row.Date });
                }

                currentCostManagementProcessModel.DocumentManagementProcess = costManagementProcess.DocumentManagementProcess;
                currentCostManagementProcessModel.Overview = costManagementProcess.Overview;
                currentCostManagementProcessModel.DocumentExpense = costManagementProcess.DocumentExpense;
                currentCostManagementProcessModel.ApproveExpense = costManagementProcess.ApproveExpense;
                currentCostManagementProcessModel.UpdateExpense = costManagementProcess.UpdateExpense;
                currentCostManagementProcessModel.ProjectAdmin = costManagementProcess.ProjectAdmin;
                currentCostManagementProcessModel.ProjectManager = costManagementProcess.ProjectManager;
                currentCostManagementProcessModel.ExpenseForm = costManagementProcess.ExpenseForm;
                currentCostManagementProcessModel.ExpenseRegister = costManagementProcess.ExpenseRegister;
            }
        }
    }
}