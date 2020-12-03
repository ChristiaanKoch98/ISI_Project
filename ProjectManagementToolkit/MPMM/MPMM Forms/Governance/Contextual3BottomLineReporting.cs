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
    public partial class Contextual3BottomLineReporting : Form
    {
        public Contextual3BottomLineReporting()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn6C01_Click(object sender, EventArgs e)
        {
            _6C01 _6c01 = new _6C01();
            _6c01.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _6C02 _6c02 = new _6C02();
            _6c02.Show();
        }
    }
}
