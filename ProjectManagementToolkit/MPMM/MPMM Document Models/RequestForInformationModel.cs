using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Models
{
    class RequestForInformationModel
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

        #region Introduction
        public string introOverview { get; set; }
        public string introPurpose { get; set; }
        public string introAcknowledgement { get; set; }
        public string introRecipients { get; set; }
        public string introProcess { get; set; }
        public string introRules { get; set; }
        public string introQuestions { get; set; }
        #endregion

        #region Company
        public List<string> companyOverview { get; set; }
        public List<string> companyOffering { get; set; }
        #endregion

        #region Approach
        public List<string> approachMethod { get; set; }
        public List<string> approachTimeframes { get; set; }
        public List<string> approachPricing { get; set; }
        #endregion

        #region Other
        public List<string> otherConfidentiality { get; set; }
        public List<string> otherDocumentation { get; set; }
        #endregion
    }
}
