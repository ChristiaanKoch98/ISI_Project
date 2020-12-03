using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Models
{
    class IssueManagementProcessModel
    {
        public string ProjectName { get; set; }
        public string DocumentID { get; set; }
        public string DocumentOwner { get; set; }
        public string IssueDate { get; set; }

        public string LastSavedDate { get; set; }

        public string FileName { get; set; }

        public List<DocumentHistory> DocumentHistories { get; set; }

        public List<DocumentApproval> DocumentApprovals { get; set; }

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

        public string Overview { get; set; }

        public string RaiseIssue { get; set; }

        public string ReviewIssue { get; set; }

        public string IssueAction { get; set; }

        public string TeamMember { get; set; }

        public string ProjectManager { get; set; }

        public string ProjectBoard { get; set; }

        public string IssueForm { get; set; }

        public string IssueRegister { get; set; }
    }
}
