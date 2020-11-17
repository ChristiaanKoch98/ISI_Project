
namespace ProjectManagementToolkit.MPMM.MPMM_Document_Forms
{
    partial class ProcurementRegister
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
            this.txtProjectManagerName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.txtProcurementRegisterProjectName = new System.Windows.Forms.TextBox();
            this.txtProcurementManager = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvProcurementRegister = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProcurementRegister)).BeginInit();
            this.SuspendLayout();
            // 
            // txtProjectManagerName
            // 
            this.txtProjectManagerName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.txtProjectManagerName.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProjectManagerName.ForeColor = System.Drawing.Color.White;
            this.txtProjectManagerName.Location = new System.Drawing.Point(287, 41);
            this.txtProjectManagerName.Margin = new System.Windows.Forms.Padding(4);
            this.txtProjectManagerName.Name = "txtProjectManagerName";
            this.txtProjectManagerName.Size = new System.Drawing.Size(190, 24);
            this.txtProjectManagerName.TabIndex = 31;
            this.txtProjectManagerName.TextChanged += new System.EventHandler(this.txtProjectManagerName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(13, 44);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 16);
            this.label1.TabIndex = 30;
            this.label1.Text = "Please Enter Project Manager Name:";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.White;
            this.label27.Location = new System.Drawing.Point(13, 9);
            this.label27.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(204, 16);
            this.label27.TabIndex = 29;
            this.label27.Text = "Please Enter Your Project Name:";
            // 
            // txtProcurementRegisterProjectName
            // 
            this.txtProcurementRegisterProjectName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.txtProcurementRegisterProjectName.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProcurementRegisterProjectName.ForeColor = System.Drawing.Color.White;
            this.txtProcurementRegisterProjectName.Location = new System.Drawing.Point(287, 6);
            this.txtProcurementRegisterProjectName.Margin = new System.Windows.Forms.Padding(4);
            this.txtProcurementRegisterProjectName.Name = "txtProcurementRegisterProjectName";
            this.txtProcurementRegisterProjectName.Size = new System.Drawing.Size(190, 24);
            this.txtProcurementRegisterProjectName.TabIndex = 28;
            this.txtProcurementRegisterProjectName.Text = "Project Name";
            // 
            // txtProcurementManager
            // 
            this.txtProcurementManager.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.txtProcurementManager.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProcurementManager.ForeColor = System.Drawing.Color.White;
            this.txtProcurementManager.Location = new System.Drawing.Point(287, 81);
            this.txtProcurementManager.Margin = new System.Windows.Forms.Padding(4);
            this.txtProcurementManager.Name = "txtProcurementManager";
            this.txtProcurementManager.Size = new System.Drawing.Size(190, 24);
            this.txtProcurementManager.TabIndex = 33;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(13, 81);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(266, 16);
            this.label2.TabIndex = 32;
            this.label2.Text = "Please Enter Procurement Manager Name:";
            // 
            // dgvProcurementRegister
            // 
            this.dgvProcurementRegister.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProcurementRegister.Location = new System.Drawing.Point(16, 125);
            this.dgvProcurementRegister.Name = "dgvProcurementRegister";
            this.dgvProcurementRegister.RowHeadersWidth = 51;
            this.dgvProcurementRegister.RowTemplate.Height = 24;
            this.dgvProcurementRegister.Size = new System.Drawing.Size(902, 406);
            this.dgvProcurementRegister.TabIndex = 34;
            // 
            // ProcurementRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(930, 543);
            this.Controls.Add(this.dgvProcurementRegister);
            this.Controls.Add(this.txtProcurementManager);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtProjectManagerName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.txtProcurementRegisterProjectName);
            this.Name = "ProcurementRegister";
            this.Text = "Procurement Register";
            ((System.ComponentModel.ISupportInitialize)(this.dgvProcurementRegister)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtProjectManagerName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox txtProcurementRegisterProjectName;
        private System.Windows.Forms.TextBox txtProcurementManager;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvProcurementRegister;
    }
}