using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;
using ProjectManagementToolkit.Utility;
using ProjectManagementToolkit.Properties;
using Newtonsoft.Json.Linq;
using System.IO;

namespace ProjectManagementToolkit.MPMM
{
    public partial class SyncForm : Form
    {
        private static readonly HttpClient client = new HttpClient();
        

        public SyncForm()
        {
            InitializeComponent();
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            bool connectionSuccessful = attemptHttpConnection();

            if(!connectionSuccessful)
            {
                MessageBox.Show("Unable to connect to server.", "Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<string> serverDocuments;
            List<string> localDocuments;

            serverDocuments = getServerCollections();
            if(serverDocuments == null)
            {
                MessageBox.Show("An unexpected server ocurred.", "Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            localDocuments = getLocalDocuments();

            //Pull all missing documents from server.
            /*var missingLocal = new List<string>();
            foreach (var item in serverDocuments)
            {
                if(!localDocuments.Contains(item))
                {
                    missingLocal.Add(item);
                }
            }

            foreach (var item in missingLocal)
            {
                
            }*/

            if(localDocuments != null && serverDocuments != null)
            {
                //Loop Through All Syncable Documents
                //VersionControl.getLatest()
                foreach (string item in localDocuments)
                {
                    syncDocument(item);
                }
            }
            else
            {
                lblProgress.Text = "Sync Failed...";
            }
            /* Old Temp Code 
             
            List<string> documents = new List<string>();
            documents.Add("Project Plan");
            documents.Add("Business Case");
            documents.Add("Acceptance Plan");
            documents.Add("Financial Plan");
            documents.Add("Feasiblity Study");

            syncProgressBar.Maximum = (documents.Count);
            double progressValue = 0;
            foreach(string item in documents)
            {
                progressValue++;
                double progressPercentage = ((progressValue-1) / syncProgressBar.Maximum)*100;
                lblProgress.Text = "Progress: " + item +" - "+ progressPercentage.ToString()+"%";
                syncProgressBar.Value = (int)progressValue;
                lblProgress.Refresh();
                syncProgressBar.Refresh();
                Thread.Sleep(1000);
            }
            syncProgressBar.Value = syncProgressBar.Maximum;
            lblProgress.Text = "Progress: 100%";
            MessageBox.Show("Sync completed");
            this.Close();
            */
        }
        private List<string> getServerCollections()
        {
            List<string> serverDocuments = new List<string>();
            try
            {
                HttpResponseMessage responseMessage = client.GetAsync("http://localhost:3000/document/" + Settings.Default.ProjectID).Result;
                var jsonResponse = responseMessage.Content.ReadAsStringAsync().Result;
                JArray serverDocumentsJson = JArray.Parse(jsonResponse);
                foreach (var item in serverDocumentsJson)
                {
                    serverDocuments.Add(item["name"].ToString());
                    MessageBox.Show("Server " + item["name"].ToString());
                }
                return serverDocuments;
            }
            catch (AggregateException)
            {
                MessageBox.Show("An unexpected server ocurred.", "Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private List<string> getLocalDocuments()
        {
            List<string> localDocuments = new List<string>();
            string projectPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ProjectManagementToolkit", Settings.Default.ProjectID);
            
            if (Directory.Exists(projectPath))
            {
                foreach (string documentPath in Directory.GetFiles(projectPath))
                {
                    string documentName = Path.GetFileNameWithoutExtension(documentPath);
                    MessageBox.Show("Local " + documentName);
                    localDocuments.Add(documentName);
                }
            }
            else
            {
                return null;
            }

            return localDocuments;
        }

        private bool syncDocument(string document)
        {
            string documentJson = JsonHelper.loadDocument(Settings.Default.ProjectID, document);
            //Server = Local
                //Do Nothing
            //Server ahead of Local
                //Merge Server with Local version and save locally
            //Local ahead of Server
                //Merge Local version with srver version and POST


            var body = new StringContent(documentJson, Encoding.UTF8, "application/json");

            Task<HttpResponseMessage> responseMessage = client.PostAsync("http://localhost:3000/document/" + Settings.Default.ProjectID + "/" + document, body);
            HttpResponseMessage response = responseMessage.Result;
            int statusCode = response.StatusCode.GetHashCode();

            switch (statusCode)
            {
                case 200:
                    return true;
                case 404:
                    return false;
                default:
                    break;
            }

            return false;
        }

        private void getServerDocument(string document)
        {

        }

        private bool attemptHttpConnection()
        {
            try
            {
                Task<HttpResponseMessage> responseMessage = client.GetAsync("http://137.117.194.119:3000/");
                HttpResponseMessage response = responseMessage.Result;
                int statusCode = response.StatusCode.GetHashCode();

                switch (statusCode)
                {
                    case 200:
                        return true;
                    case 404:
                        return false;
                    default:
                        break;
                }

                return false;
            }
            catch (AggregateException)
            {
                MessageBox.Show("An unexpected server ocurred.", "Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        

    }
}
