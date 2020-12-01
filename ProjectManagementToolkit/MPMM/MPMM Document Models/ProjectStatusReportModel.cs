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
        public string ReportPreparationDate { get; set; }
        public string Recipients { get; set; }
        public string PreperationPeriod { get; set; }
        public string PrepDate { get; set; }
        public string RepPeriod { get; set; }
        public string proSchedule { get; set; }

        public string NewProSchedule { get; set; }
        public string ProEx { get; set; }

        public string ProjectDescription { get; set; }
        public string OverallStatus { get; set; }
        public string ESProjectSchedule { get; set; }
        public string ProjectDeliverables { get; set; }
        public string ProjectRisks { get; set; }
        public string textProjectIssues { get; set; }
        public string ProjectChanges { get; set; }


        public List<ProjectSchedule> ProSchedule { get; set; }
        public List<ProjectExpenses> ProjExpenses { get; set; }
        public List<ProjectEffort> ProjEffort { get; set; }
        public List<ProjectQuality> ProjQuality { get; set; }
        public List<ProjectRisk> ProjRisk { get; set; }
        public List<ProjectIssues> NProjIssues { get; set; }

        public class ProjectSchedule
        {
            public string Deliverable { get; set; }
            public string ScheduledCompletionDate { get; set; }
            public string ActualCompletionDate { get; set; }
            public string ActualVariance { get; set; }
            public string ForecastCompletionDate { get; set; }
            public string ForecastVariance { get; set; }
            public string Summary { get; set; }
        }

        public class ProjectExpenses
        {
            public string ExpenseType { get; set; }
            public string BudgetedExpenditure { get; set; }
            public string ActualExpenditure { get; set; }
            public string ActualVariance { get; set; }
            public string ForecastExpenditure { get; set; }
            public string ForecastVariance { get; set; }
            public string Summary { get; set; }
        }

        public class ProjectEffort
        {
            public string Activities { get; set; }
            public string BudgetedEffort { get; set; }
            public string ActualEffort { get; set; }
            public string ActualVariance { get; set; }
            public string ForecastEffort { get; set; }
            public string ForecastVariance { get; set; }
            public string Summary { get; set; }
        }

        public class ProjectQuality
        {
            public string Deliverables { get; set; }
            public string QualityTarget { get; set; }
            public string QualityAchieved { get; set; }
            public string QualityVariance { get; set; }
            public string Summary { get; set; }
        }

        public class ProjectRisk
        {
            public string Risks { get; set; }
            public string Likelihood { get; set; }
            public string Impact { get; set; }
            public string Summary { get; set; }
        }

        public class ProjectIssues
        {
            public string Issues { get; set; }
            public string Impact { get; set; }
            public string Summary { get; set; }
        }

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
