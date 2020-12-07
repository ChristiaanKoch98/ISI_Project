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
    public partial class IssueRegisterForm : Form
    {
        VersionControl<IssueRegisterModel> versionControl;
        IssueRegisterModel newIssueRegisterModel;
        IssueRegisterModel currentIssueRegisterModel;
        Color TABLE_HEADER_COLOR = Color.FromArgb(73, 173, 252);
        ProjectModel projectModel = new ProjectModel();
        public IssueRegisterForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            List<IssueRegisterModel.IssueEntry> issueEntries = new List<IssueRegisterModel.IssueEntry>();
            int issueEntryCount = dataGridViewSolutionRaiseRaised.Rows.Count;

            for (int i = 0; i < issueEntryCount - 1; i++)
            {
                IssueRegisterModel.IssueEntry issueEntry = new IssueRegisterModel.IssueEntry();
                var id = dataGridViewSolutionRaiseRaised.Rows[i].Cells[0].Value?.ToString() ?? "";
                var dateRaised = dataGridViewSolutionRaiseRaised.Rows[i].Cells[1].Value?.ToString() ?? "";
                var raisedBy = dataGridViewSolutionRaiseRaised.Rows[i].Cells[2].Value?.ToString() ?? "";
                var receivedBy = dataGridViewSolutionRaiseRaised.Rows[i].Cells[3].Value?.ToString() ?? "";
                var description = dataGridViewSolutionRaiseRaised.Rows[i].Cells[4].Value?.ToString() ?? "";
                var impact = dataGridViewSolutionRaiseRaised.Rows[i].Cells[5].Value?.ToString() ?? "";
                var priority = dataGridViewSolutionRaiseRaised.Rows[i].Cells[6].Value?.ToString() ?? "";
                var action = dataGridViewSolutionRaiseRaised.Rows[i].Cells[7].Value?.ToString() ?? "";
                var owner = dataGridViewSolutionRaiseRaised.Rows[i].Cells[8].Value?.ToString() ?? "";
                var outcome = dataGridViewSolutionRaiseRaised.Rows[i].Cells[9].Value?.ToString() ?? "";
                var dateBeingResolved = dataGridViewSolutionRaiseRaised.Rows[i].Cells[10].Value?.ToString() ?? "";
                var dateResolved = dataGridViewSolutionRaiseRaised.Rows[i].Cells[11].Value?.ToString() ?? "";

                issueEntry.ID = (id);
                issueEntry.DateRaised = dateRaised;
                issueEntry.RaisedBy = raisedBy;
                issueEntry.ReceivedBy = receivedBy;
                issueEntry.Description = description;
                issueEntry.Impact = impact;
                issueEntry.Priority = priority;
                issueEntry.Action = action;
                issueEntry.Owner = owner;
                issueEntry.Outcome = outcome;
                issueEntry.DateForResolution = dateBeingResolved;
                issueEntry.DateResolved = dateResolved;
                issueEntries.Add(issueEntry);
            }

            newIssueRegisterModel.IssueEntries = issueEntries;
            List<VersionControl<IssueRegisterModel>.DocumentModel> documentModels = versionControl.DocumentModels;

            if (!versionControl.isEqual(currentIssueRegisterModel, newIssueRegisterModel))
            {
                VersionControl<IssueRegisterModel>.DocumentModel documentModel = new VersionControl<IssueRegisterModel>.DocumentModel(newIssueRegisterModel, DateTime.Now, VersionControl<IssueRegisterModel>.generateID());

                documentModels.Add(documentModel);
                string json = JsonConvert.SerializeObject(versionControl);
                currentIssueRegisterModel = JsonConvert.DeserializeObject<IssueRegisterModel>(JsonConvert.SerializeObject(newIssueRegisterModel));
                JsonHelper.saveDocument(json, Settings.Default.ProjectID, "IssueRegister");
                MessageBox.Show("Issue Register saved successfully", "save", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("No changes were made.", "save", MessageBoxButtons.OK);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ExcelAppend.ExportNotQualityRegister((int)ExcelAppend.DocumentType.IssueRegister, dataGridViewSolutionRaiseRaised);
        }

        private void IssueRegisterForm_Load(object sender, EventArgs e)
        {
            string jsoni = JsonHelper.loadProjectInfo(Settings.Default.Username);
            List<ProjectModel> projectListModel = JsonConvert.DeserializeObject<List<ProjectModel>>(jsoni);
            projectModel = projectModel.getProjectModel(Settings.Default.ProjectID, projectListModel);
            txtIssueRegisterProjectName.Text = projectModel.ProjectName;
            txtIssueRegisterProjectManager.Text = projectModel.ProjectManager;

            string json = JsonHelper.loadDocument(Settings.Default.ProjectID, "IssueRegister");
            newIssueRegisterModel = new IssueRegisterModel();
            currentIssueRegisterModel = new IssueRegisterModel();

            if (json != "")
            {
                versionControl = JsonConvert.DeserializeObject<VersionControl<IssueRegisterModel>>(json);
                newIssueRegisterModel = JsonConvert.DeserializeObject<IssueRegisterModel>(versionControl.getLatest(versionControl.DocumentModels));
                currentIssueRegisterModel = JsonConvert.DeserializeObject<IssueRegisterModel>(versionControl.getLatest(versionControl.DocumentModels));

                foreach (var row in currentIssueRegisterModel.IssueEntries)
                {
                    dataGridViewSolutionRaiseRaised.Rows.Add(new string[] { row.ID.ToString(), row.DateRaised, row.RaisedBy, 
                    row.ReceivedBy,row.Description,row.Impact,row.Priority,row.Action,row.Owner,row.Outcome,row.DateForResolution
                    ,row.DateResolved});
                }
            }
            else
            {
                versionControl = new VersionControl<IssueRegisterModel>();
                versionControl.DocumentModels = new List<VersionControl<IssueRegisterModel>.DocumentModel>();
            }

        }
    }
}
