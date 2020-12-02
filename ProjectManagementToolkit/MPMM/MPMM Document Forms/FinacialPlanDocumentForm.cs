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
    public partial class FinacialPlanDocumentForm : Form
    {
        public FinacialPlanDocumentForm()
        {
            InitializeComponent();
        }

        private void btnSaveAssumptions_Click(object sender, EventArgs e)
        {
            string assumptions = txtAssumptions.Text;
        }

        private void btnSaveConstraints_Click(object sender, EventArgs e)
        {
            string constraints = txtConstraints.Text;
        }

        private void btnSaveActivitiesRolesDocuments_Click(object sender, EventArgs e)
        {
            string activies = txtActivities.Text;
            string roles = txtRoles.Text;
            string documents = txtDocuments.Text;
        }

        private void btnSaveProjectName_Click(object sender, EventArgs e)
        {
            string projectName = txtProjectName.Text;
        }

        private void dataGridViewOther_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabControlFinancialExpense_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FinacialPlanDocumentForm_Load(object sender, EventArgs e)
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

            dataGridViewLabour.Columns.Add("Role2", "Role");
            dataGridViewLabour.Columns.Add("UnitCost", "Unit Cost");

            dataGridViewEquipment.Columns.Add("Equipment ", "Equipment ");
            dataGridViewEquipment.Columns.Add("UnitCost1", "Unit Cost");

            dataGridViewMaterials.Columns.Add("Material ", "Material ");
            dataGridViewMaterials.Columns.Add("UnitCost2", "Unit Cost");

            dataGridViewSuppliers.Columns.Add("DeliverableItem ", "Deliverable Item ");
            dataGridViewSuppliers.Columns.Add("UnitCost3", "Unit Cost");

            dataGridViewAdmin.Columns.Add("Administrative", "Administrative Item");
            dataGridViewAdmin.Columns.Add("UnitCost4", "Unit Cost");

            dataGridViewOther.Columns.Add("Othexpensetem", "Other Expense Item");
            dataGridViewOther.Columns.Add("UnitCost5", "Unit Cost");

            dataGridView1.Columns.Add("ExpenseT", "Expense Type");
            dataGridView1.Columns.Add("Jan", "Jan");
            dataGridView1.Columns.Add("Feb", "Feb");
            dataGridView1.Columns.Add("Mar", "Mar");
            dataGridView1.Columns.Add("Apr", "Apr");
            dataGridView1.Columns.Add("May", "May");
            dataGridView1.Columns.Add("Jun", "Jun");
            dataGridView1.Columns.Add("Jul", "Jul");
            dataGridView1.Columns.Add("Aug", "Aug");
            dataGridView1.Columns.Add("Sept", "Sept");
            dataGridView1.Columns.Add("Oct", "Oct");
            dataGridView1.Columns.Add("Nov", "Nov");
            dataGridView1.Columns.Add("Dec", "Dec");
            dataGridView1.Columns.Add("Total", "Total");
        }
    }
}
