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

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Forms
{
    public partial class ProjectPlanDocumentForm : Form
    {
        private ProjectPlanModel projectPlanModel = new ProjectPlanModel();
        public ProjectPlanDocumentForm()
        {
            InitializeComponent();
            List<string[]> rows = new List<string[]>();
            rows.Add(new string[] { "Document ID", "" });
            rows.Add(new string[] { "Document Owner", "" });
            rows.Add(new string[] { "Issue Date", "" });
            rows.Add(new string[] { "Last Save Date", "" });
            rows.Add(new string[] { "File Name", "" });
            foreach (var row in rows)
            {
                documentInformation.Rows.Add(row);
            }
            documentInformation.AllowUserToAddRows = false;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void tasks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void constrains_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            projectPlanModel.DocumentID     = documentInformation.Rows[0].Cells[1].Value.ToString();
            projectPlanModel.DocumentOwner  = documentInformation.Rows[1].Cells[1].Value.ToString();
            projectPlanModel.IssueDate      = documentInformation.Rows[2].Cells[1].Value.ToString();
            projectPlanModel.LastSavedDate  = documentInformation.Rows[3].Cells[1].Value.ToString();
            projectPlanModel.FileName       = documentInformation.Rows[4].Cells[1].Value.ToString();

            List<ProjectPlanModel.DocumentHistory>  documentHistories = new List<ProjectPlanModel.DocumentHistory>();

            int versionRowsCount = documentHistory.Rows.Count;

            for (int i = 0; i < versionRowsCount - 1; i++)
            {
                ProjectPlanModel.DocumentHistory documentHistoryModel = new ProjectPlanModel.DocumentHistory();
                var version     = documentHistory.Rows[i].Cells[0].Value?.ToString() ?? "";
                var issueDate   = documentHistory.Rows[i].Cells[1].Value?.ToString() ?? "";
                var changes     = documentHistory.Rows[i].Cells[2].Value?.ToString() ?? "";
                documentHistoryModel.Version = version;
                documentHistoryModel.IssueDate = issueDate;
                documentHistoryModel.Changes = changes;
                documentHistories.Add(documentHistoryModel);
            }
            projectPlanModel.DocumentHistories = documentHistories;

            List<ProjectPlanModel.DocumentApproval> documentApprovalsModel = new List<ProjectPlanModel.DocumentApproval>();

            int approvalRowsCount = documentApprovals.Rows.Count;

            for (int i = 0; i < approvalRowsCount - 1; i++)
            {
                ProjectPlanModel.DocumentApproval documentApproval = new ProjectPlanModel.DocumentApproval();
                var role        = documentApprovals.Rows[i].Cells[0].Value?.ToString() ?? "";
                var name        = documentApprovals.Rows[i].Cells[1].Value?.ToString() ?? "";
                var signature   = documentApprovals.Rows[i].Cells[2].Value?.ToString() ?? "";
                var date        = documentApprovals.Rows[i].Cells[3].Value?.ToString() ?? "";
                documentApproval.Role = role;
                documentApproval.Name = name;
                documentApproval.Signature = signature;
                documentApproval.DateApproved = date;

                documentApprovalsModel.Add(documentApproval);
            }
            projectPlanModel.DocumentApprovals = documentApprovalsModel;

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
            projectPlanModel.Phases = phases;

            List<ProjectPlanModel.Activity> activities = new List<ProjectPlanModel.Activity>();
            int activityRowsCount = activitiesDataGridView.Rows.Count;

            for (int i = 0; i < activityRowsCount - 1; i++)
            {
                ProjectPlanModel.Activity activity = new ProjectPlanModel.Activity();
                var phaseTitle = activitiesDataGridView.Rows[i].Cells[0].Value?.ToString() ?? "";
                var activityTitle = activitiesDataGridView.Rows[i].Cells[1].Value?.ToString() ?? "";
                var activityDescription = activitiesDataGridView.Rows[i].Cells[2].Value?.ToString() ?? "";
                var activitySequence= activitiesDataGridView.Rows[i].Cells[3].Value?.ToString() ?? "";

                activity.PhaseTitle = phaseTitle;
                activity.ActivityTitle = activityTitle;
                activity.ActivityDescription = activityDescription;
                activity.ActivitySequence = activitySequence;

                activities.Add(activity);
            }
            projectPlanModel.Activities = activities;

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
            projectPlanModel.Tasks = tasks;

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
            projectPlanModel.Milestones = milestones;

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
            projectPlanModel.Efforts = efforts;

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

            projectPlanModel.Dependencies = dependencies;

            projectPlanModel.Asssumptions = assumptionsTxt.Text;
            projectPlanModel.Constraints = constrainsTxt.Text;

            string json = JsonConvert.SerializeObject(projectPlanModel);
            MessageBox.Show(json);
        }
    }
}
