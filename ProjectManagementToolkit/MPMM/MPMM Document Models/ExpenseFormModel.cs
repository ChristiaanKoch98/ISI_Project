using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Models
{
    class ExpenseFormModel
    {
        public string ProjectDetails { get; set; }

        public List<ExpenseDetail> ExpenseDetails { get; set; }

        public string Approvaldetails { get; set; }

        public class ExpenseDetail
        {
          
            public string ActivityID { get; set; }

            public string TaskID { get; set; }

            public DateTime ExpenseDate { get; set; }

            public string ExpenseType { get; set; }

            public string ExpenseDescription { get; set; }

            public string ExpenseAmount { get; set; }

            public string PayeeName { get; set; }

            public string InvoiceNumber { get; set; }
        }
    }
}
