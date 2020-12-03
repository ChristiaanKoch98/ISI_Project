using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectManagementToolkit.MPMM.MPMM_Forms.Governance
{
    public partial class GovernanceGoals : Form
    {
        public GovernanceGoals()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnStrategy_Click(object sender, EventArgs e)
        {
            ProjectManagementToolkit.MPMM.MPMM_Forms.Governance.Strategy openFormStrategy = new ProjectManagementToolkit.MPMM.MPMM_Forms.Governance.Strategy();
            openFormStrategy.Show();
        }

        private void btnPolicies_Click(object sender, EventArgs e)
        {
            ProjectManagementToolkit.MPMM.MPMM_Forms.Governance.Policies openFormPolicies = new ProjectManagementToolkit.MPMM.MPMM_Forms.Governance.Policies();
            openFormPolicies.Show();
        }

        private void btnOversight_Click(object sender, EventArgs e)
        {
            ProjectManagementToolkit.MPMM.MPMM_Forms.Governance.Oversight openFormOversight = new ProjectManagementToolkit.MPMM.MPMM_Forms.Governance.Oversight();
            openFormOversight.Show();
        }

        private void btnAccountability_Click(object sender, EventArgs e)
        {
            ProjectManagementToolkit.MPMM.MPMM_Forms.Governance.Accountability openFormAccountability = new ProjectManagementToolkit.MPMM.MPMM_Forms.Governance.Accountability();
            openFormAccountability.Show();
        }
    }
}
