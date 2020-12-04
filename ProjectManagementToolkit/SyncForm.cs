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
            Cursor.Current = Cursors.WaitCursor;

            bool connectionSuccessful = attemptHttpConnection();

            if (!connectionSuccessful)
            {
                MessageBox.Show("Unable to connect to server.", "Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool projectExists = checkProjectConfig();

            if (!projectExists)
            {
                bool projectSynced = syncProjectConfig();
                if (projectSynced)
                {
                    MessageBox.Show("Project Synced to server");
                }
                else
                {
                    MessageBox.Show("Error syncing project with server", "Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            List<string> localDocuments = getLocalDocuments();
            List<string> serverDocuments = getServerCollections();

            

            if (localDocuments == null && serverDocuments == null)
            {
                MessageBox.Show("No documents to sync.", "Sync Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            serverDocuments.Remove("Config");

            List<string> documentsToSync;

            //documentsToSync = localDocuments.Union(serverDocuments).ToList<string>();

            //Documents server only
            if(localDocuments == null && serverDocuments != null)
            {
                documentsToSync = serverDocuments;
            }
            //Documents local only
            else if(localDocuments != null && serverDocuments == null)
            {
                documentsToSync = localDocuments;
            }
            else if(localDocuments != null && serverDocuments != null)
            {
                documentsToSync = localDocuments.Union(serverDocuments).ToList<string>();
            }
            else
            {
                MessageBox.Show("Error syncing documents.","Sync Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool[] documentsSuccesful = new bool[documentsToSync.Count];
            
            syncProgressBar.Maximum = (documentsToSync.Count);
            double progressValue = 0;
            if (connectionSuccessful)
            {

                foreach (string item in documentsToSync)
                {
                    bool syncSuccess = false;
                    try
                    {
                        syncSuccess = syncDocument(item);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("An unexpected sync error occurred.", "Sync Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    

                    documentsSuccesful[documentsToSync.IndexOf(item)] = syncSuccess;

                    progressValue++;
                    double progressPercentage = ((progressValue - 1) / syncProgressBar.Maximum) * 100;
                    syncProgressBar.Value = (int)progressValue;
                    lblProgress.Text = "Progress: " + item + " - " + Math.Round(progressPercentage,2).ToString() + "%";
                    lblProgress.Refresh();
                    syncProgressBar.Refresh();
                }
                syncProgressBar.Value = syncProgressBar.Maximum;
                lblProgress.Text = "Progress: 100%";
                MessageBox.Show("Sync completed");
            }
            else
            {
                lblProgress.Text = "Sync Failed...";
            }

            bool errorFound = false;
            string errorMessage = "Error syncing the following forms:\n";
            
            for (int i = 0; i < documentsSuccesful.Length; i++)
            {
                if (!documentsSuccesful[i])
                {
                    errorFound = true;
                    errorMessage += documentsToSync[i] + "\n";
                }
            }

            if(errorFound)
            {
                MessageBox.Show(errorMessage, "Sync Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Cursor.Current = Cursors.Default;
        }

        private bool checkProjectConfig()
        {
            try
            {
                HttpResponseMessage httpResponseMessage = client.GetAsync(Settings.Default.URI + "/project/" + Settings.Default.ProjectID).Result;
                var jsonResponse = httpResponseMessage.Content.ReadAsStringAsync().Result;

                if (jsonResponse == "[]")
                {
                    MessageBox.Show("Syncing Project for the first time.");
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (AggregateException)
            {
                return false;
            }
        }

        private bool syncProjectConfig()
        {
            List<ProjectModel> projectListModel = new List<ProjectModel>();
            string json = JsonHelper.loadProjectInfo(Settings.Default.Username);
            if (json != "")
            {
                projectListModel = JsonConvert.DeserializeObject<List<ProjectModel>>(json);
            }

            ProjectModel currentProject = new ProjectModel();
            currentProject = currentProject.getProjectModel(Settings.Default.ProjectID, projectListModel);
            var currentProjectJson = JsonConvert.SerializeObject(currentProject);


            var body = new StringContent(currentProjectJson, Encoding.UTF8, "application/json");
            try
            {
                HttpResponseMessage httpResponseMessage = client.PostAsync(Settings.Default.URI + "/project/" + Settings.Default.ProjectID, body).Result;

                int statusCode = httpResponseMessage.StatusCode.GetHashCode();

                switch (statusCode)
                {
                    case 200:
                        return true;
                    case 404:
                        return false;
                    default:
                        break;
                }
            }
            catch (AggregateException)
            {
                MessageBox.Show("An unexpected server error occurred.","Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            

            return false;
        }
       
        private bool syncDocument(string document)
        {
            string localJsonString = JsonHelper.loadDocument(Settings.Default.ProjectID, document);
            string serverJsonString = getServerDocument(document);

            string documentJson = "";
            string documentLocalJson = "";

            JObject localJson, serverJson;

            if (serverJsonString == null && localJsonString != "")
            {
                serverJsonString = localJsonString;
                localJson = JObject.Parse(localJsonString);
                serverJson = localJson;
            }
            else if (localJsonString == "" && serverJsonString != null)
            {
                localJsonString = serverJsonString;
                serverJson = JArray.Parse(serverJsonString)[0].ToObject<JObject>();
                localJson = serverJson;
            }
            else if (localJsonString != "" && serverJsonString != null)
            {
                localJson = JObject.Parse(localJsonString);
                serverJson = JArray.Parse(serverJsonString)[0].ToObject<JObject>();
            }
            else
            {
                MessageBox.Show("Error syncing " + document, "Sync Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //Get Latest Document Object from local and server
            var localLatest = localJson["DocumentModels"].OrderByDescending(x => x["DateModified"])
                                                            .FirstOrDefault().DeepClone()
                                                            .ToObject<JObject>();

            var serverLatest = serverJson["DocumentModels"].OrderByDescending(x => x["DateModified"])
                                                            .FirstOrDefault().DeepClone()
                                                            .ToObject<JObject>();
            
            //Server ahead of Local
            //Merge Server with Local version and save locally
            if (serverLatest["DateModified"].ToObject<DateTime>() > localLatest["DateModified"].ToObject<DateTime>())
            {
                JObject tempServerLatest = serverLatest.DeepClone().ToObject<JObject>();
                JObject tempLocalLatest = localLatest.DeepClone().ToObject<JObject>();
                tempLocalLatest.Merge(tempServerLatest, new JsonMergeSettings
                {
                    MergeArrayHandling = MergeArrayHandling.Union
                });
                JObject updatedDocument = new JObject();
                updatedDocument.Add("DocumentObject", tempServerLatest["DocumentObject"]);
                updatedDocument.Add("VersionID", generateID());
                updatedDocument.Add("DateModified", DateTime.Now);

                //Add document to serverJson
                JArray documentModels = serverJson["DocumentModels"].ToObject<JArray>();
                documentModels.Add(updatedDocument);

                serverJson["DocumentModels"] = documentModels;

                documentJson = JsonConvert.SerializeObject(serverJson);

                //Add document to localJson
                JArray documentLocalModels = localJson["DocumentModels"].ToObject<JArray>();
                documentLocalModels.Add(updatedDocument);

                localJson["DocumentModels"] = documentLocalModels;

                documentLocalJson = JsonConvert.SerializeObject(localJson);


            }
            //Local ahead of Server
            //Merge Local version with server version and PUT
            else if (localLatest["DateModified"].ToObject<DateTime>() > serverLatest["DateModified"].ToObject<DateTime>())
            {
                JObject tempServerLatest = serverLatest.DeepClone().ToObject<JObject>();
                JObject tempLocalLatest = localLatest.DeepClone().ToObject<JObject>();
                tempServerLatest.Merge(tempLocalLatest, new JsonMergeSettings
                {
                    MergeArrayHandling = MergeArrayHandling.Union
                });

                JObject updatedDocument = new JObject();
                updatedDocument.Add("DocumentObject", tempLocalLatest["DocumentObject"]);
                updatedDocument.Add("VersionID", generateID());
                updatedDocument.Add("DateModified", DateTime.Now);

                //Add document to serverJson
                JArray documentModels = serverJson["DocumentModels"].ToObject<JArray>();
                documentModels.Add(updatedDocument);

                serverJson["DocumentModels"] = documentModels;

                documentJson = JsonConvert.SerializeObject(serverJson);

                //Add document to localJson
                JArray documentLocalModels = localJson["DocumentModels"].ToObject<JArray>();
                documentLocalModels.Add(updatedDocument);

                localJson["DocumentModels"] = documentLocalModels;

                documentLocalJson = JsonConvert.SerializeObject(localJson);
            }
            //Server = Local
            //Keep same
            else if (localLatest["DateModified"].ToObject<DateTime>() == serverLatest["DateModified"].ToObject<DateTime>())
            {
                JArray documentModels = serverJson["DocumentModels"].ToObject<JArray>();
                documentModels.Clear();
                documentModels.Add(localLatest);

                serverJson["DocumentModels"] = documentModels;

                documentJson = JsonConvert.SerializeObject(serverJson);
                documentLocalJson = JsonConvert.SerializeObject(localJson);
            }
            else
            {
                MessageBox.Show("Error with DateModified");
            }

            //Save to local
            //Load local

            JsonHelper.saveDocument(documentLocalJson, Settings.Default.ProjectID, document);

            //Save to server
            var body = new StringContent(documentJson, Encoding.UTF8, "application/json");
            try
            {
                Task<HttpResponseMessage> responseMessage = client.PutAsync(Settings.Default.URI + "/document/" + Settings.Default.ProjectID + "/" + document, body);
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
            }
            catch (AggregateException)
            {
                MessageBox.Show("An unexpected server error ocurred.", "Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            

            return false;
        }

        private List<string> getServerCollections()
        {
            List<string> serverDocuments = new List<string>();
            try
            {
                HttpResponseMessage responseMessage = client.GetAsync(Settings.Default.URI + "/document/" + Settings.Default.ProjectID).Result;
                var jsonResponse = responseMessage.Content.ReadAsStringAsync().Result;
                JArray serverDocumentsJson = JArray.Parse(jsonResponse);
                foreach (var item in serverDocumentsJson)
                {
                    serverDocuments.Add(item["name"].ToString());
                }
                return serverDocuments;
            }
            catch (AggregateException)
            {
                
                MessageBox.Show("An unexpected server error ocurred.", "Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    localDocuments.Add(documentName);
                }
            }
            else
            {
                return null;
            }

            return localDocuments;
        }

        private string getServerDocument(string document)
        {
            try
            {
                string uri = Settings.Default.URI + "/document/" + Settings.Default.ProjectID + "/" + document;
                HttpResponseMessage responseMessage = client.GetAsync(uri).Result;
                var jsonResponse = responseMessage.Content.ReadAsStringAsync().Result;
                int statusCode = responseMessage.StatusCode.GetHashCode();
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
                MessageBox.Show("An unexpected server error ocurred.", "Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
        }

        private bool attemptHttpConnection()
        {
            try
            {
                Task<HttpResponseMessage> responseMessage = client.GetAsync(Settings.Default.URI + "/");
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
