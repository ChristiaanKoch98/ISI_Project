using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectManagementToolkit.MPMM.MPMM_Document_Models;
using ProjectManagementToolkit.Utility;
using ProjectManagementToolkit.Properties;
using Newtonsoft.Json;
using Xceed.Words.NET;
using Xceed.Document.NET;

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Forms
{
    public partial class PhaseReviewFormInitiationDocumentForm : Form
    {
        VersionControl<PhaseReviewFormInitiationModel> versionControl;
        PhaseReviewFormInitiationModel newPhaseReviewFormInitiationModel;
        PhaseReviewFormInitiationModel currentPhaseReviewFormInitiationModel;
        Color TABLE_HEADER_COLOR = Color.FromArgb(73, 173, 252);
        ProjectModel projectModel = new ProjectModel();
        public PhaseReviewFormInitiationDocumentForm()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveDocument();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            exportToWord();
        }

        private void PhaseReviewFormInitiationDocumentForm_Load(object sender, EventArgs e)
        {
            loadDocument();
            string json = JsonHelper.loadProjectInfo(Settings.Default.Username);
            List<ProjectModel> projectListModel = JsonConvert.DeserializeObject<List<ProjectModel>>(json);
            projectModel = projectModel.getProjectModel(Settings.Default.ProjectID, projectListModel);
            projectName.Text = projectModel.ProjectName;
        }

        public void saveDocument()
        {
            newPhaseReviewFormInitiationModel.ProjectName = projectName.Text;
            newPhaseReviewFormInitiationModel.ProjectManager = projectManager.Text;
            newPhaseReviewFormInitiationModel.ProjectSponsor = projectSponsor.Text;
            newPhaseReviewFormInitiationModel.ReportPreparedBy = reportPreparedBy.Text;
            newPhaseReviewFormInitiationModel.ReportPreparationDate = reportPreparationDate.Text;
            newPhaseReviewFormInitiationModel.ReportingPeriod = reportingPeriod.Text;

            newPhaseReviewFormInitiationModel.Summary = summary.Text;
            newPhaseReviewFormInitiationModel.ProjectSchedule = projectSchedule.Text;
            newPhaseReviewFormInitiationModel.ProjectExpenses = projectExpenses.Text;
            newPhaseReviewFormInitiationModel.ProjectDeliverables = projectDeliverables.Text;
            newPhaseReviewFormInitiationModel.ProjectRisks = projectRisks.Text;
            newPhaseReviewFormInitiationModel.ProjectIssues = projectIssues.Text;
            newPhaseReviewFormInitiationModel.ProjectChanges = projectChanges.Text;

            int reviewDetailCount = dgvReviewDetails.Rows.Count;
            newPhaseReviewFormInitiationModel.ReviewDetials = new List<PhaseReviewFormInitiationModel.ReviewDetial>();
            for (int i = 0; i < reviewDetailCount - 1; i++)
            {
                var category = dgvReviewDetails.Rows[i].Cells[0].Value?.ToString() ?? "";
                var question = dgvReviewDetails.Rows[i].Cells[1].Value?.ToString() ?? "";
                var answer = dgvReviewDetails.Rows[i].Cells[2].Value?.ToString() ?? "";
                var varaince = dgvReviewDetails.Rows[i].Cells[3].Value?.ToString() ?? "";
                newPhaseReviewFormInitiationModel.ReviewDetials
                    .Add(new PhaseReviewFormInitiationModel.ReviewDetial(category, question, answer, varaince));
            }

            newPhaseReviewFormInitiationModel.SupportingDocumentation = supportingDetails.Text;
            newPhaseReviewFormInitiationModel.SignatureDate = signatureDate.Value.ToString();

            List<VersionControl<PhaseReviewFormInitiationModel>.DocumentModel> documentModels = versionControl.DocumentModels;
            if (!versionControl.isEqual(currentPhaseReviewFormInitiationModel, newPhaseReviewFormInitiationModel))
            {
                VersionControl<PhaseReviewFormInitiationModel>.DocumentModel documentModel = new VersionControl<PhaseReviewFormInitiationModel>.DocumentModel(newPhaseReviewFormInitiationModel, DateTime.Now, VersionControl<ProjectModel>.generateID());
                documentModels.Add(documentModel);
                versionControl.DocumentModels = documentModels;
                string json = JsonConvert.SerializeObject(versionControl);
                currentPhaseReviewFormInitiationModel = JsonConvert.DeserializeObject<PhaseReviewFormInitiationModel>(JsonConvert.SerializeObject(newPhaseReviewFormInitiationModel));
                JsonHelper.saveDocument(json, Settings.Default.ProjectID, "PhaseReviewFormInitiation");
                MessageBox.Show("Phase Review Initiation Form saved successfully", "save", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("No changes was made!", "save", MessageBoxButtons.OK);
            }
        }

        private void loadDocument()
        {
            string json = JsonHelper.loadDocument(Settings.Default.ProjectID, "PhaseReviewFormInitiation");
            List<string[]> documentReviewDetails = new List<string[]>();
            newPhaseReviewFormInitiationModel = new PhaseReviewFormInitiationModel();
            currentPhaseReviewFormInitiationModel = new PhaseReviewFormInitiationModel();
            if (json != "")
            {
                versionControl = JsonConvert.DeserializeObject<VersionControl<PhaseReviewFormInitiationModel>>(json);
                newPhaseReviewFormInitiationModel = JsonConvert.DeserializeObject<PhaseReviewFormInitiationModel>(versionControl.getLatest(versionControl.DocumentModels));
                currentPhaseReviewFormInitiationModel = JsonConvert.DeserializeObject<PhaseReviewFormInitiationModel>(versionControl.getLatest(versionControl.DocumentModels));
                projectName.Text = newPhaseReviewFormInitiationModel.ProjectName ;
                projectManager.Text = newPhaseReviewFormInitiationModel.ProjectManager;
                projectSponsor.Text = newPhaseReviewFormInitiationModel.ProjectSponsor;
                reportPreparedBy.Text = newPhaseReviewFormInitiationModel.ReportPreparedBy;
                reportPreparationDate.Text = newPhaseReviewFormInitiationModel.ReportPreparationDate;
                reportingPeriod.Text = newPhaseReviewFormInitiationModel.ReportingPeriod;

                summary.Text = newPhaseReviewFormInitiationModel.Summary;
                projectSchedule.Text = newPhaseReviewFormInitiationModel.ProjectSchedule;
                projectExpenses.Text = newPhaseReviewFormInitiationModel.ProjectExpenses;
                projectDeliverables.Text = newPhaseReviewFormInitiationModel.ProjectDeliverables;
                projectRisks.Text = newPhaseReviewFormInitiationModel.ProjectRisks;
                projectIssues.Text = newPhaseReviewFormInitiationModel.ProjectIssues;
                projectChanges.Text = newPhaseReviewFormInitiationModel.ProjectChanges;
                projectChanges.Text = newPhaseReviewFormInitiationModel.ProjectChanges;
                
                foreach (var row in currentPhaseReviewFormInitiationModel.ReviewDetials)
                {
                    dgvReviewDetails.Rows.Add(new string[] {row.ReviewCategory,row.ReviewQuestion,row.Answer,row.Varaince});
                }
            }
            else
            {
                versionControl = new VersionControl<PhaseReviewFormInitiationModel>();
                versionControl.DocumentModels = new List<VersionControl<PhaseReviewFormInitiationModel>.DocumentModel>();
                currentPhaseReviewFormInitiationModel.ReviewDetials = new List<PhaseReviewFormInitiationModel.ReviewDetial>(); 
                currentPhaseReviewFormInitiationModel.ReviewDetials
                    .Add(new PhaseReviewFormInitiationModel.ReviewDetial("Schedule", "Was the phase completed to schedule?", "", ""));
                currentPhaseReviewFormInitiationModel.ReviewDetials
                    .Add(new PhaseReviewFormInitiationModel.ReviewDetial("Expenses", "Was the phase completed within budget?", "", ""));
                currentPhaseReviewFormInitiationModel.ReviewDetials
                    .Add(new PhaseReviewFormInitiationModel.ReviewDetial("Business Case", "Was a Business Case completed and approved?", "", ""));
                currentPhaseReviewFormInitiationModel.ReviewDetials
                    .Add(new PhaseReviewFormInitiationModel.ReviewDetial("Feasibility Study", "Was a Feasibility Study completed and approved?", "", ""));
                currentPhaseReviewFormInitiationModel.ReviewDetials
                    .Add(new PhaseReviewFormInitiationModel.ReviewDetial("Terms of Reference", "Was a Terms of Reference completed and approved?", "", ""));
                currentPhaseReviewFormInitiationModel.ReviewDetials
                    .Add(new PhaseReviewFormInitiationModel.ReviewDetial("Project Team", "Has the Project Team been appointed?", "", ""));
                currentPhaseReviewFormInitiationModel.ReviewDetials
                    .Add(new PhaseReviewFormInitiationModel.ReviewDetial("Project Office", "Has the Project Office been established?", "", ""));
                currentPhaseReviewFormInitiationModel.ReviewDetials
                    .Add(new PhaseReviewFormInitiationModel.ReviewDetial("Other", "Are there any outstanding deliverables?", "", ""));
                currentPhaseReviewFormInitiationModel.ReviewDetials
                    .Add(new PhaseReviewFormInitiationModel.ReviewDetial("Risks", "Are there any outstanding project risks?", "", ""));
                currentPhaseReviewFormInitiationModel.ReviewDetials
                    .Add(new PhaseReviewFormInitiationModel.ReviewDetial("Issues", "Are there any outstanding project issues?", "", ""));
                currentPhaseReviewFormInitiationModel.ReviewDetials
                   .Add(new PhaseReviewFormInitiationModel.ReviewDetial("Changes", "Are there any outstanding project changes?", "", ""));
                
                foreach (var row in currentPhaseReviewFormInitiationModel.ReviewDetials)
                {
                    dgvReviewDetails.Rows.Add(new string[] {row.ReviewCategory,row.ReviewQuestion,row.Answer,row.Varaince });
                }

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
                        document.InsertParagraph("Initiation Phase \nStage Gate Review Form\nFor " + projectModel.ProjectName)
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(22d).Alignment = Alignment.left;
                        document.InsertSectionPageBreak();

                        document.InsertParagraph("Stage Gate Review Form\nInitiation Phase")
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(14d).Alignment = Alignment.left;

                        var phaseTable = document.AddTable(9, 1);
                        phaseTable.Rows[0].Cells[0].Paragraphs[0]
                            .Append("Project Details")
                            .Bold(true)
                            .Font("Arial")
                            .FontSize(11d)
                            .Color(Color.White)
                            .SpacingBefore(6d)
                            .SpacingAfter(6d);
                        phaseTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;

                        phaseTable.Rows[1].Cells[0]
                            .InsertParagraph("Project Name:"+currentPhaseReviewFormInitiationModel.ProjectName
                            +"\tReport Prepared By"+currentPhaseReviewFormInitiationModel.ReportPreparedBy
                            +"\nProject Manager:"+currentPhaseReviewFormInitiationModel.ProjectManager+"\tReport Preparation Date:"+currentPhaseReviewFormInitiationModel.ReportPreparationDate
                            +"\nProject Sponsor:"+currentPhaseReviewFormInitiationModel.ProjectSponsor+"\tReporting Period:"+currentPhaseReviewFormInitiationModel.ReportingPeriod)
                            .Font("Arial")
                            .FontSize(11d)
                            .SpacingBefore(12d)
                            .SpacingAfter(12d);

                        string overallStatus =
                            $"Summary: {currentPhaseReviewFormInitiationModel.Summary}\n" +
                            $"Project Schedule: {currentPhaseReviewFormInitiationModel.ProjectSchedule}\n" +
                            $"Project Expenses: {currentPhaseReviewFormInitiationModel.ProjectExpenses}\n" +
                            $"Project Deliverables: {currentPhaseReviewFormInitiationModel.ProjectDeliverables}\n" +
                            $"Project Risks: {currentPhaseReviewFormInitiationModel.ProjectRisks}\n" +
                            $"Project Issues: {currentPhaseReviewFormInitiationModel.ProjectIssues}\n" +
                            $"Project Changes: {currentPhaseReviewFormInitiationModel.ProjectChanges}";

                        phaseTable.Rows[2].Cells[0].Paragraphs[0]
                            .Append("Overall Status")
                            .Bold(true)
                            .Font("Arial")
                            .FontSize(11d)
                            .Color(Color.White)
                            .SpacingBefore(6d)
                            .SpacingAfter(6d);
                        phaseTable.Rows[2].Cells[0].FillColor = TABLE_HEADER_COLOR;

                        phaseTable.Rows[3].Cells[0].Paragraphs[0]
                            .Append(overallStatus)
                            .Font("Arial")
                            .FontSize(11d)
                            .SpacingBefore(12d)
                            .SpacingAfter(12d);

                        phaseTable.Rows[4].Cells[0].Paragraphs[0]
                            .Append("Review Details")
                            .Bold(true)
                            .Font("Arial")
                            .FontSize(11d)
                            .Color(Color.White)
                            .SpacingBefore(6d)
                            .SpacingAfter(6d);
                        phaseTable.Rows[4].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        var reviewDetailsTable = document.AddTable(12, 4);
                        reviewDetailsTable.Rows[0].Cells[0].Paragraphs[0].Append("Review Category")
                           .Bold(true);
                        reviewDetailsTable.Rows[0].Cells[1].Paragraphs[0].Append("Review Question")
                            .Bold(true);
                        reviewDetailsTable.Rows[0].Cells[2].Paragraphs[0].Append("Answer")
                            .Bold(true);
                        reviewDetailsTable.Rows[0].Cells[3].Paragraphs[0].Append("Variance")
                            .Bold(true);

                        reviewDetailsTable.Rows[0].Cells[0].FillColor = Color.Yellow;
                        reviewDetailsTable.Rows[0].Cells[1].FillColor = Color.Yellow;
                        reviewDetailsTable.Rows[0].Cells[2].FillColor = Color.Yellow;
                        reviewDetailsTable.Rows[0].Cells[3].FillColor = Color.Yellow;

                        for (int i = 1; i < currentPhaseReviewFormInitiationModel.ReviewDetials.Count + 1; i++)
                        {
                            reviewDetailsTable.Rows[i].Cells[0].Paragraphs[0].Append(currentPhaseReviewFormInitiationModel.ReviewDetials[i - 1].ReviewCategory);
                            reviewDetailsTable.Rows[i].Cells[1].Paragraphs[0].Append(currentPhaseReviewFormInitiationModel.ReviewDetials[i - 1].ReviewQuestion);
                            reviewDetailsTable.Rows[i].Cells[2].Paragraphs[0].Append(currentPhaseReviewFormInitiationModel.ReviewDetials[i - 1].Answer);
                            reviewDetailsTable.Rows[i].Cells[3].Paragraphs[0].Append(currentPhaseReviewFormInitiationModel.ReviewDetials[i - 1].Varaince);
                        }
      

                        phaseTable.Rows[5].Cells[0].Paragraphs[0]
                            .InsertTableAfterSelf(reviewDetailsTable).SetWidths(new float[] { 399, 700, 166, 188 });

                        phaseTable.Rows[6].Cells[0].Paragraphs[0]
                            .Append("Approval Details")
                            .Bold(true)
                            .Font("Arial")
                            .FontSize(11d)
                            .Color(Color.White)
                            .SpacingBefore(6d)
                            .SpacingAfter(6d);
                        phaseTable.Rows[6].Cells[0].FillColor = TABLE_HEADER_COLOR;

                        phaseTable.Rows[7].Cells[0]
                            .InsertParagraph("Supporting Documentation:\n" + currentPhaseReviewFormInitiationModel.SupportingDocumentation)
                            .Font("Arial")
                            .FontSize(11d)
                            .SpacingBefore(12d)
                            .SpacingAfter(12d);

                        phaseTable.Rows[8].Cells[0]
                           .InsertParagraph("Signature:                                                                          Date:")
                           .Font("Arial")
                           .FontSize(11d)
                           .SpacingBefore(12d)
                           .SpacingAfter(12d);

                        phaseTable.Rows[8].Cells[0]
                           .InsertParagraph("_______________________                                            " + Convert.ToDateTime(currentPhaseReviewFormInitiationModel.SignatureDate).ToShortDateString())
                           .Font("Arial")
                           .FontSize(11d)
                           .SpacingBefore(12d)
                           .SpacingAfter(12d);

                        phaseTable.Rows[8].Cells[0]
                           .InsertParagraph("PLEASE FORWARD THIS FORM TO THE PROJECT MANAGER FOR ACTION")
                           .Font("Arial")
                           .FontSize(11d)
                           .SpacingBefore(12d)
                           .SpacingAfter(12d);


                        phaseTable.SetWidths(new float[] { 1650 });
                        document.InsertTable(phaseTable);

                        try
                        {
                            document.Save();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("The selected File is open.", "Close File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
    }
}
