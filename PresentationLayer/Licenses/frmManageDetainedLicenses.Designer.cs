﻿namespace PresentationLayer
{
    partial class frmManageDetainedLicenses
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManageDetainedLicenses));
            this.tsmShowPersonDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmShowLicenseDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmShowLicenseHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmReleaseLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsDetainedLicenses = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnClose = new System.Windows.Forms.Button();
            this.DetainedLicensesPage = new PresentationLayer.ctrlDataPage();
            this.cmsDetainedLicenses.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsmShowPersonDetails
            // 
            this.tsmShowPersonDetails.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmShowPersonDetails.Image = global::PresentationLayer.Properties.Resources.information;
            this.tsmShowPersonDetails.Name = "tsmShowPersonDetails";
            this.tsmShowPersonDetails.Size = new System.Drawing.Size(375, 36);
            this.tsmShowPersonDetails.Text = "Show Person Details";
            this.tsmShowPersonDetails.Click += new System.EventHandler(this.tsmShowPersonDetails_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(372, 6);
            // 
            // tsmShowLicenseDetails
            // 
            this.tsmShowLicenseDetails.Font = new System.Drawing.Font("Segoe UI", 13.8F);
            this.tsmShowLicenseDetails.Image = global::PresentationLayer.Properties.Resources.licence;
            this.tsmShowLicenseDetails.Name = "tsmShowLicenseDetails";
            this.tsmShowLicenseDetails.Size = new System.Drawing.Size(375, 36);
            this.tsmShowLicenseDetails.Text = "Show License Details";
            this.tsmShowLicenseDetails.Click += new System.EventHandler(this.tsmShowLicenseDetails_Click);
            // 
            // tsmShowLicenseHistory
            // 
            this.tsmShowLicenseHistory.Font = new System.Drawing.Font("Segoe UI", 13.8F);
            this.tsmShowLicenseHistory.Image = global::PresentationLayer.Properties.Resources.history;
            this.tsmShowLicenseHistory.Name = "tsmShowLicenseHistory";
            this.tsmShowLicenseHistory.Size = new System.Drawing.Size(375, 36);
            this.tsmShowLicenseHistory.Text = "Show Person License History";
            this.tsmShowLicenseHistory.Click += new System.EventHandler(this.tsmShowLicenseHistory_Click);
            // 
            // tsmReleaseLicense
            // 
            this.tsmReleaseLicense.Font = new System.Drawing.Font("Segoe UI", 13.8F);
            this.tsmReleaseLicense.Image = global::PresentationLayer.Properties.Resources.unboxing;
            this.tsmReleaseLicense.Name = "tsmReleaseLicense";
            this.tsmReleaseLicense.Size = new System.Drawing.Size(375, 36);
            this.tsmReleaseLicense.Text = "Release License";
            this.tsmReleaseLicense.Click += new System.EventHandler(this.tsmReleaseLicense_Click);
            // 
            // cmsDetainedLicenses
            // 
            this.cmsDetainedLicenses.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsDetainedLicenses.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmShowPersonDetails,
            this.toolStripSeparator2,
            this.tsmShowLicenseDetails,
            this.tsmShowLicenseHistory,
            this.tsmReleaseLicense});
            this.cmsDetainedLicenses.Name = "cmsDrivers";
            this.cmsDetainedLicenses.Size = new System.Drawing.Size(376, 182);
            this.cmsDetainedLicenses.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(this.cmsDetainedLicenses_Closed);
            this.cmsDetainedLicenses.Opened += new System.EventHandler(this.cmsDetainedLicenses_Opened);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(1056, 522);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(163, 35);
            this.btnClose.TabIndex = 22;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // DetainedLicensesPage
            // 
            this.DetainedLicensesPage.Location = new System.Drawing.Point(1, 0);
            this.DetainedLicensesPage.Name = "DetainedLicensesPage";
            this.DetainedLicensesPage.Size = new System.Drawing.Size(1246, 575);
            this.DetainedLicensesPage.TabIndex = 23;
            this.DetainedLicensesPage.Title = "Detained Licenses";
            // 
            // frmManageDetainedLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1254, 573);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.DetainedLicensesPage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmManageDetainedLicenses";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Detained Licenses";
            this.Load += new System.EventHandler(this.frmManageDetainedLicenses_Load);
            this.cmsDetainedLicenses.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem tsmShowPersonDetails;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmShowLicenseDetails;
        private System.Windows.Forms.ToolStripMenuItem tsmShowLicenseHistory;
        private System.Windows.Forms.ToolStripMenuItem tsmReleaseLicense;
        private System.Windows.Forms.ContextMenuStrip cmsDetainedLicenses;
        private System.Windows.Forms.Button btnClose;
        private ctrlDataPage DetainedLicensesPage;
    }
}