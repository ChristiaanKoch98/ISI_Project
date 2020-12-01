using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Models
{
    class PhaseReviewFormExecutionModel
    {
        public string ProjectName { get; set; }
        public string ProjectManager { get; set; }
        public string ProjectSponsor { get; set; }
        public string ReportPreparedBy { get; set; }
        public string ReportPreparationDate { get; set; }

        public string Recipients { get; set; }

        public string Summary { get; set; }
        public string ProjectSchedule { get; set; }
        public string ProjectExpenses { get; set; }
        public string ProjectDeliverables { get; set; }
        public string ProjectRisks { get; set; }
        public string ProjectIssues { get; set; }
        public string ProjectChanges { get; set; }

        public string eportingPeriod { get; set; }

        public List<ReviewDetial> ReviewDetials { get; set; }
        public string SupportingDocumentation { get; set; }
        public string Signature { get; set; }
        public string SignatureDate { get; set; } 

        public class ReportingPeriod 
        {
            public DateTime StartingDate { get; set; }
            public DateTime EndDate { get; set; }
        }

        public class ReviewDetial
        {
            public string ReviewCategory { get; set; }
            public string ReviewQuestion { get; set; }
            public bool Answer { get; set; }
            public string Varaince { get; set; }
        }
    }
}
