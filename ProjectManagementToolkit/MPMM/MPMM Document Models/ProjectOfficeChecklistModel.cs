using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Models
{
    class ProjectOfficeChecklistModel
    {
        public string ProjectName { get; set; }

        public string ProjectManager { get; set; }

        public string ProjectOfficeManager { get; set; }

        public List<Questionare> Premises { get; set; }

        public List<Questionare> Equipment { get; set; }

        public List<Questionare> Roles { get; set; }

        public List<Questionare> StandardsProcesses { get; set; }

        public List<Questionare> TemplatesInitiation { get; set; }
        public List<Questionare> TemplatesPlanning { get; set; }
        public List<Questionare> TemplatesExecution { get; set; }
        public List<Questionare> TemplatesClosure { get; set; }


        public class Questionare
        {
            public string Question { get; set; }
            public bool Answer { get; set; }

            public Questionare(string question, bool answer)
            {
                this.Question = question;
                this.Answer = answer;
            }

        }
    }
}
