using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementToolkit.Classes
{
    //AcceptanceFormModel
    class AcceptanceFormModel
    {
        //Project details
        public string AcceptanceFormFor { get; set; }
        public string ProjectName { get; set; }
        public string ProjectManager { get; set; }
        //Acceptance details
        public int AcceptanceId { get; set; }
        public string RequestedBy { get; set; }
        public string DateRequired { get; set; }
        public string Description { get; set; }
        //Acceptance criteria
        public string  Criteria { get; set; }
        public string Standards { get; set; }
        //Acceptance Results
        public string AcceptanceResults { get; set; }
        //Customer approval
        public string SupportingDocumentation { get; set; }
        public List<ChildAcceptanceFormModel> acceptanceForm { get; set; } = new List<ChildAcceptanceFormModel>();


    }

    class ChildAcceptanceFormModel
    {
        public string Acceptance { get; set; }
        public string Method { get; set; }
        public string Reviewer { get; set; }
        public string Date { get; set; }
        public string Result { get; set; }

    }
}
