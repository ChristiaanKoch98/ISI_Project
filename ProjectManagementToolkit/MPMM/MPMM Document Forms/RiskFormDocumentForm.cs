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
using ProjectManagementToolkit.MPMM.MPMM_Document_Models;
using Newtonsoft.Json;
using ProjectManagementToolkit.Properties;
using Xceed.Words.NET;
using Xceed.Document.NET;

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Forms
{
    public partial class RiskFormDocumentForm : Form
    {
        VersionControl<RiskFormModel> versionControl;
        RiskFormModel newRiskFormModel;
        RiskFormModel currentRiskFormModel;
        Color TABLE_HEADER_COLOR = Color.FromArgb(73, 173, 252);
        RiskFormModel RiskFormModel = new RiskFormModel();
        ProjectModel projectModel = new ProjectModel();
        public RiskFormDocumentForm()
        {
            InitializeComponent();
        }

        private void RiskFormDocumentForm_Load(object sender, EventArgs e)
        {
            loadDocument();
            string json = JsonHelper.loadProjectInfo(Settings.Default.Username);
            List<ProjectModel> projectListModel = JsonConvert.DeserializeObject<List<ProjectModel>>(json);
            projectModel = projectModel.getProjectModel(Settings.Default.ProjectID, projectListModel);
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
            newRiskFormModel.ProjectName = txtprojectName.Text;
            newRiskFormModel.ProjectManager = projectManager.Text;
            newRiskFormModel.RiskID = riskID.Text;
            newRiskFormModel.DateRaised = dateRaised.Text;
            newRiskFormModel.RaisedBy = raisedBy.Text;
            newRiskFormModel.RiskDescription = riskDescription.Text;
            newRiskFormModel.RiskLikelihood = riskLikelihood.Text;
            newRiskFormModel.RiskImpact = riskImpact.Text;
            newRiskFormModel.RiskMitigationList = riskMigigationList.Text;
            newRiskFormModel.RiskRecommendedActions = riskRecommendedContingentActions.Text;
            newRiskFormModel.SupportingDocumentation = supportingDocumentation.Text;
            newRiskFormModel.SignatureDate = signatureDate.Value.ToString();

            List<VersionControl<RiskFormModel>.DocumentModel> documentModels = versionControl.DocumentModels;
            if (!versionControl.isEqual(currentRiskFormModel, newRiskFormModel))
            {
                VersionControl<RiskFormModel>.DocumentModel documentModel = new VersionControl<RiskFormModel>
                    .DocumentModel(newRiskFormModel, DateTime.Now, VersionControl<RiskFormModel>
                    .generateID());

                documentModels.Add(documentModel);
                versionControl.DocumentModels = documentModels;
                string json = JsonConvert.SerializeObject(versionControl);
                currentRiskFormModel = JsonConvert
                    .DeserializeObject<RiskFormModel>(JsonConvert.SerializeObject(newRiskFormModel));
                JsonHelper.saveDocument(json, Settings.Default.ProjectID, "RiskForm");
                MessageBox.Show("Project plan saved successfully", "save", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("No changes was made!", "save", MessageBoxButtons.OK);
            }
        }

        private void loadDocument()
        {
            string json = JsonHelper.loadDocument(Settings.Default.ProjectID, "RiskForm");
            newRiskFormModel = new RiskFormModel();
            currentRiskFormModel = new RiskFormModel();

            if (json != "")
            {
                versionControl = JsonConvert.DeserializeObject<VersionControl<RiskFormModel>>(json);
                newRiskFormModel = JsonConvert.DeserializeObject<RiskFormModel>(versionControl.getLatest(versionControl.DocumentModels));
                currentRiskFormModel = JsonConvert.DeserializeObject<RiskFormModel>(versionControl.getLatest(versionControl.DocumentModels));

                txtprojectName.Text = newRiskFormModel.ProjectName;
                projectManager.Text = newRiskFormModel.ProjectManager;
                riskID.Text = newRiskFormModel.RiskID;
                dateRaised.Text = newRiskFormModel.DateRaised;
                raisedBy.Text = newRiskFormModel.RaisedBy;
                riskDescription.Text = newRiskFormModel.RiskDescription;
                riskLikelihood.Text = newRiskFormModel.RiskLikelihood;
                riskImpact.Text = newRiskFormModel.RiskImpact;
                riskMigigationList.Text = newRiskFormModel.RiskMitigationList;
                riskRecommendedContingentActions.Text = newRiskFormModel.RiskRecommendedActions;
                supportingDocumentation.Text = newRiskFormModel.SupportingDocumentation;
                signatureDate.Value = Convert.ToDateTime(newRiskFormModel.SignatureDate);
            }
            else
            {
                versionControl = new VersionControl<RiskFormModel>();
                versionControl.DocumentModels = new List<VersionControl<RiskFormModel>.DocumentModel>();
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
                        document.InsertParagraph("Project Plan \nFor " + projectModel.ProjectName)
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(22d).Alignment = Alignment.left;
                        document.InsertSectionPageBreak();
                        document.InsertParagraph("Risk Form\n")
                           .Font("Arial")
                           .Bold(true)
                           .FontSize(14d).Alignment = Alignment.left;

                        var documentProjectDetailTable = document.AddTable(5, 1);
                        documentProjectDetailTable.Rows[0].Cells[0].Paragraphs[0]
                            .Append("Project Details")
                            .Bold(true)
                            .Font("Arial")
                            .FontSize(11d)
                            .Color(Color.White)
                            .SpacingBefore(6d)
                            .SpacingAfter(6d);
                        documentProjectDetailTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        documentProjectDetailTable.Rows[1].Cells[0].Paragraphs[0]
                           .Append("Project Name: " + projectModel.ProjectName + "\t Project Manager: " + currentRiskFormModel.ProjectManager)
                           .Font("Arial")
                           .FontSize(11d)
                           .SpacingBefore(12d)
                           .SpacingAfter(12d);
                        documentProjectDetailTable.Rows[2].Cells[0].Paragraphs[0]
                            .Append("Risk Details")
                            .Bold(true)
                            .Font("Arial")
                            .FontSize(11d)
                            .Color(Color.White)
                            .SpacingBefore(6d)
                            .SpacingAfter(6d);
                        documentProjectDetailTable.Rows[2].Cells[0].FillColor = TABLE_HEADER_COLOR;

                        documentProjectDetailTable.Rows[3].Cells[0].Paragraphs[0]
                           .Append("Risk ID:\t " + currentRiskFormModel.RiskID 
                            + "\nRaised By:\t " + currentRiskFormModel.RaisedBy
                            + "\nDate Raised:\t " + currentRiskFormModel.DateRaised)
                           .Font("Arial")
                           .FontSize(11d)
                           .SpacingBefore(12d)
                           .SpacingAfter(12d);

                        documentProjectDetailTable.Rows[4].Cells[0].Paragraphs[0]
                           .Append("Risk Description: "+currentRiskFormModel.RiskDescription)
                           .Font("Arial")
                           .FontSize(11d)
                           .SpacingBefore(12d)
                           .SpacingAfter(12d);


                        documentProjectDetailTable.SetWidths(new float[] { 1620 });
                        document.InsertTable(documentProjectDetailTable);

                        var documentRiskImLik = document.AddTable(1, 2);

                        documentRiskImLik.Rows[0].Cells[0].Paragraphs[0]
                           .Append("Risk Likelihood: " + currentRiskFormModel.RiskLikelihood)
                           .Font("Arial")
                           .FontSize(11d)
                           .SpacingBefore(12d)
                           .SpacingAfter(12d);

                        documentRiskImLik.Rows[0].Cells[1].Paragraphs[0]
                           .Append("Risk Impact: " + currentRiskFormModel.RiskImpact)
                           .Font("Arial")
                           .FontSize(11d)
                           .SpacingBefore(12d)
                           .SpacingAfter(12d);
                        documentRiskImLik.SetWidths(new float[] { 810,810 });

                        document.InsertTable(documentRiskImLik);

                        var documentRiskMiti = document.AddTable(5, 1);
                        documentRiskMiti.Rows[0].Cells[0].Paragraphs[0].Append("Risk Mitigation")
                            .Bold(true)
                            .Font("Arial")
                            .FontSize(11d)
                            .Color(Color.White)
                            .SpacingBefore(6d)
                            .SpacingAfter(6d);
                        documentRiskMiti.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;

                        documentRiskMiti.Rows[1].Cells[0].Paragraphs[0]
                           .InsertParagraphAfterSelf(currentRiskFormModel.RiskMitigationList)
                           .Font("Arial")
                           .FontSize(11d)
                           .SpacingBefore(12d)
                           .SpacingAfter(12d);

                        documentRiskMiti.Rows[1].Cells[0].Paragraphs[0]
                           .InsertParagraphAfterSelf("Recommended Contingent Actions:\n" + currentRiskFormModel.RiskRecommendedActions)
                           .Font("Arial")
                           .FontSize(11d)
                           .SpacingBefore(12d)
                           .SpacingAfter(12d);

                        documentRiskMiti.Rows[2].Cells[0].Paragraphs[0].Append("Approval Details")
                            .Bold(true)
                            .Font("Arial")
                            .FontSize(11d)
                            .Color(Color.White)
                            .SpacingBefore(6d)
                            .SpacingAfter(6d);
                        documentRiskMiti.Rows[2].Cells[0].FillColor = TABLE_HEADER_COLOR;

                        documentRiskMiti.Rows[3].Cells[0].Paragraphs[0]
                           .Append("Supporting Documentation:\n" + currentRiskFormModel.SupportingDocumentation)
                           .Font("Arial")
                           .FontSize(11d)
                           .SpacingBefore(12d)
                           .SpacingAfter(12d);

             
                        documentRiskMiti.Rows[4].Cells[0]
                           .InsertParagraph("Signature:                                                                          Date:")
                           .Font("Arial")
                           .FontSize(11d)
                           .SpacingBefore(12d)
                           .SpacingAfter(12d);

                        documentRiskMiti.Rows[4].Cells[0]
                           .InsertParagraph("_______________________                                            "+Convert.ToDateTime(currentRiskFormModel.SignatureDate).ToShortDateString())
                           .Font("Arial")
                           .FontSize(11d)
                           .SpacingBefore(12d)
                           .SpacingAfter(12d);

                        documentRiskMiti.Rows[4].Cells[0]
                           .InsertParagraph("PLEASE FORWARD THIS FORM TO THE PROJECT MANAGER FOR ACTION")
                           .Font("Arial")
                           .FontSize(11d)
                           .SpacingBefore(12d)
                           .SpacingAfter(12d);

                        documentRiskMiti.SetWidths(new float[] { 1620 });
                        document.InsertTable(documentRiskMiti);

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
