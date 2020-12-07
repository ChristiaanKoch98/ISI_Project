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
using ProjectManagementToolkit.MPMM.MPMM_Document_Models;
using ProjectManagementToolkit.Properties;
using ProjectManagementToolkit.Utility;

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Forms
{
    public partial class CommunicationsRegister : Form
    {
        VersionControl<CommunicationRegisterModel> versionControl;
        CommunicationRegisterModel newCommunicationRegisterModel;
        CommunicationRegisterModel currentCommunicationRegisterModel;
        ProjectModel projectModel = new ProjectModel();
        Color TABLE_HEADER_COLOR = Color.FromArgb(73, 173, 252);
        public CommunicationsRegister()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            List<CommunicationRegisterModel.CommunicationEntry> CommunicationEntries = new List<CommunicationRegisterModel.CommunicationEntry>();
            int issueEntryCount = dgvCommunicationsRegister.Rows.Count;

            for (int i = 0; i < issueEntryCount - 1; i++)
            {
                CommunicationRegisterModel.CommunicationEntry communicationEntry = new CommunicationRegisterModel.CommunicationEntry();
                var ID = dgvCommunicationsRegister.Rows[i].Cells[0].Value?.ToString() ?? "";
                var Status = dgvCommunicationsRegister.Rows[i].Cells[1].Value?.ToString() ?? "";
                var DateApproved = dgvCommunicationsRegister.Rows[i].Cells[2].Value?.ToString() ?? "";
                var ApprovedBy = dgvCommunicationsRegister.Rows[i].Cells[3].Value?.ToString() ?? "";
                var DateSent = dgvCommunicationsRegister.Rows[i].Cells[4].Value?.ToString() ?? "";
                var SendBy = dgvCommunicationsRegister.Rows[i].Cells[5].Value?.ToString() ?? "";
                var SendTo = dgvCommunicationsRegister.Rows[i].Cells[6].Value?.ToString() ?? "";
                var Type = dgvCommunicationsRegister.Rows[i].Cells[7].Value?.ToString() ?? "";
                var Message = dgvCommunicationsRegister.Rows[i].Cells[8].Value?.ToString() ?? "";
                var FileLocation = dgvCommunicationsRegister.Rows[i].Cells[9].Value?.ToString() ?? "";
                var FeedBack = dgvCommunicationsRegister.Rows[i].Cells[10].Value?.ToString() ?? "";
                
                communicationEntry.ID = int.Parse(ID);
                communicationEntry.Status = Status;
                communicationEntry.DateApproved = DateApproved;
                communicationEntry.ApprovedBy = ApprovedBy;
                communicationEntry.DateSent = DateSent;
                communicationEntry.SendBy = SendBy;
                communicationEntry.SendTo = SendTo;
                communicationEntry.Type = Type;
                communicationEntry.Message = Message;
                communicationEntry.FileLocation = FileLocation;
                communicationEntry.FeedBack = FeedBack;
          
                CommunicationEntries.Add(communicationEntry);
            }

            newCommunicationRegisterModel.CommunicationEntries = CommunicationEntries;
            List<VersionControl<CommunicationRegisterModel>.DocumentModel> documentModels = versionControl.DocumentModels;

            if (!versionControl.isEqual(currentCommunicationRegisterModel, newCommunicationRegisterModel))
            {
                VersionControl<CommunicationRegisterModel>.DocumentModel documentModel = new VersionControl<CommunicationRegisterModel>.DocumentModel(newCommunicationRegisterModel, DateTime.Now, VersionControl<CommunicationRegisterModel>.generateID());

                documentModels.Add(documentModel);
                string json = JsonConvert.SerializeObject(versionControl);
                currentCommunicationRegisterModel = JsonConvert.DeserializeObject<CommunicationRegisterModel>(JsonConvert.SerializeObject(newCommunicationRegisterModel));
                JsonHelper.saveDocument(json, Settings.Default.ProjectID, "CommunicationRegister");
                MessageBox.Show("Communication Register saved successfully", "save", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("No changes were made.", "save", MessageBoxButtons.OK);
            }
        }

        private void CommunicationsRegister_Load(object sender, EventArgs e)
        {
            string jsoni = JsonHelper.loadProjectInfo(Settings.Default.Username);
            List<ProjectModel> projectListModel = JsonConvert.DeserializeObject<List<ProjectModel>>(jsoni);
            projectModel = projectModel.getProjectModel(Settings.Default.ProjectID, projectListModel);
            txtIssueRegisterProjectName.Text = projectModel.ProjectName;
            txtIssueRegisterProjectManager.Text = projectModel.ProjectManager;


            string json = JsonHelper.loadDocument(Settings.Default.ProjectID, "CommunicationRegister");
            newCommunicationRegisterModel = new CommunicationRegisterModel();
            currentCommunicationRegisterModel = new CommunicationRegisterModel();

            if (json != "")
            {
                versionControl = JsonConvert.DeserializeObject<VersionControl<CommunicationRegisterModel>>(json);
                newCommunicationRegisterModel = JsonConvert.DeserializeObject<CommunicationRegisterModel>(versionControl.getLatest(versionControl.DocumentModels));
                currentCommunicationRegisterModel = JsonConvert.DeserializeObject<CommunicationRegisterModel>(versionControl.getLatest(versionControl.DocumentModels));

                foreach (var row in currentCommunicationRegisterModel.CommunicationEntries)
                {
                    dgvCommunicationsRegister.Rows.Add(new string[] { row.ID.ToString(), row.Status, row.DateApproved,
                    row.ApprovedBy,row.DateSent,row.SendBy,row.SendTo,row.Type,row.Message,row.FileLocation,row.FeedBack});
                }
            }
            else
            {
                versionControl = new VersionControl<CommunicationRegisterModel>();
                versionControl.DocumentModels = new List<VersionControl<CommunicationRegisterModel>.DocumentModel>();
            }
        }

        private void CommuncationsRegister_Click(object sender, EventArgs e)
        {

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ExcelAppend.ExportNotQualityRegister((int)ExcelAppend.DocumentType.CommunicationsRegister, dgvCommunicationsRegister);
        }
    }
}
