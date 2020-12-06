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
using Xceed.Words.NET;
using Xceed.Document.NET;

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
                    dgvDocumentHistories.Rows.Add(new string[] { item.Version, item.IssueDate, item.Changes });
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

            if (!versionControl.isEqual(currentProjectCharterModel, newProjectCharterModel))
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
            string path;
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                saveFileDialog.Filter = "Word 97-2003 Documents (*.doc)|*.doc|Word 2007 Documents (*.docx)|*.docx";
                saveFileDialog.FilterIndex = 2;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    path = saveFileDialog.FileName;
                    using (var document = DocX.Create(path))
                    {
                        #region Front Page
                        for (int i = 0; i < 11; i++)
                        {
                            document.InsertParagraph("")
                                .Font("Arial")
                                .Bold(true)
                                .FontSize(22d).Alignment = Alignment.left;
                        }

                        document.InsertParagraph("Project Charter \nFor " + currentProjectCharterModel.ProjectName)
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
                        #endregion

                        #region Document Basics
                        var documentInfoTable = document.AddTable(6, 2);
                        documentInfoTable.Rows[0].Cells[0].Paragraphs[0].Append("").Bold(true).Color(Color.White);
                        documentInfoTable.Rows[0].Cells[1].Paragraphs[0].Append("Information").Bold(true).Color(Color.White);
                        documentInfoTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        documentInfoTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;

                        documentInfoTable.Rows[1].Cells[0].Paragraphs[0].Append("Document ID");
                        documentInfoTable.Rows[1].Cells[1].Paragraphs[0].Append(currentProjectCharterModel.DocumentID);

                        documentInfoTable.Rows[2].Cells[0].Paragraphs[0].Append("Document Owner");
                        documentInfoTable.Rows[2].Cells[1].Paragraphs[0].Append(currentProjectCharterModel.DocumentOwner);

                        documentInfoTable.Rows[3].Cells[0].Paragraphs[0].Append("Issue Date");
                        documentInfoTable.Rows[3].Cells[1].Paragraphs[0].Append(currentProjectCharterModel.IssueDate);

                        documentInfoTable.Rows[4].Cells[0].Paragraphs[0].Append("Last Saved Date");
                        documentInfoTable.Rows[4].Cells[1].Paragraphs[0].Append(currentProjectCharterModel.LastSavedDate);

                        documentInfoTable.Rows[5].Cells[0].Paragraphs[0].Append("File Name");
                        documentInfoTable.Rows[5].Cells[1].Paragraphs[0].Append(currentProjectCharterModel.FileName);
                        documentInfoTable.SetWidths(new float[] { 493, 1094 });
                        document.InsertTable(documentInfoTable);

                        document.InsertParagraph("\nDocument History\n")
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(14d).Alignment = Alignment.left;

                        var documentHistoryTable = document.AddTable(currentProjectCharterModel.DocumentHistories.Count + 1, 3);
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

                        for (int i = 1; i < currentProjectCharterModel.DocumentHistories.Count + 1; i++)
                        {
                            documentHistoryTable.Rows[i].Cells[0].Paragraphs[0].Append(currentProjectCharterModel.DocumentHistories[i - 1].Version);
                            documentHistoryTable.Rows[i].Cells[1].Paragraphs[0].Append(currentProjectCharterModel.DocumentHistories[i - 1].IssueDate);
                            documentHistoryTable.Rows[i].Cells[2].Paragraphs[0].Append(currentProjectCharterModel.DocumentHistories[i - 1].Changes);

                        }

                        documentHistoryTable.SetWidths(new float[] { 190, 303, 1094 });
                        document.InsertTable(documentHistoryTable);

                        document.InsertParagraph("\nDocument Approvals\n")
                           .Font("Arial")
                           .Bold(true)
                           .FontSize(14d).Alignment = Alignment.left;

                        var documentApprovalTable = document.AddTable(currentProjectCharterModel.DocumentApprovals.Count + 1, 4);
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

                        for (int i = 1; i < currentProjectCharterModel.DocumentApprovals.Count + 1; i++)
                        {
                            documentApprovalTable.Rows[i].Cells[0].Paragraphs[0].Append(currentProjectCharterModel.DocumentApprovals[i - 1].Role);
                            documentApprovalTable.Rows[i].Cells[1].Paragraphs[0].Append(currentProjectCharterModel.DocumentApprovals[i - 1].Name);
                            documentApprovalTable.Rows[i].Cells[2].Paragraphs[0].Append(currentProjectCharterModel.DocumentApprovals[i - 1].Signature);
                            documentApprovalTable.Rows[i].Cells[3].Paragraphs[0].Append(currentProjectCharterModel.DocumentApprovals[i - 1].DateApproved);
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

                        document.InsertTableOfContents(p, "", tocSwitches);
                        document.InsertParagraph().InsertPageBreakAfterSelf();
                        #endregion

                        #region Executive Summary
                        var execSummaryHeading = document.InsertParagraph("1 Executive Summary")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        execSummaryHeading.StyleId = "Heading1";

                        document.InsertParagraph(String.Join(",\n", currentProjectCharterModel.ExecutiveSummary))
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;
                        #endregion

                        #region Project Definition
                        var projDefHeading = document.InsertParagraph("2 Project Definition")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        projDefHeading.StyleId = "Heading1";

                        //Project Definition
                        var projDefSubHeading = document.InsertParagraph("2.1 Project Definition")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        projDefSubHeading.StyleId = "Heading2";

                        document.InsertParagraph(String.Join(",\n", currentProjectCharterModel.ProjectDefinition))
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        //Vision
                        var projVisSubHeading = document.InsertParagraph("2.2 Vision")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        projVisSubHeading.StyleId = "Heading2";

                        document.InsertParagraph(String.Join(",\n", currentProjectCharterModel.Vision))
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        //Objectives
                        var projObjSubHeading = document.InsertParagraph("2.3 Objectives")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        projObjSubHeading.StyleId = "Heading2";

                        document.InsertParagraph(String.Join(",\n", currentProjectCharterModel.Objectives))
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        //Scope
                        var projScopeSubHeading = document.InsertParagraph("2.4 Scope")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        projScopeSubHeading.StyleId = "Heading2";

                        document.InsertParagraph(String.Join(",\n", currentProjectCharterModel.Scope))
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;
                        #endregion

                        #region Project Organisation
                        var projOrgHeading = document.InsertParagraph("3 Project Organisation")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        projOrgHeading.StyleId = "Heading1";

                        //Customers
                        var projCustSubHeading = document.InsertParagraph("3.1 Customers")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        projCustSubHeading.StyleId = "Heading2";

                        var customersTable = document.AddTable(currentProjectCharterModel.Customers.Count + 1, 2);

                        customersTable.Rows[0].Cells[0].Paragraphs[0].Append("Customer Group")
                            .Bold(true)
                            .Color(Color.White);
                        customersTable.Rows[0].Cells[1].Paragraphs[0].Append("Customer Representative")
                            .Bold(true)
                            .Color(Color.White);

                        customersTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        customersTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < currentProjectCharterModel.Customers.Count + 1; i++)
                        {
                            customersTable.Rows[i].Cells[0].Paragraphs[0].Append(currentProjectCharterModel.Customers[i - 1].CustomerGroup);
                            customersTable.Rows[i].Cells[1].Paragraphs[0].Append(currentProjectCharterModel.Customers[i - 1].CustomerRepresentative);
                        }

                        document.InsertTable(customersTable);

                        //Customers
                        var projStSubHeading = document.InsertParagraph("3.2 Stakeholders")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        projStSubHeading.StyleId = "Heading2";

                        var stakeholdersTable = document.AddTable(currentProjectCharterModel.Stakeholders.Count + 1, 2);

                        stakeholdersTable.Rows[0].Cells[0].Paragraphs[0].Append("Stakeholder / Group")
                            .Bold(true)
                            .Color(Color.White);
                        stakeholdersTable.Rows[0].Cells[1].Paragraphs[0].Append("Stakeholder Interest")
                            .Bold(true)
                            .Color(Color.White);

                        stakeholdersTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        stakeholdersTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < currentProjectCharterModel.Stakeholders.Count + 1; i++)
                        {
                            stakeholdersTable.Rows[i].Cells[0].Paragraphs[0].Append(currentProjectCharterModel.Stakeholders[i - 1].StakeholderGroup);
                            stakeholdersTable.Rows[i].Cells[1].Paragraphs[0].Append(currentProjectCharterModel.Stakeholders[i - 1].Interest);
                        }

                        document.InsertTable(stakeholdersTable);

                        //Roles
                        var projRolesSubHeading = document.InsertParagraph("3.3 Roles")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        projRolesSubHeading.StyleId = "Heading2";

                        document.InsertParagraph(String.Join(",\n", currentProjectCharterModel.Roles))
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        //Responsibilities
                        var projResSubHeading = document.InsertParagraph("3.4 Responsibilities")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        projResSubHeading.StyleId = "Heading2";

                        document.InsertParagraph(String.Join(",\n", currentProjectCharterModel.Responsibilities))
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        //Structure
                        var projStrSubHeading = document.InsertParagraph("3.5 Structure")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        projStrSubHeading.StyleId = "Heading2";

                        document.InsertParagraph(String.Join(",\n", currentProjectCharterModel.Structure))
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        #endregion

                        #region Implementation Plan
                        var impPlanHeading = document.InsertParagraph("4 Implementation Plan")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        impPlanHeading.StyleId = "Heading1";

                        //Approach
                        var impAppSubHeading = document.InsertParagraph("4.1 Approach")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        impAppSubHeading.StyleId = "Heading2";

                        var approachTable = document.AddTable(currentProjectCharterModel.Approaches.Count + 1, 2);

                        approachTable.Rows[0].Cells[0].Paragraphs[0].Append("Phase")
                            .Bold(true)
                            .Color(Color.White);
                        approachTable.Rows[0].Cells[1].Paragraphs[0].Append("Overall Approach")
                            .Bold(true)
                            .Color(Color.White);

                        approachTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        approachTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < currentProjectCharterModel.Approaches.Count + 1; i++)
                        {
                            approachTable.Rows[i].Cells[0].Paragraphs[0].Append(currentProjectCharterModel.Approaches[i - 1].Phase);
                            approachTable.Rows[i].Cells[1].Paragraphs[0].Append(currentProjectCharterModel.Approaches[i - 1].OverallApproach);
                        }

                        document.InsertTable(approachTable);

                        //Schedule
                        var impSchSubHeading = document.InsertParagraph("4.2 Schedule")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        impSchSubHeading.StyleId = "Heading2";

                        document.InsertParagraph(String.Join(",\n", currentProjectCharterModel.Schedule))
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        //Milestones
                        var impMilSubHeading = document.InsertParagraph("4.3 Milestones")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        impMilSubHeading.StyleId = "Heading2";

                        var milesStonesTable = document.AddTable(currentProjectCharterModel.Milestones.Count + 1, 3);

                        milesStonesTable.Rows[0].Cells[0].Paragraphs[0].Append("Milestone")
                            .Bold(true)
                            .Color(Color.White);
                        milesStonesTable.Rows[0].Cells[1].Paragraphs[0].Append("Date")
                            .Bold(true)
                            .Color(Color.White);
                        milesStonesTable.Rows[0].Cells[2].Paragraphs[0].Append("Description")
                            .Bold(true)
                            .Color(Color.White);

                        milesStonesTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        milesStonesTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        milesStonesTable.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < currentProjectCharterModel.Milestones.Count + 1; i++)
                        {
                            milesStonesTable.Rows[i].Cells[0].Paragraphs[0].Append(currentProjectCharterModel.Milestones[i - 1].MilestoneName);
                            milesStonesTable.Rows[i].Cells[1].Paragraphs[0].Append(currentProjectCharterModel.Milestones[i - 1].Date);
                            milesStonesTable.Rows[i].Cells[2].Paragraphs[0].Append(currentProjectCharterModel.Milestones[i - 1].MilestoneDescription);
                        }

                        document.InsertTable(milesStonesTable);

                        //Dependencies
                        var impDepSubHeading = document.InsertParagraph("4.4 Dependencies")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        impDepSubHeading.StyleId = "Heading2";

                        var depTable = document.AddTable(currentProjectCharterModel.Dependencies.Count + 1, 5);

                        depTable.Rows[0].Cells[0].Paragraphs[0].Append("Project Activity")
                            .Bold(true)
                            .Color(Color.White);
                        depTable.Rows[0].Cells[1].Paragraphs[0].Append("Impacts")
                            .Bold(true)
                            .Color(Color.White);
                        depTable.Rows[0].Cells[2].Paragraphs[0].Append("Is Impacted By")
                            .Bold(true)
                            .Color(Color.White);
                        depTable.Rows[0].Cells[3].Paragraphs[0].Append("Criticality")
                            .Bold(true)
                            .Color(Color.White);
                        depTable.Rows[0].Cells[4].Paragraphs[0].Append("Date")
                            .Bold(true)
                            .Color(Color.White);

                        depTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        depTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        depTable.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;
                        depTable.Rows[0].Cells[3].FillColor = TABLE_HEADER_COLOR;
                        depTable.Rows[0].Cells[4].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < currentProjectCharterModel.Dependencies.Count + 1; i++)
                        {
                            depTable.Rows[i].Cells[0].Paragraphs[0].Append(currentProjectCharterModel.Dependencies[i - 1].ProjectActivity);
                            depTable.Rows[i].Cells[1].Paragraphs[0].Append(currentProjectCharterModel.Dependencies[i - 1].Impacts);
                            depTable.Rows[i].Cells[2].Paragraphs[0].Append(currentProjectCharterModel.Dependencies[i - 1].IsImpactedBy);
                            depTable.Rows[i].Cells[3].Paragraphs[0].Append(currentProjectCharterModel.Dependencies[i - 1].Criticality);
                            depTable.Rows[i].Cells[4].Paragraphs[0].Append(currentProjectCharterModel.Dependencies[i - 1].Date);

                        }

                        document.InsertTable(depTable);

                        //Resource Plan
                        var impRecPlSubHeading = document.InsertParagraph("4.5 Resource Plan")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        impRecPlSubHeading.StyleId = "Heading2";

                        var resourcePlanTable = document.AddTable(currentProjectCharterModel.ResourcePlans.Count + 1, 4);

                        resourcePlanTable.Rows[0].Cells[0].Paragraphs[0].Append("Role")
                            .Bold(true)
                            .Color(Color.White);
                        resourcePlanTable.Rows[0].Cells[1].Paragraphs[0].Append("Start Date")
                            .Bold(true)
                            .Color(Color.White);
                        resourcePlanTable.Rows[0].Cells[2].Paragraphs[0].Append("End Date")
                            .Bold(true)
                            .Color(Color.White);
                        resourcePlanTable.Rows[0].Cells[3].Paragraphs[0].Append("% Effort")
                            .Bold(true)
                            .Color(Color.White);

                        resourcePlanTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        resourcePlanTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        resourcePlanTable.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;
                        resourcePlanTable.Rows[0].Cells[3].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < currentProjectCharterModel.ResourcePlans.Count + 1; i++)
                        {
                            resourcePlanTable.Rows[i].Cells[0].Paragraphs[0].Append(currentProjectCharterModel.ResourcePlans[i - 1].Role);
                            resourcePlanTable.Rows[i].Cells[1].Paragraphs[0].Append(currentProjectCharterModel.ResourcePlans[i - 1].StartDate);
                            resourcePlanTable.Rows[i].Cells[2].Paragraphs[0].Append(currentProjectCharterModel.ResourcePlans[i - 1].EndDate);
                            resourcePlanTable.Rows[i].Cells[3].Paragraphs[0].Append(currentProjectCharterModel.ResourcePlans[i - 1].Effort);
                        }

                        document.InsertTable(resourcePlanTable);

                        //Financial Plan
                        var impFinSubHeading = document.InsertParagraph("4.6 Financial Plan")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        impFinSubHeading.StyleId = "Heading2";

                        var finPlanTable = document.AddTable(currentProjectCharterModel.FinancialPlans.Count + 1, 3);

                        finPlanTable.Rows[0].Cells[0].Paragraphs[0].Append("Expenditure Category")
                            .Bold(true)
                            .Color(Color.White);
                        finPlanTable.Rows[0].Cells[1].Paragraphs[0].Append("Expenditure Item")
                            .Bold(true)
                            .Color(Color.White);
                        finPlanTable.Rows[0].Cells[2].Paragraphs[0].Append("Expenditure Value")
                            .Bold(true)
                            .Color(Color.White);

                        finPlanTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        finPlanTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        finPlanTable.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < currentProjectCharterModel.FinancialPlans.Count + 1; i++)
                        {
                            finPlanTable.Rows[i].Cells[0].Paragraphs[0].Append(currentProjectCharterModel.FinancialPlans[i - 1].ExpenditureCategory);
                            finPlanTable.Rows[i].Cells[1].Paragraphs[0].Append(currentProjectCharterModel.FinancialPlans[i - 1].ExpenditureItem);
                            finPlanTable.Rows[i].Cells[2].Paragraphs[0].Append(currentProjectCharterModel.FinancialPlans[i - 1].ExpenditureValue);
                        }

                        document.InsertTable(finPlanTable);

                        //Quality Plan
                        var impQualSubHeading = document.InsertParagraph("4.7 Quality Plan")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        impQualSubHeading.StyleId = "Heading2";

                        var qualityPlanTable = document.AddTable(currentProjectCharterModel.QualityPlans.Count + 1, 2);

                        qualityPlanTable.Rows[0].Cells[0].Paragraphs[0].Append("Process")
                            .Bold(true)
                            .Color(Color.White);
                        qualityPlanTable.Rows[0].Cells[1].Paragraphs[0].Append("Description")
                            .Bold(true)
                            .Color(Color.White);

                        qualityPlanTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        qualityPlanTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < currentProjectCharterModel.QualityPlans.Count + 1; i++)
                        {
                            qualityPlanTable.Rows[i].Cells[0].Paragraphs[0].Append(currentProjectCharterModel.QualityPlans[i - 1].Process);
                            qualityPlanTable.Rows[i].Cells[1].Paragraphs[0].Append(currentProjectCharterModel.QualityPlans[i - 1].Description);
                        }
                    
                        document.InsertTable(qualityPlanTable);

                        //Completion Criteria
                        var impCompSubHeading = document.InsertParagraph("4.8 Completion Criteria")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        impCompSubHeading.StyleId = "Heading2";

                        var compTable = document.AddTable(currentProjectCharterModel.CompletionCriterias.Count + 1, 2);

                        compTable.Rows[0].Cells[0].Paragraphs[0].Append("Process")
                            .Bold(true)
                            .Color(Color.White);
                        compTable.Rows[0].Cells[1].Paragraphs[0].Append("Description")
                            .Bold(true)
                            .Color(Color.White);

                        compTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        compTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < currentProjectCharterModel.CompletionCriterias.Count + 1; i++)
                        {
                            compTable.Rows[i].Cells[0].Paragraphs[0].Append(currentProjectCharterModel.CompletionCriterias[i - 1].Process);
                            compTable.Rows[i].Cells[1].Paragraphs[0].Append(currentProjectCharterModel.CompletionCriterias[i - 1].Description);
                        }

                        document.InsertTable(compTable);
                        #endregion

                        #region Project Considerations
                        var projConsidHeading = document.InsertParagraph("5 Project Considerations")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        projConsidHeading.StyleId = "Heading1";

                        //Risks
                        var projConsidRisksSubHeading = document.InsertParagraph("5.1 Risks")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        projConsidRisksSubHeading.StyleId = "Heading2";

                        var riskTable = document.AddTable(currentProjectCharterModel.Risks.Count + 1, 4);

                        riskTable.Rows[0].Cells[0].Paragraphs[0].Append("Risk Description")
                            .Bold(true)
                            .Color(Color.White);
                        riskTable.Rows[0].Cells[1].Paragraphs[0].Append("Likelihood")
                            .Bold(true)
                            .Color(Color.White);
                        riskTable.Rows[0].Cells[2].Paragraphs[0].Append("Impact")
                            .Bold(true)
                            .Color(Color.White);
                        riskTable.Rows[0].Cells[3].Paragraphs[0].Append("Actions to be Taken to Mitigate Risk")
                            .Bold(true)
                            .Color(Color.White);

                        riskTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        riskTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        riskTable.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;
                        riskTable.Rows[0].Cells[3].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < currentProjectCharterModel.Risks.Count + 1; i++)
                        {
                            riskTable.Rows[i].Cells[0].Paragraphs[0].Append(currentProjectCharterModel.Risks[i - 1].Description);
                            riskTable.Rows[i].Cells[1].Paragraphs[0].Append(currentProjectCharterModel.Risks[i - 1].Likelihood);
                            riskTable.Rows[i].Cells[2].Paragraphs[0].Append(currentProjectCharterModel.Risks[i - 1].Impact);
                            riskTable.Rows[i].Cells[3].Paragraphs[0].Append(currentProjectCharterModel.Risks[i - 1].Action);
                        }

                        document.InsertTable(riskTable);

                        //Issues
                        var projConsidIssueSubHeading = document.InsertParagraph("5.2 Issues")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        projConsidIssueSubHeading.StyleId = "Heading2";

                        var issuesTable = document.AddTable(currentProjectCharterModel.Issues.Count + 1, 3);

                        issuesTable.Rows[0].Cells[0].Paragraphs[0].Append("Issue Description")
                            .Bold(true)
                            .Color(Color.White);
                        issuesTable.Rows[0].Cells[1].Paragraphs[0].Append("Priority")
                            .Bold(true)
                            .Color(Color.White);
                        issuesTable.Rows[0].Cells[2].Paragraphs[0].Append("Actions to be Taken to Resolve Issue")
                            .Bold(true)
                            .Color(Color.White);

                        issuesTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        issuesTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        issuesTable.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < currentProjectCharterModel.Issues.Count + 1; i++)
                        {
                            issuesTable.Rows[i].Cells[0].Paragraphs[0].Append(currentProjectCharterModel.Issues[i - 1].Description);
                            issuesTable.Rows[i].Cells[1].Paragraphs[0].Append(currentProjectCharterModel.Issues[i - 1].Priority);
                            issuesTable.Rows[i].Cells[2].Paragraphs[0].Append(currentProjectCharterModel.Issues[i - 1].Action);
                        }

                        document.InsertTable(issuesTable);

                        //Assumptions
                        var projConsidAssumSubHeading = document.InsertParagraph("5.3 Assumptions")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        projConsidAssumSubHeading.StyleId = "Heading2";

                        document.InsertParagraph(String.Join(",\n", currentProjectCharterModel.Assumptions))
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        //Constraints
                        var projConsidConstSubHeading = document.InsertParagraph("5.4 Constraints")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        projConsidConstSubHeading.StyleId = "Heading2";

                        document.InsertParagraph(String.Join(",\n", currentProjectCharterModel.Constraints))
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;
                        #endregion

                        #region Appendix
                        //Appendix
                        var appendixHeading = document.InsertParagraph("Appendix")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        appendixHeading.StyleId = "Heading1";

                        document.InsertParagraph(String.Join(",\n", currentProjectCharterModel.Appendix))
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;
                        #endregion

                        try
                        {
                            document.Save();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("The selected file is open.", "Close File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
    }
}
