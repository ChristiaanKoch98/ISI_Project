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
    public partial class GoverningBodyResponsibilities : Form
    {
        public GoverningBodyResponsibilities()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GoverningBodyResponsibilities_Load(object sender, EventArgs e)
        {
            textBox1.ReadOnly = true;
        }
    }
}
