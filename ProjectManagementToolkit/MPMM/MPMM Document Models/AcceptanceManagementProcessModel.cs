using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Models
{
    class AcceptanceManagementProcessModel
    {
        public string ProjectName { get; set; }

        public string DocumentID { get; set; }

        public string DocumentOwner { get; set; }

        public string IssueDate { get; set; }

        public string LastSavedDate { get; set; }

        public string FileName { get; set; }

        public List<DocumentHistory> DocumentHistories { get; set; }

        public List<DocumentApproval> DocumentApprovals { get; set; }

        public string AcceptanceprocessDescription { get; set; }

        public string AcceptanceprocessOverview { get; set; }

        public string AcceptanceprocessCompleteDeliverable { get; set; }

        public string AcceptanceprocessCompleteAcceptanceTest { get; set; }

        public string AcceptanceprocessAcceptDeliverable { get; set; }

        public string AcceptancerolesDescription { get; set; }

        public string AcceptancerolesProjectManager { get; set; }

        public string AcceptancerolesCustomer { get; set; }

        public string AcceptancedocumentsDescription { get; set; }

        public string AcceptancedocumentsAcceptanceForm { get; set; }

        public string AcceptancedocumentsAcceptanceRegister { get; set; }

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
