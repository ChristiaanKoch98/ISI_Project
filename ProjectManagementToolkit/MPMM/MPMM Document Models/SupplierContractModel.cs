using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Models
{
    class SupplierContractModel
    {
        public string ProjectName { get; set; }
        public string DocumentID { get; set; }
        public string DocumentOwner { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime LastSavedDate { get; set; }
        public string FileName { get; set; }
        public List<DocumentHistory> DocumentHistories { get; set; }
        public List<DocumentApproval> DocumentApprovals { get; set; }
        public string Introduction { get; set; }
        public string Purpose { get; set; }
        public string Recipients { get; set; }
        public List<Definition> Definitions { get; set; }
        public List<ProcurementItem> ProcurementItems { get; set; }
        public string DeliverySchedule { get; set; }
        public string Supplier { get; set; }
        public string Project { get; set; }
        public string Performance { get; set; }
        public List<ReviewCriteria> ReviewCriterion { get; set; }
        public string ReviewSchedule { get; set; }
        public string ReviewProcess { get; set; }
        public string TermAndConditions { get; set; }
        public string Payment { get; set; }
        public string Invoicing { get; set; }
        public string Confidentiality { get; set; }
        public string Termination { get; set; }
        public string Indemnity { get; set; }
        public string Law { get; set; }
        public string Agreement { get; set; }


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

        public class Definition
        {
            public string Term { get; set; }
            public string definition { get; set; }

        }

        public class ProcurementItem
        {
            public string ItemName { get; set; }
            public string ItemDescription { get; set; }
            public string ItemQuantity { get; set; }
            public string ItemPrice { get; set; }
        }

        public class ReviewCriteria
        {
            public string Criteria { get; set; }
            public string Description { get; set; }
        }
    }
}
