namespace ProjectManagementToolkit.MPMM.MPMM_Forms.Governance
{
    partial class PrinciplesandLegislationMatrix
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
            this.pictureBoxPrinciplesandLegislationMatrix = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPrinciplesandLegislationMatrix)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxPrinciplesandLegislationMatrix
            // 
            this.pictureBoxPrinciplesandLegislationMatrix.Location = new System.Drawing.Point(13, 13);
            this.pictureBoxPrinciplesandLegislationMatrix.Name = "pictureBoxPrinciplesandLegislationMatrix";
            this.pictureBoxPrinciplesandLegislationMatrix.Size = new System.Drawing.Size(775, 364);
            this.pictureBoxPrinciplesandLegislationMatrix.TabIndex = 0;
            this.pictureBoxPrinciplesandLegislationMatrix.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.btnClose.Location = new System.Drawing.Point(361, 383);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // PrinciplesandLegislationMatrix
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(800, 415);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pictureBoxPrinciplesandLegislationMatrix);
            this.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "PrinciplesandLegislationMatrix";
            this.Text = "PrinciplesandLegislationMatrix";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPrinciplesandLegislationMatrix)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxPrinciplesandLegislationMatrix;
        private System.Windows.Forms.Button btnClose;
    }
}