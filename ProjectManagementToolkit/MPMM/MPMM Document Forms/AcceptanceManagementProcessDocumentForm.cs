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
    public partial class AcceptanceManagementProcessDocumentForm : Form
    {

        private string projectName;
        private string documentId;
        private string documentOwner;
        private DateTime issueDate;
        private DateTime lastSavedDate;
        private string fileName;
        private List<DocumentHistory> documentHistories;
        private List<DocumentApproval> documentApprovals;
        private string acceptanceprocessDescription;
        private string acceptanceprocessOverview;
        private string acceptancedocumentsAcceptanceRegister;
        private string acceptancedocumentsAcceptanceForm;
        private string acceptancedocumentsDescription;
        private string acceptancerolesCustomer;
        private string acceptancerolesProjectManager;
        private string acceptancerolesDescription;
        private string acceptanceprocessAcceptDeliverable;
        private string acceptanceprocessCompleteAcceptanceTest;
        private string projectNaOverviewDescriptionme;
        private string acceptanceprocessCompleteDeliverable;

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




        // Properties
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

        public string AcceptanceprocessDescription
        {
            get { return acceptanceprocessDescription; }
            set { acceptanceprocessDescription = value; }
        }

        public string AcceptanceprocessOverview
        {
            get { return acceptanceprocessOverview; }
            set { acceptanceprocessOverview = value; }
        }

        public string AcceptanceprocessCompleteDeliverable
        {
            get { return acceptanceprocessCompleteDeliverable; }
            set { acceptanceprocessCompleteDeliverable = value; }
        }

        public string AcceptanceprocessCompleteAcceptanceTest
        {
            get { return acceptanceprocessCompleteAcceptanceTest; }
            set { acceptanceprocessCompleteAcceptanceTest = value; }
        }

        public string AcceptanceprocessAcceptDeliverable
        {
            get { return acceptanceprocessAcceptDeliverable; }
            set { acceptanceprocessAcceptDeliverable = value; }
        }

        public string AcceptancerolesDescription
        {
            get { return acceptancerolesDescription; }
            set { acceptancerolesDescription = value; }
        }

        public string AcceptancerolesProjectManager
        {
            get { return acceptancerolesProjectManager; }
            set { acceptancerolesProjectManager = value; }
        }

        public string AcceptancerolesCustomer
        {
            get { return acceptancerolesCustomer; }
            set { acceptancerolesCustomer = value; }
        }

        public string AcceptancedocumentsDescription
        {
            get { return acceptancedocumentsDescription; }
            set { acceptancedocumentsDescription = value; }
        }

        public string AcceptancedocumentsAcceptanceForm
        {
            get { return acceptancedocumentsAcceptanceForm; }
            set { acceptancedocumentsAcceptanceForm = value; }
        }

        public string AcceptancedocumentsAcceptanceRegister
        {
            get { return acceptancedocumentsAcceptanceRegister; }
            set { acceptancedocumentsAcceptanceRegister = value; }
        }





        //Here I put all of the classes
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



        private void AcceptanceManagementProcessDocumentForm_Load(object sender, EventArgs e)
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
