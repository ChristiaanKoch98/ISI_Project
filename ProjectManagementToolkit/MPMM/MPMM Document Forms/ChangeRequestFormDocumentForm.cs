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
    public partial class ChangeRequestFormDocumentForm : Form
    {
        VersionControl<ChangeRequestModel> versionControl;
        ChangeRequestModel newChangeRequestModel;
        ChangeRequestModel currentChangeRequestModel;

        public ChangeRequestFormDocumentForm()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnChangeSave_Click(object sender, EventArgs e)
        {
            saveDocument();
        }

        private void ChangeRequestFormDocumentForm_Load(object sender, EventArgs e)
        {
            loadDocument();
        }

        public void saveDocument()
        {
            newChangeRequestModel.ProjectName = projectNameTextBox.Text;
            newChangeRequestModel.ProjectManager = projectMamagerTextBox.Text;
            newChangeRequestModel.ChangeNumber = chngNumLabel.Text;
            newChangeRequestModel.ChangeRequester = chngRqstTextBox.Text;
            newChangeRequestModel.ChangeRequestDate = chngRqstDateTextField.Text;
            newChangeRequestModel.ChangeUrgancy = chngeUrgencyTextBox.Text;
            newChangeRequestModel.ChangeDescription = chngDscrpTextBox.Text;
            newChangeRequestModel.ChangeDrivers = changeDriversTextField.Text;
            newChangeRequestModel.ChangeBenefits = chngBnftsTextBox.Text;
            newChangeRequestModel.ChangeCost = chngCostsTextBox.Text;
            newChangeRequestModel.ProjectImpact = textBox2.Text;
            newChangeRequestModel.SupportingDocumentation = approvalDetailsTextBox.Text;
            newChangeRequestModel.Signatue = signatureTextBox.Text;

            List<VersionControl<ChangeRequestModel>.DocumentModel> documentModels = versionControl.DocumentModels;


            if (!versionControl.isEqual(currentChangeRequestModel, newChangeRequestModel))
            {
                VersionControl<ChangeRequestModel>.DocumentModel documentModel = new VersionControl<ChangeRequestModel>.DocumentModel(newChangeRequestModel, DateTime.Now, VersionControl<ProjectModel>.generateID());

                documentModels.Add(documentModel);

                versionControl.DocumentModels = documentModels;

                string json = JsonConvert.SerializeObject(versionControl);
                JsonHelper.saveDocument(json, Settings.Default.ProjectID, "ChangeRequestForm");
                MessageBox.Show("Change Request saved successfully", "save", MessageBoxButtons.OK);
            }
        }

        public void loadDocument()
        {
            string json = JsonHelper.loadDocument(Settings.Default.ProjectID, "ChangeRequestForm");
            List<string[]> documentInfo = new List<string[]>();
            newChangeRequestModel = new ChangeRequestModel();
            currentChangeRequestModel = new ChangeRequestModel();
            if (json != "")
            {
                versionControl = JsonConvert.DeserializeObject<VersionControl<ChangeRequestModel>>(json);
                newChangeRequestModel = JsonConvert.DeserializeObject<ChangeRequestModel>(versionControl.getLatest(versionControl.DocumentModels));
                currentChangeRequestModel = JsonConvert.DeserializeObject<ChangeRequestModel>(versionControl.getLatest(versionControl.DocumentModels));


                projectNameTextBox.Text = currentChangeRequestModel.ProjectName;
                projectMamagerTextBox.Text = currentChangeRequestModel.ProjectManager;
                chngNumLabel.Text = currentChangeRequestModel.ChangeNumber;
                chngRqstTextBox.Text = currentChangeRequestModel.ChangeRequester;
                chngRqstDateTextField.Text = currentChangeRequestModel.ChangeRequestDate;
                chngeUrgencyTextBox.Text = currentChangeRequestModel.ChangeUrgancy;
                chngDscrpTextBox.Text = currentChangeRequestModel.ChangeDescription;
                changeDriversTextField.Text = currentChangeRequestModel.ChangeDrivers;
                chngBnftsTextBox.Text = currentChangeRequestModel.ChangeBenefits;
                chngCostsTextBox.Text = currentChangeRequestModel.ChangeCost;
                textBox2.Text = currentChangeRequestModel.ProjectImpact;
                approvalDetailsTextBox.Text = currentChangeRequestModel.SupportingDocumentation;
                signatureTextBox.Text = currentChangeRequestModel.Signatue;

            }
        }

    }
}
