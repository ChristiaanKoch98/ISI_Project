using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Models
{
    class QualityReviewPlanModel
    {
        public string projectName { get; set; }
        public string qualityOfProcessDescription { get; set; }

        public List<QualityOfProcess> qualityOfProcesses { get; set; }

        public string qualityOfDeliverablesDescription { get; set; }
        public List<QualityOfDeliverable> qualityOfDeliverables { get; set; }
        public class QualityOfProcess
        {
            private string process { get; set; }
            private string procedure { get; set; }
            private bool standardMet { get; set; }
            private string deviation { get; set; }
            private string correctiveAction { get; set; }
        }

        public class QualityOfDeliverable
        { 
            private string requirement { get; set; }
            private string deliverable { get; set; }
            private string qualityCriteria { get; set; }
            private string qualityStandard { get; set; }
            private bool standardMet { get; set; }
            private string qualityDeviation { get; set; }
            private string correctiveActionsRequired { get; set; }

        }

    }
}
