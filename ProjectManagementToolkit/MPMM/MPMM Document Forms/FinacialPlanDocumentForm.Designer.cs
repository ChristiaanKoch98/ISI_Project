namespace ProjectManagementToolkit.MPMM.MPMM_Document_Forms
{
    partial class FinacialPlanDocumentForm
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
            this.lblProjectName = new System.Windows.Forms.Label();
            this.txtProjectName = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageDocumentControl = new System.Windows.Forms.TabPage();
            this.lblDocApprovs = new System.Windows.Forms.Label();
            this.lblDocHist = new System.Windows.Forms.Label();
            this.lblDocInfo = new System.Windows.Forms.Label();
            this.dataGridViewDocumentApprovals = new System.Windows.Forms.DataGridView();
            this.dataGridViewDocumentHistory = new System.Windows.Forms.DataGridView();
            this.dataGridViewDocumentInformation = new System.Windows.Forms.DataGridView();
            this.tabPageFinancialExpenses = new System.Windows.Forms.TabPage();
            this.dataGridViewOther = new System.Windows.Forms.DataGridView();
            this.dataGridViewAdmin = new System.Windows.Forms.DataGridView();
            this.dataGridViewSuppliers = new System.Windows.Forms.DataGridView();
            this.dataGridViewMaterials = new System.Windows.Forms.DataGridView();
            this.dataGridViewEquipment = new System.Windows.Forms.DataGridView();
            this.tabPageFinancialPlan = new System.Windows.Forms.TabPage();
            this.btnSaveConstraints = new System.Windows.Forms.Button();
            this.btnSaveAssumptions = new System.Windows.Forms.Button();
            this.lblAssumption = new System.Windows.Forms.Label();
            this.lblConstraints = new System.Windows.Forms.Label();
            this.txtAssumptions = new System.Windows.Forms.TextBox();
            this.txtConstraints = new System.Windows.Forms.TextBox();
            this.lblSchedule = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabPageFinancialProcess = new System.Windows.Forms.TabPage();
            this.btnSaveActivitiesRolesDocuments = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDocuments = new System.Windows.Forms.TextBox();
            this.txtRoles = new System.Windows.Forms.TextBox();
            this.txtActivities = new System.Windows.Forms.TextBox();
            this.tabPageAppendix = new System.Windows.Forms.TabPage();
            this.btnSaveProjectName = new System.Windows.Forms.Button();
            this.tabControlFinancialExpense = new System.Windows.Forms.TabControl();
            this.tabPageLabour = new System.Windows.Forms.TabPage();
            this.tabPageEquipment = new System.Windows.Forms.TabPage();
            this.tabPageMaterials = new System.Windows.Forms.TabPage();
            this.tabPageSuppliers = new System.Windows.Forms.TabPage();
            this.tabPageAdmin = new System.Windows.Forms.TabPage();
            this.tabPageOther = new System.Windows.Forms.TabPage();
            this.dataGridViewLabour = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tabPageDocumentControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDocumentApprovals)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDocumentHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDocumentInformation)).BeginInit();
            this.tabPageFinancialExpenses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOther)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAdmin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSuppliers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMaterials)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEquipment)).BeginInit();
            this.tabPageFinancialPlan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPageFinancialProcess.SuspendLayout();
            this.tabControlFinancialExpense.SuspendLayout();
            this.tabPageLabour.SuspendLayout();
            this.tabPageEquipment.SuspendLayout();
            this.tabPageMaterials.SuspendLayout();
            this.tabPageSuppliers.SuspendLayout();
            this.tabPageAdmin.SuspendLayout();
            this.tabPageOther.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLabour)).BeginInit();
            this.SuspendLayout();
            // 
            // lblProjectName
            // 
            this.lblProjectName.AutoSize = true;
            this.lblProjectName.ForeColor = System.Drawing.Color.Black;
            this.lblProjectName.Location = new System.Drawing.Point(12, 10);
            this.lblProjectName.Name = "lblProjectName";
            this.lblProjectName.Size = new System.Drawing.Size(170, 14);
            this.lblProjectName.TabIndex = 0;
            this.lblProjectName.Text = "Please Enter Your Project Name: ";
            // 
            // txtProjectName
            // 
            this.txtProjectName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            this.txtProjectName.ForeColor = System.Drawing.Color.Black;
            this.txtProjectName.Location = new System.Drawing.Point(184, 8);
            this.txtProjectName.Name = "txtProjectName";
            this.txtProjectName.Size = new System.Drawing.Size(100, 21);
            this.txtProjectName.TabIndex = 1;
            this.txtProjectName.Text = "Project Name";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPageDocumentControl);
            this.tabControl1.Controls.Add(this.tabPageFinancialExpenses);
            this.tabControl1.Controls.Add(this.tabPageFinancialPlan);
            this.tabControl1.Controls.Add(this.tabPageFinancialProcess);
            this.tabControl1.Controls.Add(this.tabPageAppendix);
            this.tabControl1.Location = new System.Drawing.Point(14, 37);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(774, 465);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPageDocumentControl
            // 
            this.tabPageDocumentControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            this.tabPageDocumentControl.Controls.Add(this.lblDocApprovs);
            this.tabPageDocumentControl.Controls.Add(this.lblDocHist);
            this.tabPageDocumentControl.Controls.Add(this.lblDocInfo);
            this.tabPageDocumentControl.Controls.Add(this.dataGridViewDocumentApprovals);
            this.tabPageDocumentControl.Controls.Add(this.dataGridViewDocumentHistory);
            this.tabPageDocumentControl.Controls.Add(this.dataGridViewDocumentInformation);
            this.tabPageDocumentControl.Location = new System.Drawing.Point(4, 23);
            this.tabPageDocumentControl.Name = "tabPageDocumentControl";
            this.tabPageDocumentControl.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDocumentControl.Size = new System.Drawing.Size(766, 438);
            this.tabPageDocumentControl.TabIndex = 0;
            this.tabPageDocumentControl.Text = "Document Control";
            // 
            // lblDocApprovs
            // 
            this.lblDocApprovs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDocApprovs.AutoSize = true;
            this.lblDocApprovs.Font = new System.Drawing.Font("Helvetica Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDocApprovs.ForeColor = System.Drawing.Color.Black;
            this.lblDocApprovs.Location = new System.Drawing.Point(5, 355);
            this.lblDocApprovs.Name = "lblDocApprovs";
            this.lblDocApprovs.Size = new System.Drawing.Size(148, 19);
            this.lblDocApprovs.TabIndex = 11;
            this.lblDocApprovs.Text = "Document Approvals";
            // 
            // lblDocHist
            // 
            this.lblDocHist.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDocHist.AutoSize = true;
            this.lblDocHist.Font = new System.Drawing.Font("Helvetica Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDocHist.ForeColor = System.Drawing.Color.Black;
            this.lblDocHist.Location = new System.Drawing.Point(5, 206);
            this.lblDocHist.Name = "lblDocHist";
            this.lblDocHist.Size = new System.Drawing.Size(127, 19);
            this.lblDocHist.TabIndex = 10;
            this.lblDocHist.Text = "Document History";
            // 
            // lblDocInfo
            // 
            this.lblDocInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDocInfo.AutoSize = true;
            this.lblDocInfo.Font = new System.Drawing.Font("Helvetica Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDocInfo.ForeColor = System.Drawing.Color.Black;
            this.lblDocInfo.Location = new System.Drawing.Point(5, 52);
            this.lblDocInfo.Name = "lblDocInfo";
            this.lblDocInfo.Size = new System.Drawing.Size(152, 19);
            this.lblDocInfo.TabIndex = 9;
            this.lblDocInfo.Text = "Document Information";
            // 
            // dataGridViewDocumentApprovals
            // 
            this.dataGridViewDocumentApprovals.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewDocumentApprovals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDocumentApprovals.Location = new System.Drawing.Point(166, 285);
            this.dataGridViewDocumentApprovals.Name = "dataGridViewDocumentApprovals";
            this.dataGridViewDocumentApprovals.Size = new System.Drawing.Size(594, 143);
            this.dataGridViewDocumentApprovals.TabIndex = 8;
            // 
            // dataGridViewDocumentHistory
            // 
            this.dataGridViewDocumentHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewDocumentHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDocumentHistory.Location = new System.Drawing.Point(166, 140);
            this.dataGridViewDocumentHistory.Name = "dataGridViewDocumentHistory";
            this.dataGridViewDocumentHistory.Size = new System.Drawing.Size(594, 136);
            this.dataGridViewDocumentHistory.TabIndex = 7;
            // 
            // dataGridViewDocumentInformation
            // 
            this.dataGridViewDocumentInformation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewDocumentInformation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDocumentInformation.Location = new System.Drawing.Point(166, 7);
            this.dataGridViewDocumentInformation.Name = "dataGridViewDocumentInformation";
            this.dataGridViewDocumentInformation.Size = new System.Drawing.Size(594, 124);
            this.dataGridViewDocumentInformation.TabIndex = 6;
            // 
            // tabPageFinancialExpenses
            // 
            this.tabPageFinancialExpenses.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            this.tabPageFinancialExpenses.Controls.Add(this.tabControlFinancialExpense);
            this.tabPageFinancialExpenses.Location = new System.Drawing.Point(4, 23);
            this.tabPageFinancialExpenses.Name = "tabPageFinancialExpenses";
            this.tabPageFinancialExpenses.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFinancialExpenses.Size = new System.Drawing.Size(766, 438);
            this.tabPageFinancialExpenses.TabIndex = 1;
            this.tabPageFinancialExpenses.Text = "Financial Expenses";
            // 
            // dataGridViewOther
            // 
            this.dataGridViewOther.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewOther.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOther.Location = new System.Drawing.Point(6, 6);
            this.dataGridViewOther.Name = "dataGridViewOther";
            this.dataGridViewOther.Size = new System.Drawing.Size(734, 378);
            this.dataGridViewOther.TabIndex = 12;
            // 
            // dataGridViewAdmin
            // 
            this.dataGridViewAdmin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewAdmin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAdmin.Location = new System.Drawing.Point(6, 6);
            this.dataGridViewAdmin.Name = "dataGridViewAdmin";
            this.dataGridViewAdmin.Size = new System.Drawing.Size(734, 378);
            this.dataGridViewAdmin.TabIndex = 11;
            // 
            // dataGridViewSuppliers
            // 
            this.dataGridViewSuppliers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewSuppliers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSuppliers.Location = new System.Drawing.Point(6, 6);
            this.dataGridViewSuppliers.Name = "dataGridViewSuppliers";
            this.dataGridViewSuppliers.Size = new System.Drawing.Size(734, 378);
            this.dataGridViewSuppliers.TabIndex = 10;
            // 
            // dataGridViewMaterials
            // 
            this.dataGridViewMaterials.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewMaterials.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMaterials.Location = new System.Drawing.Point(6, 6);
            this.dataGridViewMaterials.Name = "dataGridViewMaterials";
            this.dataGridViewMaterials.Size = new System.Drawing.Size(734, 378);
            this.dataGridViewMaterials.TabIndex = 6;
            // 
            // dataGridViewEquipment
            // 
            this.dataGridViewEquipment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewEquipment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEquipment.Location = new System.Drawing.Point(6, 6);
            this.dataGridViewEquipment.Name = "dataGridViewEquipment";
            this.dataGridViewEquipment.Size = new System.Drawing.Size(734, 378);
            this.dataGridViewEquipment.TabIndex = 5;
            // 
            // tabPageFinancialPlan
            // 
            this.tabPageFinancialPlan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            this.tabPageFinancialPlan.Controls.Add(this.btnSaveConstraints);
            this.tabPageFinancialPlan.Controls.Add(this.btnSaveAssumptions);
            this.tabPageFinancialPlan.Controls.Add(this.lblAssumption);
            this.tabPageFinancialPlan.Controls.Add(this.lblConstraints);
            this.tabPageFinancialPlan.Controls.Add(this.txtAssumptions);
            this.tabPageFinancialPlan.Controls.Add(this.txtConstraints);
            this.tabPageFinancialPlan.Controls.Add(this.lblSchedule);
            this.tabPageFinancialPlan.Controls.Add(this.dataGridView1);
            this.tabPageFinancialPlan.ForeColor = System.Drawing.Color.White;
            this.tabPageFinancialPlan.Location = new System.Drawing.Point(4, 23);
            this.tabPageFinancialPlan.Name = "tabPageFinancialPlan";
            this.tabPageFinancialPlan.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFinancialPlan.Size = new System.Drawing.Size(766, 438);
            this.tabPageFinancialPlan.TabIndex = 2;
            this.tabPageFinancialPlan.Text = "Financial Plan";
            // 
            // btnSaveConstraints
            // 
            this.btnSaveConstraints.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(173)))), ((int)(((byte)(252)))));
            this.btnSaveConstraints.Font = new System.Drawing.Font("Helvetica Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveConstraints.ForeColor = System.Drawing.Color.Black;
            this.btnSaveConstraints.Location = new System.Drawing.Point(468, 399);
            this.btnSaveConstraints.Name = "btnSaveConstraints";
            this.btnSaveConstraints.Size = new System.Drawing.Size(292, 27);
            this.btnSaveConstraints.TabIndex = 7;
            this.btnSaveConstraints.Text = "Save Constraints";
            this.btnSaveConstraints.UseVisualStyleBackColor = false;
            this.btnSaveConstraints.Click += new System.EventHandler(this.btnSaveConstraints_Click);
            // 
            // btnSaveAssumptions
            // 
            this.btnSaveAssumptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(173)))), ((int)(((byte)(252)))));
            this.btnSaveAssumptions.Font = new System.Drawing.Font("Helvetica Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveAssumptions.ForeColor = System.Drawing.Color.Black;
            this.btnSaveAssumptions.Location = new System.Drawing.Point(77, 399);
            this.btnSaveAssumptions.Name = "btnSaveAssumptions";
            this.btnSaveAssumptions.Size = new System.Drawing.Size(292, 27);
            this.btnSaveAssumptions.TabIndex = 6;
            this.btnSaveAssumptions.Text = "Save Assumptions";
            this.btnSaveAssumptions.UseVisualStyleBackColor = false;
            this.btnSaveAssumptions.Click += new System.EventHandler(this.btnSaveAssumptions_Click);
            // 
            // lblAssumption
            // 
            this.lblAssumption.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAssumption.AutoSize = true;
            this.lblAssumption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            this.lblAssumption.Font = new System.Drawing.Font("Helvetica Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAssumption.ForeColor = System.Drawing.Color.Black;
            this.lblAssumption.Location = new System.Drawing.Point(3, 248);
            this.lblAssumption.Name = "lblAssumption";
            this.lblAssumption.Size = new System.Drawing.Size(71, 14);
            this.lblAssumption.TabIndex = 5;
            this.lblAssumption.Text = "Assumptions";
            // 
            // lblConstraints
            // 
            this.lblConstraints.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblConstraints.AutoSize = true;
            this.lblConstraints.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            this.lblConstraints.Font = new System.Drawing.Font("Helvetica Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConstraints.ForeColor = System.Drawing.Color.Black;
            this.lblConstraints.Location = new System.Drawing.Point(396, 248);
            this.lblConstraints.Name = "lblConstraints";
            this.lblConstraints.Size = new System.Drawing.Size(63, 14);
            this.lblConstraints.TabIndex = 4;
            this.lblConstraints.Text = "Constraints";
            // 
            // txtAssumptions
            // 
            this.txtAssumptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAssumptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            this.txtAssumptions.Font = new System.Drawing.Font("Helvetica Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAssumptions.ForeColor = System.Drawing.Color.Black;
            this.txtAssumptions.Location = new System.Drawing.Point(77, 248);
            this.txtAssumptions.Multiline = true;
            this.txtAssumptions.Name = "txtAssumptions";
            this.txtAssumptions.Size = new System.Drawing.Size(292, 141);
            this.txtAssumptions.TabIndex = 3;
            this.txtAssumptions.Text = "Assumptions";
            // 
            // txtConstraints
            // 
            this.txtConstraints.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConstraints.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            this.txtConstraints.Font = new System.Drawing.Font("Helvetica Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConstraints.ForeColor = System.Drawing.Color.Black;
            this.txtConstraints.Location = new System.Drawing.Point(468, 248);
            this.txtConstraints.Multiline = true;
            this.txtConstraints.Name = "txtConstraints";
            this.txtConstraints.Size = new System.Drawing.Size(292, 141);
            this.txtConstraints.TabIndex = 2;
            this.txtConstraints.Text = "Constraints";
            // 
            // lblSchedule
            // 
            this.lblSchedule.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSchedule.AutoSize = true;
            this.lblSchedule.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            this.lblSchedule.Font = new System.Drawing.Font("Helvetica Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSchedule.ForeColor = System.Drawing.Color.Black;
            this.lblSchedule.Location = new System.Drawing.Point(6, 8);
            this.lblSchedule.Name = "lblSchedule";
            this.lblSchedule.Size = new System.Drawing.Size(53, 14);
            this.lblSchedule.TabIndex = 1;
            this.lblSchedule.Text = "Schedule";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(77, 8);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(683, 230);
            this.dataGridView1.TabIndex = 0;
            // 
            // tabPageFinancialProcess
            // 
            this.tabPageFinancialProcess.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            this.tabPageFinancialProcess.Controls.Add(this.btnSaveActivitiesRolesDocuments);
            this.tabPageFinancialProcess.Controls.Add(this.label3);
            this.tabPageFinancialProcess.Controls.Add(this.label2);
            this.tabPageFinancialProcess.Controls.Add(this.label1);
            this.tabPageFinancialProcess.Controls.Add(this.txtDocuments);
            this.tabPageFinancialProcess.Controls.Add(this.txtRoles);
            this.tabPageFinancialProcess.Controls.Add(this.txtActivities);
            this.tabPageFinancialProcess.Location = new System.Drawing.Point(4, 23);
            this.tabPageFinancialProcess.Name = "tabPageFinancialProcess";
            this.tabPageFinancialProcess.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFinancialProcess.Size = new System.Drawing.Size(766, 438);
            this.tabPageFinancialProcess.TabIndex = 3;
            this.tabPageFinancialProcess.Text = "Financial Process";
            // 
            // btnSaveActivitiesRolesDocuments
            // 
            this.btnSaveActivitiesRolesDocuments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveActivitiesRolesDocuments.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(173)))), ((int)(((byte)(252)))));
            this.btnSaveActivitiesRolesDocuments.Font = new System.Drawing.Font("Helvetica Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveActivitiesRolesDocuments.ForeColor = System.Drawing.Color.Black;
            this.btnSaveActivitiesRolesDocuments.Location = new System.Drawing.Point(98, 380);
            this.btnSaveActivitiesRolesDocuments.Name = "btnSaveActivitiesRolesDocuments";
            this.btnSaveActivitiesRolesDocuments.Size = new System.Drawing.Size(662, 49);
            this.btnSaveActivitiesRolesDocuments.TabIndex = 6;
            this.btnSaveActivitiesRolesDocuments.Text = "Save Information";
            this.btnSaveActivitiesRolesDocuments.UseVisualStyleBackColor = false;
            this.btnSaveActivitiesRolesDocuments.Click += new System.EventHandler(this.btnSaveActivitiesRolesDocuments_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            this.label3.Font = new System.Drawing.Font("Helvetica Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(6, 260);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 5;
            this.label3.Text = "Documents";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            this.label2.Font = new System.Drawing.Font("Helvetica Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(6, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 14);
            this.label2.TabIndex = 4;
            this.label2.Text = "Roles";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            this.label1.Font = new System.Drawing.Font("Helvetica Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(6, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "Activities";
            // 
            // txtDocuments
            // 
            this.txtDocuments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDocuments.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            this.txtDocuments.Font = new System.Drawing.Font("Helvetica Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDocuments.ForeColor = System.Drawing.Color.Black;
            this.txtDocuments.Location = new System.Drawing.Point(98, 260);
            this.txtDocuments.Multiline = true;
            this.txtDocuments.Name = "txtDocuments";
            this.txtDocuments.Size = new System.Drawing.Size(662, 109);
            this.txtDocuments.TabIndex = 2;
            this.txtDocuments.Text = "Documents";
            // 
            // txtRoles
            // 
            this.txtRoles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRoles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            this.txtRoles.Font = new System.Drawing.Font("Helvetica Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRoles.ForeColor = System.Drawing.Color.Black;
            this.txtRoles.Location = new System.Drawing.Point(98, 133);
            this.txtRoles.Multiline = true;
            this.txtRoles.Name = "txtRoles";
            this.txtRoles.Size = new System.Drawing.Size(662, 117);
            this.txtRoles.TabIndex = 1;
            this.txtRoles.Text = "Roles";
            // 
            // txtActivities
            // 
            this.txtActivities.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtActivities.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            this.txtActivities.Font = new System.Drawing.Font("Helvetica Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtActivities.ForeColor = System.Drawing.Color.Black;
            this.txtActivities.Location = new System.Drawing.Point(98, 15);
            this.txtActivities.Multiline = true;
            this.txtActivities.Name = "txtActivities";
            this.txtActivities.Size = new System.Drawing.Size(662, 108);
            this.txtActivities.TabIndex = 0;
            this.txtActivities.Text = "Activities";
            // 
            // tabPageAppendix
            // 
            this.tabPageAppendix.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            this.tabPageAppendix.ForeColor = System.Drawing.Color.White;
            this.tabPageAppendix.Location = new System.Drawing.Point(4, 23);
            this.tabPageAppendix.Name = "tabPageAppendix";
            this.tabPageAppendix.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAppendix.Size = new System.Drawing.Size(766, 438);
            this.tabPageAppendix.TabIndex = 4;
            this.tabPageAppendix.Text = "Appendix";
            // 
            // btnSaveProjectName
            // 
            this.btnSaveProjectName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(173)))), ((int)(((byte)(252)))));
            this.btnSaveProjectName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.btnSaveProjectName.Location = new System.Drawing.Point(290, 8);
            this.btnSaveProjectName.Name = "btnSaveProjectName";
            this.btnSaveProjectName.Size = new System.Drawing.Size(110, 23);
            this.btnSaveProjectName.TabIndex = 3;
            this.btnSaveProjectName.Text = "Save Project Name";
            this.btnSaveProjectName.UseVisualStyleBackColor = false;
            this.btnSaveProjectName.Click += new System.EventHandler(this.btnSaveProjectName_Click);
            // 
            // tabControlFinancialExpense
            // 
            this.tabControlFinancialExpense.Controls.Add(this.tabPageLabour);
            this.tabControlFinancialExpense.Controls.Add(this.tabPageEquipment);
            this.tabControlFinancialExpense.Controls.Add(this.tabPageMaterials);
            this.tabControlFinancialExpense.Controls.Add(this.tabPageSuppliers);
            this.tabControlFinancialExpense.Controls.Add(this.tabPageAdmin);
            this.tabControlFinancialExpense.Controls.Add(this.tabPageOther);
            this.tabControlFinancialExpense.Location = new System.Drawing.Point(6, 6);
            this.tabControlFinancialExpense.Name = "tabControlFinancialExpense";
            this.tabControlFinancialExpense.SelectedIndex = 0;
            this.tabControlFinancialExpense.Size = new System.Drawing.Size(754, 417);
            this.tabControlFinancialExpense.TabIndex = 15;
            // 
            // tabPageLabour
            // 
            this.tabPageLabour.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            this.tabPageLabour.Controls.Add(this.dataGridViewLabour);
            this.tabPageLabour.Location = new System.Drawing.Point(4, 23);
            this.tabPageLabour.Name = "tabPageLabour";
            this.tabPageLabour.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLabour.Size = new System.Drawing.Size(746, 390);
            this.tabPageLabour.TabIndex = 0;
            this.tabPageLabour.Text = "Labour";
            // 
            // tabPageEquipment
            // 
            this.tabPageEquipment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            this.tabPageEquipment.Controls.Add(this.dataGridViewEquipment);
            this.tabPageEquipment.Location = new System.Drawing.Point(4, 23);
            this.tabPageEquipment.Name = "tabPageEquipment";
            this.tabPageEquipment.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEquipment.Size = new System.Drawing.Size(746, 390);
            this.tabPageEquipment.TabIndex = 1;
            this.tabPageEquipment.Text = "Equipment";
            // 
            // tabPageMaterials
            // 
            this.tabPageMaterials.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            this.tabPageMaterials.Controls.Add(this.dataGridViewMaterials);
            this.tabPageMaterials.Location = new System.Drawing.Point(4, 23);
            this.tabPageMaterials.Name = "tabPageMaterials";
            this.tabPageMaterials.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMaterials.Size = new System.Drawing.Size(746, 390);
            this.tabPageMaterials.TabIndex = 2;
            this.tabPageMaterials.Text = "Materials";
            // 
            // tabPageSuppliers
            // 
            this.tabPageSuppliers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            this.tabPageSuppliers.Controls.Add(this.dataGridViewSuppliers);
            this.tabPageSuppliers.Location = new System.Drawing.Point(4, 23);
            this.tabPageSuppliers.Name = "tabPageSuppliers";
            this.tabPageSuppliers.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSuppliers.Size = new System.Drawing.Size(746, 390);
            this.tabPageSuppliers.TabIndex = 3;
            this.tabPageSuppliers.Text = "Suppliers";
            // 
            // tabPageAdmin
            // 
            this.tabPageAdmin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            this.tabPageAdmin.Controls.Add(this.dataGridViewAdmin);
            this.tabPageAdmin.Location = new System.Drawing.Point(4, 23);
            this.tabPageAdmin.Name = "tabPageAdmin";
            this.tabPageAdmin.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAdmin.Size = new System.Drawing.Size(746, 390);
            this.tabPageAdmin.TabIndex = 4;
            this.tabPageAdmin.Text = "Admin";
            // 
            // tabPageOther
            // 
            this.tabPageOther.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            this.tabPageOther.Controls.Add(this.dataGridViewOther);
            this.tabPageOther.Location = new System.Drawing.Point(4, 23);
            this.tabPageOther.Name = "tabPageOther";
            this.tabPageOther.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOther.Size = new System.Drawing.Size(746, 390);
            this.tabPageOther.TabIndex = 5;
            this.tabPageOther.Text = "Other";
            // 
            // dataGridViewLabour
            // 
            this.dataGridViewLabour.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewLabour.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLabour.Location = new System.Drawing.Point(6, 6);
            this.dataGridViewLabour.Name = "dataGridViewLabour";
            this.dataGridViewLabour.Size = new System.Drawing.Size(734, 378);
            this.dataGridViewLabour.TabIndex = 5;
            // 
            // FinacialPlanDocumentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(800, 507);
            this.Controls.Add(this.btnSaveProjectName);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.txtProjectName);
            this.Controls.Add(this.lblProjectName);
            this.Font = new System.Drawing.Font("Helvetica Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "FinacialPlanDocumentForm";
            this.Text = "FinacialPlanDocumentForm";
            this.tabControl1.ResumeLayout(false);
            this.tabPageDocumentControl.ResumeLayout(false);
            this.tabPageDocumentControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDocumentApprovals)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDocumentHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDocumentInformation)).EndInit();
            this.tabPageFinancialExpenses.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOther)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAdmin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSuppliers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMaterials)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEquipment)).EndInit();
            this.tabPageFinancialPlan.ResumeLayout(false);
            this.tabPageFinancialPlan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPageFinancialProcess.ResumeLayout(false);
            this.tabPageFinancialProcess.PerformLayout();
            this.tabControlFinancialExpense.ResumeLayout(false);
            this.tabPageLabour.ResumeLayout(false);
            this.tabPageEquipment.ResumeLayout(false);
            this.tabPageMaterials.ResumeLayout(false);
            this.tabPageSuppliers.ResumeLayout(false);
            this.tabPageAdmin.ResumeLayout(false);
            this.tabPageOther.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLabour)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblProjectName;
        private System.Windows.Forms.TextBox txtProjectName;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageDocumentControl;
        private System.Windows.Forms.TabPage tabPageFinancialExpenses;
        private System.Windows.Forms.Label lblDocApprovs;
        private System.Windows.Forms.Label lblDocHist;
        private System.Windows.Forms.Label lblDocInfo;
        private System.Windows.Forms.DataGridView dataGridViewDocumentApprovals;
        private System.Windows.Forms.DataGridView dataGridViewDocumentHistory;
        private System.Windows.Forms.DataGridView dataGridViewDocumentInformation;
        private System.Windows.Forms.DataGridView dataGridViewOther;
        private System.Windows.Forms.DataGridView dataGridViewAdmin;
        private System.Windows.Forms.DataGridView dataGridViewSuppliers;
        private System.Windows.Forms.DataGridView dataGridViewMaterials;
        private System.Windows.Forms.DataGridView dataGridViewEquipment;
        private System.Windows.Forms.TabPage tabPageFinancialPlan;
        private System.Windows.Forms.Label lblAssumption;
        private System.Windows.Forms.Label lblConstraints;
        private System.Windows.Forms.TextBox txtAssumptions;
        private System.Windows.Forms.TextBox txtConstraints;
        private System.Windows.Forms.Label lblSchedule;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabPage tabPageFinancialProcess;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDocuments;
        private System.Windows.Forms.TextBox txtRoles;
        private System.Windows.Forms.TextBox txtActivities;
        private System.Windows.Forms.TabPage tabPageAppendix;
        private System.Windows.Forms.Button btnSaveConstraints;
        private System.Windows.Forms.Button btnSaveAssumptions;
        private System.Windows.Forms.Button btnSaveActivitiesRolesDocuments;
        private System.Windows.Forms.Button btnSaveProjectName;
        private System.Windows.Forms.TabControl tabControlFinancialExpense;
        private System.Windows.Forms.TabPage tabPageLabour;
        private System.Windows.Forms.DataGridView dataGridViewLabour;
        private System.Windows.Forms.TabPage tabPageEquipment;
        private System.Windows.Forms.TabPage tabPageMaterials;
        private System.Windows.Forms.TabPage tabPageSuppliers;
        private System.Windows.Forms.TabPage tabPageAdmin;
        private System.Windows.Forms.TabPage tabPageOther;
    }
}