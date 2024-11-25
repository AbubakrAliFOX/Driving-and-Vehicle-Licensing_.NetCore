﻿using System;
using System.Collections.Generic;

namespace DataLayer.Models;

public partial class LocalDrivingLicenseApplicationsView
{
    public int LocalDrivingLicenseApplicationId { get; set; }

    public string ClassName { get; set; }

    public string NationalNo { get; set; }

    public string FullName { get; set; }

    public DateTime ApplicationDate { get; set; }

    public int? PassedTestCount { get; set; }

    public string Status { get; set; }
}
