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
        RiskRegisterModel currentIssueRegisterModel;
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
            List<RiskRegisterModel.RiskEntry> issueEntries = new List<RiskRegisterModel.RiskEntry>();
            int issueEntryCount = dgvRiskRegister.Rows.Count;

            for (int i = 0; i < issueEntryCount - 1; i++)
            {
                RiskRegisterModel.RiskEntry issueEntry = new RiskRegisterModel.RiskEntry();
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

                issueEntry.ID = int.Parse(id);
                issueEntry.DateRaised = dateRaised;
                issueEntry.RaisedBy = raisedBy;
                issueEntry.ReceivedBy = receivedBy;
                issueEntry.DescriptionRisk = descriptionRisk;
                issueEntry.DescriptionImpact = descriptionImpact;
                issueEntry.LikelyHoodRating = likelyhoodRating;
                issueEntry.ImpactRating = impactRating;
                issueEntry.PriorityRating = priorityRating;
                issueEntry.PreventionAction = preventionActions;
                issueEntry.PreventionOwner = preventionOwner;
                issueEntry.PreventionDate = preventionDate;
                issueEntry.ContingencyActions = contingencyActions;
                issueEntry.ContingencyOwner = contingencyOwner;
                issueEntry.ContingencyDate = contingencyDate;
            }

            newRiskRegisterModel.IssueEntries = issueEntries;
            List<VersionControl<RiskRegisterModel>.DocumentModel> documentModels = versionControl.DocumentModels;

            if (!versionControl.isEqual(currentIssueRegisterModel, newRiskRegisterModel))
            {
                VersionControl<RiskRegisterModel>.DocumentModel documentModel = new VersionControl<RiskRegisterModel>.DocumentModel(newRiskRegisterModel, DateTime.Now, VersionControl<IssueRegisterModel>.generateID());

                documentModels.Add(documentModel);
                string json = JsonConvert.SerializeObject(versionControl);
                currentIssueRegisterModel = JsonConvert.DeserializeObject<RiskRegisterModel>(JsonConvert.SerializeObject(newRiskRegisterModel));
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
    }
}
