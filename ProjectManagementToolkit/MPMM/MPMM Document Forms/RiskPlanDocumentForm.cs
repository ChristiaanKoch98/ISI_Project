using ProjectManagementToolkit.Classes;
using ProjectManagementToolkit.Properties;
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

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Forms
{
    public partial class RiskPlanDocumentForm : Form
    {
        VersionControl<RiskPlanModel> versionControl;
        RiskPlanModel newRiskPlanModel;
        RiskPlanModel currentRiskPlanModel;

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

            loadDocument();
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
                newRiskPlanModel.Schedule = schedules;
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
            newRiskPlanModel.impact = impacts;

            List<Priority> priorities = new List<Priority>();
            int PriorityrowCount = Priority_dgv.RowCount;
            for (int i = 0; i < PriorityrowCount - 1; i++)
            {
                Priority priority = new Priority();
                var ID = Priority_dgv.Rows[i].Cells[0].Value?.ToString() ?? "";
                var LikelihoodScore = Priority_dgv.Rows[i].Cells[1].Value?.ToString() ?? "";
                var ImpactScore = Priority_dgv.Rows[i].Cells[2].Value?.ToString() ?? "";
                var PriorityScore = Priority_dgv.Rows[i].Cells[3].Value?.ToString() ?? "";


                priority.ID = ID;
                priority.LikelihoodScore = LikelihoodScore;
                priority.ImpactScore = ImpactScore;
                priority.PriorityScore = PriorityScore;

                priorities.Add(priority);
            }
            newRiskPlanModel.Priority = priorities;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<Information> informations = new List<Information>();
            int Document_infoRowCount = Document_Information_dgv.RowCount;
            for (int i = 0; i < Document_infoRowCount - 1; i++)
            {

                Information information = new Information();
                var DocumentID = Document_Information_dgv.Rows[i].Cells[0].Value.ToString();
                var DocumentOwner = Document_Information_dgv.Rows[i].Cells[1].Value.ToString();
                var IssueDate = Document_Information_dgv.Rows[i].Cells[2].Value.ToString();
                var LastSavedDate = Document_Information_dgv.Rows[i].Cells[3].Value.ToString();
                var FileName = Document_Information_dgv.Rows[i].Cells[4].Value.ToString();

                information.DocumentID = DocumentID;
                information.DocumentOwner = DocumentOwner;
                information.IssueDate = IssueDate;
                information.LastSavedDate = LastSavedDate;
                information.FileName = FileName;
                informations.Add(information);
            }
            newRiskPlanModel.Information = informations;


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
            newRiskPlanModel.History = histories;

            List<Approvals> approvals = new List<Approvals>();
            int approvalCount = Document_Approvals_dgv.RowCount;
            for (int i = 0; i < Document_HistoryRowCount - 1; i++)
            {
                Approvals approval = new Approvals();
                var ProjectSponsor = Document_History_dgv.Rows[i].Cells[0].Value?.ToString() ?? "";
                var ProjectReviewGroup = Document_History_dgv.Rows[i].Cells[1].Value?.ToString() ?? "";
                var ProjectManager = Document_History_dgv.Rows[i].Cells[2].Value?.ToString() ?? "";
                var QualityManager = Document_History_dgv.Rows[i].Cells[3].Value?.ToString() ?? "";
                var ProcumentManager = Document_History_dgv.Rows[i].Cells[4].Value?.ToString() ?? "";
                var CommunicationsManager = Document_History_dgv.Rows[i].Cells[5].Value?.ToString() ?? "";
                var ProjectOfficeManager = Document_History_dgv.Rows[i].Cells[6].Value?.ToString() ?? "";

                approval.ProjectSponsor = ProjectSponsor;
                approval.ProjectReviewGroup = ProjectReviewGroup;
                approval.ProjectManager = ProjectManager;
                approval.QualityManager = QualityManager;
                approval.ProcumentManager = ProcumentManager;
                approval.CommunicationsManager = CommunicationsManager;
                approval.ProjectOfficeManager = ProjectOfficeManager;
            }
            newRiskPlanModel.approvals = approvals;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveDocument();
        }

        private void saveDocument()
        {
            List<VersionControl<RiskPlanModel>.DocumentModel> documentModels = versionControl.DocumentModels;


            if (!versionControl.isEqual(currentRiskPlanModel, newRiskPlanModel))
            {
                VersionControl<RiskPlanModel>.DocumentModel documentModel = new VersionControl<RiskPlanModel>.DocumentModel(newRiskPlanModel, DateTime.Now, VersionControl<RiskPlanModel>.generateID());

                documentModels.Add(documentModel);

                versionControl.DocumentModels = documentModels;

                string json = JsonConvert.SerializeObject(versionControl);
                JsonHelper.saveDocument(json, Settings.Default.ProjectID, "ProjectPlan");
                MessageBox.Show("Project plan saved successfully", "save", MessageBoxButtons.OK);
            }
        }

        private void loadDocument()
        {

            string json = JsonHelper.loadDocument(Settings.Default.ProjectID, "ProjectPlan");
            List<string[]> documentInfo = new List<string[]>();
            newRiskPlanModel = new RiskPlanModel();
            currentRiskPlanModel = new RiskPlanModel();
            if (json != "")
            {
                versionControl = JsonConvert.DeserializeObject<VersionControl<RiskPlanModel>>(json);
                newRiskPlanModel = JsonConvert.DeserializeObject<RiskPlanModel>(versionControl.getLatest(versionControl.DocumentModels));
                currentRiskPlanModel = JsonConvert.DeserializeObject<RiskPlanModel>(versionControl.getLatest(versionControl.DocumentModels));

                documentInfo.Add(new string[] { "Document ID", currentRiskPlanModel.Info.DocumentID });
                documentInfo.Add(new string[] { "Document Owner", currentRiskPlanModel.Info.DocumentOwner });
                documentInfo.Add(new string[] { "Issue Date", currentRiskPlanModel.Info.IssueDate });
                documentInfo.Add(new string[] { "Last Save Date", currentRiskPlanModel.Info.LastSavedDate });
                documentInfo.Add(new string[] { "File Name", currentRiskPlanModel.Info.FileName });

                foreach (var row in documentInfo)
                {
                    Document_Information_dgv.Rows.Add(row);
                }
                Document_Information_dgv.AllowUserToAddRows = false;

                foreach (var row in currentRiskPlanModel.History)
                {
                    Document_History_dgv.Rows.Add(new string[] { row.Version, row.IssueDate, row.Changes });
                }

                foreach (var row in currentRiskPlanModel.approvals)
                {
                    Document_Approvals_dgv.Rows.Add(new string[] { row.ProjectSponsor, row.ProjectReviewGroup, row.ProjectManager, row.QualityManager, row.ProcumentManager, row.CommunicationsManager, row.ProjectOfficeManager });
                }

                foreach (var row in currentRiskPlanModel.Risks)
                {
                    Risks_dgv.Rows.Add(new string[] { row.RiskCategory, row.RiskDescription, "", row.ID });
                }

                foreach (var row in currentRiskPlanModel.likelihood)
                {
                    Likelihood_dgv.Rows.Add(new string[] { row.Title, row.Description, row.Score });
                }

                foreach (var row in currentRiskPlanModel.Priority)
                {
                    Priority_dgv.Rows.Add(new string[] { row.ID, row.LikelihoodScore, row.ImpactScore, row.PriorityScore });
                }

                foreach (var row in currentRiskPlanModel.impact)
                {
                    Impact_dgv.Rows.Add(new string[] { row.Title, row.Score, row.Description });
                }

                foreach (var row in currentRiskPlanModel.Schedule)
                {
                    Schedule_dgv.Rows.Add(new string[] { row.Rating, row.ID, row.PrevalantiveActions, row.ActionResource1, row.ActionDate1, row.ContingentActions, row.ActionResource2, row.ActionDate2 });
                }

                Project_Name_tbx.Text = currentRiskPlanModel.ProjectName;
                Categories_tbx.Text = currentRiskPlanModel.Categories;
                Constraints_tbx.Text = currentRiskPlanModel.Constraints;
                Assumptions_tbx.Text = currentRiskPlanModel.Constraints;
                Roles_tbx.Text = currentRiskPlanModel.Roles;
                Activities_tbx.Text = currentRiskPlanModel.Activities;
                Documents_tbx.Text = currentRiskPlanModel.Documents;
                Appendix_tbx.Text = currentRiskPlanModel.Appendix;

            }
        }
    }
}
