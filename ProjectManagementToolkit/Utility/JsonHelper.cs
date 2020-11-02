﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;

namespace ProjectManagementToolkit.Utility
{
    class JsonHelper
    {
        static public void saveJson(string json, string projectID, string documentName)
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

        static public string loadJson(string projectID, string documentName)
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



   
    }
}
