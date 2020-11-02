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
        public string Schedule { get; internal set; }
        public string Risks { get; internal set; }

        public RiskPlanModel()
        {

        }

    }
}
