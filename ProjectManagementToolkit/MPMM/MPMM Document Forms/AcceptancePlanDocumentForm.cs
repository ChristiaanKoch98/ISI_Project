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
    public partial class AcceptancePlanDocumentForm : Form
    {
        VersionControl<AcceptancePlanModel> versionControl;
        AcceptancePlanModel newAcceptancePlanModel;
        AcceptancePlanModel currentAcceptancePlanModel;

        public AcceptancePlanDocumentForm()
        {
            InitializeComponent();
        }

        private void AcceptancePlanDocumentForm_Load(object sender, EventArgs e)
        {
            loadDocument();
        }

        private void btnSaveProjectName_Click(object sender, EventArgs e)
        {
            string projectName = txtProjectName.Text;
            SaveDocument();
        }

        private void btnCompanyOverview_Click(object sender, EventArgs e)
        {
            string addAssumptions = txtAssumptions.Text;
            listBoxAssumptions.Items.Add(addAssumptions);
        }

        private void btnConstraints_Click(object sender, EventArgs e)
        {
            string addConstraints = txtConstraints.Text;
            listBoxConstraints.Items.Add(addConstraints);
        }

        private void btnActivities_Click(object sender, EventArgs e)
        {
            string activities = txtActivities.Text;
            listBoxActivities.Items.Add(activities);
        }

        private void btnRoles_Click(object sender, EventArgs e)
        {
            string roles = txtRoles.Text;
            listBoxRoles.Items.Add(roles);
        }

        private void btnDocuments_Click(object sender, EventArgs e)
        {
            string documents = txtDocuments.Text;
            listBoxDocuments.Items.Add(documents);
        }


        //Back-End
        public void SaveDocument()
        {
            newAcceptancePlanModel.documentID = dataGridViewDocumentInformation.Rows[0].Cells[1].Value.ToString();
            newAcceptancePlanModel.documentOwner = dataGridViewDocumentInformation.Rows[1].Cells[1].Value.ToString();
            newAcceptancePlanModel.issueDate = dataGridViewDocumentInformation.Rows[2].Cells[1].Value.ToString();
            newAcceptancePlanModel.lastSavedDate = dataGridViewDocumentInformation.Rows[3].Cells[1].Value.ToString();
            newAcceptancePlanModel.fileName = dataGridViewDocumentInformation.Rows[4].Cells[1].Value.ToString();

            List<AcceptancePlanModel.DocumentHistory> documentHistories = new List<AcceptancePlanModel.DocumentHistory>();

            int versionRowCount = dataGridViewDocumentHistory.Rows.Count;

            for (int i = 0; i < versionRowCount; i++)
            {
                AcceptancePlanModel.DocumentHistory documentHistory = new AcceptancePlanModel.DocumentHistory();
                var tempVersion = dataGridViewDocumentHistory.Rows[i].Cells[0].Value?.ToString() ?? "";
                var tempIssueDate = dataGridViewDocumentHistory.Rows[i].Cells[1].Value?.ToString() ?? "";
                var tempChanges = dataGridViewDocumentHistory.Rows[i].Cells[2].Value?.ToString() ?? "";
                documentHistory.version = tempVersion;
                documentHistory.issueDate = tempIssueDate;
                documentHistory.changes = tempChanges;
                documentHistories.Add(documentHistory);
            }
            newAcceptancePlanModel.documentHistories = documentHistories;

            List<AcceptancePlanModel.DocumentApprovals> documentApprovals = new List<AcceptancePlanModel.DocumentApprovals>();

            int approvalRowsCount = dataGridViewDocumentApprovals.Rows.Count;

            for (int i = 0; i < approvalRowsCount; i++)
            {
                AcceptancePlanModel.DocumentApprovals documentApproval = new AcceptancePlanModel.DocumentApprovals();
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
            newAcceptancePlanModel.documentApprovals = documentApprovals;

            List<AcceptancePlanModel.DocumentMilestones> documentMilestones = new List<AcceptancePlanModel.DocumentMilestones>();

            int milstonesRowCount = dataGridViewMilestones.Rows.Count;

            for (int i = 0; i < milstonesRowCount; i++)
            {
                AcceptancePlanModel.DocumentMilestones documentMilestone = new AcceptancePlanModel.DocumentMilestones();
                var tempName = dataGridViewMilestones.Rows[i].Cells[0].Value?.ToString() ?? "";
                var tempDesc = dataGridViewMilestones.Rows[i].Cells[1].Value?.ToString() ?? "";
                var tempDate = dataGridViewMilestones.Rows[i].Cells[2].Value?.ToString() ?? "";
                documentMilestone.name = tempName;
                documentMilestone.description = tempDesc;
                documentMilestone.date = tempDate;

                documentMilestones.Add(documentMilestone);
            }
            newAcceptancePlanModel.documentMilestones = documentMilestones;

            List<AcceptancePlanModel.DocumentCriteria> documentCriterias = new List<AcceptancePlanModel.DocumentCriteria>();

            int criteriaRowCount = dataGridViewCriteria.Rows.Count;

            for (int i = 0; i < criteriaRowCount; i++)
            {
                AcceptancePlanModel.DocumentCriteria documentCriteria = new AcceptancePlanModel.DocumentCriteria();
                var tempName = dataGridViewCriteria.Rows[i].Cells[0].Value?.ToString() ?? "";
                var tempCrit = dataGridViewCriteria.Rows[i].Cells[1].Value?.ToString() ?? "";
                var tempAccStand = dataGridViewCriteria.Rows[i].Cells[2].Value?.ToString() ?? "";
                documentCriteria.name = tempName;
                documentCriteria.criteria = tempCrit;
                documentCriteria.acceptanceStandards = tempAccStand;

                documentCriterias.Add(documentCriteria);
            }
            newAcceptancePlanModel.documentCriterias = documentCriterias;

            List<AcceptancePlanModel.DocumentSchedule> documentSchedules = new List<AcceptancePlanModel.DocumentSchedule>();

            int scheduleRowCount = dataGridViewSchedule.Rows.Count;

            for (int i = 0; i < scheduleRowCount; i++)
            {
                AcceptancePlanModel.DocumentSchedule documentSchedule = new AcceptancePlanModel.DocumentSchedule();
                var tempMilestone = dataGridViewSchedule.Rows[i].Cells[0].Value?.ToString() ?? "";
                var tempDeliver = dataGridViewSchedule.Rows[i].Cells[1].Value?.ToString() ?? "";
                var tempMilestoneDate = dataGridViewSchedule.Rows[i].Cells[2].Value?.ToString() ?? "";
                var tempReviewMethod = dataGridViewSchedule.Rows[i].Cells[3].Value?.ToString() ?? "";
                var tempReviewers = dataGridViewSchedule.Rows[i].Cells[4].Value?.ToString() ?? "";
                var tempAcceptanceDate = dataGridViewSchedule.Rows[i].Cells[5].Value?.ToString() ?? "";
                documentSchedule.milestone = tempMilestone;
                documentSchedule.deliverables = tempDeliver;
                documentSchedule.milestoneDate = tempMilestoneDate;
                documentSchedule.reviewMethod = tempReviewMethod;
                documentSchedule.reviewers = tempReviewers;
                documentSchedule.acceptanceDate = tempAcceptanceDate;

                documentSchedules.Add(documentSchedule);
            }
            newAcceptancePlanModel.documentSchedules = documentSchedules;

            newAcceptancePlanModel.assumptions = listBoxAssumptions.Text;
            newAcceptancePlanModel.constraints = listBoxConstraints.Text;
            newAcceptancePlanModel.activites = listBoxActivities.Text;
            newAcceptancePlanModel.roles = listBoxRoles.Text;
            newAcceptancePlanModel.documents = listBoxDocuments.Text;

            List<VersionControl<AcceptancePlanModel>.DocumentModel> documentModels = versionControl.DocumentModels;

            if (!versionControl.isEqual(currentAcceptancePlanModel, newAcceptancePlanModel))
            {
                VersionControl<AcceptancePlanModel>.DocumentModel documentModel = new VersionControl<AcceptancePlanModel>.DocumentModel(newAcceptancePlanModel, DateTime.Now, VersionControl<ProjectModel>.generateID());

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
            newAcceptancePlanModel = new AcceptancePlanModel();
            currentAcceptancePlanModel = new AcceptancePlanModel();
            if (json != "")
            {
                versionControl = JsonConvert.DeserializeObject<VersionControl<AcceptancePlanModel>>(json);
                newAcceptancePlanModel = JsonConvert.DeserializeObject<AcceptancePlanModel>(versionControl.getLatest(versionControl.DocumentModels));
                currentAcceptancePlanModel = JsonConvert.DeserializeObject<AcceptancePlanModel>(versionControl.getLatest(versionControl.DocumentModels));

                documentInfo.Add(new string[] { "Document ID", currentAcceptancePlanModel.documentID });
                documentInfo.Add(new string[] { "Document Owner", currentAcceptancePlanModel.documentOwner });
                documentInfo.Add(new string[] { "Issue Date", currentAcceptancePlanModel.issueDate });
                documentInfo.Add(new string[] { "Last Save Date", currentAcceptancePlanModel.lastSavedDate });
                documentInfo.Add(new string[] { "File Name", currentAcceptancePlanModel.fileName });

                foreach (var row in documentInfo)
                {
                    dataGridViewDocumentInformation.Rows.Add(row);
                }
                dataGridViewDocumentInformation.AllowUserToAddRows = false;

                foreach (var row in currentAcceptancePlanModel.documentHistories)
                {
                    dataGridViewDocumentHistory.Rows.Add(row);
                }
                dataGridViewDocumentHistory.AllowUserToAddRows = false;

                foreach (var row in currentAcceptancePlanModel.documentApprovals)
                {
                    dataGridViewDocumentApprovals.Rows.Add(row);
                }
                dataGridViewDocumentApprovals.AllowUserToAddRows = false;

                foreach (var row in currentAcceptancePlanModel.documentMilestones)
                {
                    dataGridViewMilestones.Rows.Add(row);
                }
                dataGridViewMilestones.AllowUserToAddRows = false;

                foreach (var row in currentAcceptancePlanModel.documentCriterias)
                {
                    dataGridViewCriteria.Rows.Add(row);
                }
                dataGridViewCriteria.AllowUserToAddRows = false;

                foreach (var row in currentAcceptancePlanModel.documentSchedules)
                {
                    dataGridViewSchedule.Rows.Add(row);
                }
                dataGridViewSchedule.AllowUserToAddRows = false;

                listBoxActivities.Text = currentAcceptancePlanModel.activites;
                listBoxAssumptions.Text = currentAcceptancePlanModel.assumptions;
                listBoxConstraints.Text = currentAcceptancePlanModel.constraints;
                listBoxDocuments.Text = currentAcceptancePlanModel.documents;
                listBoxRoles.Text = currentAcceptancePlanModel.roles;
            }
            else
            {
                versionControl = new VersionControl<AcceptancePlanModel>();
                versionControl.DocumentModels = new List<VersionControl<AcceptancePlanModel>.DocumentModel>();
                documentInfo.Add(new string[] { "Document ID", "" });
                documentInfo.Add(new string[] { "Document Owner", "" });
                documentInfo.Add(new string[] { "Issue Date", "" });
                documentInfo.Add(new string[] { "Last Save Date", "" });
                documentInfo.Add(new string[] { "File Name", "" });
                newAcceptancePlanModel = new AcceptancePlanModel();
                foreach (var row in documentInfo)
                {
                    dataGridViewDocumentInformation.Rows.Add(row);
                }
                dataGridViewDocumentInformation.AllowUserToAddRows = false;
            }
        }
    }
}
