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
using Newtonsoft.Json;
using ProjectManagementToolkit.Utility;
using ProjectManagementToolkit.Properties;

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Forms
{
    public partial class PurchaseOrderFormDocumentForm : Form
    {
        VersionControl<PurchaseOrderModel> versionControl;
        PurchaseOrderModel newPurchaseOrderModel;
        PurchaseOrderModel currentPurchaseOrderModel;

        PurchaseOrderModel purchaseOrderModel;
        public PurchaseOrderFormDocumentForm()
        {
            InitializeComponent();
            purchaseOrderModel = new PurchaseOrderModel();
            LoadDocument();
        }

        private void Enter_btn_Click(object sender, EventArgs e)
        {
            if (Purchase_Order_Form_tbx.Text.Length > 0)
            {
                purchaseOrderModel.PurchaseOrderFor = Purchase_Order_Form_tbx.Text;
                newPurchaseOrderModel.PurchaseOrderFor = purchaseOrderModel.PurchaseOrderFor;
            }
        }

        private void PROJECT_DETAILS_btn_Click(object sender, EventArgs e)
        {
            if (Purchase_Order_Number_tbx.Text.Length > 0 && Purchase_Order_Date_tbx.Text.Length > 0 && Date_Required_tbx.Text.Length > 0)
            {
                purchaseOrderModel.PurchaseOrderNumber = Purchase_Order_Date_tbx.Text;
                purchaseOrderModel.PurchaseOrderDate = Purchase_Order_Date_tbx.Text;
                purchaseOrderModel.DateRequired = Date_Required_tbx.Text;

                newPurchaseOrderModel.PurchaseOrderNumber = purchaseOrderModel.PurchaseOrderNumber;
                newPurchaseOrderModel.PurchaseOrderDate = purchaseOrderModel.PurchaseOrderDate;
                newPurchaseOrderModel.DateRequired = purchaseOrderModel.DateRequired;
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

                newPurchaseOrderModel.ProjectName = purchaseOrderModel.ProjectName;
                newPurchaseOrderModel.ProjectAddress = purchaseOrderModel.ProjectAddress;
                newPurchaseOrderModel.ProjectContactName = purchaseOrderModel.ProjectContactName;
                newPurchaseOrderModel.ProjectContactPhone = purchaseOrderModel.ProjectContactPhone;
            }

            if (Supplier_Name_tbx.Text.Length > 0 && Supplier_Address_tbx.Text.Length > 0 && Supplier_Contact_Name_tbx.Text.Length > 0 && Supplier_Contact_Phone_tbx.Text.Length > 0)
            {
                purchaseOrderModel.SupplierName = Supplier_Name_tbx.Text;
                purchaseOrderModel.SupplierAddress = Supplier_Address_tbx.Text;
                purchaseOrderModel.SupplierContactName = Supplier_Contact_Name_tbx.Text;
                purchaseOrderModel.SupplierContactPhone = Supplier_Contact_Phone_tbx.Text;

                newPurchaseOrderModel.SupplierName = purchaseOrderModel.SupplierName;
                purchaseOrderModel.SupplierAddress = purchaseOrderModel.SupplierAddress;
                newPurchaseOrderModel.SupplierContactName = purchaseOrderModel.SupplierContactName;
                newPurchaseOrderModel.SupplierContactPhone = purchaseOrderModel.SupplierContactPhone;
            }

            if (Contact_Name1_tbx.Text.Length > 0 && Contact_Address1_tbx.Text.Length > 0)
            {
                purchaseOrderModel.BillToContactName = Contact_Name1_tbx.Text;
                purchaseOrderModel.BillToContactAddress = Contact_Address1_tbx.Text;

                newPurchaseOrderModel.BillToContactName = purchaseOrderModel.BillToContactName;
                newPurchaseOrderModel.BillToContactAddress = purchaseOrderModel.BillToContactAddress;
            }

            if (Contact_Name2_tbx.Text.Length > 0 && Contact_Address2_tbx.Text.Length > 0)
            {
                purchaseOrderModel.BillToContactName = Contact_Name2_tbx.Text;
                purchaseOrderModel.BillToContactAddress = Contact_Address2_tbx.Text;

                newPurchaseOrderModel.BillToContactName = purchaseOrderModel.BillToContactName;
                newPurchaseOrderModel.BillToContactAddress = purchaseOrderModel.BillToContactAddress;
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

                    newPurchaseOrderModel.CardType = purchaseOrderModel.CardType;
                    newPurchaseOrderModel.CardNumber = purchaseOrderModel.CardNumber;
                    newPurchaseOrderModel.ExpiryDate = purchaseOrderModel.ExpiryDate;
                    newPurchaseOrderModel.CardName = purchaseOrderModel.CardName;
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

                newPurchaseOrderModel.orders = orderDetails;
            }
        }

        private void TERMS_AND_CONDITIONS_btn_Click(object sender, EventArgs e)
        {
            if (Terms_and_Conditions_tbx.Text.Length > 0)
            {
                purchaseOrderModel.TermsAndConditions = Terms_and_Conditions_tbx.Text;
                newPurchaseOrderModel.TermsAndConditions = purchaseOrderModel.TermsAndConditions;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveDocument();
        }

        public void SaveDocument()
        {
            List<VersionControl<PurchaseOrderModel>.DocumentModel> documentModels = versionControl.DocumentModels;


            if (!versionControl.isEqual(currentPurchaseOrderModel, newPurchaseOrderModel))
            {
                VersionControl<PurchaseOrderModel>.DocumentModel documentModel = new VersionControl<PurchaseOrderModel>.DocumentModel(newPurchaseOrderModel, DateTime.Now, VersionControl<PurchaseOrderModel>.generateID());

                documentModels.Add(documentModel);

                versionControl.DocumentModels = documentModels;

                string json = JsonConvert.SerializeObject(versionControl);
                JsonHelper.saveDocument(json, Settings.Default.ProjectID, "PurchaseOrder");
                MessageBox.Show("Purchase Order Form saved successfully", "save", MessageBoxButtons.OK);
            }
        }

        public void LoadDocument()
        {
            string json = JsonHelper.loadDocument(Settings.Default.ProjectID, "PurchaseOrder");
            List<string[]> documentInfo = new List<string[]>();
            newPurchaseOrderModel = new PurchaseOrderModel();
            currentPurchaseOrderModel = new PurchaseOrderModel();
            if (json != "")
            {
                versionControl = JsonConvert.DeserializeObject<VersionControl<PurchaseOrderModel>>(json);
                newPurchaseOrderModel = JsonConvert.DeserializeObject<PurchaseOrderModel>(versionControl.getLatest(versionControl.DocumentModels));
                currentPurchaseOrderModel = JsonConvert.DeserializeObject<PurchaseOrderModel>(versionControl.getLatest(versionControl.DocumentModels));

                Purchase_Order_Number_tbx.Text = purchaseOrderModel.PurchaseOrderNumber;
                Purchase_Order_Date_tbx.Text = purchaseOrderModel.PurchaseOrderDate;
                Date_Required_tbx.Text = purchaseOrderModel.DateRequired;
                Project_Name_tbx.Text = purchaseOrderModel.ProjectName;
                Project_Address_tbx.Text = purchaseOrderModel.ProjectAddress;
                Project_Contact_Name_tbx.Text = purchaseOrderModel.ProjectContactName;
                Project_Contact_Phone_tbx.Text = purchaseOrderModel.ProjectContactPhone;
                Contact_Name1_tbx.Text = purchaseOrderModel.ContactName;
                Contact_Address1_tbx.Text = purchaseOrderModel.ContactAddress;
                Contact_Name2_tbx.Text = purchaseOrderModel.BillToContactName;
                Contact_Address2_tbx.Text = purchaseOrderModel.BillToContactAddress;
                Card_Type_tbx.Text = purchaseOrderModel.CardType;
                Card_Number_tbx.Text = purchaseOrderModel.CardNumber;
                Name_on_Card_tbx.Text = purchaseOrderModel.CardName;
            }
        }
    }
}
