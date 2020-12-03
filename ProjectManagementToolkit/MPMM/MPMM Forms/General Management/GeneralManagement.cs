using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectManagementToolkit
{
    public partial class GeneralManagement : Form
    {
        public GeneralManagement()
        {
            InitializeComponent();
        }

        private void btnOpeninNewTab_Click(object sender, EventArgs e)
        {
            //this button in the Access program has a print symbol next to it so i do not know exactly if this button should print the document or create a new tab for the document to be shown in
        }

        private void btnSaveOrganizationInfo_Click(object sender, EventArgs e)
        {
            string companyName = txtCompanyName.Text;
            string address = txtAddress.Text;
            string city = txtCity.Text;
            string stateProvince = txtStateProvince.Text;
            int postalCode = int.Parse(txtPostalCode.Text);
            string country = txtCountry.Text;
            int phoneNumber = 0;
            if (txtPhoneNumber.Text.Length == 10)
            {
                phoneNumber = int.Parse(txtPhoneNumber.Text);
            }
            else
            {
                MessageBox.Show("PLEASE ENTER A NUMBER THAT IS 10 DIGITS IN LENGTH");
            }
            int faxNumber = int.Parse(txtFaxNumber.Text); // Fax number should have a similar if statement to the phone number yet i dont know how long a fax number is supposed to be
            string salesTaxRate = txtSalesTaxRate.Text;
            string paymentTerms = txtPaymentTerms.Text;
            string invoiceDescription = txtInvoiceDescription.Text;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
