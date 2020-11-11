using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectManagementToolkit.MPMM
{
    public partial class SyncForm : Form
    {
        public SyncForm()
        {
            InitializeComponent();
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            List<string> documents = new List<string>();
            documents.Add("Project Plan");
            documents.Add("Business Case");
            documents.Add("Acceptacne Plan");
            documents.Add("Financial Plan");
            documents.Add("Feasiblity Study");

            syncProgressBar.Maximum = (documents.Count);
            double progressValue = 0;
            foreach(string item in documents)
            {
                progressValue++;
                double progressPercentage = ((progressValue-1) / syncProgressBar.Maximum)*100;
                lblProgress.Text = "Progress: " + item +" - "+ progressPercentage.ToString()+"%";
                syncProgressBar.Value = (int)progressValue;
                lblProgress.Refresh();
                syncProgressBar.Refresh();
                Thread.Sleep(1000);
            }
            syncProgressBar.Value = syncProgressBar.Maximum;
            lblProgress.Text = "Progress: 100%";
            MessageBox.Show("Sync completed");
            this.Close();
        }
    }
}
