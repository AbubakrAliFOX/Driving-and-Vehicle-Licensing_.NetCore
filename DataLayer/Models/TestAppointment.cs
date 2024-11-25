using System;
using System.Collections.Generic;

namespace DataLayer.Models;

public partial class TestAppointment
{
    public int TestAppointmentId { get; set; }

    public int TestTypeId { get; set; }

    public int LocalDrivingLicenseApplicationId { get; set; }

    public DateTime AppointmentDate { get; set; }

    public decimal PaidFees { get; set; }

    public int CreatedByUserId { get; set; }

    public bool IsLocked { get; set; }

    public int? RetakeTestApplicationId { get; set; }

    public virtual User CreatedByUser { get; set; }

    public virtual LocalDrivingLicenseApplication LocalDrivingLicenseApplication { get; set; }

    public virtual TestType TestType { get; set; }

    public virtual ICollection<Test> Tests { get; set; } = new List<Test>();
}
