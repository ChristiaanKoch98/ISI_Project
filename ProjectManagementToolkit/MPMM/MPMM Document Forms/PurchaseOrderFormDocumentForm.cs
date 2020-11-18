using ProjectManagementToolkit.Classes;
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
    public partial class PurchaseOrderFormDocumentForm : Form
    {
        PurchaseOrderModel purchaseOrderModel;
        public PurchaseOrderFormDocumentForm()
        {
            InitializeComponent();
            purchaseOrderModel = new PurchaseOrderModel();
        }

        private void Enter_btn_Click(object sender, EventArgs e)
        {
            if (Purchase_Order_Form_tbx.Text.Length > 0)
            {
                purchaseOrderModel.PurchaseOrderFor = Purchase_Order_Form_tbx.Text;
            }
        }

        private void PROJECT_DETAILS_btn_Click(object sender, EventArgs e)
        {
            if (Purchase_Order_Number_tbx.Text.Length > 0 && Purchase_Order_Date_tbx.Text.Length > 0 && Date_Required_tbx.Text.Length > 0)
            {
                purchaseOrderModel.PurchaseOrderNumber = Purchase_Order_Date_tbx.Text;
                purchaseOrderModel.PurchaseOrderDate = Purchase_Order_Date_tbx.Text;
                purchaseOrderModel.DateRequired = Date_Required_tbx.Text;
            }
        }

        private void DELIVERY_DETAILS_btn_Click(object sender, EventArgs e)
        {
            if (Project_Name_tbx.Text.Length > 0 && Project_Address_tbx.Text.Length > 0 && Project_Contact_Name_tbx.Text.Length > 0 && Project_Contact_Phone_tbx.Text.Length > 0)
            {
                purchaseOrderModel.ProjectName = Project_Name_tbx.Text;
                purchaseOrderModel.ProjectAddress = Project_Address_tbx.Text;
                purchaseOrderModel.ProjectContactName = Project_Contact_Name_tbx.Text;
                purchaseOrderModel.ProjectContactPhone = Project_Contact_Phone_tbx.Text;
            }

            if (Supplier_Name_tbx.Text.Length > 0 && Supplier_Address_tbx.Text.Length > 0 && Supplier_Contact_Name_tbx.Text.Length > 0 && Supplier_Contact_Phone_tbx.Text.Length > 0)
            {
                purchaseOrderModel.SupplierName = Supplier_Name_tbx.Text;
                purchaseOrderModel.SupplierAddress = Supplier_Address_tbx.Text;
                purchaseOrderModel.SupplierContactName = Supplier_Contact_Name_tbx.Text;
                purchaseOrderModel.SupplierContactPhone = Supplier_Contact_Phone_tbx.Text;
            }

            if (Contact_Name1_tbx.Text.Length > 0 && Contact_Address1_tbx.Text.Length > 0)
            {
                purchaseOrderModel.BillToContactName = Contact_Name1_tbx.Text;
                purchaseOrderModel.BillToContactAddress = Contact_Address1_tbx.Text;
            }

            if (Contact_Name2_tbx.Text.Length > 0 && Contact_Address2_tbx.Text.Length > 0)
            {
                purchaseOrderModel.BillToContactName = Contact_Name2_tbx.Text;
                purchaseOrderModel.BillToContactAddress = Contact_Address2_tbx.Text;
            }
        }

        private void PAYMENT_DETAILS_btn_Click(object sender, EventArgs e)
        {
            if (cmbxPaymentMethod.SelectedIndex != 0)
            {
                purchaseOrderModel.PaymentMethod = cmbxPaymentMethod.SelectedItem.ToString();
                if (Card_Type_tbx.Text.Length > 0 && Card_Number_tbx.Text.Length > 0 && Expiration_Date_tbx.Text.Length > 0 && Name_on_Card_tbx.Text.Length > 0)
                {
                    purchaseOrderModel.CardType = Card_Type_tbx.Text;
                    purchaseOrderModel.CardNumber = Card_Number_tbx.Text;
                    purchaseOrderModel.ExpiryDate = Expiration_Date_tbx.Text;
                    purchaseOrderModel.CardName = Name_on_Card_tbx.Text;
                }

                List<OrderDetails> orderDetails = new List<OrderDetails>();
                int RowCount = ORDER_DETAILS_dgv.RowCount;
                for (int i = 0; i < RowCount - 1; i++)
                {
                    OrderDetails details = new OrderDetails();
                    var Item = ORDER_DETAILS_dgv.Rows[i].Cells[0].Value?.ToString() ?? "";
                    var Description = ORDER_DETAILS_dgv.Rows[i].Cells[1].Value?.ToString() ?? "";
                    var Quanlity = ORDER_DETAILS_dgv.Rows[i].Cells[2].Value?.ToString() ?? "";
                    var UnitPrice = ORDER_DETAILS_dgv.Rows[i].Cells[3].Value?.ToString() ?? "";
                    var TotalPrice = ORDER_DETAILS_dgv.Rows[i].Cells[4].Value?.ToString() ?? "";
                    details.Item = Item;
                    details.Description = Description;
                    details.Quanlity = Quanlity;
                    details.UnitPrice = UnitPrice;
                    details.TotalPrice = TotalPrice;
                    orderDetails.Add(details); 
                }
            }
        }

        private void TERMS_AND_CONDITIONS_btn_Click(object sender, EventArgs e)
        {
            if (Terms_and_Conditions_tbx.Text.Length > 0)
            {
                purchaseOrderModel.TermsAndConditions = Terms_and_Conditions_tbx.Text;
            }
        }
    }
}
