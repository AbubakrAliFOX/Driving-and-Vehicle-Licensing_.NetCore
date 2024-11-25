﻿using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsInternationalLicense
    {
        public clsLicense LocalLicenseInfo;
        public int ILApplicationID { set; get; }
        public int InternationalLicenseID { set; get; }
        public DateTime IssueDate { set; get; }
        public DateTime ApplicationDate { set; get; }
        public DateTime ExpirationDate { set; get; }
        public decimal PaidFees { set; get; }
        public string CreatedByUser { set; get; }

        public clsInternationalLicense(int LocalLicenseID, int InternationalLicenseID, int ILApplicationID, DateTime IssueDate, DateTime ApplicationDate, DateTime ExpirationDate, decimal PaidFees, string CreatedByUser)
        {
            this.InternationalLicenseID = InternationalLicenseID;
            this.LocalLicenseInfo = clsLicense.FindLicenseByID(LocalLicenseID);
            this.ILApplicationID = ILApplicationID;
            this.IssueDate = IssueDate;
            this.ApplicationDate = ApplicationDate;
            this.ExpirationDate = ExpirationDate;
            this.PaidFees = PaidFees;
            this.CreatedByUser = CreatedByUser;
        }
        
        public static DataTable GetAllPersonLicenses(string NationalNo)
        {
            return clsInternationalLicensesDataAccess.GetAllPersonLicenses(NationalNo);
        }

        public static DataTable GetAllLicenses()
        {
            return clsInternationalLicensesDataAccess.GetAllLicenses();
        }

        public static clsInternationalLicense FindInternationalLicenseByID(int InternationalLicenseID)
        {
            int LocalLicenseID = -1;
            int ILApplicationID = -1;
            DateTime IssueDate = DateTime.Now;
            DateTime ApplicationDate = DateTime.Now;
            DateTime ExpirationDate = DateTime.Now;
            decimal PaidFees = 0;
            string CreatedByUser = "";

            if (clsInternationalLicensesDataAccess.FindInternationalLicenseByID(
                InternationalLicenseID,
                ref LocalLicenseID,
                ref ILApplicationID,
                ref IssueDate,
                ref ApplicationDate,
                ref ExpirationDate,
                ref PaidFees,
                ref CreatedByUser
            ))
            {
                return new clsInternationalLicense(LocalLicenseID, InternationalLicenseID, ILApplicationID, IssueDate, ApplicationDate, ExpirationDate, PaidFees, CreatedByUser);
            }
            else
            {
                return null;
            }
        }

        public static clsInternationalLicense FindInternationalLicenseByLocalLicenseID(int LocalLicenseID)
        {
            int InternationalLicenseID = -1;
            int ILApplicationID = -1;
            DateTime IssueDate = DateTime.Now;
            DateTime ApplicationDate = DateTime.Now;
            DateTime ExpirationDate = DateTime.Now;
            decimal PaidFees = 0;
            string CreatedByUser = "";

            if (clsInternationalLicensesDataAccess.FindInternationalLicenseByLocalLicenseID(
                LocalLicenseID,
                ref InternationalLicenseID,
                ref ILApplicationID,
                ref IssueDate,
                ref ApplicationDate,
                ref ExpirationDate,
                ref PaidFees,
                ref CreatedByUser
            ))
            {
                return new clsInternationalLicense(LocalLicenseID, InternationalLicenseID, ILApplicationID, IssueDate, ApplicationDate, ExpirationDate, PaidFees, CreatedByUser);
            }
            else
            {
                return null;
            }
        }

        public static bool HasInternationalLicense(int LocalLicenseID)
        {
            return clsLicensesDataAccess.HasInternationalLicense(LocalLicenseID);
        }

        public static int IssueInternationalLicense(int LocalLicenseID, int CreatedByUserID)
        {
            clsLicense LocalLicenseDetails = clsLicense.FindLicenseByID(LocalLicenseID);

            if (HasInternationalLicense(LocalLicenseID))
            {
                return -4;
            }

            if (!clsLicense.IsLicenseActive(LocalLicenseID))
            {
                return -3;
            } 


            if (LocalLicenseDetails.LicenseClassID != 3)
            {
                return -2;
            }

            int ApplicationID = clsApplication.CreateApplication(LocalLicenseDetails.PersonInfo.ID, 6, CreatedByUserID);
            int DriverID = LocalLicenseDetails.DriverID;

            return clsInternationalLicensesDataAccess.IssueInternationalLicense(LocalLicenseID, ApplicationID, DriverID, CreatedByUserID);
        }
    }
}
