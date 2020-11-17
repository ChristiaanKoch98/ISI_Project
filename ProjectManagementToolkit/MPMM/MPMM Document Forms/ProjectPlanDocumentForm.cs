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
    public partial class ProjectPlanDocumentForm : Form
    {

        VersionControl<ProjectPlanModel> versionControl;
        ProjectPlanModel newProjectPlanModel;
        ProjectPlanModel currentProjectPlanModel;


        public ProjectPlanDocumentForm()
        {
            InitializeComponent();
        }

        private void ProjectPlanDocumentForm_Load(object sender, EventArgs e)
        {
            loadDocument();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveDocument();
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
                JsonHelper.saveDocument(json, Settings.Default.ProjectID, "ProjectPlan");
                MessageBox.Show("Project plan saved successfully", "save", MessageBoxButtons.OK);
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
       
    }
}
