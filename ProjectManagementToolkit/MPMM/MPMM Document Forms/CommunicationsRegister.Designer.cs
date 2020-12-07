namespace ProjectManagementToolkit.MPMM.MPMM_Document_Forms
{
    partial class CommunicationsRegister
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.CommuncationsRegister = new System.Windows.Forms.TabPage();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCommManager = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIssueRegisterProjectManager = new System.Windows.Forms.TextBox();
            this.txtIssueRegisterProjectName = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.dgvCommunicationsRegister = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateApproved = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApprovedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateSent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SentBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SentTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Message = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Feedback = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.CommuncationsRegister.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommunicationsRegister)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.CommuncationsRegister);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1316, 435);
            this.tabControl1.TabIndex = 0;
            // 
            // CommuncationsRegister
            // 
            this.CommuncationsRegister.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            this.CommuncationsRegister.Controls.Add(this.btnSave);
            this.CommuncationsRegister.Controls.Add(this.btnExport);
            this.CommuncationsRegister.Controls.Add(this.label2);
            this.CommuncationsRegister.Controls.Add(this.txtCommManager);
            this.CommuncationsRegister.Controls.Add(this.label1);
            this.CommuncationsRegister.Controls.Add(this.txtIssueRegisterProjectManager);
            this.CommuncationsRegister.Controls.Add(this.txtIssueRegisterProjectName);
            this.CommuncationsRegister.Controls.Add(this.label27);
            this.CommuncationsRegister.Controls.Add(this.dgvCommunicationsRegister);
            this.CommuncationsRegister.Location = new System.Drawing.Point(4, 23);
            this.CommuncationsRegister.Name = "CommuncationsRegister";
            this.CommuncationsRegister.Padding = new System.Windows.Forms.Padding(3);
            this.CommuncationsRegister.Size = new System.Drawing.Size(1308, 408);
            this.CommuncationsRegister.TabIndex = 0;
            this.CommuncationsRegister.Text = "Communications Register";
            this.CommuncationsRegister.Click += new System.EventHandler(this.CommuncationsRegister_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(173)))), ((int)(((byte)(252)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Location = new System.Drawing.Point(480, 47);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 37);
            this.btnSave.TabIndex = 43;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(173)))), ((int)(((byte)(252)))));
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExport.Location = new System.Drawing.Point(614, 47);
            this.btnExport.Margin = new System.Windows.Forms.Padding(2);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(120, 37);
            this.btnExport.TabIndex = 42;
            this.btnExport.Text = "Export to Excel";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(25, 67);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 14);
            this.label2.TabIndex = 41;
            this.label2.Text = "Communication Manager:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtCommManager
            // 
            this.txtCommManager.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(173)))), ((int)(((byte)(252)))));
            this.txtCommManager.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCommManager.ForeColor = System.Drawing.Color.Black;
            this.txtCommManager.Location = new System.Drawing.Point(181, 64);
            this.txtCommManager.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtCommManager.Name = "txtCommManager";
            this.txtCommManager.Size = new System.Drawing.Size(274, 20);
            this.txtCommManager.TabIndex = 40;
            this.txtCommManager.Text = "Communication Manager";
            this.txtCommManager.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(25, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 14);
            this.label1.TabIndex = 39;
            this.label1.Text = "Project Manager:";
            // 
            // txtIssueRegisterProjectManager
            // 
            this.txtIssueRegisterProjectManager.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(173)))), ((int)(((byte)(252)))));
            this.txtIssueRegisterProjectManager.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIssueRegisterProjectManager.ForeColor = System.Drawing.Color.Black;
            this.txtIssueRegisterProjectManager.Location = new System.Drawing.Point(181, 36);
            this.txtIssueRegisterProjectManager.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtIssueRegisterProjectManager.Name = "txtIssueRegisterProjectManager";
            this.txtIssueRegisterProjectManager.Size = new System.Drawing.Size(274, 20);
            this.txtIssueRegisterProjectManager.TabIndex = 38;
            this.txtIssueRegisterProjectManager.Text = "Project Manager";
            // 
            // txtIssueRegisterProjectName
            // 
            this.txtIssueRegisterProjectName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(173)))), ((int)(((byte)(252)))));
            this.txtIssueRegisterProjectName.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIssueRegisterProjectName.ForeColor = System.Drawing.Color.Black;
            this.txtIssueRegisterProjectName.Location = new System.Drawing.Point(181, 11);
            this.txtIssueRegisterProjectName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtIssueRegisterProjectName.Name = "txtIssueRegisterProjectName";
            this.txtIssueRegisterProjectName.Size = new System.Drawing.Size(274, 20);
            this.txtIssueRegisterProjectName.TabIndex = 36;
            this.txtIssueRegisterProjectName.Text = "Project Name";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.Black;
            this.label27.Location = new System.Drawing.Point(25, 17);
            this.label27.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(83, 14);
            this.label27.TabIndex = 37;
            this.label27.Text = "Project Name:";
            // 
            // dgvCommunicationsRegister
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(173)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(173)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCommunicationsRegister.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCommunicationsRegister.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCommunicationsRegister.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Status,
            this.DateApproved,
            this.ApprovedBy,
            this.DateSent,
            this.SentBy,
            this.SentTo,
            this.Type,
            this.Message,
            this.FileLocation,
            this.Feedback});
            this.dgvCommunicationsRegister.EnableHeadersVisualStyles = false;
            this.dgvCommunicationsRegister.Location = new System.Drawing.Point(6, 99);
            this.dgvCommunicationsRegister.Name = "dgvCommunicationsRegister";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(173)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCommunicationsRegister.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvCommunicationsRegister.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCommunicationsRegister.Size = new System.Drawing.Size(1153, 247);
            this.dgvCommunicationsRegister.TabIndex = 6;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            // 
            // DateApproved
            // 
            this.DateApproved.HeaderText = "Date Approval";
            this.DateApproved.Name = "DateApproved";
            // 
            // ApprovedBy
            // 
            this.ApprovedBy.HeaderText = "Approved By";
            this.ApprovedBy.Name = "ApprovedBy";
            // 
            // DateSent
            // 
            this.DateSent.HeaderText = "Date Sent";
            this.DateSent.Name = "DateSent";
            // 
            // SentBy
            // 
            this.SentBy.HeaderText = "Sent By";
            this.SentBy.Name = "SentBy";
            // 
            // SentTo
            // 
            this.SentTo.HeaderText = "Sent To";
            this.SentTo.Name = "SentTo";
            // 
            // Type
            // 
            this.Type.HeaderText = "Type";
            this.Type.Name = "Type";
            // 
            // Message
            // 
            this.Message.HeaderText = "Message";
            this.Message.Name = "Message";
            // 
            // FileLocation
            // 
            this.FileLocation.HeaderText = "File Location";
            this.FileLocation.Name = "FileLocation";
            // 
            // Feedback
            // 
            this.Feedback.HeaderText = "Feedback";
            this.Feedback.Name = "Feedback";
            // 
            // CommunicationsRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(1187, 409);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "CommunicationsRegister";
            this.Text = "CommunicationsRegister";
            this.Load += new System.EventHandler(this.CommunicationsRegister_Load);
            this.tabControl1.ResumeLayout(false);
            this.CommuncationsRegister.ResumeLayout(false);
            this.CommuncationsRegister.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommunicationsRegister)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage CommuncationsRegister;
        private System.Windows.Forms.DataGridView dgvCommunicationsRegister;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateApproved;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApprovedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateSent;
        private System.Windows.Forms.DataGridViewTextBoxColumn SentBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn SentTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Message;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn Feedback;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCommManager;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIssueRegisterProjectManager;
        private System.Windows.Forms.TextBox txtIssueRegisterProjectName;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnSave;
    }
}