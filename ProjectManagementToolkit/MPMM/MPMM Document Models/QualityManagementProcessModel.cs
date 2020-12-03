using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Models
{
    class QualityManagementProcessModel
    {
        public string ProjectName { get; set; }

        public string DocumentID { get; set; }

        public string DocumentOwner { get; set; }

        public string IssueDate { get; set; }

        public string LastSavedDate { get; set; }

        public string FileName { get; set; }

        public List<DocumentHistory> DocumentHistories { get; set; }

        public List<DocumentApproval> DocumentApprovals { get; set; }

        public string QualityprocessDescription { get; set; }

        public string QualityprocessOverview { get; set; }

        public string QualityprocessMeasureQualityAchieved { get; set; }

        public string QualityprocessEnhanceQualityAchieved { get; set; }

        public string QualitymanagementrolesDescription { get; set; }

        public string QualitymanagementrolesQualityManager { get; set; }

        public string QualitymanagementrolesProjectManager { get; set; }

        public string QualitymanagementdocumentsDescription { get; set; }

        public string QualitymanagementdocumentsQualityRegister { get; set; }

        public string QualitymanagementdocumentsQualityReviewForm { get; set; }


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
    }
}
