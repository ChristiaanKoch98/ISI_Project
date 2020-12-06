using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Models
{
    class AcceptanceRegisterModel
    {
        public List<AcceptanceEntry> AcceptanceEntries { get; set; }
        public class AcceptanceEntry
        {
            public int ID { get; set; }
            public string DeliverableName { get; set; } = "";
            public string DeliverableDescription { get; set; } = "";
            public string DeliverableStatus { get; set; } = "";
            public string AcceptanceCriteria { get; set; } = "";
            public string AcceptanceStandards { get; set; } = "";
            public string AcceptanceTestMethod { get; set; } = "";
            public string AcceptanceTestReviewer { get; set; } = "";
            public string AcceptanceTestDate { get; set; } = "";
            public string AcceptanceResults { get; set; } = "";
            public string AcceptanceResultsStatus { get; set; } = "";
        }
    }
}
