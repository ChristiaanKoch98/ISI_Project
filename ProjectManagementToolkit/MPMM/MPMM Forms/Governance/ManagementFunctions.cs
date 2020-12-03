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
    public partial class ManagementFunctions : Form
    {
        public ManagementFunctions()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMF1_Click(object sender, EventArgs e)
        {
            MF1 mF1 = new MF1();
            mF1.Show();
        }

        private void btnMF2_Click(object sender, EventArgs e)
        {
            MF2 mF2= new MF2();
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
