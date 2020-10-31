using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Models
{
    class TimeMangementProcessModel
    {
        public string ProjectName { get; set; }

        public string DocumentID { get; set; }

        public string DocumentOwner { get; set; }

        public DateTime IssueDate { get; set; }

        public DateTime LastSavedDate { get; set; }

        public string FileName { get; set; }

        public List<DocumentHistory> DocumentHistories { get; set; }

        public List<DocumentApproval> DocumentApprovals { get; set; }

        public string TimemanagementprocessDescription { get; set; }

        public string TimemanagementprocessOverview { get; set; }

        public string TimemanagementprocessDocumentTimesheet { get; set; }

        public string TimemanagementprocessApprovedTimesheet { get; set; }

        public string TimemanagementprocessUpdateProcessPlan { get; set; }

        public string TimemanagementrolesDescription { get; set; }

        public string TimemanagementrolesTeamMember { get; set; }

        public string TimemanagementrolesProjectManager { get; set; }

        public string TimemanagementrolesProjectAdminstratror { get; set; }

        public string TimemanagementdocumentsDescription { get; set; }

        public string TimemanagementdocumentsTimeSheet { get; set; }

        public string TimemanagementdocumentsTimeSheetRegister { get; set; }

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
    }
}
