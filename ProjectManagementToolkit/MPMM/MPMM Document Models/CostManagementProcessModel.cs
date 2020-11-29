using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementToolkit.Classes
{
    class CostManagementProcessModel
    {
        public string CostManagementProcess { get; set; }
        public string Overview { get; set; }
        public string DocumentExpense { get; set; }
        public string ApproveExpense { get; set; }
        public string UpdateExpense { get; set; }
        public string TeamMembers { get; set; }
        public string ProjectAdmin { get; set; }
        public string ProjectManager { get; set; }
        public string ExpenseForm { get; set; }
        public string ExpenseRegister { get; set; }
        public Information Information { get; set; }
        public List<History> Histories { get; set; }
        public List<Approval> Approvals { get; set; }
    } 
}
