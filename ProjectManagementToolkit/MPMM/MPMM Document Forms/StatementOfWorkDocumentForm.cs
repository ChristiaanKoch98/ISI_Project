using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Forms
{
    
        public partial class StatementOfWorkDocumentForm : Form
    {
        private string projectName;
        private string documentId;
        private string documentOwner;
        private DateTime issueDate;
        private DateTime lastSavedDate;
        private string fileName;
        private List<DocumentHistory> documentHistories;
        private List<DocumentApproval> documentApprovals;
        private string introduction;
        private string objectives;
        private List<ScopeOfWork> scopeOfWork;
        private string supplierResponsibilities;
        private string projectResponsibilities;
        private string acceptanceTerms;
        private string paymentTerms;
        private string confidentiality;
        private string otherTerms;


        public string ProjectName
        {
            get { return projectName; }
            set { projectName = value; }
        }

        public string DocumentID
        {
            get { return documentId; }
            set { documentId = value; }
        }

        public string DocumentOwner
        {
            get { return documentOwner; }
            set { documentOwner = value; }
        }

        public DateTime IssueDate
        {
            get { return issueDate; }
            set { issueDate = value; }
        }

        public DateTime LastSavedDate
        {
            get { return lastSavedDate; }
            set { lastSavedDate = value; }
        }

        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

        public List<DocumentHistory> DocumentHistories
        {
            get { return documentHistories; }
            set { documentHistories = value; }
        }

        public List<DocumentApproval> DocumentApprovals
        {
            get { return documentApprovals; }
            set { documentApprovals = value; }
        }

        public string Introduction
        {
            get { return introduction; }
            set { introduction = value; }
        }

        public string Objectives
        {
            get { return objectives; }
            set { objectives = value; }
        }

        public List<ScopeOfWork> ScopeOfWorks
        {
            get { return scopeOfWork; }
            set { scopeOfWork = value; }
        }

        public string SupplierResponsibilities
        {
            get { return supplierResponsibilities; }
            set { supplierResponsibilities = value; }
        }

        public string ProjectResponsibilities
        {
            get { return projectResponsibilities; }
            set { projectResponsibilities = value; }
        }

        public string AcceptanceTerms
        {
            get { return acceptanceTerms; }
            set { acceptanceTerms = value; }
        }

        public string PaymentTerms
        {
            get { return paymentTerms; }
            set { paymentTerms = value; }
        }

        public string Confidentiality
        {
            get { return confidentiality; }
            set { confidentiality = value; }
        }

        public string OtherTerms
        {
            get { return otherTerms; }
            set { otherTerms = value; }
        }    

        public class DocumentHistory
        {
            private string version;
            private DateTime issueDate;
            private string changes;

            //Properties
            public string Version
            {
                get { return version; }
                set { version = value; }
            }

            public DateTime IssueDate
            {
                get { return issueDate; }
                set { issueDate = value; }
            }

            public string Changes
            {
                get { return changes; }
                set { changes = value; }
            }
        }

        public class DocumentApproval
        {
            private string role;
            private string name;
            private string signature; //Function for signature creation
            private DateTime dateApproved;

            public string Role
            {
                get { return role; }
                set { role = value; }
            }

            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            public string Signature
            {
                get { return signature; }
                set { signature = value; }
            }

            public DateTime DateApproved
            {
                get { return dateApproved; }
                set { dateApproved = value; }
            }
        }

        public class ScopeOfWork
        {
            private string itemTitle;
            private string itemDescription;
            private string itemQuantity;

            public string ItemTitle
            {
                get { return itemTitle; }
                set { itemTitle = value; }
            }
            public string ItemDescription
            {
                get { return itemDescription; }
                set { itemDescription = value; }
            }
            public string ItemQuantity
            {
                get { return itemQuantity; }
                set { itemQuantity = value; }
            }

        }

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
            List<string[]> rows = new List<string[]>();
            rows.Add(new string[] { "Document ID", "" });
            rows.Add(new string[] { "Document Owner", "" });
            rows.Add(new string[] { "Issue Date", "" });
            rows.Add(new string[] { "Last Save Date", "" });
            rows.Add(new string[] { "File Name", "" });

            foreach (var row in rows)
            {
                dataGridView1.Rows.Add(row);
            }
            dataGridView1.AllowUserToAddRows = false;
        }
    }
}
