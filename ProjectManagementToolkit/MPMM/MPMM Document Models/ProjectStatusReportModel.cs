using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Models
{
    class ProjectStatusReportModel
    {
        public string ProjectName { get; set; }
        public string ProjectID { get; set; }
        public string ProjectManager { get; set; }
        public string ProjectSponsor { get; set; }
        public string ReportPreparedBy { get; set; }
        public DateTime ReportPreparationDate { get; set; }
        public string Recipients { get; set; }

        public string ProjectDescription { get; set; }
        public string OverallStatus { get; set; }
        public string ProjectSchedule { get; set; }
        public string ProjectExpenses { get; set; }
        public string ProjectDeliverables { get; set; }
        public string ProjectRisks { get; set; }
        public string ProjectIssues { get; set; }
        public string ProjectChanges { get; set; }

        public string DSSchedule { get; set; }
        public string DSExpenses { get; set; }
        public string DSEffort { get; set; }
        public string DSRisks { get; set; }
        public string DSIssues { get; set; }
        public string DSQuality { get; set; }

        public List<ReviewDetial> ReviewDetials { get; set; }
        public string SupportingDocumentation { get; set; }
        public string Signature { get; set; }
        public DateTime SignatureDate { get; set; } 

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
