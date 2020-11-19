using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Models
{
    class CommunicationsPlanModel
    {
        public List<Stakeholder> StakeholderReq { get; set; }



        public string ProjectName { get; set; }
        public string DocumentID { get; set; }
        public string DocumentOwner { get; set; }
        public string IssueDate { get; set; }
        public string LastSavedDate { get; set; }
        public string FileName { get; set; }
        public List<DocumentHistory> DocumentHistories { get; set; }
        public List<DocumentApproval> DocumentApprovals { get; set; }

        public string ComPlan;
        public string Assumptions;

        public string ComProcess;
        public string Activities;
        public string Roles;
        public string Documents;

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

        public class Stakeholder
        {
            public string StakeholderName { get; set; }
            public string StakeholderRole { get; set; }
            public string StakeholderOrganization { get; set; }
            public string InformationRequirement { get; set; }

        }

        public class Phase
        {
            public string PhaseTitle { get; set; }
            public string PhaseDescription { get; set; }
            public string PhaseSequence { get; set; }
        }
    }
}
