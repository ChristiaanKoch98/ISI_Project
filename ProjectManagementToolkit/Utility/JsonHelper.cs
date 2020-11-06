using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;
using Newtonsoft.Json.Linq;

namespace ProjectManagementToolkit.Utility
{
    class JsonHelper
    {
        static public void saveDocument(string json, string projectID, string documentName)
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),"ProjectManagementToolkit", projectID);
            
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                //Adds full control to directory when creating the file (if access denied error occur)
                /*
                DirectoryInfo dinfo = new DirectoryInfo(path);
                DirectorySecurity dSecurity = dinfo.GetAccessControl();
                dSecurity.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.FullControl, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.NoPropagateInherit, AccessControlType.Allow));

                dinfo.SetAccessControl(dSecurity);
                */
            }

            string filename = Path.Combine(path, documentName + ".json");
            File.WriteAllText(filename, json);
        }

        static public string loadDocument(string projectID, string documentName)
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ProjectManagementToolkit", projectID);
            string filename = Path.Combine(path, documentName + ".json");
            string json = "";

            if (File.Exists(filename))
            {
                json = File.ReadAllText(filename);
            }

            return json;
        }

        static public void saveProjectInfo(string json)
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ProjectManagementToolkit", "Config");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string filename = Path.Combine(path, "ProjectInfo.json");
            File.WriteAllText(filename, json);
        }

        static public string loadProjectInfo()
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ProjectManagementToolkit", "Config");
            string filename = Path.Combine(path, "ProjectInfo.json");
            string json = "";
            if (File.Exists(filename))
            {
                json = File.ReadAllText(filename);
            }
            return json;
        }

        static public string mergeObjects(string currentJson, string newJson)
        {
            JObject currentObject = JObject.Parse(currentJson);
            JObject newObject = JObject.Parse(newJson);

            currentObject.Merge(newObject, new JsonMergeSettings
            {
                // union array values together to avoid duplicates
                MergeArrayHandling = MergeArrayHandling.Union
            });

            string mergedJson = currentObject.ToString();
            return mergedJson;
        }

   
    }
}


