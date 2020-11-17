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
    public partial class JobDescriptionDocumentForm : Form
    {

        VersionControl<JobDescriptionModel> versionControl;
        JobDescriptionModel newJobDescriptionDocumentModel;
        JobDescriptionModel currentJobDescriptionDocumentModel;



        public void saveDocument()
        {

            newJobDescriptionDocumentModel.ProjectName = txtProjectName.Text;

            newJobDescriptionDocumentModel.ProjectNaOverviewDescriptionme = txtOverviewDescription.Text;

            newJobDescriptionDocumentModel.PurposeDescription = txtpurposeDescription.Text;

            newJobDescriptionDocumentModel.ResponsibilitiesDescription = txtresponsibilitiesDescription.Text;

            newJobDescriptionDocumentModel.OrganizationDescription = txtorganizationDescription.Text;

            newJobDescriptionDocumentModel.RelationshipsDescription = txtrelationshipsDescription.Text;

            newJobDescriptionDocumentModel.SkillsDescription = txtskillsDescription.Text;

            newJobDescriptionDocumentModel.ExperienceDescription = txtexperienceDescription.Text;

            newJobDescriptionDocumentModel.QualificationsDescription = txtqualificationsDescription.Text;

            newJobDescriptionDocumentModel.PersonalityDescription = txtpersonalityDescription.Text;

            newJobDescriptionDocumentModel.PerformancecriteriaDescription = txtperformancecriteriaDescription.Text;

            newJobDescriptionDocumentModel.WorkenvironmentDescription = txtworkenvironmentDescription.Text;

            newJobDescriptionDocumentModel.SalaryDescription = txtsalaryDescription.Text;

            newJobDescriptionDocumentModel.SpecialconditionsDescription = txtspecialconditionsDescription.Text;



            List<VersionControl<JobDescriptionModel>.DocumentModel> documentModels = versionControl.DocumentModels;


            if (!versionControl.isEqual(currentJobDescriptionDocumentModel, newJobDescriptionDocumentModel))
            {
                VersionControl<JobDescriptionModel>.DocumentModel documentModel = new VersionControl<JobDescriptionModel>.DocumentModel(newJobDescriptionDocumentModel, DateTime.Now, VersionControl<ProjectModel>.generateID());

                documentModels.Add(documentModel);

                versionControl.DocumentModels = documentModels;

                string json = JsonConvert.SerializeObject(versionControl);
                JsonHelper.saveDocument(json, Settings.Default.ProjectID, "JobDescription");
                MessageBox.Show("Job Decryption saved successfully", "save", MessageBoxButtons.OK);
            }
        }



        private void loadDocument()
        {
            string json = JsonHelper.loadDocument(Settings.Default.ProjectID, "JobDescription");
            List<string[]> documentInfo = new List<string[]>();
            newJobDescriptionDocumentModel = new JobDescriptionModel();
            currentJobDescriptionDocumentModel = new JobDescriptionModel();

            if (json != "")
            {
                versionControl = JsonConvert.DeserializeObject<VersionControl<JobDescriptionModel>>(json);
                newJobDescriptionDocumentModel = JsonConvert.DeserializeObject<JobDescriptionModel>(versionControl.getLatest(versionControl.DocumentModels));
                currentJobDescriptionDocumentModel = JsonConvert.DeserializeObject<JobDescriptionModel>(versionControl.getLatest(versionControl.DocumentModels));


                txtProjectName.Text = currentJobDescriptionDocumentModel.ProjectName  ;

                txtOverviewDescription.Text = currentJobDescriptionDocumentModel.ProjectNaOverviewDescriptionme  ;

                txtpurposeDescription.Text = currentJobDescriptionDocumentModel.PurposeDescription  ;

                txtresponsibilitiesDescription.Text = currentJobDescriptionDocumentModel.ResponsibilitiesDescription  ;

                txtorganizationDescription.Text = currentJobDescriptionDocumentModel.OrganizationDescription  ;

                txtrelationshipsDescription.Text = currentJobDescriptionDocumentModel.RelationshipsDescription  ;

                txtskillsDescription.Text = currentJobDescriptionDocumentModel.SkillsDescription  ;

                txtexperienceDescription.Text = currentJobDescriptionDocumentModel.ExperienceDescription  ;

                txtqualificationsDescription.Text = currentJobDescriptionDocumentModel.QualificationsDescription  ;

                txtpersonalityDescription.Text = currentJobDescriptionDocumentModel.PersonalityDescription  ;

                txtperformancecriteriaDescription.Text = currentJobDescriptionDocumentModel.PerformancecriteriaDescription  ;

                txtworkenvironmentDescription.Text = currentJobDescriptionDocumentModel.WorkenvironmentDescription  ;

                txtsalaryDescription.Text = currentJobDescriptionDocumentModel.SalaryDescription  ;

                txtspecialconditionsDescription.Text = currentJobDescriptionDocumentModel.SpecialconditionsDescription  ;

            }
            else
            {
                versionControl = new VersionControl<JobDescriptionModel>();
                versionControl.DocumentModels = new List<VersionControl<JobDescriptionModel>.DocumentModel>();

                newJobDescriptionDocumentModel = new JobDescriptionModel();
            }

        }



            public JobDescriptionDocumentForm()
        {
            InitializeComponent();
        }

        private void JobDescriptionDocumentForm_Load(object sender, EventArgs e)
        {
            loadDocument();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveDocument();
        }
    }
}
