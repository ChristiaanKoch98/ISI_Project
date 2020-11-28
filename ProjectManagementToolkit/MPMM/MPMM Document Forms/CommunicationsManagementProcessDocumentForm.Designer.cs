namespace ProjectManagementToolkit.MPMM.MPMM_Document_Forms
{
    partial class CommunicationsManagementProcessDocumentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommunicationsManagementProcessDocumentForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.documentControl = new System.Windows.Forms.TabPage();
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
            this.CommunicationsProcessIntro = new System.Windows.Forms.TabPage();
            this.txtIntro = new System.Windows.Forms.TextBox();
            this.txtOverview = new System.Windows.Forms.TextBox();
            this.communicateMessage = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.createMessage = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.communicate = new System.Windows.Forms.TabPage();
            this.projectManager = new System.Windows.Forms.TextBox();
            this.communicationsTeam = new System.Windows.Forms.TextBox();
            this.communicationsDocuments = new System.Windows.Forms.TabPage();
            this.communicationsRegister = new System.Windows.Forms.TextBox();
            this.projectStatusReport = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.documentControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentApprovals)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentInformation)).BeginInit();
            this.CommunicationsProcessIntro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.communicate.SuspendLayout();
            this.communicationsDocuments.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.documentControl);
            this.tabControl1.Controls.Add(this.CommunicationsProcessIntro);
            this.tabControl1.Controls.Add(this.communicate);
            this.tabControl1.Controls.Add(this.communicationsDocuments);
            this.tabControl1.Location = new System.Drawing.Point(16, 50);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1289, 537);
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
            this.documentControl.Location = new System.Drawing.Point(4, 25);
            this.documentControl.Margin = new System.Windows.Forms.Padding(4);
            this.documentControl.Name = "documentControl";
            this.documentControl.Padding = new System.Windows.Forms.Padding(4);
            this.documentControl.Size = new System.Drawing.Size(1281, 508);
            this.documentControl.TabIndex = 0;
            this.documentControl.Text = "Document Control";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cambria", 11F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(8, 374);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(182, 22);
            this.label3.TabIndex = 11;
            this.label3.Text = "Document Approvals";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cambria", 11F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(8, 218);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 22);
            this.label2.TabIndex = 10;
            this.label2.Text = "Document History";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 11F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(8, 55);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 22);
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
            this.documentApprovals.Location = new System.Drawing.Point(223, 300);
            this.documentApprovals.Margin = new System.Windows.Forms.Padding(4);
            this.documentApprovals.Name = "documentApprovals";
            this.documentApprovals.RowHeadersWidth = 51;
            this.documentApprovals.Size = new System.Drawing.Size(921, 153);
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
            this.documentHistory.Location = new System.Drawing.Point(223, 148);
            this.documentHistory.Margin = new System.Windows.Forms.Padding(4);
            this.documentHistory.Name = "documentHistory";
            this.documentHistory.RowHeadersWidth = 51;
            this.documentHistory.Size = new System.Drawing.Size(921, 145);
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
            this.documentInformation.Location = new System.Drawing.Point(223, 7);
            this.documentInformation.Margin = new System.Windows.Forms.Padding(4);
            this.documentInformation.Name = "documentInformation";
            this.documentInformation.RowHeadersWidth = 51;
            this.documentInformation.Size = new System.Drawing.Size(921, 133);
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
            // CommunicationsProcessIntro
            // 
            this.CommunicationsProcessIntro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.CommunicationsProcessIntro.Controls.Add(this.txtIntro);
            this.CommunicationsProcessIntro.Controls.Add(this.txtOverview);
            this.CommunicationsProcessIntro.Controls.Add(this.communicateMessage);
            this.CommunicationsProcessIntro.Controls.Add(this.label10);
            this.CommunicationsProcessIntro.Controls.Add(this.createMessage);
            this.CommunicationsProcessIntro.Controls.Add(this.label9);
            this.CommunicationsProcessIntro.Controls.Add(this.pictureBox1);
            this.CommunicationsProcessIntro.Controls.Add(this.label4);
            this.CommunicationsProcessIntro.Location = new System.Drawing.Point(4, 25);
            this.CommunicationsProcessIntro.Margin = new System.Windows.Forms.Padding(4);
            this.CommunicationsProcessIntro.Name = "CommunicationsProcessIntro";
            this.CommunicationsProcessIntro.Padding = new System.Windows.Forms.Padding(4);
            this.CommunicationsProcessIntro.Size = new System.Drawing.Size(1281, 508);
            this.CommunicationsProcessIntro.TabIndex = 1;
            this.CommunicationsProcessIntro.Text = "Communications Process";
            // 
            // txtIntro
            // 
            this.txtIntro.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIntro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.txtIntro.Font = new System.Drawing.Font("Cambria", 10F);
            this.txtIntro.ForeColor = System.Drawing.Color.White;
            this.txtIntro.Location = new System.Drawing.Point(32, 30);
            this.txtIntro.Margin = new System.Windows.Forms.Padding(4);
            this.txtIntro.Multiline = true;
            this.txtIntro.Name = "txtIntro";
            this.txtIntro.Size = new System.Drawing.Size(521, 198);
            this.txtIntro.TabIndex = 8;
            this.txtIntro.Text = "Intro";
            // 
            // txtOverview
            // 
            this.txtOverview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOverview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.txtOverview.Font = new System.Drawing.Font("Cambria", 10F);
            this.txtOverview.ForeColor = System.Drawing.Color.White;
            this.txtOverview.Location = new System.Drawing.Point(43, 267);
            this.txtOverview.Margin = new System.Windows.Forms.Padding(4);
            this.txtOverview.Multiline = true;
            this.txtOverview.Name = "txtOverview";
            this.txtOverview.Size = new System.Drawing.Size(521, 198);
            this.txtOverview.TabIndex = 7;
            this.txtOverview.Text = "Overview";
            // 
            // communicateMessage
            // 
            this.communicateMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.communicateMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.communicateMessage.Font = new System.Drawing.Font("Cambria", 10F);
            this.communicateMessage.ForeColor = System.Drawing.Color.White;
            this.communicateMessage.Location = new System.Drawing.Point(625, 281);
            this.communicateMessage.Margin = new System.Windows.Forms.Padding(4);
            this.communicateMessage.Multiline = true;
            this.communicateMessage.Name = "communicateMessage";
            this.communicateMessage.Size = new System.Drawing.Size(611, 198);
            this.communicateMessage.TabIndex = 6;
            this.communicateMessage.Text = "Describe the process for reviewing all communications messages within the project" +
    " and distributing those messages, once approved, to their respective audiences.";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Cambria", 11F);
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(621, 240);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(194, 22);
            this.label10.TabIndex = 5;
            this.label10.Text = "Communicate Message";
            // 
            // createMessage
            // 
            this.createMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.createMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.createMessage.Font = new System.Drawing.Font("Cambria", 10F);
            this.createMessage.ForeColor = System.Drawing.Color.White;
            this.createMessage.Location = new System.Drawing.Point(625, 30);
            this.createMessage.Margin = new System.Windows.Forms.Padding(4);
            this.createMessage.Multiline = true;
            this.createMessage.Name = "createMessage";
            this.createMessage.Size = new System.Drawing.Size(611, 198);
            this.createMessage.TabIndex = 4;
            this.createMessage.Text = "List the steps needed to create a communications message for distribution:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Cambria", 11F);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(621, 4);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(134, 22);
            this.label9.TabIndex = 3;
            this.label9.Text = "Create Message";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(20, 30);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(504, 450);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cambria", 11F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(16, 4);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 22);
            this.label4.TabIndex = 0;
            this.label4.Text = "Overview";
            // 
            // communicate
            // 
            this.communicate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.communicate.Controls.Add(this.projectManager);
            this.communicate.Controls.Add(this.communicationsTeam);
            this.communicate.Location = new System.Drawing.Point(4, 25);
            this.communicate.Margin = new System.Windows.Forms.Padding(4);
            this.communicate.Name = "communicate";
            this.communicate.Padding = new System.Windows.Forms.Padding(4);
            this.communicate.Size = new System.Drawing.Size(1281, 508);
            this.communicate.TabIndex = 2;
            this.communicate.Text = "Communications Roles";
            // 
            // projectManager
            // 
            this.projectManager.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.projectManager.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.projectManager.Font = new System.Drawing.Font("Cambria", 10F);
            this.projectManager.ForeColor = System.Drawing.Color.White;
            this.projectManager.Location = new System.Drawing.Point(609, 38);
            this.projectManager.Margin = new System.Windows.Forms.Padding(4);
            this.projectManager.Multiline = true;
            this.projectManager.Name = "projectManager";
            this.projectManager.Size = new System.Drawing.Size(599, 427);
            this.projectManager.TabIndex = 6;
            this.projectManager.Text = "Project Manager";
            // 
            // communicationsTeam
            // 
            this.communicationsTeam.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.communicationsTeam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.communicationsTeam.Font = new System.Drawing.Font("Cambria", 10F);
            this.communicationsTeam.ForeColor = System.Drawing.Color.White;
            this.communicationsTeam.Location = new System.Drawing.Point(8, 38);
            this.communicationsTeam.Margin = new System.Windows.Forms.Padding(4);
            this.communicationsTeam.Multiline = true;
            this.communicationsTeam.Name = "communicationsTeam";
            this.communicationsTeam.Size = new System.Drawing.Size(561, 427);
            this.communicationsTeam.TabIndex = 5;
            this.communicationsTeam.Text = "Communications Team";
            // 
            // communicationsDocuments
            // 
            this.communicationsDocuments.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.communicationsDocuments.Controls.Add(this.communicationsRegister);
            this.communicationsDocuments.Controls.Add(this.projectStatusReport);
            this.communicationsDocuments.Location = new System.Drawing.Point(4, 25);
            this.communicationsDocuments.Margin = new System.Windows.Forms.Padding(4);
            this.communicationsDocuments.Name = "communicationsDocuments";
            this.communicationsDocuments.Padding = new System.Windows.Forms.Padding(4);
            this.communicationsDocuments.Size = new System.Drawing.Size(1281, 508);
            this.communicationsDocuments.TabIndex = 3;
            this.communicationsDocuments.Text = "Communications Documents";
            // 
            // communicationsRegister
            // 
            this.communicationsRegister.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.communicationsRegister.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.communicationsRegister.Font = new System.Drawing.Font("Cambria", 10F);
            this.communicationsRegister.ForeColor = System.Drawing.Color.White;
            this.communicationsRegister.Location = new System.Drawing.Point(637, 32);
            this.communicationsRegister.Margin = new System.Windows.Forms.Padding(4);
            this.communicationsRegister.Multiline = true;
            this.communicationsRegister.Name = "communicationsRegister";
            this.communicationsRegister.Size = new System.Drawing.Size(561, 427);
            this.communicationsRegister.TabIndex = 7;
            this.communicationsRegister.Text = "Communications Register";
            // 
            // projectStatusReport
            // 
            this.projectStatusReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.projectStatusReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.projectStatusReport.Font = new System.Drawing.Font("Cambria", 10F);
            this.projectStatusReport.ForeColor = System.Drawing.Color.White;
            this.projectStatusReport.Location = new System.Drawing.Point(24, 32);
            this.projectStatusReport.Margin = new System.Windows.Forms.Padding(4);
            this.projectStatusReport.Multiline = true;
            this.projectStatusReport.Name = "projectStatusReport";
            this.projectStatusReport.Size = new System.Drawing.Size(561, 427);
            this.projectStatusReport.TabIndex = 6;
            this.projectStatusReport.Text = "Project Status Report";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(651, 20);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(770, 20);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(118, 23);
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "Export to Word";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // CommunicationsManagementProcessDocumentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(1321, 603);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CommunicationsManagementProcessDocumentForm";
            this.Text = "CommunicationsManagementProcessDocumentForm";
            this.Load += new System.EventHandler(this.CommunicationsManagementProcessDocumentForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.documentControl.ResumeLayout(false);
            this.documentControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentApprovals)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentInformation)).EndInit();
            this.CommunicationsProcessIntro.ResumeLayout(false);
            this.CommunicationsProcessIntro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.communicate.ResumeLayout(false);
            this.communicate.PerformLayout();
            this.communicationsDocuments.ResumeLayout(false);
            this.communicationsDocuments.PerformLayout();
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
        private System.Windows.Forms.TabPage CommunicationsProcessIntro;
        private System.Windows.Forms.TabPage communicate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox communicateMessage;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox createMessage;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox projectManager;
        private System.Windows.Forms.TextBox communicationsTeam;
        private System.Windows.Forms.TabPage communicationsDocuments;
        private System.Windows.Forms.TextBox communicationsRegister;
        private System.Windows.Forms.TextBox projectStatusReport;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.TextBox txtOverview;
        private System.Windows.Forms.TextBox txtIntro;
    }
}