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

    public partial class StatementOfWorkDocumentForm : Form
    {
        VersionControl<StatementOfWorkModel> versionControl;
        StatementOfWorkModel newStatementOfWorkModel;
        StatementOfWorkModel currentStatementOfWorkModel;

        public StatementOfWorkDocumentForm()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void StatementOfWorkDocumentForm_Load(object sender, EventArgs e)
        {
            loadDocument();
        }

        private void btnStatementSave_Click(object sender, EventArgs e)
        {
            saveDocument();
        }

        public void saveDocument()
        {
            newStatementOfWorkModel.DocumentID = dataGridView1.Rows[0].Cells[1].Value.ToString();
            newStatementOfWorkModel.DocumentOwner = dataGridView1.Rows[1].Cells[1].Value.ToString();
            newStatementOfWorkModel.IssueDate = dataGridView1.Rows[2].Cells[1].Value.ToString();
            newStatementOfWorkModel.LastSavedDate = dataGridView1.Rows[3].Cells[1].Value.ToString();
            newStatementOfWorkModel.FileName = dataGridView1.Rows[4].Cells[1].Value.ToString();

            List<StatementOfWorkModel.DocumentHistory> documentHistories = new List<StatementOfWorkModel.DocumentHistory>();

            int versionRowsCount = dataGridView2.Rows.Count;

            for (int i = 0; i < versionRowsCount - 1; i++)
            {
                StatementOfWorkModel.DocumentHistory documentHistoryModel = new StatementOfWorkModel.DocumentHistory();
                var version = dataGridView2.Rows[i].Cells[0].Value?.ToString() ?? "";
                var issueDate = dataGridView2.Rows[i].Cells[1].Value?.ToString() ?? "";
                var changes = dataGridView2.Rows[i].Cells[2].Value?.ToString() ?? "";
                documentHistoryModel.Version = version;
                documentHistoryModel.IssueDate = issueDate;
                documentHistoryModel.Changes = changes;
                documentHistories.Add(documentHistoryModel);
            }
            newStatementOfWorkModel.DocumentHistories = documentHistories;

            List<StatementOfWorkModel.DocumentApproval> documentApprovalsModel = new List<StatementOfWorkModel.DocumentApproval>();

            int approvalRowsCount = dataGridView3.Rows.Count;

            for (int i = 0; i < approvalRowsCount - 1; i++)
            {
                StatementOfWorkModel.DocumentApproval documentApproval = new StatementOfWorkModel.DocumentApproval();
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
            newStatementOfWorkModel.DocumentApprovals = documentApprovalsModel;

            List<StatementOfWorkModel.ScopeOfWork> scopeOfWorkModel = new List<StatementOfWorkModel.ScopeOfWork>();

            int scopeRowsCount = dataGridView4.Rows.Count;

            for (int i = 0; i < approvalRowsCount - 1; i++)
            {
                StatementOfWorkModel.ScopeOfWork scopeOfWork = new StatementOfWorkModel.ScopeOfWork();
                var itemTitle = dataGridView4.Rows[i].Cells[0].Value?.ToString() ?? "";
                var itemDescription = dataGridView4.Rows[i].Cells[1].Value?.ToString() ?? "";
                var itemQuantity = dataGridView4.Rows[i].Cells[2].Value?.ToString() ?? "";
                scopeOfWork.ItemTitle = itemTitle;
                scopeOfWork.ItemDescription = itemDescription;
                scopeOfWork.ItemQuantity = itemQuantity;

                scopeOfWorkModel.Add(scopeOfWork);
            }
            newStatementOfWorkModel.ScopeOfWorks = scopeOfWorkModel;

            newStatementOfWorkModel.Introduction = textBox2.Text;


            newStatementOfWorkModel.Objectives = textBox3.Text;

            newStatementOfWorkModel.SupplierResponsibilities = textBox4.Text ;

            newStatementOfWorkModel.ProjectResponsibilities = textBox5.Text ;

            newStatementOfWorkModel.AcceptanceTerms = textBox6.Text ;

            newStatementOfWorkModel.PaymentTerms = textBox7.Text ;

            newStatementOfWorkModel.Confidentiality = textBox8.Text ;

            newStatementOfWorkModel.OtherTerms = textBox9.Text ;


            List<VersionControl<StatementOfWorkModel>.DocumentModel> documentModels = versionControl.DocumentModels;


            if (!versionControl.isEqual(currentStatementOfWorkModel, newStatementOfWorkModel))
            {
                VersionControl<StatementOfWorkModel>.DocumentModel documentModel = new VersionControl<StatementOfWorkModel>.DocumentModel(newStatementOfWorkModel, DateTime.Now, VersionControl<ProjectModel>.generateID());

                documentModels.Add(documentModel);

                versionControl.DocumentModels = documentModels;

                string json = JsonConvert.SerializeObject(versionControl);
                JsonHelper.saveDocument(json, Settings.Default.ProjectID, "StatementOfWork");
                MessageBox.Show("PStatement of Work saved successfully", "save", MessageBoxButtons.OK);
            }



        }

        public void loadDocument()
        {
            string json = JsonHelper.loadDocument(Settings.Default.ProjectID, "StatementOfWork");
            List<string[]> documentInfo = new List<string[]>();
            newStatementOfWorkModel = new StatementOfWorkModel();
            currentStatementOfWorkModel = new StatementOfWorkModel();
            if (json != "")
            {
                versionControl = JsonConvert.DeserializeObject<VersionControl<StatementOfWorkModel>>(json);
                newStatementOfWorkModel = JsonConvert.DeserializeObject<StatementOfWorkModel>(versionControl.getLatest(versionControl.DocumentModels));
                currentStatementOfWorkModel = JsonConvert.DeserializeObject<StatementOfWorkModel>(versionControl.getLatest(versionControl.DocumentModels));

                documentInfo.Add(new string[] { "Document ID", currentStatementOfWorkModel.DocumentID });
                documentInfo.Add(new string[] { "Document Owner", currentStatementOfWorkModel.DocumentOwner });
                documentInfo.Add(new string[] { "Issue Date", currentStatementOfWorkModel.IssueDate });
                documentInfo.Add(new string[] { "Last Save Date", currentStatementOfWorkModel.LastSavedDate });
                documentInfo.Add(new string[] { "File Name", currentStatementOfWorkModel.FileName });

                foreach (var row in documentInfo)
                {
                    dataGridView1.Rows.Add(row);
                }
                dataGridView1.AllowUserToAddRows = false;

                foreach (var row in currentStatementOfWorkModel.DocumentHistories)
                {
                    dataGridView2.Rows.Add(new string[] { row.Version, row.IssueDate, row.Changes });
                }

                foreach (var row in currentStatementOfWorkModel.DocumentApprovals)
                {
                    dataGridView3.Rows.Add(new string[] { row.Role, row.Name, "", row.DateApproved });
                }

                textBox2.Text = currentStatementOfWorkModel.Introduction;

                textBox3.Text = currentStatementOfWorkModel.Objectives;

                foreach (var row in currentStatementOfWorkModel.ScopeOfWorks)
                {
                    dataGridView4.Rows.Add(new string[] { row.ItemTitle, row.ItemDescription, row.ItemQuantity });
                }


                textBox4.Text = currentStatementOfWorkModel.SupplierResponsibilities;

                textBox5.Text = currentStatementOfWorkModel.ProjectResponsibilities;

                textBox6.Text = currentStatementOfWorkModel.AcceptanceTerms;

                textBox7.Text = currentStatementOfWorkModel.PaymentTerms;

                textBox8.Text = currentStatementOfWorkModel.Confidentiality;

                textBox9.Text = currentStatementOfWorkModel.OtherTerms;
            }
            else
            {
                versionControl = new VersionControl<StatementOfWorkModel>();
                versionControl.DocumentModels = new List<VersionControl<StatementOfWorkModel>.DocumentModel>();
                documentInfo.Add(new string[] { "Document ID", "" });
                documentInfo.Add(new string[] { "Document Owner", "" });
                documentInfo.Add(new string[] { "Issue Date", "" });
                documentInfo.Add(new string[] { "Last Save Date", "" });
                documentInfo.Add(new string[] { "File Name", "" });
                newStatementOfWorkModel = new StatementOfWorkModel();
                foreach (var row in documentInfo)
                {
                    dataGridView1.Rows.Add(row);
                }
                dataGridView1.AllowUserToAddRows = false;
            }
        }
    }
}
