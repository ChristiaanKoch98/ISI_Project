namespace ProjectManagementToolkit.MPMM.MPMM_Document_Forms
{
    partial class SupplierContractDocumentForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.documentControl = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvDocumentApprovals = new System.Windows.Forms.DataGridView();
            this.approvalRole = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.approvalName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.approvalSignature = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.approvalDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDocumentHistory = new System.Windows.Forms.DataGridView();
            this.Version = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.historyIssueDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.historyChanges = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDocumentInformation = new System.Windows.Forms.DataGridView();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Information = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.introduction = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvDefinitions = new System.Windows.Forms.DataGridView();
            this.term = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.definition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.purpose = new System.Windows.Forms.TextBox();
            this.recipients = new System.Windows.Forms.TextBox();
            this.scopeOfWork = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvProcurementItems = new System.Windows.Forms.DataGridView();
            this.itemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.responsibilities = new System.Windows.Forms.TabPage();
            this.project = new System.Windows.Forms.TextBox();
            this.supplier = new System.Windows.Forms.TextBox();
            this.performance = new System.Windows.Forms.TabPage();
            this.reviewProcess = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvReviewCriteriaIntro = new System.Windows.Forms.DataGridView();
            this.reviewCriteria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reviewDecription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.termsAndConditions = new System.Windows.Forms.TabPage();
            this.indemnity = new System.Windows.Forms.TextBox();
            this.confidentiality = new System.Windows.Forms.TextBox();
            this.law = new System.Windows.Forms.TextBox();
            this.agreement = new System.Windows.Forms.TextBox();
            this.invoicing = new System.Windows.Forms.TextBox();
            this.termination = new System.Windows.Forms.TextBox();
            this.disputes = new System.Windows.Forms.TextBox();
            this.payment = new System.Windows.Forms.TextBox();
            this.reviewSchedule = new System.Windows.Forms.TabPage();
            this.deliverySchedule = new System.Windows.Forms.TabPage();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.documentControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocumentApprovals)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocumentHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocumentInformation)).BeginInit();
            this.introduction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDefinitions)).BeginInit();
            this.scopeOfWork.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProcurementItems)).BeginInit();
            this.responsibilities.SuspendLayout();
            this.performance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReviewCriteriaIntro)).BeginInit();
            this.termsAndConditions.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.documentControl);
            this.tabControl1.Controls.Add(this.introduction);
            this.tabControl1.Controls.Add(this.scopeOfWork);
            this.tabControl1.Controls.Add(this.responsibilities);
            this.tabControl1.Controls.Add(this.performance);
            this.tabControl1.Controls.Add(this.termsAndConditions);
            this.tabControl1.Controls.Add(this.reviewSchedule);
            this.tabControl1.Controls.Add(this.deliverySchedule);
            this.tabControl1.Location = new System.Drawing.Point(16, 50);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1229, 586);
            this.tabControl1.TabIndex = 0;
            // 
            // documentControl
            // 
            this.documentControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.documentControl.Controls.Add(this.label3);
            this.documentControl.Controls.Add(this.label2);
            this.documentControl.Controls.Add(this.label1);
            this.documentControl.Controls.Add(this.dgvDocumentApprovals);
            this.documentControl.Controls.Add(this.dgvDocumentHistory);
            this.documentControl.Controls.Add(this.dgvDocumentInformation);
            this.documentControl.Location = new System.Drawing.Point(4, 25);
            this.documentControl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.documentControl.Name = "documentControl";
            this.documentControl.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.documentControl.Size = new System.Drawing.Size(1221, 557);
            this.documentControl.TabIndex = 0;
            this.documentControl.Text = "Document Control";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cambria", 11F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(11, 415);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(182, 22);
            this.label3.TabIndex = 11;
            this.label3.Text = "Document Approvals";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cambria", 11F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(11, 258);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 22);
            this.label2.TabIndex = 10;
            this.label2.Text = "Document History";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 11F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(11, 96);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 22);
            this.label1.TabIndex = 9;
            this.label1.Text = "Document Information";
            // 
            // documentApprovals
            // 
            this.dgvDocumentApprovals.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDocumentApprovals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocumentApprovals.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.approvalRole,
            this.approvalName,
            this.approvalSignature,
            this.approvalDate});
            this.dgvDocumentApprovals.Location = new System.Drawing.Point(225, 341);
            this.dgvDocumentApprovals.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvDocumentApprovals.Name = "documentApprovals";
            this.dgvDocumentApprovals.RowHeadersWidth = 51;
            this.dgvDocumentApprovals.Size = new System.Drawing.Size(921, 153);
            this.dgvDocumentApprovals.TabIndex = 8;
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
            // documentHistory
            // 
            this.dgvDocumentHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDocumentHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocumentHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Version,
            this.historyIssueDate,
            this.historyChanges});
            this.dgvDocumentHistory.Location = new System.Drawing.Point(225, 188);
            this.dgvDocumentHistory.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvDocumentHistory.Name = "documentHistory";
            this.dgvDocumentHistory.RowHeadersWidth = 51;
            this.dgvDocumentHistory.Size = new System.Drawing.Size(921, 145);
            this.dgvDocumentHistory.TabIndex = 7;
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
            // documentInformation
            // 
            this.dgvDocumentInformation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDocumentInformation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocumentInformation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Type,
            this.Information});
            this.dgvDocumentInformation.Location = new System.Drawing.Point(225, 48);
            this.dgvDocumentInformation.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvDocumentInformation.Name = "documentInformation";
            this.dgvDocumentInformation.RowHeadersWidth = 51;
            this.dgvDocumentInformation.Size = new System.Drawing.Size(921, 133);
            this.dgvDocumentInformation.TabIndex = 6;
            // 
            // Type
            // 
            this.Type.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Type.HeaderText = "Type";
            this.Type.MinimumWidth = 6;
            this.Type.Name = "Type";
            // 
            // Information
            // 
            this.Information.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Information.HeaderText = "Information";
            this.Information.MinimumWidth = 6;
            this.Information.Name = "Information";
            // 
            // introduction
            // 
            this.introduction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.introduction.Controls.Add(this.label6);
            this.introduction.Controls.Add(this.dgvDefinitions);
            this.introduction.Controls.Add(this.purpose);
            this.introduction.Controls.Add(this.recipients);
            this.introduction.Location = new System.Drawing.Point(4, 25);
            this.introduction.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.introduction.Name = "introduction";
            this.introduction.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.introduction.Size = new System.Drawing.Size(1221, 557);
            this.introduction.TabIndex = 1;
            this.introduction.Text = "Introduction";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Cambria", 11F);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(40, 362);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 22);
            this.label6.TabIndex = 21;
            this.label6.Text = "Definitions";
            // 
            // definitions
            // 
            this.dgvDefinitions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDefinitions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDefinitions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.term,
            this.definition});
            this.dgvDefinitions.Location = new System.Drawing.Point(203, 292);
            this.dgvDefinitions.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvDefinitions.Name = "definitions";
            this.dgvDefinitions.RowHeadersWidth = 51;
            this.dgvDefinitions.Size = new System.Drawing.Size(921, 133);
            this.dgvDefinitions.TabIndex = 20;
            // 
            // term
            // 
            this.term.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.term.HeaderText = "Term";
            this.term.MinimumWidth = 6;
            this.term.Name = "term";
            // 
            // definition
            // 
            this.definition.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.definition.HeaderText = "Definition";
            this.definition.MinimumWidth = 6;
            this.definition.Name = "definition";
            // 
            // purpose
            // 
            this.purpose.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.purpose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.purpose.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.purpose.ForeColor = System.Drawing.Color.White;
            this.purpose.Location = new System.Drawing.Point(203, 36);
            this.purpose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.purpose.Multiline = true;
            this.purpose.Name = "purpose";
            this.purpose.Size = new System.Drawing.Size(416, 228);
            this.purpose.TabIndex = 19;
            this.purpose.Text = "Purpose";
            // 
            // recipients
            // 
            this.recipients.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.recipients.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.recipients.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recipients.ForeColor = System.Drawing.Color.White;
            this.recipients.Location = new System.Drawing.Point(719, 36);
            this.recipients.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.recipients.Multiline = true;
            this.recipients.Name = "recipients";
            this.recipients.Size = new System.Drawing.Size(404, 228);
            this.recipients.TabIndex = 18;
            this.recipients.Text = "Recipients";
            // 
            // scopeOfWork
            // 
            this.scopeOfWork.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.scopeOfWork.Controls.Add(this.label5);
            this.scopeOfWork.Controls.Add(this.dgvProcurementItems);
            this.scopeOfWork.Location = new System.Drawing.Point(4, 25);
            this.scopeOfWork.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.scopeOfWork.Name = "scopeOfWork";
            this.scopeOfWork.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.scopeOfWork.Size = new System.Drawing.Size(1221, 557);
            this.scopeOfWork.TabIndex = 2;
            this.scopeOfWork.Text = "Scope Of Work";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cambria", 11F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(4, 137);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(166, 22);
            this.label5.TabIndex = 11;
            this.label5.Text = "Procurement Items";
            // 
            // procurementItems
            // 
            this.dgvProcurementItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProcurementItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProcurementItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.itemName,
            this.itemDescription,
            this.itemQuantity,
            this.itemPrice});
            this.dgvProcurementItems.Location = new System.Drawing.Point(197, 90);
            this.dgvProcurementItems.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvProcurementItems.Name = "procurementItems";
            this.dgvProcurementItems.RowHeadersWidth = 51;
            this.dgvProcurementItems.Size = new System.Drawing.Size(921, 133);
            this.dgvProcurementItems.TabIndex = 1;
            // 
            // itemName
            // 
            this.itemName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.itemName.HeaderText = "Item Name";
            this.itemName.MinimumWidth = 6;
            this.itemName.Name = "itemName";
            // 
            // itemDescription
            // 
            this.itemDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.itemDescription.HeaderText = "Item Description";
            this.itemDescription.MinimumWidth = 6;
            this.itemDescription.Name = "itemDescription";
            // 
            // itemQuantity
            // 
            this.itemQuantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.itemQuantity.HeaderText = "Item Quantity";
            this.itemQuantity.MinimumWidth = 6;
            this.itemQuantity.Name = "itemQuantity";
            // 
            // itemPrice
            // 
            this.itemPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.itemPrice.HeaderText = "Item Price";
            this.itemPrice.MinimumWidth = 6;
            this.itemPrice.Name = "itemPrice";
            // 
            // responsibilities
            // 
            this.responsibilities.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.responsibilities.Controls.Add(this.project);
            this.responsibilities.Controls.Add(this.supplier);
            this.responsibilities.Location = new System.Drawing.Point(4, 25);
            this.responsibilities.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.responsibilities.Name = "responsibilities";
            this.responsibilities.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.responsibilities.Size = new System.Drawing.Size(1221, 557);
            this.responsibilities.TabIndex = 3;
            this.responsibilities.Text = "Responsibilities";
            // 
            // project
            // 
            this.project.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.project.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.project.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.project.ForeColor = System.Drawing.Color.White;
            this.project.Location = new System.Drawing.Point(603, 46);
            this.project.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.project.Multiline = true;
            this.project.Name = "project";
            this.project.Size = new System.Drawing.Size(463, 320);
            this.project.TabIndex = 19;
            this.project.Text = "Project";
            // 
            // supplier
            // 
            this.supplier.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.supplier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.supplier.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.supplier.ForeColor = System.Drawing.Color.White;
            this.supplier.Location = new System.Drawing.Point(48, 46);
            this.supplier.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.supplier.Multiline = true;
            this.supplier.Name = "supplier";
            this.supplier.Size = new System.Drawing.Size(436, 320);
            this.supplier.TabIndex = 18;
            this.supplier.Text = "Supplier";
            // 
            // performance
            // 
            this.performance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.performance.Controls.Add(this.reviewProcess);
            this.performance.Controls.Add(this.label4);
            this.performance.Controls.Add(this.dgvReviewCriteriaIntro);
            this.performance.Location = new System.Drawing.Point(4, 25);
            this.performance.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.performance.Name = "performance";
            this.performance.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.performance.Size = new System.Drawing.Size(1221, 557);
            this.performance.TabIndex = 4;
            this.performance.Text = "Performance";
            // 
            // reviewProcess
            // 
            this.reviewProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reviewProcess.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.reviewProcess.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reviewProcess.ForeColor = System.Drawing.Color.White;
            this.reviewProcess.Location = new System.Drawing.Point(168, 186);
            this.reviewProcess.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.reviewProcess.Multiline = true;
            this.reviewProcess.Name = "reviewProcess";
            this.reviewProcess.Size = new System.Drawing.Size(840, 308);
            this.reviewProcess.TabIndex = 18;
            this.reviewProcess.Text = "Review Process";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cambria", 11F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(8, 79);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 22);
            this.label4.TabIndex = 10;
            this.label4.Text = "Review Criteria";
            // 
            // reviewCriteriaIntro
            // 
            this.dgvReviewCriteriaIntro.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvReviewCriteriaIntro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReviewCriteriaIntro.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.reviewCriteria,
            this.reviewDecription});
            this.dgvReviewCriteriaIntro.Location = new System.Drawing.Point(168, 27);
            this.dgvReviewCriteriaIntro.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvReviewCriteriaIntro.Name = "reviewCriteriaIntro";
            this.dgvReviewCriteriaIntro.RowHeadersWidth = 51;
            this.dgvReviewCriteriaIntro.Size = new System.Drawing.Size(921, 133);
            this.dgvReviewCriteriaIntro.TabIndex = 0;
            // 
            // reviewCriteria
            // 
            this.reviewCriteria.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.reviewCriteria.HeaderText = "Criteria";
            this.reviewCriteria.MinimumWidth = 6;
            this.reviewCriteria.Name = "reviewCriteria";
            // 
            // reviewDecription
            // 
            this.reviewDecription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.reviewDecription.HeaderText = "Description";
            this.reviewDecription.MinimumWidth = 6;
            this.reviewDecription.Name = "reviewDecription";
            // 
            // termsAndConditions
            // 
            this.termsAndConditions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.termsAndConditions.Controls.Add(this.indemnity);
            this.termsAndConditions.Controls.Add(this.confidentiality);
            this.termsAndConditions.Controls.Add(this.law);
            this.termsAndConditions.Controls.Add(this.agreement);
            this.termsAndConditions.Controls.Add(this.invoicing);
            this.termsAndConditions.Controls.Add(this.termination);
            this.termsAndConditions.Controls.Add(this.disputes);
            this.termsAndConditions.Controls.Add(this.payment);
            this.termsAndConditions.Location = new System.Drawing.Point(4, 25);
            this.termsAndConditions.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.termsAndConditions.Name = "termsAndConditions";
            this.termsAndConditions.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.termsAndConditions.Size = new System.Drawing.Size(1221, 557);
            this.termsAndConditions.TabIndex = 5;
            this.termsAndConditions.Text = "Terms and Conditions";
            // 
            // indemnity
            // 
            this.indemnity.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.indemnity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.indemnity.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.indemnity.ForeColor = System.Drawing.Color.White;
            this.indemnity.Location = new System.Drawing.Point(833, 198);
            this.indemnity.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.indemnity.Multiline = true;
            this.indemnity.Name = "indemnity";
            this.indemnity.Size = new System.Drawing.Size(364, 136);
            this.indemnity.TabIndex = 24;
            this.indemnity.Text = "Indemnity";
            // 
            // confidentiality
            // 
            this.confidentiality.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.confidentiality.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.confidentiality.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confidentiality.ForeColor = System.Drawing.Color.White;
            this.confidentiality.Location = new System.Drawing.Point(833, 26);
            this.confidentiality.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.confidentiality.Multiline = true;
            this.confidentiality.Name = "confidentiality";
            this.confidentiality.Size = new System.Drawing.Size(364, 136);
            this.confidentiality.TabIndex = 23;
            this.confidentiality.Text = "Confidentiality";
            // 
            // law
            // 
            this.law.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.law.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.law.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.law.ForeColor = System.Drawing.Color.White;
            this.law.Location = new System.Drawing.Point(8, 367);
            this.law.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.law.Multiline = true;
            this.law.Name = "law";
            this.law.Size = new System.Drawing.Size(364, 136);
            this.law.TabIndex = 22;
            this.law.Text = "Law";
            // 
            // agreement
            // 
            this.agreement.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.agreement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.agreement.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.agreement.ForeColor = System.Drawing.Color.White;
            this.agreement.Location = new System.Drawing.Point(436, 367);
            this.agreement.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.agreement.Multiline = true;
            this.agreement.Name = "agreement";
            this.agreement.Size = new System.Drawing.Size(352, 136);
            this.agreement.TabIndex = 21;
            this.agreement.Text = "Agreement";
            // 
            // invoicing
            // 
            this.invoicing.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.invoicing.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.invoicing.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.invoicing.ForeColor = System.Drawing.Color.White;
            this.invoicing.Location = new System.Drawing.Point(436, 26);
            this.invoicing.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.invoicing.Multiline = true;
            this.invoicing.Name = "invoicing";
            this.invoicing.Size = new System.Drawing.Size(352, 136);
            this.invoicing.TabIndex = 20;
            this.invoicing.Text = "Invoicing";
            // 
            // termination
            // 
            this.termination.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.termination.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.termination.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.termination.ForeColor = System.Drawing.Color.White;
            this.termination.Location = new System.Drawing.Point(8, 198);
            this.termination.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.termination.Multiline = true;
            this.termination.Name = "termination";
            this.termination.Size = new System.Drawing.Size(364, 136);
            this.termination.TabIndex = 19;
            this.termination.Text = "Termination";
            // 
            // disputes
            // 
            this.disputes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.disputes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.disputes.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.disputes.ForeColor = System.Drawing.Color.White;
            this.disputes.Location = new System.Drawing.Point(436, 198);
            this.disputes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.disputes.Multiline = true;
            this.disputes.Name = "disputes";
            this.disputes.Size = new System.Drawing.Size(352, 136);
            this.disputes.TabIndex = 18;
            this.disputes.Text = "Disputes";
            // 
            // payment
            // 
            this.payment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.payment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.payment.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.payment.ForeColor = System.Drawing.Color.White;
            this.payment.Location = new System.Drawing.Point(8, 26);
            this.payment.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.payment.Multiline = true;
            this.payment.Name = "payment";
            this.payment.Size = new System.Drawing.Size(364, 136);
            this.payment.TabIndex = 17;
            this.payment.Text = "Payment";
            // 
            // reviewSchedule
            // 
            this.reviewSchedule.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.reviewSchedule.Location = new System.Drawing.Point(4, 25);
            this.reviewSchedule.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.reviewSchedule.Name = "reviewSchedule";
            this.reviewSchedule.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.reviewSchedule.Size = new System.Drawing.Size(1221, 557);
            this.reviewSchedule.TabIndex = 6;
            this.reviewSchedule.Text = "Review Schedule";
            // 
            // deliverySchedule
            // 
            this.deliverySchedule.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.deliverySchedule.Location = new System.Drawing.Point(4, 25);
            this.deliverySchedule.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.deliverySchedule.Name = "deliverySchedule";
            this.deliverySchedule.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.deliverySchedule.Size = new System.Drawing.Size(1221, 557);
            this.deliverySchedule.TabIndex = 7;
            this.deliverySchedule.Text = "Delivery Schedule";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(545, 13);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(645, 12);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(130, 23);
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "Export to Word";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // SupplierContractDocumentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(1261, 652);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "SupplierContractDocumentForm";
            this.Text = "SupplierContractDocumentForm";
            this.Load += new System.EventHandler(this.SupplierContractDocumentForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.documentControl.ResumeLayout(false);
            this.documentControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocumentApprovals)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocumentHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocumentInformation)).EndInit();
            this.introduction.ResumeLayout(false);
            this.introduction.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDefinitions)).EndInit();
            this.scopeOfWork.ResumeLayout(false);
            this.scopeOfWork.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProcurementItems)).EndInit();
            this.responsibilities.ResumeLayout(false);
            this.responsibilities.PerformLayout();
            this.performance.ResumeLayout(false);
            this.performance.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReviewCriteriaIntro)).EndInit();
            this.termsAndConditions.ResumeLayout(false);
            this.termsAndConditions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage documentControl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvDocumentApprovals;
        private System.Windows.Forms.DataGridViewTextBoxColumn approvalRole;
        private System.Windows.Forms.DataGridViewTextBoxColumn approvalName;
        private System.Windows.Forms.DataGridViewTextBoxColumn approvalSignature;
        private System.Windows.Forms.DataGridViewTextBoxColumn approvalDate;
        private System.Windows.Forms.DataGridView dgvDocumentHistory;
        private System.Windows.Forms.DataGridViewTextBoxColumn Version;
        private System.Windows.Forms.DataGridViewTextBoxColumn historyIssueDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn historyChanges;
        private System.Windows.Forms.DataGridView dgvDocumentInformation;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Information;
        private System.Windows.Forms.TabPage introduction;
        private System.Windows.Forms.TabPage scopeOfWork;
        private System.Windows.Forms.TabPage responsibilities;
        private System.Windows.Forms.TabPage performance;
        private System.Windows.Forms.TabPage termsAndConditions;
        private System.Windows.Forms.TextBox reviewProcess;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvReviewCriteriaIntro;
        private System.Windows.Forms.DataGridViewTextBoxColumn reviewCriteria;
        private System.Windows.Forms.DataGridViewTextBoxColumn reviewDecription;
        private System.Windows.Forms.TextBox indemnity;
        private System.Windows.Forms.TextBox confidentiality;
        private System.Windows.Forms.TextBox law;
        private System.Windows.Forms.TextBox agreement;
        private System.Windows.Forms.TextBox invoicing;
        private System.Windows.Forms.TextBox termination;
        private System.Windows.Forms.TextBox disputes;
        private System.Windows.Forms.TextBox payment;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvProcurementItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemPrice;
        private System.Windows.Forms.TextBox project;
        private System.Windows.Forms.TextBox supplier;
        private System.Windows.Forms.TabPage reviewSchedule;
        private System.Windows.Forms.TabPage deliverySchedule;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvDefinitions;
        private System.Windows.Forms.DataGridViewTextBoxColumn term;
        private System.Windows.Forms.DataGridViewTextBoxColumn definition;
        private System.Windows.Forms.TextBox purpose;
        private System.Windows.Forms.TextBox recipients;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExport;
    }
}