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
    public partial class PLSM_ProcessGroupingGovernance_Interfaces : Form
    {
        public PLSM_ProcessGroupingGovernance_Interfaces(string type)
        {
            InitializeComponent();
            lblType.Text = type;
        }

        private void PLSM_ProcessGroupingGovernance_Interfaces_Activated(object sender, EventArgs e)
        {
            pnlHideTabPages.Location = new Point(10, -3);
            tbcProcessOverview.SelectTab(lblType.Text);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnBackToPLSM_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmProjectManagement ProjectManagement = new frmProjectManagement("tbp_PLSMs");
            ProjectManagement.Show();
        }

        private void btnJobDescriptions1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MPMM.MPMM_Document_Forms.JobDescriptionDocumentForm jobDescription = new MPMM.MPMM_Document_Forms.JobDescriptionDocumentForm();
            jobDescription.Show();
        }
    }
}
