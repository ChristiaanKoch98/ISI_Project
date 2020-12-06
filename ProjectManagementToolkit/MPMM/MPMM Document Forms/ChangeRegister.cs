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
    public partial class ChangeRegister : Form
    {
        VersionControl<ChangeRegisterModel> versionControl;
        ChangeRegisterModel newChangeRegisterModel;
        ChangeRegisterModel currentChangeRegisterModel;
        Color TABLE_HEADER_COLOR = Color.FromArgb(73, 173, 252);
        ProjectModel projectModel = new ProjectModel();

        public ChangeRegister()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            List<ChangeRegisterModel.ChangeEntry> changeEntries = new List<ChangeRegisterModel.ChangeEntry>();
            int changeEntryCount = dgvChangeRegister.Rows.Count;

            for (int i = 0; i < changeEntryCount - 1; i++)
            {
                ChangeRegisterModel.ChangeEntry changeEntry = new ChangeRegisterModel.ChangeEntry();
                string id = dgvChangeRegister.Rows[i].Cells[0].Value?.ToString() ?? "";
                var dateRaised = dgvChangeRegister.Rows[i].Cells[1].Value?.ToString() ?? "";
                var raisedBy = dgvChangeRegister.Rows[i].Cells[2].Value?.ToString() ?? "";
                var receivedBy = dgvChangeRegister.Rows[i].Cells[3].Value?.ToString() ?? "";
                var description = dgvChangeRegister.Rows[i].Cells[4].Value?.ToString() ?? "";
                var impactDescription = dgvChangeRegister.Rows[i].Cells[5].Value?.ToString() ?? "";
                var impactRating = dgvChangeRegister.Rows[i].Cells[6].Value?.ToString() ?? "";
                var changeApprover = dgvChangeRegister.Rows[i].Cells[7].Value?.ToString() ?? "";
                var approvalStatus = dgvChangeRegister.Rows[i].Cells[8].Value?.ToString() ?? "";
                var approvalDate = dgvChangeRegister.Rows[i].Cells[9].Value?.ToString() ?? "";
                var implementationResource = dgvChangeRegister.Rows[i].Cells[10].Value?.ToString() ?? "";
                var implementationStatus = dgvChangeRegister.Rows[i].Cells[11].Value?.ToString() ?? "";
                var implementationDate = dgvChangeRegister.Rows[i].Cells[12].Value?.ToString() ?? "";

                try
                {
                    changeEntry.ID = int.Parse(id);
                }
                catch
                {
                    MessageBox.Show("The ID field must contain only numbers.");
                    return;
                }
                
                changeEntry.DateRaised = dateRaised;
                changeEntry.RaisedBy = raisedBy;
                changeEntry.ReceivedBy = receivedBy;
                changeEntry.Description = description;
                changeEntry.ImpactDescription = impactDescription;
                changeEntry.ImpactRating = impactRating;
                changeEntry.ChangeApprover = changeApprover;
                changeEntry.ApprovalStatus = approvalStatus;
                changeEntry.ApprovalDate = approvalDate;
                changeEntry.ImplementationResource = implementationResource;
                changeEntry.ImplementationStatus = implementationStatus;
                changeEntry.ImplementationDate = implementationDate;
                changeEntries.Add(changeEntry);
            }

            newChangeRegisterModel.ChangeEntries = changeEntries;
            newChangeRegisterModel.ProjectManager = Project_Manager_tbx.Text;
            newChangeRegisterModel.ProjectName = Project_Name_tbx.Text;

            List<VersionControl<ChangeRegisterModel>.DocumentModel> documentModels = versionControl.DocumentModels;

            if (!versionControl.isEqual(currentChangeRegisterModel, newChangeRegisterModel))
            {
                VersionControl<ChangeRegisterModel>.DocumentModel documentModel = new VersionControl<ChangeRegisterModel>.DocumentModel(newChangeRegisterModel, DateTime.Now, VersionControl<ChangeRegisterModel>.generateID());

                documentModels.Add(documentModel);
                string json = JsonConvert.SerializeObject(versionControl);
                currentChangeRegisterModel = JsonConvert.DeserializeObject<ChangeRegisterModel>(JsonConvert.SerializeObject(newChangeRegisterModel));
                JsonHelper.saveDocument(json, Settings.Default.ProjectID, "ChangeRegister");
                MessageBox.Show("Change register saved successfully", "save", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("No changes were made.", "save", MessageBoxButtons.OK);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void ChangeRegister_Load(object sender, EventArgs e)
        {
            string json = JsonHelper.loadDocument(Settings.Default.ProjectID, "ChangeRegister");
            newChangeRegisterModel = new ChangeRegisterModel();
            currentChangeRegisterModel = new ChangeRegisterModel();

            if (json != "")
            {
                versionControl = JsonConvert.DeserializeObject<VersionControl<ChangeRegisterModel>>(json);
                newChangeRegisterModel = JsonConvert.DeserializeObject<ChangeRegisterModel>(versionControl.getLatest(versionControl.DocumentModels));
                currentChangeRegisterModel = JsonConvert.DeserializeObject<ChangeRegisterModel>(versionControl.getLatest(versionControl.DocumentModels));

                Project_Manager_tbx.Text = currentChangeRegisterModel.ProjectManager;
                Project_Name_tbx.Text = currentChangeRegisterModel.ProjectName;

                foreach (var row in currentChangeRegisterModel.ChangeEntries)
                {
                    dgvChangeRegister.Rows.Add(new string[] { row.ID.ToString(), row.DateRaised, row.RaisedBy,
                    row.ReceivedBy, row.Description, row.ImpactDescription, row.ImpactRating, row.ChangeApprover, 
                    row.ApprovalStatus,row.ApprovalDate,row.ImplementationResource, row.ImplementationStatus, row.ImplementationDate});
                }
            }
            else
            {
                versionControl = new VersionControl<ChangeRegisterModel>();
                versionControl.DocumentModels = new List<VersionControl<ChangeRegisterModel>.DocumentModel>();
            }
        }
    }
}
