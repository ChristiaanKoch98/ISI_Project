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

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Forms
{
    public partial class IssueManagementProcessDocumentForm : Form
    {
        VersionControl<IssueManagementProcessModel> versionControl;
        IssueManagementProcessModel newIssueManagementProcessModel;
        IssueManagementProcessModel currentIssueManagementProcessModel;

        public IssueManagementProcessDocumentForm()
        {
            InitializeComponent();
        }

        private void IssueManagementProcessDocumentForm_Load(object sender, EventArgs e)
        {
            loadDocument();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveDocument();
        }


        public void saveDocument()
        {
            newIssueManagementProcessModel.DocumentID = DocumentInfoGrid.Rows[0].Cells[1].Value.ToString();
            newIssueManagementProcessModel.DocumentOwner = DocumentInfoGrid.Rows[1].Cells[1].Value.ToString();
            newIssueManagementProcessModel.IssueDate = DocumentInfoGrid.Rows[2].Cells[1].Value.ToString();
            newIssueManagementProcessModel.LastSavedDate = DocumentInfoGrid.Rows[3].Cells[1].Value.ToString();
            newIssueManagementProcessModel.FileName = DocumentInfoGrid.Rows[4].Cells[1].Value.ToString();

            List<IssueManagementProcessModel.DocumentHistory> documentHistories = new List<IssueManagementProcessModel.DocumentHistory>();

            int versionRowsCount = docHistDataGrid.Rows.Count;

            for (int i = 0; i < versionRowsCount - 1; i++)
            {
                IssueManagementProcessModel.DocumentHistory documentHistoryModel = new IssueManagementProcessModel.DocumentHistory();
                var version = docHistDataGrid.Rows[i].Cells[0].Value?.ToString() ?? "";
                var issueDate = docHistDataGrid.Rows[i].Cells[1].Value?.ToString() ?? "";
                var changes = docHistDataGrid.Rows[i].Cells[2].Value?.ToString() ?? "";
                documentHistoryModel.Version = version;
                documentHistoryModel.IssueDate = issueDate;
                documentHistoryModel.Changes = changes;
                documentHistories.Add(documentHistoryModel);
            }
            newIssueManagementProcessModel.DocumentHistories = documentHistories;

            List<IssueManagementProcessModel.DocumentApproval> documentApprovalsModel = new List<IssueManagementProcessModel.DocumentApproval>();

            int approvalRowsCount = docApprovalsDataGrid.Rows.Count;

            for (int i = 0; i < approvalRowsCount - 1; i++)
            {
                IssueManagementProcessModel.DocumentApproval documentApproval = new IssueManagementProcessModel.DocumentApproval();
                var role = docApprovalsDataGrid.Rows[i].Cells[0].Value?.ToString() ?? "";
                var name = docApprovalsDataGrid.Rows[i].Cells[1].Value?.ToString() ?? "";
                var signature = docApprovalsDataGrid.Rows[i].Cells[2].Value?.ToString() ?? "";
                var date = docApprovalsDataGrid.Rows[i].Cells[3].Value?.ToString() ?? "";
                documentApproval.Role = role;
                documentApproval.Name = name;
                documentApproval.Signature = signature;
                documentApproval.DateApproved = date;

                documentApprovalsModel.Add(documentApproval);
            }
            newIssueManagementProcessModel.DocumentApprovals = documentApprovalsModel;

            newIssueManagementProcessModel.Overview = overviewTextBox.Text;
            newIssueManagementProcessModel.RaiseIssue = raiseIssueLabel.Text;
            newIssueManagementProcessModel.ReviewIssue = reviewIssueLabel.Text;
            newIssueManagementProcessModel.IssueAction = assgnActTextBox.Text;
            newIssueManagementProcessModel.TeamMember = textBox1.Text;
            newIssueManagementProcessModel.ProjectManager = textBox2.Text;
            newIssueManagementProcessModel.ProjectBoard = textBox3.Text;
            newIssueManagementProcessModel.IssueForm = issueFormTextBox.Text;
            newIssueManagementProcessModel.IssueRegister = issueRegisterTextBox.Text;

            List<VersionControl<IssueManagementProcessModel>.DocumentModel> documentModels = versionControl.DocumentModels;


            if (!versionControl.isEqual(currentIssueManagementProcessModel, newIssueManagementProcessModel))
            {
                VersionControl<IssueManagementProcessModel>.DocumentModel documentModel = new VersionControl<IssueManagementProcessModel>.DocumentModel(newIssueManagementProcessModel, DateTime.Now, VersionControl<ProjectModel>.generateID());

                documentModels.Add(documentModel);

                versionControl.DocumentModels = documentModels;

                string json = JsonConvert.SerializeObject(versionControl);
                JsonHelper.saveDocument(json, Settings.Default.ProjectID, "IssueManagementProcess");
                MessageBox.Show("Issue Management Process Document saved successfully", "save", MessageBoxButtons.OK);
            }

        }

        private void loadDocument()
        {
            string json = JsonHelper.loadDocument(Settings.Default.ProjectID, "IssueManagementProcess");
            List<string[]> documentInfo = new List<string[]>();
            newIssueManagementProcessModel = new IssueManagementProcessModel();
            currentIssueManagementProcessModel = new IssueManagementProcessModel();
            if (json != "")
            {
                versionControl = JsonConvert.DeserializeObject<VersionControl<IssueManagementProcessModel>>(json);
                newIssueManagementProcessModel = JsonConvert.DeserializeObject<IssueManagementProcessModel>(versionControl.getLatest(versionControl.DocumentModels));
                currentIssueManagementProcessModel = JsonConvert.DeserializeObject<IssueManagementProcessModel>(versionControl.getLatest(versionControl.DocumentModels));

                documentInfo.Add(new string[] { "Document ID", currentIssueManagementProcessModel.DocumentID });
                documentInfo.Add(new string[] { "Document Owner", currentIssueManagementProcessModel.DocumentOwner });
                documentInfo.Add(new string[] { "Issue Date", currentIssueManagementProcessModel.IssueDate });
                documentInfo.Add(new string[] { "Last Save Date", currentIssueManagementProcessModel.LastSavedDate });
                documentInfo.Add(new string[] { "File Name", currentIssueManagementProcessModel.FileName });

                foreach (var row in documentInfo)
                {
                    DocumentInfoGrid.Rows.Add(row);
                }
                DocumentInfoGrid.AllowUserToAddRows = false;

                foreach (var row in currentIssueManagementProcessModel.DocumentHistories)
                {
                    docHistDataGrid.Rows.Add(new string[] { row.Version, row.IssueDate, row.Changes });
                }

                foreach (var row in currentIssueManagementProcessModel.DocumentApprovals)
                {
                    docApprovalsDataGrid.Rows.Add(new string[] { row.Role, row.Name, "", row.DateApproved });
                }

                overviewTextBox.Text = currentIssueManagementProcessModel.Overview;
                raiseIssueLabel.Text = currentIssueManagementProcessModel.RaiseIssue;
                reviewIssueLabel.Text = currentIssueManagementProcessModel.ReviewIssue;
                assgnActTextBox.Text = currentIssueManagementProcessModel.IssueAction;
                textBox1.Text = currentIssueManagementProcessModel.TeamMember;
                textBox2.Text = currentIssueManagementProcessModel.ProjectManager;
                textBox3.Text = currentIssueManagementProcessModel.ProjectBoard;
                issueFormTextBox.Text = currentIssueManagementProcessModel.IssueForm;
                issueRegisterTextBox.Text = currentIssueManagementProcessModel.IssueRegister;
            }
            else
            {
                versionControl = new VersionControl<IssueManagementProcessModel>();
                versionControl.DocumentModels = new List<VersionControl<IssueManagementProcessModel>.DocumentModel>();
                documentInfo.Add(new string[] { "Document ID", "" });
                documentInfo.Add(new string[] { "Document Owner", "" });
                documentInfo.Add(new string[] { "Issue Date", "" });
                documentInfo.Add(new string[] { "Last Save Date", "" });
                documentInfo.Add(new string[] { "File Name", "" });
                newIssueManagementProcessModel = new IssueManagementProcessModel();
                foreach (var row in documentInfo)
                {
                    DocumentInfoGrid.Rows.Add(row);
                }
                DocumentInfoGrid.AllowUserToAddRows = false;

            }
        }
    }
}
