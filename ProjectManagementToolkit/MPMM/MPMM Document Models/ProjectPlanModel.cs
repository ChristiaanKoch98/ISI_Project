using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Models
{
    class ProjectPlanModel
    {
        public string ProjectName { get; set; }
        public string DocumentID { get; set; }
        public string DocumentOwner { get; set; }
        public string IssueDate { get; set; }
        public string LastSavedDate { get; set; }
        public string FileName { get; set; }
        public List<DocumentHistory> DocumentHistories { get; set; }
        public List<DocumentApproval> DocumentApprovals { get; set; }
        public string WorkBreakDownStructure { get; set; }
        public List<Phase> Phases { get; set; }
        public List<Activity> Activities { get; set; }
        public List<Task> Tasks { get; set; }
        public List<Milestone> Milestones { get; set; }
        public List<Effort> Efforts { get; set; }
        public string ProjectPlan { get; set; }
        public List<Dependency> Dependencies { get; set;}
        public string Asssumptions { get; set; }
        public string Constraints { get; set; }
        public class DocumentHistory
        {
            public string Version { get; set; }
            public string IssueDate { get; set; }
            public string Changes { get; set; }
        }
        public class DocumentApproval
        {
            public string Role { get; set; }
            public string Name { get; set; }
            public string Signature { get; set; }
            public string DateApproved { get; set; }
        }

        public class Phase
        {
            public string PhaseTitle { get; set; }
            public string PhaseDescription { get; set; }
            public string PhaseSequence { get; set; }
        }
        public class Activity
        {
            public string PhaseTitle { get; set; }
            public string ActivityTitle { get; set; }
            public string ActivityDescription { get; set; }
            public string ActivitySequence { get; set; }
        }
        public class Task
        {
            public string ActivityTitle { get; set; }
            public string TaskTitle { get; set; }
            public string TaskDescription { get; set; }
            public string TaskSequence { get; set; }
        }

        public class Milestone
        {
            public string MilestoneTitle { get; set; }
            public string MilestoneDate { get; set; }
            public string MilestoneDescription { get; set; }
        }

        public class Effort
        {
            public string TaskTitle { get; set; }
            public string Resource { get; set; }
            public string EffortMade { get; set; }
        }
        public class Dependency
        {
            public string ActivityTitle { get; set; }
            public string DependsOn { get; set; }
            public string DependencyType { get; set; }
        }
    }
}
