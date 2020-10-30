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
    public partial class QualityManagementProcessDocumentForm : Form
    {
        private string projectName;
        private string documentId;
        private string documentOwner;
        private DateTime issueDate;
        private DateTime lastSavedDate;
        private string fileName;
        private List<DocumentHistory> documentHistories;
        private List<DocumentApproval> documentApprovals;
        private string qualityprocessDescription;
        private string qualityprocessOverview;
        private string qualityprocessMeasureQualityAchieved;
        private string qualityprocessEnhanceQualityAchieved;
        private string qualitymanagementrolesDescription;
        private string qualitymanagementrolesQualityManager;
        private string qualitymanagementrolesProjectManager;
        private string qualitymanagementdocumentsDescription;
        private string qualitymanagementdocumentsQualityRegister;
        private string qualitymanagementdocumentsQualityReviewForm;

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

        public string QualityprocessDescription
        {
            get { return qualityprocessDescription; }
            set { qualityprocessDescription = value; }
        }

        public string QualityprocessOverview
        {
            get { return qualityprocessOverview; }
            set { qualityprocessOverview = value; }
        }

        public string QualityprocessMeasureQualityAchieved
        {
            get { return qualityprocessMeasureQualityAchieved; }
            set { qualityprocessMeasureQualityAchieved = value; }
        }

        public string QualityprocessEnhanceQualityAchieved
        {
            get { return qualityprocessEnhanceQualityAchieved; }
            set { qualityprocessEnhanceQualityAchieved = value; }
        }

        public string QualitymanagementrolesDescription
        {
            get { return qualitymanagementrolesDescription; }
            set { qualitymanagementrolesDescription = value; }
        }

        public string QualitymanagementrolesQualityManager
        {
            get { return qualitymanagementrolesQualityManager; }
            set { qualitymanagementrolesQualityManager = value; }
        }

        public string QualitymanagementrolesProjectManager
        {
            get { return qualitymanagementrolesProjectManager; }
            set { qualitymanagementrolesProjectManager = value; }
        }

        public string QualitymanagementdocumentsDescription
        {
            get { return qualitymanagementdocumentsDescription; }
            set { qualitymanagementdocumentsDescription = value; }
        }

        public string QualitymanagementdocumentsQualityRegister
        {
            get { return qualitymanagementdocumentsQualityRegister; }
            set { qualitymanagementdocumentsQualityRegister = value; }
        }

        public string QualitymanagementdocumentsQualityReviewForm
        {
            get { return qualitymanagementdocumentsQualityReviewForm; }
            set { qualitymanagementdocumentsQualityReviewForm = value; }
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




        private void QualityManagementProcessDocumentForm_Load(object sender, EventArgs e)
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
