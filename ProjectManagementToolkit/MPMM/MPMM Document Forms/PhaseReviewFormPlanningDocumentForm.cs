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
    public partial class PhaseReviewFormPlanningDocumentForm : Form
    {
        VersionControl<PhaseReviewPlanningModel> versionControl;
        PhaseReviewPlanningModel newPhaseReviewPlanningModel;
        PhaseReviewPlanningModel currentPhaseReviewPlanningModel;

        PhaseReviewPlanningModel phaseReview;
        public PhaseReviewFormPlanningDocumentForm()
        {
            InitializeComponent();
            phaseReview = new PhaseReviewPlanningModel();
            LoadDocument();
        }

        private void PhaseReviewFormPlanningDocumentForm_Load(object sender, EventArgs e)
        {

        }

        private void PROJECT_DETAILS_btn_Click(object sender, EventArgs e)
        {
            if (Project_Name_tbx.Text.Length > 0 && Project_Manager_tbx.Text.Length > 0 && Project_Sponsor_tbx.Text.Length > 0)
            {
                phaseReview.ProjectName = Project_Name_tbx.Text;
                phaseReview.ProjectManager = Project_Manager_tbx.Text;
                phaseReview.ProjectSponsor = Project_Sponsor_tbx.Text;

                newPhaseReviewPlanningModel.ProjectName = phaseReview.ProjectName;
                newPhaseReviewPlanningModel.ProjectManager = phaseReview.ProjectManager;
                newPhaseReviewPlanningModel.ProjectSponsor = phaseReview.ProjectSponsor;
            }
        }

        private void OVERALL_STATUS_btn_Click(object sender, EventArgs e)
        {
            if (Summary_tbx.Text.Length > 0 && Project_Schedule_tbx.Text.Length > 0 && Project_Expenses_tbx.Text.Length > 0
                && Project_Deliverables_tbx.Text.Length > 0 && Project_Risks_tbx.Text.Length > 0 && Project_Issues_tbx.Text.Length > 0
                && Project_Changes_tbx.Text.Length > 0)
            {
                phaseReview.Summary = Summary_tbx.Text;
                phaseReview.ProjectSchedule = Project_Schedule_tbx.Text;
                phaseReview.ProjectExpense = Project_Expenses_tbx.Text;
                phaseReview.ProjectDeliverables = Project_Deliverables_tbx.Text;
                phaseReview.ProjectRisks = Project_Risks_tbx.Text;
                phaseReview.ProjectIssues = Project_Issues_tbx.Text;
                phaseReview.ProjectChanges = Project_Changes_tbx.Text;

                newPhaseReviewPlanningModel.Summary = phaseReview.Summary;
                newPhaseReviewPlanningModel.ProjectSchedule = phaseReview.ProjectSchedule;
                newPhaseReviewPlanningModel.ProjectExpense = phaseReview.ProjectExpense;
                newPhaseReviewPlanningModel.ProjectDeliverables = phaseReview.ProjectDeliverables;
                newPhaseReviewPlanningModel.ProjectRisks = phaseReview.ProjectRisks;
                newPhaseReviewPlanningModel.ProjectIssues = phaseReview.ProjectIssues;
                newPhaseReviewPlanningModel.ProjectChanges = phaseReview.ProjectChanges;

            }
        }

        private void CUSTOMER_APPROVAL_btn_Click(object sender, EventArgs e)
        {
            if (Supporting_Documentation_tbx.Text.Length > 0)
            {
                phaseReview.SupportingDocumentation = Supporting_Documentation_tbx.Text;
            }

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
            newPhaseReviewPlanningModel.reviws = reviews;

        }

        private void Enter_btn_Click(object sender, EventArgs e)
        {
            if (Planning_Phase_tbx.Text.Length > 0)
            {
                phaseReview.PlanningPhase = Planning_Phase_tbx.Text;
                newPhaseReviewPlanningModel.PlanningPhase = phaseReview.PlanningPhase;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveDocument();
        }

        public void SaveDocument()
        {
            List<VersionControl<PhaseReviewPlanningModel>.DocumentModel> documentModels = versionControl.DocumentModels;


            if (!versionControl.isEqual(currentPhaseReviewPlanningModel, newPhaseReviewPlanningModel))
            {
                VersionControl<PhaseReviewPlanningModel>.DocumentModel documentModel = new VersionControl<PhaseReviewPlanningModel>.DocumentModel(newPhaseReviewPlanningModel, DateTime.Now, VersionControl<PhaseReviewPlanningModel>.generateID());

                documentModels.Add(documentModel);

                versionControl.DocumentModels = documentModels;

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

                foreach (var row in currentPhaseReviewPlanningModel.reviws)
                {
                    REVIEW_DETAILS_dgv.Rows.Add(new string[] { row.ReviewCategory, row.ReviewQuestion, row.Answer, row.Variance });
                }
            }

            currentPhaseReviewPlanningModel.ProjectName = phaseReview.ProjectName;
            currentPhaseReviewPlanningModel.ProjectManager = phaseReview.ProjectManager;
            currentPhaseReviewPlanningModel.ProjectSponsor = phaseReview.ProjectSponsor;

            currentPhaseReviewPlanningModel.Summary = phaseReview.Summary;
            currentPhaseReviewPlanningModel.ProjectSchedule = phaseReview.ProjectSchedule;
            currentPhaseReviewPlanningModel.ProjectExpense = phaseReview.ProjectExpense;
            currentPhaseReviewPlanningModel.ProjectDeliverables = phaseReview.ProjectDeliverables;
            currentPhaseReviewPlanningModel.ProjectRisks = phaseReview.ProjectRisks;
            currentPhaseReviewPlanningModel.ProjectIssues = phaseReview.ProjectIssues;
            currentPhaseReviewPlanningModel.ProjectChanges = phaseReview.ProjectChanges;

            currentPhaseReviewPlanningModel.PlanningPhase = phaseReview.PlanningPhase;

        }
    }
}
