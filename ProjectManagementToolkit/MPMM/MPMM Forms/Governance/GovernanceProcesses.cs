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
    public partial class GovernanceProcesses : Form
    {
        public GovernanceProcesses()
        {
            InitializeComponent();
        }

        private void GovernanceProcesses_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGP1_Click(object sender, EventArgs e)
        {
            GP1 gP1 = new GP1();
            gP1.Show();
        }

        private void btnGP2_Click(object sender, EventArgs e)
        {
            GP2 gP2 = new GP2();
            gP2.Show();
        }

        private void btnGP3_Click(object sender, EventArgs e)
        {
            GP3 gP3 = new GP3();
            gP3.Show();
        }

        private void btnGP4_Click(object sender, EventArgs e)
        {
            GP4 gP4 = new GP4();
            gP4.Show();
        }

        private void btnGP5_Click(object sender, EventArgs e)
        {
            GP5 gP5 = new GP5();
            gP5.Show();
        }
    }
}
