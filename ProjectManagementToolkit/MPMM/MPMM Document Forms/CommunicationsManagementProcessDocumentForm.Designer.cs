namespace ProjectManagementToolkit.MPMM.MPMM_Document_Forms
{
    partial class CommunicationsManagementProcessDocumentForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.documentControl = new System.Windows.Forms.TabPage();
            this.CommunicationsProcessIntro = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.documentApprovals = new System.Windows.Forms.DataGridView();
            this.approvalRole = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.approvalName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.approvalSignature = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.approvalDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.documentHistory = new System.Windows.Forms.DataGridView();
            this.Version = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.historyIssueDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.historyChanges = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.documentInformation = new System.Windows.Forms.DataGridView();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Information = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.communicate = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.documentControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentApprovals)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentInformation)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.documentControl);
            this.tabControl1.Controls.Add(this.CommunicationsProcessIntro);
            this.tabControl1.Controls.Add(this.communicate);
            this.tabControl1.Location = new System.Drawing.Point(12, 41);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(922, 415);
            this.tabControl1.TabIndex = 0;
            // 
            // documentControl
            // 
            this.documentControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.documentControl.Controls.Add(this.label3);
            this.documentControl.Controls.Add(this.label2);
            this.documentControl.Controls.Add(this.label1);
            this.documentControl.Controls.Add(this.documentApprovals);
            this.documentControl.Controls.Add(this.documentHistory);
            this.documentControl.Controls.Add(this.documentInformation);
            this.documentControl.Location = new System.Drawing.Point(4, 22);
            this.documentControl.Name = "documentControl";
            this.documentControl.Padding = new System.Windows.Forms.Padding(3);
            this.documentControl.Size = new System.Drawing.Size(914, 389);
            this.documentControl.TabIndex = 0;
            this.documentControl.Text = "Document Control";
            // 
            // CommunicationsProcessIntro
            // 
            this.CommunicationsProcessIntro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.CommunicationsProcessIntro.Location = new System.Drawing.Point(4, 22);
            this.CommunicationsProcessIntro.Name = "CommunicationsProcessIntro";
            this.CommunicationsProcessIntro.Padding = new System.Windows.Forms.Padding(3);
            this.CommunicationsProcessIntro.Size = new System.Drawing.Size(914, 386);
            this.CommunicationsProcessIntro.TabIndex = 1;
            this.CommunicationsProcessIntro.Text = "Communications Process";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cambria", 11F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(6, 304);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Document Approvals";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cambria", 11F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(6, 177);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Document History";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 11F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(6, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Document Information";
            // 
            // documentApprovals
            // 
            this.documentApprovals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.documentApprovals.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.approvalRole,
            this.approvalName,
            this.approvalSignature,
            this.approvalDate});
            this.documentApprovals.Location = new System.Drawing.Point(167, 244);
            this.documentApprovals.Name = "documentApprovals";
            this.documentApprovals.RowHeadersWidth = 51;
            this.documentApprovals.Size = new System.Drawing.Size(691, 124);
            this.documentApprovals.TabIndex = 8;
            // 
            // approvalRole
            // 
            this.approvalRole.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.approvalRole.HeaderText = "Role";
            this.approvalRole.MinimumWidth = 6;
            this.approvalRole.Name = "approvalRole";
            // 
            // approvalName
            // 
            this.approvalName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.approvalName.HeaderText = "Name";
            this.approvalName.MinimumWidth = 6;
            this.approvalName.Name = "approvalName";
            // 
            // approvalSignature
            // 
            this.approvalSignature.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.approvalSignature.DataPropertyName = "(none)";
            this.approvalSignature.HeaderText = "Signature";
            this.approvalSignature.MinimumWidth = 6;
            this.approvalSignature.Name = "approvalSignature";
            this.approvalSignature.ReadOnly = true;
            // 
            // approvalDate
            // 
            this.approvalDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.approvalDate.HeaderText = "Date";
            this.approvalDate.MinimumWidth = 6;
            this.approvalDate.Name = "approvalDate";
            // 
            // documentHistory
            // 
            this.documentHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.documentHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Version,
            this.historyIssueDate,
            this.historyChanges});
            this.documentHistory.Location = new System.Drawing.Point(167, 120);
            this.documentHistory.Name = "documentHistory";
            this.documentHistory.RowHeadersWidth = 51;
            this.documentHistory.Size = new System.Drawing.Size(691, 118);
            this.documentHistory.TabIndex = 7;
            // 
            // Version
            // 
            this.Version.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Version.HeaderText = "Version";
            this.Version.MinimumWidth = 6;
            this.Version.Name = "Version";
            // 
            // historyIssueDate
            // 
            this.historyIssueDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.historyIssueDate.HeaderText = "Issue Date";
            this.historyIssueDate.MinimumWidth = 6;
            this.historyIssueDate.Name = "historyIssueDate";
            // 
            // historyChanges
            // 
            this.historyChanges.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.historyChanges.HeaderText = "Changes";
            this.historyChanges.MinimumWidth = 6;
            this.historyChanges.Name = "historyChanges";
            // 
            // documentInformation
            // 
            this.documentInformation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.documentInformation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Type,
            this.Information});
            this.documentInformation.Location = new System.Drawing.Point(167, 6);
            this.documentInformation.Name = "documentInformation";
            this.documentInformation.RowHeadersWidth = 51;
            this.documentInformation.Size = new System.Drawing.Size(691, 108);
            this.documentInformation.TabIndex = 6;
            // 
            // Type
            // 
            this.Type.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Type.HeaderText = "Type";
            this.Type.MinimumWidth = 6;
            this.Type.Name = "Type";
            // 
            // Information
            // 
            this.Information.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Information.HeaderText = "Information";
            this.Information.MinimumWidth = 6;
            this.Information.Name = "Information";
            // 
            // communicate
            // 
            this.communicate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.communicate.Location = new System.Drawing.Point(4, 22);
            this.communicate.Name = "communicate";
            this.communicate.Padding = new System.Windows.Forms.Padding(3);
            this.communicate.Size = new System.Drawing.Size(914, 386);
            this.communicate.TabIndex = 2;
            this.communicate.Text = "Communications Roles";
            // 
            // CommunicationsManagementProcessDocumentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(946, 469);
            this.Controls.Add(this.tabControl1);
            this.Name = "CommunicationsManagementProcessDocumentForm";
            this.Text = "CommunicationsManagementProcessDocumentForm";
            this.tabControl1.ResumeLayout(false);
            this.documentControl.ResumeLayout(false);
            this.documentControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentApprovals)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentInformation)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage documentControl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView documentApprovals;
        private System.Windows.Forms.DataGridViewTextBoxColumn approvalRole;
        private System.Windows.Forms.DataGridViewTextBoxColumn approvalName;
        private System.Windows.Forms.DataGridViewTextBoxColumn approvalSignature;
        private System.Windows.Forms.DataGridViewTextBoxColumn approvalDate;
        private System.Windows.Forms.DataGridView documentHistory;
        private System.Windows.Forms.DataGridViewTextBoxColumn Version;
        private System.Windows.Forms.DataGridViewTextBoxColumn historyIssueDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn historyChanges;
        private System.Windows.Forms.DataGridView documentInformation;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Information;
        private System.Windows.Forms.TabPage CommunicationsProcessIntro;
        private System.Windows.Forms.TabPage communicate;
    }
}