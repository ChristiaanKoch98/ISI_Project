using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Models
{
    class AcceptancePlanModel
    {
        #region Title
        public string projectName { get; set; }
        #endregion

        #region Document information
        public string documentID { get; set; }
        public string documentOwner { get; set; }
        public DateTime issueDate { get; set; }
        public DateTime lastSavedDate { get; set; }
        public string fileName { get; set; }
        #endregion

        #region Document History
        public class DocumentHistory
        {
            public string version { get; set; }
            public DateTime issueDate { get; set; }
            public string changes { get; set; }
        }

        public List<DocumentHistory> documentHistories { get; set; }
        #endregion

        #region Document Approvals
        public class DocumentApprovals
        {
            public string role { get; set; }
            public string mame { get; set; }
            public string changes { get; set; }
            public DateTime date { get; set; }

        }

        public List<DocumentApprovals> documentApprovals { get; set; }
        #endregion

        #region Milestones
        public class DocumentMilestones
        {
            public string name { get; set; }
            public string description { get; set; }
            public DateTime date { get; set; }

        }

        public List<DocumentMilestones> documentMilestones { get; set; }
        #endregion

        #region Criteria
        public class DocumentCriteria
        {
            public string name { get; set; }
            public string criteria { get; set; }
            public string acceptanceStandards { get; set; }

        }

        public List<DocumentCriteria> documentCriterias { get; set; }
        #endregion

        #region Schedule
        public class DocumentSchedule
        {
            public string milestone { get; set; }
            public string deliverables { get; set; }
            public DateTime milestoneDate { get; set; }
            public string reviewMethod { get; set; }
            public string reviewers { get; set; }
            public DateTime acceptanceDate { get; set; }
        }

        public List<DocumentSchedule> documentSchedules { get; set; }
        #endregion

        #region assumptions, constraints, accptance process, activities, roles, documents
        public string assumptions { get; set; }
        public string constraints { get; set; }
        public string acceptanceProcess { get; set; }
        public string activites { get; set; }
        public string roles { get; set; }
        public string documents { get; set; }
        #endregion
    }
}
