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
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Forms
{
    public partial class TermOfReferenceDocumentForm : Form
    {
        VersionControl<TermsOfReferenceModel> versionControl;
        TermsOfReferenceModel newTermsOfReferenceModel;
        TermsOfReferenceModel currentTermsOfReferenceModel;
        ProjectModel projectModel = new ProjectModel();
        Color TABLE_HEADER_COLOR = Color.FromArgb(73, 173, 252);

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

            int stakeRowsCount = dgvStakeholders.Rows.Count;

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

            int roleRowsCount = dgvRoles.Rows.Count;

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

            List<TermsOfReferenceModel.Issues> theIssuess = new List<TermsOfReferenceModel.Issues>();

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

                theIssuess.Add(iss);
            }
            newTermsOfReferenceModel.theIssuess = theIssuess;

            newTermsOfReferenceModel.ExecutiveSummary = txtExecutiveSummary.Text;

            newTermsOfReferenceModel.ProjDefinition = txtProjectDefinition.Text;
            newTermsOfReferenceModel.Vision = txtVision.Text;
            newTermsOfReferenceModel.Objectives = txtObjectives.Text;
            newTermsOfReferenceModel.Scope = txtScope.Text;

            newTermsOfReferenceModel.Responsibilities = txtResponsibilities.Text;
            newTermsOfReferenceModel.Structure = txtStructure.Text;

            newTermsOfReferenceModel.Assumptions = txtAssumptions.Text;
            newTermsOfReferenceModel.Constraints = txtConstraints.Text;

            newTermsOfReferenceModel.DocumentID = dgvDocumentInformation.Rows[0].Cells[1].Value.ToString();
            newTermsOfReferenceModel.DocumentOwner = dgvDocumentInformation.Rows[1].Cells[1].Value.ToString();
            newTermsOfReferenceModel.IssueDate = dgvDocumentInformation.Rows[2].Cells[1].Value.ToString();
            newTermsOfReferenceModel.LastSavedDate = dgvDocumentInformation.Rows[3].Cells[1].Value.ToString();
            newTermsOfReferenceModel.FileName = dgvDocumentInformation.Rows[4].Cells[1].Value.ToString();

            List<VersionControl<TermsOfReferenceModel>.DocumentModel> documentModels = versionControl.DocumentModels;
            if (!versionControl.isEqual(currentTermsOfReferenceModel, newTermsOfReferenceModel))
            {
                VersionControl<TermsOfReferenceModel>.DocumentModel documentModel = new VersionControl<TermsOfReferenceModel>.DocumentModel(newTermsOfReferenceModel, DateTime.Now, VersionControl<ProjectModel>.generateID());

                documentModels.Add(documentModel);

                versionControl.DocumentModels = documentModels;

                string json = JsonConvert.SerializeObject(versionControl);
                JsonHelper.saveDocument(json, Settings.Default.ProjectID, "TermOfReferenceDocument");
                MessageBox.Show("Terms of reference saved successfully", "save", MessageBoxButtons.OK);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveDocument();
        }

        private void loadDocument()
        {
            dgvDocumentInformation.Columns.Add("colType", "Type");
            dgvDocumentInformation.Columns.Add("colInformation", "Information");

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


            string json = JsonHelper.loadDocument(Settings.Default.ProjectID, "TermOfReferenceDocument");
            List<string[]> documentInfo = new List<string[]>();
            newTermsOfReferenceModel = new TermsOfReferenceModel();
            currentTermsOfReferenceModel = new TermsOfReferenceModel();

            string jsonWord = JsonHelper.loadProjectInfo(Settings.Default.Username);
            List<ProjectModel> projectListModel = JsonConvert.DeserializeObject<List<ProjectModel>>(jsonWord);
            projectModel = projectModel.getProjectModel(Settings.Default.ProjectID, projectListModel);

            if (json != "")
            {
                versionControl = JsonConvert.DeserializeObject<VersionControl<TermsOfReferenceModel>>(json);
                newTermsOfReferenceModel = JsonConvert.DeserializeObject<TermsOfReferenceModel>(versionControl.getLatest(versionControl.DocumentModels));
                currentTermsOfReferenceModel = JsonConvert.DeserializeObject<TermsOfReferenceModel>(versionControl.getLatest(versionControl.DocumentModels));

                documentInfo.Add(new string[] { "Document ID", currentTermsOfReferenceModel.DocumentID });
                documentInfo.Add(new string[] { "Document Owner", currentTermsOfReferenceModel.DocumentOwner });
                documentInfo.Add(new string[] { "Issue Date", currentTermsOfReferenceModel.IssueDate });
                documentInfo.Add(new string[] { "Last Save Date", currentTermsOfReferenceModel.LastSavedDate });
                documentInfo.Add(new string[] { "File Name", currentTermsOfReferenceModel.FileName });

                foreach (var row in documentInfo)
                {
                    dgvDocumentInformation.Rows.Add(row);
                }
                dgvDocumentInformation.AllowUserToAddRows = false;

                foreach (var row in currentTermsOfReferenceModel.DocumentHistories)
                {
                    dgvDocumentHistory.Rows.Add(new string[] { row.Version, row.IssueDate, row.Changes });
                }

                foreach (var row in currentTermsOfReferenceModel.DocumentApprovals)
                {
                    dgvDocumentApprovals.Rows.Add(new string[] { row.Role, row.Name, row.Signature, row.DateApproved });
                }

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

                foreach (var row in currentTermsOfReferenceModel.theIssuess)
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

        private void exportToWord()
        {
            string path;
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                saveFileDialog.Filter = "Word 97-2003 Documents (*.doc)|*.doc|Word 2007 Documents (*.docx)|*.docx";
                saveFileDialog.FilterIndex = 2;
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.ShowDialog();

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    path = saveFileDialog.FileName;
                    using (var document = DocX.Create(path))
                    {
                        for (int i = 0; i < 11; i++)
                        {
                            document.InsertParagraph("")
                                .Font("Arial")
                                .Bold(true)
                                .FontSize(22d).Alignment = Alignment.left;
                        }
                        document.InsertParagraph("Terms of reference \nFor " + projectModel.ProjectName)
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(22d).Alignment = Alignment.left;
                        document.InsertSectionPageBreak();
                        document.InsertParagraph("Document Control\n")
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(14d).Alignment = Alignment.left;
                        document.InsertParagraph("")
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(14d).Alignment = Alignment.left;
                        document.InsertParagraph("Document Information\n")
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(14d).Alignment = Alignment.left;

                        var documentInfoTable = document.AddTable(6, 2);
                        documentInfoTable.Rows[0].Cells[0].Paragraphs[0].Append("").Bold(true).Color(Color.White);
                        documentInfoTable.Rows[0].Cells[1].Paragraphs[0].Append("Information").Bold(true).Color(Color.White);
                        documentInfoTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        documentInfoTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;

                        documentInfoTable.Rows[1].Cells[0].Paragraphs[0].Append("Document ID");
                        documentInfoTable.Rows[1].Cells[1].Paragraphs[0].Append(currentTermsOfReferenceModel.DocumentID);

                        documentInfoTable.Rows[2].Cells[0].Paragraphs[0].Append("Document Owner");
                        documentInfoTable.Rows[2].Cells[1].Paragraphs[0].Append(currentTermsOfReferenceModel.DocumentOwner);

                        documentInfoTable.Rows[3].Cells[0].Paragraphs[0].Append("Issue Date");
                        documentInfoTable.Rows[3].Cells[1].Paragraphs[0].Append(currentTermsOfReferenceModel.IssueDate);

                        documentInfoTable.Rows[4].Cells[0].Paragraphs[0].Append("Last Saved Date");
                        documentInfoTable.Rows[4].Cells[1].Paragraphs[0].Append(currentTermsOfReferenceModel.LastSavedDate);

                        documentInfoTable.Rows[5].Cells[0].Paragraphs[0].Append("File Name");
                        documentInfoTable.Rows[5].Cells[1].Paragraphs[0].Append(currentTermsOfReferenceModel.FileName);
                        documentInfoTable.SetWidths(new float[] { 493, 1094 });
                        document.InsertTable(documentInfoTable);

                        document.InsertParagraph("\nDocument History\n")
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(14d).Alignment = Alignment.left;

                        var documentHistoryTable = document.AddTable(currentTermsOfReferenceModel.DocumentHistories.Count + 1, 3);
                        documentHistoryTable.Rows[0].Cells[0].Paragraphs[0].Append("Version")
                            .Bold(true)
                            .Color(Color.White);
                        documentHistoryTable.Rows[0].Cells[1].Paragraphs[0].Append("Issue Date")
                            .Bold(true)
                            .Color(Color.White);
                        documentHistoryTable.Rows[0].Cells[2].Paragraphs[0].Append("Changes")
                            .Bold(true)
                            .Color(Color.White);
                        documentHistoryTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        documentHistoryTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        documentHistoryTable.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;
                        for (int i = 1; i < currentTermsOfReferenceModel.DocumentHistories.Count + 1; i++)
                        {
                            documentHistoryTable.Rows[i].Cells[0].Paragraphs[0].Append(currentTermsOfReferenceModel.DocumentHistories[i - 1].Version);
                            documentHistoryTable.Rows[i].Cells[1].Paragraphs[0].Append(currentTermsOfReferenceModel.DocumentHistories[i - 1].IssueDate);
                            documentHistoryTable.Rows[i].Cells[2].Paragraphs[0].Append(currentTermsOfReferenceModel.DocumentHistories[i - 1].Changes);

                        }

                        documentHistoryTable.SetWidths(new float[] { 190, 303, 1094 });
                        document.InsertTable(documentHistoryTable);

                        document.InsertParagraph("\nDocument Approvals\n")
                           .Font("Arial")
                           .Bold(true)
                           .FontSize(14d).Alignment = Alignment.left;

                        var documentApprovalTable = document.AddTable(currentTermsOfReferenceModel.DocumentApprovals.Count + 1, 4);
                        documentApprovalTable.Rows[0].Cells[0].Paragraphs[0].Append("Role")
                            .Bold(true)
                            .Color(Color.White);
                        documentApprovalTable.Rows[0].Cells[1].Paragraphs[0].Append("Name")
                            .Bold(true)
                            .Color(Color.White);
                        documentApprovalTable.Rows[0].Cells[2].Paragraphs[0].Append("Signature")
                            .Bold(true)
                            .Color(Color.White);
                        documentApprovalTable.Rows[0].Cells[3].Paragraphs[0].Append("Date")
                            .Bold(true)
                            .Color(Color.White);
                        documentApprovalTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        documentApprovalTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        documentApprovalTable.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;
                        documentApprovalTable.Rows[0].Cells[3].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < currentTermsOfReferenceModel.DocumentApprovals.Count + 1; i++)
                        {
                            documentApprovalTable.Rows[i].Cells[0].Paragraphs[0].Append(currentTermsOfReferenceModel.DocumentApprovals[i - 1].Role);
                            documentApprovalTable.Rows[i].Cells[1].Paragraphs[0].Append(currentTermsOfReferenceModel.DocumentApprovals[i - 1].Name);
                            documentApprovalTable.Rows[i].Cells[2].Paragraphs[0].Append(currentTermsOfReferenceModel.DocumentApprovals[i - 1].Signature);
                            documentApprovalTable.Rows[i].Cells[3].Paragraphs[0].Append(currentTermsOfReferenceModel.DocumentApprovals[i - 1].DateApproved);
                        }
                        documentApprovalTable.SetWidths(new float[] { 493, 332, 508, 254 });
                        document.InsertTable(documentApprovalTable);
                        document.InsertParagraph().InsertPageBreakAfterSelf();


                        var p = document.InsertParagraph();
                        var title = p.InsertParagraphBeforeSelf("Table of Contents").Bold().FontSize(20);

                        var tocSwitches = new Dictionary<TableOfContentsSwitches, string>()
                        {
                            { TableOfContentsSwitches.O, "1-3"},
                            { TableOfContentsSwitches.U, ""},
                            { TableOfContentsSwitches.Z, ""},
                            { TableOfContentsSwitches.H, ""}
                        };

                        var ComPlanHeading = document.InsertParagraph("1 Executive summary")
                       .Bold()
                       .FontSize(12d)
                       .Color(Color.Black)
                       .Bold(true)
                       .Font("Arial");

                        document.InsertParagraph(currentTermsOfReferenceModel.ExecutiveSummary)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;


                        ComPlanHeading.StyleId = "Heading1";

                        document.InsertTableOfContents(p, "", tocSwitches);
                        document.InsertParagraph().InsertPageBreakAfterSelf();
                        var CommunicationReqHeading = document.InsertParagraph("2 Project definition")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        CommunicationReqHeading.StyleId = "Heading1";

                        var ProDefHeading = document.InsertParagraph("2.1 Project Definition")
                      .Bold()
                      .FontSize(12d)
                      .Color(Color.Black)
                      .Bold(true)
                      .Font("Arial");

                        document.InsertParagraph(currentTermsOfReferenceModel.ProjDefinition)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;


                        ProDefHeading.StyleId = "Heading2";

                        var VisionHeading = document.InsertParagraph("2.2 Vision")
                         .Bold()
                         .FontSize(12d)
                         .Color(Color.Black)
                         .Bold(true)
                         .Font("Arial");

                        document.InsertParagraph(currentTermsOfReferenceModel.Vision)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;


                        VisionHeading.StyleId = "Heading2";

                        var ObjectivesHeading = document.InsertParagraph("2.2 Objectives")
                         .Bold()
                         .FontSize(12d)
                         .Color(Color.Black)
                         .Bold(true)
                         .Font("Arial");

                        document.InsertParagraph(currentTermsOfReferenceModel.Objectives)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;


                        ObjectivesHeading.StyleId = "Heading2";

                        var ScopesHeading = document.InsertParagraph("2.2 Scope")
                        .Bold()
                        .FontSize(12d)
                        .Color(Color.Black)
                        .Bold(true)
                        .Font("Arial");

                        document.InsertParagraph(currentTermsOfReferenceModel.Scope)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;


                        ScopesHeading.StyleId = "Heading2";

                        var deliverablesDocument = document.AddTable(currentTermsOfReferenceModel.Deliv.Count + 1, 3);
                        deliverablesDocument.Rows[0].Cells[0].Paragraphs[0].Append("Deliverable")
                            .Bold(true)
                            .Color(Color.White);
                        deliverablesDocument.Rows[0].Cells[1].Paragraphs[0].Append("Components")
                            .Bold(true)
                            .Color(Color.White);
                        deliverablesDocument.Rows[0].Cells[2].Paragraphs[0].Append("Description")
                            .Bold(true)
                            .Color(Color.White);

                        deliverablesDocument.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        deliverablesDocument.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        deliverablesDocument.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < currentTermsOfReferenceModel.Deliv.Count + 1; i++)
                        {
                            deliverablesDocument.Rows[i].Cells[0].Paragraphs[0].Append(currentTermsOfReferenceModel.Deliv[i - 1].Deliverable);
                            deliverablesDocument.Rows[i].Cells[1].Paragraphs[0].Append(currentTermsOfReferenceModel.Deliv[i - 1].Components);
                            deliverablesDocument.Rows[i].Cells[2].Paragraphs[0].Append(currentTermsOfReferenceModel.Deliv[i - 1].Description);
                        }

                        deliverablesDocument.SetWidths(new float[] { 762, 762, 762 });
                        document.InsertTable(deliverablesDocument);

                        var CommunicationPlanHeading = document.InsertParagraph("3 Project Organization")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        CommunicationReqHeading.StyleId = "Heading1";

                        var custSubHeading = document.InsertParagraph("3.1 Customers")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        CommunicationReqHeading.StyleId = "Heading2";

                        var customersDoc = document.AddTable(currentTermsOfReferenceModel.Cust.Count + 1, 2);
                        customersDoc.Rows[0].Cells[0].Paragraphs[0].Append("Customer group")
                            .Bold(true)
                            .Color(Color.White);
                        customersDoc.Rows[0].Cells[1].Paragraphs[0].Append("Customer representattive")
                            .Bold(true)
                            .Color(Color.White);

                        customersDoc.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        customersDoc.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < currentTermsOfReferenceModel.Deliv.Count + 1; i++)
                        {
                            customersDoc.Rows[i].Cells[0].Paragraphs[0].Append(currentTermsOfReferenceModel.Deliv[i - 1].Deliverable);
                            customersDoc.Rows[i].Cells[1].Paragraphs[0].Append(currentTermsOfReferenceModel.Deliv[i - 1].Components);
                        }

                        customersDoc.SetWidths(new float[] { 762, 762 });
                        document.InsertTable(customersDoc);

                        var custSubHeading1 = document.InsertParagraph("3.2 Stakeholders")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        CommunicationReqHeading.StyleId = "Heading2";

                        var stakeholdersDoc = document.AddTable(currentTermsOfReferenceModel.Stake.Count + 1, 2);
                        stakeholdersDoc.Rows[0].Cells[0].Paragraphs[0].Append("Stakeholders Group")
                            .Bold(true)
                            .Color(Color.White);
                        stakeholdersDoc.Rows[0].Cells[1].Paragraphs[0].Append("Stakeholder Interest")
                            .Bold(true)
                            .Color(Color.White);

                        stakeholdersDoc.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        stakeholdersDoc.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < currentTermsOfReferenceModel.Deliv.Count + 1; i++)
                        {
                            stakeholdersDoc.Rows[i].Cells[0].Paragraphs[0].Append(currentTermsOfReferenceModel.Stake[i - 1].StakeholdersGroup);
                            stakeholdersDoc.Rows[i].Cells[1].Paragraphs[0].Append(currentTermsOfReferenceModel.Stake[i - 1].StakeholderInterest);
                        }

                        stakeholdersDoc.SetWidths(new float[] { 762, 762 });
                        document.InsertTable(stakeholdersDoc);

                        var rolesSubHeading = document.InsertParagraph("3.3 Roles")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        CommunicationReqHeading.StyleId = "Heading2";

                        var documentRoles = document.AddTable(currentTermsOfReferenceModel.DocumentApprovals.Count + 1, 5);
                        documentRoles.Rows[0].Cells[0].Paragraphs[0].Append("Role")
                            .Bold(true)
                            .Color(Color.White);
                        documentRoles.Rows[0].Cells[1].Paragraphs[0].Append("Resource Name")
                            .Bold(true)
                            .Color(Color.White);
                        documentRoles.Rows[0].Cells[2].Paragraphs[0].Append("Organization")
                            .Bold(true)
                            .Color(Color.White);
                        documentRoles.Rows[0].Cells[3].Paragraphs[0].Append("Assignment Status")
                            .Bold(true)
                            .Color(Color.White);
                        documentRoles.Rows[0].Cells[4].Paragraphs[0].Append("Assignment Date")
                           .Bold(true)
                           .Color(Color.White);
                        documentRoles.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        documentRoles.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        documentRoles.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;
                        documentRoles.Rows[0].Cells[3].FillColor = TABLE_HEADER_COLOR;
                        documentRoles.Rows[0].Cells[4].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < currentTermsOfReferenceModel.DocumentApprovals.Count + 1; i++)
                        {
                            documentRoles.Rows[i].Cells[0].Paragraphs[0].Append(currentTermsOfReferenceModel.Rol[i - 1].Role);
                            documentRoles.Rows[i].Cells[1].Paragraphs[0].Append(currentTermsOfReferenceModel.Rol[i - 1].ResourceName);
                            documentRoles.Rows[i].Cells[2].Paragraphs[0].Append(currentTermsOfReferenceModel.Rol[i - 1].Organization);
                            documentRoles.Rows[i].Cells[3].Paragraphs[0].Append(currentTermsOfReferenceModel.Rol[i - 1].AssignmentStatus);
                            documentRoles.Rows[i].Cells[4].Paragraphs[0].Append(currentTermsOfReferenceModel.Rol[i - 1].AssignmentDate);
                        }
                        documentRoles.SetWidths(new float[] { 762, 762, 762, 762, 762 });
                        document.InsertTable(documentRoles);

                        var resposibiitiesHeading = document.InsertParagraph("3.4 Responsibilities")
                         .Bold()
                         .FontSize(12d)
                         .Color(Color.Black)
                         .Bold(true)
                         .Font("Arial");

                        document.InsertParagraph(currentTermsOfReferenceModel.Responsibilities)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;


                        ObjectivesHeading.StyleId = "Heading2";

                        var structureHeading = document.InsertParagraph("3.4 Structure")
                        .Bold()
                        .FontSize(12d)
                        .Color(Color.Black)
                        .Bold(true)
                        .Font("Arial");

                        document.InsertParagraph(currentTermsOfReferenceModel.Structure)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;


                        structureHeading.StyleId = "Heading2";

                        var impHeading = document.InsertParagraph("4 Implementation plan")
                           .Bold()
                           .FontSize(14d)
                           .Color(Color.Black)
                           .Bold(true)
                           .Font("Arial");

                        impHeading.StyleId = "Heading1";

                        var appSubHeading = document.InsertParagraph("4.1 Approach")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        appSubHeading.StyleId = "Heading2";

                        var appDoc = document.AddTable(currentTermsOfReferenceModel.Appr.Count + 1, 2);
                        appDoc.Rows[0].Cells[0].Paragraphs[0].Append("Phase")
                            .Bold(true)
                            .Color(Color.White);
                        appDoc.Rows[0].Cells[1].Paragraphs[0].Append("Overall Approach")
                            .Bold(true)
                            .Color(Color.White);

                        appDoc.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        appDoc.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < currentTermsOfReferenceModel.Appr.Count + 1; i++)
                        {
                            appDoc.Rows[i].Cells[0].Paragraphs[0].Append(currentTermsOfReferenceModel.Appr[i - 1].Phase);
                            appDoc.Rows[i].Cells[1].Paragraphs[0].Append(currentTermsOfReferenceModel.Appr[i - 1].OverallApproach);
                        }

                        appDoc.SetWidths(new float[] { 762, 762 });
                        document.InsertTable(appDoc);

                        var scheduleHeading = document.InsertParagraph("4.2 Schedule")
                      .Bold()
                      .FontSize(12d)
                      .Color(Color.Black)
                      .Bold(true)
                      .Font("Arial");

                        document.InsertParagraph(currentTermsOfReferenceModel.Schedule)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;


                        scheduleHeading.StyleId = "Heading2";

                        var mileSubHeading = document.InsertParagraph("4.3 Milestones")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        mileSubHeading.StyleId = "Heading2";

                        var milestonesDoc = document.AddTable(currentTermsOfReferenceModel.Mile.Count + 1, 3);
                        milestonesDoc.Rows[0].Cells[0].Paragraphs[0].Append("Milestone")
                            .Bold(true)
                            .Color(Color.White);
                        milestonesDoc.Rows[0].Cells[1].Paragraphs[0].Append("Date")
                            .Bold(true)
                            .Color(Color.White);
                        milestonesDoc.Rows[0].Cells[2].Paragraphs[0].Append("Description")
                            .Bold(true)
                            .Color(Color.White);

                        milestonesDoc.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        milestonesDoc.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        milestonesDoc.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < currentTermsOfReferenceModel.Mile.Count + 1; i++)
                        {
                            milestonesDoc.Rows[i].Cells[0].Paragraphs[0].Append(currentTermsOfReferenceModel.Mile[i - 1].Milestone);
                            milestonesDoc.Rows[i].Cells[1].Paragraphs[0].Append(currentTermsOfReferenceModel.Mile[i - 1].Date);
                            milestonesDoc.Rows[i].Cells[2].Paragraphs[0].Append(currentTermsOfReferenceModel.Mile[i - 1].Description);
                        }

                        milestonesDoc.SetWidths(new float[] { 762, 762, 762 });
                        document.InsertTable(milestonesDoc);

                        var depSubHeading = document.InsertParagraph("4.4 Dependencies")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        depSubHeading.StyleId = "Heading2";

                        var dependDoc = document.AddTable(currentTermsOfReferenceModel.Dep.Count + 1, 5);
                        dependDoc.Rows[0].Cells[0].Paragraphs[0].Append("ProjectActivity")
                            .Bold(true)
                            .Color(Color.White);
                        dependDoc.Rows[0].Cells[1].Paragraphs[0].Append("Impacts")
                            .Bold(true)
                            .Color(Color.White);
                        dependDoc.Rows[0].Cells[2].Paragraphs[0].Append("Impacted By")
                            .Bold(true)
                            .Color(Color.White);
                        dependDoc.Rows[0].Cells[3].Paragraphs[0].Append("Critically")
                            .Bold(true)
                            .Color(Color.White);
                        dependDoc.Rows[0].Cells[4].Paragraphs[0].Append("Date")
                            .Bold(true)
                            .Color(Color.White);

                        dependDoc.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        dependDoc.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        dependDoc.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;
                        dependDoc.Rows[0].Cells[3].FillColor = TABLE_HEADER_COLOR;
                        dependDoc.Rows[0].Cells[4].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < currentTermsOfReferenceModel.Dep.Count + 1; i++)
                        {
                            dependDoc.Rows[i].Cells[0].Paragraphs[0].Append(currentTermsOfReferenceModel.Dep[i - 1].ProjectActivity);
                            dependDoc.Rows[i].Cells[1].Paragraphs[0].Append(currentTermsOfReferenceModel.Dep[i - 1].Impacts);
                            dependDoc.Rows[i].Cells[2].Paragraphs[0].Append(currentTermsOfReferenceModel.Dep[i - 1].ImpactedBy);
                            dependDoc.Rows[i].Cells[3].Paragraphs[0].Append(currentTermsOfReferenceModel.Dep[i - 1].Critically);
                            dependDoc.Rows[i].Cells[4].Paragraphs[0].Append(currentTermsOfReferenceModel.Dep[i - 1].Date);
                        }

                        dependDoc.SetWidths(new float[] { 762, 762, 762, 762, 762 });
                        document.InsertTable(dependDoc);

                        var resourcePlanSubHeading = document.InsertParagraph("4.5 Resource plan")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        resourcePlanSubHeading.StyleId = "Heading2";

                        var resourcePlanDoc = document.AddTable(currentTermsOfReferenceModel.ResP.Count + 1, 4);
                        resourcePlanDoc.Rows[0].Cells[0].Paragraphs[0].Append("Role")
                            .Bold(true)
                            .Color(Color.White);
                        resourcePlanDoc.Rows[0].Cells[1].Paragraphs[0].Append("Start Date")
                            .Bold(true)
                            .Color(Color.White);
                        resourcePlanDoc.Rows[0].Cells[2].Paragraphs[0].Append("End Date")
                            .Bold(true)
                            .Color(Color.White);
                        resourcePlanDoc.Rows[0].Cells[3].Paragraphs[0].Append("Effort")
                            .Bold(true)
                            .Color(Color.White);

                        resourcePlanDoc.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        resourcePlanDoc.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        resourcePlanDoc.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;
                        resourcePlanDoc.Rows[0].Cells[3].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < currentTermsOfReferenceModel.ResP.Count + 1; i++)
                        {
                            resourcePlanDoc.Rows[i].Cells[0].Paragraphs[0].Append(currentTermsOfReferenceModel.ResP[i - 1].Role);
                            resourcePlanDoc.Rows[i].Cells[1].Paragraphs[0].Append(currentTermsOfReferenceModel.ResP[i - 1].StartDate);
                            resourcePlanDoc.Rows[i].Cells[2].Paragraphs[0].Append(currentTermsOfReferenceModel.ResP[i - 1].EndDate);
                            resourcePlanDoc.Rows[i].Cells[3].Paragraphs[0].Append(currentTermsOfReferenceModel.ResP[i - 1].Effort);
                        }

                        resourcePlanDoc.SetWidths(new float[] { 762, 762, 762, 762 });
                        document.InsertTable(resourcePlanDoc);

                        var finPlanSubHeading = document.InsertParagraph("4.6 Financial plan")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        finPlanSubHeading.StyleId = "Heading2";

                        var finPlanDoc = document.AddTable(currentTermsOfReferenceModel.FinP.Count + 1, 3);
                        finPlanDoc.Rows[0].Cells[0].Paragraphs[0].Append("Expenditure Category")
                            .Bold(true)
                            .Color(Color.White);
                        finPlanDoc.Rows[0].Cells[1].Paragraphs[0].Append("Expenditure Item")
                            .Bold(true)
                            .Color(Color.White);
                        finPlanDoc.Rows[0].Cells[2].Paragraphs[0].Append("Expenditure Value")
                            .Bold(true)
                            .Color(Color.White);


                        finPlanDoc.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        finPlanDoc.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        finPlanDoc.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;


                        for (int i = 1; i < currentTermsOfReferenceModel.FinP.Count + 1; i++)
                        {
                            finPlanDoc.Rows[i].Cells[0].Paragraphs[0].Append(currentTermsOfReferenceModel.FinP[i - 1].ExpenditureCategory);
                            finPlanDoc.Rows[i].Cells[1].Paragraphs[0].Append(currentTermsOfReferenceModel.FinP[i - 1].ExpenditureItem);
                            finPlanDoc.Rows[i].Cells[2].Paragraphs[0].Append(currentTermsOfReferenceModel.FinP[i - 1].ExpenditureValue);
                        }

                        finPlanDoc.SetWidths(new float[] { 762, 762, 762 });
                        document.InsertTable(finPlanDoc);

                        var qpSubHeading = document.InsertParagraph("4.7 Quality plan")
                           .Bold()
                           .FontSize(14d)
                           .Color(Color.Black)
                           .Bold(true)
                           .Font("Arial");

                        qpSubHeading.StyleId = "Heading2";

                        var qPlanDoc = document.AddTable(currentTermsOfReferenceModel.QuaP.Count + 1, 2);
                        qPlanDoc.Rows[0].Cells[0].Paragraphs[0].Append("Process")
                            .Bold(true)
                            .Color(Color.White);
                        qPlanDoc.Rows[0].Cells[1].Paragraphs[0].Append("Description")
                            .Bold(true)
                            .Color(Color.White);

                        qPlanDoc.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        qPlanDoc.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;


                        for (int i = 1; i < currentTermsOfReferenceModel.QuaP.Count + 1; i++)
                        {
                            qPlanDoc.Rows[i].Cells[0].Paragraphs[0].Append(currentTermsOfReferenceModel.QuaP[i - 1].Process);
                            qPlanDoc.Rows[i].Cells[1].Paragraphs[0].Append(currentTermsOfReferenceModel.QuaP[i - 1].Description);
                        }

                        qPlanDoc.SetWidths(new float[] { 762, 762 });
                        document.InsertTable(qPlanDoc);

                        var compcHeading = document.InsertParagraph("4.8 Completion Criteria")
                           .Bold()
                           .FontSize(14d)
                           .Color(Color.Black)
                           .Bold(true)
                           .Font("Arial");

                        compcHeading.StyleId = "Heading2";

                        var compcDoc = document.AddTable(currentTermsOfReferenceModel.CompC.Count + 1, 2);
                        compcDoc.Rows[0].Cells[0].Paragraphs[0].Append("Process")
                            .Bold(true)
                            .Color(Color.White);
                        compcDoc.Rows[0].Cells[1].Paragraphs[0].Append("Description")
                            .Bold(true)
                            .Color(Color.White);

                        compcDoc.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        compcDoc.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;


                        for (int i = 1; i < currentTermsOfReferenceModel.CompC.Count + 1; i++)
                        {
                            compcDoc.Rows[i].Cells[0].Paragraphs[0].Append(currentTermsOfReferenceModel.CompC[i - 1].Process);
                            compcDoc.Rows[i].Cells[1].Paragraphs[0].Append(currentTermsOfReferenceModel.CompC[i - 1].Description);
                        }

                        compcDoc.SetWidths(new float[] { 762, 762 });
                        document.InsertTable(compcDoc);

                        var considerationsHeading = document.InsertParagraph("5 Project considerations")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        considerationsHeading.StyleId = "Heading1";

                        var riskSubHeading = document.InsertParagraph("5.1 Risks")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        riskSubHeading.StyleId = "Heading2";

                        var riskDoc = document.AddTable(currentTermsOfReferenceModel.Risk.Count + 1, 4);
                        riskDoc.Rows[0].Cells[0].Paragraphs[0].Append("Role")
                            .Bold(true)
                            .Color(Color.White);
                        riskDoc.Rows[0].Cells[1].Paragraphs[0].Append("Start Date")
                            .Bold(true)
                            .Color(Color.White);
                        riskDoc.Rows[0].Cells[2].Paragraphs[0].Append("End Date")
                            .Bold(true)
                            .Color(Color.White);
                        riskDoc.Rows[0].Cells[3].Paragraphs[0].Append("Effort")
                            .Bold(true)
                            .Color(Color.White);

                        riskDoc.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        riskDoc.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        riskDoc.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;
                        riskDoc.Rows[0].Cells[3].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < currentTermsOfReferenceModel.Risk.Count + 1; i++)
                        {
                            riskDoc.Rows[i].Cells[0].Paragraphs[0].Append(currentTermsOfReferenceModel.Risk[i - 1].RiskDesc);
                            riskDoc.Rows[i].Cells[1].Paragraphs[0].Append(currentTermsOfReferenceModel.Risk[i - 1].RiskLikelihood);
                            riskDoc.Rows[i].Cells[2].Paragraphs[0].Append(currentTermsOfReferenceModel.Risk[i - 1].RiskImpact);
                            riskDoc.Rows[i].Cells[3].Paragraphs[0].Append(currentTermsOfReferenceModel.Risk[i - 1].Action);
                        }

                        riskDoc.SetWidths(new float[] { 762, 762, 762, 762 });
                        document.InsertTable(riskDoc);

                        var issuesSubHeading = document.InsertParagraph("5.2 Issues")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        issuesSubHeading.StyleId = "Heading2";

                        var issuesDoc = document.AddTable(currentTermsOfReferenceModel.theIssuess.Count + 1, 3);
                        issuesDoc.Rows[0].Cells[0].Paragraphs[0].Append("Issue Description")
                            .Bold(true)
                            .Color(Color.White);
                        issuesDoc.Rows[0].Cells[1].Paragraphs[0].Append("Issue Priority")
                            .Bold(true)
                            .Color(Color.White);
                        issuesDoc.Rows[0].Cells[2].Paragraphs[0].Append("Action")
                            .Bold(true)
                            .Color(Color.White);


                        issuesDoc.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        issuesDoc.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        issuesDoc.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;


                        for (int i = 1; i < currentTermsOfReferenceModel.theIssuess.Count + 1; i++)
                        {
                            issuesDoc.Rows[i].Cells[0].Paragraphs[0].Append(currentTermsOfReferenceModel.theIssuess[i - 1].IssueDescription);
                            issuesDoc.Rows[i].Cells[1].Paragraphs[0].Append(currentTermsOfReferenceModel.theIssuess[i - 1].IssuePriority);
                            issuesDoc.Rows[i].Cells[2].Paragraphs[0].Append(currentTermsOfReferenceModel.theIssuess[i - 1].Action);

                        }

                        issuesDoc.SetWidths(new float[] { 762, 762, 762 });
                        document.InsertTable(issuesDoc);

                        var assHeading = document.InsertParagraph("5.3 Asssumptions")
                     .Bold()
                     .FontSize(12d)
                     .Color(Color.Black)
                     .Bold(true)
                     .Font("Arial");

                        document.InsertParagraph(currentTermsOfReferenceModel.Assumptions)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;


                        assHeading.StyleId = "Heading2";

                        var contHeading = document.InsertParagraph("5.4 Contraints")
                    .Bold()
                    .FontSize(12d)
                    .Color(Color.Black)
                    .Bold(true)
                    .Font("Arial");

                        document.InsertParagraph(currentTermsOfReferenceModel.Constraints)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;


                        contHeading.StyleId = "Heading2";

                        try
                        {
                            document.Save();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("The selected File is open.", "Close File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }


                }
                else
                {
                    MessageBox.Show("Not saved");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            exportToWord();
        }
    }   
}
