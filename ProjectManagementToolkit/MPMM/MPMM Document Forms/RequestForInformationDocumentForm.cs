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
    public partial class RequestForInformationDocumentForm : Form
    {
        public RequestForInformationDocumentForm()
        {
            InitializeComponent();
        }

        private void btnSaveProjectNameRequestForInfo_Click(object sender, EventArgs e)
        {
            string ProjectName = txtProjectName.Text;
        }

        private void btnSaveIntroductionInfo_Click(object sender, EventArgs e)
        {
            string OverviewIntroduction = txtOverview.Text;
            string Purpose = txtPurpose.Text;
            string Acknowledgment = txtAcknowledgement.Text;
            string Recipiants = txtRecipiants.Text;
            string Process = txtProcess.Text;
            string Rules = txtRules.Text;
            string Questions = txtQuestions.Text;
        }

        private void btnCompanyOverview_Click(object sender, EventArgs e)
        {
            string CompanyOverview = txtCompanyOverview.Text;
            listBoxCompanyOverview.Items.Add(txtCompanyOverview.Text);
        }

        private void btnCompanyOffering_Click(object sender, EventArgs e)
        {
            string CompanyOffering = txtCompanyOffering.Text;
            listBoxCompanyOffering.Items.Add(txtCompanyOffering.Text);
        }

        private void btnMethod_Click(object sender, EventArgs e)
        {
            string method = txtMethod.Text;
            listBoxMethods.Items.Add(txtMethod.Text);
        }

        private void btnTimeframes_Click(object sender, EventArgs e)
        {
            string timeframes = txtTimeframes.Text;
            listBoxTimeframes.Items.Add(txtTimeframes.Text);
        }

        private void btnPricing_Click(object sender, EventArgs e)
        {
            string pricing = txtPricing.Text;
            listBoxPricing.Items.Add(txtPricing.Text);
        }

        private void btnConfidentiality_Click(object sender, EventArgs e)
        {
            string confidentiality = txtConfidentiality.Text;
            listBoxConfidentiality.Items.Add(txtConfidentiality.Text);
        }

        private void btnDocumentation_Click(object sender, EventArgs e)
        {
            string documentation = txtDocumentation.Text;
            listBoxDocumentation.Items.Add(txtDocumentation.Text);
        }

        private void RequestForInformationDocumentForm_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
