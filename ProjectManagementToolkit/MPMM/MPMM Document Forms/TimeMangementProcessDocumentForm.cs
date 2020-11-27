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
    public partial class TimeMangementProcessDocumentForm : Form
    {

        VersionControl<TimeMangementProcessModel> versionControl;
        TimeMangementProcessModel newTimeMangementProcessModel;
        TimeMangementProcessModel currentTimeMangementProcessModel;

        Color TABLE_HEADER_COLOR = Color.FromArgb(73, 173, 252);
        ProjectModel projectModel = new ProjectModel();



        public void saveDocument()
        {
            newTimeMangementProcessModel.DocumentID = dataGridView1.Rows[0].Cells[1].Value.ToString();
            newTimeMangementProcessModel.DocumentOwner = dataGridView1.Rows[1].Cells[1].Value.ToString();
            newTimeMangementProcessModel.IssueDate = dataGridView1.Rows[2].Cells[1].Value.ToString();
            newTimeMangementProcessModel.LastSavedDate = dataGridView1.Rows[3].Cells[1].Value.ToString();
            newTimeMangementProcessModel.FileName = dataGridView1.Rows[4].Cells[1].Value.ToString();

            List<TimeMangementProcessModel.DocumentHistory> documentHistories = new List<TimeMangementProcessModel.DocumentHistory>();

            int versionRowsCount = dataGridView2.Rows.Count;

            for (int i = 0; i < versionRowsCount - 1; i++)
            {
                TimeMangementProcessModel.DocumentHistory documentHistoryModel = new TimeMangementProcessModel.DocumentHistory();
                var version = dataGridView2.Rows[i].Cells[0].Value?.ToString() ?? "";
                var issueDate = dataGridView2.Rows[i].Cells[1].Value?.ToString() ?? "";
                var changes = dataGridView2.Rows[i].Cells[2].Value?.ToString() ?? "";
                documentHistoryModel.Version = version;
                documentHistoryModel.IssueDate = issueDate;
                documentHistoryModel.Changes = changes;
                documentHistories.Add(documentHistoryModel);
            }
            newTimeMangementProcessModel.DocumentHistories = documentHistories;

            List<TimeMangementProcessModel.DocumentApproval> documentApprovalsModel = new List<TimeMangementProcessModel.DocumentApproval>();

            int approvalRowsCount = dataGridView3.Rows.Count;

            for (int i = 0; i < approvalRowsCount - 1; i++)
            {
                TimeMangementProcessModel.DocumentApproval documentApproval = new TimeMangementProcessModel.DocumentApproval();
                var role = dataGridView3.Rows[i].Cells[0].Value?.ToString() ?? "";
                var name = dataGridView3.Rows[i].Cells[1].Value?.ToString() ?? "";
                var signature = dataGridView3.Rows[i].Cells[2].Value?.ToString() ?? "";
                var date = dataGridView3.Rows[i].Cells[3].Value?.ToString() ?? "";
                documentApproval.Role = role;
                documentApproval.Name = name;
                documentApproval.Signature = signature;
                documentApproval.DateApproved = date;

                documentApprovalsModel.Add(documentApproval);
            }
            newTimeMangementProcessModel.DocumentApprovals = documentApprovalsModel;



            newTimeMangementProcessModel.TimemanagementprocessDescription = txttimemanagementprocessDescription.Text;

            newTimeMangementProcessModel.TimemanagementprocessOverview = txttimemanagementprocessOverview.Text;

            newTimeMangementProcessModel.TimemanagementprocessDocumentTimesheet = txttimemanagementprocessDocumentTimesheet.Text;

            newTimeMangementProcessModel.TimemanagementprocessApprovedTimesheet = txttimemanagementprocessApprovedTimesheet.Text;

            newTimeMangementProcessModel.TimemanagementprocessUpdateProcessPlan = txttimemanagementprocessUpdateProcessPlan.Text;

            newTimeMangementProcessModel.TimemanagementrolesDescription = txttimemanagementrolesDescription.Text;

            newTimeMangementProcessModel.TimemanagementrolesTeamMember = txttimemanagementrolesTeamMember.Text;

            newTimeMangementProcessModel.TimemanagementrolesProjectManager = txttimemanagementrolesProjectManager.Text;

            newTimeMangementProcessModel.TimemanagementrolesProjectAdminstratror = txttimemanagementrolesProjectAdminstratror.Text;

            newTimeMangementProcessModel.TimemanagementdocumentsDescription = txttimemanagementdocumentsDescription.Text;

            newTimeMangementProcessModel.TimemanagementdocumentsTimeSheet = txttimemanagementdocumentsTimeSheet.Text;

            newTimeMangementProcessModel.TimemanagementdocumentsTimeSheetRegister = txttimemanagementdocumentsTimeSheetRegister.Text;



            List<VersionControl<TimeMangementProcessModel>.DocumentModel> documentModels = versionControl.DocumentModels;

            if (!versionControl.isEqual(currentTimeMangementProcessModel, newTimeMangementProcessModel))
            {
                VersionControl<TimeMangementProcessModel>.DocumentModel documentModel = new VersionControl<TimeMangementProcessModel>.DocumentModel(newTimeMangementProcessModel, DateTime.Now, VersionControl<ProjectModel>.generateID());

                documentModels.Add(documentModel);

                versionControl.DocumentModels = documentModels;

                string json = JsonConvert.SerializeObject(versionControl);
                JsonHelper.saveDocument(json, Settings.Default.ProjectID, "TimeMangement");
                MessageBox.Show("Time Management Process saved successfully", "save", MessageBoxButtons.OK);
            }

        }




        private void loadDocument()
        {
            string json = JsonHelper.loadDocument(Settings.Default.ProjectID, "TimeMangement");
            List<string[]> documentInfo = new List<string[]>();
            newTimeMangementProcessModel = new TimeMangementProcessModel();
            currentTimeMangementProcessModel = new TimeMangementProcessModel();
            if (json != "")
            {
                versionControl = JsonConvert.DeserializeObject<VersionControl<TimeMangementProcessModel>>(json);
                newTimeMangementProcessModel = JsonConvert.DeserializeObject<TimeMangementProcessModel>(versionControl.getLatest(versionControl.DocumentModels));
                currentTimeMangementProcessModel = JsonConvert.DeserializeObject<TimeMangementProcessModel>(versionControl.getLatest(versionControl.DocumentModels));

                documentInfo.Add(new string[] { "Document ID", currentTimeMangementProcessModel.DocumentID });
                documentInfo.Add(new string[] { "Document Owner", currentTimeMangementProcessModel.DocumentOwner });
                documentInfo.Add(new string[] { "Issue Date", currentTimeMangementProcessModel.IssueDate });
                documentInfo.Add(new string[] { "Last Save Date", currentTimeMangementProcessModel.LastSavedDate });
                documentInfo.Add(new string[] { "File Name", currentTimeMangementProcessModel.FileName });

                foreach (var row in documentInfo)
                {
                    dataGridView1.Rows.Add(row);
                }
                dataGridView1.AllowUserToAddRows = false;

                foreach (var row in currentTimeMangementProcessModel.DocumentHistories)
                {
                    dataGridView2.Rows.Add(new string[] { row.Version, row.IssueDate, row.Changes });
                }

                foreach (var row in currentTimeMangementProcessModel.DocumentApprovals)
                {
                    dataGridView3.Rows.Add(new string[] { row.Role, row.Name, "", row.DateApproved });
                }



                txttimemanagementprocessDescription.Text = currentTimeMangementProcessModel.TimemanagementprocessDescription ;

                txttimemanagementprocessOverview.Text = currentTimeMangementProcessModel.TimemanagementprocessOverview;

                txttimemanagementprocessDocumentTimesheet.Text = currentTimeMangementProcessModel.TimemanagementprocessDocumentTimesheet  ;

                txttimemanagementprocessApprovedTimesheet.Text = currentTimeMangementProcessModel.TimemanagementprocessApprovedTimesheet  ;

                txttimemanagementprocessUpdateProcessPlan.Text = currentTimeMangementProcessModel.TimemanagementprocessUpdateProcessPlan  ;

                txttimemanagementrolesDescription.Text = currentTimeMangementProcessModel.TimemanagementrolesDescription  ;

                txttimemanagementrolesTeamMember.Text = currentTimeMangementProcessModel.TimemanagementrolesTeamMember  ;

                txttimemanagementrolesProjectManager.Text = currentTimeMangementProcessModel.TimemanagementrolesProjectManager  ;

                txttimemanagementrolesProjectAdminstratror.Text = currentTimeMangementProcessModel.TimemanagementrolesProjectAdminstratror  ;

                txttimemanagementdocumentsDescription.Text = currentTimeMangementProcessModel.TimemanagementdocumentsDescription  ;

                txttimemanagementdocumentsTimeSheet.Text = currentTimeMangementProcessModel.TimemanagementdocumentsTimeSheet ;

                txttimemanagementdocumentsTimeSheetRegister.Text = currentTimeMangementProcessModel.TimemanagementdocumentsTimeSheetRegister ;
            }
            else
            {
                versionControl = new VersionControl<TimeMangementProcessModel>();
                versionControl.DocumentModels = new List<VersionControl<TimeMangementProcessModel>.DocumentModel>();
                documentInfo.Add(new string[] { "Document ID", "" });
                documentInfo.Add(new string[] { "Document Owner", "" });
                documentInfo.Add(new string[] { "Issue Date", "" });
                documentInfo.Add(new string[] { "Last Save Date", "" });
                documentInfo.Add(new string[] { "File Name", "" });
                newTimeMangementProcessModel = new TimeMangementProcessModel();
                foreach (var row in documentInfo)
                {
                    dataGridView1.Rows.Add(row);
                }
                dataGridView1.AllowUserToAddRows = false;
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

                        //Code for the Front page
                        document.InsertParagraph("Project Plan \nFor " + projectModel.ProjectName)
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(22d).Alignment = Alignment.left;
                        document.InsertSectionPageBreak();
                        //Code for the Front page



                    }
                }
            }
        }





        public TimeMangementProcessDocumentForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveDocument();
        }

        private void TimeMangementProcessDocumentForm_Load(object sender, EventArgs e)
        {
            loadDocument();
            string json = JsonHelper.loadProjectInfo(Settings.Default.Username);
            List<ProjectModel> projectListModel = JsonConvert.DeserializeObject<List<ProjectModel>>(json);
            projectModel = projectModel.getProjectModel(Settings.Default.ProjectID, projectListModel);
        }
    }
}
