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
    public partial class QualityPlanDocumentForm : Form
    {
        VersionControl<QualityPlanModel> versionControl;
        QualityPlanModel newQualityPlanModel;
        QualityPlanModel currentQualityPlanModel;

        public QualityPlanDocumentForm()
        {
            InitializeComponent();
        }

        private void btnSaveProjectName_Click(object sender, EventArgs e)
        {
            string projectName = txtProjectName.Text;
            SaveDocument();
        }

        private void QualityPlanDocumentForm_Load(object sender, EventArgs e)
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

        private void btnQualityActivities_Click(object sender, EventArgs e)
        {
            string addQualityAct = txtQualityActivities.Text;
            listBoxQualityActivities.Items.Add(addQualityAct);
        }

        private void btnQualityRoles_Click(object sender, EventArgs e)
        {
            string addQualityRoles = txtQualityRoles.Text;
            listBoxQualityRoles.Items.Add(addQualityRoles);
        }

        private void btnQualityDocuments_Click(object sender, EventArgs e)
        {
            string addQualityDocs = txtQualityDocuments.Text;
            listBoxQualityDocuments.Items.Add(addQualityDocs);
        }

        //Back-End
        public void SaveDocument()
        {
            newQualityPlanModel.documentID = dataGridViewDocumentInformation.Rows[0].Cells[1].Value.ToString();
            newQualityPlanModel.documentOwner = dataGridViewDocumentInformation.Rows[1].Cells[1].Value.ToString();
            newQualityPlanModel.issueDate = dataGridViewDocumentInformation.Rows[2].Cells[1].Value.ToString();
            newQualityPlanModel.lastSavedDate = dataGridViewDocumentInformation.Rows[3].Cells[1].Value.ToString();
            newQualityPlanModel.fileName = dataGridViewDocumentInformation.Rows[4].Cells[1].Value.ToString();

            List<QualityPlanModel.DocumentHistory> documentHistories = new List<QualityPlanModel.DocumentHistory>();

            int versionRowCount = dataGridViewDocumentHistory.Rows.Count;

            for (int i = 0; i < versionRowCount; i++)
            {
                QualityPlanModel.DocumentHistory documentHistory = new QualityPlanModel.DocumentHistory();
                var tempVersion = dataGridViewDocumentHistory.Rows[i].Cells[0].Value?.ToString() ?? "";
                var tempIssueDate = dataGridViewDocumentHistory.Rows[i].Cells[1].Value?.ToString() ?? "";
                var tempChanges = dataGridViewDocumentHistory.Rows[i].Cells[2].Value?.ToString() ?? "";
                documentHistory.version = tempVersion;
                documentHistory.issueDate = tempIssueDate;
                documentHistory.changes = tempChanges;
                documentHistories.Add(documentHistory);
            }
            newQualityPlanModel.documentHistories = documentHistories;

            List<QualityPlanModel.DocumentApprovals> documentApprovals = new List<QualityPlanModel.DocumentApprovals>();

            int approvalRowsCount = dataGridViewDocumentApprovals.Rows.Count;

            for (int i = 0; i < approvalRowsCount; i++)
            {
                QualityPlanModel.DocumentApprovals documentApproval = new QualityPlanModel.DocumentApprovals();
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
            newQualityPlanModel.documentApprovals = documentApprovals;

            List<QualityPlanModel.DocumentQualityTargets> documentQualityTargets = new List<QualityPlanModel.DocumentQualityTargets>();

            int qualTargetCount = dataGridViewQualityTargets.Rows.Count;

            for (int i = 0; i < qualTargetCount; i++)
            {
                QualityPlanModel.DocumentQualityTargets documentQualityTarget = new QualityPlanModel.DocumentQualityTargets();
                var tempRequirements = dataGridViewQualityTargets.Rows[i].Cells[0].Value?.ToString() ?? "";
                var tempDeliverable = dataGridViewQualityTargets.Rows[i].Cells[1].Value?.ToString() ?? "";
                var tempCriteria = dataGridViewQualityTargets.Rows[i].Cells[2].Value?.ToString() ?? "";
                var tempStandards = dataGridViewQualityTargets.Rows[i].Cells[3].Value?.ToString() ?? "";
                documentQualityTarget.requirement = tempRequirements;
                documentQualityTarget.deliverable = tempDeliverable;
                documentQualityTarget.criteria = tempCriteria;
                documentQualityTarget.standards = tempStandards;

                documentQualityTargets.Add(documentQualityTarget);
            }
            newQualityPlanModel.documentQualityTargets = documentQualityTargets;

            List<QualityPlanModel.DocumentQualityAssurance> documentQualityAssurances = new List<QualityPlanModel.DocumentQualityAssurance>();

            int qualAssuranceCount = dataGridViewQAP.Rows.Count;

            for (int i = 0; i < qualAssuranceCount; i++)
            {
                QualityPlanModel.DocumentQualityAssurance documentQualityAssurance = new QualityPlanModel.DocumentQualityAssurance();
                var tempTechnique = dataGridViewQAP.Rows[i].Cells[0].Value?.ToString() ?? "";
                var tempDescription = dataGridViewQAP.Rows[i].Cells[1].Value?.ToString() ?? "";
                var tempFrequency = dataGridViewQAP.Rows[i].Cells[2].Value?.ToString() ?? "";
                documentQualityAssurance.technique = tempTechnique;
                documentQualityAssurance.description = tempDescription;
                documentQualityAssurance.frequency = tempFrequency;

                documentQualityAssurances.Add(documentQualityAssurance);
            }
            newQualityPlanModel.documentQualityAssurances = documentQualityAssurances;

            List<QualityPlanModel.DocumentQualityControl> documentQualityControls = new List<QualityPlanModel.DocumentQualityControl>();

            int qualControlCount = dataGridViewQCP.Rows.Count;

            for (int i = 0; i < qualControlCount; i++)
            {
                QualityPlanModel.DocumentQualityControl documentQualityControl = new QualityPlanModel.DocumentQualityControl();
                var tempTechnique = dataGridViewQCP.Rows[i].Cells[0].Value?.ToString() ?? "";
                var tempDescription = dataGridViewQCP.Rows[i].Cells[1].Value?.ToString() ?? "";
                var tempFrequency = dataGridViewQCP.Rows[i].Cells[2].Value?.ToString() ?? "";
                documentQualityControl.technique = tempTechnique;
                documentQualityControl.description = tempDescription;
                documentQualityControl.frequency = tempFrequency;

                documentQualityControls.Add(documentQualityControl);
            }
            newQualityPlanModel.documentQualityControls = documentQualityControls;

            newQualityPlanModel.assumptions = ReadAllFromList(listBoxAssumptions);
            newQualityPlanModel.constraints = ReadAllFromList(listBoxConstraints);

            newQualityPlanModel.activites = ReadAllFromList(listBoxQualityActivities);
            newQualityPlanModel.roles = ReadAllFromList(listBoxQualityRoles);
            newQualityPlanModel.documents = ReadAllFromList(listBoxQualityDocuments);

            List<VersionControl<QualityPlanModel>.DocumentModel> documentModels = versionControl.DocumentModels;

            if (!versionControl.isEqual(currentQualityPlanModel, newQualityPlanModel))
            {
                VersionControl<QualityPlanModel>.DocumentModel documentModel = new VersionControl<QualityPlanModel>.DocumentModel(newQualityPlanModel, DateTime.Now, VersionControl<ProjectModel>.generateID());

                documentModels.Add(documentModel);
                versionControl.DocumentModels = documentModels;

                string json = JsonConvert.SerializeObject(versionControl);
                JsonHelper.saveDocument(json, Settings.Default.ProjectID, "QualityPlan");
                MessageBox.Show("Quality plan saved successfully", "save", MessageBoxButtons.OK);
            }
        }

        public void loadDocument()
        {
            string json = JsonHelper.loadDocument(Settings.Default.ProjectID, "QualityPlan");
            List<string[]> documentInfo = new List<string[]>();
            newQualityPlanModel = new QualityPlanModel();
            currentQualityPlanModel = new QualityPlanModel();
            if (json != "")
            {
                versionControl = JsonConvert.DeserializeObject<VersionControl<QualityPlanModel>>(json);
                newQualityPlanModel = JsonConvert.DeserializeObject<QualityPlanModel>(versionControl.getLatest(versionControl.DocumentModels));
                currentQualityPlanModel = JsonConvert.DeserializeObject<QualityPlanModel>(versionControl.getLatest(versionControl.DocumentModels));

                documentInfo.Add(new string[] { "Document ID", currentQualityPlanModel.documentID });
                documentInfo.Add(new string[] { "Document Owner", currentQualityPlanModel.documentOwner });
                documentInfo.Add(new string[] { "Issue Date", currentQualityPlanModel.issueDate });
                documentInfo.Add(new string[] { "Last Save Date", currentQualityPlanModel.lastSavedDate });
                documentInfo.Add(new string[] { "File Name", currentQualityPlanModel.fileName });

                foreach (var row in documentInfo)
                {
                    dataGridViewDocumentInformation.Rows.Add(row);
                }
                dataGridViewDocumentInformation.AllowUserToAddRows = false;

                foreach (var row in currentQualityPlanModel.documentHistories)
                {
                    dataGridViewDocumentHistory.Rows.Add(new string[] { row.version, row.issueDate, row.changes });
                }

                foreach (var row in currentQualityPlanModel.documentApprovals)
                {
                    dataGridViewDocumentApprovals.Rows.Add(new String[] { row.role, row.name, row.changes, row.date });
                }

                foreach (var row in currentQualityPlanModel.documentQualityTargets)
                {
                    dataGridViewQualityTargets.Rows.Add(new String[] { row.requirement, row.deliverable, row.criteria, row.standards });
                }

                foreach (var row in currentQualityPlanModel.documentQualityAssurances)
                {
                    dataGridViewQAP.Rows.Add(new String[] { row.technique, row.description, row.frequency });
                }

                foreach (var row in currentQualityPlanModel.documentQualityControls)
                {
                    dataGridViewQCP.Rows.Add(new String[] { row.technique, row.description, row.frequency });
                }

                WriteAllToList(listBoxAssumptions, currentQualityPlanModel.assumptions);
                WriteAllToList(listBoxConstraints, currentQualityPlanModel.constraints);

                WriteAllToList(listBoxQualityActivities, currentQualityPlanModel.activites);
                WriteAllToList(listBoxQualityRoles, currentQualityPlanModel.roles);
                WriteAllToList(listBoxQualityDocuments, currentQualityPlanModel.documents);
            }
            else
            {
                versionControl = new VersionControl<QualityPlanModel>();
                versionControl.DocumentModels = new List<VersionControl<QualityPlanModel>.DocumentModel>();
                documentInfo.Add(new string[] { "Document ID", "" });
                documentInfo.Add(new string[] { "Document Owner", "" });
                documentInfo.Add(new string[] { "Issue Date", "" });
                documentInfo.Add(new string[] { "Last Save Date", "" });
                documentInfo.Add(new string[] { "File Name", "" });
                newQualityPlanModel = new QualityPlanModel();
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
