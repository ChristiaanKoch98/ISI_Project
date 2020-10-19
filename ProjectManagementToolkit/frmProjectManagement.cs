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
    public partial class frmProjectManagement : Form
    {
        public frmProjectManagement()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime datetime = DateTime.Now;
            this.lblReportCenterDate.Text = datetime.ToString("dddd, MMMM dd, yyyy");
            this.lblReportCenterTime.Text = datetime.ToString("hh:mm tt");
        }

        private void linkOpenProjects_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lblSelectingReport.Text = linkOpenProjects.Text;
        }

        private void linkProjectsBalanceSheet_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lblSelectingReport.Text = linkProjectsBalanceSheet.Text;
        }

        private void btnGovernanceProcess_Click(object sender, EventArgs e)
        {
            tbcProcesses.SelectTab(0);
        }

        private void btnRiskManagement_Click(object sender, EventArgs e)
        {
            tbcProcesses.SelectTab(9);
        }

        private void btnChnageManagement_Click(object sender, EventArgs e)
        {
            tbcProcesses.SelectTab(2);
        }

        private void btnCostAndExpenseManagement_Click(object sender, EventArgs e)
        {
            tbcProcesses.SelectTab(1);
        }

        private void btnCommunicationAndStakeholderManagement_Click(object sender, EventArgs e)
        {
            tbcProcesses.SelectTab(3);
        }

        private void btnIssueManagement_Click(object sender, EventArgs e)
        {
            tbcProcesses.SelectTab(4);
        }

        private void btnQualityManagement_Click(object sender, EventArgs e)
        {
            tbcProcesses.SelectTab(10);
        }

        private void btnAcceptanceManagement_Click(object sender, EventArgs e)
        {
            tbcProcesses.SelectTab(5);
        }

        private void btnProcurementManagement_Click(object sender, EventArgs e)
        {
            tbcProcesses.SelectTab(6);
        }

        private void btnTimeAllocation_Click(object sender, EventArgs e)
        {
            tbcProcesses.SelectTab(7);
        }

        private void btnExceptionManagement_Click(object sender, EventArgs e)
        {
            tbcProcesses.SelectTab(8);
        }

    }
}
