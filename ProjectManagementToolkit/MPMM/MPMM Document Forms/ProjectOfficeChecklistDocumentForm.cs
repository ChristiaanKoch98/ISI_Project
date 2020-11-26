using ProjectManagementToolkit.MPMM.MPMM_Document_Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Runtime.InteropServices;
using ProjectManagementToolkit.Utility;
using ProjectManagementToolkit.Properties;

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Forms
{
    public partial class ProjectOfficeChecklistDocumentForm : Form
    {
        VersionControl<ProjectOfficeChecklistModel> versionControl;
        ProjectOfficeChecklistModel newProjectOfficeChecklistModel;
        ProjectOfficeChecklistModel currentProjectOfficeChecklistModel;

        public ProjectOfficeChecklistDocumentForm()
        {
            InitializeComponent();
        }

        private void ProjectOfficeChecklistDocumentForm_Load(object sender, EventArgs e)
        {
            loadDocument();
        }

        private void btnSaveProjectDetails_Click(object sender, EventArgs e)
        {
            saveDocument();
        }

        public void saveDocument()
        {
            //Premises
            newProjectOfficeChecklistModel.PremisesProjectOfficeDocumented = checkBoxProjectOfficeRequirements.Checked;
            newProjectOfficeChecklistModel.PremisesProjectOfficeProcured = checkBoxProjectOfficePremisesProcured.Checked;
            newProjectOfficeChecklistModel.PremisesPracticalLocation = checkBoxPremisesPracticalLocation.Checked;
            newProjectOfficeChecklistModel.PremisesRequiredDocumted = checkBoxPremisesMeetRequirements.Checked;
            newProjectOfficeChecklistModel.PremisesFormalContract = checkBoxFormalContract.Checked;
            newProjectOfficeChecklistModel.PremisesSufficientSpace = checkBoxPremisesProvideSufficient.Checked;
            newProjectOfficeChecklistModel.PremisesContinueAvailible = checkBoxPremisesContinueAvaliable.Checked;
            newProjectOfficeChecklistModel.PremisesAdditionalFitOut = checkBoxAdditionalFitOut.Checked;
            newProjectOfficeChecklistModel.PremisesOnSiteFacilities = checkBoxOnSiteFacilities.Checked;

            //Equipment
            newProjectOfficeChecklistModel.EquipmentRequiredOffice = checkBoxProjectTeamRequiredEquipment.Checked;
            newProjectOfficeChecklistModel.EquipmentMaintananceCOntracts = checkBoxMaintanenceContractsInPlace.Checked;
            newProjectOfficeChecklistModel.EquipmentSpareEquipment = checkBoxSpareEquipmentAvaliable.Checked;
            newProjectOfficeChecklistModel.EquipmentOfficeFunctioning = checkBoxOfficeEquipmentFunctioning.Checked;
            newProjectOfficeChecklistModel.EquipmentSufficientCommunication = checkBoxSufficientCommunicationsTechnologies.Checked;
            newProjectOfficeChecklistModel.EquipmentVideoCOnferensing = checkBoxVideoConferencingAvaliable.Checked;
            newProjectOfficeChecklistModel.EquipmentFunctioningAsRequired = checkBoxEquipmentFunctioningAsRequired.Checked;

            //Roles
            newProjectOfficeChecklistModel.RolesAppointedProjectSponsor = checkBoxProjectSponser.Checked;
            newProjectOfficeChecklistModel.RolesAppointedProjectManager = checkBoxProjectManager.Checked;
            newProjectOfficeChecklistModel.RolesAppointedProjectOfficeManager = checkBoxProjectOfficeManager.Checked;
            newProjectOfficeChecklistModel.RolesAppointedProcurementManager = checkBoxProcurementManager.Checked;
            newProjectOfficeChecklistModel.RolesAppointedCommunicationsManager = checkBoxCommManager.Checked;
            newProjectOfficeChecklistModel.RolesAppointedQualityManager = checkBoxQualityManager.Checked;
            newProjectOfficeChecklistModel.RolesAppointedRiskManager = checkBoxRiskManager.Checked;
            newProjectOfficeChecklistModel.RolesAppointedTeamLeader = checkBoxTeamLeader.Checked;
            newProjectOfficeChecklistModel.RolesJobDescriptionsDocumented = checkBoxJobDescriptionDocumented.Checked;
            newProjectOfficeChecklistModel.RolesJobDescriptionsResponsibilities = checkBoxJobDescriptionDescribeResponsibilities.Checked;
            newProjectOfficeChecklistModel.RolesSkilledPeopleAppointed = checkBoxSuitablySkilledPeopleAppointed.Checked;

            //Standards and Processes
            newProjectOfficeChecklistModel.StandardsIndustyStandards = checkBoxISO.Checked;
            newProjectOfficeChecklistModel.StandardsHealthAndSafety = checkBoxHealthSafetyStandard.Checked;
            newProjectOfficeChecklistModel.StandardsProjectPlanning = checkBoxProjectPlanning.Checked;
            newProjectOfficeChecklistModel.StandardsPMI = checkBoxPMBOK.Checked;
            newProjectOfficeChecklistModel.StandardSuitableProjManMethod = checkBoxSuitableProjectManagementMethodology.Checked;

            newProjectOfficeChecklistModel.ProcessesTimeManagement = checkBoxTimeMP.Checked;
            newProjectOfficeChecklistModel.ProcessesCostManagement = checkBoxCostMP.Checked;
            newProjectOfficeChecklistModel.ProcessesQualityManagement = checkBoxQualityMP.Checked;
            newProjectOfficeChecklistModel.ProcessesChangeManagement = checkBoxChangeMP.Checked;
            newProjectOfficeChecklistModel.ProcessesRiskManagement = checkBoxRiskMP.Checked;
            newProjectOfficeChecklistModel.ProcessesIssueManagement = checkBoxIssueMP.Checked;
            newProjectOfficeChecklistModel.ProcessesProcurementManagement = checkBoxProcurementMP.Checked;
            newProjectOfficeChecklistModel.ProcessesAcceptanceManagement = checkBoxAcceptanceMP.Checked;
            newProjectOfficeChecklistModel.ProcessesCommunicationsManagement = checkBoxCommunicationsMP.Checked;

            //Templates
            newProjectOfficeChecklistModel.TemplatesInitiationBusinessCase = checkBoxBusinessCase.Checked;
            newProjectOfficeChecklistModel.TemplatesInitiationFeasibilityStudy = checkBoxFeasibilityStudy.Checked;
            newProjectOfficeChecklistModel.TemplatesInitiationTermsOfReference = checkBoxTermsofReference.Checked;
            newProjectOfficeChecklistModel.TemplatesInitiationJobDescription = checkBoxJobDescription.Checked;
            newProjectOfficeChecklistModel.TemplatesInitiationStageGate = checkBoxStageGateReviewForm.Checked;

            newProjectOfficeChecklistModel.TemplatesPlanningProjectPlan = checkBoxProjectPlan.Checked;
            newProjectOfficeChecklistModel.TemplatesPlanningResourcePlan = checkBoxResourcePlan.Checked;
            newProjectOfficeChecklistModel.TemplatesPlanningFinancialPlan = checkBoxFinancialPlan.Checked;
            newProjectOfficeChecklistModel.TemplatesPlanningQualityPlan = checkBoxQualityPlan.Checked;
            newProjectOfficeChecklistModel.TemplatesPlanningRiskPlan = checkBoxTemplatesRiskPlan.Checked;
            newProjectOfficeChecklistModel.TemplatesPlanningAcceptancePlan = checkBoxAcceptancePlan.Checked;
            newProjectOfficeChecklistModel.TemplatesPlanningCommunicationsPlan = checkBoxCommunicationsPlan.Checked;
            newProjectOfficeChecklistModel.TemplatesPlanningProcurementPlan = checkBoxProcurementPlan.Checked;
            newProjectOfficeChecklistModel.TemplatesPlanningSupplierPlan = checkBoxSupplierContract.Checked;
            newProjectOfficeChecklistModel.TemplatesPlanningTenderPlan = checkBoxTenderRegister.Checked;

            newProjectOfficeChecklistModel.TemplatesExecutionTimesheet = checkBoxTFTR.Checked;
            newProjectOfficeChecklistModel.TemplatesExecutionExpense = checkBoxEFER.Checked;
            newProjectOfficeChecklistModel.TemplatesExecutionQuality = checkBoxQFDR.Checked;
            newProjectOfficeChecklistModel.TemplatesExecutionChange = checkBoxCFCR.Checked;
            newProjectOfficeChecklistModel.TemplatesExecutionRisk = checkBoxRFRR.Checked;
            newProjectOfficeChecklistModel.TemplatesExecutionIssue = checkBoxIFIR.Checked;
            newProjectOfficeChecklistModel.TemplatesExecutionPurchase = checkBoxPOF.Checked;
            newProjectOfficeChecklistModel.TemplatesExecutionProcurement = checkBoxPR.Checked;
            newProjectOfficeChecklistModel.TemplatesExecutionProject = checkBoxPSR.Checked;
            newProjectOfficeChecklistModel.TemplatesExecutionCommunication = checkBoxCR.Checked;
            newProjectOfficeChecklistModel.TemplatesExecutionAcceptanceForm = checkBoxAF.Checked;
            newProjectOfficeChecklistModel.TemplatesExecutionAcceptanceRegister = checkBoxAR.Checked;

            newProjectOfficeChecklistModel.TemplatesClosureProjectReport = checkBoxProjectClosureReport.Checked;
            newProjectOfficeChecklistModel.TemplatesClosurePostReview = checkBoxPostImplementationReview.Checked;

            //Services(Time, Cost, Quality,Change, Risk,Issue)
            newProjectOfficeChecklistModel.ServicesTimeMonitoring = checkBoxTM1.Checked;
            newProjectOfficeChecklistModel.ServicesTimeProjectPlan = checkBoxTM2.Checked;
            newProjectOfficeChecklistModel.ServicesTimeTimesheet = checkBoxTM3.Checked;

            newProjectOfficeChecklistModel.ServicesCostMonitoring = checkBoxCM1.Checked;
            newProjectOfficeChecklistModel.ServicesCostProjectPlan = checkBoxCM2.Checked;
            newProjectOfficeChecklistModel.ServicesCostExpense = checkBoxCM3.Checked;

            newProjectOfficeChecklistModel.ServicesQualityAssurance = checkBoxQM1.Checked;
            newProjectOfficeChecklistModel.ServicesQualityControl = checkBoxQM2.Checked;
            newProjectOfficeChecklistModel.ServicesQualityDeliverables = checkBoxQM3.Checked;

            newProjectOfficeChecklistModel.ServicesChangeRequests = checkBoxChangeM1.Checked;
            newProjectOfficeChecklistModel.ServicesChangeSheduling = checkBoxChangeM2.Checked;
            newProjectOfficeChecklistModel.ServicesChangeKeeping = checkBoxChangeM3.Checked;

            newProjectOfficeChecklistModel.ServicesRiskForms = checkBoxRM1.Checked;
            newProjectOfficeChecklistModel.ServicesRiskSheduling = checkBoxRM2.Checked;
            newProjectOfficeChecklistModel.ServicesRiskKeeping = checkBoxRM3.Checked;

            newProjectOfficeChecklistModel.ServicesIssueForms = checkBoxIM1.Checked;
            newProjectOfficeChecklistModel.ServicesIssueScheduling = checkBoxIM2.Checked;
            newProjectOfficeChecklistModel.ServicesIssueKeeping = checkBoxIM3.Checked;

            //Services(Procuremenm, Acceptance, communication)
            newProjectOfficeChecklistModel.ServicesProcurementPurchase = checkBoxPM1.Checked;
            newProjectOfficeChecklistModel.ServicesProcurementGoodsAndServices = checkBoxPM2.Checked;
            newProjectOfficeChecklistModel.ServicesProcurementKeeping = checkBoxPM3.Checked;
            newProjectOfficeChecklistModel.ServicesProcurementPayement = checkBoxPM4.Checked;
            newProjectOfficeChecklistModel.ServicesProcurementManaging = checkBoxPM5.Checked;

            newProjectOfficeChecklistModel.ServicesAcceptanceInitiating = checkBoxAM1.Checked;
            newProjectOfficeChecklistModel.ServicesAcceptanceDocumenting = checkBoxAM2.Checked;
            newProjectOfficeChecklistModel.ServicesAcceptanceGainingFinalAcceptance = checkBoxAM3.Checked;
            newProjectOfficeChecklistModel.ServicesAcceptanceKeeping = checkBoxAM4.Checked;

            newProjectOfficeChecklistModel.ServicesCommunicationsUndertaking = checkBoxCommsM1.Checked;
            newProjectOfficeChecklistModel.ServicesCommunicationsCreating = checkBoxCommsM2.Checked;
            newProjectOfficeChecklistModel.ServicesCommunicationsDistributing = checkBoxCommsM3.Checked;
            newProjectOfficeChecklistModel.ServicesCommunicationsKeeping = checkBoxCommsM4.Checked;

            //Service(StageGAte, Auditing, Supporting, Providing)
            newProjectOfficeChecklistModel.ServicesStageGateIdentifying = checkBoxSGR1.Checked;
            newProjectOfficeChecklistModel.ServicesStageGateOrganizing = checkBoxSGR2.Checked;

            newProjectOfficeChecklistModel.ServicesAuditingEnsuringConforms = checkBoxAandC1.Checked;
            newProjectOfficeChecklistModel.ServicesAuditingInforming = checkBoxAandC2.Checked;

            newProjectOfficeChecklistModel.ServicesSupportingAssisting = checkBoxSS1.Checked;
            newProjectOfficeChecklistModel.ServicesSupportingAdvising = checkBoxSS2.Checked;
            newProjectOfficeChecklistModel.ServicesSupportingPaying = checkBoxSS3.Checked;

            newProjectOfficeChecklistModel.ServicesProvidingProjectManagement = checkBoxPT1.Checked;
            newProjectOfficeChecklistModel.ServicesProvidingToolsForMonitoring = checkBoxPT2.Checked;
            newProjectOfficeChecklistModel.ServicesProvidingTraining = checkBoxPT3.Checked;

            //Service(Filling, Performing, Undertaking)
            newProjectOfficeChecklistModel.ServicesPerformingAdministration = checkBoxFD1.Checked;
            newProjectOfficeChecklistModel.ServicesPerformingPurchasing = checkBoxFD2.Checked;

            newProjectOfficeChecklistModel.ServicesFilingLibrary = checkBoxPA1.Checked;
            newProjectOfficeChecklistModel.ServicesFilingImplementing = checkBoxPA2.Checked;

            newProjectOfficeChecklistModel.ServicesClosureOrganizing = checkBoxUCR1.Checked;
            newProjectOfficeChecklistModel.ServicesComminicating = checkBoxUCR2.Checked;

            List<VersionControl<ProjectOfficeChecklistModel>.DocumentModel> documentModels = versionControl.DocumentModels;


            if (!versionControl.isEqual(currentProjectOfficeChecklistModel, newProjectOfficeChecklistModel))
            {
                VersionControl<ProjectOfficeChecklistModel>.DocumentModel documentModel = new VersionControl<ProjectOfficeChecklistModel>.DocumentModel(newProjectOfficeChecklistModel, DateTime.Now, VersionControl<ProjectModel>.generateID());

                documentModels.Add(documentModel);

                versionControl.DocumentModels = documentModels;

                string json = JsonConvert.SerializeObject(versionControl);
                JsonHelper.saveDocument(json, Settings.Default.ProjectID, "ProjectOfficeChecklist");
                MessageBox.Show("Project Office Checklist saved successfully", "save", MessageBoxButtons.OK);
            }
        }


        public void loadDocument()
        {
            string json = JsonHelper.loadDocument(Settings.Default.ProjectID, "ProjectOfficeChecklist");
            List<string[]> documentInfo = new List<string[]>();
            newProjectOfficeChecklistModel = new ProjectOfficeChecklistModel();
            currentProjectOfficeChecklistModel = new ProjectOfficeChecklistModel();
            if (json != "")
            {
                versionControl = JsonConvert.DeserializeObject<VersionControl<ProjectOfficeChecklistModel>>(json);
                newProjectOfficeChecklistModel = JsonConvert.DeserializeObject<ProjectOfficeChecklistModel>(versionControl.getLatest(versionControl.DocumentModels));
                currentProjectOfficeChecklistModel = JsonConvert.DeserializeObject<ProjectOfficeChecklistModel>(versionControl.getLatest(versionControl.DocumentModels));

                //Premises
                checkBoxProjectOfficeRequirements.Checked = currentProjectOfficeChecklistModel.PremisesProjectOfficeDocumented;
                checkBoxProjectOfficePremisesProcured.Checked = currentProjectOfficeChecklistModel.PremisesProjectOfficeProcured ;
                checkBoxPremisesPracticalLocation.Checked = currentProjectOfficeChecklistModel.PremisesPracticalLocation ;
                checkBoxPremisesMeetRequirements.Checked = currentProjectOfficeChecklistModel.PremisesRequiredDocumted ;
                checkBoxFormalContract.Checked = currentProjectOfficeChecklistModel.PremisesFormalContract ;
                checkBoxPremisesProvideSufficient.Checked = currentProjectOfficeChecklistModel.PremisesSufficientSpace ;
                checkBoxPremisesContinueAvaliable.Checked = currentProjectOfficeChecklistModel.PremisesContinueAvailible ;
                checkBoxAdditionalFitOut.Checked = currentProjectOfficeChecklistModel.PremisesAdditionalFitOut ;
                checkBoxOnSiteFacilities.Checked = currentProjectOfficeChecklistModel.PremisesOnSiteFacilities ;

                //Equipment
                checkBoxProjectTeamRequiredEquipment.Checked = currentProjectOfficeChecklistModel.EquipmentRequiredOffice ;
                checkBoxMaintanenceContractsInPlace.Checked = currentProjectOfficeChecklistModel.EquipmentMaintananceCOntracts ;
                checkBoxSpareEquipmentAvaliable.Checked = currentProjectOfficeChecklistModel.EquipmentSpareEquipment ;
                checkBoxOfficeEquipmentFunctioning.Checked = currentProjectOfficeChecklistModel.EquipmentOfficeFunctioning ;
                checkBoxSufficientCommunicationsTechnologies.Checked = currentProjectOfficeChecklistModel.EquipmentSufficientCommunication ;
                checkBoxVideoConferencingAvaliable.Checked = currentProjectOfficeChecklistModel.EquipmentVideoCOnferensing ;
                checkBoxEquipmentFunctioningAsRequired.Checked = currentProjectOfficeChecklistModel.EquipmentFunctioningAsRequired ;

                //Roles
                checkBoxProjectSponser.Checked = currentProjectOfficeChecklistModel.RolesAppointedProjectSponsor ;
                checkBoxProjectManager.Checked = currentProjectOfficeChecklistModel.RolesAppointedProjectManager ;
                checkBoxProjectOfficeManager.Checked = currentProjectOfficeChecklistModel.RolesAppointedProjectOfficeManager ;
                checkBoxProcurementManager.Checked = currentProjectOfficeChecklistModel.RolesAppointedProcurementManager ;
                checkBoxCommManager.Checked = currentProjectOfficeChecklistModel.RolesAppointedCommunicationsManager ;
                checkBoxQualityManager.Checked = currentProjectOfficeChecklistModel.RolesAppointedQualityManager ;
                checkBoxRiskManager.Checked = currentProjectOfficeChecklistModel.RolesAppointedRiskManager ;
                checkBoxTeamLeader.Checked = currentProjectOfficeChecklistModel.RolesAppointedTeamLeader ;
                checkBoxJobDescriptionDocumented.Checked = currentProjectOfficeChecklistModel.RolesJobDescriptionsDocumented ;
                checkBoxJobDescriptionDescribeResponsibilities.Checked = currentProjectOfficeChecklistModel.RolesJobDescriptionsResponsibilities ;
                checkBoxSuitablySkilledPeopleAppointed.Checked = currentProjectOfficeChecklistModel.RolesSkilledPeopleAppointed ;

                //Standards and Processes
                checkBoxISO.Checked = currentProjectOfficeChecklistModel.StandardsIndustyStandards ;
                checkBoxHealthSafetyStandard.Checked = currentProjectOfficeChecklistModel.StandardsHealthAndSafety ;
                checkBoxProjectPlanning.Checked = currentProjectOfficeChecklistModel.StandardsProjectPlanning ;
                checkBoxPMBOK.Checked = currentProjectOfficeChecklistModel.StandardsPMI ;
                checkBoxSuitableProjectManagementMethodology.Checked = currentProjectOfficeChecklistModel.StandardSuitableProjManMethod ;

                checkBoxTimeMP.Checked = currentProjectOfficeChecklistModel.ProcessesTimeManagement ;
                checkBoxCostMP.Checked = currentProjectOfficeChecklistModel.ProcessesCostManagement ;
                checkBoxQualityMP.Checked = currentProjectOfficeChecklistModel.ProcessesQualityManagement ;
                checkBoxChangeMP.Checked = currentProjectOfficeChecklistModel.ProcessesChangeManagement ;
                checkBoxRiskMP.Checked = currentProjectOfficeChecklistModel.ProcessesRiskManagement ;
                checkBoxIssueMP.Checked = currentProjectOfficeChecklistModel.ProcessesIssueManagement ;
                checkBoxProcurementMP.Checked = currentProjectOfficeChecklistModel.ProcessesProcurementManagement ;
                checkBoxAcceptanceMP.Checked = currentProjectOfficeChecklistModel.ProcessesAcceptanceManagement ;
                checkBoxCommunicationsMP.Checked = currentProjectOfficeChecklistModel.ProcessesCommunicationsManagement ;

                //Templates
                checkBoxBusinessCase.Checked = currentProjectOfficeChecklistModel.TemplatesInitiationBusinessCase ;
                checkBoxFeasibilityStudy.Checked = currentProjectOfficeChecklistModel.TemplatesInitiationFeasibilityStudy ;
                checkBoxTermsofReference.Checked = currentProjectOfficeChecklistModel.TemplatesInitiationTermsOfReference ;
                checkBoxJobDescription.Checked = currentProjectOfficeChecklistModel.TemplatesInitiationJobDescription ;
                checkBoxStageGateReviewForm.Checked = currentProjectOfficeChecklistModel.TemplatesInitiationStageGate ;

                checkBoxProjectPlan.Checked = currentProjectOfficeChecklistModel.TemplatesPlanningProjectPlan ;
                checkBoxResourcePlan.Checked = currentProjectOfficeChecklistModel.TemplatesPlanningResourcePlan ;
                checkBoxFinancialPlan.Checked = currentProjectOfficeChecklistModel.TemplatesPlanningFinancialPlan ;
                checkBoxQualityPlan.Checked = currentProjectOfficeChecklistModel.TemplatesPlanningQualityPlan ;
                checkBoxTemplatesRiskPlan.Checked = currentProjectOfficeChecklistModel.TemplatesPlanningRiskPlan ;
                checkBoxAcceptancePlan.Checked = currentProjectOfficeChecklistModel.TemplatesPlanningAcceptancePlan ;
                checkBoxCommunicationsPlan.Checked = currentProjectOfficeChecklistModel.TemplatesPlanningCommunicationsPlan ;
                checkBoxProcurementPlan.Checked = currentProjectOfficeChecklistModel.TemplatesPlanningProcurementPlan ;
                checkBoxSupplierContract.Checked = currentProjectOfficeChecklistModel.TemplatesPlanningSupplierPlan ;
                checkBoxTenderRegister.Checked = currentProjectOfficeChecklistModel.TemplatesPlanningTenderPlan ;

                checkBoxTFTR.Checked = currentProjectOfficeChecklistModel.TemplatesExecutionTimesheet ;
                checkBoxEFER.Checked = currentProjectOfficeChecklistModel.TemplatesExecutionExpense ;
                checkBoxQFDR.Checked = currentProjectOfficeChecklistModel.TemplatesExecutionQuality ;
                checkBoxCFCR.Checked = currentProjectOfficeChecklistModel.TemplatesExecutionChange ;
                checkBoxRFRR.Checked = currentProjectOfficeChecklistModel.TemplatesExecutionRisk ;
                checkBoxIFIR.Checked = currentProjectOfficeChecklistModel.TemplatesExecutionIssue ;
                checkBoxPOF.Checked = currentProjectOfficeChecklistModel.TemplatesExecutionPurchase ;
                checkBoxPR.Checked = currentProjectOfficeChecklistModel.TemplatesExecutionProcurement ;
                checkBoxPSR.Checked = currentProjectOfficeChecklistModel.TemplatesExecutionProject ;
                checkBoxCR.Checked = currentProjectOfficeChecklistModel.TemplatesExecutionCommunication ;
                checkBoxAF.Checked = currentProjectOfficeChecklistModel.TemplatesExecutionAcceptanceForm ;
                checkBoxAR.Checked = currentProjectOfficeChecklistModel.TemplatesExecutionAcceptanceRegister ;

                checkBoxProjectClosureReport.Checked = currentProjectOfficeChecklistModel.TemplatesClosureProjectReport ;
                checkBoxPostImplementationReview.Checked = currentProjectOfficeChecklistModel.TemplatesClosurePostReview ;

                //Services(Time, Cost, Quality,Change, Risk,Issue)
                checkBoxTM1.Checked = currentProjectOfficeChecklistModel.ServicesTimeMonitoring ;
                checkBoxTM2.Checked = currentProjectOfficeChecklistModel.ServicesTimeProjectPlan ;
                checkBoxTM3.Checked = currentProjectOfficeChecklistModel.ServicesTimeTimesheet ;

                checkBoxCM1.Checked = currentProjectOfficeChecklistModel.ServicesCostMonitoring ;
                checkBoxCM2.Checked = currentProjectOfficeChecklistModel.ServicesCostProjectPlan ;
                checkBoxCM3.Checked = currentProjectOfficeChecklistModel.ServicesCostExpense ;

                checkBoxQM1.Checked = currentProjectOfficeChecklistModel.ServicesQualityAssurance ;
                checkBoxQM2.Checked = currentProjectOfficeChecklistModel.ServicesQualityControl ;
                checkBoxQM3.Checked = currentProjectOfficeChecklistModel.ServicesQualityDeliverables ;

                checkBoxChangeM1.Checked = currentProjectOfficeChecklistModel.ServicesChangeRequests ;
                checkBoxChangeM2.Checked = currentProjectOfficeChecklistModel.ServicesChangeSheduling ;
                checkBoxChangeM3.Checked = currentProjectOfficeChecklistModel.ServicesChangeKeeping ;

                checkBoxRM1.Checked = currentProjectOfficeChecklistModel.ServicesRiskForms ;
                checkBoxRM2.Checked = currentProjectOfficeChecklistModel.ServicesRiskSheduling ;
                checkBoxRM3.Checked = currentProjectOfficeChecklistModel.ServicesRiskKeeping ;

                checkBoxIM1.Checked = currentProjectOfficeChecklistModel.ServicesIssueForms ;
                checkBoxIM2.Checked = currentProjectOfficeChecklistModel.ServicesIssueScheduling ;
                checkBoxIM3.Checked = currentProjectOfficeChecklistModel.ServicesIssueKeeping ;

                //Services(Procuremenm, Acceptance, communication)
                checkBoxPM1.Checked = currentProjectOfficeChecklistModel.ServicesProcurementPurchase ;
                checkBoxPM2.Checked = currentProjectOfficeChecklistModel.ServicesProcurementGoodsAndServices ;
                checkBoxPM3.Checked = currentProjectOfficeChecklistModel.ServicesProcurementKeeping ;
                checkBoxPM4.Checked = currentProjectOfficeChecklistModel.ServicesProcurementPayement ;
                checkBoxPM5.Checked = currentProjectOfficeChecklistModel.ServicesProcurementManaging ;

                checkBoxAM1.Checked = currentProjectOfficeChecklistModel.ServicesAcceptanceInitiating ;
                checkBoxAM2.Checked = currentProjectOfficeChecklistModel.ServicesAcceptanceDocumenting ;
                checkBoxAM3.Checked = currentProjectOfficeChecklistModel.ServicesAcceptanceGainingFinalAcceptance ;
                checkBoxAM4.Checked = currentProjectOfficeChecklistModel.ServicesAcceptanceKeeping ;

                checkBoxCommsM1.Checked = currentProjectOfficeChecklistModel.ServicesCommunicationsUndertaking ;
                checkBoxCommsM2.Checked = currentProjectOfficeChecklistModel.ServicesCommunicationsCreating ;
                checkBoxCommsM3.Checked = currentProjectOfficeChecklistModel.ServicesCommunicationsDistributing ;
                checkBoxCommsM4.Checked = currentProjectOfficeChecklistModel.ServicesCommunicationsKeeping ;

                //Service(StageGAte, Auditing, Supporting, Providing)
                checkBoxSGR1.Checked = currentProjectOfficeChecklistModel.ServicesStageGateIdentifying ;
                checkBoxSGR2.Checked = currentProjectOfficeChecklistModel.ServicesStageGateOrganizing ;

                checkBoxAandC1.Checked = currentProjectOfficeChecklistModel.ServicesAuditingEnsuringConforms ;
                checkBoxAandC2.Checked = currentProjectOfficeChecklistModel.ServicesAuditingInforming ;

                checkBoxSS1.Checked = currentProjectOfficeChecklistModel.ServicesSupportingAssisting ;
                checkBoxSS2.Checked = currentProjectOfficeChecklistModel.ServicesSupportingAdvising ;
                checkBoxSS3.Checked = currentProjectOfficeChecklistModel.ServicesSupportingPaying ;

                checkBoxPT1.Checked = currentProjectOfficeChecklistModel.ServicesProvidingProjectManagement ;
                checkBoxPT2.Checked = currentProjectOfficeChecklistModel.ServicesProvidingToolsForMonitoring ;
                checkBoxPT3.Checked = currentProjectOfficeChecklistModel.ServicesProvidingTraining ;

                //Service(Filling, Performing, Undertaking)
                checkBoxFD1.Checked = currentProjectOfficeChecklistModel.ServicesPerformingAdministration ;
                checkBoxFD2.Checked = currentProjectOfficeChecklistModel.ServicesPerformingPurchasing ;

                checkBoxPA1.Checked = currentProjectOfficeChecklistModel.ServicesFilingLibrary ;
                checkBoxPA2.Checked = currentProjectOfficeChecklistModel.ServicesFilingImplementing ;

                checkBoxUCR1.Checked = currentProjectOfficeChecklistModel.ServicesClosureOrganizing ;
                checkBoxUCR2.Checked = currentProjectOfficeChecklistModel.ServicesComminicating ;


            }
        }

        private void checkBoxQualityManager_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
