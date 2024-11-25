﻿using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsApplication
    {
        public int LocalDrivingLicenseApplicationID { set; get; }
        public int ApplicationID { set; get; }
        public int ApplicantID { set; get; }
        public string ApplicantName { set; get; }
        public string ApplicationType { set; get; }
        public string ApplicationStatus { set; get; }
        public string CreatedByUser { set; get; }
        public DateTime StatusDate { set; get; }
        public DateTime Date { set; get; }
        public int LicenseClassID { set; get; }
        public string LicenseClassName { set; get; }
        public decimal PaidFees { set; get; }
        public decimal ApplicationTypeFees { set; get; }

        public clsApplication()
        {
            
        }

        public clsApplication(
            int ApplicationID,
            int ApplicantID,
            string ApplicantName,
            string ApplicationType,
            string ApplicationStatus,
            string CreatedByUser,
            DateTime StatusDate,
            DateTime Date,
            decimal PaidFees
        )
        {
            this.ApplicationID = ApplicationID;
            this.ApplicantID = ApplicantID;
            this.ApplicantName = ApplicantName;
            this.ApplicationType = ApplicationType;
            this.ApplicationStatus = ApplicationStatus;
            this.CreatedByUser = CreatedByUser;
            this.StatusDate = StatusDate;
            this.Date = Date;
            this.PaidFees = PaidFees;
            this.ApplicationTypeFees = GetApplicationFees(GetApplicationTypeIDByName(ApplicationType));
        }

        public static DataTable GetApplicationTypes()
        {
            return clsApplicationsDataAccess.GetApplicationTypes();
        }
        
        public static int GetApplicationTypeIDByName(string ApplicationName)
        {
            return clsApplicationsDataAccess.GetApplicationTypeIDByName(ApplicationName);
        }
        
        public static bool UpdateApplicationType(int ApplicationID, string ApplicationTitle, decimal ApplicationFees)
        {
            return clsApplicationsDataAccess.UpdateApplicationType(ApplicationID, ApplicationTitle, ApplicationFees);
        }

        public static bool UpdateApplicationStatus(int ApplicationID, int Status)
        {
            return clsApplicationsDataAccess.UpdateApplicationStatus(ApplicationID, Status);
        }

        public static bool DeleteApplication(int ApplicationID)
        {
            return clsApplicationsDataAccess.DeleteApplicationByID(ApplicationID);
        }

        public static decimal GetApplicationFees(int ApplicationTypeID)
        {
            return clsApplicationsDataAccess.GetApplicationFees(ApplicationTypeID);
        }
        
        public static clsApplication FindApplicationByID(int ApplicationID)
        {

            int ApplicantID = -1;
            string ApplicantName = "";
            string ApplicationType = "";
            string ApplicationStatus = "";
            string CreatedByUser = "";
            DateTime StatusDate = DateTime.Now;
            DateTime Date = DateTime.Now;
            decimal Fees = 0;

            if (
                clsApplicationsDataAccess.FindApplicationByID(
                    ApplicationID,
                    ref ApplicantName,
                    ref ApplicationType,
                    ref ApplicantID,
                    ref ApplicationStatus,
                    ref CreatedByUser,
                    ref StatusDate,
                    ref Date,
                    ref Fees
                )
            )
            {
                return new clsApplication(
                    ApplicationID,
                    ApplicantID,
                    ApplicantName,
                    ApplicationType,
                    ApplicationStatus,
                    CreatedByUser,
                    StatusDate,
                    Date,
                    Fees
                );
            }
            else
            {
                return null;
            }
        }
        
        public static int CreateApplication(int PersonID, int ApplicationTypeID, int CreatedByUserID)
        {
            return clsApplicationsDataAccess.CreateApplication(PersonID, ApplicationTypeID, CreatedByUserID);
        }
    }
}
