using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Models
{
    class ChangeManagementProcessModel
    {
        public string projectName { get; set; }
        public List<DocumentInformation> documentInformations { get; set; }
        public List<DocumentHistory> documentHistories { get; set; }
        public List<DocumentApproval> documentApprovals { get; set; }
        //Change Process tab
        public string changeProcessDescription { get; set; }
        public string changeProcessOverview { get; set; }
        public string changeProcessIdentifyChange { get; set; }
        public string changeProcessReviewChange { get; set; }
        public string changeProcessApproveChange { get; set; }
        public string changeProcessImplementChange { get; set; }
        //Change Roles
        public string changeRolesDescription { get; set; }
        public string changeRolesTeamMember { get; set; }
        public string changeRolesProjectManager { get; set; }
        public string changeRolesProjectBoard { get; set; }
        //Change Document
        public string changeDocumentDescription { get; set; }
        public string changeDocumentChangeRequestForm { get; set; }
        public string changeDocumentChangeRegister { get; set; }

        public class DocumentInformation
        {
            private string type { get; set; }
            private string information { get; set; }

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
            private DateTime approvalDate { get; set; }

        }
    }
}
