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
    public partial class GovernanceFunctions : Form
    {
        public GovernanceFunctions()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGF01_Click(object sender, EventArgs e)
        {
            GF1 gf1 = new GF1();
            gf1.Show();
        }

        private void btnGF02_Click(object sender, EventArgs e)
        {
            GF2 gf2 = new GF2();
            gf2.Show();
        }

        private void btnGF03_Click(object sender, EventArgs e)
        {
            GF3 gf3 = new GF3();
            gf3.Show();
        }

        private void btnGF04_Click(object sender, EventArgs e)
        {
            GF4 gf4 = new GF4();
            gf4.Show();
        }

        private void btnGF05_Click(object sender, EventArgs e)
        {
            GF5 gf5 = new GF5();
            gf5.Show();
        }

        private void btnGF06_Click(object sender, EventArgs e)
        {
            GF6 gf6 = new GF6();
            gf6.Show();
        }

        private void btnImplementation_Click(object sender, EventArgs e)
        {
            GFImplementation gfImplementation = new GFImplementation();
            gfImplementation.Show();
        }
    }
}
