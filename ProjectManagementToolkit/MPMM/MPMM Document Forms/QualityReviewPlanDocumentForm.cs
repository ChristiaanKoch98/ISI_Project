using Newtonsoft.Json;
using ProjectManagementToolkit.MPMM.MPMM_Document_Models;
using ProjectManagementToolkit.Properties;
using ProjectManagementToolkit.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Forms
{
    public partial class QualityReviewPlanDocumentForm : Form
    {
        VersionControl<QualityReviewPlanModel> versionControl;
        QualityReviewPlanModel newQualityReviewPlanModel;
        QualityReviewPlanModel currentQualityReviewPlanModel;
        Color TABLE_HEADER_COLOR = Color.FromArgb(73, 173, 252);
        ProjectModel projectModel = new ProjectModel();
        public QualityReviewPlanDocumentForm()
        {
            InitializeComponent();
        }

        private void QualityReviewPlanDocumentForm_Load(object sender, EventArgs e)
        {
            loadDocument();
            string json = JsonHelper.loadProjectInfo(Settings.Default.Username);
            List<ProjectModel> projectListModel = JsonConvert.DeserializeObject<List<ProjectModel>>(json);
            projectModel = projectModel.getProjectModel(Settings.Default.ProjectID, projectListModel);
            txtQualityReviewFormProjectName.Text = projectModel.ProjectName;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveDocument();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            exportToWord();
        }
        public void saveDocument()
        {
            newQualityReviewPlanModel.ProjectName = projectModel.ProjectName;

            newQualityReviewPlanModel.QualityOfProcessDescription = txtQualityOfProcess.Text;

            List<QualityReviewPlanModel.QualityOfProcess> processes = new List<QualityReviewPlanModel.QualityOfProcess>();
            int processesRowsCount = dataGridViewQualityOfProcess.Rows.Count;

            for (int i = 0; i < processesRowsCount - 1; i++)
            {
                QualityReviewPlanModel.QualityOfProcess processMod = new QualityReviewPlanModel.QualityOfProcess();
                var process = dataGridViewQualityOfProcess.Rows[i].Cells[0].Value?.ToString() ?? "";
                var procedure = dataGridViewQualityOfProcess.Rows[i].Cells[1].Value?.ToString() ?? "";
                var standardMet = dataGridViewQualityOfProcess.Rows[i].Cells[2].Value?.ToString() ?? "";
                var deviation = dataGridViewQualityOfProcess.Rows[i].Cells[3].Value?.ToString() ?? "";
                var corrective = dataGridViewQualityOfProcess.Rows[i].Cells[4].Value?.ToString() ?? "";

                processMod.Process = process;
                processMod.Procedure = procedure;
                processMod.StandardMet = standardMet;
                processMod.Deviation = deviation;
                processMod.CorrectiveAction = corrective;
                processes.Add(processMod);
            }
            newQualityReviewPlanModel.QualityOfProcesses = processes;

            newQualityReviewPlanModel.QualityOfDeliverablesDescription = txtQualityOfDeliverables.Text;

            List<QualityReviewPlanModel.QualityOfDeliverable> deliverables = new List<QualityReviewPlanModel.QualityOfDeliverable>();
            int deliverablesRowsCount = dataGridViewQualityOfDeliverables.Rows.Count;

            for (int i = 0; i < deliverablesRowsCount - 1; i++)
            {
                QualityReviewPlanModel.QualityOfDeliverable deliverableMod = new QualityReviewPlanModel.QualityOfDeliverable();
                var requirement = dataGridViewQualityOfDeliverables.Rows[i].Cells[0].Value?.ToString() ?? "";
                var deliverable = dataGridViewQualityOfDeliverables.Rows[i].Cells[1].Value?.ToString() ?? "";
                var qualityCrit = dataGridViewQualityOfDeliverables.Rows[i].Cells[2].Value?.ToString() ?? "";
                var qualityStd = dataGridViewQualityOfDeliverables.Rows[i].Cells[3].Value?.ToString() ?? "";
                var stdMet = dataGridViewQualityOfDeliverables.Rows[i].Cells[4].Value?.ToString() ?? "";
                var qualDev = dataGridViewQualityOfDeliverables.Rows[i].Cells[5].Value?.ToString() ?? "";
                var action = dataGridViewQualityOfDeliverables.Rows[i].Cells[6].Value?.ToString() ?? "";

                deliverableMod.Requirement = requirement;
                deliverableMod.Deliverable = deliverable;
                deliverableMod.QualityCriteria = qualityCrit;
                deliverableMod.QualityStandard = qualityStd;
                deliverableMod.StandardMet = stdMet;
                deliverableMod.QualityDeviation = qualDev;
                deliverableMod.CorrectiveActionsRequired = action;
                deliverables.Add(deliverableMod);
            }
            newQualityReviewPlanModel.QualityOfDeliverables = deliverables;

            List<VersionControl<QualityReviewPlanModel>.DocumentModel> documentModels = versionControl.DocumentModels;


            if (!versionControl.isEqual(currentQualityReviewPlanModel, newQualityReviewPlanModel))
            {
                VersionControl<QualityReviewPlanModel>.DocumentModel documentModel = new VersionControl<QualityReviewPlanModel>.DocumentModel(newQualityReviewPlanModel, DateTime.Now, VersionControl<QualityReviewPlanModel>.generateID());

                documentModels.Add(documentModel);

                versionControl.DocumentModels = documentModels;
                string json = JsonConvert.SerializeObject(versionControl);
                currentQualityReviewPlanModel = JsonConvert.DeserializeObject<QualityReviewPlanModel>(JsonConvert.SerializeObject(newQualityReviewPlanModel));
                JsonHelper.saveDocument(json, Settings.Default.ProjectID, "QualityReviewPlan");
                MessageBox.Show("Project plan saved successfully", "save", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("No changes was made!", "save", MessageBoxButtons.OK);
            }

        }

        private void loadDocument()
        {
            string json = JsonHelper.loadDocument(Settings.Default.ProjectID, "QualityReviewPlan");
            List<string[]> documentInfo = new List<string[]>();
            newQualityReviewPlanModel = new QualityReviewPlanModel();
            currentQualityReviewPlanModel = new QualityReviewPlanModel();
            
            if (json != "")
            {
                versionControl = JsonConvert.DeserializeObject<VersionControl<QualityReviewPlanModel>>(json);
                newQualityReviewPlanModel = JsonConvert.DeserializeObject<QualityReviewPlanModel>(versionControl.getLatest(versionControl.DocumentModels));
                currentQualityReviewPlanModel = JsonConvert.DeserializeObject<QualityReviewPlanModel>(versionControl.getLatest(versionControl.DocumentModels));
                txtQualityOfProcess.Text = newQualityReviewPlanModel.QualityOfProcessDescription;

                foreach (var row in currentQualityReviewPlanModel.QualityOfProcesses)
                {
                    dataGridViewQualityOfProcess.Rows.Add(new string[] { row.Process, row.Procedure, row.StandardMet, row.Deviation, row.CorrectiveAction });
                }

                txtQualityOfDeliverables.Text = newQualityReviewPlanModel.QualityOfDeliverablesDescription;

                foreach (var row in currentQualityReviewPlanModel.QualityOfDeliverables)
                {
                    dataGridViewQualityOfDeliverables.Rows.Add(new string[] { row.Requirement, row.Deliverable, row.QualityCriteria, row.QualityStandard, row.StandardMet, row.QualityDeviation, row.CorrectiveActionsRequired });
                }

            }
            else
            {
                versionControl = new VersionControl<QualityReviewPlanModel>();
                versionControl.DocumentModels = new List<VersionControl<QualityReviewPlanModel>.DocumentModel>();
            }

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
                        
                        for (int i = 0; i < 11; i++)
                        {
                            document.InsertParagraph("")
                                .Font("Arial")
                                .Bold(true)
                                .FontSize(22d).Alignment = Alignment.left;
                        }
                        document.InsertParagraph("Quality Review Form \nFor " + projectModel.ProjectName)
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(22d).Alignment = Alignment.left;
                        var section = document.InsertSectionPageBreak();

                        section.PageLayout.Orientation = Xceed.Document.NET.Orientation.Landscape;

                        var QualityProcesses = document.InsertParagraph("1\tQuality of Processes")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");
                        QualityProcesses.StyleId = "Heading1";

                        document.InsertParagraph(currentQualityReviewPlanModel.QualityOfProcessDescription)
                           .FontSize(11d)
                           .Color(Color.Black)
                           .Font("Arial").Alignment = Alignment.left;


                        var qualityProcess = document.AddTable(currentQualityReviewPlanModel.QualityOfProcesses.Count + 2, 5);

                        qualityProcess.Rows[0].MergeCells(0, 1);
                        qualityProcess.Rows[0].MergeCells(1, 3);

                        qualityProcess.Rows[0].Cells[0].Paragraphs[0].Append("Project Process")
                             .Bold(true)
                             .Color(Color.White)
                             .SpacingBefore(6d)
                             .SpacingAfter(6d);
                        qualityProcess.Rows[0].Cells[1].Paragraphs[0].Append("Quality Achieved")
                            .Bold(true)
                            .Color(Color.White)
                            .SpacingBefore(6d)
                            .SpacingAfter(6d);

                        qualityProcess.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        qualityProcess.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;

                        qualityProcess.Rows[1].Cells[0].Paragraphs[0].Append("Process")
                             .Bold(true)
                             .Color(Color.Black)
                             .SpacingBefore(6d)
                             .SpacingAfter(6d);
                        qualityProcess.Rows[1].Cells[1].Paragraphs[0].Append("Procedure")
                            .Bold(true)
                            .Color(Color.Black)
                            .SpacingBefore(6d)
                            .SpacingAfter(6d);
                        qualityProcess.Rows[1].Cells[2].Paragraphs[0].Append("Standard Met?")
                             .Bold(true)
                             .Color(Color.Black)
                             .SpacingBefore(6d)
                             .SpacingAfter(6d);
                        qualityProcess.Rows[1].Cells[3].Paragraphs[0].Append("Deviation")
                            .Bold(true)
                            .Color(Color.Black)
                            .SpacingBefore(6d)
                            .SpacingAfter(6d);
                        qualityProcess.Rows[1].Cells[4].Paragraphs[0].Append("Corrective Action")
                             .Bold(true)
                             .Color(Color.Black)
                             .SpacingBefore(6d)
                             .SpacingAfter(6d);

                        

                        for (int i = 2; i < currentQualityReviewPlanModel.QualityOfProcesses.Count + 2; i++)
                        {
                            qualityProcess.Rows[i].Cells[0].Paragraphs[0].Append(currentQualityReviewPlanModel.QualityOfProcesses[i - 2].Process);
                            qualityProcess.Rows[i].Cells[1].Paragraphs[0].Append(currentQualityReviewPlanModel.QualityOfProcesses[i - 2].Procedure);
                            qualityProcess.Rows[i].Cells[2].Paragraphs[0].Append(currentQualityReviewPlanModel.QualityOfProcesses[i - 2].StandardMet);
                            qualityProcess.Rows[i].Cells[3].Paragraphs[0].Append(currentQualityReviewPlanModel.QualityOfProcesses[i - 2].Deviation);
                            qualityProcess.Rows[i].Cells[4].Paragraphs[0].Append(currentQualityReviewPlanModel.QualityOfProcesses[i - 2].CorrectiveAction);
                        }
                        
                        qualityProcess.AutoFit = AutoFit.Window;
                        document.InsertTable(qualityProcess);

                        //////


                        var QualityDeliverables = document.InsertParagraph("2\tQuality of Deliverables")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");
                        QualityDeliverables.StyleId = "Heading1";

                        document.InsertParagraph(currentQualityReviewPlanModel.QualityOfDeliverablesDescription)
                           .FontSize(11d)
                           .Color(Color.Black)
                           .Font("Arial").Alignment = Alignment.left;


                        /*var splitDeliverable = document.AddTable(1, 3);

                        splitDeliverable.Rows[0].Cells[0].Paragraphs[0].Append("Project Deliverable")
                             .Bold(true)
                             .Color(Color.White)
                             .SpacingBefore(6d)
                             .SpacingAfter(6d);
                        splitDeliverable.Rows[0].Cells[1].Paragraphs[0].Append("Quality Target")
                            .Bold(true)
                            .Color(Color.White)
                            .SpacingBefore(6d)
                            .SpacingAfter(6d);
                        splitDeliverable.Rows[0].Cells[2].Paragraphs[0].Append("Quality Achieved")
                            .Bold(true)
                            .Color(Color.White)
                            .SpacingBefore(6d)
                            .SpacingAfter(6d);


                        splitDeliverable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        splitDeliverable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        splitDeliverable.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;

                        float QoDwidth_1 = 3000;
                        float QoDwidth_2 = 2500;
                        float QoDwidth_3 = 3000;


                        splitDeliverable.SetWidths(new float[] { QoDwidth_1, QoDwidth_2, QoDwidth_3 });

             

                        document.InsertTable(splitDeliverable);*/


                        var qualityDeliverable = document.AddTable(currentQualityReviewPlanModel.QualityOfDeliverables.Count + 2, 7);

                        qualityDeliverable.Rows[0].MergeCells(0, 1);
                        qualityDeliverable.Rows[0].MergeCells(1, 2);
                        qualityDeliverable.Rows[0].MergeCells(2, 4);

                        qualityDeliverable.Rows[0].Cells[0].Paragraphs[0].Append("Project Deliverable")
                             .Bold(true)
                             .Color(Color.White)
                             .SpacingBefore(6d)
                             .SpacingAfter(6d);
                        qualityDeliverable.Rows[0].Cells[1].Paragraphs[0].Append("Quality Target")
                            .Bold(true)
                            .Color(Color.White)
                            .SpacingBefore(6d)
                            .SpacingAfter(6d);
                        qualityDeliverable.Rows[0].Cells[2].Paragraphs[0].Append("Quality Achieved")
                            .Bold(true)
                            .Color(Color.White)
                            .SpacingBefore(6d)
                            .SpacingAfter(6d);

                        qualityDeliverable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        qualityDeliverable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        qualityDeliverable.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;


                        qualityDeliverable.Rows[1].Cells[0].Paragraphs[0].Append("Requirement")
                             .Bold(true)
                             .Color(Color.Black)
                             .SpacingBefore(6d)
                             .SpacingAfter(6d);
                        qualityDeliverable.Rows[1].Cells[1].Paragraphs[0].Append("Deliverable")
                            .Bold(true)
                            .Color(Color.Black)
                            .SpacingBefore(6d)
                            .SpacingAfter(6d);
                        qualityDeliverable.Rows[1].Cells[2].Paragraphs[0].Append("Quality Criteria")
                             .Bold(true)
                             .Color(Color.Black)
                             .SpacingBefore(6d)
                             .SpacingAfter(6d);
                        qualityDeliverable.Rows[1].Cells[3].Paragraphs[0].Append("Quality Standards")
                            .Bold(true)
                            .Color(Color.Black)
                            .SpacingBefore(6d)
                            .SpacingAfter(6d);
                        qualityDeliverable.Rows[1].Cells[4].Paragraphs[0].Append("Standard Met?")
                             .Bold(true)
                             .Color(Color.Black)
                             .SpacingBefore(6d)
                             .SpacingAfter(6d);
                        qualityDeliverable.Rows[1].Cells[5].Paragraphs[0].Append("Quality Deviation")
                             .Bold(true)
                             .Color(Color.Black)
                             .SpacingBefore(6d)
                             .SpacingAfter(6d);
                        qualityDeliverable.Rows[1].Cells[6].Paragraphs[0].Append("Corrective Actions Required")
                             .Bold(true)
                             .Color(Color.Black)
                             .SpacingBefore(6d)
                             .SpacingAfter(6d);

                        for (int i = 2; i < currentQualityReviewPlanModel.QualityOfDeliverables.Count + 2; i++)
                        {
                            qualityDeliverable.Rows[i].Cells[0].Paragraphs[0].Append(currentQualityReviewPlanModel.QualityOfDeliverables[i - 2].Requirement);
                            qualityDeliverable.Rows[i].Cells[1].Paragraphs[0].Append(currentQualityReviewPlanModel.QualityOfDeliverables[i - 2].Deliverable);
                            qualityDeliverable.Rows[i].Cells[2].Paragraphs[0].Append(currentQualityReviewPlanModel.QualityOfDeliverables[i - 2].QualityCriteria);
                            qualityDeliverable.Rows[i].Cells[3].Paragraphs[0].Append(currentQualityReviewPlanModel.QualityOfDeliverables[i - 2].QualityStandard);
                            qualityDeliverable.Rows[i].Cells[4].Paragraphs[0].Append(currentQualityReviewPlanModel.QualityOfDeliverables[i - 2].StandardMet);
                            qualityDeliverable.Rows[i].Cells[5].Paragraphs[0].Append(currentQualityReviewPlanModel.QualityOfDeliverables[i - 2].QualityDeviation);
                            qualityDeliverable.Rows[i].Cells[6].Paragraphs[0].Append(currentQualityReviewPlanModel.QualityOfDeliverables[i - 2].CorrectiveActionsRequired);
                        }
                        //qualityDeliverable.SetWidths(new float[] { (float)QoDwidth_1 / 2, (float)QoDwidth_1 / 2, (float)QoDwidth_2 / 2, (float)QoDwidth_2 / 2, (float)QoDwidth_3 / 3, (float)QoDwidth_3 / 3, (float)QoDwidth_3 / 3 });
                        qualityDeliverable.AutoFit = AutoFit.Window;
                        
                        document.InsertTable(qualityDeliverable);





                        try
                        {
                            document.Save();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("The selected File is open.", "Close File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }


        }

       
    }
}
