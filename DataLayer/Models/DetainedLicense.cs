using System;
using System.Collections.Generic;

namespace DataLayer.Models;

public partial class DetainedLicense
{
    public int DetainId { get; set; }

    public int LicenseId { get; set; }

    public DateTime DetainDate { get; set; }

    public decimal FineFees { get; set; }

    public int CreatedByUserId { get; set; }

    public bool IsReleased { get; set; }

    public DateTime? ReleaseDate { get; set; }

    public int? ReleasedByUserId { get; set; }

    public int? ReleaseApplicationId { get; set; }

    public virtual User CreatedByUser { get; set; }

    public virtual License License { get; set; }

    public virtual Application ReleaseApplication { get; set; }

    public virtual User ReleasedByUser { get; set; }
}
