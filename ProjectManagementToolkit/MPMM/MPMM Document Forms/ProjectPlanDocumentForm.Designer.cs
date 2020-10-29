namespace ProjectManagementToolkit.MPMM.MPMM_Document_Forms
{
    partial class ProjectPlanDocumentForm
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
            this.workBreakStructure = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.effortDataGridView = new System.Windows.Forms.DataGridView();
            this.effortTaskTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resource = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.effortMade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.milestonesDataGridView = new System.Windows.Forms.DataGridView();
            this.milestoneTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.milestoneDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.milestoneDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.tasksDataGridView = new System.Windows.Forms.DataGridView();
            this.tasksActivityTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taskTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taskDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taskSequence = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.activitiesDataGridView = new System.Windows.Forms.DataGridView();
            this.activitiesPhaseTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.activityTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.activityDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.activitySequence = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.phasesDataGridView = new System.Windows.Forms.DataGridView();
            this.phaseTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phaseDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phaseSequence = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.projectPlan = new System.Windows.Forms.TabPage();
            this.constrainsTxt = new System.Windows.Forms.TextBox();
            this.assumptionsTxt = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dependenciesDataGridView = new System.Windows.Forms.DataGridView();
            this.dependencyActivityTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dependsOn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dependencyType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.appendix = new System.Windows.Forms.TabPage();
            this.schedule = new System.Windows.Forms.TabPage();
            this.btnSave = new System.Windows.Forms.Button();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Information = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.documentControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentApprovals)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentInformation)).BeginInit();
            this.workBreakStructure.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.effortDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.milestonesDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tasksDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.activitiesDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.phasesDataGridView)).BeginInit();
            this.projectPlan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dependenciesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.documentControl);
            this.tabControl1.Controls.Add(this.workBreakStructure);
            this.tabControl1.Controls.Add(this.projectPlan);
            this.tabControl1.Controls.Add(this.appendix);
            this.tabControl1.Controls.Add(this.schedule);
            this.tabControl1.Location = new System.Drawing.Point(16, 15);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1229, 607);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
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
            this.documentControl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.documentControl.Name = "documentControl";
            this.documentControl.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.documentControl.Size = new System.Drawing.Size(1221, 578);
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
            this.label3.Location = new System.Drawing.Point(7, 389);
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
            this.label2.Location = new System.Drawing.Point(7, 233);
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
            this.label1.Location = new System.Drawing.Point(7, 70);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 22);
            this.label1.TabIndex = 9;
            this.label1.Text = "Document Information";
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
            this.documentApprovals.Location = new System.Drawing.Point(221, 315);
            this.documentApprovals.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.documentHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.documentHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.documentHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Version,
            this.historyIssueDate,
            this.historyChanges});
            this.documentHistory.Location = new System.Drawing.Point(221, 162);
            this.documentHistory.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.documentInformation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.documentInformation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.documentInformation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Type,
            this.Information});
            this.documentInformation.Location = new System.Drawing.Point(221, 22);
            this.documentInformation.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.documentInformation.Name = "documentInformation";
            this.documentInformation.RowHeadersWidth = 51;
            this.documentInformation.Size = new System.Drawing.Size(921, 133);
            this.documentInformation.TabIndex = 6;
            // 
            // workBreakStructure
            // 
            this.workBreakStructure.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.workBreakStructure.Controls.Add(this.label8);
            this.workBreakStructure.Controls.Add(this.effortDataGridView);
            this.workBreakStructure.Controls.Add(this.label7);
            this.workBreakStructure.Controls.Add(this.milestonesDataGridView);
            this.workBreakStructure.Controls.Add(this.label6);
            this.workBreakStructure.Controls.Add(this.tasksDataGridView);
            this.workBreakStructure.Controls.Add(this.label5);
            this.workBreakStructure.Controls.Add(this.activitiesDataGridView);
            this.workBreakStructure.Controls.Add(this.label4);
            this.workBreakStructure.Controls.Add(this.phasesDataGridView);
            this.workBreakStructure.Location = new System.Drawing.Point(4, 25);
            this.workBreakStructure.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.workBreakStructure.Name = "workBreakStructure";
            this.workBreakStructure.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.workBreakStructure.Size = new System.Drawing.Size(1221, 578);
            this.workBreakStructure.TabIndex = 1;
            this.workBreakStructure.Text = "Work Breakdown Structure";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Cambria", 11F);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(9, 517);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(145, 22);
            this.label8.TabIndex = 13;
            this.label8.Text = "Document Effort";
            // 
            // effortDataGridView
            // 
            this.effortDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.effortDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.effortDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.effortTaskTitle,
            this.resource,
            this.effortMade});
            this.effortDataGridView.Location = new System.Drawing.Point(224, 469);
            this.effortDataGridView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.effortDataGridView.Name = "effortDataGridView";
            this.effortDataGridView.RowHeadersWidth = 51;
            this.effortDataGridView.Size = new System.Drawing.Size(959, 103);
            this.effortDataGridView.TabIndex = 12;
            // 
            // effortTaskTitle
            // 
            this.effortTaskTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.effortTaskTitle.HeaderText = "Task Title";
            this.effortTaskTitle.MinimumWidth = 6;
            this.effortTaskTitle.Name = "effortTaskTitle";
            // 
            // resource
            // 
            this.resource.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.resource.HeaderText = "Resource";
            this.resource.MinimumWidth = 6;
            this.resource.Name = "resource";
            // 
            // effortMade
            // 
            this.effortMade.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.effortMade.HeaderText = "Effort";
            this.effortMade.MinimumWidth = 6;
            this.effortMade.Name = "effortMade";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Cambria", 11F);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(9, 406);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 22);
            this.label7.TabIndex = 11;
            this.label7.Text = "Milestones";
            // 
            // milestonesDataGridView
            // 
            this.milestonesDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.milestonesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.milestonesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.milestoneTitle,
            this.milestoneDescription,
            this.milestoneDate});
            this.milestonesDataGridView.Location = new System.Drawing.Point(224, 358);
            this.milestonesDataGridView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.milestonesDataGridView.Name = "milestonesDataGridView";
            this.milestonesDataGridView.RowHeadersWidth = 51;
            this.milestonesDataGridView.Size = new System.Drawing.Size(959, 103);
            this.milestonesDataGridView.TabIndex = 10;
            // 
            // milestoneTitle
            // 
            this.milestoneTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.milestoneTitle.HeaderText = "Milestone Title";
            this.milestoneTitle.MinimumWidth = 6;
            this.milestoneTitle.Name = "milestoneTitle";
            // 
            // milestoneDescription
            // 
            this.milestoneDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.milestoneDescription.HeaderText = "Milestone Description";
            this.milestoneDescription.MinimumWidth = 6;
            this.milestoneDescription.Name = "milestoneDescription";
            // 
            // milestoneDate
            // 
            this.milestoneDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.milestoneDate.HeaderText = "Milestone Date";
            this.milestoneDate.MinimumWidth = 6;
            this.milestoneDate.Name = "milestoneDate";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Cambria", 11F);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(9, 295);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 22);
            this.label6.TabIndex = 9;
            this.label6.Text = "Tasks";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // tasksDataGridView
            // 
            this.tasksDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tasksDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tasksDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tasksActivityTitle,
            this.taskTitle,
            this.taskDescription,
            this.taskSequence});
            this.tasksDataGridView.Location = new System.Drawing.Point(224, 247);
            this.tasksDataGridView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tasksDataGridView.Name = "tasksDataGridView";
            this.tasksDataGridView.RowHeadersWidth = 51;
            this.tasksDataGridView.Size = new System.Drawing.Size(959, 103);
            this.tasksDataGridView.TabIndex = 8;
            this.tasksDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tasks_CellContentClick);
            // 
            // tasksActivityTitle
            // 
            this.tasksActivityTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.tasksActivityTitle.HeaderText = "Activity Title";
            this.tasksActivityTitle.MinimumWidth = 6;
            this.tasksActivityTitle.Name = "tasksActivityTitle";
            // 
            // taskTitle
            // 
            this.taskTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.taskTitle.HeaderText = "Task Title";
            this.taskTitle.MinimumWidth = 6;
            this.taskTitle.Name = "taskTitle";
            // 
            // taskDescription
            // 
            this.taskDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.taskDescription.HeaderText = "Task Description";
            this.taskDescription.MinimumWidth = 6;
            this.taskDescription.Name = "taskDescription";
            // 
            // taskSequence
            // 
            this.taskSequence.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.taskSequence.HeaderText = "Task Sequence";
            this.taskSequence.MinimumWidth = 6;
            this.taskSequence.Name = "taskSequence";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cambria", 11F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(9, 185);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 22);
            this.label5.TabIndex = 7;
            this.label5.Text = "Activities";
            // 
            // activitiesDataGridView
            // 
            this.activitiesDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.activitiesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.activitiesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.activitiesPhaseTitle,
            this.activityTitle,
            this.activityDescription,
            this.activitySequence});
            this.activitiesDataGridView.Location = new System.Drawing.Point(224, 137);
            this.activitiesDataGridView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.activitiesDataGridView.Name = "activitiesDataGridView";
            this.activitiesDataGridView.RowHeadersWidth = 51;
            this.activitiesDataGridView.Size = new System.Drawing.Size(959, 103);
            this.activitiesDataGridView.TabIndex = 6;
            // 
            // activitiesPhaseTitle
            // 
            this.activitiesPhaseTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.activitiesPhaseTitle.HeaderText = "Phase Title";
            this.activitiesPhaseTitle.MinimumWidth = 6;
            this.activitiesPhaseTitle.Name = "activitiesPhaseTitle";
            // 
            // activityTitle
            // 
            this.activityTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.activityTitle.HeaderText = "Activity Title";
            this.activityTitle.MinimumWidth = 6;
            this.activityTitle.Name = "activityTitle";
            // 
            // activityDescription
            // 
            this.activityDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.activityDescription.HeaderText = "Activity Description";
            this.activityDescription.MinimumWidth = 6;
            this.activityDescription.Name = "activityDescription";
            // 
            // activitySequence
            // 
            this.activitySequence.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.activitySequence.HeaderText = "Activity Sequence";
            this.activitySequence.MinimumWidth = 6;
            this.activitySequence.Name = "activitySequence";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cambria", 11F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(13, 68);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 22);
            this.label4.TabIndex = 5;
            this.label4.Text = "Phases";
            // 
            // phasesDataGridView
            // 
            this.phasesDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.phasesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.phasesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.phaseTitle,
            this.phaseDescription,
            this.phaseSequence});
            this.phasesDataGridView.Location = new System.Drawing.Point(224, 26);
            this.phasesDataGridView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.phasesDataGridView.Name = "phasesDataGridView";
            this.phasesDataGridView.RowHeadersWidth = 51;
            this.phasesDataGridView.Size = new System.Drawing.Size(959, 103);
            this.phasesDataGridView.TabIndex = 4;
            // 
            // phaseTitle
            // 
            this.phaseTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.phaseTitle.HeaderText = "Phase Title";
            this.phaseTitle.MinimumWidth = 6;
            this.phaseTitle.Name = "phaseTitle";
            // 
            // phaseDescription
            // 
            this.phaseDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.phaseDescription.HeaderText = "Phase Description";
            this.phaseDescription.MinimumWidth = 6;
            this.phaseDescription.Name = "phaseDescription";
            // 
            // phaseSequence
            // 
            this.phaseSequence.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.phaseSequence.HeaderText = "Phase Sequence";
            this.phaseSequence.MinimumWidth = 6;
            this.phaseSequence.Name = "phaseSequence";
            // 
            // projectPlan
            // 
            this.projectPlan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.projectPlan.Controls.Add(this.constrainsTxt);
            this.projectPlan.Controls.Add(this.assumptionsTxt);
            this.projectPlan.Controls.Add(this.label9);
            this.projectPlan.Controls.Add(this.dependenciesDataGridView);
            this.projectPlan.Location = new System.Drawing.Point(4, 25);
            this.projectPlan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.projectPlan.Name = "projectPlan";
            this.projectPlan.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.projectPlan.Size = new System.Drawing.Size(1221, 578);
            this.projectPlan.TabIndex = 2;
            this.projectPlan.Text = "Project Plan";
            // 
            // constrainsTxt
            // 
            this.constrainsTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.constrainsTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.constrainsTxt.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.constrainsTxt.ForeColor = System.Drawing.Color.White;
            this.constrainsTxt.Location = new System.Drawing.Point(771, 252);
            this.constrainsTxt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.constrainsTxt.Multiline = true;
            this.constrainsTxt.Name = "constrainsTxt";
            this.constrainsTxt.Size = new System.Drawing.Size(389, 283);
            this.constrainsTxt.TabIndex = 10;
            this.constrainsTxt.Text = "Constrains";
            this.constrainsTxt.TextChanged += new System.EventHandler(this.constrains_TextChanged);
            // 
            // assumptionsTxt
            // 
            this.assumptionsTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.assumptionsTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.assumptionsTxt.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.assumptionsTxt.ForeColor = System.Drawing.Color.White;
            this.assumptionsTxt.Location = new System.Drawing.Point(203, 252);
            this.assumptionsTxt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.assumptionsTxt.Multiline = true;
            this.assumptionsTxt.Name = "assumptionsTxt";
            this.assumptionsTxt.Size = new System.Drawing.Size(380, 283);
            this.assumptionsTxt.TabIndex = 9;
            this.assumptionsTxt.Text = "Assumptions";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Cambria", 11F);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(8, 112);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 22);
            this.label9.TabIndex = 8;
            this.label9.Text = "Activities";
            // 
            // dependenciesDataGridView
            // 
            this.dependenciesDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dependenciesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dependenciesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dependencyActivityTitle,
            this.dependsOn,
            this.dependencyType});
            this.dependenciesDataGridView.Location = new System.Drawing.Point(203, 89);
            this.dependenciesDataGridView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dependenciesDataGridView.Name = "dependenciesDataGridView";
            this.dependenciesDataGridView.RowHeadersWidth = 51;
            this.dependenciesDataGridView.Size = new System.Drawing.Size(959, 103);
            this.dependenciesDataGridView.TabIndex = 7;
            // 
            // dependencyActivityTitle
            // 
            this.dependencyActivityTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dependencyActivityTitle.HeaderText = "Activity Title";
            this.dependencyActivityTitle.MinimumWidth = 6;
            this.dependencyActivityTitle.Name = "dependencyActivityTitle";
            // 
            // dependsOn
            // 
            this.dependsOn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dependsOn.HeaderText = "Depends on";
            this.dependsOn.MinimumWidth = 6;
            this.dependsOn.Name = "dependsOn";
            // 
            // dependencyType
            // 
            this.dependencyType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dependencyType.HeaderText = "Dependency Type";
            this.dependencyType.MinimumWidth = 6;
            this.dependencyType.Name = "dependencyType";
            // 
            // appendix
            // 
            this.appendix.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.appendix.Location = new System.Drawing.Point(4, 25);
            this.appendix.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.appendix.Name = "appendix";
            this.appendix.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.appendix.Size = new System.Drawing.Size(1221, 578);
            this.appendix.TabIndex = 3;
            this.appendix.Text = "Appendix";
            // 
            // schedule
            // 
            this.schedule.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.schedule.Location = new System.Drawing.Point(4, 25);
            this.schedule.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.schedule.Name = "schedule";
            this.schedule.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.schedule.Size = new System.Drawing.Size(1221, 578);
            this.schedule.TabIndex = 4;
            this.schedule.Text = "Schedule";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(711, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(179, 27);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // Type
            // 
            this.Type.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Type.HeaderText = "Type";
            this.Type.MinimumWidth = 6;
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            // 
            // Information
            // 
            this.Information.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Information.HeaderText = "Information";
            this.Information.MinimumWidth = 6;
            this.Information.Name = "Information";
            // 
            // ProjectPlanDocumentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(1261, 636);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ProjectPlanDocumentForm";
            this.Text = "ProjectPlanDocumentForm";
            this.tabControl1.ResumeLayout(false);
            this.documentControl.ResumeLayout(false);
            this.documentControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentApprovals)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentInformation)).EndInit();
            this.workBreakStructure.ResumeLayout(false);
            this.workBreakStructure.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.effortDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.milestonesDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tasksDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.activitiesDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.phasesDataGridView)).EndInit();
            this.projectPlan.ResumeLayout(false);
            this.projectPlan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dependenciesDataGridView)).EndInit();
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
        private System.Windows.Forms.TabPage workBreakStructure;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView effortDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn effortTaskTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn resource;
        private System.Windows.Forms.DataGridViewTextBoxColumn effortMade;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView milestonesDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn milestoneTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn milestoneDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn milestoneDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView tasksDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn tasksActivityTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn taskTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn taskDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn taskSequence;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView activitiesDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn activitiesPhaseTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn activityTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn activityDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn activitySequence;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView phasesDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn phaseTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn phaseDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn phaseSequence;
        private System.Windows.Forms.TabPage projectPlan;
        private System.Windows.Forms.TabPage appendix;
        private System.Windows.Forms.TabPage schedule;
        private System.Windows.Forms.TextBox constrainsTxt;
        private System.Windows.Forms.TextBox assumptionsTxt;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dependenciesDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dependencyActivityTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn dependsOn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dependencyType;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Information;
    }
}