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

        private void exportToWord()
        {
            string path;
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                saveFileDialog.Filter = "Word 97-2003 Documents (*.doc)|*.doc|Word 2007 Documents (*.docx)|*.docx";
                saveFileDialog.FilterIndex = 2;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    path = saveFileDialog.FileName;
                    using (var document = DocX.Create(path))
                    {
                        var title = p.InsertParagraphBeforeSelf("Table of Contents").Bold().FontSize(20);

                        var tocSwitches = new Dictionary<TableOfContentsSwitches, string>()
                        {
                            { TableOfContentsSwitches.O, "1-3"},
                            { TableOfContentsSwitches.U, ""},
                            { TableOfContentsSwitches.Z, ""},
                            { TableOfContentsSwitches.H, ""}
                        };

                        document.InsertTableOfContents(p, "", tocSwitches);
                        document.InsertParagraph().InsertPageBreakAfterSelf();
                        var CommunicationReqHeading = document.InsertParagraph("1 Project details")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        CommunicationReqHeading.StyleId = "Heading1";

                        var ComPlanHeading = document.InsertParagraph("1.1 Project name")
                     .Bold()
                     .FontSize(12d)
                     .Color(Color.Black)
                     .Bold(true)
                     .Font("Arial");

                        document.InsertParagraph(currentPhaseReviewExeModel.ProjectName)
                             .FontSize(11d)
                             .Color(Color.Black)
                             .Font("Arial").Alignment = Alignment.left;


                        ComPlanHeading.StyleId = "Heading2";

                        var projIDHeading = document.InsertParagraph("1.2 Project ID")
                         .Bold()
                         .FontSize(12d)
                         .Color(Color.Black)
                         .Bold(true)
                         .Font("Arial");

                        document.InsertParagraph(currentPhaseReviewExeModel.ProjectID)
                             .FontSize(11d)
                             .Color(Color.Black)
                             .Font("Arial").Alignment = Alignment.left;


                        projIDHeading.StyleId = "Heading2";

                        var promanagerHeading = document.InsertParagraph("1.3 Project manager")
                         .Bold()
                         .FontSize(12d)
                         .Color(Color.Black)
                         .Bold(true)
                         .Font("Arial");

                        document.InsertParagraph(currentPhaseReviewExeModel.ProjectManager)
                             .FontSize(11d)
                             .Color(Color.Black)
                             .Font("Arial").Alignment = Alignment.left;


                        promanagerHeading.StyleId = "Heading2";

                        var sponsorHeading = document.InsertParagraph("1.4 Project sponsor")
                         .Bold()
                         .FontSize(12d)
                         .Color(Color.Black)
                         .Bold(true)
                         .Font("Arial");

                        document.InsertParagraph(currentPhaseReviewExeModel.ProjectSponsor)
                             .FontSize(11d)
                             .Color(Color.Black)
                             .Font("Arial").Alignment = Alignment.left;


                        sponsorHeading.StyleId = "Heading2";

                        var reportHeading = document.InsertParagraph("1.5 Report prepared by")
                        .Bold()
                        .FontSize(12d)
                        .Color(Color.Black)
                        .Bold(true)
                        .Font("Arial");

                        document.InsertParagraph(currentPhaseReviewExeModel.ReportPreparedBy)
                             .FontSize(11d)
                             .Color(Color.Black)
                             .Font("Arial").Alignment = Alignment.left;


                        sponsorHeading.StyleId = "Heading2";

                        var prepdateHeading = document.InsertParagraph("1.6 Report preperation date")
                        .Bold()
                        .FontSize(12d)
                        .Color(Color.Black)
                        .Bold(true)
                        .Font("Arial");

                        document.InsertParagraph(currentPhaseReviewExeModel.ReportPreparationDate)
                             .FontSize(11d)
                             .Color(Color.Black)
                             .Font("Arial").Alignment = Alignment.left;


                        prepdateHeading.StyleId = "Heading2";

                        var rperHeading = document.InsertParagraph("1.7 Reporting Period")
                        .Bold()
                        .FontSize(12d)
                        .Color(Color.Black)
                        .Bold(true)
                        .Font("Arial");

                        document.InsertParagraph(currentPhaseReviewExeModel.PreperationPeriod)
                             .FontSize(11d)
                             .Color(Color.Black)
                             .Font("Arial").Alignment = Alignment.left;


                        rperHeading.StyleId = "Heading2";

                        var recHeading = document.InsertParagraph("1.8 Reporting Recipients")
                        .Bold()
                        .FontSize(12d)
                        .Color(Color.Black)
                        .Bold(true)
                        .Font("Arial");

                        document.InsertParagraph(currentPhaseReviewExeModel.Recipients)
                             .FontSize(11d)
                             .Color(Color.Black)
                             .Font("Arial").Alignment = Alignment.left;


                        recHeading.StyleId = "Heading2";

                        var sumHeading = document.InsertParagraph("2 Overall status")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        CommunicationReqHeading.StyleId = "Heading1";

                        var desHeading = document.InsertParagraph("2.1 Project Summary")
                     .Bold()
                     .FontSize(12d)
                     .Color(Color.Black)
                     .Bold(true)
                     .Font("Arial");

                        document.InsertParagraph(currentPhaseReviewExeModel.Summary)
                             .FontSize(11d)
                             .Color(Color.Black)
                             .Font("Arial").Alignment = Alignment.left;


                        desHeading.StyleId = "Heading2";




                        var scheHeading = document.InsertParagraph("2.2 Project schedule")
                         .Bold()
                         .FontSize(12d)
                         .Color(Color.Black)
                         .Bold(true)
                         .Font("Arial");

                        document.InsertParagraph(currentPhaseReviewExeModel.ProjectSchedule)
                             .FontSize(11d)
                             .Color(Color.Black)
                             .Font("Arial").Alignment = Alignment.left;


                        scheHeading.StyleId = "Heading2";

                        var expensesHeading = document.InsertParagraph("2.3 Project expenses")
                         .Bold()
                         .FontSize(12d)
                         .Color(Color.Black)
                         .Bold(true)
                         .Font("Arial");

                        document.InsertParagraph(currentPhaseReviewExeModel.ProjectExpenses)
                             .FontSize(11d)
                             .Color(Color.Black)
                             .Font("Arial").Alignment = Alignment.left;


                        expensesHeading.StyleId = "Heading2";

                        var delivHeading = document.InsertParagraph("2.4 Project Deliverables")
                        .Bold()
                        .FontSize(12d)
                        .Color(Color.Black)
                        .Bold(true)
                        .Font("Arial");

                        document.InsertParagraph(currentPhaseReviewExeModel.ProjectDeliverables)
                             .FontSize(11d)
                             .Color(Color.Black)
                             .Font("Arial").Alignment = Alignment.left;


                        delivHeading.StyleId = "Heading2";

                        var riskHeading = document.InsertParagraph("2.5 Project risks")
                        .Bold()
                        .FontSize(12d)
                        .Color(Color.Black)
                        .Bold(true)
                        .Font("Arial");

                        document.InsertParagraph(currentPhaseReviewExeModel.ProjectRisks)
                             .FontSize(11d)
                             .Color(Color.Black)
                             .Font("Arial").Alignment = Alignment.left;


                        riskHeading.StyleId = "Heading2";

                        var issuesHeading = document.InsertParagraph("2.6 Reporting Issues")
                        .Bold()
                        .FontSize(12d)
                        .Color(Color.Black)
                        .Bold(true)
                        .Font("Arial");

                        document.InsertParagraph(currentPhaseReviewExeModel.ProjectIssues)
                             .FontSize(11d)
                             .Color(Color.Black)
                             .Font("Arial").Alignment = Alignment.left;


                        issuesHeading.StyleId = "Heading2";

                        var changesHeading = document.InsertParagraph("2.7 Reporting Changes")
                        .Bold()
                        .FontSize(12d)
                        .Color(Color.Black)
                        .Bold(true)
                        .Font("Arial");

                        document.InsertParagraph(currentPhaseReviewExeModel.ProjectChanges)
                             .FontSize(11d)
                             .Color(Color.Black)
                             .Font("Arial").Alignment = Alignment.left;


                        changesHeading.StyleId = "Heading2";

                        var adHeading = document.InsertParagraph("3 Approval details")
                           .Bold()
                           .FontSize(14d)
                           .Color(Color.Black)
                           .Bold(true)
                           .Font("Arial");

                        CommunicationReqHeading.StyleId = "Heading1";

                        var sdHeading = document.InsertParagraph("3.1 Supporting documentation")
                     .Bold()
                     .FontSize(12d)
                     .Color(Color.Black)
                     .Bold(true)
                     .Font("Arial");

                        document.InsertParagraph(currentPhaseReviewExeModel.SupportingDocumentation)
                             .FontSize(11d)
                             .Color(Color.Black)
                             .Font("Arial").Alignment = Alignment.left;


                        sdHeading.StyleId = "Heading2";




                        var psSignature = document.InsertParagraph("3.2 Project signature")
                         .Bold()
                         .FontSize(12d)
                         .Color(Color.Black)
                         .Bold(true)
                         .Font("Arial");

                        document.InsertParagraph(currentPhaseReviewExeModel.Signature)
                             .FontSize(11d)
                             .Color(Color.Black)
                             .Font("Arial").Alignment = Alignment.left;


                        psSignature.StyleId = "Heading2";

                        var dateHeading = document.InsertParagraph("3.3 Date")
                         .Bold()
                         .FontSize(12d)
                         .Color(Color.Black)
                         .Bold(true)
                         .Font("Arial");

                        document.InsertParagraph(currentPhaseReviewExeModel.SignatureDate)
                             .FontSize(11d)
                             .Color(Color.Black)
                             .Font("Arial").Alignment = Alignment.left;


                        dateHeading.StyleId = "Heading2";
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveDocument();
        }
    }
}
