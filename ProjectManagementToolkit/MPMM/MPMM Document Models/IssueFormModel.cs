using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Models
{

    class IssueFormModel
    {
        public string ProjectName { get; set; } = "";
        public string ProjectManagerName { get; set; } = "";
        public string IssueID { get; set; } = "";
        public string RaisedBy { get; set; } = "";
        public string DateRaised { get; set; } = DateTime.Now.ToString();
        public string IssueDescription { get; set; } = "";
        public string IssueImpact { get; set; } = "";
        public string IssueResolution { get; set; } = "";
        public string SupportingDocumentation { get; set; } = "";
    }
}
