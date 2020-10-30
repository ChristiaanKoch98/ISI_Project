using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Models
{
    class StatementOfWorkModel
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


        public string Objectives { get; set; }


        public List<ScopeOfWork> ScopeOfWorks { get; set; }


        public string SupplierResponsibilities { get; set; }


        public string ProjectResponsibilities { get; set; }


        public string AcceptanceTerms { get; set; }


        public string PaymentTerms { get; set; }


        public string Confidentiality { get; set; }


        public string OtherTerms { get; set; }


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

        public class ScopeOfWork
        {

            public string ItemTitle { get; set; }

            public string ItemDescription { get; set; }

            public string ItemQuantity { get; set; }


        }
    }
}
