using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Models
{
    class TermsOfReferenceModel
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

        public string ProjDefinition { get; set; }
        public string Vision { get; set; }
        public string Objectives { get; set; }
        public string Scope { get; set; }
        //public string Deliverables { get; set; }

        public string Responsibilities { get; set; }
        public string Structure { get; set; }

       
        public string Constraints { get; set; }
        public string Assumptions { get; set; }

        public List<Deliverables> Deliv { get; set; }
        public List<Customers> Cust { get; set; }
        public List<Stakeholders> Stake { get; set; }
        public List<Roles> Rol { get; set; }
        public List<Approach> Appr { get; set; }
        public List<Milestones> Mile { get; set; }
        public List<Dependencies> Dep { get; set; }
        public List<ResourcePlan> ResP { get; set; }
        public List<FinancialPlan> FinP { get; set; }
        public List<QualityPlan> QuaP { get; set; }
        public List<CompletionCriteria> CompC { get; set; }
        public List<Risks> Risk { get; set; }
        public List<Issues> Issuess { get; set; }

        public class Deliverables
        {
            public string Deliverable { get; set; }
            public string Components { get; set; }
            public string Description { get; set; }
        }

        public class Customers
        {
            public string CustomerGroup { get; set; }
            public string CustomerRepresentative { get; set; }
        }

        public class Stakeholders
        {
            public string StakeholdersGroup { get; set; }
            public string StakeholderInterest { get; set; }
        }

        public class Roles
        {
            public string Role { get; set; }
            public string ResourceName { get; set; }
            public string Organization { get; set; }
            public string AssignmentStatus { get; set; }
            public string AssignmentDate { get; set; }
        }

        public class Approach
        {
            public string Phase { get; set; }
            public string OverallApproach { get; set; }
        }

        public class Milestones
        {
            public string Milestone { get; set; }
            public string Date { get; set; }
            public string Description { get; set; }
}

        public class Dependencies
        {
            public string ProjectActivity { get; set; }
            public string Impacts { get; set; }
            public string ImpactedBy { get; set; }
            public string Critically { get; set; }
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

        public class Risks
        {   
            public string RiskDesc { get; set; }
            public string RiskLikelihood { get; set; }
            public string RiskImpact { get; set; }
            public string Action { get; set; }
}

        public class Issues
        {
            public string IssueDescription{ get; set; }
            public string IssuePriority{ get; set; }
            public string Action { get; set; }
        }

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

        
    }
}
