namespace ProjectManagementToolkit.MPMM.MPMM_Document_Forms
{
    partial class ExpenseRegister
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
            this.dataGridViewExpenseRegister = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIssueRegisterProjectManager = new System.Windows.Forms.TextBox();
            this.txtIssueRegisterProjectName = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.ActivityID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActivityDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaskIID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaskDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExpenseID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExpenseType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExpenseDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExpenseAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApprovalStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApprovalDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Approver = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaymentStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaymentDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Payee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Method = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExpenseRegister)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewExpenseRegister
            // 
            this.dataGridViewExpenseRegister.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(173)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(173)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewExpenseRegister.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewExpenseRegister.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewExpenseRegister.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ActivityID,
            this.ActivityDescription,
            this.TaskIID,
            this.TaskDesc,
            this.ExpenseID,
            this.ExpenseType,
            this.ExpenseDescription,
            this.ExpenseAmount,
            this.ApprovalStatus,
            this.ApprovalDate,
            this.Approver,
            this.PaymentStatus,
            this.PaymentDate,
            this.Payee,
            this.Method});
            this.dataGridViewExpenseRegister.EnableHeadersVisualStyles = false;
            this.dataGridViewExpenseRegister.Location = new System.Drawing.Point(12, 78);
            this.dataGridViewExpenseRegister.Name = "dataGridViewExpenseRegister";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(173)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewExpenseRegister.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 10.8F);
            this.dataGridViewExpenseRegister.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewExpenseRegister.Size = new System.Drawing.Size(904, 370);
            this.dataGridViewExpenseRegister.TabIndex = 4;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(173)))), ((int)(((byte)(252)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Location = new System.Drawing.Point(408, 24);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 37);
            this.btnSave.TabIndex = 37;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(11, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 14);
            this.label1.TabIndex = 41;
            this.label1.Text = "Project Manager:";
            // 
            // txtIssueRegisterProjectManager
            // 
            this.txtIssueRegisterProjectManager.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(173)))), ((int)(((byte)(252)))));
            this.txtIssueRegisterProjectManager.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIssueRegisterProjectManager.ForeColor = System.Drawing.Color.Black;
            this.txtIssueRegisterProjectManager.Location = new System.Drawing.Point(116, 41);
            this.txtIssueRegisterProjectManager.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtIssueRegisterProjectManager.Name = "txtIssueRegisterProjectManager";
            this.txtIssueRegisterProjectManager.Size = new System.Drawing.Size(274, 20);
            this.txtIssueRegisterProjectManager.TabIndex = 40;
            this.txtIssueRegisterProjectManager.Text = "Project Manager";
            // 
            // txtIssueRegisterProjectName
            // 
            this.txtIssueRegisterProjectName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(173)))), ((int)(((byte)(252)))));
            this.txtIssueRegisterProjectName.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIssueRegisterProjectName.ForeColor = System.Drawing.Color.Black;
            this.txtIssueRegisterProjectName.Location = new System.Drawing.Point(116, 17);
            this.txtIssueRegisterProjectName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtIssueRegisterProjectName.Name = "txtIssueRegisterProjectName";
            this.txtIssueRegisterProjectName.Size = new System.Drawing.Size(274, 20);
            this.txtIssueRegisterProjectName.TabIndex = 38;
            this.txtIssueRegisterProjectName.Text = "Project Name";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.Black;
            this.label27.Location = new System.Drawing.Point(11, 22);
            this.label27.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(83, 14);
            this.label27.TabIndex = 39;
            this.label27.Text = "Project Name:";
            // 
            // ActivityID
            // 
            this.ActivityID.HeaderText = "Activity ID";
            this.ActivityID.Name = "ActivityID";
            // 
            // ActivityDescription
            // 
            this.ActivityDescription.HeaderText = "Activity Description";
            this.ActivityDescription.Name = "ActivityDescription";
            // 
            // TaskIID
            // 
            this.TaskIID.HeaderText = "Task ID";
            this.TaskIID.Name = "TaskIID";
            // 
            // TaskDesc
            // 
            this.TaskDesc.HeaderText = "Task Description ";
            this.TaskDesc.Name = "TaskDesc";
            // 
            // ExpenseID
            // 
            this.ExpenseID.HeaderText = "Expense ID";
            this.ExpenseID.Name = "ExpenseID";
            // 
            // ExpenseType
            // 
            this.ExpenseType.HeaderText = "Expense Type";
            this.ExpenseType.Name = "ExpenseType";
            // 
            // ExpenseDescription
            // 
            this.ExpenseDescription.HeaderText = "Expense Description";
            this.ExpenseDescription.Name = "ExpenseDescription";
            // 
            // ExpenseAmount
            // 
            this.ExpenseAmount.HeaderText = "Expense Amount";
            this.ExpenseAmount.Name = "ExpenseAmount";
            // 
            // ApprovalStatus
            // 
            this.ApprovalStatus.HeaderText = "Approval Status";
            this.ApprovalStatus.Name = "ApprovalStatus";
            // 
            // ApprovalDate
            // 
            this.ApprovalDate.HeaderText = "Approval Date";
            this.ApprovalDate.Name = "ApprovalDate";
            // 
            // Approver
            // 
            this.Approver.HeaderText = "Approver";
            this.Approver.Name = "Approver";
            // 
            // PaymentStatus
            // 
            this.PaymentStatus.HeaderText = "Payment Status";
            this.PaymentStatus.Name = "PaymentStatus";
            // 
            // PaymentDate
            // 
            this.PaymentDate.HeaderText = "Payment Date";
            this.PaymentDate.Name = "PaymentDate";
            // 
            // Payee
            // 
            this.Payee.HeaderText = "Payee";
            this.Payee.Name = "Payee";
            // 
            // Method
            // 
            this.Method.HeaderText = "Method";
            this.Method.Name = "Method";
            // 
            // ExpenseRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(933, 484);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtIssueRegisterProjectManager);
            this.Controls.Add(this.txtIssueRegisterProjectName);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dataGridViewExpenseRegister);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "ExpenseRegister";
            this.Text = "ExpenseRegister";
            this.Load += new System.EventHandler(this.ExpenseRegister_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExpenseRegister)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridViewExpenseRegister;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIssueRegisterProjectManager;
        private System.Windows.Forms.TextBox txtIssueRegisterProjectName;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActivityID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActivityDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaskIID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaskDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExpenseID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExpenseType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExpenseDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExpenseAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApprovalStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApprovalDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Approver;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaymentStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaymentDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Payee;
        private System.Windows.Forms.DataGridViewTextBoxColumn Method;
    }
}