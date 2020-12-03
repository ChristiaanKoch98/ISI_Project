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
    public partial class ResourcePlanDocumentForm : Form
    {
        VersionControl<ResourcePlanModel> versionControl;
        ResourcePlanModel newResourcePlanModel;
        ResourcePlanModel currentResourcePlanModel;
        Color TABLE_HEADER_COLOR = Color.FromArgb(73, 173, 252);
        ProjectModel projectModel = new ProjectModel();

        public ResourcePlanDocumentForm()
        {
            InitializeComponent();
        }

        public void saveDocument()
        {
            newResourcePlanModel.ProjectName = textBoxProjectName.Text;
            newResourcePlanModel.DocumentID = docInfodataGridView.Rows[0].Cells[1].Value.ToString();
            newResourcePlanModel.DocumentOwner = docInfodataGridView.Rows[1].Cells[1].Value.ToString();
            newResourcePlanModel.IssueDate = docInfodataGridView.Rows[2].Cells[1].Value.ToString();
            newResourcePlanModel.LastSavedDate = docInfodataGridView.Rows[3].Cells[1].Value.ToString();
            newResourcePlanModel.FileName = docInfodataGridView.Rows[4].Cells[1].Value.ToString();

            List<ResourcePlanModel.DocumentHistory> documentHistories = new List<ResourcePlanModel.DocumentHistory>();

            int versionRowsCount = docHistdataGridView.Rows.Count;

            for (int i = 0; i < versionRowsCount - 1; i++)
            {
                ResourcePlanModel.DocumentHistory documentHistoryModel = new ResourcePlanModel.DocumentHistory();
                var version = docHistdataGridView.Rows[i].Cells[0].Value?.ToString() ?? "";
                var issueDate = docHistdataGridView.Rows[i].Cells[1].Value?.ToString() ?? "";
                var changes = docHistdataGridView.Rows[i].Cells[2].Value?.ToString() ?? "";
                documentHistoryModel.Version = version;
                documentHistoryModel.IssueDate = issueDate;
                documentHistoryModel.Changes = changes;
                documentHistories.Add(documentHistoryModel);
            }
            newResourcePlanModel.DocumentHistories = documentHistories;

            List<ResourcePlanModel.DocumentApproval> documentApprovalsModel = new List<ResourcePlanModel.DocumentApproval>();

            int approvalRowsCount = docApprovalsdataGridView.Rows.Count;

            for (int i = 0; i < approvalRowsCount - 1; i++)
            {
                ResourcePlanModel.DocumentApproval documentApproval = new ResourcePlanModel.DocumentApproval();
                var role = docApprovalsdataGridView.Rows[i].Cells[0].Value?.ToString() ?? "";
                var name = docApprovalsdataGridView.Rows[i].Cells[1].Value?.ToString() ?? "";
                var signature = docApprovalsdataGridView.Rows[i].Cells[2].Value?.ToString() ?? "";
                var date = docApprovalsdataGridView.Rows[i].Cells[3].Value?.ToString() ?? "";
                documentApproval.Role = role;
                documentApproval.Name = name;
                documentApproval.Signature = signature;
                documentApproval.DateApproved = date;

                documentApprovalsModel.Add(documentApproval);
            }
            newResourcePlanModel.DocumentApprovals = documentApprovalsModel;


            List<ResourcePlanModel.Labor> documentLaborModel = new List<ResourcePlanModel.Labor>();

            int laborRowsCount = laborDataGridView.Rows.Count;

            for (int i = 0; i < laborRowsCount - 1; i++)
            {
                ResourcePlanModel.Labor documentLabor = new ResourcePlanModel.Labor();
                var role = laborDataGridView.Rows[i].Cells[0].Value?.ToString() ?? "";
                var number = laborDataGridView.Rows[i].Cells[1].Value?.ToString() ?? "";
                var responsibility = laborDataGridView.Rows[i].Cells[2].Value?.ToString() ?? "";
                var skill = laborDataGridView.Rows[i].Cells[3].Value?.ToString() ?? "";
                var startDate = laborDataGridView.Rows[i].Cells[4].Value?.ToString() ?? "";      //HIERSO
                var endDate = laborDataGridView.Rows[i].Cells[5].Value?.ToString() ?? "";
                documentLabor.Role = role;
                documentLabor.Number = number;
                documentLabor.Responsibility = responsibility;
                documentLabor.Skill = skill;
                documentLabor.StartDate = startDate;
                documentLabor.EndDate = endDate;

                documentLaborModel.Add(documentLabor);
            }
            newResourcePlanModel.Labors = documentLaborModel;


            List<ResourcePlanModel.Equipment> documentEquipmentModel = new List<ResourcePlanModel.Equipment>();

            int equipmentRowsCount = EquipmentDataGridView.Rows.Count;

            for (int i = 0; i < equipmentRowsCount - 1; i++)
            {
                ResourcePlanModel.Equipment documentEquipment = new ResourcePlanModel.Equipment();
                var item = EquipmentDataGridView.Rows[i].Cells[0].Value?.ToString() ?? "";
                var amount = EquipmentDataGridView.Rows[i].Cells[1].Value?.ToString() ?? "";
                var purpose = EquipmentDataGridView.Rows[i].Cells[2].Value?.ToString() ?? "";
                var specification = EquipmentDataGridView.Rows[i].Cells[3].Value?.ToString() ?? "";
                var startDate = EquipmentDataGridView.Rows[i].Cells[4].Value?.ToString() ?? "";
                var endDate = EquipmentDataGridView.Rows[i].Cells[5].Value?.ToString() ?? "";
                documentEquipment.Item = item;
                documentEquipment.Amount = amount;
                documentEquipment.Purpose = purpose;
                documentEquipment.Specification = specification;
                documentEquipment.StartDate = startDate;
                documentEquipment.EndDate = endDate;

                documentEquipmentModel.Add(documentEquipment);
            }
            newResourcePlanModel.Equipments = documentEquipmentModel;

            List<ResourcePlanModel.Materials> documentMaterialModel = new List<ResourcePlanModel.Materials>();

            int materialRowsCount = materialdDataGridView.Rows.Count;

            for (int i = 0; i < materialRowsCount - 1; i++)
            {
                ResourcePlanModel.Materials documentMaterial = new ResourcePlanModel.Materials();
                var item = materialdDataGridView.Rows[i].Cells[0].Value?.ToString() ?? "";
                var amount = materialdDataGridView.Rows[i].Cells[1].Value?.ToString() ?? "";
                var startDate = materialdDataGridView.Rows[i].Cells[2].Value?.ToString() ?? "";
                var endDate = materialdDataGridView.Rows[i].Cells[3].Value?.ToString() ?? "";
                documentMaterial.Iitem = item;
                documentMaterial.Amount = amount;
                documentMaterial.StartDate = startDate;
                documentMaterial.EndDate = endDate;

                documentMaterialModel.Add(documentMaterial);
            }
            newResourcePlanModel.Material = documentMaterialModel;



            List<ResourcePlanModel.Schedule> documentSchedulelModel = new List<ResourcePlanModel.Schedule>();

            int sheduleRowsCount = scheduleDataGridView.Rows.Count;

            for (int i = 0; i < sheduleRowsCount - 1; i++)
            {
                ResourcePlanModel.Schedule documentSchedule = new ResourcePlanModel.Schedule();
                var resource = scheduleDataGridView.Rows[i].Cells[0].Value?.ToString() ?? "";
                var jan = scheduleDataGridView.Rows[i].Cells[1].Value?.ToString() ?? "";
                var feb = scheduleDataGridView.Rows[i].Cells[2].Value?.ToString() ?? "";
                var mar = scheduleDataGridView.Rows[i].Cells[3].Value?.ToString() ?? "";
                var apr = scheduleDataGridView.Rows[i].Cells[4].Value?.ToString() ?? "";
                var may = scheduleDataGridView.Rows[i].Cells[5].Value?.ToString() ?? "";
                var jun = scheduleDataGridView.Rows[i].Cells[6].Value?.ToString() ?? "";
                var jul = scheduleDataGridView.Rows[i].Cells[7].Value?.ToString() ?? "";
                var aug = scheduleDataGridView.Rows[i].Cells[8].Value?.ToString() ?? "";
                var sept = scheduleDataGridView.Rows[i].Cells[9].Value?.ToString() ?? "";
                var oct = scheduleDataGridView.Rows[i].Cells[10].Value?.ToString() ?? "";
                var nov = scheduleDataGridView.Rows[i].Cells[11].Value?.ToString() ?? "";
                var dec = scheduleDataGridView.Rows[i].Cells[12].Value?.ToString() ?? "";
                var total = scheduleDataGridView.Rows[i].Cells[13].Value?.ToString() ?? "";
                documentSchedule.Resource = resource;
                documentSchedule.Jan = jan;
                documentSchedule.Feb = feb;
                documentSchedule.Mar = mar;
                documentSchedule.Apr = apr;
                documentSchedule.May = may;
                documentSchedule.Jun = jun;
                documentSchedule.Jul = jul;
                documentSchedule.Aug = aug;
                documentSchedule.Sept = sept;
                documentSchedule.Oct = oct;
                documentSchedule.Nov = nov;
                documentSchedule.Dec = dec;
                documentSchedule.Total = total;


                documentSchedulelModel.Add(documentSchedule);
            }
            newResourcePlanModel.Schedules = documentSchedulelModel;

            newResourcePlanModel.Assumptions = txtRPAssumptions.Text;

            newResourcePlanModel.Constraints = txtRPConstraints.Text;

            List<VersionControl<ResourcePlanModel>.DocumentModel> documentModels = versionControl.DocumentModels;


            if (!versionControl.isEqual(currentResourcePlanModel, newResourcePlanModel))
            {
                VersionControl<ResourcePlanModel>.DocumentModel documentModel = new VersionControl<ResourcePlanModel>.DocumentModel(newResourcePlanModel, DateTime.Now, VersionControl<ProjectModel>.generateID());

                documentModels.Add(documentModel);

                versionControl.DocumentModels = documentModels;
                currentResourcePlanModel = JsonConvert.DeserializeObject<ResourcePlanModel>(JsonConvert.SerializeObject(newResourcePlanModel));
                string json = JsonConvert.SerializeObject(versionControl);
                JsonHelper.saveDocument(json, Settings.Default.ProjectID, "ResourcePlan");
                MessageBox.Show("Resource Plan saved successfully", "save", MessageBoxButtons.OK);
            }

        }


        public void loadDocument()
        {
            string json = JsonHelper.loadDocument(Settings.Default.ProjectID, "ResourcePlan");
            List<string[]> documentInfo = new List<string[]>();
            newResourcePlanModel = new ResourcePlanModel();
            currentResourcePlanModel = new ResourcePlanModel();
            if (json != "")
            {
                versionControl = JsonConvert.DeserializeObject<VersionControl<ResourcePlanModel>>(json);
                newResourcePlanModel = JsonConvert.DeserializeObject<ResourcePlanModel>(versionControl.getLatest(versionControl.DocumentModels));
                currentResourcePlanModel = JsonConvert.DeserializeObject<ResourcePlanModel>(versionControl.getLatest(versionControl.DocumentModels));

                documentInfo.Add(new string[] { "Document ID", currentResourcePlanModel.DocumentID });
                documentInfo.Add(new string[] { "Document Owner", currentResourcePlanModel.DocumentOwner });
                documentInfo.Add(new string[] { "Issue Date", currentResourcePlanModel.IssueDate });
                documentInfo.Add(new string[] { "Last Save Date", currentResourcePlanModel.LastSavedDate });
                documentInfo.Add(new string[] { "File Name", currentResourcePlanModel.FileName });

                foreach (var row in documentInfo)
                {
                    docInfodataGridView.Rows.Add(row);
                }
                docInfodataGridView.AllowUserToAddRows = false;

                foreach (var row in currentResourcePlanModel.DocumentHistories)
                {
                    docHistdataGridView.Rows.Add(new string[] { row.Version, row.IssueDate, row.Changes });
                }

                foreach (var row in currentResourcePlanModel.DocumentApprovals)
                {
                    docApprovalsdataGridView.Rows.Add(new string[] { row.Role, row.Name, "", row.DateApproved });
                }

                foreach (var row in currentResourcePlanModel.Labors)
                {
                    laborDataGridView.Rows.Add(new string[] { row.Role, row.Number, row.Responsibility, row.Skill, row.StartDate, row.EndDate });
                }

                foreach (var row in currentResourcePlanModel.Equipments)
                {
                    EquipmentDataGridView.Rows.Add(new string[] { row.Item, row.Amount, row.Purpose, row.Specification, row.StartDate, row.EndDate });
                }

                foreach (var row in currentResourcePlanModel.Material)
                {
                    materialdDataGridView.Rows.Add(new string[] { row.Iitem, row.Iitem, row.Amount, row.StartDate, row.EndDate });
                }

                foreach (var row in currentResourcePlanModel.Schedules)
                {
                    scheduleDataGridView.Rows.Add(new string[] { row.Resource, row.Jan, row.Feb, row.Mar, row.Apr, row.May, row.Jun, row.Jul, row.Aug, row.Sept, row.Oct, row.Nov, row.Dec, row.Total });
                }

                txtRPAssumptions.Text = currentResourcePlanModel.Assumptions;
                textBoxProjectName.Text = currentResourcePlanModel.ProjectName;
                txtRPConstraints.Text = currentResourcePlanModel.Constraints;
            }
            else
            {
                versionControl = new VersionControl<ResourcePlanModel>();
                versionControl.DocumentModels = new List<VersionControl<ResourcePlanModel>.DocumentModel>();
                documentInfo.Add(new string[] { "Document ID", "" });
                documentInfo.Add(new string[] { "Document Owner", "" });
                documentInfo.Add(new string[] { "Issue Date", "" });
                documentInfo.Add(new string[] { "Last Save Date", "" });
                documentInfo.Add(new string[] { "File Name", "" });
                newResourcePlanModel = new ResourcePlanModel();
                foreach (var row in documentInfo)
                {
                    docInfodataGridView.Rows.Add(row);
                }
                docInfodataGridView.AllowUserToAddRows = false;
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
                        document.InsertParagraph("Resource Plan \nFor " + projectModel.ProjectName)
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(22d).Alignment = Alignment.left;
                        document.InsertSectionPageBreak();
                        document.InsertParagraph("Document Control\n")
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(14d).Alignment = Alignment.left;
                        document.InsertParagraph("")
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(14d).Alignment = Alignment.left;
                        document.InsertParagraph("Document Information\n")
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(14d).Alignment = Alignment.left;

                        var documentInfoTable = document.AddTable(6, 2);
                        documentInfoTable.Rows[0].Cells[0].Paragraphs[0].Append("").Bold(true).Color(Color.White);
                        documentInfoTable.Rows[0].Cells[1].Paragraphs[0].Append("Information").Bold(true).Color(Color.White);
                        documentInfoTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        documentInfoTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;

                        documentInfoTable.Rows[1].Cells[0].Paragraphs[0].Append("Document ID");
                        documentInfoTable.Rows[1].Cells[1].Paragraphs[0].Append(currentResourcePlanModel.DocumentID);

                        documentInfoTable.Rows[2].Cells[0].Paragraphs[0].Append("Document Owner");
                        documentInfoTable.Rows[2].Cells[1].Paragraphs[0].Append(currentResourcePlanModel.DocumentOwner);

                        documentInfoTable.Rows[3].Cells[0].Paragraphs[0].Append("Issue Date");
                        documentInfoTable.Rows[3].Cells[1].Paragraphs[0].Append(currentResourcePlanModel.IssueDate);

                        documentInfoTable.Rows[4].Cells[0].Paragraphs[0].Append("Last Saved Date");
                        documentInfoTable.Rows[4].Cells[1].Paragraphs[0].Append(currentResourcePlanModel.LastSavedDate);

                        documentInfoTable.Rows[5].Cells[0].Paragraphs[0].Append("File Name");
                        documentInfoTable.Rows[5].Cells[1].Paragraphs[0].Append(currentResourcePlanModel.FileName);
                        documentInfoTable.SetWidths(new float[] { 493, 1094 });
                        document.InsertTable(documentInfoTable);


                        //Document Histories
                        document.InsertParagraph("\nDocument History\n")
                            .Font("Arial")
                            .Bold(true)
                            .FontSize(14d).Alignment = Alignment.left;

                        var documentHistoryTable = document.AddTable(currentResourcePlanModel.DocumentHistories.Count + 1, 3);
                        documentHistoryTable.Rows[0].Cells[0].Paragraphs[0].Append("Version")
                            .Bold(true)
                            .Color(Color.White);
                        documentHistoryTable.Rows[0].Cells[1].Paragraphs[0].Append("Issue Date")
                            .Bold(true)
                            .Color(Color.White);
                        documentHistoryTable.Rows[0].Cells[2].Paragraphs[0].Append("Changes")
                            .Bold(true)
                            .Color(Color.White);
                        documentHistoryTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        documentHistoryTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        documentHistoryTable.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;
                        for (int i = 1; i < currentResourcePlanModel.DocumentHistories.Count + 1; i++)
                        {
                            documentHistoryTable.Rows[i].Cells[0].Paragraphs[0].Append(currentResourcePlanModel.DocumentHistories[i - 1].Version);
                            documentHistoryTable.Rows[i].Cells[1].Paragraphs[0].Append(currentResourcePlanModel.DocumentHistories[i - 1].IssueDate);
                            documentHistoryTable.Rows[i].Cells[2].Paragraphs[0].Append(currentResourcePlanModel.DocumentHistories[i - 1].Changes);

                        }

                        documentHistoryTable.SetWidths(new float[] { 190, 303, 1094 });
                        document.InsertTable(documentHistoryTable);


                        //Document approvals
                        document.InsertParagraph("\nDocument Approvals\n")
                           .Font("Arial")
                           .Bold(true)
                           .FontSize(14d).Alignment = Alignment.left;

                        var documentApprovalTable = document.AddTable(currentResourcePlanModel.DocumentApprovals.Count + 1, 4);
                        documentApprovalTable.Rows[0].Cells[0].Paragraphs[0].Append("Role")
                            .Bold(true)
                            .Color(Color.White);
                        documentApprovalTable.Rows[0].Cells[1].Paragraphs[0].Append("Name")
                            .Bold(true)
                            .Color(Color.White);
                        documentApprovalTable.Rows[0].Cells[2].Paragraphs[0].Append("Signature")
                            .Bold(true)
                            .Color(Color.White);
                        documentApprovalTable.Rows[0].Cells[3].Paragraphs[0].Append("Date")
                            .Bold(true)
                            .Color(Color.White);
                        documentApprovalTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        documentApprovalTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        documentApprovalTable.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;
                        documentApprovalTable.Rows[0].Cells[3].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < currentResourcePlanModel.DocumentApprovals.Count + 1; i++)
                        {
                            documentApprovalTable.Rows[i].Cells[0].Paragraphs[0].Append(currentResourcePlanModel.DocumentApprovals[i - 1].Role);
                            documentApprovalTable.Rows[i].Cells[1].Paragraphs[0].Append(currentResourcePlanModel.DocumentApprovals[i - 1].Name);
                            documentApprovalTable.Rows[i].Cells[2].Paragraphs[0].Append(currentResourcePlanModel.DocumentApprovals[i - 1].Signature);
                            documentApprovalTable.Rows[i].Cells[3].Paragraphs[0].Append(currentResourcePlanModel.DocumentApprovals[i - 1].DateApproved);
                        }
                        documentApprovalTable.SetWidths(new float[] { 493, 332, 508, 254 });
                        document.InsertTable(documentApprovalTable);
                        document.InsertParagraph().InsertPageBreakAfterSelf();


                        var p = document.InsertParagraph();
                        var title = p.InsertParagraphBeforeSelf("Table of Contents").Bold().FontSize(20);

                        var tocSwitches = new Dictionary<TableOfContentsSwitches, string>()
                        {
                            { TableOfContentsSwitches.O, "1-3"},
                            { TableOfContentsSwitches.U, ""},
                            { TableOfContentsSwitches.Z, ""},
                            { TableOfContentsSwitches.H, ""}
                        };
                        document.InsertTableOfContents(p, "", tocSwitches);
                        document.InsertParagraph().InsertPageBreakAfterSelf();


                        //Resource Listing/////////////////////
                        var responsibilitiesHeading = document.InsertParagraph("1. Resource Listing")
                           .Bold()
                           .FontSize(14d)
                           .Color(Color.Black)
                           .Bold(true)
                           .Font("Arial");


                        responsibilitiesHeading.StyleId = "Heading1";
                        //Labor
                        
                        var equipmentSubHeading = document.InsertParagraph("1.1 Labour")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        equipmentSubHeading.StyleId = "Heading2";

                        var laborTable = document.AddTable(currentResourcePlanModel.DocumentHistories.Count + 1, 6);
                        laborTable.Rows[0].Cells[0].Paragraphs[0].Append("Role")
                            .Bold(true)
                            .Color(Color.White);
                        laborTable.Rows[0].Cells[1].Paragraphs[0].Append("Number")
                            .Bold(true)
                            .Color(Color.White);
                        laborTable.Rows[0].Cells[2].Paragraphs[0].Append("Responsibilities")
                            .Bold(true)
                            .Color(Color.White);
                        laborTable.Rows[0].Cells[3].Paragraphs[0].Append("SKills")
                           .Bold(true)
                           .Color(Color.White);
                        laborTable.Rows[0].Cells[4].Paragraphs[0].Append("Start Date")
                            .Bold(true)
                            .Color(Color.White);
                        laborTable.Rows[0].Cells[5].Paragraphs[0].Append("End Date")
                            .Bold(true)
                            .Color(Color.White);

                        laborTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        laborTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        laborTable.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;
                        laborTable.Rows[0].Cells[3].FillColor = TABLE_HEADER_COLOR;
                        laborTable.Rows[0].Cells[4].FillColor = TABLE_HEADER_COLOR;
                        laborTable.Rows[0].Cells[5].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < currentResourcePlanModel.Labors.Count + 1; i++)
                        {
                            laborTable.Rows[i].Cells[0].Paragraphs[0].Append(currentResourcePlanModel.Labors[i - 1].Role);
                            laborTable.Rows[i].Cells[1].Paragraphs[0].Append(currentResourcePlanModel.Labors[i - 1].Number);
                            laborTable.Rows[i].Cells[2].Paragraphs[0].Append(currentResourcePlanModel.Labors[i - 1].Responsibility);
                            laborTable.Rows[i].Cells[3].Paragraphs[0].Append(currentResourcePlanModel.Labors[i - 1].Skill);
                            laborTable.Rows[i].Cells[4].Paragraphs[0].Append(currentResourcePlanModel.Labors[i - 1].StartDate);
                            laborTable.Rows[i].Cells[5].Paragraphs[0].Append(currentResourcePlanModel.Labors[i - 1].EndDate);

                        }

                        laborTable.SetWidths(new float[] { 394, 400, 400 });
                        document.InsertTable(laborTable);

                        //Equipment
                        
                        var equipmentubHeading = document.InsertParagraph("1.2 Equipment")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        equipmentubHeading.StyleId = "Heading2";

                        var equipmentTable = document.AddTable(currentResourcePlanModel.Equipments.Count + 1, 6);
                        equipmentTable.Rows[0].Cells[0].Paragraphs[0].Append("Item")
                            .Bold(true)
                            .Color(Color.White);
                        equipmentTable.Rows[0].Cells[1].Paragraphs[0].Append("Amount")
                            .Bold(true)
                            .Color(Color.White);
                        equipmentTable.Rows[0].Cells[2].Paragraphs[0].Append("Purpose")
                            .Bold(true)
                            .Color(Color.White);
                        equipmentTable.Rows[0].Cells[3].Paragraphs[0].Append("Specification")
                           .Bold(true)
                           .Color(Color.White);
                        equipmentTable.Rows[0].Cells[4].Paragraphs[0].Append("Start Date")
                            .Bold(true)
                            .Color(Color.White);
                        equipmentTable.Rows[0].Cells[5].Paragraphs[0].Append("End Date")
                            .Bold(true)
                            .Color(Color.White);
                        equipmentTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        equipmentTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        equipmentTable.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;
                        equipmentTable.Rows[0].Cells[3].FillColor = TABLE_HEADER_COLOR;
                        equipmentTable.Rows[0].Cells[4].FillColor = TABLE_HEADER_COLOR;
                        equipmentTable.Rows[0].Cells[5].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < currentResourcePlanModel.Labors.Count + 1; i++)
                        {
                            equipmentTable.Rows[i].Cells[0].Paragraphs[0].Append(currentResourcePlanModel.Equipments[i - 1].Item);
                            equipmentTable.Rows[i].Cells[1].Paragraphs[0].Append(currentResourcePlanModel.Equipments[i - 1].Amount);
                            equipmentTable.Rows[i].Cells[2].Paragraphs[0].Append(currentResourcePlanModel.Equipments[i - 1].Purpose);
                            equipmentTable.Rows[i].Cells[3].Paragraphs[0].Append(currentResourcePlanModel.Equipments[i - 1].Specification);
                            equipmentTable.Rows[i].Cells[4].Paragraphs[0].Append(currentResourcePlanModel.Equipments[i - 1].StartDate);
                            equipmentTable.Rows[i].Cells[5].Paragraphs[0].Append(currentResourcePlanModel.Equipments[i - 1].EndDate);

                        }

                        laborTable.SetWidths(new float[] { 190, 180, 250, 180, 200, 200 });
                        document.InsertTable(equipmentTable);


                        //Materials
                        var MaterialtubHeading = document.InsertParagraph("1.3 Material")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        equipmentubHeading.StyleId = "Heading2";

                        var materialTable = document.AddTable(currentResourcePlanModel.Material.Count + 1, 4);
                        materialTable.Rows[0].Cells[0].Paragraphs[0].Append("Item")
                            .Bold(true)
                            .Color(Color.White);
                        materialTable.Rows[0].Cells[1].Paragraphs[0].Append("Amount")
                            .Bold(true)
                            .Color(Color.White);
                        materialTable.Rows[0].Cells[2].Paragraphs[0].Append("Start Date")
                            .Bold(true)
                            .Color(Color.White);
                        materialTable.Rows[0].Cells[3].Paragraphs[0].Append("End Date")
                            .Bold(true)
                            .Color(Color.White);
                        materialTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        materialTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        materialTable.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;
                        materialTable.Rows[0].Cells[3].FillColor = TABLE_HEADER_COLOR;
                        for (int i = 1; i < currentResourcePlanModel.Labors.Count + 1; i++)
                        {
                            materialTable.Rows[i].Cells[0].Paragraphs[0].Append(currentResourcePlanModel.Equipments[i - 1].Item);
                            materialTable.Rows[i].Cells[1].Paragraphs[0].Append(currentResourcePlanModel.Equipments[i - 1].Amount);
                            materialTable.Rows[i].Cells[2].Paragraphs[0].Append(currentResourcePlanModel.Equipments[i - 1].StartDate);
                            materialTable.Rows[i].Cells[3].Paragraphs[0].Append(currentResourcePlanModel.Equipments[i - 1].EndDate);

                        }

                        laborTable.SetWidths(new float[] { 190, 180, 250, 180 });
                        document.InsertTable(materialTable);




                        //Resource plan//////////////////////////////
                        var resourclePlanHeading = document.InsertParagraph("2. Resource Plan")
                           .Bold()
                           .FontSize(14d)
                           .Color(Color.Black)
                           .Bold(true)
                           .Font("Arial");

                        resourclePlanHeading.StyleId = "Heading1";

                        //Shedule
                        var sheduleSubHeading = document.InsertParagraph("2.1 Shedule")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        sheduleSubHeading.StyleId = "Heading2";

                        var scheduleTable = document.AddTable(currentResourcePlanModel.Equipments.Count + 1, 7);
                        scheduleTable.Rows[0].Cells[0].Paragraphs[0].Append("Resource")
                            .Bold(true)
                            .Color(Color.White);
                        scheduleTable.Rows[0].Cells[1].Paragraphs[0].Append("Jan")
                            .Bold(true)
                            .Color(Color.White);
                        scheduleTable.Rows[0].Cells[2].Paragraphs[0].Append("Feb")
                            .Bold(true)
                            .Color(Color.White);
                        scheduleTable.Rows[0].Cells[3].Paragraphs[0].Append("Mar")
                           .Bold(true)
                           .Color(Color.White);
                        scheduleTable.Rows[0].Cells[4].Paragraphs[0].Append("Apr")
                            .Bold(true)
                            .Color(Color.White);
                        scheduleTable.Rows[0].Cells[5].Paragraphs[0].Append("May")
                            .Bold(true)
                            .Color(Color.White);
                        scheduleTable.Rows[0].Cells[6].Paragraphs[0].Append("Jun")
                            .Bold(true)
                            .Color(Color.White);

                        scheduleTable.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        scheduleTable.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        scheduleTable.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;
                        scheduleTable.Rows[0].Cells[3].FillColor = TABLE_HEADER_COLOR;
                        scheduleTable.Rows[0].Cells[4].FillColor = TABLE_HEADER_COLOR;
                        scheduleTable.Rows[0].Cells[5].FillColor = TABLE_HEADER_COLOR;
                        scheduleTable.Rows[0].Cells[6].FillColor = TABLE_HEADER_COLOR;

                        for (int i = 1; i < currentResourcePlanModel.Labors.Count + 1; i++)
                        {
                            scheduleTable.Rows[i].Cells[0].Paragraphs[0].Append(currentResourcePlanModel.Schedules[i - 1].Resource);
                            scheduleTable.Rows[i].Cells[1].Paragraphs[0].Append(currentResourcePlanModel.Schedules[i - 1].Jan);
                            scheduleTable.Rows[i].Cells[2].Paragraphs[0].Append(currentResourcePlanModel.Schedules[i - 1].Feb);
                            scheduleTable.Rows[i].Cells[3].Paragraphs[0].Append(currentResourcePlanModel.Schedules[i - 1].Mar);
                            scheduleTable.Rows[i].Cells[4].Paragraphs[0].Append(currentResourcePlanModel.Schedules[i - 1].Apr);
                            scheduleTable.Rows[i].Cells[5].Paragraphs[0].Append(currentResourcePlanModel.Schedules[i - 1].May);
                            scheduleTable.Rows[i].Cells[6].Paragraphs[0].Append(currentResourcePlanModel.Schedules[i - 1].Jun);

                        }

                        scheduleTable.SetWidths(new float[] { 100, 80, 80, 80, 80, 80, 80 });
                        document.InsertTable(scheduleTable);




                        document.InsertParagraph("")
                           .Font("Arial")
                           .Bold(true)
                           .FontSize(14d).Alignment = Alignment.left;

                        var schedule2Table = document.AddTable(currentResourcePlanModel.Equipments.Count + 1, 7);
                        schedule2Table.Rows[0].Cells[0].Paragraphs[0].Append("Jul")
                            .Bold(true)
                            .Color(Color.White);
                        schedule2Table.Rows[0].Cells[1].Paragraphs[0].Append("Aug")
                            .Bold(true)
                            .Color(Color.White);
                        schedule2Table.Rows[0].Cells[2].Paragraphs[0].Append("Sept")
                           .Bold(true)
                           .Color(Color.White);
                        schedule2Table.Rows[0].Cells[3].Paragraphs[0].Append("Oct")
                            .Bold(true)
                            .Color(Color.White);
                        schedule2Table.Rows[0].Cells[4].Paragraphs[0].Append("Nov")
                            .Bold(true)
                            .Color(Color.White);
                        schedule2Table.Rows[0].Cells[5].Paragraphs[0].Append("Dec")
                            .Bold(true)
                            .Color(Color.White);
                        schedule2Table.Rows[0].Cells[6].Paragraphs[0].Append("Total")
                            .Bold(true)
                            .Color(Color.White);
                        schedule2Table.Rows[0].Cells[0].FillColor = TABLE_HEADER_COLOR;
                        schedule2Table.Rows[0].Cells[1].FillColor = TABLE_HEADER_COLOR;
                        schedule2Table.Rows[0].Cells[2].FillColor = TABLE_HEADER_COLOR;
                        schedule2Table.Rows[0].Cells[3].FillColor = TABLE_HEADER_COLOR;
                        schedule2Table.Rows[0].Cells[4].FillColor = TABLE_HEADER_COLOR;
                        schedule2Table.Rows[0].Cells[5].FillColor = TABLE_HEADER_COLOR;
                        schedule2Table.Rows[0].Cells[6].FillColor = TABLE_HEADER_COLOR;
                        for (int i = 1; i < currentResourcePlanModel.Labors.Count + 1; i++)
                        {
                            schedule2Table.Rows[i].Cells[0].Paragraphs[0].Append(currentResourcePlanModel.Schedules[i - 1].Jul);
                            schedule2Table.Rows[i].Cells[1].Paragraphs[0].Append(currentResourcePlanModel.Schedules[i - 1].Aug);
                            schedule2Table.Rows[i].Cells[2].Paragraphs[0].Append(currentResourcePlanModel.Schedules[i - 1].Sept);
                            schedule2Table.Rows[i].Cells[3].Paragraphs[0].Append(currentResourcePlanModel.Schedules[i - 1].Oct);
                            schedule2Table.Rows[i].Cells[4].Paragraphs[0].Append(currentResourcePlanModel.Schedules[i - 1].Nov);
                            schedule2Table.Rows[i].Cells[5].Paragraphs[0].Append(currentResourcePlanModel.Schedules[i - 1].Dec);
                            schedule2Table.Rows[i].Cells[6].Paragraphs[0].Append(currentResourcePlanModel.Schedules[i - 1].Total);
                        }

                        schedule2Table.SetWidths(new float[] { 80, 80, 80, 80, 80, 80, 100});
                        document.InsertTable(schedule2Table);

                        //Assumptions


                        var assumptionsHeading = document.InsertParagraph("2.2 Assumptions ")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        document.InsertParagraph(currentResourcePlanModel.Assumptions)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        assumptionsHeading.StyleId = "Heading2";

                        //Constraints
                        var constraintHeading = document.InsertParagraph("2.3 Constraints ")
                            .Bold()
                            .FontSize(12d)
                            .Color(Color.Black)
                            .Bold(true)
                            .Font("Arial");

                        document.InsertParagraph(currentResourcePlanModel.Constraints)
                            .FontSize(11d)
                            .Color(Color.Black)
                            .Font("Arial").Alignment = Alignment.left;

                        constraintHeading.StyleId = "Heading2";

                        //Appendix

                        //Save document 
                        try
                        {
                            document.Save();
                        }
                        catch
                        {
                            MessageBox.Show("The selected File is open.", "Close File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                }
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            saveDocument();
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            exportToWord();
        }

        private void ResourcePlanDocumentForm_Load_2(object sender, EventArgs e)
        {
            loadDocument();
            string json = JsonHelper.loadProjectInfo(Settings.Default.Username);
            List<ProjectModel> projectListModel = JsonConvert.DeserializeObject<List<ProjectModel>>(json);
            projectModel = projectModel.getProjectModel(Settings.Default.ProjectID, projectListModel);
        }
    }
}
