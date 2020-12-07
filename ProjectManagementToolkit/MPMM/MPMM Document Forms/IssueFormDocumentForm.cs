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
        VersionControl<List<IssueFormModel>> versionControl;
        List<IssueFormModel> newIssueFormModel;
        List<IssueFormModel> currentIssueFormModel;

        VersionControl<IssueRegisterModel> versionControlRegister;
        IssueRegisterModel newRegisterModel;
        Color TABLE_HEADER_COLOR = Color.FromArgb(73, 173, 252);
        ProjectModel projectModel = new ProjectModel();
        public IssueFormDocumentForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveCurrentDocument();
        }

        private void IssueFormDocumentForm_Load(object sender, EventArgs e)
        {
            if (cmbIssueForms.SelectedIndex == -1)
            {
                tbcQualityReviewForm.Hide();
            }
            loadDocuments();

            for (int i = 0; i < currentIssueFormModel.Count; i++)
            {
                cmbIssueForms.Items.Add("Issue Request: " + (i + 1));
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            exportToWord();
        }

        public void loadDocuments()
        {
            string json = JsonHelper.loadDocument(Settings.Default.ProjectID, "IssueForm");
            string jsonRegister = JsonHelper.loadDocument(Settings.Default.ProjectID, "IssueRegister");
            newIssueFormModel = new List<IssueFormModel>();
            currentIssueFormModel = new List<IssueFormModel>();
            newRegisterModel = new IssueRegisterModel(); 
            if (json != "")
            {
                versionControl = JsonConvert.DeserializeObject<VersionControl<List<IssueFormModel>>>(json);
                versionControlRegister = JsonConvert.DeserializeObject<VersionControl<IssueRegisterModel>>(jsonRegister);
                newIssueFormModel = JsonConvert.DeserializeObject<List<IssueFormModel>>(versionControl.getLatest(versionControl.DocumentModels));
                currentIssueFormModel = JsonConvert.DeserializeObject<List<IssueFormModel>>(versionControl.getLatest(versionControl.DocumentModels));
                newRegisterModel = JsonConvert.DeserializeObject<IssueRegisterModel>(versionControlRegister.getLatest(versionControlRegister.DocumentModels));
            }
            else
            {
                versionControl = new VersionControl<List<IssueFormModel>>();
                versionControl.DocumentModels = new List<VersionControl<List<IssueFormModel>>.DocumentModel>();

                versionControlRegister = new VersionControl<IssueRegisterModel>();
                versionControlRegister.DocumentModels = new List<VersionControl<IssueRegisterModel>.DocumentModel>();
                newRegisterModel.IssueEntries = new List<IssueRegisterModel.IssueEntry>();
            }
        }

        public void saveCurrentDocument()
        {
            IssueFormModel tempIssueFormModel = new IssueFormModel();
            tempIssueFormModel.ProjectName = projectModel.ProjectName;
            tempIssueFormModel.ProjectManagerName = txtProjectManagerName.Text;
            tempIssueFormModel.IssueID = txtIssueID.Text;
            tempIssueFormModel.RaisedBy = txtRaisedBy.Text;
            tempIssueFormModel.DateRaised = dateTimePicker1.Value.ToString();
            tempIssueFormModel.IssueDescription = txtIssueDescription.Text;
            tempIssueFormModel.IssueImpact = txtIssueImpact.Text;
            tempIssueFormModel.IssueResolution = txtIssueResolution.Text;
            tempIssueFormModel.SupportingDocumentation = txtSupportingDocumentation.Text;

            IssueRegisterModel.IssueEntry issueEntry = new IssueRegisterModel.IssueEntry();
            issueEntry.ID = (cmbIssueForms.SelectedIndex+1).ToString();
            issueEntry.DateRaised = dateTimePicker1.Value.ToString();
            issueEntry.RaisedBy = txtRaisedBy.Text;
            issueEntry.ReceivedBy = txtProjectManagerName.Text;
            issueEntry.Description = txtIssueDescription.Text;
            issueEntry.Impact = txtIssueImpact.Text;
            issueEntry.Action = txtIssueResolution.Text;


            newIssueFormModel[cmbIssueForms.SelectedIndex] = tempIssueFormModel;
            newRegisterModel.IssueEntries[cmbIssueForms.SelectedIndex] = issueEntry;

            List<VersionControl<List<IssueFormModel>>.DocumentModel> documentModels = versionControl.DocumentModels;
            List<VersionControl<IssueRegisterModel>.DocumentModel> documentModelsReg = versionControlRegister.DocumentModels;
            if (!versionControl.isEqual(currentIssueFormModel, newIssueFormModel))
            {
                VersionControl<List<IssueFormModel>>.DocumentModel documentModel = new VersionControl<List<IssueFormModel>>
                    .DocumentModel(newIssueFormModel, DateTime.Now, VersionControl<List<IssueFormModel>>
                    .generateID());

                VersionControl<IssueRegisterModel>.DocumentModel documentModelReg = new VersionControl<IssueRegisterModel>
                    .DocumentModel(newRegisterModel, DateTime.Now, VersionControl<IssueRegisterModel>
                    .generateID());


                documentModels.Add(documentModel);
                versionControl.DocumentModels = documentModels;
                string jsonIssueForm = JsonConvert.SerializeObject(versionControl);
                currentIssueFormModel = JsonConvert
                    .DeserializeObject<List<IssueFormModel>>(JsonConvert.SerializeObject(newIssueFormModel));
                JsonHelper.saveDocument(jsonIssueForm, Settings.Default.ProjectID, "IssueForm");

                documentModelsReg.Add(documentModelReg);
                versionControlRegister.DocumentModels = documentModelsReg;
                string jsonIssueRegister = JsonConvert.SerializeObject(versionControlRegister);
                JsonHelper.saveDocument(jsonIssueRegister, Settings.Default.ProjectID, "IssueRegister");
                currentIssueFormModel = JsonConvert
                    .DeserializeObject<List<IssueFormModel>>(JsonConvert.SerializeObject(newIssueFormModel));
                MessageBox.Show("Issue Form saved successfully", "save", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("No changes was made!", "save", MessageBoxButtons.OK);
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
                          .Append("Project Name: " + projectModel.ProjectName + "\nProject Manager: " + currentIssueFormModel[cmbIssueForms.SelectedIndex].ProjectManagerName)
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
                         .Append("Issue ID:\t " + currentIssueFormModel[cmbIssueForms.SelectedIndex].IssueID
                          + "\nRaised By:\t " + currentIssueFormModel[cmbIssueForms.SelectedIndex].RaisedBy
                          + "\nDate Raised:\t " + currentIssueFormModel[cmbIssueForms.SelectedIndex].DateRaised)
                         .Font("Arial")
                         .FontSize(11d)
                         .SpacingBefore(12d)
                         .SpacingAfter(12d);

                        IssueFormTable.Rows[4].Cells[0].Paragraphs[0]
                           .Append("Issue Description: " + currentIssueFormModel[cmbIssueForms.SelectedIndex].IssueDescription)
                           .Font("Arial")
                           .FontSize(11d)
                           .SpacingBefore(12d)
                           .SpacingAfter(12d);

                        IssueFormTable.Rows[5].Cells[0].Paragraphs[0]
                          .Append("Issue Impact: " + currentIssueFormModel[cmbIssueForms.SelectedIndex].IssueImpact)
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
                          .Append("Recommended Actions: " + currentIssueFormModel[cmbIssueForms.SelectedIndex].IssueResolution)
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
                           .Append("Supporting Documentation:\n" + currentIssueFormModel[cmbIssueForms.SelectedIndex].SupportingDocumentation)
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

        private void btnNewForm_Click(object sender, EventArgs e)
        {
            int index = cmbIssueForms.Items.Count + 1;
            cmbIssueForms.Items.Add("Issue Request: " + index);
            newIssueFormModel.Add(new IssueFormModel());
            currentIssueFormModel.Add(new IssueFormModel());
            cmbIssueForms.SelectedIndex = cmbIssueForms.Items.Count - 1;
            newRegisterModel.IssueEntries.Add(new IssueRegisterModel.IssueEntry());


            versionControl.DocumentModels.Add(
                new VersionControl<List<IssueFormModel>>
                .DocumentModel(currentIssueFormModel, DateTime.Now, VersionControl<List<IssueFormModel>>.generateID()));

            versionControlRegister.DocumentModels.Add(
               new VersionControl<IssueRegisterModel>
               .DocumentModel(newRegisterModel, DateTime.Now, VersionControl<List<IssueRegisterModel>>.generateID()));

            string json = JsonConvert.SerializeObject(versionControl);
            JsonHelper.saveDocument(json, Settings.Default.ProjectID, "IssueForm");

            string jsonIssueRegister = JsonConvert.SerializeObject(versionControlRegister);
            JsonHelper.saveDocument(jsonIssueRegister, Settings.Default.ProjectID, "IssueRegister");
        }

        private void cmbIssueForms_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbIssueForms.SelectedIndex != -1)
            {
                tbcQualityReviewForm.Show();

                txtProjectManagerName.Text = currentIssueFormModel[cmbIssueForms.SelectedIndex].ProjectManagerName;
                txtIssueID.Text = currentIssueFormModel[cmbIssueForms.SelectedIndex].IssueID;
                txtRaisedBy.Text = currentIssueFormModel[cmbIssueForms.SelectedIndex].RaisedBy;
                dateTimePicker1.Value = Convert.ToDateTime(currentIssueFormModel[cmbIssueForms.SelectedIndex].DateRaised);
                txtIssueDescription.Text = currentIssueFormModel[cmbIssueForms.SelectedIndex].IssueDescription;
                txtIssueImpact.Text = currentIssueFormModel[cmbIssueForms.SelectedIndex].IssueImpact;
                txtIssueResolution.Text = currentIssueFormModel[cmbIssueForms.SelectedIndex].IssueResolution;
                txtSupportingDocumentation.Text = currentIssueFormModel[cmbIssueForms.SelectedIndex].SupportingDocumentation;
            }
            else
            {
                tbcQualityReviewForm.Hide();
            }
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (cmbIssueForms.SelectedIndex != -1)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete the current form?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                
                    currentIssueFormModel.RemoveAt(cmbIssueForms.SelectedIndex);
                    newRegisterModel.IssueEntries.RemoveAt(cmbIssueForms.SelectedIndex);
                    cmbIssueForms.Items.RemoveAt(cmbIssueForms.SelectedIndex);
                    cmbIssueForms_SelectedIndexChanged(this, EventArgs.Empty);

                    versionControl.DocumentModels.Add(
                       new VersionControl<List<IssueFormModel>>
                       .DocumentModel(currentIssueFormModel, DateTime.Now, VersionControl<List<IssueFormModel>>.generateID()));

                    string json = JsonConvert.SerializeObject(versionControl);
                    JsonHelper.saveDocument(json, Settings.Default.ProjectID, "IssueForm");

                    versionControlRegister.DocumentModels.Add(new VersionControl<IssueRegisterModel>
                      .DocumentModel(newRegisterModel, DateTime.Now, VersionControl<IssueRegisterModel>
                      .generateID()));

                    string jsonIssueRegister = JsonConvert.SerializeObject(versionControlRegister);

                    JsonHelper.saveDocument(jsonIssueRegister, Settings.Default.ProjectID, "IssueRegister");
                }
            }
        }
    }
}
