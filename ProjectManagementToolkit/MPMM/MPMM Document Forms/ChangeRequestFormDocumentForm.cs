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
            newChangeRequestModel.ProjectName = txtProjectName.Text;
            newChangeRequestModel.ProjectManager = txtProjectManager.Text;
            newChangeRequestModel.ChangeNumber = txtChangeDetails.Text;
            newChangeRequestModel.ChangeRequester = txtChangeRequester.Text;
            newChangeRequestModel.ChangeRequestDate = txtChangeRequestDate.Text;
            newChangeRequestModel.ChangeUrgancy = txtChangeUrgency.Text;
            newChangeRequestModel.ChangeDescription = txtChangeDescription.Text;
            newChangeRequestModel.ChangeDrivers = txtChangeDrivers.Text;
            newChangeRequestModel.ChangeBenefits = txtChangeBenefits.Text;
            newChangeRequestModel.ChangeCost = txtChangeCosts.Text;
            newChangeRequestModel.ProjectImpact = textBox1.Text;

            //newChangeRequestModel.SupportingDocumentation = approvalDetailsTextBox.Text;

            newChangeRequestModel.SubmittedName = txtName.Text;
            newChangeRequestModel.SubmittedRole = txtProjectRole.Text;
            newChangeRequestModel.SubmittedSignature = txtSignature.Text;
            newChangeRequestModel.SubmittedDate = dateTimePickerSubmittedBy.Text;

            newChangeRequestModel.ApprovedName = txtApprovedByName.Text;
            newChangeRequestModel.ApprovedRole = txtApprovedByProjectRole.Text;
            newChangeRequestModel.ApprovedSignature = txtApprovedBySignature.Text;
            newChangeRequestModel.ApprovedDate = dateTimePickerApprovedBy.Text;

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


                txtProjectName.Text = currentChangeRequestModel.ProjectName;
                txtProjectManager.Text = currentChangeRequestModel.ProjectManager;
                txtChangeDetails.Text = currentChangeRequestModel.ChangeNumber;
                txtChangeRequester.Text = currentChangeRequestModel.ChangeRequester;
                txtChangeRequestDate.Text = currentChangeRequestModel.ChangeRequestDate;
                txtChangeUrgency.Text = currentChangeRequestModel.ChangeUrgancy;
                txtChangeDescription.Text = currentChangeRequestModel.ChangeDescription;
                txtChangeDrivers.Text = currentChangeRequestModel.ChangeDrivers;
                txtChangeBenefits.Text = currentChangeRequestModel.ChangeBenefits;
                txtChangeCosts.Text = currentChangeRequestModel.ChangeCost;
                textBox1.Text = currentChangeRequestModel.ProjectImpact;

                //approvalDetailsTextBox.Text = currentChangeRequestModel.SupportingDocumentation;


                txtName.Text = currentChangeRequestModel.SubmittedName ;
                txtProjectRole.Text = currentChangeRequestModel.SubmittedRole ;
                txtSignature.Text = currentChangeRequestModel.SubmittedSignature ;
                dateTimePickerSubmittedBy.Text = currentChangeRequestModel.SubmittedDate ;

                txtApprovedByName.Text = currentChangeRequestModel.ApprovedName ;
                txtApprovedByProjectRole.Text = currentChangeRequestModel.ApprovedRole ;
                txtApprovedBySignature.Text = currentChangeRequestModel.ApprovedSignature ;
                dateTimePickerApprovedBy.Text = currentChangeRequestModel.ApprovedDate ;

            }
        }

        private void signatureTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
