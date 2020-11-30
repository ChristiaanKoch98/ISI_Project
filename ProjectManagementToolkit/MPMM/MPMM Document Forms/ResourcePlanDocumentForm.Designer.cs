namespace ProjectManagementToolkit.MPMM.MPMM_Document_Forms
{
    partial class ResourcePlanDocumentForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ResourcePlanTabControl = new System.Windows.Forms.TabControl();
            this.documentCtrlTabPG = new System.Windows.Forms.TabPage();
            this.dataGridViewDocApprovals = new System.Windows.Forms.DataGridView();
            this.approvalRole = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.approvalName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.approvalSignature = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.approvalDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridViewDocHistory = new System.Windows.Forms.DataGridView();
            this.Version = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.historyIssueDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.historyChanges = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.docInfoGridData = new System.Windows.Forms.DataGridView();
            this.docNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Information = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dcmntInfoLabel = new System.Windows.Forms.Label();
            this.resourceListTab = new System.Windows.Forms.TabPage();
            this.dataGridViewMaterial = new System.Windows.Forms.DataGridView();
            this.material_ItemColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.materialAmountColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.materialsStartDateClmn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.materialEndDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridViewEquipment = new System.Windows.Forms.DataGridView();
            this.equipmentLabel = new System.Windows.Forms.Label();
            this.laborDataGridView = new System.Windows.Forms.DataGridView();
            this.laborLabel = new System.Windows.Forms.Label();
            this.resourcePlabTab = new System.Windows.Forms.TabPage();
            this.btnSaveResourcePlan = new System.Windows.Forms.Button();
            this.constraintsLabel = new System.Windows.Forms.Label();
            this.assumptionsLabel = new System.Windows.Forms.Label();
            this.txtRPConstraints = new System.Windows.Forms.TextBox();
            this.txtRPAssumptions = new System.Windows.Forms.TextBox();
            this.resourcePlanLabel = new System.Windows.Forms.Label();
            this.dataGridViewResourcePlanSchedule = new System.Windows.Forms.DataGridView();
            this.ResourceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.janColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.febColomn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.marColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aprColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mayColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.junColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JulColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.augColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.septColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.octColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.novColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.decColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.appendixTabPage = new System.Windows.Forms.TabPage();
            this.btnSaveProjectName = new System.Windows.Forms.Button();
            this.label27 = new System.Windows.Forms.Label();
            this.txtProjectName = new System.Windows.Forms.TextBox();
            this.btnExportResourcePlan = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.purposeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.specificationColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.equipmentStartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.equipmentEndDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ResourcePlanTabControl.SuspendLayout();
            this.documentCtrlTabPG.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDocApprovals)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDocHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docInfoGridData)).BeginInit();
            this.resourceListTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMaterial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEquipment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.laborDataGridView)).BeginInit();
            this.resourcePlabTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResourcePlanSchedule)).BeginInit();
            this.SuspendLayout();
            // 
            // ResourcePlanTabControl
            // 
            this.ResourcePlanTabControl.Controls.Add(this.documentCtrlTabPG);
            this.ResourcePlanTabControl.Controls.Add(this.resourceListTab);
            this.ResourcePlanTabControl.Controls.Add(this.resourcePlabTab);
            this.ResourcePlanTabControl.Controls.Add(this.appendixTabPage);
            this.ResourcePlanTabControl.Location = new System.Drawing.Point(12, 35);
            this.ResourcePlanTabControl.Name = "ResourcePlanTabControl";
            this.ResourcePlanTabControl.SelectedIndex = 0;
            this.ResourcePlanTabControl.Size = new System.Drawing.Size(855, 401);
            this.ResourcePlanTabControl.TabIndex = 2;
            // 
            // documentCtrlTabPG
            // 
            this.documentCtrlTabPG.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.documentCtrlTabPG.Controls.Add(this.dataGridViewDocApprovals);
            this.documentCtrlTabPG.Controls.Add(this.label3);
            this.documentCtrlTabPG.Controls.Add(this.dataGridViewDocHistory);
            this.documentCtrlTabPG.Controls.Add(this.label2);
            this.documentCtrlTabPG.Controls.Add(this.docInfoGridData);
            this.documentCtrlTabPG.Controls.Add(this.dcmntInfoLabel);
            this.documentCtrlTabPG.ForeColor = System.Drawing.Color.White;
            this.documentCtrlTabPG.Location = new System.Drawing.Point(4, 21);
            this.documentCtrlTabPG.Name = "documentCtrlTabPG";
            this.documentCtrlTabPG.Padding = new System.Windows.Forms.Padding(3);
            this.documentCtrlTabPG.Size = new System.Drawing.Size(847, 376);
            this.documentCtrlTabPG.TabIndex = 0;
            this.documentCtrlTabPG.Text = "Document Control";
            // 
            // dataGridViewDocApprovals
            // 
            this.dataGridViewDocApprovals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDocApprovals.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.approvalRole,
            this.approvalName,
            this.approvalSignature,
            this.approvalDate});
            this.dataGridViewDocApprovals.Location = new System.Drawing.Point(180, 241);
            this.dataGridViewDocApprovals.Name = "dataGridViewDocApprovals";
            this.dataGridViewDocApprovals.RowHeadersWidth = 51;
            this.dataGridViewDocApprovals.Size = new System.Drawing.Size(659, 114);
            this.dataGridViewDocApprovals.TabIndex = 8;
            // 
            // approvalRole
            // 
            this.approvalRole.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.approvalRole.HeaderText = "Role";
            this.approvalRole.MinimumWidth = 6;
            this.approvalRole.Name = "approvalRole";
            // 
            // approvalName
            // 
            this.approvalName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.approvalName.HeaderText = "Name";
            this.approvalName.MinimumWidth = 6;
            this.approvalName.Name = "approvalName";
            // 
            // approvalSignature
            // 
            this.approvalSignature.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.approvalSignature.DataPropertyName = "(none)";
            this.approvalSignature.HeaderText = "Signature";
            this.approvalSignature.MinimumWidth = 6;
            this.approvalSignature.Name = "approvalSignature";
            this.approvalSignature.ReadOnly = true;
            // 
            // approvalDate
            // 
            this.approvalDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.approvalDate.HeaderText = "Date";
            this.approvalDate.MinimumWidth = 6;
            this.approvalDate.Name = "approvalDate";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cambria", 12F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(6, 272);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 19);
            this.label3.TabIndex = 7;
            this.label3.Text = "Document Approvals";
            // 
            // dataGridViewDocHistory
            // 
            this.dataGridViewDocHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDocHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Version,
            this.historyIssueDate,
            this.historyChanges});
            this.dataGridViewDocHistory.Location = new System.Drawing.Point(180, 126);
            this.dataGridViewDocHistory.Name = "dataGridViewDocHistory";
            this.dataGridViewDocHistory.RowHeadersWidth = 51;
            this.dataGridViewDocHistory.Size = new System.Drawing.Size(659, 85);
            this.dataGridViewDocHistory.TabIndex = 6;
            // 
            // Version
            // 
            this.Version.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Version.HeaderText = "Version";
            this.Version.MinimumWidth = 6;
            this.Version.Name = "Version";
            // 
            // historyIssueDate
            // 
            this.historyIssueDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.historyIssueDate.HeaderText = "Issue Date";
            this.historyIssueDate.MinimumWidth = 6;
            this.historyIssueDate.Name = "historyIssueDate";
            // 
            // historyChanges
            // 
            this.historyChanges.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.historyChanges.HeaderText = "Changes";
            this.historyChanges.MinimumWidth = 6;
            this.historyChanges.Name = "historyChanges";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cambria", 12F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(6, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "Document History";
            // 
            // docInfoGridData
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.docInfoGridData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.docInfoGridData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.docInfoGridData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.docNameColumn,
            this.Information});
            this.docInfoGridData.Location = new System.Drawing.Point(180, 6);
            this.docInfoGridData.Name = "docInfoGridData";
            this.docInfoGridData.RowHeadersWidth = 51;
            this.docInfoGridData.Size = new System.Drawing.Size(659, 81);
            this.docInfoGridData.TabIndex = 2;
            // 
            // docNameColumn
            // 
            this.docNameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.docNameColumn.HeaderText = "";
            this.docNameColumn.MinimumWidth = 6;
            this.docNameColumn.Name = "docNameColumn";
            // 
            // Information
            // 
            this.Information.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Information.HeaderText = "Information";
            this.Information.MinimumWidth = 6;
            this.Information.Name = "Information";
            // 
            // dcmntInfoLabel
            // 
            this.dcmntInfoLabel.AutoSize = true;
            this.dcmntInfoLabel.Font = new System.Drawing.Font("Cambria", 12F);
            this.dcmntInfoLabel.ForeColor = System.Drawing.Color.White;
            this.dcmntInfoLabel.Location = new System.Drawing.Point(6, 37);
            this.dcmntInfoLabel.Name = "dcmntInfoLabel";
            this.dcmntInfoLabel.Size = new System.Drawing.Size(167, 19);
            this.dcmntInfoLabel.TabIndex = 1;
            this.dcmntInfoLabel.Text = "Document Information";
            // 
            // resourceListTab
            // 
            this.resourceListTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.resourceListTab.Controls.Add(this.dataGridViewMaterial);
            this.resourceListTab.Controls.Add(this.label4);
            this.resourceListTab.Controls.Add(this.dataGridViewEquipment);
            this.resourceListTab.Controls.Add(this.equipmentLabel);
            this.resourceListTab.Controls.Add(this.laborDataGridView);
            this.resourceListTab.Controls.Add(this.laborLabel);
            this.resourceListTab.Location = new System.Drawing.Point(4, 21);
            this.resourceListTab.Name = "resourceListTab";
            this.resourceListTab.Padding = new System.Windows.Forms.Padding(3);
            this.resourceListTab.Size = new System.Drawing.Size(847, 376);
            this.resourceListTab.TabIndex = 1;
            this.resourceListTab.Text = "Resource Listing";
            // 
            // dataGridViewMaterial
            // 
            this.dataGridViewMaterial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMaterial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.material_ItemColumn,
            this.materialAmountColumn,
            this.materialsStartDateClmn,
            this.materialEndDateColumn});
            this.dataGridViewMaterial.Location = new System.Drawing.Point(93, 264);
            this.dataGridViewMaterial.Name = "dataGridViewMaterial";
            this.dataGridViewMaterial.RowHeadersWidth = 51;
            this.dataGridViewMaterial.Size = new System.Drawing.Size(749, 96);
            this.dataGridViewMaterial.TabIndex = 7;
            // 
            // material_ItemColumn
            // 
            this.material_ItemColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.material_ItemColumn.HeaderText = "Item";
            this.material_ItemColumn.MinimumWidth = 6;
            this.material_ItemColumn.Name = "material_ItemColumn";
            // 
            // materialAmountColumn
            // 
            this.materialAmountColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.materialAmountColumn.HeaderText = "Amount";
            this.materialAmountColumn.MinimumWidth = 6;
            this.materialAmountColumn.Name = "materialAmountColumn";
            // 
            // materialsStartDateClmn
            // 
            this.materialsStartDateClmn.HeaderText = "Start Date";
            this.materialsStartDateClmn.Name = "materialsStartDateClmn";
            // 
            // materialEndDateColumn
            // 
            this.materialEndDateColumn.HeaderText = "End Date";
            this.materialEndDateColumn.Name = "materialEndDateColumn";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cambria", 12F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(6, 302);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 19);
            this.label4.TabIndex = 6;
            this.label4.Text = "Materials";
            // 
            // dataGridViewEquipment
            // 
            this.dataGridViewEquipment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEquipment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.itemColumn,
            this.amountColumn,
            this.purposeColumn,
            this.specificationColumn,
            this.equipmentStartDate,
            this.equipmentEndDateColumn});
            this.dataGridViewEquipment.Location = new System.Drawing.Point(93, 135);
            this.dataGridViewEquipment.Name = "dataGridViewEquipment";
            this.dataGridViewEquipment.RowHeadersWidth = 51;
            this.dataGridViewEquipment.Size = new System.Drawing.Size(749, 104);
            this.dataGridViewEquipment.TabIndex = 5;
            // 
            // equipmentLabel
            // 
            this.equipmentLabel.AutoSize = true;
            this.equipmentLabel.Font = new System.Drawing.Font("Cambria", 12F);
            this.equipmentLabel.ForeColor = System.Drawing.Color.White;
            this.equipmentLabel.Location = new System.Drawing.Point(6, 171);
            this.equipmentLabel.Name = "equipmentLabel";
            this.equipmentLabel.Size = new System.Drawing.Size(84, 19);
            this.equipmentLabel.TabIndex = 4;
            this.equipmentLabel.Text = "Equipment";
            // 
            // laborDataGridView
            // 
            this.laborDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.laborDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.startDateColumn,
            this.endDateColumn});
            this.laborDataGridView.Location = new System.Drawing.Point(93, 14);
            this.laborDataGridView.Name = "laborDataGridView";
            this.laborDataGridView.RowHeadersWidth = 51;
            this.laborDataGridView.Size = new System.Drawing.Size(749, 94);
            this.laborDataGridView.TabIndex = 3;
            // 
            // laborLabel
            // 
            this.laborLabel.AutoSize = true;
            this.laborLabel.Font = new System.Drawing.Font("Cambria", 12F);
            this.laborLabel.ForeColor = System.Drawing.Color.White;
            this.laborLabel.Location = new System.Drawing.Point(6, 54);
            this.laborLabel.Name = "laborLabel";
            this.laborLabel.Size = new System.Drawing.Size(51, 19);
            this.laborLabel.TabIndex = 0;
            this.laborLabel.Text = "Labor";
            // 
            // resourcePlabTab
            // 
            this.resourcePlabTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.resourcePlabTab.Controls.Add(this.btnSaveResourcePlan);
            this.resourcePlabTab.Controls.Add(this.constraintsLabel);
            this.resourcePlabTab.Controls.Add(this.assumptionsLabel);
            this.resourcePlabTab.Controls.Add(this.txtRPConstraints);
            this.resourcePlabTab.Controls.Add(this.txtRPAssumptions);
            this.resourcePlabTab.Controls.Add(this.resourcePlanLabel);
            this.resourcePlabTab.Controls.Add(this.dataGridViewResourcePlanSchedule);
            this.resourcePlabTab.Location = new System.Drawing.Point(4, 21);
            this.resourcePlabTab.Name = "resourcePlabTab";
            this.resourcePlabTab.Padding = new System.Windows.Forms.Padding(3);
            this.resourcePlabTab.Size = new System.Drawing.Size(847, 376);
            this.resourcePlabTab.TabIndex = 2;
            this.resourcePlabTab.Text = "Resource Plan";
            // 
            // btnSaveResourcePlan
            // 
            this.btnSaveResourcePlan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.btnSaveResourcePlan.Location = new System.Drawing.Point(379, 347);
            this.btnSaveResourcePlan.Name = "btnSaveResourcePlan";
            this.btnSaveResourcePlan.Size = new System.Drawing.Size(114, 22);
            this.btnSaveResourcePlan.TabIndex = 21;
            this.btnSaveResourcePlan.Text = "Save Resource Plan";
            this.btnSaveResourcePlan.UseVisualStyleBackColor = true;
            // 
            // constraintsLabel
            // 
            this.constraintsLabel.AutoSize = true;
            this.constraintsLabel.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.constraintsLabel.Location = new System.Drawing.Point(438, 212);
            this.constraintsLabel.Name = "constraintsLabel";
            this.constraintsLabel.Size = new System.Drawing.Size(88, 19);
            this.constraintsLabel.TabIndex = 5;
            this.constraintsLabel.Text = "Constraints";
            // 
            // assumptionsLabel
            // 
            this.assumptionsLabel.AutoSize = true;
            this.assumptionsLabel.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.assumptionsLabel.Location = new System.Drawing.Point(9, 211);
            this.assumptionsLabel.Name = "assumptionsLabel";
            this.assumptionsLabel.Size = new System.Drawing.Size(98, 19);
            this.assumptionsLabel.TabIndex = 4;
            this.assumptionsLabel.Text = "Assumptions";
            // 
            // txtRPConstraints
            // 
            this.txtRPConstraints.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.txtRPConstraints.ForeColor = System.Drawing.Color.White;
            this.txtRPConstraints.Location = new System.Drawing.Point(442, 233);
            this.txtRPConstraints.Multiline = true;
            this.txtRPConstraints.Name = "txtRPConstraints";
            this.txtRPConstraints.Size = new System.Drawing.Size(396, 108);
            this.txtRPConstraints.TabIndex = 3;
            // 
            // txtRPAssumptions
            // 
            this.txtRPAssumptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.txtRPAssumptions.ForeColor = System.Drawing.Color.White;
            this.txtRPAssumptions.Location = new System.Drawing.Point(9, 233);
            this.txtRPAssumptions.Multiline = true;
            this.txtRPAssumptions.Name = "txtRPAssumptions";
            this.txtRPAssumptions.Size = new System.Drawing.Size(415, 108);
            this.txtRPAssumptions.TabIndex = 2;
            // 
            // resourcePlanLabel
            // 
            this.resourcePlanLabel.AutoSize = true;
            this.resourcePlanLabel.Font = new System.Drawing.Font("Cambria", 12F);
            this.resourcePlanLabel.Location = new System.Drawing.Point(12, 6);
            this.resourcePlanLabel.Name = "resourcePlanLabel";
            this.resourcePlanLabel.Size = new System.Drawing.Size(71, 19);
            this.resourcePlanLabel.TabIndex = 1;
            this.resourcePlanLabel.Text = "Schedule";
            // 
            // dataGridViewResourcePlanSchedule
            // 
            this.dataGridViewResourcePlanSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewResourcePlanSchedule.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ResourceColumn,
            this.janColumn,
            this.febColomn,
            this.marColumn,
            this.aprColumn,
            this.mayColumn,
            this.junColumn,
            this.JulColumn,
            this.augColumn,
            this.septColumn,
            this.octColumn,
            this.novColumn,
            this.decColumn,
            this.totalColumn});
            this.dataGridViewResourcePlanSchedule.Location = new System.Drawing.Point(9, 28);
            this.dataGridViewResourcePlanSchedule.Name = "dataGridViewResourcePlanSchedule";
            this.dataGridViewResourcePlanSchedule.Size = new System.Drawing.Size(832, 185);
            this.dataGridViewResourcePlanSchedule.TabIndex = 0;
            // 
            // ResourceColumn
            // 
            this.ResourceColumn.HeaderText = "Resource";
            this.ResourceColumn.Name = "ResourceColumn";
            // 
            // janColumn
            // 
            this.janColumn.HeaderText = "Jan";
            this.janColumn.Name = "janColumn";
            this.janColumn.Width = 50;
            // 
            // febColomn
            // 
            this.febColomn.HeaderText = "Feb";
            this.febColomn.Name = "febColomn";
            this.febColomn.Width = 50;
            // 
            // marColumn
            // 
            this.marColumn.HeaderText = "Mar";
            this.marColumn.Name = "marColumn";
            this.marColumn.Width = 50;
            // 
            // aprColumn
            // 
            this.aprColumn.HeaderText = "Apr";
            this.aprColumn.Name = "aprColumn";
            this.aprColumn.Width = 50;
            // 
            // mayColumn
            // 
            this.mayColumn.HeaderText = "May";
            this.mayColumn.Name = "mayColumn";
            this.mayColumn.Width = 50;
            // 
            // junColumn
            // 
            this.junColumn.HeaderText = "Jun";
            this.junColumn.Name = "junColumn";
            this.junColumn.Width = 50;
            // 
            // JulColumn
            // 
            this.JulColumn.HeaderText = "Jul";
            this.JulColumn.Name = "JulColumn";
            this.JulColumn.Width = 50;
            // 
            // augColumn
            // 
            this.augColumn.HeaderText = "Aug";
            this.augColumn.Name = "augColumn";
            this.augColumn.Width = 50;
            // 
            // septColumn
            // 
            this.septColumn.HeaderText = "Sept";
            this.septColumn.Name = "septColumn";
            this.septColumn.Width = 50;
            // 
            // octColumn
            // 
            this.octColumn.HeaderText = "Oct";
            this.octColumn.Name = "octColumn";
            this.octColumn.Width = 50;
            // 
            // novColumn
            // 
            this.novColumn.HeaderText = "Nov";
            this.novColumn.Name = "novColumn";
            this.novColumn.Width = 50;
            // 
            // decColumn
            // 
            this.decColumn.HeaderText = "Dec";
            this.decColumn.Name = "decColumn";
            this.decColumn.Width = 50;
            // 
            // totalColumn
            // 
            this.totalColumn.HeaderText = "Total";
            this.totalColumn.Name = "totalColumn";
            // 
            // appendixTabPage
            // 
            this.appendixTabPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.appendixTabPage.Font = new System.Drawing.Font("Cambria", 10F);
            this.appendixTabPage.Location = new System.Drawing.Point(4, 21);
            this.appendixTabPage.Name = "appendixTabPage";
            this.appendixTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.appendixTabPage.Size = new System.Drawing.Size(847, 376);
            this.appendixTabPage.TabIndex = 3;
            this.appendixTabPage.Text = "Appendix";
            // 
            // btnSaveProjectName
            // 
            this.btnSaveProjectName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.btnSaveProjectName.Location = new System.Drawing.Point(772, 8);
            this.btnSaveProjectName.Name = "btnSaveProjectName";
            this.btnSaveProjectName.Size = new System.Drawing.Size(95, 42);
            this.btnSaveProjectName.TabIndex = 3;
            this.btnSaveProjectName.Text = "Save Project Name";
            this.btnSaveProjectName.UseVisualStyleBackColor = true;
            this.btnSaveProjectName.Click += new System.EventHandler(this.btnResourceSave_Click);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.White;
            this.label27.Location = new System.Drawing.Point(4, 12);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(153, 12);
            this.label27.TabIndex = 20;
            this.label27.Text = "Please Enter Your Project Name:";
            // 
            // txtProjectName
            // 
            this.txtProjectName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.txtProjectName.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProjectName.ForeColor = System.Drawing.Color.White;
            this.txtProjectName.Location = new System.Drawing.Point(173, 9);
            this.txtProjectName.Name = "txtProjectName";
            this.txtProjectName.Size = new System.Drawing.Size(113, 20);
            this.txtProjectName.TabIndex = 19;
            this.txtProjectName.Text = "Project Name";
            // 
            // btnExportResourcePlan
            // 
            this.btnExportResourcePlan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.btnExportResourcePlan.Location = new System.Drawing.Point(661, 8);
            this.btnExportResourcePlan.Name = "btnExportResourcePlan";
            this.btnExportResourcePlan.Size = new System.Drawing.Size(95, 42);
            this.btnExportResourcePlan.TabIndex = 21;
            this.btnExportResourcePlan.Text = "Export Project Name";
            this.btnExportResourcePlan.UseVisualStyleBackColor = true;
            this.btnExportResourcePlan.Click += new System.EventHandler(this.btnExportResourcePlan_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.HeaderText = "Role";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.HeaderText = "Number";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "(none)";
            this.dataGridViewTextBoxColumn3.HeaderText = "Responsibilities";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.HeaderText = "Skills";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // startDateColumn
            // 
            this.startDateColumn.HeaderText = "Start Date";
            this.startDateColumn.Name = "startDateColumn";
            // 
            // endDateColumn
            // 
            this.endDateColumn.HeaderText = "End Date";
            this.endDateColumn.Name = "endDateColumn";
            // 
            // itemColumn
            // 
            this.itemColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.itemColumn.HeaderText = "Item";
            this.itemColumn.MinimumWidth = 6;
            this.itemColumn.Name = "itemColumn";
            // 
            // amountColumn
            // 
            this.amountColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.amountColumn.HeaderText = "Amount";
            this.amountColumn.MinimumWidth = 6;
            this.amountColumn.Name = "amountColumn";
            // 
            // purposeColumn
            // 
            this.purposeColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.purposeColumn.DataPropertyName = "(none)";
            this.purposeColumn.HeaderText = "Purpose";
            this.purposeColumn.MinimumWidth = 6;
            this.purposeColumn.Name = "purposeColumn";
            // 
            // specificationColumn
            // 
            this.specificationColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.specificationColumn.HeaderText = "Specification";
            this.specificationColumn.MinimumWidth = 6;
            this.specificationColumn.Name = "specificationColumn";
            // 
            // equipmentStartDate
            // 
            this.equipmentStartDate.HeaderText = "Start Date";
            this.equipmentStartDate.Name = "equipmentStartDate";
            // 
            // equipmentEndDateColumn
            // 
            this.equipmentEndDateColumn.HeaderText = "End Date";
            this.equipmentEndDateColumn.Name = "equipmentEndDateColumn";
            // 
            // ResourcePlanDocumentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(879, 448);
            this.Controls.Add(this.btnExportResourcePlan);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.txtProjectName);
            this.Controls.Add(this.btnSaveProjectName);
            this.Controls.Add(this.ResourcePlanTabControl);
            this.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "ResourcePlanDocumentForm";
            this.Text = "ResourcePlanDocumentForm";
            this.Load += new System.EventHandler(this.ResourcePlanDocumentForm_Load);
            this.ResourcePlanTabControl.ResumeLayout(false);
            this.documentCtrlTabPG.ResumeLayout(false);
            this.documentCtrlTabPG.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDocApprovals)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDocHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docInfoGridData)).EndInit();
            this.resourceListTab.ResumeLayout(false);
            this.resourceListTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMaterial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEquipment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.laborDataGridView)).EndInit();
            this.resourcePlabTab.ResumeLayout(false);
            this.resourcePlabTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResourcePlanSchedule)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabControl ResourcePlanTabControl;
        private System.Windows.Forms.TabPage documentCtrlTabPG;
        private System.Windows.Forms.DataGridView docInfoGridData;
        private System.Windows.Forms.DataGridViewTextBoxColumn docNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Information;
        private System.Windows.Forms.Label dcmntInfoLabel;
        private System.Windows.Forms.TabPage resourceListTab;
        private System.Windows.Forms.TabPage resourcePlabTab;
        private System.Windows.Forms.TabPage appendixTabPage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridViewDocApprovals;
        private System.Windows.Forms.DataGridViewTextBoxColumn approvalRole;
        private System.Windows.Forms.DataGridViewTextBoxColumn approvalName;
        private System.Windows.Forms.DataGridViewTextBoxColumn approvalSignature;
        private System.Windows.Forms.DataGridViewTextBoxColumn approvalDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridViewDocHistory;
        private System.Windows.Forms.DataGridViewTextBoxColumn Version;
        private System.Windows.Forms.DataGridViewTextBoxColumn historyIssueDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn historyChanges;
        private System.Windows.Forms.DataGridView dataGridViewMaterial;
        private System.Windows.Forms.DataGridViewTextBoxColumn material_ItemColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn materialAmountColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn materialsStartDateClmn;
        private System.Windows.Forms.DataGridViewTextBoxColumn materialEndDateColumn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridViewEquipment;
        private System.Windows.Forms.Label equipmentLabel;
        private System.Windows.Forms.DataGridView laborDataGridView;
        private System.Windows.Forms.Label laborLabel;
        private System.Windows.Forms.Label constraintsLabel;
        private System.Windows.Forms.Label assumptionsLabel;
        private System.Windows.Forms.TextBox txtRPConstraints;
        private System.Windows.Forms.TextBox txtRPAssumptions;
        private System.Windows.Forms.Label resourcePlanLabel;
        private System.Windows.Forms.DataGridView dataGridViewResourcePlanSchedule;
        private System.Windows.Forms.DataGridViewTextBoxColumn ResourceColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn janColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn febColomn;
        private System.Windows.Forms.DataGridViewTextBoxColumn marColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aprColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mayColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn junColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn JulColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn augColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn septColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn octColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn novColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn decColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalColumn;
        private System.Windows.Forms.Button btnSaveProjectName;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox txtProjectName;
        private System.Windows.Forms.Button btnSaveResourcePlan;
        private System.Windows.Forms.Button btnExportResourcePlan;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn purposeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn specificationColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn equipmentStartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn equipmentEndDateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn startDateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn endDateColumn;
    }
}