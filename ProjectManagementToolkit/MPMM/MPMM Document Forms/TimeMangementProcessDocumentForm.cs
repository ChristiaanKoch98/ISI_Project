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
    public partial class TimeMangementProcessDocumentForm : Form
    {
        private string projectName;
        private string documentId;
        private string documentOwner;
        private DateTime issueDate;
        private DateTime lastSavedDate;
        private string fileName;
        private List<DocumentHistory> documentHistories;
        private List<DocumentApproval> documentApprovals;
        private string timemanagementprocessDescription;
        private string timemanagementprocessOverview;
        private string timemanagementprocessDocumentTimesheet;
        private string timemanagementprocessApprovedTimesheet;
        private string timemanagementprocessUpdateProcessPlan;
        private string timemanagementrolesDescription;
        private string timemanagementrolesTeamMember;
        private string timemanagementrolesProjectManager;
        private string timemanagementrolesProjectAdminstratror;
        private string timemanagementdocumentsDescription;
        private string timemanagementdocumentsTimeSheet;
        private string timemanagementdocumentsTimeSheetRegister;

        public TimeMangementProcessDocumentForm()
        {
            InitializeComponent();
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

        public string TimemanagementprocessDescription
        {
            get { return timemanagementprocessDescription; }
            set { timemanagementprocessDescription = value; }
        }

        public string TimemanagementprocessOverview
        {
            get { return timemanagementprocessOverview; }
            set { timemanagementprocessOverview = value; }
        }

        public string TimemanagementprocessDocumentTimesheet
        {
            get { return timemanagementprocessDocumentTimesheet; }
            set { timemanagementprocessDocumentTimesheet = value; }
        }

        public string TimemanagementprocessApprovedTimesheet
        {
            get { return timemanagementprocessApprovedTimesheet; }
            set { timemanagementprocessApprovedTimesheet = value; }
        }

        public string TimemanagementprocessUpdateProcessPlan
        {
            get { return timemanagementprocessUpdateProcessPlan; }
            set { timemanagementprocessUpdateProcessPlan = value; }
        }

        public string TimemanagementrolesDescription
        {
            get { return timemanagementrolesDescription; }
            set { timemanagementrolesDescription = value; }
        }

        public string TimemanagementrolesTeamMember
        {
            get { return timemanagementrolesTeamMember; }
            set { timemanagementrolesTeamMember = value; }
        }

        public string TimemanagementrolesProjectManager
        {
            get { return timemanagementrolesProjectManager; }
            set { timemanagementrolesProjectManager = value; }
        }

        public string TimemanagementrolesProjectAdminstratror
        {
            get { return timemanagementrolesProjectAdminstratror; }
            set { timemanagementrolesProjectAdminstratror = value; }
        }

        public string TimemanagementdocumentsDescription
        {
            get { return timemanagementdocumentsDescription; }
            set { timemanagementdocumentsDescription = value; }
        }

        public string TimemanagementdocumentsTimeSheet
        {
            get { return timemanagementdocumentsTimeSheet; }
            set { timemanagementdocumentsTimeSheet = value; }
        }

        public string TimemanagementdocumentsTimeSheetRegister
        {
            get { return timemanagementdocumentsTimeSheetRegister; }
            set { timemanagementdocumentsTimeSheetRegister = value; }
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

        private void TimeMangementProcessDocumentForm_Load(object sender, EventArgs e)
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
