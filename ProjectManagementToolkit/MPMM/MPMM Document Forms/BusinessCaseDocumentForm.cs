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
        ProjectModel projectModel = new ProjectModel();
        Color TABLE_HEADER_COLOR = Color.FromArgb(73, 173, 252);
        Color TABLE_SUBHEADER_COLOR = Color.FromArgb(255, 255, 0);

        public BusinessCaseDocumentForm()
        {
            InitializeComponent();
        }

        public void Save()
        {
            //Project Name
            newBusinessCaseModel.ProjectName = txtProjName.Text;

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
                JsonHelper.saveDocument(json, Settings.Default.ProjectID, "BusinessCase");
                MessageBox.Show("Business case document saved successfully", "save", MessageBoxButtons.OK);
            }
        }

        public void LoadDoc()
        {
            string json = JsonHelper.loadDocument(Settings.Default.ProjectID, "BusinessCase");
            List<string[]> documentInfo = new List<string[]>();
            newBusinessCaseModel = new BusinessCaseModel();
            currentBusinessCaseModel = new BusinessCaseModel();

            if (json != "")
            {
                versionControl = JsonConvert.DeserializeObject<VersionControl<BusinessCaseModel>>(json);
                newBusinessCaseModel = JsonConvert.DeserializeObject<BusinessCaseModel>(versionControl.getLatest(versionControl.DocumentModels));
                currentBusinessCaseModel = JsonConvert.DeserializeObject<BusinessCaseModel>(versionControl.getLatest(versionControl.DocumentModels));

                //Project Name
                txtProjName.Text = currentBusinessCaseModel.ProjectName;

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
                        #region Front Page
                        for (int i = 0; i < 11; i++)
                        {
                            document.InsertParagraph("")
                                .Font("Arial")
                                .Bold(true)
                                .FontSize(22d).Alignment = Alignment.left;
                        }

                        document.InsertParagraph("Business Case \nFor " + currentBusinessCaseModel.ProjectName)
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(22d).Alignment = Alignment.left;
                        document.InsertSectionPageBreak();
                        document.InsertParagraph("Document Control\n")
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(14d).Alignment = Alignment.left;
                        document.InsertParagraph("")
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(14d).Alignment = Alignment.left;
                        document.InsertParagraph("Document Information\n")
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(14d).Alignment = Alignment.left;
                        #endregion

                        #region Document Basics
                        var documentInfoTable = document.AddTable(6, 2);
                        documentInfoTable.Rows[0].Cells[0].Paragraphs[0].Append("").Bold(true).Color(Color.White);
                        documentInfoTable.Rows[0].Cells[1].Paragraphs[0].Append("Information").Bold(true).Color(Color.White);
                        documentInfoTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        documentInfoTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;

                        documentInfoTable.Rows[1].Cells[0].Paragraphs[0].Append("Document ID");
                        documentInfoTable.Rows[1].Cells[1].Paragraphs[0].Append(currentBusinessCaseModel.DocumentID);

                        documentInfoTable.Rows[2].Cells[0].Paragraphs[0].Append("Document Owner");
                        documentInfoTable.Rows[2].Cells[1].Paragraphs[0].Append(currentBusinessCaseModel.DocumentOwner);

                        documentInfoTable.Rows[3].Cells[0].Paragraphs[0].Append("Issue Date");
                        documentInfoTable.Rows[3].Cells[1].Paragraphs[0].Append(currentBusinessCaseModel.IssueDate);

                        documentInfoTable.Rows[4].Cells[0].Paragraphs[0].Append("Last Saved Date");
                        documentInfoTable.Rows[4].Cells[1].Paragraphs[0].Append(currentBusinessCaseModel.LastSavedDate);

                        documentInfoTable.Rows[5].Cells[0].Paragraphs[0].Append("File Name");
                        documentInfoTable.Rows[5].Cells[1].Paragraphs[0].Append(currentBusinessCaseModel.FileName);
                        documentInfoTable.SetWidths(new float[] { 493, 1094 });
                        document.InsertTable(documentInfoTable);

                        document.InsertParagraph("\nDocument History\n")
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(14d).Alignment = Alignment.left;

                        var documentHistoryTable = document.AddTable(currentBusinessCaseModel.DocumentHistories.Count + 1, 3);
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

                        for (int i = 1; i < currentBusinessCaseModel.DocumentHistories.Count + 1; i++)
                        {
                            documentHistoryTable.Rows[i].Cells[0].Paragraphs[0].Append(currentBusinessCaseModel.DocumentHistories[i - 1].Version);
                            documentHistoryTable.Rows[i].Cells[1].Paragraphs[0].Append(currentBusinessCaseModel.DocumentHistories[i - 1].IssueDate);
                            documentHistoryTable.Rows[i].Cells[2].Paragraphs[0].Append(currentBusinessCaseModel.DocumentHistories[i - 1].Changes);

                        }

                        documentHistoryTable.SetWidths(new float[] { 190, 303, 1094 });
                        document.InsertTable(documentHistoryTable);

                        document.InsertParagraph("\nDocument Approvals\n")
                           .Font("Arial")
                           .Bold(true)
                           .FontSize(14d).Alignment = Alignment.left;

                        var documentApprovalTable = document.AddTable(currentBusinessCaseModel.DocumentApprovals.Count + 1, 4);
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

                        for (int i = 1; i < currentBusinessCaseModel.DocumentApprovals.Count + 1; i++)
                        {
                            documentApprovalTable.Rows[i].Cells[0].Paragraphs[0].Append(currentBusinessCaseModel.DocumentApprovals[i - 1].Role);
                            documentApprovalTable.Rows[i].Cells[1].Paragraphs[0].Append(currentBusinessCaseModel.DocumentApprovals[i - 1].Name);
                            documentApprovalTable.Rows[i].Cells[2].Paragraphs[0].Append(currentBusinessCaseModel.DocumentApprovals[i - 1].Signature);
                            documentApprovalTable.Rows[i].Cells[3].Paragraphs[0].Append(currentBusinessCaseModel.DocumentApprovals[i - 1].DateApproved);
                        }
                        documentApprovalTable.SetWidths(new float[] { 493, 332, 508, 254 });
                        document.InsertTable(documentApprovalTable);
                        document.InsertParagraph().InsertPageBreakAfterSelf();

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
                        document.InsertParagraph().InsertPageBreakAfterSelf();
                        #endregion

                        #region Executive Summary & Business Problem
                        var execSummaryHeading = document.InsertParagraph("1 Executive Summary and Business Problem")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        execSummaryHeading.StyleId = "Heading1";

                        //Executive Summary
                        var execSummarySubHeading = document.InsertParagraph("1.1 Executive Summary")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        execSummarySubHeading.StyleId = "Heading2";

                        document.InsertParagraph(String.Join(",\n", currentBusinessCaseModel.ExecutiveSummary))
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        //Business Problem Description
                        var pbdSubHeading = document.InsertParagraph("1.2 Business Problem Description")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        pbdSubHeading.StyleId = "Heading2";

                        document.InsertParagraph(String.Join(",\n", currentBusinessCaseModel.BusinessProblemDescription))
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        //Environmental Analysis
                        var eaSubHeading = document.InsertParagraph("1.3 Environmental Analysis")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        eaSubHeading.StyleId = "Heading2";

                        document.InsertParagraph(String.Join(",\n", currentBusinessCaseModel.EnvironmentalAnalysis))
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        //Problem Analysis
                        var paSubHeading = document.InsertParagraph("1.4 Problem Analysis")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        paSubHeading.StyleId = "Heading2";

                        document.InsertParagraph(String.Join(",\n", currentBusinessCaseModel.ProblemAnalysis))
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        //Business Problem
                        var bpSubHeading = document.InsertParagraph("1.5 Business Problem")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        bpSubHeading.StyleId = "Heading2";

                        document.InsertParagraph(String.Join(",\n", currentBusinessCaseModel.BusinessProblem))
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        //Business Opportunity
                        var boSubHeading = document.InsertParagraph("1.6 Business Opportunity")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        boSubHeading.StyleId = "Heading2";

                        document.InsertParagraph(String.Join(",\n", currentBusinessCaseModel.BusinessOpportunity))
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        #endregion

                        #region Alternative Solutions
                        var asHeading = document.InsertParagraph("2 Alternative Solutions")
                                .Bold()
                                .FontSize(14d)
                                .Color(Color.Black)
                                .Bold(true)
                                .Font("Arial");

                        asHeading.StyleId = "Heading1";

                        ///Solution 1
                        #region Solution 1
                        var option1 = currentBusinessCaseModel.AlternativeSolutions[0];

                        var op1Heading = document.InsertParagraph("2.1 Solution 1")
                                .Bold()
                                .FontSize(12d)
                                .Color(Color.Black)
                                .Bold(true)
                                .Font("Arial");

                        op1Heading.StyleId = "Heading2";

                        //Description
                        var op1DescHeading = document.InsertParagraph("2.1.1 Description")
                                .Bold()
                                .FontSize(11d)
                                .Color(Color.Black)
                                .Bold(true)
                                .Font("Arial");

                        op1DescHeading.StyleId = "Heading3";

                        document.InsertParagraph(String.Join(",\n", option1.AlternativeSolutionDescription))
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        //Benefits
                        var op1BenHeading = document.InsertParagraph("2.1.2 Benefits")
                                .Bold()
                                .FontSize(11d)
                                .Color(Color.Black)
                                .Bold(true)
                                .Font("Arial");

                        op1BenHeading.StyleId = "Heading3";


                        var op1BenefitsTable = document.AddTable(option1.Benefits.Count + 1, 3);

                        op1BenefitsTable.Rows[0].Cells[0].Paragraphs[0].Append("Category")
                            .Bold(true)
                            .Color(Color.White);
                        op1BenefitsTable.Rows[0].Cells[1].Paragraphs[0].Append("Description")
                            .Bold(true)
                            .Color(Color.White);
                        op1BenefitsTable.Rows[0].Cells[2].Paragraphs[0].Append("Value")
                            .Bold(true)
                            .Color(Color.White);

                        op1BenefitsTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        op1BenefitsTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        op1BenefitsTable.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < option1.Benefits.Count + 1; i++)
                        {
                            op1BenefitsTable.Rows[i].Cells[0].Paragraphs[0].Append(option1.Benefits[i - 1].BenefitCategory);
                            op1BenefitsTable.Rows[i].Cells[1].Paragraphs[0].Append(option1.Benefits[i - 1].BenefitDescription);
                            op1BenefitsTable.Rows[i].Cells[2].Paragraphs[0].Append(option1.Benefits[i - 1].BenefitValue);
                        }

                        document.InsertTable(op1BenefitsTable);

                        //Costs
                        var op1CostsHeading = document.InsertParagraph("2.1.3 Costs")
                                .Bold()
                                .FontSize(11d)
                                .Color(Color.Black)
                                .Bold(true)
                                .Font("Arial");

                        op1CostsHeading.StyleId = "Heading3";


                        var op1CostsTable = document.AddTable(option1.Costs.Count + 1, 4);

                        op1CostsTable.Rows[0].Cells[0].Paragraphs[0].Append("Category")
                            .Bold(true)
                            .Color(Color.White);
                        op1CostsTable.Rows[0].Cells[1].Paragraphs[0].Append("Description")
                            .Bold(true)
                            .Color(Color.White);
                        op1CostsTable.Rows[0].Cells[2].Paragraphs[0].Append("Value")
                            .Bold(true)
                            .Color(Color.White);
                        op1CostsTable.Rows[0].Cells[3].Paragraphs[0].Append("Type")
                            .Bold(true)
                            .Color(Color.White);

                        op1CostsTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        op1CostsTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        op1CostsTable.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;
                        op1CostsTable.Rows[0].Cells[3].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < option1.Costs.Count + 1; i++)
                        {
                            op1CostsTable.Rows[i].Cells[0].Paragraphs[0].Append(option1.Costs[i - 1].ExpenseCategory);
                            op1CostsTable.Rows[i].Cells[1].Paragraphs[0].Append(option1.Costs[i - 1].CostDescription);
                            op1CostsTable.Rows[i].Cells[2].Paragraphs[0].Append(option1.Costs[i - 1].ExpenseValue);
                            op1CostsTable.Rows[i].Cells[3].Paragraphs[0].Append(option1.Costs[i - 1].ExpenseType);
                        }

                        document.InsertTable(op1CostsTable);

                        //Feasibilities
                        var op1FeasHeading = document.InsertParagraph("2.1.4 Feasibilities")
                                .Bold()
                                .FontSize(11d)
                                .Color(Color.Black)
                                .Bold(true)
                                .Font("Arial");

                        op1FeasHeading.StyleId = "Heading3";


                        var op1FeasTable = document.AddTable(option1.Feasibilities.Count + 1, 3);

                        op1FeasTable.Rows[0].Cells[0].Paragraphs[0].Append("Solution")
                            .Bold(true)
                            .Color(Color.White);
                        op1FeasTable.Rows[0].Cells[1].Paragraphs[0].Append("Feasibility Rating")
                            .Bold(true)
                            .Color(Color.White);
                        op1FeasTable.Rows[0].Cells[2].Paragraphs[0].Append("Assessment Method")
                            .Bold(true)
                            .Color(Color.White);

                        op1FeasTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        op1FeasTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        op1FeasTable.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < option1.Feasibilities.Count + 1; i++)
                        {
                            op1FeasTable.Rows[i].Cells[0].Paragraphs[0].Append(option1.Feasibilities[i - 1].Solution);
                            op1FeasTable.Rows[i].Cells[1].Paragraphs[0].Append(option1.Feasibilities[i - 1].FeasibilityRating);
                            op1FeasTable.Rows[i].Cells[2].Paragraphs[0].Append(option1.Feasibilities[i - 1].AssementMethod);
                        }

                        document.InsertTable(op1FeasTable);

                        //Risks
                        var op1RiskHeading = document.InsertParagraph("2.1.5 Risks")
                                .Bold()
                                .FontSize(11d)
                                .Color(Color.Black)
                                .Bold(true)
                                .Font("Arial");

                        op1RiskHeading.StyleId = "Heading3";


                        var op1RiskTable = document.AddTable(option1.Risks.Count + 1, 4);

                        op1RiskTable.Rows[0].Cells[0].Paragraphs[0].Append("Risk Description")
                            .Bold(true)
                            .Color(Color.White);
                        op1RiskTable.Rows[0].Cells[1].Paragraphs[0].Append("Likelihood")
                            .Bold(true)
                            .Color(Color.White);
                        op1RiskTable.Rows[0].Cells[2].Paragraphs[0].Append("Impact")
                            .Bold(true)
                            .Color(Color.White);
                        op1RiskTable.Rows[0].Cells[3].Paragraphs[0].Append("Mitigation Actions")
                            .Bold(true)
                            .Color(Color.White);

                        op1RiskTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        op1RiskTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        op1RiskTable.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;
                        op1RiskTable.Rows[0].Cells[3].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < option1.Risks.Count + 1; i++)
                        {
                            op1RiskTable.Rows[i].Cells[0].Paragraphs[0].Append(option1.Risks[i - 1].RiskDescription);
                            op1RiskTable.Rows[i].Cells[1].Paragraphs[0].Append(option1.Risks[i - 1].RiskLikelihood);
                            op1RiskTable.Rows[i].Cells[2].Paragraphs[0].Append(option1.Risks[i - 1].RiskImpact);
                            op1RiskTable.Rows[i].Cells[3].Paragraphs[0].Append(option1.Risks[i - 1].RiskMitgation);
                        }

                        document.InsertTable(op1RiskTable);

                        //Issues
                        var op1issueHeading = document.InsertParagraph("2.1.6 Issues")
                                .Bold()
                                .FontSize(11d)
                                .Color(Color.Black)
                                .Bold(true)
                                .Font("Arial");

                        op1issueHeading.StyleId = "Heading3";


                        var op1IssueTable = document.AddTable(option1.Issues.Count + 1, 3);

                        op1IssueTable.Rows[0].Cells[0].Paragraphs[0].Append("Issue Description")
                            .Bold(true)
                            .Color(Color.White);
                        op1IssueTable.Rows[0].Cells[1].Paragraphs[0].Append("Priority")
                            .Bold(true)
                            .Color(Color.White);
                        op1IssueTable.Rows[0].Cells[2].Paragraphs[0].Append("Action required to Resolve Issue")
                            .Bold(true)
                            .Color(Color.White);

                        op1IssueTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        op1IssueTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        op1IssueTable.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < option1.Issues.Count + 1; i++)
                        {
                            op1IssueTable.Rows[i].Cells[0].Paragraphs[0].Append(option1.Issues[i - 1].IssueDescription);
                            op1IssueTable.Rows[i].Cells[1].Paragraphs[0].Append(option1.Issues[i - 1].IssuePriority);
                            op1IssueTable.Rows[i].Cells[2].Paragraphs[0].Append(option1.Issues[i - 1].ResolveAction);
                        }

                        document.InsertTable(op1IssueTable);

                        //Assumptions
                        var op1AssumpHeading = document.InsertParagraph("2.1.7 Assumptions")
                                .Bold()
                                .FontSize(11d)
                                .Color(Color.Black)
                                .Bold(true)
                                .Font("Arial");

                        op1AssumpHeading.StyleId = "Heading3";

                        document.InsertParagraph(String.Join(",\n", option1.Assumptions))
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;
                        #endregion

                        ///Solution 2
                        #region Solution 2
                        var option2 = currentBusinessCaseModel.AlternativeSolutions[1];

                        var op2Heading = document.InsertParagraph("2.2 Solution 2")
                                .Bold()
                                .FontSize(12d)
                                .Color(Color.Black)
                                .Bold(true)
                                .Font("Arial");

                        op2Heading.StyleId = "Heading2";

                        //Description
                        var op2DescHeading = document.InsertParagraph("2.2.1 Description")
                                .Bold()
                                .FontSize(11d)
                                .Color(Color.Black)
                                .Bold(true)
                                .Font("Arial");

                        op2DescHeading.StyleId = "Heading3";

                        document.InsertParagraph(String.Join(",\n", option2.AlternativeSolutionDescription))
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        //Benefits
                        var op2BenHeading = document.InsertParagraph("2.2.2 Benefits")
                                .Bold()
                                .FontSize(11d)
                                .Color(Color.Black)
                                .Bold(true)
                                .Font("Arial");

                        op2BenHeading.StyleId = "Heading3";


                        var op2BenefitsTable = document.AddTable(option2.Benefits.Count + 1, 3);

                        op2BenefitsTable.Rows[0].Cells[0].Paragraphs[0].Append("Category")
                            .Bold(true)
                            .Color(Color.White);
                        op2BenefitsTable.Rows[0].Cells[1].Paragraphs[0].Append("Description")
                            .Bold(true)
                            .Color(Color.White);
                        op2BenefitsTable.Rows[0].Cells[2].Paragraphs[0].Append("Value")
                            .Bold(true)
                            .Color(Color.White);

                        op2BenefitsTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        op2BenefitsTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        op2BenefitsTable.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < option2.Benefits.Count + 1; i++)
                        {
                            op2BenefitsTable.Rows[i].Cells[0].Paragraphs[0].Append(option2.Benefits[i - 1].BenefitCategory);
                            op2BenefitsTable.Rows[i].Cells[1].Paragraphs[0].Append(option2.Benefits[i - 1].BenefitDescription);
                            op2BenefitsTable.Rows[i].Cells[2].Paragraphs[0].Append(option2.Benefits[i - 1].BenefitValue);
                        }

                        document.InsertTable(op2BenefitsTable);

                        //Costs
                        var op2CostsHeading = document.InsertParagraph("2.2.3 Costs")
                                .Bold()
                                .FontSize(11d)
                                .Color(Color.Black)
                                .Bold(true)
                                .Font("Arial");

                        op2CostsHeading.StyleId = "Heading3";


                        var op2CostsTable = document.AddTable(option2.Costs.Count + 1, 4);

                        op2CostsTable.Rows[0].Cells[0].Paragraphs[0].Append("Category")
                            .Bold(true)
                            .Color(Color.White);
                        op2CostsTable.Rows[0].Cells[1].Paragraphs[0].Append("Description")
                            .Bold(true)
                            .Color(Color.White);
                        op2CostsTable.Rows[0].Cells[2].Paragraphs[0].Append("Value")
                            .Bold(true)
                            .Color(Color.White);
                        op2CostsTable.Rows[0].Cells[3].Paragraphs[0].Append("Type")
                            .Bold(true)
                            .Color(Color.White);

                        op2CostsTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        op2CostsTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        op2CostsTable.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;
                        op2CostsTable.Rows[0].Cells[3].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < option2.Costs.Count + 1; i++)
                        {
                            op2CostsTable.Rows[i].Cells[0].Paragraphs[0].Append(option2.Costs[i - 1].ExpenseCategory);
                            op2CostsTable.Rows[i].Cells[1].Paragraphs[0].Append(option2.Costs[i - 1].CostDescription);
                            op2CostsTable.Rows[i].Cells[2].Paragraphs[0].Append(option2.Costs[i - 1].ExpenseValue);
                            op2CostsTable.Rows[i].Cells[3].Paragraphs[0].Append(option2.Costs[i - 1].ExpenseType);
                        }

                        document.InsertTable(op2CostsTable);

                        //Feasibilities
                        var op2FeasHeading = document.InsertParagraph("2.2.4 Feasibilities")
                                .Bold()
                                .FontSize(11d)
                                .Color(Color.Black)
                                .Bold(true)
                                .Font("Arial");

                        op2FeasHeading.StyleId = "Heading3";


                        var op2FeasTable = document.AddTable(option2.Feasibilities.Count + 1, 3);

                        op2FeasTable.Rows[0].Cells[0].Paragraphs[0].Append("Solution")
                            .Bold(true)
                            .Color(Color.White);
                        op2FeasTable.Rows[0].Cells[1].Paragraphs[0].Append("Feasibility Rating")
                            .Bold(true)
                            .Color(Color.White);
                        op2FeasTable.Rows[0].Cells[2].Paragraphs[0].Append("Assessment Method")
                            .Bold(true)
                            .Color(Color.White);

                        op2FeasTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        op2FeasTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        op2FeasTable.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < option2.Feasibilities.Count + 1; i++)
                        {
                            op2FeasTable.Rows[i].Cells[0].Paragraphs[0].Append(option2.Feasibilities[i - 1].Solution);
                            op2FeasTable.Rows[i].Cells[1].Paragraphs[0].Append(option2.Feasibilities[i - 1].FeasibilityRating);
                            op2FeasTable.Rows[i].Cells[2].Paragraphs[0].Append(option2.Feasibilities[i - 1].AssementMethod);
                        }

                        document.InsertTable(op2FeasTable);

                        //Risks
                        var op2RiskHeading = document.InsertParagraph("2.2.5 Risks")
                                .Bold()
                                .FontSize(11d)
                                .Color(Color.Black)
                                .Bold(true)
                                .Font("Arial");

                        op2RiskHeading.StyleId = "Heading3";


                        var op2RiskTable = document.AddTable(option2.Risks.Count + 1, 4);

                        op2RiskTable.Rows[0].Cells[0].Paragraphs[0].Append("Risk Description")
                            .Bold(true)
                            .Color(Color.White);
                        op2RiskTable.Rows[0].Cells[1].Paragraphs[0].Append("Likelihood")
                            .Bold(true)
                            .Color(Color.White);
                        op2RiskTable.Rows[0].Cells[2].Paragraphs[0].Append("Impact")
                            .Bold(true)
                            .Color(Color.White);
                        op2RiskTable.Rows[0].Cells[3].Paragraphs[0].Append("Mitigation Actions")
                            .Bold(true)
                            .Color(Color.White);

                        op2RiskTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        op2RiskTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        op2RiskTable.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;
                        op2RiskTable.Rows[0].Cells[3].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < option2.Risks.Count + 1; i++)
                        {
                            op2RiskTable.Rows[i].Cells[0].Paragraphs[0].Append(option2.Risks[i - 1].RiskDescription);
                            op2RiskTable.Rows[i].Cells[1].Paragraphs[0].Append(option2.Risks[i - 1].RiskLikelihood);
                            op2RiskTable.Rows[i].Cells[2].Paragraphs[0].Append(option2.Risks[i - 1].RiskImpact);
                            op2RiskTable.Rows[i].Cells[3].Paragraphs[0].Append(option2.Risks[i - 1].RiskMitgation);
                        }

                        document.InsertTable(op2RiskTable);

                        //Issues
                        var op2issueHeading = document.InsertParagraph("2.2.6 Issues")
                                .Bold()
                                .FontSize(11d)
                                .Color(Color.Black)
                                .Bold(true)
                                .Font("Arial");

                        op2issueHeading.StyleId = "Heading3";


                        var op2IssueTable = document.AddTable(option2.Issues.Count + 1, 3);

                        op2IssueTable.Rows[0].Cells[0].Paragraphs[0].Append("Issue Description")
                            .Bold(true)
                            .Color(Color.White);
                        op2IssueTable.Rows[0].Cells[1].Paragraphs[0].Append("Priority")
                            .Bold(true)
                            .Color(Color.White);
                        op2IssueTable.Rows[0].Cells[2].Paragraphs[0].Append("Action required to Resolve Issue")
                            .Bold(true)
                            .Color(Color.White);

                        op2IssueTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        op2IssueTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        op2IssueTable.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < option2.Issues.Count + 1; i++)
                        {
                            op2IssueTable.Rows[i].Cells[0].Paragraphs[0].Append(option2.Issues[i - 1].IssueDescription);
                            op2IssueTable.Rows[i].Cells[1].Paragraphs[0].Append(option2.Issues[i - 1].IssuePriority);
                            op2IssueTable.Rows[i].Cells[2].Paragraphs[0].Append(option2.Issues[i - 1].ResolveAction);
                        }

                        document.InsertTable(op2IssueTable);

                        //Assumptions
                        var op2AssumpHeading = document.InsertParagraph("2.2.7 Assumptions")
                                .Bold()
                                .FontSize(11d)
                                .Color(Color.Black)
                                .Bold(true)
                                .Font("Arial");

                        op2AssumpHeading.StyleId = "Heading3";

                        document.InsertParagraph(String.Join(",\n", option2.Assumptions))
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;
                        #endregion

                        ///Solution 3
                        #region Solution 3
                        var option3 = currentBusinessCaseModel.AlternativeSolutions[2];

                        var op3Heading = document.InsertParagraph("2.3 Solution 3")
                                .Bold()
                                .FontSize(12d)
                                .Color(Color.Black)
                                .Bold(true)
                                .Font("Arial");

                        op3Heading.StyleId = "Heading2";

                        //Description
                        var op3DescHeading = document.InsertParagraph("2.3.1 Description")
                                .Bold()
                                .FontSize(11d)
                                .Color(Color.Black)
                                .Bold(true)
                                .Font("Arial");

                        op3DescHeading.StyleId = "Heading3";

                        document.InsertParagraph(String.Join(",\n", option3.AlternativeSolutionDescription))
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        //Benefits
                        var op3BenHeading = document.InsertParagraph("2.3.2 Benefits")
                                .Bold()
                                .FontSize(11d)
                                .Color(Color.Black)
                                .Bold(true)
                                .Font("Arial");

                        op3BenHeading.StyleId = "Heading3";


                        var op3BenefitsTable = document.AddTable(option3.Benefits.Count + 1, 3);

                        op3BenefitsTable.Rows[0].Cells[0].Paragraphs[0].Append("Category")
                            .Bold(true)
                            .Color(Color.White);
                        op3BenefitsTable.Rows[0].Cells[1].Paragraphs[0].Append("Description")
                            .Bold(true)
                            .Color(Color.White);
                        op3BenefitsTable.Rows[0].Cells[2].Paragraphs[0].Append("Value")
                            .Bold(true)
                            .Color(Color.White);

                        op3BenefitsTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        op3BenefitsTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        op3BenefitsTable.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < option3.Benefits.Count + 1; i++)
                        {
                            op3BenefitsTable.Rows[i].Cells[0].Paragraphs[0].Append(option3.Benefits[i - 1].BenefitCategory);
                            op3BenefitsTable.Rows[i].Cells[1].Paragraphs[0].Append(option3.Benefits[i - 1].BenefitDescription);
                            op3BenefitsTable.Rows[i].Cells[2].Paragraphs[0].Append(option3.Benefits[i - 1].BenefitValue);
                        }

                        document.InsertTable(op3BenefitsTable);

                        //Costs
                        var op3CostsHeading = document.InsertParagraph("2.3.3 Costs")
                                .Bold()
                                .FontSize(11d)
                                .Color(Color.Black)
                                .Bold(true)
                                .Font("Arial");

                        op3CostsHeading.StyleId = "Heading3";


                        var op3CostsTable = document.AddTable(option3.Costs.Count + 1, 4);

                        op3CostsTable.Rows[0].Cells[0].Paragraphs[0].Append("Category")
                            .Bold(true)
                            .Color(Color.White);
                        op3CostsTable.Rows[0].Cells[1].Paragraphs[0].Append("Description")
                            .Bold(true)
                            .Color(Color.White);
                        op3CostsTable.Rows[0].Cells[2].Paragraphs[0].Append("Value")
                            .Bold(true)
                            .Color(Color.White);
                        op3CostsTable.Rows[0].Cells[3].Paragraphs[0].Append("Type")
                            .Bold(true)
                            .Color(Color.White);

                        op3CostsTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        op3CostsTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        op3CostsTable.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;
                        op3CostsTable.Rows[0].Cells[3].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < option3.Costs.Count + 1; i++)
                        {
                            op3CostsTable.Rows[i].Cells[0].Paragraphs[0].Append(option3.Costs[i - 1].ExpenseCategory);
                            op3CostsTable.Rows[i].Cells[1].Paragraphs[0].Append(option3.Costs[i - 1].CostDescription);
                            op3CostsTable.Rows[i].Cells[2].Paragraphs[0].Append(option3.Costs[i - 1].ExpenseValue);
                            op3CostsTable.Rows[i].Cells[3].Paragraphs[0].Append(option3.Costs[i - 1].ExpenseType);
                        }

                        document.InsertTable(op3CostsTable);

                        //Feasibilities
                        var op3FeasHeading = document.InsertParagraph("2.3.4 Feasibilities")
                                .Bold()
                                .FontSize(11d)
                                .Color(Color.Black)
                                .Bold(true)
                                .Font("Arial");

                        op3FeasHeading.StyleId = "Heading3";


                        var op3FeasTable = document.AddTable(option3.Feasibilities.Count + 1, 3);

                        op3FeasTable.Rows[0].Cells[0].Paragraphs[0].Append("Solution")
                            .Bold(true)
                            .Color(Color.White);
                        op3FeasTable.Rows[0].Cells[1].Paragraphs[0].Append("Feasibility Rating")
                            .Bold(true)
                            .Color(Color.White);
                        op3FeasTable.Rows[0].Cells[2].Paragraphs[0].Append("Assessment Method")
                            .Bold(true)
                            .Color(Color.White);

                        op3FeasTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        op3FeasTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        op3FeasTable.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < option3.Feasibilities.Count + 1; i++)
                        {
                            op3FeasTable.Rows[i].Cells[0].Paragraphs[0].Append(option3.Feasibilities[i - 1].Solution);
                            op3FeasTable.Rows[i].Cells[1].Paragraphs[0].Append(option3.Feasibilities[i - 1].FeasibilityRating);
                            op3FeasTable.Rows[i].Cells[2].Paragraphs[0].Append(option3.Feasibilities[i - 1].AssementMethod);
                        }

                        document.InsertTable(op3FeasTable);

                        //Risks
                        var op3RiskHeading = document.InsertParagraph("2.3.5 Risks")
                                .Bold()
                                .FontSize(11d)
                                .Color(Color.Black)
                                .Bold(true)
                                .Font("Arial");

                        op3RiskHeading.StyleId = "Heading3";


                        var op3RiskTable = document.AddTable(option3.Risks.Count + 1, 4);

                        op3RiskTable.Rows[0].Cells[0].Paragraphs[0].Append("Risk Description")
                            .Bold(true)
                            .Color(Color.White);
                        op3RiskTable.Rows[0].Cells[1].Paragraphs[0].Append("Likelihood")
                            .Bold(true)
                            .Color(Color.White);
                        op3RiskTable.Rows[0].Cells[2].Paragraphs[0].Append("Impact")
                            .Bold(true)
                            .Color(Color.White);
                        op3RiskTable.Rows[0].Cells[3].Paragraphs[0].Append("Mitigation Actions")
                            .Bold(true)
                            .Color(Color.White);

                        op3RiskTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        op3RiskTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        op3RiskTable.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;
                        op3RiskTable.Rows[0].Cells[3].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < option3.Risks.Count + 1; i++)
                        {
                            op3RiskTable.Rows[i].Cells[0].Paragraphs[0].Append(option3.Risks[i - 1].RiskDescription);
                            op3RiskTable.Rows[i].Cells[1].Paragraphs[0].Append(option3.Risks[i - 1].RiskLikelihood);
                            op3RiskTable.Rows[i].Cells[2].Paragraphs[0].Append(option3.Risks[i - 1].RiskImpact);
                            op3RiskTable.Rows[i].Cells[3].Paragraphs[0].Append(option3.Risks[i - 1].RiskMitgation);
                        }

                        document.InsertTable(op3RiskTable);

                        //Issues
                        var op3issueHeading = document.InsertParagraph("2.3.6 Issues")
                                .Bold()
                                .FontSize(11d)
                                .Color(Color.Black)
                                .Bold(true)
                                .Font("Arial");

                        op3issueHeading.StyleId = "Heading3";


                        var op3IssueTable = document.AddTable(option3.Issues.Count + 1, 3);

                        op3IssueTable.Rows[0].Cells[0].Paragraphs[0].Append("Issue Description")
                            .Bold(true)
                            .Color(Color.White);
                        op3IssueTable.Rows[0].Cells[1].Paragraphs[0].Append("Priority")
                            .Bold(true)
                            .Color(Color.White);
                        op3IssueTable.Rows[0].Cells[2].Paragraphs[0].Append("Action required to Resolve Issue")
                            .Bold(true)
                            .Color(Color.White);

                        op3IssueTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        op3IssueTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        op3IssueTable.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < option3.Issues.Count + 1; i++)
                        {
                            op3IssueTable.Rows[i].Cells[0].Paragraphs[0].Append(option3.Issues[i - 1].IssueDescription);
                            op3IssueTable.Rows[i].Cells[1].Paragraphs[0].Append(option3.Issues[i - 1].IssuePriority);
                            op3IssueTable.Rows[i].Cells[2].Paragraphs[0].Append(option3.Issues[i - 1].ResolveAction);
                        }

                        document.InsertTable(op3IssueTable);

                        //Assumptions
                        var op3AssumpHeading = document.InsertParagraph("2.3.7 Assumptions")
                                .Bold()
                                .FontSize(11d)
                                .Color(Color.Black)
                                .Bold(true)
                                .Font("Arial");

                        op3AssumpHeading.StyleId = "Heading3";

                        document.InsertParagraph(String.Join(",\n", option3.Assumptions))
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;
                        #endregion

                        #endregion

                        #region Recommended Solution
                        var recSolHeading = document.InsertParagraph("3 Recommended Solution")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        recSolHeading.StyleId = "Heading1";

                        //Description
                        var recSolDescSubHeading = document.InsertParagraph("3.1 Description")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        recSolDescSubHeading.StyleId = "Heading2";

                        document.InsertParagraph(String.Join(",\n", currentBusinessCaseModel.RecommendedSolutionDescription))
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        //Solution Ratings
                        var recSolPrefSubHeading = document.InsertParagraph("3.3 Preferred Solution")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        recSolPrefSubHeading.StyleId = "Heading2";


                        var solTable = document.AddTable(currentBusinessCaseModel.SolutionRatings.Count + 1, 4);

                        solTable.Rows[0].Cells[0].Paragraphs[0].Append("Assessment Criteria")
                            .Bold(true)
                            .Color(Color.White);
                        solTable.Rows[0].Cells[1].Paragraphs[0].Append("Solution 1 Score")
                            .Bold(true)
                            .Color(Color.White);
                        solTable.Rows[0].Cells[2].Paragraphs[0].Append("Solution 2 Score")
                            .Bold(true)
                            .Color(Color.White);
                        solTable.Rows[0].Cells[3].Paragraphs[0].Append("Solution 3 Score")
                           .Bold(true)
                           .Color(Color.White);

                        solTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        solTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        solTable.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;
                        solTable.Rows[0].Cells[3].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < option1.Benefits.Count + 1; i++)
                        {
                            solTable.Rows[i].Cells[0].Paragraphs[0].Append(currentBusinessCaseModel.SolutionRatings[i - 1].AssementCriteria);
                            solTable.Rows[i].Cells[1].Paragraphs[0].Append(currentBusinessCaseModel.SolutionRatings[i - 1].Solution1_Score);
                            solTable.Rows[i].Cells[2].Paragraphs[0].Append(currentBusinessCaseModel.SolutionRatings[i - 1].Solution2_Score);
                            solTable.Rows[i].Cells[3].Paragraphs[0].Append(currentBusinessCaseModel.SolutionRatings[i - 1].Solution3_Score);
                        }

                        document.InsertTable(solTable);

                        //Solution Rating
                        var recSolRatingSubHeading = document.InsertParagraph("3.3 Preferred Solution")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        recSolRatingSubHeading.StyleId = "Heading2";

                        document.InsertParagraph(String.Join(",\n", $"Solution {currentBusinessCaseModel.RecommendedSolutionChosen} is preferred when the criteria above are taken into consideration."))
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;
                        #endregion

                        #region Implementation Approach
                        var impApHeading = document.InsertParagraph("4 Implementation Approach")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        impApHeading.StyleId = "Heading1";

                        //Project Description
                        var projDescSubHeading = document.InsertParagraph("4.1 Project Description")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        projDescSubHeading.StyleId = "Heading2";

                        document.InsertParagraph(String.Join(",\n", currentBusinessCaseModel.ProjectDescription))
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        //Project Initiation
                        var projInitSubHeading = document.InsertParagraph("4.2 Project Initiation")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        projInitSubHeading.StyleId = "Heading2";

                        document.InsertParagraph(String.Join(",\n", currentBusinessCaseModel.ProjectInitiation))
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        //Project Planning
                        var projPlSubHeading = document.InsertParagraph("4.3 Project Planning")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        projPlSubHeading.StyleId = "Heading2";

                        document.InsertParagraph(String.Join(",\n", currentBusinessCaseModel.ProjectPlanning))
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        //Project Execution
                        var projExecSubHeading = document.InsertParagraph("4.4 Project Execution")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        projExecSubHeading.StyleId = "Heading2";

                        document.InsertParagraph(String.Join(",\n", currentBusinessCaseModel.ProjectExecution))
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        //Project Closure
                        var projClSubHeading = document.InsertParagraph("4.5 Project Closure")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        projClSubHeading.StyleId = "Heading2";

                        document.InsertParagraph(String.Join(",\n", currentBusinessCaseModel.ProjectClosure))
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        //Project Management
                        var projManagSubHeading = document.InsertParagraph("4.6 Project Management")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        projManagSubHeading.StyleId = "Heading2";

                        document.InsertParagraph(String.Join(",\n", currentBusinessCaseModel.ProjectManagement))
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;
                        #endregion

                        #region Appendix
                        var appendHeading = document.InsertParagraph("Appendix")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        appendHeading.StyleId = "Heading1";

                        document.InsertParagraph(String.Join(",\n", currentBusinessCaseModel.Appendix))
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;
                        #endregion

                        try
                        {
                            document.Save();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("The selected file is open.", "Close File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void BusinessCaseDocumentForm_Load(object sender, EventArgs e)
        {
            string json = JsonHelper.loadProjectInfo(Settings.Default.Username);
            List<ProjectModel> projectListModel = JsonConvert.DeserializeObject<List<ProjectModel>>(json);
            projectModel = projectModel.getProjectModel(Settings.Default.ProjectID, projectListModel);
            txtProjectName.Text = projectModel.ProjectName;

            LoadDoc();
        }

        private void dgvDocInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ExportToWord();
        }
    }
}
