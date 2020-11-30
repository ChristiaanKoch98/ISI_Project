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
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.documentInformation = new System.Windows.Forms.DataGridView();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Information = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.documentHistory = new System.Windows.Forms.DataGridView();
            this.Version = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.historyIssueDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.historyChanges = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.documentApprovals = new System.Windows.Forms.DataGridView();
            this.approvalRole = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.approvalName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.approvalSignature = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.approvalDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CommunicationsProcessIntro = new System.Windows.Forms.TabPage();
            this.tabControl3 = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.createMessage = new System.Windows.Forms.TextBox();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.communicateMessage = new System.Windows.Forms.TextBox();
            this.communicate = new System.Windows.Forms.TabPage();
            this.tabControl5 = new System.Windows.Forms.TabControl();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.communicationsTeam = new System.Windows.Forms.TextBox();
            this.tabPage10 = new System.Windows.Forms.TabPage();
            this.projectManager = new System.Windows.Forms.TextBox();
            this.communicationsDocuments = new System.Windows.Forms.TabPage();
            this.tabControl4 = new System.Windows.Forms.TabControl();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.projectStatusReport = new System.Windows.Forms.TextBox();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.communicationsRegister = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.documentControl.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentInformation)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentHistory)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentApprovals)).BeginInit();
            this.CommunicationsProcessIntro.SuspendLayout();
            this.tabControl3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.communicate.SuspendLayout();
            this.tabControl5.SuspendLayout();
            this.tabPage9.SuspendLayout();
            this.tabPage10.SuspendLayout();
            this.communicationsDocuments.SuspendLayout();
            this.tabControl4.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.tabPage8.SuspendLayout();
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
            this.tabControl1.Font = new System.Drawing.Font("Helvetica", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(12, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(978, 510);
            this.tabControl1.TabIndex = 0;
            // 
            // documentControl
            // 
            this.documentControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            this.documentControl.Controls.Add(this.tabControl2);
            this.documentControl.Font = new System.Drawing.Font("Helvetica", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.documentControl.Location = new System.Drawing.Point(4, 23);
            this.documentControl.Name = "documentControl";
            this.documentControl.Padding = new System.Windows.Forms.Padding(3);
            this.documentControl.Size = new System.Drawing.Size(970, 483);
            this.documentControl.TabIndex = 0;
            this.documentControl.Text = "Document Control";
            // 
            // tabControl2
            // 
            this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl2.Controls.Add(this.tabPage1);
            this.tabControl2.Controls.Add(this.tabPage2);
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Font = new System.Drawing.Font("Helvetica", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl2.Location = new System.Drawing.Point(3, 3);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(950, 472);
            this.tabControl2.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            this.tabPage1.Controls.Add(this.documentInformation);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(942, 445);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Document Information";
            // 
            // documentInformation
            // 
            this.documentInformation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.documentInformation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.documentInformation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Type,
            this.Information});
            this.documentInformation.Location = new System.Drawing.Point(3, 2);
            this.documentInformation.Name = "documentInformation";
            this.documentInformation.RowHeadersWidth = 51;
            this.documentInformation.Size = new System.Drawing.Size(933, 436);
            this.documentInformation.TabIndex = 16;
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
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            this.tabPage2.Controls.Add(this.documentHistory);
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(942, 445);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Document History";
            // 
            // documentHistory
            // 
            this.documentHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.documentHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.documentHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Version,
            this.historyIssueDate,
            this.historyChanges});
            this.documentHistory.Location = new System.Drawing.Point(3, 2);
            this.documentHistory.Name = "documentHistory";
            this.documentHistory.RowHeadersWidth = 51;
            this.documentHistory.Size = new System.Drawing.Size(936, 436);
            this.documentHistory.TabIndex = 13;
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
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            this.tabPage3.Controls.Add(this.documentApprovals);
            this.tabPage3.Location = new System.Drawing.Point(4, 23);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(942, 445);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Document Approval";
            // 
            // documentApprovals
            // 
            this.documentApprovals.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.documentApprovals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.documentApprovals.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.approvalRole,
            this.approvalName,
            this.approvalSignature,
            this.approvalDate});
            this.documentApprovals.Location = new System.Drawing.Point(3, 3);
            this.documentApprovals.Name = "documentApprovals";
            this.documentApprovals.RowHeadersWidth = 51;
            this.documentApprovals.Size = new System.Drawing.Size(940, 433);
            this.documentApprovals.TabIndex = 18;
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
            // CommunicationsProcessIntro
            // 
            this.CommunicationsProcessIntro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            this.CommunicationsProcessIntro.Controls.Add(this.tabControl3);
            this.CommunicationsProcessIntro.Location = new System.Drawing.Point(4, 23);
            this.CommunicationsProcessIntro.Name = "CommunicationsProcessIntro";
            this.CommunicationsProcessIntro.Padding = new System.Windows.Forms.Padding(3);
            this.CommunicationsProcessIntro.Size = new System.Drawing.Size(970, 483);
            this.CommunicationsProcessIntro.TabIndex = 1;
            this.CommunicationsProcessIntro.Text = "Communications Process";
            // 
            // tabControl3
            // 
            this.tabControl3.Controls.Add(this.tabPage4);
            this.tabControl3.Controls.Add(this.tabPage5);
            this.tabControl3.Controls.Add(this.tabPage6);
            this.tabControl3.Location = new System.Drawing.Point(6, 6);
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.SelectedIndex = 0;
            this.tabControl3.Size = new System.Drawing.Size(945, 470);
            this.tabControl3.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            this.tabPage4.Controls.Add(this.pictureBox1);
            this.tabPage4.Location = new System.Drawing.Point(4, 23);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(937, 443);
            this.tabPage4.TabIndex = 0;
            this.tabPage4.Text = "Overview";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(234, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(394, 435);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            this.tabPage5.Controls.Add(this.createMessage);
            this.tabPage5.Location = new System.Drawing.Point(4, 23);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(937, 443);
            this.tabPage5.TabIndex = 1;
            this.tabPage5.Text = "Create Message";
            // 
            // createMessage
            // 
            this.createMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.createMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            this.createMessage.Font = new System.Drawing.Font("Helvetica", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createMessage.ForeColor = System.Drawing.Color.Black;
            this.createMessage.Location = new System.Drawing.Point(6, 3);
            this.createMessage.Multiline = true;
            this.createMessage.Name = "createMessage";
            this.createMessage.Size = new System.Drawing.Size(925, 428);
            this.createMessage.TabIndex = 11;
            this.createMessage.Text = "List the steps needed to create a communications message for distribution:";
            // 
            // tabPage6
            // 
            this.tabPage6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            this.tabPage6.Controls.Add(this.communicateMessage);
            this.tabPage6.Location = new System.Drawing.Point(4, 23);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(937, 443);
            this.tabPage6.TabIndex = 2;
            this.tabPage6.Text = "Communicate Message";
            // 
            // communicateMessage
            // 
            this.communicateMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.communicateMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            this.communicateMessage.Font = new System.Drawing.Font("Helvetica", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.communicateMessage.ForeColor = System.Drawing.Color.Black;
            this.communicateMessage.Location = new System.Drawing.Point(3, 6);
            this.communicateMessage.Multiline = true;
            this.communicateMessage.Name = "communicateMessage";
            this.communicateMessage.Size = new System.Drawing.Size(928, 425);
            this.communicateMessage.TabIndex = 13;
            this.communicateMessage.Text = "Describe the process for reviewing all communications messages within the project" +
    " and distributing those messages, once approved, to their respective audiences.";
            // 
            // communicate
            // 
            this.communicate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            this.communicate.Controls.Add(this.tabControl5);
            this.communicate.Location = new System.Drawing.Point(4, 23);
            this.communicate.Name = "communicate";
            this.communicate.Padding = new System.Windows.Forms.Padding(3);
            this.communicate.Size = new System.Drawing.Size(970, 483);
            this.communicate.TabIndex = 2;
            this.communicate.Text = "Communications Roles";
            // 
            // tabControl5
            // 
            this.tabControl5.Controls.Add(this.tabPage9);
            this.tabControl5.Controls.Add(this.tabPage10);
            this.tabControl5.Location = new System.Drawing.Point(6, 6);
            this.tabControl5.Name = "tabControl5";
            this.tabControl5.SelectedIndex = 0;
            this.tabControl5.Size = new System.Drawing.Size(934, 458);
            this.tabControl5.TabIndex = 0;
            // 
            // tabPage9
            // 
            this.tabPage9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            this.tabPage9.Controls.Add(this.communicationsTeam);
            this.tabPage9.Location = new System.Drawing.Point(4, 23);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage9.Size = new System.Drawing.Size(926, 431);
            this.tabPage9.TabIndex = 0;
            this.tabPage9.Text = "Communications Team";
            // 
            // communicationsTeam
            // 
            this.communicationsTeam.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.communicationsTeam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            this.communicationsTeam.Font = new System.Drawing.Font("Helvetica", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.communicationsTeam.ForeColor = System.Drawing.Color.Black;
            this.communicationsTeam.Location = new System.Drawing.Point(3, 3);
            this.communicationsTeam.Multiline = true;
            this.communicationsTeam.Name = "communicationsTeam";
            this.communicationsTeam.Size = new System.Drawing.Size(917, 419);
            this.communicationsTeam.TabIndex = 7;
            this.communicationsTeam.Text = "Communications Team";
            // 
            // tabPage10
            // 
            this.tabPage10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            this.tabPage10.Controls.Add(this.projectManager);
            this.tabPage10.Location = new System.Drawing.Point(4, 23);
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage10.Size = new System.Drawing.Size(926, 431);
            this.tabPage10.TabIndex = 1;
            this.tabPage10.Text = "Project Manager";
            // 
            // projectManager
            // 
            this.projectManager.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.projectManager.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            this.projectManager.Font = new System.Drawing.Font("Helvetica", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.projectManager.ForeColor = System.Drawing.Color.Black;
            this.projectManager.Location = new System.Drawing.Point(6, 3);
            this.projectManager.Multiline = true;
            this.projectManager.Name = "projectManager";
            this.projectManager.Size = new System.Drawing.Size(914, 417);
            this.projectManager.TabIndex = 9;
            this.projectManager.Text = "Project Manager";
            // 
            // communicationsDocuments
            // 
            this.communicationsDocuments.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            this.communicationsDocuments.Controls.Add(this.tabControl4);
            this.communicationsDocuments.Location = new System.Drawing.Point(4, 23);
            this.communicationsDocuments.Name = "communicationsDocuments";
            this.communicationsDocuments.Padding = new System.Windows.Forms.Padding(3);
            this.communicationsDocuments.Size = new System.Drawing.Size(970, 483);
            this.communicationsDocuments.TabIndex = 3;
            this.communicationsDocuments.Text = "Communications Documents";
            // 
            // tabControl4
            // 
            this.tabControl4.Controls.Add(this.tabPage7);
            this.tabControl4.Controls.Add(this.tabPage8);
            this.tabControl4.Location = new System.Drawing.Point(2, 3);
            this.tabControl4.Name = "tabControl4";
            this.tabControl4.SelectedIndex = 0;
            this.tabControl4.Size = new System.Drawing.Size(885, 468);
            this.tabControl4.TabIndex = 0;
            // 
            // tabPage7
            // 
            this.tabPage7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            this.tabPage7.Controls.Add(this.projectStatusReport);
            this.tabPage7.Location = new System.Drawing.Point(4, 23);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(877, 441);
            this.tabPage7.TabIndex = 0;
            this.tabPage7.Text = "Project Status Report";
            // 
            // projectStatusReport
            // 
            this.projectStatusReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.projectStatusReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            this.projectStatusReport.Font = new System.Drawing.Font("Helvetica", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.projectStatusReport.ForeColor = System.Drawing.Color.Black;
            this.projectStatusReport.Location = new System.Drawing.Point(2, 3);
            this.projectStatusReport.Multiline = true;
            this.projectStatusReport.Name = "projectStatusReport";
            this.projectStatusReport.Size = new System.Drawing.Size(868, 430);
            this.projectStatusReport.TabIndex = 8;
            this.projectStatusReport.Text = "Project Status Report";
            // 
            // tabPage8
            // 
            this.tabPage8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            this.tabPage8.Controls.Add(this.communicationsRegister);
            this.tabPage8.Location = new System.Drawing.Point(4, 23);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(877, 441);
            this.tabPage8.TabIndex = 1;
            this.tabPage8.Text = "Communications Register";
            // 
            // communicationsRegister
            // 
            this.communicationsRegister.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.communicationsRegister.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            this.communicationsRegister.Font = new System.Drawing.Font("Helvetica", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.communicationsRegister.ForeColor = System.Drawing.Color.Black;
            this.communicationsRegister.Location = new System.Drawing.Point(3, 3);
            this.communicationsRegister.Multiline = true;
            this.communicationsRegister.Name = "communicationsRegister";
            this.communicationsRegister.Size = new System.Drawing.Size(878, 427);
            this.communicationsRegister.TabIndex = 10;
            this.communicationsRegister.Text = "Communications Register";
            // 
            // CommunicationsManagementProcessDocumentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(989, 536);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Helvetica Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "CommunicationsManagementProcessDocumentForm";
            this.Text = "CommunicationsManagementProcessDocumentForm";
            this.tabControl1.ResumeLayout(false);
            this.documentControl.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.documentInformation)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.documentHistory)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.documentApprovals)).EndInit();
            this.CommunicationsProcessIntro.ResumeLayout(false);
            this.tabControl3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.communicate.ResumeLayout(false);
            this.tabControl5.ResumeLayout(false);
            this.tabPage9.ResumeLayout(false);
            this.tabPage9.PerformLayout();
            this.tabPage10.ResumeLayout(false);
            this.tabPage10.PerformLayout();
            this.communicationsDocuments.ResumeLayout(false);
            this.tabControl4.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            this.tabPage7.PerformLayout();
            this.tabPage8.ResumeLayout(false);
            this.tabPage8.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage documentControl;
        private System.Windows.Forms.TabPage CommunicationsProcessIntro;
        private System.Windows.Forms.TabPage communicate;
        private System.Windows.Forms.TabPage communicationsDocuments;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView documentInformation;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Information;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView documentHistory;
        private System.Windows.Forms.DataGridViewTextBoxColumn Version;
        private System.Windows.Forms.DataGridViewTextBoxColumn historyIssueDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn historyChanges;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView documentApprovals;
        private System.Windows.Forms.DataGridViewTextBoxColumn approvalRole;
        private System.Windows.Forms.DataGridViewTextBoxColumn approvalName;
        private System.Windows.Forms.DataGridViewTextBoxColumn approvalSignature;
        private System.Windows.Forms.DataGridViewTextBoxColumn approvalDate;
        private System.Windows.Forms.TabControl tabControl3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TextBox createMessage;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TextBox communicateMessage;
        private System.Windows.Forms.TabControl tabControl4;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.TextBox projectStatusReport;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.TextBox communicationsRegister;
        private System.Windows.Forms.TabControl tabControl5;
        private System.Windows.Forms.TabPage tabPage9;
        private System.Windows.Forms.TextBox communicationsTeam;
        private System.Windows.Forms.TabPage tabPage10;
        private System.Windows.Forms.TextBox projectManager;
    }
}