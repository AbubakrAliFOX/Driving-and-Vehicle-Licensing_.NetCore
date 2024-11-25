using System;
using System.Collections.Generic;

namespace DataLayer.Models;

public partial class DriversView
{
    public int DriverId { get; set; }

    public int PersonId { get; set; }

    public string NationalNo { get; set; }

    public string FullName { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? NumberOfActiveLicenses { get; set; }
}
