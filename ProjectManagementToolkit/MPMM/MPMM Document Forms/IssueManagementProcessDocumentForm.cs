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
    public partial class IssueManagementProcessDocumentForm : Form
    {
        private string projectName;
        private string documentId;
        private string documentOwner;
        private DateTime issueDate;
        private DateTime lastSavedDate;
        private string fileName;
        private List<DocumentHistory> documentHistories;
        private List<DocumentApproval> documentApprovals;
        private string overview;
        private string raiseIssue;
        private string reviewIssue;
        private string issueAction;
        private string teamMember;
        private string projectManager;
        private string projectBoard;
        private string issueForm;
        private string issueRegister;


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

        public string Overview
        {
            get { return overview; }
            set { overview = value; }
        }

        public string RaiseIssue
        {
            get { return raiseIssue; }
            set { raiseIssue = value; }
        }

        public string ReviewIssue
        {
            get { return reviewIssue; }
            set { reviewIssue = value; }
        }

        public string IssueAction
        {
            get { return issueAction; }
            set { issueAction = value; }
        }

        public string TeamMember
        {
            get { return teamMember; }
            set { teamMember = value; }
        }

        public string ProjectManager
        {
            get { return projectManager; }
            set { projectManager = value; }
        }

        public string ProjectBoard
        {
            get { return projectBoard; }
            set { projectBoard = value; }
        }

        public string IssueForm
        {
            get { return issueForm; }
            set { issueForm = value; }
        }

        public string IssueRegister
        {
            get { return issueRegister; }
            set { issueRegister = value; }
        }

        public IssueManagementProcessDocumentForm()
        {
            InitializeComponent();
        }

        private void IssueManagementProcessDocumentForm_Load(object sender, EventArgs e)
        {
            List<string[]> rows = new List<string[]>();
            rows.Add(new string[] { "Document ID", "" });
            rows.Add(new string[] { "Document Owner", "" });
            rows.Add(new string[] { "Issue Date", "" });
            rows.Add(new string[] { "Last Save Date", "" });
            rows.Add(new string[] { "File Name", "" });

            foreach (var row in rows)
            {
                DocumentInfoGrid.Rows.Add(row);
            }
            DocumentInfoGrid.AllowUserToAddRows = false;
        }
    }
}
