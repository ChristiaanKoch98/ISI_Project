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
    public partial class QualityPlanDocumentForm : Form
    {
        public QualityPlanDocumentForm()
        {
            InitializeComponent();
        }

        private void btnSaveProjectName_Click(object sender, EventArgs e)
        {
            string projectName = txtProjectName.Text;
        }

        private void btnAddAssumptions_Click(object sender, EventArgs e)
        {
            string addAssumptions = txtAssumptions.Text;
            listBoxAssumptions.Items.Add(addAssumptions);
        }

        private void btnAddConstraints_Click(object sender, EventArgs e)
        {
            string addConstraints = txtConstraints.Text;
            listBoxConstraints.Items.Add(addConstraints);
        }

        private void btnQualityActivities_Click(object sender, EventArgs e)
        {
            string addQualityAct = txtQualityActivities.Text;
            listBoxQualityActivities.Items.Add(addQualityAct);
        }

        private void btnQualityRoles_Click(object sender, EventArgs e)
        {
            string addQualityRoles = txtQualityRoles.Text;
            listBoxQualityRoles.Items.Add(addQualityRoles);
        }

        private void btnQualityDocuments_Click(object sender, EventArgs e)
        {
            string addQualityDocs = txtQualityDocuments.Text;
            listBoxQualityDocuments.Items.Add(addQualityDocs);
        }
    }
}
