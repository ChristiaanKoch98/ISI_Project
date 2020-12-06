using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Models
{
    public class ProcurementRegisterModel
    {
        public List<ProcurementEntry> procurementEntries { get; set; }

        public string ProjectName { get; set; }
        public string ProjectManagerName { get; set; }

        public string ProcurementManagerName { get; set; }

        public class ProcurementEntry
        {
            public int PO_Number { get; set; }
            public string ItemTitle { get; set; }
            public string ItemDescription { get; set; }
            public int Quantity { get; set; }
            public int UnitPrice { get; set; }
            public int TotalPrice { get; set; }
            public string RequiredByDate { get; set; }
            public string Company { get; set; }
            public string ContactName { get; set; }
            public string ContactPhoneNumber { get; set; }
            public string PO_Status { get; set; }
            public string PO_Date { get; set; }
            public string DeliveryStatus { get; set; }
            public string DeliveryDate { get; set; }
            public string PaymentMethod { get; set; }
            public string PaymentStatus{ get; set; }
            public string PaymentDate { get; set; }
        }
    }
}
