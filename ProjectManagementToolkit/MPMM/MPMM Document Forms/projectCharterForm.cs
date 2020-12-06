using Newtonsoft.Json;
using ProjectManagementToolkit.MPMM.MPMM_Document_Models;
using ProjectManagementToolkit.Properties;
using ProjectManagementToolkit.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Forms
{
    public partial class ProjectCharterForm : Form
    {
        VersionControl<ProjectCharterModel> versionControl;
        ProjectCharterModel newProjectCharterModel;
        ProjectCharterModel currentProjectCharterModel;
        Color TABLE_HEADER_COLOR = Color.FromArgb(73, 173, 252);
        ProjectModel projectModel = new ProjectModel();
        public ProjectCharterForm()
        {
            InitializeComponent();
        }

        private void ProjectCharterForm_Load(object sender, EventArgs e)
        {
            string json = JsonHelper.loadProjectInfo(Settings.Default.Username);
            List<ProjectModel> projectListModel = JsonConvert.DeserializeObject<List<ProjectModel>>(json);
            projectModel = projectModel.getProjectModel(Settings.Default.ProjectID, projectListModel);
            txtProjectName.Text = projectModel.ProjectName;
            loadDocument();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            saveDocument();
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            exportToWord();
        }

        private void loadDocument()
        {
            string json = JsonHelper.loadDocument(Settings.Default.ProjectID, "ProjectCharter");
            newProjectCharterModel = new ProjectCharterModel();
            currentProjectCharterModel = new ProjectCharterModel();
            List<string[]> documentInfo = new List<string[]>();
            if (json != "")
            {
                versionControl = JsonConvert.DeserializeObject<VersionControl<ProjectCharterModel>>(json);
                newProjectCharterModel = JsonConvert.DeserializeObject<ProjectCharterModel>(versionControl.getLatest(versionControl.DocumentModels));
                currentProjectCharterModel = JsonConvert.DeserializeObject<ProjectCharterModel>(versionControl.getLatest(versionControl.DocumentModels));

                documentInfo.Add(new string[] { "Document ID", currentProjectCharterModel.DocumentID });
                documentInfo.Add(new string[] { "Document Owner", currentProjectCharterModel.DocumentOwner });
                documentInfo.Add(new string[] { "Issue Date", currentProjectCharterModel.IssueDate });
                documentInfo.Add(new string[] { "Last Save Date", currentProjectCharterModel.LastSavedDate });
                documentInfo.Add(new string[] { "File Name", currentProjectCharterModel.FileName });

                foreach (var item in documentInfo)
                {
                    dgvDocumentInformation.Rows.Add(item);
                }

                foreach (var item in currentProjectCharterModel.DocumentHistories)
                {
                    dgvDocumentHistories.Rows.Add(new string[] { item.Version, item.IssueDate, item.Changes});
                }

                foreach (var item in currentProjectCharterModel.DocumentApprovals)
                {
                    dgvDocumentApprovals.Rows.Add(new string[] { item.Role, item.Name, item.Signature, item.DateApproved });
                }

                txtExecutiveSummary.Text = currentProjectCharterModel.ExecutiveSummary;
                txtProjectDefinition.Text = currentProjectCharterModel.ProjectDefinition;
                txtVision.Text = currentProjectCharterModel.Vision;
                txtObjectives.Text = currentProjectCharterModel.Objectives;
                txtScope.Text = currentProjectCharterModel.Scope;


                foreach (var item in currentProjectCharterModel.Customers)
                {
                    dgvCustomers.Rows.Add(new string[] { item.CustomerGroup, item.CustomerRepresentative });
                }

                foreach (var item in currentProjectCharterModel.Stakeholders)
                {
                    dgvStakeholders.Rows.Add(new string[] { item.StakeholderGroup, item.Interest });
                }

                txtRoles.Text = currentProjectCharterModel.Roles;
                txtResponsibilities.Text = currentProjectCharterModel.Responsibilities;
                txtStructure.Text = currentProjectCharterModel.Structure;

                foreach (var item in currentProjectCharterModel.Approaches)
                {
                    dgvApproach.Rows.Add(new string[] { item.Phase, item.OverallApproach });
                }

                txtSchedule.Text = currentProjectCharterModel.Schedule;
                
                foreach (var item in currentProjectCharterModel.Milestones)
                {
                    dgvMilestones.Rows.Add(new string[] { item.MilestoneName, item.Date, item.MilestoneDescription });
                }

                foreach (var item in currentProjectCharterModel.Dependencies)
                {
                    dgvDependencies.Rows.Add(new string[] { item.ProjectActivity, item.Impacts, item.IsImpactedBy, item.Criticality, item.Date });
                }

                foreach (var item in currentProjectCharterModel.ResourcePlans)
                {
                    dgvResourcePlan.Rows.Add(new string[] { item.Role, item.StartDate, item.EndDate, item.Effort });
                }

                foreach (var item in currentProjectCharterModel.FinancialPlans)
                {
                    dgvFinancialPlan.Rows.Add(new string[] { item.ExpenditureCategory, item.ExpenditureItem, item.ExpenditureValue });
                }

                foreach (var item in currentProjectCharterModel.QualityPlans)
                {
                    dgvQualityPlan.Rows.Add(new string[] { item.Process, item.Description });
                }

                foreach (var item in currentProjectCharterModel.CompletionCriterias)
                {
                    dgvCompletionCriteria.Rows.Add(new string[] { item.Process, item.Description });
                }

                foreach (var item in currentProjectCharterModel.QualityPlans)
                {
                    dgvQualityPlan.Rows.Add(new string[] { item.Process, item.Description });
                }

                foreach (var item in currentProjectCharterModel.Risks)
                {
                    dgvRisks.Rows.Add(new string[] { item.Description, item.Likelihood, item.Impact, item.Action });
                }

                foreach (var item in currentProjectCharterModel.Issues)
                {
                    dgvIssue.Rows.Add(new string[] { item.Description, item.Priority, item.Action });
                }
                
                txtAssumptions.Text = currentProjectCharterModel.Assumptions;
                txtConstraints.Text = currentProjectCharterModel.Constraints;
                txtAppendix.Text = currentProjectCharterModel.Appendix;
            }
            else
            {
                versionControl = new VersionControl<ProjectCharterModel>();
                versionControl.DocumentModels = new List<VersionControl<ProjectCharterModel>.DocumentModel>();
                newProjectCharterModel = new ProjectCharterModel();
                documentInfo.Add(new string[] { "Document ID", "" });
                documentInfo.Add(new string[] { "Document Owner", "" });
                documentInfo.Add(new string[] { "Issue Date", "" });
                documentInfo.Add(new string[] { "Last Save Date", "" });
                documentInfo.Add(new string[] { "File Name", "" });

                foreach (var row in documentInfo)
                {
                    dgvDocumentInformation.Rows.Add(row);
                }
            }
        }

        private void saveDocument()
        {
            newProjectCharterModel.ProjectName = txtProjectName.Text;
            newProjectCharterModel.DocumentID = dgvDocumentInformation.Rows[0].Cells[1].Value.ToString();
            newProjectCharterModel.DocumentOwner = dgvDocumentInformation.Rows[1].Cells[1].Value.ToString();
            newProjectCharterModel.IssueDate = dgvDocumentInformation.Rows[2].Cells[1].Value.ToString();
            newProjectCharterModel.LastSavedDate = dgvDocumentInformation.Rows[3].Cells[1].Value.ToString();
            newProjectCharterModel.FileName = dgvDocumentInformation.Rows[4].Cells[1].Value.ToString();

            List<ProjectCharterModel.DocumentHistory> documentHistories = new List<ProjectCharterModel.DocumentHistory>();
            for (int i = 0; i < dgvDocumentHistories.Rows.Count - 1; i++)
            {
                ProjectCharterModel.DocumentHistory documentHistory = new ProjectCharterModel.DocumentHistory();
                documentHistory.Version = dgvDocumentHistories.Rows[i].Cells[0].Value?.ToString() ?? "";
                documentHistory.IssueDate = dgvDocumentHistories.Rows[i].Cells[1].Value?.ToString() ?? "";
                documentHistory.Changes = dgvDocumentHistories.Rows[i].Cells[2].Value?.ToString() ?? "";
                documentHistories.Add(documentHistory);
            }
            newProjectCharterModel.DocumentHistories = documentHistories;

            List<ProjectCharterModel.DocumentApproval> documentApprovals = new List<ProjectCharterModel.DocumentApproval>();
            for (int i = 0; i < dgvDocumentApprovals.Rows.Count - 1; i++)
            {
                ProjectCharterModel.DocumentApproval documentApproval = new ProjectCharterModel.DocumentApproval();
                documentApproval.Role = dgvDocumentApprovals.Rows[i].Cells[0].Value?.ToString() ?? "";
                documentApproval.Name = dgvDocumentApprovals.Rows[i].Cells[1].Value?.ToString() ?? "";
                documentApproval.Signature = dgvDocumentApprovals.Rows[i].Cells[2].Value?.ToString() ?? "";
                documentApproval.DateApproved = dgvDocumentApprovals.Rows[i].Cells[3].Value?.ToString() ?? "";
                documentApprovals.Add(documentApproval);
            }
            newProjectCharterModel.DocumentApprovals = documentApprovals;

            newProjectCharterModel.ExecutiveSummary = txtExecutiveSummary.Text;
            newProjectCharterModel.ProjectDefinition = txtProjectDefinition.Text;
            newProjectCharterModel.Vision = txtVision.Text;
            newProjectCharterModel.Objectives = txtObjectives.Text;
            newProjectCharterModel.Scope = txtScope.Text;

            List<ProjectCharterModel.Customer> newCustomers = new List<ProjectCharterModel.Customer>();
            for (int i = 0; i < dgvCustomers.Rows.Count - 1; i++)
            {
                ProjectCharterModel.Customer newCustomer = new ProjectCharterModel.Customer();
                newCustomer.CustomerGroup = dgvCustomers.Rows[i].Cells[0].Value?.ToString() ?? "";
                newCustomer.CustomerRepresentative = dgvCustomers.Rows[i].Cells[1].Value?.ToString() ?? "";
                newCustomers.Add(newCustomer);
            }
            newProjectCharterModel.Customers = newCustomers;

            List<ProjectCharterModel.Stakeholder> newStakeholders = new List<ProjectCharterModel.Stakeholder>();
            for (int i = 0; i < dgvStakeholders.Rows.Count - 1; i++)
            {
                ProjectCharterModel.Stakeholder newStakeholder = new ProjectCharterModel.Stakeholder();
                newStakeholder.StakeholderGroup = dgvStakeholders.Rows[i].Cells[0].Value?.ToString() ?? "";
                newStakeholder.Interest = dgvStakeholders.Rows[i].Cells[1].Value?.ToString() ?? "";
                newStakeholders.Add(newStakeholder);
            }
            newProjectCharterModel.Stakeholders = newStakeholders;

            newProjectCharterModel.Roles = txtRoles.Text;
            newProjectCharterModel.Responsibilities = txtResponsibilities.Text;
            newProjectCharterModel.Structure = txtStructure.Text;

            List<ProjectCharterModel.Approach> approaches = new List<ProjectCharterModel.Approach>();
            for (int i = 0; i < dgvApproach.Rows.Count - 1; i++)
            {
                ProjectCharterModel.Approach approach = new ProjectCharterModel.Approach();
                approach.Phase = dgvApproach.Rows[i].Cells[0].Value?.ToString() ?? "";
                approach.OverallApproach = dgvApproach.Rows[i].Cells[1].Value?.ToString() ?? "";
                approaches.Add(approach);
            }
            newProjectCharterModel.Approaches = approaches;

            newProjectCharterModel.Schedule = txtSchedule.Text;

            List<ProjectCharterModel.Milestone> newMilestones = new List<ProjectCharterModel.Milestone>();
            for (int i = 0; i < dgvMilestones.Rows.Count - 1; i++)
            {
                ProjectCharterModel.Milestone newMilestone = new ProjectCharterModel.Milestone();
                newMilestone.MilestoneName = dgvMilestones.Rows[i].Cells[0].Value?.ToString() ?? "";
                newMilestone.Date = dgvMilestones.Rows[i].Cells[1].Value?.ToString() ?? "";
                newMilestone.MilestoneDescription = dgvMilestones.Rows[i].Cells[2].Value?.ToString() ?? "";
                newMilestones.Add(newMilestone);
            }
            newProjectCharterModel.Milestones = newMilestones;

            List<ProjectCharterModel.Dependency> newDependencies = new List<ProjectCharterModel.Dependency>();
            for (int i = 0; i < dgvDependencies.Rows.Count - 1; i++)
            {
                ProjectCharterModel.Dependency newDependency = new ProjectCharterModel.Dependency();
                newDependency.ProjectActivity = dgvDependencies.Rows[i].Cells[0].Value?.ToString() ?? "";
                newDependency.Impacts = dgvDependencies.Rows[i].Cells[1].Value?.ToString() ?? "";
                newDependency.IsImpactedBy = dgvDependencies.Rows[i].Cells[2].Value?.ToString() ?? "";
                newDependency.Criticality = dgvDependencies.Rows[i].Cells[3].Value?.ToString() ?? "";
                newDependency.Date = dgvDependencies.Rows[i].Cells[4].Value?.ToString() ?? "";
                newDependencies.Add(newDependency);
            }
            newProjectCharterModel.Dependencies = newDependencies;

            List<ProjectCharterModel.ResourcePlan> newResourcePlans = new List<ProjectCharterModel.ResourcePlan>();
            for (int i = 0; i < dgvResourcePlan.Rows.Count - 1; i++)
            {
                ProjectCharterModel.ResourcePlan newResourcePlan = new ProjectCharterModel.ResourcePlan();
                newResourcePlan.Role = dgvResourcePlan.Rows[i].Cells[0].Value?.ToString() ?? "";
                newResourcePlan.StartDate = dgvResourcePlan.Rows[i].Cells[1].Value?.ToString() ?? "";
                newResourcePlan.EndDate = dgvResourcePlan.Rows[i].Cells[2].Value?.ToString() ?? "";
                newResourcePlan.Effort = dgvResourcePlan.Rows[i].Cells[3].Value?.ToString() ?? "";
                newResourcePlans.Add(newResourcePlan);
            }
            newProjectCharterModel.ResourcePlans = newResourcePlans;

            List<ProjectCharterModel.FinancialPlan> newFinancialPlans = new List<ProjectCharterModel.FinancialPlan>();
            for (int i = 0; i < dgvFinancialPlan.Rows.Count - 1; i++)
            {
                ProjectCharterModel.FinancialPlan newFinancialPlan = new ProjectCharterModel.FinancialPlan();
                newFinancialPlan.ExpenditureCategory = dgvFinancialPlan.Rows[i].Cells[0].Value?.ToString() ?? "";
                newFinancialPlan.ExpenditureItem = dgvFinancialPlan.Rows[i].Cells[1].Value?.ToString() ?? "";
                newFinancialPlan.ExpenditureValue = dgvFinancialPlan.Rows[i].Cells[2].Value?.ToString() ?? "";
                newFinancialPlans.Add(newFinancialPlan);
            }
            newProjectCharterModel.FinancialPlans = newFinancialPlans;

            List<ProjectCharterModel.QualityPlan> newQualityPlans = new List<ProjectCharterModel.QualityPlan>();
            for (int i = 0; i < dgvQualityPlan.Rows.Count - 1; i++)
            {
                ProjectCharterModel.QualityPlan newQualityPlan = new ProjectCharterModel.QualityPlan();
                newQualityPlan.Process = dgvQualityPlan.Rows[i].Cells[0].Value?.ToString() ?? "";
                newQualityPlan.Description = dgvQualityPlan.Rows[i].Cells[1].Value?.ToString() ?? "";
                newQualityPlans.Add(newQualityPlan);
            }
            newProjectCharterModel.QualityPlans = newQualityPlans;

            List<ProjectCharterModel.CompletionCriteria> newCompletionCriterias = new List<ProjectCharterModel.CompletionCriteria>();
            for (int i = 0; i < dgvCompletionCriteria.Rows.Count - 1; i++)
            {
                ProjectCharterModel.CompletionCriteria newCompletionCriteria = new ProjectCharterModel.CompletionCriteria();
                newCompletionCriteria.Process = dgvCompletionCriteria.Rows[i].Cells[0].Value?.ToString() ?? "";
                newCompletionCriteria.Description = dgvCompletionCriteria.Rows[i].Cells[1].Value?.ToString() ?? "";
                newCompletionCriterias.Add(newCompletionCriteria);
            }
            newProjectCharterModel.CompletionCriterias = newCompletionCriterias;


            List<ProjectCharterModel.Risk> newRisks = new List<ProjectCharterModel.Risk>();
            for (int i = 0; i < dgvRisks.Rows.Count - 1; i++)
            {
                ProjectCharterModel.Risk newRisk = new ProjectCharterModel.Risk();
                newRisk.Description = dgvRisks.Rows[i].Cells[0].Value?.ToString() ?? "";
                newRisk.Likelihood = dgvRisks.Rows[i].Cells[1].Value?.ToString() ?? "";
                newRisk.Impact = dgvRisks.Rows[i].Cells[2].Value?.ToString() ?? "";
                newRisk.Action = dgvRisks.Rows[i].Cells[3].Value?.ToString() ?? "";
                newRisks.Add(newRisk);
            }
            newProjectCharterModel.Risks = newRisks;

            List<ProjectCharterModel.Issue> newIssues = new List<ProjectCharterModel.Issue>();
            for (int i = 0; i < dgvIssue.Rows.Count - 1; i++)
            {
                ProjectCharterModel.Issue newIssue = new ProjectCharterModel.Issue();
                newIssue.Description = dgvIssue.Rows[i].Cells[0].Value?.ToString() ?? "";
                newIssue.Priority = dgvIssue.Rows[i].Cells[1].Value?.ToString() ?? "";
                newIssue.Action = dgvIssue.Rows[i].Cells[2].Value?.ToString() ?? "";
                newIssues.Add(newIssue);
            }
            newProjectCharterModel.Issues = newIssues;

            newProjectCharterModel.Assumptions = txtAssumptions.Text;
            newProjectCharterModel.Constraints = txtConstraints.Text;
            newProjectCharterModel.Appendix = txtAppendix.Text;

            List<VersionControl<ProjectCharterModel>.DocumentModel> documentModels = versionControl.DocumentModels;

            if (!versionControl.isEqual(currentProjectCharterModel,newProjectCharterModel))
            {
                VersionControl<ProjectCharterModel>.DocumentModel documentModel = new VersionControl<ProjectCharterModel>.DocumentModel(newProjectCharterModel, DateTime.Now, VersionControl<ProjectModel>.generateID());
                
                documentModels.Add(documentModel);

                versionControl.DocumentModels = documentModels;
                string json = JsonConvert.SerializeObject(versionControl);
                currentProjectCharterModel = JsonConvert.DeserializeObject<ProjectCharterModel>(JsonConvert.SerializeObject(newProjectCharterModel));
                JsonHelper.saveDocument(json, Settings.Default.ProjectID, "ProjectCharter");
                MessageBox.Show("Project Charter saved successfully", "Save", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("No changes were made", "Save", MessageBoxButtons.OK);
            }
        }

        private void exportToWord()
        {

        }
    }
}
