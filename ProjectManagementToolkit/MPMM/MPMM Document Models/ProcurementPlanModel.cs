using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Models
{
    class ProcurementPlanModel
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

        #region Procurement requirements
        public class DocumentRequirements
        {
            public string item { get; set; }
            public string description { get; set; }
            public string justification { get; set; }
            public string quantity { get; set; }
            public string budget { get; set; }
        }

       public  List<DocumentRequirements> documentRequirements { get; set; }

        public class DocumentMarketResearch
        {
            public string item { get; set; }
            public string supplier { get; set; }
            public string offering { get; set; }
            public string price { get; set; }
            public string availability { get; set; }
        }

        public List<DocumentMarketResearch> documentMarketResearch { get; set; }
        #endregion

        #region Procurement Plan
        //TODO add gant chart image

        public List<string> assumptions { get; set; }
        public List<string> constraints { get; set; }
        #endregion

        #region Tender Process
        public List<string> tenderActivities { get; set; }
        public List<string> tenderRoles { get; set; }
        public List<string> tenderDocuments { get; set; }
        #endregion

        #region Procurement Process
        public List<string> procurementActivities { get; set; }
        public List<string> procurementRoles { get; set; }
        public List<string> procurementDocuments { get; set; }
        #endregion
    }
}
