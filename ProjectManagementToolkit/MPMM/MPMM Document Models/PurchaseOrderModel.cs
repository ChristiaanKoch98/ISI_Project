using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementToolkit.Classes
{
    class PurchaseOrderModel
    {
        public string PurchaseOrderFor { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public string PurchaseOrderDate { get; set; }
        public string DateRequired { get; set; }

        public string ProjectName { get; set; }
        public string ProjectAddress { get; set; }
        public string ProjectContactName { get; set; }
        public string ProjectContactPhone { get; set; }

        public string SupplierName { get; set; }
        public string SupplierAddress { get; set; }
        public string SupplierContactName { get; set; }
        public string SupplierContactPhone { get; set; }

        public string ContactName { get; set; }
        public string ContactAddress { get; set; }

        public string BillToContactName { get; set; }
        public string BillToContactAddress { get; set; }

        public string PaymentMethod { get; set; }
        public string CardType { get; set; }
        public string CardNumber { get; set; }
        public string ExpiryDate { get; set; }
        public string CardName { get; set; }

        public string TermsAndConditions { get; set; }
        public List<OrderDetails> orders { get; set; } = new List<OrderDetails>();

    }
    class OrderDetails
    {
        public string Item { get; set; }
        public string Description { get; set; }
        public string Quanlity { get; set; }
        public string UnitPrice { get; set; }
        public string TotalPrice { get; set; }

        public decimal SubTotal { get; set; }
        public decimal Other { get; set; }
        public decimal Total { get; set; }
    }
}
