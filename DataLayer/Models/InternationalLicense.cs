using System;
using System.Collections.Generic;

namespace DataLayer.Models;

public partial class InternationalLicense
{
    public int InternationalLicenseId { get; set; }

    public int ApplicationId { get; set; }

    public int DriverId { get; set; }

    public int IssuedUsingLocalLicenseId { get; set; }

    public DateTime IssueDate { get; set; }

    public DateTime ExpirationDate { get; set; }

    public bool IsActive { get; set; }

    public int CreatedByUserId { get; set; }

    public virtual Application Application { get; set; }

    public virtual User CreatedByUser { get; set; }

    public virtual Driver Driver { get; set; }

    public virtual License IssuedUsingLocalLicense { get; set; }
}
