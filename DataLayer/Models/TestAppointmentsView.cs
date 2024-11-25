using System;
using System.Collections.Generic;

namespace DataLayer.Models;

public partial class TestAppointmentsView
{
    public int TestAppointmentId { get; set; }

    public int LocalDrivingLicenseApplicationId { get; set; }

    public string TestTypeTitle { get; set; }

    public string ClassName { get; set; }

    public DateTime AppointmentDate { get; set; }

    public decimal PaidFees { get; set; }

    public string FullName { get; set; }

    public bool IsLocked { get; set; }
}
