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

        public void saveDocument()
        {
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

            List<TermsOfReferenceModel.Deliverables> Deliv = new List<TermsOfReferenceModel.Deliverables>();

            int delivRowsCount = dgvDeliverables.Rows.Count;

            for (int i = 0; i < delivRowsCount - 1; i++)
            {
                TermsOfReferenceModel.Deliverables deliv = new TermsOfReferenceModel.Deliverables();
                var Deliverable = dgvDeliverables.Rows[i].Cells[0].Value?.ToString() ?? "";
                var Components = dgvDeliverables.Rows[i].Cells[1].Value?.ToString() ?? "";
                var Description = dgvDeliverables.Rows[i].Cells[2].Value?.ToString() ?? "";

                deliv.Deliverable = Deliverable;
                deliv.Components = Components;
                deliv.Description = Description;

                Deliv.Add(deliv);
            }
            newTermsOfReferenceModel.Deliv = Deliv;

            List<TermsOfReferenceModel.Customers> Cust = new List<TermsOfReferenceModel.Customers>();

            int cusRowsCount = dgvDeliverables.Rows.Count;

            for (int i = 0; i < delivRowsCount - 1; i++)
            {
                TermsOfReferenceModel.Customers custo = new TermsOfReferenceModel.Customers();
                var CustomerGroup = dgvCustomers.Rows[i].Cells[0].Value?.ToString() ?? "";
                var CustomerRepresentative = dgvCustomers.Rows[i].Cells[1].Value?.ToString() ?? "";

                custo.CustomerGroup = CustomerGroup;
                custo.CustomerRepresentative = CustomerRepresentative;
                

                Cust.Add(custo);
            }
            newTermsOfReferenceModel.Cust = Cust;

            List<TermsOfReferenceModel.Stakeholders> Stake = new List<TermsOfReferenceModel.Stakeholders>();

            int stakeRowsCount = dgvDeliverables.Rows.Count;

            for (int i = 0; i < stakeRowsCount - 1; i++)
            {
                TermsOfReferenceModel.Stakeholders stak = new TermsOfReferenceModel.Stakeholders();
                var StakeholdersGroup = dgvStakeholders.Rows[i].Cells[0].Value?.ToString() ?? "";
                var StakeholderInterest = dgvStakeholders.Rows[i].Cells[1].Value?.ToString() ?? "";

                stak.StakeholdersGroup = StakeholdersGroup;
                stak.StakeholderInterest = StakeholderInterest;


                Stake.Add(stak);
            }
            newTermsOfReferenceModel.Stake = Stake;

            List<TermsOfReferenceModel.Roles> Rol = new List<TermsOfReferenceModel.Roles>();

            int roleRowsCount = dgvDeliverables.Rows.Count;

            for (int i = 0; i < roleRowsCount - 1; i++)
            {
                TermsOfReferenceModel.Roles rolls = new TermsOfReferenceModel.Roles();
                var Role = dgvRoles.Rows[i].Cells[0].Value?.ToString() ?? "";
                var ResourceName = dgvRoles.Rows[i].Cells[1].Value?.ToString() ?? "";
                var Organization = dgvRoles.Rows[i].Cells[0].Value?.ToString() ?? "";
                var AssignmentStatus = dgvRoles.Rows[i].Cells[1].Value?.ToString() ?? "";
                var AssignmentDate = dgvRoles.Rows[i].Cells[1].Value?.ToString() ?? "";

                rolls.Role = Role;
                rolls.ResourceName = ResourceName;
                rolls.Organization = Organization;
                rolls.AssignmentStatus = AssignmentStatus;
                rolls.AssignmentDate = AssignmentDate;


                Rol.Add(rolls);
            }
            newTermsOfReferenceModel.Rol = Rol;

            List<TermsOfReferenceModel.Approach> Appr = new List<TermsOfReferenceModel.Approach>();

            int apprRowsCount = dgvApproach.Rows.Count;

            for (int i = 0; i < apprRowsCount - 1; i++)
            {
                TermsOfReferenceModel.Approach app = new TermsOfReferenceModel.Approach();
                var Phase = dgvApproach.Rows[i].Cells[0].Value?.ToString() ?? "";
                var OverallApproach = dgvApproach.Rows[i].Cells[1].Value?.ToString() ?? "";
                
                app.Phase = Phase;
                app.OverallApproach = OverallApproach;

                Appr.Add(app);
            }
            newTermsOfReferenceModel.Appr = Appr;

            List<TermsOfReferenceModel.Milestones> Mile = new List<TermsOfReferenceModel.Milestones>();

            int milRowsCount = dgvMilestones.Rows.Count;

            for (int i = 0; i < milRowsCount - 1; i++)
            {
                TermsOfReferenceModel.Milestones mil = new TermsOfReferenceModel.Milestones();
                var Milestone = dgvMilestones.Rows[i].Cells[0].Value?.ToString() ?? "";
                var Date = dgvMilestones.Rows[i].Cells[1].Value?.ToString() ?? "";
                var Description = dgvMilestones.Rows[i].Cells[0].Value?.ToString() ?? "";
                
                mil.Milestone = Milestone;
                mil.Date = Date;
                mil.Description = Description;

                Mile.Add(mil);
            }
            newTermsOfReferenceModel.Mile = Mile;

            List<TermsOfReferenceModel.Dependencies> Dep = new List<TermsOfReferenceModel.Dependencies>();

            int depRowsCount = dgvDependencies.Rows.Count;

            for (int i = 0; i < depRowsCount - 1; i++)
            {
                TermsOfReferenceModel.Dependencies depe = new TermsOfReferenceModel.Dependencies();
                var ProjectActivity = dgvDependencies.Rows[i].Cells[0].Value?.ToString() ?? "";
                var Impacts = dgvDependencies.Rows[i].Cells[1].Value?.ToString() ?? "";
                var ImpactedBy = dgvDependencies.Rows[i].Cells[0].Value?.ToString() ?? "";
                var Critically = dgvDependencies.Rows[i].Cells[1].Value?.ToString() ?? "";
                var Date = dgvDependencies.Rows[i].Cells[1].Value?.ToString() ?? "";

                depe.ProjectActivity = ProjectActivity;
                depe.Impacts = Impacts;
                depe.ImpactedBy = ImpactedBy;
                depe.Critically = Critically;
                depe.Date = Date;

                Dep.Add(depe);
            }
            newTermsOfReferenceModel.Dep = Dep;

            List<TermsOfReferenceModel.ResourcePlan> ResP = new List<TermsOfReferenceModel.ResourcePlan>();

            int resRowsCount = dgvResourcePlan.Rows.Count;

            for (int i = 0; i < resRowsCount - 1; i++)
            {
                TermsOfReferenceModel.ResourcePlan resou = new TermsOfReferenceModel.ResourcePlan();
                var Role = dgvResourcePlan.Rows[i].Cells[0].Value?.ToString() ?? "";
                var StartDate = dgvResourcePlan.Rows[i].Cells[1].Value?.ToString() ?? "";
                var EndDate = dgvResourcePlan.Rows[i].Cells[0].Value?.ToString() ?? "";
                var Effort = dgvResourcePlan.Rows[i].Cells[1].Value?.ToString() ?? "";
          
                resou.Role = Role;
                resou.StartDate = StartDate;
                resou.EndDate = EndDate;
                resou.Effort = Effort;

                ResP.Add(resou);
            }
            newTermsOfReferenceModel.ResP = ResP;

            List<TermsOfReferenceModel.FinancialPlan> FinP = new List<TermsOfReferenceModel.FinancialPlan>();

            int finRowsCount = dgvFinancialPlan.Rows.Count;

            for (int i = 0; i < finRowsCount - 1; i++)
            {
                TermsOfReferenceModel.FinancialPlan fin = new TermsOfReferenceModel.FinancialPlan();
                var ExpenditureCategory = dgvFinancialPlan.Rows[i].Cells[0].Value?.ToString() ?? "";
                var ExpenditureItem = dgvFinancialPlan.Rows[i].Cells[1].Value?.ToString() ?? "";
                var ExpenditureValue = dgvFinancialPlan.Rows[i].Cells[1].Value?.ToString() ?? "";

                fin.ExpenditureCategory = ExpenditureCategory;
                fin.ExpenditureItem = ExpenditureItem;
                fin.ExpenditureValue = ExpenditureValue;

                FinP.Add(fin);
            }
            newTermsOfReferenceModel.FinP = FinP;

            List<TermsOfReferenceModel.QualityPlan> QuaP = new List<TermsOfReferenceModel.QualityPlan>();

            int quaRowsCount = dgvQualityPlan.Rows.Count;

            for (int i = 0; i < quaRowsCount - 1; i++)
            {
                TermsOfReferenceModel.QualityPlan qua = new TermsOfReferenceModel.QualityPlan();
                var ExpenditureCategory = dgvQualityPlan.Rows[i].Cells[0].Value?.ToString() ?? "";
                var ExpenditureItem = dgvQualityPlan.Rows[i].Cells[1].Value?.ToString() ?? "";

                qua.Process = ExpenditureCategory;
                qua.Description = ExpenditureItem;

                QuaP.Add(qua);
            }
            newTermsOfReferenceModel.QuaP = QuaP;

            List<TermsOfReferenceModel.CompletionCriteria> CompC = new List<TermsOfReferenceModel.CompletionCriteria>();

            int comRowsCount = dgvCompletionCriteria.Rows.Count;

            for (int i = 0; i < quaRowsCount - 1; i++)
            {
                TermsOfReferenceModel.CompletionCriteria com = new TermsOfReferenceModel.CompletionCriteria();
                var Process = dgvCompletionCriteria.Rows[i].Cells[0].Value?.ToString() ?? "";
                var Description = dgvCompletionCriteria.Rows[i].Cells[1].Value?.ToString() ?? "";

                com.Process = Process;
                com.Description = Description;

                CompC.Add(com);
            }
            newTermsOfReferenceModel.CompC = CompC;

            List<TermsOfReferenceModel.Risks> Risk = new List<TermsOfReferenceModel.Risks>();

            int risRowsCount = dgvRisks.Rows.Count;

            for (int i = 0; i < risRowsCount - 1; i++)
            {
                TermsOfReferenceModel.Risks ris = new TermsOfReferenceModel.Risks();
                var Role = dgvRisks.Rows[i].Cells[0].Value?.ToString() ?? "";
                var StartDate = dgvRisks.Rows[i].Cells[1].Value?.ToString() ?? "";
                var EndDate = dgvRisks.Rows[i].Cells[0].Value?.ToString() ?? "";
                var Effort = dgvRisks.Rows[i].Cells[1].Value?.ToString() ?? "";

                ris.RiskDesc = Role;
                ris.RiskLikelihood = StartDate;
                ris.RiskImpact = EndDate;
                ris.Action = Effort;

                Risk.Add(ris);
            }
            newTermsOfReferenceModel.Risk = Risk;

            List<TermsOfReferenceModel.Issues> Issuess = new List<TermsOfReferenceModel.Issues>();

            int issRowsCount = dgvIssues.Rows.Count;

            for (int i = 0; i < issRowsCount - 1; i++)
            {
                TermsOfReferenceModel.Issues iss = new TermsOfReferenceModel.Issues();
                var IssueDescription = dgvIssues.Rows[i].Cells[0].Value?.ToString() ?? "";
                var IssuePriority = dgvIssues.Rows[i].Cells[1].Value?.ToString() ?? "";
                var Action = dgvIssues.Rows[i].Cells[0].Value?.ToString() ?? "";

                iss.IssueDescription = IssueDescription;
                iss.IssuePriority = IssuePriority;
                iss.Action = Action;

                Issuess.Add(iss);
            }
            newTermsOfReferenceModel.Risk = Risk;

            newTermsOfReferenceModel.ExecutiveSummary = txtExecutiveSummary.Text;

            newTermsOfReferenceModel.ProjDefinition = txtProjectDefinition.Text;
            newTermsOfReferenceModel.Vision = txtVision.Text;
            newTermsOfReferenceModel.Objectives = txtObjectives.Text;
            newTermsOfReferenceModel.Scope = txtScope.Text;

            newTermsOfReferenceModel.Responsibilities = txtResponsibilities.Text;
            newTermsOfReferenceModel.Structure = txtStructure.Text;

            newTermsOfReferenceModel.Assumptions = txtAssumptions.Text;
            newTermsOfReferenceModel.Constraints = txtConstraints.Text;

            List<VersionControl<TermsOfReferenceModel>.DocumentModel> documentModels = versionControl.DocumentModels;
            if (!versionControl.isEqual(currentTermsOfReferenceModel, newTermsOfReferenceModel))
            {
                VersionControl<TermsOfReferenceModel>.DocumentModel documentModel = new VersionControl<TermsOfReferenceModel>.DocumentModel(newTermsOfReferenceModel, DateTime.Now, VersionControl<ProjectModel>.generateID());

                documentModels.Add(documentModel);

                versionControl.DocumentModels = documentModels;

                string json = JsonConvert.SerializeObject(versionControl);
                JsonHelper.saveDocument(json, Settings.Default.ProjectID, "ProjectPlan");
                MessageBox.Show("Terms of reference saved successfully", "save", MessageBoxButtons.OK);
            }
        }

         

        private void loadDocument()
        {
            dgvDocumentHistory.Columns.Add("colVersion", "Version");
            dgvDocumentHistory.Columns.Add("colIssueDate", "Issue date");
            dgvDocumentHistory.Columns.Add("colChanges", "Changes");

            dgvDocumentApprovals.Columns.Add("colRole", "Role");
            dgvDocumentApprovals.Columns.Add("colName", "Name");
            dgvDocumentApprovals.Columns.Add("colSignature", "Signature");
            dgvDocumentApprovals.Columns.Add("colDateApproved", "Date approved");

            dgvDeliverables.Columns.Add("colDeliv", "Deliverable");
            dgvDeliverables.Columns.Add("colName", "Components");
            dgvDeliverables.Columns.Add("colSignature", "Description");

            dgvCustomers.Columns.Add("colCG", "CustomerGroup");
            dgvCustomers.Columns.Add("colCR", "CustomerRepresentative");

            dgvStakeholders.Columns.Add("colSG", "Stakeholders Group");
            dgvStakeholders.Columns.Add("colSI", "Stakeholder Interest");

            dgvRoles.Columns.Add("colRole", "Role");
            dgvRoles.Columns.Add("colRN", "ResourceName");
            dgvRoles.Columns.Add("colOrg", "Organization");
            dgvRoles.Columns.Add("colDateAS", "Assignment Status");
            dgvRoles.Columns.Add("colAD", "Assignment Date");

            dgvApproach.Columns.Add("colPhase", "Phase");
            dgvApproach.Columns.Add("colSI", "OverallApproach");

            dgvMilestones.Columns.Add("colMilestone", "Milestone");
            dgvMilestones.Columns.Add("colDate", "Date");
            dgvMilestones.Columns.Add("colDescription", "Description");

            dgvDependencies.Columns.Add("colProjectActivity", "Project Activity");
            dgvDependencies.Columns.Add("colImpacts", "Impacts");
            dgvDependencies.Columns.Add("colImpactedBy", "Impacted By");
            dgvDependencies.Columns.Add("colCritically", "Critically");
            dgvDependencies.Columns.Add("colDate", "Date");

            dgvResourcePlan.Columns.Add("colRole", "Role");
            dgvResourcePlan.Columns.Add("colStartDate", "Start Date");
            dgvResourcePlan.Columns.Add("colEndDate", "End Date");
            dgvResourcePlan.Columns.Add("colEffort", "Effort");

            dgvFinancialPlan.Columns.Add("colExpenditureCategory", "Expenditure Category");
            dgvFinancialPlan.Columns.Add("colExpenditureItem", "Expenditure Item");
            dgvFinancialPlan.Columns.Add("colExpenditureValue", "Expenditure Value");

            dgvQualityPlan.Columns.Add("colProcess", "Process");
            dgvQualityPlan.Columns.Add("colDescription", "Description");

            dgvCompletionCriteria.Columns.Add("colCCProcess", "Process");
            dgvCompletionCriteria.Columns.Add("colCCDescription", "Description");

            dgvRisks.Columns.Add("colRiskDesc", "Risk description");
            dgvRisks.Columns.Add("colRiskLikelihood", "Risk Likelihood");
            dgvRisks.Columns.Add("colRiskImpact", "Risk Impact");
            dgvRisks.Columns.Add("colAction", "Action");

            dgvIssues.Columns.Add("colIssueDescription", "Issue Description");
            dgvIssues.Columns.Add("colIssuePriority", "Issue Priority");
            dgvIssues.Columns.Add("colAction", "Action");


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
           
               
                txtExecutiveSummary.Text = currentTermsOfReferenceModel.ExecutiveSummary;

                txtProjectDefinition.Text = currentTermsOfReferenceModel.ProjDefinition;
                txtVision.Text = currentTermsOfReferenceModel.Vision;
                txtObjectives.Text = currentTermsOfReferenceModel.Objectives;
                txtScope.Text = currentTermsOfReferenceModel.Scope;

                txtResponsibilities.Text = currentTermsOfReferenceModel.Responsibilities;
                txtStructure.Text = currentTermsOfReferenceModel.Structure;

                txtAssumptions.Text = currentTermsOfReferenceModel.Assumptions;
                txtConstraints.Text = currentTermsOfReferenceModel.Constraints;

                foreach (var row in currentTermsOfReferenceModel.Deliv)
                {
                    dgvDeliverables.Rows.Add(new string[] { row.Deliverable, row.Components, row.Description });
                }

                foreach (var row in currentTermsOfReferenceModel.Cust)
                {
                    dgvCustomers.Rows.Add(new string[] { row.CustomerGroup, row.CustomerRepresentative});
                }

                foreach (var row in currentTermsOfReferenceModel.Stake)
                {
                    dgvStakeholders.Rows.Add(new string[] { row.StakeholdersGroup, row.StakeholderInterest});
                }

                foreach (var row in currentTermsOfReferenceModel.Rol)
                {
                    dgvRoles.Rows.Add(new string[] { row.Role, row.ResourceName, row.Organization, row.AssignmentStatus, row.AssignmentDate });
                }

                foreach (var row in currentTermsOfReferenceModel.Appr)
                {
                    dgvApproach.Rows.Add(new string[] { row.Phase, row.OverallApproach });
                }

                foreach (var row in currentTermsOfReferenceModel.Mile)
                {
                    dgvMilestones.Rows.Add(new string[] { row.Milestone, row.Date, row.Description });
                }

                foreach (var row in currentTermsOfReferenceModel.Dep)
                {
                    dgvDependencies.Rows.Add(new string[] { row.ProjectActivity, row.Impacts, row.ImpactedBy, row.Critically, row.Date });
                }

                foreach (var row in currentTermsOfReferenceModel.ResP)
                {
                    dgvResourcePlan.Rows.Add(new string[] { row.Role, row.StartDate, row.EndDate, row.Effort });
                }

                foreach (var row in currentTermsOfReferenceModel.FinP)
                {
                    dgvFinancialPlan.Rows.Add(new string[] { row.ExpenditureCategory, row.ExpenditureItem, row.ExpenditureValue });
                }

                foreach (var row in currentTermsOfReferenceModel.QuaP)
                {
                    dgvQualityPlan.Rows.Add(new string[] { row.Process, row.Description });
                }

                foreach (var row in currentTermsOfReferenceModel.CompC)
                {
                    dgvCompletionCriteria.Rows.Add(new string[] { row.Process, row.Description });
                }

                foreach (var row in currentTermsOfReferenceModel.Risk)
                {
                    dgvRisks.Rows.Add(new string[] { row.RiskDesc, row.RiskLikelihood, row.RiskImpact, row.Action });
                }

                foreach (var row in currentTermsOfReferenceModel.Issuess)
                {
                    dgvIssues.Rows.Add(new string[] { row.IssueDescription, row.IssuePriority, row.Action });
                }


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
