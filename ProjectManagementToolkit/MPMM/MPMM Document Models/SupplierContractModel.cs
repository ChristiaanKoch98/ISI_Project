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
        public string IssueDate { get; set; }
        public string LastSavedDate { get; set; }
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

        public string Disputes { get; set; }
        public string Indemnity { get; set; }
        public string Law { get; set; }
        public string Agreement { get; set; }


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

        public class Definition
        {
            public string Term { get; set; }
            public string definition { get; set; }

            public Definition(string term, string definition) 
            {
                this.Term = term;
                this.definition = definition;
            }
        }

        public class ProcurementItem
        {
            public string ItemName { get; set; }
            public string ItemDescription { get; set; }
            public string ItemQuantity { get; set; }
            public string ItemPrice { get; set; }

            public ProcurementItem(string itemName, string itemDescription, string itemQuantity, string itemPrice)
            {
                this.ItemName = itemName;
                this.ItemDescription = itemDescription;
                this.ItemQuantity = itemQuantity;
                this.ItemPrice = itemPrice;
            }
        }

        public class ReviewCriteria
        {
            public string Criteria { get; set; }
            public string Description { get; set; }

            public ReviewCriteria(string criteria, string description)
            {
                this.Criteria = criteria;
                this.Description = description;
            }
        }
    }
}
