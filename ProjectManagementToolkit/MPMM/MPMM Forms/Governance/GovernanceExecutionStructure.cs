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
    public partial class GovernanceExecutionStructure : Form
    {
        public GovernanceExecutionStructure()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGES1_Click(object sender, EventArgs e)
        {
            GES1 gES1 = new GES1();
            gES1.Show();
        }

        private void btnGES2_Click(object sender, EventArgs e)
        {
            GES2 gES2 = new GES2();
            gES2.Show();
        }

        private void btnGES3_Click(object sender, EventArgs e)
        {
            GES3 gES3 = new GES3();
            gES3.Show();
        }

        private void btnGES4_Click(object sender, EventArgs e)
        {
            GES4 gES4 = new GES4();
            gES4.Show();
        }

        private void btnGES5_Click(object sender, EventArgs e)
        {
            GES5 gES5 = new GES5();
            gES5.Show();
        }

        private void btnGES6_Click(object sender, EventArgs e)
        {
            GES6 gES6 = new GES6();
            gES6.Show();
        }

        private void btnGES7_Click(object sender, EventArgs e)
        {
            GES7 gES7 = new GES7();
            gES7.Show();
        }

        private void btnGES8_Click(object sender, EventArgs e)
        {
            GES8 gES8 = new GES8();
            gES8.Show();
        }

        private void btnProcessLegalInteractions_Click(object sender, EventArgs e)
        {
            ProcessLegalInteractions processLegalInteractions = new ProcessLegalInteractions();
            processLegalInteractions.Show();
        }

        private void btnPrinciplesLegalInteractions_Click(object sender, EventArgs e)
        {
            PrinciplesLegalInteractions principlesLegalInteractions = new PrinciplesLegalInteractions();
            principlesLegalInteractions.Show();
        }

        private void btnProcessPrincipleInteractions_Click(object sender, EventArgs e)
        {
            ProcessPrinciplesInteractions processPrinciplesInteractions = new ProcessPrinciplesInteractions();
            processPrinciplesInteractions.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PARICS pARICS = new PARICS();
            pARICS.Show();
        }
    }
}
