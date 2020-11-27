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
    public partial class PostImplementationReviewDocumentForm : Form
    {

        VersionControl<PostImplementationReviewModel> versionControl;
        PostImplementationReviewModel newPostImplementationReviewModel;
        PostImplementationReviewModel currentPostImplementationReviewModel;

        Color TABLE_HEADER_COLOR = Color.FromArgb(73, 173, 252);
        ProjectModel projectModel = new ProjectModel();




        public void saveDocument()
        {
            newPostImplementationReviewModel.DocumentID = dataGridView1.Rows[0].Cells[1].Value.ToString();
            newPostImplementationReviewModel.DocumentOwner = dataGridView1.Rows[1].Cells[1].Value.ToString();
            newPostImplementationReviewModel.IssueDate = dataGridView1.Rows[2].Cells[1].Value.ToString();
            newPostImplementationReviewModel.LastSavedDate = dataGridView1.Rows[3].Cells[1].Value.ToString();
            newPostImplementationReviewModel.FileName = dataGridView1.Rows[4].Cells[1].Value.ToString();

            List<PostImplementationReviewModel.DocumentHistory> documentHistories = new List<PostImplementationReviewModel.DocumentHistory>();

            int versionRowsCount = dataGridView2.Rows.Count;

            for (int i = 0; i < versionRowsCount - 1; i++)
            {
                PostImplementationReviewModel.DocumentHistory documentHistoryModel = new PostImplementationReviewModel.DocumentHistory();
                var version = dataGridView2.Rows[i].Cells[0].Value?.ToString() ?? "";
                var issueDate = dataGridView2.Rows[i].Cells[1].Value?.ToString() ?? "";
                var changes = dataGridView2.Rows[i].Cells[2].Value?.ToString() ?? "";
                documentHistoryModel.Version = version;
                documentHistoryModel.IssueDate = issueDate;
                documentHistoryModel.Changes = changes;
                documentHistories.Add(documentHistoryModel);
            }
            newPostImplementationReviewModel.DocumentHistories = documentHistories;

            List<PostImplementationReviewModel.DocumentApproval> documentApprovalsModel = new List<PostImplementationReviewModel.DocumentApproval>();

            int approvalRowsCount = dataGridView3.Rows.Count;

            for (int i = 0; i < approvalRowsCount - 1; i++)
            {
                PostImplementationReviewModel.DocumentApproval documentApproval = new PostImplementationReviewModel.DocumentApproval();
                var role = dataGridView3.Rows[i].Cells[0].Value?.ToString() ?? "";
                var name = dataGridView3.Rows[i].Cells[1].Value?.ToString() ?? "";
                var signature = dataGridView3.Rows[i].Cells[2].Value?.ToString() ?? "";
                var date = dataGridView3.Rows[i].Cells[3].Value?.ToString() ?? "";
                documentApproval.Role = role;
                documentApproval.Name = name;
                documentApproval.Signature = signature;
                documentApproval.DateApproved = date;

                documentApprovalsModel.Add(documentApproval);
            }
            newPostImplementationReviewModel.DocumentApprovals = documentApprovalsModel;


            newPostImplementationReviewModel.ProjectName = txtProjectName.Text;

            newPostImplementationReviewModel.ExecutivesummaryDescription = txtexecutivesummaryDescription.Text;

            newPostImplementationReviewModel.ProjectperformanceDescription = txtprojectperformanceDescription.Text;



            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            List<PostImplementationReviewModel.Benefit> documentBenefitss = new List<PostImplementationReviewModel.Benefit>();

            versionRowsCount = dataGridView10.Rows.Count;

            for (int i = 0; i < versionRowsCount - 1; i++)
            {
                PostImplementationReviewModel.Benefit documentHistoryModel = new PostImplementationReviewModel.Benefit();
                var first_Row = dataGridView10.Rows[i].Cells[0].Value?.ToString() ?? "";
                var second_Row = dataGridView10.Rows[i].Cells[1].Value?.ToString() ?? "";
                var third_Row = dataGridView10.Rows[i].Cells[2].Value?.ToString() ?? "";
                var fourth_Row = dataGridView10.Rows[i].Cells[3].Value?.ToString() ?? "";
                documentHistoryModel.BenefitDesc = first_Row;
                documentHistoryModel.ForecastValue = second_Row;
                documentHistoryModel.ActualValue = third_Row;
                documentHistoryModel.Deviation = fourth_Row;
                documentBenefitss.Add(documentHistoryModel);
            }
            newPostImplementationReviewModel.Benefits = documentBenefitss;




            List<PostImplementationReviewModel.Objective> documentObjectives = new List<PostImplementationReviewModel.Objective>();

            versionRowsCount = dataGridView5.Rows.Count;

            for (int i = 0; i < versionRowsCount - 1; i++)
            {
                PostImplementationReviewModel.Objective documentHistoryModel = new PostImplementationReviewModel.Objective();
                var first_Row = dataGridView5.Rows[i].Cells[0].Value?.ToString() ?? "";
                var second_Row = dataGridView5.Rows[i].Cells[1].Value?.ToString() ?? "";
                var third_Row = dataGridView5.Rows[i].Cells[2].Value?.ToString() ?? "";
                documentHistoryModel.ObjectiveDesc = first_Row;
                documentHistoryModel.Achievement = second_Row;
                documentHistoryModel.Shortfall = third_Row;
                documentObjectives.Add(documentHistoryModel);
            }
            newPostImplementationReviewModel.Objectives = documentObjectives;




            List<PostImplementationReviewModel.Scope> documentScopes = new List<PostImplementationReviewModel.Scope>();

            versionRowsCount = dataGridView6.Rows.Count;

            for (int i = 0; i < versionRowsCount - 1; i++)
            {
                PostImplementationReviewModel.Scope documentHistoryModel = new PostImplementationReviewModel.Scope();
                var first_Row = dataGridView6.Rows[i].Cells[0].Value?.ToString() ?? "";
                var second_Row = dataGridView6.Rows[i].Cells[1].Value?.ToString() ?? "";
                var third_Row = dataGridView6.Rows[i].Cells[2].Value?.ToString() ?? "";
                documentHistoryModel.OriginalScope = first_Row;
                documentHistoryModel.ActualScope = second_Row;
                documentHistoryModel.Deviation = third_Row;
                documentScopes.Add(documentHistoryModel);
            }
            newPostImplementationReviewModel.Scopes = documentScopes;




            List<PostImplementationReviewModel.Delivarable> documentDelivarables = new List<PostImplementationReviewModel.Delivarable>();

            versionRowsCount = dataGridView7.Rows.Count;

            for (int i = 0; i < versionRowsCount - 1; i++)
            {
                PostImplementationReviewModel.Delivarable documentHistoryModel = new PostImplementationReviewModel.Delivarable();
                var first_Row = dataGridView7.Rows[i].Cells[0].Value?.ToString() ?? "";
                var second_Row = dataGridView7.Rows[i].Cells[1].Value?.ToString() ?? "";
                var third_Row = dataGridView7.Rows[i].Cells[2].Value?.ToString() ?? "";
                var fourth_Row = dataGridView7.Rows[i].Cells[3].Value?.ToString() ?? "";
                documentHistoryModel.DeliverableDesc = first_Row;
                documentHistoryModel.QualityCriteria = second_Row;
                documentHistoryModel.QualityStandards = third_Row;
                documentHistoryModel.Achievement = fourth_Row;
                documentDelivarables.Add(documentHistoryModel);
            }
            newPostImplementationReviewModel.Delivarables = documentDelivarables;




            newPostImplementationReviewModel.ProjectperformanceSchedule = txtprojectperformanceSchedule.Text;




            List<PostImplementationReviewModel.Expense> documentExpensess = new List<PostImplementationReviewModel.Expense>();

            versionRowsCount = dataGridView8.Rows.Count;

            for (int i = 0; i < versionRowsCount - 1; i++)
            {
                PostImplementationReviewModel.Expense documentHistoryModel = new PostImplementationReviewModel.Expense();
                var first_Row = dataGridView8.Rows[i].Cells[0].Value?.ToString() ?? "";
                var second_Row = dataGridView8.Rows[i].Cells[1].Value?.ToString() ?? "";
                var third_Row = dataGridView8.Rows[i].Cells[2].Value?.ToString() ?? "";
                var fourth_Row = dataGridView8.Rows[i].Cells[3].Value?.ToString() ?? "";
                documentHistoryModel.ExpenseTypes = first_Row;
                documentHistoryModel.ForecastExpenditure = second_Row;
                documentHistoryModel.ActualExpenditure = third_Row;
                documentHistoryModel.Deviation = fourth_Row;
                documentExpensess.Add(documentHistoryModel);
            }
            newPostImplementationReviewModel.Expenses = documentExpensess;




            List<PostImplementationReviewModel.Resource> documentResources = new List<PostImplementationReviewModel.Resource>();

            versionRowsCount = dataGridView4.Rows.Count;

            for (int i = 0; i < versionRowsCount - 1; i++)
            {
                PostImplementationReviewModel.Resource documentHistoryModel = new PostImplementationReviewModel.Resource();
                var first_Row = dataGridView4.Rows[i].Cells[0].Value?.ToString() ?? "";
                var second_Row = dataGridView4.Rows[i].Cells[1].Value?.ToString() ?? "";
                var third_Row = dataGridView4.Rows[i].Cells[2].Value?.ToString() ?? "";
                var fourth_Row = dataGridView4.Rows[i].Cells[3].Value?.ToString() ?? "";
                documentHistoryModel.ResourceTypes = first_Row;
                documentHistoryModel.ForecastResource = second_Row;
                documentHistoryModel.ActualResource = third_Row;
                documentHistoryModel.Deviation = fourth_Row;
                documentResources.Add(documentHistoryModel);
            }
            newPostImplementationReviewModel.Resources = documentResources;





            newPostImplementationReviewModel.ProjectComformanceDescription = txtprojectComformanceDescription.Text;

            newPostImplementationReviewModel.ProjectcomformanceTimeManagement = txtprojectcomformanceTimeManagement.Text;

            newPostImplementationReviewModel.ProjectcomformanceCostManagement = txtprojectcomformanceCostManagement.Text;

            newPostImplementationReviewModel.ProjectcomformanceQualitManagement = txtprojectcomformanceQualitManagement.Text;

            newPostImplementationReviewModel.ProjectcomformanceChangeManagement = txtprojectcomformanceChangeManagement.Text;

            newPostImplementationReviewModel.ProjectcomformanceRiskManagement = txtprojectcomformanceRiskManagement.Text;

            newPostImplementationReviewModel.ProjectcomformanceIssueManagement = txtprojectcomformanceIssueManagement.Text;

            newPostImplementationReviewModel.ProjectcomformanceProcurementManagement = txtprojectcomformanceProcurementManagement.Text;

            newPostImplementationReviewModel.ProjectcomformanceAcceptanceManagement = txtprojectcomformanceAcceptanceManagement.Text;

            newPostImplementationReviewModel.ProjectcomformanceCommunicationManagement = txtprojectcomformanceCommunicationManagement.Text;










            newPostImplementationReviewModel.ProjectachievementDescription = txtprojectachievementDescription.Text;



            List<PostImplementationReviewModel.ProjectAchievement> documentProjectAchievements = new List<PostImplementationReviewModel.ProjectAchievement>();

            versionRowsCount = dataGridView9.Rows.Count;

            for (int i = 0; i < versionRowsCount - 1; i++)
            {
                PostImplementationReviewModel.ProjectAchievement documentHistoryModel = new PostImplementationReviewModel.ProjectAchievement();
                var first_Row = dataGridView9.Rows[i].Cells[0].Value?.ToString() ?? "";
                var second_Row = dataGridView9.Rows[i].Cells[1].Value?.ToString() ?? "";
                documentHistoryModel.Achievement = first_Row;
                documentHistoryModel.EffectOnBusiness = second_Row;
                documentProjectAchievements.Add(documentHistoryModel);
            }
            newPostImplementationReviewModel.ProjectAchievements = documentProjectAchievements;







            newPostImplementationReviewModel.ProjectfailureDescription = txtprojectfailureDescription.Text;



            List<PostImplementationReviewModel.ProjectFailure> documentProjectFailures = new List<PostImplementationReviewModel.ProjectFailure>();

            versionRowsCount = dataGridView11.Rows.Count;

            for (int i = 0; i < versionRowsCount - 1; i++)
            {
                PostImplementationReviewModel.ProjectFailure documentHistoryModel = new PostImplementationReviewModel.ProjectFailure();
                var first_Row = dataGridView11.Rows[i].Cells[0].Value?.ToString() ?? "";
                var second_Row = dataGridView11.Rows[i].Cells[1].Value?.ToString() ?? "";
                documentHistoryModel.Failure = first_Row;
                documentHistoryModel.EffectOnBusiness = second_Row;
                documentProjectFailures.Add(documentHistoryModel);
            }
            newPostImplementationReviewModel.ProjectFailures = documentProjectFailures;







            newPostImplementationReviewModel.ProjectlessonslearneDescription = txtprojectlessonslearneDescription.Text;



            List<PostImplementationReviewModel.ProjectLessonsLearned> documentProjectLessonsLearneds = new List<PostImplementationReviewModel.ProjectLessonsLearned>();

            versionRowsCount = dataGridView12.Rows.Count;

            for (int i = 0; i < versionRowsCount - 1; i++)
            {
                PostImplementationReviewModel.ProjectLessonsLearned documentHistoryModel = new PostImplementationReviewModel.ProjectLessonsLearned();
                var first_Row = dataGridView12.Rows[i].Cells[0].Value?.ToString() ?? "";
                var second_Row = dataGridView12.Rows[i].Cells[1].Value?.ToString() ?? "";
                documentHistoryModel.Learning = first_Row;
                documentHistoryModel.Recommendation = second_Row;
                documentProjectLessonsLearneds.Add(documentHistoryModel);
            }
            newPostImplementationReviewModel.ProjectLessonsLearneds = documentProjectLessonsLearneds;





            newPostImplementationReviewModel.AppendixDescription = txtappendixDescription.Text;

            newPostImplementationReviewModel.AppendixSupportingDocumentation = txtappendixSupportingDocumentation.Text;


            List<VersionControl<PostImplementationReviewModel>.DocumentModel> documentModels = versionControl.DocumentModels;

            if (!versionControl.isEqual(currentPostImplementationReviewModel, newPostImplementationReviewModel))
            {
                VersionControl<PostImplementationReviewModel>.DocumentModel documentModel = new VersionControl<PostImplementationReviewModel>.DocumentModel(newPostImplementationReviewModel, DateTime.Now, VersionControl<ProjectModel>.generateID());

                documentModels.Add(documentModel);

                versionControl.DocumentModels = documentModels;

                string json = JsonConvert.SerializeObject(versionControl);
                JsonHelper.saveDocument(json, Settings.Default.ProjectID, "PostImplementationReview");
                MessageBox.Show("Post Implementation Review saved successfully", "save", MessageBoxButtons.OK);
            }
        }










        private void loadDocument()
        {
            string json = JsonHelper.loadDocument(Settings.Default.ProjectID, "PostImplementation");
            List<string[]> documentInfo = new List<string[]>();
            newPostImplementationReviewModel = new PostImplementationReviewModel();
            currentPostImplementationReviewModel = new PostImplementationReviewModel();
            if (json != "")
            {
                versionControl = JsonConvert.DeserializeObject<VersionControl<PostImplementationReviewModel>>(json);
                newPostImplementationReviewModel = JsonConvert.DeserializeObject<PostImplementationReviewModel>(versionControl.getLatest(versionControl.DocumentModels));
                currentPostImplementationReviewModel = JsonConvert.DeserializeObject<PostImplementationReviewModel>(versionControl.getLatest(versionControl.DocumentModels));

                documentInfo.Add(new string[] { "Document ID", currentPostImplementationReviewModel.DocumentID });
                documentInfo.Add(new string[] { "Document Owner", currentPostImplementationReviewModel.DocumentOwner });
                documentInfo.Add(new string[] { "Issue Date", currentPostImplementationReviewModel.IssueDate });
                documentInfo.Add(new string[] { "Last Save Date", currentPostImplementationReviewModel.LastSavedDate });
                documentInfo.Add(new string[] { "File Name", currentPostImplementationReviewModel.FileName });

                foreach (var row in documentInfo)
                {
                    dataGridView1.Rows.Add(row);
                }
                dataGridView1.AllowUserToAddRows = false;

                foreach (var row in currentPostImplementationReviewModel.DocumentHistories)
                {
                    dataGridView2.Rows.Add(new string[] { row.Version, row.IssueDate, row.Changes });
                }

                foreach (var row in currentPostImplementationReviewModel.DocumentApprovals)
                {
                    dataGridView3.Rows.Add(new string[] { row.Role, row.Name, "", row.DateApproved });
                }




                foreach (var row in currentPostImplementationReviewModel.Benefits)
                {
                    dataGridView10.Rows.Add(new string[] { row.BenefitDesc, row.ForecastValue, row.ActualValue, row.Deviation });
                }

                foreach (var row in currentPostImplementationReviewModel.Objectives)
                {
                    dataGridView5.Rows.Add(new string[] { row.ObjectiveDesc, row.Achievement, row.Shortfall });
                }

                foreach (var row in currentPostImplementationReviewModel.Scopes)
                {
                    dataGridView6.Rows.Add(new string[] { row.OriginalScope, row.ActualScope, row.Deviation });
                }

                foreach (var row in currentPostImplementationReviewModel.Delivarables)
                {
                    dataGridView7.Rows.Add(new string[] { row.DeliverableDesc, row.QualityCriteria, row.QualityStandards, row.Achievement });
                }

                foreach (var row in currentPostImplementationReviewModel.Expenses)
                {
                    dataGridView8.Rows.Add(new string[] { row.ExpenseTypes, row.ForecastExpenditure, row.ActualExpenditure, row.Deviation });
                }

                foreach (var row in currentPostImplementationReviewModel.Resources)
                {
                    dataGridView4.Rows.Add(new string[] { row.ResourceTypes, row.ForecastResource, row.ActualResource, row.Deviation });
                }

                foreach (var row in currentPostImplementationReviewModel.ProjectAchievements)
                {
                    dataGridView9.Rows.Add(new string[] { row.Achievement, row.EffectOnBusiness });
                }

                foreach (var row in currentPostImplementationReviewModel.ProjectFailures)
                {
                    dataGridView11.Rows.Add(new string[] { row.Failure, row.EffectOnBusiness });
                }

                foreach (var row in currentPostImplementationReviewModel.ProjectLessonsLearneds)
                {
                    dataGridView12.Rows.Add(new string[] { row.Learning, row.Recommendation });
                }




                txtProjectName.Text = newPostImplementationReviewModel.ProjectName  ;

                txtexecutivesummaryDescription.Text = newPostImplementationReviewModel.ExecutivesummaryDescription  ;

                txtprojectperformanceDescription.Text = newPostImplementationReviewModel.ProjectperformanceDescription  ;

                txtprojectperformanceSchedule.Text = newPostImplementationReviewModel.ProjectperformanceSchedule  ;

                txtprojectComformanceDescription.Text = newPostImplementationReviewModel.ProjectComformanceDescription  ;

                txtprojectcomformanceTimeManagement.Text = newPostImplementationReviewModel.ProjectcomformanceTimeManagement  ;

                txtprojectcomformanceCostManagement.Text = newPostImplementationReviewModel.ProjectcomformanceCostManagement  ;

                txtprojectcomformanceQualitManagement.Text = newPostImplementationReviewModel.ProjectcomformanceQualitManagement  ;

                txtprojectcomformanceChangeManagement.Text = newPostImplementationReviewModel.ProjectcomformanceChangeManagement  ;

                txtprojectcomformanceRiskManagement.Text = newPostImplementationReviewModel.ProjectcomformanceRiskManagement  ;

                txtprojectcomformanceIssueManagement.Text = newPostImplementationReviewModel.ProjectcomformanceIssueManagement  ;

                txtprojectcomformanceProcurementManagement.Text = newPostImplementationReviewModel.ProjectcomformanceProcurementManagement  ;

                txtprojectcomformanceAcceptanceManagement.Text = newPostImplementationReviewModel.ProjectcomformanceAcceptanceManagement  ;

                txtprojectcomformanceCommunicationManagement.Text = newPostImplementationReviewModel.ProjectcomformanceCommunicationManagement  ;

                txtprojectachievementDescription.Text = newPostImplementationReviewModel.ProjectachievementDescription  ;

                txtprojectfailureDescription.Text = newPostImplementationReviewModel.ProjectfailureDescription  ;

                txtprojectlessonslearneDescription.Text = newPostImplementationReviewModel.ProjectlessonslearneDescription  ;

                txtappendixDescription.Text = newPostImplementationReviewModel.AppendixDescription  ;

                txtappendixSupportingDocumentation.Text = newPostImplementationReviewModel.AppendixSupportingDocumentation  ;

            }
            else
            {
                versionControl = new VersionControl<PostImplementationReviewModel>();
                versionControl.DocumentModels = new List<VersionControl<PostImplementationReviewModel>.DocumentModel>();
                documentInfo.Add(new string[] { "Document ID", "" });
                documentInfo.Add(new string[] { "Document Owner", "" });
                documentInfo.Add(new string[] { "Issue Date", "" });
                documentInfo.Add(new string[] { "Last Save Date", "" });
                documentInfo.Add(new string[] { "File Name", "" });
                newPostImplementationReviewModel = new PostImplementationReviewModel();
                foreach (var row in documentInfo)
                {
                    dataGridView1.Rows.Add(row);
                }
                dataGridView1.AllowUserToAddRows = false;
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








        public PostImplementationReviewDocumentForm()
        {
            InitializeComponent();
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView11_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveDocument();
        }

        private void PostImplementationReviewDocumentForm_Load(object sender, EventArgs e)
        {
            loadDocument();
            string json = JsonHelper.loadProjectInfo(Settings.Default.Username);
            List<ProjectModel> projectListModel = JsonConvert.DeserializeObject<List<ProjectModel>>(json);
            projectModel = projectModel.getProjectModel(Settings.Default.ProjectID, projectListModel);
        }

        private void btnExportWord_Click(object sender, EventArgs e)
        {
            exportToWord();
        }
    }
}
