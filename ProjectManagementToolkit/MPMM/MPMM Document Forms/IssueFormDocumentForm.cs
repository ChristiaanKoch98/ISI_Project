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
    public partial class IssueFormDocumentForm : Form
    {
        VersionControl<IssueFormModel> versionControl;
        IssueFormModel newIssueFormModel;
        IssueFormModel currentIssueFormModel;
        Color TABLE_HEADER_COLOR = Color.FromArgb(73, 173, 252);
        ProjectModel projectModel = new ProjectModel();
        public IssueFormDocumentForm()
        {
            InitializeComponent();
        }

        private void IssueFormDocumentForm_Load(object sender, EventArgs e)
        {
            loadDocument();
            string json = JsonHelper.loadProjectInfo(Settings.Default.Username);
            List<ProjectModel> projectListModel = JsonConvert.DeserializeObject<List<ProjectModel>>(json);
            projectModel = projectModel.getProjectModel(Settings.Default.ProjectID, projectListModel);
            txtIssueFormProjectName.Text = projectModel.ProjectName;
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
            newIssueFormModel.ProjectName = projectModel.ProjectName;
            newIssueFormModel.ProjectManagerName = txtProjectManagerName.Text;
            newIssueFormModel.IssueID = txtIssueID.Text;
            newIssueFormModel.RaisedBy = txtRaisedBy.Text;
            newIssueFormModel.DateRaised = txtDateRaised.Text;
            newIssueFormModel.IssueDescription = txtIssueDescription.Text;
            newIssueFormModel.IssueImpact = txtIssueImpact.Text;
            newIssueFormModel.IssueResolution = txtIssueResolution.Text;
            newIssueFormModel.SupportingDocumentation = txtSupportingDocumentation.Text;


            List<VersionControl<IssueFormModel>.DocumentModel> documentModels = versionControl.DocumentModels;
            if (!versionControl.isEqual(currentIssueFormModel, newIssueFormModel))
            {
                VersionControl<IssueFormModel>.DocumentModel documentModel = new VersionControl<IssueFormModel>
                    .DocumentModel(newIssueFormModel, DateTime.Now, VersionControl<IssueFormModel>
                    .generateID());

                documentModels.Add(documentModel);
                versionControl.DocumentModels = documentModels;
                string json = JsonConvert.SerializeObject(versionControl);
                currentIssueFormModel = JsonConvert
                    .DeserializeObject<IssueFormModel>(JsonConvert.SerializeObject(newIssueFormModel));
                JsonHelper.saveDocument(json, Settings.Default.ProjectID, "IssueForm");
                MessageBox.Show("Issue Form saved successfully", "save", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("No changes was made!", "save", MessageBoxButtons.OK);
            }

        }

        public void loadDocument()
        {
            string json = JsonHelper.loadDocument(Settings.Default.ProjectID, "IssueForm");
            newIssueFormModel = new IssueFormModel();
            currentIssueFormModel = new IssueFormModel();

            if (json != "")
            {
                versionControl = JsonConvert.DeserializeObject<VersionControl<IssueFormModel>>(json);
                newIssueFormModel = JsonConvert.DeserializeObject<IssueFormModel>(versionControl.getLatest(versionControl.DocumentModels));
                currentIssueFormModel = JsonConvert.DeserializeObject<IssueFormModel>(versionControl.getLatest(versionControl.DocumentModels));

                txtProjectManagerName.Text = newIssueFormModel.ProjectManagerName;
                txtIssueID.Text = newIssueFormModel.IssueID;
                txtRaisedBy.Text = newIssueFormModel.RaisedBy;
                txtDateRaised.Text = newIssueFormModel.DateRaised;
                txtIssueDescription.Text = newIssueFormModel.IssueDescription;
                txtIssueImpact.Text = newIssueFormModel.IssueImpact;
                txtIssueResolution.Text = newIssueFormModel.IssueResolution;
                txtSupportingDocumentation.Text = newIssueFormModel.SupportingDocumentation;

            }
            else
            {
                versionControl = new VersionControl<IssueFormModel>();
                versionControl.DocumentModels = new List<VersionControl<IssueFormModel>.DocumentModel>();
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
                        document.InsertParagraph("Issue Form \nFor " + projectModel.ProjectName)
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(22d).Alignment = Alignment.left;
                        document.InsertSectionPageBreak();
                        document.InsertParagraph("Issue Form\n")
                           .Font("Arial")
                           .Bold(true)
                           .FontSize(14d).Alignment = Alignment.left;

                        var IssueFormTable = document.AddTable(11, 1);
                        IssueFormTable.Rows[0].Cells[0].Paragraphs[0]
                            .Append("Project Details")
                            .Bold(true)
                            .Font("Arial")
                            .FontSize(11d)
                            .Color(Color.White)
                            .SpacingBefore(6d)
                            .SpacingAfter(6d);
                        IssueFormTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;

                        IssueFormTable.Rows[1].Cells[0].Paragraphs[0]
                          .Append("Project Name: " + projectModel.ProjectName + "\nProject Manager: " + currentIssueFormModel.ProjectManagerName)
                          .Font("Arial")
                          .FontSize(11d)
                          .SpacingBefore(12d)
                          .SpacingAfter(12d);

                        IssueFormTable.Rows[2].Cells[0].Paragraphs[0]
                            .Append("Issue Details")
                            .Bold(true)
                            .Font("Arial")
                            .FontSize(11d)
                            .Color(Color.White)
                            .SpacingBefore(6d)
                            .SpacingAfter(6d);
                        IssueFormTable.Rows[2].Cells[0].FillColor = TABLE_HEADER_COLOR;

                        IssueFormTable.Rows[3].Cells[0].Paragraphs[0]
                         .Append("Issue ID:\t " + currentIssueFormModel.IssueID
                          + "\nRaised By:\t " + currentIssueFormModel.RaisedBy
                          + "\nDate Raised:\t " + currentIssueFormModel.DateRaised)
                         .Font("Arial")
                         .FontSize(11d)
                         .SpacingBefore(12d)
                         .SpacingAfter(12d);

                        IssueFormTable.Rows[4].Cells[0].Paragraphs[0]
                           .Append("Issue Description: " + currentIssueFormModel.IssueDescription)
                           .Font("Arial")
                           .FontSize(11d)
                           .SpacingBefore(12d)
                           .SpacingAfter(12d);

                        IssueFormTable.Rows[5].Cells[0].Paragraphs[0]
                          .Append("Issue Impact: " + currentIssueFormModel.IssueImpact)
                          .Font("Arial")
                          .FontSize(11d)
                          .SpacingBefore(12d)
                          .SpacingAfter(12d);

                        IssueFormTable.Rows[6].Cells[0].Paragraphs[0]
                            .Append("Issue Resolution")
                            .Bold(true)
                            .Font("Arial")
                            .FontSize(11d)
                            .Color(Color.White)
                            .SpacingBefore(6d)
                            .SpacingAfter(6d);
                        IssueFormTable.Rows[6].Cells[0].FillColor = TABLE_HEADER_COLOR;

                        IssueFormTable.Rows[7].Cells[0].Paragraphs[0]
                          .Append("Recommended Actions: " + currentIssueFormModel.IssueResolution)
                          .Font("Arial")
                          .FontSize(11d)
                          .SpacingBefore(12d)
                          .SpacingAfter(12d);

                        IssueFormTable.Rows[8].Cells[0].Paragraphs[0]
                            .Append("Approval  Details")
                            .Bold(true)
                            .Font("Arial")
                            .FontSize(11d)
                            .Color(Color.White)
                            .SpacingBefore(6d)
                            .SpacingAfter(6d);
                        IssueFormTable.Rows[8].Cells[0].FillColor = TABLE_HEADER_COLOR;

                        IssueFormTable.Rows[9].Cells[0].Paragraphs[0]
                           .Append("Supporting Documentation:\n" + currentIssueFormModel.SupportingDocumentation)
                           .Font("Arial")
                           .FontSize(11d)
                           .SpacingBefore(12d)
                           .SpacingAfter(12d);

                        IssueFormTable.Rows[10].Cells[0]
                           .InsertParagraph("Signature:                                                                          Date:")
                           .Font("Arial")
                           .FontSize(11d)
                           .SpacingBefore(12d)
                           .SpacingAfter(12d);

                        IssueFormTable.Rows[10].Cells[0]
                           .InsertParagraph("_______________________                                            ___/___/____ " )
                           .Font("Arial")
                           .FontSize(11d)
                           .SpacingBefore(12d)
                           .SpacingAfter(12d);

                        IssueFormTable.Rows[10].Cells[0]
                           .InsertParagraph("PLEASE FORWARD THIS FORM TO THE PROJECT MANAGER FOR ACTION")
                           .Font("Arial")
                           .FontSize(11d)
                           .SpacingBefore(12d)
                           .SpacingAfter(12d);

                        IssueFormTable.SetWidths(new float[] { 1620 });
                        document.InsertTable(IssueFormTable);

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
