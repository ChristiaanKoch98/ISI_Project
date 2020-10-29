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
            this.workBreakStructure = new System.Windows.Forms.TabPage();
            this.projectPlan = new System.Windows.Forms.TabPage();
            this.appendix = new System.Windows.Forms.TabPage();
            this.schedule = new System.Windows.Forms.TabPage();
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
            this.label4 = new System.Windows.Forms.Label();
            this.phases = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.activities = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.tasks = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.milestones = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.effort = new System.Windows.Forms.DataGridView();
            this.phaseTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phaseDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phaseSequence = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.activitiesPhaseTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.activityTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.activityDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.activitySequence = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tasksActivityTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taskTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taskDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taskSequence = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.milestoneTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.milestoneDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.milestoneDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.effortTaskTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resource = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.effortMade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dependencies = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.assumptions = new System.Windows.Forms.TextBox();
            this.constrains = new System.Windows.Forms.TextBox();
            this.dependencyActivityTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dependsOn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dependencyType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.documentControl.SuspendLayout();
            this.workBreakStructure.SuspendLayout();
            this.projectPlan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentApprovals)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentInformation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.phases)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.activities)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tasks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.milestones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.effort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dependencies)).BeginInit();
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
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(922, 493);
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
            this.documentControl.Location = new System.Drawing.Point(4, 22);
            this.documentControl.Name = "documentControl";
            this.documentControl.Padding = new System.Windows.Forms.Padding(3);
            this.documentControl.Size = new System.Drawing.Size(914, 467);
            this.documentControl.TabIndex = 0;
            this.documentControl.Text = "Document Control";
            // 
            // workBreakStructure
            // 
            this.workBreakStructure.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.workBreakStructure.Controls.Add(this.label8);
            this.workBreakStructure.Controls.Add(this.effort);
            this.workBreakStructure.Controls.Add(this.label7);
            this.workBreakStructure.Controls.Add(this.milestones);
            this.workBreakStructure.Controls.Add(this.label6);
            this.workBreakStructure.Controls.Add(this.tasks);
            this.workBreakStructure.Controls.Add(this.label5);
            this.workBreakStructure.Controls.Add(this.activities);
            this.workBreakStructure.Controls.Add(this.label4);
            this.workBreakStructure.Controls.Add(this.phases);
            this.workBreakStructure.Location = new System.Drawing.Point(4, 22);
            this.workBreakStructure.Name = "workBreakStructure";
            this.workBreakStructure.Padding = new System.Windows.Forms.Padding(3);
            this.workBreakStructure.Size = new System.Drawing.Size(914, 467);
            this.workBreakStructure.TabIndex = 1;
            this.workBreakStructure.Text = "Work Breakdown Structure";
            // 
            // projectPlan
            // 
            this.projectPlan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.projectPlan.Controls.Add(this.constrains);
            this.projectPlan.Controls.Add(this.assumptions);
            this.projectPlan.Controls.Add(this.label9);
            this.projectPlan.Controls.Add(this.dependencies);
            this.projectPlan.Location = new System.Drawing.Point(4, 22);
            this.projectPlan.Name = "projectPlan";
            this.projectPlan.Padding = new System.Windows.Forms.Padding(3);
            this.projectPlan.Size = new System.Drawing.Size(914, 467);
            this.projectPlan.TabIndex = 2;
            this.projectPlan.Text = "Project Plan";
            // 
            // appendix
            // 
            this.appendix.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.appendix.Location = new System.Drawing.Point(4, 22);
            this.appendix.Name = "appendix";
            this.appendix.Padding = new System.Windows.Forms.Padding(3);
            this.appendix.Size = new System.Drawing.Size(914, 467);
            this.appendix.TabIndex = 3;
            this.appendix.Text = "Appendix";
            // 
            // schedule
            // 
            this.schedule.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.schedule.Location = new System.Drawing.Point(4, 22);
            this.schedule.Name = "schedule";
            this.schedule.Padding = new System.Windows.Forms.Padding(3);
            this.schedule.Size = new System.Drawing.Size(914, 467);
            this.schedule.TabIndex = 4;
            this.schedule.Text = "Schedule";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cambria", 11F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(5, 316);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 17);
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
            this.label2.Location = new System.Drawing.Point(5, 189);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 17);
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
            this.label1.Location = new System.Drawing.Point(5, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 17);
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
            this.documentApprovals.Location = new System.Drawing.Point(166, 256);
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
            this.documentHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.documentHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.documentHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Version,
            this.historyIssueDate,
            this.historyChanges});
            this.documentHistory.Location = new System.Drawing.Point(166, 132);
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
            this.documentInformation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.documentInformation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.documentInformation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Type,
            this.Information});
            this.documentInformation.Location = new System.Drawing.Point(166, 18);
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
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cambria", 11F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(10, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Phases";
            // 
            // phases
            // 
            this.phases.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.phases.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.phases.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.phaseTitle,
            this.phaseDescription,
            this.phaseSequence});
            this.phases.Location = new System.Drawing.Point(168, 21);
            this.phases.Name = "phases";
            this.phases.RowHeadersWidth = 51;
            this.phases.Size = new System.Drawing.Size(719, 84);
            this.phases.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cambria", 11F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(7, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "Activities";
            // 
            // activities
            // 
            this.activities.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.activities.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.activities.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.activitiesPhaseTitle,
            this.activityTitle,
            this.activityDescription,
            this.activitySequence});
            this.activities.Location = new System.Drawing.Point(168, 111);
            this.activities.Name = "activities";
            this.activities.RowHeadersWidth = 51;
            this.activities.Size = new System.Drawing.Size(719, 84);
            this.activities.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Cambria", 11F);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(7, 240);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "Tasks";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // tasks
            // 
            this.tasks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tasks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tasksActivityTitle,
            this.taskTitle,
            this.taskDescription,
            this.taskSequence});
            this.tasks.Location = new System.Drawing.Point(168, 201);
            this.tasks.Name = "tasks";
            this.tasks.RowHeadersWidth = 51;
            this.tasks.Size = new System.Drawing.Size(719, 84);
            this.tasks.TabIndex = 8;
            this.tasks.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tasks_CellContentClick);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Cambria", 11F);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(7, 330);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 17);
            this.label7.TabIndex = 11;
            this.label7.Text = "Milestones";
            // 
            // milestones
            // 
            this.milestones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.milestones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.milestones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.milestoneTitle,
            this.milestoneDescription,
            this.milestoneDate});
            this.milestones.Location = new System.Drawing.Point(168, 291);
            this.milestones.Name = "milestones";
            this.milestones.RowHeadersWidth = 51;
            this.milestones.Size = new System.Drawing.Size(719, 84);
            this.milestones.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Cambria", 11F);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(7, 420);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 17);
            this.label8.TabIndex = 13;
            this.label8.Text = "Document Effort";
            // 
            // effort
            // 
            this.effort.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.effort.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.effort.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.effortTaskTitle,
            this.resource,
            this.effortMade});
            this.effort.Location = new System.Drawing.Point(168, 381);
            this.effort.Name = "effort";
            this.effort.RowHeadersWidth = 51;
            this.effort.Size = new System.Drawing.Size(719, 84);
            this.effort.TabIndex = 12;
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
            this.phaseSequence.Name = "phaseSequence";
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
            this.activityDescription.Name = "activityDescription";
            // 
            // activitySequence
            // 
            this.activitySequence.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.activitySequence.HeaderText = "Activity Sequence";
            this.activitySequence.Name = "activitySequence";
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
            this.taskDescription.Name = "taskDescription";
            // 
            // taskSequence
            // 
            this.taskSequence.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.taskSequence.HeaderText = "Task Sequence";
            this.taskSequence.Name = "taskSequence";
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
            this.milestoneDate.Name = "milestoneDate";
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
            this.effortMade.Name = "effortMade";
            // 
            // dependencies
            // 
            this.dependencies.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dependencies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dependencies.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dependencyActivityTitle,
            this.dependsOn,
            this.dependencyType});
            this.dependencies.Location = new System.Drawing.Point(152, 72);
            this.dependencies.Name = "dependencies";
            this.dependencies.RowHeadersWidth = 51;
            this.dependencies.Size = new System.Drawing.Size(719, 84);
            this.dependencies.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Cambria", 11F);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(6, 91);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 17);
            this.label9.TabIndex = 8;
            this.label9.Text = "Activities";
            // 
            // assumptions
            // 
            this.assumptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.assumptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.assumptions.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.assumptions.ForeColor = System.Drawing.Color.White;
            this.assumptions.Location = new System.Drawing.Point(152, 205);
            this.assumptions.Multiline = true;
            this.assumptions.Name = "assumptions";
            this.assumptions.Size = new System.Drawing.Size(286, 231);
            this.assumptions.TabIndex = 9;
            this.assumptions.Text = "Assumptions";
            // 
            // constrains
            // 
            this.constrains.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.constrains.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.constrains.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.constrains.ForeColor = System.Drawing.Color.White;
            this.constrains.Location = new System.Drawing.Point(578, 205);
            this.constrains.Multiline = true;
            this.constrains.Name = "constrains";
            this.constrains.Size = new System.Drawing.Size(293, 231);
            this.constrains.TabIndex = 10;
            this.constrains.Text = "Constrains";
            this.constrains.TextChanged += new System.EventHandler(this.constrains_TextChanged);
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
            this.dependencyType.Name = "dependencyType";
            // 
            // ProjectPlanDocumentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(946, 517);
            this.Controls.Add(this.tabControl1);
            this.Name = "ProjectPlanDocumentForm";
            this.Text = "ProjectPlanDocumentForm";
            this.tabControl1.ResumeLayout(false);
            this.documentControl.ResumeLayout(false);
            this.documentControl.PerformLayout();
            this.workBreakStructure.ResumeLayout(false);
            this.workBreakStructure.PerformLayout();
            this.projectPlan.ResumeLayout(false);
            this.projectPlan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentApprovals)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentInformation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.phases)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.activities)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tasks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.milestones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.effort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dependencies)).EndInit();
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
        private System.Windows.Forms.TabPage workBreakStructure;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView effort;
        private System.Windows.Forms.DataGridViewTextBoxColumn effortTaskTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn resource;
        private System.Windows.Forms.DataGridViewTextBoxColumn effortMade;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView milestones;
        private System.Windows.Forms.DataGridViewTextBoxColumn milestoneTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn milestoneDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn milestoneDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView tasks;
        private System.Windows.Forms.DataGridViewTextBoxColumn tasksActivityTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn taskTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn taskDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn taskSequence;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView activities;
        private System.Windows.Forms.DataGridViewTextBoxColumn activitiesPhaseTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn activityTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn activityDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn activitySequence;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView phases;
        private System.Windows.Forms.DataGridViewTextBoxColumn phaseTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn phaseDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn phaseSequence;
        private System.Windows.Forms.TabPage projectPlan;
        private System.Windows.Forms.TabPage appendix;
        private System.Windows.Forms.TabPage schedule;
        private System.Windows.Forms.TextBox constrains;
        private System.Windows.Forms.TextBox assumptions;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dependencies;
        private System.Windows.Forms.DataGridViewTextBoxColumn dependencyActivityTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn dependsOn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dependencyType;
    }
}