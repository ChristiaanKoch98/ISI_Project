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
    public partial class ResourcePlanDocumentForm : Form
    {
        VersionControl<ResourcePlanModel> versionControl;
        ResourcePlanModel newResourcePlanModel;
        ResourcePlanModel currentResourcePlanModel;

        public ResourcePlanDocumentForm()
        {
            InitializeComponent();
        }

        private void ResourcePlanDocumentForm_Load(object sender, EventArgs e)
        {

            loadDocument();

        }

        private void ResourcePlanDocumentForm_Load_1(object sender, EventArgs e)
        {

        }

        private void btnResourceSave_Click(object sender, EventArgs e)
        {
            saveDocument();
        }

        public void saveDocument()
        {
            newResourcePlanModel.DocumentID = docInfoGridData.Rows[0].Cells[1].Value.ToString();
            newResourcePlanModel.DocumentOwner = docInfoGridData.Rows[1].Cells[1].Value.ToString();
            newResourcePlanModel.IssueDate = docInfoGridData.Rows[2].Cells[1].Value.ToString();
            newResourcePlanModel.LastSavedDate = docInfoGridData.Rows[3].Cells[1].Value.ToString();
            newResourcePlanModel.FileName = docInfoGridData.Rows[4].Cells[1].Value.ToString();

            List<ResourcePlanModel.DocumentHistory> documentHistories = new List<ResourcePlanModel.DocumentHistory>();

            int versionRowsCount = dataGridViewDocHistory.Rows.Count;

            for (int i = 0; i < versionRowsCount - 1; i++)
            {
                ResourcePlanModel.DocumentHistory documentHistoryModel = new ResourcePlanModel.DocumentHistory();
                var version = dataGridViewDocHistory.Rows[i].Cells[0].Value?.ToString() ?? "";
                var issueDate = dataGridViewDocHistory.Rows[i].Cells[1].Value?.ToString() ?? "";
                var changes = dataGridViewDocHistory.Rows[i].Cells[2].Value?.ToString() ?? "";
                documentHistoryModel.Version = version;
                documentHistoryModel.IssueDate = issueDate;
                documentHistoryModel.Changes = changes;
                documentHistories.Add(documentHistoryModel);
            }
            newResourcePlanModel.DocumentHistories = documentHistories;

            List<ResourcePlanModel.DocumentApproval> documentApprovalsModel = new List<ResourcePlanModel.DocumentApproval>();

            int approvalRowsCount = dataGridViewDocApprovals.Rows.Count;

            for (int i = 0; i < approvalRowsCount - 1; i++)
            {
                ResourcePlanModel.DocumentApproval documentApproval = new ResourcePlanModel.DocumentApproval();
                var role = dataGridViewDocApprovals.Rows[i].Cells[0].Value?.ToString() ?? "";
                var name = dataGridViewDocApprovals.Rows[i].Cells[1].Value?.ToString() ?? "";
                var signature = dataGridViewDocApprovals.Rows[i].Cells[2].Value?.ToString() ?? "";
                var date = dataGridViewDocApprovals.Rows[i].Cells[3].Value?.ToString() ?? "";
                documentApproval.Role = role;
                documentApproval.Name = name;
                documentApproval.Signature = signature;
                documentApproval.DateApproved = date;

                documentApprovalsModel.Add(documentApproval);
            }
            newResourcePlanModel.DocumentApprovals = documentApprovalsModel;


            List<ResourcePlanModel.Labor> documentLaborModel = new List<ResourcePlanModel.Labor>();

            int laborRowsCount = laborDataGridView.Rows.Count;

            for (int i = 0; i < approvalRowsCount - 1; i++)
            {
                ResourcePlanModel.Labor documentLabor = new ResourcePlanModel.Labor();
                var constraint = dataGridViewDocApprovals.Rows[i].Cells[0].Value?.ToString() ?? "";
                var number = dataGridViewDocApprovals.Rows[i].Cells[1].Value?.ToString() ?? "";
                var responsibility = dataGridViewDocApprovals.Rows[i].Cells[2].Value?.ToString() ?? "";
                var skill = dataGridViewDocApprovals.Rows[i].Cells[3].Value?.ToString() ?? "";
                var startDate = dataGridViewDocApprovals.Rows[i].Cells[4].Value?.ToString() ?? "";
                var endDate = dataGridViewDocApprovals.Rows[i].Cells[5].Value?.ToString() ?? "";
                documentLabor.Constraints = constraint;
                documentLabor.Number = number;
                documentLabor.Responsibility = responsibility;
                documentLabor.Skill = skill;
                documentLabor.StartDate = startDate;
                documentLabor.EndDate = endDate;

                documentLaborModel.Add(documentLabor);
            }
            newResourcePlanModel.Labors = documentLaborModel;


            List<ResourcePlanModel.Equipment> documentEquipmentModel = new List<ResourcePlanModel.Equipment>();

            int equipmentRowsCount = dataGridViewEquipment.Rows.Count;

            for (int i = 0; i < approvalRowsCount - 1; i++)
            {
                ResourcePlanModel.Equipment documentEquipment = new ResourcePlanModel.Equipment();
                var item = dataGridViewDocApprovals.Rows[i].Cells[0].Value?.ToString() ?? "";
                var amount = dataGridViewDocApprovals.Rows[i].Cells[1].Value?.ToString() ?? "";
                var purpose = dataGridViewDocApprovals.Rows[i].Cells[2].Value?.ToString() ?? "";
                var specification = dataGridViewDocApprovals.Rows[i].Cells[3].Value?.ToString() ?? "";
                var startDate = dataGridViewDocApprovals.Rows[i].Cells[4].Value?.ToString() ?? "";
                var endDate = dataGridViewDocApprovals.Rows[i].Cells[5].Value?.ToString() ?? "";
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

            int materialRowsCount = dataGridViewEquipment.Rows.Count;

            for (int i = 0; i < approvalRowsCount - 1; i++)
            {
                ResourcePlanModel.Materials documentMaterial = new ResourcePlanModel.Materials();
                var item = dataGridViewDocApprovals.Rows[i].Cells[0].Value?.ToString() ?? "";
                var amount = dataGridViewDocApprovals.Rows[i].Cells[1].Value?.ToString() ?? "";
                var startDate = dataGridViewDocApprovals.Rows[i].Cells[2].Value?.ToString() ?? "";
                var endDate = dataGridViewDocApprovals.Rows[i].Cells[3].Value?.ToString() ?? "";
                documentMaterial.Iitem = item;
                documentMaterial.Amount = amount;
                documentMaterial.StartDate = startDate;
                documentMaterial.EndDate = endDate;

                documentMaterialModel.Add(documentMaterial);
            }
            newResourcePlanModel.Material = documentMaterialModel;



            List<ResourcePlanModel.Schedule> documentSchedulelModel = new List<ResourcePlanModel.Schedule>();

            int sheduleRowsCount = dataGridViewEquipment.Rows.Count;

            for (int i = 0; i < approvalRowsCount - 1; i++)
            {
                ResourcePlanModel.Schedule documentSchedule = new ResourcePlanModel.Schedule();
                var resource = dataGridViewDocApprovals.Rows[i].Cells[0].Value?.ToString() ?? "";
                var jan = dataGridViewDocApprovals.Rows[i].Cells[1].Value?.ToString() ?? "";
                var feb = dataGridViewDocApprovals.Rows[i].Cells[2].Value?.ToString() ?? "";
                var mar = dataGridViewDocApprovals.Rows[i].Cells[3].Value?.ToString() ?? "";
                var apr = dataGridViewDocApprovals.Rows[i].Cells[4].Value?.ToString() ?? "";
                var may = dataGridViewDocApprovals.Rows[i].Cells[5].Value?.ToString() ?? "";
                var jun = dataGridViewDocApprovals.Rows[i].Cells[6].Value?.ToString() ?? "";
                var jul = dataGridViewDocApprovals.Rows[i].Cells[7].Value?.ToString() ?? "";
                var aug = dataGridViewDocApprovals.Rows[i].Cells[8].Value?.ToString() ?? "";
                var sept = dataGridViewDocApprovals.Rows[i].Cells[9].Value?.ToString() ?? "";
                var oct = dataGridViewDocApprovals.Rows[i].Cells[10].Value?.ToString() ?? "";
                var nov = dataGridViewDocApprovals.Rows[i].Cells[11].Value?.ToString() ?? "";
                var dec = dataGridViewDocApprovals.Rows[i].Cells[12].Value?.ToString() ?? "";
                var total = dataGridViewDocApprovals.Rows[i].Cells[13].Value?.ToString() ?? "";
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

            newResourcePlanModel.Assumption = txtRPAssumptions.Text;

            newResourcePlanModel.Constraint = txtRPConstraints.Text;

            List<VersionControl<ResourcePlanModel>.DocumentModel> documentModels = versionControl.DocumentModels;


            if (!versionControl.isEqual(currentResourcePlanModel, newResourcePlanModel))
            {
                VersionControl<ResourcePlanModel>.DocumentModel documentModel = new VersionControl<ResourcePlanModel>.DocumentModel(newResourcePlanModel, DateTime.Now, VersionControl<ProjectModel>.generateID());

                documentModels.Add(documentModel);

                versionControl.DocumentModels = documentModels;

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
                    docInfoGridData.Rows.Add(row);
                }
                docInfoGridData.AllowUserToAddRows = false;

                foreach (var row in currentResourcePlanModel.DocumentHistories)
                {
                    dataGridViewDocHistory.Rows.Add(new string[] { row.Version, row.IssueDate, row.Changes });
                }

                foreach (var row in currentResourcePlanModel.DocumentApprovals)
                {
                    dataGridViewDocApprovals.Rows.Add(new string[] { row.Role, row.Name, "", row.DateApproved });
                }

                foreach (var row in currentResourcePlanModel.Labors)
                {
                    laborDataGridView.Rows.Add(new string[] { row.Constraints, row.Number, row.Responsibility, row.Skill, row.StartDate, row.EndDate });
                }

                foreach (var row in currentResourcePlanModel.Equipments)
                {
                    dataGridViewEquipment.Rows.Add(new string[] { row.Item, row.Amount, row.Purpose, row.Specification, row.StartDate, row.EndDate });
                }

                foreach (var row in currentResourcePlanModel.Material)
                {
                    dataGridViewMaterial.Rows.Add(new string[] { row.Iitem, row.Iitem, row.Amount, row.StartDate, row.EndDate });
                }

                foreach (var row in currentResourcePlanModel.Schedules)
                {
                    dataGridViewResourcePlanSchedule.Rows.Add(new string[] { row.Resource, row.Jan, row.Feb, row.Mar, row.Apr, row.May, row.Jun, row.Jul, row.Aug, row.Sept, row.Oct, row.Nov, row.Dec, row.Total });
                }

                txtRPAssumptions.Text = currentResourcePlanModel.Assumptions;

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
                    docInfoGridData.Rows.Add(row);
                }
                docInfoGridData.AllowUserToAddRows = false;
            }
        }
    }
}

