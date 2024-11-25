using System;
using System.Collections.Generic;

namespace DataLayer.Models;

public partial class LocalDrivingLicenseApplication
{
    public int LocalDrivingLicenseApplicationId { get; set; }

    public int ApplicationId { get; set; }

    public int LicenseClassId { get; set; }

    public virtual Application Application { get; set; }

    public virtual LicenseClass LicenseClass { get; set; }

    public virtual ICollection<TestAppointment> TestAppointments { get; set; } = new List<TestAppointment>();
}
