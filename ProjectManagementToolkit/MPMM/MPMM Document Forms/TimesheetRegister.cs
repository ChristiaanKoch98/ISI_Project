using System;
using Newtonsoft.Json;
using ProjectManagementToolkit.MPMM.MPMM_Document_Models;
using ProjectManagementToolkit.Properties;
using ProjectManagementToolkit.Utility;
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
    public partial class TimesheetRegister : Form
    {
        VersionControl<TimesheetRegisterModel> versionControl;
        TimesheetRegisterModel newTimeSheetRegisterModel;
        TimesheetRegisterModel currentTimeSheetRegisterModel;
        Color TABLE_HEADER_COLOR = Color.FromArgb(73, 173, 252);
        ProjectModel projectModel = new ProjectModel();
        public TimesheetRegister()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            List<TimesheetRegisterModel.TimesheetEntry> TimeSheetEntries = new List<TimesheetRegisterModel.TimesheetEntry> ();
            int issueEntryCount = dataGridViewTimesheetRegister.Rows.Count;

            for (int i = 0; i < issueEntryCount - 1; i++)
            {
                TimesheetRegisterModel.TimesheetEntry TimesheetEntry = new TimesheetRegisterModel.TimesheetEntry();
                var ActivityID = dataGridViewTimesheetRegister.Rows[i].Cells[0].Value?.ToString() ?? "";
                var ActivityDescription = dataGridViewTimesheetRegister.Rows[i].Cells[1].Value?.ToString() ?? "";
                var TaskID = dataGridViewTimesheetRegister.Rows[i].Cells[2].Value?.ToString() ?? "";
                var TaskDescription = dataGridViewTimesheetRegister.Rows[i].Cells[3].Value?.ToString() ?? "";
                var TeamMember = dataGridViewTimesheetRegister.Rows[i].Cells[4].Value?.ToString() ?? "";
                var Time = dataGridViewTimesheetRegister.Rows[i].Cells[5].Value?.ToString() ?? "";
                var OverTime = dataGridViewTimesheetRegister.Rows[i].Cells[6].Value?.ToString() ?? "";
                var StartPercentageComplete = dataGridViewTimesheetRegister.Rows[i].Cells[7].Value?.ToString() ?? "";
                var EndPercentageComplete = dataGridViewTimesheetRegister.Rows[i].Cells[8].Value?.ToString() ?? "";
                var Result = dataGridViewTimesheetRegister.Rows[i].Cells[9].Value?.ToString() ?? "";
                var ApprovalStatus = dataGridViewTimesheetRegister.Rows[i].Cells[10].Value?.ToString() ?? "";
                var ApprovalDate = dataGridViewTimesheetRegister.Rows[i].Cells[11].Value?.ToString() ?? "";
                var Approver = dataGridViewTimesheetRegister.Rows[i].Cells[11].Value?.ToString() ?? "";

                TimesheetEntry.ActivityID = int.Parse(ActivityID);
                TimesheetEntry.ActivityDescription = ActivityDescription;
                TimesheetEntry.TaskID = TaskID;
                TimesheetEntry.TaskDescription = TaskDescription;
                TimesheetEntry.TeamMember = TeamMember;
                TimesheetEntry.Time = Time;
                TimesheetEntry.OverTime = OverTime;
                TimesheetEntry.StartPercentageComplete = StartPercentageComplete;
                TimesheetEntry.EndPercentageComplete = EndPercentageComplete;
                TimesheetEntry.Result = Result;
                TimesheetEntry.ApprovalStatus = ApprovalStatus;
                TimesheetEntry.ApprovalDate = ApprovalDate;
                TimesheetEntry.Approver = Approver;

                TimeSheetEntries.Add(TimesheetEntry);
            }

            newTimeSheetRegisterModel.TimeSheetEntries = TimeSheetEntries;
            List<VersionControl<TimesheetRegisterModel>.DocumentModel> documentModels = versionControl.DocumentModels;

            if (!versionControl.isEqual(currentTimeSheetRegisterModel, newTimeSheetRegisterModel))
            {
                VersionControl<TimesheetRegisterModel>.DocumentModel documentModel = new VersionControl<TimesheetRegisterModel>.DocumentModel(newTimeSheetRegisterModel, DateTime.Now, VersionControl<TimesheetRegisterModel>.generateID());

                documentModels.Add(documentModel);
                string json = JsonConvert.SerializeObject(versionControl);
                currentTimeSheetRegisterModel = JsonConvert.DeserializeObject<TimesheetRegisterModel>(JsonConvert.SerializeObject(newTimeSheetRegisterModel));
                JsonHelper.saveDocument(json, Settings.Default.ProjectID, "TimeSheetRegister");
                MessageBox.Show("TimeSheet Register saved successfully", "save", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("No changes were made.", "save", MessageBoxButtons.OK);
            }
        }

        private void TimesheetRegister_Load(object sender, EventArgs e)
        {
            string json = JsonHelper.loadDocument(Settings.Default.ProjectID, "TimeSheetRegister");
            newTimeSheetRegisterModel = new TimesheetRegisterModel();
            currentTimeSheetRegisterModel = new TimesheetRegisterModel();

            if (json != "")
            {
                versionControl = JsonConvert.DeserializeObject<VersionControl<TimesheetRegisterModel>>(json);
                newTimeSheetRegisterModel = JsonConvert.DeserializeObject<TimesheetRegisterModel>(versionControl.getLatest(versionControl.DocumentModels));
                currentTimeSheetRegisterModel = JsonConvert.DeserializeObject<TimesheetRegisterModel>(versionControl.getLatest(versionControl.DocumentModels));

                foreach (var row in currentTimeSheetRegisterModel.TimeSheetEntries)
                {
                    dataGridViewTimesheetRegister.Rows.Add(new string[] { row.ActivityID.ToString(),row.ActivityDescription,row.TaskID,
                    row.TaskDescription,row.TeamMember,row.Time ,row.OverTime,row.StartPercentageComplete,row.EndPercentageComplete,
                    row.Result ,row.ApprovalStatus,row.ApprovalDate,row.Approver});
                }
            }
            else
            {
                versionControl = new VersionControl<TimesheetRegisterModel>();
                versionControl.DocumentModels = new List<VersionControl<TimesheetRegisterModel>.DocumentModel>();
            }
        }

        private void TimesheetRegister_Load(object sender, EventArgs e)
        {

        }
    }
}
