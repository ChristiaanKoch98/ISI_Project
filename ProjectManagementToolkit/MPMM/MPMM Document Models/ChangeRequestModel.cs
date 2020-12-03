using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Models
{
    class ChangeRequestModel
    {
        public string ProjectName { get; set; }


        public string ProjectManager { get; set; }


        public string ChangeNumber { get; set; }


        public string ChangeRequester { get; set; }

        public string ChangeRequestDate { get; set; }


        public string ChangeUrgancy { get; set; }


        public string ChangeDescription { get; set; }


        public string ChangeDrivers { get; set; }


        public string ChangeBenefits { get; set; }


        public string ChangeCost { get; set; }


        public string ProjectImpact { get; set; }


        public List<SupportingDocument> SupportingDocuments { get; set; }

        public class SupportingDocument
        {
            public string DocumentName { get; set; }
            public string DocumentDescription { get; set; }
        }

        public string SubmittedName { get; set; }
        public string SubmittedRole { get; set; }
        public string SubmittedSignature { get; set; }
        public string SubmittedDate { get; set; }

        public string ApprovedName { get; set; }
        public string ApprovedRole { get; set; }
        public string ApprovedSignature { get; set; }
        public string ApprovedDate { get; set; }
    }
}
