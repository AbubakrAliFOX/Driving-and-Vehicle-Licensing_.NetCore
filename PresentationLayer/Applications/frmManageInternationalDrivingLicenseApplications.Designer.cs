﻿namespace PresentationLayer
{
    partial class frmManageInternationalDrivingLicenseApplications
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManageInternationalDrivingLicenseApplications));
            this.btnClose = new System.Windows.Forms.Button();
            this.cmsInternationalLicences = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmShowPersonDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmShowLicenseDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmShowPersonLicenseHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.InternationalLicenseApplicationsPage = new PresentationLayer.ctrlDataPage();
            this.cmsInternationalLicences.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(792, 424);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(122, 28);
            this.btnClose.TabIndex = 22;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cmsInternationalLicences
            // 
            this.cmsInternationalLicences.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsInternationalLicences.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmShowPersonDetails,
            this.toolStripSeparator1,
            this.tsmShowLicenseDetails,
            this.tsmShowPersonLicenseHistory});
            this.cmsInternationalLicences.Name = "cmsDrivers";
            this.cmsInternationalLicences.Size = new System.Drawing.Size(323, 100);
            // 
            // tsmShowPersonDetails
            // 
            this.tsmShowPersonDetails.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmShowPersonDetails.Image = global::PresentationLayer.Properties.Resources.information;
            this.tsmShowPersonDetails.Name = "tsmShowPersonDetails";
            this.tsmShowPersonDetails.Size = new System.Drawing.Size(322, 30);
            this.tsmShowPersonDetails.Text = "Show Person Details";
            this.tsmShowPersonDetails.Click += new System.EventHandler(this.tsmShowPersonDetails_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(319, 6);
            // 
            // tsmShowLicenseDetails
            // 
            this.tsmShowLicenseDetails.Font = new System.Drawing.Font("Segoe UI", 13.8F);
            this.tsmShowLicenseDetails.Image = global::PresentationLayer.Properties.Resources.licence;
            this.tsmShowLicenseDetails.Name = "tsmShowLicenseDetails";
            this.tsmShowLicenseDetails.Size = new System.Drawing.Size(322, 30);
            this.tsmShowLicenseDetails.Text = "Show License Details";
            this.tsmShowLicenseDetails.Click += new System.EventHandler(this.tsmShowLicenseDetails_Click);
            // 
            // tsmShowPersonLicenseHistory
            // 
            this.tsmShowPersonLicenseHistory.Font = new System.Drawing.Font("Segoe UI", 13.8F);
            this.tsmShowPersonLicenseHistory.Image = global::PresentationLayer.Properties.Resources.history;
            this.tsmShowPersonLicenseHistory.Name = "tsmShowPersonLicenseHistory";
            this.tsmShowPersonLicenseHistory.Size = new System.Drawing.Size(322, 30);
            this.tsmShowPersonLicenseHistory.Text = "Show Person License History";
            this.tsmShowPersonLicenseHistory.Click += new System.EventHandler(this.tsmShowPersonLicenseHistory_Click);
            // 
            // InternationalLicenseApplicationsPage
            // 
            this.InternationalLicenseApplicationsPage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InternationalLicenseApplicationsPage.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.InternationalLicenseApplicationsPage.Location = new System.Drawing.Point(1, 0);
            this.InternationalLicenseApplicationsPage.Margin = new System.Windows.Forms.Padding(2);
            this.InternationalLicenseApplicationsPage.Name = "InternationalLicenseApplicationsPage";
            this.InternationalLicenseApplicationsPage.Size = new System.Drawing.Size(938, 465);
            this.InternationalLicenseApplicationsPage.TabIndex = 23;
            this.InternationalLicenseApplicationsPage.Title = "International Driving Licenses";
            // 
            // frmManageInternationalDrivingLicenseApplications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 466);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.InternationalLicenseApplicationsPage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmManageInternationalDrivingLicenseApplications";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage International Driving License Applications";
            this.Load += new System.EventHandler(this.frmManageInternationalDrivingLicenseApplications_Load);
            this.cmsInternationalLicences.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ContextMenuStrip cmsInternationalLicences;
        private System.Windows.Forms.ToolStripMenuItem tsmShowPersonDetails;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmShowLicenseDetails;
        private System.Windows.Forms.ToolStripMenuItem tsmShowPersonLicenseHistory;
        private ctrlDataPage InternationalLicenseApplicationsPage;
    }
}