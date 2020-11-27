namespace ProjectManagementToolkit.MPMM.MPMM_Document_Forms
{
    partial class ExpenseFormDocumentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExpenseFormDocumentForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnSave = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.txtapprovaldetails = new System.Windows.Forms.TextBox();
            this.txtprojectdetailsContent = new System.Windows.Forms.TextBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.expensedetailsActivityID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expensedetailsTaskID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expensedetailsExpenseDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expensedetailsExpenseType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.detailsExpenseDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.detailsExpenseAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expensedetailsPayeeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expensedetailsInvoiceNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnExportWord = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(3, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(922, 476);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.tabPage1.Controls.Add(this.btnExportWord);
            this.tabPage1.Controls.Add(this.btnSave);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label27);
            this.tabPage1.Controls.Add(this.txtapprovaldetails);
            this.tabPage1.Controls.Add(this.txtprojectdetailsContent);
            this.tabPage1.Controls.Add(this.dataGridView2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(914, 450);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "EXPENSE FORM";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(774, 5);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(134, 22);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(140, 234);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 19);
            this.label4.TabIndex = 15;
            this.label4.Text = "APPROVAL DETAILS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(140, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 19);
            this.label2.TabIndex = 14;
            this.label2.Text = "EXPENSE DETAILS";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(140, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 19);
            this.label1.TabIndex = 13;
            this.label1.Text = "PROJECT DETAILS";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.White;
            this.label27.Location = new System.Drawing.Point(142, 282);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(0, 12);
            this.label27.TabIndex = 12;
            this.label27.Click += new System.EventHandler(this.label27_Click);
            // 
            // txtapprovaldetails
            // 
            this.txtapprovaldetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.txtapprovaldetails.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtapprovaldetails.ForeColor = System.Drawing.Color.White;
            this.txtapprovaldetails.Location = new System.Drawing.Point(144, 256);
            this.txtapprovaldetails.Multiline = true;
            this.txtapprovaldetails.Name = "txtapprovaldetails";
            this.txtapprovaldetails.Size = new System.Drawing.Size(719, 188);
            this.txtapprovaldetails.TabIndex = 10;
            this.txtapprovaldetails.Text = resources.GetString("txtapprovaldetails.Text");
            this.txtapprovaldetails.TextChanged += new System.EventHandler(this.textBox8_TextChanged);
            // 
            // txtprojectdetailsContent
            // 
            this.txtprojectdetailsContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.txtprojectdetailsContent.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtprojectdetailsContent.ForeColor = System.Drawing.Color.White;
            this.txtprojectdetailsContent.Location = new System.Drawing.Point(144, 38);
            this.txtprojectdetailsContent.Multiline = true;
            this.txtprojectdetailsContent.Name = "txtprojectdetailsContent";
            this.txtprojectdetailsContent.Size = new System.Drawing.Size(719, 76);
            this.txtprojectdetailsContent.TabIndex = 6;
            this.txtprojectdetailsContent.Text = "\r\nProject Name:\r\nProject Manager:\r\nTeam Member:";
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.expensedetailsActivityID,
            this.expensedetailsTaskID,
            this.expensedetailsExpenseDate,
            this.expensedetailsExpenseType,
            this.detailsExpenseDescription,
            this.detailsExpenseAmount,
            this.expensedetailsPayeeName,
            this.expensedetailsInvoiceNumber});
            this.dataGridView2.Location = new System.Drawing.Point(144, 134);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.Size = new System.Drawing.Size(719, 97);
            this.dataGridView2.TabIndex = 1;
            // 
            // expensedetailsActivityID
            // 
            this.expensedetailsActivityID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.expensedetailsActivityID.HeaderText = "Activity ID";
            this.expensedetailsActivityID.MinimumWidth = 6;
            this.expensedetailsActivityID.Name = "expensedetailsActivityID";
            // 
            // expensedetailsTaskID
            // 
            this.expensedetailsTaskID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.expensedetailsTaskID.HeaderText = "Task ID";
            this.expensedetailsTaskID.MinimumWidth = 6;
            this.expensedetailsTaskID.Name = "expensedetailsTaskID";
            // 
            // expensedetailsExpenseDate
            // 
            this.expensedetailsExpenseDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.expensedetailsExpenseDate.HeaderText = "Expense Date";
            this.expensedetailsExpenseDate.MinimumWidth = 6;
            this.expensedetailsExpenseDate.Name = "expensedetailsExpenseDate";
            // 
            // expensedetailsExpenseType
            // 
            this.expensedetailsExpenseType.HeaderText = "Expense Type";
            this.expensedetailsExpenseType.Name = "expensedetailsExpenseType";
            // 
            // detailsExpenseDescription
            // 
            this.detailsExpenseDescription.HeaderText = "Expense Description";
            this.detailsExpenseDescription.Name = "detailsExpenseDescription";
            // 
            // detailsExpenseAmount
            // 
            this.detailsExpenseAmount.HeaderText = "Expense Amount";
            this.detailsExpenseAmount.Name = "detailsExpenseAmount";
            // 
            // expensedetailsPayeeName
            // 
            this.expensedetailsPayeeName.HeaderText = "Payee Name";
            this.expensedetailsPayeeName.Name = "expensedetailsPayeeName";
            // 
            // expensedetailsInvoiceNumber
            // 
            this.expensedetailsInvoiceNumber.HeaderText = "Invoice Number";
            this.expensedetailsInvoiceNumber.Name = "expensedetailsInvoiceNumber";
            // 
            // btnExportWord
            // 
            this.btnExportWord.Location = new System.Drawing.Point(636, 5);
            this.btnExportWord.Margin = new System.Windows.Forms.Padding(2);
            this.btnExportWord.Name = "btnExportWord";
            this.btnExportWord.Size = new System.Drawing.Size(134, 22);
            this.btnExportWord.TabIndex = 16;
            this.btnExportWord.Text = "Export to Word";
            this.btnExportWord.UseVisualStyleBackColor = true;
            this.btnExportWord.Click += new System.EventHandler(this.btnExportWord_Click);
            // 
            // ExpenseFormDocumentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 514);
            this.Controls.Add(this.tabControl1);
            this.Name = "ExpenseFormDocumentForm";
            this.Text = "ua";
            this.Load += new System.EventHandler(this.ExpenseFormDocumentForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TextBox txtprojectdetailsContent;
        private System.Windows.Forms.TextBox txtapprovaldetails;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn expensedetailsActivityID;
        private System.Windows.Forms.DataGridViewTextBoxColumn expensedetailsTaskID;
        private System.Windows.Forms.DataGridViewTextBoxColumn expensedetailsExpenseDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn expensedetailsExpenseType;
        private System.Windows.Forms.DataGridViewTextBoxColumn detailsExpenseDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn detailsExpenseAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn expensedetailsPayeeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn expensedetailsInvoiceNumber;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExportWord;
    }
}