using System;
using System.Collections.Generic;

namespace DataLayer.Models;

public partial class TestType
{
    public int TestTypeId { get; set; }

    public string TestTypeTitle { get; set; }

    public string TestTypeDescription { get; set; }

    public decimal TestTypeFees { get; set; }

    public virtual ICollection<TestAppointment> TestAppointments { get; set; } = new List<TestAppointment>();
}
