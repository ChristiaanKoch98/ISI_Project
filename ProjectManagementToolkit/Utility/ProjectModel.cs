using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementToolkit.Utility
{
    public class ProjectModel
    {
        public string ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string ProjectSponsor { get; set; }
        public string ProjectReviewGroup { get; set; }
        public string ProjectManager { get; set; }
        public string QualityManager { get; set; }
        public string ProcurementManager { get; set; }
        public string CommunicationsManager { get; set; }
        public string OfficeManager { get; set; }
        public DateTime LastDateTimeSynced { get; set; }

        public static ProjectModel getProjectModel(string ProjectID, List<ProjectModel> projectModels)
        {
            ProjectModel projectModel = new ProjectModel();
            projectModel = projectModels.Find(project => project.ProjectID == ProjectID);
            return projectModel;
        }

        public List<ProjectModel> updateProjectList(List<ProjectModel> projectList, ProjectModel projectModel)
        {
            int index = projectList.FindIndex(project => project.ProjectID == projectModel.ProjectID);
            projectList[index] = projectModel;
            return projectList;
        }
        public string generateID()
        {
            Guid guid = Guid.NewGuid();
            string id = guid.ToString();
            return id;
        }
    }
}
