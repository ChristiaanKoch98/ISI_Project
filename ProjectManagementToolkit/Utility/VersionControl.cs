using MoreLinq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectManagementToolkit.Utility
{
    class VersionControl<T>
    {
        public VersionControl(List<DocumentModel> documentModels)
        {
            DocumentModels = documentModels;
        }

        public VersionControl()
        {

        }

        public string getLatest(List<DocumentModel> documentModels)
        {
            string lastestJSON;
            if (documentModels.Count >= 1)
            {
                documentModels = sortVersionByDate(documentModels);
                DocumentModel documentModel = documentModels.Last();
                T latestObject = documentModel.DocumentObject;
                lastestJSON = JsonConvert.SerializeObject(latestObject);
                return lastestJSON;
            }
            else
            {
                return "";
            }
            
        }

        public bool isEqual(T Object1, T Object2)
        {
            string object1Json = JsonConvert.SerializeObject(Object1);
            string object2Json = JsonConvert.SerializeObject(Object2);

            if (object1Json == object2Json)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }

        public List<DocumentModel> DocumentModels { get; set; }

        public class DocumentModel
        {
            public T DocumentObject { get; set; }
            public DateTime DateModified { get; set; }
            public string VersionID { get; set; }

            public DocumentModel(T documentObject, DateTime dateModified, string versionID)
            {
                DocumentObject = documentObject;
                DateModified = dateModified;
                VersionID = versionID;
            }
        }

        static public List<DocumentModel> sortVersionByDate(List<DocumentModel> documentModels)
        {
            var sortedModels = documentModels.OrderBy(document => document.DateModified).ToList();
            return sortedModels;
        }

        static public List<DocumentModel> removeDuplicates(List<DocumentModel> documentModels)
        {
            var uniqueDocuments = documentModels.DistinctBy(document => document.VersionID).ToList();
            return uniqueDocuments;
        }

        static public string generateID()
        {
            Guid guid = Guid.NewGuid();
            string id = guid.ToString();
            return id;
        }
    }
}
