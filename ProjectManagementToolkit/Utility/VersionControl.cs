using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementToolkit.Utility
{
    class VersionControl
    {
        public VersionControl(List<DocumentModel> documentModels)
        {
            DocumentModels = documentModels;
        }

        public VersionControl()
        {
        }

        public List<DocumentModel> DocumentModels { get; set; }
        public class DocumentModel
        {
            public object DocumentObject { get; set; }
            public DateTime DateModified { get; set; }
            public string VersionID { get; set; }

            public DocumentModel(object documentObject, DateTime dateModified, string versionID)
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
    }
}
