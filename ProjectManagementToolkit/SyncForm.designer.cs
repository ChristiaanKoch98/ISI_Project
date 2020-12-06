namespace ProjectManagementToolkit.MPMM
{
    partial class SyncForm
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
            this.syncProgressBar = new System.Windows.Forms.ProgressBar();
            this.lblProgress = new System.Windows.Forms.Label();
            this.btnSync = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // syncProgressBar
            // 
            this.syncProgressBar.Location = new System.Drawing.Point(9, 17);
            this.syncProgressBar.Margin = new System.Windows.Forms.Padding(2);
            this.syncProgressBar.Name = "syncProgressBar";
            this.syncProgressBar.Size = new System.Drawing.Size(727, 40);
            this.syncProgressBar.TabIndex = 0;
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.ForeColor = System.Drawing.Color.Black;
            this.lblProgress.Location = new System.Drawing.Point(9, 69);
            this.lblProgress.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(54, 13);
            this.lblProgress.TabIndex = 1;
            this.lblProgress.Text = "Progress: ";
            // 
            // btnSync
            // 
            this.btnSync.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(173)))), ((int)(((byte)(252)))));
            this.btnSync.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSync.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSync.ForeColor = System.Drawing.Color.Black;
            this.btnSync.Location = new System.Drawing.Point(12, 94);
            this.btnSync.Name = "btnSync";
            this.btnSync.Size = new System.Drawing.Size(93, 34);
            this.btnSync.TabIndex = 4;
            this.btnSync.Text = "Sync Now";
            this.btnSync.UseVisualStyleBackColor = false;
            this.btnSync.Click += new System.EventHandler(this.btnSync_Click);
            // 
            // SyncForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(760, 140);
            this.Controls.Add(this.btnSync);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.syncProgressBar);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SyncForm";
            this.Text = "Sync Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar syncProgressBar;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.Button btnSync;
    }
}