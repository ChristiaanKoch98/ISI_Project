using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectManagementToolkit.MPMM.MPMM_Document_Models;
using ProjectManagementToolkit.Utility;
using ProjectManagementToolkit.Properties;
using Newtonsoft.Json;
using MoreLinq;

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Forms
{
    public partial class ProjectStatusReportDocumentForm : Form
    {
        VersionControl<ProjectStatusReportModel> versionControl;
        ProjectStatusReportModel newProjectStatusReportModel;
        ProjectStatusReportModel currentProjectStatusReportModel;

        public ProjectStatusReportDocumentForm()
        {
            InitializeComponent();
        }

        private void ProjectStatusReportDocumentForm_Load(object sender, EventArgs e)
        {
            loadDocument();
        }

        private void loadDocument()
        {
            string json = JsonHelper.loadDocument(Settings.Default.ProjectID, "ProjectStatusReport");
            List<string[]> documentInfo = new List<string[]>();
            newProjectStatusReportModel = new ProjectStatusReportModel();
            currentProjectStatusReportModel = new ProjectStatusReportModel();
            if (json != "")
            {
                versionControl = JsonConvert.DeserializeObject<VersionControl<ProjectStatusReportModel>>(json);
                newProjectStatusReportModel = JsonConvert.DeserializeObject<ProjectStatusReportModel>(versionControl.getLatest(versionControl.DocumentModels));
                currentProjectStatusReportModel = JsonConvert.DeserializeObject<ProjectStatusReportModel>(versionControl.getLatest(versionControl.DocumentModels));

                txtProjectName2.Text = currentProjectStatusReportModel.ProjectName;
                txtProjectID.Text = currentProjectStatusReportModel.ProjectID;
                txtProjectManager.Text = currentProjectStatusReportModel.ProjectManager;
                txtProjectSponsor.Text = currentProjectStatusReportModel.ProjectSponsor;
                txtReportPreparedBy.Text = currentProjectStatusReportModel.ReportPreparedBy;
                txtReportPreperationDate.Text = currentProjectStatusReportModel.ReportPreparedBy;
                //txtReportingPeriod.Text = currentProjectStatusReportModel.ReportingPeriod;
                txtProjectRecipients.Text = currentProjectStatusReportModel.Recipients;

                txtProjectDescription.Text = currentProjectStatusReportModel.ProjectDescription;
                txtOverallStatus.Text = currentProjectStatusReportModel.OverallStatus;
                txtProjectSchedule.Text = currentProjectStatusReportModel.ProjectSchedule;
                txtProjectExpenses.Text = currentProjectStatusReportModel.ProjectDeliverables;
                txtProjectRisks.Text = currentProjectStatusReportModel.ProjectRisks;
                txtProjectIssues.Text = currentProjectStatusReportModel.ProjectIssues;
                txtProjectChanges.Text = currentProjectStatusReportModel.ProjectChanges;

                txtD
;
            }
            else
            {
                versionControl = new VersionControl<ProjectPlanModel>();
                versionControl.DocumentModels = new List<VersionControl<ProjectPlanModel>.DocumentModel>();
                documentInfo.Add(new string[] { "Document ID", "" });
                documentInfo.Add(new string[] { "Document Owner", "" });
                documentInfo.Add(new string[] { "Issue Date", "" });
                documentInfo.Add(new string[] { "Last Save Date", "" });
                documentInfo.Add(new string[] { "File Name", "" });
                newProjectPlanModel = new ProjectPlanModel();
                foreach (var row in documentInfo)
                {
                    documentInformation.Rows.Add(row);
                }
                documentInformation.AllowUserToAddRows = false;
            }
        }
    }
}
