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
    public partial class FinacialPlanDocumentForm : Form
    {
        VersionControl<FinancialPlanModel> versionControl;
        FinancialPlanModel newFinancialPlanModel;
        FinancialPlanModel currentFinancialPlanModel;

        public FinacialPlanDocumentForm()
        {
            InitializeComponent();
        }

        private void btnSaveAssumptions_Click(object sender, EventArgs e)
        {
            string assumptions = txtAssumptions.Text;
        }

        private void btnSaveConstraints_Click(object sender, EventArgs e)
        {
            string constraints = txtConstraints.Text;
        }

        private void btnSaveActivitiesRolesDocuments_Click(object sender, EventArgs e)
        {
            string activies = txtActivities.Text;
            string roles = txtRoles.Text;
            string documents = txtDocuments.Text;
        }

        private void btnSaveProjectName_Click(object sender, EventArgs e)
        {
            string projectName = txtProjectName.Text;
            SaveDocument();
        }

        private void FinacialPlanDocumentForm_Load(object sender, EventArgs e)
        {
            loadDocument();
        }

        //Back-End
        public void SaveDocument()
        {
            newFinancialPlanModel.schedule = new FinancialPlanModel.DocumentSchedule();
            newFinancialPlanModel.schedule.expenses = new List<FinancialPlanModel.DocumentSchedule.Expense>();

            newFinancialPlanModel.documentID = dataGridViewDocumentInformation.Rows[0].Cells[1].Value.ToString();
            newFinancialPlanModel.documentOwner = dataGridViewDocumentInformation.Rows[1].Cells[1].Value.ToString();
            newFinancialPlanModel.issueDate = dataGridViewDocumentInformation.Rows[2].Cells[1].Value.ToString();
            newFinancialPlanModel.lastSavedDate = dataGridViewDocumentInformation.Rows[3].Cells[1].Value.ToString();
            newFinancialPlanModel.fileName = dataGridViewDocumentInformation.Rows[4].Cells[1].Value.ToString();

            List<FinancialPlanModel.DocumentHistory> documentHistories = new List<FinancialPlanModel.DocumentHistory>();

            int versionRowCount = dataGridViewDocumentHistory.Rows.Count;

            for (int i = 0; i < versionRowCount; i++)
            {
                FinancialPlanModel.DocumentHistory documentHistory = new FinancialPlanModel.DocumentHistory();
                var tempVersion = dataGridViewDocumentHistory.Rows[i].Cells[0].Value?.ToString() ?? "";
                var tempIssueDate = dataGridViewDocumentHistory.Rows[i].Cells[1].Value?.ToString() ?? "";
                var tempChanges = dataGridViewDocumentHistory.Rows[i].Cells[2].Value?.ToString() ?? "";
                documentHistory.version = tempVersion;
                documentHistory.issueDate = tempIssueDate;
                documentHistory.changes = tempChanges;
                documentHistories.Add(documentHistory);
            }
            newFinancialPlanModel.documentHistories = documentHistories;

            List<FinancialPlanModel.DocumentApprovals> documentApprovals = new List<FinancialPlanModel.DocumentApprovals>();

            int approvalRowsCount = dataGridViewDocumentApprovals.Rows.Count;

            for (int i = 0; i < approvalRowsCount; i++)
            {
                FinancialPlanModel.DocumentApprovals documentApproval = new FinancialPlanModel.DocumentApprovals();
                var tempRole = dataGridViewDocumentApprovals.Rows[i].Cells[0].Value?.ToString() ?? "";
                var tempName = dataGridViewDocumentApprovals.Rows[i].Cells[1].Value?.ToString() ?? "";
                var tempChanges = dataGridViewDocumentApprovals.Rows[i].Cells[2].Value?.ToString() ?? "";
                var tempDate = dataGridViewDocumentApprovals.Rows[i].Cells[3].Value?.ToString() ?? "";
                documentApproval.role = tempRole;
                documentApproval.name = tempName;
                documentApproval.changes = tempChanges;
                documentApproval.date = tempDate;

                documentApprovals.Add(documentApproval);
            }
            newFinancialPlanModel.documentApprovals = documentApprovals;

            List<FinancialPlanModel.DocumentLabor> documentLabors = new List<FinancialPlanModel.DocumentLabor>();

            int labourCount = dataGridViewLabour.Rows.Count;

            for (int i = 0; i < labourCount; i++)
            {
                FinancialPlanModel.DocumentLabor documentLabor = new FinancialPlanModel.DocumentLabor();
                var tempRole = dataGridViewLabour.Rows[i].Cells[0].Value?.ToString() ?? "";
                var tempUnitCost = dataGridViewLabour.Rows[i].Cells[1].Value?.ToString() ?? "";
                documentLabor.role = tempRole;
                documentLabor.unitCost = tempUnitCost;

                documentLabors.Add(documentLabor);
            }
            newFinancialPlanModel.documentLabors = documentLabors;

            List<FinancialPlanModel.DocumentEquipment> documentEquipments = new List<FinancialPlanModel.DocumentEquipment>();

            int equipmentCount = dataGridViewEquipment.Rows.Count;

            for (int i = 0; i < equipmentCount; i++)
            {
                FinancialPlanModel.DocumentEquipment documentEquipment = new FinancialPlanModel.DocumentEquipment();
                var tempEquipment = dataGridViewEquipment.Rows[i].Cells[0].Value?.ToString() ?? "";
                var tempUnitCost = dataGridViewEquipment.Rows[i].Cells[1].Value?.ToString() ?? "";
                documentEquipment.equipment = tempEquipment;
                documentEquipment.unitCost = tempUnitCost;

                documentEquipments.Add(documentEquipment);
            }
            newFinancialPlanModel.documentEquipments = documentEquipments;

            List<FinancialPlanModel.DocumentMaterial> documentMaterials = new List<FinancialPlanModel.DocumentMaterial>();

            int materialCount = dataGridViewMaterials.Rows.Count;

            for (int i = 0; i < materialCount; i++)
            {
                FinancialPlanModel.DocumentMaterial documentMaterial = new FinancialPlanModel.DocumentMaterial();
                var tempMat = dataGridViewMaterials.Rows[i].Cells[0].Value?.ToString() ?? "";
                var tempUnitCost = dataGridViewMaterials.Rows[i].Cells[1].Value?.ToString() ?? "";
                documentMaterial.material = tempMat;
                documentMaterial.unitCost = tempUnitCost;

                documentMaterials.Add(documentMaterial);
            }
            newFinancialPlanModel.documentMaterials = documentMaterials;

            List<FinancialPlanModel.DocumentSupplier> documentSuppliers = new List<FinancialPlanModel.DocumentSupplier>();

            int supplierCount = dataGridViewSuppliers.Rows.Count;

            for (int i = 0; i < supplierCount; i++)
            {
                FinancialPlanModel.DocumentSupplier documentSupplier = new FinancialPlanModel.DocumentSupplier();
                var tempDeliverable = dataGridViewSuppliers.Rows[i].Cells[0].Value?.ToString() ?? "";
                var tempUnitCost = dataGridViewSuppliers.Rows[i].Cells[1].Value?.ToString() ?? "";
                documentSupplier.deliverableItem = tempDeliverable;
                documentSupplier.unitCost = tempUnitCost;

                documentSuppliers.Add(documentSupplier);
            }
            newFinancialPlanModel.documentSuppliers = documentSuppliers;

            List<FinancialPlanModel.DocumentAdministration> documentAdministrations = new List<FinancialPlanModel.DocumentAdministration>();

            int adminCount = dataGridViewAdmin.Rows.Count;

            for (int i = 0; i < adminCount; i++)
            {
                FinancialPlanModel.DocumentAdministration documentAdministration = new FinancialPlanModel.DocumentAdministration();
                var tempAdminItem = dataGridViewAdmin.Rows[i].Cells[0].Value?.ToString() ?? "";
                var tempUnitCost = dataGridViewAdmin.Rows[i].Cells[1].Value?.ToString() ?? "";
                documentAdministration.administrativeItem = tempAdminItem;
                documentAdministration.unitCost = tempUnitCost;

                documentAdministrations.Add(documentAdministration);
            }
            newFinancialPlanModel.documentAdministrations = documentAdministrations;

            List<FinancialPlanModel.DocumentOther> documentOthers = new List<FinancialPlanModel.DocumentOther>();

            int otherCount = dataGridViewOther.Rows.Count;

            for (int i = 0; i < otherCount; i++)
            {
                FinancialPlanModel.DocumentOther documentOther = new FinancialPlanModel.DocumentOther();
                var tempOther = dataGridViewOther.Rows[i].Cells[0].Value?.ToString() ?? "";
                var tempUnitCost = dataGridViewOther.Rows[i].Cells[1].Value?.ToString() ?? "";
                documentOther.otherExpenseItem = tempOther;
                documentOther.unitCost = tempUnitCost;

                documentOthers.Add(documentOther);
            }
            newFinancialPlanModel.documentOthers = documentOthers;

            List<FinancialPlanModel.DocumentSchedule.Expense> expenses = new List<FinancialPlanModel.DocumentSchedule.Expense>();

            int scheduleCount = dataGridView1.Rows.Count;

            for (int i = 0; i < scheduleCount; i++)
            {
                FinancialPlanModel.DocumentSchedule.Expense expense = new FinancialPlanModel.DocumentSchedule.Expense();
                expense.expenseType = dataGridView1.Rows[i].Cells[0].Value?.ToString() ?? "";

                for (int j = 0; j < 12; j++)
                {
                    expense.expensePerMonth[j] = dataGridView1.Rows[i].Cells[j + 1].Value?.ToString() ?? "";
                }

                expenses.Add(expense);
            }
            newFinancialPlanModel.schedule.expenses = expenses;

            newFinancialPlanModel.assumptions = txtAssumptions.Text;
            newFinancialPlanModel.constraints = txtConstraints.Text;

            newFinancialPlanModel.financialActivities = txtActivities.Text;
            newFinancialPlanModel.financialDocuments = txtDocuments.Text;
            newFinancialPlanModel.financialRoles = txtRoles.Text;

            List<VersionControl<FinancialPlanModel>.DocumentModel> documentModels = versionControl.DocumentModels;

            if (!versionControl.isEqual(currentFinancialPlanModel, newFinancialPlanModel))
            {
                VersionControl<FinancialPlanModel>.DocumentModel documentModel = new VersionControl<FinancialPlanModel>.DocumentModel(newFinancialPlanModel, DateTime.Now, VersionControl<ProjectModel>.generateID());

                documentModels.Add(documentModel);
                versionControl.DocumentModels = documentModels;

                string json = JsonConvert.SerializeObject(versionControl);
                JsonHelper.saveDocument(json, Settings.Default.ProjectID, "FinancialPlan");
                MessageBox.Show("Financial plan saved successfully", "save", MessageBoxButtons.OK);
            }
        }

        public void loadDocument()
        {
            string json = JsonHelper.loadDocument(Settings.Default.ProjectID, "FinancialPlan");
            List<string[]> documentInfo = new List<string[]>();
            newFinancialPlanModel = new FinancialPlanModel();
            currentFinancialPlanModel = new FinancialPlanModel();
            if (json != "")
            {
                versionControl = JsonConvert.DeserializeObject<VersionControl<FinancialPlanModel>>(json);
                newFinancialPlanModel = JsonConvert.DeserializeObject<FinancialPlanModel>(versionControl.getLatest(versionControl.DocumentModels));
                currentFinancialPlanModel = JsonConvert.DeserializeObject<FinancialPlanModel>(versionControl.getLatest(versionControl.DocumentModels));

                documentInfo.Add(new string[] { "Document ID", currentFinancialPlanModel.documentID });
                documentInfo.Add(new string[] { "Document Owner", currentFinancialPlanModel.documentOwner });
                documentInfo.Add(new string[] { "Issue Date", currentFinancialPlanModel.issueDate });
                documentInfo.Add(new string[] { "Last Save Date", currentFinancialPlanModel.lastSavedDate });
                documentInfo.Add(new string[] { "File Name", currentFinancialPlanModel.fileName });

                foreach (var row in documentInfo)
                {
                    dataGridViewDocumentInformation.Rows.Add(row);
                }
                dataGridViewDocumentInformation.AllowUserToAddRows = false;

                foreach (var row in currentFinancialPlanModel.documentHistories)
                {
                    dataGridViewDocumentHistory.Rows.Add(new string[] { row.version, row.issueDate, row.changes });
                }

                foreach (var row in currentFinancialPlanModel.documentApprovals)
                {
                    dataGridViewDocumentApprovals.Rows.Add(new String[] { row.role, row.name, row.changes, row.date });
                }

                foreach (var row in currentFinancialPlanModel.documentLabors)
                {
                    dataGridViewLabour.Rows.Add(new String[] { row.role, row.unitCost });
                }

                foreach (var row in currentFinancialPlanModel.documentEquipments)
                {
                    dataGridViewEquipment.Rows.Add(new String[] { row.equipment, row.unitCost });
                }

                foreach (var row in currentFinancialPlanModel.documentMaterials)
                {
                    dataGridViewMaterials.Rows.Add(new String[] { row.material, row.unitCost });
                }

                foreach (var row in currentFinancialPlanModel.documentSuppliers)
                {
                    dataGridViewSuppliers.Rows.Add(new String[] { row.deliverableItem, row.unitCost });
                }

                foreach (var row in currentFinancialPlanModel.documentAdministrations)
                {
                    dataGridViewAdmin.Rows.Add(new String[] { row.administrativeItem, row.unitCost });
                }

                foreach (var row in currentFinancialPlanModel.documentOthers)
                {
                    dataGridViewOther.Rows.Add(new String[] { row.otherExpenseItem, row.unitCost });
                }

                foreach (var row in currentFinancialPlanModel.schedule.expenses)
                {
                    dataGridView1.Rows.Add(new String[] {
                        row.expenseType,
                        row.expensePerMonth[0],
                        row.expensePerMonth[1],
                        row.expensePerMonth[2],
                        row.expensePerMonth[3],
                        row.expensePerMonth[4],
                        row.expensePerMonth[5],
                        row.expensePerMonth[6],
                        row.expensePerMonth[7],
                        row.expensePerMonth[8],
                        row.expensePerMonth[9],
                        row.expensePerMonth[10],
                        row.expensePerMonth[11],
                    });
                }

                txtAssumptions.Text = newFinancialPlanModel.assumptions;
                txtConstraints.Text = newFinancialPlanModel.constraints;

                txtActivities.Text = newFinancialPlanModel.financialActivities;
                txtDocuments.Text = newFinancialPlanModel.financialDocuments;
                txtRoles.Text = newFinancialPlanModel.financialRoles;
            }
            else
            {
                versionControl = new VersionControl<FinancialPlanModel>();
                versionControl.DocumentModels = new List<VersionControl<FinancialPlanModel>.DocumentModel>();
                documentInfo.Add(new string[] { "Document ID", "" });
                documentInfo.Add(new string[] { "Document Owner", "" });
                documentInfo.Add(new string[] { "Issue Date", "" });
                documentInfo.Add(new string[] { "Last Save Date", "" });
                documentInfo.Add(new string[] { "File Name", "" });
                newFinancialPlanModel = new FinancialPlanModel();
                foreach (var row in documentInfo)
                {
                    dataGridViewDocumentInformation.Rows.Add(row);
                }
                dataGridViewDocumentInformation.AllowUserToAddRows = false;
            }
        }
    }
}
