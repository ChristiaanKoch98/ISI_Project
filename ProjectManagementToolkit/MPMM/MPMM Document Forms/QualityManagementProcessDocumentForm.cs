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

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Forms
{
    public partial class QualityManagementProcessDocumentForm : Form
    {

        VersionControl<QualityManagementProcessModel> versionControl;
        QualityManagementProcessModel newQualityManagementProcessModel;
        QualityManagementProcessModel currentQualityManagementProcessModel;



        public void saveDocument()
        {
            newQualityManagementProcessModel.DocumentID = dataGridView1.Rows[0].Cells[1].Value.ToString();
            newQualityManagementProcessModel.DocumentOwner = dataGridView1.Rows[1].Cells[1].Value.ToString();
            newQualityManagementProcessModel.IssueDate = dataGridView1.Rows[2].Cells[1].Value.ToString();
            newQualityManagementProcessModel.LastSavedDate = dataGridView1.Rows[3].Cells[1].Value.ToString();
            newQualityManagementProcessModel.FileName = dataGridView1.Rows[4].Cells[1].Value.ToString();

            List<QualityManagementProcessModel.DocumentHistory> documentHistories = new List<QualityManagementProcessModel.DocumentHistory>();

            int versionRowsCount = dataGridView2.Rows.Count;

            for (int i = 0; i < versionRowsCount - 1; i++)
            {
                QualityManagementProcessModel.DocumentHistory documentHistoryModel = new QualityManagementProcessModel.DocumentHistory();
                var version = dataGridView2.Rows[i].Cells[0].Value?.ToString() ?? "";
                var issueDate = dataGridView2.Rows[i].Cells[1].Value?.ToString() ?? "";
                var changes = dataGridView2.Rows[i].Cells[2].Value?.ToString() ?? "";
                documentHistoryModel.Version = version;
                documentHistoryModel.IssueDate = issueDate;
                documentHistoryModel.Changes = changes;
                documentHistories.Add(documentHistoryModel);
            }
            newQualityManagementProcessModel.DocumentHistories = documentHistories;

            List<QualityManagementProcessModel.DocumentApproval> documentApprovalsModel = new List<QualityManagementProcessModel.DocumentApproval>();

            int approvalRowsCount = dataGridView3.Rows.Count;

            for (int i = 0; i < approvalRowsCount - 1; i++)
            {
                QualityManagementProcessModel.DocumentApproval documentApproval = new QualityManagementProcessModel.DocumentApproval();
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
            newQualityManagementProcessModel.DocumentApprovals = documentApprovalsModel;



            newQualityManagementProcessModel.QualityprocessDescription = txtqualityprocessDescription.Text;

            newQualityManagementProcessModel.QualityprocessOverview = txtqualityprocessOverview.Text;

            newQualityManagementProcessModel.QualityprocessMeasureQualityAchieved = txtqualityprocessMeasureQualityAchieved.Text;

            newQualityManagementProcessModel.QualityprocessEnhanceQualityAchieved = txtqualityprocessEnhanceQualityAchieved.Text;

            newQualityManagementProcessModel.QualitymanagementrolesDescription = txtqualitymanagementrolesDescription.Text;

            newQualityManagementProcessModel.QualitymanagementrolesQualityManager = txtqualitymanagementrolesQualityManager.Text;

            newQualityManagementProcessModel.QualitymanagementrolesProjectManager = txtqualitymanagementrolesProjectManager.Text;

            newQualityManagementProcessModel.QualitymanagementdocumentsDescription = txtqualitymanagementdocumentsDescription.Text;

            newQualityManagementProcessModel.QualitymanagementdocumentsQualityRegister = txtqualitymanagementdocumentsQualityRegister.Text;

            newQualityManagementProcessModel.QualitymanagementdocumentsQualityReviewForm = txtqualitymanagementdocumentsQualityReviewForm.Text;



            List<VersionControl<QualityManagementProcessModel>.DocumentModel> documentModels = versionControl.DocumentModels;

            if (!versionControl.isEqual(currentQualityManagementProcessModel, newQualityManagementProcessModel))
            {
                VersionControl<QualityManagementProcessModel>.DocumentModel documentModel = new VersionControl<QualityManagementProcessModel>.DocumentModel(newQualityManagementProcessModel, DateTime.Now, VersionControl<ProjectModel>.generateID());

                documentModels.Add(documentModel);

                versionControl.DocumentModels = documentModels;

                string json = JsonConvert.SerializeObject(versionControl);
                JsonHelper.saveDocument(json, Settings.Default.ProjectID, "QualityManagement");
                MessageBox.Show("Quality Management Process saved successfully", "save", MessageBoxButtons.OK);
            }

        }



        private void loadDocument()
        {
            string json = JsonHelper.loadDocument(Settings.Default.ProjectID, "TimeMangement");
            List<string[]> documentInfo = new List<string[]>();
            newQualityManagementProcessModel = new QualityManagementProcessModel();
            currentQualityManagementProcessModel = new QualityManagementProcessModel();
            if (json != "")
            {
                versionControl = JsonConvert.DeserializeObject<VersionControl<QualityManagementProcessModel>>(json);
                newQualityManagementProcessModel = JsonConvert.DeserializeObject<QualityManagementProcessModel>(versionControl.getLatest(versionControl.DocumentModels));
                currentQualityManagementProcessModel = JsonConvert.DeserializeObject<QualityManagementProcessModel>(versionControl.getLatest(versionControl.DocumentModels));

                documentInfo.Add(new string[] { "Document ID", currentQualityManagementProcessModel.DocumentID });
                documentInfo.Add(new string[] { "Document Owner", currentQualityManagementProcessModel.DocumentOwner });
                documentInfo.Add(new string[] { "Issue Date", currentQualityManagementProcessModel.IssueDate });
                documentInfo.Add(new string[] { "Last Save Date", currentQualityManagementProcessModel.LastSavedDate });
                documentInfo.Add(new string[] { "File Name", currentQualityManagementProcessModel.FileName });

                foreach (var row in documentInfo)
                {
                    dataGridView1.Rows.Add(row);
                }
                dataGridView1.AllowUserToAddRows = false;

                foreach (var row in currentQualityManagementProcessModel.DocumentHistories)
                {
                    dataGridView2.Rows.Add(new string[] { row.Version, row.IssueDate, row.Changes });
                }

                foreach (var row in currentQualityManagementProcessModel.DocumentApprovals)
                {
                    dataGridView3.Rows.Add(new string[] { row.Role, row.Name, "", row.DateApproved });
                }



                txtqualityprocessDescription.Text = currentQualityManagementProcessModel.QualityprocessDescription  ;

                txtqualityprocessOverview.Text = currentQualityManagementProcessModel.QualityprocessOverview  ;

                txtqualityprocessMeasureQualityAchieved.Text = currentQualityManagementProcessModel.QualityprocessMeasureQualityAchieved  ;

                txtqualityprocessEnhanceQualityAchieved.Text = currentQualityManagementProcessModel.QualityprocessEnhanceQualityAchieved  ;

                txtqualitymanagementrolesDescription.Text = currentQualityManagementProcessModel.QualitymanagementrolesDescription  ;

                txtqualitymanagementrolesQualityManager.Text = currentQualityManagementProcessModel.QualitymanagementrolesQualityManager  ;

                txtqualitymanagementrolesProjectManager.Text = currentQualityManagementProcessModel.QualitymanagementrolesProjectManager  ;

                txtqualitymanagementdocumentsDescription.Text = currentQualityManagementProcessModel.QualitymanagementdocumentsDescription  ;

                txtqualitymanagementdocumentsQualityRegister.Text = currentQualityManagementProcessModel.QualitymanagementdocumentsQualityRegister  ;

                txtqualitymanagementdocumentsQualityReviewForm.Text = currentQualityManagementProcessModel.QualitymanagementdocumentsQualityReviewForm  ;
            }
            else
            {
                versionControl = new VersionControl<QualityManagementProcessModel>();
                versionControl.DocumentModels = new List<VersionControl<QualityManagementProcessModel>.DocumentModel>();
                documentInfo.Add(new string[] { "Document ID", "" });
                documentInfo.Add(new string[] { "Document Owner", "" });
                documentInfo.Add(new string[] { "Issue Date", "" });
                documentInfo.Add(new string[] { "Last Save Date", "" });
                documentInfo.Add(new string[] { "File Name", "" });
                newQualityManagementProcessModel = new QualityManagementProcessModel();
                foreach (var row in documentInfo)
                {
                    dataGridView1.Rows.Add(row);
                }
                dataGridView1.AllowUserToAddRows = false;
            }
        }



        public QualityManagementProcessDocumentForm()
        {
            InitializeComponent();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtExecutiveSummary_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveDocument();
        }

        private void QualityManagementProcessDocumentForm_Load(object sender, EventArgs e)
        {
            loadDocument();
        }
    }
}
