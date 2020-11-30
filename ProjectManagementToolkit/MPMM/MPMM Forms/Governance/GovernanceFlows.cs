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
    public partial class GovernanceFlows : Form
    {
        public GovernanceFlows()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGF01_Click(object sender, EventArgs e)
        {
            GFlows1 gFlows1 = new GFlows1();
            gFlows1.Show();
        }

        private void btnGF02_Click(object sender, EventArgs e)
        {
            GFlows2 gFlows2 = new GFlows2();
            gFlows2.Show();
        }
    }
}
