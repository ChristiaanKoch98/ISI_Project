using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Models
{
    class ChangeManagementProcessModel
    {
        public string ProjectName { get; set; }
        public string DocumentID { get; set; }
        public string DocumentOwner { get; set; }
        public string IssueDate { get; set; }
        public string LastSavedDate { get; set; }
        public string FileName { get; set; }
        public List<DocumentHistory> DocumentHistories { get; set; }
        public List<DocumentApproval> DocumentApprovals { get; set; }
        //Change Process tab
        public string ChangeProcessDescription { get; set; }
        public string ChangeProcessOverview { get; set; }
        public string ChangeProcessIdentifyChange { get; set; }
        public string ChangeProcessReviewChange { get; set; }
        public string ChangeProcessApproveChange { get; set; }
        public string ChangeProcessImplementChange { get; set; }
        //Change Roles
        public string ChangeRolesDescription { get; set; }
        public string ChangeRolesTeamMember { get; set; }
        public string ChangeRolesProjectManager { get; set; }
        public string ChangeRolesProjectBoard { get; set; }
        //Change Document
        public string ChangeDocumentDescription { get; set; }
        public string ChangeDocumentChangeRequestForm { get; set; }
        public string ChangeDocumentChangeRegister { get; set; }

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
