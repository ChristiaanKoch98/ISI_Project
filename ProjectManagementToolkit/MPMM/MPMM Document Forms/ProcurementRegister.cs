using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Forms
{
    public partial class ProcurementRegister : Form
    {
        public ProcurementRegister()
        {
            InitializeComponent();
        }

        private void txtProjectManagerName_TextChanged(object sender, EventArgs e)
        {

        }

        private void ProcurementRegister_Load(object sender, EventArgs e)
        {
            dgvProcurementRegister.Columns.Add("colPO","PO #" );
            dgvProcurementRegister.Columns.Add("colItemTitle", "Item Title");
            dgvProcurementRegister.Columns.Add("colItemDesc", "Item Description");
            dgvProcurementRegister.Columns.Add("colQuantity", "Quantity");
            dgvProcurementRegister.Columns.Add("colUnitPrice", "Unit Price");
            dgvProcurementRegister.Columns.Add("colTotalPrice", "Total Price");
            dgvProcurementRegister.Columns.Add("colReqByDate", "Required By Date");
            dgvProcurementRegister.Columns.Add("colCompany", "Company");
            dgvProcurementRegister.Columns.Add("colContactName", "Contact Name");
            dgvProcurementRegister.Columns.Add("colContactPhNo", "Contact Ph. NO.");
            dgvProcurementRegister.Columns.Add("colPOStatus", "PO Status");
            dgvProcurementRegister.Columns.Add("colPODate", "PO Date");
            dgvProcurementRegister.Columns.Add("colDeliveryStatus", "Delivery Status");
            dgvProcurementRegister.Columns.Add("colDeliveryDate", "Delivery Date");
            dgvProcurementRegister.Columns.Add("colPaymentMethod", "Payment Method");
            dgvProcurementRegister.Columns.Add("colPaymentStatus", "Payment Status");
            dgvProcurementRegister.Columns.Add("colPaymentDate", "Payment Date");
        }
    }
}
