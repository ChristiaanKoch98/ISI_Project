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

        public void saveDocument()
        {
            newChangeRequestModel.ProjectName = txtProjectName.Text;
            newChangeRequestModel.ProjectManager = txtProjectManager.Text;

            newChangeRequestModel.ChangeNumber = txtChangeNumber.Text;
            newChangeRequestModel.ChangeRequester = txtChangeRequester.Text;
            newChangeRequestModel.ChangeRequestDate = txtChangeRequestDate.Text;
            newChangeRequestModel.ChangeUrgancy = txtChangeUrgency.Text;
            
            newChangeRequestModel.ChangeDescription = txtChangeDescription.Text;
            newChangeRequestModel.ChangeDrivers = txtChangeDrivers.Text;
            newChangeRequestModel.ChangeBenefits = txtChangeBenefits.Text;
            newChangeRequestModel.ChangeCost = txtChangeCosts.Text;
            newChangeRequestModel.ProjectImpact = txtImpactDetails.Text;

            newChangeRequestModel.SupportingDocuments = txtSupportingDocumentation.Text;
            newChangeRequestModel.Signature = txtSignature.Text;

            List<VersionControl<ChangeRequestModel>.DocumentModel> documentModels = versionControl.DocumentModels; //Error here


            if (!versionControl.isEqual(currentChangeRequestModel, newChangeRequestModel))
            {
                VersionControl<ChangeRequestModel>.DocumentModel documentModel = new VersionControl<ChangeRequestModel>.DocumentModel(newChangeRequestModel, DateTime.Now, VersionControl<ProjectModel>.generateID());

                documentModels.Add(documentModel);

                versionControl.DocumentModels = documentModels;

                string json = JsonConvert.SerializeObject(versionControl);
                currentChangeRequestModel = JsonConvert.DeserializeObject<ChangeRequestModel>(JsonConvert.SerializeObject(newChangeRequestModel));
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
                txtChangeNumber.Text = currentChangeRequestModel.ChangeNumber;
                txtChangeRequester.Text = currentChangeRequestModel.ChangeRequester;
                txtChangeRequestDate.Text = currentChangeRequestModel.ChangeRequestDate;
                txtChangeUrgency.Text = currentChangeRequestModel.ChangeUrgancy;
                txtChangeDescription.Text = currentChangeRequestModel.ChangeDescription;
                txtChangeDrivers.Text = currentChangeRequestModel.ChangeDrivers;
                txtChangeBenefits.Text = currentChangeRequestModel.ChangeBenefits;
                txtChangeCosts.Text = currentChangeRequestModel.ChangeCost;
                txtImpactDetails.Text = currentChangeRequestModel.ProjectImpact;
                txtSupportingDocumentation.Text = currentChangeRequestModel.SupportingDocuments;
                txtSignature.Text = currentChangeRequestModel.Signature;
            }
            else 
            {
                versionControl = new VersionControl<ChangeRequestModel>();
                versionControl.DocumentModels = new List<VersionControl<ChangeRequestModel>.DocumentModel>();
                newChangeRequestModel = new ChangeRequestModel();

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
                        document.InsertParagraph("Change Request Form \nFor " + projectModel.ProjectName)
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(22d).Alignment = Alignment.left;
                        document.InsertSectionPageBreak();

                        //Change details

                        var documentInfoTable = document.AddTable(14, 1);
                        documentInfoTable.Rows[0].Cells[0].Paragraphs[0].Append("Project Details").Bold(true).Color(Color.White).FontSize(14d);
               
                        documentInfoTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        documentInfoTable.Rows[2].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        documentInfoTable.Rows[4].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        documentInfoTable.Rows[6].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        documentInfoTable.Rows[8].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        documentInfoTable.Rows[10].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        documentInfoTable.Rows[12].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        documentInfoTable.Rows[1].Cells[0].Paragraphs[0].Append("Project Name: \t\t"+ currentChangeRequestModel.ProjectName+"\nProject Manager: \t"+ currentChangeRequestModel.ProjectManager);
                        documentInfoTable.Rows[2].Cells[0].Paragraphs[0].Append("Change Details").Bold().Color(Color.White).FontSize(14d);
                        documentInfoTable.Rows[3].Cells[0].Paragraphs[0].Append("Change Number: \t").Bold()
                                                                        .Append(currentChangeRequestModel.ChangeNumber)
                                                                        .Append("\nRequester: \t\t").Bold()
                                                                        .Append(currentChangeRequestModel.ChangeRequester)
                                                                        .Append("\nDate: \t\t\t").Bold()
                                                                        .Append(currentChangeRequestModel.ChangeRequestDate)
                                                                        .Append("\nUrgency: \t\t").Bold()
                                                                        .Append(currentChangeRequestModel.ChangeUrgancy);
                        documentInfoTable.Rows[4].Cells[0].Paragraphs[0].Append("Change Description: \n").Bold(true).Color(Color.White).FontSize(14d);
                        documentInfoTable.Rows[5].Cells[0].Paragraphs[0].Append(currentChangeRequestModel.ChangeDescription);
                        documentInfoTable.Rows[6].Cells[0].Paragraphs[0].Append("Change Drivers: \n").Bold().Color(Color.White).FontSize(14d);
                        documentInfoTable.Rows[7].Cells[0].Paragraphs[0].Append(currentChangeRequestModel.ChangeDrivers);
                        documentInfoTable.Rows[8].Cells[0].Paragraphs[0].Append("Change Benefits: \n").Bold().FontSize(14d).Color(Color.White);
                        documentInfoTable.Rows[9].Cells[0].Paragraphs[0].Append(currentChangeRequestModel.ChangeBenefits);
                        documentInfoTable.Rows[10].Cells[0].Paragraphs[0].Append("Change Costs: \n").Bold().FontSize(14d).Color(Color.White);
                        documentInfoTable.Rows[11].Cells[0].Paragraphs[0].Append(currentChangeRequestModel.ChangeCost);
                        documentInfoTable.Rows[12].Cells[0].Paragraphs[0].Append("Impact Details\n").Bold().FontSize(14d).Color(Color.White);
                        documentInfoTable.Rows[13].Cells[0].Paragraphs[0].Append(currentChangeRequestModel.ProjectImpact);
                        
                        documentInfoTable.SetWidths(new float[] { 1000});
                        document.InsertTable(documentInfoTable);

                        //Supporting documents table
                        document.InsertParagraph("\nApproval Details\n")
                           .Font("Arial")
                           .Bold()
                           .FontSize(14d).Alignment = Alignment.left;
                        
                        document.InsertParagraph("\nSupporting documents\n")
                           .Font("Arial")
                           .Bold()
                           .FontSize(11d).Alignment = Alignment.left;

                        document.InsertParagraph(currentChangeRequestModel.SupportingDocuments)
                           .Font("Arial")
                           .FontSize(11).Alignment = Alignment.left;

                        document.InsertParagraph("\nSignature\n")
                            .Font("Arial")
                            .FontSize(11d)
                            .Bold()
                            .Alignment = Alignment.left;

                        document.InsertParagraph(currentChangeRequestModel.Signature)
                           .Font("Arial")
                           .FontSize(11).Alignment = Alignment.left;

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

        

        private void ChangeRequestFormDocumentForm_Load_1(object sender, EventArgs e)
        {
            loadDocument();
            string jsoni = JsonHelper.loadProjectInfo(Settings.Default.Username);
            List<ProjectModel> projectListModel = JsonConvert.DeserializeObject<List<ProjectModel>>(jsoni);
            projectModel = projectModel.getProjectModel(Settings.Default.ProjectID, projectListModel);
            txtProjectName.Text = projectModel.ProjectName;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveDocument();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            exportToWord();
        }
    }
}
