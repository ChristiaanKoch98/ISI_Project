namespace ProjectManagementToolkit.MPMM.MPMM_Document_Forms
{
    partial class StatementOfWorkDocumentForm
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
            this.tabPage1 = new System.Windows.Forms.TabPage();
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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnSaveIntro = new System.Windows.Forms.Button();
            this.txtIntroduction = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnSaveObjectives = new System.Windows.Forms.Button();
            this.txtObjectives = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.btnSaveResponsibilities = new System.Windows.Forms.Button();
            this.txtProjectResponsibilities = new System.Windows.Forms.TextBox();
            this.txtSupplierResponsibilities = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.btnSaveTermsOfSupply = new System.Windows.Forms.Button();
            this.txtOtherTerms = new System.Windows.Forms.TextBox();
            this.txtConfidentiality = new System.Windows.Forms.TextBox();
            this.txtPaymentTerms = new System.Windows.Forms.TextBox();
            this.txtAcceptanceTerms = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.txtProjectName = new System.Windows.Forms.TextBox();
            this.btnSaveProjectName = new System.Windows.Forms.Button();
            this.btnStatementSave = new System.Windows.Forms.Button();
            this.btnExportStatementOfWork = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDocApprovals)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDocHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docInfoGridData)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Location = new System.Drawing.Point(13, 45);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(830, 397);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.tabPage1.Controls.Add(this.dataGridViewDocApprovals);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.dataGridViewDocHistory);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.docInfoGridData);
            this.tabPage1.Controls.Add(this.dcmntInfoLabel);
            this.tabPage1.ForeColor = System.Drawing.Color.White;
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(822, 372);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Document Control";
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // dataGridViewDocApprovals
            // 
            this.dataGridViewDocApprovals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDocApprovals.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.approvalRole,
            this.approvalName,
            this.approvalSignature,
            this.approvalDate});
            this.dataGridViewDocApprovals.Location = new System.Drawing.Point(188, 241);
            this.dataGridViewDocApprovals.Name = "dataGridViewDocApprovals";
            this.dataGridViewDocApprovals.RowHeadersWidth = 51;
            this.dataGridViewDocApprovals.Size = new System.Drawing.Size(628, 101);
            this.dataGridViewDocApprovals.TabIndex = 14;
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
            this.label3.Location = new System.Drawing.Point(14, 272);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 19);
            this.label3.TabIndex = 13;
            this.label3.Text = "Document Approvals";
            // 
            // dataGridViewDocHistory
            // 
            this.dataGridViewDocHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDocHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Version,
            this.historyIssueDate,
            this.historyChanges});
            this.dataGridViewDocHistory.Location = new System.Drawing.Point(188, 126);
            this.dataGridViewDocHistory.Name = "dataGridViewDocHistory";
            this.dataGridViewDocHistory.RowHeadersWidth = 51;
            this.dataGridViewDocHistory.Size = new System.Drawing.Size(628, 85);
            this.dataGridViewDocHistory.TabIndex = 12;
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
            this.label2.Location = new System.Drawing.Point(14, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 19);
            this.label2.TabIndex = 11;
            this.label2.Text = "Document History";
            // 
            // docInfoGridData
            // 
            this.docInfoGridData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.docInfoGridData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.docNameColumn,
            this.Information});
            this.docInfoGridData.Location = new System.Drawing.Point(188, 6);
            this.docInfoGridData.Name = "docInfoGridData";
            this.docInfoGridData.RowHeadersWidth = 51;
            this.docInfoGridData.Size = new System.Drawing.Size(628, 81);
            this.docInfoGridData.TabIndex = 10;
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
            this.dcmntInfoLabel.Location = new System.Drawing.Point(14, 37);
            this.dcmntInfoLabel.Name = "dcmntInfoLabel";
            this.dcmntInfoLabel.Size = new System.Drawing.Size(167, 19);
            this.dcmntInfoLabel.TabIndex = 9;
            this.dcmntInfoLabel.Text = "Document Information";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.tabPage2.Controls.Add(this.btnSaveIntro);
            this.tabPage2.Controls.Add(this.txtIntroduction);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(822, 372);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Introduction";
            // 
            // btnSaveIntro
            // 
            this.btnSaveIntro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.btnSaveIntro.Location = new System.Drawing.Point(369, 332);
            this.btnSaveIntro.Name = "btnSaveIntro";
            this.btnSaveIntro.Size = new System.Drawing.Size(95, 34);
            this.btnSaveIntro.TabIndex = 24;
            this.btnSaveIntro.Text = "Save Introduction";
            this.btnSaveIntro.UseVisualStyleBackColor = true;
            this.btnSaveIntro.Click += new System.EventHandler(this.btnSaveIntro_Click);
            // 
            // txtIntroduction
            // 
            this.txtIntroduction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.txtIntroduction.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIntroduction.ForeColor = System.Drawing.Color.White;
            this.txtIntroduction.Location = new System.Drawing.Point(6, 6);
            this.txtIntroduction.Multiline = true;
            this.txtIntroduction.Name = "txtIntroduction";
            this.txtIntroduction.Size = new System.Drawing.Size(810, 320);
            this.txtIntroduction.TabIndex = 32;
            this.txtIntroduction.Text = "Introduction";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.tabPage3.Controls.Add(this.btnSaveObjectives);
            this.tabPage3.Controls.Add(this.txtObjectives);
            this.tabPage3.ForeColor = System.Drawing.Color.White;
            this.tabPage3.Location = new System.Drawing.Point(4, 21);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(822, 372);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Objectives";
            // 
            // btnSaveObjectives
            // 
            this.btnSaveObjectives.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.btnSaveObjectives.Location = new System.Drawing.Point(369, 332);
            this.btnSaveObjectives.Name = "btnSaveObjectives";
            this.btnSaveObjectives.Size = new System.Drawing.Size(95, 34);
            this.btnSaveObjectives.TabIndex = 33;
            this.btnSaveObjectives.Text = "Save Objectives";
            this.btnSaveObjectives.UseVisualStyleBackColor = true;
            // 
            // txtObjectives
            // 
            this.txtObjectives.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.txtObjectives.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObjectives.ForeColor = System.Drawing.Color.White;
            this.txtObjectives.Location = new System.Drawing.Point(6, 6);
            this.txtObjectives.Multiline = true;
            this.txtObjectives.Name = "txtObjectives";
            this.txtObjectives.Size = new System.Drawing.Size(810, 320);
            this.txtObjectives.TabIndex = 34;
            this.txtObjectives.Text = "Objectives";
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.tabPage4.Controls.Add(this.label1);
            this.tabPage4.Controls.Add(this.dataGridView4);
            this.tabPage4.Location = new System.Drawing.Point(4, 21);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(822, 372);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Scope of Work";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 12F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(330, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 19);
            this.label1.TabIndex = 10;
            this.label1.Text = "Scope of Work Table";
            // 
            // dataGridView4
            // 
            this.dataGridView4.AllowUserToOrderColumns = true;
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column10,
            this.Column11,
            this.Column12});
            this.dataGridView4.Location = new System.Drawing.Point(6, 25);
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.Size = new System.Drawing.Size(810, 341);
            this.dataGridView4.TabIndex = 0;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Item Title";
            this.Column10.Name = "Column10";
            // 
            // Column11
            // 
            this.Column11.HeaderText = "Item Description";
            this.Column11.Name = "Column11";
            // 
            // Column12
            // 
            this.Column12.HeaderText = "Item Quantity";
            this.Column12.Name = "Column12";
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.tabPage5.Controls.Add(this.btnSaveResponsibilities);
            this.tabPage5.Controls.Add(this.txtProjectResponsibilities);
            this.tabPage5.Controls.Add(this.txtSupplierResponsibilities);
            this.tabPage5.Controls.Add(this.label6);
            this.tabPage5.Controls.Add(this.label5);
            this.tabPage5.ForeColor = System.Drawing.Color.White;
            this.tabPage5.Location = new System.Drawing.Point(4, 21);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(822, 372);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Responsibilites";
            // 
            // btnSaveResponsibilities
            // 
            this.btnSaveResponsibilities.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.btnSaveResponsibilities.Location = new System.Drawing.Point(721, 315);
            this.btnSaveResponsibilities.Name = "btnSaveResponsibilities";
            this.btnSaveResponsibilities.Size = new System.Drawing.Size(95, 51);
            this.btnSaveResponsibilities.TabIndex = 24;
            this.btnSaveResponsibilities.Text = "Save Responsibilities";
            this.btnSaveResponsibilities.UseVisualStyleBackColor = true;
            // 
            // txtProjectResponsibilities
            // 
            this.txtProjectResponsibilities.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.txtProjectResponsibilities.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProjectResponsibilities.ForeColor = System.Drawing.Color.White;
            this.txtProjectResponsibilities.Location = new System.Drawing.Point(169, 165);
            this.txtProjectResponsibilities.Multiline = true;
            this.txtProjectResponsibilities.Name = "txtProjectResponsibilities";
            this.txtProjectResponsibilities.Size = new System.Drawing.Size(647, 144);
            this.txtProjectResponsibilities.TabIndex = 34;
            this.txtProjectResponsibilities.Text = "Project Responsibilities";
            // 
            // txtSupplierResponsibilities
            // 
            this.txtSupplierResponsibilities.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.txtSupplierResponsibilities.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSupplierResponsibilities.ForeColor = System.Drawing.Color.White;
            this.txtSupplierResponsibilities.Location = new System.Drawing.Point(169, 6);
            this.txtSupplierResponsibilities.Multiline = true;
            this.txtSupplierResponsibilities.Name = "txtSupplierResponsibilities";
            this.txtSupplierResponsibilities.Size = new System.Drawing.Size(647, 144);
            this.txtSupplierResponsibilities.TabIndex = 33;
            this.txtSupplierResponsibilities.Text = "Supplier Responsibilities";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Cambria", 11F);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(8, 230);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(155, 17);
            this.label6.TabIndex = 3;
            this.label6.Text = "Project Responsibilities";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cambria", 11F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(6, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(157, 17);
            this.label5.TabIndex = 2;
            this.label5.Text = "Supplier Responsibilites";
            // 
            // tabPage6
            // 
            this.tabPage6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.tabPage6.Controls.Add(this.btnSaveTermsOfSupply);
            this.tabPage6.Controls.Add(this.txtOtherTerms);
            this.tabPage6.Controls.Add(this.txtConfidentiality);
            this.tabPage6.Controls.Add(this.txtPaymentTerms);
            this.tabPage6.Controls.Add(this.txtAcceptanceTerms);
            this.tabPage6.Controls.Add(this.label10);
            this.tabPage6.Controls.Add(this.label9);
            this.tabPage6.Controls.Add(this.label8);
            this.tabPage6.Controls.Add(this.label7);
            this.tabPage6.ForeColor = System.Drawing.Color.White;
            this.tabPage6.Location = new System.Drawing.Point(4, 21);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(822, 372);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Terms of Supply";
            // 
            // btnSaveTermsOfSupply
            // 
            this.btnSaveTermsOfSupply.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.btnSaveTermsOfSupply.Location = new System.Drawing.Point(721, 324);
            this.btnSaveTermsOfSupply.Name = "btnSaveTermsOfSupply";
            this.btnSaveTermsOfSupply.Size = new System.Drawing.Size(95, 42);
            this.btnSaveTermsOfSupply.TabIndex = 24;
            this.btnSaveTermsOfSupply.Text = "Save Terms of Supply";
            this.btnSaveTermsOfSupply.UseVisualStyleBackColor = true;
            // 
            // txtOtherTerms
            // 
            this.txtOtherTerms.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.txtOtherTerms.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOtherTerms.ForeColor = System.Drawing.Color.White;
            this.txtOtherTerms.Location = new System.Drawing.Point(169, 246);
            this.txtOtherTerms.Multiline = true;
            this.txtOtherTerms.Name = "txtOtherTerms";
            this.txtOtherTerms.Size = new System.Drawing.Size(647, 74);
            this.txtOtherTerms.TabIndex = 38;
            this.txtOtherTerms.Text = "Other Terms";
            // 
            // txtConfidentiality
            // 
            this.txtConfidentiality.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.txtConfidentiality.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfidentiality.ForeColor = System.Drawing.Color.White;
            this.txtConfidentiality.Location = new System.Drawing.Point(169, 166);
            this.txtConfidentiality.Multiline = true;
            this.txtConfidentiality.Name = "txtConfidentiality";
            this.txtConfidentiality.Size = new System.Drawing.Size(647, 74);
            this.txtConfidentiality.TabIndex = 37;
            this.txtConfidentiality.Text = "Confidentiality";
            // 
            // txtPaymentTerms
            // 
            this.txtPaymentTerms.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.txtPaymentTerms.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaymentTerms.ForeColor = System.Drawing.Color.White;
            this.txtPaymentTerms.Location = new System.Drawing.Point(169, 86);
            this.txtPaymentTerms.Multiline = true;
            this.txtPaymentTerms.Name = "txtPaymentTerms";
            this.txtPaymentTerms.Size = new System.Drawing.Size(647, 74);
            this.txtPaymentTerms.TabIndex = 36;
            this.txtPaymentTerms.Text = "Payment Terms";
            // 
            // txtAcceptanceTerms
            // 
            this.txtAcceptanceTerms.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.txtAcceptanceTerms.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAcceptanceTerms.ForeColor = System.Drawing.Color.White;
            this.txtAcceptanceTerms.Location = new System.Drawing.Point(169, 6);
            this.txtAcceptanceTerms.Multiline = true;
            this.txtAcceptanceTerms.Name = "txtAcceptanceTerms";
            this.txtAcceptanceTerms.Size = new System.Drawing.Size(647, 74);
            this.txtAcceptanceTerms.TabIndex = 34;
            this.txtAcceptanceTerms.Text = "Acceptance Terms";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Cambria", 11F);
            this.label10.Location = new System.Drawing.Point(6, 271);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 17);
            this.label10.TabIndex = 7;
            this.label10.Text = "Other Terms";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Cambria", 11F);
            this.label9.Location = new System.Drawing.Point(6, 192);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(101, 17);
            this.label9.TabIndex = 6;
            this.label9.Text = "Confidentiality";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Cambria", 11F);
            this.label8.Location = new System.Drawing.Point(6, 115);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 17);
            this.label8.TabIndex = 5;
            this.label8.Text = "Payment Terms";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Cambria", 11F);
            this.label7.Location = new System.Drawing.Point(6, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(122, 17);
            this.label7.TabIndex = 4;
            this.label7.Text = "Acceptance Terms";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.White;
            this.label27.Location = new System.Drawing.Point(11, 9);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(153, 12);
            this.label27.TabIndex = 23;
            this.label27.Text = "Please Enter Your Project Name:";
            // 
            // txtProjectName
            // 
            this.txtProjectName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.txtProjectName.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProjectName.ForeColor = System.Drawing.Color.White;
            this.txtProjectName.Location = new System.Drawing.Point(180, 6);
            this.txtProjectName.Name = "txtProjectName";
            this.txtProjectName.Size = new System.Drawing.Size(113, 20);
            this.txtProjectName.TabIndex = 22;
            this.txtProjectName.Text = "Project Name";
            // 
            // btnSaveProjectName
            // 
            this.btnSaveProjectName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.btnSaveProjectName.Location = new System.Drawing.Point(748, 6);
            this.btnSaveProjectName.Name = "btnSaveProjectName";
            this.btnSaveProjectName.Size = new System.Drawing.Size(95, 45);
            this.btnSaveProjectName.TabIndex = 21;
            this.btnSaveProjectName.Text = "Save Project Name";
            this.btnSaveProjectName.UseVisualStyleBackColor = true;
            this.btnSaveProjectName.Click += new System.EventHandler(this.btnSaveProjectName_Click);
            // 
            // btnStatementSave
            // 
            this.btnStatementSave.ForeColor = System.Drawing.Color.Black;
            this.btnStatementSave.Location = new System.Drawing.Point(411, 13);
            this.btnStatementSave.Name = "btnStatementSave";
            this.btnStatementSave.Size = new System.Drawing.Size(75, 23);
            this.btnStatementSave.TabIndex = 24;
            this.btnStatementSave.Text = "Save";
            this.btnStatementSave.UseVisualStyleBackColor = true;
            this.btnStatementSave.Click += new System.EventHandler(this.btnStatementSave_Click_1);
            // 
            // btnExportStatementOfWork
            // 
            this.btnExportStatementOfWork.ForeColor = System.Drawing.Color.Black;
            this.btnExportStatementOfWork.Location = new System.Drawing.Point(569, 13);
            this.btnExportStatementOfWork.Name = "btnExportStatementOfWork";
            this.btnExportStatementOfWork.Size = new System.Drawing.Size(75, 23);
            this.btnExportStatementOfWork.TabIndex = 25;
            this.btnExportStatementOfWork.Text = "Export";
            this.btnExportStatementOfWork.UseVisualStyleBackColor = true;
            this.btnExportStatementOfWork.Click += new System.EventHandler(this.btnExportStatementOfWork_Click);
            // 
            // StatementOfWorkDocumentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(855, 454);
            this.Controls.Add(this.btnExportStatementOfWork);
            this.Controls.Add(this.btnStatementSave);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.txtProjectName);
            this.Controls.Add(this.btnSaveProjectName);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "StatementOfWorkDocumentForm";
            this.Text = "StatementOfWorkDocumentForm";
            this.Load += new System.EventHandler(this.StatementOfWorkDocumentForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDocApprovals)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDocHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docInfoGridData)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.DataGridView dataGridView4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox txtProjectName;
        private System.Windows.Forms.Button btnSaveProjectName;
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView docInfoGridData;
        private System.Windows.Forms.DataGridViewTextBoxColumn docNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Information;
        private System.Windows.Forms.Label dcmntInfoLabel;
        private System.Windows.Forms.Button btnSaveIntro;
        private System.Windows.Forms.TextBox txtIntroduction;
        private System.Windows.Forms.Button btnSaveObjectives;
        private System.Windows.Forms.TextBox txtObjectives;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSaveResponsibilities;
        private System.Windows.Forms.TextBox txtProjectResponsibilities;
        private System.Windows.Forms.TextBox txtSupplierResponsibilities;
        private System.Windows.Forms.Button btnSaveTermsOfSupply;
        private System.Windows.Forms.TextBox txtOtherTerms;
        private System.Windows.Forms.TextBox txtConfidentiality;
        private System.Windows.Forms.TextBox txtPaymentTerms;
        private System.Windows.Forms.TextBox txtAcceptanceTerms;
        private System.Windows.Forms.Button btnStatementSave;
        private System.Windows.Forms.Button btnExportStatementOfWork;
    }
}