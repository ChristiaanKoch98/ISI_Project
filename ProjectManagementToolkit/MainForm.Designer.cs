﻿namespace ProjectManagementToolkit
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mPMMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.governanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.assetAndInventoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.assetAndInventoryToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.informationTechnologyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.mPMMToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(116, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // mPMMToolStripMenuItem
            // 
            this.mPMMToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.governanceToolStripMenuItem,
            this.assetAndInventoryToolStripMenuItem});
            this.mPMMToolStripMenuItem.Name = "mPMMToolStripMenuItem";
            this.mPMMToolStripMenuItem.Size = new System.Drawing.Size(70, 24);
            this.mPMMToolStripMenuItem.Text = "MPMM";
            // 
            // governanceToolStripMenuItem
            // 
            this.governanceToolStripMenuItem.Name = "governanceToolStripMenuItem";
            this.governanceToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.governanceToolStripMenuItem.Text = "Governance";
            this.governanceToolStripMenuItem.Click += new System.EventHandler(this.governanceToolStripMenuItem_Click);
            // 
            // assetAndInventoryToolStripMenuItem
            // 
            this.assetAndInventoryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.assetAndInventoryToolStripMenuItem1,
            this.informationTechnologyToolStripMenuItem});
            this.assetAndInventoryToolStripMenuItem.Name = "assetAndInventoryToolStripMenuItem";
            this.assetAndInventoryToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.assetAndInventoryToolStripMenuItem.Text = "Management";
            // 
            // assetAndInventoryToolStripMenuItem1
            // 
            this.assetAndInventoryToolStripMenuItem1.Name = "assetAndInventoryToolStripMenuItem1";
            this.assetAndInventoryToolStripMenuItem1.Size = new System.Drawing.Size(250, 26);
            this.assetAndInventoryToolStripMenuItem1.Text = "Asset and Inventory";
            this.assetAndInventoryToolStripMenuItem1.Click += new System.EventHandler(this.assetAndInventoryToolStripMenuItem1_Click);
            // 
            // informationTechnologyToolStripMenuItem
            // 
            this.informationTechnologyToolStripMenuItem.Name = "informationTechnologyToolStripMenuItem";
            this.informationTechnologyToolStripMenuItem.Size = new System.Drawing.Size(250, 26);
            this.informationTechnologyToolStripMenuItem.Text = "Information Technology";
            this.informationTechnologyToolStripMenuItem.Click += new System.EventHandler(this.informationTechnologyToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mPMMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem governanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem assetAndInventoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem assetAndInventoryToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem informationTechnologyToolStripMenuItem;
    }
}