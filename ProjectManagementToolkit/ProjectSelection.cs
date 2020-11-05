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
    public partial class ProjectSelection : Form
    {
        public ProjectSelection()
        {
            InitializeComponent();
            Properties.Settings.Default.ProjectID = "test";
        }

        private void tabPageExistingProjects_Click(object sender, EventArgs e)
        {

        }

        private void btnSelectProject_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            this.Visible = false;
            mainForm.Show();
        }
    }
}
