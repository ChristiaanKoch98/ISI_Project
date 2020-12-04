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
        public string Criteria { get; set; }
        public string Solution3Description { get; set; }
        public string Solution3Assessment { get; set; }
        public string Solution3Assumption { get; set; }
        public string RankingCriteria { get; set; }
        public string FeasibilityResults { get; set; }
        public string SupportingDocumentation { get; set; }
        public List<Result1> Results1 { get; set; }
        public List<Risk1> Risks1 { get; set; }
        public List<Issue1> Issues1 { get; set; }
        public List<Result2> Results2 { get; set; }
        public List<Risk2> Risks2 { get; set; }
        public List<Issue2> Issues2 { get; set; }
        public List<Result3> Results3 { get; set; }
        public List<Risk3> Risks3 { get; set; }
        public List<Issue3> Issues3 { get; set; }
        public List<BusinessRequirements> Requirements { get; set; }
        public Information Information { get; set; }
        public RankingScore Ranking { get; set; }
        public List<History> Histories { get; set; }
        public List<Approval> Approvals { get; set; }
        public List<RankingScore> RankingScores { get; set; }
    }

    class BusinessRequirements
    {
        public string BusinessProblem { get; set; }
        public string ProjectRequirement { get; set; }
    }

    class Result1 {
        public string Solution { get; set; }
        public string FeasibilityScore { get; set; }
        public string AssessmentMethod { get; set; }
       
    }
    class Risk1 {
        public string RiskDescription { get; set; }
        public string RiskLikelihood { get; set; }
        public string RiskImpact { get; set; }
        public string ActionRequiredToMinRisk { get; set; }
        
    }
    class Issue1 {
        public string IssueDescription { get; set; }
        public string IssuePriority { get; set; }
        public string ActionRequiredToResolveRisk { get; set; }
        
    }

    class Result2
    {
        public string Solution { get; set; }
        public string FeasibilityScore { get; set; }
        public string AssessmentMethod { get; set; }
       
    }
    class Risk2
    {
        public string RiskDescription { get; set; }
        public string RiskLikelihood { get; set; }
        public string RiskImpact { get; set; }
        public string ActionRequiredToMinRisk { get; set; }
       
    }
    class Issue2
    {
        public string IssueDescription { get; set; }
        public string IssuePriority { get; set; }
        public string ActionRequiredToResolveRisk { get; set; }
       
    }

    class Result3
    {
        public string Solution { get; set; }
        public string FeasibilityScore { get; set; }
        public string AssessmentMethod { get; set; }
        
    }
    class Risk3
    {
        public string RiskDescription { get; set; }
        public string RiskLikelihood { get; set; }
        public string RiskImpact { get; set; }
        public string ActionRequiredToMinRisk { get; set; }
        
    }
    class Issue3
    {
        public string IssueDescription { get; set; }
        public string IssuePriority { get; set; }
        public string ActionRequiredToResolveRisk { get; set; }
        
    }

    class RankingScore
    {
        

        public string Solution1Score { get; set; }
        public string Solution2Score { get; set; }
        public string Solution3Score { get; set; }

        public string Score2 { get; set; }
        public string Weight2 { get; set; }
        public string Total2 { get; set; }

        public string Score3 { get; set; }
        public string Weight3 { get; set; }
        public string Total3 { get; set; }
    }
}
