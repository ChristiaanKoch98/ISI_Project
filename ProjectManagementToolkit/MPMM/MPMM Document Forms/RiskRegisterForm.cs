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
    public partial class RiskRegisterForm : Form
    {
        VersionControl<RiskRegisterModel> versionControl;
        RiskRegisterModel newRiskRegisterModel;
        RiskRegisterModel currentRiskRegisterModel;
        Color TABLE_HEADER_COLOR = Color.FromArgb(73, 173, 252);
        ProjectModel projectModel = new ProjectModel();
        public RiskRegisterForm()
        {
            InitializeComponent();
        }

        private void dataGridViewSolutionRaiseRaised_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            List<RiskRegisterModel.RiskEntry> RiskEntries = new List<RiskRegisterModel.RiskEntry>();
            int issueEntryCount = dgvRiskRegister.Rows.Count;

            for (int i = 0; i < issueEntryCount - 1; i++)
            {
                RiskRegisterModel.RiskEntry RiskEntry = new RiskRegisterModel.RiskEntry();
                var id = dgvRiskRegister.Rows[i].Cells[0].Value?.ToString() ?? "";
                var dateRaised = dgvRiskRegister.Rows[i].Cells[1].Value?.ToString() ?? "";
                var raisedBy = dgvRiskRegister.Rows[i].Cells[2].Value?.ToString() ?? "";
                var receivedBy = dgvRiskRegister.Rows[i].Cells[3].Value?.ToString() ?? "";
                var descriptionRisk = dgvRiskRegister.Rows[i].Cells[4].Value?.ToString() ?? "";
                var descriptionImpact = dgvRiskRegister.Rows[i].Cells[5].Value?.ToString() ?? "";
                var likelyhoodRating = dgvRiskRegister.Rows[i].Cells[6].Value?.ToString() ?? "";
                var impactRating = dgvRiskRegister.Rows[i].Cells[7].Value?.ToString() ?? "";
                var priorityRating = dgvRiskRegister.Rows[i].Cells[8].Value?.ToString() ?? "";
                var preventionActions = dgvRiskRegister.Rows[i].Cells[9].Value?.ToString() ?? "";
                var preventionOwner = dgvRiskRegister.Rows[i].Cells[10].Value?.ToString() ?? "";
                var preventionDate = dgvRiskRegister.Rows[i].Cells[11].Value?.ToString() ?? "";
                var contingencyActions = dgvRiskRegister.Rows[i].Cells[12].Value?.ToString() ?? "";
                var contingencyOwner = dgvRiskRegister.Rows[i].Cells[13].Value?.ToString() ?? "";
                var contingencyDate = dgvRiskRegister.Rows[i].Cells[14].Value?.ToString() ?? "";

                try
                {
                    RiskEntry.ID = int.Parse(id);
                }
                catch (Exception)
                {
                    MessageBox.Show("Please ensure that you provide a number for the ID otherwise the changes wil not e saved.");
                    return;
                }
                
                RiskEntry.DateRaised = dateRaised;
                RiskEntry.RaisedBy = raisedBy;
                RiskEntry.ReceivedBy = receivedBy;
                RiskEntry.DescriptionRisk = descriptionRisk;
                RiskEntry.DescriptionImpact = descriptionImpact;
                RiskEntry.LikelyHoodRating = likelyhoodRating;
                RiskEntry.ImpactRating = impactRating;
                RiskEntry.PriorityRating = priorityRating;
                RiskEntry.PreventionAction = preventionActions;
                RiskEntry.PreventionOwner = preventionOwner;
                RiskEntry.PreventionDate = preventionDate;
                RiskEntry.ContingencyActions = contingencyActions;
                RiskEntry.ContingencyOwner = contingencyOwner;
                RiskEntry.ContingencyDate = contingencyDate;
                RiskEntries.Add(RiskEntry);
            }

            newRiskRegisterModel.RiskEntries = RiskEntries;
            List<VersionControl<RiskRegisterModel>.DocumentModel> documentModels = versionControl.DocumentModels;

            if (!versionControl.isEqual(currentRiskRegisterModel, newRiskRegisterModel))
            {
                VersionControl<RiskRegisterModel>.DocumentModel documentModel = new VersionControl<RiskRegisterModel>.DocumentModel(newRiskRegisterModel, DateTime.Now, VersionControl<RiskRegisterModel>.generateID());

                documentModels.Add(documentModel);
                string json = JsonConvert.SerializeObject(versionControl);
                currentRiskRegisterModel = JsonConvert.DeserializeObject<RiskRegisterModel>(JsonConvert.SerializeObject(newRiskRegisterModel));
                JsonHelper.saveDocument(json, Settings.Default.ProjectID, "RiskRegister");
                MessageBox.Show("Risk Register saved successfully", "save", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("No changes were made.", "save", MessageBoxButtons.OK);
            }

        }

        private void btnExport_Click(object sender, EventArgs e)
        {

        }

        private void RiskRegisterForm_Load(object sender, EventArgs e)
        {
            string jsoni = JsonHelper.loadProjectInfo(Settings.Default.Username);
            List<ProjectModel> projectListModel = JsonConvert.DeserializeObject<List<ProjectModel>>(jsoni);
            projectModel = projectModel.getProjectModel(Settings.Default.ProjectID, projectListModel);
            txtRiskRegisterProjectName.Text = projectModel.ProjectName;

            string json = JsonHelper.loadDocument(Settings.Default.ProjectID, "RiskRegister");
            newRiskRegisterModel = new RiskRegisterModel();
            currentRiskRegisterModel = new RiskRegisterModel();

            if (json != "")
            {
                versionControl = JsonConvert.DeserializeObject<VersionControl<RiskRegisterModel>>(json);
                newRiskRegisterModel = JsonConvert.DeserializeObject<RiskRegisterModel>(versionControl.getLatest(versionControl.DocumentModels));
                currentRiskRegisterModel = JsonConvert.DeserializeObject<RiskRegisterModel>(versionControl.getLatest(versionControl.DocumentModels));

                foreach (var row in currentRiskRegisterModel.RiskEntries)
                {
                    dgvRiskRegister.Rows.Add(new string[] { row.ID.ToString(), row.DateRaised, row.RaisedBy,
                    row.ReceivedBy,row.DescriptionRisk,row.DescriptionImpact,row.LikelyHoodRating,row.PriorityRating,row.PreventionAction,row.PreventionOwner,row.PreventionDate,
                    row.ContingencyActions,row.ContingencyOwner,row.ContingencyDate});
                }
            }
            else
            {
                
                versionControl = new VersionControl<RiskRegisterModel>();
                versionControl.DocumentModels = new List<VersionControl<RiskRegisterModel>.DocumentModel>();
            }
        }

        private void txtRiskRegisterProjectName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
