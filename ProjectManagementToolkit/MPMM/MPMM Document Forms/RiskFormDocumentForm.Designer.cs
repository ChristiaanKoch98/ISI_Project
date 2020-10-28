namespace ProjectManagementToolkit.MPMM.MPMM_Document_Forms
{
    partial class RiskFormDocumentForm
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
            this.projectDeatailsAndRiskDetails = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.riskDescription = new System.Windows.Forms.TextBox();
            this.riskLikelihood = new System.Windows.Forms.TextBox();
            this.riskImpact = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.projectName = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.projectManager = new System.Windows.Forms.TextBox();
            this.riskID = new System.Windows.Forms.TextBox();
            this.raisedBy = new System.Windows.Forms.TextBox();
            this.dateRaised = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.projectDeatailsAndRiskDetails.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.projectDeatailsAndRiskDetails);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 48);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(922, 415);
            this.tabControl1.TabIndex = 0;
            // 
            // projectDeatailsAndRiskDetails
            // 
            this.projectDeatailsAndRiskDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.projectDeatailsAndRiskDetails.Controls.Add(this.riskImpact);
            this.projectDeatailsAndRiskDetails.Controls.Add(this.riskLikelihood);
            this.projectDeatailsAndRiskDetails.Controls.Add(this.riskDescription);
            this.projectDeatailsAndRiskDetails.Controls.Add(this.panel2);
            this.projectDeatailsAndRiskDetails.Controls.Add(this.panel1);
            this.projectDeatailsAndRiskDetails.Controls.Add(this.label3);
            this.projectDeatailsAndRiskDetails.Controls.Add(this.label2);
            this.projectDeatailsAndRiskDetails.Font = new System.Drawing.Font("Cambria", 10F);
            this.projectDeatailsAndRiskDetails.Location = new System.Drawing.Point(4, 22);
            this.projectDeatailsAndRiskDetails.Name = "projectDeatailsAndRiskDetails";
            this.projectDeatailsAndRiskDetails.Padding = new System.Windows.Forms.Padding(3);
            this.projectDeatailsAndRiskDetails.Size = new System.Drawing.Size(914, 389);
            this.projectDeatailsAndRiskDetails.TabIndex = 0;
            this.projectDeatailsAndRiskDetails.Text = "Project Deatails & Risk Details";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dateRaised);
            this.panel2.Controls.Add(this.raisedBy);
            this.panel2.Controls.Add(this.riskID);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(466, 59);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(407, 109);
            this.panel2.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cambria", 11F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(463, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 17);
            this.label3.TabIndex = 13;
            this.label3.Text = "Risk Deatails";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cambria", 11F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(21, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Project Details";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(914, 389);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 11F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(481, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 17);
            this.label1.TabIndex = 15;
            this.label1.Text = "Document History";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cambria", 11F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(6, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 17);
            this.label4.TabIndex = 16;
            this.label4.Text = "Document History";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cambria", 11F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(19, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 17);
            this.label5.TabIndex = 13;
            this.label5.Text = "Risk ID:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Cambria", 11F);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(19, 81);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 17);
            this.label8.TabIndex = 14;
            this.label8.Text = "Date Raised:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Cambria", 11F);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(19, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 17);
            this.label9.TabIndex = 15;
            this.label9.Text = "Raised By:";
            // 
            // riskDescription
            // 
            this.riskDescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.riskDescription.ForeColor = System.Drawing.Color.White;
            this.riskDescription.Location = new System.Drawing.Point(24, 181);
            this.riskDescription.Multiline = true;
            this.riskDescription.Name = "riskDescription";
            this.riskDescription.Size = new System.Drawing.Size(353, 179);
            this.riskDescription.TabIndex = 17;
            this.riskDescription.Text = "Risk Description";
            // 
            // riskLikelihood
            // 
            this.riskLikelihood.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.riskLikelihood.ForeColor = System.Drawing.Color.White;
            this.riskLikelihood.Location = new System.Drawing.Point(449, 181);
            this.riskLikelihood.Multiline = true;
            this.riskLikelihood.Name = "riskLikelihood";
            this.riskLikelihood.Size = new System.Drawing.Size(353, 85);
            this.riskLikelihood.TabIndex = 18;
            this.riskLikelihood.Text = "Risk Likelihood";
            // 
            // riskImpact
            // 
            this.riskImpact.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.riskImpact.ForeColor = System.Drawing.Color.White;
            this.riskImpact.Location = new System.Drawing.Point(449, 275);
            this.riskImpact.Multiline = true;
            this.riskImpact.Name = "riskImpact";
            this.riskImpact.Size = new System.Drawing.Size(353, 85);
            this.riskImpact.TabIndex = 19;
            this.riskImpact.Text = "Risk Impact";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Cambria", 11F);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(3, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "Project Name:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Cambria", 11F);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(3, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 17);
            this.label7.TabIndex = 13;
            this.label7.Text = "Project Manager:";
            // 
            // projectName
            // 
            this.projectName.Location = new System.Drawing.Point(147, 6);
            this.projectName.Name = "projectName";
            this.projectName.Size = new System.Drawing.Size(185, 23);
            this.projectName.TabIndex = 14;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.projectManager);
            this.panel1.Controls.Add(this.projectName);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(24, 59);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(353, 98);
            this.panel1.TabIndex = 15;
            // 
            // projectManager
            // 
            this.projectManager.Location = new System.Drawing.Point(147, 53);
            this.projectManager.Name = "projectManager";
            this.projectManager.Size = new System.Drawing.Size(185, 23);
            this.projectManager.TabIndex = 15;
            // 
            // riskID
            // 
            this.riskID.Location = new System.Drawing.Point(151, 6);
            this.riskID.Name = "riskID";
            this.riskID.Size = new System.Drawing.Size(185, 23);
            this.riskID.TabIndex = 16;
            // 
            // raisedBy
            // 
            this.raisedBy.Location = new System.Drawing.Point(151, 42);
            this.raisedBy.Name = "raisedBy";
            this.raisedBy.Size = new System.Drawing.Size(185, 23);
            this.raisedBy.TabIndex = 17;
            // 
            // dateRaised
            // 
            this.dateRaised.Location = new System.Drawing.Point(151, 75);
            this.dateRaised.Name = "dateRaised";
            this.dateRaised.Size = new System.Drawing.Size(185, 23);
            this.dateRaised.TabIndex = 18;
            // 
            // RiskFormDocumentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(946, 469);
            this.Controls.Add(this.tabControl1);
            this.Name = "RiskFormDocumentForm";
            this.Text = "RiskFormDocumentForm";
            this.tabControl1.ResumeLayout(false);
            this.projectDeatailsAndRiskDetails.ResumeLayout(false);
            this.projectDeatailsAndRiskDetails.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage projectDeatailsAndRiskDetails;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox riskImpact;
        private System.Windows.Forms.TextBox riskLikelihood;
        private System.Windows.Forms.TextBox riskDescription;
        private System.Windows.Forms.TextBox dateRaised;
        private System.Windows.Forms.TextBox raisedBy;
        private System.Windows.Forms.TextBox riskID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox projectManager;
        private System.Windows.Forms.TextBox projectName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
    }
}