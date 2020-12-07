using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Models
{
    class IssueRegisterModel
    {
        public List<IssueEntry> IssueEntries { get; set; }
        public class IssueEntry
        {
            public string ID { get; set; }
            public string DateRaised { get; set; } = "";
            public string RaisedBy { get; set; } = "";
            public string ReceivedBy { get; set; } = "";
            public string Description { get; set; } = "";
            public string Impact { get; set; } = "";
            public string Priority { get; set; } = "";
            public string Action { get; set; } = "";
            public string Owner { get; set; } = "";
            public string Outcome { get; set; } = ""; 
            public string DateForResolution { get; set; } = "";
            public string DateResolved { get; set; } = "";
        }
    }
}
