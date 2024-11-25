using System;
using System.Collections.Generic;

namespace DataLayer.Models;

public partial class TestsDetail
{
    public int TestId { get; set; }

    public int TestAppointmentId { get; set; }

    public bool TestResult { get; set; }

    public string Notes { get; set; }

    public int CreatedByUserId { get; set; }

    public int LocalDrivingLicenseApplicationId { get; set; }
}
