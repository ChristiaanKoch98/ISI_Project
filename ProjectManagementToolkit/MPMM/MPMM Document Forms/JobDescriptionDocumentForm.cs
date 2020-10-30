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
    public partial class JobDescriptionDocumentForm : Form
    {
        private string projectName;
        private string projectNaOverviewDescriptionme;
        private string purposeDescription;
        private string responsibilitiesDescription;
        private string organizationDescription;
        private string relationshipsDescription;
        private string skillsDescription;
        private string experienceDescription;
        private string qualificationsDescription;
        private string personalityDescription;
        private string performancecriteriaDescription;
        private string workenvironmentDescription;
        private string salaryDescription;
        private string specialconditionsDescription;





        public JobDescriptionDocumentForm()
        {
            InitializeComponent();
        }

        private void JobDescriptionDocumentForm_Load(object sender, EventArgs e)
        {

        }





        // Properties
        public string ProjectName
        {
            get { return projectName; }
            set { projectName = value; }
        }

        public string ProjectNaOverviewDescriptionme
        {
            get { return projectNaOverviewDescriptionme; }
            set { projectNaOverviewDescriptionme = value; }
        }

        public string PurposeDescription
        {
            get { return purposeDescription; }
            set { purposeDescription = value; }
        }

        public string ResponsibilitiesDescription
        {
            get { return responsibilitiesDescription; }
            set { responsibilitiesDescription = value; }
        }

        public string OrganizationDescription
        {
            get { return organizationDescription; }
            set { organizationDescription = value; }
        }

        public string RelationshipsDescription
        {
            get { return relationshipsDescription; }
            set { relationshipsDescription = value; }
        }

        public string SkillsDescription
        {
            get { return skillsDescription; }
            set { skillsDescription = value; }
        }

        public string ExperienceDescription
        {
            get { return experienceDescription; }
            set { experienceDescription = value; }
        }

        public string QualificationsDescription
        {
            get { return qualificationsDescription; }
            set { qualificationsDescription = value; }
        }

        public string PersonalityDescription
        {
            get { return personalityDescription; }
            set { personalityDescription = value; }
        }

        public string PerformancecriteriaDescription
        {
            get { return performancecriteriaDescription; }
            set { performancecriteriaDescription = value; }
        }

        public string WorkenvironmentDescription
        {
            get { return workenvironmentDescription; }
            set { workenvironmentDescription = value; }
        }

        public string SalaryDescription
        {
            get { return salaryDescription; }
            set { salaryDescription = value; }
        }

        public string SpecialconditionsDescription
        {
            get { return specialconditionsDescription; }
            set { specialconditionsDescription = value; }
        }


    }
}
