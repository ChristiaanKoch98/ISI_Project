using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Models
{
    class SelectionProcessModel
    {
        public string PeriodicMeasurement { get; set; }
        public List<Schedule> Schedules { get; set; }
        public string Resources { get; set; }
        public string Cost { get; set; }
        public List<Labour> Labours { get; set; }
        public List<Equipment> Equipments { get; set; }
        public List<Material> Materials { get; set; }
        public List<ResourcesSchedule> ResourcesSchedules { get; set; }
        public string RiskAssessment { get; set; }
        public List<RiskIdentification> RiskIdentifications { get; set; }
        public List<RiskResponsePlanning> RiskResponsePlannings { get; set; }
        public string RiskMonitoringandControl { get; set; }
        public List<ResourceAvaliabilityandAllocation> ResourceAvaliabilityandAllocations { get; set; }
        public List<StrategyAlingment> StrategyAlingments { get; set; }
        public List<Balancing> Balancings { get; set; }

        public class Schedule
        {
            public string Phase { get; set; }
            public string Activity { get; set; }
            public string Task { get; set; }
            public string Date { get; set; }
        }
        public class Labour
        {
            public string Role { get; set; }
            public string Number { get; set; }
            public string Responsibilities { get; set; }
            public string Skills { get; set; }
            public string StartDate { get; set; }
            public string EndDate { get; set; }
        }
        public class Equipment
        {
            public string Item { get; set; }
            public string Amount { get; set; }
            public string Purpose { get; set; }
            public string Specification { get; set; }
            public string StartDate { get; set; }
            public string EndDate { get; set; }
        }
        public class Material
        {
            public string Item { get; set; }
            public string Amount { get; set; }
            public string StartDate { get; set; }
            public string EndDate { get; set; }
        }
        public class ResourcesSchedule
        {
            public string Resource { get; set; }
            public string Jan { get; set; }
            public string Feb { get; set; }
            public string Mar { get; set; }
            public string Apr { get; set; }
            public string May { get; set; }
            public string Jun { get; set; }
            public string Jul { get; set; }
            public string Aug { get; set; }
            public string Sep { get; set; }
            public string Oct { get; set; }
            public string Nov { get; set; }
            public string Dec { get; set; }
            public string Total { get; set; }
        }
        public class RiskIdentification
        {
            public string RiskDescription { get; set; }
            public string Probability { get; set; }
            public string Likelihood { get; set; }
            public string ImpactofRisk { get; set; }
            public string QualitativQuantative { get; set; }
            public string RiskOwner { get; set; }
        }
        public class RiskResponsePlanning
        {
            public string RiskDescription { get; set; }
            public string RiskCategory { get; set; }
            public string RiskResponseStrategy { get; set; }
        }
        public class ResourceAvaliabilityandAllocation
        {
            public string Avaliability { get; set; }
            public string Allocation { get; set; }
            public string SizeofProject { get; set; }
        }
        public class StrategyAlingment
        {
            public string StrategyPlan { get; set; }
            public string NeedsOppurtunities { get; set; }
            public string SetResources { get; set; }
            public string SetBudgetNeed { get; set; }
            public string SetRiskPosture { get; set; }
        }
        public class Balancing
        {
            public string BalancingofProjects { get; set; }
            public string PurposeandBenefit { get; set; }
            public string OppurtunityBenefitRisk { get; set; }
            public string PurposeBenefit { get; set; }
        }
    }
}
