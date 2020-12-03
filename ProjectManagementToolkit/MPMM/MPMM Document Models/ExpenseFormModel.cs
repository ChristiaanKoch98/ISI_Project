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
        public List<ProjectDetail> ProjectDetails { get; set; }

        public List<ExpenseDetail> ExpenseDetails { get; set; }

        public List<SubmittedBy> SubmittedByDetails { get; set; }
        public List<ApprovedBy> ApprovedByDetails { get; set; }

        public string ApprovalDetails { get; set; }




        public class ProjectDetail
        {

            public string ProjectName { get; set; }

            public string ProjectManager { get; set; }

            public string TeamMember { get; set; }

        }






        public class ExpenseDetail
        {
          
            public string ActivityID { get; set; }

            public string TaskID { get; set; }

            public string ExpenseDate { get; set; }

            public string ExpenseType { get; set; }

            public string ExpenseDescription { get; set; }

            public string ExpenseAmount { get; set; }

            public string PayeeName { get; set; }

            public string InvoiceNumber { get; set; }
        }




        public class SubmittedBy
        {

            public string Name { get; set; }

            public string Signature { get; set; }

            public string Date { get; set; }

        }




        public class ApprovedBy
        {

            public string Name { get; set; }

            public string Signature { get; set; }

            public string Date { get; set; }

        }
    }
}
