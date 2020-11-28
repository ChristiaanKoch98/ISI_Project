namespace ProjectManagementToolkit.MPMM.MPMM_Document_Forms
{
    partial class PhaseReviewFormInitiationDocumentForm
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dgvReviewDetails = new System.Windows.Forms.DataGridView();
            this.variance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.answer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reviewQuestions = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reviewCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label10 = new System.Windows.Forms.Label();
            this.supportingDetails = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.signatureDate = new System.Windows.Forms.DateTimePicker();
            this.signature = new System.Windows.Forms.PictureBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.projectName = new System.Windows.Forms.TextBox();
            this.projectManager = new System.Windows.Forms.TextBox();
            this.projectSponsor = new System.Windows.Forms.TextBox();
            this.reportPreparationDate = new System.Windows.Forms.TextBox();
            this.reportPreparedBy = new System.Windows.Forms.TextBox();
            this.reportingPeriod = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.summary = new System.Windows.Forms.TextBox();
            this.projectExpenses = new System.Windows.Forms.TextBox();
            this.projectRisks = new System.Windows.Forms.TextBox();
            this.projectDeliverables = new System.Windows.Forms.TextBox();
            this.projectSchedule = new System.Windows.Forms.TextBox();
            this.projectIssues = new System.Windows.Forms.TextBox();
            this.projectChanges = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReviewDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.signature)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(612, 20);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(122, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(784, 20);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(145, 23);
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "Export to Word";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.tabPage3.Controls.Add(this.label13);
            this.tabPage3.Controls.Add(this.signature);
            this.tabPage3.Controls.Add(this.signatureDate);
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Controls.Add(this.supportingDetails);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.dgvReviewDetails);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage3.Size = new System.Drawing.Size(1221, 487);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Review Details &  Approval Details";
            // 
            // dgvReviewDetails
            // 
            this.dgvReviewDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvReviewDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReviewDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.reviewCategory,
            this.reviewQuestions,
            this.answer,
            this.variance});
            this.dgvReviewDetails.Location = new System.Drawing.Point(167, 26);
            this.dgvReviewDetails.Margin = new System.Windows.Forms.Padding(4);
            this.dgvReviewDetails.Name = "dgvReviewDetails";
            this.dgvReviewDetails.RowHeadersWidth = 51;
            this.dgvReviewDetails.Size = new System.Drawing.Size(1029, 133);
            this.dgvReviewDetails.TabIndex = 10;
            // 
            // variance
            // 
            this.variance.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.variance.HeaderText = "Variance";
            this.variance.MinimumWidth = 6;
            this.variance.Name = "variance";
            // 
            // answer
            // 
            this.answer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.answer.HeaderText = "Answer";
            this.answer.MinimumWidth = 6;
            this.answer.Name = "answer";
            // 
            // reviewQuestions
            // 
            this.reviewQuestions.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.reviewQuestions.HeaderText = "Review Questions";
            this.reviewQuestions.MinimumWidth = 6;
            this.reviewQuestions.Name = "reviewQuestions";
            // 
            // reviewCategory
            // 
            this.reviewCategory.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.reviewCategory.HeaderText = "Review Category";
            this.reviewCategory.MinimumWidth = 6;
            this.reviewCategory.Name = "reviewCategory";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Cambria", 11F);
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(11, 70);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(129, 22);
            this.label10.TabIndex = 11;
            this.label10.Text = "Review Details";
            // 
            // supportingDetails
            // 
            this.supportingDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.supportingDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.supportingDetails.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.supportingDetails.ForeColor = System.Drawing.Color.White;
            this.supportingDetails.Location = new System.Drawing.Point(15, 178);
            this.supportingDetails.Margin = new System.Windows.Forms.Padding(4);
            this.supportingDetails.Multiline = true;
            this.supportingDetails.Name = "supportingDetails";
            this.supportingDetails.Size = new System.Drawing.Size(695, 297);
            this.supportingDetails.TabIndex = 17;
            this.supportingDetails.Text = "Supporting Documentation";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Cambria", 11F);
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(741, 210);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(87, 22);
            this.label11.TabIndex = 18;
            this.label11.Text = "Signature";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Cambria", 11F);
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(741, 300);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(47, 22);
            this.label12.TabIndex = 19;
            this.label12.Text = "Date";
            // 
            // signatureDate
            // 
            this.signatureDate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.signatureDate.Location = new System.Drawing.Point(917, 300);
            this.signatureDate.Margin = new System.Windows.Forms.Padding(4);
            this.signatureDate.Name = "signatureDate";
            this.signatureDate.Size = new System.Drawing.Size(265, 22);
            this.signatureDate.TabIndex = 20;
            // 
            // signature
            // 
            this.signature.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.signature.Location = new System.Drawing.Point(917, 202);
            this.signature.Margin = new System.Windows.Forms.Padding(4);
            this.signature.Name = "signature";
            this.signature.Size = new System.Drawing.Size(217, 30);
            this.signature.TabIndex = 21;
            this.signature.TabStop = false;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Cambria", 11F);
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(741, 434);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(322, 44);
            this.label13.TabIndex = 22;
            this.label13.Text = "THIS PROJECT IS APPROVED TO \r\nPROCEEED TO THE PLANNING PHASE";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(1221, 487);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Project Details & Overall Status";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.reportingPeriod);
            this.panel1.Controls.Add(this.reportPreparedBy);
            this.panel1.Controls.Add(this.reportPreparationDate);
            this.panel1.Controls.Add(this.projectSponsor);
            this.panel1.Controls.Add(this.projectManager);
            this.panel1.Controls.Add(this.projectName);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(16, 30);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1179, 145);
            this.panel1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cambria", 11F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(4, 14);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 22);
            this.label4.TabIndex = 11;
            this.label4.Text = "Project Name:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cambria", 11F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(576, 50);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(213, 22);
            this.label5.TabIndex = 12;
            this.label5.Text = "Report Preparation Date:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Cambria", 11F);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(576, 14);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(177, 22);
            this.label6.TabIndex = 13;
            this.label6.Text = "Report Prepared By:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Cambria", 11F);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(4, 50);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 22);
            this.label7.TabIndex = 14;
            this.label7.Text = "Manager:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Cambria", 11F);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(576, 85);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(124, 22);
            this.label8.TabIndex = 15;
            this.label8.Text = "Report Period";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Cambria", 11F);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(4, 85);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(143, 22);
            this.label9.TabIndex = 16;
            this.label9.Text = "Project Sponsor:";
            // 
            // projectName
            // 
            this.projectName.Location = new System.Drawing.Point(195, 10);
            this.projectName.Margin = new System.Windows.Forms.Padding(4);
            this.projectName.Name = "projectName";
            this.projectName.Size = new System.Drawing.Size(309, 22);
            this.projectName.TabIndex = 17;
            // 
            // projectManager
            // 
            this.projectManager.Location = new System.Drawing.Point(195, 47);
            this.projectManager.Margin = new System.Windows.Forms.Padding(4);
            this.projectManager.Name = "projectManager";
            this.projectManager.Size = new System.Drawing.Size(309, 22);
            this.projectManager.TabIndex = 18;
            // 
            // projectSponsor
            // 
            this.projectSponsor.Location = new System.Drawing.Point(195, 85);
            this.projectSponsor.Margin = new System.Windows.Forms.Padding(4);
            this.projectSponsor.Name = "projectSponsor";
            this.projectSponsor.Size = new System.Drawing.Size(309, 22);
            this.projectSponsor.TabIndex = 19;
            // 
            // reportPreparationDate
            // 
            this.reportPreparationDate.Location = new System.Drawing.Point(835, 46);
            this.reportPreparationDate.Margin = new System.Windows.Forms.Padding(4);
            this.reportPreparationDate.Name = "reportPreparationDate";
            this.reportPreparationDate.Size = new System.Drawing.Size(309, 22);
            this.reportPreparationDate.TabIndex = 20;
            // 
            // reportPreparedBy
            // 
            this.reportPreparedBy.Location = new System.Drawing.Point(835, 10);
            this.reportPreparedBy.Margin = new System.Windows.Forms.Padding(4);
            this.reportPreparedBy.Name = "reportPreparedBy";
            this.reportPreparedBy.Size = new System.Drawing.Size(309, 22);
            this.reportPreparedBy.TabIndex = 21;
            // 
            // reportingPeriod
            // 
            this.reportingPeriod.Location = new System.Drawing.Point(835, 81);
            this.reportingPeriod.Margin = new System.Windows.Forms.Padding(4);
            this.reportingPeriod.Name = "reportingPeriod";
            this.reportingPeriod.Size = new System.Drawing.Size(309, 22);
            this.reportingPeriod.TabIndex = 22;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.projectChanges);
            this.panel2.Controls.Add(this.projectIssues);
            this.panel2.Controls.Add(this.projectSchedule);
            this.panel2.Controls.Add(this.projectDeliverables);
            this.panel2.Controls.Add(this.projectRisks);
            this.panel2.Controls.Add(this.projectExpenses);
            this.panel2.Controls.Add(this.summary);
            this.panel2.Location = new System.Drawing.Point(16, 198);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1179, 278);
            this.panel2.TabIndex = 1;
            // 
            // summary
            // 
            this.summary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.summary.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.summary.ForeColor = System.Drawing.Color.White;
            this.summary.Location = new System.Drawing.Point(8, 20);
            this.summary.Margin = new System.Windows.Forms.Padding(4);
            this.summary.Multiline = true;
            this.summary.Name = "summary";
            this.summary.Size = new System.Drawing.Size(264, 110);
            this.summary.TabIndex = 16;
            this.summary.Text = "Summary";
            // 
            // projectExpenses
            // 
            this.projectExpenses.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.projectExpenses.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.projectExpenses.ForeColor = System.Drawing.Color.White;
            this.projectExpenses.Location = new System.Drawing.Point(304, 20);
            this.projectExpenses.Margin = new System.Windows.Forms.Padding(4);
            this.projectExpenses.Multiline = true;
            this.projectExpenses.Name = "projectExpenses";
            this.projectExpenses.Size = new System.Drawing.Size(264, 110);
            this.projectExpenses.TabIndex = 17;
            this.projectExpenses.Text = "Project Expenses";
            // 
            // projectRisks
            // 
            this.projectRisks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.projectRisks.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.projectRisks.ForeColor = System.Drawing.Color.White;
            this.projectRisks.Location = new System.Drawing.Point(603, 20);
            this.projectRisks.Margin = new System.Windows.Forms.Padding(4);
            this.projectRisks.Multiline = true;
            this.projectRisks.Name = "projectRisks";
            this.projectRisks.Size = new System.Drawing.Size(264, 110);
            this.projectRisks.TabIndex = 18;
            this.projectRisks.Text = "Project Risks";
            // 
            // projectDeliverables
            // 
            this.projectDeliverables.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.projectDeliverables.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.projectDeliverables.ForeColor = System.Drawing.Color.White;
            this.projectDeliverables.Location = new System.Drawing.Point(304, 138);
            this.projectDeliverables.Margin = new System.Windows.Forms.Padding(4);
            this.projectDeliverables.Multiline = true;
            this.projectDeliverables.Name = "projectDeliverables";
            this.projectDeliverables.Size = new System.Drawing.Size(264, 126);
            this.projectDeliverables.TabIndex = 19;
            this.projectDeliverables.Text = "Project Deliverables";
            // 
            // projectSchedule
            // 
            this.projectSchedule.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.projectSchedule.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.projectSchedule.ForeColor = System.Drawing.Color.White;
            this.projectSchedule.Location = new System.Drawing.Point(8, 138);
            this.projectSchedule.Margin = new System.Windows.Forms.Padding(4);
            this.projectSchedule.Multiline = true;
            this.projectSchedule.Name = "projectSchedule";
            this.projectSchedule.Size = new System.Drawing.Size(264, 126);
            this.projectSchedule.TabIndex = 20;
            this.projectSchedule.Text = "Project Schedule";
            // 
            // projectIssues
            // 
            this.projectIssues.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.projectIssues.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.projectIssues.ForeColor = System.Drawing.Color.White;
            this.projectIssues.Location = new System.Drawing.Point(603, 138);
            this.projectIssues.Margin = new System.Windows.Forms.Padding(4);
            this.projectIssues.Multiline = true;
            this.projectIssues.Name = "projectIssues";
            this.projectIssues.Size = new System.Drawing.Size(264, 126);
            this.projectIssues.TabIndex = 21;
            this.projectIssues.Text = "Project Issues ";
            // 
            // projectChanges
            // 
            this.projectChanges.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.projectChanges.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.projectChanges.ForeColor = System.Drawing.Color.White;
            this.projectChanges.Location = new System.Drawing.Point(897, 20);
            this.projectChanges.Margin = new System.Windows.Forms.Padding(4);
            this.projectChanges.Multiline = true;
            this.projectChanges.Name = "projectChanges";
            this.projectChanges.Size = new System.Drawing.Size(264, 110);
            this.projectChanges.TabIndex = 22;
            this.projectChanges.Text = "Project Changes";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(16, 50);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1229, 516);
            this.tabControl1.TabIndex = 0;
            // 
            // PhaseReviewFormInitiationDocumentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(1261, 582);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "PhaseReviewFormInitiationDocumentForm";
            this.Text = "PhaseReviewFormInitiationDocumentForm";
            this.Load += new System.EventHandler(this.PhaseReviewFormInitiationDocumentForm_Load);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReviewDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.signature)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.PictureBox signature;
        private System.Windows.Forms.DateTimePicker signatureDate;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox supportingDetails;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dgvReviewDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn reviewCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn reviewQuestions;
        private System.Windows.Forms.DataGridViewTextBoxColumn answer;
        private System.Windows.Forms.DataGridViewTextBoxColumn variance;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox projectChanges;
        private System.Windows.Forms.TextBox projectIssues;
        private System.Windows.Forms.TextBox projectSchedule;
        private System.Windows.Forms.TextBox projectDeliverables;
        private System.Windows.Forms.TextBox projectRisks;
        private System.Windows.Forms.TextBox projectExpenses;
        private System.Windows.Forms.TextBox summary;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox reportingPeriod;
        private System.Windows.Forms.TextBox reportPreparedBy;
        private System.Windows.Forms.TextBox reportPreparationDate;
        private System.Windows.Forms.TextBox projectSponsor;
        private System.Windows.Forms.TextBox projectManager;
        private System.Windows.Forms.TextBox projectName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabControl tabControl1;
    }
}