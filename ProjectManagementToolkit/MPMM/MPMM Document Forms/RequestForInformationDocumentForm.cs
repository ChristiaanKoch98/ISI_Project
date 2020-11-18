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
    public partial class RequestForInformationDocumentForm : Form
    {
        VersionControl<RequestForInformationModel> versionControl;
        RequestForInformationModel newRequestForInformationModel;
        RequestForInformationModel currentRequestForInformationModel;

        public RequestForInformationDocumentForm()
        {
            InitializeComponent();
        }

        private void btnSaveProjectNameRequestForInfo_Click(object sender, EventArgs e)
        {
            string ProjectName = txtProjectName.Text;
            SaveDocument();
        }

        private void RequestForInformationDocumentForm_Load(object sender, EventArgs e)
        {
            loadDocument();
        }

        private void btnSaveIntroductionInfo_Click(object sender, EventArgs e)
        {
            string OverviewIntroduction = txtOverview.Text;
            string Purpose = txtPurpose.Text;
            string Acknowledgment = txtAcknowledgement.Text;
            string Recipiants = txtRecipiants.Text;
            string Process = txtProcess.Text;
            string Rules = txtRules.Text;
            string Questions = txtQuestions.Text;
        }

        private void btnCompanyOverview_Click(object sender, EventArgs e)
        {
            string CompanyOverview = txtCompanyOverview.Text;
            listBoxCompanyOverview.Items.Add(txtCompanyOverview.Text);
        }

        private void btnCompanyOffering_Click(object sender, EventArgs e)
        {
            string CompanyOffering = txtCompanyOffering.Text;
            listBoxCompanyOffering.Items.Add(txtCompanyOffering.Text);
        }

        private void btnMethod_Click(object sender, EventArgs e)
        {
            string method = txtMethod.Text;
            listBoxMethods.Items.Add(txtMethod.Text);
        }

        private void btnTimeframes_Click(object sender, EventArgs e)
        {
            string timeframes = txtTimeframes.Text;
            listBoxTimeframes.Items.Add(txtTimeframes.Text);
        }

        private void btnPricing_Click(object sender, EventArgs e)
        {
            string pricing = txtPricing.Text;
            listBoxPricing.Items.Add(txtPricing.Text);
        }

        private void btnConfidentiality_Click(object sender, EventArgs e)
        {
            string confidentiality = txtConfidentiality.Text;
            listBoxConfidentiality.Items.Add(txtConfidentiality.Text);
        }

        private void btnDocumentation_Click(object sender, EventArgs e)
        {
            string documentation = txtDocumentation.Text;
            listBoxDocumentation.Items.Add(txtDocumentation.Text);
        }

        //Back-End
        public void SaveDocument()
        {
            newRequestForInformationModel.documentID = dataGridViewDocumentInformation.Rows[0].Cells[1].Value.ToString();
            newRequestForInformationModel.documentOwner = dataGridViewDocumentInformation.Rows[1].Cells[1].Value.ToString();
            newRequestForInformationModel.issueDate = dataGridViewDocumentInformation.Rows[2].Cells[1].Value.ToString();
            newRequestForInformationModel.lastSavedDate = dataGridViewDocumentInformation.Rows[3].Cells[1].Value.ToString();
            newRequestForInformationModel.fileName = dataGridViewDocumentInformation.Rows[4].Cells[1].Value.ToString();

            List<RequestForInformationModel.DocumentHistory> documentHistories = new List<RequestForInformationModel.DocumentHistory>();

            int versionRowCount = dataGridViewDocumentHistory.Rows.Count;

            for (int i = 0; i < versionRowCount; i++)
            {
                RequestForInformationModel.DocumentHistory documentHistory = new RequestForInformationModel.DocumentHistory();
                var tempVersion = dataGridViewDocumentHistory.Rows[i].Cells[0].Value?.ToString() ?? "";
                var tempIssueDate = dataGridViewDocumentHistory.Rows[i].Cells[1].Value?.ToString() ?? "";
                var tempChanges = dataGridViewDocumentHistory.Rows[i].Cells[2].Value?.ToString() ?? "";
                documentHistory.version = tempVersion;
                documentHistory.issueDate = tempIssueDate;
                documentHistory.changes = tempChanges;
                documentHistories.Add(documentHistory);
            }
            newRequestForInformationModel.documentHistories = documentHistories;

            List<RequestForInformationModel.DocumentApprovals> documentApprovals = new List<RequestForInformationModel.DocumentApprovals>();

            int approvalRowsCount = dataGridViewDocumentApprovals.Rows.Count;

            for (int i = 0; i < approvalRowsCount; i++)
            {
                RequestForInformationModel.DocumentApprovals documentApproval = new RequestForInformationModel.DocumentApprovals();
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
            newRequestForInformationModel.documentApprovals = documentApprovals;

            newRequestForInformationModel.introOverview = txtOverview.Text;
            newRequestForInformationModel.introPurpose = txtPurpose.Text;
            newRequestForInformationModel.introAcknowledgement = txtAcknowledgement.Text;
            newRequestForInformationModel.introRecipients = txtRecipiants.Text;
            newRequestForInformationModel.introProcess = txtProcess.Text;
            newRequestForInformationModel.introRules = txtRules.Text;
            newRequestForInformationModel.introQuestions = txtQuestions.Text;

            newRequestForInformationModel.companyOverview = ReadAllFromList(listBoxCompanyOverview);
            newRequestForInformationModel.companyOffering = ReadAllFromList(listBoxCompanyOffering);

            newRequestForInformationModel.approachMethod = ReadAllFromList(listBoxMethods);
            newRequestForInformationModel.approachTimeframes = ReadAllFromList(listBoxTimeframes);
            newRequestForInformationModel.approachPricing = ReadAllFromList(listBoxPricing);

            newRequestForInformationModel.otherConfidentiality = ReadAllFromList(listBoxConfidentiality);
            newRequestForInformationModel.otherDocumentation = ReadAllFromList(listBoxDocumentation);

            List<VersionControl<RequestForInformationModel>.DocumentModel> documentModels = versionControl.DocumentModels;

            if (!versionControl.isEqual(currentRequestForInformationModel, newRequestForInformationModel))
            {
                VersionControl<RequestForInformationModel>.DocumentModel documentModel = new VersionControl<RequestForInformationModel>.DocumentModel(newRequestForInformationModel, DateTime.Now, VersionControl<ProjectModel>.generateID());

                documentModels.Add(documentModel);
                versionControl.DocumentModels = documentModels;

                string json = JsonConvert.SerializeObject(versionControl);
                JsonHelper.saveDocument(json, Settings.Default.ProjectID, "AcceptancePlan");
                MessageBox.Show("Acceptance plan saved successfully", "save", MessageBoxButtons.OK);
            }
        }

        public void loadDocument()
        {
            string json = JsonHelper.loadDocument(Settings.Default.ProjectID, "AcceptancePlan");
            List<string[]> documentInfo = new List<string[]>();
            newRequestForInformationModel = new RequestForInformationModel();
            currentRequestForInformationModel = new RequestForInformationModel();
            if (json != "")
            {
                versionControl = JsonConvert.DeserializeObject<VersionControl<RequestForInformationModel>>(json);
                newRequestForInformationModel = JsonConvert.DeserializeObject<RequestForInformationModel>(versionControl.getLatest(versionControl.DocumentModels));
                currentRequestForInformationModel = JsonConvert.DeserializeObject<RequestForInformationModel>(versionControl.getLatest(versionControl.DocumentModels));

                documentInfo.Add(new string[] { "Document ID", currentRequestForInformationModel.documentID });
                documentInfo.Add(new string[] { "Document Owner", currentRequestForInformationModel.documentOwner });
                documentInfo.Add(new string[] { "Issue Date", currentRequestForInformationModel.issueDate });
                documentInfo.Add(new string[] { "Last Save Date", currentRequestForInformationModel.lastSavedDate });
                documentInfo.Add(new string[] { "File Name", currentRequestForInformationModel.fileName });

                foreach (var row in documentInfo)
                {
                    dataGridViewDocumentInformation.Rows.Add(row);
                }
                dataGridViewDocumentInformation.AllowUserToAddRows = false;

                foreach (var row in currentRequestForInformationModel.documentHistories)
                {
                    dataGridViewDocumentHistory.Rows.Add(new string[] { row.version, row.issueDate, row.changes });
                }

                foreach (var row in currentRequestForInformationModel.documentApprovals)
                {
                    dataGridViewDocumentApprovals.Rows.Add(new String[] { row.role, row.name, row.changes, row.date });
                }

                WriteAllToList(listBoxCompanyOverview, currentRequestForInformationModel.companyOverview);
                WriteAllToList(listBoxCompanyOffering, currentRequestForInformationModel.companyOffering);

                WriteAllToList(listBoxMethods, currentRequestForInformationModel.approachMethod);
                WriteAllToList(listBoxTimeframes, currentRequestForInformationModel.approachTimeframes);
                WriteAllToList(listBoxPricing, currentRequestForInformationModel.approachPricing);

                WriteAllToList(listBoxConfidentiality, currentRequestForInformationModel.otherConfidentiality);
                WriteAllToList(listBoxDocumentation, currentRequestForInformationModel.otherDocumentation);

                txtOverview.Text = currentRequestForInformationModel.introOverview;
                txtPurpose.Text = currentRequestForInformationModel.introPurpose;
                txtAcknowledgement.Text = currentRequestForInformationModel.introAcknowledgement;
                txtRecipiants.Text = currentRequestForInformationModel.introRecipients;
                txtProcess.Text = currentRequestForInformationModel.introProcess;
                txtRules.Text = currentRequestForInformationModel.introRules;
                txtQuestions.Text = currentRequestForInformationModel.introQuestions;
            }
            else
            {
                versionControl = new VersionControl<RequestForInformationModel>();
                versionControl.DocumentModels = new List<VersionControl<RequestForInformationModel>.DocumentModel>();
                documentInfo.Add(new string[] { "Document ID", "" });
                documentInfo.Add(new string[] { "Document Owner", "" });
                documentInfo.Add(new string[] { "Issue Date", "" });
                documentInfo.Add(new string[] { "Last Save Date", "" });
                documentInfo.Add(new string[] { "File Name", "" });
                newRequestForInformationModel = new RequestForInformationModel();
                foreach (var row in documentInfo)
                {
                    dataGridViewDocumentInformation.Rows.Add(row);
                }
                dataGridViewDocumentInformation.AllowUserToAddRows = false;
            }
        }

        List<string> ReadAllFromList(ListBox listBox)
        {
            List<string> tempList = new List<string>();
            foreach (var li in listBox.Items)
            {
                tempList.Add(li.ToString());
            }

            return tempList;
        }

        void WriteAllToList(ListBox listBox, List<string> items)
        {
            listBox.Items.Clear();

            if (items == null)
            {
                return;
            }

            foreach (string item in items)
            {
                listBox.Items.Add(item);
            }
        }
    }
}
