using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Models
{
    class ResourcePlanModel
    {

        public string ProjectName { get; set; }

        public string DocumentID { get; set; }

        public string DocumentOwner { get; set; }

        public DateTime IssueDate { get; set; }

        public DateTime LastSavedDate { get; set; }

        public string FileName { get; set; }

        public List<DocumentHistory> DocumentHistories { get; set; }

        public List<DocumentApproval> DocumentApprovals { get; set; }

        public List<Labor> Labors { get; set; }

        public List<Equipment> Equipments { get; set; }

        public List<Materials> Material { get; set; }

        public List<Schedule> Schedules { get; set; }

        public string Assumptions { get; set; }

        public string Constraints { get; set; }


        public class DocumentHistory
        {

            public string Version { get; set; }

            public DateTime IssueDate { get; set; }

            public string Changes { get; set; }

        }

        public class DocumentApproval
        {

            public string Role { get; set; }

            public string Name { get; set; }

            public string Signature { get; set; }

            public DateTime DateApproved { get; set; }

        }

        public class Labor
        {

            public string Constraints { get; set; }

            public string Number { get; set; }

            public string Responsibility { get; set; }

            public string Skill { get; set; }

            public DateTime StartDate { get; set; }

            public DateTime EndDate { get; set; }

        }
        public class Equipment
        {

            public string Iitem { get; set; }

            public string Amount { get; set; }

            public string Purpose { get; set; }

            public string Specification { get; set; }

            public DateTime StartDate { get; set; }

            public DateTime EndDate { get; set; }

        }
        public class Materials
        {
            public string Iitem { get; set; }

            public string Amount { get; set; }

            public DateTime StartDate { get; set; }

            public DateTime EndDate { get; set; }
        }

        public class Schedule
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


            public string Sept { get; set; }


            public string Oct { get; set; }


            public string Nov { get; set; }


            public string Dec { get; set; }


            public string Total { get; set; }

        }

        public string Assumption { get; set; }


        public string Constraint { get; set; }

    }
}
