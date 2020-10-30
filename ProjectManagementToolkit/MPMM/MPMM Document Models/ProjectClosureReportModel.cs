using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Models
{
    class ProjectClosureReportModel
    {
        public string projectName { get; set; }
        public List<DocumentInformation> documentInformation {get; set;}
        public List<DocumentApproval> documentApproval { get; set; }
        public string projectCompletionDescription { get; set; }
        public List<CompletionCriteria> completionCriteria { get; set; }
        public List<OutstandingItem> outstandingItems { get; set; }
        public string projectClosureDescription { get; set; }
        public List<Deliverable> deliverables { get; set; }
        public List<Documentation> documentation { get; set; }
        public List<Supplier> suppliers { get; set; }
        public List<Resource> resources { get; set; }
        public List<Communication> communications { get; set; }
        public string approvalName { get; set; }
        public string approvalRole { get; set; }
        public string approvalSignature { get; set; }
        public DateTime approvalDate { get; set; }
        public class DocumentInformation
        {
            private string documentType { get; set; }
            private string documentInformation { get; set; }

        }

        public class DocumentHistory
        {
            private string version { get; set; }
            private DateTime issueDate { get; set; }
            private string changes { get; set; }

        }

        public class DocumentApproval
        {
            private string role { get; set; }
            private string name { get; set; }
            private string signature { get; set; }
            private DateTime date { get; set; }

        }

        public class CompletionCriteria
        {
            private string completionCategory { get; set; }
            private string completionCriteria { get; set; }
            private bool satisfied { get; set; }
        }

        public class OutstandingItem
        {
            private string outstandingItem { get; set; }
            private string actionRequired { get; set; }
            private DateTime completionDate { get; set; }

        }
        public class Deliverable
        {
            private string projectDeliverable { get; set; }
            private string actionRequired { get; set; }
            private DateTime completionDate { get; set; } 
        }

        public class Documentation
        {
            private string projectDocument { get; set; }
            private string actionRequired { get; set; }
            private DateTime completionDate { get; set; }
        }

        public class Supplier
        {
            private string supplierContract { get; set; }
            private string actionRequired { get; set; }
            private DateTime completionDate { get; set; }
        }
        public class Resource
        {
            private string projectResource { get; set; }
            private string actionRequired { get; set; }
            private DateTime completionDate { get; set; }
        }
        public class Communication
        {
            private string audience { get; set; }
            private string message { get; set; }
            private string method { get; set; }
            private DateTime communicationDate { get; set; }
        }
    }
}
