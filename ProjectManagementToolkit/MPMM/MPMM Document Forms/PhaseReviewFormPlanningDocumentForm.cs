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
using Xceed.Words.NET;
using Xceed.Document.NET;

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Forms
{
    public partial class PhaseReviewFormPlanningDocumentForm : Form
    {
        VersionControl<PhaseReviewPlanningModel> versionControl;
        PhaseReviewPlanningModel newPhaseReviewPlanningModel;
        PhaseReviewPlanningModel currentPhaseReviewPlanningModel;

        Color TABLE_HEADER_COLOR = Color.FromArgb(73, 173, 252);
        PhaseReviewPlanningModel PhaseReviewPlanning = new PhaseReviewPlanningModel();

        public PhaseReviewFormPlanningDocumentForm()
        {
            InitializeComponent();
        }

        public void SaveDocument()
        {
            newPhaseReviewPlanningModel.PlanningPhase = Planning_Phase_tbx.Text;
            newPhaseReviewPlanningModel.ProjectName = Project_Name_tbx.Text;
            newPhaseReviewPlanningModel.ProjectManager = Project_Manager_tbx.Text;
            newPhaseReviewPlanningModel.ProjectSponsor = Project_Sponsor_tbx.Text;

            /*newPhaseReviewPlanningModel.RepportPreparedBy = txtPreparedBy.Text;
            newPhaseReviewPlanningModel.ReportPrepDate = txtPrepDate.Text;
            newPhaseReviewPlanningModel.ReportingPeriod = txtReportingPeriod.Text;*/

            newPhaseReviewPlanningModel.Summary = Summary_tbx.Text;
            newPhaseReviewPlanningModel.ProjectSchedule = Project_Schedule_tbx.Text;
            newPhaseReviewPlanningModel.ProjectExpense = Project_Expenses_tbx.Text;
            newPhaseReviewPlanningModel.ProjectDeliverables = Project_Deliverables_tbx.Text;
            newPhaseReviewPlanningModel.ProjectRisks = Project_Risks_tbx.Text;
            newPhaseReviewPlanningModel.ProjectIssues = Project_Issues_tbx.Text;
            newPhaseReviewPlanningModel.ProjectChanges = Project_Changes_tbx.Text;

            newPhaseReviewPlanningModel.SupportingDocumentation = Supporting_Documentation_tbx.Text;

            List<ReviewDetails> reviews = new List<ReviewDetails>();
            int RowCount = REVIEW_DETAILS_dgv.RowCount;
            for (int i = 0; i < RowCount - 1; i++)
            {
                ReviewDetails review = new ReviewDetails();
                var ReviewCategory = REVIEW_DETAILS_dgv.Rows[i].Cells[0].Value?.ToString() ?? "";
                var ReviewQuestion = REVIEW_DETAILS_dgv.Rows[i].Cells[1].Value?.ToString() ?? "";
                var Answer = REVIEW_DETAILS_dgv.Rows[i].Cells[2].Value?.ToString() ?? "";
                var Variance = REVIEW_DETAILS_dgv.Rows[i].Cells[3].Value?.ToString() ?? "";

                review.ReviewCategory = ReviewCategory;
                review.ReviewQuestion = ReviewQuestion;
                review.Answer = Answer;
                review.Variance = Variance;

                reviews.Add(review);
            }

            newPhaseReviewPlanningModel.Reviews = reviews;

            newPhaseReviewPlanningModel.SupportingDocumentation = Supporting_Documentation_tbx.Text;

            List<VersionControl<PhaseReviewPlanningModel>.DocumentModel> documentModels = versionControl.DocumentModels;

            //MessageBox.Show(JsonConvert.SerializeObject(newPhaseReviewPlanningModel), "save", MessageBoxButtons.OK);

            if (!versionControl.isEqual(currentPhaseReviewPlanningModel, newPhaseReviewPlanningModel))
            {
                VersionControl<PhaseReviewPlanningModel>.DocumentModel documentModel = new VersionControl<PhaseReviewPlanningModel>.DocumentModel(newPhaseReviewPlanningModel, DateTime.Now, VersionControl<PhaseReviewPlanningModel>.generateID());

                documentModels.Add(documentModel);

                versionControl.DocumentModels = documentModels;
                currentPhaseReviewPlanningModel = JsonConvert.DeserializeObject<PhaseReviewPlanningModel>(JsonConvert.SerializeObject(newPhaseReviewPlanningModel));
                string json = JsonConvert.SerializeObject(versionControl);
                JsonHelper.saveDocument(json, Settings.Default.ProjectID, "PhaseReviewPlanning");
                MessageBox.Show("Phase Review Planning Form saved successfully", "save", MessageBoxButtons.OK);
            }
        }

        public void LoadDocument()
        {
            string json = JsonHelper.loadDocument(Settings.Default.ProjectID, "PhaseReviewPlanning");
            List<string[]> documentInfo = new List<string[]>();
            newPhaseReviewPlanningModel = new PhaseReviewPlanningModel();
            currentPhaseReviewPlanningModel = new PhaseReviewPlanningModel();

            if (json != "")
            {
                versionControl = JsonConvert.DeserializeObject<VersionControl<PhaseReviewPlanningModel>>(json);
                newPhaseReviewPlanningModel = JsonConvert.DeserializeObject<PhaseReviewPlanningModel>(versionControl.getLatest(versionControl.DocumentModels));
                currentPhaseReviewPlanningModel = JsonConvert.DeserializeObject<PhaseReviewPlanningModel>(versionControl.getLatest(versionControl.DocumentModels));

                Planning_Phase_tbx.Text = currentPhaseReviewPlanningModel.PlanningPhase;
                Project_Name_tbx.Text = currentPhaseReviewPlanningModel.ProjectName;
                Project_Manager_tbx.Text = currentPhaseReviewPlanningModel.ProjectManager;
                Project_Sponsor_tbx.Text = currentPhaseReviewPlanningModel.ProjectSponsor;

                /*txtPreparedBy.Text = currentPhaseReviewPlanningModel.RepportPreparedBy;
                txtPrepDate.Text = currentPhaseReviewPlanningModel.ReportPrepDate;
                txtReportingPeriod.Text = currentPhaseReviewPlanningModel.ReportingPeriod;*/

                Summary_tbx.Text = currentPhaseReviewPlanningModel.Summary;
                Project_Schedule_tbx.Text = currentPhaseReviewPlanningModel.ProjectSchedule;
                Project_Expenses_tbx.Text = currentPhaseReviewPlanningModel.ProjectExpense;
                Project_Deliverables_tbx.Text = currentPhaseReviewPlanningModel.ProjectDeliverables;
                Project_Risks_tbx.Text = currentPhaseReviewPlanningModel.ProjectRisks;
                Project_Issues_tbx.Text = currentPhaseReviewPlanningModel.ProjectIssues;
                Project_Changes_tbx.Text = currentPhaseReviewPlanningModel.ProjectChanges;

                foreach (var row in currentPhaseReviewPlanningModel.Reviews)
                {
                    REVIEW_DETAILS_dgv.Rows.Add(new string[] { row.ReviewCategory, row.ReviewQuestion, row.Answer, row.Variance });
                }

                Supporting_Documentation_tbx.Text = currentPhaseReviewPlanningModel.SupportingDocumentation;

            }
            else
            {
                versionControl = new VersionControl<PhaseReviewPlanningModel>();
                versionControl.DocumentModels = new List<VersionControl<PhaseReviewPlanningModel>.DocumentModel>();
                newPhaseReviewPlanningModel = new PhaseReviewPlanningModel();
            }

        }

        public void ExportToWord()
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
                        document.InsertParagraph("Planning Phase Stage Gate Review Form \nFor " + currentPhaseReviewPlanningModel.ProjectName)
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(22d).Alignment = Alignment.left;
                        document.InsertSectionPageBreak();

                        document.InsertParagraph("Stage Gate Review Form Planning Phase\n")
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(14d).Alignment = Alignment.left;

                        var projectDetailsTable = document.AddTable(4, 1);
                        projectDetailsTable.Rows[0].Cells[0].Paragraphs[0].Append("PROJECT DETAILS").Bold(true).Color(Color.White);
                        //projectDetailsTable.Rows[0].Cells[1].Paragraphs[0].Append("").Bold(true).Color(Color.White);
                        projectDetailsTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        //projectDetailsTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;

                        projectDetailsTable.Rows[1].Cells[0].Paragraphs[0].Append($"Project Name: { currentPhaseReviewPlanningModel.ProjectName}\t\t" +
                            $"Report Prepared By: {currentPhaseReviewPlanningModel.RepportPreparedBy}");

                        projectDetailsTable.Rows[2].Cells[0].Paragraphs[0].Append($"Project Manager: {currentPhaseReviewPlanningModel.ProjectManager}\t" +
                            $"Report Preparation Date: {currentPhaseReviewPlanningModel.ReportPrepDate}");

                        projectDetailsTable.Rows[3].Cells[0].Paragraphs[0].Append($"Project Sponsor: {currentPhaseReviewPlanningModel.ProjectSponsor}\t\t" +
                            $"Reporting Period {currentPhaseReviewPlanningModel.ReportingPeriod}");

                        projectDetailsTable.SetWidths(new float[] {1000});
                        document.InsertTable(projectDetailsTable);

                        var overAllStatusTable = document.AddTable(8, 1);
                        overAllStatusTable.Rows[0].Cells[0].Paragraphs[0].Append("OVERALL STATUS").Bold(true).Color(Color.White);
                        //acceptanceDetailsTable.Rows[0].Cells[1].Paragraphs[0].Append("").Bold(true).Color(Color.White);
                        overAllStatusTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        //acceptanceDetailsTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;

                        overAllStatusTable.Rows[1].Cells[0].Paragraphs[0].Append("Summary: " + currentPhaseReviewPlanningModel.Summary);
                        //overAllStatusTable.Rows[1].Cells[1].Paragraphs[0].Append(currentAcceptanceFormModel.AcceptanceId);
                        overAllStatusTable.Rows[2].Cells[0].Paragraphs[0].Append("Project Schedule: " + currentPhaseReviewPlanningModel.ProjectSchedule);
                        //overAllStatusTable.Rows[2].Cells[1].Paragraphs[0].Append(currentAcceptanceFormModel.RequestedBy);
                        overAllStatusTable.Rows[3].Cells[0].Paragraphs[0].Append("Project Expense: " + currentPhaseReviewPlanningModel.ProjectExpense);
                        //overAllStatusTable.Rows[3].Cells[1].Paragraphs[0].Append(currentAcceptanceFormModel.DateRequired);
                        overAllStatusTable.Rows[4].Cells[0].Paragraphs[0].Append("Project Deliverables: " + currentPhaseReviewPlanningModel.ProjectDeliverables);
                        //overAllStatusTable.Rows[4].Cells[1].Paragraphs[0].Append(currentAcceptanceFormModel.Description);
                        overAllStatusTable.Rows[5].Cells[0].Paragraphs[0].Append("Project Risks: " + currentPhaseReviewPlanningModel.ProjectRisks);
                        overAllStatusTable.Rows[6].Cells[0].Paragraphs[0].Append("Project Issues: " + currentPhaseReviewPlanningModel.ProjectIssues);
                        overAllStatusTable.Rows[7].Cells[0].Paragraphs[0].Append("Project Changes: " + currentPhaseReviewPlanningModel.ProjectChanges);

                        overAllStatusTable.SetWidths(new float[] {1000});
                        document.InsertTable(overAllStatusTable);

                        document.InsertParagraph("\nREVIEW DETAILS\n")
                           .Font("Arial")
                           .Bold(true)
                           .FontSize(14d).Alignment = Alignment.left;

                        var reviewDetailsTable = document.AddTable(currentPhaseReviewPlanningModel.Reviews.Count + 1, 4);
                        reviewDetailsTable.Rows[0].Cells[0].Paragraphs[0].Append("Review Category")
                            .Bold(true)
                            .Color(Color.White);
                        reviewDetailsTable.Rows[0].Cells[1].Paragraphs[0].Append("Review Question")
                            .Bold(true)
                            .Color(Color.White);
                        reviewDetailsTable.Rows[0].Cells[2].Paragraphs[0].Append("Answer")
                            .Bold(true)
                            .Color(Color.White);
                        reviewDetailsTable.Rows[0].Cells[3].Paragraphs[0].Append("Variance")
                            .Bold(true)
                            .Color(Color.White);

                        reviewDetailsTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        reviewDetailsTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        reviewDetailsTable.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;
                        reviewDetailsTable.Rows[0].Cells[3].FillColor = TABLE_HEADER_COLOR;


                        for (int i = 1; i < currentPhaseReviewPlanningModel.Reviews.Count + 1; i++)
                        {
                            reviewDetailsTable.Rows[i].Cells[0].Paragraphs[0].Append(currentPhaseReviewPlanningModel.Reviews[i - 1].ReviewCategory);
                            reviewDetailsTable.Rows[i].Cells[1].Paragraphs[0].Append(currentPhaseReviewPlanningModel.Reviews[i - 1].ReviewQuestion);
                            reviewDetailsTable.Rows[i].Cells[2].Paragraphs[0].Append(currentPhaseReviewPlanningModel.Reviews[i - 1].Answer);
                            reviewDetailsTable.Rows[i].Cells[3].Paragraphs[0].Append(currentPhaseReviewPlanningModel.Reviews[i - 1].Variance);
                        }

                        //reviewDetailsTable.SetWidths(new float[] { 190, 303, 1094 });
                        document.InsertTable(reviewDetailsTable);

                        document.InsertParagraph("")
                           .Font("Arial")
                           .Bold(true)
                           .FontSize(14d).Alignment = Alignment.left;

                        var approvalDetails = document.AddTable(2, 1);
                        approvalDetails.Rows[0].Cells[0].Paragraphs[0].Append("APPROVAL DETAILS").Bold(true).Color(Color.White);
                        //caustomerApproval.Rows[0].Cells[1].Paragraphs[0].Append("").Bold(true).Color(Color.White);
                        approvalDetails.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        //caustomerApproval.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;

                        approvalDetails.Rows[1].Cells[0].Paragraphs[0].Append($"Supporting Documentation:\n\n{currentPhaseReviewPlanningModel.SupportingDocumentation}\n");
                        //approvalDetails.Rows[1].Cells[1].Paragraphs[0].Append(currentAcceptanceFormModel.SupportingDocumentation);

                        approvalDetails.SetWidths(new float[] {1000});
                        document.InsertTable(approvalDetails);

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



        private void btnSave_Click_1(object sender, EventArgs e)
        {
            SaveDocument();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ExportToWord();
        }

        private void PhaseReviewFormPlanningDocumentForm_Load(object sender, EventArgs e)
        {
            LoadDocument();
        }
    }
}
