namespace ProjectManagementToolkit
{
    partial class ProjectDashboard
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label3 = new System.Windows.Forms.Label();
            this.lblProjectName = new System.Windows.Forms.Label();
            this.lblInitiation = new System.Windows.Forms.Label();
            this.pbarInitiation = new System.Windows.Forms.ProgressBar();
            this.tabInitiation = new System.Windows.Forms.TabControl();
            this.tbpInitiation = new System.Windows.Forms.TabPage();
            this.dgvInitiation = new System.Windows.Forms.DataGridView();
            this.InitiationDocument = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DoneInitation = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lblInitiationProgress = new System.Windows.Forms.Label();
            this.tbpPlanning = new System.Windows.Forms.TabPage();
            this.tbpExecution = new System.Windows.Forms.TabPage();
            this.tbpClosure = new System.Windows.Forms.TabPage();
            this.dgvPlanning = new System.Windows.Forms.DataGridView();
            this.lblPlanningProgress = new System.Windows.Forms.Label();
            this.pbarPlanning = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvExecution = new System.Windows.Forms.DataGridView();
            this.lblExecutionProgress = new System.Windows.Forms.Label();
            this.pbarExecution = new System.Windows.Forms.ProgressBar();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvClosing = new System.Windows.Forms.DataGridView();
            this.lblClosingProgress = new System.Windows.Forms.Label();
            this.pbarClosing = new System.Windows.Forms.ProgressBar();
            this.label7 = new System.Windows.Forms.Label();
            this.PlanningDocument = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DonePlanning = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tabInitiation.SuspendLayout();
            this.tbpInitiation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInitiation)).BeginInit();
            this.tbpPlanning.SuspendLayout();
            this.tbpExecution.SuspendLayout();
            this.tbpClosure.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanning)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExecution)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClosing)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 29);
            this.label3.TabIndex = 5;
            this.label3.Text = "Project:";
            // 
            // lblProjectName
            // 
            this.lblProjectName.AutoSize = true;
            this.lblProjectName.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProjectName.ForeColor = System.Drawing.SystemColors.InfoText;
            this.lblProjectName.Location = new System.Drawing.Point(117, 9);
            this.lblProjectName.Name = "lblProjectName";
            this.lblProjectName.Size = new System.Drawing.Size(34, 29);
            this.lblProjectName.TabIndex = 6;
            this.lblProjectName.Text = "...";
            // 
            // lblInitiation
            // 
            this.lblInitiation.AutoSize = true;
            this.lblInitiation.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInitiation.ForeColor = System.Drawing.SystemColors.InfoText;
            this.lblInitiation.Location = new System.Drawing.Point(8, 13);
            this.lblInitiation.Name = "lblInitiation";
            this.lblInitiation.Size = new System.Drawing.Size(103, 22);
            this.lblInitiation.TabIndex = 7;
            this.lblInitiation.Text = "Progress:";
            // 
            // pbarInitiation
            // 
            this.pbarInitiation.Location = new System.Drawing.Point(116, 4);
            this.pbarInitiation.Margin = new System.Windows.Forms.Padding(2);
            this.pbarInitiation.Name = "pbarInitiation";
            this.pbarInitiation.Size = new System.Drawing.Size(583, 40);
            this.pbarInitiation.TabIndex = 11;
            // 
            // tabInitiation
            // 
            this.tabInitiation.Controls.Add(this.tbpInitiation);
            this.tabInitiation.Controls.Add(this.tbpPlanning);
            this.tabInitiation.Controls.Add(this.tbpExecution);
            this.tabInitiation.Controls.Add(this.tbpClosure);
            this.tabInitiation.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabInitiation.Location = new System.Drawing.Point(11, 107);
            this.tabInitiation.Margin = new System.Windows.Forms.Padding(2);
            this.tabInitiation.Name = "tabInitiation";
            this.tabInitiation.SelectedIndex = 0;
            this.tabInitiation.Size = new System.Drawing.Size(720, 495);
            this.tabInitiation.TabIndex = 13;
            // 
            // tbpInitiation
            // 
            this.tbpInitiation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            this.tbpInitiation.Controls.Add(this.dgvInitiation);
            this.tbpInitiation.Controls.Add(this.lblInitiationProgress);
            this.tbpInitiation.Controls.Add(this.pbarInitiation);
            this.tbpInitiation.Controls.Add(this.lblInitiation);
            this.tbpInitiation.Location = new System.Drawing.Point(4, 21);
            this.tbpInitiation.Margin = new System.Windows.Forms.Padding(2);
            this.tbpInitiation.Name = "tbpInitiation";
            this.tbpInitiation.Padding = new System.Windows.Forms.Padding(2);
            this.tbpInitiation.Size = new System.Drawing.Size(712, 470);
            this.tbpInitiation.TabIndex = 0;
            this.tbpInitiation.Text = "Initation Phase";
            // 
            // dgvInitiation
            // 
            this.dgvInitiation.AllowUserToAddRows = false;
            this.dgvInitiation.AllowUserToDeleteRows = false;
            this.dgvInitiation.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInitiation.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(173)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(173)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInitiation.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvInitiation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInitiation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.InitiationDocument,
            this.DoneInitation});
            this.dgvInitiation.EnableHeadersVisualStyles = false;
            this.dgvInitiation.Location = new System.Drawing.Point(12, 90);
            this.dgvInitiation.Margin = new System.Windows.Forms.Padding(2);
            this.dgvInitiation.Name = "dgvInitiation";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(173)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInitiation.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvInitiation.RowHeadersWidth = 51;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 10.8F);
            this.dgvInitiation.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvInitiation.Size = new System.Drawing.Size(687, 376);
            this.dgvInitiation.TabIndex = 17;
            // 
            // InitiationDocument
            // 
            this.InitiationDocument.HeaderText = "Initation Document";
            this.InitiationDocument.Name = "InitiationDocument";
            this.InitiationDocument.ReadOnly = true;
            // 
            // DoneInitation
            // 
            this.DoneInitation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.DoneInitation.HeaderText = "Done?";
            this.DoneInitation.Name = "DoneInitation";
            this.DoneInitation.ReadOnly = true;
            this.DoneInitation.Width = 48;
            // 
            // lblInitiationProgress
            // 
            this.lblInitiationProgress.AutoSize = true;
            this.lblInitiationProgress.Location = new System.Drawing.Point(113, 56);
            this.lblInitiationProgress.Name = "lblInitiationProgress";
            this.lblInitiationProgress.Size = new System.Drawing.Size(65, 14);
            this.lblInitiationProgress.TabIndex = 12;
            this.lblInitiationProgress.Text = "Progress: ";
            // 
            // tbpPlanning
            // 
            this.tbpPlanning.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            this.tbpPlanning.Controls.Add(this.dgvPlanning);
            this.tbpPlanning.Controls.Add(this.lblPlanningProgress);
            this.tbpPlanning.Controls.Add(this.pbarPlanning);
            this.tbpPlanning.Controls.Add(this.label2);
            this.tbpPlanning.Location = new System.Drawing.Point(4, 21);
            this.tbpPlanning.Margin = new System.Windows.Forms.Padding(2);
            this.tbpPlanning.Name = "tbpPlanning";
            this.tbpPlanning.Padding = new System.Windows.Forms.Padding(2);
            this.tbpPlanning.Size = new System.Drawing.Size(712, 470);
            this.tbpPlanning.TabIndex = 1;
            this.tbpPlanning.Text = "Planning Phase";
            // 
            // tbpExecution
            // 
            this.tbpExecution.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            this.tbpExecution.Controls.Add(this.dgvExecution);
            this.tbpExecution.Controls.Add(this.lblExecutionProgress);
            this.tbpExecution.Controls.Add(this.pbarExecution);
            this.tbpExecution.Controls.Add(this.label5);
            this.tbpExecution.Location = new System.Drawing.Point(4, 21);
            this.tbpExecution.Margin = new System.Windows.Forms.Padding(2);
            this.tbpExecution.Name = "tbpExecution";
            this.tbpExecution.Size = new System.Drawing.Size(712, 470);
            this.tbpExecution.TabIndex = 2;
            this.tbpExecution.Text = "Execution Phase";
            // 
            // tbpClosure
            // 
            this.tbpClosure.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            this.tbpClosure.Controls.Add(this.dgvClosing);
            this.tbpClosure.Controls.Add(this.lblClosingProgress);
            this.tbpClosure.Controls.Add(this.pbarClosing);
            this.tbpClosure.Controls.Add(this.label7);
            this.tbpClosure.Location = new System.Drawing.Point(4, 21);
            this.tbpClosure.Name = "tbpClosure";
            this.tbpClosure.Size = new System.Drawing.Size(712, 470);
            this.tbpClosure.TabIndex = 3;
            this.tbpClosure.Text = "Closing Phase";
            // 
            // dgvPlanning
            // 
            this.dgvPlanning.AllowUserToAddRows = false;
            this.dgvPlanning.AllowUserToDeleteRows = false;
            this.dgvPlanning.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPlanning.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(173)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(173)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPlanning.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPlanning.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlanning.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PlanningDocument,
            this.DonePlanning});
            this.dgvPlanning.EnableHeadersVisualStyles = false;
            this.dgvPlanning.Location = new System.Drawing.Point(12, 90);
            this.dgvPlanning.Margin = new System.Windows.Forms.Padding(2);
            this.dgvPlanning.Name = "dgvPlanning";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(173)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPlanning.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvPlanning.RowHeadersWidth = 51;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Arial", 10.8F);
            this.dgvPlanning.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvPlanning.Size = new System.Drawing.Size(687, 376);
            this.dgvPlanning.TabIndex = 21;
            // 
            // lblPlanningProgress
            // 
            this.lblPlanningProgress.AutoSize = true;
            this.lblPlanningProgress.Location = new System.Drawing.Point(113, 56);
            this.lblPlanningProgress.Name = "lblPlanningProgress";
            this.lblPlanningProgress.Size = new System.Drawing.Size(65, 14);
            this.lblPlanningProgress.TabIndex = 20;
            this.lblPlanningProgress.Text = "Progress: ";
            // 
            // pbarPlanning
            // 
            this.pbarPlanning.Location = new System.Drawing.Point(116, 4);
            this.pbarPlanning.Margin = new System.Windows.Forms.Padding(2);
            this.pbarPlanning.Name = "pbarPlanning";
            this.pbarPlanning.Size = new System.Drawing.Size(583, 40);
            this.pbarPlanning.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label2.Location = new System.Drawing.Point(8, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 22);
            this.label2.TabIndex = 18;
            this.label2.Text = "Progress:";
            // 
            // dgvExecution
            // 
            this.dgvExecution.AllowUserToAddRows = false;
            this.dgvExecution.AllowUserToDeleteRows = false;
            this.dgvExecution.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvExecution.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(173)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(173)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvExecution.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvExecution.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExecution.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewCheckBoxColumn2});
            this.dgvExecution.EnableHeadersVisualStyles = false;
            this.dgvExecution.Location = new System.Drawing.Point(12, 90);
            this.dgvExecution.Margin = new System.Windows.Forms.Padding(2);
            this.dgvExecution.Name = "dgvExecution";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(173)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvExecution.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvExecution.RowHeadersWidth = 51;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Arial", 10.8F);
            this.dgvExecution.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvExecution.Size = new System.Drawing.Size(687, 376);
            this.dgvExecution.TabIndex = 21;
            // 
            // lblExecutionProgress
            // 
            this.lblExecutionProgress.AutoSize = true;
            this.lblExecutionProgress.Location = new System.Drawing.Point(113, 56);
            this.lblExecutionProgress.Name = "lblExecutionProgress";
            this.lblExecutionProgress.Size = new System.Drawing.Size(65, 14);
            this.lblExecutionProgress.TabIndex = 20;
            this.lblExecutionProgress.Text = "Progress: ";
            // 
            // pbarExecution
            // 
            this.pbarExecution.Location = new System.Drawing.Point(116, 4);
            this.pbarExecution.Margin = new System.Windows.Forms.Padding(2);
            this.pbarExecution.Name = "pbarExecution";
            this.pbarExecution.Size = new System.Drawing.Size(583, 40);
            this.pbarExecution.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label5.Location = new System.Drawing.Point(8, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 22);
            this.label5.TabIndex = 18;
            this.label5.Text = "Progress:";
            // 
            // dgvClosing
            // 
            this.dgvClosing.AllowUserToAddRows = false;
            this.dgvClosing.AllowUserToDeleteRows = false;
            this.dgvClosing.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvClosing.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(173)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(173)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvClosing.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvClosing.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClosing.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewCheckBoxColumn3});
            this.dgvClosing.EnableHeadersVisualStyles = false;
            this.dgvClosing.Location = new System.Drawing.Point(12, 90);
            this.dgvClosing.Margin = new System.Windows.Forms.Padding(2);
            this.dgvClosing.Name = "dgvClosing";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(173)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvClosing.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvClosing.RowHeadersWidth = 51;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Arial", 10.8F);
            this.dgvClosing.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvClosing.Size = new System.Drawing.Size(687, 376);
            this.dgvClosing.TabIndex = 25;
            // 
            // lblClosingProgress
            // 
            this.lblClosingProgress.AutoSize = true;
            this.lblClosingProgress.Location = new System.Drawing.Point(113, 56);
            this.lblClosingProgress.Name = "lblClosingProgress";
            this.lblClosingProgress.Size = new System.Drawing.Size(65, 14);
            this.lblClosingProgress.TabIndex = 24;
            this.lblClosingProgress.Text = "Progress: ";
            // 
            // pbarClosing
            // 
            this.pbarClosing.Location = new System.Drawing.Point(116, 4);
            this.pbarClosing.Margin = new System.Windows.Forms.Padding(2);
            this.pbarClosing.Name = "pbarClosing";
            this.pbarClosing.Size = new System.Drawing.Size(583, 40);
            this.pbarClosing.TabIndex = 23;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label7.Location = new System.Drawing.Point(8, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 22);
            this.label7.TabIndex = 22;
            this.label7.Text = "Progress:";
            // 
            // PlanningDocument
            // 
            this.PlanningDocument.HeaderText = "Planning Document";
            this.PlanningDocument.Name = "PlanningDocument";
            this.PlanningDocument.ReadOnly = true;
            // 
            // DonePlanning
            // 
            this.DonePlanning.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.DonePlanning.HeaderText = "Done?";
            this.DonePlanning.Name = "DonePlanning";
            this.DonePlanning.ReadOnly = true;
            this.DonePlanning.Width = 48;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Execution Document";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewCheckBoxColumn2
            // 
            this.dataGridViewCheckBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewCheckBoxColumn2.HeaderText = "Done?";
            this.dataGridViewCheckBoxColumn2.Name = "dataGridViewCheckBoxColumn2";
            this.dataGridViewCheckBoxColumn2.ReadOnly = true;
            this.dataGridViewCheckBoxColumn2.Width = 48;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Closing Document";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewCheckBoxColumn3
            // 
            this.dataGridViewCheckBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewCheckBoxColumn3.HeaderText = "Done?";
            this.dataGridViewCheckBoxColumn3.Name = "dataGridViewCheckBoxColumn3";
            this.dataGridViewCheckBoxColumn3.ReadOnly = true;
            this.dataGridViewCheckBoxColumn3.Width = 48;
            // 
            // ProjectDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(747, 693);
            this.Controls.Add(this.tabInitiation);
            this.Controls.Add(this.lblProjectName);
            this.Controls.Add(this.label3);
            this.Name = "ProjectDashboard";
            this.Text = "ProjectDashboard";
            this.Load += new System.EventHandler(this.ProjectDashboard_Load);
            this.tabInitiation.ResumeLayout(false);
            this.tbpInitiation.ResumeLayout(false);
            this.tbpInitiation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInitiation)).EndInit();
            this.tbpPlanning.ResumeLayout(false);
            this.tbpPlanning.PerformLayout();
            this.tbpExecution.ResumeLayout(false);
            this.tbpExecution.PerformLayout();
            this.tbpClosure.ResumeLayout(false);
            this.tbpClosure.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanning)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExecution)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClosing)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblProjectName;
        private System.Windows.Forms.Label lblInitiation;
        private System.Windows.Forms.ProgressBar pbarInitiation;
        private System.Windows.Forms.TabControl tabInitiation;
        private System.Windows.Forms.TabPage tbpInitiation;
        private System.Windows.Forms.TabPage tbpPlanning;
        private System.Windows.Forms.TabPage tbpExecution;
        private System.Windows.Forms.Label lblInitiationProgress;
        private System.Windows.Forms.TabPage tbpClosure;
        private System.Windows.Forms.DataGridView dgvInitiation;
        private System.Windows.Forms.DataGridViewTextBoxColumn InitiationDocument;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DoneInitation;
        private System.Windows.Forms.DataGridView dgvPlanning;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlanningDocument;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DonePlanning;
        private System.Windows.Forms.Label lblPlanningProgress;
        private System.Windows.Forms.ProgressBar pbarPlanning;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvExecution;
        private System.Windows.Forms.Label lblExecutionProgress;
        private System.Windows.Forms.ProgressBar pbarExecution;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvClosing;
        private System.Windows.Forms.Label lblClosingProgress;
        private System.Windows.Forms.ProgressBar pbarClosing;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn3;
    }
}