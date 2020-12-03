using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Models
{
    class QualityReviewPlanModel
    {
        public string ProjectName { get; set; }
        public string QualityOfProcessDescription { get; set; }

        public List<QualityOfProcess> QualityOfProcesses { get; set; }

        public string QualityOfDeliverablesDescription { get; set; }
        public List<QualityOfDeliverable> QualityOfDeliverables { get; set; }
        public class QualityOfProcess
        {
            public string Process { get; set; }
            public string Procedure { get; set; }
            public string StandardMet { get; set; }
            public string Deviation { get; set; }
            public string CorrectiveAction { get; set; }
        }

        public class QualityOfDeliverable
        {
            public string Requirement { get; set; }
            public string Deliverable { get; set; }
            public string QualityCriteria { get; set; }
            public string QualityStandard { get; set; }
            public string StandardMet { get; set; }
            public string QualityDeviation { get; set; }
            public string CorrectiveActionsRequired { get; set; }

        }

    }
}
