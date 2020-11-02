using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementToolkit.Classes
{
    class CostManagementProcessModel
    {
        public string DocumentManagementProcess { get; set; }
        public string Overview { get; set; }
        public string DocumentExpense { get; set; }
        public string ApproveExpense { get; set; }
        public string UpdateExpense { get; set; }
        public IEnumerable<string> TeamMembers { get; set; }
        public string ProjectAdmin { get; set; }
        public string ProjectManager { get; set; }
        public string ExpenseForm { get; set; }
        public string ExpenseRegister { get; set; }

        public CostManagementProcessModel()
        {

        }
    }
}
