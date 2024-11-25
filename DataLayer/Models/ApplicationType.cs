using System;
using System.Collections.Generic;

namespace DataLayer.Models;

public partial class ApplicationType
{
    public int ApplicationTypeId { get; set; }

    public string ApplicationTypeTitle { get; set; }

    public decimal ApplicationFees { get; set; }

    public virtual ICollection<Application> Applications { get; set; } = new List<Application>();
}
