namespace ProjectManagementToolkit.MPMM.MPMM_Document_Forms
{
    partial class ChangeRegister
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
            this.dgvChangeRegister = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date_Raised = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Raised_By = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Recieved_By = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description_of_change = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description_of_impact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Impact_Rating = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Change_Approver = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Approval_Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Approval_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Implementation_Resource = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Implementation_Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Implementation_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.Project_Manager_tbx = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.Project_Name_tbx = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChangeRegister)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvChangeRegister
            // 
            this.dgvChangeRegister.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvChangeRegister.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChangeRegister.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(173)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(173)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvChangeRegister.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvChangeRegister.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChangeRegister.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Date_Raised,
            this.Raised_By,
            this.Recieved_By,
            this.Description_of_change,
            this.Description_of_impact,
            this.Impact_Rating,
            this.Change_Approver,
            this.Approval_Status,
            this.Approval_date,
            this.Implementation_Resource,
            this.Implementation_Status,
            this.Implementation_Date});
            this.dgvChangeRegister.EnableHeadersVisualStyles = false;
            this.dgvChangeRegister.Location = new System.Drawing.Point(20, 194);
            this.dgvChangeRegister.Name = "dgvChangeRegister";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(173)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvChangeRegister.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvChangeRegister.RowHeadersWidth = 51;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvChangeRegister.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvChangeRegister.Size = new System.Drawing.Size(1329, 341);
            this.dgvChangeRegister.TabIndex = 27;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            // 
            // Date_Raised
            // 
            this.Date_Raised.HeaderText = "Date Raised";
            this.Date_Raised.MinimumWidth = 6;
            this.Date_Raised.Name = "Date_Raised";
            // 
            // Raised_By
            // 
            this.Raised_By.HeaderText = "Raised By";
            this.Raised_By.MinimumWidth = 6;
            this.Raised_By.Name = "Raised_By";
            // 
            // Recieved_By
            // 
            this.Recieved_By.HeaderText = "Recieved By";
            this.Recieved_By.MinimumWidth = 6;
            this.Recieved_By.Name = "Recieved_By";
            // 
            // Description_of_change
            // 
            this.Description_of_change.HeaderText = "Description of change";
            this.Description_of_change.MinimumWidth = 6;
            this.Description_of_change.Name = "Description_of_change";
            // 
            // Description_of_impact
            // 
            this.Description_of_impact.HeaderText = "Description of impact";
            this.Description_of_impact.MinimumWidth = 6;
            this.Description_of_impact.Name = "Description_of_impact";
            // 
            // Impact_Rating
            // 
            this.Impact_Rating.HeaderText = "Impact Rating";
            this.Impact_Rating.MinimumWidth = 6;
            this.Impact_Rating.Name = "Impact_Rating";
            // 
            // Change_Approver
            // 
            this.Change_Approver.HeaderText = "Change Approver";
            this.Change_Approver.MinimumWidth = 6;
            this.Change_Approver.Name = "Change_Approver";
            // 
            // Approval_Status
            // 
            this.Approval_Status.HeaderText = "Approval Status";
            this.Approval_Status.MinimumWidth = 6;
            this.Approval_Status.Name = "Approval_Status";
            // 
            // Approval_date
            // 
            this.Approval_date.HeaderText = "Approval date";
            this.Approval_date.MinimumWidth = 6;
            this.Approval_date.Name = "Approval_date";
            // 
            // Implementation_Resource
            // 
            this.Implementation_Resource.HeaderText = "Implementation Resource";
            this.Implementation_Resource.MinimumWidth = 6;
            this.Implementation_Resource.Name = "Implementation_Resource";
            // 
            // Implementation_Status
            // 
            this.Implementation_Status.HeaderText = "Implementation Status";
            this.Implementation_Status.MinimumWidth = 6;
            this.Implementation_Status.Name = "Implementation_Status";
            // 
            // Implementation_Date
            // 
            this.Implementation_Date.HeaderText = "Implementation Date";
            this.Implementation_Date.MinimumWidth = 6;
            this.Implementation_Date.Name = "Implementation_Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(370, 51);
            this.label4.TabIndex = 25;
            this.label4.Text = "Change Register";
            // 
            // Project_Manager_tbx
            // 
            this.Project_Manager_tbx.Location = new System.Drawing.Point(170, 147);
            this.Project_Manager_tbx.Name = "Project_Manager_tbx";
            this.Project_Manager_tbx.Size = new System.Drawing.Size(237, 23);
            this.Project_Manager_tbx.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 25);
            this.label2.TabIndex = 21;
            this.label2.Text = "Project Manager:";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(173)))), ((int)(((byte)(252)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.btnSave.Location = new System.Drawing.Point(433, 100);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(119, 70);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // Project_Name_tbx
            // 
            this.Project_Name_tbx.Location = new System.Drawing.Point(170, 104);
            this.Project_Name_tbx.Name = "Project_Name_tbx";
            this.Project_Name_tbx.Size = new System.Drawing.Size(237, 23);
            this.Project_Name_tbx.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 25);
            this.label1.TabIndex = 18;
            this.label1.Text = "Project Name:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(173)))), ((int)(((byte)(252)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.button1.Location = new System.Drawing.Point(576, 100);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 70);
            this.button1.TabIndex = 28;
            this.button1.Text = "Export to Excel";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ChangeRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(1361, 547);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvChangeRegister);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Project_Manager_tbx);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.Project_Name_tbx);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "ChangeRegister";
            this.Text = "ChangeRegister";
            this.Load += new System.EventHandler(this.ChangeRegister_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChangeRegister)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvChangeRegister;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Project_Manager_tbx;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox Project_Name_tbx;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date_Raised;
        private System.Windows.Forms.DataGridViewTextBoxColumn Raised_By;
        private System.Windows.Forms.DataGridViewTextBoxColumn Recieved_By;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description_of_change;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description_of_impact;
        private System.Windows.Forms.DataGridViewTextBoxColumn Impact_Rating;
        private System.Windows.Forms.DataGridViewTextBoxColumn Change_Approver;
        private System.Windows.Forms.DataGridViewTextBoxColumn Approval_Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Approval_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Implementation_Resource;
        private System.Windows.Forms.DataGridViewTextBoxColumn Implementation_Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Implementation_Date;
        private System.Windows.Forms.Button button1;
    }
}