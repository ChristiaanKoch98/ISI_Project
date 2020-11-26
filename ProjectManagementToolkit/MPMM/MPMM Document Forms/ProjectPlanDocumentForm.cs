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
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Forms
{
    public partial class ProjectPlanDocumentForm : Form
    {
        VersionControl<ProjectPlanModel> versionControl;
        ProjectPlanModel newProjectPlanModel;
        ProjectPlanModel currentProjectPlanModel;
        Color TABLE_HEADER_COLOR = Color.FromArgb(73, 173, 252);
        ProjectModel projectModel = new ProjectModel();
        public ProjectPlanDocumentForm()
        {
            InitializeComponent();
        }

        private void ProjectPlanDocumentForm_Load(object sender, EventArgs e)
        {
            loadDocument();
            string json = JsonHelper.loadProjectInfo(Settings.Default.Username);
            List<ProjectModel> projectListModel = JsonConvert.DeserializeObject<List<ProjectModel>>(json);
            projectModel = projectModel.getProjectModel(Settings.Default.ProjectID, projectListModel);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveDocument();
        }

        private void btnExportWord_Click(object sender, EventArgs e)
        {
            exportToWord();
        }

        public void saveDocument()
        {
            newProjectPlanModel.DocumentID = documentInformation.Rows[0].Cells[1].Value.ToString();
            newProjectPlanModel.DocumentOwner = documentInformation.Rows[1].Cells[1].Value.ToString();
            newProjectPlanModel.IssueDate = documentInformation.Rows[2].Cells[1].Value.ToString();
            newProjectPlanModel.LastSavedDate = documentInformation.Rows[3].Cells[1].Value.ToString();
            newProjectPlanModel.FileName = documentInformation.Rows[4].Cells[1].Value.ToString();

            List<ProjectPlanModel.DocumentHistory> documentHistories = new List<ProjectPlanModel.DocumentHistory>();

            int versionRowsCount = documentHistoryDataGridView.Rows.Count;

            for (int i = 0; i < versionRowsCount - 1; i++)
            {
                ProjectPlanModel.DocumentHistory documentHistoryModel = new ProjectPlanModel.DocumentHistory();
                var version = documentHistoryDataGridView.Rows[i].Cells[0].Value?.ToString() ?? "";
                var issueDate = documentHistoryDataGridView.Rows[i].Cells[1].Value?.ToString() ?? "";
                var changes = documentHistoryDataGridView.Rows[i].Cells[2].Value?.ToString() ?? "";
                documentHistoryModel.Version = version;
                documentHistoryModel.IssueDate = issueDate;
                documentHistoryModel.Changes = changes;
                documentHistories.Add(documentHistoryModel);
            }
            newProjectPlanModel.DocumentHistories = documentHistories;

            List<ProjectPlanModel.DocumentApproval> documentApprovalsModel = new List<ProjectPlanModel.DocumentApproval>();

            int approvalRowsCount = documentApprovalsDataGridView.Rows.Count;

            for (int i = 0; i < approvalRowsCount - 1; i++)
            {
                ProjectPlanModel.DocumentApproval documentApproval = new ProjectPlanModel.DocumentApproval();
                var role = documentApprovalsDataGridView.Rows[i].Cells[0].Value?.ToString() ?? "";
                var name = documentApprovalsDataGridView.Rows[i].Cells[1].Value?.ToString() ?? "";
                var signature = documentApprovalsDataGridView.Rows[i].Cells[2].Value?.ToString() ?? "";
                var date = documentApprovalsDataGridView.Rows[i].Cells[3].Value?.ToString() ?? "";
                documentApproval.Role = role;
                documentApproval.Name = name;
                documentApproval.Signature = signature;
                documentApproval.DateApproved = date;

                documentApprovalsModel.Add(documentApproval);
            }
            newProjectPlanModel.DocumentApprovals = documentApprovalsModel;

            List<ProjectPlanModel.Phase> phases = new List<ProjectPlanModel.Phase>();

            int phaseRowsCount = phasesDataGridView.Rows.Count;

            for (int i = 0; i < phaseRowsCount - 1; i++)
            {
                ProjectPlanModel.Phase phase = new ProjectPlanModel.Phase();
                var phaseTitle = phasesDataGridView.Rows[i].Cells[0].Value?.ToString() ?? "";
                var phaseDescription = phasesDataGridView.Rows[i].Cells[1].Value?.ToString() ?? "";
                var phaseSequence = phasesDataGridView.Rows[i].Cells[2].Value?.ToString() ?? "";

                phase.PhaseTitle = phaseTitle;
                phase.PhaseDescription = phaseDescription;
                phase.PhaseSequence = phaseSequence;

                phases.Add(phase);
            }
            newProjectPlanModel.Phases = phases;

            List<ProjectPlanModel.Activity> activities = new List<ProjectPlanModel.Activity>();
            int activityRowsCount = activitiesDataGridView.Rows.Count;

            for (int i = 0; i < activityRowsCount - 1; i++)
            {
                ProjectPlanModel.Activity activity = new ProjectPlanModel.Activity();
                var phaseTitle = activitiesDataGridView.Rows[i].Cells[0].Value?.ToString() ?? "";
                var activityTitle = activitiesDataGridView.Rows[i].Cells[1].Value?.ToString() ?? "";
                var activityDescription = activitiesDataGridView.Rows[i].Cells[2].Value?.ToString() ?? "";
                var activitySequence = activitiesDataGridView.Rows[i].Cells[3].Value?.ToString() ?? "";

                activity.PhaseTitle = phaseTitle;
                activity.ActivityTitle = activityTitle;
                activity.ActivityDescription = activityDescription;
                activity.ActivitySequence = activitySequence;

                activities.Add(activity);
            }
            newProjectPlanModel.Activities = activities;

            List<ProjectPlanModel.Task> tasks = new List<ProjectPlanModel.Task>();
            int tasksRowsCount = tasksDataGridView.Rows.Count;
            for (int i = 0; i < tasksRowsCount - 1; i++)
            {
                ProjectPlanModel.Task task = new ProjectPlanModel.Task();
                var activityTitle = tasksDataGridView.Rows[i].Cells[0].Value?.ToString() ?? "";
                var taskTitle = tasksDataGridView.Rows[i].Cells[1].Value?.ToString() ?? "";
                var taskDescription = tasksDataGridView.Rows[i].Cells[2].Value?.ToString() ?? "";
                var taskSequence = tasksDataGridView.Rows[i].Cells[3].Value?.ToString() ?? "";

                task.ActivityTitle = activityTitle;
                task.TaskTitle = taskTitle;
                task.TaskDescription = taskDescription;
                task.TaskSequence = taskSequence;

                tasks.Add(task);
            }
            newProjectPlanModel.Tasks = tasks;

            List<ProjectPlanModel.Milestone> milestones = new List<ProjectPlanModel.Milestone>();
            int milestoneRowsCount = milestonesDataGridView.Rows.Count;
            for (int i = 0; i < milestoneRowsCount - 1; i++)
            {
                ProjectPlanModel.Milestone milestone = new ProjectPlanModel.Milestone();
                var milestoneTitle = milestonesDataGridView.Rows[i].Cells[0].Value?.ToString() ?? "";
                var milestoneDescription = milestonesDataGridView.Rows[i].Cells[1].Value?.ToString() ?? "";
                var milestoneDate = milestonesDataGridView.Rows[i].Cells[2].Value?.ToString() ?? "";

                milestone.MilestoneTitle = milestoneTitle;
                milestone.MilestoneDescription = milestoneDescription;
                milestone.MilestoneDate = milestoneDate;

                milestones.Add(milestone);
            }
            newProjectPlanModel.Milestones = milestones;

            List<ProjectPlanModel.Effort> efforts = new List<ProjectPlanModel.Effort>();
            int effortRowsCount = effortDataGridView.Rows.Count;
            for (int i = 0; i < effortRowsCount - 1; i++)
            {
                ProjectPlanModel.Effort effort = new ProjectPlanModel.Effort();
                var taskTitle = effortDataGridView.Rows[i].Cells[0].Value?.ToString() ?? "";
                var resource = effortDataGridView.Rows[i].Cells[1].Value?.ToString() ?? "";
                var effortMade = effortDataGridView.Rows[i].Cells[2].Value?.ToString() ?? "";

                effort.TaskTitle = taskTitle;
                effort.Resource = resource;
                effort.EffortMade = effortMade;

                efforts.Add(effort);
            }
            newProjectPlanModel.Efforts = efforts;

            List<ProjectPlanModel.Dependency> dependencies = new List<ProjectPlanModel.Dependency>();
            int dependenciesRowsCount = dependenciesDataGridView.Rows.Count;
            for (int i = 0; i < dependenciesRowsCount - 1; i++)
            {
                ProjectPlanModel.Dependency dependency = new ProjectPlanModel.Dependency();
                var activityTitle = dependenciesDataGridView.Rows[i].Cells[0].Value?.ToString() ?? "";
                var dependsOn = dependenciesDataGridView.Rows[i].Cells[1].Value?.ToString() ?? "";
                var dependencyType = dependenciesDataGridView.Rows[i].Cells[2].Value?.ToString() ?? "";

                dependency.ActivityTitle = activityTitle;
                dependency.DependsOn = dependsOn;
                dependency.DependencyType = dependencyType;

                dependencies.Add(dependency);
            }


            newProjectPlanModel.Dependencies = dependencies;

            newProjectPlanModel.Asssumptions = assumptionsTxt.Text;
            newProjectPlanModel.Constraints = constrainsTxt.Text;

            List<VersionControl<ProjectPlanModel>.DocumentModel> documentModels = versionControl.DocumentModels;


            if (!versionControl.isEqual(currentProjectPlanModel, newProjectPlanModel))
            {
                VersionControl<ProjectPlanModel>.DocumentModel documentModel = new VersionControl<ProjectPlanModel>.DocumentModel(newProjectPlanModel, DateTime.Now, VersionControl<ProjectModel>.generateID());

                documentModels.Add(documentModel);

                versionControl.DocumentModels = documentModels;
                string json = JsonConvert.SerializeObject(versionControl);
                currentProjectPlanModel = JsonConvert.DeserializeObject<ProjectPlanModel>(JsonConvert.SerializeObject(newProjectPlanModel));
                JsonHelper.saveDocument(json, Settings.Default.ProjectID, "ProjectPlan");
                MessageBox.Show("Project plan saved successfully", "save", MessageBoxButtons.OK);
            }
            else 
            {
                MessageBox.Show("No changes was made!", "save", MessageBoxButtons.OK);
            }
        }

        private void loadDocument()
        {
            string json = JsonHelper.loadDocument(Settings.Default.ProjectID, "ProjectPlan");
            List<string[]> documentInfo = new List<string[]>();
            newProjectPlanModel = new ProjectPlanModel();
            currentProjectPlanModel = new ProjectPlanModel();
            if (json != "")
            {
                versionControl = JsonConvert.DeserializeObject<VersionControl<ProjectPlanModel>>(json);
                newProjectPlanModel = JsonConvert.DeserializeObject<ProjectPlanModel>(versionControl.getLatest(versionControl.DocumentModels));
                currentProjectPlanModel = JsonConvert.DeserializeObject<ProjectPlanModel>(versionControl.getLatest(versionControl.DocumentModels));

                documentInfo.Add(new string[] { "Document ID", currentProjectPlanModel.DocumentID });
                documentInfo.Add(new string[] { "Document Owner", currentProjectPlanModel.DocumentOwner });
                documentInfo.Add(new string[] { "Issue Date", currentProjectPlanModel.IssueDate });
                documentInfo.Add(new string[] { "Last Save Date", currentProjectPlanModel.LastSavedDate });
                documentInfo.Add(new string[] { "File Name", currentProjectPlanModel.FileName });

                foreach (var row in documentInfo)
                {
                    documentInformation.Rows.Add(row);
                }
                documentInformation.AllowUserToAddRows = false;

                foreach (var row in currentProjectPlanModel.DocumentHistories)
                {
                    documentHistoryDataGridView.Rows.Add(new string[] { row.Version, row.IssueDate, row.Changes });
                }

                foreach (var row in currentProjectPlanModel.DocumentApprovals)
                {
                    documentApprovalsDataGridView.Rows.Add(new string[] { row.Role, row.Name, "", row.DateApproved });
                }

                foreach (var row in currentProjectPlanModel.Phases)
                {
                    phasesDataGridView.Rows.Add(new string[] { row.PhaseTitle, row.PhaseDescription, row.PhaseSequence });
                }

                foreach (var row in currentProjectPlanModel.Activities)
                {
                    activitiesDataGridView.Rows.Add(new string[] { row.PhaseTitle, row.ActivityTitle, row.ActivityDescription, row.ActivitySequence });
                }

                foreach (var row in currentProjectPlanModel.Tasks)
                {
                    tasksDataGridView.Rows.Add(new string[] { row.ActivityTitle, row.TaskTitle, row.TaskDescription, row.TaskSequence });
                }

                foreach (var row in currentProjectPlanModel.Milestones)
                {
                    milestonesDataGridView.Rows.Add(new string[] { row.MilestoneTitle, row.MilestoneDescription, row.MilestoneDate });
                }

                foreach (var row in currentProjectPlanModel.Efforts)
                {
                    effortDataGridView.Rows.Add(new string[] { row.TaskTitle, row.Resource, row.EffortMade });
                }

                foreach (var row in currentProjectPlanModel.Dependencies)
                {
                    dependenciesDataGridView.Rows.Add(new string[] { row.ActivityTitle, row.DependsOn, row.DependencyType });
                }

                assumptionsTxt.Text = currentProjectPlanModel.Asssumptions;
                constrainsTxt.Text = currentProjectPlanModel.Constraints;
            }
            else
            {
                versionControl = new VersionControl<ProjectPlanModel>();
                versionControl.DocumentModels = new List<VersionControl<ProjectPlanModel>.DocumentModel>();
                documentInfo.Add(new string[] { "Document ID", "" });
                documentInfo.Add(new string[] { "Document Owner", "" });
                documentInfo.Add(new string[] { "Issue Date", "" });
                documentInfo.Add(new string[] { "Last Save Date", "" });
                documentInfo.Add(new string[] { "File Name", "" });
                newProjectPlanModel = new ProjectPlanModel();
                foreach (var row in documentInfo)
                {
                    documentInformation.Rows.Add(row);
                }
                documentInformation.AllowUserToAddRows = false;
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
                    using (var document = DocX.Create(path)) {
                        for (int i = 0; i < 11; i++) {
                            document.InsertParagraph("")
                                .Font("Arial")
                                .Bold(true)
                                .FontSize(22d).Alignment = Alignment.left;
                        }
                        document.InsertParagraph("Project Plan \nFor " + projectModel.ProjectName)
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
                        documentInfoTable.Rows[1].Cells[1].Paragraphs[0].Append(currentProjectPlanModel.DocumentID);

                        documentInfoTable.Rows[2].Cells[0].Paragraphs[0].Append("Document Owner");
                        documentInfoTable.Rows[2].Cells[1].Paragraphs[0].Append(currentProjectPlanModel.DocumentOwner);

                        documentInfoTable.Rows[3].Cells[0].Paragraphs[0].Append("Issue Date");
                        documentInfoTable.Rows[3].Cells[1].Paragraphs[0].Append(currentProjectPlanModel.IssueDate);

                        documentInfoTable.Rows[4].Cells[0].Paragraphs[0].Append("Last Saved Date");
                        documentInfoTable.Rows[4].Cells[1].Paragraphs[0].Append(currentProjectPlanModel.LastSavedDate);

                        documentInfoTable.Rows[5].Cells[0].Paragraphs[0].Append("File Name");
                        documentInfoTable.Rows[5].Cells[1].Paragraphs[0].Append(currentProjectPlanModel.FileName);
                        documentInfoTable.SetWidths(new float[] { 493, 1094 });
                        document.InsertTable(documentInfoTable);

                        document.InsertParagraph("\nDocument History\n")
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(14d).Alignment = Alignment.left;

                        var documentHistoryTable = document.AddTable(currentProjectPlanModel.DocumentHistories.Count+1, 3);
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
                        for (int i = 1; i < currentProjectPlanModel.DocumentHistories.Count+1; i++)
                        {
                            documentHistoryTable.Rows[i].Cells[0].Paragraphs[0].Append(currentProjectPlanModel.DocumentHistories[i-1].Version);
                            documentHistoryTable.Rows[i].Cells[1].Paragraphs[0].Append(currentProjectPlanModel.DocumentHistories[i-1].IssueDate);
                            documentHistoryTable.Rows[i].Cells[2].Paragraphs[0].Append(currentProjectPlanModel.DocumentHistories[i-1].Changes);

                        }

                        documentHistoryTable.SetWidths(new float[] {190 , 303, 1094 });
                        document.InsertTable(documentHistoryTable);

                        document.InsertParagraph("\nDocument Approvals\n")
                           .Font("Arial")
                           .Bold(true)
                           .FontSize(14d).Alignment = Alignment.left;

                        var documentApprovalTable = document.AddTable(currentProjectPlanModel.DocumentApprovals.Count + 1, 4);
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

                        for (int i = 1; i < currentProjectPlanModel.DocumentApprovals.Count + 1; i++) 
                        {
                            documentApprovalTable.Rows[i].Cells[0].Paragraphs[0].Append(currentProjectPlanModel.DocumentApprovals[i - 1].Role);
                            documentApprovalTable.Rows[i].Cells[1].Paragraphs[0].Append(currentProjectPlanModel.DocumentApprovals[i - 1].Name);
                            documentApprovalTable.Rows[i].Cells[2].Paragraphs[0].Append(currentProjectPlanModel.DocumentApprovals[i - 1].Signature);
                            documentApprovalTable.Rows[i].Cells[3].Paragraphs[0].Append(currentProjectPlanModel.DocumentApprovals[i - 1].DateApproved);
                        }
                        documentApprovalTable.SetWidths(new float[] { 493, 332, 508, 254});
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


                        document.InsertTableOfContents(p,"", tocSwitches);
                        document.InsertParagraph().InsertPageBreakAfterSelf();
                        var WorkBreakdownHeading = document.InsertParagraph("1 Work Breakdown Structure")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");
                            
                        WorkBreakdownHeading.StyleId = "Heading1";

                        var PhasesSubHeading = WorkBreakdownHeading.InsertParagraphAfterSelf("1.1 Phases")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        PhasesSubHeading.StyleId = "Heading2";

                        var documentPhaseTable = document.AddTable(currentProjectPlanModel.Phases.Count + 1, 3);
                        documentPhaseTable.Rows[0].Cells[0].Paragraphs[0].Append("Phase Title")
                            .Bold(true)
                            .Color(Color.White);
                        documentPhaseTable.Rows[0].Cells[1].Paragraphs[0].Append("Phase Description")
                            .Bold(true)
                            .Color(Color.White);
                        documentPhaseTable.Rows[0].Cells[2].Paragraphs[0].Append("Phase Sequence")
                            .Bold(true)
                            .Color(Color.White);

                        documentPhaseTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        documentPhaseTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        documentPhaseTable.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < currentProjectPlanModel.Phases.Count + 1; i++) 
                        {
                            documentPhaseTable.Rows[i].Cells[0].Paragraphs[0].Append(currentProjectPlanModel.Phases[i - 1].PhaseTitle);
                            documentPhaseTable.Rows[i].Cells[1].Paragraphs[0].Append(currentProjectPlanModel.Phases[i - 1].PhaseDescription);
                            documentPhaseTable.Rows[i].Cells[2].Paragraphs[0].Append(currentProjectPlanModel.Phases[i - 1].PhaseSequence);
                        }

                        documentPhaseTable.SetWidths(new float[] { 394, 762, 419 });
                        document.InsertTable(documentPhaseTable);


                        var activitiesSubHeading = document.InsertParagraph("1.2 Activities")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        activitiesSubHeading.StyleId = "Heading2";

                        var documentActivitiesTable = document.AddTable(currentProjectPlanModel.Activities.Count + 1, 4);

                        documentActivitiesTable.Rows[0].Cells[0].Paragraphs[0].Append("Phase Title")
                            .Bold(true)
                            .Color(Color.White);
                        documentActivitiesTable.Rows[0].Cells[1].Paragraphs[0].Append("Activity Title")
                            .Bold(true)
                            .Color(Color.White);
                        documentActivitiesTable.Rows[0].Cells[2].Paragraphs[0].Append("Activity Description")
                            .Bold(true)
                            .Color(Color.White);
                        documentActivitiesTable.Rows[0].Cells[3].Paragraphs[0].Append("Activity Sequence")
                            .Bold(true)
                            .Color(Color.White);

                        documentActivitiesTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        documentActivitiesTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        documentActivitiesTable.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;
                        documentActivitiesTable.Rows[0].Cells[3].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < currentProjectPlanModel.Activities.Count + 1; i++)
                        {
                            
                            documentActivitiesTable.Rows[i].Cells[0].Paragraphs[0].Append(currentProjectPlanModel.Activities[i - 1].PhaseTitle);
                            documentActivitiesTable.Rows[i].Cells[1].Paragraphs[0].Append(currentProjectPlanModel.Activities[i - 1].ActivityTitle);
                            documentActivitiesTable.Rows[i].Cells[2].Paragraphs[0].Append(currentProjectPlanModel.Activities[i - 1].ActivityDescription);
                            documentActivitiesTable.Rows[i].Cells[3].Paragraphs[0].Append(currentProjectPlanModel.Activities[i - 1].ActivitySequence);
                        }

                        documentActivitiesTable.SetWidths(new float[] { 250, 279, 626, 420});
                        document.InsertTable(documentActivitiesTable);


                        var taskSubHeading = document.InsertParagraph("1.3 Tasks")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        taskSubHeading.StyleId = "Heading2";

                        var documentTasksTable = document.AddTable(currentProjectPlanModel.Tasks.Count + 1, 4);

                        documentTasksTable.Rows[0].Cells[0].Paragraphs[0].Append("Activity Title")
                            .Bold(true)
                            .Color(Color.White);
                        documentTasksTable.Rows[0].Cells[1].Paragraphs[0].Append("Task Title")
                            .Bold(true)
                            .Color(Color.White);
                        documentTasksTable.Rows[0].Cells[2].Paragraphs[0].Append("Task Description")
                            .Bold(true)
                            .Color(Color.White);
                        documentTasksTable.Rows[0].Cells[3].Paragraphs[0].Append("Task Sequence")
                            .Bold(true)
                            .Color(Color.White);

                        documentTasksTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        documentTasksTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        documentTasksTable.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;
                        documentTasksTable.Rows[0].Cells[3].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < currentProjectPlanModel.Tasks.Count + 1; i++)
                        {

                            documentTasksTable.Rows[i].Cells[0].Paragraphs[0].Append(currentProjectPlanModel.Tasks[i - 1].ActivityTitle);
                            documentTasksTable.Rows[i].Cells[1].Paragraphs[0].Append(currentProjectPlanModel.Tasks[i - 1].TaskTitle);
                            documentTasksTable.Rows[i].Cells[2].Paragraphs[0].Append(currentProjectPlanModel.Tasks[i - 1].TaskDescription);
                            documentTasksTable.Rows[i].Cells[3].Paragraphs[0].Append(currentProjectPlanModel.Tasks[i - 1].TaskSequence);
                        }

                        documentTasksTable.SetWidths(new float[] { 250, 279, 626, 420 });
                        document.InsertTable(documentTasksTable);

                        var milstoneSubHeading = document.InsertParagraph("1.4 Milestones")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        milstoneSubHeading.StyleId = "Heading2";

                        var documentMilestonesTable = document.AddTable(currentProjectPlanModel.Milestones.Count + 1, 3);
                        documentMilestonesTable.Rows[0].Cells[0].Paragraphs[0].Append("Milestone Title")
                            .Bold(true)
                            .Color(Color.White);
                        documentMilestonesTable.Rows[0].Cells[1].Paragraphs[0].Append("Milestone Description")
                            .Bold(true)
                            .Color(Color.White);
                        documentMilestonesTable.Rows[0].Cells[2].Paragraphs[0].Append("Milestone Date")
                            .Bold(true)
                            .Color(Color.White);

                        documentMilestonesTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        documentMilestonesTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        documentMilestonesTable.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < currentProjectPlanModel.Milestones.Count + 1; i++)
                        {
                            documentMilestonesTable.Rows[i].Cells[0].Paragraphs[0].Append(currentProjectPlanModel.Milestones[i - 1].MilestoneTitle);
                            documentMilestonesTable.Rows[i].Cells[1].Paragraphs[0].Append(currentProjectPlanModel.Milestones[i - 1].MilestoneDescription);
                            documentMilestonesTable.Rows[i].Cells[2].Paragraphs[0].Append(currentProjectPlanModel.Milestones[i - 1].MilestoneDate);
                        }

                        documentMilestonesTable.SetWidths(new float[] { 394, 762, 419 });
                        document.InsertTable(documentMilestonesTable);

                        var effortSubHeading = document.InsertParagraph("1.5 Effort")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        effortSubHeading.StyleId = "Heading2";

                        var documentEffortsTable = document.AddTable(currentProjectPlanModel.Efforts.Count + 1, 3);
                        documentEffortsTable.Rows[0].Cells[0].Paragraphs[0].Append("Task Title")
                            .Bold(true)
                            .Color(Color.White);
                        documentEffortsTable.Rows[0].Cells[1].Paragraphs[0].Append("Resource")
                            .Bold(true)
                            .Color(Color.White);
                        documentEffortsTable.Rows[0].Cells[2].Paragraphs[0].Append("Effort")
                            .Bold(true)
                            .Color(Color.White);

                        documentEffortsTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        documentEffortsTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        documentEffortsTable.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < currentProjectPlanModel.Efforts.Count + 1; i++)
                        {
                            documentEffortsTable.Rows[i].Cells[0].Paragraphs[0].Append(currentProjectPlanModel.Efforts[i - 1].TaskTitle);
                            documentEffortsTable.Rows[i].Cells[1].Paragraphs[0].Append(currentProjectPlanModel.Efforts[i - 1].Resource);
                            documentEffortsTable.Rows[i].Cells[2].Paragraphs[0].Append(currentProjectPlanModel.Efforts[i - 1].EffortMade);
                        }

                        documentEffortsTable.SetWidths(new float[] { 394, 762, 419 });
                        document.InsertTable(documentEffortsTable);

                        var projectPLanHeading = document.InsertParagraph("2 Project Plan")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        projectPLanHeading.StyleId = "Heading1";

                        var scheduleSubHeading = document.InsertParagraph("2.1 Schedule")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        scheduleSubHeading.StyleId = "Heading2";

                        var dependancySubHeading = document.InsertParagraph("2.2 Dependencies")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        dependancySubHeading.StyleId = "Heading2";

                        var documentDependenciesTable = document.AddTable(currentProjectPlanModel.Dependencies.Count + 1, 3);
                        documentDependenciesTable.Rows[0].Cells[0].Paragraphs[0].Append("Task Title")
                            .Bold(true)
                            .Color(Color.White);
                        documentDependenciesTable.Rows[0].Cells[1].Paragraphs[0].Append("Resource")
                            .Bold(true)
                            .Color(Color.White);
                        documentDependenciesTable.Rows[0].Cells[2].Paragraphs[0].Append("Effort")
                            .Bold(true)
                            .Color(Color.White);

                        documentDependenciesTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        documentDependenciesTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        documentDependenciesTable.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < currentProjectPlanModel.Dependencies.Count + 1; i++)
                        {
                            documentDependenciesTable.Rows[i].Cells[0].Paragraphs[0].Append(currentProjectPlanModel.Dependencies[i - 1].ActivityTitle);
                            documentDependenciesTable.Rows[i].Cells[1].Paragraphs[0].Append(currentProjectPlanModel.Dependencies[i - 1].DependsOn);
                            documentDependenciesTable.Rows[i].Cells[2].Paragraphs[0].Append(currentProjectPlanModel.Dependencies[i - 1].DependencyType);
                        }

                        documentDependenciesTable.SetWidths(new float[] { 394, 540, 667 });
                        document.InsertTable(documentDependenciesTable);


                        var assumptionsSubheading = document.InsertParagraph("2.3 Assumptions")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        document.InsertParagraph(currentProjectPlanModel.Asssumptions)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;


                        assumptionsSubheading.StyleId = "Heading2";

                        var constrainstSubHeading = document.InsertParagraph("2.4 Constraints")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        document.InsertParagraph(currentProjectPlanModel.Constraints)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        constrainstSubHeading.StyleId = "Heading2";

                        var appendixHeading = document.InsertParagraph("3 Appendix")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        appendixHeading.StyleId = "Heading1";

                        try
                        {
                            document.Save();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("The selected File is open.", "Close File",MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        

                    }


                }
            }
        }
    }
}
