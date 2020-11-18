namespace ProjectManagementToolkit.MPMM.MPMM_Document_Forms
{
    partial class ProcurementManagementProcess
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProcurementManagementProcess));
            this.DocumentControlTab = new System.Windows.Forms.TabControl();
            this.DocumentControl = new System.Windows.Forms.TabPage();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.Role = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Signature = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DocumentApproval = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.Version = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IssueDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Changes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DocumentHistory = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Information = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DocumentInformation = new System.Windows.Forms.Label();
            this.ProcurementProcess = new System.Windows.Forms.TabPage();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.ManageSupplierContract = new System.Windows.Forms.Label();
            this.CompletePurchaseOrder = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.IssuePurchaseOrder = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Overview = new System.Windows.Forms.Label();
            this.procurement = new System.Windows.Forms.TextBox();
            this.ProcurementRoles = new System.Windows.Forms.TabPage();
            this.ProcurementDocuments = new System.Windows.Forms.TabPage();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.ProcurementManager = new System.Windows.Forms.Label();
            this.ProjectManager = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.PurchaseOrderForm = new System.Windows.Forms.Label();
            this.ProcurementRegister = new System.Windows.Forms.Label();
            this.DocumentControlTab.SuspendLayout();
            this.DocumentControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.ProcurementProcess.SuspendLayout();
            this.ProcurementRoles.SuspendLayout();
            this.ProcurementDocuments.SuspendLayout();
            this.SuspendLayout();
            // 
            // DocumentControlTab
            // 
            this.DocumentControlTab.Controls.Add(this.DocumentControl);
            this.DocumentControlTab.Controls.Add(this.ProcurementProcess);
            this.DocumentControlTab.Controls.Add(this.ProcurementRoles);
            this.DocumentControlTab.Controls.Add(this.ProcurementDocuments);
            this.DocumentControlTab.Location = new System.Drawing.Point(27, 12);
            this.DocumentControlTab.Name = "DocumentControlTab";
            this.DocumentControlTab.SelectedIndex = 0;
            this.DocumentControlTab.Size = new System.Drawing.Size(620, 740);
            this.DocumentControlTab.TabIndex = 0;
            // 
            // DocumentControl
            // 
            this.DocumentControl.Controls.Add(this.dataGridView3);
            this.DocumentControl.Controls.Add(this.DocumentApproval);
            this.DocumentControl.Controls.Add(this.dataGridView2);
            this.DocumentControl.Controls.Add(this.DocumentHistory);
            this.DocumentControl.Controls.Add(this.dataGridView1);
            this.DocumentControl.Controls.Add(this.DocumentInformation);
            this.DocumentControl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.DocumentControl.Location = new System.Drawing.Point(4, 22);
            this.DocumentControl.Name = "DocumentControl";
            this.DocumentControl.Padding = new System.Windows.Forms.Padding(3);
            this.DocumentControl.Size = new System.Drawing.Size(612, 714);
            this.DocumentControl.TabIndex = 0;
            this.DocumentControl.Text = "Document Control";
            this.DocumentControl.UseVisualStyleBackColor = true;
            // 
            // dataGridView3
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Role,
            this.Name,
            this.Signature,
            this.Date});
            this.dataGridView3.Location = new System.Drawing.Point(7, 395);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.Size = new System.Drawing.Size(311, 150);
            this.dataGridView3.TabIndex = 5;
            // 
            // Role
            // 
            this.Role.HeaderText = "Role";
            this.Role.Name = "Role";
            // 
            // Name
            // 
            this.Name.HeaderText = "Name";
            this.Name.Name = "Name";
            // 
            // Signature
            // 
            this.Signature.HeaderText = "Signature";
            this.Signature.Name = "Signature";
            // 
            // Date
            // 
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            // 
            // DocumentApproval
            // 
            this.DocumentApproval.AutoSize = true;
            this.DocumentApproval.ForeColor = System.Drawing.Color.Blue;
            this.DocumentApproval.Location = new System.Drawing.Point(9, 369);
            this.DocumentApproval.Name = "DocumentApproval";
            this.DocumentApproval.Size = new System.Drawing.Size(101, 13);
            this.DocumentApproval.TabIndex = 4;
            this.DocumentApproval.Text = "Document Approval";
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Version,
            this.IssueDate,
            this.Changes});
            this.dataGridView2.Location = new System.Drawing.Point(6, 212);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(312, 150);
            this.dataGridView2.TabIndex = 3;
            // 
            // Version
            // 
            this.Version.HeaderText = "Version";
            this.Version.Name = "Version";
            // 
            // IssueDate
            // 
            this.IssueDate.HeaderText = "Issue Date";
            this.IssueDate.Name = "IssueDate";
            // 
            // Changes
            // 
            this.Changes.HeaderText = "Changes";
            this.Changes.Name = "Changes";
            // 
            // DocumentHistory
            // 
            this.DocumentHistory.AutoSize = true;
            this.DocumentHistory.ForeColor = System.Drawing.Color.Blue;
            this.DocumentHistory.Location = new System.Drawing.Point(6, 196);
            this.DocumentHistory.Name = "DocumentHistory";
            this.DocumentHistory.Size = new System.Drawing.Size(91, 13);
            this.DocumentHistory.TabIndex = 2;
            this.DocumentHistory.Text = "Document History";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Information});
            this.dataGridView1.GridColor = System.Drawing.Color.Blue;
            this.dataGridView1.Location = new System.Drawing.Point(6, 43);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(240, 150);
            this.dataGridView1.TabIndex = 1;
            // 
            // Column1
            // 
            this.Column1.HeaderText = " ";
            this.Column1.Name = "Column1";
            // 
            // Information
            // 
            this.Information.HeaderText = "Information";
            this.Information.Name = "Information";
            // 
            // DocumentInformation
            // 
            this.DocumentInformation.AutoSize = true;
            this.DocumentInformation.ForeColor = System.Drawing.Color.Blue;
            this.DocumentInformation.Location = new System.Drawing.Point(6, 18);
            this.DocumentInformation.Name = "DocumentInformation";
            this.DocumentInformation.Size = new System.Drawing.Size(111, 13);
            this.DocumentInformation.TabIndex = 0;
            this.DocumentInformation.Text = "Document Information";
            // 
            // ProcurementProcess
            // 
            this.ProcurementProcess.Controls.Add(this.textBox4);
            this.ProcurementProcess.Controls.Add(this.ManageSupplierContract);
            this.ProcurementProcess.Controls.Add(this.CompletePurchaseOrder);
            this.ProcurementProcess.Controls.Add(this.textBox3);
            this.ProcurementProcess.Controls.Add(this.textBox2);
            this.ProcurementProcess.Controls.Add(this.IssuePurchaseOrder);
            this.ProcurementProcess.Controls.Add(this.textBox1);
            this.ProcurementProcess.Controls.Add(this.Overview);
            this.ProcurementProcess.Controls.Add(this.procurement);
            this.ProcurementProcess.Location = new System.Drawing.Point(4, 22);
            this.ProcurementProcess.Name = "ProcurementProcess";
            this.ProcurementProcess.Padding = new System.Windows.Forms.Padding(3);
            this.ProcurementProcess.Size = new System.Drawing.Size(612, 714);
            this.ProcurementProcess.TabIndex = 1;
            this.ProcurementProcess.Text = "Procurement Process";
            this.ProcurementProcess.UseVisualStyleBackColor = true;
            // 
            // textBox4
            // 
            this.textBox4.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.textBox4.Location = new System.Drawing.Point(357, 35);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(235, 198);
            this.textBox4.TabIndex = 9;
            this.textBox4.Text = resources.GetString("textBox4.Text");
            // 
            // ManageSupplierContract
            // 
            this.ManageSupplierContract.AutoSize = true;
            this.ManageSupplierContract.Location = new System.Drawing.Point(354, 19);
            this.ManageSupplierContract.Name = "ManageSupplierContract";
            this.ManageSupplierContract.Size = new System.Drawing.Size(148, 13);
            this.ManageSupplierContract.TabIndex = 8;
            this.ManageSupplierContract.Text = "1.4 Manage Supplier Contract";
            // 
            // CompletePurchaseOrder
            // 
            this.CompletePurchaseOrder.AutoSize = true;
            this.CompletePurchaseOrder.Location = new System.Drawing.Point(3, 368);
            this.CompletePurchaseOrder.Name = "CompletePurchaseOrder";
            this.CompletePurchaseOrder.Size = new System.Drawing.Size(146, 13);
            this.CompletePurchaseOrder.TabIndex = 7;
            this.CompletePurchaseOrder.Text = "1.3 Complete Purchase Order";
            // 
            // textBox3
            // 
            this.textBox3.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.textBox3.Location = new System.Drawing.Point(0, 393);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(279, 151);
            this.textBox3.TabIndex = 6;
            this.textBox3.Text = resources.GetString("textBox3.Text");
            // 
            // textBox2
            // 
            this.textBox2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.textBox2.Location = new System.Drawing.Point(6, 226);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(279, 129);
            this.textBox2.TabIndex = 5;
            this.textBox2.Text = resources.GetString("textBox2.Text");
            // 
            // IssuePurchaseOrder
            // 
            this.IssuePurchaseOrder.AutoSize = true;
            this.IssuePurchaseOrder.Location = new System.Drawing.Point(9, 195);
            this.IssuePurchaseOrder.Name = "IssuePurchaseOrder";
            this.IssuePurchaseOrder.Size = new System.Drawing.Size(127, 13);
            this.IssuePurchaseOrder.TabIndex = 4;
            this.IssuePurchaseOrder.Text = "1.2 Issue Purchase Order";
            this.IssuePurchaseOrder.Click += new System.EventHandler(this.IssuePurchaseOrder_Click);
            // 
            // textBox1
            // 
            this.textBox1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.textBox1.Location = new System.Drawing.Point(9, 155);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(326, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "Provide an overview of the Procurement Management Process, depicted as follows:";
            // 
            // Overview
            // 
            this.Overview.AutoSize = true;
            this.Overview.Location = new System.Drawing.Point(6, 138);
            this.Overview.Name = "Overview";
            this.Overview.Size = new System.Drawing.Size(70, 13);
            this.Overview.TabIndex = 1;
            this.Overview.Text = "1.1 Overview";
            // 
            // procurement
            // 
            this.procurement.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.procurement.Location = new System.Drawing.Point(6, 19);
            this.procurement.Multiline = true;
            this.procurement.Name = "procurement";
            this.procurement.Size = new System.Drawing.Size(329, 104);
            this.procurement.TabIndex = 0;
            this.procurement.Text = resources.GetString("procurement.Text");
            // 
            // ProcurementRoles
            // 
            this.ProcurementRoles.Controls.Add(this.textBox7);
            this.ProcurementRoles.Controls.Add(this.textBox6);
            this.ProcurementRoles.Controls.Add(this.ProjectManager);
            this.ProcurementRoles.Controls.Add(this.ProcurementManager);
            this.ProcurementRoles.Controls.Add(this.textBox5);
            this.ProcurementRoles.Location = new System.Drawing.Point(4, 22);
            this.ProcurementRoles.Name = "ProcurementRoles";
            this.ProcurementRoles.Padding = new System.Windows.Forms.Padding(3);
            this.ProcurementRoles.Size = new System.Drawing.Size(612, 714);
            this.ProcurementRoles.TabIndex = 2;
            this.ProcurementRoles.Text = "Procurement Roles";
            this.ProcurementRoles.UseVisualStyleBackColor = true;
            // 
            // ProcurementDocuments
            // 
            this.ProcurementDocuments.Controls.Add(this.ProcurementRegister);
            this.ProcurementDocuments.Controls.Add(this.PurchaseOrderForm);
            this.ProcurementDocuments.Controls.Add(this.textBox10);
            this.ProcurementDocuments.Controls.Add(this.textBox9);
            this.ProcurementDocuments.Controls.Add(this.textBox8);
            this.ProcurementDocuments.Location = new System.Drawing.Point(4, 22);
            this.ProcurementDocuments.Name = "ProcurementDocuments";
            this.ProcurementDocuments.Padding = new System.Windows.Forms.Padding(3);
            this.ProcurementDocuments.Size = new System.Drawing.Size(612, 714);
            this.ProcurementDocuments.TabIndex = 3;
            this.ProcurementDocuments.Text = "Procurement Documents";
            this.ProcurementDocuments.UseVisualStyleBackColor = true;
            // 
            // textBox5
            // 
            this.textBox5.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.textBox5.Location = new System.Drawing.Point(30, 30);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(247, 54);
            this.textBox5.TabIndex = 0;
            this.textBox5.Text = "In this section, describe the key roles and responsibilities involved in the Proc" +
    "urement Management Process.";
            // 
            // ProcurementManager
            // 
            this.ProcurementManager.AutoSize = true;
            this.ProcurementManager.Location = new System.Drawing.Point(30, 106);
            this.ProcurementManager.Name = "ProcurementManager";
            this.ProcurementManager.Size = new System.Drawing.Size(130, 13);
            this.ProcurementManager.TabIndex = 1;
            this.ProcurementManager.Text = "2.1 Procurement Manager";
            // 
            // ProjectManager
            // 
            this.ProjectManager.AutoSize = true;
            this.ProjectManager.Location = new System.Drawing.Point(30, 230);
            this.ProjectManager.Name = "ProjectManager";
            this.ProjectManager.Size = new System.Drawing.Size(103, 13);
            this.ProjectManager.TabIndex = 2;
            this.ProjectManager.Text = "2.2 Project Manager";
            // 
            // textBox6
            // 
            this.textBox6.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.textBox6.Location = new System.Drawing.Point(33, 150);
            this.textBox6.Multiline = true;
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(227, 57);
            this.textBox6.TabIndex = 3;
            this.textBox6.Text = "List the responsibilities of the Procurement Manager in the Procurement Managemen" +
    "t Process.";
            // 
            // textBox7
            // 
            this.textBox7.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.textBox7.Location = new System.Drawing.Point(33, 268);
            this.textBox7.Multiline = true;
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(212, 51);
            this.textBox7.TabIndex = 4;
            this.textBox7.Text = "List the responsibilities of the Project Manager in the Procurement Management Pr" +
    "ocess.";
            // 
            // textBox8
            // 
            this.textBox8.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.textBox8.Location = new System.Drawing.Point(20, 17);
            this.textBox8.Multiline = true;
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(221, 74);
            this.textBox8.TabIndex = 0;
            this.textBox8.Text = "In this section, identify the documents that are used to successfully undertake t" +
    "he Procurement Management Process.";
            // 
            // textBox9
            // 
            this.textBox9.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.textBox9.Location = new System.Drawing.Point(20, 147);
            this.textBox9.Multiline = true;
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(169, 71);
            this.textBox9.TabIndex = 1;
            this.textBox9.Text = "Describe the purpose of the Purchase Order Form and provide a template for its co" +
    "mpletion.";
            // 
            // textBox10
            // 
            this.textBox10.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.textBox10.Location = new System.Drawing.Point(20, 282);
            this.textBox10.Multiline = true;
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(169, 75);
            this.textBox10.TabIndex = 2;
            this.textBox10.Text = "Describe the purpose of the Procurement Register and provide a template for its c" +
    "ompletion.";
            // 
            // PurchaseOrderForm
            // 
            this.PurchaseOrderForm.AutoSize = true;
            this.PurchaseOrderForm.Location = new System.Drawing.Point(20, 116);
            this.PurchaseOrderForm.Name = "PurchaseOrderForm";
            this.PurchaseOrderForm.Size = new System.Drawing.Size(125, 13);
            this.PurchaseOrderForm.TabIndex = 3;
            this.PurchaseOrderForm.Text = "3.1 Purchase Order From";
            // 
            // ProcurementRegister
            // 
            this.ProcurementRegister.AutoSize = true;
            this.ProcurementRegister.Location = new System.Drawing.Point(23, 263);
            this.ProcurementRegister.Name = "ProcurementRegister";
            this.ProcurementRegister.Size = new System.Drawing.Size(127, 13);
            this.ProcurementRegister.TabIndex = 4;
            this.ProcurementRegister.Text = "3.2 Procurement Register";
            // 
            // ProcurementManagementProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(685, 749);
            this.Controls.Add(this.DocumentControlTab);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.Name = "ProcurementManagementProcess";
            this.Text = "ProcurementManagementProcess";
            this.DocumentControlTab.ResumeLayout(false);
            this.DocumentControl.ResumeLayout(false);
            this.DocumentControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ProcurementProcess.ResumeLayout(false);
            this.ProcurementProcess.PerformLayout();
            this.ProcurementRoles.ResumeLayout(false);
            this.ProcurementRoles.PerformLayout();
            this.ProcurementDocuments.ResumeLayout(false);
            this.ProcurementDocuments.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl DocumentControlTab;
        private System.Windows.Forms.TabPage DocumentControl;
        private System.Windows.Forms.TabPage ProcurementProcess;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Version;
        private System.Windows.Forms.DataGridViewTextBoxColumn IssueDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Changes;
        private System.Windows.Forms.Label DocumentHistory;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Information;
        private System.Windows.Forms.Label DocumentInformation;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Role;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Signature;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.Label DocumentApproval;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label IssuePurchaseOrder;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label Overview;
        private System.Windows.Forms.TextBox procurement;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label ManageSupplierContract;
        private System.Windows.Forms.Label CompletePurchaseOrder;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TabPage ProcurementRoles;
        private System.Windows.Forms.Label ProjectManager;
        private System.Windows.Forms.Label ProcurementManager;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TabPage ProcurementDocuments;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Label ProcurementRegister;
        private System.Windows.Forms.Label PurchaseOrderForm;
    }
}