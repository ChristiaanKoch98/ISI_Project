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
    public partial class TermOfReferenceDocumentForm : Form
    {
        VersionControl<TermsOfReferenceModel> versionControl;
        TermsOfReferenceModel newTermsOfReferenceModel;
        TermsOfReferenceModel currentTermsOfReferenceModel;

        public TermOfReferenceDocumentForm()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void tabAppendix_Click(object sender, EventArgs e)
        {

        }

        private void TermOfReferenceDocumentForm_Load(object sender, EventArgs e)
        {
            loadDocument();
        }

        private void loadDocument()
        {
            string json = JsonHelper.loadDocument(Settings.Default.ProjectID, "TermsOfReference");
            List<string[]> documentInfo = new List<string[]>();
            newTermsOfReferenceModel = new TermsOfReferenceModel();
            currentTermsOfReferenceModel = new TermsOfReferenceModel();

            if (json != "")
            {
                newTermsOfReferenceModel.DocumentID = dgvDocumentInformation.Rows[0].Cells[1].Value.ToString();
                newTermsOfReferenceModel.DocumentOwner = dgvDocumentInformation.Rows[1].Cells[1].Value.ToString();
                newTermsOfReferenceModel.IssueDate = dgvDocumentInformation.Rows[2].Cells[1].Value.ToString();
                newTermsOfReferenceModel.LastSavedDate = dgvDocumentInformation.Rows[3].Cells[1].Value.ToString();
                newTermsOfReferenceModel.FileName = dgvDocumentInformation.Rows[4].Cells[1].Value.ToString();

                List<TermsOfReferenceModel.DocumentHistory> documentHistories = new List<TermsOfReferenceModel.DocumentHistory>();

                int versionRowsCount = dgvDocumentHistory.Rows.Count;

                for (int i = 0; i < versionRowsCount - 1; i++)
                {
                    TermsOfReferenceModel.DocumentHistory documentHistoryModel = new TermsOfReferenceModel.DocumentHistory();
                    var version = dgvDocumentHistory.Rows[i].Cells[0].Value?.ToString() ?? "";
                    var issueDate = dgvDocumentHistory.Rows[i].Cells[1].Value?.ToString() ?? "";
                    var changes = dgvDocumentHistory.Rows[i].Cells[2].Value?.ToString() ?? "";
                    documentHistoryModel.Version = version;
                    documentHistoryModel.IssueDate = issueDate;
                    documentHistoryModel.Changes = changes;
                    documentHistories.Add(documentHistoryModel);
                }
                newTermsOfReferenceModel.DocumentHistories = documentHistories;

                List<TermsOfReferenceModel.DocumentApproval> documentApprovalsModel = new List<TermsOfReferenceModel.DocumentApproval>();

                int approvalRowsCount = dgvDocumentApprovals.Rows.Count;

                for (int i = 0; i < approvalRowsCount - 1; i++)
                {
                    TermsOfReferenceModel.DocumentApproval documentApproval = new TermsOfReferenceModel.DocumentApproval();
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
                newTermsOfReferenceModel.DocumentApprovals = documentApprovalsModel;

                txtExecutiveSummary.Text = currentTermsOfReferenceModel.ExecutiveSummary;

                txtProjectDefinition.Text = currentTermsOfReferenceModel.ProjDefinition;
                txtVision.Text = currentTermsOfReferenceModel.Vision;
                txtObjectives.Text = currentTermsOfReferenceModel.Objectives;
                txtScope.Text = currentTermsOfReferenceModel.Scope;

                txtResponsibilities.Text = currentTermsOfReferenceModel.Responsibilities;
                txtStructure.Text = currentTermsOfReferenceModel.Structure;

                txtSchedule.Text = currentTermsOfReferenceModel.Schedule;

                txtAssumptions.Text = currentTermsOfReferenceModel.Assumptions;
                txtConstraints.Text = currentTermsOfReferenceModel.Constraints;

            }
            else
            {
                versionControl = new VersionControl<TermsOfReferenceModel>();
                versionControl.DocumentModels = new List<VersionControl<TermsOfReferenceModel>.DocumentModel>();
                documentInfo.Add(new string[] { "Document ID", "" });
                documentInfo.Add(new string[] { "Document Owner", "" });
                documentInfo.Add(new string[] { "Issue Date", "" });
                documentInfo.Add(new string[] { "Last Save Date", "" });
                documentInfo.Add(new string[] { "File Name", "" });
                newTermsOfReferenceModel = new TermsOfReferenceModel();
                foreach (var row in documentInfo)
                {
                    dgvDocumentInformation.Rows.Add(row);
                }
                dgvDocumentInformation.AllowUserToAddRows = false;
            }
        }
    }
}
