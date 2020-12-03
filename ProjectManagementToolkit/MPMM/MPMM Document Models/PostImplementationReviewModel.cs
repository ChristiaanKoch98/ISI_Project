using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Models
{
    class PostImplementationReviewModel
    {
        public string ProjectName { get; set; }

        public string DocumentID { get; set; }

        public string DocumentOwner { get; set; }

        public string IssueDate { get; set; }

        public string LastSavedDate { get; set; }

        public string FileName { get; set; }

        public List<DocumentHistory> DocumentHistories { get; set; }

        public List<DocumentApproval> DocumentApprovals { get; set; }

        public string ExecutivesummaryDescription { get; set; }

        public string ProjectperformanceDescription { get; set; }

        public List<Benefit> Benefits { get; set; }

        public List<Objective> Objectives { get; set; }

        public List<Scope> Scopes { get; set; }

        public List<Delivarable> Delivarables { get; set; }

        public string ProjectperformanceSchedule { get; set; }

        public List<Expense> Expenses { get; set; }

        public List<Resource> Resources { get; set; }

        public string ProjectComformanceDescription { get; set; }

        public string ProjectcomformanceTimeManagement { get; set; }

        public string ProjectcomformanceCostManagement { get; set; }

        public string ProjectcomformanceQualitManagement { get; set; }

        public string ProjectcomformanceChangeManagement { get; set; }

        public string ProjectcomformanceRiskManagement { get; set; }

        public string ProjectcomformanceIssueManagement { get; set; }

        public string ProjectcomformanceProcurementManagement { get; set; }

        public string ProjectcomformanceAcceptanceManagement { get; set; }

        public string ProjectcomformanceCommunicationManagement { get; set; }

        public string ProjectachievementDescription { get; set; }

        public List<ProjectAchievement> ProjectAchievements { get; set; }

        public string ProjectfailureDescription { get; set; }

        public List<ProjectFailure> ProjectFailures { get; set; }

        public string ProjectlessonslearneDescription { get; set; }

        public List<ProjectLessonsLearned> ProjectLessonsLearneds { get; set; }

        public string AppendixDescription { get; set; }

        public string AppendixSupportingDocumentation { get; set; }


        public class DocumentHistory
        {
            public string Version { get; set; }

            public string IssueDate { get; set; }

            public string Changes { get; set; }
        }

        public class DocumentApproval
        {
            public string Role { get; set; }

            public string Name { get; set; }

            public string Signature { get; set; }

            public string DateApproved { get; set; }
        }

        public class Benefit
        {
            public string BenefitDesc { get; set; }

            public string ForecastValue { get; set; }

            public string ActualValue { get; set; }

            public string Deviation { get; set; }
        }

        public class Objective
        {
            public string ObjectiveDesc { get; set; }

            public string Achievement { get; set; }

            public string Shortfall { get; set; }
        }

        public class Scope
        {
            public string OriginalScope { get; set; }

            public string ActualScope { get; set; }

            public string Deviation { get; set; }
        }

        public class Delivarable
        {
            public string DeliverableDesc { get; set; }

            public string QualityCriteria { get; set; }

            public string QualityStandards { get; set; }

            public string Achievement { get; set; }
        }

        public class Expense
        {
            public string ExpenseTypes { get; set; }

            public string ForecastExpenditure { get; set; }

            public string ActualExpenditure { get; set; }

            public string Deviation { get; set; }
        }

        public class Resource
        {
            public string ResourceTypes { get; set; }

            public string ForecastResource { get; set; }

            public string ActualResource { get; set; }

            public string Deviation { get; set; }
        }

        public class ProjectAchievement
        {
            public string Achievement { get; set; }

            public string EffectOnBusiness { get; set; }
        }

        public class ProjectFailure
        {
            public string Failure { get; set; }

            public string EffectOnBusiness { get; set; }
        }

        public class ProjectLessonsLearned
        {
            public string Learning { get; set; }

            public string Recommendation { get; set; }
        }
    }
}
