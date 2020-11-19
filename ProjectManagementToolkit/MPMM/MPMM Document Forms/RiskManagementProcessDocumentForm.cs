using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectManagementToolkit.MPMM.MPMM_Document_Models;
using ProjectManagementToolkit.Utility;
using ProjectManagementToolkit.Properties;
using Newtonsoft.Json;
using MoreLinq;

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Forms
{
    public partial class RiskManagementProcessDocumentForm : Form
    {
        VersionControl<RiskManagmentProcessModel> versionControl;
        RiskManagmentProcessModel newRiskManagmentProcessModel;
        RiskManagmentProcessModel currentRiskManagmentProcessModel;

        public RiskManagementProcessDocumentForm()
        {
            InitializeComponent();
        }

        private void RiskManagementProcessDocumentForm_Load(object sender, EventArgs e)
        {
            loadDocument();
        }

        private void loadDocument()
        {
        
            string json = JsonHelper.loadDocument(Settings.Default.ProjectID, "RiskManagamentProcess");
            List<string[]> documentInfo = new List<string[]>();
            newRiskManagmentProcessModel = new RiskManagmentProcessModel();
            currentRiskManagmentProcessModel = new RiskManagmentProcessModel();

            if (json != "")
            {
                newRiskManagmentProcessModel.DocumentID = dgvDocumentInformation.Rows[0].Cells[1].Value.ToString();
                newRiskManagmentProcessModel.DocumentOwner = dgvDocumentInformation.Rows[1].Cells[1].Value.ToString();
                newRiskManagmentProcessModel.IssueDate = dgvDocumentInformation.Rows[2].Cells[1].Value.ToString();
                newRiskManagmentProcessModel.LastSavedDate = dgvDocumentInformation.Rows[3].Cells[1].Value.ToString();
                newRiskManagmentProcessModel.FileName = dgvDocumentInformation.Rows[4].Cells[1].Value.ToString();

                List<RiskManagmentProcessModel.DocumentHistory> documentHistories = new List<RiskManagmentProcessModel.DocumentHistory>();

                int versionRowsCount = dgvDocumentHistory.Rows.Count;

                for (int i = 0; i < versionRowsCount - 1; i++)
                {
                    RiskManagmentProcessModel.DocumentHistory documentHistoryModel = new RiskManagmentProcessModel.DocumentHistory();
                    var version = dgvDocumentHistory.Rows[i].Cells[0].Value?.ToString() ?? "";
                    var issueDate = dgvDocumentHistory.Rows[i].Cells[1].Value?.ToString() ?? "";
                    var changes = dgvDocumentHistory.Rows[i].Cells[2].Value?.ToString() ?? "";
                    documentHistoryModel.Version = version;
                    documentHistoryModel.IssueDate = issueDate;
                    documentHistoryModel.Changes = changes;
                    documentHistories.Add(documentHistoryModel);
                }
                newRiskManagmentProcessModel.DocumentHistories = documentHistories;

                List<RiskManagmentProcessModel.DocumentApproval> documentApprovalsModel = new List<RiskManagmentProcessModel.DocumentApproval>();

                int approvalRowsCount = dgvDocumentApprovals.Rows.Count;

                for (int i = 0; i < approvalRowsCount - 1; i++)
                {
                    RiskManagmentProcessModel.DocumentApproval documentApproval = new RiskManagmentProcessModel.DocumentApproval();
                    var role = dgvDocumentApprovals.Rows[i].Cells[0].Value?.ToString() ?? "";
                    var name = dgvDocumentApprovals.Rows[i].Cells[1].Value?.ToString() ?? "";
                    var signature = dgvDocumentApprovals.Rows[i].Cells[2].Value?.ToString() ?? "";
                    var date = dgvDocumentApprovals.Rows[i].Cells[3].Value?.ToString() ?? "";
                    documentApproval.Role = role;
                    documentApproval.Name = name;
                    documentApproval.Signature = signature;
                    documentApproval.DateApproved = date;

                    documentApprovalsModel.Add(documentApproval);
                }
                newRiskManagmentProcessModel.DocumentApprovals = documentApprovalsModel;

                txtIdentifyRisk.Text = currentRiskManagmentProcessModel.IdentifyRisk;
                txtReviewRisk.Text = currentRiskManagmentProcessModel.ReviewRisk;
                txtAssignRiskActions.Text = currentRiskManagmentProcessModel.AssignRisk;

                txtTeamMember.Text = currentRiskManagmentProcessModel.TeamMember;
                txtProjectManager.Text = currentRiskManagmentProcessModel.ProjectManager;
                txtProjectBoard.Text = currentRiskManagmentProcessModel.ProjectBoard;

                txtRiskForm.Text = currentRiskManagmentProcessModel.RiskForm;
                txtRiskRegister.Text = currentRiskManagmentProcessModel.RiskRegister;
            }
            else
            {
                versionControl = new VersionControl<RiskManagmentProcessModel>();
                versionControl.DocumentModels = new List<VersionControl<RiskManagmentProcessModel>.DocumentModel>();
                documentInfo.Add(new string[] { "Document ID", "" });
                documentInfo.Add(new string[] { "Document Owner", "" });
                documentInfo.Add(new string[] { "Issue Date", "" });
                documentInfo.Add(new string[] { "Last Save Date", "" });
                documentInfo.Add(new string[] { "File Name", "" });
                newRiskManagmentProcessModel = new RiskManagmentProcessModel();
                foreach (var row in documentInfo)
                {
                    dgvDocumentInformation.Rows.Add(row);
                }
                dgvDocumentInformation.AllowUserToAddRows = false;
            }
        }
    }
}
