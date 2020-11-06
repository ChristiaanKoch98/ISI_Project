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
    public partial class TimesheetFormDocumentForm : Form
    {
        public TimesheetFormDocumentForm()
        {
            InitializeComponent();
        }

        private void btnSaveTimesheetForm_Click(object sender, EventArgs e)
        {
            string timesheetProjectName = txtTimesheetFormProjectName.Text; //Add an if statement to make sure project name on timesheet form matches project name above timesheet form
            string timesheetProjectManager = txtTimesheetFormProjectManager.Text;
            string timesheetTeamMember = txtTimesheetFormTeamMember.Text;
            string submittedbyName = txtName.Text;
            string submittedbyProjectRole = txtProjectRole.Text;
            string submittedbySignature = txtSignature.Text;
            string submittedbyDate = dateTimePickerSubmittedBy.Text;
            string approvedbyName = txtApprovedByName.Text;
            string approvedbyProjectRole = txtApprovedByProjectRole.Text;
            string approvedbySignature = txtApprovedBySignature.Text;
            string approvedbyDate = dateTimePickerApprovedBy.Text;
            //Grid view on this page i believe is used to showcase all inputed information that must be saved to database

        }

        private void btnSaveProjectName_Click(object sender, EventArgs e)
        {
            string projectName = txtProjectName.Text;
        }
    }
}
