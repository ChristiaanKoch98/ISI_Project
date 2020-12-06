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

        public string SupportingDocuments { get; set; }

        public string Signature { get; set; }
    }
}
