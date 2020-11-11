using ProjectManagementToolkit.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Web;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using ProjectManagementToolkit.Properties;

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Forms
{
    public partial class ProjectSelection : Form
    {
        List<ProjectModel> projectListModel = new List<ProjectModel>();
       
        public ProjectSelection()
        {
            InitializeComponent();
        }

        private void btnSelectProject_Click(object sender, EventArgs e)
        {
            if (lstboxProject.SelectedIndex != -1)
            {
                int index = lstboxProject.SelectedIndex;
                Settings.Default.ProjectID = projectListModel[index].ProjectID;
                MainForm mainForm = new MainForm();
                mainForm.WindowState = FormWindowState.Maximized;
                mainForm.Show();
                this.Visible = false;
            }
        }

        private void btnCreateProject_Click(object sender, EventArgs e)
        {
            ProjectModel newProject = new ProjectModel();
            string projectID = newProject.generateID();
            Settings.Default.ProjectID = projectID;

            newProject.ProjectID = projectID;
            newProject.ProjectName = txtProjectName.Text;
            newProject.ProjectSponsor = txtProjectSponsor.Text;
            newProject.ProjectReviewGroup = txtProjectReviewGroup.Text;
            newProject.ProjectManager = txtProjectManager.Text;
            newProject.QualityManager = txtQualityManager.Text;
            newProject.ProcurementManager = txtProcurementManager.Text;
            newProject.CommunicationsManager = txtCommunicationsManager.Text;
            newProject.OfficeManager = txtProjectOfficeManager.Text;

            projectListModel.Add(newProject);
            Settings.Default.ProjectID = newProject.ProjectID;
            string json = JsonConvert.SerializeObject(projectListModel);
            JsonHelper.saveProjectInfo(json,Settings.Default.Username);
            MainForm mainForm = new MainForm();
            mainForm.WindowState = FormWindowState.Maximized;
            mainForm.Show();
            this.Visible = false;

        }

        private void ProjectSelection_Load(object sender, EventArgs e)
        {
            string json = JsonHelper.loadProjectInfo(Settings.Default.Username);
            if (json != "")
            {
                projectListModel = JsonConvert.DeserializeObject<List<ProjectModel>>(json);
            }

            foreach (var project in projectListModel)
            {
                lstboxProject.Items.Add(project.ProjectName);
            }
        }
    }
}
