using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Models
{
    class ProjectClosureReportModel
    {
        public string ProjectName { get; set; }
        public string DocumentID { get; set; }
        public string DocumentOwner { get; set; }
        public string IssueDate { get; set; }
        public string LastSavedDate { get; set; }
        public string FileName { get; set; }
        public List<DocumentHistory> DocumentHistories { get; set; }
        public List<DocumentApproval> DocumentApprovals { get; set; }
        public string ProjectCompletionDescription { get; set; }
        public List<CompletionCriteria> CompletionCriterion { get; set; }
        public List<OutstandingItem> OutstandingItems { get; set; }
        public string ProjectClosureDescription { get; set; }
        public List<Deliverable> Deliverables { get; set; }
        public List<Documentation> Documentations { get; set; }
        public List<Supplier> Suppliers { get; set; }
        public List<Resource> Resources { get; set; }
        public List<Communication> Communications { get; set; }
        public string ApprovalName { get; set; }
        public string ApprovalRole { get; set; }
        public string ApprovalSignature { get; set; }
        public string ApprovalDate { get; set; }

        public class DocumentHistory
        {
            public string Version { get; set; }
            public string IssueDate { get; set; }
            public string Changes { get; set; }

            public DocumentHistory(string version, string issueDate, string changes)
            {
                this.Changes = changes;
                this.Version = version;
                this.IssueDate = issueDate;
            }
        }
        public class DocumentApproval
        {
            public string Role { get; set; }
            public string Name { get; set; }
            public string Signature { get; set; }
            public string DateApproved { get; set; }

            public DocumentApproval(string role, string name, string signature, string date)
            {
                this.Role = role;
                this.Name = name;
                this.Signature = signature;
                this.DateApproved = date;
            }
        }

        public class CompletionCriteria
        {
            public string CompletionCategory { get; set; }
            public string completionCriteria { get; set; }
            public string Satisfied { get; set; }

            public CompletionCriteria(string completionCategory, string completionCriteria, string statisfied)
            {
                this.CompletionCategory = completionCategory;
                this.completionCriteria = completionCriteria;
                this.Satisfied = statisfied;
            }
        }

        public class OutstandingItem
        {
            public string outstandingItem { get; set; }
            public string ActionRequired { get; set; }
            public string CompletionDate { get; set; }

            public OutstandingItem(string outstandingItem, string actionRequired, string completionDate)
            {
                this.outstandingItem = outstandingItem;
                this.ActionRequired = actionRequired;
                this.CompletionDate = completionDate;
            }

        }
        public class Deliverable
        {
            public string ProjectDeliverable { get; set; }
            public string ActionRequired { get; set; }
            public string CompletionDate { get; set; }

            public Deliverable(string projectDeliverable, string actionRequired, string completionDate)
            {
                this.ProjectDeliverable = projectDeliverable;
                this.ActionRequired = actionRequired;
                this.CompletionDate = completionDate;
            }
        }

        public class Documentation
        {
            public string ProjectDocument { get; set; }
            public string ActionRequired { get; set; }
            public string CompletionDate { get; set; }

            public Documentation(string projectDocument, string actionRequired, string completionDate)
            {
                this.ProjectDocument = projectDocument;
                this.ActionRequired = actionRequired;
                this.CompletionDate = completionDate;
            }
        }

        public class Supplier
        {
            public string SupplierContract { get; set; }
            public string ActionRequired { get; set; }
            public string CompletionDate { get; set; }

            public Supplier(string supplierContract, string actionRequired, string completionDate)
            {
                this.SupplierContract = supplierContract;
                this.ActionRequired = actionRequired;
                this.CompletionDate = completionDate;
            }
        }
        public class Resource
        {
            public string ProjectResource { get; set; }
            public string ActionRequired { get; set; }
            public string CompletionDate { get; set; }
            public Resource(string projectResource, string actionRequired, string completionDate)
            {
                this.ProjectResource = projectResource;
                this.ActionRequired = actionRequired;
                this.CompletionDate = completionDate;
            }
        }
        public class Communication
        {
            public string Audience { get; set; }
            public string Message { get; set; }
            public string Method { get; set; }
            public string CommunicationDate { get; set; }

            public Communication(string audience, string message, string method, string communicationDate)
            {
                this.Audience = audience;
                this.Message = message;
                this.Method = method;
                this.CommunicationDate = communicationDate;
                
            }
        }
    }
}
