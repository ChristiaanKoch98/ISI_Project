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
using Xceed.Words.NET;
using Xceed.Document.NET;

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Forms
{
    public partial class BusinessCaseDocumentForm : Form
    {
        VersionControl<BusinessCaseModel> versionControl = new VersionControl<BusinessCaseModel>();
        BusinessCaseModel newBusinessCaseModel = new BusinessCaseModel();
        BusinessCaseModel currentBusinessCaseModel = new BusinessCaseModel();

        Color TABLE_HEADER_COLOR = Color.FromArgb(73, 173, 252);
        Color TABLE_SUBHEADER_COLOR = Color.FromArgb(255, 255, 0);

        public BusinessCaseDocumentForm()
        {
            InitializeComponent();
        }

        public void Save()
        {
            //Document Info
            newBusinessCaseModel.DocumentID = dgvDocInfo.Rows[0].Cells[1].Value.ToString();
            newBusinessCaseModel.DocumentOwner = dgvDocInfo.Rows[1].Cells[1].Value.ToString();
            newBusinessCaseModel.IssueDate = dgvDocInfo.Rows[2].Cells[1].Value.ToString();
            newBusinessCaseModel.LastSavedDate = dgvDocInfo.Rows[3].Cells[1].Value.ToString();
            newBusinessCaseModel.FileName = dgvDocInfo.Rows[4].Cells[1].Value.ToString();

            //Document History
            var documentHistories = new List<BusinessCaseModel.DocumentHistory>();

            int versionRowCount = dgvDocHistory.Rows.Count - 1;

            for (int i = 0; i < versionRowCount; i++)
            {
                BusinessCaseModel.DocumentHistory documentHistory = new BusinessCaseModel.DocumentHistory();
                var tempVersion = dgvDocHistory.Rows[i].Cells[0].Value?.ToString() ?? "";
                var tempIssueDate = dgvDocHistory.Rows[i].Cells[1].Value?.ToString() ?? "";
                var tempChanges = dgvDocHistory.Rows[i].Cells[2].Value?.ToString() ?? "";
                documentHistory.Version = tempVersion;
                documentHistory.IssueDate = tempIssueDate;
                documentHistory.Changes = tempChanges;
                documentHistories.Add(documentHistory);
            }

            newBusinessCaseModel.DocumentHistories = documentHistories;

            //Document Approvals
            List<BusinessCaseModel.DocumentApproval> documentApprovals = new List<BusinessCaseModel.DocumentApproval>();

            int approvalRowsCount = dgvDocApprovals.Rows.Count - 1;

            for (int i = 0; i < approvalRowsCount; i++)
            {
                BusinessCaseModel.DocumentApproval documentApproval = new BusinessCaseModel.DocumentApproval();
                var tempRole = dgvDocApprovals.Rows[i].Cells[0].Value?.ToString() ?? "";
                var tempName = dgvDocApprovals.Rows[i].Cells[1].Value?.ToString() ?? "";
                var tempChanges = dgvDocApprovals.Rows[i].Cells[2].Value?.ToString() ?? "";
                var tempDate = dgvDocApprovals.Rows[i].Cells[3].Value?.ToString() ?? "";
                documentApproval.Role = tempRole;
                documentApproval.Name = tempName;
                documentApproval.Signature = tempChanges;
                documentApproval.DateApproved = tempDate;

                documentApprovals.Add(documentApproval);
            }

            newBusinessCaseModel.DocumentApprovals = documentApprovals;

            ///Executive Summary and Business Problem Tab
            newBusinessCaseModel.ExecutiveSummary = txtExecutiveSummary.Text;
            newBusinessCaseModel.BusinessProblemDescription = txtBusinessProblemDescription.Text;
            newBusinessCaseModel.EnvironmentalAnalysis = txtEnvirAnalysis.Text;
            newBusinessCaseModel.ProblemAnalysis = txtProblemAnalysis.Text;
            newBusinessCaseModel.BusinessProblem = txtBusinessProblem.Text;
            newBusinessCaseModel.BusinessOpportunity = txtBusinessOppurtunity.Text;

            ///Alternative Solutions
            //Option 1
            #region Option 1
            var option1 = new BusinessCaseModel.AlternativeSolution();

            //Description
            option1.AlternativeSolutionDescription = txtOp1_Desc.Text;

            //Benefits
            List<BusinessCaseModel.Benefit> option1Benefits = new List<BusinessCaseModel.Benefit>();

            int rowsCount = dgvOp1_Benefits.Rows.Count - 1;

            for (int i = 0; i < rowsCount; i++)
            {
                BusinessCaseModel.Benefit option1Benefit = new BusinessCaseModel.Benefit();
                var tempCategory = dgvOp1_Benefits.Rows[i].Cells[0].Value?.ToString() ?? "";
                var tempDescription = dgvOp1_Benefits.Rows[i].Cells[1].Value?.ToString() ?? "";
                var tempValue = dgvOp1_Benefits.Rows[i].Cells[2].Value?.ToString() ?? "";

                option1Benefit.BenefitCategory = tempCategory;
                option1Benefit.BenefitDescription = tempDescription;
                option1Benefit.BenefitValue = tempValue;

                option1Benefits.Add(option1Benefit);
            }

            option1.Benefits = option1Benefits;

            //Costs
            List<BusinessCaseModel.Cost> option1Costs = new List<BusinessCaseModel.Cost>();

            rowsCount = dgvOp1_Costs.Rows.Count - 1;

            for (int i = 0; i < rowsCount; i++)
            {
                BusinessCaseModel.Cost option1Cost = new BusinessCaseModel.Cost();
                var tempCategory = dgvOp1_Costs.Rows[i].Cells[0].Value?.ToString() ?? "";
                var tempDescription = dgvOp1_Costs.Rows[i].Cells[1].Value?.ToString() ?? "";
                var tempValue = dgvOp1_Costs.Rows[i].Cells[2].Value?.ToString() ?? "";
                var tempType = dgvOp1_Costs.Rows[i].Cells[3].Value?.ToString() ?? "";

                option1Cost.ExpenseCategory = tempCategory;
                option1Cost.CostDescription = tempDescription;
                option1Cost.ExpenseValue = tempValue;
                option1Cost.ExpenseType = tempType;

                option1Costs.Add(option1Cost);
            }

            option1.Costs = option1Costs;

            //Feasibility
            List<BusinessCaseModel.Feasibility> option1Feasibilities = new List<BusinessCaseModel.Feasibility>();

            rowsCount = dgvOp1_Feas.Rows.Count - 1;

            for (int i = 0; i < rowsCount; i++)
            {
                BusinessCaseModel.Feasibility option1Feasibility = new BusinessCaseModel.Feasibility();
                var tempSolution = dgvOp1_Feas.Rows[i].Cells[0].Value?.ToString() ?? "";
                var tempRating = dgvOp1_Feas.Rows[i].Cells[1].Value?.ToString() ?? "";
                var tempMethod = dgvOp1_Feas.Rows[i].Cells[2].Value?.ToString() ?? "";

                option1Feasibility.Solution = tempSolution;
                option1Feasibility.FeasibilityRating = tempRating;
                option1Feasibility.AssementMethod = tempMethod;

                option1Feasibilities.Add(option1Feasibility);
            }

            option1.Feasibilities = option1Feasibilities;

            //Risks
            List<BusinessCaseModel.Risk> option1Risks = new List<BusinessCaseModel.Risk>();

            rowsCount = dgvOp1_Risks.Rows.Count - 1;

            for (int i = 0; i < rowsCount; i++)
            {
                BusinessCaseModel.Risk option1Risk = new BusinessCaseModel.Risk();
                var tempDescr = dgvOp1_Risks.Rows[i].Cells[0].Value?.ToString() ?? "";
                var tempLikelihood = dgvOp1_Risks.Rows[i].Cells[1].Value?.ToString() ?? "";
                var tempImpact = dgvOp1_Risks.Rows[i].Cells[2].Value?.ToString() ?? "";
                var tempMitigation= dgvOp1_Risks.Rows[i].Cells[3].Value?.ToString() ?? "";

                option1Risk.RiskDescription = tempDescr;
                option1Risk.RiskLikelihood = tempLikelihood;
                option1Risk.RiskImpact = tempImpact;
                option1Risk.RiskMitgation = tempMitigation;

                option1Risks.Add(option1Risk);
            }

            option1.Risks = option1Risks;

            //Issues
            List<BusinessCaseModel.Issue> option1Issues = new List<BusinessCaseModel.Issue>();

            rowsCount = dgvOp1_Issues.Rows.Count - 1;

            for (int i = 0; i < rowsCount; i++)
            {
                BusinessCaseModel.Issue option1Issue = new BusinessCaseModel.Issue();
                var tempDescr = dgvOp1_Issues.Rows[i].Cells[0].Value?.ToString() ?? "";
                var tempPriority = dgvOp1_Issues.Rows[i].Cells[1].Value?.ToString() ?? "";
                var tempAction= dgvOp1_Issues.Rows[i].Cells[2].Value?.ToString() ?? "";

                option1Issue.IssueDescription = tempDescr;
                option1Issue.IssuePriority = tempPriority;
                option1Issue.ResolveAction = tempAction;

                option1Issues.Add(option1Issue);
            }

            option1.Issues = option1Issues;

            option1.Assumptions = txtOp1_Assumptions.Text;
            #endregion

            //Option 2
            #region Option 2
            var option2 = new BusinessCaseModel.AlternativeSolution();

            //Description
            option2.AlternativeSolutionDescription = txtOp2_Desc.Text;

            //Benefits
            List<BusinessCaseModel.Benefit> option2Benefits = new List<BusinessCaseModel.Benefit>();

            rowsCount = dgvOp2_Benefits.Rows.Count - 1;

            for (int i = 0; i < rowsCount; i++)
            {
                BusinessCaseModel.Benefit option2Benefit = new BusinessCaseModel.Benefit();
                var tempCategory = dgvOp2_Benefits.Rows[i].Cells[0].Value?.ToString() ?? "";
                var tempDescription = dgvOp2_Benefits.Rows[i].Cells[1].Value?.ToString() ?? "";
                var tempValue = dgvOp2_Benefits.Rows[i].Cells[2].Value?.ToString() ?? "";

                option2Benefit.BenefitCategory = tempCategory;
                option2Benefit.BenefitDescription = tempDescription;
                option2Benefit.BenefitValue = tempValue;

                option2Benefits.Add(option2Benefit);
            }

            option2.Benefits = option2Benefits;

            //Costs
            List<BusinessCaseModel.Cost> option2Costs = new List<BusinessCaseModel.Cost>();

            rowsCount = dgvOp2_Costs.Rows.Count - 1;

            for (int i = 0; i < rowsCount; i++)
            {
                BusinessCaseModel.Cost option2Cost = new BusinessCaseModel.Cost();
                var tempCategory = dgvOp2_Costs.Rows[i].Cells[0].Value?.ToString() ?? "";
                var tempDescription = dgvOp2_Costs.Rows[i].Cells[1].Value?.ToString() ?? "";
                var tempValue = dgvOp2_Costs.Rows[i].Cells[2].Value?.ToString() ?? "";
                var tempType = dgvOp2_Costs.Rows[i].Cells[3].Value?.ToString() ?? "";

                option2Cost.ExpenseCategory = tempCategory;
                option2Cost.CostDescription = tempDescription;
                option2Cost.ExpenseValue = tempValue;
                option2Cost.ExpenseType = tempType;

                option2Costs.Add(option2Cost);
            }

            option2.Costs = option2Costs;

            //Feasibility
            List<BusinessCaseModel.Feasibility> option2Feasibilities = new List<BusinessCaseModel.Feasibility>();

            rowsCount = dgvOp2_Feas.Rows.Count - 1;

            for (int i = 0; i < rowsCount; i++)
            {
                BusinessCaseModel.Feasibility option2Feasibility = new BusinessCaseModel.Feasibility();
                var tempSolution = dgvOp2_Feas.Rows[i].Cells[0].Value?.ToString() ?? "";
                var tempRating = dgvOp2_Feas.Rows[i].Cells[1].Value?.ToString() ?? "";
                var tempMethod = dgvOp2_Feas.Rows[i].Cells[2].Value?.ToString() ?? "";

                option2Feasibility.Solution = tempSolution;
                option2Feasibility.FeasibilityRating = tempRating;
                option2Feasibility.AssementMethod = tempMethod;

                option2Feasibilities.Add(option2Feasibility);
            }

            option2.Feasibilities = option2Feasibilities;

            //Risks
            List<BusinessCaseModel.Risk> option2Risks = new List<BusinessCaseModel.Risk>();

            rowsCount = dgvOp2_Risks.Rows.Count - 1;

            for (int i = 0; i < rowsCount; i++)
            {
                BusinessCaseModel.Risk option2Risk = new BusinessCaseModel.Risk();
                var tempDescr = dgvOp2_Risks.Rows[i].Cells[0].Value?.ToString() ?? "";
                var tempLikelihood = dgvOp2_Risks.Rows[i].Cells[1].Value?.ToString() ?? "";
                var tempImpact = dgvOp2_Risks.Rows[i].Cells[2].Value?.ToString() ?? "";
                var tempMitigation = dgvOp2_Risks.Rows[i].Cells[3].Value?.ToString() ?? "";

                option2Risk.RiskDescription = tempDescr;
                option2Risk.RiskLikelihood = tempLikelihood;
                option2Risk.RiskImpact = tempImpact;
                option2Risk.RiskMitgation = tempMitigation;

                option2Risks.Add(option2Risk);
            }

            option2.Risks = option2Risks;

            //Issues
            List<BusinessCaseModel.Issue> option2Issues = new List<BusinessCaseModel.Issue>();

            rowsCount = dgvOp2_Issues.Rows.Count - 1;

            for (int i = 0; i < rowsCount; i++)
            {
                BusinessCaseModel.Issue option2Issue = new BusinessCaseModel.Issue();
                var tempDescr = dgvOp2_Issues.Rows[i].Cells[0].Value?.ToString() ?? "";
                var tempPriority = dgvOp2_Issues.Rows[i].Cells[1].Value?.ToString() ?? "";
                var tempAction = dgvOp2_Issues.Rows[i].Cells[2].Value?.ToString() ?? "";

                option2Issue.IssueDescription = tempDescr;
                option2Issue.IssuePriority = tempPriority;
                option2Issue.ResolveAction = tempAction;

                option2Issues.Add(option2Issue);
            }

            option2.Issues = option2Issues;

            option2.Assumptions = txtOp2_Assumptions.Text;
            #endregion

            //Option 3
            #region Option 3
            var option3 = new BusinessCaseModel.AlternativeSolution();

            //Description
            option3.AlternativeSolutionDescription = txtOp3_Desc.Text;

            //Benefits
            List<BusinessCaseModel.Benefit> option3Benefits = new List<BusinessCaseModel.Benefit>();

            rowsCount = dgvOp3_Benefits.Rows.Count - 1;

            for (int i = 0; i < rowsCount; i++)
            {
                BusinessCaseModel.Benefit option3Benefit = new BusinessCaseModel.Benefit();
                var tempCategory = dgvOp3_Benefits.Rows[i].Cells[0].Value?.ToString() ?? "";
                var tempDescription = dgvOp3_Benefits.Rows[i].Cells[1].Value?.ToString() ?? "";
                var tempValue = dgvOp3_Benefits.Rows[i].Cells[2].Value?.ToString() ?? "";

                option3Benefit.BenefitCategory = tempCategory;
                option3Benefit.BenefitDescription = tempDescription;
                option3Benefit.BenefitValue = tempValue;

                option3Benefits.Add(option3Benefit);
            }

            option3.Benefits = option3Benefits;

            //Costs
            List<BusinessCaseModel.Cost> option3Costs = new List<BusinessCaseModel.Cost>();

            rowsCount = dgvOp3_Costs.Rows.Count - 1;

            for (int i = 0; i < rowsCount; i++)
            {
                BusinessCaseModel.Cost option3Cost = new BusinessCaseModel.Cost();
                var tempCategory = dgvOp3_Costs.Rows[i].Cells[0].Value?.ToString() ?? "";
                var tempDescription = dgvOp3_Costs.Rows[i].Cells[1].Value?.ToString() ?? "";
                var tempValue = dgvOp3_Costs.Rows[i].Cells[2].Value?.ToString() ?? "";
                var tempType = dgvOp3_Costs.Rows[i].Cells[3].Value?.ToString() ?? "";

                option3Cost.ExpenseCategory = tempCategory;
                option3Cost.CostDescription = tempDescription;
                option3Cost.ExpenseValue = tempValue;
                option3Cost.ExpenseType = tempType;

                option3Costs.Add(option3Cost);
            }

            option3.Costs = option3Costs;

            //Feasibility
            List<BusinessCaseModel.Feasibility> option3Feasibilities = new List<BusinessCaseModel.Feasibility>();

            rowsCount = dgvOp3_Feasibility.Rows.Count - 1;

            for (int i = 0; i < rowsCount; i++)
            {
                BusinessCaseModel.Feasibility option3Feasibility = new BusinessCaseModel.Feasibility();
                var tempSolution = dgvOp3_Feasibility.Rows[i].Cells[0].Value?.ToString() ?? "";
                var tempRating = dgvOp3_Feasibility.Rows[i].Cells[1].Value?.ToString() ?? "";
                var tempMethod = dgvOp3_Feasibility.Rows[i].Cells[2].Value?.ToString() ?? "";

                option3Feasibility.Solution = tempSolution;
                option3Feasibility.FeasibilityRating = tempRating;
                option3Feasibility.AssementMethod = tempMethod;

                option3Feasibilities.Add(option3Feasibility);
            }

            option3.Feasibilities = option3Feasibilities;

            //Risks
            List<BusinessCaseModel.Risk> option3Risks = new List<BusinessCaseModel.Risk>();

            rowsCount = dgvOp3_Risks.Rows.Count - 1;

            for (int i = 0; i < rowsCount; i++)
            {
                BusinessCaseModel.Risk option3Risk = new BusinessCaseModel.Risk();
                var tempDescr = dgvOp3_Risks.Rows[i].Cells[0].Value?.ToString() ?? "";
                var tempLikelihood = dgvOp3_Risks.Rows[i].Cells[1].Value?.ToString() ?? "";
                var tempImpact = dgvOp3_Risks.Rows[i].Cells[2].Value?.ToString() ?? "";
                var tempMitigation = dgvOp3_Risks.Rows[i].Cells[3].Value?.ToString() ?? "";

                option3Risk.RiskDescription = tempDescr;
                option3Risk.RiskLikelihood = tempLikelihood;
                option3Risk.RiskImpact = tempImpact;
                option3Risk.RiskMitgation = tempMitigation;

                option3Risks.Add(option3Risk);
            }

            option3.Risks = option3Risks;

            //Issues
            List<BusinessCaseModel.Issue> option3Issues = new List<BusinessCaseModel.Issue>();

            rowsCount = dgvOp3_Issues.Rows.Count - 1;

            for (int i = 0; i < rowsCount; i++)
            {
                BusinessCaseModel.Issue option3Issue = new BusinessCaseModel.Issue();
                var tempDescr = dgvOp3_Issues.Rows[i].Cells[0].Value?.ToString() ?? "";
                var tempPriority = dgvOp3_Issues.Rows[i].Cells[1].Value?.ToString() ?? "";
                var tempAction = dgvOp3_Issues.Rows[i].Cells[2].Value?.ToString() ?? "";

                option3Issue.IssueDescription = tempDescr;
                option3Issue.IssuePriority = tempPriority;
                option3Issue.ResolveAction = tempAction;

                option3Issues.Add(option3Issue);
            }

            option3.Issues = option3Issues;

            option3.Assumptions = txtOp3_Assumptions.Text;
            #endregion

            newBusinessCaseModel.AlternativeSolutions = new List<BusinessCaseModel.AlternativeSolution>() { option1, option2, option3 };

            ///Recommended Solution
            //Description
            newBusinessCaseModel.RecommendedSolutionDescription = txtRecommendedSolutionDescription.Text;

            //Solution Ratings
            List<BusinessCaseModel.SolutionRating> solutionRatings = new List<BusinessCaseModel.SolutionRating>();

            rowsCount = dgvSolutionRating.Rows.Count - 1;

            for (int i = 0; i < rowsCount; i++)
            {
                BusinessCaseModel.SolutionRating solutionRating = new BusinessCaseModel.SolutionRating();
                var tempCriteria = dgvSolutionRating.Rows[i].Cells[0].Value?.ToString() ?? "";
                var tempSolution1 = dgvSolutionRating.Rows[i].Cells[1].Value?.ToString() ?? "";
                var tempSolution2 = dgvSolutionRating.Rows[i].Cells[2].Value?.ToString() ?? "";
                var tempSolution3 = dgvSolutionRating.Rows[i].Cells[3].Value?.ToString() ?? "";
                solutionRating.AssementCriteria = tempCriteria;
                solutionRating.Solution1_Score = tempSolution1;
                solutionRating.Solution2_Score = tempSolution2;
                solutionRating.Solution3_Score = tempSolution3;

                solutionRatings.Add(solutionRating);
            }

            newBusinessCaseModel.SolutionRatings = solutionRatings;

            string recommendedSolutionChosen = "";

            if (radSolution1.Checked)
                recommendedSolutionChosen = "1";
            else if (radSolution2.Checked)
                recommendedSolutionChosen = "2";
            else
                recommendedSolutionChosen = "3";

            newBusinessCaseModel.RecommendedSolutionChosen = recommendedSolutionChosen;

            ///Implementation Approach
            newBusinessCaseModel.ProjectDescription = txtIprojDescription.Text;
            newBusinessCaseModel.ProjectInitiation = txtIAProjectInitiation.Text;
            newBusinessCaseModel.ProjectPlanning = txtIAProjectPlanning.Text;
            newBusinessCaseModel.ProjectExecution = txtIAProjectExecution.Text;
            newBusinessCaseModel.ProjectClosure = txtIAProjectClosure.Text;
            newBusinessCaseModel.ProjectManagement = txtIAProjectManagement.Text;

            ///Appendix
            newBusinessCaseModel.Appendix = txtAppendix.Text;

            //Convert to JSON
            List<VersionControl<BusinessCaseModel>.DocumentModel> documentModels = versionControl.DocumentModels;

            if (!versionControl.isEqual(currentBusinessCaseModel, newBusinessCaseModel))
            {
                VersionControl<BusinessCaseModel>.DocumentModel documentModel = new VersionControl<BusinessCaseModel>.DocumentModel(newBusinessCaseModel, DateTime.Now, VersionControl<ProjectModel>.generateID());

                documentModels.Add(documentModel);
                versionControl.DocumentModels = documentModels;
                currentBusinessCaseModel = JsonConvert.DeserializeObject<BusinessCaseModel>(JsonConvert.SerializeObject(newBusinessCaseModel));

                string json = JsonConvert.SerializeObject(versionControl);
                JsonHelper.saveDocument(json, Settings.Default.ProjectID, "FinancialPlan");
                MessageBox.Show("Business case document saved successfully", "save", MessageBoxButtons.OK);
            }
        }

        public void LoadDoc()
        {
            string json = JsonHelper.loadDocument(Settings.Default.ProjectID, "FinancialPlan");
            List<string[]> documentInfo = new List<string[]>();
            newBusinessCaseModel = new BusinessCaseModel();
            currentBusinessCaseModel = new BusinessCaseModel();

            if (json != "")
            {
                versionControl = JsonConvert.DeserializeObject<VersionControl<BusinessCaseModel>>(json);
                newBusinessCaseModel = JsonConvert.DeserializeObject<BusinessCaseModel>(versionControl.getLatest(versionControl.DocumentModels));
                currentBusinessCaseModel = JsonConvert.DeserializeObject<BusinessCaseModel>(versionControl.getLatest(versionControl.DocumentModels));

                ///Intro Tab
                //Document Info
                documentInfo.Add(new string[] { "Document ID", currentBusinessCaseModel.DocumentID });
                documentInfo.Add(new string[] { "Document Owner", currentBusinessCaseModel.DocumentOwner });
                documentInfo.Add(new string[] { "Issue Date", currentBusinessCaseModel.IssueDate });
                documentInfo.Add(new string[] { "Last Save Date", currentBusinessCaseModel.LastSavedDate });
                documentInfo.Add(new string[] { "File Name", currentBusinessCaseModel.FileName });

                foreach (var row in documentInfo)
                {
                    dgvDocInfo.Rows.Add(row);
                }
                dgvDocInfo.AllowUserToAddRows = false;

                //Document History
                foreach (var row in currentBusinessCaseModel.DocumentHistories)
                {
                    dgvDocHistory.Rows.Add(new string[] { row.Version, row.IssueDate, row.Changes });
                }

                //Document Approvals
                foreach (var row in currentBusinessCaseModel.DocumentApprovals)
                {
                    dgvDocApprovals.Rows.Add(new string[] { row.Role, row.Name, row.Signature, row.DateApproved });
                }

                ///Executive Summary and Business Problem Tab
                txtExecutiveSummary.Text = currentBusinessCaseModel.ExecutiveSummary;
                txtBusinessProblemDescription.Text = currentBusinessCaseModel.BusinessProblemDescription;
                txtEnvirAnalysis.Text = currentBusinessCaseModel.EnvironmentalAnalysis;
                txtProblemAnalysis.Text = currentBusinessCaseModel.ProblemAnalysis;
                txtBusinessProblem.Text = currentBusinessCaseModel.BusinessProblem;
                txtBusinessOppurtunity.Text = currentBusinessCaseModel.BusinessOpportunity;

                ///Alternative Solution
                ///Solution 1
                #region Solution 1
                var option1 = currentBusinessCaseModel.AlternativeSolutions[0];

                //Description
                txtOp1_Desc.Text = option1.AlternativeSolutionDescription;

                //Benefits
                foreach (var row in option1.Benefits)
                {
                    dgvOp1_Benefits.Rows.Add(new string[] { row.BenefitCategory, row.BenefitDescription, row.BenefitValue });
                }

                //Costs
                foreach (var row in option1.Costs)
                {
                    dgvOp1_Costs.Rows.Add(new string[] { row.ExpenseCategory, row.CostDescription, row.ExpenseValue, row.ExpenseType });
                }

                //Feasibilities
                foreach (var row in option1.Feasibilities)
                {
                    dgvOp1_Feas.Rows.Add(new string[] { row.Solution, row.FeasibilityRating, row.AssementMethod });
                }

                //Risks
                foreach (var row in option1.Risks)
                {
                    dgvOp1_Risks.Rows.Add(new string[] { row.RiskDescription, row.RiskLikelihood, row.RiskImpact, row.RiskMitgation });
                }

                //Issues
                foreach (var row in option1.Issues)
                {
                    dgvOp1_Issues.Rows.Add(new string[] { row.IssueDescription, row.IssuePriority, row.ResolveAction });
                }

                //Assumptions
                txtOp1_Assumptions.Text = option1.Assumptions;
                #endregion

                ///Solution 2
                #region Solution 2
                var option2 = currentBusinessCaseModel.AlternativeSolutions[1];

                //Description
                txtOp2_Desc.Text = option2.AlternativeSolutionDescription;

                //Benefits
                foreach (var row in option2.Benefits)
                {
                    dgvOp2_Benefits.Rows.Add(new string[] { row.BenefitCategory, row.BenefitDescription, row.BenefitValue });
                }

                //Costs
                foreach (var row in option2.Costs)
                {
                    dgvOp2_Costs.Rows.Add(new string[] { row.ExpenseCategory, row.CostDescription, row.ExpenseValue, row.ExpenseType });
                }

                //Feasibilities
                foreach (var row in option2.Feasibilities)
                {
                    dgvOp2_Feas.Rows.Add(new string[] { row.Solution, row.FeasibilityRating, row.AssementMethod });
                }

                //Risks
                foreach (var row in option2.Risks)
                {
                    dgvOp2_Risks.Rows.Add(new string[] { row.RiskDescription, row.RiskLikelihood, row.RiskImpact, row.RiskMitgation });
                }

                //Issues
                foreach (var row in option2.Issues)
                {
                    dgvOp2_Issues.Rows.Add(new string[] { row.IssueDescription, row.IssuePriority, row.ResolveAction });
                }

                //Assumptions
                txtOp2_Assumptions.Text = option2.Assumptions;
                #endregion

                ///Solution 3
                #region Solution 3
                var option3 = currentBusinessCaseModel.AlternativeSolutions[2];

                //Description
                txtOp3_Desc.Text = option3.AlternativeSolutionDescription;

                //Benefits
                foreach (var row in option3.Benefits)
                {
                    dgvOp3_Benefits.Rows.Add(new string[] { row.BenefitCategory, row.BenefitDescription, row.BenefitValue });
                }

                //Costs
                foreach (var row in option3.Costs)
                {
                    dgvOp3_Costs.Rows.Add(new string[] { row.ExpenseCategory, row.CostDescription, row.ExpenseValue, row.ExpenseType });
                }

                //Feasibilities
                foreach (var row in option3.Feasibilities)
                {
                    dgvOp3_Feasibility.Rows.Add(new string[] { row.Solution, row.FeasibilityRating, row.AssementMethod });
                }

                //Risks
                foreach (var row in option3.Risks)
                {
                    dgvOp3_Risks.Rows.Add(new string[] { row.RiskDescription, row.RiskLikelihood, row.RiskImpact, row.RiskMitgation });
                }

                //Issues
                foreach (var row in option3.Issues)
                {
                    dgvOp3_Issues.Rows.Add(new string[] { row.IssueDescription, row.IssuePriority, row.ResolveAction });
                }

                //Assumptions
                txtOp3_Assumptions.Text = option3.Assumptions;
                #endregion

                ///Recommended Solution
                //Description
                txtRecommendedSolutionDescription.Text = currentBusinessCaseModel.RecommendedSolutionDescription;

                //Solution Ratings
                foreach (var row in currentBusinessCaseModel.SolutionRatings)
                {
                    dgvSolutionRating.Rows.Add(new string[] { row.AssementCriteria, row.Solution1_Score, row.Solution2_Score, row.Solution3_Score });
                }

                //Prefered Solution / Chosen Solution
                string preferedSolution = currentBusinessCaseModel.RecommendedSolutionChosen;

                if (preferedSolution == "1")
                    radSolution1.Checked = true;
                else if (preferedSolution == "2")
                    radSolution2.Checked = true;
                else
                    radSolution3.Checked = true;

                ///Implementation Approach
                txtIprojDescription.Text = currentBusinessCaseModel.ProjectDescription;
                txtIAProjectInitiation.Text = currentBusinessCaseModel.ProjectInitiation;
                txtIAProjectPlanning.Text = currentBusinessCaseModel.ProjectPlanning;
                txtIAProjectExecution.Text = currentBusinessCaseModel.ProjectExecution;
                txtIAProjectClosure.Text = currentBusinessCaseModel.ProjectClosure;
                txtIAProjectManagement.Text = currentBusinessCaseModel.ProjectManagement;

                ///Appendix
                txtAppendix.Text = currentBusinessCaseModel.Appendix;
            }
            else
            {
                versionControl = new VersionControl<BusinessCaseModel>();
                versionControl.DocumentModels = new List<VersionControl<BusinessCaseModel>.DocumentModel>();
                documentInfo.Add(new string[] { "Document ID", "" });
                documentInfo.Add(new string[] { "Document Owner", "" });
                documentInfo.Add(new string[] { "Issue Date", "" });
                documentInfo.Add(new string[] { "Last Save Date", "" });
                documentInfo.Add(new string[] { "File Name", "" });
                newBusinessCaseModel = new BusinessCaseModel();

                foreach (var row in documentInfo)
                {
                    dgvDocInfo.Rows.Add(row);
                }

                dgvDocInfo.AllowUserToAddRows = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void BusinessCaseDocumentForm_Load(object sender, EventArgs e)
        {
            LoadDoc();
        }

        private void dgvDocInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
