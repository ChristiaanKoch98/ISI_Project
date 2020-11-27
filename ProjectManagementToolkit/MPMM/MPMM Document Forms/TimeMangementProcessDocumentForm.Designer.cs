namespace ProjectManagementToolkit.MPMM.MPMM_Document_Forms
{
    partial class TimeMangementProcessDocumentForm
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
            this.label4 = new System.Windows.Forms.Label();
            this.txtProjectName = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.approvalRole = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.approvalName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.approvalSignature = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.approvalDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.historyVersion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.historyIssueDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.historyChanges = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.InformationType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Information = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txttimemanagementprocessUpdateProcessPlan = new System.Windows.Forms.TextBox();
            this.txttimemanagementprocessApprovedTimesheet = new System.Windows.Forms.TextBox();
            this.txttimemanagementprocessDocumentTimesheet = new System.Windows.Forms.TextBox();
            this.txttimemanagementprocessOverview = new System.Windows.Forms.TextBox();
            this.txttimemanagementprocessDescription = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txttimemanagementrolesProjectAdminstratror = new System.Windows.Forms.TextBox();
            this.txttimemanagementrolesProjectManager = new System.Windows.Forms.TextBox();
            this.txttimemanagementrolesTeamMember = new System.Windows.Forms.TextBox();
            this.txttimemanagementrolesDescription = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.txttimemanagementdocumentsTimeSheetRegister = new System.Windows.Forms.TextBox();
            this.txttimemanagementdocumentsTimeSheet = new System.Windows.Forms.TextBox();
            this.txttimemanagementdocumentsDescription = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExportWord = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(6, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(153, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "Please Enter Your Project Name:";
            // 
            // txtProjectName
            // 
            this.txtProjectName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.txtProjectName.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProjectName.ForeColor = System.Drawing.Color.White;
            this.txtProjectName.Location = new System.Drawing.Point(165, 2);
            this.txtProjectName.Name = "txtProjectName";
            this.txtProjectName.Size = new System.Drawing.Size(100, 20);
            this.txtProjectName.TabIndex = 4;
            this.txtProjectName.Text = "Project Name";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(8, 57);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(820, 418);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.dataGridView3);
            this.tabPage1.Controls.Add(this.dataGridView2);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(812, 392);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Document Control";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cambria", 11F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(7, 304);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Document Approvals";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cambria", 11F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(7, 177);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Document History";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 11F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(7, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Document Information";
            // 
            // dataGridView3
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.approvalRole,
            this.approvalName,
            this.approvalSignature,
            this.approvalDate});
            this.dataGridView3.Location = new System.Drawing.Point(168, 244);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowHeadersWidth = 51;
            this.dataGridView3.Size = new System.Drawing.Size(638, 124);
            this.dataGridView3.TabIndex = 2;
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
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.historyVersion,
            this.historyIssueDate,
            this.historyChanges});
            this.dataGridView2.Location = new System.Drawing.Point(168, 120);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.Size = new System.Drawing.Size(638, 118);
            this.dataGridView2.TabIndex = 1;
            // 
            // historyVersion
            // 
            this.historyVersion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.historyVersion.HeaderText = "Version";
            this.historyVersion.MinimumWidth = 6;
            this.historyVersion.Name = "historyVersion";
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
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.InformationType,
            this.Information});
            this.dataGridView1.Location = new System.Drawing.Point(168, 6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(638, 108);
            this.dataGridView1.TabIndex = 0;
            // 
            // InformationType
            // 
            this.InformationType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.InformationType.HeaderText = "Type";
            this.InformationType.MinimumWidth = 6;
            this.InformationType.Name = "InformationType";
            // 
            // Information
            // 
            this.Information.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Information.HeaderText = "Information";
            this.Information.MinimumWidth = 6;
            this.Information.Name = "Information";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.tabPage2.Controls.Add(this.txttimemanagementprocessUpdateProcessPlan);
            this.tabPage2.Controls.Add(this.txttimemanagementprocessApprovedTimesheet);
            this.tabPage2.Controls.Add(this.txttimemanagementprocessDocumentTimesheet);
            this.tabPage2.Controls.Add(this.txttimemanagementprocessOverview);
            this.tabPage2.Controls.Add(this.txttimemanagementprocessDescription);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(812, 392);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Time Management Process";
            // 
            // txttimemanagementprocessUpdateProcessPlan
            // 
            this.txttimemanagementprocessUpdateProcessPlan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.txttimemanagementprocessUpdateProcessPlan.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttimemanagementprocessUpdateProcessPlan.ForeColor = System.Drawing.Color.White;
            this.txttimemanagementprocessUpdateProcessPlan.Location = new System.Drawing.Point(281, 285);
            this.txttimemanagementprocessUpdateProcessPlan.Multiline = true;
            this.txttimemanagementprocessUpdateProcessPlan.Name = "txttimemanagementprocessUpdateProcessPlan";
            this.txttimemanagementprocessUpdateProcessPlan.Size = new System.Drawing.Size(402, 85);
            this.txttimemanagementprocessUpdateProcessPlan.TabIndex = 4;
            this.txttimemanagementprocessUpdateProcessPlan.Text = "Update Project Plan";
            // 
            // txttimemanagementprocessApprovedTimesheet
            // 
            this.txttimemanagementprocessApprovedTimesheet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.txttimemanagementprocessApprovedTimesheet.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttimemanagementprocessApprovedTimesheet.ForeColor = System.Drawing.Color.White;
            this.txttimemanagementprocessApprovedTimesheet.Location = new System.Drawing.Point(281, 192);
            this.txttimemanagementprocessApprovedTimesheet.Multiline = true;
            this.txttimemanagementprocessApprovedTimesheet.Name = "txttimemanagementprocessApprovedTimesheet";
            this.txttimemanagementprocessApprovedTimesheet.Size = new System.Drawing.Size(403, 78);
            this.txttimemanagementprocessApprovedTimesheet.TabIndex = 3;
            this.txttimemanagementprocessApprovedTimesheet.Text = "Approve Timesheet";
            // 
            // txttimemanagementprocessDocumentTimesheet
            // 
            this.txttimemanagementprocessDocumentTimesheet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.txttimemanagementprocessDocumentTimesheet.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttimemanagementprocessDocumentTimesheet.ForeColor = System.Drawing.Color.White;
            this.txttimemanagementprocessDocumentTimesheet.Location = new System.Drawing.Point(282, 98);
            this.txttimemanagementprocessDocumentTimesheet.Multiline = true;
            this.txttimemanagementprocessDocumentTimesheet.Name = "txttimemanagementprocessDocumentTimesheet";
            this.txttimemanagementprocessDocumentTimesheet.Size = new System.Drawing.Size(402, 77);
            this.txttimemanagementprocessDocumentTimesheet.TabIndex = 2;
            this.txttimemanagementprocessDocumentTimesheet.Text = "Document Timesheet";
            // 
            // txttimemanagementprocessOverview
            // 
            this.txttimemanagementprocessOverview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.txttimemanagementprocessOverview.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttimemanagementprocessOverview.ForeColor = System.Drawing.Color.White;
            this.txttimemanagementprocessOverview.Location = new System.Drawing.Point(281, 6);
            this.txttimemanagementprocessOverview.Multiline = true;
            this.txttimemanagementprocessOverview.Name = "txttimemanagementprocessOverview";
            this.txttimemanagementprocessOverview.Size = new System.Drawing.Size(403, 78);
            this.txttimemanagementprocessOverview.TabIndex = 1;
            this.txttimemanagementprocessOverview.Text = "Overview";
            // 
            // txttimemanagementprocessDescription
            // 
            this.txttimemanagementprocessDescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.txttimemanagementprocessDescription.Font = new System.Drawing.Font("Cambria", 10F);
            this.txttimemanagementprocessDescription.ForeColor = System.Drawing.Color.White;
            this.txttimemanagementprocessDescription.Location = new System.Drawing.Point(7, 7);
            this.txttimemanagementprocessDescription.Multiline = true;
            this.txttimemanagementprocessDescription.Name = "txttimemanagementprocessDescription";
            this.txttimemanagementprocessDescription.Size = new System.Drawing.Size(246, 363);
            this.txttimemanagementprocessDescription.TabIndex = 0;
            this.txttimemanagementprocessDescription.Text = "Description";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.tabPage3.Controls.Add(this.txttimemanagementrolesProjectAdminstratror);
            this.tabPage3.Controls.Add(this.txttimemanagementrolesProjectManager);
            this.tabPage3.Controls.Add(this.txttimemanagementrolesTeamMember);
            this.tabPage3.Controls.Add(this.txttimemanagementrolesDescription);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(812, 392);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Time Management Roles";
            // 
            // txttimemanagementrolesProjectAdminstratror
            // 
            this.txttimemanagementrolesProjectAdminstratror.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txttimemanagementrolesProjectAdminstratror.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.txttimemanagementrolesProjectAdminstratror.Font = new System.Drawing.Font("Cambria", 10F);
            this.txttimemanagementrolesProjectAdminstratror.ForeColor = System.Drawing.Color.White;
            this.txttimemanagementrolesProjectAdminstratror.Location = new System.Drawing.Point(275, 246);
            this.txttimemanagementrolesProjectAdminstratror.Multiline = true;
            this.txttimemanagementrolesProjectAdminstratror.Name = "txttimemanagementrolesProjectAdminstratror";
            this.txttimemanagementrolesProjectAdminstratror.Size = new System.Drawing.Size(308, 114);
            this.txttimemanagementrolesProjectAdminstratror.TabIndex = 4;
            this.txttimemanagementrolesProjectAdminstratror.Text = "Project Adminstrator";
            // 
            // txttimemanagementrolesProjectManager
            // 
            this.txttimemanagementrolesProjectManager.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txttimemanagementrolesProjectManager.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.txttimemanagementrolesProjectManager.Font = new System.Drawing.Font("Cambria", 10F);
            this.txttimemanagementrolesProjectManager.ForeColor = System.Drawing.Color.White;
            this.txttimemanagementrolesProjectManager.Location = new System.Drawing.Point(275, 104);
            this.txttimemanagementrolesProjectManager.Multiline = true;
            this.txttimemanagementrolesProjectManager.Name = "txttimemanagementrolesProjectManager";
            this.txttimemanagementrolesProjectManager.Size = new System.Drawing.Size(308, 114);
            this.txttimemanagementrolesProjectManager.TabIndex = 3;
            this.txttimemanagementrolesProjectManager.Text = "Project Manager";
            // 
            // txttimemanagementrolesTeamMember
            // 
            this.txttimemanagementrolesTeamMember.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txttimemanagementrolesTeamMember.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.txttimemanagementrolesTeamMember.Font = new System.Drawing.Font("Cambria", 10F);
            this.txttimemanagementrolesTeamMember.ForeColor = System.Drawing.Color.White;
            this.txttimemanagementrolesTeamMember.Location = new System.Drawing.Point(275, 6);
            this.txttimemanagementrolesTeamMember.Multiline = true;
            this.txttimemanagementrolesTeamMember.Name = "txttimemanagementrolesTeamMember";
            this.txttimemanagementrolesTeamMember.Size = new System.Drawing.Size(308, 83);
            this.txttimemanagementrolesTeamMember.TabIndex = 2;
            this.txttimemanagementrolesTeamMember.Text = "Team Member";
            // 
            // txttimemanagementrolesDescription
            // 
            this.txttimemanagementrolesDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txttimemanagementrolesDescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.txttimemanagementrolesDescription.Font = new System.Drawing.Font("Cambria", 10F);
            this.txttimemanagementrolesDescription.ForeColor = System.Drawing.Color.White;
            this.txttimemanagementrolesDescription.Location = new System.Drawing.Point(7, 6);
            this.txttimemanagementrolesDescription.Multiline = true;
            this.txttimemanagementrolesDescription.Name = "txttimemanagementrolesDescription";
            this.txttimemanagementrolesDescription.Size = new System.Drawing.Size(246, 354);
            this.txttimemanagementrolesDescription.TabIndex = 1;
            this.txttimemanagementrolesDescription.Text = "Description";
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.tabPage4.Controls.Add(this.txttimemanagementdocumentsTimeSheetRegister);
            this.tabPage4.Controls.Add(this.txttimemanagementdocumentsTimeSheet);
            this.tabPage4.Controls.Add(this.txttimemanagementdocumentsDescription);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(812, 392);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Time Management Documents";
            // 
            // txttimemanagementdocumentsTimeSheetRegister
            // 
            this.txttimemanagementdocumentsTimeSheetRegister.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txttimemanagementdocumentsTimeSheetRegister.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.txttimemanagementdocumentsTimeSheetRegister.Font = new System.Drawing.Font("Cambria", 10F);
            this.txttimemanagementdocumentsTimeSheetRegister.ForeColor = System.Drawing.Color.White;
            this.txttimemanagementdocumentsTimeSheetRegister.Location = new System.Drawing.Point(294, 207);
            this.txttimemanagementdocumentsTimeSheetRegister.Multiline = true;
            this.txttimemanagementdocumentsTimeSheetRegister.Name = "txttimemanagementdocumentsTimeSheetRegister";
            this.txttimemanagementdocumentsTimeSheetRegister.Size = new System.Drawing.Size(246, 165);
            this.txttimemanagementdocumentsTimeSheetRegister.TabIndex = 2;
            this.txttimemanagementdocumentsTimeSheetRegister.Text = "TimeSheet Register";
            // 
            // txttimemanagementdocumentsTimeSheet
            // 
            this.txttimemanagementdocumentsTimeSheet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txttimemanagementdocumentsTimeSheet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.txttimemanagementdocumentsTimeSheet.Font = new System.Drawing.Font("Cambria", 10F);
            this.txttimemanagementdocumentsTimeSheet.ForeColor = System.Drawing.Color.White;
            this.txttimemanagementdocumentsTimeSheet.Location = new System.Drawing.Point(294, 7);
            this.txttimemanagementdocumentsTimeSheet.Multiline = true;
            this.txttimemanagementdocumentsTimeSheet.Name = "txttimemanagementdocumentsTimeSheet";
            this.txttimemanagementdocumentsTimeSheet.Size = new System.Drawing.Size(246, 134);
            this.txttimemanagementdocumentsTimeSheet.TabIndex = 1;
            this.txttimemanagementdocumentsTimeSheet.Text = "Time Sheet";
            // 
            // txttimemanagementdocumentsDescription
            // 
            this.txttimemanagementdocumentsDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txttimemanagementdocumentsDescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.txttimemanagementdocumentsDescription.Font = new System.Drawing.Font("Cambria", 10F);
            this.txttimemanagementdocumentsDescription.ForeColor = System.Drawing.Color.White;
            this.txttimemanagementdocumentsDescription.Location = new System.Drawing.Point(7, 7);
            this.txttimemanagementdocumentsDescription.Multiline = true;
            this.txttimemanagementdocumentsDescription.Name = "txttimemanagementdocumentsDescription";
            this.txttimemanagementdocumentsDescription.Size = new System.Drawing.Size(246, 365);
            this.txttimemanagementdocumentsDescription.TabIndex = 0;
            this.txttimemanagementdocumentsDescription.Text = "Description";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(727, 11);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(134, 22);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExportWord
            // 
            this.btnExportWord.Location = new System.Drawing.Point(589, 11);
            this.btnExportWord.Margin = new System.Windows.Forms.Padding(2);
            this.btnExportWord.Name = "btnExportWord";
            this.btnExportWord.Size = new System.Drawing.Size(134, 22);
            this.btnExportWord.TabIndex = 17;
            this.btnExportWord.Text = "Export to Word";
            this.btnExportWord.UseVisualStyleBackColor = true;
            this.btnExportWord.Click += new System.EventHandler(this.btnExportWord_Click);
            // 
            // TimeMangementProcessDocumentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(872, 487);
            this.Controls.Add(this.btnExportWord);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtProjectName);
            this.Name = "TimeMangementProcessDocumentForm";
            this.Text = "TimeMangementProcessDocumentForm";
            this.Load += new System.EventHandler(this.TimeMangementProcessDocumentForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtProjectName;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.DataGridViewTextBoxColumn approvalRole;
        private System.Windows.Forms.DataGridViewTextBoxColumn approvalName;
        private System.Windows.Forms.DataGridViewTextBoxColumn approvalSignature;
        private System.Windows.Forms.DataGridViewTextBoxColumn approvalDate;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txttimemanagementprocessUpdateProcessPlan;
        private System.Windows.Forms.TextBox txttimemanagementprocessApprovedTimesheet;
        private System.Windows.Forms.TextBox txttimemanagementprocessDocumentTimesheet;
        private System.Windows.Forms.TextBox txttimemanagementprocessOverview;
        private System.Windows.Forms.TextBox txttimemanagementprocessDescription;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox txttimemanagementrolesProjectAdminstratror;
        private System.Windows.Forms.TextBox txttimemanagementrolesProjectManager;
        private System.Windows.Forms.TextBox txttimemanagementrolesTeamMember;
        private System.Windows.Forms.TextBox txttimemanagementrolesDescription;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TextBox txttimemanagementdocumentsTimeSheetRegister;
        private System.Windows.Forms.TextBox txttimemanagementdocumentsTimeSheet;
        private System.Windows.Forms.TextBox txttimemanagementdocumentsDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn historyVersion;
        private System.Windows.Forms.DataGridViewTextBoxColumn historyIssueDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn historyChanges;
        private System.Windows.Forms.DataGridViewTextBoxColumn InformationType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Information;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExportWord;
    }
}