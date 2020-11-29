namespace ProjectManagementToolkit.MPMM.MPMM_Document_Forms
{
    partial class QualityReviewPlanDocumentForm
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
            this.tbpQualityOfProcess = new System.Windows.Forms.TabPage();
            this.txtQualityOfProcess = new System.Windows.Forms.TextBox();
            this.tbcQualityReviewForm = new System.Windows.Forms.TabControl();
            this.tbpQualityOfDeliverables = new System.Windows.Forms.TabPage();
            this.label27 = new System.Windows.Forms.Label();
            this.txtQualityReviewFormProjectName = new System.Windows.Forms.TextBox();
            this.btnQualityReviewForm_MainMenue = new System.Windows.Forms.Button();
            this.btnQualityReviewForm_EnterProjectName = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewQualityOfProcess = new System.Windows.Forms.DataGridView();
            this.Process = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Procedure = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StandardMet1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Deviation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CorrectiveAction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewQualityOfDeliverables = new System.Windows.Forms.DataGridView();
            this.Requirement = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Deliverable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QualityCriteria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QualityStandards = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StandardMet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QualityDeviation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CorrectiveActionsRequired = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.txtQualityOfDeliverables = new System.Windows.Forms.TextBox();
            this.tbpQualityOfProcess.SuspendLayout();
            this.tbcQualityReviewForm.SuspendLayout();
            this.tbpQualityOfDeliverables.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewQualityOfProcess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewQualityOfDeliverables)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbpQualityOfProcess
            // 
            this.tbpQualityOfProcess.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            this.tbpQualityOfProcess.Controls.Add(this.panel2);
            this.tbpQualityOfProcess.Controls.Add(this.panel1);
            this.tbpQualityOfProcess.Controls.Add(this.dataGridViewQualityOfProcess);
            this.tbpQualityOfProcess.Controls.Add(this.txtQualityOfProcess);
            this.tbpQualityOfProcess.Location = new System.Drawing.Point(4, 21);
            this.tbpQualityOfProcess.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbpQualityOfProcess.Name = "tbpQualityOfProcess";
            this.tbpQualityOfProcess.Size = new System.Drawing.Size(1291, 594);
            this.tbpQualityOfProcess.TabIndex = 3;
            this.tbpQualityOfProcess.Text = "Quality of Process";
            // 
            // txtQualityOfProcess
            // 
            this.txtQualityOfProcess.BackColor = System.Drawing.SystemColors.Control;
            this.txtQualityOfProcess.Location = new System.Drawing.Point(15, 16);
            this.txtQualityOfProcess.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtQualityOfProcess.Multiline = true;
            this.txtQualityOfProcess.Name = "txtQualityOfProcess";
            this.txtQualityOfProcess.Size = new System.Drawing.Size(1259, 61);
            this.txtQualityOfProcess.TabIndex = 5;
            this.txtQualityOfProcess.Text = "This form is used to determine the project’s conformance to the management proces" +
    "ses specified in the Terms of References. An example is provided for reference:";
            // 
            // tbcQualityReviewForm
            // 
            this.tbcQualityReviewForm.AllowDrop = true;
            this.tbcQualityReviewForm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbcQualityReviewForm.Controls.Add(this.tbpQualityOfProcess);
            this.tbcQualityReviewForm.Controls.Add(this.tbpQualityOfDeliverables);
            this.tbcQualityReviewForm.Location = new System.Drawing.Point(19, 52);
            this.tbcQualityReviewForm.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.tbcQualityReviewForm.Name = "tbcQualityReviewForm";
            this.tbcQualityReviewForm.SelectedIndex = 0;
            this.tbcQualityReviewForm.Size = new System.Drawing.Size(1299, 619);
            this.tbcQualityReviewForm.TabIndex = 15;
            // 
            // tbpQualityOfDeliverables
            // 
            this.tbpQualityOfDeliverables.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            this.tbpQualityOfDeliverables.Controls.Add(this.dataGridViewQualityOfDeliverables);
            this.tbpQualityOfDeliverables.Controls.Add(this.panel5);
            this.tbpQualityOfDeliverables.Controls.Add(this.panel3);
            this.tbpQualityOfDeliverables.Controls.Add(this.panel4);
            this.tbpQualityOfDeliverables.Controls.Add(this.txtQualityOfDeliverables);
            this.tbpQualityOfDeliverables.Location = new System.Drawing.Point(4, 21);
            this.tbpQualityOfDeliverables.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbpQualityOfDeliverables.Name = "tbpQualityOfDeliverables";
            this.tbpQualityOfDeliverables.Size = new System.Drawing.Size(1291, 594);
            this.tbpQualityOfDeliverables.TabIndex = 4;
            this.tbpQualityOfDeliverables.Text = "Quality of Deliverables";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Helvetica", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.Black;
            this.label27.Location = new System.Drawing.Point(16, 21);
            this.label27.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(183, 14);
            this.label27.TabIndex = 14;
            this.label27.Text = "Please Enter Your Project Name:";
            // 
            // txtQualityReviewFormProjectName
            // 
            this.txtQualityReviewFormProjectName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(173)))), ((int)(((byte)(252)))));
            this.txtQualityReviewFormProjectName.Font = new System.Drawing.Font("Helvetica", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQualityReviewFormProjectName.ForeColor = System.Drawing.Color.Black;
            this.txtQualityReviewFormProjectName.Location = new System.Drawing.Point(209, 18);
            this.txtQualityReviewFormProjectName.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtQualityReviewFormProjectName.Name = "txtQualityReviewFormProjectName";
            this.txtQualityReviewFormProjectName.Size = new System.Drawing.Size(383, 20);
            this.txtQualityReviewFormProjectName.TabIndex = 13;
            this.txtQualityReviewFormProjectName.Text = "Project Name";
            // 
            // btnQualityReviewForm_MainMenue
            // 
            this.btnQualityReviewForm_MainMenue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(173)))), ((int)(((byte)(252)))));
            this.btnQualityReviewForm_MainMenue.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnQualityReviewForm_MainMenue.ForeColor = System.Drawing.Color.Black;
            this.btnQualityReviewForm_MainMenue.Location = new System.Drawing.Point(716, 15);
            this.btnQualityReviewForm_MainMenue.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnQualityReviewForm_MainMenue.Name = "btnQualityReviewForm_MainMenue";
            this.btnQualityReviewForm_MainMenue.Size = new System.Drawing.Size(130, 26);
            this.btnQualityReviewForm_MainMenue.TabIndex = 18;
            this.btnQualityReviewForm_MainMenue.Text = "Back to Main Menu";
            this.btnQualityReviewForm_MainMenue.UseVisualStyleBackColor = false;
            // 
            // btnQualityReviewForm_EnterProjectName
            // 
            this.btnQualityReviewForm_EnterProjectName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(173)))), ((int)(((byte)(252)))));
            this.btnQualityReviewForm_EnterProjectName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnQualityReviewForm_EnterProjectName.Location = new System.Drawing.Point(601, 15);
            this.btnQualityReviewForm_EnterProjectName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnQualityReviewForm_EnterProjectName.Name = "btnQualityReviewForm_EnterProjectName";
            this.btnQualityReviewForm_EnterProjectName.Size = new System.Drawing.Size(107, 26);
            this.btnQualityReviewForm_EnterProjectName.TabIndex = 17;
            this.btnQualityReviewForm_EnterProjectName.Text = "Enter";
            this.btnQualityReviewForm_EnterProjectName.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(173)))), ((int)(((byte)(252)))));
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(900, 95);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(374, 34);
            this.panel2.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Helvetica", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(136, 8);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Quality Achieved";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(173)))), ((int)(((byte)(252)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(15, 95);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(877, 34);
            this.panel1.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Helvetica", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(370, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Project Process";
            // 
            // dataGridViewQualityOfProcess
            // 
            this.dataGridViewQualityOfProcess.AllowUserToOrderColumns = true;
            this.dataGridViewQualityOfProcess.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewQualityOfProcess.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Process,
            this.Procedure,
            this.StandardMet1,
            this.Deviation,
            this.CorrectiveAction});
            this.dataGridViewQualityOfProcess.Location = new System.Drawing.Point(15, 136);
            this.dataGridViewQualityOfProcess.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dataGridViewQualityOfProcess.Name = "dataGridViewQualityOfProcess";
            this.dataGridViewQualityOfProcess.RowHeadersWidth = 51;
            this.dataGridViewQualityOfProcess.Size = new System.Drawing.Size(1259, 438);
            this.dataGridViewQualityOfProcess.TabIndex = 11;
            // 
            // Process
            // 
            this.Process.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Process.HeaderText = "Process";
            this.Process.MinimumWidth = 6;
            this.Process.Name = "Process";
            // 
            // Procedure
            // 
            this.Procedure.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Procedure.HeaderText = "Procedure";
            this.Procedure.MinimumWidth = 6;
            this.Procedure.Name = "Procedure";
            // 
            // StandardMet1
            // 
            this.StandardMet1.HeaderText = "Standard Met ?";
            this.StandardMet1.MinimumWidth = 6;
            this.StandardMet1.Name = "StandardMet1";
            this.StandardMet1.Width = 125;
            // 
            // Deviation
            // 
            this.Deviation.HeaderText = "Deviation";
            this.Deviation.MinimumWidth = 6;
            this.Deviation.Name = "Deviation";
            this.Deviation.Width = 125;
            // 
            // CorrectiveAction
            // 
            this.CorrectiveAction.HeaderText = "Corrective Action";
            this.CorrectiveAction.MinimumWidth = 6;
            this.CorrectiveAction.Name = "CorrectiveAction";
            this.CorrectiveAction.Width = 125;
            // 
            // dataGridViewQualityOfDeliverables
            // 
            this.dataGridViewQualityOfDeliverables.AllowUserToOrderColumns = true;
            this.dataGridViewQualityOfDeliverables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewQualityOfDeliverables.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Requirement,
            this.Deliverable,
            this.QualityCriteria,
            this.QualityStandards,
            this.StandardMet,
            this.QualityDeviation,
            this.CorrectiveActionsRequired});
            this.dataGridViewQualityOfDeliverables.Location = new System.Drawing.Point(15, 136);
            this.dataGridViewQualityOfDeliverables.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dataGridViewQualityOfDeliverables.Name = "dataGridViewQualityOfDeliverables";
            this.dataGridViewQualityOfDeliverables.RowHeadersWidth = 51;
            this.dataGridViewQualityOfDeliverables.Size = new System.Drawing.Size(1261, 442);
            this.dataGridViewQualityOfDeliverables.TabIndex = 19;
            // 
            // Requirement
            // 
            this.Requirement.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Requirement.HeaderText = "Requirement";
            this.Requirement.MinimumWidth = 6;
            this.Requirement.Name = "Requirement";
            // 
            // Deliverable
            // 
            this.Deliverable.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Deliverable.HeaderText = "Deliverable";
            this.Deliverable.MinimumWidth = 6;
            this.Deliverable.Name = "Deliverable";
            // 
            // QualityCriteria
            // 
            this.QualityCriteria.HeaderText = "Quality Criteria";
            this.QualityCriteria.MinimumWidth = 6;
            this.QualityCriteria.Name = "QualityCriteria";
            this.QualityCriteria.Width = 125;
            // 
            // QualityStandards
            // 
            this.QualityStandards.HeaderText = "Quality Standards";
            this.QualityStandards.MinimumWidth = 6;
            this.QualityStandards.Name = "QualityStandards";
            this.QualityStandards.Width = 125;
            // 
            // StandardMet
            // 
            this.StandardMet.HeaderText = "Standard Met ?";
            this.StandardMet.MinimumWidth = 6;
            this.StandardMet.Name = "StandardMet";
            this.StandardMet.Width = 125;
            // 
            // QualityDeviation
            // 
            this.QualityDeviation.HeaderText = "Quality Deviation";
            this.QualityDeviation.MinimumWidth = 6;
            this.QualityDeviation.Name = "QualityDeviation";
            this.QualityDeviation.Width = 125;
            // 
            // CorrectiveActionsRequired
            // 
            this.CorrectiveActionsRequired.HeaderText = "Corrective Actions Required";
            this.CorrectiveActionsRequired.MinimumWidth = 6;
            this.CorrectiveActionsRequired.Name = "CorrectiveActionsRequired";
            this.CorrectiveActionsRequired.Width = 125;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(173)))), ((int)(((byte)(252)))));
            this.panel5.Controls.Add(this.label5);
            this.panel5.Location = new System.Drawing.Point(905, 91);
            this.panel5.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(371, 38);
            this.panel5.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Helvetica", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(124, 12);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "Quality Achieved";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(173)))), ((int)(((byte)(252)))));
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(651, 91);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(246, 38);
            this.panel3.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Helvetica", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(78, 12);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Quality Target";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(173)))), ((int)(((byte)(252)))));
            this.panel4.Controls.Add(this.label4);
            this.panel4.Location = new System.Drawing.Point(15, 91);
            this.panel4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(628, 38);
            this.panel4.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Helvetica", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(247, 11);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Project Deliverable";
            // 
            // txtQualityOfDeliverables
            // 
            this.txtQualityOfDeliverables.BackColor = System.Drawing.SystemColors.Control;
            this.txtQualityOfDeliverables.Location = new System.Drawing.Point(15, 18);
            this.txtQualityOfDeliverables.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtQualityOfDeliverables.Multiline = true;
            this.txtQualityOfDeliverables.Name = "txtQualityOfDeliverables";
            this.txtQualityOfDeliverables.Size = new System.Drawing.Size(1261, 56);
            this.txtQualityOfDeliverables.TabIndex = 15;
            this.txtQualityOfDeliverables.Text = "This form is used to review the current quality of project deliverables against t" +
    "he targets specified in the Quality Plan. An example is provided for reference:";
            // 
            // QualityReviewPlanDocumentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(1332, 687);
            this.Controls.Add(this.btnQualityReviewForm_MainMenue);
            this.Controls.Add(this.btnQualityReviewForm_EnterProjectName);
            this.Controls.Add(this.tbcQualityReviewForm);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.txtQualityReviewFormProjectName);
            this.Font = new System.Drawing.Font("Helvetica", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "QualityReviewPlanDocumentForm";
            this.Text = "Quality Review Form";
            this.tbpQualityOfProcess.ResumeLayout(false);
            this.tbpQualityOfProcess.PerformLayout();
            this.tbcQualityReviewForm.ResumeLayout(false);
            this.tbpQualityOfDeliverables.ResumeLayout(false);
            this.tbpQualityOfDeliverables.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewQualityOfProcess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewQualityOfDeliverables)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tbcQualityReviewForm;
        private System.Windows.Forms.TextBox txtQualityOfProcess;
        private System.Windows.Forms.TabPage tbpQualityOfDeliverables;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox txtQualityReviewFormProjectName;
        private System.Windows.Forms.TabPage tbpQualityOfProcess;
        private System.Windows.Forms.Button btnQualityReviewForm_MainMenue;
        private System.Windows.Forms.Button btnQualityReviewForm_EnterProjectName;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewQualityOfProcess;
        private System.Windows.Forms.DataGridViewTextBoxColumn Process;
        private System.Windows.Forms.DataGridViewTextBoxColumn Procedure;
        private System.Windows.Forms.DataGridViewTextBoxColumn StandardMet1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Deviation;
        private System.Windows.Forms.DataGridViewTextBoxColumn CorrectiveAction;
        private System.Windows.Forms.DataGridView dataGridViewQualityOfDeliverables;
        private System.Windows.Forms.DataGridViewTextBoxColumn Requirement;
        private System.Windows.Forms.DataGridViewTextBoxColumn Deliverable;
        private System.Windows.Forms.DataGridViewTextBoxColumn QualityCriteria;
        private System.Windows.Forms.DataGridViewTextBoxColumn QualityStandards;
        private System.Windows.Forms.DataGridViewTextBoxColumn StandardMet;
        private System.Windows.Forms.DataGridViewTextBoxColumn QualityDeviation;
        private System.Windows.Forms.DataGridViewTextBoxColumn CorrectiveActionsRequired;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtQualityOfDeliverables;
    }
}