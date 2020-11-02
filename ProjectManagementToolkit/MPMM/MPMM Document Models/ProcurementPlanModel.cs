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

        #region Procurement requirements
        public class DocumentRequirements
        {
            public string item { get; set; }
            public string description { get; set; }
            public string justification { get; set; }
            public string quantity { get; set; }
            public string budget { get; set; }
        }

        List<DocumentRequirements> documentRequirements { get; set; }

        public class DocumentMarketResearch
        {
            public string item { get; set; }
            public string supplier { get; set; }
            public string offering { get; set; }
            public double price { get; set; }
            public string availability { get; set; }
        }

        List<DocumentMarketResearch> documentMarketResearch { get; set; }
        #endregion

        #region Procurement Plan
        //TODO add gant chart image

        public string assumptions { get; set; }
        public string constraints { get; set; }
        #endregion

        #region Tender Process
        public string tenderProcess { get; set; }
        public string tenderActivities { get; set; }
        public string tenderRoles { get; set; }
        public string tenderDocuments { get; set; }
        #endregion

        #region Procurement Process
        public string procurementProcess { get; set; }
        public string procurementActivities { get; set; }
        public string procurementRoles { get; set; }
        public string procurementDocuments { get; set; }
        #endregion
    }
}
