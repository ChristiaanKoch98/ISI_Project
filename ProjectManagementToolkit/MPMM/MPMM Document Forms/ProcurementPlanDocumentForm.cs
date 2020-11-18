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
    public partial class ProcurementPlanDocumentForm : Form
    {
        VersionControl<ProcurementPlanModel> versionControl;
        ProcurementPlanModel newProcurementPlanModel;
        ProcurementPlanModel currentProcurementPlanModel;

        public ProcurementPlanDocumentForm()
        {
            InitializeComponent();
        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ProcurementPlanDocumentForm_Load(object sender, EventArgs e)
        {
            loadDocument();
        }

        private void btnAddAssumptions_Click(object sender, EventArgs e)
        {
            string addAssumptions = txtAssumptions.Text;
            listBoxAssumptions.Items.Add(addAssumptions);
        }

        private void btnAddConstraints_Click(object sender, EventArgs e)
        {
            string addConstraints = txtConstraints.Text;
            listBoxConstraints.Items.Add(addConstraints);
        }

        private void btnTenderActivities_Click(object sender, EventArgs e)
        {
            string tenderActivities = txtTenderActivities.Text;
            listBoxTenderActivities.Items.Add(tenderActivities);
        }

        private void btnTenderRoles_Click(object sender, EventArgs e)
        {
            string tenderRoles = txtTenderRoles.Text;
            listBoxTenderRoles.Items.Add(tenderRoles);
        }

        private void btnTenderDocuments_Click(object sender, EventArgs e)
        {
            string tenderDocuments = txtTenderDocuments.Text;
            listBoxTenderDocuments.Items.Add(tenderDocuments);
        }

        private void btnProcessActivities_Click(object sender, EventArgs e)
        {
            string processActivities = txtProcessActivities.Text;
            listBoxProcessActivities.Items.Add(processActivities);
        }

        private void btnProcessRoles_Click(object sender, EventArgs e)
        {
            string processRoles = txtProcessRoles.Text;
            listBoxProcessRoles.Items.Add(processRoles);
        }

        private void btnProcessDocuments_Click(object sender, EventArgs e)
        {
            string processDocuments = txtProcessDocuments.Text;
            listBoxProcessDocuments.Items.Add(processDocuments);
        }

        private void btnSaveProjectName_Click(object sender, EventArgs e)
        {
            SaveDocument();
        }

        public void SaveDocument()
        {
            newProcurementPlanModel.documentID = dataGridViewDocumentInformation.Rows[0].Cells[1].Value.ToString();
            newProcurementPlanModel.documentOwner = dataGridViewDocumentInformation.Rows[1].Cells[1].Value.ToString();
            newProcurementPlanModel.issueDate = dataGridViewDocumentInformation.Rows[2].Cells[1].Value.ToString();
            newProcurementPlanModel.lastSavedDate = dataGridViewDocumentInformation.Rows[3].Cells[1].Value.ToString();
            newProcurementPlanModel.fileName = dataGridViewDocumentInformation.Rows[4].Cells[1].Value.ToString();

            List<ProcurementPlanModel.DocumentHistory> documentHistories = new List<ProcurementPlanModel.DocumentHistory>();

            int versionRowCount = dataGridViewDocumentHistory.Rows.Count;

            for (int i = 0; i < versionRowCount; i++)
            {
                ProcurementPlanModel.DocumentHistory documentHistory = new ProcurementPlanModel.DocumentHistory();
                var tempVersion = dataGridViewDocumentHistory.Rows[i].Cells[0].Value?.ToString() ?? "";
                var tempIssueDate = dataGridViewDocumentHistory.Rows[i].Cells[1].Value?.ToString() ?? "";
                var tempChanges = dataGridViewDocumentHistory.Rows[i].Cells[2].Value?.ToString() ?? "";
                documentHistory.version = tempVersion;
                documentHistory.issueDate = tempIssueDate;
                documentHistory.changes = tempChanges;
                documentHistories.Add(documentHistory);
            }
            newProcurementPlanModel.documentHistories = documentHistories;

            List<ProcurementPlanModel.DocumentApprovals> documentApprovals = new List<ProcurementPlanModel.DocumentApprovals>();

            int approvalRowsCount = dataGridViewDocumentApprovals.Rows.Count;

            for (int i = 0; i < approvalRowsCount; i++)
            {
                ProcurementPlanModel.DocumentApprovals documentApproval = new ProcurementPlanModel.DocumentApprovals();
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
            newProcurementPlanModel.documentApprovals = documentApprovals;

            List<ProcurementPlanModel.DocumentRequirements> documentRequirements = new List<ProcurementPlanModel.DocumentRequirements>();

            int requirementsCount = dataGridViewRequirements.Rows.Count;

            for (int i = 0; i < requirementsCount; i++)
            {
                ProcurementPlanModel.DocumentRequirements documentRequirement = new ProcurementPlanModel.DocumentRequirements();
                var tempItem = dataGridViewRequirements.Rows[i].Cells[0].Value?.ToString() ?? "";
                var tempDescription = dataGridViewRequirements.Rows[i].Cells[1].Value?.ToString() ?? "";
                var tempJustification = dataGridViewRequirements.Rows[i].Cells[2].Value?.ToString() ?? "";
                var tempQuantity = dataGridViewRequirements.Rows[i].Cells[3].Value?.ToString() ?? "";
                var tempBudget = dataGridViewRequirements.Rows[i].Cells[4].Value?.ToString() ?? "";
                documentRequirement.item = tempItem;
                documentRequirement.description = tempDescription;
                documentRequirement.justification = tempJustification;
                documentRequirement.quantity = tempQuantity;
                documentRequirement.budget = tempBudget;

                documentRequirements.Add(documentRequirement);
            }
            newProcurementPlanModel.documentRequirements = documentRequirements;

            List<ProcurementPlanModel.DocumentMarketResearch> documentMarketResearches = new List<ProcurementPlanModel.DocumentMarketResearch>();

            int researchCount = dataGridViewMarketResearch.Rows.Count;

            for (int i = 0; i < researchCount; i++)
            {
                ProcurementPlanModel.DocumentMarketResearch documentMarketResearch = new ProcurementPlanModel.DocumentMarketResearch();
                var tempItem = dataGridViewMarketResearch.Rows[i].Cells[0].Value?.ToString() ?? "";
                var tempSupplier = dataGridViewMarketResearch.Rows[i].Cells[1].Value?.ToString() ?? "";
                var tempOffering = dataGridViewMarketResearch.Rows[i].Cells[2].Value?.ToString() ?? "";
                var tempPrice = dataGridViewMarketResearch.Rows[i].Cells[3].Value?.ToString() ?? "";
                var tempAvailability = dataGridViewMarketResearch.Rows[i].Cells[4].Value?.ToString() ?? "";
                documentMarketResearch.item = tempItem;
                documentMarketResearch.supplier = tempSupplier;
                documentMarketResearch.offering = tempOffering;
                documentMarketResearch.price = tempPrice;
                documentMarketResearch.availability = tempAvailability;

                documentMarketResearches.Add(documentMarketResearch);
            }
            newProcurementPlanModel.documentMarketResearch = documentMarketResearches;

            newProcurementPlanModel.assumptions = ReadAllFromList(listBoxAssumptions);
            newProcurementPlanModel.constraints = ReadAllFromList(listBoxConstraints);

            newProcurementPlanModel.tenderActivities = ReadAllFromList(listBoxTenderActivities);
            newProcurementPlanModel.tenderRoles = ReadAllFromList(listBoxTenderRoles);
            newProcurementPlanModel.tenderDocuments = ReadAllFromList(listBoxTenderDocuments);

            newProcurementPlanModel.procurementActivities = ReadAllFromList(listBoxProcessActivities);
            newProcurementPlanModel.procurementRoles = ReadAllFromList(listBoxProcessRoles);
            newProcurementPlanModel.procurementDocuments = ReadAllFromList(listBoxProcessDocuments);

            List<VersionControl<ProcurementPlanModel>.DocumentModel> documentModels = versionControl.DocumentModels;

            if (!versionControl.isEqual(currentProcurementPlanModel, newProcurementPlanModel))
            {
                VersionControl<ProcurementPlanModel>.DocumentModel documentModel = new VersionControl<ProcurementPlanModel>.DocumentModel(newProcurementPlanModel, DateTime.Now, VersionControl<ProjectModel>.generateID());

                documentModels.Add(documentModel);
                versionControl.DocumentModels = documentModels;

                string json = JsonConvert.SerializeObject(versionControl);
                JsonHelper.saveDocument(json, Settings.Default.ProjectID, "ProcurementPlan");
                MessageBox.Show("Procurement Plan saved successfully", "save", MessageBoxButtons.OK);
            }
        }

        public void loadDocument()
        {
            string json = JsonHelper.loadDocument(Settings.Default.ProjectID, "ProcurementPlan");
            List<string[]> documentInfo = new List<string[]>();
            newProcurementPlanModel = new ProcurementPlanModel();
            currentProcurementPlanModel = new ProcurementPlanModel();
            if (json != "")
            {
                versionControl = JsonConvert.DeserializeObject<VersionControl<ProcurementPlanModel>>(json);
                newProcurementPlanModel = JsonConvert.DeserializeObject<ProcurementPlanModel>(versionControl.getLatest(versionControl.DocumentModels));
                currentProcurementPlanModel = JsonConvert.DeserializeObject<ProcurementPlanModel>(versionControl.getLatest(versionControl.DocumentModels));

                documentInfo.Add(new string[] { "Document ID", currentProcurementPlanModel.documentID });
                documentInfo.Add(new string[] { "Document Owner", currentProcurementPlanModel.documentOwner });
                documentInfo.Add(new string[] { "Issue Date", currentProcurementPlanModel.issueDate });
                documentInfo.Add(new string[] { "Last Save Date", currentProcurementPlanModel.lastSavedDate });
                documentInfo.Add(new string[] { "File Name", currentProcurementPlanModel.fileName });

                foreach (var row in documentInfo)
                {
                    dataGridViewDocumentInformation.Rows.Add(row);
                }
                dataGridViewDocumentInformation.AllowUserToAddRows = false;

                foreach (var row in currentProcurementPlanModel.documentHistories)
                {
                    dataGridViewDocumentHistory.Rows.Add(new string[] { row.version, row.issueDate, row.changes });
                }

                foreach (var row in currentProcurementPlanModel.documentApprovals)
                {
                    dataGridViewDocumentApprovals.Rows.Add(new String[] { row.role, row.name, row.changes, row.date });
                }

                foreach (var row in currentProcurementPlanModel.documentRequirements)
                {
                    dataGridViewRequirements.Rows.Add(new String[] { row.item, row.description, row.justification, row.quantity, row.budget });
                }

                foreach (var row in currentProcurementPlanModel.documentMarketResearch)
                {
                    dataGridViewMarketResearch.Rows.Add(new String[] { row.item, row.supplier, row.offering, row.price, row.availability });
                }

                WriteAllToList(listBoxAssumptions, currentProcurementPlanModel.assumptions);
                WriteAllToList(listBoxConstraints, currentProcurementPlanModel.constraints);

                WriteAllToList(listBoxTenderActivities, currentProcurementPlanModel.tenderActivities);
                WriteAllToList(listBoxTenderRoles, currentProcurementPlanModel.tenderRoles);
                WriteAllToList(listBoxTenderDocuments, currentProcurementPlanModel.tenderDocuments);

                WriteAllToList(listBoxProcessActivities, currentProcurementPlanModel.procurementActivities);
                WriteAllToList(listBoxProcessRoles, currentProcurementPlanModel.procurementRoles);
                WriteAllToList(listBoxProcessDocuments, currentProcurementPlanModel.procurementDocuments);
            }
            else
            {
                versionControl = new VersionControl<ProcurementPlanModel>();
                versionControl.DocumentModels = new List<VersionControl<ProcurementPlanModel>.DocumentModel>();
                documentInfo.Add(new string[] { "Document ID", "" });
                documentInfo.Add(new string[] { "Document Owner", "" });
                documentInfo.Add(new string[] { "Issue Date", "" });
                documentInfo.Add(new string[] { "Last Save Date", "" });
                documentInfo.Add(new string[] { "File Name", "" });
                newProcurementPlanModel = new ProcurementPlanModel();
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
