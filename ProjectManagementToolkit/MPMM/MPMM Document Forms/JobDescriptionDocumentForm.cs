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
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Forms
{
    public partial class JobDescriptionDocumentForm : Form
    {

        VersionControl<JobDescriptionModel> versionControl;
        JobDescriptionModel newJobDescriptionDocumentModel;
        JobDescriptionModel currentJobDescriptionDocumentModel;

        Color TABLE_HEADER_COLOR = Color.FromArgb(73, 173, 252);
        ProjectModel projectModel = new ProjectModel();



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


        private void exportToWord()
        {
            string path;
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                saveFileDialog.Filter = "Word 97-2003 Documents (*.doc)|*.doc|Word 2007 Documents (*.docx)|*.docx";
                saveFileDialog.FilterIndex = 2;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    path = saveFileDialog.FileName;
                    using (var document = DocX.Create(path))
                    {
                        for (int i = 0; i < 11; i++)
                        {
                            document.InsertParagraph("")
                                .Font("Arial")
                                .Bold(true)
                                .FontSize(22d).Alignment = Alignment.left;
                        }

                        //Code for the Front page
                        document.InsertParagraph("Project Plan \nFor " + projectModel.ProjectName)
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(22d).Alignment = Alignment.left;
                        document.InsertSectionPageBreak();
                        //Code for the Front page



                    }
                }
            }
        }


        public JobDescriptionDocumentForm()
         {
            InitializeComponent();
         }

        private void JobDescriptionDocumentForm_Load(object sender, EventArgs e)
        {
            loadDocument();
            string json = JsonHelper.loadProjectInfo(Settings.Default.Username);
            List<ProjectModel> projectListModel = JsonConvert.DeserializeObject<List<ProjectModel>>(json);
            projectModel = projectModel.getProjectModel(Settings.Default.ProjectID, projectListModel);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveDocument();
        }

        private void btnExportWord_Click(object sender, EventArgs e)
        {
            exportToWord();
        }
    }
}
