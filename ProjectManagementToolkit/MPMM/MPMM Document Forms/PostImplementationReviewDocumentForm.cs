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
    public partial class PostImplementationReviewDocumentForm : Form
    {
        private string projectName;
        private string documentId;
        private string documentOwner;
        private DateTime issueDate;
        private DateTime lastSavedDate;
        private string fileName;
        private List<DocumentHistory> documentHistories;
        private List<DocumentApproval> documentApprovals;
        private string executivesummaryDescription;
        private string projectperformanceDescription;
        private List<Benefit> benefits;
        private List<Objective> objectives;
        private List<Scope> scopes;
        private List<Delivarable> delivarables;
        private string projectperformanceSchedule;
        private List<Expense> expenses;
        private List<Resource> resources;
        private string projectComformanceDescription;
        private string projectcomformanceTimeManagement;
        private string projectcomformanceCostManagement;
        private string projectcomformanceQualitManagement;
        private string projectcomformanceChangeManagement;
        private string projectcomformanceRiskManagement;
        private string projectcomformanceIssueManagement;
        private string projectcomformanceProcurementManagement;
        private string projectcomformanceAcceptanceManagement;
        private string projectcomformanceCommunicationManagement;
        private string projectachievementDescription;
        private List<ProjectAchievement> projectAchievements;
        private string projectfailureDescription;
        private List<ProjectFailure> projectFailures;
        private string projectlessonslearneDescription;
        private List<ProjectLessonsLearned> projectLessonsLearned;
        private string appendixDescription;
        private string appendixSupportingDocumentation;

        public PostImplementationReviewDocumentForm()
        {
            InitializeComponent();
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView11_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
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

        public string ExecutivesummaryDescription
        {
            get { return executivesummaryDescription; }
            set { executivesummaryDescription = value; }
        }

        public string ProjectperformanceDescription
        {
            get { return projectperformanceDescription; }
            set { projectperformanceDescription = value; }
        }

        public List<Benefit> Benefits
        {
            get { return benefits; }
            set { benefits = value; }
        }

        public List<Objective> Objectives
        {
            get { return objectives; }
            set { objectives = value; }
        }

        public List<Scope> Scopes
        {
            get { return scopes; }
            set { scopes = value; }
        }

        public List<Delivarable> Delivarables
        {
            get { return delivarables; }
            set { delivarables = value; }
        }

        public string ProjectperformanceSchedule
        {
            get { return projectperformanceSchedule; }
            set { projectperformanceSchedule = value; }
        }

        public List<Expense> Expenses
        {
            get { return expenses; }
            set { expenses = value; }
        }

        public List<Resource> Resources
        {
            get { return resources; }
            set { resources = value; }
        }

        public string ProjectComformanceDescription
        {
            get { return projectComformanceDescription; }
            set { projectComformanceDescription = value; }
        }

        public string ProjectcomformanceTimeManagement
        {
            get { return projectcomformanceTimeManagement; }
            set { projectcomformanceTimeManagement = value; }
        }

        public string ProjectcomformanceCostManagement
        {
            get { return projectcomformanceCostManagement; }
            set { projectcomformanceCostManagement = value; }
        }

        public string ProjectcomformanceQualitManagement
        {
            get { return projectcomformanceQualitManagement; }
            set { projectcomformanceQualitManagement = value; }
        }

        public string ProjectcomformanceChangeManagement
        {
            get { return projectcomformanceChangeManagement; }
            set { projectcomformanceChangeManagement = value; }
        }

        public string ProjectcomformanceRiskManagement
        {
            get { return projectcomformanceRiskManagement; }
            set { projectcomformanceRiskManagement = value; }
        }

        public string ProjectcomformanceIssueManagement
        {
            get { return projectcomformanceIssueManagement; }
            set { projectcomformanceIssueManagement = value; }
        }

        public string ProjectcomformanceProcurementManagement
        {
            get { return projectcomformanceProcurementManagement; }
            set { projectcomformanceProcurementManagement = value; }
        }

        public string ProjectcomformanceAcceptanceManagement
        {
            get { return projectcomformanceAcceptanceManagement; }
            set { projectcomformanceAcceptanceManagement = value; }
        }

        public string ProjectcomformanceCommunicationManagement
        {
            get { return projectcomformanceCommunicationManagement; }
            set { projectcomformanceCommunicationManagement = value; }
        }

        public string ProjectachievementDescription
        {
            get { return projectachievementDescription; }
            set { projectachievementDescription = value; }
        }

        public List<ProjectAchievement> ProjectAchievements
        {
            get { return projectAchievements; }
            set { projectAchievements = value; }
        }

        public string ProjectfailureDescription
        {
            get { return projectfailureDescription; }
            set { projectfailureDescription = value; }
        }

        public List<ProjectFailure> ProjectFailures
        {
            get { return projectFailures; }
            set { projectFailures = value; }
        }

        public string ProjectlessonslearneDescription
        {
            get { return projectlessonslearneDescription; }
            set { projectlessonslearneDescription = value; }
        }

        public List<ProjectLessonsLearned> ProjectLessonsLearneds
        {
            get { return projectLessonsLearned; }
            set { projectLessonsLearned = value; }
        }

        public string AppendixDescription
        {
            get { return appendixDescription; }
            set { appendixDescription = value; }
        }

        public string AppendixSupportingDocumentation
        {
            get { return appendixSupportingDocumentation; }
            set { appendixSupportingDocumentation = value; }
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

        public class Benefit
        {
            private string benefitDesc;
            private string forecastValue;
            private string actualValue;
            private string deviation;

            public string BenefitDesc
            {
                get { return benefitDesc; }
                set { benefitDesc = value; }
            }

            public string ForecastValue
            {
                get { return forecastValue; }
                set { forecastValue = value; }
            }

            public string ActualValue
            {
                get { return actualValue; }
                set { actualValue = value; }
            }

            public string Deviation
            {
                get { return deviation; }
                set { deviation = value; }
            }
        }

        public class Objective
        {
            private string objectiveDesc;
            private string achievement;
            private string shortfall;

            public string ObjectiveDesc
            {
                get { return objectiveDesc; }
                set { objectiveDesc = value; }
            }

            public string Achievement
            {
                get { return achievement; }
                set { achievement = value; }
            }

            public string Shortfall
            {
                get { return shortfall; }
                set { shortfall = value; }
            }

        }

        public class Scope
        {
            private string originalScope;
            private string actualScope;
            private string deviation;

            public string OriginalScope
            {
                get { return originalScope; }
                set { originalScope = value; }
            }

            public string ActualScope
            {
                get { return actualScope; }
                set { actualScope = value; }
            }

            public string Deviation
            {
                get { return deviation; }
                set { deviation = value; }
            }

        }

        public class Delivarable
        {
            private string deliverableDesc;
            private string qualityCriteria;
            private string qualityStandards;
            private string achievement;

            public string DeliverableDesc
            {
                get { return deliverableDesc; }
                set { deliverableDesc = value; }
            }

            public string QualityCriteria
            {
                get { return qualityCriteria; }
                set { qualityCriteria = value; }
            }

            public string QualityStandards
            {
                get { return qualityStandards; }
                set { qualityStandards = value; }
            }

            public string Achievement
            {
                get { return achievement; }
                set { achievement = value; }
            }
        }

        public class Expense
        {
            private string expenseTypes;
            private string forecastExpenditure;
            private string actualExpenditure;
            private string deviation;

            public string ExpenseTypes
            {
                get { return expenseTypes; }
                set { expenseTypes = value; }
            }

            public string ForecastExpenditure
            {
                get { return forecastExpenditure; }
                set { forecastExpenditure = value; }
            }

            public string ActualExpenditure
            {
                get { return actualExpenditure; }
                set { actualExpenditure = value; }
            }

            public string Deviation
            {
                get { return deviation; }
                set { deviation = value; }
            }
        }

        public class Resource
        {
            private string resourceTypes;
            private string forecastResource;
            private string actualResource;
            private string deviation;

            public string ResourceTypes
            {
                get { return resourceTypes; }
                set { resourceTypes = value; }
            }

            public string ForecastResource
            {
                get { return forecastResource; }
                set { forecastResource = value; }
            }

            public string ActualResource
            {
                get { return actualResource; }
                set { actualResource = value; }
            }

            public string Deviation
            {
                get { return deviation; }
                set { deviation = value; }
            }
        }

        public class ProjectAchievement
        {
            private string achievement;
            private string effectOnBusiness;

            public string Achievement
            {
                get { return achievement; }
                set { achievement = value; }
            }

            public string EffectOnBusiness
            {
                get { return effectOnBusiness; }
                set { effectOnBusiness = value; }
            }

        }

        public class ProjectFailure
        {
            private string failure;
            private string effectOnBusiness;

            public string Failure
            {
                get { return failure; }
                set { failure = value; }
            }

            public string EffectOnBusiness
            {
                get { return effectOnBusiness; }
                set { effectOnBusiness = value; }
            }

        }

        public class ProjectLessonsLearned
        {
            private string learning;
            private string recommendation;

            public string Learning
            {
                get { return learning; }
                set { learning = value; }
            }

            public string Recommendation
            {
                get { return recommendation; }
                set { recommendation = value; }
            }

        }



        private void PostImplementationReviewDocumentForm_Load(object sender, EventArgs e)
        {

        }
    }
}
