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
    public partial class ExpenseRegister : Form
    {
        public ExpenseRegister()
        {
            InitializeComponent();
        }

        private void btnEnterData_Click(object sender, EventArgs e)
        {
            string projectName = txtProjectName.Text;
            string projectManager = txtProjectManager.Text;
        }
    }
}
