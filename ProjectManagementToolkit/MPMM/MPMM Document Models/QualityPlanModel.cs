using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Models
{
    class QualityPlanModel
    {
        #region Title
        public string projectName { get; set; }
        #endregion

        #region Document information
        public string documentID { get; set; }
        public string documentOwner { get; set; }
        public string issueDate { get; set; }
        public string lastSavedDate { get; set; }
        public string fileName { get; set; }
        #endregion

        #region Document History
        public class DocumentHistory
        {
            public string version { get; set; }
            public string issueDate { get; set; }
            public string changes { get; set; }
        }

        public List<DocumentHistory> documentHistories { get; set; }
        #endregion

        #region Document Approvals
        public class DocumentApprovals
        {
            public string role { get; set; }
            public string name { get; set; }
            public string changes { get; set; }
            public string date { get; set; }

        }

        public List<DocumentApprovals> documentApprovals { get; set; }
        #endregion

        #region Quality Targets
        public class DocumentQualityTargets
        {
            public string requirement { get; set; }
            public string deliverable { get; set; }
            public string criteria { get; set; }
            public string standards { get; set; }
        }

        public List<DocumentQualityTargets> documentQualityTargets { get; set; }
        #endregion

        #region Quality assurance plan
        public class DocumentQualityAssurance
        {
            public string technique { get; set; }
            public string description { get; set; }
            public string frequency { get; set; }
        }

        public List<DocumentQualityAssurance> documentQualityAssurances { get; set; }
        #endregion

        #region Quality control plan
        public class DocumentQualityControl
        {
            public string technique { get; set; }
            public string description { get; set; }
            public string frequency { get; set; }
        }

        public List<DocumentQualityControl> documentQualityControls { get; set; }
        #endregion

        #region assumptions, constraints
        public List<string> assumptions { get; set; }
        public List<string> constraints { get; set; }
        #endregion

        #region Quality Process
        public List<string> activites { get; set; }
        public List<string> roles { get; set; }
        public List<string> documents { get; set; }

        #endregion
    }
}
