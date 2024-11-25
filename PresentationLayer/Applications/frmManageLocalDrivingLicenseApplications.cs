﻿using BusinessLayer;
using PresentationLayer.Applications;
using PresentationLayer.Global_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class frmManageLocalDrivingLicenseApplications : Form
    {
        public frmManageLocalDrivingLicenseApplications()
        {
            InitializeComponent();
        }

        private void frmManageLocalDrivingLicenseApplications_Load(object sender, EventArgs e)
        {
            LocalLicenseApplicationsPage.SetAddNewClickEventHandler(AddNewApplication_Click);
            FormatLayout();
        }

        private void FormatLayout()
        {
            DataGridView dgv = LocalLicenseApplicationsPage.Controls.OfType<DataGridView>().FirstOrDefault();
            if (dgv != null && dgv.RowCount > 0)
            {
                dgv.Columns["DrivingClass"].HeaderText = "Driving Class";
                dgv.Columns["NationalNo"].HeaderText = "National No";
                dgv.Columns["FullName"].HeaderText = "Full Name";
                dgv.Columns["ApplicationDate"].HeaderText = "Application Date";
                dgv.Columns["PassedTests"].HeaderText = "Passed Tests";
                dgv.Columns["ApplicationStatus"].HeaderText = "Application Status";

                clsUtils.dgvWidth = dgv.Width - dgv.RowHeadersWidth;

                dgv.Columns["L.D.L.AppID"].Width = clsUtils.SetCellWidth(10);
                dgv.Columns["DrivingClass"].Width = clsUtils.SetCellWidth(20);
                dgv.Columns["NationalNo"].Width = clsUtils.SetCellWidth(10);
                dgv.Columns["FullName"].Width = clsUtils.SetCellWidth(25);
                dgv.Columns["ApplicationDate"].Width = clsUtils.SetCellWidth(15);
                dgv.Columns["PassedTests"].Width = clsUtils.SetCellWidth(10);
                dgv.Columns["ApplicationStatus"].Width = clsUtils.SetCellWidth(10);

                dgv.ContextMenuStrip = cmsLocalLicences;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddNewApplication_Click(object sender, EventArgs e)
        {
            frmNewLocalDrivingLicenseApplication NewApplication = new frmNewLocalDrivingLicenseApplication();
            NewApplication.ShowDialog();
            LocalLicenseApplicationsPage.RefreshData();
        }

        private void tsmShowApplicationDetails_Click(object sender, EventArgs e)
        {
            frmLDLApplicatinoInfo LDLApplicatinoInfo = new frmLDLApplicatinoInfo((int)LocalLicenseApplicationsPage.dgv.CurrentRow.Cells[0].Value);
            LDLApplicatinoInfo.ShowDialog();
        }

        private void tsmCancelApplication_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to cancel this application?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) != DialogResult.OK)
            {
                return;
            }

            clsLocalDrivingLicensApplication LDLApplicationDetails = clsLocalDrivingLicensApplication.FindLocalDrivingLicenseApplicationByID((int)LocalLicenseApplicationsPage.dgv.CurrentRow.Cells[0].Value);

            if (LDLApplicationDetails.Application.ApplicationStatus == "New")
            {
                if (LDLApplicationDetails.Cancel())
                {
                    MessageBox.Show("Application Cancelled Successfully!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Something went wrong!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                LocalLicenseApplicationsPage.RefreshData();

            } else if (LDLApplicationDetails.Application.ApplicationStatus == "Completed")
            {
                MessageBox.Show("You can't cancell a complete application!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {
                MessageBox.Show("The application is already cancelled", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsmDeleteApplication_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to delete this application?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) != DialogResult.OK)
            {
                return;
            }

            clsLocalDrivingLicensApplication LDLApplicationDetails = clsLocalDrivingLicensApplication.FindLocalDrivingLicenseApplicationByID((int)LocalLicenseApplicationsPage.dgv.CurrentRow.Cells[0].Value);

            if (LDLApplicationDetails.Application.ApplicationStatus != "Completed")
            {
                if (LDLApplicationDetails.Delete())
                {
                    MessageBox.Show("Application Deleted Successfully!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("You can't delete an application that has active tests!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                LocalLicenseApplicationsPage.RefreshData();
            } else
            {
                MessageBox.Show("You can't delete a completed application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsmScheduleVisionTest_Click(object sender, EventArgs e)
        {
            frmTestAppointment TestAppointment = new frmTestAppointment((int)LocalLicenseApplicationsPage.dgv.CurrentRow.Cells[0].Value, 1);
            TestAppointment.ShowDialog();
            LocalLicenseApplicationsPage.RefreshData();
        }

        private void tsmScheduleWrittenTest_Click(object sender, EventArgs e)
        {
            frmTestAppointment TestAppointment = new frmTestAppointment((int)LocalLicenseApplicationsPage.dgv.CurrentRow.Cells[0].Value, 2);
            TestAppointment.ShowDialog();
            LocalLicenseApplicationsPage.RefreshData();
        }

        private void tsmScheduleStreetTest_Click(object sender, EventArgs e)
        {
            frmTestAppointment TestAppointment = new frmTestAppointment((int)LocalLicenseApplicationsPage.dgv.CurrentRow.Cells[0].Value, 3);
            TestAppointment.ShowDialog();
            LocalLicenseApplicationsPage.RefreshData();
        }
        
        private void tsmIssueDrivingLicenseFirstTime_Click(object sender, EventArgs e)
        {
            frmIssueLocalLicense IssueLicense = new frmIssueLocalLicense((int)LocalLicenseApplicationsPage.dgv.CurrentRow.Cells[0].Value);
            IssueLicense.ShowDialog();
            LocalLicenseApplicationsPage.RefreshData();
        }

        private void tsmShowLicense_Click(object sender, EventArgs e)
        {
            int LDLApplicationID = (int)LocalLicenseApplicationsPage.dgv.CurrentRow.Cells[0].Value;
            clsLicense License = clsLicense.FindLicenseByLocalDrivingLicenseApplicationID(LDLApplicationID);

            frmLicenseDetails LicenseDetails = new frmLicenseDetails(License.LicenseID);
            LicenseDetails.ShowDialog();
        }

        private void tsmShowPersonLicenseHistory_Click(object sender, EventArgs e)
        {
            frmLicenseHistory LicenseHistory = new frmLicenseHistory((string)LocalLicenseApplicationsPage.dgv.CurrentRow.Cells[2].Value);
            LicenseHistory.ShowDialog();
        }

        private void cmsLocalLicences_Opened(object sender, EventArgs e)
        {
            int PassedTests = (int)LocalLicenseApplicationsPage.dgv.CurrentRow.Cells[4].Value;
            string ApplicationStatus = (string)LocalLicenseApplicationsPage.dgv.CurrentRow.Cells[6].Value;

            if (ApplicationStatus == "New")
            {
                if (PassedTests < 3)
                {
                    tsmScheduleTests.Enabled = true;

                    if (PassedTests == 0)
                    {
                        tsmScheduleVisionTest.Enabled = true;
                    }
                    else if (PassedTests == 1)
                    {
                        tsmScheduleWrittenTest.Enabled = true;
                    }
                    else if (PassedTests == 2)
                    {
                        tsmScheduleStreetTest.Enabled = true;
                    }
                }
                else if (PassedTests == 3)
                {
                    tsmIssueDrivingLicenseFirstTime.Enabled = true;
                }
            }
            else if (ApplicationStatus == "Completed")
            {
                tsmCancelApplication.Enabled = false;
                tsmDeleteApplication.Enabled = false;

                tsmShowLicense.Enabled = true;
                tsmShowPersonLicenseHistory.Enabled = true;
            }
            else if (ApplicationStatus == "Cancelled")
            {
                tsmCancelApplication.Enabled = false;

                tsmShowLicense.Enabled = false;
                tsmShowPersonLicenseHistory.Enabled = true;
            }
        }
        private void cmsLocalLicences_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            //Default settings
            tsmCancelApplication.Enabled = true;
            tsmDeleteApplication.Enabled = true;

            tsmScheduleTests.Enabled = false;

            tsmScheduleVisionTest.Enabled = false;
            tsmScheduleWrittenTest.Enabled = false;
            tsmScheduleStreetTest.Enabled = false;

            tsmIssueDrivingLicenseFirstTime.Enabled = false;

            tsmShowLicense.Enabled = false;
            tsmShowPersonLicenseHistory.Enabled = false;
        }

    }
}
