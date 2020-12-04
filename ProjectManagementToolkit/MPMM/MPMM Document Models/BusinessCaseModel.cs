using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Models
{
    public class BusinessCaseDocument
    {
        public string ProjectName { get; set; }

        public string DocumentID { get; set; }

        public string DocumentOwner { get; set; }

        public DateTime IssueDate { get; set; }

        public DateTime LastSavedDate { get; set; }

        public string FileName { get; set; }

        public List<DocumentHistory> DocumentHistories { get; set; }

        public List<DocumentApproval> DocumentApprovals { get; set; }

        public string ExecutiveSummary { get; set; }

        public string BusinessProblemMain { get; set; }

        public string BusinessProblemSub { get; set; }

        public string EnvironmentalAnalysis { get; set; }

        public string ProblemAnalysis { get; set; }

        public string BusinessOpportunity { get; set; }

        public string AlternativeSolutionsBrief { get; set; }

        public List<AlternativeSolution> AlternativeSolutions { get; set; }

        public string RecommendedSolutionDescription { get; set; }

        public List<SolutionRating> SolutionRatings { get; set; }

        public string RecommendedSolutionSummary { get; set; }

        public string ImplementationApproachDescription { get; set; }

        public string ProjectInitiation { get; set; }

        public string ProjectPlanning { get; set; }

        public string ProjectExecution { get; set; }

        public string ProjectClosure { get; set; }

        public string ProjectManagement { get; set; }


        public class DocumentHistory
        {
            public string Version { get; set; }

            public DateTime IssueDate { get; set; }

            public string Changes { get; set; }
        }

        public class DocumentApproval
        {
            public string Role { get; set; }

            public string Name { get; set; }

            public string Signature { get; set; }

            public DateTime DateApproved { get; set; }
        }

        public class AlternativeSolution
        {
            public string AlternativeSolutionDescription { get; set; }

            public List<Benefit> Benefits { get; set; }

            public List<Cost> Costs { get; set; }

            public List<Feasibility> Feasibilities { get; set; }
        }

        public List<Risk> Risks { get; set; }

        public List<Issue> Issues { get; set; }

        public string Assumptions { get; set; }

        public class Benefit
        {
            public string BenefitDescription { get; set; }

            public string BenefitCategory { get; set; }

            public string BenefitValue { get; set; }
        }

        public class Cost
        {
            public string CostDescription { get; set; }

            public string ExpenseCategory { get; set; }

            public string ExpenseValue { get; set; }

            public string ExpenseType { get; set; }
        }

        public class Feasibility
        {
            public string FeasibilityRating { get; set; }

            public string Solution { get; set; }

            public string AssementMethod { get; set; }
        }

        public class Risk
        {
            public string RiskSummary { get; set; }

            public string RiskDescription { get; set; }

            public string RiskLikelihood { get; set; }

            public string RiskImpact { get; set; }

            public string RiskMitgation { get; set; }
        }
        public class Issue
        {
            public string IssueSummary { get; set; }

            public string IssueDescription { get; set; }

            public string IssuePriority { get; set; }

            public string ResolveAction { get; set; }
        }

        public class SolutionRating
        {
            public string AssementCriteria { get; set; }

            public List<string> SolutionName { get; set; }

            public List<int> SolutionScore { get; set; }
        }

    }
}

