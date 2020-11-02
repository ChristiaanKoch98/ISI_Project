using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Models
{
    class FinancialPlanModel
    {
        #region Title
        public string projectName { get; set; }
        #endregion

        #region Document information
        public string documentID { get; set; }
        public string documentOwner { get; set; }
        public DateTime issueDate { get; set; }
        public DateTime lastSavedDate { get; set; }
        public string fileName { get; set; }
        #endregion

        #region Document History
        public class DocumentHistory
        {
            public string version { get; set; }
            public DateTime issueDate { get; set; }
            public string changes { get; set; }
        }

        public List<DocumentHistory> documentHistories { get; set; }
        #endregion

        #region Document Approvals
        public class DocumentApprovals
        {
            public string role { get; set; }
            public string mame { get; set; }
            public string changes { get; set; }
            public DateTime date { get; set; }

        }

        public List<DocumentApprovals> documentApprovals { get; set; }
        #endregion

        #region Financial Expenses
        public class DocumentLabor
        {
            public string role { get; set; }
            public double unitCost { get; set; }
        }

        public List<DocumentLabor> documentLabors { get; set; }

        public class DocumentEquipment
        {
            public string equipment { get; set; }
            public double unitCost { get; set; }
        }

        public List<DocumentEquipment> documentEquipments { get; set; }

        public class DocumentMaterial
        {
            public string material { get; set; }
            public double unitCost { get; set; }
        }

        public List<DocumentMaterial> documentMaterials { get; set; }

        public class DocumentSupplier
        {
            public string deliverableItem { get; set; }
            public double unitCost { get; set; }
        }

        public List<DocumentSupplier> documentSuppliers { get; set; }

        public class DocumentAdministration
        {
            public string administrativeItem { get; set; }
            public double unitCost { get; set; }
        }

        public List<DocumentAdministration> documentAdministrations { get; set; }

        public class DocumentOther
        {
            public string otherExpenseItem { get; set; }
            public double unitCost { get; set; }
        }

        public List<DocumentOther> documentOthers { get; set; }
        #endregion

        #region Financial Plan
        public class DocumentSchedule
        {
            public class Expense
            {
                public string expenseType { get; set; }
                //Creates an array with 12 indexes, which correlates to each month of the year
                public double[] expensePerMonth { get; set; }

                public Expense()
                {
                    //Resets prices of expense for each month of the year
                    this.expensePerMonth = new double[12];
                    for (int i = 0; i < this.expensePerMonth.Length; i++)
                    {
                        this.expensePerMonth[i] = 0.0;
                    }
                }
            }

            public List<Expense> expenses { get; set; }

            //Returns the total expenses for an entire month
            //A month correlates to the index
            //Eg Jan is month index 0
            public double GetTotalForMonth(int month)
            {
                double total = 0;
                for (int i = 0; i < this.expenses.Count; i++)
                {
                    total += this.expenses[i].expensePerMonth[month];
                }

                return total;
            }
        }

        public string assumptions { get; set; }
        public string constraints { get; set; }
        #endregion

        #region Financial Process
        public string financialProcess { get; set; }
        public string financialActivities { get; set; }
        public string financialRoles { get; set; }
        public string financialDocuments { get; set; }
        #endregion
    }
}
