using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementToolkit.Classes
{
    class FeasibilityStudyModel
    {
        public string ProjectName { get; set; }
        public string ExecutiveSummary { get; set; }
        public string BusinessEnvironment { get; set; }
        public string BusinessProblem { get; set; }
        public string BusinessOpportunity { get; set; }
        public string BusinessDrivers { get; set; }
        public string BusinessRequirements { get; set; }
        public string PotentialSolution { get; set; }
        public string Solution1Description { get; set; }
        public string Solution1Assessment { get; set; }
        public string Solution1Assumption { get; set; }
        public string Solution2Description { get; set; }
        public string Solution2Assessment { get; set; }
        public string Solution2Assumption { get; set; }
        public string Solution3Description { get; set; }
        public string Solution3Assessment { get; set; }
        public string Solution3Assumption { get; set; }
        public string RankingCriteria { get; set; }
        public string FeasibilityResults { get; set; }
        public string SupportingDocumentation { get; set; }
        public string RankingScores { get; internal set; }

        public string Results { get; set; }
        public string Risks { get; set; }
        public string Results2 { get; set; }
        public string Risks2 { get; set; }
        public string Results3 { get; set; }
        public string Risks3 { get; set; }
    }

    class BusinessRequirements
    {
        public string BusinessProblem { get; set; }
        public string ProjectRequirement { get; set; }

       
    }

    class Solution1
    {
        public string Solution { get; set; }
        public string FeasibilityScore { get; set; }
        public string AssessmentMethod { get; set; }

        public string RiskDescription { get; set; }
        public string RiskLikelihood { get; set; }
        public string RiskImpact { get; set; }
        public string ActionRequiredToMinRisk { get; set; }

        public string IssueDescription { get; set; }
        public string IssuePriority { get; set; }
        public string ActionRequiredToResolveRisk { get; set; }

        public string Score1 { get; set; }
        public string Weight1 { get; set; }
        public string Total1 { get; set; }


    }
    class Solution2
    {
        public string Solution { get; set; }
        public string FeasibilityScore { get; set; }
        public string AssessmentMethod { get; set; }

        public string RiskDescription { get; set; }
        public string RiskLikelihood { get; set; }
        public string RiskImpact { get; set; }
        public string ActionRequiredToMinRisk { get; set; }

        public string IssueDescription { get; set; }
        public string IssuePriority { get; set; }
        public string ActionRequiredToResolveRisk { get; set; }

        public string Score2 { get; set; }
        public string Weight2 { get; set; }
        public string Total2 { get; set; }

    }
    class Solution3
    {
        public string Solution { get; set; }
        public string FeasibilityScore { get; set; }
        public string AssessmentMethod { get; set; }

        public string RiskDescription { get; set; }
        public string RiskLikelihood { get; set; }
        public string RiskImpact { get; set; }
        public string ActionRequiredToMinRisk { get; set; }

        public string IssueDescription { get; set; }
        public string IssuePriority { get; set; }
        public string ActionRequiredToResolveRisk { get; set; }

        public string Score3 { get; set; }
        public string Weight3 { get; set; }
        public string Total3 { get; set; }
    }
}
