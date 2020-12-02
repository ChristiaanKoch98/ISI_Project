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
    public partial class ProcurementPlanDocumentForm : Form
    {
        public ProcurementPlanDocumentForm()
        {
            InitializeComponent();
        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ProcurementPlanDocumentForm_Load(object sender, EventArgs e)
        {
            dataGridViewDocumentInformation.Columns.Add("type", "Type");
            dataGridViewDocumentInformation.Columns.Add("info", "Information");

            dataGridViewDocumentHistory.Columns.Add("Version", "Version");
            dataGridViewDocumentHistory.Columns.Add("IssueDate", "Issue Date");
            dataGridViewDocumentHistory.Columns.Add("Changes", "Changes");

            dataGridViewDocumentApprovals.Columns.Add("Role1", "Role");
            dataGridViewDocumentApprovals.Columns.Add("Name1", "Name");
            dataGridViewDocumentApprovals.Columns.Add("Signature1", "Signature");
            dataGridViewDocumentApprovals.Columns.Add("Date1", "Date");

            dataGridViewRequirements.Columns.Add("Item1", "Item");
            dataGridViewRequirements.Columns.Add("Description1", "Description");
            dataGridViewRequirements.Columns.Add("Justification1", "Justification");
            dataGridViewRequirements.Columns.Add("Quantity1", "Quantity");
            dataGridViewRequirements.Columns.Add("Budget1", "Budget");

            dataGridViewMarketResearch.Columns.Add("Item2", "Item");
            dataGridViewMarketResearch.Columns.Add("Supplier", "Supplier");
            dataGridViewMarketResearch.Columns.Add("Offering", "Offering");
            dataGridViewMarketResearch.Columns.Add("Price", "Price");
            dataGridViewMarketResearch.Columns.Add("Availability", "Availability");

        }

        private void btnAddAssumptions_Click(object sender, EventArgs e)
        {
            string addAssumptions = txtAssumptions.Text;
            listBoxAssumptions.Items.Add(addAssumptions);
        }

        private void btnAddConstraints_Click(object sender, EventArgs e)
        {
            string addConstraints = txtConstraints.Text;
            listBoxConstraints.Items.Add(addConstraints);
        }

        private void btnTenderActivities_Click(object sender, EventArgs e)
        {
            string tenderActivities = txtTenderActivities.Text;
            listBoxTenderActivities.Items.Add(tenderActivities);
        }

        private void btnTenderRoles_Click(object sender, EventArgs e)
        {
            string tenderRoles = txtTenderRoles.Text;
            listBoxTenderRoles.Items.Add(tenderRoles);
        }

        private void btnTenderDocuments_Click(object sender, EventArgs e)
        {
            string tenderDocuments = txtTenderDocuments.Text;
            listBoxTenderDocuments.Items.Add(tenderDocuments);
        }

        private void btnProcessActivities_Click(object sender, EventArgs e)
        {
            string processActivities = txtProcessActivities.Text;
            listBoxProcessActivities.Items.Add(processActivities);
        }

        private void btnProcessRoles_Click(object sender, EventArgs e)
        {
            string processRoles = txtProcessRoles.Text;
            listBoxProcessRoles.Items.Add(processRoles);
        }

        private void btnProcessDocuments_Click(object sender, EventArgs e)
        {
            string processDocuments = txtProcessDocuments.Text;
            listBoxProcessDocuments.Items.Add(processDocuments);
        }
    }
}
