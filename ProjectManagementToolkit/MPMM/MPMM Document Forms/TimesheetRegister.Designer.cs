namespace ProjectManagementToolkit.MPMM.MPMM_Document_Forms
{
    partial class TimesheetRegister
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
            this.btnEnterData = new System.Windows.Forms.Button();
            this.dataGridViewTimesheetRegister = new System.Windows.Forms.DataGridView();
            this.txtProjectManager = new System.Windows.Forms.TextBox();
            this.txtProjectName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTimesheetRegister)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEnterData
            // 
            this.btnEnterData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(173)))), ((int)(((byte)(252)))));
            this.btnEnterData.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.btnEnterData.Location = new System.Drawing.Point(832, 40);
            this.btnEnterData.Name = "btnEnterData";
            this.btnEnterData.Size = new System.Drawing.Size(87, 27);
            this.btnEnterData.TabIndex = 11;
            this.btnEnterData.Text = "Enter Data";
            this.btnEnterData.UseVisualStyleBackColor = false;
            this.btnEnterData.Click += new System.EventHandler(this.btnEnterData_Click);
            // 
            // dataGridViewTimesheetRegister
            // 
            this.dataGridViewTimesheetRegister.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(173)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(173)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTimesheetRegister.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTimesheetRegister.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTimesheetRegister.EnableHeadersVisualStyles = false;
            this.dataGridViewTimesheetRegister.Location = new System.Drawing.Point(15, 100);
            this.dataGridViewTimesheetRegister.Name = "dataGridViewTimesheetRegister";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(173)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTimesheetRegister.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 10.8F);
            this.dataGridViewTimesheetRegister.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTimesheetRegister.Size = new System.Drawing.Size(904, 370);
            this.dataGridViewTimesheetRegister.TabIndex = 10;
            // 
            // txtProjectManager
            // 
            this.txtProjectManager.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProjectManager.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            this.txtProjectManager.ForeColor = System.Drawing.Color.Black;
            this.txtProjectManager.Location = new System.Drawing.Point(122, 59);
            this.txtProjectManager.Name = "txtProjectManager";
            this.txtProjectManager.Size = new System.Drawing.Size(116, 20);
            this.txtProjectManager.TabIndex = 9;
            this.txtProjectManager.Text = "Project Manager";
            // 
            // txtProjectName
            // 
            this.txtProjectName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProjectName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            this.txtProjectName.ForeColor = System.Drawing.Color.Black;
            this.txtProjectName.Location = new System.Drawing.Point(122, 14);
            this.txtProjectName.Name = "txtProjectName";
            this.txtProjectName.Size = new System.Drawing.Size(116, 20);
            this.txtProjectName.TabIndex = 8;
            this.txtProjectName.Text = "Project Name";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 14);
            this.label2.TabIndex = 7;
            this.label2.Text = "Project Manager: ";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 14);
            this.label1.TabIndex = 6;
            this.label1.Text = "Project Name:";
            // 
            // TimesheetRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(933, 484);
            this.Controls.Add(this.btnEnterData);
            this.Controls.Add(this.dataGridViewTimesheetRegister);
            this.Controls.Add(this.txtProjectManager);
            this.Controls.Add(this.txtProjectName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "TimesheetRegister";
            this.Text = "TimesheetRegister";
            this.Load += new System.EventHandler(this.TimesheetRegister_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTimesheetRegister)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEnterData;
        private System.Windows.Forms.DataGridView dataGridViewTimesheetRegister;
        private System.Windows.Forms.TextBox txtProjectManager;
        private System.Windows.Forms.TextBox txtProjectName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}