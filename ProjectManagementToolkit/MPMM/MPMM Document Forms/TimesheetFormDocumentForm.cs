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
    public partial class TimesheetFormDocumentForm : Form
    {
        VersionControl<TimeSheetModel> versionControl;
        TimeSheetModel newTimeSheetModel;
        TimeSheetModel currentTimeSheetModel;

        public TimesheetFormDocumentForm()
        {
            InitializeComponent();
        }

        private void btnSaveTimesheetForm_Click(object sender, EventArgs e)
        {
            string timesheetProjectName = txtTimesheetFormProjectName.Text; //Add an if statement to make sure project name on timesheet form matches project name above timesheet form
            string timesheetProjectManager = txtTimesheetFormProjectManager.Text;
            string timesheetTeamMember = txtTimesheetFormTeamMember.Text;
            string submittedbyName = txtName.Text;
            string submittedbyProjectRole = txtProjectRole.Text;
            string submittedbySignature = txtSignature.Text;
            string submittedbyDate = dateTimePickerSubmittedBy.Text;
            string approvedbyName = txtApprovedByName.Text;
            string approvedbyProjectRole = txtApprovedByProjectRole.Text;
            string approvedbySignature = txtApprovedBySignature.Text;
            string approvedbyDate = dateTimePickerApprovedBy.Text;
            //Grid view on this page i believe is used to showcase all inputed information that must be saved to database

        }

        private void btnSaveProjectName_Click(object sender, EventArgs e)
        {
            string projectName = txtProjectName.Text;
            SaveDocument();
        }

        private void TimesheetFormDocumentForm_Load(object sender, EventArgs e)
        {
            loadDocument();
        }

        //Back-End
        public void SaveDocument()
        {
            newTimeSheetModel = new TimeSheetModel();
            newTimeSheetModel.timeSheetForm = new TimeSheetModel.TimeSheetForm();
            newTimeSheetModel.timeSheetForm.projectName = txtTimesheetFormProjectName.Text;
            newTimeSheetModel.timeSheetForm.projectManager = txtTimesheetFormProjectManager.Text;
            newTimeSheetModel.timeSheetForm.teamMember = txtTimesheetFormTeamMember.Text;

            newTimeSheetModel.timeSheetForm.submittedName = txtName.Text;
            newTimeSheetModel.timeSheetForm.submittedRole = txtProjectRole.Text;
            newTimeSheetModel.timeSheetForm.submittedSignature = txtSignature.Text;
            newTimeSheetModel.timeSheetForm.submittedDate = dateTimePickerSubmittedBy.Text;

            newTimeSheetModel.timeSheetForm.approvedName = txtApprovedByName.Text;
            newTimeSheetModel.timeSheetForm.approvedRole = txtApprovedByProjectRole.Text;
            newTimeSheetModel.timeSheetForm.approvedSignature = txtApprovedBySignature.Text;
            newTimeSheetModel.timeSheetForm.approvedDate = dateTimePickerApprovedBy.Text;

            List<TimeSheetModel.TimeSheetForm.TimeSpent> timeSpents = new List<TimeSheetModel.TimeSheetForm.TimeSpent>();
            List<TimeSheetModel.TimeSheetForm.TasksCompleted> tasksCompleteds = new List<TimeSheetModel.TimeSheetForm.TasksCompleted>();
            List<TimeSheetModel.TimeSheetForm.DeliverablesProduced> deliverablesProduceds = new List<TimeSheetModel.TimeSheetForm.DeliverablesProduced>();

            int gridViewCounter = dataGridViewTimesheetForm.Rows.Count;

            for (int i = 0; i < gridViewCounter; i++)
            {
                TimeSheetModel.TimeSheetForm.TimeSpent timeSpent = new TimeSheetModel.TimeSheetForm.TimeSpent();
                TimeSheetModel.TimeSheetForm.TasksCompleted tasksCompleted = new TimeSheetModel.TimeSheetForm.TasksCompleted();
                TimeSheetModel.TimeSheetForm.DeliverablesProduced deliverablesProduced = new TimeSheetModel.TimeSheetForm.DeliverablesProduced();

                var tempDate = dataGridViewTimesheetForm.Rows[i].Cells[0].Value?.ToString() ?? "";
                var tempStartTime = dataGridViewTimesheetForm.Rows[i].Cells[1].Value?.ToString() ?? "";
                var tempEndTime = dataGridViewTimesheetForm.Rows[i].Cells[2].Value?.ToString() ?? "";
                var tempDuration = dataGridViewTimesheetForm.Rows[i].Cells[3].Value?.ToString() ?? "";

                var tempActivity = dataGridViewTimesheetForm.Rows[i].Cells[4].Value?.ToString() ?? "";
                var tempTask = dataGridViewTimesheetForm.Rows[i].Cells[5].Value?.ToString() ?? "";

                var tempStartPercentage = dataGridViewTimesheetForm.Rows[i].Cells[6].Value?.ToString() ?? "";
                var tempEndPercentage = dataGridViewTimesheetForm.Rows[i].Cells[7].Value?.ToString() ?? "";
                var tempResult = dataGridViewTimesheetForm.Rows[i].Cells[8].Value?.ToString() ?? "";

                timeSpent.date = tempDate;
                timeSpent.startTime = tempStartTime;
                timeSpent.endTime = tempEndTime;
                timeSpent.duration = tempDuration;

                tasksCompleted.activity = tempActivity;
                tasksCompleted.task = tempTask;

                deliverablesProduced.startPercentComplete = tempStartPercentage;
                deliverablesProduced.endPercentComplete = tempEndPercentage;
                deliverablesProduced.result = tempResult;

                timeSpents.Add(timeSpent);
                tasksCompleteds.Add(tasksCompleted);
                deliverablesProduceds.Add(deliverablesProduced);
            }
            newTimeSheetModel.timeSheetForm.timeSpents = timeSpents;
            newTimeSheetModel.timeSheetForm.tasksCompleted = tasksCompleteds;
            newTimeSheetModel.timeSheetForm.deliverablesProduced = deliverablesProduceds;

            List<VersionControl<TimeSheetModel>.DocumentModel> documentModels = versionControl.DocumentModels;

            if (!versionControl.isEqual(currentTimeSheetModel, newTimeSheetModel))
            {
                VersionControl<TimeSheetModel>.DocumentModel documentModel = new VersionControl<TimeSheetModel>.DocumentModel(newTimeSheetModel, DateTime.Now, VersionControl<ProjectModel>.generateID());

                documentModels.Add(documentModel);
                versionControl.DocumentModels = documentModels;

                string json = JsonConvert.SerializeObject(versionControl);
                JsonHelper.saveDocument(json, Settings.Default.ProjectID, "TimeSheet");
                MessageBox.Show("Time sheet saved successfully", "save", MessageBoxButtons.OK);
            }
        }

        public void loadDocument()
        {
            string json = JsonHelper.loadDocument(Settings.Default.ProjectID, "TimeSheet");
            List<string[]> documentInfo = new List<string[]>();
            newTimeSheetModel = new TimeSheetModel();
            currentTimeSheetModel = new TimeSheetModel();
            if (json != "")
            {
                versionControl = JsonConvert.DeserializeObject<VersionControl<TimeSheetModel>>(json);
                newTimeSheetModel = JsonConvert.DeserializeObject<TimeSheetModel>(versionControl.getLatest(versionControl.DocumentModels));
                currentTimeSheetModel = JsonConvert.DeserializeObject<TimeSheetModel>(versionControl.getLatest(versionControl.DocumentModels));

                txtTimesheetFormProjectName.Text = newTimeSheetModel.timeSheetForm.projectName;
                txtTimesheetFormProjectManager.Text = newTimeSheetModel.timeSheetForm.projectManager;
                txtTimesheetFormTeamMember.Text = newTimeSheetModel.timeSheetForm.teamMember;

                txtName.Text = newTimeSheetModel.timeSheetForm.submittedName;
                txtProjectRole.Text = newTimeSheetModel.timeSheetForm.submittedRole;
                txtSignature.Text = newTimeSheetModel.timeSheetForm.submittedSignature;
                dateTimePickerSubmittedBy.Text = newTimeSheetModel.timeSheetForm.submittedDate;

                txtApprovedByName.Text = newTimeSheetModel.timeSheetForm.approvedName;
                txtApprovedByProjectRole.Text = newTimeSheetModel.timeSheetForm.approvedRole;
                txtApprovedBySignature.Text = newTimeSheetModel.timeSheetForm.approvedSignature;
                dateTimePickerApprovedBy.Text = newTimeSheetModel.timeSheetForm.approvedDate;

                for (int i = 0; i < currentTimeSheetModel.timeSheetForm.timeSpents.Count; i++)
                {
                    var timeSpent = currentTimeSheetModel.timeSheetForm.timeSpents[i];
                    var taskCompleted = currentTimeSheetModel.timeSheetForm.tasksCompleted[i];
                    var deliverables = currentTimeSheetModel.timeSheetForm.deliverablesProduced[i];

                    dataGridViewTimesheetForm.Rows.Add(new String[] {
                        timeSpent.date,
                        timeSpent.startTime,
                        timeSpent.endTime,
                        timeSpent.duration,
                        taskCompleted.activity,
                        taskCompleted.task,
                        deliverables.startPercentComplete,
                        deliverables.endPercentComplete,
                        deliverables.result
                    });
                }
            }
            else
            {
                versionControl = new VersionControl<TimeSheetModel>();
                versionControl.DocumentModels = new List<VersionControl<TimeSheetModel>.DocumentModel>();
                newTimeSheetModel = new TimeSheetModel();
            }
        }
    }
}
