using ProjectManagementToolkit.MPMM.MPMM_Document_Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Runtime.InteropServices;
using ProjectManagementToolkit.Utility;
using ProjectManagementToolkit.Properties;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Forms
{
    public partial class ChangeRequestFormDocumentForm : Form
    {
        VersionControl<ChangeRequestModel> versionControl;
        ChangeRequestModel newChangeRequestModel;
        ChangeRequestModel currentChangeRequestModel;
        Color TABLE_HEADER_COLOR = Color.FromArgb(73, 173, 252);
        ProjectModel projectModel = new ProjectModel();

        public ChangeRequestFormDocumentForm()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnChangeSave_Click(object sender, EventArgs e)
        {
            
        }

        private void ChangeRequestFormDocumentForm_Load(object sender, EventArgs e)
        {
            loadDocument();
            string json = JsonHelper.loadProjectInfo(Settings.Default.Username);
            List<ProjectModel> projectListModel = JsonConvert.DeserializeObject<List<ProjectModel>>(json);
            projectModel = projectModel.getProjectModel(Settings.Default.ProjectID, projectListModel);
        }

        public void saveDocument()
        {
            newChangeRequestModel.ProjectName = txtProjectName.Text;
            newChangeRequestModel.ProjectManager = txtProjectManager.Text;
            newChangeRequestModel.ChangeNumber = txtChangeDetails.Text;
            newChangeRequestModel.ChangeRequester = txtChangeRequester.Text;
            newChangeRequestModel.ChangeRequestDate = txtChangeRequestDate.Text;
            newChangeRequestModel.ChangeUrgancy = txtChangeUrgency.Text;
            newChangeRequestModel.ChangeDescription = txtChangeDescription.Text;
            newChangeRequestModel.ChangeDrivers = txtChangeDrivers.Text;
            newChangeRequestModel.ChangeBenefits = txtChangeBenefits.Text;
            newChangeRequestModel.ChangeCost = txtChangeCosts.Text;
            newChangeRequestModel.ProjectImpact = textBox1.Text;

            //newChangeRequestModel.SupportingDocumentation = approvalDetailsTextBox.Text;

            newChangeRequestModel.SubmittedName = txtName.Text;
            newChangeRequestModel.SubmittedRole = txtProjectRole.Text;
            newChangeRequestModel.SubmittedSignature = txtSignature.Text;
            newChangeRequestModel.SubmittedDate = dateTimePickerSubmittedBy.Text;

            newChangeRequestModel.ApprovedName = txtApprovedByName.Text;
            newChangeRequestModel.ApprovedRole = txtApprovedByProjectRole.Text;
            newChangeRequestModel.ApprovedSignature = txtApprovedBySignature.Text;
            newChangeRequestModel.ApprovedDate = dateTimePickerApprovedBy.Text;

            List<ChangeRequestModel.SupportingDocument> supportingDocuments = new List<ChangeRequestModel.SupportingDocument>();

            int versionRowsCount = dataGridViewSupportingDocuments.Rows.Count;

            for (int i = 0; i < versionRowsCount - 1; i++)
            {
                ChangeRequestModel.SupportingDocument supportDocumentModel = new ChangeRequestModel.SupportingDocument();
                var documentName = dataGridViewSupportingDocuments.Rows[i].Cells[0].Value?.ToString() ?? "";
                var documentDescription = dataGridViewSupportingDocuments.Rows[i].Cells[1].Value?.ToString() ?? "";

                supportDocumentModel.DocumentName = documentName;
                supportDocumentModel.DocumentDescription = documentDescription;

                supportingDocuments.Add(supportDocumentModel);
            }
            newChangeRequestModel.SupportingDocuments = supportingDocuments;


            List<VersionControl<ChangeRequestModel>.DocumentModel> documentModels = versionControl.DocumentModels; //Error here


            if (!versionControl.isEqual(currentChangeRequestModel, newChangeRequestModel))
            {
                VersionControl<ChangeRequestModel>.DocumentModel documentModel = new VersionControl<ChangeRequestModel>.DocumentModel(newChangeRequestModel, DateTime.Now, VersionControl<ProjectModel>.generateID());

                documentModels.Add(documentModel);

                versionControl.DocumentModels = documentModels;

                string json = JsonConvert.SerializeObject(versionControl);
                JsonHelper.saveDocument(json, Settings.Default.ProjectID, "ChangeRequestForm");
                MessageBox.Show("Change Request saved successfully", "save", MessageBoxButtons.OK);
            }
        }

        public void loadDocument()
        {
            string json = JsonHelper.loadDocument(Settings.Default.ProjectID, "ChangeRequestForm");
            List<string[]> documentInfo = new List<string[]>();
            newChangeRequestModel = new ChangeRequestModel();
            currentChangeRequestModel = new ChangeRequestModel();
            if (json != "")
            {
                versionControl = JsonConvert.DeserializeObject<VersionControl<ChangeRequestModel>>(json);
                newChangeRequestModel = JsonConvert.DeserializeObject<ChangeRequestModel>(versionControl.getLatest(versionControl.DocumentModels));
                currentChangeRequestModel = JsonConvert.DeserializeObject<ChangeRequestModel>(versionControl.getLatest(versionControl.DocumentModels));




                txtProjectName.Text = currentChangeRequestModel.ProjectName;
                txtProjectManager.Text = currentChangeRequestModel.ProjectManager;
                txtChangeDetails.Text = currentChangeRequestModel.ChangeNumber;
                txtChangeRequester.Text = currentChangeRequestModel.ChangeRequester;
                txtChangeRequestDate.Text = currentChangeRequestModel.ChangeRequestDate;
                txtChangeUrgency.Text = currentChangeRequestModel.ChangeUrgancy;
                txtChangeDescription.Text = currentChangeRequestModel.ChangeDescription;
                txtChangeDrivers.Text = currentChangeRequestModel.ChangeDrivers;
                txtChangeBenefits.Text = currentChangeRequestModel.ChangeBenefits;
                txtChangeCosts.Text = currentChangeRequestModel.ChangeCost;
                textBox1.Text = currentChangeRequestModel.ProjectImpact;

                foreach (var row in currentChangeRequestModel.SupportingDocuments)
                {
                    dataGridViewSupportingDocuments.Rows.Add(new string[] { row.DocumentName, row.DocumentDescription});
                }

                txtName.Text = currentChangeRequestModel.SubmittedName;
                txtProjectRole.Text = currentChangeRequestModel.SubmittedRole;
                txtSignature.Text = currentChangeRequestModel.SubmittedSignature;
                dateTimePickerSubmittedBy.Text = currentChangeRequestModel.SubmittedDate;

                txtApprovedByName.Text = currentChangeRequestModel.ApprovedName;
                txtApprovedByProjectRole.Text = currentChangeRequestModel.ApprovedRole;
                txtApprovedBySignature.Text = currentChangeRequestModel.ApprovedSignature;
                dateTimePickerApprovedBy.Text = currentChangeRequestModel.ApprovedDate;

            }
            else 
            {
                versionControl = new VersionControl<ChangeRequestModel>();
                versionControl.DocumentModels = new List<VersionControl<ChangeRequestModel>.DocumentModel>();
                newChangeRequestModel = new ChangeRequestModel();

            }
        }

        private void signatureTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnExportChanges_Click(object sender, EventArgs e)
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
                        document.InsertParagraph("Change Request Form \nFor " + projectModel.ProjectName)
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(22d).Alignment = Alignment.left;
                        document.InsertSectionPageBreak();

                        //Change details

                        var documentInfoTable = document.AddTable(13, 1);
                        documentInfoTable.Rows[0].Cells[0].Paragraphs[0].Append("Project Details").Bold(true).Color(Color.White).FontSize(14d);
               
                        documentInfoTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        documentInfoTable.Rows[2].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        documentInfoTable.Rows[8].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        documentInfoTable.Rows[10].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        documentInfoTable.Rows[1].Cells[0].Paragraphs[0].Append("Project Name: \t\t"+ currentChangeRequestModel.ProjectName+"\nProject Manager: \t"+ currentChangeRequestModel.ProjectManager);
                        documentInfoTable.Rows[2].Cells[0].Paragraphs[0].Append("Change Details").Bold(true).Color(Color.White).FontSize(14d);
                        documentInfoTable.Rows[3].Cells[0].Paragraphs[0].Append("Change Number: \t" + currentChangeRequestModel.ChangeNumber + "\nRequester: \t\t" + currentChangeRequestModel.ChangeRequester + " \nDate: \t\t\t" + currentChangeRequestModel.ChangeRequestDate + " \nUrgency: \t\t" + currentChangeRequestModel.ChangeUrgancy);
                        documentInfoTable.Rows[4].Cells[0].Paragraphs[0].Append("Change Description: \t" + currentChangeRequestModel.ChangeDescription);
                        documentInfoTable.Rows[5].Cells[0].Paragraphs[0].Append("Change Drivers: \t" + currentChangeRequestModel.ChangeDrivers);
                        documentInfoTable.Rows[6].Cells[0].Paragraphs[0].Append("Change Benefits: \t" + currentChangeRequestModel.ChangeBenefits);
                        documentInfoTable.Rows[7].Cells[0].Paragraphs[0].Append("Change Costs: \t\t" + currentChangeRequestModel.ChangeCost);
                        documentInfoTable.Rows[8].Cells[0].Paragraphs[0].Append("Impact Details").Bold(true).Color(Color.White).FontSize(14d);
                        documentInfoTable.Rows[9].Cells[0].Paragraphs[0].Append(currentChangeRequestModel.ProjectImpact);
                        documentInfoTable.Rows[10].Cells[0].Paragraphs[0].Append("Approval Details").Bold(true).Color(Color.White).FontSize(14d);
                        documentInfoTable.Rows[11].Cells[0].Paragraphs[0].Append("See below for supporting documentation");
                        documentInfoTable.Rows[12].Cells[0].Paragraphs[0].Append("Submitted by: \t\t\t\t\tApproved by: \nName: " + currentChangeRequestModel.SubmittedName+"\t\t\t\t\tName: " + currentChangeRequestModel.ApprovedName 
                            +"\nSignitaure: " + currentChangeRequestModel.SubmittedSignature + "\t\t\t\tSignature: "+ currentChangeRequestModel.ApprovedSignature
                            +"\nDate :" + currentChangeRequestModel.SubmittedDate + "\t\t\t\t\t\tDate: " + currentChangeRequestModel.ApprovedDate);

                        documentInfoTable.SetWidths(new float[] { 1000});
                        document.InsertTable(documentInfoTable);

                        //Supporting documents table
                        document.InsertParagraph("\nSupporting documents\n")
                           .Font("Arial")
                           .Bold(true)
                           .FontSize(14d).Alignment = Alignment.left;

                        var supportDocumentTable = document.AddTable(currentChangeRequestModel.SupportingDocuments.Count + 1, 2);
                        supportDocumentTable.Rows[0].Cells[0].Paragraphs[0].Append("Document Name")
                            .Bold(true)
                            .Color(Color.White);
                        supportDocumentTable.Rows[0].Cells[1].Paragraphs[0].Append("Document Description")
                            .Bold(true)
                            .Color(Color.White);
                        supportDocumentTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        supportDocumentTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        for (int i = 1; i < currentChangeRequestModel.SupportingDocuments.Count + 1; i++)
                        {
                            supportDocumentTable.Rows[i].Cells[0].Paragraphs[0].Append(currentChangeRequestModel.SupportingDocuments[i - 1].DocumentName);
                            supportDocumentTable.Rows[i].Cells[1].Paragraphs[0].Append(currentChangeRequestModel.SupportingDocuments[i - 1].DocumentDescription);

                        }

                        supportDocumentTable.SetWidths(new float[] { 500, 500});
                        document.InsertTable(supportDocumentTable);



                        //Save the document
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

        private void btnSaveProjectDetails_Click(object sender, EventArgs e)
        {
            saveDocument();
        }
    }
}
