using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Models
{
    class TimesheetRegisterModel
    {
        public List<TimesheetEntry> TimeSheetEntries { get; set; }
        public class TimesheetEntry
        {
            public int ActivityID { get; set; }
            public string ActivityDescription { get; set; } = "";
            public string TaskID { get; set; } = "";
            public string TaskDescription { get; set; } = "";
            public string TeamMember { get; set; } = "";
            public string Time { get; set; } = "";
            public string OverTime { get; set; } = "";
            public string StartPercentageComplete { get; set; } = "";
            public string EndPercentageComplete { get; set; } = "";
            public string Result { get; set; } = "";
            public string ApprovalStatus { get; set; } = "";
            public string ApprovalDate { get; set; } = "";
            public string Approver { get; set; } = "";
        }
    }
}
