using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectManagementToolkit.MPMM.MPMM_Document_Models;
using ProjectManagementToolkit.Utility;
using ProjectManagementToolkit.Properties;
using Newtonsoft.Json;
using MoreLinq;

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Forms
{
    public partial class PhaseReviewFormExecutionDocumentForm : Form
    {
        VersionControl<PhaseReviewFormExecutionModel> versionControl;
        PhaseReviewFormExecutionModel newPhaseReviewExeModel;
        PhaseReviewFormExecutionModel currentPhaseReviewExeModel;

        public PhaseReviewFormExecutionDocumentForm()
        {
            InitializeComponent();
        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void PhaseReviewFormExecutionDocumentForm_Load(object sender, EventArgs e)
        {
            loadDocument();
        }

        private void loadDocument()
        {
            string json = JsonHelper.loadDocument(Settings.Default.ProjectID, "PhaseReviewExecution");
            List<string[]> documentInfo = new List<string[]>();
            newPhaseReviewExeModel = new PhaseReviewFormExecutionModel();
            currentPhaseReviewExeModel = new PhaseReviewFormExecutionModel();

            if (json != "")
            {
                txtProjectName2.Text = currentPhaseReviewExeModel.ProjectName;
                txtProjectManager.Text = currentPhaseReviewExeModel.ProjectManager;
                txtProjectSponsor.Text = currentPhaseReviewExeModel.ProjectSponsor;
                txtReportPreparedBy.Text = currentPhaseReviewExeModel.ReportPreparedBy;
                txtReportPreperationDate.Text = currentPhaseReviewExeModel.ReportPreparationDate.ToString();

                txtSummary.Text = currentPhaseReviewExeModel.Summary;
                txtProjectSchedule.Text = currentPhaseReviewExeModel.ProjectSchedule;
                txtProjectExpenses.Text = currentPhaseReviewExeModel.ProjectExpenses;
                txtProjectDeliverables.Text = currentPhaseReviewExeModel.ProjectDeliverables;
                txtProjectRisks.Text = currentPhaseReviewExeModel.ProjectRisks;
                txtProjectIssues.Text = currentPhaseReviewExeModel.ProjectIssues;
                txtProjectChanges.Text = currentPhaseReviewExeModel.ProjectChanges;

                txtSupportingDocumentation.Text = currentPhaseReviewExeModel.SupportingDocumentation;
                txtSignature.Text = currentPhaseReviewExeModel.Signature;
                txtDate.Text = currentPhaseReviewExeModel.SignatureDate.ToString();

            }
            else
            {
     
            }            
        }

        private void saveDocument()
        {
            newPhaseReviewExeModel.ProjectName = txtProjectName2.Text;
            newPhaseReviewExeModel.ProjectManager = txtProjectManager.Text;
            newPhaseReviewExeModel.ProjectSponsor = txtProjectSponsor.Text;
            newPhaseReviewExeModel.ReportPreparedBy = txtReportPreparedBy.Text;
            newPhaseReviewExeModel.ReportPreparationDate = txtReportPreperationDate.Text;

            newPhaseReviewExeModel.Summary = txtSummary.Text;
            newPhaseReviewExeModel.ProjectSchedule = txtProjectSchedule.Text;
            newPhaseReviewExeModel.ProjectExpenses = txtProjectExpenses.Text;
            newPhaseReviewExeModel.ProjectDeliverables = txtProjectDeliverables.Text;
            newPhaseReviewExeModel.ProjectRisks = txtProjectRisks.Text;
            newPhaseReviewExeModel.ProjectIssues = txtProjectIssues.Text;
            newPhaseReviewExeModel.ProjectChanges = txtProjectChanges.Text;

            newPhaseReviewExeModel.SupportingDocumentation = txtSupportingDocumentation.Text;
            newPhaseReviewExeModel.Signature = txtSignature.Text;
            newPhaseReviewExeModel.SignatureDate = txtDate.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveDocument();
        }
    }
}
