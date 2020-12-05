namespace ProjectManagementToolkit.MPMM.MPMM_Document_Forms
{
    partial class IssueRegisterForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewSolutionRaiseRaised = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date_Raised = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Raised_By = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Received_By = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description_of_Issue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Impact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Priority = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Action = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Owner = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Outcome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date_for_Resolution = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date_Resolved = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIssueRegisterProjectManager = new System.Windows.Forms.TextBox();
            this.txtIssueRegisterProjectName = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSolutionRaiseRaised)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewSolutionRaiseRaised
            // 
            this.dataGridViewSolutionRaiseRaised.AllowUserToOrderColumns = true;
            this.dataGridViewSolutionRaiseRaised.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(173)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Helvetica", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(173)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewSolutionRaiseRaised.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewSolutionRaiseRaised.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSolutionRaiseRaised.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Date_Raised,
            this.Raised_By,
            this.Received_By,
            this.Description_of_Issue,
            this.Impact,
            this.Priority,
            this.Action,
            this.Owner,
            this.Outcome,
            this.Date_for_Resolution,
            this.Date_Resolved});
            this.dataGridViewSolutionRaiseRaised.EnableHeadersVisualStyles = false;
            this.dataGridViewSolutionRaiseRaised.Location = new System.Drawing.Point(12, 63);
            this.dataGridViewSolutionRaiseRaised.Name = "dataGridViewSolutionRaiseRaised";
            this.dataGridViewSolutionRaiseRaised.RightToLeft = System.Windows.Forms.RightToLeft.No;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(173)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Helvetica", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewSolutionRaiseRaised.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewSolutionRaiseRaised.RowHeadersWidth = 51;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Helvetica", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            this.dataGridViewSolutionRaiseRaised.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewSolutionRaiseRaised.Size = new System.Drawing.Size(1585, 363);
            this.dataGridViewSolutionRaiseRaised.TabIndex = 38;
            // 
            // ID
            // 
            this.ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.Width = 55;
            // 
            // Date_Raised
            // 
            this.Date_Raised.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Date_Raised.HeaderText = "Date_Raised";
            this.Date_Raised.MinimumWidth = 6;
            this.Date_Raised.Name = "Date_Raised";
            this.Date_Raised.Width = 134;
            // 
            // Raised_By
            // 
            this.Raised_By.HeaderText = "Raised_By";
            this.Raised_By.MinimumWidth = 6;
            this.Raised_By.Name = "Raised_By";
            this.Raised_By.Width = 125;
            // 
            // Received_By
            // 
            this.Received_By.HeaderText = "Received_By";
            this.Received_By.MinimumWidth = 6;
            this.Received_By.Name = "Received_By";
            this.Received_By.Width = 125;
            // 
            // Description_of_Issue
            // 
            this.Description_of_Issue.HeaderText = "Description_of_Issue";
            this.Description_of_Issue.MinimumWidth = 6;
            this.Description_of_Issue.Name = "Description_of_Issue";
            this.Description_of_Issue.Width = 125;
            // 
            // Impact
            // 
            this.Impact.HeaderText = "Impact";
            this.Impact.MinimumWidth = 6;
            this.Impact.Name = "Impact";
            this.Impact.Width = 125;
            // 
            // Priority
            // 
            this.Priority.HeaderText = "Priority";
            this.Priority.MinimumWidth = 6;
            this.Priority.Name = "Priority";
            this.Priority.Width = 125;
            // 
            // Action
            // 
            this.Action.HeaderText = "Action";
            this.Action.MinimumWidth = 6;
            this.Action.Name = "Action";
            this.Action.Width = 125;
            // 
            // Owner
            // 
            this.Owner.HeaderText = "Owner";
            this.Owner.MinimumWidth = 6;
            this.Owner.Name = "Owner";
            this.Owner.Width = 125;
            // 
            // Outcome
            // 
            this.Outcome.HeaderText = "Outcome";
            this.Outcome.MinimumWidth = 6;
            this.Outcome.Name = "Outcome";
            this.Outcome.Width = 125;
            // 
            // Date_for_Resolution
            // 
            this.Date_for_Resolution.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Date_for_Resolution.HeaderText = "Date_for_Resolution";
            this.Date_for_Resolution.MinimumWidth = 6;
            this.Date_for_Resolution.Name = "Date_for_Resolution";
            this.Date_for_Resolution.Width = 190;
            // 
            // Date_Resolved
            // 
            this.Date_Resolved.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Date_Resolved.HeaderText = "Date_Resolved";
            this.Date_Resolved.MinimumWidth = 6;
            this.Date_Resolved.Name = "Date_Resolved";
            this.Date_Resolved.Width = 152;
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(173)))), ((int)(((byte)(252)))));
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExport.Location = new System.Drawing.Point(729, 3);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(160, 45);
            this.btnExport.TabIndex = 37;
            this.btnExport.Text = "Export to Word";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(173)))), ((int)(((byte)(252)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Location = new System.Drawing.Point(547, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(160, 45);
            this.btnSave.TabIndex = 36;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Helvetica", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(9, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 16);
            this.label1.TabIndex = 35;
            this.label1.Text = "Project Manager:";
            // 
            // txtIssueRegisterProjectManager
            // 
            this.txtIssueRegisterProjectManager.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(173)))), ((int)(((byte)(252)))));
            this.txtIssueRegisterProjectManager.Font = new System.Drawing.Font("Helvetica", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIssueRegisterProjectManager.ForeColor = System.Drawing.Color.Black;
            this.txtIssueRegisterProjectManager.Location = new System.Drawing.Point(150, 32);
            this.txtIssueRegisterProjectManager.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtIssueRegisterProjectManager.Name = "txtIssueRegisterProjectManager";
            this.txtIssueRegisterProjectManager.Size = new System.Drawing.Size(364, 24);
            this.txtIssueRegisterProjectManager.TabIndex = 34;
            this.txtIssueRegisterProjectManager.Text = "Project Manager";
            // 
            // txtIssueRegisterProjectName
            // 
            this.txtIssueRegisterProjectName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(173)))), ((int)(((byte)(252)))));
            this.txtIssueRegisterProjectName.Font = new System.Drawing.Font("Helvetica", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIssueRegisterProjectName.ForeColor = System.Drawing.Color.Black;
            this.txtIssueRegisterProjectName.Location = new System.Drawing.Point(150, 3);
            this.txtIssueRegisterProjectName.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtIssueRegisterProjectName.Name = "txtIssueRegisterProjectName";
            this.txtIssueRegisterProjectName.Size = new System.Drawing.Size(364, 24);
            this.txtIssueRegisterProjectName.TabIndex = 32;
            this.txtIssueRegisterProjectName.Text = "Project Name";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Helvetica", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.Black;
            this.label27.Location = new System.Drawing.Point(9, 9);
            this.label27.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(109, 16);
            this.label27.TabIndex = 33;
            this.label27.Text = "Project Name:";
            // 
            // IssueRegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(1613, 472);
            this.Controls.Add(this.dataGridViewSolutionRaiseRaised);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtIssueRegisterProjectManager);
            this.Controls.Add(this.txtIssueRegisterProjectName);
            this.Controls.Add(this.label27);
            this.Name = "IssueRegisterForm";
            this.Text = "IssueRegisterForm";
            this.Load += new System.EventHandler(this.IssueRegisterForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSolutionRaiseRaised)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridViewSolutionRaiseRaised;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIssueRegisterProjectManager;
        private System.Windows.Forms.TextBox txtIssueRegisterProjectName;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date_Raised;
        private System.Windows.Forms.DataGridViewTextBoxColumn Raised_By;
        private System.Windows.Forms.DataGridViewTextBoxColumn Received_By;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description_of_Issue;
        private System.Windows.Forms.DataGridViewTextBoxColumn Impact;
        private System.Windows.Forms.DataGridViewTextBoxColumn Priority;
        private System.Windows.Forms.DataGridViewTextBoxColumn Action;
        private System.Windows.Forms.DataGridViewTextBoxColumn Owner;
        private System.Windows.Forms.DataGridViewTextBoxColumn Outcome;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date_for_Resolution;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date_Resolved;
    }
}