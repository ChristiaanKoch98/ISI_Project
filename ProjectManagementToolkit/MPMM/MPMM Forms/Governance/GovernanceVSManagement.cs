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
    public partial class GovernanceVSManagement : Form
    {
        public GovernanceVSManagement()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGF01_Click(object sender, EventArgs e)
        {
            GF1 gF1 = new GF1();
            gF1.Show();
        }

        private void btnGF02_Click(object sender, EventArgs e)
        {
            GF2 gF2 = new GF2();
            gF2.Show();
        }

        private void btnGF03_Click(object sender, EventArgs e)
        {
            GF3 gF3 = new GF3();
            gF3.Show();
        }

        private void btnGF04_Click(object sender, EventArgs e)
        {
            GF4 gF4 = new GF4();
            gF4.Show();
        }

        private void btnGF05_Click(object sender, EventArgs e)
        {
            GF5 gF5 = new GF5();
            gF5.Show();
        }

        private void btnGF06_Click(object sender, EventArgs e)
        {
            GF6 gF6 = new GF6();
            gF6.Show();
        }

        private void btnMF1_Click(object sender, EventArgs e)
        {
            MF1 mF1 = new MF1();
            mF1.Show();
        }

        private void btnMF2_Click(object sender, EventArgs e)
        {
            MF2 mF2 = new MF2();
            mF2.Show();
        }

        private void btnMF3_Click(object sender, EventArgs e)
        {
            MF3 mF3 = new MF3();
            mF3.Show();
        }

        private void btnMF4_Click(object sender, EventArgs e)
        {
            MF4 mF4 = new MF4();
            mF4.Show();
        }

        private void btnMF5_Click(object sender, EventArgs e)
        {
            MF5 mF5 = new MF5();
            mF5.Show();
        }
    }
}
