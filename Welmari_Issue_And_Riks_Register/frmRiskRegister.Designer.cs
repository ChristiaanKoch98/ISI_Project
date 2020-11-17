namespace Welmari_Issue_And_Riks_Register
{
    partial class frmRiskRegister
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridViewSolutionRaiseRaised = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date_Raised = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Raised_By = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Received_By = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description_of_Issue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Impact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Likelihood_Rating = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Impact_Rating = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Priority_Rating = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Preventative_Actions = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PreventativeActionsOwner = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PreventativeActions_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Contingency_Actions = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Contingency_ActionsOwner = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Contingency_ActionsData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRiskRegisterProjectManager = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.txtRiskRegisterProjectName = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSolutionRaiseRaised)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.dataGridViewSolutionRaiseRaised);
            this.panel1.Location = new System.Drawing.Point(20, 74);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1098, 509);
            this.panel1.TabIndex = 26;
            // 
            // dataGridViewSolutionRaiseRaised
            // 
            this.dataGridViewSolutionRaiseRaised.AllowUserToOrderColumns = true;
            this.dataGridViewSolutionRaiseRaised.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSolutionRaiseRaised.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Date_Raised,
            this.Raised_By,
            this.Received_By,
            this.Description_of_Issue,
            this.Impact,
            this.Likelihood_Rating,
            this.Impact_Rating,
            this.Priority_Rating,
            this.Preventative_Actions,
            this.PreventativeActionsOwner,
            this.PreventativeActions_Date,
            this.Contingency_Actions,
            this.Contingency_ActionsOwner,
            this.Contingency_ActionsData});
            this.dataGridViewSolutionRaiseRaised.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewSolutionRaiseRaised.Name = "dataGridViewSolutionRaiseRaised";
            this.dataGridViewSolutionRaiseRaised.RowHeadersWidth = 51;
            this.dataGridViewSolutionRaiseRaised.Size = new System.Drawing.Size(1088, 499);
            this.dataGridViewSolutionRaiseRaised.TabIndex = 22;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            // 
            // Date_Raised
            // 
            this.Date_Raised.HeaderText = "Date_Raised";
            this.Date_Raised.Name = "Date_Raised";
            // 
            // Raised_By
            // 
            this.Raised_By.HeaderText = "Raised_By";
            this.Raised_By.Name = "Raised_By";
            // 
            // Received_By
            // 
            this.Received_By.HeaderText = "Received_By";
            this.Received_By.Name = "Received_By";
            // 
            // Description_of_Issue
            // 
            this.Description_of_Issue.HeaderText = "Description_of_Risk";
            this.Description_of_Issue.Name = "Description_of_Issue";
            // 
            // Impact
            // 
            this.Impact.HeaderText = "Description_of_Impact";
            this.Impact.Name = "Impact";
            // 
            // Likelihood_Rating
            // 
            this.Likelihood_Rating.HeaderText = "Likelihood_Rating";
            this.Likelihood_Rating.Name = "Likelihood_Rating";
            // 
            // Impact_Rating
            // 
            this.Impact_Rating.HeaderText = "Impact_Rating";
            this.Impact_Rating.Name = "Impact_Rating";
            // 
            // Priority_Rating
            // 
            this.Priority_Rating.HeaderText = "Priority_Rating";
            this.Priority_Rating.Name = "Priority_Rating";
            // 
            // Preventative_Actions
            // 
            this.Preventative_Actions.HeaderText = "Preventative_Actions";
            this.Preventative_Actions.Name = "Preventative_Actions";
            // 
            // PreventativeActionsOwner
            // 
            this.PreventativeActionsOwner.HeaderText = "Preventative_ActionsOwner";
            this.PreventativeActionsOwner.Name = "PreventativeActionsOwner";
            // 
            // PreventativeActions_Date
            // 
            this.PreventativeActions_Date.HeaderText = "Preventative_ActionsDate";
            this.PreventativeActions_Date.Name = "PreventativeActions_Date";
            // 
            // Contingency_Actions
            // 
            this.Contingency_Actions.HeaderText = "Contingency_Actions";
            this.Contingency_Actions.Name = "Contingency_Actions";
            // 
            // Contingency_ActionsOwner
            // 
            this.Contingency_ActionsOwner.HeaderText = "Contingency_ActionsOwner";
            this.Contingency_ActionsOwner.Name = "Contingency_ActionsOwner";
            // 
            // Contingency_ActionsData
            // 
            this.Contingency_ActionsData.HeaderText = "Contingency_ActionsData";
            this.Contingency_ActionsData.Name = "Contingency_ActionsData";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(16, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 12);
            this.label1.TabIndex = 25;
            this.label1.Text = "Project Manager:";
            // 
            // txtRiskRegisterProjectManager
            // 
            this.txtRiskRegisterProjectManager.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.txtRiskRegisterProjectManager.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRiskRegisterProjectManager.ForeColor = System.Drawing.Color.White;
            this.txtRiskRegisterProjectManager.Location = new System.Drawing.Point(109, 38);
            this.txtRiskRegisterProjectManager.Margin = new System.Windows.Forms.Padding(4);
            this.txtRiskRegisterProjectManager.Name = "txtRiskRegisterProjectManager";
            this.txtRiskRegisterProjectManager.Size = new System.Drawing.Size(116, 20);
            this.txtRiskRegisterProjectManager.TabIndex = 24;
            this.txtRiskRegisterProjectManager.Text = "Project Manager";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.White;
            this.label27.Location = new System.Drawing.Point(18, 13);
            this.label27.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(70, 12);
            this.label27.TabIndex = 23;
            this.label27.Text = "Project Name:";
            // 
            // txtRiskRegisterProjectName
            // 
            this.txtRiskRegisterProjectName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.txtRiskRegisterProjectName.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRiskRegisterProjectName.ForeColor = System.Drawing.Color.White;
            this.txtRiskRegisterProjectName.Location = new System.Drawing.Point(109, 10);
            this.txtRiskRegisterProjectName.Margin = new System.Windows.Forms.Padding(4);
            this.txtRiskRegisterProjectName.Name = "txtRiskRegisterProjectName";
            this.txtRiskRegisterProjectName.Size = new System.Drawing.Size(116, 20);
            this.txtRiskRegisterProjectName.TabIndex = 22;
            this.txtRiskRegisterProjectName.Text = "Project Name";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(235, 35);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(144, 25);
            this.btnSearch.TabIndex = 27;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(974, 35);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(144, 25);
            this.btnBack.TabIndex = 28;
            this.btnBack.Text = "Back to Main Menu";
            this.btnBack.UseVisualStyleBackColor = true;
            // 
            // frmRiskRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(1135, 598);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRiskRegisterProjectManager);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.txtRiskRegisterProjectName);
            this.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmRiskRegister";
            this.Text = "Risk Register";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSolutionRaiseRaised)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridViewSolutionRaiseRaised;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRiskRegisterProjectManager;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox txtRiskRegisterProjectName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date_Raised;
        private System.Windows.Forms.DataGridViewTextBoxColumn Raised_By;
        private System.Windows.Forms.DataGridViewTextBoxColumn Received_By;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description_of_Issue;
        private System.Windows.Forms.DataGridViewTextBoxColumn Impact;
        private System.Windows.Forms.DataGridViewTextBoxColumn Likelihood_Rating;
        private System.Windows.Forms.DataGridViewTextBoxColumn Impact_Rating;
        private System.Windows.Forms.DataGridViewTextBoxColumn Priority_Rating;
        private System.Windows.Forms.DataGridViewTextBoxColumn Preventative_Actions;
        private System.Windows.Forms.DataGridViewTextBoxColumn PreventativeActionsOwner;
        private System.Windows.Forms.DataGridViewTextBoxColumn PreventativeActions_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Contingency_Actions;
        private System.Windows.Forms.DataGridViewTextBoxColumn Contingency_ActionsOwner;
        private System.Windows.Forms.DataGridViewTextBoxColumn Contingency_ActionsData;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnBack;
    }
}