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
            //MainForm main = new MainForm();
            //this.Visible = false;
            //main.Show();
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
                //Object newProjectJson = JObject.Parse(newProjectJsonString);
                var content = new StringContent(newProjectJsonString, Encoding.UTF8, "application/json");

                var response = client.PostAsync("http://localhost:3000/project", content).Result;

                loadAllProjects(response.ToString());
                /*JObject newProjectJson = JObject.Parse(newProjectJsonString);
                
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:3000/project");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                using (Stream stream = httpWebRequest.GetRequestStream() )
                {
                    stream.Write()
                }*/

                /*
                Stream stream = httpWebRequest.GetRequestStream();

                using (var streamWriter = new StreamWriter(stream))
                {
                    streamWriter.Write(newProjectJsonString);
                }
                */

                /*Stream stream = httpWebResponse.GetResponseStream();
                string projectsResponse = "";
                using (var streamReader = new StreamReader(stream))
                {
                    var result = streamReader.ReadToEnd();
                    System.Diagnostics.Debug.WriteLine("Stream reader result");
                    System.Diagnostics.Debug.WriteLine(result);
                    projectsResponse = result;
                }

                loadAllProjects(projectsResponse);*/
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
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:3000/project");
                httpWebRequest.ContentType = "application/json";
                //httpWebRequest.Method = "GET";
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                Stream stream = httpWebResponse.GetResponseStream();
                string projectsResponse = "";
                using (var streamReader = new StreamReader(stream))
                {
                    var result = streamReader.ReadToEnd();
                    System.Diagnostics.Debug.WriteLine("Stream reader result");
                    System.Diagnostics.Debug.WriteLine(result);
                    projectsResponse = result;
                }

                loadAllProjects(projectsResponse);
            }
            catch (Exception e)
            {

                throw;
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
            }

            //foreach (var item in json)
            //{
            //    projects.Add(JsonConvert.DeserializeObject<ProjectModel>(projectsJSON));
            //}

            //ProjectModel loadedProject = JsonConvert.DeserializeObject<ProjectModel>(projectsJSON);

            foreach (var item in projects)
            {
                string projectName = item.ProjectName;

                System.Diagnostics.Debug.WriteLine(projectName);

                lstboxProject.Items.Add(projectName);
            }
            
            
        }
    }
}
