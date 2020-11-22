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
    public partial class CommunicationsPlanDocumentForm : Form
    {
        VersionControl<CommunicationsPlanModel> versionControl;
        CommunicationsPlanModel newCommunicationsPlanModel;
        CommunicationsPlanModel currentCommunicationsPlanModel;

        public CommunicationsPlanDocumentForm()
        {
            InitializeComponent();
        }

        private void txtStakeholderList_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtScope_TextChanged(object sender, EventArgs e)
        {

        }

        private void CommunicationsPlanDocumentForm_Load(object sender, EventArgs e)
        {
            loadDocument();
        }

        private void loadDocument()
        {
            string json = JsonHelper.loadDocument(Settings.Default.ProjectID, "Communications Plan");
            List<string[]> documentInfo = new List<string[]>();
            newCommunicationsPlanModel = new CommunicationsPlanModel();
            currentCommunicationsPlanModel = new CommunicationsPlanModel();

            if (json != "")
            {
                versionControl = JsonConvert.DeserializeObject<VersionControl<CommunicationsPlanModel>>(json);
                newCommunicationsPlanModel = JsonConvert.DeserializeObject<CommunicationsPlanModel>(versionControl.getLatest(versionControl.DocumentModels));
                currentCommunicationsPlanModel = JsonConvert.DeserializeObject<CommunicationsPlanModel>(versionControl.getLatest(versionControl.DocumentModels));

                documentInfo.Add(new string[] { "Document ID", currentCommunicationsPlanModel.DocumentID });
                documentInfo.Add(new string[] { "Document Owner", currentCommunicationsPlanModel.DocumentOwner });
                documentInfo.Add(new string[] { "Issue Date", currentCommunicationsPlanModel.IssueDate });
                documentInfo.Add(new string[] { "Last Save Date", currentCommunicationsPlanModel.LastSavedDate });
                documentInfo.Add(new string[] { "File Name", currentCommunicationsPlanModel.FileName });

                foreach (var row in documentInfo)
                {
                    dgvDocumentInformation.Rows.Add(row);
                }
                dgvDocumentInformation.AllowUserToAddRows = false;

                foreach (var row in currentCommunicationsPlanModel.DocumentHistories)
                {
                    dgvDocumentHistory.Rows.Add(new string[] { row.Version, row.IssueDate, row.Changes });
                }

                foreach (var row in currentCommunicationsPlanModel.DocumentApprovals)
                {
                    dgvDocumentApprovals.Rows.Add(new string[] { row.Role, row.Name, "", row.DateApproved });
                }

                
                txtActivities.Text = currentCommunicationsPlanModel.Activities;
                txtCommunicationsProcess.Text = currentCommunicationsPlanModel.ComProcess;
                txtRoles.Text = currentCommunicationsPlanModel.Roles;
                txtDocuments.Text = currentCommunicationsPlanModel.Documents;
            }
            else
            {
                versionControl = new VersionControl<CommunicationsPlanModel>();
                versionControl.DocumentModels = new List<VersionControl<CommunicationsPlanModel>.DocumentModel>();
                documentInfo.Add(new string[] { "Document ID", "" });
                documentInfo.Add(new string[] { "Document Owner", "" });
                documentInfo.Add(new string[] { "Issue Date", "" });
                documentInfo.Add(new string[] { "Last Save Date", "" });
                documentInfo.Add(new string[] { "File Name", "" });
                newCommunicationsPlanModel = new CommunicationsPlanModel();
                foreach (var row in documentInfo)
                {
                    dgvDocumentInformation.Rows.Add(row);
                }
                dgvDocumentInformation.AllowUserToAddRows = false;
            }
        }

        private void saveDocument()
        {
            newCommunicationsPlanModel.DocumentID = dgvDocumentInformation.Rows[0].Cells[1].Value.ToString();
            newCommunicationsPlanModel.DocumentOwner = dgvDocumentInformation.Rows[1].Cells[1].Value.ToString();
            newCommunicationsPlanModel.IssueDate = dgvDocumentInformation.Rows[2].Cells[1].Value.ToString();
            newCommunicationsPlanModel.LastSavedDate = dgvDocumentInformation.Rows[3].Cells[1].Value.ToString();
            newCommunicationsPlanModel.FileName = dgvDocumentInformation.Rows[4].Cells[1].Value.ToString();

            List<CommunicationsPlanModel.DocumentHistory> documentHistories = new List<CommunicationsPlanModel.DocumentHistory>();

            int versionRowsCount = dgvDocumentHistory.Rows.Count;

            for (int i = 0; i < versionRowsCount - 1; i++)
            {
                CommunicationsPlanModel.DocumentHistory documentHistoryModel = new CommunicationsPlanModel.DocumentHistory();
                var version = dgvDocumentHistory.Rows[i].Cells[0].Value?.ToString() ?? "";
                var issueDate = dgvDocumentHistory.Rows[i].Cells[1].Value?.ToString() ?? "";
                var changes = dgvDocumentHistory.Rows[i].Cells[2].Value?.ToString() ?? "";
                documentHistoryModel.Version = version;
                documentHistoryModel.IssueDate = issueDate;
                documentHistoryModel.Changes = changes;
                documentHistories.Add(documentHistoryModel);
            }
            newCommunicationsPlanModel.DocumentHistories = documentHistories;

            List<CommunicationsPlanModel.DocumentApproval> documentApprovalsModel = new List<CommunicationsPlanModel.DocumentApproval>();

            int approvalRowsCount = dgvDocumentApprovals.Rows.Count;

            for (int i = 0; i < approvalRowsCount - 1; i++)
            {
                CommunicationsPlanModel.DocumentApproval documentApproval = new CommunicationsPlanModel.DocumentApproval();
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
            newCommunicationsPlanModel.DocumentApprovals = documentApprovalsModel;

            List<CommunicationsPlanModel.Stakeholder> Stake = new List<CommunicationsPlanModel.Stakeholder>();

            int stakeRowsCount = dgvStakeholderRequirements.Rows.Count;

            for (int i = 0; i < stakeRowsCount - 1; i++)
            {
                CommunicationsPlanModel.Stakeholder Stakereq = new CommunicationsPlanModel.Stakeholder();
                var StakeName = dgvStakeholderRequirements.Rows[i].Cells[0].Value?.ToString() ?? "";
                var StakeRole = dgvStakeholderRequirements.Rows[i].Cells[1].Value?.ToString() ?? "";
                var Organization = dgvStakeholderRequirements.Rows[i].Cells[2].Value?.ToString() ?? "";
                var Requirement = dgvStakeholderRequirements.Rows[i].Cells[2].Value?.ToString() ?? "";

                Stakereq.StakeholderName = StakeName;
                Stakereq.StakeholderRole = StakeRole;
                Stakereq.StakeholderOrganization = Organization;
                Stakereq.InformationRequirement = Requirement;

                Stake.Add(Stakereq);
            }
            newCommunicationsPlanModel.StakeholderReq = Stake;

            newCommunicationsPlanModel.Activities = txtActivities.Text;
            newCommunicationsPlanModel.ComProcess = txtCommunicationsProcess.Text;
            newCommunicationsPlanModel.Roles = txtRoles.Text;
            newCommunicationsPlanModel.Documents = txtDocuments.Text;

        }
    }
}
