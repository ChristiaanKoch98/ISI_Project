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
    public partial class ExpenseFormDocumentForm : Form
    {
        private string projectDetails;
        private List<ExpenseDetail> expenseDetail;
        private string approvaldetails;

        public ExpenseFormDocumentForm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void txtProjectName_TextChanged(object sender, EventArgs e)
        {

        }




        // Properties
        public string ProjectDetails
        {
            get { return projectDetails; }
            set { projectDetails = value; }
        }

        public List<ExpenseDetail> ExpenseDetails
        {
            get { return expenseDetail; }
            set { expenseDetail = value; }
        }

        public string Approvaldetails
        {
            get { return approvaldetails; }
            set { approvaldetails = value; }
        }







        //Here I put all of the classes
        public class ExpenseDetail
        {
            private string activityID;
            private string taskID;
            private DateTime issueDate;
            private string expenseType;
            private string expenseDescription;
            private string expenseAmount;
            private string payeeName;
            private string invoiceNumber;


            //Properties
            public string ActivityID
            {
                get { return activityID; }
                set { activityID = value; }
            }

            public string TaskID
            {
                get { return taskID; }
                set { taskID = value; }
            }

            public DateTime ExpenseDate
            {
                get { return issueDate; }
                set { issueDate = value; }
            }

            public string ExpenseType
            {
                get { return expenseType; }
                set { expenseType = value; }
            }

            public string ExpenseDescription
            {
                get { return expenseDescription; }
                set { expenseDescription = value; }
            }

            public string ExpenseAmount
            {
                get { return expenseAmount; }
                set { expenseAmount = value; }
            }

            public string PayeeName
            {
                get { return payeeName; }
                set { payeeName = value; }
            }

            public string InvoiceNumber
            {
                get { return invoiceNumber; }
                set { invoiceNumber = value; }
            }
        }

    }
}
