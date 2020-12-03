using ProjectManagementToolkit.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Forms
{
    public partial class PhaseReviewFormPlanningDocumentForm : Form
    {
        PhaseReviewPlanningModel phaseReview;
        public PhaseReviewFormPlanningDocumentForm()
        {
            InitializeComponent();
            phaseReview = new PhaseReviewPlanningModel();
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
            }
        }

        private void OVERALL_STATUS_btn_Click(object sender, EventArgs e)
        {
            if (Summary_tbx.Text.Length > 0 && Project_Schedule_tbx.Text.Length > 0 && Project_Expenses_tbx.Text.Length > 0
                && Project_Deliverables_tbx.Text.Length > 0 && Project_Risks_tbx.Text.Length > 0 && Project_Issues_tbx.Text.Length > 0
                && Project_Changes_tbx.Text.Length > 0)
            {
                phaseReview.Suummary = Summary_tbx.Text;
                phaseReview.ProjectSchedule = Project_Schedule_tbx.Text;
                phaseReview.ProjectExpense = Project_Expenses_tbx.Text;
                phaseReview.ProjectDeliverables = Project_Deliverables_tbx.Text;
                phaseReview.ProjectRisks = Project_Risks_tbx.Text;
                phaseReview.ProjectIssues = Project_Issues_tbx.Text;
                phaseReview.ProjectChanges = Project_Changes_tbx.Text;
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
             
    }

        private void Enter_btn_Click(object sender, EventArgs e)
        {
            if (Planning_Phase_tbx.Text.Length > 0)
            {
                phaseReview.PlanningPhase = Planning_Phase_tbx.Text;
            }
        }
    }
}
