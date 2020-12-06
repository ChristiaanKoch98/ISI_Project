using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Models
{
    class RiskRegisterModel
    {
        public List<RiskEntry> IssueEntries { get; set; }
        public class RiskEntry
        {
            public int ID { get; set; }
            public string DateRaised { get; set; } = "";
            public string RaisedBy { get; set; } = "";
            public string ReceivedBy { get; set; } = "";
            public string DescriptionRisk { get; set; } = "";
            public string DescriptionImpact { get; set; } = "";
            public string LikelyHoodRating { get; set; } = "";
            public string ImpactRating { get; set; } = "";
            public string PriorityRating { get; set; } = "";
            public string PreventionAction { get; set; } = "";
            public string PreventionOwner { get; set; } = "";
            public string PreventionDate { get; set; } = "";
            public string ContingencyActions { get; set; } = "";
            public string ContingencyOwner { get; set; } = "";
            public string ContingencyDate { get; set; } = "";
        }
    }
}
