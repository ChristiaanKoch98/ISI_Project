using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Models
{
    class CommunicationRegisterModel
    {
        public List<CommunicationEntry> CommunicationEntries { get; set; }
        public class CommunicationEntry
        {
            public int ID { get; set; }
            public string Status { get; set; } = "";
            public string DateApproved { get; set; } = "";
            public string ApprovedBy { get; set; } = "";
            public string DateSent { get; set; } = "";
            public string SendBy { get; set; } = "";
            public string SendTo { get; set; } = "";
            public string Type { get; set; } = "";
            public string Message { get; set; } = "";
            public string FileLocation { get; set; } = "";
            public string FeedBack { get; set; } = "";
        }
    }
}
