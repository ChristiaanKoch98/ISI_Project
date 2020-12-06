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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
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
            this.CommunicationsManager = new System.Windows.Forms.Label();
            this.ProjectManager = new System.Windows.Forms.Label();
            this.ProjectName = new System.Windows.Forms.Label();
            this.comMan = new System.Windows.Forms.TextBox();
            this.projMan = new System.Windows.Forms.TextBox();
            this.projName = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.CommuncationsRegister.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.CommuncationsRegister);
            this.tabControl1.Location = new System.Drawing.Point(14, 37);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1316, 435);
            this.tabControl1.TabIndex = 0;
            // 
            // CommuncationsRegister
            // 
            this.CommuncationsRegister.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            this.CommuncationsRegister.Controls.Add(this.dataGridView1);
            this.CommuncationsRegister.Controls.Add(this.CommunicationsManager);
            this.CommuncationsRegister.Controls.Add(this.ProjectManager);
            this.CommuncationsRegister.Controls.Add(this.ProjectName);
            this.CommuncationsRegister.Controls.Add(this.comMan);
            this.CommuncationsRegister.Controls.Add(this.projMan);
            this.CommuncationsRegister.Controls.Add(this.projName);
            this.CommuncationsRegister.Location = new System.Drawing.Point(4, 23);
            this.CommuncationsRegister.Name = "CommuncationsRegister";
            this.CommuncationsRegister.Padding = new System.Windows.Forms.Padding(3);
            this.CommuncationsRegister.Size = new System.Drawing.Size(1308, 408);
            this.CommuncationsRegister.TabIndex = 0;
            this.CommuncationsRegister.Text = "Communications Register";
            this.CommuncationsRegister.Click += new System.EventHandler(this.CommuncationsRegister_Click);
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(173)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(173)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(15, 215);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(173)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Size = new System.Drawing.Size(1284, 162);
            this.dataGridView1.TabIndex = 6;
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
            // CommunicationsManager
            // 
            this.CommunicationsManager.AutoSize = true;
            this.CommunicationsManager.Location = new System.Drawing.Point(12, 97);
            this.CommunicationsManager.Name = "CommunicationsManager";
            this.CommunicationsManager.Size = new System.Drawing.Size(155, 14);
            this.CommunicationsManager.TabIndex = 5;
            this.CommunicationsManager.Text = "Communications Manager:";
            // 
            // ProjectManager
            // 
            this.ProjectManager.AutoSize = true;
            this.ProjectManager.Location = new System.Drawing.Point(12, 53);
            this.ProjectManager.Name = "ProjectManager";
            this.ProjectManager.Size = new System.Drawing.Size(100, 14);
            this.ProjectManager.TabIndex = 4;
            this.ProjectManager.Text = "Project Manager:";
            // 
            // ProjectName
            // 
            this.ProjectName.AutoSize = true;
            this.ProjectName.Location = new System.Drawing.Point(8, 13);
            this.ProjectName.Name = "ProjectName";
            this.ProjectName.Size = new System.Drawing.Size(83, 14);
            this.ProjectName.TabIndex = 3;
            this.ProjectName.Text = "Project Name:";
            // 
            // comMan
            // 
            this.comMan.Font = new System.Drawing.Font("Arial", 8.25F);
            this.comMan.Location = new System.Drawing.Point(176, 90);
            this.comMan.Name = "comMan";
            this.comMan.Size = new System.Drawing.Size(116, 20);
            this.comMan.TabIndex = 2;
            // 
            // projMan
            // 
            this.projMan.Font = new System.Drawing.Font("Arial", 8.25F);
            this.projMan.Location = new System.Drawing.Point(176, 46);
            this.projMan.Name = "projMan";
            this.projMan.Size = new System.Drawing.Size(116, 20);
            this.projMan.TabIndex = 1;
            // 
            // projName
            // 
            this.projName.Font = new System.Drawing.Font("Arial", 8.25F);
            this.projName.Location = new System.Drawing.Point(176, 6);
            this.projName.Name = "projName";
            this.projName.Size = new System.Drawing.Size(116, 20);
            this.projName.TabIndex = 0;
            // 
            // CommunicationsRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(1344, 485);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "CommunicationsRegister";
            this.Text = "CommunicationsRegister";
            this.tabControl1.ResumeLayout(false);
            this.CommuncationsRegister.ResumeLayout(false);
            this.CommuncationsRegister.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage CommuncationsRegister;
        private System.Windows.Forms.Label CommunicationsManager;
        private System.Windows.Forms.Label ProjectManager;
        private System.Windows.Forms.Label ProjectName;
        private System.Windows.Forms.TextBox comMan;
        private System.Windows.Forms.TextBox projMan;
        private System.Windows.Forms.TextBox projName;
        private System.Windows.Forms.DataGridView dataGridView1;
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
    }
}