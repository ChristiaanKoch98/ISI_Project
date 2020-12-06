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
    public partial class QualityRegister : Form
    {
        VersionControl<QualityRegisterModel> versionControl;
        QualityRegisterModel newQualityRegisterModel;
        QualityRegisterModel currentQualityRegisterModel;
        Color TABLE_HEADER_COLOR = Color.FromArgb(73, 173, 252);
        ProjectModel projectModel = new ProjectModel();
        public QualityRegister()
        {
            InitializeComponent();
        }

        private void QualityRegister_Load(object sender, EventArgs e)
        {
            string json = JsonHelper.loadProjectInfo(Settings.Default.Username);
            List<ProjectModel> projectListModel = JsonConvert.DeserializeObject<List<ProjectModel>>(json);
            projectModel = projectModel.getProjectModel(Settings.Default.ProjectID, projectListModel);
            txtProjectName.Text = projectModel.ProjectName;
            txtProjectManager.Text = projectModel.ProjectManager;
            txtQualityManager.Text = projectModel.QualityManager;
            loadDocument();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveDocument();
        }

        private void saveDocument()
        {
            List<QualityRegisterModel.ConformanceOfProcess> conformanceOfProcesses = new List<QualityRegisterModel.ConformanceOfProcess>();
            List<QualityRegisterModel.QualityOfDeliverable> qualityOfDeliverables = new List<QualityRegisterModel.QualityOfDeliverable>();



            for (int i = 0; i < dgvConformanceOfProcesses.Rows.Count - 1; i++)
            {
                QualityRegisterModel.ConformanceOfProcess conformanceOfProcess = new QualityRegisterModel.ConformanceOfProcess();
                conformanceOfProcess.ID = dgvConformanceOfProcesses.Rows[i].Cells[0].Value?.ToString() ?? "";
                conformanceOfProcess.Process = dgvConformanceOfProcesses.Rows[i].Cells[1].Value?.ToString() ?? "";
                conformanceOfProcess.Procedure = dgvConformanceOfProcesses.Rows[i].Cells[2].Value?.ToString() ?? "";
                conformanceOfProcess.StandardMet = dgvConformanceOfProcesses.Rows[i].Cells[3].Value?.ToString() ?? "";
                conformanceOfProcess.Deviation = dgvConformanceOfProcesses.Rows[i].Cells[4].Value?.ToString() ?? "";
                conformanceOfProcess.CorrectiveAction = dgvConformanceOfProcesses.Rows[i].Cells[5].Value?.ToString() ?? "";
                conformanceOfProcess.Methods = dgvConformanceOfProcesses.Rows[i].Cells[6].Value?.ToString() ?? "";
                conformanceOfProcess.Date = dgvConformanceOfProcesses.Rows[i].Cells[7].Value?.ToString() ?? "";
                conformanceOfProcess.Outcome = dgvConformanceOfProcesses.Rows[i].Cells[8].Value?.ToString() ?? "";

                conformanceOfProcesses.Add(conformanceOfProcess);
            }
            for (int i = 0; i< dgvQualityOfDeliverables.Rows.Count - 1; i++)
            { 
                QualityRegisterModel.QualityOfDeliverable qualityOfDeliverable = new QualityRegisterModel.QualityOfDeliverable();
                qualityOfDeliverable.ID = dgvQualityOfDeliverables.Rows[i].Cells[0].Value?.ToString() ?? "";
                qualityOfDeliverable.Requirement = dgvQualityOfDeliverables.Rows[i].Cells[1].Value?.ToString() ?? "";
                qualityOfDeliverable.Deliverable = dgvQualityOfDeliverables.Rows[i].Cells[2].Value?.ToString() ?? "";
                qualityOfDeliverable.Criteria = dgvQualityOfDeliverables.Rows[i].Cells[3].Value?.ToString() ?? "";
                qualityOfDeliverable.Standards = dgvQualityOfDeliverables.Rows[i].Cells[4].Value?.ToString() ?? "";
                qualityOfDeliverable.MeetStandards = dgvQualityOfDeliverables.Rows[i].Cells[5].Value?.ToString() ?? "";
                qualityOfDeliverable.Deviation = dgvQualityOfDeliverables.Rows[i].Cells[6].Value?.ToString() ?? "";
                qualityOfDeliverable.CorrectiveAction = dgvQualityOfDeliverables.Rows[i].Cells[7].Value?.ToString() ?? "";
                qualityOfDeliverable.Methods = dgvQualityOfDeliverables.Rows[i].Cells[8].Value?.ToString() ?? "";
                qualityOfDeliverable.Date = dgvQualityOfDeliverables.Rows[i].Cells[9].Value?.ToString() ?? "";
                qualityOfDeliverable.Outcome = dgvQualityOfDeliverables.Rows[i].Cells[10].Value?.ToString() ?? "";

                qualityOfDeliverables.Add(qualityOfDeliverable);
            }

            newQualityRegisterModel.ConformanceOfProcesses = conformanceOfProcesses;
            newQualityRegisterModel.QualityOfDeliverables = qualityOfDeliverables;
            List<VersionControl<QualityRegisterModel>.DocumentModel> documentModels = versionControl.DocumentModels;

            if (!versionControl.isEqual(currentQualityRegisterModel,newQualityRegisterModel))
            {
                VersionControl<QualityRegisterModel>.DocumentModel documentModel = new VersionControl<QualityRegisterModel>.DocumentModel(newQualityRegisterModel, DateTime.Now, VersionControl<QualityRegisterModel>.generateID());
                documentModels.Add(documentModel);
                string json = JsonConvert.SerializeObject(versionControl);
                currentQualityRegisterModel = JsonConvert.DeserializeObject<QualityRegisterModel>(JsonConvert.SerializeObject(newQualityRegisterModel));
                JsonHelper.saveDocument(json, Settings.Default.ProjectID, "QualityRegister");
                MessageBox.Show("Quality Register saved successfully.", "Save", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("No changes were made.", "Save", MessageBoxButtons.OK);
            }
        }

        private void loadDocument()
        {
            string json = JsonHelper.loadDocument(Settings.Default.ProjectID, "QualityRegister");
            newQualityRegisterModel = new QualityRegisterModel();
            currentQualityRegisterModel = new QualityRegisterModel();


            if (json != "")
            {
                versionControl = JsonConvert.DeserializeObject<VersionControl<QualityRegisterModel>>(json);
                newQualityRegisterModel = JsonConvert.DeserializeObject<QualityRegisterModel>(versionControl.getLatest(versionControl.DocumentModels));
                currentQualityRegisterModel = JsonConvert.DeserializeObject<QualityRegisterModel>(versionControl.getLatest(versionControl.DocumentModels));

                
                    foreach (var conformanceOfProcess in currentQualityRegisterModel.ConformanceOfProcesses)
                    {
                        dgvConformanceOfProcesses.Rows.Add(new string[] {   conformanceOfProcess.ID,
                                                                            conformanceOfProcess.Process,
                                                                            conformanceOfProcess.Procedure,
                                                                            conformanceOfProcess.StandardMet,
                                                                            conformanceOfProcess.Deviation,
                                                                            conformanceOfProcess.CorrectiveAction,
                                                                            conformanceOfProcess.Methods,
                                                                            conformanceOfProcess.Date,
                                                                            conformanceOfProcess.Outcome});

                    }

                    foreach (var qualityOfDeliverable in currentQualityRegisterModel.QualityOfDeliverables)
                    {
                        dgvQualityOfDeliverables.Rows.Add(new string[] {    qualityOfDeliverable.ID,
                                                                            qualityOfDeliverable.Requirement,
                                                                            qualityOfDeliverable.Deliverable,
                                                                            qualityOfDeliverable.Criteria,
                                                                            qualityOfDeliverable.Standards,
                                                                            qualityOfDeliverable.MeetStandards,
                                                                            qualityOfDeliverable.Deviation,
                                                                            qualityOfDeliverable.CorrectiveAction,
                                                                            qualityOfDeliverable.Methods,
                                                                            qualityOfDeliverable.Date,
                                                                            qualityOfDeliverable.Outcome});
                    }
                
            }
            else
            {
                versionControl = new VersionControl<QualityRegisterModel>();
                versionControl.DocumentModels = new List<VersionControl<QualityRegisterModel>.DocumentModel>();
                newQualityRegisterModel = new QualityRegisterModel();
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            exportToWord();
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
                        document.InsertParagraph("Quality Register \nFor " + projectModel.ProjectName)
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(22d).Alignment = Alignment.left;
                        document.InsertParagraph("").InsertPageBreakAfterSelf();
                        
                        document.PageLayout.Orientation = Xceed.Document.NET.Orientation.Landscape;


                        var qualityRegisterHeading = document.InsertParagraph("Quality Register")
                             .Bold()
                             .FontSize(14d)
                             .Color(Color.Black)
                             .Bold(true)
                             .Font("Arial");

                        qualityRegisterHeading.StyleId = "Heading1";
                        
                        var conformanceOfProcessesSubHeading = document.InsertParagraph("Conformance Of Processes:")
                             .Bold()
                             .FontSize(12d)
                             .Color(Color.Black)
                             .Bold(true)
                             .Font("Arial");

                        conformanceOfProcessesSubHeading.StyleId = "Heading2";

                        var conformanceOfProcessesTable  = document.AddTable(currentQualityRegisterModel.ConformanceOfProcesses.Count + 1, 9);
                        conformanceOfProcessesTable.Rows[0].Cells[0].Paragraphs[0].Append("ID")
                            .Bold(true)
                            .Color(Color.White);
                        conformanceOfProcessesTable.Rows[0].Cells[1].Paragraphs[0].Append("Process")
                            .Bold(true)
                            .Color(Color.White);
                        conformanceOfProcessesTable.Rows[0].Cells[2].Paragraphs[0].Append("Procedure")
                            .Bold(true)
                            .Color(Color.White);
                        conformanceOfProcessesTable.Rows[0].Cells[3].Paragraphs[0].Append("Standard Met?")
                            .Bold(true)
                            .Color(Color.White);
                        conformanceOfProcessesTable.Rows[0].Cells[4].Paragraphs[0].Append("Deviation")
                            .Bold(true)
                            .Color(Color.White);
                        conformanceOfProcessesTable.Rows[0].Cells[5].Paragraphs[0].Append("Corrective Actions")
                            .Bold(true)
                            .Color(Color.White);
                        conformanceOfProcessesTable.Rows[0].Cells[6].Paragraphs[0].Append("Methods")
                            .Bold(true)
                            .Color(Color.White);
                        conformanceOfProcessesTable.Rows[0].Cells[7].Paragraphs[0].Append("Date")
                            .Bold(true)
                            .Color(Color.White);
                        conformanceOfProcessesTable.Rows[0].Cells[8].Paragraphs[0].Append("Outcome")
                            .Bold(true)
                            .Color(Color.White);
                        conformanceOfProcessesTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        conformanceOfProcessesTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        conformanceOfProcessesTable.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;
                        conformanceOfProcessesTable.Rows[0].Cells[3].FillColor = TABLE_HEADER_COLOR;
                        conformanceOfProcessesTable.Rows[0].Cells[4].FillColor = TABLE_HEADER_COLOR;
                        conformanceOfProcessesTable.Rows[0].Cells[5].FillColor = TABLE_HEADER_COLOR;
                        conformanceOfProcessesTable.Rows[0].Cells[6].FillColor = TABLE_HEADER_COLOR;
                        conformanceOfProcessesTable.Rows[0].Cells[7].FillColor = TABLE_HEADER_COLOR;
                        conformanceOfProcessesTable.Rows[0].Cells[8].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < currentQualityRegisterModel.ConformanceOfProcesses.Count + 1; i++)
                        {
                            conformanceOfProcessesTable.Rows[i].Cells[0].Paragraphs[0].Append(currentQualityRegisterModel.ConformanceOfProcesses[i - 1].ID);
                            conformanceOfProcessesTable.Rows[i].Cells[1].Paragraphs[0].Append(currentQualityRegisterModel.ConformanceOfProcesses[i - 1].Process);
                            conformanceOfProcessesTable.Rows[i].Cells[2].Paragraphs[0].Append(currentQualityRegisterModel.ConformanceOfProcesses[i - 1].Procedure);
                            conformanceOfProcessesTable.Rows[i].Cells[3].Paragraphs[0].Append(currentQualityRegisterModel.ConformanceOfProcesses[i - 1].StandardMet);
                            conformanceOfProcessesTable.Rows[i].Cells[4].Paragraphs[0].Append(currentQualityRegisterModel.ConformanceOfProcesses[i - 1].Deviation);
                            conformanceOfProcessesTable.Rows[i].Cells[5].Paragraphs[0].Append(currentQualityRegisterModel.ConformanceOfProcesses[i - 1].CorrectiveAction);
                            conformanceOfProcessesTable.Rows[i].Cells[6].Paragraphs[0].Append(currentQualityRegisterModel.ConformanceOfProcesses[i - 1].Methods);
                            conformanceOfProcessesTable.Rows[i].Cells[7].Paragraphs[0].Append(currentQualityRegisterModel.ConformanceOfProcesses[i - 1].Date);
                            conformanceOfProcessesTable.Rows[i].Cells[8].Paragraphs[0].Append(currentQualityRegisterModel.ConformanceOfProcesses[i - 1].Outcome);
                        }

                        conformanceOfProcessesTable.AutoFit = AutoFit.Window;
                        document.InsertTable(conformanceOfProcessesTable);

                        var qualityOfDeliverables = document.InsertParagraph("\nQuality of Deliverables")
                             .Bold()
                             .FontSize(12d)
                             .Color(Color.Black)
                             .Bold(true)
                             .Font("Arial");

                        qualityOfDeliverables.StyleId = "Heading2";

                        var qualityOfDeliverablesTable = document.AddTable(currentQualityRegisterModel.QualityOfDeliverables.Count + 1, 11);
                        qualityOfDeliverablesTable.Rows[0].Cells[0].Paragraphs[0].Append("ID")
                            .Bold(true)
                            .Color(Color.White);
                        qualityOfDeliverablesTable.Rows[0].Cells[1].Paragraphs[0].Append("Requirement")
                            .Bold(true)
                            .Color(Color.White);
                        qualityOfDeliverablesTable.Rows[0].Cells[2].Paragraphs[0].Append("Deliverable")
                            .Bold(true)
                            .Color(Color.White);
                        qualityOfDeliverablesTable.Rows[0].Cells[3].Paragraphs[0].Append("Criteria")
                            .Bold(true)
                            .Color(Color.White);
                        qualityOfDeliverablesTable.Rows[0].Cells[4].Paragraphs[0].Append("Standards")
                            .Bold(true)
                            .Color(Color.White);
                        qualityOfDeliverablesTable.Rows[0].Cells[5].Paragraphs[0].Append("Meet Standards?")
                            .Bold(true)
                            .Color(Color.White);
                        qualityOfDeliverablesTable.Rows[0].Cells[6].Paragraphs[0].Append("Deviation")
                            .Bold(true)
                            .Color(Color.White);
                        qualityOfDeliverablesTable.Rows[0].Cells[7].Paragraphs[0].Append("Corrective Actions")
                            .Bold(true)
                            .Color(Color.White);
                        qualityOfDeliverablesTable.Rows[0].Cells[8].Paragraphs[0].Append("Methods")
                            .Bold(true)
                            .Color(Color.White);
                        qualityOfDeliverablesTable.Rows[0].Cells[9].Paragraphs[0].Append("Date")
                            .Bold(true)
                            .Color(Color.White);
                        qualityOfDeliverablesTable.Rows[0].Cells[10].Paragraphs[0].Append("Outcome")
                            .Bold(true)
                            .Color(Color.White);
                        qualityOfDeliverablesTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        qualityOfDeliverablesTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        qualityOfDeliverablesTable.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;
                        qualityOfDeliverablesTable.Rows[0].Cells[3].FillColor = TABLE_HEADER_COLOR;
                        qualityOfDeliverablesTable.Rows[0].Cells[4].FillColor = TABLE_HEADER_COLOR;
                        qualityOfDeliverablesTable.Rows[0].Cells[5].FillColor = TABLE_HEADER_COLOR;
                        qualityOfDeliverablesTable.Rows[0].Cells[6].FillColor = TABLE_HEADER_COLOR;
                        qualityOfDeliverablesTable.Rows[0].Cells[7].FillColor = TABLE_HEADER_COLOR;
                        qualityOfDeliverablesTable.Rows[0].Cells[8].FillColor = TABLE_HEADER_COLOR;
                        qualityOfDeliverablesTable.Rows[0].Cells[9].FillColor = TABLE_HEADER_COLOR;
                        qualityOfDeliverablesTable.Rows[0].Cells[10].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < currentQualityRegisterModel.QualityOfDeliverables.Count + 1; i++)
                        {
                            qualityOfDeliverablesTable.Rows[i].Cells[0].Paragraphs[0].Append(currentQualityRegisterModel.QualityOfDeliverables[i - 1].ID);
                            qualityOfDeliverablesTable.Rows[i].Cells[1].Paragraphs[0].Append(currentQualityRegisterModel.QualityOfDeliverables[i - 1].Requirement);
                            qualityOfDeliverablesTable.Rows[i].Cells[2].Paragraphs[0].Append(currentQualityRegisterModel.QualityOfDeliverables[i - 1].Deliverable);
                            qualityOfDeliverablesTable.Rows[i].Cells[3].Paragraphs[0].Append(currentQualityRegisterModel.QualityOfDeliverables[i - 1].Criteria);
                            qualityOfDeliverablesTable.Rows[i].Cells[4].Paragraphs[0].Append(currentQualityRegisterModel.QualityOfDeliverables[i - 1].Standards);
                            qualityOfDeliverablesTable.Rows[i].Cells[5].Paragraphs[0].Append(currentQualityRegisterModel.QualityOfDeliverables[i - 1].MeetStandards);
                            qualityOfDeliverablesTable.Rows[i].Cells[6].Paragraphs[0].Append(currentQualityRegisterModel.QualityOfDeliverables[i - 1].Deviation);
                            qualityOfDeliverablesTable.Rows[i].Cells[7].Paragraphs[0].Append(currentQualityRegisterModel.QualityOfDeliverables[i - 1].CorrectiveAction);
                            qualityOfDeliverablesTable.Rows[i].Cells[8].Paragraphs[0].Append(currentQualityRegisterModel.QualityOfDeliverables[i - 1].Methods);
                            qualityOfDeliverablesTable.Rows[i].Cells[9].Paragraphs[0].Append(currentQualityRegisterModel.QualityOfDeliverables[i - 1].Date);
                            qualityOfDeliverablesTable.Rows[i].Cells[10].Paragraphs[0].Append(currentQualityRegisterModel.QualityOfDeliverables[i - 1].Outcome);
                        }
                        qualityOfDeliverablesTable.AutoFit = AutoFit.Window;
                        document.InsertTable(qualityOfDeliverablesTable);

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

        private void txtProjectName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
