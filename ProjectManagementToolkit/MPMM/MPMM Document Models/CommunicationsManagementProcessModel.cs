using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Models
{
    class CommunicationsManagementProcessModel
    {
        public string ProjectName { get; set; }
        public string DocumentID { get; set; }
        public string DocumentOwner { get; set; }
        public string IssueDate { get; set; }
        public string LastSavedDate { get; set; }
        public string FileName { get; set; }
        public List<DocumentHistory> DocumentHistories { get; set; }
        public List<DocumentApproval> DocumentApprovals { get; set; }

        public string CommunicationsProcessIntro { get; set; }
        public string Overview { get; set; }
        public string CreateMessage { get; set; }
        public string CommunicateMessage { get; set; }
        public string CommunicationsIntro { get; set; }
        public string CommunicationsTeam { get; set; }
        public string ProjectManagerResponsibilities { get; set; }
        public string CommunicationsDocumentsIntro { get; set; }
        public string ProjectStatusReport { get; set; }
        public string CommunicationsRegister { get; set; }

        public class DocumentHistory
        {
            public string Version { get; set; }
            public string IssueDate { get; set; }
            public string Changes { get; set; }

            public DocumentHistory(string version, string date, string changes)
            {
                this.Changes = changes;
                this.Version = version;
                this.IssueDate = date;
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

    }
}
