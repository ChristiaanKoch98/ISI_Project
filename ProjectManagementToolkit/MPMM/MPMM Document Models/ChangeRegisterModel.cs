using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Models
{
    public class ChangeRegisterModel
    {
        public List<ChangeEntry> ChangeEntries { get; set; }
        public string ProjectName { get; set; }
        public string ProjectManager { get; set; }

        public class ChangeEntry
        {
            public int ID { get; set; }
            public string DateRaised { get; set; } = "";
            public string RaisedBy { get; set; } = "";
            public string ReceivedBy { get; set; } = "";
            public string Description { get; set; } = "";
            public string ImpactDescription { get; set; } = "";
            public string ImpactRating { get; set; } = "";
            public string ChangeApprover { get; set; } = "";
            public string ApprovalStatus { get; set; } = "";
            public string ApprovalDate { get; set; } = "";
            public string ImplementationResource { get; set; } = "";
            public string ImplementationStatus { get; set; } = "";
            public string ImplementationDate { get; set; } = "";
        }
    }
}
