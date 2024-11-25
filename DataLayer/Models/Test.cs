using System;
using System.Collections.Generic;

namespace DataLayer.Models;

public partial class Test
{
    public int TestId { get; set; }

    public int TestAppointmentId { get; set; }

    /// <summary>
    /// 0 - Fail 1-Pass
    /// </summary>
    public bool TestResult { get; set; }

    public string Notes { get; set; }

    public int CreatedByUserId { get; set; }

    public virtual User CreatedByUser { get; set; }

    public virtual TestAppointment TestAppointment { get; set; }
}
