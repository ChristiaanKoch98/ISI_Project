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
        public DateTime IssueDate { get; set; }
        public DateTime LastSavedDate { get; set; }
        public string FileName { get; set; }
        public List<DocumentHistory> DocumentHistories { get; set; }
        public List<DocumentApproval> DocumentApprovals { get; set; }

        public string ExecutiveSummary { get; set; }

        public string ProjDefinition { get; set; }
        public string Vision { get; set; }
        public string Objectives { get; set; }
        public string Scope { get; set; }
        public string Deliverables { get; set; }

        public string Customers { get; set; }
        public string Stakeholders { get; set; }
        public string Roles { get; set; }
        public string Responsibilities { get; set; }
        public string Structure { get; set; }

        public string Approach { get; set; }
        public string Schedule { get; set; }
        public string Milestones { get; set; }
        public string Dependencies { get; set; }
        public string ResourcePlan { get; set; }
        public string FinancialPlan { get; set; }
        public string QualityPlan { get; set; }
        public string CompletionCriteria { get; set; }

        public string Risks { get; set; }
        public string Issues { get; set; }
        public string Assumptions { get; set; }
        public string Constraints { get; set; }

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
    }
}
