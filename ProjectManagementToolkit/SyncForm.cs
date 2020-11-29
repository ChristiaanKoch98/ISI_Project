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
        List<string> serverDocuments = new List<string>();

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

            List<string> documentsToSync = new List<string>();

            documentsToSync.Add("ProjectPlan");
            
        
            if (connectionSuccessful)
            {
                //Loop Through All Syncable Documents
                //VersionControl.getLatest()
                foreach (string item in documentsToSync)
                {
                    MessageBox.Show("Syncing: " + item);
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

        private async Task<bool> syncDocument(string document)
        {
            string localJsonString = JsonHelper.loadDocument(Settings.Default.ProjectID, document);
            string serverJsonString = await getServerDocument(document);
            //string serverJsonString = serverDocuments[serverDocuments.IndexOf(document)];
            string documentJson = "";
            
            if (serverJsonString == null)
            {
                MessageBox.Show("No document on server");
                serverJsonString = localJsonString;
            }

            JObject localJson = JObject.Parse(localJsonString);
            JObject serverJson = JObject.Parse(serverJsonString);
            
            //Server = Local
            //Do Nothing
            var localLatest = localJson["DocumentModels"].OrderByDescending(x => x["DateModified"]).FirstOrDefault().ToObject<JObject>();
            var serverLatest = serverJson["DocumentModels"].OrderByDescending(x => x["DateModified"]).FirstOrDefault().ToObject<JObject>();
            MessageBox.Show("LocalLatest: " + localLatest.ToString());
            var temp = localJson["DocumentModels"][0];
            
            //Server ahead of Local
            //Merge Server with Local version and save locally
            if (serverLatest["DateModified"].ToObject<DateTime>() > localLatest["DateModified"].ToObject<DateTime>())
            {
                MessageBox.Show("Server is Latest");
                serverLatest.Merge(localLatest, new JsonMergeSettings
                {
                    MergeArrayHandling = MergeArrayHandling.Union
                });

                temp["DocumentObject"] = serverLatest;
                temp["VersionID"] = generateID();
                temp["DateModified"] = DateTime.Now;

                serverJson["DocumentModels"].ToObject<JObject>().Add("DocumentObject", temp);

                documentJson = JsonConvert.SerializeObject(serverJson);
            }
            //Local ahead of Server
            //Merge Local version with server version and PUT
            else if (localLatest["DateModified"].ToObject<DateTime>() > serverLatest["DateModified"].ToObject<DateTime>())
            {
                MessageBox.Show("Local is Latest");
                localLatest.Merge(serverLatest, new JsonMergeSettings
                {
                    MergeArrayHandling = MergeArrayHandling.Union
                });

                temp["DocumentObject"] = localLatest;
                temp["VersionID"] = generateID();
                temp["DateModified"] = DateTime.Now;

                localJson["DocumentModels"].ToObject<JObject>().Add("DocumentObject", temp); ;

                documentJson = JsonConvert.SerializeObject(localJson);
            }
            //Server = Local
            //Keep same
            else if (localLatest["VersionID"].ToObject<DateTime>() == serverLatest["VersionID"].ToObject<DateTime>())
            {
                MessageBox.Show("Local = Server");
                documentJson = JsonConvert.SerializeObject(localJson);
            }
            else
            {
                MessageBox.Show("Error with DateModified");
            }

            //Save to local
            JsonHelper.saveDocument(documentJson, Settings.Default.ProjectID, document);

            //Save to server
            var body = new StringContent(documentJson, Encoding.UTF8, "application/json");

            Task<HttpResponseMessage> responseMessage = client.PutAsync("http://localhost:3000/document/" + Settings.Default.ProjectID + "/" + document, body);
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


        private async Task<string> getServerDocument(string document)
        {
            try
            {
                string uri = "http://localhost:3000/document/" + Settings.Default.ProjectID + "/" + document;
                MessageBox.Show(uri);
                HttpResponseMessage responseMessage = await client.GetAsync(uri);
                var jsonResponse = responseMessage.Content.ReadAsStringAsync().Result;
                int statusCode = responseMessage.StatusCode.GetHashCode();
                MessageBox.Show("Get Server Document (" + statusCode.ToString() + ") = " + jsonResponse.ToString());
                //Check if the collection does not exist
                if (statusCode == 404 || jsonResponse.ToString() == "[]")
                {
                    return null;
                }
                else
                {
                    return jsonResponse;
                }
            }
            catch (AggregateException)
            {
                MessageBox.Show("An unexpected server ocurred.", "Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
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
        static public string generateID()
        {
            Guid guid = Guid.NewGuid();
            string id = guid.ToString();
            return id;
        }
    }
}
