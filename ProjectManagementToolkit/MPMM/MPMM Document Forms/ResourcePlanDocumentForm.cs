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
    public partial class ResourcePlanDocumentForm : Form
    {
        private string projectName;
        private string documentId;
        private string documentOwner;
        private DateTime issueDate;
        private DateTime lastSavedDate;
        private string fileName;
        private List<DocumentHistory> documentHistories;
        private List<DocumentApproval> documentApprovals;
        private List<Labor> labors;
        private List<Equipment> equipments;
        private List<Materials> material;
        private List<Schedule> schedules;
        private string assumptions;
        private string constraints;

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

        public List<Labor> Labors
        {
            get { return labors; }
            set { labors = value; }
        }
        public List<Equipment> Equipments
        {
            get { return equipments; }
            set { equipments = value; }
        }
        public List<Materials> Material
        {
            get { return material; }
            set { material = value; }
        }

        public List<Schedule> Schedules
        {
            get { return schedules; }
            set { schedules = value; }
        }

        public string Assumptions
        {
            get { return fileName; }
            set { fileName = value; }
        }

        public string Constraints
        {
            get { return fileName; }
            set { fileName = value; }
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

        public class Labor
        {
            private string role;
            private string number;
            private string responsibility;
            private string skill;
            private DateTime startDate;
            private DateTime endDate;

            public string Constraints
            {
                get { return role; }
                set { role = value; }
            }

            public string Number
            {
                get { return number; }
                set { number = value; }
            }

            public string Responsibility
            {
                get { return responsibility; }
                set { responsibility = value; }
            }

            public string Skill
            {
                get { return skill; }
                set { skill = value; }
            }

            public DateTime StartDate
            {
                get { return startDate; }
                set { startDate = value; }
            }
            public DateTime EndDate
            {
                get { return endDate; }
                set { endDate = value; }
            }

        }
        public class Equipment
        {
            private string item;
            private string amount;
            private string purpose;
            private string specification;
            private DateTime startDate;
            private DateTime endDate;


            public string Iitem
            {
                get { return item; }
                set { item = value; }
            }
            public string Amount
            {
                get { return amount; }
                set { amount = value; }
            }
            public string Purpose
            {
                get { return purpose; }
                set { purpose = value; }
            }
            public string Specification
            {
                get { return specification; }
                set { specification = value; }
            }
            public DateTime StartDate
            {
                get { return startDate; }
                set { startDate = value; }
            }
            public DateTime EndDate
            {
                get { return endDate; }
                set { endDate = value; }
            }
        }
        public class Materials
        {
            private string item;
            private string amount;
            private DateTime startDate;
            private DateTime endDate;

            public string Iitem
            {
                get { return item; }
                set { item = value; }
            }
            public string Amount
            {
                get { return amount; }
                set { amount = value; }
            }
            public DateTime StartDate
            {
                get { return startDate; }
                set { startDate = value; }
            }
            public DateTime EndDate
            {
                get { return endDate; }
                set { endDate = value; }
            }
        }

        public class Schedule
        {
            private string resource;
            private string jan;
            private string feb;
            private string mar;
            private string apr;
            private string may;
            private string jun;
            private string jul;
            private string aug;
            private string sept;
            private string oct;
            private string nov;
            private string dec;
            private string total;

            public string Resource
            {
                get { return resource; }
                set { resource = value; }
            }

            public string Jan
            {
                get { return jan; }
                set { jan = value; }
            }

            public string Feb
            {
                get { return feb; }
                set { feb = value; }
            }

            public string Mar
            {
                get { return mar; }
                set { mar = value; }
            }

            public string Apr
            {
                get { return apr; }
                set { apr = value; }
            }

            public string May
            {
                get { return may; }
                set { may = value; }
            }

            public string Jun
            {
                get { return jun; }
                set { jun = value; }
            }

            public string Jul
            {
                get { return jul; }
                set { jul = value; }
            }

            public string Aug
            {
                get { return aug; }
                set { aug = value; }
            }

            public string Sept
            {
                get { return sept; }
                set { sept = value; }
            }

            public string Oct
            {
                get { return oct; }
                set { oct = value; }
            }

            public string Nov
            {
                get { return nov; }
                set { nov = value; }
            }

            public string Dec
            {
                get { return dec; }
                set { dec = value; }
            }

            public string Total
            {
                get { return total; }
                set { total = value; }
            }
        }

        public string Assumption
        {
            get { return assumptions; }
            set { assumptions = value; }
        }

        public string Constraint
        {
            get { return constraints; }
            set { constraints = value; }
        }

        public ResourcePlanDocumentForm()
        {
            InitializeComponent();
        }

        private void ResourcePlanDocumentForm_Load(object sender, EventArgs e)
        {
            
                List<string[]> rows = new List<string[]>();
                rows.Add(new string[] { "Document ID", "" });
                rows.Add(new string[] { "Document Owner", "" });
                rows.Add(new string[] { "Issue Date", "" });
                rows.Add(new string[] { "Last Save Date", "" });
                rows.Add(new string[] { "File Name", "" });
                foreach (var row in rows)
                {
                    docInfoGridData.Rows.Add(row);
                }
                docInfoGridData.AllowUserToAddRows = false;

            }

        private void ResourcePlanDocumentForm_Load_1(object sender, EventArgs e)
        {
           
        }
    }
    }

