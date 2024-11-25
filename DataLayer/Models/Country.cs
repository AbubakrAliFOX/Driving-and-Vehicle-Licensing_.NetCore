using System;
using System.Collections.Generic;

namespace DataLayer.Models;

public partial class Country
{
    public int CountryId { get; set; }

    public string CountryName { get; set; }

    public virtual ICollection<Person> People { get; set; } = new List<Person>();
}
