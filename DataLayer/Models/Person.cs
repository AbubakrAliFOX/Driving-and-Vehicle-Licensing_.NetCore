using System;
using System.Collections.Generic;

namespace DataLayer.Models;

public partial class Person
{
    public int PersonId { get; set; }

    public string NationalNo { get; set; }

    public string FirstName { get; set; }

    public string SecondName { get; set; }

    public string ThirdName { get; set; }

    public string LastName { get; set; }

    public DateTime DateOfBirth { get; set; }

    /// <summary>
    /// 0 Male , 1 Femail
    /// </summary>
    public byte Gendor { get; set; }

    public string Address { get; set; }

    public string Phone { get; set; }

    public string Email { get; set; }

    public int NationalityCountryId { get; set; }

    public string ImagePath { get; set; }

    public virtual ICollection<Application> Applications { get; set; } = new List<Application>();

    public virtual ICollection<Driver> Drivers { get; set; } = new List<Driver>();

    public virtual Country NationalityCountry { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
