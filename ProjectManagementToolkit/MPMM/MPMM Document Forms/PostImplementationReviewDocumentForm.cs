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
            string json = JsonHelper.loadDocument(Settings.Default.ProjectID, "PostImplementationReview");
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
                        document.InsertParagraph("Post Implementation Review \nFor " + projectModel.ProjectName)
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(22d).Alignment = Alignment.left;
                        document.InsertSectionPageBreak();
                        //Code for the Front page


                        //Code for the title of a page
                        document.InsertParagraph("Document Control\n")
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(14d).Alignment = Alignment.left;
                        //Code for the title of a page


                        //Code for a space
                        document.InsertParagraph("")
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(14d).Alignment = Alignment.left;
                        //Code for a space


                        //Code of a sentence
                        document.InsertParagraph("Document Information\n")
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(14d).Alignment = Alignment.left;
                        //Code of a sentence


                        //Code for a table
                        var documentInfoTable = document.AddTable(6, 2);
                        documentInfoTable.Rows[0].Cells[0].Paragraphs[0].Append("").Bold(true).Color(Color.White);
                        documentInfoTable.Rows[0].Cells[1].Paragraphs[0].Append("Information").Bold(true).Color(Color.White);
                        documentInfoTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        documentInfoTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;

                        documentInfoTable.Rows[1].Cells[0].Paragraphs[0].Append("Document ID");
                        documentInfoTable.Rows[1].Cells[1].Paragraphs[0].Append(currentPostImplementationReviewModel.DocumentID);

                        documentInfoTable.Rows[2].Cells[0].Paragraphs[0].Append("Document Owner");
                        documentInfoTable.Rows[2].Cells[1].Paragraphs[0].Append(currentPostImplementationReviewModel.DocumentOwner);

                        documentInfoTable.Rows[3].Cells[0].Paragraphs[0].Append("Issue Date");
                        documentInfoTable.Rows[3].Cells[1].Paragraphs[0].Append(currentPostImplementationReviewModel.IssueDate);

                        documentInfoTable.Rows[4].Cells[0].Paragraphs[0].Append("Last Saved Date");
                        documentInfoTable.Rows[4].Cells[1].Paragraphs[0].Append(currentPostImplementationReviewModel.LastSavedDate);

                        documentInfoTable.Rows[5].Cells[0].Paragraphs[0].Append("File Name");
                        documentInfoTable.Rows[5].Cells[1].Paragraphs[0].Append(currentPostImplementationReviewModel.FileName);
                        documentInfoTable.SetWidths(new float[] { 493, 1094 });
                        document.InsertTable(documentInfoTable);
                        //Code for a table


                        //Code of a sentence
                        document.InsertParagraph("\nDocument History\n")
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(14d).Alignment = Alignment.left;
                        //Code of a sentence


                        //Code for a table
                        var documentHistoryTable = document.AddTable(currentPostImplementationReviewModel.DocumentHistories.Count + 1, 3);
                        documentHistoryTable.Rows[0].Cells[0].Paragraphs[0].Append("Version")
                            .Bold(true)
                            .Color(Color.White);
                        documentHistoryTable.Rows[0].Cells[1].Paragraphs[0].Append("Issue Date")
                            .Bold(true)
                            .Color(Color.White);
                        documentHistoryTable.Rows[0].Cells[2].Paragraphs[0].Append("Changes")
                            .Bold(true)
                            .Color(Color.White);
                        documentHistoryTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        documentHistoryTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        documentHistoryTable.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;
                        for (int i = 1; i < currentPostImplementationReviewModel.DocumentHistories.Count + 1; i++)
                        {
                            documentHistoryTable.Rows[i].Cells[0].Paragraphs[0].Append(currentPostImplementationReviewModel.DocumentHistories[i - 1].Version);
                            documentHistoryTable.Rows[i].Cells[1].Paragraphs[0].Append(currentPostImplementationReviewModel.DocumentHistories[i - 1].IssueDate);
                            documentHistoryTable.Rows[i].Cells[2].Paragraphs[0].Append(currentPostImplementationReviewModel.DocumentHistories[i - 1].Changes);

                        }

                        documentHistoryTable.SetWidths(new float[] { 190, 303, 1094 });
                        document.InsertTable(documentHistoryTable);
                        //Code for a table


                        //Code of a sentence
                        document.InsertParagraph("\nDocument Approvals\n")
                           .Font("Arial")
                           .Bold(true)
                           .FontSize(14d).Alignment = Alignment.left;
                        //Code of a sentence


                        //Code for a table
                        var documentApprovalTable = document.AddTable(currentPostImplementationReviewModel.DocumentApprovals.Count + 1, 4);
                        documentApprovalTable.Rows[0].Cells[0].Paragraphs[0].Append("Role")
                            .Bold(true)
                            .Color(Color.White);
                        documentApprovalTable.Rows[0].Cells[1].Paragraphs[0].Append("Name")
                            .Bold(true)
                            .Color(Color.White);
                        documentApprovalTable.Rows[0].Cells[2].Paragraphs[0].Append("Signature")
                            .Bold(true)
                            .Color(Color.White);
                        documentApprovalTable.Rows[0].Cells[3].Paragraphs[0].Append("Date")
                            .Bold(true)
                            .Color(Color.White);
                        documentApprovalTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        documentApprovalTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        documentApprovalTable.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;
                        documentApprovalTable.Rows[0].Cells[3].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < currentPostImplementationReviewModel.DocumentApprovals.Count + 1; i++)
                        {
                            documentApprovalTable.Rows[i].Cells[0].Paragraphs[0].Append(currentPostImplementationReviewModel.DocumentApprovals[i - 1].Role);
                            documentApprovalTable.Rows[i].Cells[1].Paragraphs[0].Append(currentPostImplementationReviewModel.DocumentApprovals[i - 1].Name);
                            documentApprovalTable.Rows[i].Cells[2].Paragraphs[0].Append(currentPostImplementationReviewModel.DocumentApprovals[i - 1].Signature);
                            documentApprovalTable.Rows[i].Cells[3].Paragraphs[0].Append(currentPostImplementationReviewModel.DocumentApprovals[i - 1].DateApproved);
                        }
                        documentApprovalTable.SetWidths(new float[] { 493, 332, 508, 254 });
                        document.InsertTable(documentApprovalTable);
                        //Code for a table


                        //Code for a page break
                        document.InsertParagraph().InsertPageBreakAfterSelf();
                        //Code for a page break


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
                        var ExecutiveSummaryHeading = document.InsertParagraph("1 Executive Summary")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        ExecutiveSummaryHeading.StyleId = "Heading1";
                        //Code for a heading 1


                        //Code for a sentence
                        document.InsertParagraph(currentPostImplementationReviewModel.ExecutivesummaryDescription)
                               .FontSize(11d)
                               .Color(Color.Black)
                               .Font("Arial").Alignment = Alignment.left;
                        //Code for a sentence


                        //Code for a heading 1
                        var ProjectPerformanceHeading = document.InsertParagraph("2 Project Performance")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        ProjectPerformanceHeading.StyleId = "Heading1";
                        //Code for a heading 1


                        //Code for a heading 2
                        var BenefitsHeading = document.InsertParagraph("2.1 Benefits")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        BenefitsHeading.StyleId = "Heading2";
                        //Code for a heading 2


                        //Code for a table
                        var documentBenefitsTable = document.AddTable(currentPostImplementationReviewModel.Benefits.Count + 1, 4);
                        documentBenefitsTable.Rows[0].Cells[0].Paragraphs[0].Append("Benefit")
                            .Bold(true)
                            .Color(Color.White);
                        documentBenefitsTable.Rows[0].Cells[1].Paragraphs[0].Append("Forecast Value")
                            .Bold(true)
                            .Color(Color.White);
                        documentBenefitsTable.Rows[0].Cells[2].Paragraphs[0].Append("Actual Value")
                            .Bold(true)
                            .Color(Color.White);
                        documentBenefitsTable.Rows[0].Cells[3].Paragraphs[0].Append("Deviation")
                            .Bold(true)
                            .Color(Color.White);

                        documentBenefitsTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        documentBenefitsTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        documentBenefitsTable.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;
                        documentBenefitsTable.Rows[0].Cells[3].FillColor = TABLE_HEADER_COLOR;


                        for (int i = 1; i < currentPostImplementationReviewModel.Benefits.Count + 1; i++)
                        {
                            documentBenefitsTable.Rows[i].Cells[0].Paragraphs[0].Append(currentPostImplementationReviewModel.Benefits[i - 1].BenefitDesc);
                            documentBenefitsTable.Rows[i].Cells[1].Paragraphs[0].Append(currentPostImplementationReviewModel.Benefits[i - 1].ForecastValue);
                            documentBenefitsTable.Rows[i].Cells[2].Paragraphs[0].Append(currentPostImplementationReviewModel.Benefits[i - 1].ActualValue);
                            documentBenefitsTable.Rows[i].Cells[3].Paragraphs[0].Append(currentPostImplementationReviewModel.Benefits[i - 1].Deviation);
                        }

                        documentBenefitsTable.SetWidths(new float[] { 493, 332, 508, 254 });
                        document.InsertTable(documentBenefitsTable);
                        //Code for a table





                        //Code for a heading 2
                        var ObjectivesHeading = document.InsertParagraph("2.2 Objectives")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        ObjectivesHeading.StyleId = "Heading2";
                        //Code for a heading 2


                        //Code for a table
                        var documentObjectivesTable = document.AddTable(currentPostImplementationReviewModel.Objectives.Count + 1, 3);
                        documentObjectivesTable.Rows[0].Cells[0].Paragraphs[0].Append("Objective")
                            .Bold(true)
                            .Color(Color.White);
                        documentObjectivesTable.Rows[0].Cells[1].Paragraphs[0].Append("Achievement")
                            .Bold(true)
                            .Color(Color.White);
                        documentObjectivesTable.Rows[0].Cells[2].Paragraphs[0].Append("Shortfall")
                            .Bold(true)
                            .Color(Color.White);

                        documentObjectivesTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        documentObjectivesTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        documentObjectivesTable.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;


                        for (int i = 1; i < currentPostImplementationReviewModel.Objectives.Count + 1; i++)
                        {
                            documentObjectivesTable.Rows[i].Cells[0].Paragraphs[0].Append(currentPostImplementationReviewModel.Objectives[i - 1].ObjectiveDesc);
                            documentObjectivesTable.Rows[i].Cells[1].Paragraphs[0].Append(currentPostImplementationReviewModel.Objectives[i - 1].Achievement);
                            documentObjectivesTable.Rows[i].Cells[2].Paragraphs[0].Append(currentPostImplementationReviewModel.Objectives[i - 1].Shortfall);
                        }

                        documentObjectivesTable.SetWidths(new float[] { 394, 762, 419});
                        document.InsertTable(documentObjectivesTable);
                        //Code for a table




                        //Code for a heading 2
                        var ScopeHeading = document.InsertParagraph("2.3 Scope")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        ScopeHeading.StyleId = "Heading2";
                        //Code for a heading 2


                        //Code for a table
                        var documentScopeTable = document.AddTable(currentPostImplementationReviewModel.Scopes.Count + 1, 3);
                        documentScopeTable.Rows[0].Cells[0].Paragraphs[0].Append("Original Scope")
                            .Bold(true)
                            .Color(Color.White);
                        documentScopeTable.Rows[0].Cells[1].Paragraphs[0].Append("Actual Scope")
                            .Bold(true)
                            .Color(Color.White);
                        documentScopeTable.Rows[0].Cells[2].Paragraphs[0].Append("Deviation")
                            .Bold(true)
                            .Color(Color.White);

                        documentScopeTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        documentScopeTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        documentScopeTable.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;


                        for (int i = 1; i < currentPostImplementationReviewModel.Scopes.Count + 1; i++)
                        {
                            documentScopeTable.Rows[i].Cells[0].Paragraphs[0].Append(currentPostImplementationReviewModel.Scopes[i - 1].OriginalScope);
                            documentScopeTable.Rows[i].Cells[1].Paragraphs[0].Append(currentPostImplementationReviewModel.Scopes[i - 1].ActualScope);
                            documentScopeTable.Rows[i].Cells[2].Paragraphs[0].Append(currentPostImplementationReviewModel.Scopes[i - 1].Deviation);
                        }

                        documentScopeTable.SetWidths(new float[] { 394, 762, 419 });
                        document.InsertTable(documentScopeTable);
                        //Code for a table




                        //Code for a heading 2
                        var DeliverablesHeading = document.InsertParagraph("2.4 Deliverables")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        DeliverablesHeading.StyleId = "Heading2";
                        //Code for a heading 2


                        //Code for a table
                        var documentDeliverablesTable = document.AddTable(currentPostImplementationReviewModel.Delivarables.Count + 1, 4);
                        documentDeliverablesTable.Rows[0].Cells[0].Paragraphs[0].Append("Deliverable")
                            .Bold(true)
                            .Color(Color.White);
                        documentDeliverablesTable.Rows[0].Cells[1].Paragraphs[0].Append("Quality Criteria")
                            .Bold(true)
                            .Color(Color.White);
                        documentDeliverablesTable.Rows[0].Cells[2].Paragraphs[0].Append("Quality Standards")
                            .Bold(true)
                            .Color(Color.White);
                        documentDeliverablesTable.Rows[0].Cells[3].Paragraphs[0].Append("% Achievement")
                            .Bold(true)
                            .Color(Color.White);

                        documentDeliverablesTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        documentDeliverablesTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        documentDeliverablesTable.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;
                        documentDeliverablesTable.Rows[0].Cells[3].FillColor = TABLE_HEADER_COLOR;


                        for (int i = 1; i < currentPostImplementationReviewModel.Delivarables.Count + 1; i++)
                        {
                            documentDeliverablesTable.Rows[i].Cells[0].Paragraphs[0].Append(currentPostImplementationReviewModel.Delivarables[i - 1].DeliverableDesc);
                            documentDeliverablesTable.Rows[i].Cells[1].Paragraphs[0].Append(currentPostImplementationReviewModel.Delivarables[i - 1].QualityCriteria);
                            documentDeliverablesTable.Rows[i].Cells[2].Paragraphs[0].Append(currentPostImplementationReviewModel.Delivarables[i - 1].QualityStandards);
                            documentDeliverablesTable.Rows[i].Cells[3].Paragraphs[0].Append(currentPostImplementationReviewModel.Delivarables[i - 1].Achievement);
                        }

                        documentDeliverablesTable.SetWidths(new float[] { 493, 332, 508, 254 });
                        document.InsertTable(documentDeliverablesTable);
                        //Code for a table





                        //Code for a heading 2
                        var ScheduleHeading = document.InsertParagraph("2.5 Schedule")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        ScheduleHeading.StyleId = "Heading2";
                        //Code for a heading 2
                        //Code for a sentence
                        document.InsertParagraph(currentPostImplementationReviewModel.ProjectperformanceSchedule)
                               .FontSize(11d)
                               .Color(Color.Black)
                               .Font("Arial").Alignment = Alignment.left;
                        //Code for a sentence




                        //Code for a heading 2
                        var ExpensesHeading = document.InsertParagraph("2.6 Expenses")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        ExpensesHeading.StyleId = "Heading2";
                        //Code for a heading 2


                        //Code for a table
                        var documentExpensesTable = document.AddTable(currentPostImplementationReviewModel.Expenses.Count + 1, 4);
                        documentExpensesTable.Rows[0].Cells[0].Paragraphs[0].Append("Expense Types")
                            .Bold(true)
                            .Color(Color.White);
                        documentExpensesTable.Rows[0].Cells[1].Paragraphs[0].Append("Forecast Expenditure")
                            .Bold(true)
                            .Color(Color.White);
                        documentExpensesTable.Rows[0].Cells[2].Paragraphs[0].Append("Actual Expenditure")
                            .Bold(true)
                            .Color(Color.White);
                        documentExpensesTable.Rows[0].Cells[3].Paragraphs[0].Append("Deviation")
                            .Bold(true)
                            .Color(Color.White);

                        documentExpensesTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        documentExpensesTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        documentExpensesTable.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;
                        documentExpensesTable.Rows[0].Cells[3].FillColor = TABLE_HEADER_COLOR;


                        for (int i = 1; i < currentPostImplementationReviewModel.Expenses.Count + 1; i++)
                        {
                            documentExpensesTable.Rows[i].Cells[0].Paragraphs[0].Append(currentPostImplementationReviewModel.Expenses[i - 1].ExpenseTypes);
                            documentExpensesTable.Rows[i].Cells[1].Paragraphs[0].Append(currentPostImplementationReviewModel.Expenses[i - 1].ForecastExpenditure);
                            documentExpensesTable.Rows[i].Cells[2].Paragraphs[0].Append(currentPostImplementationReviewModel.Expenses[i - 1].ActualExpenditure);
                            documentExpensesTable.Rows[i].Cells[3].Paragraphs[0].Append(currentPostImplementationReviewModel.Expenses[i - 1].Deviation);
                        }

                        documentExpensesTable.SetWidths(new float[] { 493, 332, 508, 254 });
                        document.InsertTable(documentExpensesTable);
                        //Code for a table




                        //Code for a heading 2
                        var ResourcesHeading = document.InsertParagraph("2.7 Resources")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        ResourcesHeading.StyleId = "Heading2";
                        //Code for a heading 2


                        //Code for a table
                        var documentResourcesTable = document.AddTable(currentPostImplementationReviewModel.Resources.Count + 1, 4);
                        documentResourcesTable.Rows[0].Cells[0].Paragraphs[0].Append("Resource Types")
                            .Bold(true)
                            .Color(Color.White);
                        documentResourcesTable.Rows[0].Cells[1].Paragraphs[0].Append("Forecast Resource")
                            .Bold(true)
                            .Color(Color.White);
                        documentResourcesTable.Rows[0].Cells[2].Paragraphs[0].Append("Actual Resource")
                            .Bold(true)
                            .Color(Color.White);
                        documentResourcesTable.Rows[0].Cells[3].Paragraphs[0].Append("Deviation")
                            .Bold(true)
                            .Color(Color.White);

                        documentResourcesTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        documentResourcesTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        documentResourcesTable.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;
                        documentResourcesTable.Rows[0].Cells[3].FillColor = TABLE_HEADER_COLOR;


                        for (int i = 1; i < currentPostImplementationReviewModel.Resources.Count + 1; i++)
                        {
                            documentResourcesTable.Rows[i].Cells[0].Paragraphs[0].Append(currentPostImplementationReviewModel.Resources[i - 1].ResourceTypes);
                            documentResourcesTable.Rows[i].Cells[1].Paragraphs[0].Append(currentPostImplementationReviewModel.Resources[i - 1].ForecastResource);
                            documentResourcesTable.Rows[i].Cells[2].Paragraphs[0].Append(currentPostImplementationReviewModel.Resources[i - 1].ActualResource);
                            documentResourcesTable.Rows[i].Cells[3].Paragraphs[0].Append(currentPostImplementationReviewModel.Resources[i - 1].Deviation);
                        }

                        documentResourcesTable.SetWidths(new float[] { 493, 332, 508, 254 });
                        document.InsertTable(documentResourcesTable);
                        //Code for a table





                        //Code for a heading 1
                        var ProjectConformanceHeading = document.InsertParagraph("3 Project Conformance")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        ProjectConformanceHeading.StyleId = "Heading1";
                        //Code for a heading 1


                        //Code for a heading 2
                        var TimeManagementHeading = document.InsertParagraph("3.1 Time Management")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        TimeManagementHeading.StyleId = "Heading2";
                        //Code for a heading 2
                        //Code for a sentence
                        document.InsertParagraph(currentPostImplementationReviewModel.ProjectcomformanceTimeManagement)
                               .FontSize(11d)
                               .Color(Color.Black)
                               .Font("Arial").Alignment = Alignment.left;
                        //Code for a sentence




                        //Code for a heading 2
                        var CostManagementHeading = document.InsertParagraph("3.2 Cost Management")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        CostManagementHeading.StyleId = "Heading2";
                        //Code for a heading 2
                        //Code for a sentence
                        document.InsertParagraph(currentPostImplementationReviewModel.ProjectcomformanceCostManagement)
                               .FontSize(11d)
                               .Color(Color.Black)
                               .Font("Arial").Alignment = Alignment.left;
                        //Code for a sentence




                        //Code for a heading 2
                        var QualityManagementHeading = document.InsertParagraph("3.3 Quality Management")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        QualityManagementHeading.StyleId = "Heading2";
                        //Code for a heading 2
                        //Code for a sentence
                        document.InsertParagraph(currentPostImplementationReviewModel.ProjectcomformanceQualitManagement)
                               .FontSize(11d)
                               .Color(Color.Black)
                               .Font("Arial").Alignment = Alignment.left;
                        //Code for a sentence




                        //Code for a heading 2
                        var ChangeManagementHeading = document.InsertParagraph("3.4 Change Management")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        ChangeManagementHeading.StyleId = "Heading2";
                        //Code for a heading 2
                        //Code for a sentence
                        document.InsertParagraph(currentPostImplementationReviewModel.ProjectcomformanceChangeManagement)
                               .FontSize(11d)
                               .Color(Color.Black)
                               .Font("Arial").Alignment = Alignment.left;
                        //Code for a sentence




                        //Code for a heading 2
                        var RiskManagementHeading = document.InsertParagraph("3.5 Risk Management")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        RiskManagementHeading.StyleId = "Heading2";
                        //Code for a heading 2
                        //Code for a sentence
                        document.InsertParagraph(currentPostImplementationReviewModel.ProjectcomformanceRiskManagement)
                               .FontSize(11d)
                               .Color(Color.Black)
                               .Font("Arial").Alignment = Alignment.left;
                        //Code for a sentence




                        //Code for a heading 2
                        var IssueManagementHeading = document.InsertParagraph("3.6 Issue Management")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        IssueManagementHeading.StyleId = "Heading2";
                        //Code for a heading 2
                        //Code for a sentence
                        document.InsertParagraph(currentPostImplementationReviewModel.ProjectcomformanceIssueManagement)
                               .FontSize(11d)
                               .Color(Color.Black)
                               .Font("Arial").Alignment = Alignment.left;
                        //Code for a sentence





                        //Code for a heading 2
                        var ProcurementManagementHeading = document.InsertParagraph("3.7 Procurement Management")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        ProcurementManagementHeading.StyleId = "Heading2";
                        //Code for a heading 2
                        //Code for a sentence
                        document.InsertParagraph(currentPostImplementationReviewModel.ProjectcomformanceProcurementManagement)
                               .FontSize(11d)
                               .Color(Color.Black)
                               .Font("Arial").Alignment = Alignment.left;
                        //Code for a sentence




                        //Code for a heading 2
                        var AcceptanceManagementHeading = document.InsertParagraph("3.8 Acceptance Management")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        AcceptanceManagementHeading.StyleId = "Heading2";
                        //Code for a heading 2
                        //Code for a sentence
                        document.InsertParagraph(currentPostImplementationReviewModel.ProjectcomformanceAcceptanceManagement)
                               .FontSize(11d)
                               .Color(Color.Black)
                               .Font("Arial").Alignment = Alignment.left;
                        //Code for a sentence




                        //Code for a heading 2
                        var CommunicationsManagementHeading = document.InsertParagraph("3.9 Communications Management")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        CommunicationsManagementHeading.StyleId = "Heading2";
                        //Code for a heading 2
                        //Code for a sentence
                        document.InsertParagraph(currentPostImplementationReviewModel.ProjectcomformanceCommunicationManagement)
                               .FontSize(11d)
                               .Color(Color.Black)
                               .Font("Arial").Alignment = Alignment.left;
                        //Code for a sentence




                        //Code for a heading 1
                        var ProjectAchievementsHeading = document.InsertParagraph("4 Project Achievements")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        ProjectAchievementsHeading.StyleId = "Heading1";
                        //Code for a heading 1
                        //Code for a table
                        var documentProjectAchievementsTable = document.AddTable(currentPostImplementationReviewModel.ProjectAchievements.Count + 1, 2);
                        documentProjectAchievementsTable.Rows[0].Cells[0].Paragraphs[0].Append("Achievement")
                            .Bold(true)
                            .Color(Color.White);
                        documentProjectAchievementsTable.Rows[0].Cells[1].Paragraphs[0].Append("Effect on Business")
                            .Bold(true)
                            .Color(Color.White);

                        documentProjectAchievementsTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        documentProjectAchievementsTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;


                        for (int i = 1; i < currentPostImplementationReviewModel.ProjectAchievements.Count + 1; i++)
                        {
                            documentProjectAchievementsTable.Rows[i].Cells[0].Paragraphs[0].Append(currentPostImplementationReviewModel.ProjectAchievements[i - 1].Achievement);
                            documentProjectAchievementsTable.Rows[i].Cells[1].Paragraphs[0].Append(currentPostImplementationReviewModel.ProjectAchievements[i - 1].EffectOnBusiness);
                        }

                        documentProjectAchievementsTable.SetWidths(new float[] { 500, 500 });
                        document.InsertTable(documentProjectAchievementsTable);
                        //Code for a table





                        //Code for a heading 1
                        var ProjectFailuresHeading = document.InsertParagraph("5 Project Failures")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        ProjectFailuresHeading.StyleId = "Heading1";
                        //Code for a heading 1
                        //Code for a table
                        var documentProjectFailuresHeadingTable = document.AddTable(currentPostImplementationReviewModel.ProjectFailures.Count + 1, 2);
                        documentProjectFailuresHeadingTable.Rows[0].Cells[0].Paragraphs[0].Append("Failure")
                            .Bold(true)
                            .Color(Color.White);
                        documentProjectFailuresHeadingTable.Rows[0].Cells[1].Paragraphs[0].Append("Effect on Business")
                            .Bold(true)
                            .Color(Color.White);

                        documentProjectFailuresHeadingTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        documentProjectFailuresHeadingTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;


                        for (int i = 1; i < currentPostImplementationReviewModel.ProjectFailures.Count + 1; i++)
                        {
                            documentProjectFailuresHeadingTable.Rows[i].Cells[0].Paragraphs[0].Append(currentPostImplementationReviewModel.ProjectFailures[i - 1].Failure);
                            documentProjectFailuresHeadingTable.Rows[i].Cells[1].Paragraphs[0].Append(currentPostImplementationReviewModel.ProjectFailures[i - 1].EffectOnBusiness);
                        }

                        documentProjectFailuresHeadingTable.SetWidths(new float[] { 500, 500 });
                        document.InsertTable(documentProjectFailuresHeadingTable);
                        //Code for a table




                        //Code for a heading 1
                        var ProjectLessonsLearnedHeading = document.InsertParagraph("6 Project Lessons Learned")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        ProjectLessonsLearnedHeading.StyleId = "Heading1";
                        //Code for a heading 1
                        //Code for a table
                        var documentProjectLessonsLearnedTable = document.AddTable(currentPostImplementationReviewModel.ProjectLessonsLearneds.Count + 1, 2);
                        documentProjectLessonsLearnedTable.Rows[0].Cells[0].Paragraphs[0].Append("Failure")
                            .Bold(true)
                            .Color(Color.White);
                        documentProjectLessonsLearnedTable.Rows[0].Cells[1].Paragraphs[0].Append("Effect on Business")
                            .Bold(true)
                            .Color(Color.White);

                        documentProjectLessonsLearnedTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        documentProjectLessonsLearnedTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;


                        for (int i = 1; i < currentPostImplementationReviewModel.ProjectLessonsLearneds.Count + 1; i++)
                        {
                            documentProjectLessonsLearnedTable.Rows[i].Cells[0].Paragraphs[0].Append(currentPostImplementationReviewModel.ProjectLessonsLearneds[i - 1].Learning);
                            documentProjectLessonsLearnedTable.Rows[i].Cells[1].Paragraphs[0].Append(currentPostImplementationReviewModel.ProjectLessonsLearneds[i - 1].Recommendation);
                        }

                        documentProjectLessonsLearnedTable.SetWidths(new float[] { 500, 500 });
                        document.InsertTable(documentProjectLessonsLearnedTable);
                        //Code for a table


                                                                     

                        //Code for a heading 1
                        var AppendixHeading = document.InsertParagraph("7 Appendix")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        AppendixHeading.StyleId = "Heading1";
                        //Code for a heading 1


                        //Code for a heading 2
                        var SupportingDocumentationHeading = document.InsertParagraph("7.1 Supporting Documentation")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        SupportingDocumentationHeading.StyleId = "Heading2";
                        //Code for a heading 2
                        //Code for a sentence
                        document.InsertParagraph(currentPostImplementationReviewModel.AppendixSupportingDocumentation)
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
