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
    public partial class TimesheetFormDocumentForm : Form
    {
        VersionControl<TimeSheetModel> versionControl;
        TimeSheetModel newTimeSheetModel;
        TimeSheetModel currentTimeSheetModel;

        Color TABLE_HEADER_COLOR = Color.FromArgb(73, 173, 252);
        Color TABLE_SUBHEADER_FIRST_COLOR = Color.FromArgb(0, 255, 0);
        Color TABLE_SUBHEADER_SECOND_COLOR = Color.FromArgb(255, 255, 0);
        Color TABLE_SUBHEADER_THIRD_COLOR = Color.FromArgb(255, 165, 0);

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

        private void btn_Export_Click(object sender, EventArgs e)
        {
            exportToWord();
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
                        #region Heading
                        for (int i = 0; i < 11; i++)
                        {
                            document.InsertParagraph("")
                                .Font("Arial")
                                .Bold(true)
                                .FontSize(22d).Alignment = Alignment.left;
                        }

                        document.InsertParagraph("TimeSheet \nFor " + txtProjectName.Text)
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(22d).Alignment = Alignment.left;
                        document.InsertSectionPageBreak();
                        #endregion

                        int maxList = Math.Max(currentTimeSheetModel.timeSheetForm.timeSpents.Count, currentTimeSheetModel.timeSheetForm.tasksCompleted.Count);
                        maxList = Math.Max(maxList, currentTimeSheetModel.timeSheetForm.deliverablesProduced.Count) - 1;

                        var documentTimeSheet = document.AddTable(maxList + 7, 9);

                        documentTimeSheet.Rows[0].MergeCells(0, 8);
                        documentTimeSheet.Rows[0].Cells[0].Paragraphs[0].Append("TIMESHEET FORM")
                            .Bold(true)
                            .Color(Color.White)
                            .Alignment = Alignment.center;
                        documentTimeSheet.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;

                        documentTimeSheet.Rows[1].MergeCells(0, 8);
                        documentTimeSheet.Rows[1].Cells[0].Paragraphs[0].Append(string.Format("Project Name: {0}\n", currentTimeSheetModel.timeSheetForm.projectName));
                        documentTimeSheet.Rows[1].Cells[0].Paragraphs[0].Append(string.Format("Project Manager: {0}\n", currentTimeSheetModel.timeSheetForm.projectManager));
                        documentTimeSheet.Rows[1].Cells[0].Paragraphs[0].Append(string.Format("Team Memeber: {0}\n", currentTimeSheetModel.timeSheetForm.teamMember));

                        documentTimeSheet.Rows[2].MergeCells(0, 3);
                        documentTimeSheet.Rows[2].MergeCells(1, 2);
                        documentTimeSheet.Rows[2].MergeCells(2, 4);
                        documentTimeSheet.Rows[2].Cells[0].Paragraphs[0].Append("Time Spent")
                            .Bold(true)
                            .Alignment = Alignment.center;
                        documentTimeSheet.Rows[2].Cells[1].Paragraphs[0].Append("Tasks Completed")
                            .Bold(true)
                            .Alignment = Alignment.center;
                        documentTimeSheet.Rows[2].Cells[2].Paragraphs[0].Append("Deliverables Produced")
                            .Bold(true)
                            .Alignment = Alignment.center;
                        documentTimeSheet.Rows[2].Cells[0].FillColor = TABLE_SUBHEADER_FIRST_COLOR;
                        documentTimeSheet.Rows[2].Cells[1].FillColor = TABLE_SUBHEADER_SECOND_COLOR;
                        documentTimeSheet.Rows[2].Cells[2].FillColor = TABLE_SUBHEADER_THIRD_COLOR;

                        documentTimeSheet.Rows[3].Cells[0].Paragraphs[0].Append("Date")
                            .Bold(true)
                            .Alignment = Alignment.center;
                        documentTimeSheet.Rows[3].Cells[1].Paragraphs[0].Append("Start Time")
                            .Bold(true)
                            .Alignment = Alignment.center;
                        documentTimeSheet.Rows[3].Cells[2].Paragraphs[0].Append("End Time")
                            .Bold(true)
                            .Alignment = Alignment.center;
                        documentTimeSheet.Rows[3].Cells[3].Paragraphs[0].Append("Duration")
                            .Bold(true)
                            .Alignment = Alignment.center;
                        documentTimeSheet.Rows[3].Cells[0].FillColor = TABLE_SUBHEADER_FIRST_COLOR;
                        documentTimeSheet.Rows[3].Cells[1].FillColor = TABLE_SUBHEADER_FIRST_COLOR;
                        documentTimeSheet.Rows[3].Cells[2].FillColor = TABLE_SUBHEADER_FIRST_COLOR;
                        documentTimeSheet.Rows[3].Cells[3].FillColor = TABLE_SUBHEADER_FIRST_COLOR;
                        documentTimeSheet.Rows[3].Cells[4].Paragraphs[0].Append("Activity")
                            .Bold(true)
                            .Alignment = Alignment.center;
                        documentTimeSheet.Rows[3].Cells[5].Paragraphs[0].Append("Task")
                            .Bold(true)
                            .Alignment = Alignment.center;
                        documentTimeSheet.Rows[3].Cells[4].FillColor = TABLE_SUBHEADER_SECOND_COLOR;
                        documentTimeSheet.Rows[3].Cells[5].FillColor = TABLE_SUBHEADER_SECOND_COLOR;
                        documentTimeSheet.Rows[3].Cells[6].Paragraphs[0].Append("Start % Complete")
                            .Bold(true)
                            .Alignment = Alignment.center;
                        documentTimeSheet.Rows[3].Cells[7].Paragraphs[0].Append("End % Complete")
                            .Bold(true)
                            .Alignment = Alignment.center;
                        documentTimeSheet.Rows[3].Cells[8].Paragraphs[0].Append("Result")
                            .Bold(true)
                            .Alignment = Alignment.center;
                        documentTimeSheet.Rows[3].Cells[6].FillColor = TABLE_SUBHEADER_THIRD_COLOR;
                        documentTimeSheet.Rows[3].Cells[7].FillColor = TABLE_SUBHEADER_THIRD_COLOR;
                        documentTimeSheet.Rows[3].Cells[8].FillColor = TABLE_SUBHEADER_THIRD_COLOR;

                        for (int i = 0; i < currentTimeSheetModel.timeSheetForm.timeSpents.Count; i++)
                        {
                            documentTimeSheet.Rows[4 + i].Cells[0].Paragraphs[0].Append(currentTimeSheetModel.timeSheetForm.timeSpents[i].date);
                            documentTimeSheet.Rows[4 + i].Cells[1].Paragraphs[0].Append(currentTimeSheetModel.timeSheetForm.timeSpents[i].startTime);
                            documentTimeSheet.Rows[4 + i].Cells[2].Paragraphs[0].Append(currentTimeSheetModel.timeSheetForm.timeSpents[i].endTime);
                            documentTimeSheet.Rows[4 + i].Cells[3].Paragraphs[0].Append(currentTimeSheetModel.timeSheetForm.timeSpents[i].duration);
                        }

                        for (int i = 0; i < currentTimeSheetModel.timeSheetForm.tasksCompleted.Count; i++)
                        {
                            documentTimeSheet.Rows[4 + i].Cells[4].Paragraphs[0].Append(currentTimeSheetModel.timeSheetForm.tasksCompleted[i].activity);
                            documentTimeSheet.Rows[4 + i].Cells[5].Paragraphs[0].Append(currentTimeSheetModel.timeSheetForm.tasksCompleted[i].task);
                        }

                        for (int i = 0; i < currentTimeSheetModel.timeSheetForm.deliverablesProduced.Count; i++)
                        {
                            documentTimeSheet.Rows[4 + i].Cells[6].Paragraphs[0].Append(currentTimeSheetModel.timeSheetForm.deliverablesProduced[i].startPercentComplete);
                            documentTimeSheet.Rows[4 + i].Cells[7].Paragraphs[0].Append(currentTimeSheetModel.timeSheetForm.deliverablesProduced[i].endPercentComplete);
                            documentTimeSheet.Rows[4 + i].Cells[8].Paragraphs[0].Append(currentTimeSheetModel.timeSheetForm.deliverablesProduced[i].result);
                        }

                        int currentRowAfterInsert = maxList + 5;

                        documentTimeSheet.Rows[currentRowAfterInsert].MergeCells(0, 8);
                        documentTimeSheet.Rows[0].Cells[0].Paragraphs[0].Append("APPROVAL DETAILS")
                            .Bold(true)
                            .Color(Color.White)
                            .Alignment = Alignment.center;
                        documentTimeSheet.Rows[currentRowAfterInsert].Cells[0].FillColor = TABLE_HEADER_COLOR;

                        var finalData = new[]
                        {
                            new[] {"Submitted by", "Approved by"},
                            new[] {
                                string.Format("Name: {0}", currentTimeSheetModel.timeSheetForm.submittedName),
                                string.Format("Name: {0}", currentTimeSheetModel.timeSheetForm.approvedName) 
                            },
                            new[] {
                                string.Format("Project role: {0}", currentTimeSheetModel.timeSheetForm.submittedRole),
                                string.Format("Project role: {0}", currentTimeSheetModel.timeSheetForm.approvedRole) 
                            },
                        };
                        var tabbedData = EvenColumns(100, finalData);

                        documentTimeSheet.Rows[currentRowAfterInsert + 1].MergeCells(0, 8);
                        documentTimeSheet.Rows[currentRowAfterInsert + 1].Cells[0].Paragraphs[0].Append(tabbedData + "\n");

                        finalData = new[]
                        {
                            new[] {"Signature", "Date:", "Signature", "Date"},
                            new[] {
                                currentTimeSheetModel.timeSheetForm.submittedSignature,
                                currentTimeSheetModel.timeSheetForm.submittedDate,
                                currentTimeSheetModel.timeSheetForm.approvedSignature,
                                currentTimeSheetModel.timeSheetForm.approvedDate
                            },
                        };
                        tabbedData = EvenColumns(50, finalData);
                        documentTimeSheet.Rows[currentRowAfterInsert + 1].Cells[0].Paragraphs[0]
                            .Append(tabbedData + "\nPLEASE FORWARD THIS FORM TO THE PROJECT MANAGER FOR APPROVAL");

                        document.InsertTable(documentTimeSheet);

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
            }
        }

        public string EvenColumns(int desiredWidth, IEnumerable<IEnumerable<string>> lists)
        {
            return string.Join(Environment.NewLine, EvenColumns(desiredWidth, true, lists));
        }

        public IEnumerable<string> EvenColumns(int desiredWidth, bool rightOrLeft, IEnumerable<IEnumerable<string>> lists)
        {
            return lists.Select(o => EvenColumns(desiredWidth, rightOrLeft, o.ToArray()));
        }

        public string EvenColumns(int desiredWidth, bool rightOrLeftAlignment, string[] list, bool fitToItems = false)
        {
            int columnWidth = (rightOrLeftAlignment ? -1 : 1) *
                                (fitToItems
                                    ? Math.Max(desiredWidth, list.Select(o => o.Length).Max())
                                    : desiredWidth
                                );

            string format = string.Concat(Enumerable.Range(rightOrLeftAlignment ? 0 : 1, list.Length - 1).Select(i => string.Format("{{{0},{1}}}", i, columnWidth)));

            if (rightOrLeftAlignment)
            {
                format += "{" + (list.Length - 1) + "}";
            }
            else
            {
                format = "{0}" + format;
            }

            return string.Format(format, list);
        }
    }
}
