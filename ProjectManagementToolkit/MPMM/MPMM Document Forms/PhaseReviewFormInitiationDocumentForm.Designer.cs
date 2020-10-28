namespace ProjectManagementToolkit.MPMM.MPMM_Document_Forms
{
    partial class PhaseReviewFormInitiationDocumentForm
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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.documentApprovals = new System.Windows.Forms.DataGridView();
            this.approvalRole = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.approvalName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.approvalSignature = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.approvalDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.documentHistory = new System.Windows.Forms.DataGridView();
            this.Version = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.historyIssueDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.historyChanges = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.documentInformation = new System.Windows.Forms.DataGridView();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Information = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.projectName = new System.Windows.Forms.TextBox();
            this.projectManager = new System.Windows.Forms.TextBox();
            this.projectSponsor = new System.Windows.Forms.TextBox();
            this.reportPreparationDate = new System.Windows.Forms.TextBox();
            this.reportPreparedBy = new System.Windows.Forms.TextBox();
            this.reportingPeriod = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.summary = new System.Windows.Forms.TextBox();
            this.projectExpenses = new System.Windows.Forms.TextBox();
            this.projectRisks = new System.Windows.Forms.TextBox();
            this.projectDeliverables = new System.Windows.Forms.TextBox();
            this.projectSchedule = new System.Windows.Forms.TextBox();
            this.projectIssues = new System.Windows.Forms.TextBox();
            this.projectChanges = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.reviewDetails = new System.Windows.Forms.DataGridView();
            this.reviewCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reviewQuestions = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.answer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.variance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.documentControl.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentApprovals)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentInformation)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reviewDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.documentControl);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 41);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(922, 419);
            this.tabControl1.TabIndex = 0;
            // 
            // documentControl
            // 
            this.documentControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.documentControl.Controls.Add(this.label3);
            this.documentControl.Controls.Add(this.label2);
            this.documentControl.Controls.Add(this.label1);
            this.documentControl.Controls.Add(this.documentApprovals);
            this.documentControl.Controls.Add(this.documentHistory);
            this.documentControl.Controls.Add(this.documentInformation);
            this.documentControl.Location = new System.Drawing.Point(4, 22);
            this.documentControl.Name = "documentControl";
            this.documentControl.Padding = new System.Windows.Forms.Padding(3);
            this.documentControl.Size = new System.Drawing.Size(914, 393);
            this.documentControl.TabIndex = 0;
            this.documentControl.Text = "Document Control";
            this.documentControl.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(914, 393);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Project Details & Overall Status";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.reviewDetails);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(914, 393);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Review Details &  Approval Details";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cambria", 11F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(31, 313);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Document Approvals";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cambria", 11F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(31, 186);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Document History";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 11F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(31, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Document Information";
            // 
            // documentApprovals
            // 
            this.documentApprovals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.documentApprovals.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.approvalRole,
            this.approvalName,
            this.approvalSignature,
            this.approvalDate});
            this.documentApprovals.Location = new System.Drawing.Point(192, 253);
            this.documentApprovals.Name = "documentApprovals";
            this.documentApprovals.RowHeadersWidth = 51;
            this.documentApprovals.Size = new System.Drawing.Size(691, 124);
            this.documentApprovals.TabIndex = 8;
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
            this.documentHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.documentHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Version,
            this.historyIssueDate,
            this.historyChanges});
            this.documentHistory.Location = new System.Drawing.Point(192, 129);
            this.documentHistory.Name = "documentHistory";
            this.documentHistory.RowHeadersWidth = 51;
            this.documentHistory.Size = new System.Drawing.Size(691, 118);
            this.documentHistory.TabIndex = 7;
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
            this.documentInformation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.documentInformation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Type,
            this.Information});
            this.documentInformation.Location = new System.Drawing.Point(192, 15);
            this.documentInformation.Name = "documentInformation";
            this.documentInformation.RowHeadersWidth = 51;
            this.documentInformation.Size = new System.Drawing.Size(691, 108);
            this.documentInformation.TabIndex = 6;
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
            // panel1
            // 
            this.panel1.Controls.Add(this.reportingPeriod);
            this.panel1.Controls.Add(this.reportPreparedBy);
            this.panel1.Controls.Add(this.reportPreparationDate);
            this.panel1.Controls.Add(this.projectSponsor);
            this.panel1.Controls.Add(this.projectManager);
            this.panel1.Controls.Add(this.projectName);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(12, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(884, 118);
            this.panel1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cambria", 11F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(3, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "Project Name:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cambria", 11F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(432, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(165, 17);
            this.label5.TabIndex = 12;
            this.label5.Text = "Report Preparation Date:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Cambria", 11F);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(432, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(136, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "Report Prepared By:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Cambria", 11F);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(3, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 17);
            this.label7.TabIndex = 14;
            this.label7.Text = "Manager:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Cambria", 11F);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(432, 69);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 17);
            this.label8.TabIndex = 15;
            this.label8.Text = "Report Period";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Cambria", 11F);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(3, 69);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(112, 17);
            this.label9.TabIndex = 16;
            this.label9.Text = "Project Sponsor:";
            // 
            // projectName
            // 
            this.projectName.Location = new System.Drawing.Point(146, 8);
            this.projectName.Name = "projectName";
            this.projectName.Size = new System.Drawing.Size(233, 20);
            this.projectName.TabIndex = 17;
            // 
            // projectManager
            // 
            this.projectManager.Location = new System.Drawing.Point(146, 38);
            this.projectManager.Name = "projectManager";
            this.projectManager.Size = new System.Drawing.Size(233, 20);
            this.projectManager.TabIndex = 18;
            // 
            // projectSponsor
            // 
            this.projectSponsor.Location = new System.Drawing.Point(146, 69);
            this.projectSponsor.Name = "projectSponsor";
            this.projectSponsor.Size = new System.Drawing.Size(233, 20);
            this.projectSponsor.TabIndex = 19;
            // 
            // reportPreparationDate
            // 
            this.reportPreparationDate.Location = new System.Drawing.Point(626, 37);
            this.reportPreparationDate.Name = "reportPreparationDate";
            this.reportPreparationDate.Size = new System.Drawing.Size(233, 20);
            this.reportPreparationDate.TabIndex = 20;
            // 
            // reportPreparedBy
            // 
            this.reportPreparedBy.Location = new System.Drawing.Point(626, 8);
            this.reportPreparedBy.Name = "reportPreparedBy";
            this.reportPreparedBy.Size = new System.Drawing.Size(233, 20);
            this.reportPreparedBy.TabIndex = 21;
            // 
            // reportingPeriod
            // 
            this.reportingPeriod.Location = new System.Drawing.Point(626, 66);
            this.reportingPeriod.Name = "reportingPeriod";
            this.reportingPeriod.Size = new System.Drawing.Size(233, 20);
            this.reportingPeriod.TabIndex = 22;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.projectChanges);
            this.panel2.Controls.Add(this.projectIssues);
            this.panel2.Controls.Add(this.projectSchedule);
            this.panel2.Controls.Add(this.projectDeliverables);
            this.panel2.Controls.Add(this.projectRisks);
            this.panel2.Controls.Add(this.projectExpenses);
            this.panel2.Controls.Add(this.summary);
            this.panel2.Location = new System.Drawing.Point(12, 161);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(884, 226);
            this.panel2.TabIndex = 1;
            // 
            // summary
            // 
            this.summary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.summary.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.summary.ForeColor = System.Drawing.Color.White;
            this.summary.Location = new System.Drawing.Point(6, 16);
            this.summary.Multiline = true;
            this.summary.Name = "summary";
            this.summary.Size = new System.Drawing.Size(199, 90);
            this.summary.TabIndex = 16;
            this.summary.Text = "Summary";
            // 
            // projectExpenses
            // 
            this.projectExpenses.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.projectExpenses.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.projectExpenses.ForeColor = System.Drawing.Color.White;
            this.projectExpenses.Location = new System.Drawing.Point(228, 16);
            this.projectExpenses.Multiline = true;
            this.projectExpenses.Name = "projectExpenses";
            this.projectExpenses.Size = new System.Drawing.Size(199, 90);
            this.projectExpenses.TabIndex = 17;
            this.projectExpenses.Text = "Project Expenses";
            // 
            // projectRisks
            // 
            this.projectRisks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.projectRisks.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.projectRisks.ForeColor = System.Drawing.Color.White;
            this.projectRisks.Location = new System.Drawing.Point(452, 16);
            this.projectRisks.Multiline = true;
            this.projectRisks.Name = "projectRisks";
            this.projectRisks.Size = new System.Drawing.Size(199, 90);
            this.projectRisks.TabIndex = 18;
            this.projectRisks.Text = "Project Risks";
            // 
            // projectDeliverables
            // 
            this.projectDeliverables.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.projectDeliverables.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.projectDeliverables.ForeColor = System.Drawing.Color.White;
            this.projectDeliverables.Location = new System.Drawing.Point(228, 112);
            this.projectDeliverables.Multiline = true;
            this.projectDeliverables.Name = "projectDeliverables";
            this.projectDeliverables.Size = new System.Drawing.Size(199, 103);
            this.projectDeliverables.TabIndex = 19;
            this.projectDeliverables.Text = "Project Deliverables";
            // 
            // projectSchedule
            // 
            this.projectSchedule.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.projectSchedule.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.projectSchedule.ForeColor = System.Drawing.Color.White;
            this.projectSchedule.Location = new System.Drawing.Point(6, 112);
            this.projectSchedule.Multiline = true;
            this.projectSchedule.Name = "projectSchedule";
            this.projectSchedule.Size = new System.Drawing.Size(199, 103);
            this.projectSchedule.TabIndex = 20;
            this.projectSchedule.Text = "Project Schedule";
            // 
            // projectIssues
            // 
            this.projectIssues.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.projectIssues.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.projectIssues.ForeColor = System.Drawing.Color.White;
            this.projectIssues.Location = new System.Drawing.Point(452, 112);
            this.projectIssues.Multiline = true;
            this.projectIssues.Name = "projectIssues";
            this.projectIssues.Size = new System.Drawing.Size(199, 103);
            this.projectIssues.TabIndex = 21;
            this.projectIssues.Text = "Project Issues ";
            // 
            // projectChanges
            // 
            this.projectChanges.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.projectChanges.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.projectChanges.ForeColor = System.Drawing.Color.White;
            this.projectChanges.Location = new System.Drawing.Point(673, 16);
            this.projectChanges.Multiline = true;
            this.projectChanges.Name = "projectChanges";
            this.projectChanges.Size = new System.Drawing.Size(199, 90);
            this.projectChanges.TabIndex = 22;
            this.projectChanges.Text = "Project Changes";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Cambria", 11F);
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(8, 57);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(101, 17);
            this.label10.TabIndex = 11;
            this.label10.Text = "Review Details";
            // 
            // reviewDetails
            // 
            this.reviewDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.reviewDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.reviewCategory,
            this.reviewQuestions,
            this.answer,
            this.variance});
            this.reviewDetails.Location = new System.Drawing.Point(125, 21);
            this.reviewDetails.Name = "reviewDetails";
            this.reviewDetails.RowHeadersWidth = 51;
            this.reviewDetails.Size = new System.Drawing.Size(772, 108);
            this.reviewDetails.TabIndex = 10;
            // 
            // reviewCategory
            // 
            this.reviewCategory.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.reviewCategory.HeaderText = "Review Category";
            this.reviewCategory.MinimumWidth = 6;
            this.reviewCategory.Name = "reviewCategory";
            // 
            // reviewQuestions
            // 
            this.reviewQuestions.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.reviewQuestions.HeaderText = "Review Questions";
            this.reviewQuestions.MinimumWidth = 6;
            this.reviewQuestions.Name = "reviewQuestions";
            // 
            // answer
            // 
            this.answer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.answer.HeaderText = "Answer";
            this.answer.Name = "answer";
            // 
            // variance
            // 
            this.variance.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.variance.HeaderText = "Variance";
            this.variance.Name = "variance";
            // 
            // PhaseReviewFormInitiationDocumentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(946, 473);
            this.Controls.Add(this.tabControl1);
            this.Name = "PhaseReviewFormInitiationDocumentForm";
            this.Text = "PhaseReviewFormInitiationDocumentForm";
            this.tabControl1.ResumeLayout(false);
            this.documentControl.ResumeLayout(false);
            this.documentControl.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentApprovals)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentInformation)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reviewDetails)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage documentControl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView documentApprovals;
        private System.Windows.Forms.DataGridViewTextBoxColumn approvalRole;
        private System.Windows.Forms.DataGridViewTextBoxColumn approvalName;
        private System.Windows.Forms.DataGridViewTextBoxColumn approvalSignature;
        private System.Windows.Forms.DataGridViewTextBoxColumn approvalDate;
        private System.Windows.Forms.DataGridView documentHistory;
        private System.Windows.Forms.DataGridViewTextBoxColumn Version;
        private System.Windows.Forms.DataGridViewTextBoxColumn historyIssueDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn historyChanges;
        private System.Windows.Forms.DataGridView documentInformation;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Information;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox projectChanges;
        private System.Windows.Forms.TextBox projectIssues;
        private System.Windows.Forms.TextBox projectSchedule;
        private System.Windows.Forms.TextBox projectDeliverables;
        private System.Windows.Forms.TextBox projectRisks;
        private System.Windows.Forms.TextBox projectExpenses;
        private System.Windows.Forms.TextBox summary;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox reportingPeriod;
        private System.Windows.Forms.TextBox reportPreparedBy;
        private System.Windows.Forms.TextBox reportPreparationDate;
        private System.Windows.Forms.TextBox projectSponsor;
        private System.Windows.Forms.TextBox projectManager;
        private System.Windows.Forms.TextBox projectName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView reviewDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn reviewCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn reviewQuestions;
        private System.Windows.Forms.DataGridViewTextBoxColumn answer;
        private System.Windows.Forms.DataGridViewTextBoxColumn variance;
    }
}