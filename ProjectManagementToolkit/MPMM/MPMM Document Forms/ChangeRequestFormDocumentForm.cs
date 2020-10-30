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
    public partial class ChangeRequestFormDocumentForm : Form
    {
        private string projectName;
        private string projectManager;
        private string changeNumber;
        private string changeRequester;
        private DateTime changeRequestDate;
        private string changeUrgancy;
        private string changeDescription;
        private string changeDrivers;
        private string changeBenefits;
        private string changeCost;
        private string projectImpact;
        private string supportingDocumentation;
        private string signatue;

        public string ProjectName
        {
            get { return projectName; }
            set { projectName = value; }
        }

        public string ProjectManager
        {
            get { return projectManager; }
            set { projectManager = value; }
        }

        public string ChangeNumber
        {
            get { return changeNumber; }
            set { changeNumber = value; }
        }

        public string ChangeRequester
        {
            get { return changeRequester; }
            set { changeRequester = value; }
        }
        public DateTime ChangeRequestDate
        {
            get { return changeRequestDate; }
            set { changeRequestDate = value; }
        }

        public string ChangeUrgancy
        {
            get { return changeUrgancy; }
            set { changeUrgancy = value; }
        }

        public string ChangeDescription
        {
            get { return changeDescription; }
            set { changeDescription = value; }
        }

        public string ChangeDrivers
        {
            get { return changeDrivers; }
            set { changeDrivers = value; }
        }

        public string ChangeBenefits
        {
            get { return changeBenefits; }
            set { changeBenefits = value; }
        }

        public string ChangeCost
        {
            get { return changeCost; }
            set { changeCost = value; }
        }

        public string ProjectImpact
        {
            get { return projectImpact; }
            set { projectImpact = value; }
        }

        public string SupportingDocumentation
        {
            get { return supportingDocumentation; }
            set { supportingDocumentation = value; }
        }

        public string Signatue
        {
            get { return signatue; }
            set { signatue = value; }
        }
        public ChangeRequestFormDocumentForm()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
