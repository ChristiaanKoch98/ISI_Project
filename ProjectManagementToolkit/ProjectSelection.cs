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

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Forms
{
    public partial class ProjectSelection : Form
    {
        private static readonly HttpClient client = new HttpClient();
        public ProjectSelection()
        {
            InitializeComponent();
            
        }

        private void tabPageExistingProjects_Click(object sender, EventArgs e)
        {

        }

        private void btnSelectProject_Click(object sender, EventArgs e)
        {
            string projectName = lstboxProject.SelectedItem.ToString();

            MainForm mainForm = new MainForm();
            this.Visible = false;
            mainForm.Show();
        }

        private void btnCreateProject_Click(object sender, EventArgs e)
        {
            string projectID = generateNewProjectID();
            ProjectModel newProject = new ProjectModel();

            newProject.ProjectID = projectID;
            newProject.ProjectName = txtProjectName.Text;
            newProject.ProjectSponsor = txtProjectSponsor.Text;
            newProject.ProjectReviewGroup = txtProjectReviewGroup.Text;
            newProject.ProjectManager = txtProjectManager.Text;
            newProject.QualityManager = txtQualityManager.Text;
            newProject.ProcurementManager = txtProcurementManager.Text;
            newProject.CommunicationsManager = txtCommunicationsManager.Text;
            newProject.OfficeManager = txtProjectOfficeManager.Text;
            

            string projectJSON = projectJsonSerialize(newProject);
            createNewProject(projectJSON);
            System.Diagnostics.Debug.WriteLine(projectJSON);
            Properties.Settings.Default.ProjectID = projectID;
            lstboxProject.Items.Clear();
            attemptHttpConnection();
        }

        private string generateNewProjectID()
        {
            System.Diagnostics.Debug.WriteLine("Generating new Project ID");
            return "Project ID TEST 001";
        }

        private void createNewProject(string newProjectJsonString)
        {
            try
            {
                var content = new StringContent(newProjectJsonString, Encoding.UTF8, "application/json");

                var response = client.PostAsync("http://137.117.194.119:3000/project", content).Result;

                loadAllProjects(response.ToString());
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.StackTrace);
                //throw;
            }
        }

        private string projectJsonSerialize(ProjectModel project)
        {
            return JsonConvert.SerializeObject(project);
        }

        private void ProjectSelection_Load(object sender, EventArgs e)
        {
            attemptHttpConnection();
        }

        private void attemptHttpConnection()
        {
            try
            {
                string projectsResponse = client.GetStringAsync("http://137.117.194.119:3000/project").Result;

                loadAllProjects(projectsResponse);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.StackTrace);
                //throw;
            }
        }

        private void loadAllProjects(string projectsJSON)
        {
            System.Diagnostics.Debug.WriteLine(projectsJSON);
            JArray json = JArray.Parse(projectsJSON);
            List<ProjectModel> projects = new List<ProjectModel>();

            for (int i = 0; i < json.Count; i++)
            {
                projects.Add(JsonConvert.DeserializeObject<ProjectModel>(json[i].ToString()));
                lstboxProject.Items.Add(projects[i].ProjectID + " - " +projects[i].ProjectName);
            }
        }
    }
}
