using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using ProjectManagementToolkit.MPMM.MPMM_Document_Models;
using ProjectManagementToolkit.Properties;
using ProjectManagementToolkit.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectManagementToolkit.MPMM.MPMM_Document_Forms
{
    public partial class ProcurementRegister : Form
    {
        VersionControl<ProcurementRegisterModel> versionControl;
        ProcurementRegisterModel newProcurementRegisterModel;
        ProcurementRegisterModel currentProcurementRegisterModel;
        Color TABLE_HEADER_COLOR = Color.FromArgb(73, 173, 252);
        ProjectModel projectModel = new ProjectModel();

        public ProcurementRegister()
        {
            InitializeComponent();
        }

        private void txtProjectManagerName_TextChanged(object sender, EventArgs e)
        {

        }

        private void ProcurementRegister_Load(object sender, EventArgs e)
        {
            string jsoni = JsonHelper.loadProjectInfo(Settings.Default.Username);
            List<ProjectModel> projectListModel = JsonConvert.DeserializeObject<List<ProjectModel>>(jsoni);
            projectModel = projectModel.getProjectModel(Settings.Default.ProjectID, projectListModel);
            txtProcurementRegisterProjectName.Text = projectModel.ProjectName;
            txtProjectManagerName.Text = projectModel.ProjectManager;
            txtProcurementManager.Text = projectModel.ProcurementManager;


            dgvProcurementRegister.Columns.Add("colPO","PO #" );
            dgvProcurementRegister.Columns.Add("colItemTitle", "Item Title");
            dgvProcurementRegister.Columns.Add("colItemDesc", "Item Description");
            dgvProcurementRegister.Columns.Add("colQuantity", "Quantity");
            dgvProcurementRegister.Columns.Add("colUnitPrice", "Unit Price");
            dgvProcurementRegister.Columns.Add("colTotalPrice", "Total Price");
            dgvProcurementRegister.Columns.Add("colReqByDate", "Required By Date");
            dgvProcurementRegister.Columns.Add("colCompany", "Company");
            dgvProcurementRegister.Columns.Add("colContactName", "Contact Name");
            dgvProcurementRegister.Columns.Add("colContactPhNo", "Contact Ph. NO.");
            dgvProcurementRegister.Columns.Add("colPOStatus", "PO Status");
            dgvProcurementRegister.Columns.Add("colPODate", "PO Date");
            dgvProcurementRegister.Columns.Add("colDeliveryStatus", "Delivery Status");
            dgvProcurementRegister.Columns.Add("colDeliveryDate", "Delivery Date");
            dgvProcurementRegister.Columns.Add("colPaymentMethod", "Payment Method");
            dgvProcurementRegister.Columns.Add("colPaymentStatus", "Payment Status");
            dgvProcurementRegister.Columns.Add("colPaymentDate", "Payment Date");

            string json = JsonHelper.loadDocument(Settings.Default.ProjectID, "ProcurementRegister");
            newProcurementRegisterModel = new ProcurementRegisterModel();
            currentProcurementRegisterModel = new ProcurementRegisterModel();

            if (json != "")
            {
                versionControl = JsonConvert.DeserializeObject<VersionControl<ProcurementRegisterModel>>(json);
                newProcurementRegisterModel = JsonConvert.DeserializeObject<ProcurementRegisterModel>(versionControl.getLatest(versionControl.DocumentModels));
                currentProcurementRegisterModel = JsonConvert.DeserializeObject<ProcurementRegisterModel>(versionControl.getLatest(versionControl.DocumentModels));

                txtProjectManagerName.Text = currentProcurementRegisterModel.ProjectManagerName;
                txtProcurementRegisterProjectName.Text = currentProcurementRegisterModel.ProjectName;
                txtProcurementManager.Text = currentProcurementRegisterModel.ProcurementManagerName;

                foreach (var row in currentProcurementRegisterModel.procurementEntries)
                {
                    dgvProcurementRegister.Rows.Add(new string[] { row.PO_Number.ToString(), 
                                                                   row.ItemTitle, 
                                                                   row.ItemDescription,
                                                                   row.Quantity.ToString(), 
                                                                   row.UnitPrice.ToString(), 
                                                                   row.TotalPrice.ToString(), 
                                                                   row.RequiredByDate, 
                                                                   row.Company,
                                                                   row.ContactName,
                                                                   row.ContactPhoneNumber,
                                                                   row.PO_Status, 
                                                                   row.PO_Date,
                                                                   row.DeliveryStatus, 
                                                                   row.DeliveryDate,
                                                                   row.PaymentMethod,
                                                                   row.PaymentStatus,
                                                                   row.PaymentDate});
                }
            }
            else
            {
                versionControl = new VersionControl<ProcurementRegisterModel>();
                versionControl.DocumentModels = new List<VersionControl<ProcurementRegisterModel>.DocumentModel>();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            List<ProcurementRegisterModel.ProcurementEntry> procurementEntries = new List<ProcurementRegisterModel.ProcurementEntry>();
            int procurementEntryCount = dgvProcurementRegister.Rows.Count;

            for (int i = 0; i < procurementEntryCount - 1; i++)
            {
                ProcurementRegisterModel.ProcurementEntry procurementEntry = new ProcurementRegisterModel.ProcurementEntry();
                string poNum = dgvProcurementRegister.Rows[i].Cells[0].Value?.ToString() ?? "";
                var itemTitle = dgvProcurementRegister.Rows[i].Cells[1].Value?.ToString() ?? "";
                var itemDesc = dgvProcurementRegister.Rows[i].Cells[2].Value?.ToString() ?? "";
                var quantity = dgvProcurementRegister.Rows[i].Cells[3].Value?.ToString() ?? "";
                var unitPrice = dgvProcurementRegister.Rows[i].Cells[4].Value?.ToString() ?? "";
                var totalPrice = dgvProcurementRegister.Rows[i].Cells[5].Value?.ToString() ?? "";
                var reqByDate = dgvProcurementRegister.Rows[i].Cells[6].Value?.ToString() ?? "";
                var company = dgvProcurementRegister.Rows[i].Cells[7].Value?.ToString() ?? "";
                var contactName = dgvProcurementRegister.Rows[i].Cells[8].Value?.ToString() ?? "";
                var contactPhNum = dgvProcurementRegister.Rows[i].Cells[9].Value?.ToString() ?? "";
                var poStatus = dgvProcurementRegister.Rows[i].Cells[10].Value?.ToString() ?? "";
                var poDate = dgvProcurementRegister.Rows[i].Cells[11].Value?.ToString() ?? "";
                var deliveryStatus = dgvProcurementRegister.Rows[i].Cells[12].Value?.ToString() ?? "";
                var deliveryDate = dgvProcurementRegister.Rows[i].Cells[13].Value?.ToString() ?? "";
                var payMethod = dgvProcurementRegister.Rows[i].Cells[14].Value?.ToString() ?? "";
                var payStatus = dgvProcurementRegister.Rows[i].Cells[15].Value?.ToString() ?? "";
                var payDate = dgvProcurementRegister.Rows[i].Cells[16].Value?.ToString() ?? "";

                try
                {
                    procurementEntry.PO_Number = int.Parse(poNum);
                }
                catch
                {
                    MessageBox.Show("The PO # field must contain only numbers.");
                    return;
                }

                procurementEntry.ItemTitle = itemTitle;
                procurementEntry.ItemDescription = itemDesc;

                try
                {
                    procurementEntry.Quantity = int.Parse(quantity);
                }
                catch
                {
                    MessageBox.Show("The Quantity field must contain only numbers.");
                    return;
                }

                try
                {
                    procurementEntry.UnitPrice = int.Parse(unitPrice);
                }
                catch
                {
                    MessageBox.Show("The Unit Price field must contain only numbers.");
                    return;
                }

                try
                {
                    procurementEntry.TotalPrice = int.Parse(totalPrice);
                }
                catch
                {
                    MessageBox.Show("The Total Price field must contain only numbers.");
                    return;
                }

                procurementEntry.RequiredByDate = reqByDate;
                procurementEntry.Company = company;
                procurementEntry.ContactName = contactName;
                procurementEntry.ContactPhoneNumber = contactPhNum;
                procurementEntry.PO_Status = poStatus;
                procurementEntry.PO_Date = poDate;
                procurementEntry.DeliveryStatus = deliveryStatus;
                procurementEntry.DeliveryDate = deliveryDate;
                procurementEntry.PaymentMethod = payMethod;
                procurementEntry.PaymentStatus = payStatus;
                procurementEntry.PaymentDate = payDate;

                procurementEntries.Add(procurementEntry);
            }

            newProcurementRegisterModel.procurementEntries = procurementEntries;
            newProcurementRegisterModel.ProcurementManagerName = txtProcurementManager.Text;
            newProcurementRegisterModel.ProjectName = txtProcurementRegisterProjectName.Text;
            newProcurementRegisterModel.ProjectManagerName = txtProjectManagerName.Text;

            List<VersionControl<ProcurementRegisterModel>.DocumentModel> documentModels = versionControl.DocumentModels;

            if (!versionControl.isEqual(currentProcurementRegisterModel, newProcurementRegisterModel))
            {
                VersionControl<ProcurementRegisterModel>.DocumentModel documentModel = new VersionControl<ProcurementRegisterModel>.DocumentModel(newProcurementRegisterModel, DateTime.Now, VersionControl<ProcurementRegisterModel>.generateID());

                documentModels.Add(documentModel);
                string json = JsonConvert.SerializeObject(versionControl);
                currentProcurementRegisterModel = JsonConvert.DeserializeObject<ProcurementRegisterModel>(JsonConvert.SerializeObject(newProcurementRegisterModel));
                JsonHelper.saveDocument(json, Settings.Default.ProjectID, "ProcurementRegister");
                MessageBox.Show("Procurement register saved successfully", "save", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("No changes were made.", "save", MessageBoxButtons.OK);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ExcelAppend.ExportNotQualityRegister((int)ExcelAppend.DocumentType.ProcurementRegister, dgvProcurementRegister);
        }
    }
}
