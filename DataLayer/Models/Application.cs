﻿using System;
using System.Collections.Generic;

namespace DataLayer.Models;

public partial class Application
{
    public int ApplicationId { get; set; }

    public int ApplicantPersonId { get; set; }

    public DateTime ApplicationDate { get; set; }

    public int ApplicationTypeId { get; set; }

    /// <summary>
    /// 1-New 2-Cancelled 3-Completed
    /// </summary>
    public byte ApplicationStatus { get; set; }

    public DateTime LastStatusDate { get; set; }

    public decimal PaidFees { get; set; }

    public int CreatedByUserId { get; set; }

    public virtual Person ApplicantPerson { get; set; }

    public virtual ApplicationType ApplicationType { get; set; }

    public virtual User CreatedByUser { get; set; }

    public virtual ICollection<DetainedLicense> DetainedLicenses { get; set; } = new List<DetainedLicense>();

    public virtual ICollection<InternationalLicense> InternationalLicenses { get; set; } = new List<InternationalLicense>();

    public virtual ICollection<License> Licenses { get; set; } = new List<License>();

    public virtual ICollection<LocalDrivingLicenseApplication> LocalDrivingLicenseApplications { get; set; } = new List<LocalDrivingLicenseApplication>();
}
