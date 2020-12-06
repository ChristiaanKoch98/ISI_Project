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
    public partial class SelectionProcess : Form
    {
        ProjectManagementToolkit.Utility.VersionControl<ProjectManagementToolkit.MPMM.MPMM_Document_Models.SelectionProcessModel> versionControl;
        ProjectManagementToolkit.MPMM.MPMM_Document_Models.SelectionProcessModel newSelectionProcessModel;
        ProjectManagementToolkit.MPMM.MPMM_Document_Models.SelectionProcessModel currentSelectionProcessModel;
        Color TABLE_HEADER_COLOR = Color.FromArgb(73, 173, 252);
        ProjectManagementToolkit.Utility.ProjectModel projectModel = new ProjectManagementToolkit.Utility.ProjectModel();
        public SelectionProcess()
        {
            InitializeComponent();
        }

        private void SelectionProcess_Load(object sender, EventArgs e)
        {
            loadDocument();
            string json = JsonHelper.loadProjectInfo(Settings.Default.Username);
            List<ProjectModel> projectListModel = JsonConvert.DeserializeObject<List<ProjectModel>>(json);
            projectModel = projectModel.getProjectModel(Settings.Default.ProjectID, projectListModel);

            //Data info need here I feel
        }
        public void saveDocument()
        {
            List<SelectionProcessModel.Schedule> schedules = new List<SelectionProcessModel.Schedule>();
            int versionRowsCount = scheduleDataGridView.Rows.Count;
            for (int i = 0; i < versionRowsCount - 1; i++)
            {
                SelectionProcessModel.Schedule schdeuleModel = new SelectionProcessModel.Schedule();
                var phase = scheduleDataGridView.Rows[i].Cells[0].Value?.ToString() ?? "";
                var activity = scheduleDataGridView.Rows[i].Cells[1].Value?.ToString() ?? "";
                var task = scheduleDataGridView.Rows[i].Cells[2].Value?.ToString() ?? "";
                var date = scheduleDataGridView.Rows[i].Cells[3].Value?.ToString() ?? "";
                schdeuleModel.Phase = phase;
                schdeuleModel.Activity = activity;
                schdeuleModel.Task = task;
                schdeuleModel.Date = date;
                schedules.Add(schdeuleModel);
            }
            newSelectionProcessModel.Schedules = schedules;

            List<SelectionProcessModel.Labour> labours = new List<SelectionProcessModel.Labour>();
            for (int i = 0; i < versionRowsCount - 1; i++)
            {
                SelectionProcessModel.Labour labourModel = new SelectionProcessModel.Labour();
                var role = laborDataGridView.Rows[i].Cells[0].Value?.ToString() ?? "";
                var number = laborDataGridView.Rows[i].Cells[1].Value?.ToString() ?? "";
                var responsibilities = laborDataGridView.Rows[i].Cells[2].Value?.ToString() ?? "";
                var skills = laborDataGridView.Rows[i].Cells[3].Value?.ToString() ?? "";
                var startDate = laborDataGridView.Rows[i].Cells[4].Value?.ToString() ?? "";
                var endDate = laborDataGridView.Rows[i].Cells[5].Value?.ToString() ?? "";
                labourModel.Role = role;
                labourModel.Number = number;
                labourModel.Responsibilities = responsibilities;
                labourModel.Skills = skills;
                labourModel.StartDate = startDate;
                labourModel.EndDate = endDate;
                labours.Add(labourModel);
            }
            newSelectionProcessModel.Labours = labours;

            List<SelectionProcessModel.Equipment> equipments = new List<SelectionProcessModel.Equipment>();
            for (int i = 0; i < versionRowsCount - 1; i++)
            {
                SelectionProcessModel.Equipment equipmentModel = new SelectionProcessModel.Equipment();
                var item = EquipmentDataGridView.Rows[i].Cells[0].Value?.ToString() ?? "";
                var amount = EquipmentDataGridView.Rows[i].Cells[1].Value?.ToString() ?? "";
                var purpose = EquipmentDataGridView.Rows[i].Cells[2].Value?.ToString() ?? "";
                var specification = EquipmentDataGridView.Rows[i].Cells[3].Value?.ToString() ?? "";
                var startDate = EquipmentDataGridView.Rows[i].Cells[4].Value?.ToString() ?? "";
                var endDate = EquipmentDataGridView.Rows[i].Cells[5].Value?.ToString() ?? "";
                equipmentModel.Item = item;
                equipmentModel.Amount = amount;
                equipmentModel.Purpose = purpose;
                equipmentModel.Specification = specification;
                equipmentModel.StartDate = startDate;
                equipmentModel.EndDate = endDate;
                equipments.Add(equipmentModel);
            }
            newSelectionProcessModel.Equipments = equipments;

            List<SelectionProcessModel.Material> materials = new List<SelectionProcessModel.Material>();
            for (int i = 0; i < versionRowsCount - 1; i++)
            {
                SelectionProcessModel.Material materialModel = new SelectionProcessModel.Material();
                var item = materialdDataGridView.Rows[i].Cells[0].Value?.ToString() ?? "";
                var amount = materialdDataGridView.Rows[i].Cells[1].Value?.ToString() ?? "";
                var startDate = materialdDataGridView.Rows[i].Cells[2].Value?.ToString() ?? "";
                var endDate = materialdDataGridView.Rows[i].Cells[3].Value?.ToString() ?? "";
                materialModel.Item = item;
                materialModel.Amount = amount;
                materialModel.StartDate = startDate;
                materialModel.EndDate = endDate;
                materials.Add(materialModel);
            }
            newSelectionProcessModel.Materials = materials;

            List<SelectionProcessModel.ResourcesSchedule> resourcesSchedules = new List<SelectionProcessModel.ResourcesSchedule>();
            for (int i = 0; i < versionRowsCount - 1; i++)
            {
                SelectionProcessModel.ResourcesSchedule resourceScheduleModel = new SelectionProcessModel.ResourcesSchedule();
                var resource = echeduleDataGridView.Rows[i].Cells[0].Value?.ToString() ?? "";
                var jan = echeduleDataGridView.Rows[i].Cells[1].Value?.ToString() ?? "";
                var feb = echeduleDataGridView.Rows[i].Cells[2].Value?.ToString() ?? "";
                var mar = echeduleDataGridView.Rows[i].Cells[3].Value?.ToString() ?? "";
                var apr = echeduleDataGridView.Rows[i].Cells[4].Value?.ToString() ?? "";
                var may = echeduleDataGridView.Rows[i].Cells[5].Value?.ToString() ?? "";
                var jun = echeduleDataGridView.Rows[i].Cells[6].Value?.ToString() ?? "";
                var jul = echeduleDataGridView.Rows[i].Cells[7].Value?.ToString() ?? "";
                var aug = echeduleDataGridView.Rows[i].Cells[8].Value?.ToString() ?? "";
                var sep = echeduleDataGridView.Rows[i].Cells[9].Value?.ToString() ?? "";
                var oct = echeduleDataGridView.Rows[i].Cells[10].Value?.ToString() ?? "";
                var nov = echeduleDataGridView.Rows[i].Cells[11].Value?.ToString() ?? "";
                var dec = echeduleDataGridView.Rows[i].Cells[12].Value?.ToString() ?? "";
                var total = echeduleDataGridView.Rows[i].Cells[13].Value?.ToString() ?? "";
                resourceScheduleModel.Resource = resource;
                resourceScheduleModel.Jan = jan;
                resourceScheduleModel.Feb = feb;
                resourceScheduleModel.Mar = mar;
                resourceScheduleModel.Apr = apr;
                resourceScheduleModel.May = may;
                resourceScheduleModel.Jun = jun;
                resourceScheduleModel.Jul = jul;
                resourceScheduleModel.Aug = aug;
                resourceScheduleModel.Sep = sep;
                resourceScheduleModel.Oct = oct;
                resourceScheduleModel.Nov = nov;
                resourceScheduleModel.Dec = dec;
                resourceScheduleModel.Total = total;
                resourcesSchedules.Add(resourceScheduleModel);
            }
            newSelectionProcessModel.ResourcesSchedules = resourcesSchedules;

            List<SelectionProcessModel.RiskIdentification> riskIdentifications = new List<SelectionProcessModel.RiskIdentification>();
            for (int i = 0; i < versionRowsCount - 1; i++)
            {
                SelectionProcessModel.RiskIdentification riskIdentificationModel = new SelectionProcessModel.RiskIdentification();
                var riskdescription = RiskDataGridView.Rows[i].Cells[0].Value?.ToString() ?? "";
                var probability = RiskDataGridView.Rows[i].Cells[1].Value?.ToString() ?? "";
                var likelihood = RiskDataGridView.Rows[i].Cells[2].Value?.ToString() ?? "";
                var impactofrisk = RiskDataGridView.Rows[i].Cells[3].Value?.ToString() ?? "";
                var qualitativequantative = RiskDataGridView.Rows[i].Cells[4].Value?.ToString() ?? "";
                var riskowner = RiskDataGridView.Rows[i].Cells[5].Value?.ToString() ?? "";
                riskIdentificationModel.RiskDescription = riskdescription;
                riskIdentificationModel.Probability = probability;
                riskIdentificationModel.Likelihood = likelihood;
                riskIdentificationModel.ImpactofRisk = impactofrisk;
                riskIdentificationModel.QualitativQuantative = qualitativequantative;
                riskIdentificationModel.RiskOwner = riskowner;
                riskIdentifications.Add(riskIdentificationModel);
            }
            newSelectionProcessModel.RiskIdentifications = riskIdentifications;

            List<SelectionProcessModel.RiskResponsePlanning> riskResponsePlannings = new List<SelectionProcessModel.RiskResponsePlanning>();
            for (int i = 0; i < versionRowsCount - 1; i++)
            {
                SelectionProcessModel.RiskResponsePlanning riskResponseModel = new SelectionProcessModel.RiskResponsePlanning();
                var riskdescription = riskResponseDataGridView.Rows[i].Cells[0].Value?.ToString() ?? "";
                var riskcategory = riskResponseDataGridView.Rows[i].Cells[1].Value?.ToString() ?? "";
                var riskresponsestrategy = riskResponseDataGridView.Rows[i].Cells[2].Value?.ToString() ?? "";
                riskResponseModel.RiskDescription = riskdescription;
                riskResponseModel.RiskCategory = riskcategory;
                riskResponseModel.RiskResponseStrategy = riskresponsestrategy;
                riskResponsePlannings.Add(riskResponseModel);
            }
            newSelectionProcessModel.RiskResponsePlannings = riskResponsePlannings;

            List<SelectionProcessModel.ResourceAvaliabilityandAllocation> resourceavaliabilityandallocation = new List<SelectionProcessModel.ResourceAvaliabilityandAllocation>();
            for (int i = 0; i < versionRowsCount - 1; i++)
            {
                SelectionProcessModel.ResourceAvaliabilityandAllocation resourceavaliabilityandallocationModel = new SelectionProcessModel.ResourceAvaliabilityandAllocation();
                var avaliability = ResourceDataGridView.Rows[i].Cells[0].Value?.ToString() ?? "";
                var allocation = ResourceDataGridView.Rows[i].Cells[1].Value?.ToString() ?? "";
                var sizeofproject = ResourceDataGridView.Rows[i].Cells[2].Value?.ToString() ?? "";
                resourceavaliabilityandallocationModel.Avaliability = avaliability;
                resourceavaliabilityandallocationModel.Allocation = allocation;
                resourceavaliabilityandallocationModel.SizeofProject = sizeofproject;
                resourceavaliabilityandallocation.Add(resourceavaliabilityandallocationModel);
            }
            newSelectionProcessModel.ResourceAvaliabilityandAllocations = resourceavaliabilityandallocation;

            List<SelectionProcessModel.StrategyAlingment> strategyalingments = new List<SelectionProcessModel.StrategyAlingment>();
            for (int i = 0; i < versionRowsCount - 1; i++)
            {
                SelectionProcessModel.StrategyAlingment strategyalingmentsModel = new SelectionProcessModel.StrategyAlingment();
                var strategyplan = strategyDataGridView.Rows[i].Cells[0].Value?.ToString() ?? "";
                var needsoppurtunites = strategyDataGridView.Rows[i].Cells[1].Value?.ToString() ?? "";
                var setresources = strategyDataGridView.Rows[i].Cells[2].Value?.ToString() ?? "";
                var setbudgetneeds = strategyDataGridView.Rows[i].Cells[3].Value?.ToString() ?? "";
                var setriskposture = strategyDataGridView.Rows[i].Cells[4].Value?.ToString() ?? "";
                strategyalingmentsModel.StrategyPlan = strategyplan;
                strategyalingmentsModel.NeedsOppurtunities = needsoppurtunites;
                strategyalingmentsModel.SetResources = setresources;
                strategyalingmentsModel.SetBudgetNeed = setbudgetneeds;
                strategyalingmentsModel.SetRiskPosture = setriskposture;
                strategyalingments.Add(strategyalingmentsModel);
            }
            newSelectionProcessModel.StrategyAlingments = strategyalingments;

            List<SelectionProcessModel.Balancing> balancings = new List<SelectionProcessModel.Balancing>();
            for (int i = 0; i < versionRowsCount - 1; i++)
            {
                SelectionProcessModel.Balancing balancingModel = new SelectionProcessModel.Balancing();
                var balancingofprojects = balancingDataGridView.Rows[i].Cells[0].Value?.ToString() ?? "";
                var purposeandbenefit = balancingDataGridView.Rows[i].Cells[1].Value?.ToString() ?? "";
                var oppurtunitybenefitrisk = balancingDataGridView.Rows[i].Cells[2].Value?.ToString() ?? "";
                var purposebenefit = balancingDataGridView.Rows[i].Cells[3].Value?.ToString() ?? "";
                balancingModel.BalancingofProjects = balancingofprojects;
                balancingModel.PurposeandBenefit = purposeandbenefit;
                balancingModel.OppurtunityBenefitRisk = oppurtunitybenefitrisk;
                balancingModel.PurposeBenefit = purposebenefit;
                balancings.Add(balancingModel);
            }
            newSelectionProcessModel.Balancings = balancings;

            newSelectionProcessModel.Cost = costTextBox.Text;
            newSelectionProcessModel.RiskMonitoringandControl = riskMonitorigTextBox.Text;

            /*List<VersionControl<SelectionProcessModel>.DocumentModel> documentModels = versionControl.DocumentModels;


            if (!versionControl.isEqual(currentSelectionProcessModel, newSelectionProcessModel))
            {
                VersionControl<SelectionProcessModel>.DocumentModel documentModel = new VersionControl<ProjectPlanModel>.DocumentModel(newSelectionProcessModel, DateTime.Now, VersionControl<ProjectModel>.generateID());

                documentModels.Add(documentModel);

                versionControl.DocumentModels = documentModels;
                string json = JsonConvert.SerializeObject(versionControl);
                currentSelectionProcessModel = JsonConvert.DeserializeObject<ProjectPlanModel>(JsonConvert.SerializeObject(newSelectionProcessModel));
                JsonHelper.saveDocument(json, Settings.Default.ProjectID, "ProjectPlan");
                MessageBox.Show("Project plan saved successfully", "save", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("No changes was made!", "save", MessageBoxButtons.OK);
            }*/

        }
        private void loadDocument()
        {
            string json = JsonHelper.loadDocument(Settings.Default.ProjectID, "SelectionProcess");
            List<string[]> documentInfo = new List<string[]>();
            newSelectionProcessModel = new SelectionProcessModel();
            currentSelectionProcessModel = new SelectionProcessModel();
            if (json != "")
            {
                /*versionControl = JsonConvert.DeserializeObject<VersionControl<ProjectPlanModel>>(json);
                newSelectionProcessModel = JsonConvert.DeserializeObject<ProjectPlanModel>(versionControl.getLatest(versionControl.DocumentModels));
                currentSelectionProcessModel = JsonConvert.DeserializeObject<ProjectPlanModel>(versionControl.getLatest(versionControl.DocumentModels));
                
                documentInfo.Add(new string[] { "Document ID", currentProjectPlanModel.DocumentID });
                documentInfo.Add(new string[] { "Document Owner", currentProjectPlanModel.DocumentOwner });
                documentInfo.Add(new string[] { "Issue Date", currentProjectPlanModel.IssueDate });
                documentInfo.Add(new string[] { "Last Save Date", currentProjectPlanModel.LastSavedDate });
                documentInfo.Add(new string[] { "File Name", currentProjectPlanModel.FileName });*/

                foreach (var row in currentSelectionProcessModel.Schedules)
                {
                    scheduleDataGridView.Rows.Add(new string[] { row.Phase, row.Activity, row.Task, row.Date });
                }

                foreach (var row in currentSelectionProcessModel.Labours)
                {
                    laborDataGridView.Rows.Add(new string[] { row.Role, row.Number, row.Responsibilities, row.Skills, row.StartDate, row.EndDate });
                }

                foreach (var row in currentSelectionProcessModel.Equipments)
                {
                    EquipmentDataGridView.Rows.Add(new string[] { row.Item, row.Amount, row.Purpose, row.Specification, row.StartDate, row.EndDate });
                }

                foreach (var row in currentSelectionProcessModel.Materials)
                {
                    materialdDataGridView.Rows.Add(new string[] { row.Item, row.Amount, row.StartDate, row.EndDate });
                }

                foreach (var row in currentSelectionProcessModel.ResourcesSchedules)
                {
                    echeduleDataGridView.Rows.Add(new string[] { row.Resource, row.Jan, row.Feb, row.Mar, row.Apr, row.May, row.Jun, row.Jul, row.Aug, row.Sep, row.Oct, row.Nov, row.Dec, row.Total });
                }

                foreach (var row in currentSelectionProcessModel.RiskIdentifications)
                {
                    RiskDataGridView.Rows.Add(new string[] { row.RiskDescription, row.Probability, row.Likelihood, row.ImpactofRisk, row.QualitativQuantative, row.RiskOwner });
                }

                foreach (var row in currentSelectionProcessModel.RiskResponsePlannings)
                {
                    riskResponseDataGridView.Rows.Add(new string[] { row.RiskDescription, row.RiskCategory, row.RiskResponseStrategy });
                }

                foreach (var row in currentSelectionProcessModel.ResourceAvaliabilityandAllocations)
                {
                    ResourceDataGridView.Rows.Add(new string[] { row.Avaliability, row.Allocation, row.SizeofProject });
                }

                foreach (var row in currentSelectionProcessModel.StrategyAlingments)
                {
                    strategyDataGridView.Rows.Add(new string[] { row.StrategyPlan, row.NeedsOppurtunities, row.SetResources, row.SetBudgetNeed, row.SetRiskPosture });
                }

                foreach (var row in currentSelectionProcessModel.Balancings)
                {
                    balancingDataGridView.Rows.Add(new string[] { row.BalancingofProjects, row.PurposeandBenefit, row.OppurtunityBenefitRisk, row.PurposeBenefit });
                }

                costTextBox.Text = newSelectionProcessModel.Cost;
                riskMonitorigTextBox.Text = newSelectionProcessModel.RiskMonitoringandControl;

            }
            else
            {
                versionControl = new VersionControl<SelectionProcessModel>();
                versionControl.DocumentModels = new List<VersionControl<SelectionProcessModel>.DocumentModel>();
                documentInfo.Add(new string[] { "Document ID", "" });
                documentInfo.Add(new string[] { "Document Owner", "" });
                documentInfo.Add(new string[] { "Issue Date", "" });
                documentInfo.Add(new string[] { "Last Save Date", "" });
                documentInfo.Add(new string[] { "File Name", "" });
                newSelectionProcessModel = new SelectionProcessModel();
                /*foreach (var row in documentInfo)
                {
                    documentInformation.Rows.Add(row);
                }
                documentInformation.AllowUserToAddRows = false;*/
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
                        document.InsertParagraph("Project Plan \nFor " + projectModel.ProjectName)
                           .Font("Arial")
                           .Bold(true)
                           .FontSize(22d).Alignment = Alignment.left;
                        document.InsertSectionPageBreak();
                        var p = document.InsertParagraph();
                        var title = p.InsertParagraphBeforeSelf("Table of Contents").Bold().FontSize(20);

                        var tocSwitches = new Dictionary<TableOfContentsSwitches, string>()
                        {
                            { TableOfContentsSwitches.O, "1-6"},
                            { TableOfContentsSwitches.U, ""},
                            { TableOfContentsSwitches.Z, ""},
                            { TableOfContentsSwitches.H, ""}
                        };

                        document.InsertTableOfContents(p, "", tocSwitches);
                        document.InsertParagraph().InsertPageBreakAfterSelf();
                        var OverviewHeading = document.InsertParagraph("1 Overview")
                            .Bold()
                            .FontSize(14d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        OverviewHeading.StyleId = "Heading1";

                        var PeriodicMeasurementHeading = document.InsertParagraph("2 Periodic Measurement")
                           .Bold()
                           .FontSize(12d)
                           .Color(Color.Black)
                           .Bold(true)
                           .Font("Arial");

                        PeriodicMeasurementHeading.StyleId = "Heading1";

                        var PMSchedule = document.InsertParagraph("2.1 Schedule")
                           .Bold()
                           .FontSize(12d)
                           .Color(Color.Black)
                           .Bold(true)
                           .Font("Arial");

                        PMSchedule.StyleId = "Heading2";

                        var documentPmScheduleTable = document.AddTable(currentSelectionProcessModel.Schedules.Count + 1, 3);
                        documentPmScheduleTable.Rows[0].Cells[0].Paragraphs[0].Append("Phase")
                            .Bold(true)
                            .Color(Color.White);
                        documentPmScheduleTable.Rows[0].Cells[1].Paragraphs[0].Append("Activity")
                            .Bold(true)
                            .Color(Color.White);
                        documentPmScheduleTable.Rows[0].Cells[2].Paragraphs[0].Append("Task")
                            .Bold(true)
                            .Color(Color.White);
                        documentPmScheduleTable.Rows[0].Cells[3].Paragraphs[0].Append("Date")
                            .Bold(true)
                            .Color(Color.White);

                        var PMCost = document.InsertParagraph("2.2 Cost")
                           .Bold()
                           .FontSize(12d)
                           .Color(Color.Black)
                           .Bold(true)
                           .Font("Arial");

                        document.InsertParagraph(currentSelectionProcessModel.Cost)
                           .FontSize(11d)
                           .Color(Color.Black)
                           .Font("Arial").Alignment = Alignment.left;

                        PMCost.StyleId = "Heading2";

                        var PMResource = document.InsertParagraph("2.3 Resource")
                           .Bold()
                           .FontSize(12d)
                           .Color(Color.Black)
                           .Bold(true)
                           .Font("Arial");

                        PMResource.StyleId = "Heading2";

                        var PMResourceLabour = document.InsertParagraph("2.3.1 Resource Labour")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        PMResourceLabour.StyleId = "Heading3";

                        var documentResourceLabourTable = document.AddTable(currentSelectionProcessModel.Labours.Count + 1, 3);
                        documentResourceLabourTable.Rows[0].Cells[0].Paragraphs[0].Append("Role")
                            .Bold(true)
                            .Color(Color.White);
                        documentResourceLabourTable.Rows[0].Cells[1].Paragraphs[0].Append("Number")
                            .Bold(true)
                            .Color(Color.White);
                        documentResourceLabourTable.Rows[0].Cells[2].Paragraphs[0].Append("Responsibilities")
                            .Bold(true)
                            .Color(Color.White);
                        documentResourceLabourTable.Rows[0].Cells[3].Paragraphs[0].Append("Skills")
                            .Bold(true)
                            .Color(Color.White);
                        documentResourceLabourTable.Rows[0].Cells[4].Paragraphs[0].Append("Start Date")
                            .Bold(true)
                            .Color(Color.White);
                        documentResourceLabourTable.Rows[0].Cells[5].Paragraphs[0].Append("End Date")
                            .Bold(true)
                            .Color(Color.White);

                        var PMResourceEquipment = document.InsertParagraph("2.3.2 Resource Equipment")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        PMResourceEquipment.StyleId = "Heading3";

                        var documentResourceEquipmentTable = document.AddTable(currentSelectionProcessModel.Equipments.Count + 1, 3);
                        documentResourceEquipmentTable.Rows[0].Cells[0].Paragraphs[0].Append("Item")
                            .Bold(true)
                            .Color(Color.White);
                        documentResourceEquipmentTable.Rows[0].Cells[1].Paragraphs[0].Append("Amount")
                            .Bold(true)
                            .Color(Color.White);
                        documentResourceEquipmentTable.Rows[0].Cells[2].Paragraphs[0].Append("Purpose")
                            .Bold(true)
                            .Color(Color.White);
                        documentResourceEquipmentTable.Rows[0].Cells[3].Paragraphs[0].Append("Specification")
                            .Bold(true)
                            .Color(Color.White);
                        documentResourceEquipmentTable.Rows[0].Cells[4].Paragraphs[0].Append("Start Date")
                            .Bold(true)
                            .Color(Color.White);
                        documentResourceEquipmentTable.Rows[0].Cells[5].Paragraphs[0].Append("End Date")
                            .Bold(true)
                            .Color(Color.White);

                        var PMResourceMaterial = document.InsertParagraph("2.3.3 Resource Material")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        PMResourceMaterial.StyleId = "Heading3";

                        var documentResourceMaterialTable = document.AddTable(currentSelectionProcessModel.Materials.Count + 1, 3);
                        documentResourceMaterialTable.Rows[0].Cells[0].Paragraphs[0].Append("Item")
                            .Bold(true)
                            .Color(Color.White);
                        documentResourceMaterialTable.Rows[0].Cells[1].Paragraphs[0].Append("Amount")
                            .Bold(true)
                            .Color(Color.White);
                        documentResourceMaterialTable.Rows[0].Cells[2].Paragraphs[0].Append("Start Date")
                            .Bold(true)
                            .Color(Color.White);
                        documentResourceMaterialTable.Rows[0].Cells[3].Paragraphs[0].Append("End Date")
                            .Bold(true)
                            .Color(Color.White);

                        var PMResourceSchedule = document.InsertParagraph("2.3.4 Resource Schedule")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        PMResourceSchedule.StyleId = "Heading3";

                        var documentResourceScheduleTable = document.AddTable(currentSelectionProcessModel.ResourcesSchedules.Count + 1, 3);
                        documentResourceScheduleTable.Rows[0].Cells[0].Paragraphs[0].Append("Resource")
                            .Bold(true)
                            .Color(Color.White);
                        documentResourceScheduleTable.Rows[0].Cells[1].Paragraphs[0].Append("Jan")
                            .Bold(true)
                            .Color(Color.White);
                        documentResourceScheduleTable.Rows[0].Cells[2].Paragraphs[0].Append("Feb")
                            .Bold(true)
                            .Color(Color.White);
                        documentResourceScheduleTable.Rows[0].Cells[3].Paragraphs[0].Append("Mar")
                            .Bold(true)
                            .Color(Color.White);
                        documentResourceScheduleTable.Rows[0].Cells[4].Paragraphs[0].Append("Apr")
                            .Bold(true)
                            .Color(Color.White);
                        documentResourceScheduleTable.Rows[0].Cells[5].Paragraphs[0].Append("May")
                            .Bold(true)
                            .Color(Color.White);
                        documentResourceScheduleTable.Rows[0].Cells[6].Paragraphs[0].Append("Jun")
                            .Bold(true)
                            .Color(Color.White);
                        documentResourceScheduleTable.Rows[0].Cells[7].Paragraphs[0].Append("Jul")
                            .Bold(true)
                            .Color(Color.White);
                        documentResourceScheduleTable.Rows[0].Cells[8].Paragraphs[0].Append("Aug")
                            .Bold(true)
                            .Color(Color.White);
                        documentResourceScheduleTable.Rows[0].Cells[9].Paragraphs[0].Append("Sep")
                            .Bold(true)
                            .Color(Color.White);
                        documentResourceScheduleTable.Rows[0].Cells[10].Paragraphs[0].Append("Oct")
                            .Bold(true)
                            .Color(Color.White);
                        documentResourceScheduleTable.Rows[0].Cells[11].Paragraphs[0].Append("Nov")
                            .Bold(true)
                            .Color(Color.White);
                        documentResourceScheduleTable.Rows[0].Cells[12].Paragraphs[0].Append("Dec")
                            .Bold(true)
                            .Color(Color.White);
                        documentResourceScheduleTable.Rows[0].Cells[13].Paragraphs[0].Append("Total")
                            .Bold(true)
                            .Color(Color.White);

                        var RiskASsessmentHeading = document.InsertParagraph("3 Risk Assessment")
                           .Bold()
                           .FontSize(12d)
                           .Color(Color.Black)
                           .Bold(true)
                           .Font("Arial");

                        RiskASsessmentHeading.StyleId = "Heading1";

                        var RARiskIdentification = document.InsertParagraph("3.1 Risk Identification")
                           .Bold()
                           .FontSize(12d)
                           .Color(Color.Black)
                           .Bold(true)
                           .Font("Arial");

                        RARiskIdentification.StyleId = "Heading2";

                        var documentRiskIdentificationTable = document.AddTable(currentSelectionProcessModel.RiskIdentifications.Count + 1, 3);
                        documentRiskIdentificationTable.Rows[0].Cells[0].Paragraphs[0].Append("Risk Description")
                            .Bold(true)
                            .Color(Color.White);
                        documentRiskIdentificationTable.Rows[0].Cells[1].Paragraphs[0].Append("Probability(0-1)")
                            .Bold(true)
                            .Color(Color.White);
                        documentRiskIdentificationTable.Rows[0].Cells[2].Paragraphs[0].Append("Likelihood(Low/Med/High)")
                            .Bold(true)
                            .Color(Color.White);
                        documentRiskIdentificationTable.Rows[0].Cells[3].Paragraphs[0].Append("Impact of risk if it occurs")
                            .Bold(true)
                            .Color(Color.White);
                        documentRiskIdentificationTable.Rows[0].Cells[4].Paragraphs[0].Append("Qualitative/Quantitative Assessment")
                            .Bold(true)
                            .Color(Color.White);
                        documentRiskIdentificationTable.Rows[0].Cells[5].Paragraphs[0].Append("Risk Owner")
                            .Bold(true)
                            .Color(Color.White);

                        var RARiskResponsePlanning = document.InsertParagraph("3.2 Risk Response Planning")
                           .Bold()
                           .FontSize(12d)
                           .Color(Color.Black)
                           .Bold(true)
                           .Font("Arial");

                        RARiskResponsePlanning.StyleId = "Heading2";

                        var documentRiskResponsePlanningTable = document.AddTable(currentSelectionProcessModel.RiskResponsePlannings.Count + 1, 3);
                        documentRiskResponsePlanningTable.Rows[0].Cells[0].Paragraphs[0].Append("Risk Description")
                            .Bold(true)
                            .Color(Color.White);
                        documentRiskResponsePlanningTable.Rows[0].Cells[1].Paragraphs[0].Append("Risk Category")
                            .Bold(true)
                            .Color(Color.White);
                        documentRiskResponsePlanningTable.Rows[0].Cells[2].Paragraphs[0].Append("Risk Response Strategy")
                            .Bold(true)
                            .Color(Color.White);

                        var RARiskMonitoringandControl = document.InsertParagraph("3.3 Risk Monitoring and Control")
                           .Bold()
                           .FontSize(12d)
                           .Color(Color.Black)
                           .Bold(true)
                           .Font("Arial");

                        document.InsertParagraph(currentSelectionProcessModel.RiskMonitoringandControl)
                           .FontSize(11d)
                           .Color(Color.Black)
                           .Font("Arial").Alignment = Alignment.left;

                        RARiskMonitoringandControl.StyleId = "Heading2";

                        var ResourceAvaliabilityandAllocationHeading = document.InsertParagraph("4 Resource Avaliability and Allocation")
                          .Bold()
                          .FontSize(12d)
                          .Color(Color.Black)
                          .Bold(true)
                          .Font("Arial");

                        ResourceAvaliabilityandAllocationHeading.StyleId = "Heading1";

                        var documentResourceAvaliabilityandAllocationTable = document.AddTable(currentSelectionProcessModel.ResourceAvaliabilityandAllocations.Count + 1, 3);
                        documentResourceAvaliabilityandAllocationTable.Rows[0].Cells[0].Paragraphs[0].Append("Avaliability(In-House, Outsourced)")
                            .Bold(true)
                            .Color(Color.White);
                        documentResourceAvaliabilityandAllocationTable.Rows[0].Cells[1].Paragraphs[0].Append("Allocation(Committed, Soft Allocation)")
                            .Bold(true)
                            .Color(Color.White);
                        documentResourceAvaliabilityandAllocationTable.Rows[0].Cells[2].Paragraphs[0].Append("Optimal or Acceptable size of project")
                            .Bold(true)
                            .Color(Color.White);

                        var StrategyAlignmentHeading = document.InsertParagraph("5 Strategy Alignment")
                          .Bold()
                          .FontSize(12d)
                          .Color(Color.Black)
                          .Bold(true)
                          .Font("Arial");

                        StrategyAlignmentHeading.StyleId = "Heading1";

                        var documentStrategyAlignmentTable = document.AddTable(currentSelectionProcessModel.StrategyAlingments.Count + 1, 3);
                        documentStrategyAlignmentTable.Rows[0].Cells[0].Paragraphs[0].Append("Strategy Plan Parameters")
                            .Bold(true)
                            .Color(Color.White);
                        documentStrategyAlignmentTable.Rows[0].Cells[1].Paragraphs[0].Append("Needs/Oppurtunities")
                            .Bold(true)
                            .Color(Color.White);
                        documentStrategyAlignmentTable.Rows[0].Cells[2].Paragraphs[0].Append("Set Resource")
                            .Bold(true)
                            .Color(Color.White);
                        documentStrategyAlignmentTable.Rows[0].Cells[3].Paragraphs[0].Append("Set Budget Need")
                            .Bold(true)
                            .Color(Color.White);
                        documentStrategyAlignmentTable.Rows[0].Cells[4].Paragraphs[0].Append("Set Risk Posture")
                            .Bold(true)
                            .Color(Color.White);

                        var BalancingHeading = document.InsertParagraph("6 Balancing")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        BalancingHeading.StyleId = "Heading1";

                        var documentBalancingTable = document.AddTable(currentSelectionProcessModel.Balancings.Count + 1, 3);
                        documentBalancingTable.Rows[0].Cells[0].Paragraphs[0].Append("Balancing different types of projects by")
                            .Bold(true)
                            .Color(Color.White);
                        documentBalancingTable.Rows[0].Cells[1].Paragraphs[0].Append("Purpose and Benefit")
                            .Bold(true)
                            .Color(Color.White);
                        documentBalancingTable.Rows[0].Cells[2].Paragraphs[0].Append("Oppurtunities, benefits and risk")
                            .Bold(true)
                            .Color(Color.White);
                        documentBalancingTable.Rows[0].Cells[3].Paragraphs[0].Append("Purpose and Benefit")
                            .Bold(true)
                            .Color(Color.White);

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

        private void savebutton_Click(object sender, EventArgs e)
        {
            saveDocument();
        }

        private void exportToWordbutton_Click(object sender, EventArgs e)
        {
            exportToWord();
        }
    }
}
