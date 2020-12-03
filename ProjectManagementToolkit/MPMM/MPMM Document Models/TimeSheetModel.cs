using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Models
{
    class TimeSheetModel
    {
        public string projectName { get; set; }

        public class TimeSheetForm
        {
            public string projectName { get; set; }
            public string projectManager { get; set; }
            public string teamMember { get; set; }

            public class TimeSpent
            {
                public string date { get; set; }
                public string startTime { get; set; }
                public string endTime { get; set; }
                public string duration { get; set; }
            }

            public class TasksCompleted
            {
                public string activity { get; set; }
                public string task { get; set; }
            }

            public class DeliverablesProduced
            {
                public string startPercentComplete { get; set; }
                public string endPercentComplete { get; set; }
                public string result { get; set; }
            }

            public List<TimeSpent> timeSpents { get; set; }
            public List<TasksCompleted> tasksCompleted { get; set; }
            public List<DeliverablesProduced> deliverablesProduced { get; set; }

            public string submittedName { get; set; }
            public string submittedRole { get; set; }
            public string submittedSignature { get; set; }
            public string submittedDate { get; set; }

            public string approvedName { get; set; }
            public string approvedRole { get; set; }
            public string approvedSignature { get; set; }
            public string approvedDate { get; set; }
        }

        public TimeSheetForm timeSheetForm;
    }
}
