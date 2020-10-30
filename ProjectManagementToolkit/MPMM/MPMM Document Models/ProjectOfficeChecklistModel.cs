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

        /*Premesis*/

        public Boolean PremisesProjectOfficeDocumented { get; set; }

        public Boolean PremisesProjectOfficeProcured { get; set; }

        public Boolean PremisesPracticalLocation { get; set; }

        public Boolean PremisesRequiredDocumted { get; set; }

        public Boolean PremisesFormalContract { get; set; }

        public Boolean PremisesSufficientSpace { get; set; }

        public Boolean PremisesContinueAvailible { get; set; }

        public Boolean PremisesAdditionalFitOut { get; set; }

        public Boolean PremisesOnSiteFacilities { get; set; }

        /*Equipement*/

        public Boolean EquipmentRequiredOffice { get; set; }

        public Boolean EquipmentMaintananceCOntracts { get; set; }

        public Boolean EquipmentSpareEquipment { get; set; }

        public Boolean EquipmentOfficeFunctioning { get; set; }

        public Boolean EquipmentSufficientCommunication { get; set; }

        public Boolean EquipmentVideoCOnferensing { get; set; }

        public Boolean EquipmentFunctioningAsRequired { get; set; }

        /*Roles*/

        public Boolean RolesAppointedProjectSponsor { get; set; }
        public Boolean RolesAppointedProjectManager { get; set; }
        public Boolean RolesAppointedProjectOfficeManager { get; set; }
        public Boolean RolesAppointedProcurementManager { get; set; }
        public Boolean RolesAppointedCommunicationsManager { get; set; }
        public Boolean RolesAppointedQualityManager { get; set; }
        public Boolean RolesAppointedRiskManager { get; set; }
        public Boolean RolesAppointedTeamLeader { get; set; }
        public Boolean RolesJobDescriptionsDocumented { get; set; }
        public Boolean RolesJobDescriptionsResponsibilities { get; set; }
        public Boolean RolesSkilledPeopleAppointed { get; set; }

        /*Standards and Processes*/

        //Standards
        public Boolean StandardsIndustyStandards { get; set; }
        public Boolean StandardsHealthAndSafety { get; set; }
        public Boolean StandardsProjectPlanning { get; set; }
        public Boolean StandardsPMI { get; set; }

        //Processes
        public Boolean ProcessesTimeManagement { get; set; }
        public Boolean ProcessesCostManagement { get; set; }
        public Boolean ProcessesQualityManagement { get; set; }
        public Boolean ProcessesChangeManagement { get; set; }
        public Boolean ProcessesRiskManagement { get; set; }
        public Boolean ProcessesIssueManagement { get; set; }
        public Boolean ProcessesProcurementManagement { get; set; }
        public Boolean ProcessesAcceptanceManagement { get; set; }
        public Boolean ProcessesCommunicationsManagement { get; set; }

        /*Templates*/

        //Initiation
        public Boolean TemplatesInitiationBusinessCase { get; set; }
        public Boolean TemplatesInitiationFeasibilityStudy { get; set; }
        public Boolean TemplatesInitiationTermsOfReference { get; set; }
        public Boolean TemplatesInitiationJobDescription { get; set; }
        public Boolean TemplatesInitiationStageGate { get; set; }

        //Planning
        public Boolean TemplatesPlanningProjectPlan { get; set; }
        public Boolean TemplatesPlanningResourcePlan { get; set; }
        public Boolean TemplatesPlanningFinancialPlan { get; set; }
        public Boolean TemplatesPlanningQualityPlan { get; set; }
        public Boolean TemplatesPlanningRiskPlan { get; set; }
        public Boolean TemplatesPlanningAcceptancePlan { get; set; }
        public Boolean TemplatesPlanningCommunicationsPlan { get; set; }
        public Boolean TemplatesPlanningProcurementPlan { get; set; }
        public Boolean TemplatesPlanningSupplierPlan { get; set; }
        public Boolean TemplatesPlanningTenderPlan { get; set; }

        //Execution
        public Boolean TemplatesExecutionTimesheet { get; set; }
        public Boolean TemplatesExecutionExpense { get; set; }
        public Boolean TemplatesExecutionQuality { get; set; }
        public Boolean TemplatesExecutionChange { get; set; }
        public Boolean TemplatesExecutionRisk { get; set; }
        public Boolean TemplatesExecutionIssue { get; set; }
        public Boolean TemplatesExecutionPurchase { get; set; }
        public Boolean TemplatesExecutionProcurement { get; set; }
        public Boolean TemplatesExecutionProject { get; set; }
        public Boolean TemplatesExecutionCommunication { get; set; }
        public Boolean TemplatesExecutionAcceptance { get; set; }

        //Closure
        public Boolean TemplatesClosureProjectReport { get; set; }
        public Boolean TemplatesClosurePostReview { get; set; }

        /*Services*/

        //TimeManagement
        public Boolean ServicesTimeMonitoring { get; set; }
        public Boolean ServicesTimeProjectPlan { get; set; }
        public Boolean ServicesTimeTimesheet { get; set; }

        //Cost Management
        public Boolean ServicesCostMonitoring { get; set; }
        public Boolean ServicesCostProjectPlan { get; set; }
        public Boolean ServicesCostExpense { get; set; }

        //Quality Management
        public Boolean ServicesQualityAssurance { get; set; }
        public Boolean ServicesQualityControl { get; set; }
        public Boolean ServicesQualityDeliverables { get; set; }

        //Change Management
        public Boolean ServicesChangeRequests { get; set; }
        public Boolean ServicesChangeSheduling { get; set; }
        public Boolean ServicesChangeKeeping { get; set; }

        //Risk Management
        public Boolean ServicesRiskForms { get; set; }
        public Boolean ServicesRiskSheduling { get; set; }
        public Boolean ServicesRiskKeeping { get; set; }

        //Issue Management
        public Boolean ServicesIssueForms { get; set; }
        public Boolean ServicesIssueScheduling { get; set; }
        public Boolean ServicesIssueKeeping { get; set; }


        //Procurement Management
        public Boolean ServicesProcurementPurchase { get; set; }
        public Boolean ServicesProcurementGoodsAndServices { get; set; }
        public Boolean ServicesProcurementKeeping { get; set; }
        public Boolean ServicesProcurementPayement { get; set; }
        public Boolean ServicesProcurementManaging { get; set; }

        //Acceptance Management
        public Boolean ServicesAcceptanceInitiating { get; set; }
        public Boolean ServicesAcceptanceDocumenting { get; set; }
        public Boolean ServicesAcceptanceGainingFinalAcceptance { get; set; }
        public Boolean ServicesAcceptanceKeeping { get; set; }

        //Communications Management
        public Boolean ServicesCommunicationsUndertaking { get; set; }
        public Boolean ServicesCommunicationsCreating { get; set; }
        public Boolean ServicesCommunicationsDistributing { get; set; }
        public Boolean ServicesCommunicationsKeeping { get; set; }

        //Stage Gate Reviews
        public Boolean ServicesStageGateIdentifying { get; set; }
        public Boolean ServicesStageGateOrganizing { get; set; }

        //Auditing and Compliance
        public Boolean ServicesAuditingEnsuringConforms { get; set; }
        public Boolean ServicesAuditingInforming { get; set; }

        //Supporting Staff
        public Boolean ServicesSupportingAssisting { get; set; }
        public Boolean ServicesSupportingAdvising{ get; set; }
        public Boolean ServicesSupportingPaying { get; set; }

        //Providing tools
        public Boolean ServicesProvidingProjectManagement { get; set; }
        public Boolean ServicesProvidingToolsForMonitoring { get; set; }
        public Boolean ServicesProvidingTraining { get; set; }

        //Performing administration  
        public Boolean ServicesPerformingAdministration { get; set; }
        public Boolean ServicesPerformingPurchasing { get; set; }

        //Filing documents
        public Boolean ServicesFilingLibrary { get; set; }
        public Boolean ServicesFilingImplementing { get; set; }

        //Undertaking closue reviews
        public Boolean ServicesClosureOrganizing { get; set; }
        public Boolean ServicesComminicating { get; set; }
    }
}
