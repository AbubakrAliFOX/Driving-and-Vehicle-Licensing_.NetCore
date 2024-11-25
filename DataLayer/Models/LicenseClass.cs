﻿using System;
using System.Collections.Generic;

namespace DataLayer.Models;

public partial class LicenseClass
{
    public int LicenseClassId { get; set; }

    public string ClassName { get; set; }

    public string ClassDescription { get; set; }

    /// <summary>
    /// Minmum age allowed to apply for this license
    /// </summary>
    public byte MinimumAllowedAge { get; set; }

    /// <summary>
    /// How many years the licesnse will be valid.
    /// </summary>
    public byte DefaultValidityLength { get; set; }

    public decimal ClassFees { get; set; }

    public virtual ICollection<License> Licenses { get; set; } = new List<License>();

    public virtual ICollection<LocalDrivingLicenseApplication> LocalDrivingLicenseApplications { get; set; } = new List<LocalDrivingLicenseApplication>();
}
