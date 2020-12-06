using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Models
{
    class ExpenseRegister
    {
        public List<ExpenseEntry> ExpenseEntries { get; set; }
        public class ExpenseEntry
        {
            public int ActivityID { get; set; }
            public string ActivityDescription { get; set; } = "";
            public int TaskId { get; set; }
            public string TaskDescription { get; set; } = "";
            public int ExpenseID { get; set; }
            public string ExpenseType { get; set; } = "";
            public string ExpenseDescription { get; set; } = "";
            public string ExpenseAmount { get; set; } = "";
            public string ApprovalStatus { get; set; } = "";
            public string ApprovalDate { get; set; } = "";
            public string Approver { get; set; } = "";
            public string PaymentStatus { get; set; } = "";
            public string PaymentDate { get; set; } = "";
            public string Payee { get; set; } = "";
            public string Method { get; set; } = "";
        }
    }
}
