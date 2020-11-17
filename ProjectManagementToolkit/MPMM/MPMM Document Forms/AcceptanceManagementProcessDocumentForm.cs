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
    public partial class AcceptanceManagementProcessDocumentForm : Form
    {

        VersionControl<AcceptanceManagementProcessModel> versionControl;
        AcceptanceManagementProcessModel newAcceptanceManagementProcessModel;
        AcceptanceManagementProcessModel currentAcceptanceManagementProcessModel;





        public void saveDocument()
        {
            newAcceptanceManagementProcessModel.DocumentID = dataGridView1.Rows[0].Cells[1].Value.ToString();
            newAcceptanceManagementProcessModel.DocumentOwner = dataGridView1.Rows[1].Cells[1].Value.ToString();
            newAcceptanceManagementProcessModel.IssueDate = dataGridView1.Rows[2].Cells[1].Value.ToString();
            newAcceptanceManagementProcessModel.LastSavedDate = dataGridView1.Rows[3].Cells[1].Value.ToString();
            newAcceptanceManagementProcessModel.FileName = dataGridView1.Rows[4].Cells[1].Value.ToString();

            List<AcceptanceManagementProcessModel.DocumentHistory> documentHistories = new List<AcceptanceManagementProcessModel.DocumentHistory>();

            int versionRowsCount = dataGridView2.Rows.Count;

            for (int i = 0; i < versionRowsCount - 1; i++)
            {
                AcceptanceManagementProcessModel.DocumentHistory documentHistoryModel = new AcceptanceManagementProcessModel.DocumentHistory();
                var version = dataGridView2.Rows[i].Cells[0].Value?.ToString() ?? "";
                var issueDate = dataGridView2.Rows[i].Cells[1].Value?.ToString() ?? "";
                var changes = dataGridView2.Rows[i].Cells[2].Value?.ToString() ?? "";
                documentHistoryModel.Version = version;
                documentHistoryModel.IssueDate = issueDate;
                documentHistoryModel.Changes = changes;
                documentHistories.Add(documentHistoryModel);
            }
            newAcceptanceManagementProcessModel.DocumentHistories = documentHistories;

            List<AcceptanceManagementProcessModel.DocumentApproval> documentApprovalsModel = new List<AcceptanceManagementProcessModel.DocumentApproval>();

            int approvalRowsCount = dataGridView3.Rows.Count;

            for (int i = 0; i < approvalRowsCount - 1; i++)
            {
                AcceptanceManagementProcessModel.DocumentApproval documentApproval = new AcceptanceManagementProcessModel.DocumentApproval();
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
            newAcceptanceManagementProcessModel.DocumentApprovals = documentApprovalsModel;



            newAcceptanceManagementProcessModel.ProjectName = txtProjectName.Text;

            newAcceptanceManagementProcessModel.AcceptanceprocessDescription = txtacceptanceprocessDescription.Text;

            newAcceptanceManagementProcessModel.AcceptanceprocessOverview = txtacceptanceprocessOverview.Text;

            newAcceptanceManagementProcessModel.AcceptanceprocessCompleteDeliverable = txtacceptanceprocessCompleteDeliverable.Text;

            newAcceptanceManagementProcessModel.AcceptanceprocessCompleteAcceptanceTest = txtacceptanceprocessCompleteAcceptanceTest.Text;

            newAcceptanceManagementProcessModel.AcceptanceprocessAcceptDeliverable = txtacceptanceprocessAcceptDeliverable.Text;

            newAcceptanceManagementProcessModel.AcceptancerolesDescription = txtacceptancerolesDescription.Text;

            newAcceptanceManagementProcessModel.AcceptancerolesProjectManager = txtacceptancerolesProjectManager.Text;

            newAcceptanceManagementProcessModel.AcceptancerolesCustomer = txtacceptancerolesCustomer.Text;

            newAcceptanceManagementProcessModel.AcceptancedocumentsDescription = txtacceptancedocumentsDescription.Text;

            newAcceptanceManagementProcessModel.AcceptancedocumentsAcceptanceForm = txtacceptancedocumentsAcceptanceForm.Text;

            newAcceptanceManagementProcessModel.AcceptancedocumentsAcceptanceRegister = txtacceptancedocumentsAcceptanceRegister.Text;



            List<VersionControl<AcceptanceManagementProcessModel>.DocumentModel> documentModels = versionControl.DocumentModels;

            if (!versionControl.isEqual(currentAcceptanceManagementProcessModel, newAcceptanceManagementProcessModel))
            {
                VersionControl<AcceptanceManagementProcessModel>.DocumentModel documentModel = new VersionControl<AcceptanceManagementProcessModel>.DocumentModel(newAcceptanceManagementProcessModel, DateTime.Now, VersionControl<ProjectModel>.generateID());

                documentModels.Add(documentModel);

                versionControl.DocumentModels = documentModels;

                string json = JsonConvert.SerializeObject(versionControl);
                JsonHelper.saveDocument(json, Settings.Default.ProjectID, "AcceptanceManagementProcess");
                MessageBox.Show("Acceptance Management Process saved successfully", "save", MessageBoxButtons.OK);
            }

        }




        private void loadDocument()
        {
            string json = JsonHelper.loadDocument(Settings.Default.ProjectID, "AcceptanceManagementProcess");
            List<string[]> documentInfo = new List<string[]>();
            newAcceptanceManagementProcessModel = new AcceptanceManagementProcessModel();
            currentAcceptanceManagementProcessModel = new AcceptanceManagementProcessModel();
            if (json != "")
            {
                versionControl = JsonConvert.DeserializeObject<VersionControl<AcceptanceManagementProcessModel>>(json);
                newAcceptanceManagementProcessModel = JsonConvert.DeserializeObject<AcceptanceManagementProcessModel>(versionControl.getLatest(versionControl.DocumentModels));
                currentAcceptanceManagementProcessModel = JsonConvert.DeserializeObject<AcceptanceManagementProcessModel>(versionControl.getLatest(versionControl.DocumentModels));

                documentInfo.Add(new string[] { "Document ID", currentAcceptanceManagementProcessModel.DocumentID });
                documentInfo.Add(new string[] { "Document Owner", currentAcceptanceManagementProcessModel.DocumentOwner });
                documentInfo.Add(new string[] { "Issue Date", currentAcceptanceManagementProcessModel.IssueDate });
                documentInfo.Add(new string[] { "Last Save Date", currentAcceptanceManagementProcessModel.LastSavedDate });
                documentInfo.Add(new string[] { "File Name", currentAcceptanceManagementProcessModel.FileName });

                foreach (var row in documentInfo)
                {
                    dataGridView1.Rows.Add(row);
                }
                dataGridView1.AllowUserToAddRows = false;

                foreach (var row in currentAcceptanceManagementProcessModel.DocumentHistories)
                {
                    dataGridView2.Rows.Add(new string[] { row.Version, row.IssueDate, row.Changes });
                }

                foreach (var row in currentAcceptanceManagementProcessModel.DocumentApprovals)
                {
                    dataGridView3.Rows.Add(new string[] { row.Role, row.Name, "", row.DateApproved });
                }



                txtProjectName.Text = currentAcceptanceManagementProcessModel.ProjectName  ;

                txtacceptanceprocessDescription.Text = currentAcceptanceManagementProcessModel.AcceptanceprocessDescription  ;

                txtacceptanceprocessOverview.Text = currentAcceptanceManagementProcessModel.AcceptanceprocessOverview  ;

                txtacceptanceprocessCompleteDeliverable.Text = currentAcceptanceManagementProcessModel.AcceptanceprocessCompleteDeliverable  ;

                txtacceptanceprocessCompleteAcceptanceTest.Text = currentAcceptanceManagementProcessModel.AcceptanceprocessCompleteAcceptanceTest  ;

                txtacceptanceprocessAcceptDeliverable.Text = currentAcceptanceManagementProcessModel.AcceptanceprocessAcceptDeliverable  ;

                txtacceptancerolesDescription.Text = currentAcceptanceManagementProcessModel.AcceptancerolesDescription  ;

                txtacceptancerolesProjectManager.Text = currentAcceptanceManagementProcessModel.AcceptancerolesProjectManager  ;

                txtacceptancerolesCustomer.Text = currentAcceptanceManagementProcessModel.AcceptancerolesCustomer  ;

                txtacceptancedocumentsDescription.Text = currentAcceptanceManagementProcessModel.AcceptancedocumentsDescription  ;

                txtacceptancedocumentsAcceptanceForm.Text = currentAcceptanceManagementProcessModel.AcceptancedocumentsAcceptanceForm  ;

                txtacceptancedocumentsAcceptanceRegister.Text = currentAcceptanceManagementProcessModel.AcceptancedocumentsAcceptanceRegister  ;
            }
            else
            {
                versionControl = new VersionControl<AcceptanceManagementProcessModel>();
                versionControl.DocumentModels = new List<VersionControl<AcceptanceManagementProcessModel>.DocumentModel>();
                documentInfo.Add(new string[] { "Document ID", "" });
                documentInfo.Add(new string[] { "Document Owner", "" });
                documentInfo.Add(new string[] { "Issue Date", "" });
                documentInfo.Add(new string[] { "Last Save Date", "" });
                documentInfo.Add(new string[] { "File Name", "" });
                newAcceptanceManagementProcessModel = new AcceptanceManagementProcessModel();
                foreach (var row in documentInfo)
                {
                    dataGridView1.Rows.Add(row);
                }
                dataGridView1.AllowUserToAddRows = false;
            }
        }







        public AcceptanceManagementProcessDocumentForm()
        {
            InitializeComponent();
        }

        private void txtEnvirAnalysis_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBusinessOppurtunity_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBusinessProblemDescription_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveDocument();
        }

        private void AcceptanceManagementProcessDocumentForm_Load(object sender, EventArgs e)
        {
            loadDocument();
        }
    }
}
