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
    public partial class Governance : Form
    {
        public Governance()
        {
            InitializeComponent();
        }

        private void btnOpenInNewTab_Click(object sender, EventArgs e)
        {
            //This button in the access program has a print symbol next to it, so I do not know if we still want to implement this or if this button should be removed
        }

        private void btnLEgislativeEnviroment_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 3;
        }

        private void btnProcessesandLegislationMatrix_Click(object sender, EventArgs e)
        {
            ProjectManagementToolkit.MPMM.MPMM_Forms.Governance.ProcessesAndLegislationMatrix formOpenProcess = new MPMM.MPMM_Forms.Governance.ProcessesAndLegislationMatrix();
            formOpenProcess.Show();
        }

        private void btnPrinciplesandLegislationMatrix_Click(object sender, EventArgs e)
        {
            ProjectManagementToolkit.MPMM.MPMM_Forms.Governance.PrinciplesandLegislationMatrix formOpenPrinciples = new MPMM.MPMM_Forms.Governance.PrinciplesandLegislationMatrix();
            formOpenPrinciples.Show();
        }

        private void btnCompanyGoals_Click(object sender, EventArgs e)
        {
            ProjectManagementToolkit.MPMM.MPMM_Forms.Governance.CompanyGoals formOpenCompanyGoals = new MPMM.MPMM_Forms.Governance.CompanyGoals();
            formOpenCompanyGoals.Show();
        }

        private void btnGoverningBodyResponsibiities_Click(object sender, EventArgs e)
        {
            ProjectManagementToolkit.MPMM.MPMM_Forms.Governance.GoverningBodyResponsibilities formOpenGBR = new MPMM.MPMM_Forms.Governance.GoverningBodyResponsibilities();
            formOpenGBR.Show();
        }

        private void btnGovernanceGoals_Click(object sender, EventArgs e)
        {
            ProjectManagementToolkit.MPMM.MPMM_Forms.Governance.GovernanceGoals formOpenGovernanceGoals = new MPMM.MPMM_Forms.Governance.GovernanceGoals();
            formOpenGovernanceGoals.Show();
        }

        private void btnGovernanceFunctions_Click(object sender, EventArgs e)
        {
            ProjectManagementToolkit.MPMM.MPMM_Forms.Governance.GovernanceFunctions formOpengovernanceFunctions = new MPMM.MPMM_Forms.Governance.GovernanceFunctions();
            formOpengovernanceFunctions.Show();
        }

        private void btnGovernancePrinciples_Click(object sender, EventArgs e)
        {
            ProjectManagementToolkit.MPMM.MPMM_Forms.Governance.GovernancePrinciples formOpengovernancePrinciples = new MPMM.MPMM_Forms.Governance.GovernancePrinciples();
            formOpengovernancePrinciples.Show();
        }

        private void btnGovernanceProcesses_Click(object sender, EventArgs e)
        {
            ProjectManagementToolkit.MPMM.MPMM_Forms.Governance.GovernanceProcesses formOpengovernanceProcesses = new MPMM.MPMM_Forms.Governance.GovernanceProcesses();
            formOpengovernanceProcesses.Show();
        }

        private void btnGovernanceOutcomes_Click(object sender, EventArgs e)
        {
            ProjectManagementToolkit.MPMM.MPMM_Forms.Governance.GovernanceOutcomes formOpengovernanceOutcomes = new MPMM.MPMM_Forms.Governance.GovernanceOutcomes();
            formOpengovernanceOutcomes.Show();
        }

        private void btnGovernanceFlows_Click(object sender, EventArgs e)
        {
            ProjectManagementToolkit.MPMM.MPMM_Forms.Governance.GovernanceFlows formOpengovernaneFlows = new MPMM.MPMM_Forms.Governance.GovernanceFlows();
            formOpengovernaneFlows.Show();
        }

        private void btnGovernanceExecutionStructures_Click(object sender, EventArgs e)
        {
            ProjectManagementToolkit.MPMM.MPMM_Forms.Governance.GovernanceExecutionStructure formOpengovernanceExecutionStructure = new MPMM.MPMM_Forms.Governance.GovernanceExecutionStructure();
            formOpengovernanceExecutionStructure.Show();
        }

        private void btnUnderpinningConcepts_Click(object sender, EventArgs e)
        {
            ProjectManagementToolkit.MPMM.MPMM_Forms.Governance.UnderpinningConcepts formOpenunderpinningConcepts = new MPMM.MPMM_Forms.Governance.UnderpinningConcepts();
            formOpenunderpinningConcepts.Show();
        }
    }
}
