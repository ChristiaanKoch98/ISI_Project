using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Models
{
    class QualityRegisterModel
    {
        
            public List<ConformanceOfProcess> ConformanceOfProcesses;
            public List<QualityOfDeliverable> QualityOfDeliverables;

            public class ConformanceOfProcess
            {
                public string ID { get; set; }
                public string Process { get; set; }
                public string Procedure { get; set; }
                public string StandardMet { get; set; }
                public string Deviation { get; set; }
                public string CorrectiveAction { get; set; }
                public string Methods { get; set; }
                public string Date { get; set; }
                public string Outcome { get; set; }

            }

            public class QualityOfDeliverable
            {
                public string ID { get; set; }
                public string Requirement { get; set; }
                public string Deliverable { get; set; }
                public string Criteria { get; set; }
                public string Standards { get; set; }
                public string MeetStandards { get; set; }
                public string Deviation { get; set; }
                public string CorrectiveAction { get; set; }
                public string Methods { get; set; }
                public string Date { get; set; }
                public string Outcome { get; set; }
            }
        

        
    }
}
