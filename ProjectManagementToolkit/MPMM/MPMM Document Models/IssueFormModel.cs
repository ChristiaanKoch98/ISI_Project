using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Models
{

    class IssueFormModel
    {
        public string projectName { get; set; }
        public string projectManagerName { get; set; }
        public string issueID { get; set; }
        public string raisedBy { get; set; }
        public DateTime dateRaised { get; set; }
        public string issueDescription { get; set; }
        public string issueImpact { get; set; }
        public string issueResolution { get; set; }
        public string supportingDocumentation { get; set; }
    }
}
