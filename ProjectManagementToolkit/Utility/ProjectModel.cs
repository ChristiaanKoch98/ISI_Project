using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementToolkit.Utility
{
    
    class ProjectModel
    {
        public string ProjectID { get; set; }
        public string ProjectName { get; set; }
        public  string ProjectSponsor { get; set; }
        public string ProjectReviewGroup { get; set; }
        public string ProjectManager { get; set; }
        public string QualityManager { get; set; }
        public string ProcurementManager { get; set; }
        public string CommunicationsManager { get; set; }
        public string OfficeManager { get; set; }
    }
}
