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
    public partial class AcceptanceRegister : Form
    {
        public AcceptanceRegister()
        {
            InitializeComponent();
        }

        private void AcceptanceRegister_Load(object sender, EventArgs e)
        {
            dgvAcceptanceRegister.Columns.Add("colID", "ID");
            dgvAcceptanceRegister.Columns.Add("colDeliveryName", "Delivery Name");
            dgvAcceptanceRegister.Columns.Add("colDeliveryDescription", "Delivery Description");
            dgvAcceptanceRegister.Columns.Add("colDeliverableStatus", "Deliverable Status");
            dgvAcceptanceRegister.Columns.Add("colCriteria", "Criteria");
            dgvAcceptanceRegister.Columns.Add("colStandards", "Standards");
            dgvAcceptanceRegister.Columns.Add("colMethod", "Method");
            dgvAcceptanceRegister.Columns.Add("colReviewer", "Reviewer");
            dgvAcceptanceRegister.Columns.Add("colDate", "Date");
            dgvAcceptanceRegister.Columns.Add("colResults", "Results");
            dgvAcceptanceRegister.Columns.Add("colStatus", "Status");
        }
    }
}
