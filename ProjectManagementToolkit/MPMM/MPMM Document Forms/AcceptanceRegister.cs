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
    public partial class AcceptanceRegister : Form
    {
        VersionControl<AcceptanceRegisterModel> versionControl;
        AcceptanceRegisterModel newAcceptanceRegisterModel;
        AcceptanceRegisterModel currentAcceptanceRegisterModel;
        Color TABLE_HEADER_COLOR = Color.FromArgb(73, 173, 252);
        ProjectModel projectModel = new ProjectModel();
        public AcceptanceRegister()
        {
            InitializeComponent();
        }

        private void AcceptanceRegister_Load(object sender, EventArgs e)
        {
            /*
            dgvAcceptanceRegister.Columns.Add("colID", "ID");
            dgvAcceptanceRegister.Columns.Add("colDeliveryName", "Delivery Name");
            dgvAcceptanceRegister.Columns.Add("colDeliveryDescription", "Delivery Description");
            dgvAcceptanceRegister.Columns.Add("colDeliverableStatus", "Deliverable Status");
            dgvAcceptanceRegister.Columns.Add("colCriteria", "Criteria");
            dgvAcceptanceRegister.Columns.Add("colStandards", "Standards");
            dgvAcceptanceRegister.Columns.Add("colMethod", "Method");
            dgvAcceptanceRegister.Columns.Add("colReviewer", "Reviewer");
            dgvAcceptanceRegister.Columns.Add("colDate", "Date");
            dgvAcceptanceRegister.Columns.Add("colResults", "Results");
            dgvAcceptanceRegister.Columns.Add("colStatus", "Status");
            */

            string jsoni = JsonHelper.loadProjectInfo(Settings.Default.Username);
            List<ProjectModel> projectListModel = JsonConvert.DeserializeObject<List<ProjectModel>>(jsoni);
            projectModel = projectModel.getProjectModel(Settings.Default.ProjectID, projectListModel);
            txtAcceptanceRegisterProjectName.Text = projectModel.ProjectName;
            txtProjectManagerName.Text = projectModel.ProjectManager;

            string json = JsonHelper.loadDocument(Settings.Default.ProjectID, "AcceptanceRegister");
            newAcceptanceRegisterModel = new AcceptanceRegisterModel();
            currentAcceptanceRegisterModel = new AcceptanceRegisterModel();

            if (json != "")
            {
                versionControl = JsonConvert.DeserializeObject<VersionControl<AcceptanceRegisterModel>>(json);
                newAcceptanceRegisterModel = JsonConvert.DeserializeObject<AcceptanceRegisterModel>(versionControl.getLatest(versionControl.DocumentModels));
                currentAcceptanceRegisterModel = JsonConvert.DeserializeObject<AcceptanceRegisterModel>(versionControl.getLatest(versionControl.DocumentModels));

                foreach (var row in currentAcceptanceRegisterModel.AcceptanceEntries)
                {
                    dgvAcceptanceRegister.Rows.Add(new string[] { row.ID.ToString(), row.DeliverableName, row.DeliverableDescription,
                    row.DeliverableStatus,row.AcceptanceCriteria,row.AcceptanceStandards,row.AcceptanceTestMethod,row.AcceptanceTestReviewer,
                        row.AcceptanceTestDate,row.AcceptanceResults,row.AcceptanceResultsStatus});
                }
            }
            else
            {
                versionControl = new VersionControl<AcceptanceRegisterModel>();
                versionControl.DocumentModels = new List<VersionControl<AcceptanceRegisterModel>.DocumentModel>();
            }



        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            List<AcceptanceRegisterModel.AcceptanceEntry> acceptanceEntries = new List<AcceptanceRegisterModel.AcceptanceEntry>();
            int AcceptanceEntryCount = dgvAcceptanceRegister.Rows.Count;

            for (int i = 0; i < AcceptanceEntryCount - 1; i++)
            {
                AcceptanceRegisterModel.AcceptanceEntry acceptanceEntry = new AcceptanceRegisterModel.AcceptanceEntry();
                var id = dgvAcceptanceRegister.Rows[i].Cells[0].Value?.ToString() ?? ""; 
                var deliverableName = dgvAcceptanceRegister.Rows[i].Cells[1].Value?.ToString() ?? "";
                var deliverableDescription = dgvAcceptanceRegister.Rows[i].Cells[2].Value?.ToString() ?? "";
                var deliverableStatus = dgvAcceptanceRegister.Rows[i].Cells[3].Value?.ToString() ?? "";
                var acceptanceCriteria = dgvAcceptanceRegister.Rows[i].Cells[4].Value?.ToString() ?? "";
                var acceptanceStandards = dgvAcceptanceRegister.Rows[i].Cells[5].Value?.ToString() ?? "";
                var acceptanceTestMethod = dgvAcceptanceRegister.Rows[i].Cells[6].Value?.ToString() ?? "";
                var acceptanceTestReviewer = dgvAcceptanceRegister.Rows[i].Cells[7].Value?.ToString() ?? "";
                var acceptanceTestDate = dgvAcceptanceRegister.Rows[i].Cells[8].Value?.ToString() ?? "";
                var acceptanceResults = dgvAcceptanceRegister.Rows[i].Cells[9].Value?.ToString() ?? "";
                var acceptanceResultsStatus = dgvAcceptanceRegister.Rows[i].Cells[10].Value?.ToString() ?? "";


                acceptanceEntry.ID = int.Parse(id);
                acceptanceEntry.DeliverableName = deliverableName;
                acceptanceEntry.DeliverableDescription = deliverableDescription;
                acceptanceEntry.DeliverableStatus = deliverableStatus;
                acceptanceEntry.AcceptanceCriteria = acceptanceCriteria;
                acceptanceEntry.AcceptanceStandards = acceptanceStandards;
                acceptanceEntry.AcceptanceTestMethod = acceptanceTestMethod;
                acceptanceEntry.AcceptanceTestReviewer = acceptanceTestReviewer;
                acceptanceEntry.AcceptanceTestDate = acceptanceTestDate;
                acceptanceEntry.AcceptanceResults = acceptanceResults;
                acceptanceEntry.AcceptanceResultsStatus = acceptanceResultsStatus;
                acceptanceEntries.Add(acceptanceEntry);

            }

            newAcceptanceRegisterModel.AcceptanceEntries = acceptanceEntries;
            List<VersionControl<AcceptanceRegisterModel>.DocumentModel> documentModels = versionControl.DocumentModels;

            if (!versionControl.isEqual(currentAcceptanceRegisterModel, newAcceptanceRegisterModel))
            {
                VersionControl<AcceptanceRegisterModel>.DocumentModel documentModel = new VersionControl<AcceptanceRegisterModel>.DocumentModel(newAcceptanceRegisterModel, DateTime.Now, VersionControl<AcceptanceRegisterModel>.generateID());

                documentModels.Add(documentModel);
                string json = JsonConvert.SerializeObject(versionControl);
                currentAcceptanceRegisterModel = JsonConvert.DeserializeObject<AcceptanceRegisterModel>(JsonConvert.SerializeObject(newAcceptanceRegisterModel));
                JsonHelper.saveDocument(json, Settings.Default.ProjectID, "AcceptanceRegister");
                MessageBox.Show("Acceptance Register saved successfully", "save", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("No changes were made.", "save", MessageBoxButtons.OK);
            }
        }
    }
}
