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
        public string companyOverview { get; set; }
        public string companyOffering { get; set; }
        #endregion

        #region Approach
        public string approachMethod { get; set; }
        public string approachTimeframes { get; set; }
        public string approachPricing { get; set; }
        #endregion

        #region Other
        public string otherConfidentiality { get; set; }
        public string otherDocumentation { get; set; }
        #endregion
    }
}
