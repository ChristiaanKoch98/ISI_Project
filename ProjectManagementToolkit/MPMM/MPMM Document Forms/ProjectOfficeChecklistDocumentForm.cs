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
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Forms
{
    public partial class ProjectOfficeChecklistDocumentForm : Form
    {
        VersionControl<ProjectOfficeChecklistModel> versionControl;
        ProjectOfficeChecklistModel newProjectOfficeChecklistModel;
        ProjectOfficeChecklistModel currentProjectOfficeChecklistModel;
        Color TABLE_HEADER_COLOR = Color.FromArgb(73, 173, 252);
        ProjectModel projectModel = new ProjectModel();

        public ProjectOfficeChecklistDocumentForm()
        {
            InitializeComponent();
        }

        /*

        private void ProjectOfficeChecklistDocumentForm_Load(object sender, EventArgs e)
        {
            loadDocument();
            string json = JsonHelper.loadProjectInfo(Settings.Default.Username);
            List<ProjectModel> projectListModel = JsonConvert.DeserializeObject<List<ProjectModel>>(json);
            projectModel = projectModel.getProjectModel(Settings.Default.ProjectID, projectListModel);
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
                checkBoxProjectOfficePremisesProcured.Checked = currentProjectOfficeChecklistModel.PremisesProjectOfficeProcured;
                checkBoxPremisesPracticalLocation.Checked = currentProjectOfficeChecklistModel.PremisesPracticalLocation;
                checkBoxPremisesMeetRequirements.Checked = currentProjectOfficeChecklistModel.PremisesRequiredDocumted;
                checkBoxFormalContract.Checked = currentProjectOfficeChecklistModel.PremisesFormalContract;
                checkBoxPremisesProvideSufficient.Checked = currentProjectOfficeChecklistModel.PremisesSufficientSpace;
                checkBoxPremisesContinueAvaliable.Checked = currentProjectOfficeChecklistModel.PremisesContinueAvailible;
                checkBoxAdditionalFitOut.Checked = currentProjectOfficeChecklistModel.PremisesAdditionalFitOut;
                checkBoxOnSiteFacilities.Checked = currentProjectOfficeChecklistModel.PremisesOnSiteFacilities;

                //Equipment
                checkBoxProjectTeamRequiredEquipment.Checked = currentProjectOfficeChecklistModel.EquipmentRequiredOffice;
                checkBoxMaintanenceContractsInPlace.Checked = currentProjectOfficeChecklistModel.EquipmentMaintananceCOntracts;
                checkBoxSpareEquipmentAvaliable.Checked = currentProjectOfficeChecklistModel.EquipmentSpareEquipment;
                checkBoxOfficeEquipmentFunctioning.Checked = currentProjectOfficeChecklistModel.EquipmentOfficeFunctioning;
                checkBoxSufficientCommunicationsTechnologies.Checked = currentProjectOfficeChecklistModel.EquipmentSufficientCommunication;
                checkBoxVideoConferencingAvaliable.Checked = currentProjectOfficeChecklistModel.EquipmentVideoCOnferensing;
                checkBoxEquipmentFunctioningAsRequired.Checked = currentProjectOfficeChecklistModel.EquipmentFunctioningAsRequired;

                //Roles
                checkBoxProjectSponser.Checked = currentProjectOfficeChecklistModel.RolesAppointedProjectSponsor;
                checkBoxProjectManager.Checked = currentProjectOfficeChecklistModel.RolesAppointedProjectManager;
                checkBoxProjectOfficeManager.Checked = currentProjectOfficeChecklistModel.RolesAppointedProjectOfficeManager;
                checkBoxProcurementManager.Checked = currentProjectOfficeChecklistModel.RolesAppointedProcurementManager;
                checkBoxCommManager.Checked = currentProjectOfficeChecklistModel.RolesAppointedCommunicationsManager;
                checkBoxQualityManager.Checked = currentProjectOfficeChecklistModel.RolesAppointedQualityManager;
                checkBoxRiskManager.Checked = currentProjectOfficeChecklistModel.RolesAppointedRiskManager;
                checkBoxTeamLeader.Checked = currentProjectOfficeChecklistModel.RolesAppointedTeamLeader;
                checkBoxJobDescriptionDocumented.Checked = currentProjectOfficeChecklistModel.RolesJobDescriptionsDocumented;
                checkBoxJobDescriptionDescribeResponsibilities.Checked = currentProjectOfficeChecklistModel.RolesJobDescriptionsResponsibilities;
                checkBoxSuitablySkilledPeopleAppointed.Checked = currentProjectOfficeChecklistModel.RolesSkilledPeopleAppointed;

                //Standards and Processes
                checkBoxISO.Checked = currentProjectOfficeChecklistModel.StandardsIndustyStandards;
                checkBoxHealthSafetyStandard.Checked = currentProjectOfficeChecklistModel.StandardsHealthAndSafety;
                checkBoxProjectPlanning.Checked = currentProjectOfficeChecklistModel.StandardsProjectPlanning;
                checkBoxPMBOK.Checked = currentProjectOfficeChecklistModel.StandardsPMI;
                checkBoxSuitableProjectManagementMethodology.Checked = currentProjectOfficeChecklistModel.StandardSuitableProjManMethod;

                checkBoxTimeMP.Checked = currentProjectOfficeChecklistModel.ProcessesTimeManagement;
                checkBoxCostMP.Checked = currentProjectOfficeChecklistModel.ProcessesCostManagement;
                checkBoxQualityMP.Checked = currentProjectOfficeChecklistModel.ProcessesQualityManagement;
                checkBoxChangeMP.Checked = currentProjectOfficeChecklistModel.ProcessesChangeManagement;
                checkBoxRiskMP.Checked = currentProjectOfficeChecklistModel.ProcessesRiskManagement;
                checkBoxIssueMP.Checked = currentProjectOfficeChecklistModel.ProcessesIssueManagement;
                checkBoxProcurementMP.Checked = currentProjectOfficeChecklistModel.ProcessesProcurementManagement;
                checkBoxAcceptanceMP.Checked = currentProjectOfficeChecklistModel.ProcessesAcceptanceManagement;
                checkBoxCommunicationsMP.Checked = currentProjectOfficeChecklistModel.ProcessesCommunicationsManagement;

                //Templates
                checkBoxBusinessCase.Checked = currentProjectOfficeChecklistModel.TemplatesInitiationBusinessCase;
                checkBoxFeasibilityStudy.Checked = currentProjectOfficeChecklistModel.TemplatesInitiationFeasibilityStudy;
                checkBoxTermsofReference.Checked = currentProjectOfficeChecklistModel.TemplatesInitiationTermsOfReference;
                checkBoxJobDescription.Checked = currentProjectOfficeChecklistModel.TemplatesInitiationJobDescription;
                checkBoxStageGateReviewForm.Checked = currentProjectOfficeChecklistModel.TemplatesInitiationStageGate;

                checkBoxProjectPlan.Checked = currentProjectOfficeChecklistModel.TemplatesPlanningProjectPlan;
                checkBoxResourcePlan.Checked = currentProjectOfficeChecklistModel.TemplatesPlanningResourcePlan;
                checkBoxFinancialPlan.Checked = currentProjectOfficeChecklistModel.TemplatesPlanningFinancialPlan;
                checkBoxQualityPlan.Checked = currentProjectOfficeChecklistModel.TemplatesPlanningQualityPlan;
                checkBoxTemplatesRiskPlan.Checked = currentProjectOfficeChecklistModel.TemplatesPlanningRiskPlan;
                checkBoxAcceptancePlan.Checked = currentProjectOfficeChecklistModel.TemplatesPlanningAcceptancePlan;
                checkBoxCommunicationsPlan.Checked = currentProjectOfficeChecklistModel.TemplatesPlanningCommunicationsPlan;
                checkBoxProcurementPlan.Checked = currentProjectOfficeChecklistModel.TemplatesPlanningProcurementPlan;
                checkBoxSupplierContract.Checked = currentProjectOfficeChecklistModel.TemplatesPlanningSupplierPlan;
                checkBoxTenderRegister.Checked = currentProjectOfficeChecklistModel.TemplatesPlanningTenderPlan;

                checkBoxTFTR.Checked = currentProjectOfficeChecklistModel.TemplatesExecutionTimesheet;
                checkBoxEFER.Checked = currentProjectOfficeChecklistModel.TemplatesExecutionExpense;
                checkBoxQFDR.Checked = currentProjectOfficeChecklistModel.TemplatesExecutionQuality;
                checkBoxCFCR.Checked = currentProjectOfficeChecklistModel.TemplatesExecutionChange;
                checkBoxRFRR.Checked = currentProjectOfficeChecklistModel.TemplatesExecutionRisk;
                checkBoxIFIR.Checked = currentProjectOfficeChecklistModel.TemplatesExecutionIssue;
                checkBoxPOF.Checked = currentProjectOfficeChecklistModel.TemplatesExecutionPurchase;
                checkBoxPR.Checked = currentProjectOfficeChecklistModel.TemplatesExecutionProcurement;
                checkBoxPSR.Checked = currentProjectOfficeChecklistModel.TemplatesExecutionProject;
                checkBoxCR.Checked = currentProjectOfficeChecklistModel.TemplatesExecutionCommunication;
                checkBoxAF.Checked = currentProjectOfficeChecklistModel.TemplatesExecutionAcceptanceForm;
                checkBoxAR.Checked = currentProjectOfficeChecklistModel.TemplatesExecutionAcceptanceRegister;

                checkBoxProjectClosureReport.Checked = currentProjectOfficeChecklistModel.TemplatesClosureProjectReport;
                checkBoxPostImplementationReview.Checked = currentProjectOfficeChecklistModel.TemplatesClosurePostReview;

                //Services(Time, Cost, Quality,Change, Risk,Issue)
                checkBoxTM1.Checked = currentProjectOfficeChecklistModel.ServicesTimeMonitoring;
                checkBoxTM2.Checked = currentProjectOfficeChecklistModel.ServicesTimeProjectPlan;
                checkBoxTM3.Checked = currentProjectOfficeChecklistModel.ServicesTimeTimesheet;

                checkBoxCM1.Checked = currentProjectOfficeChecklistModel.ServicesCostMonitoring;
                checkBoxCM2.Checked = currentProjectOfficeChecklistModel.ServicesCostProjectPlan;
                checkBoxCM3.Checked = currentProjectOfficeChecklistModel.ServicesCostExpense;

                checkBoxQM1.Checked = currentProjectOfficeChecklistModel.ServicesQualityAssurance;
                checkBoxQM2.Checked = currentProjectOfficeChecklistModel.ServicesQualityControl;
                checkBoxQM3.Checked = currentProjectOfficeChecklistModel.ServicesQualityDeliverables;

                checkBoxChangeM1.Checked = currentProjectOfficeChecklistModel.ServicesChangeRequests;
                checkBoxChangeM2.Checked = currentProjectOfficeChecklistModel.ServicesChangeSheduling;
                checkBoxChangeM3.Checked = currentProjectOfficeChecklistModel.ServicesChangeKeeping;

                checkBoxRM1.Checked = currentProjectOfficeChecklistModel.ServicesRiskForms;
                checkBoxRM2.Checked = currentProjectOfficeChecklistModel.ServicesRiskSheduling;
                checkBoxRM3.Checked = currentProjectOfficeChecklistModel.ServicesRiskKeeping;

                checkBoxIM1.Checked = currentProjectOfficeChecklistModel.ServicesIssueForms;
                checkBoxIM2.Checked = currentProjectOfficeChecklistModel.ServicesIssueScheduling;
                checkBoxIM3.Checked = currentProjectOfficeChecklistModel.ServicesIssueKeeping;

                //Services(Procuremenm, Acceptance, communication)
                checkBoxPM1.Checked = currentProjectOfficeChecklistModel.ServicesProcurementPurchase;
                checkBoxPM2.Checked = currentProjectOfficeChecklistModel.ServicesProcurementGoodsAndServices;
                checkBoxPM3.Checked = currentProjectOfficeChecklistModel.ServicesProcurementKeeping;
                checkBoxPM4.Checked = currentProjectOfficeChecklistModel.ServicesProcurementPayement;
                checkBoxPM5.Checked = currentProjectOfficeChecklistModel.ServicesProcurementManaging;

                checkBoxAM1.Checked = currentProjectOfficeChecklistModel.ServicesAcceptanceInitiating;
                checkBoxAM2.Checked = currentProjectOfficeChecklistModel.ServicesAcceptanceDocumenting;
                checkBoxAM3.Checked = currentProjectOfficeChecklistModel.ServicesAcceptanceGainingFinalAcceptance;
                checkBoxAM4.Checked = currentProjectOfficeChecklistModel.ServicesAcceptanceKeeping;

                checkBoxCommsM1.Checked = currentProjectOfficeChecklistModel.ServicesCommunicationsUndertaking;
                checkBoxCommsM2.Checked = currentProjectOfficeChecklistModel.ServicesCommunicationsCreating;
                checkBoxCommsM3.Checked = currentProjectOfficeChecklistModel.ServicesCommunicationsDistributing;
                checkBoxCommsM4.Checked = currentProjectOfficeChecklistModel.ServicesCommunicationsKeeping;

                //Service(StageGAte, Auditing, Supporting, Providing)
                checkBoxSGR1.Checked = currentProjectOfficeChecklistModel.ServicesStageGateIdentifying;
                checkBoxSGR2.Checked = currentProjectOfficeChecklistModel.ServicesStageGateOrganizing;

                checkBoxAandC1.Checked = currentProjectOfficeChecklistModel.ServicesAuditingEnsuringConforms;
                checkBoxAandC2.Checked = currentProjectOfficeChecklistModel.ServicesAuditingInforming;

                checkBoxSS1.Checked = currentProjectOfficeChecklistModel.ServicesSupportingAssisting;
                checkBoxSS2.Checked = currentProjectOfficeChecklistModel.ServicesSupportingAdvising;
                checkBoxSS3.Checked = currentProjectOfficeChecklistModel.ServicesSupportingPaying;

                checkBoxPT1.Checked = currentProjectOfficeChecklistModel.ServicesProvidingProjectManagement;
                checkBoxPT2.Checked = currentProjectOfficeChecklistModel.ServicesProvidingToolsForMonitoring;
                checkBoxPT3.Checked = currentProjectOfficeChecklistModel.ServicesProvidingTraining;

                //Service(Filling, Performing, Undertaking)
                checkBoxFD1.Checked = currentProjectOfficeChecklistModel.ServicesPerformingAdministration;
                checkBoxFD2.Checked = currentProjectOfficeChecklistModel.ServicesPerformingPurchasing;

                checkBoxPA1.Checked = currentProjectOfficeChecklistModel.ServicesFilingLibrary;
                checkBoxPA2.Checked = currentProjectOfficeChecklistModel.ServicesFilingImplementing;

                checkBoxUCR1.Checked = currentProjectOfficeChecklistModel.ServicesClosureOrganizing;
                checkBoxUCR2.Checked = currentProjectOfficeChecklistModel.ServicesComminicating;


            }
            else
            {
                versionControl = new VersionControl<ProjectOfficeChecklistModel>();
                versionControl.DocumentModels = new List<VersionControl<ProjectOfficeChecklistModel>.DocumentModel>();
            }
        }

        private void checkBoxQualityManager_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnExportProjectDetails_Click(object sender, EventArgs e)
        {
            exportToWord();
        }

        static string DisplayYesNo(bool answer)
        {
            string yn = "";

            if (answer == true)
            {
                yn = "Yes";
                return yn;
            }
            else
            {
                yn = "No";
                return yn;
            }
        }

        private void exportToWord()
        {
            string path;
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                saveFileDialog.Filter = "Word 97-2003 Documents (*.doc)|*.doc|Word 2007 Documents (*.docx)|*.docx";
                saveFileDialog.FilterIndex = 2;
                saveFileDialog.RestoreDirectory = true;


                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    path = saveFileDialog.FileName;
                    using (var document = DocX.Create(path))
                    {
                        for (int i = 0; i < 11; i++)
                        {
                            document.InsertParagraph("")
                                .Font("Arial")
                                .Bold(true)
                                .FontSize(22d).Alignment = Alignment.left;
                        }
                        document.InsertParagraph("Project Office Checklist \nFor " + projectModel.ProjectName)
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(22d).Alignment = Alignment.left;
                        document.InsertSectionPageBreak();


                        var checklistTable = document.AddTable(15, 1);

                        //Project details///
                        checklistTable.Rows[0].Cells[0].Paragraphs[0].Append("Project Details").Bold(true).Color(Color.White).FontSize(14d);

                        checklistTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        checklistTable.Rows[1].Cells[0].Paragraphs[0].Append("Project Name: \t\t" + currentProjectOfficeChecklistModel.ProjectName
                            + "\nProject Manager: \t" + currentProjectOfficeChecklistModel.ProjectManager
                            + "\nProject Office Manager: \t" + currentProjectOfficeChecklistModel.ProjectOfficeManager);

                        //Premises//////
                        checklistTable.Rows[2].Cells[0].Paragraphs[0].Append("Premises").Bold(true).Color(Color.White).FontSize(14d);
                        checklistTable.Rows[2].Cells[0].FillColor = TABLE_HEADER_COLOR;

                        checklistTable.Rows[3].Cells[0].Paragraphs[0].Append("Were the Project Office requirements documented? \t\t\t\t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.PremisesProjectOfficeDocumented)
                            + "\nHave the Project Office premises been procured? \t\t\t\t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.PremisesProjectOfficeProcured)
                            + "\nAre the premises in a practical location? \t\t\t\t\t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.PremisesPracticalLocation)
                            + "\nDo the premises meet the requirements documented? \t\t\t\t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.PremisesRequiredDocumted)
                            + "\nIs there a formal contract for the lease / purchase / use of the premises? \t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.PremisesFormalContract)
                            + "\nDo the premises provide sufficient space for the project team? \t\t\t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.PremisesSufficientSpace)
                            + "\nWill the premises continue to be available if the project is delayed? \t\t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.PremisesContinueAvailible)
                            + "\nDo the premises require additional fit-out (e.g. partitions, cabling, air conditioning)? \t" + DisplayYesNo(currentProjectOfficeChecklistModel.PremisesAdditionalFitOut)
                            + "\nAre the on-site facilities sufficient (e.g. number of meeting rooms, bathrooms \t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.PremisesOnSiteFacilities));

                        //Equipment/////////
                        checklistTable.Rows[4].Cells[0].Paragraphs[0].Append("Equipment").Bold(true).Color(Color.White).FontSize(14d);
                        checklistTable.Rows[4].Cells[0].FillColor = TABLE_HEADER_COLOR;

                        checklistTable.Rows[5].Cells[0].Paragraphs[0].Append("Office Equipment\n \t" 
                           + "\nDoes the project team have the required office equipment and application software available to manage the project (e.g. computer hardware, project planning and financial software, projectors, fax machines, printers, scanners, copiers)? \t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.EquipmentRequiredOffice)
                           + "\nAre maintenance contracts in place to ensure that equipment remains operational throughout the project? \t\t\t\t\t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.EquipmentMaintananceCOntracts)
                           + "\nIs spare equipment available in case of a shortage? \t" + DisplayYesNo(currentProjectOfficeChecklistModel.EquipmentSpareEquipment)
                           + "\nIs office equipment functioning as required? \t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.EquipmentFunctioningAsRequired)

                           + "\n\nCommunications Equipment\n \t"  
                           + "\nAre sufficient communications technologies available (e.g. computer networks, email, internet access, remote network dial-up software, mobile phones, laptops and hand-held devices)? \t\t\t\t\t\t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.EquipmentSufficientCommunication)
                           + "\nIs video conferencing equipment available? \t" + DisplayYesNo(currentProjectOfficeChecklistModel.EquipmentVideoCOnferensing)
                           + "\nIs the equipment functioning as required?  \t" + DisplayYesNo(currentProjectOfficeChecklistModel.EquipmentFunctioningAsRequired));




                        //Roles/////////////////
                        checklistTable.Rows[6].Cells[0].Paragraphs[0].Append("Roles").Bold(true).Color(Color.White).FontSize(14d);
                        checklistTable.Rows[6].Cells[0].FillColor = TABLE_HEADER_COLOR;

                        checklistTable.Rows[7].Cells[0].Paragraphs[0].Append("Have the following key roles been appointed?\n "
                           + "\n\tProject Sponsor \t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.RolesAppointedProjectSponsor)
                           + "\n\tProject Manager \t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.RolesAppointedProjectManager)
                           + "\n\tProject Office Manager \t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.RolesAppointedProjectOfficeManager)
                           + "\n\tProcurement Manager \t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.RolesAppointedProcurementManager)
                           + "\n\tCommunications Manager \t" + DisplayYesNo(currentProjectOfficeChecklistModel.RolesAppointedCommunicationsManager)
                           + "\n\tQuality Manager \t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.RolesAppointedQualityManager)
                           + "\n\tRisk Manager \t\t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.RolesAppointedRiskManager)
                           + "\n\tTeam Leader(s)\t\t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.RolesAppointedTeamLeader)
                           + "\n\nHave Job Descriptions been documented for all the project roles?  \t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.RolesJobDescriptionsDocumented)
                           + "\nDo all Job Descriptions describe the responsibilities and performance criteria?  \t" + DisplayYesNo(currentProjectOfficeChecklistModel.RolesJobDescriptionsResponsibilities)
                           + "\nWere suitably skilled people appointed to all the project roles? \t\t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.RolesSkilledPeopleAppointed));

                        //Standards and Process///////////
                        checklistTable.Rows[8].Cells[0].Paragraphs[0].Append("Standards and Process").Bold(true).Color(Color.White).FontSize(14d);
                        checklistTable.Rows[8].Cells[0].FillColor = TABLE_HEADER_COLOR;

                        checklistTable.Rows[9].Cells[0].Paragraphs[0].Append("Have all required industry, business and project management standards been identified? For example:\n "
                           + "\nIndustry standards (ISO):\t\t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.StandardsIndustyStandards)
                           + "\nHealth & Safety Standards:\t\t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.StandardsHealthAndSafety)
                           + "\nProject Planning & Reporting Standards:\t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.StandardsProjectPlanning)
                           + "\nPMI® & PMBOK®:\t\t\t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.StandardsPMI)
                           + "\n\nHas a suitable Project Management methodology been implemented?\t" + DisplayYesNo(currentProjectOfficeChecklistModel.StandardSuitableProjManMethod));

                        
                        checklistTable.Rows[10].Cells[0].Paragraphs[0].Append("Have the following processes been defined?\n "
                           + "\n\nTime Management Process: \t\t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.ProcessesTimeManagement)
                           + "\nCost Management Process: \t\t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.ProcessesCostManagement)
                           + "\nQuality Management Process: \t\t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.ProcessesQualityManagement)
                           + "\nChange Management Process: \t\t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.ProcessesChangeManagement)
                           + "\nRisk Management Process: \t\t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.ProcessesRiskManagement)
                           + "\nIssue Management Process: \t\t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.ProcessesIssueManagement)
                           + "\nProcurement Management Process: \t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.ProcessesProcurementManagement)
                           + "\nAcceptance Management Process:  \t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.ProcessesAcceptanceManagement)
                           + "\nCommunications Management Process:  \t" + DisplayYesNo(currentProjectOfficeChecklistModel.ProcessesCommunicationsManagement));

                        //Templates////////////
                        checklistTable.Rows[11].Cells[0].Paragraphs[0].Append("Templates").Bold(true).Color(Color.White).FontSize(14d);
                        checklistTable.Rows[11].Cells[0].FillColor = TABLE_HEADER_COLOR;

                        checklistTable.Rows[12].Cells[0].Paragraphs[0].Append("Are the following templates available?\n\n "
                           + "\nInitiation \t\t" 
                           + "\nBusiness Case \t\t\t\t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.TemplatesInitiationBusinessCase)
                           + "\nFeasibility Study \t\t\t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.TemplatesInitiationFeasibilityStudy)
                           + "\nTerms of Reference \t\t\t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.TemplatesInitiationTermsOfReference)
                           + "\nJob Description \t\t\t\t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.TemplatesInitiationJobDescription)
                           + "\nStage Gate Review Form \t\t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.TemplatesInitiationStageGate)

                           + "\n\nPlanning \n" 
                           + "\nProject Plan \t\t\t\t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.TemplatesPlanningProjectPlan)
                           + "\nResource Plan \t\t\t\t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.TemplatesPlanningResourcePlan)
                           + "\nFinancial Plan \t\t\t\t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.TemplatesPlanningFinancialPlan)
                           + "\nQuality Plan \t\t\t\t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.TemplatesPlanningQualityPlan)
                           + "\nRisk Plan \t\t\t\t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.TemplatesPlanningRiskPlan)
                           + "\nAcceptance Plan\t\t\t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.TemplatesPlanningAcceptancePlan)
                           + "\nCommunications Plan \t\t\t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.TemplatesPlanningCommunicationsPlan)
                           + "\nProcurement Plan \t\t\t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.TemplatesPlanningProcurementPlan)
                           + "\nSupplier Contract \t\t\t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.TemplatesPlanningSupplierPlan)
                           + "\nTender Register  \t\t\t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.TemplatesPlanningTenderPlan)

                           + "\n\nExecution  \t\t" 
                           + "\nTimesheet Form, Timesheet Register \t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.TemplatesExecutionTimesheet)
                           + "\nExpense Form, Expense Register \t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.TemplatesExecutionExpense)
                           + "\nQuality Form, Deliverables Register \t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.TemplatesExecutionQuality)
                           + "\nChange Form, Change Register \t\t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.TemplatesExecutionChange)
                           + "\nRisk Form, Risk Register \t\t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.TemplatesExecutionRisk)
                           + "\nIssue Form, Issue Register \t\t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.TemplatesExecutionIssue)
                           + "\nPurchase Order Form \t\t\t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.TemplatesExecutionPurchase)
                           + "\nProcurement Register  \t\t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.TemplatesExecutionProcurement)
                           + "\nProject Status Report  \t\t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.TemplatesExecutionProject)
                           + "\nCommunications Register \t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.TemplatesExecutionCommunication)
                           + "\nAcceptance Form \t\t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.TemplatesExecutionAcceptanceForm)
                           + "\nAcceptance Register \t\t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.TemplatesExecutionAcceptanceRegister)

                           + "\n\nClosure  \t\t" 
                           + "\nProject Closure Report  \t\t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.TemplatesClosureProjectReport)
                           + "\nPost Implementation Review  \t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.TemplatesClosurePostReview));



                        //Services///////
                        checklistTable.Rows[13].Cells[0].Paragraphs[0].Append("Services").Bold(true).Color(Color.White).FontSize(14d);
                        checklistTable.Rows[13].Cells[0].FillColor = TABLE_HEADER_COLOR;

                        checklistTable.Rows[14].Cells[0].Paragraphs[0].Append("Time Management\n "
                           + "\nMonitoring the project progress by identifying time and effort spent vs. budgeted \t" + DisplayYesNo(currentProjectOfficeChecklistModel.ServicesTimeMonitoring)
                           + "\nKeeping the Project Plan up-to-date and identifying any delivery date slippage \t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.ServicesTimeProjectPlan)
                           + "\nKeeping the Timesheet Register up-to-date at all times \t\t\t\t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.ServicesTimeTimesheet)

                           + "\n\nCost Management \t\t"
                           + "\nMonitoring the project progress by identifying the budget spent vs. forecast \t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.ServicesCostMonitoring)
                           + "\nKeeping the Project Plan up-to-date and identifying any overspending \t\t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.ServicesCostProjectPlan)
                           + "\nKeeping the Expense Register up-to-date at all times \t\t\t\t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.ServicesCostExpense)

                           + "\n\nQuality Management  \t\t"
                           + "\nPerforming Quality Assurance to improve the chances of delivering quality  \t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.ServicesQualityAssurance)
                           + "\nEnsuring that Quality Control is implemented to measure the actual level of quality\t" + DisplayYesNo(currentProjectOfficeChecklistModel.ServicesQualityControl)
                           + "\nKeeping the Deliverables Register up-to-date at all times\t\t\t\t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.ServicesQualityDeliverables)

                           + "\n\nChange Management\t\t"
                           + "\nReceiving Change Requests and managing the change approval process\t\t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.ServicesChangeRequests)
                           + "\nScheduling Change Requests and measuring the impact of changes implemented \t" + DisplayYesNo(currentProjectOfficeChecklistModel.ServicesChangeSheduling)
                           + "\nKeeping the Change Register up-to-date at all times \t\t\t\t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.ServicesChangeKeeping)

                           + "\n\nRisk Management \t\t\t"
                           + "\nReceiving Risk Forms and managing the risk review process  \t\t\t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.ServicesRiskForms)
                           + "\nScheduling actions to mitigate risks and measuring the impact of such actions  \t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.ServicesRiskSheduling)
                           + "\nKeeping the Risk Register up-to-date at all times \t\t\t\t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.ServicesRiskKeeping)

                           + "\n\nIssue Management \t\t"
                           + "\nReceiving Issue Forms and managing the issue review process \t\t\t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.ServicesIssueForms)
                           + "\nScheduling actions to resolve issues and measuring the impact of such actions \t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.ServicesIssueScheduling)
                           + "\nKeeping the Issue Register up-to-date at all times \t\t\t\t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.ServicesIssueKeeping)

                           + "\n\nProcurement Management \t\t"
                           + "\nIssuing Purchase Orders for the provision of goods and services from suppliers \t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.ServicesProcurementPurchase)
                           + "\nReceiving and accepting goods and services ordered from suppliers  \t\t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.ServicesProcurementGoodsAndServices)
                           + "\nKeeping the Procurement Register up-to-date at all times  \t\t\t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.ServicesProcurementKeeping)
                           + "\nMaking payment to suppliers for goods and services delivered \t\t\t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.ServicesProcurementPayement)
                           + "\nManaging the overall performance of suppliers to ensure that they complete their responsibilities as contracted \t\t\t\t\t\t\t\t\t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.ServicesProcurementManaging)

                           + "\n\nAcceptance Management \t\t\t"
                           + "\nInitiating Acceptance Reviews, as scheduled in the Acceptance Plan \t\t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.ServicesAcceptanceInitiating)
                           + "\nDocumenting the results of each review by completing Acceptance Forms  \t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.ServicesAcceptanceDocumenting)
                           + "\nGaining final acceptance from the customer for each deliverable produced  \t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.ServicesAcceptanceGainingFinalAcceptance)
                           + "\nKeeping the Acceptance Register up-to-date at all times \t\t\t\t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.ServicesAcceptanceKeeping)

                           + "\n\nCommunications Management \t\t"
                           + "\nUndertaking the communications tasks and events as listed in the Communications Plan " + DisplayYesNo(currentProjectOfficeChecklistModel.ServicesCommunicationsUndertaking)
                           + "\nCreating and releasing regular Project Status Reports  \t\t\t\t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.ServicesCommunicationsCreating)
                           + "\nDistributing press releases and managing Public Relations  \t\t\t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.ServicesCommunicationsDistributing)
                           + "\nKeeping the Communications Register up-to-date at all times \t\t\t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.ServicesCommunicationsKeeping)

                           + "\n\nStage Gate Reviews  \t\t"
                           + "\nIdentifying the point in time when a Stage Gate must be undertaken  \t\t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.ServicesStageGateIdentifying)
                           + "\nOrganizing the Stage Gate and recording the results on a Stage Gate Form  \t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.ServicesStageGateOrganizing)

                           + "\n\nAuditing and Compliance  \t\t\t"
                           + "\nEnsuring that the project conforms to appropriate industry and business policies, processes, standards and guidelines  \t\t\t\t\t\t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.ServicesAuditingEnsuringConforms)
                           + "\nInforming the Project Manager of any deviations and monitoring the results of any actions taken to correct them  \t\t\t\t\t\t\t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.ServicesAuditingInforming)

                           + "\n\nSupporting Staff  \t\t"
                           + "\nAssisting the Project Manager with the recruitment of new staff \t\t\t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.ServicesSupportingAssisting)
                           + "\nSupporting and advising staff, resolving staff issues and providing staff training \t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.ServicesSupportingAdvising)
                           + "\nPaying staff in accordance with their contracts and administering leave  \t\t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.ServicesSupportingPaying)

                           + "\n\nProviding Tools  \t\t"
                           + "\nProcuring a suitable Project Management methodology  \t\t\t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.ServicesProvidingProjectManagement)
                           + "\nProcuring tools for project planning, monitoring, controlling and reporting  \t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.ServicesProvidingToolsForMonitoring)
                           + "\nTraining staff in the use of these tools and methodology  \t\t\t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.ServicesProvidingTraining)

                           + "\n\nFiling Documents  \t\t"
                           + "\nKeeping a library of all project documents, reports, job descriptions, correspondence, standards, processes, registers, forms and templates  \t\t\t\t\t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.ServicesFilingLibrary)
                           + "\nImplementing an indexing method to ensure that project documentation may be easily sourced when required  \t\t\t\t\t\t\t\t\t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.ServicesFilingImplementing)

                           + "\n\nPerforming Administration  \t\t"
                           + "\nProviding administration services such as the organization of travel bookings, room bookings, photocopying, secretarial, mail and correspondence  \t\t\t\t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.ServicesPerformingAdministration)
                           + "\nPurchasing all office equipment and materials needed by the project  \t\t\t" + DisplayYesNo(currentProjectOfficeChecklistModel.ServicesPerformingPurchasing)

                           + "\n\nUndertaking Closure Reviews  \t\t" 
                           + "\nOrganizing the completion of a Post Implementation Review after Project Closure  \t" + DisplayYesNo(currentProjectOfficeChecklistModel.ServicesClosureOrganizing)
                           + "\nCommunicating the results of the review to the appropriate project stakeholders  \t" + DisplayYesNo(currentProjectOfficeChecklistModel.ServicesComminicating));





                        checklistTable.SetWidths(new float[] { 1000 });
                        document.InsertTable(checklistTable);

                        //Save the document
                        try
                        {
                            document.Save();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("The selected File is open.", "Close File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                }
            }
        }
        */
    }
}
