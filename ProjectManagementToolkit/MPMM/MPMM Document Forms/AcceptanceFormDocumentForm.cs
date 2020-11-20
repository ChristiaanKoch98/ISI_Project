using ProjectManagementToolkit.Classes;
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
using Newtonsoft.Json;
using ProjectManagementToolkit.Properties;

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Forms
{
    public partial class AcceptanceFormDocumentForm : Form
    {
        VersionControl<AcceptanceFormModel> versionControl;
        AcceptanceFormModel newAcceptanceFormModel;
        AcceptanceFormModel currentAcceptanceFormModel;

        AcceptanceFormModel acceptanceFormModel;
        public AcceptanceFormDocumentForm()
        {
            InitializeComponent();
            acceptanceFormModel = new AcceptanceFormModel();
            LoadDocument();
        }

        private void PROJECT_DETAILS_btn_Click(object sender, EventArgs e)
        {
            if (Project_Name_tbx.Text.Length > 0 && Project_Manager_tbx.Text.Length > 0)
            {
                acceptanceFormModel.ProjectName = Project_Name_tbx.Text;
                acceptanceFormModel.ProjectManager = Project_Manager_tbx.Text;
                newAcceptanceFormModel.ProjectName = acceptanceFormModel.ProjectName;
                newAcceptanceFormModel.ProjectManager = acceptanceFormModel.ProjectManager;

            }
        }

        private void Enter_btn_Click(object sender, EventArgs e)
        {
            if (Acceptance_Form_Name_tbx.Text.Length > 0)
            {
                acceptanceFormModel.AcceptanceFormFor = Acceptance_Form_Name_tbx.Text;
                newAcceptanceFormModel.AcceptanceFormFor = acceptanceFormModel.AcceptanceFormFor;
            }

        }

        private void ACCEPTANCE_DETAILS_btn_Click(object sender, EventArgs e)
        {
            if ((Acceptance_ID_tbx.Text = Requested_By_tbx.Text = Date_Requested_tbx.Text = Description_tbx.Text).Length > 0)
            {
                acceptanceFormModel.AcceptanceId = int.Parse(Acceptance_ID_tbx.Text);
                acceptanceFormModel.RequestedBy = Requested_By_tbx.Text;
                acceptanceFormModel.DateRequired = Date_Requested_tbx.Text;
                acceptanceFormModel.Description = Description_tbx.Text;

                newAcceptanceFormModel.AcceptanceId = acceptanceFormModel.AcceptanceId;
                newAcceptanceFormModel.RequestedBy = acceptanceFormModel.RequestedBy;
                newAcceptanceFormModel.DateRequired = acceptanceFormModel.DateRequired;
                acceptanceFormModel.Description = acceptanceFormModel.Description;
            }
        }

        private void ACCEPTANCE_CRITERIA_btn_Click(object sender, EventArgs e)
        {
            if (Criteria_tbx.Text.Length > 0 && Standards_tbx.Text.Length > 0)
            {
                acceptanceFormModel.Criteria = Criteria_tbx.Text;
                acceptanceFormModel.Standards = Standards_tbx.Text;
                newAcceptanceFormModel.Criteria = acceptanceFormModel.Criteria;
                newAcceptanceFormModel.Standards = acceptanceFormModel.Standards;
            }
        }

        private void ACCEPTANCE_RESULTS_btn_Click(object sender, EventArgs e)
        {
            List<ChildAcceptanceFormModel> list = new List<ChildAcceptanceFormModel>();
            int ResultsrowCount = ACCEPTANCE_RESULTS_dgv.RowCount;
            for (int i = 0; i < ResultsrowCount - 1; i++)
            {
                ChildAcceptanceFormModel acceptanceFormModel = new ChildAcceptanceFormModel();
                var Acceptance = ACCEPTANCE_RESULTS_dgv.Rows[i].Cells[0].Value?.ToString() ?? "";
                var Method = ACCEPTANCE_RESULTS_dgv.Rows[i].Cells[1].Value?.ToString() ?? "";
                var Reviewer = ACCEPTANCE_RESULTS_dgv.Rows[i].Cells[2].Value?.ToString() ?? "";
                var Date = ACCEPTANCE_RESULTS_dgv.Rows[i].Cells[3].Value?.ToString() ?? "";
                var Result = ACCEPTANCE_RESULTS_dgv.Rows[i].Cells[4].Value?.ToString() ?? "";

                acceptanceFormModel.Acceptance = Acceptance;
                acceptanceFormModel.Method = Method;
                acceptanceFormModel.Reviewer = Reviewer;
                acceptanceFormModel.Date = Date;
                acceptanceFormModel.Result = Result;
                list.Add(acceptanceFormModel);
            }
            newAcceptanceFormModel.acceptanceForm = list;
    }

        private void CUSTOMER_APPROVAL_btn_Click(object sender, EventArgs e)
        {
            if (Supporting_Documentation_tbx.Text.Length > 0)
            {
                acceptanceFormModel.SupportingDocumentation = Supporting_Documentation_tbx.Text;
                newAcceptanceFormModel.SupportingDocumentation = acceptanceFormModel.SupportingDocumentation;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveDocument();
        }
        public void SaveDocument()
        {
            List<VersionControl<AcceptanceFormModel>.DocumentModel> documentModels = versionControl.DocumentModels;

            if (!versionControl.isEqual(currentAcceptanceFormModel, newAcceptanceFormModel))
            {
                VersionControl<AcceptanceFormModel>.DocumentModel documentModel = new VersionControl<AcceptanceFormModel>.DocumentModel(newAcceptanceFormModel, DateTime.Now, VersionControl<AcceptanceFormModel>.generateID());

                documentModels.Add(documentModel);

                versionControl.DocumentModels = documentModels;

                string json = JsonConvert.SerializeObject(versionControl);
                JsonHelper.saveDocument(json, Settings.Default.ProjectID, "AcceptanceForm");
                MessageBox.Show("Acceptance form saved successfully", "save", MessageBoxButtons.OK);
            }
        }
        public void LoadDocument()
        {
            string json = JsonHelper.loadDocument(Settings.Default.ProjectID, "AcceptanceForm");
            List<string[]> documentInfo = new List<string[]>();
            newAcceptanceFormModel = new AcceptanceFormModel();
            currentAcceptanceFormModel = new AcceptanceFormModel();
            if (json != "")
            {
                versionControl = JsonConvert.DeserializeObject<VersionControl<AcceptanceFormModel>>(json);
                newAcceptanceFormModel = JsonConvert.DeserializeObject<AcceptanceFormModel>(versionControl.getLatest(versionControl.DocumentModels));
                currentAcceptanceFormModel = JsonConvert.DeserializeObject<AcceptanceFormModel>(versionControl.getLatest(versionControl.DocumentModels));

                foreach (var row in currentAcceptanceFormModel.acceptanceForm)
                {
                    ACCEPTANCE_RESULTS_dgv.Rows.Add(new string[] { row.Acceptance, row.Method, row.Reviewer, row.Date, row.Result });
                }

                Acceptance_Form_Name_tbx.Text = acceptanceFormModel.AcceptanceFormFor;
                Project_Name_tbx.Text = acceptanceFormModel.ProjectName;
                Project_Manager_tbx.Text = acceptanceFormModel.ProjectManager;
                Acceptance_ID_tbx.Text = acceptanceFormModel.AcceptanceId.ToString();
                Requested_By_tbx.Text = acceptanceFormModel.RequestedBy;
                Date_Requested_tbx.Text = acceptanceFormModel.DateRequired;
                Description_tbx.Text = acceptanceFormModel.Description;
                Criteria_tbx.Text = acceptanceFormModel.Criteria;
                Standards_tbx.Text = acceptanceFormModel.Standards;
                Supporting_Documentation_tbx.Text = acceptanceFormModel.SupportingDocumentation;


            }
        }
    }
}
