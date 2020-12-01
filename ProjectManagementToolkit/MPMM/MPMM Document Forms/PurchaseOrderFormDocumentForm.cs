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
using Xceed.Words.NET;
using Xceed.Document.NET;

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Forms
{
    public partial class PurchaseOrderFormDocumentForm : Form
    {
        VersionControl<PurchaseOrderModel> versionControl;
        PurchaseOrderModel newPurchaseOrderModel;
        PurchaseOrderModel currentPurchaseOrderModel;

        Color TABLE_HEADER_COLOR = Color.FromArgb(73, 173, 252);
        PurchaseOrderModel PurchaseOrderModel = new PurchaseOrderModel();

        public PurchaseOrderFormDocumentForm()
        {
            InitializeComponent();
            LoadDocument();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveDocument();
        }

        public void SaveDocument()
        {
            newPurchaseOrderModel.PurchaseOrderFor = Purchase_Order_Form_tbx.Text;
            newPurchaseOrderModel.PurchaseOrderNumber = Purchase_Order_Number_tbx.Text;
            newPurchaseOrderModel.PurchaseOrderDate = Purchase_Order_Date_tbx.Text;
            newPurchaseOrderModel.DateRequired = Date_Required_tbx.Text;
            newPurchaseOrderModel.ProjectName = Project_Name_tbx.Text;
            newPurchaseOrderModel.ProjectAddress = Project_Address_tbx.Text;
            newPurchaseOrderModel.ProjectContactName = Project_Contact_Name_tbx.Text;
            newPurchaseOrderModel.ProjectContactPhone = Project_Contact_Phone_tbx.Text;
            newPurchaseOrderModel.SupplierName = Supplier_Name_tbx.Text;
            newPurchaseOrderModel.SupplierAddress = Supplier_Address_tbx.Text;
            newPurchaseOrderModel.SupplierContactName = Supplier_Contact_Name_tbx.Text;
            newPurchaseOrderModel.SupplierContactPhone = Supplier_Contact_Phone_tbx.Text;
            newPurchaseOrderModel.SupplierAddress = Supplier_Address_tbx.Text;

            newPurchaseOrderModel.ContactName = Contact_Name1_tbx.Text;
            newPurchaseOrderModel.ContactAddress = Contact_Address1_tbx.Text;
            newPurchaseOrderModel.BillToContactName = Contact_Name2_tbx.Text;
            newPurchaseOrderModel.BillToContactAddress = Contact_Address2_tbx.Text;

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
            newPurchaseOrderModel.Orders = orderDetails;

            newPurchaseOrderModel.PaymentMethod = cmbxPaymentMethod.SelectedItem.ToString();
            newPurchaseOrderModel.CardType = Card_Type_tbx.Text;
            newPurchaseOrderModel.CardNumber = Card_Number_tbx.Text;
            newPurchaseOrderModel.ExpiryDate = Expiration_Date_tbx.Text;
            newPurchaseOrderModel.CardName = Name_on_Card_tbx.Text;
            newPurchaseOrderModel.TermsAndConditions = Terms_and_Conditions_tbx.Text;
            
            List<VersionControl<PurchaseOrderModel>.DocumentModel> documentModels = versionControl.DocumentModels;

            //MessageBox.Show(JsonConvert.SerializeObject(newPurchaseOrderModel), "save", MessageBoxButtons.OK);

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

                Purchase_Order_Form_tbx.Text = currentPurchaseOrderModel.PurchaseOrderFor;
                Purchase_Order_Number_tbx.Text = currentPurchaseOrderModel.PurchaseOrderNumber;
                Purchase_Order_Date_tbx.Text = currentPurchaseOrderModel.PurchaseOrderDate;
                Date_Required_tbx.Text = currentPurchaseOrderModel.DateRequired;
                Project_Name_tbx.Text = currentPurchaseOrderModel.ProjectName;
                Project_Address_tbx.Text = currentPurchaseOrderModel.ProjectAddress;
                Project_Contact_Name_tbx.Text = currentPurchaseOrderModel.ProjectContactName;
                Project_Contact_Phone_tbx.Text = currentPurchaseOrderModel.ProjectContactPhone;
                Supplier_Name_tbx.Text = currentPurchaseOrderModel.SupplierName;
                Supplier_Address_tbx.Text = currentPurchaseOrderModel.SupplierAddress;
                Supplier_Contact_Name_tbx.Text = currentPurchaseOrderModel.SupplierContactName;
                Supplier_Contact_Phone_tbx.Text = currentPurchaseOrderModel.SupplierContactPhone;
                Supplier_Address_tbx.Text = currentPurchaseOrderModel.SupplierAddress;
                Contact_Name1_tbx.Text = currentPurchaseOrderModel.ContactName;
                Contact_Address1_tbx.Text = currentPurchaseOrderModel.ContactAddress;
                Contact_Name2_tbx.Text = currentPurchaseOrderModel.BillToContactName;
                Contact_Address2_tbx.Text = currentPurchaseOrderModel.BillToContactAddress;

                foreach (var row in currentPurchaseOrderModel.Orders)
                {
                    ORDER_DETAILS_dgv.Rows.Add(new string[] { row.Item, row.Description, row.Quanlity, row.UnitPrice, row.TotalPrice });
                }

                cmbxPaymentMethod.Text = currentPurchaseOrderModel.PaymentMethod;
                Card_Type_tbx.Text = currentPurchaseOrderModel.CardType;
                Card_Number_tbx.Text = currentPurchaseOrderModel.CardNumber;
                Expiration_Date_tbx.Text = currentPurchaseOrderModel.ExpiryDate;
                Name_on_Card_tbx.Text = currentPurchaseOrderModel.CardName;
                Terms_and_Conditions_tbx.Text = currentPurchaseOrderModel.TermsAndConditions;

            }
            else
            {
                versionControl = new VersionControl<PurchaseOrderModel>();
                versionControl.DocumentModels = new List<VersionControl<PurchaseOrderModel>.DocumentModel>();
                newPurchaseOrderModel = new PurchaseOrderModel();
            }
        }

        private void btnExportToWord_Click(object sender, EventArgs e)
        {
            ExportToWord();
        }

        public void ExportToWord()
        {
            string path;
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                saveFileDialog.Filter = "Word 97-2003 Documents (*.doc)|*.doc|Word 2007 Documents (*.docx)|*.docx";
                saveFileDialog.FilterIndex = 2;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    path = saveFileDialog.FileName;
                    using (var document = DocX.Create(path))
                    {
                        for (int i = 0; i < 11; i++)
                        {
                            document.InsertParagraph("")
                                .Font("Arial")
                                .Bold(true)
                                .FontSize(22d).Alignment = Alignment.left;
                        }
                        document.InsertParagraph("Purchase Order Form \nFor " + currentPurchaseOrderModel.PurchaseOrderFor)
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(22d).Alignment = Alignment.left;
                        document.InsertSectionPageBreak();

                        document.InsertParagraph("Purchase Order Form\n")
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(14d).Alignment = Alignment.left;
                        document.InsertParagraph("")
                           .Font("Arial")
                           .Bold(true)
                           .FontSize(14d).Alignment = Alignment.left;

                        var purchaseOrderDetails = document.AddTable(2, 1);
                        purchaseOrderDetails.Rows[0].Cells[0].Paragraphs[0].Append("PURCHASE ORDER DETAILS").Bold(true).Color(Color.White);
                        purchaseOrderDetails.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;

                        purchaseOrderDetails.Rows[1].Cells[0].Paragraphs[0].Append($"Purchase Order #: {currentPurchaseOrderModel.PurchaseOrderNumber}\n" +
                            $"Purchase Order Date: {currentPurchaseOrderModel.PurchaseOrderDate}\n" +
                            $"Date Required By: {currentPurchaseOrderModel.DateRequired}\n");
//
                        purchaseOrderDetails.SetWidths(new float[] { 1000 });
                        document.InsertTable(purchaseOrderDetails);
//
                        var deliveryDetails = document.AddTable(3, 2);
                        deliveryDetails.Rows[0].Cells[0].Paragraphs[0].Append("DELIVERY DETAILS").Bold(true).Color(Color.White);
                        deliveryDetails.Rows[0].Cells[1].Paragraphs[0].Append("").Bold(true).Color(Color.White);
                        deliveryDetails.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        deliveryDetails.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;

                        deliveryDetails.Rows[1].Cells[0].Paragraphs[0].Append($"From:\n\n" +
                            $"Project Name: {currentPurchaseOrderModel.ProjectName}\n" +
                            $"Project Address: {currentPurchaseOrderModel.ProjectAddress}\n" +
                            $"Project Contact Name: {currentPurchaseOrderModel.ProjectContactName}\n" +
                            $"Project Contact Phone #: {currentPurchaseOrderModel.ProjectContactPhone}\n");
                        deliveryDetails.Rows[1].Cells[1].Paragraphs[0].Append($"To:\n\n" +
                            $"Supplier Name: {currentPurchaseOrderModel.SupplierName}\n" +
                            $"Supplier Address: {currentPurchaseOrderModel.SupplierAddress}\n" +
                            $"Supplier Contact Name {currentPurchaseOrderModel.SupplierContactName}\n" +
                            $"Supplier Contact Phone #: {currentPurchaseOrderModel.SupplierContactPhone}\n");
                        deliveryDetails.Rows[2].Cells[0].Paragraphs[0].Append($"Delivered To:\n\n" +
                            $"Contact Name: {currentPurchaseOrderModel.ContactName}\n" +
                            $"Contact Address: {currentPurchaseOrderModel.ContactAddress}\n");
                        deliveryDetails.Rows[2].Cells[1].Paragraphs[0].Append($"Bill To:\n\n" +
                           $"Contact Name: {currentPurchaseOrderModel.BillToContactName}\n" +
                           $"Contact Address: {currentPurchaseOrderModel.BillToContactAddress}\n");
                        
                        //
                        deliveryDetails.SetWidths(new float[] { 1000 });
                        document.InsertTable(deliveryDetails);

                        document.InsertParagraph("ORDER DETAILS\n")
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(14d).Alignment = Alignment.left;

                        var orderDetailsTable = document.AddTable(currentPurchaseOrderModel.Orders.Count + 1, 5);
                        orderDetailsTable.Rows[0].Cells[0].Paragraphs[0].Append("Item")
                            .Bold(true)
                            .Color(Color.White);
                        orderDetailsTable.Rows[0].Cells[1].Paragraphs[0].Append("Description")
                            .Bold(true)
                            .Color(Color.White);
                        orderDetailsTable.Rows[0].Cells[2].Paragraphs[0].Append("Quantity")
                            .Bold(true)
                            .Color(Color.White);
                        orderDetailsTable.Rows[0].Cells[3].Paragraphs[0].Append("Unit Price")
                            .Bold(true)
                            .Color(Color.White);
                        orderDetailsTable.Rows[0].Cells[4].Paragraphs[0].Append("Total Price")
                            .Bold(true)
                            .Color(Color.White);

                        orderDetailsTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        orderDetailsTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        orderDetailsTable.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;
                        orderDetailsTable.Rows[0].Cells[3].FillColor = TABLE_HEADER_COLOR;
                        orderDetailsTable.Rows[0].Cells[4].FillColor = TABLE_HEADER_COLOR;


                        for (int i = 1; i < currentPurchaseOrderModel.Orders.Count + 1; i++)
                        {
                            orderDetailsTable.Rows[i].Cells[0].Paragraphs[0].Append(currentPurchaseOrderModel.Orders[i - 1].Item);
                            orderDetailsTable.Rows[i].Cells[1].Paragraphs[0].Append(currentPurchaseOrderModel.Orders[i - 1].Description);
                            orderDetailsTable.Rows[i].Cells[2].Paragraphs[0].Append(currentPurchaseOrderModel.Orders[i - 1].Quanlity);
                            orderDetailsTable.Rows[i].Cells[3].Paragraphs[0].Append(currentPurchaseOrderModel.Orders[i - 1].UnitPrice);
                            orderDetailsTable.Rows[i].Cells[4].Paragraphs[0].Append(currentPurchaseOrderModel.Orders[i - 1].TotalPrice);
                        }

                        //reviewDetailsTable.SetWidths(new float[] { 190, 303, 1094 });
                        document.InsertTable(orderDetailsTable);

                        document.InsertParagraph("")
                           .Font("Arial")
                           .Bold(true)
                           .FontSize(14d).Alignment = Alignment.left;

                        var paymentDetails = document.AddTable(2, 1);
                        paymentDetails.Rows[0].Cells[0].Paragraphs[0].Append("PAYMENT DETAILS").Bold(true).Color(Color.White);
                        paymentDetails.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;

                        paymentDetails.Rows[1].Cells[0].Paragraphs[0].Append($"Payment Method: {currentPurchaseOrderModel.PaymentMethod}\n\n" +
                            $"Credit Card Details:\n" +
                            $"Card Type: {currentPurchaseOrderModel.CardType}\n" +
                            $"Card Number: {currentPurchaseOrderModel.CardNumber}\n" +
                            $"Expiration Date: {currentPurchaseOrderModel.ExpiryDate}\n" +
                            $"Name on Card: {currentPurchaseOrderModel.CardName}\n");

                        paymentDetails.SetWidths(new float[] { 1000 });
                        document.InsertTable(paymentDetails);

                        var termsAndConditiionsTable = document.AddTable(2, 1);
                        termsAndConditiionsTable.Rows[0].Cells[0].Paragraphs[0].Append("TERMS AND CONDITIONS").Bold(true).Color(Color.White);
                        termsAndConditiionsTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;

                        termsAndConditiionsTable.Rows[1].Cells[0].Paragraphs[0].Append($"{currentPurchaseOrderModel.TermsAndConditions}\n");

                        termsAndConditiionsTable.SetWidths(new float[] { 1000 });
                        document.InsertTable(termsAndConditiionsTable);

                        try
                        {
                            document.Save();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("The selected File is open.", "Close File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
    }
}
