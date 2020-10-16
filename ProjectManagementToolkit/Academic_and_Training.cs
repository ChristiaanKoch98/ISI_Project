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
    public partial class Academic_and_Training : Form
    {
        public Academic_and_Training()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            panelContacts.Visible = true;
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panelAcademicAndTraining.Visible = true;
            panelContacts.Visible = false;
        }

        private void panelAcademicAndTraining_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabPage14_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage15_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabPage22_Click(object sender, EventArgs e)
        {

        }
    }
}
