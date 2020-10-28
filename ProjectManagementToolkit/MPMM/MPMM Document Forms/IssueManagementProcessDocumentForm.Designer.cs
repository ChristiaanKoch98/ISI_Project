namespace ProjectManagementToolkit.MPMM.MPMM_Document_Forms
{
    partial class IssueManagementProcessDocumentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IssueManagementProcessDocumentForm));
            this.issueMngmntLabel = new System.Windows.Forms.Label();
            this.projectNameLabel = new System.Windows.Forms.TextBox();
            this.i = new System.Windows.Forms.TabControl();
            this.dcmntControlTab = new System.Windows.Forms.TabPage();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.roleColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.signatureColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.versionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.issueDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.changesColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.documentNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.informationLabel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docApprovalsLabel = new System.Windows.Forms.Label();
            this.docHistLabel = new System.Windows.Forms.Label();
            this.docInfoLabel = new System.Windows.Forms.Label();
            this.issueProcessTab = new System.Windows.Forms.TabPage();
            this.overviewLabel = new System.Windows.Forms.Label();
            this.overviewTextBox = new System.Windows.Forms.TextBox();
            this.IssueRolesTab = new System.Windows.Forms.TabPage();
            this.issueDocumentsTab = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.raiseTextBox = new System.Windows.Forms.TextBox();
            this.reviewTextBox = new System.Windows.Forms.TextBox();
            this.assgnActTextBox = new System.Windows.Forms.TextBox();
            this.raiseIssueLabel = new System.Windows.Forms.Label();
            this.reviewIssueLabel = new System.Windows.Forms.Label();
            this.assignActionsLabel = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.teamMamberLabel = new System.Windows.Forms.Label();
            this.projMnagerLabel = new System.Windows.Forms.Label();
            this.prjctBoardLabel = new System.Windows.Forms.Label();
            this.issueFormTextBox = new System.Windows.Forms.TextBox();
            this.issueRegisterTextBox = new System.Windows.Forms.TextBox();
            this.issueFormLabel = new System.Windows.Forms.Label();
            this.issueRegisterLabel = new System.Windows.Forms.Label();
            this.i.SuspendLayout();
            this.dcmntControlTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.issueProcessTab.SuspendLayout();
            this.IssueRolesTab.SuspendLayout();
            this.issueDocumentsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // issueMngmntLabel
            // 
            this.issueMngmntLabel.AutoSize = true;
            this.issueMngmntLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.issueMngmntLabel.Location = new System.Drawing.Point(2, 9);
            this.issueMngmntLabel.Name = "issueMngmntLabel";
            this.issueMngmntLabel.Size = new System.Drawing.Size(235, 20);
            this.issueMngmntLabel.TabIndex = 0;
            this.issueMngmntLabel.Text = "Issue Management Process For";
            // 
            // projectNameLabel
            // 
            this.projectNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.projectNameLabel.Location = new System.Drawing.Point(244, 8);
            this.projectNameLabel.Name = "projectNameLabel";
            this.projectNameLabel.Size = new System.Drawing.Size(198, 26);
            this.projectNameLabel.TabIndex = 1;
            this.projectNameLabel.Text = "Project Name";
            // 
            // i
            // 
            this.i.Controls.Add(this.dcmntControlTab);
            this.i.Controls.Add(this.issueProcessTab);
            this.i.Controls.Add(this.IssueRolesTab);
            this.i.Controls.Add(this.issueDocumentsTab);
            this.i.Location = new System.Drawing.Point(6, 33);
            this.i.Name = "i";
            this.i.SelectedIndex = 0;
            this.i.Size = new System.Drawing.Size(793, 501);
            this.i.TabIndex = 2;
            // 
            // dcmntControlTab
            // 
            this.dcmntControlTab.Controls.Add(this.dataGridView3);
            this.dcmntControlTab.Controls.Add(this.dataGridView2);
            this.dcmntControlTab.Controls.Add(this.dataGridView1);
            this.dcmntControlTab.Controls.Add(this.docApprovalsLabel);
            this.dcmntControlTab.Controls.Add(this.docHistLabel);
            this.dcmntControlTab.Controls.Add(this.docInfoLabel);
            this.dcmntControlTab.Location = new System.Drawing.Point(4, 22);
            this.dcmntControlTab.Name = "dcmntControlTab";
            this.dcmntControlTab.Padding = new System.Windows.Forms.Padding(3);
            this.dcmntControlTab.Size = new System.Drawing.Size(785, 475);
            this.dcmntControlTab.TabIndex = 0;
            this.dcmntControlTab.Text = "Document Control";
            this.dcmntControlTab.UseVisualStyleBackColor = true;
            // 
            // dataGridView3
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.roleColumn,
            this.nameColumn,
            this.signatureColumn,
            this.dateColumn});
            this.dataGridView3.Location = new System.Drawing.Point(145, 297);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.Size = new System.Drawing.Size(443, 208);
            this.dataGridView3.TabIndex = 5;
            // 
            // roleColumn
            // 
            this.roleColumn.HeaderText = "Role";
            this.roleColumn.Name = "roleColumn";
            // 
            // nameColumn
            // 
            this.nameColumn.HeaderText = "Name";
            this.nameColumn.Name = "nameColumn";
            // 
            // signatureColumn
            // 
            this.signatureColumn.HeaderText = "Signature";
            this.signatureColumn.Name = "signatureColumn";
            // 
            // dateColumn
            // 
            this.dateColumn.HeaderText = "Date";
            this.dateColumn.Name = "dateColumn";
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.versionColumn,
            this.issueDateColumn,
            this.changesColumn});
            this.dataGridView2.Location = new System.Drawing.Point(145, 163);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(443, 103);
            this.dataGridView2.TabIndex = 4;
            // 
            // versionColumn
            // 
            this.versionColumn.HeaderText = "Version";
            this.versionColumn.Name = "versionColumn";
            this.versionColumn.Width = 135;
            // 
            // issueDateColumn
            // 
            this.issueDateColumn.HeaderText = "Issue Date";
            this.issueDateColumn.Name = "issueDateColumn";
            this.issueDateColumn.Width = 135;
            // 
            // changesColumn
            // 
            this.changesColumn.HeaderText = "Changes";
            this.changesColumn.Name = "changesColumn";
            this.changesColumn.Width = 130;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.documentNameColumn,
            this.informationLabel});
            this.dataGridView1.Location = new System.Drawing.Point(145, 17);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(443, 112);
            this.dataGridView1.TabIndex = 3;
            // 
            // documentNameColumn
            // 
            this.documentNameColumn.HeaderText = "";
            this.documentNameColumn.Name = "documentNameColumn";
            this.documentNameColumn.Width = 200;
            // 
            // informationLabel
            // 
            this.informationLabel.HeaderText = "Information";
            this.informationLabel.Name = "informationLabel";
            this.informationLabel.Width = 200;
            // 
            // docApprovalsLabel
            // 
            this.docApprovalsLabel.AutoSize = true;
            this.docApprovalsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.docApprovalsLabel.ForeColor = System.Drawing.Color.Navy;
            this.docApprovalsLabel.Location = new System.Drawing.Point(2, 388);
            this.docApprovalsLabel.Name = "docApprovalsLabel";
            this.docApprovalsLabel.Size = new System.Drawing.Size(134, 16);
            this.docApprovalsLabel.TabIndex = 2;
            this.docApprovalsLabel.Text = "Document Approvals";
            // 
            // docHistLabel
            // 
            this.docHistLabel.AutoSize = true;
            this.docHistLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.docHistLabel.ForeColor = System.Drawing.Color.Navy;
            this.docHistLabel.Location = new System.Drawing.Point(3, 206);
            this.docHistLabel.Name = "docHistLabel";
            this.docHistLabel.Size = new System.Drawing.Size(114, 16);
            this.docHistLabel.TabIndex = 1;
            this.docHistLabel.Text = "Document History";
            // 
            // docInfoLabel
            // 
            this.docInfoLabel.AutoSize = true;
            this.docInfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.docInfoLabel.ForeColor = System.Drawing.Color.Navy;
            this.docInfoLabel.Location = new System.Drawing.Point(2, 49);
            this.docInfoLabel.Name = "docInfoLabel";
            this.docInfoLabel.Size = new System.Drawing.Size(137, 16);
            this.docInfoLabel.TabIndex = 0;
            this.docInfoLabel.Text = "Document Information";
            // 
            // issueProcessTab
            // 
            this.issueProcessTab.Controls.Add(this.assignActionsLabel);
            this.issueProcessTab.Controls.Add(this.reviewIssueLabel);
            this.issueProcessTab.Controls.Add(this.raiseIssueLabel);
            this.issueProcessTab.Controls.Add(this.assgnActTextBox);
            this.issueProcessTab.Controls.Add(this.reviewTextBox);
            this.issueProcessTab.Controls.Add(this.raiseTextBox);
            this.issueProcessTab.Controls.Add(this.pictureBox1);
            this.issueProcessTab.Controls.Add(this.overviewLabel);
            this.issueProcessTab.Controls.Add(this.overviewTextBox);
            this.issueProcessTab.Location = new System.Drawing.Point(4, 22);
            this.issueProcessTab.Name = "issueProcessTab";
            this.issueProcessTab.Padding = new System.Windows.Forms.Padding(3);
            this.issueProcessTab.Size = new System.Drawing.Size(785, 475);
            this.issueProcessTab.TabIndex = 1;
            this.issueProcessTab.Text = "Issue Process";
            this.issueProcessTab.UseVisualStyleBackColor = true;
            // 
            // overviewLabel
            // 
            this.overviewLabel.AutoSize = true;
            this.overviewLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.overviewLabel.Location = new System.Drawing.Point(6, 12);
            this.overviewLabel.Name = "overviewLabel";
            this.overviewLabel.Size = new System.Drawing.Size(72, 16);
            this.overviewLabel.TabIndex = 1;
            this.overviewLabel.Text = "Overview";
            // 
            // overviewTextBox
            // 
            this.overviewTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.overviewTextBox.ForeColor = System.Drawing.Color.Blue;
            this.overviewTextBox.Location = new System.Drawing.Point(7, 31);
            this.overviewTextBox.Multiline = true;
            this.overviewTextBox.Name = "overviewTextBox";
            this.overviewTextBox.Size = new System.Drawing.Size(294, 586);
            this.overviewTextBox.TabIndex = 0;
            this.overviewTextBox.Text = "Provide an overview of the IssueManagement Process, depicted as follows:";
            
            // 
            // IssueRolesTab
            // 
            this.IssueRolesTab.Controls.Add(this.prjctBoardLabel);
            this.IssueRolesTab.Controls.Add(this.projMnagerLabel);
            this.IssueRolesTab.Controls.Add(this.teamMamberLabel);
            this.IssueRolesTab.Controls.Add(this.textBox3);
            this.IssueRolesTab.Controls.Add(this.textBox2);
            this.IssueRolesTab.Controls.Add(this.textBox1);
            this.IssueRolesTab.Location = new System.Drawing.Point(4, 22);
            this.IssueRolesTab.Name = "IssueRolesTab";
            this.IssueRolesTab.Padding = new System.Windows.Forms.Padding(3);
            this.IssueRolesTab.Size = new System.Drawing.Size(785, 475);
            this.IssueRolesTab.TabIndex = 2;
            this.IssueRolesTab.Text = "Issue Roles";
            this.IssueRolesTab.UseVisualStyleBackColor = true;
            // 
            // issueDocumentsTab
            // 
            this.issueDocumentsTab.Controls.Add(this.issueRegisterLabel);
            this.issueDocumentsTab.Controls.Add(this.issueFormLabel);
            this.issueDocumentsTab.Controls.Add(this.issueRegisterTextBox);
            this.issueDocumentsTab.Controls.Add(this.issueFormTextBox);
            this.issueDocumentsTab.Location = new System.Drawing.Point(4, 22);
            this.issueDocumentsTab.Name = "issueDocumentsTab";
            this.issueDocumentsTab.Padding = new System.Windows.Forms.Padding(3);
            this.issueDocumentsTab.Size = new System.Drawing.Size(785, 475);
            this.issueDocumentsTab.TabIndex = 3;
            this.issueDocumentsTab.Text = "Issue Documents";
            this.issueDocumentsTab.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(18, 70);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(225, 225);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // raiseTextBox
            // 
            this.raiseTextBox.ForeColor = System.Drawing.Color.Blue;
            this.raiseTextBox.Location = new System.Drawing.Point(307, 31);
            this.raiseTextBox.Multiline = true;
            this.raiseTextBox.Name = "raiseTextBox";
            this.raiseTextBox.Size = new System.Drawing.Size(228, 223);
            this.raiseTextBox.TabIndex = 3;
            this.raiseTextBox.Text = "List the steps needed to identify project issues and document their details on an" +
    " Issue Form. ";
            // 
            // reviewTextBox
            // 
            this.reviewTextBox.ForeColor = System.Drawing.Color.Blue;
            this.reviewTextBox.Location = new System.Drawing.Point(542, 31);
            this.reviewTextBox.Multiline = true;
            this.reviewTextBox.Name = "reviewTextBox";
            this.reviewTextBox.Size = new System.Drawing.Size(240, 223);
            this.reviewTextBox.TabIndex = 4;
            this.reviewTextBox.Text = resources.GetString("reviewTextBox.Text");
            // 
            // assgnActTextBox
            // 
            this.assgnActTextBox.ForeColor = System.Drawing.Color.Blue;
            this.assgnActTextBox.Location = new System.Drawing.Point(307, 287);
            this.assgnActTextBox.Multiline = true;
            this.assgnActTextBox.Name = "assgnActTextBox";
            this.assgnActTextBox.Size = new System.Drawing.Size(472, 188);
            this.assgnActTextBox.TabIndex = 5;
            this.assgnActTextBox.Text = resources.GetString("assgnActTextBox.Text");
            // 
            // raiseIssueLabel
            // 
            this.raiseIssueLabel.AutoSize = true;
            this.raiseIssueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.raiseIssueLabel.Location = new System.Drawing.Point(307, 12);
            this.raiseIssueLabel.Name = "raiseIssueLabel";
            this.raiseIssueLabel.Size = new System.Drawing.Size(90, 16);
            this.raiseIssueLabel.TabIndex = 6;
            this.raiseIssueLabel.Text = "Raise Issue";
            // 
            // reviewIssueLabel
            // 
            this.reviewIssueLabel.AutoSize = true;
            this.reviewIssueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reviewIssueLabel.Location = new System.Drawing.Point(542, 12);
            this.reviewIssueLabel.Name = "reviewIssueLabel";
            this.reviewIssueLabel.Size = new System.Drawing.Size(100, 16);
            this.reviewIssueLabel.TabIndex = 7;
            this.reviewIssueLabel.Text = "Review Issue";
            // 
            // assignActionsLabel
            // 
            this.assignActionsLabel.AutoSize = true;
            this.assignActionsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.assignActionsLabel.Location = new System.Drawing.Point(310, 268);
            this.assignActionsLabel.Name = "assignActionsLabel";
            this.assignActionsLabel.Size = new System.Drawing.Size(151, 16);
            this.assignActionsLabel.TabIndex = 8;
            this.assignActionsLabel.Text = "Assign Issue Actions";
            // 
            // textBox1
            // 
            this.textBox1.ForeColor = System.Drawing.Color.Blue;
            this.textBox1.Location = new System.Drawing.Point(7, 48);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(381, 195);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "In this section, describe the key roles and responsibilities involved in the Issu" +
    "e Management Process.";
            // 
            // textBox2
            // 
            this.textBox2.ForeColor = System.Drawing.Color.Blue;
            this.textBox2.Location = new System.Drawing.Point(394, 48);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(373, 195);
            this.textBox2.TabIndex = 1;
            this.textBox2.Text = "List the responsibilities of the Project Manager in the Issue Management Process." +
    "";
            // 
            // textBox3
            // 
            this.textBox3.ForeColor = System.Drawing.Color.Blue;
            this.textBox3.Location = new System.Drawing.Point(7, 293);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(760, 172);
            this.textBox3.TabIndex = 2;
            this.textBox3.Text = "List the responsibilities of the Project Board in the Issue Management Process.";
            // 
            // teamMamberLabel
            // 
            this.teamMamberLabel.AutoSize = true;
            this.teamMamberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.teamMamberLabel.Location = new System.Drawing.Point(7, 29);
            this.teamMamberLabel.Name = "teamMamberLabel";
            this.teamMamberLabel.Size = new System.Drawing.Size(108, 16);
            this.teamMamberLabel.TabIndex = 3;
            this.teamMamberLabel.Text = "Team Member";
            // 
            // projMnagerLabel
            // 
            this.projMnagerLabel.AutoSize = true;
            this.projMnagerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.projMnagerLabel.Location = new System.Drawing.Point(395, 29);
            this.projMnagerLabel.Name = "projMnagerLabel";
            this.projMnagerLabel.Size = new System.Drawing.Size(122, 16);
            this.projMnagerLabel.TabIndex = 4;
            this.projMnagerLabel.Text = "Project Manager";
            // 
            // prjctBoardLabel
            // 
            this.prjctBoardLabel.AutoSize = true;
            this.prjctBoardLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prjctBoardLabel.Location = new System.Drawing.Point(7, 274);
            this.prjctBoardLabel.Name = "prjctBoardLabel";
            this.prjctBoardLabel.Size = new System.Drawing.Size(103, 16);
            this.prjctBoardLabel.TabIndex = 5;
            this.prjctBoardLabel.Text = "Project Board";
            // 
            // issueFormTextBox
            // 
            this.issueFormTextBox.ForeColor = System.Drawing.Color.Blue;
            this.issueFormTextBox.Location = new System.Drawing.Point(6, 42);
            this.issueFormTextBox.Multiline = true;
            this.issueFormTextBox.Name = "issueFormTextBox";
            this.issueFormTextBox.Size = new System.Drawing.Size(359, 427);
            this.issueFormTextBox.TabIndex = 0;
            this.issueFormTextBox.Text = "Describe the purpose of the Issue Form and provide a template for its completion";
            // 
            // issueRegisterTextBox
            // 
            this.issueRegisterTextBox.ForeColor = System.Drawing.Color.Blue;
            this.issueRegisterTextBox.Location = new System.Drawing.Point(395, 42);
            this.issueRegisterTextBox.Multiline = true;
            this.issueRegisterTextBox.Name = "issueRegisterTextBox";
            this.issueRegisterTextBox.Size = new System.Drawing.Size(383, 427);
            this.issueRegisterTextBox.TabIndex = 1;
            this.issueRegisterTextBox.Text = "Describe the purpose of the Issue Register and provide a template for its complet" +
    "ion.";
            // 
            // issueFormLabel
            // 
            this.issueFormLabel.AutoSize = true;
            this.issueFormLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.issueFormLabel.Location = new System.Drawing.Point(7, 23);
            this.issueFormLabel.Name = "issueFormLabel";
            this.issueFormLabel.Size = new System.Drawing.Size(84, 16);
            this.issueFormLabel.TabIndex = 2;
            this.issueFormLabel.Text = "Issue Form";
            // 
            // issueRegisterLabel
            // 
            this.issueRegisterLabel.AutoSize = true;
            this.issueRegisterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.issueRegisterLabel.Location = new System.Drawing.Point(395, 22);
            this.issueRegisterLabel.Name = "issueRegisterLabel";
            this.issueRegisterLabel.Size = new System.Drawing.Size(108, 16);
            this.issueRegisterLabel.TabIndex = 3;
            this.issueRegisterLabel.Text = "Issue Register";
            // 
            // IssueManagementProcessDocumentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 532);
            this.Controls.Add(this.i);
            this.Controls.Add(this.projectNameLabel);
            this.Controls.Add(this.issueMngmntLabel);
            this.Name = "IssueManagementProcessDocumentForm";
            this.Text = "IssueManagementProcessDocumentForm";
            this.i.ResumeLayout(false);
            this.dcmntControlTab.ResumeLayout(false);
            this.dcmntControlTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.issueProcessTab.ResumeLayout(false);
            this.issueProcessTab.PerformLayout();
            this.IssueRolesTab.ResumeLayout(false);
            this.IssueRolesTab.PerformLayout();
            this.issueDocumentsTab.ResumeLayout(false);
            this.issueDocumentsTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label issueMngmntLabel;
        private System.Windows.Forms.TextBox projectNameLabel;
        private System.Windows.Forms.TabControl i;
        private System.Windows.Forms.TabPage dcmntControlTab;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.DataGridViewTextBoxColumn roleColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn signatureColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateColumn;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn versionColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn issueDateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn changesColumn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn documentNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn informationLabel;
        private System.Windows.Forms.Label docApprovalsLabel;
        private System.Windows.Forms.Label docHistLabel;
        private System.Windows.Forms.Label docInfoLabel;
        private System.Windows.Forms.TabPage issueProcessTab;
        private System.Windows.Forms.Label overviewLabel;
        private System.Windows.Forms.TextBox overviewTextBox;
        private System.Windows.Forms.TabPage IssueRolesTab;
        private System.Windows.Forms.TabPage issueDocumentsTab;
        private System.Windows.Forms.Label assignActionsLabel;
        private System.Windows.Forms.Label reviewIssueLabel;
        private System.Windows.Forms.Label raiseIssueLabel;
        private System.Windows.Forms.TextBox assgnActTextBox;
        private System.Windows.Forms.TextBox reviewTextBox;
        private System.Windows.Forms.TextBox raiseTextBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label prjctBoardLabel;
        private System.Windows.Forms.Label projMnagerLabel;
        private System.Windows.Forms.Label teamMamberLabel;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label issueRegisterLabel;
        private System.Windows.Forms.Label issueFormLabel;
        private System.Windows.Forms.TextBox issueRegisterTextBox;
        private System.Windows.Forms.TextBox issueFormTextBox;
    }
}