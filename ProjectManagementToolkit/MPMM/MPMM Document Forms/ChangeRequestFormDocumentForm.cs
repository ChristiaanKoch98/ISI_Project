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
    public partial class ChangeRequestFormDocumentForm : Form
    {
        private string projectName;

        public string ProjectName
        {
            get { return projectName; }
            set { projectName = value; }
        }

        public ChangeRequestFormDocumentForm()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
