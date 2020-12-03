using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementToolkit.Classes
{
    class RiskPlanModel
    {
        public string ProjectName { get; set; }
        public string Categories { get; set; }
        public string Assumptions { get; set; }
        public string Constraints { get; set; }
        public string Activities { get; set; }
        public string Roles { get; set; }
        public string Documents { get; set; }
        public string Appendix { get; set; }
        public List<Schedule> Schedules { get; set; }
        public List<Risk> Risks { get; set; }
        public List<Likelihood> Likelihoods { get; set; }
        public List<Impact> Impacts { get; set; }
        public Information Information { get; set; }
        public List<History> Histories { get; set; }
        public List<Priority> Priorities { get; set; }
        public List<Approval> Approvals { get; set; }


    }

    class Risk
    {
        public string RiskCategory { get; set; }
        public string RiskDescription { get; set; }
        public string ID { get; set; }
    }
    class Likelihood
    {
        public string Title { get; set; }
        public string Score { get; set; }
        public string Description { get; set; }
    }

    class Impact
    {
        public string Title { get; set; }
        public string Score { get; set; }
        public string Description { get; set; }
    }
    class Priority
    {
        public string ID { get; set; }
        public string LikelihoodScore { get; set; }
        public string ImpactScore { get; set; }
        public string PriorityScore { get; set; }
        public string PriorityRating { get; set; }
    }
    class Schedule
    {
        public string Rating { get; set; }
        public string ID { get; set; }
        public string PrevalantiveActions { get; set; }
        public string ActionResource1 { get; set; }
        public string ActionDate1 { get; set; }
        public string ContingentActions { get; set; }
        public string ActionResource2 { get; set; }
        public string ActionDate2 { get; set; }
        public Information Information { get; set; }

    }

    class Information{
        public string DocumentID { get; set; }
        public string DocumentOwner { get; set; }
        public string IssueDate { get; set; }
        public string LastSavedDate { get; set; }
        public string FileName { get; set; }
    }

    class History
    {
        public string Version { get; set; }
        public string IssueDate { get; set; }
        public string Changes { get; set; }
    }

    class Approval
    {
        public string Name { get; set; }
        public string Role { get; set; }
        public string Signature { get; set; }
        public string Date { get; set; }
    }
}
