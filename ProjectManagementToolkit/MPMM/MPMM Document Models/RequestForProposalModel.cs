using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Models
{
    class RequestForProposalModel
    {
        public string projectName { get; set; }
        public List<DocumentInformation> documentInformations { get; set; }
        public List<DocumentHistory> documentHistories { get; set; }
        public List<DocumentApproval> documentApprovals { get; set; }
        //Introduction Tab
        public string introductionDescription { get; set; }
        public string introductionOverview { get; set; }
        public string introductionPurpose { get; set; }
        public string introductionAcknowledgement { get; set; }
        public string introductionRecipients { get; set; }
        public string introductionProcess { get; set; }
        public string introductionRules { get; set; }
        public string introductionQuestions { get; set; }
        
        //Company Tab
        public string companyDescription { get; set; }
        public string companyVisionObjectivesSizeLocation { get; set; }
        public string companyTypeAndNumberOfCustomers { get; set; }
        public string companyMarketSegment { get; set; }
        public string companyKnowledgeOfIndustryAndExpertise { get; set; }

        //Solution Tab
        public string solutionDescription { get; set; }

        public List<Solution> solutions { get; set; }

        //Implementation
        public string implementationDescription { get; set; }

        //Other Information
        public string otherInformationDescription { get; set; }
        public string otherInformationConfidentiality { get; set; }
        public string otherInformationDocumentation { get; set; }

        public class DocumentInformation
        {
            public string type { get; set; }
            public string information { get; set; }

        }

        public class DocumentHistory
        {
            public string version { get; set; }
            public string issueDate { get; set; }
            public string changes { get; set; }
        }
        
        public class DocumentApproval
        {
            public string role { get; set; }
            public string name { get; set; }
            public string signature { get; set; }
            public string approvalDate { get; set; }

        }

        public class Solution
        {
            public string solutionAndComponents { get; set; }
            public string quantity { get; set; }
            public string price { get; set; }
        }
        
    }
}
