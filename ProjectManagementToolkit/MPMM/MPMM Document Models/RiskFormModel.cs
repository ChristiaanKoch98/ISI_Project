using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Models
{
    class RiskFormModel
    {
        public string ProjectName { get; set; }
        public string ProjectManager { get; set; }
        public string RiskID { get; set; }
        public string RaisedBy { get; set; }
        public DateTime DateRaised { get; set; }
        public string RiskDescription { get; set; }
        public string RiskLikelihood { get; set; }
        public string RiskImpact { get; set; }
        public string RiskMitigationList { get; set; }
        public string RiskRecommendedActions { get; set; }
        public string SupportingDocumentation { get; set; }
        public string Signature { get; set; }
        public string SignatureDate { get; set; }


    }

}
