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
                        document.InsertParagraph("Job Description \nFor " + projectModel.ProjectName)
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(22d).Alignment = Alignment.left;
                        document.InsertSectionPageBreak();
                        //Code for the Front page


                        //Code for a table of contents
                        var p = document.InsertParagraph();
                        var title = p.InsertParagraphBeforeSelf("Table of Contents").Bold().FontSize(20);

                        var tocSwitches = new Dictionary<TableOfContentsSwitches, string>()
                        {
                            { TableOfContentsSwitches.O, "1-3"},
                            { TableOfContentsSwitches.U, ""},
                            { TableOfContentsSwitches.Z, ""},
                            { TableOfContentsSwitches.H, ""}
                        };

                        document.InsertTableOfContents(p, "", tocSwitches);
                        //Code for a table of contents


                        //Code for a page break
                        document.InsertParagraph().InsertPageBreakAfterSelf();
                        //Code for a page break


                        //Code for a heading 1
                        var OverviewHeading = document.InsertParagraph("1 Overview")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        OverviewHeading.StyleId = "Heading1";
                        //Code for a heading 1
                        //Code for a sentence
                        document.InsertParagraph(currentJobDescriptionDocumentModel.ProjectNaOverviewDescriptionme)
                               .FontSize(11d)
                               .Color(Color.Black)
                               .Font("Arial").Alignment = Alignment.left;
                        //Code for a sentence


                        //Code for a heading 1
                        var PurposeHeading = document.InsertParagraph("2 Purpose")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        PurposeHeading.StyleId = "Heading1";
                        //Code for a heading 1
                        //Code for a sentence
                        document.InsertParagraph(currentJobDescriptionDocumentModel.PurposeDescription)
                               .FontSize(11d)
                               .Color(Color.Black)
                               .Font("Arial").Alignment = Alignment.left;
                        //Code for a sentence


                        //Code for a heading 1
                        var ResponsibilitiesHeading = document.InsertParagraph("3 Responsibilities")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        ResponsibilitiesHeading.StyleId = "Heading1";
                        //Code for a heading 1
                        //Code for a sentence
                        document.InsertParagraph(currentJobDescriptionDocumentModel.ResponsibilitiesDescription)
                               .FontSize(11d)
                               .Color(Color.Black)
                               .Font("Arial").Alignment = Alignment.left;
                        //Code for a sentence


                        //Code for a heading 1
                        var OrganizationHeading = document.InsertParagraph("4 Organization")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        OrganizationHeading.StyleId = "Heading1";
                        //Code for a heading 1
                        //Code for a sentence
                        document.InsertParagraph(currentJobDescriptionDocumentModel.OrganizationDescription)
                               .FontSize(11d)
                               .Color(Color.Black)
                               .Font("Arial").Alignment = Alignment.left;
                        //Code for a sentence


                        //Code for a heading 1
                        var RelationshipsHeading = document.InsertParagraph("5 Relationships")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        RelationshipsHeading.StyleId = "Heading1";
                        //Code for a heading 1
                        //Code for a sentence
                        document.InsertParagraph(currentJobDescriptionDocumentModel.RelationshipsDescription)
                               .FontSize(11d)
                               .Color(Color.Black)
                               .Font("Arial").Alignment = Alignment.left;
                        //Code for a sentence


                        //Code for a heading 1
                        var SkillsHeading = document.InsertParagraph("6 Skills")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        SkillsHeading.StyleId = "Heading1";
                        //Code for a heading 1
                        //Code for a sentence
                        document.InsertParagraph(currentJobDescriptionDocumentModel.SkillsDescription)
                               .FontSize(11d)
                               .Color(Color.Black)
                               .Font("Arial").Alignment = Alignment.left;
                        //Code for a sentence


                        //Code for a heading 1
                        var ExperienceHeading = document.InsertParagraph("7 Experience")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        ExperienceHeading.StyleId = "Heading1";
                        //Code for a heading 1
                        //Code for a sentence
                        document.InsertParagraph(currentJobDescriptionDocumentModel.ExperienceDescription)
                               .FontSize(11d)
                               .Color(Color.Black)
                               .Font("Arial").Alignment = Alignment.left;
                        //Code for a sentence


                        //Code for a heading 1
                        var QualificationsHeading = document.InsertParagraph("8 Qualifications")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        QualificationsHeading.StyleId = "Heading1";
                        //Code for a heading 1
                        //Code for a sentence
                        document.InsertParagraph(currentJobDescriptionDocumentModel.QualificationsDescription)
                               .FontSize(11d)
                               .Color(Color.Black)
                               .Font("Arial").Alignment = Alignment.left;
                        //Code for a sentence


                        //Code for a heading 1
                        var PersonalityHeading = document.InsertParagraph("9 Personality")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        PersonalityHeading.StyleId = "Heading1";
                        //Code for a heading 1
                        //Code for a sentence
                        document.InsertParagraph(currentJobDescriptionDocumentModel.PersonalityDescription)
                               .FontSize(11d)
                               .Color(Color.Black)
                               .Font("Arial").Alignment = Alignment.left;
                        //Code for a sentence


                        //Code for a heading 1
                        var PerformanceCriteriaHeading = document.InsertParagraph("10 Performance Criteria")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        PerformanceCriteriaHeading.StyleId = "Heading1";
                        //Code for a heading 1
                        //Code for a sentence
                        document.InsertParagraph(currentJobDescriptionDocumentModel.PerformancecriteriaDescription)
                               .FontSize(11d)
                               .Color(Color.Black)
                               .Font("Arial").Alignment = Alignment.left;
                        //Code for a sentence


                        //Code for a heading 1
                        var WorkEnvironmentHeading = document.InsertParagraph("11 Work Environment")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        WorkEnvironmentHeading.StyleId = "Heading1";
                        //Code for a heading 1
                        //Code for a sentence
                        document.InsertParagraph(currentJobDescriptionDocumentModel.WorkenvironmentDescription)
                               .FontSize(11d)
                               .Color(Color.Black)
                               .Font("Arial").Alignment = Alignment.left;
                        //Code for a sentence


                        //Code for a heading 1
                        var SalaryHeading = document.InsertParagraph("12 Salary")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        SalaryHeading.StyleId = "Heading1";
                        //Code for a heading 1
                        //Code for a sentence
                        document.InsertParagraph(currentJobDescriptionDocumentModel.SalaryDescription)
                               .FontSize(11d)
                               .Color(Color.Black)
                               .Font("Arial").Alignment = Alignment.left;
                        //Code for a sentence


                        //Code for a heading 1
                        var SpecialConditionsHeading = document.InsertParagraph("13 Special Conditions")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        SpecialConditionsHeading.StyleId = "Heading1";
                        //Code for a heading 1
                        //Code for a sentence
                        document.InsertParagraph(currentJobDescriptionDocumentModel.SpecialconditionsDescription)
                               .FontSize(11d)
                               .Color(Color.Black)
                               .Font("Arial").Alignment = Alignment.left;
                        //Code for a sentence



                        //Code for saving
                        try
                        {
                            document.Save();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("The selected File is open.", "Close File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        //Code for saving



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

        private void txtworkenvironmentDescription_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveDocument();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            exportToWord();
        }
    }
}
