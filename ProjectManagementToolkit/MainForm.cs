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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnItManagement_Click(object sender, EventArgs e)
        {
            tabControl2.Visible = false;
            tabControl1.Visible = true;
        }

        private void btnAssetsAndInventory_Click(object sender, EventArgs e)
        {
            tabControl2.Visible = true;
            tabControl1.Visible = false;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
