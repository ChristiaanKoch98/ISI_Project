using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Models
{
    class ProjectCharterModel
    {
        public string ProjectName { get; set; }
        public string DocumentID { get; set; }
        public string DocumentOwner { get; set; }
        public string IssueDate { get; set; }
        public string LastSavedDate { get; set; }
        public string FileName { get; set; }
        public List<DocumentHistory> DocumentHistories { get; set; }
        public List<DocumentApproval> DocumentApprovals { get; set; }
        public string ExecutiveSummary { get; set; }
        public string ProjectDefinition { get; set; }
        public string Vision { get; set; }
        public string Objectives { get; set; }
        public string Scope { get; set; }

        public List<Customer> Customers { get; set; }
        public List<Stakeholder> Stakeholders { get; set; }
        public string Roles { get; set; }
        public string Responsibilities { get; set; }
        public string Structure { get; set; }
        public List<Approach> Approaches { get; set; }
        public string Schedule { get; set; }
        public List<Milestone> Milestones { get; set; }
        public List<Dependency> Dependencies { get; set; }
        public List<ResourcePlan> ResourcePlans { get; set; }
        public List<FinancialPlan> FinancialPlans { get; set; }
        public List<QualityPlan> QualityPlans { get; set; }
        public List<CompletionCriteria> CompletionCriterias { get; set; }
        public List<Risk> Risks { get; set; }
        public List<Issue> Issues { get; set; }
        public string Assumptions { get; set; }
        public string Constraints { get; set; }
        public string Appendix { get; set; }
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
        public class Customer
        {
            public string CustomerGroup { get; set; }
            public string CustomerRepresentative { get; set; }
        }

        public class Stakeholder
        {
            public string StakeholderGroup { get; set; }
            public string Interest { get; set; }
        }

        public class Approach
        {
            public string Phase { get; set; }
            public string OverallApproach { get; set; }
        }

        public class Milestone
        {
            public string MilestoneName { get; set; }
            public string Date { get; set; }
            public string MilestoneDescription { get; set; }
        }

        public class Dependency
        {
            public string ProjectActivity { get; set; }
            public string Impacts { get; set; }
            public string IsImpactedBy { get; set; }
            public string Criticality { get; set; }
            public string Date { get; set; }
        }

        public class ResourcePlan
        {
            public string Role { get; set; }
            public string StartDate { get; set; }
            public string EndDate { get; set; }
            public string Effort { get; set; }
        }
        
        public class FinancialPlan
        {
            public string ExpenditureCategory { get; set; }
            public string ExpenditureItem { get; set; }
            public string ExpenditureValue { get; set; }
        }

        public class QualityPlan
        {
            public string Process { get; set; }
            public string Description { get; set; }
        }
        public class CompletionCriteria
        {
            public string Process { get; set; }
            public string Description { get; set; }
        }

        public class Risk
        {
            public string Description { get; set; }
            public string Likelihood { get; set; }
            public string Impact { get; set; }
            public string Action { get; set; }
        }

        public class Issue
        {
            public string Description { get; set; }
            public string Priority { get; set; }
            public string Action { get; set; }
        }
    }
}
