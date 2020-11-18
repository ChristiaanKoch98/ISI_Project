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
    public partial class RiskPlanDocumentForm : Form
    {
        RiskPlanModel riskPlanModel;
        public RiskPlanDocumentForm()
        {
            InitializeComponent();
            riskPlanModel = new RiskPlanModel();

            List<string[]> rows1 = new List<string[]>();
            rows1.Add(new string[] { "Document ID", "" });
            rows1.Add(new string[] { "Document Owner", "" });
            rows1.Add(new string[] { "Issue Date", "" });
            rows1.Add(new string[] { "Last Save Date", "" });
            rows1.Add(new string[] { "File Name", "" });
            foreach (var row in rows1) 
            {
                Document_Information_dgv.Rows.Add(row);
            }
            Document_Information_dgv.AllowUserToAddRows = false;

            List<string[]> rows2 = new List<string[]>();
            rows2.Add(new string[] { "Project Sponsor", "" });
            rows2.Add(new string[] { "Project Review Group", "" });
            rows2.Add(new string[] { "Project Manager", "" });
            rows2.Add(new string[] { "Quality Manager", "" });
            rows2.Add(new string[] { "Procument Manager", "" });
            rows2.Add(new string[] { "Communications Manager", "" });
            rows2.Add(new string[] { "Project Office Manager", "" }); 
            foreach (var row in rows2)
            {
                Document_Approvals_dgv.Rows.Add(row);
            }
            Document_Approvals_dgv.AllowUserToAddRows = false;
        }

        private void Enter_btn_Click(object sender, EventArgs e)
        {
            if (Project_Name_tbx.Text.Length > 0)
            {
                riskPlanModel.ProjectName = Project_Name_tbx.Text;
            }
        }

        private void Risk_Identification_btn_Click(object sender, EventArgs e)
        {
            if (Categories_tbx.Text.Length > 0)
            {
                riskPlanModel.Categories = Categories_tbx.Text;

                foreach (DataGridView row in Risks_dgv.Rows)
                {
                    foreach (var column in row.Columns)
                    {
                        riskPlanModel.Risks  += column;
                    }
                }
            }
        }

        private void Risk_Plan_btn_Click(object sender, EventArgs e)
        {
            if (Assumptions_tbx.Text.Length > 0 && Constraints_tbx.Text.Length > 0)
            {
                riskPlanModel.Assumptions = Assumptions_tbx.Text;
                riskPlanModel.Constraints = Constraints_tbx.Text;

                List<Schedule> schedules = new List<Schedule>();
                int SchedulerowCount = Schedule_dgv.RowCount;
                for (int i = 0; i < SchedulerowCount - 1; i++)
                {
                    Schedule schedule = new Schedule();
                    var Rating = Schedule_dgv.Rows[i].Cells[0].Value?.ToString() ?? "";
                    var ID = Schedule_dgv.Rows[i].Cells[1].Value?.ToString() ?? "";
                    var PrevalantiveActions = Schedule_dgv.Rows[i].Cells[2].Value?.ToString() ?? "";
                    var ActionResource1 = Schedule_dgv.Rows[i].Cells[3].Value?.ToString() ?? "";
                    var ActionDate1 = Schedule_dgv.Rows[i].Cells[4].Value?.ToString() ?? "";
                    var ContingentActions = Schedule_dgv.Rows[i].Cells[5].Value?.ToString() ?? "";
                    var ActionResource2 = Schedule_dgv.Rows[i].Cells[6].Value?.ToString() ?? "";
                    var ActionDate2 = Schedule_dgv.Rows[i].Cells[7].Value?.ToString() ?? "";

                    schedule.Rating = Rating;
                    schedule.ID = ID;
                    schedule.PrevalantiveActions = PrevalantiveActions;
                    schedule.ActionResource1 = ActionResource1;
                    schedule.ActionDate1 = ActionDate1;
                    schedule.ContingentActions = ContingentActions;
                    schedule.ActionResource2 = ActionResource2;
                    schedule.ActionDate2 = ActionDate2;

                    schedules.Add(schedule);
                }

                foreach (DataGridView row in Schedule_dgv.Rows)
                {
                    foreach (var column in row.Columns)
                    {
                        riskPlanModel.Schedule += column;
                    }
                }
            }
        }

        private void Risk_Process_btn_Click(object sender, EventArgs e)
        {
            if (Activities_tbx.Text.Length > 0 && Roles_tbx.Text.Length > 0 && Documents_tbx.Text.Length > 0)
            {
                riskPlanModel.Activities = Activities_tbx.Text;
                riskPlanModel.Roles = Roles_tbx.Text;
                riskPlanModel.Documents = Documents_tbx.Text;
            }
        }

        private void Appendix_btn_Click(object sender, EventArgs e)
        {
            if (Appendix_tbx.Text.Length > 0)
            {
                riskPlanModel.Appendix = Appendix_tbx.Text;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Likelihood> likelihoods = new List<Likelihood>();
            int LikelihoodrowCount = Likelihood_dgv.RowCount;
            for (int i = 0; i < LikelihoodrowCount - 1; i++)
            {
                Likelihood likelihood = new Likelihood();
                var Title = Likelihood_dgv.Rows[i].Cells[0].Value?.ToString() ?? "";
                var Score = Likelihood_dgv.Rows[i].Cells[1].Value?.ToString() ?? "";
                var Description = Likelihood_dgv.Rows[i].Cells[2].Value?.ToString() ?? "";
                likelihood.Title = Title;
                likelihood.Score = Score;
                likelihood.Description = Description;
                likelihoods.Add(likelihood); 
            }

            List<Impact> impacts = new List<Impact>(); 
            int impactrowCount = Impact_dgv.RowCount;
            for (int i = 0; i < impactrowCount - 1; i++)
            {
                Impact impact = new Impact();
                var Title = Impact_dgv.Rows[i].Cells[0].Value?.ToString() ?? "";
                var Score = Impact_dgv.Rows[i].Cells[1].Value?.ToString() ?? "";
                var Description = Impact_dgv.Rows[i].Cells[2].Value?.ToString() ?? "";
                impact.Title = Title;
                impact.Score = Score;
                impact.Description = Description;
                impacts.Add(impact);
            }

            List<Priority> priorities = new List<Priority>(); 
            int PriorityrowCount = Priority_dgv.RowCount;
            for (int i = 0; i < PriorityrowCount - 1; i++)
            {
                Priority priority = new Priority();
                var ID = Priority_dgv.Rows[i].Cells[0].Value?.ToString() ?? "";
                var LikelihoodScore = Priority_dgv.Rows[i].Cells[1].Value?.ToString() ?? "";
                var ImpactScore = Priority_dgv.Rows[i].Cells[2].Value?.ToString() ?? "";
                var PriorityScore = Priority_dgv.Rows[i].Cells[3].Value?.ToString() ?? "";
               

                priority.ID  = ID ;
                priority.LikelihoodScore = LikelihoodScore;
                priority.ImpactScore = ImpactScore;
                priority.PriorityScore = PriorityScore;
                
                priorities.Add(priority);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Information information = new Information();
            information.DocumentID = Document_Information_dgv.Rows[0].Cells[1].Value.ToString();
            information.DocumentOwner = Document_Information_dgv.Rows[1].Cells[1].Value.ToString();
            information.IssueDate = Document_Information_dgv.Rows[2].Cells[1].Value.ToString();
            information.LastSavedDate = Document_Information_dgv.Rows[3].Cells[1].Value.ToString();
            information.FileName = Document_Information_dgv.Rows[4].Cells[1].Value.ToString();

            List<History> histories = new List<History>();
            int Document_HistoryRowCount = Document_History_dgv.RowCount;
            for (int i = 0; i < Document_HistoryRowCount - 1; i++)
            {
                History history = new History();
                var Version = Document_History_dgv.Rows[i].Cells[0].Value?.ToString() ?? "";
                var IssueDate = Document_History_dgv.Rows[i].Cells[1].Value?.ToString() ?? "";
                var Changes = Document_History_dgv.Rows[i].Cells[2].Value?.ToString() ?? "";
                history.Version = Version;
                history.IssueDate = IssueDate;
                history.Changes = Changes;
                histories.Add(history);
            }

            Approvals approvals = new Approvals();
            approvals.ProjectSponsor = Document_Approvals_dgv.Rows[0].Cells[1].Value.ToString();
            approvals.ProjectReviewGroup = Document_Approvals_dgv.Rows[1].Cells[1].Value.ToString();
            approvals.ProjectManager = Document_Approvals_dgv.Rows[2].Cells[1].Value.ToString();
            approvals.QualityManager = Document_Approvals_dgv.Rows[3].Cells[1].Value.ToString();
            approvals.ProcumentManager = Document_Approvals_dgv.Rows[4].Cells[1].Value.ToString();
            approvals.CommunicationsManager = Document_Approvals_dgv.Rows[5].Cells[1].Value.ToString();
            approvals.ProjectOfficeManager = Document_Approvals_dgv.Rows[6].Cells[1].Value.ToString();
        }
    }
}
