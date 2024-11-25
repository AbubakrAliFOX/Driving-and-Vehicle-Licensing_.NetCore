using System;
using System.Collections.Generic;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Models.Context;

public partial class DbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public DbContext()
    {
    }

    public DbContext(DbContextOptions<DbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Application> Applications { get; set; }

    public virtual DbSet<ApplicationType> ApplicationTypes { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<DetainedLicense> DetainedLicenses { get; set; }

    public virtual DbSet<Driver> Drivers { get; set; }

    public virtual DbSet<DriversView> DriversViews { get; set; }

    public virtual DbSet<InternationalLicense> InternationalLicenses { get; set; }

    public virtual DbSet<License> Licenses { get; set; }

    public virtual DbSet<LicenseClass> LicenseClasses { get; set; }

    public virtual DbSet<LocalDrivingLicenseApplication> LocalDrivingLicenseApplications { get; set; }

    public virtual DbSet<LocalDrivingLicenseApplicationsView> LocalDrivingLicenseApplicationsViews { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Test> Tests { get; set; }

    public virtual DbSet<TestAppointment> TestAppointments { get; set; }

    public virtual DbSet<TestAppointmentsView> TestAppointmentsViews { get; set; }

    public virtual DbSet<TestType> TestTypes { get; set; }

    public virtual DbSet<TestsDetail> TestsDetails { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=E:\\Downloads\\WebDev\\Projects\\DVL Coree\\PresentationLayer\\bin\\Debug\\net8.0-windows\\DVLD.mdf;Integrated Security=True;Connect Timeout=30");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Latin1_General_CI_AS");

        modelBuilder.Entity<Application>(entity =>
        {
            entity.Property(e => e.ApplicationId).HasColumnName("ApplicationID");
            entity.Property(e => e.ApplicantPersonId).HasColumnName("ApplicantPersonID");
            entity.Property(e => e.ApplicationDate).HasColumnType("datetime");
            entity.Property(e => e.ApplicationStatus)
                .HasDefaultValue((byte)1)
                .HasComment("1-New 2-Cancelled 3-Completed");
            entity.Property(e => e.ApplicationTypeId).HasColumnName("ApplicationTypeID");
            entity.Property(e => e.CreatedByUserId).HasColumnName("CreatedByUserID");
            entity.Property(e => e.LastStatusDate).HasColumnType("datetime");
            entity.Property(e => e.PaidFees).HasColumnType("smallmoney");

            entity.HasOne(d => d.ApplicantPerson).WithMany(p => p.Applications)
                .HasForeignKey(d => d.ApplicantPersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Applications_People");

            entity.HasOne(d => d.ApplicationType).WithMany(p => p.Applications)
                .HasForeignKey(d => d.ApplicationTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Applications_ApplicationTypes");

            entity.HasOne(d => d.CreatedByUser).WithMany(p => p.Applications)
                .HasForeignKey(d => d.CreatedByUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Applications_Users");
        });

        modelBuilder.Entity<ApplicationType>(entity =>
        {
            entity.Property(e => e.ApplicationTypeId).HasColumnName("ApplicationTypeID");
            entity.Property(e => e.ApplicationFees).HasColumnType("smallmoney");
            entity.Property(e => e.ApplicationTypeTitle)
                .IsRequired()
                .HasMaxLength(150);
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.CountryId).HasName("PK__Countrie__10D160BFDBD6933F");

            entity.Property(e => e.CountryId).HasColumnName("CountryID");
            entity.Property(e => e.CountryName)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<DetainedLicense>(entity =>
        {
            entity.HasKey(e => e.DetainId);

            entity.Property(e => e.DetainId).HasColumnName("DetainID");
            entity.Property(e => e.CreatedByUserId).HasColumnName("CreatedByUserID");
            entity.Property(e => e.DetainDate).HasColumnType("smalldatetime");
            entity.Property(e => e.FineFees).HasColumnType("smallmoney");
            entity.Property(e => e.LicenseId).HasColumnName("LicenseID");
            entity.Property(e => e.ReleaseApplicationId).HasColumnName("ReleaseApplicationID");
            entity.Property(e => e.ReleaseDate).HasColumnType("smalldatetime");
            entity.Property(e => e.ReleasedByUserId).HasColumnName("ReleasedByUserID");

            entity.HasOne(d => d.CreatedByUser).WithMany(p => p.DetainedLicenseCreatedByUsers)
                .HasForeignKey(d => d.CreatedByUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetainedLicenses_Users");

            entity.HasOne(d => d.License).WithMany(p => p.DetainedLicenses)
                .HasForeignKey(d => d.LicenseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetainedLicenses_Licenses");

            entity.HasOne(d => d.ReleaseApplication).WithMany(p => p.DetainedLicenses)
                .HasForeignKey(d => d.ReleaseApplicationId)
                .HasConstraintName("FK_DetainedLicenses_Applications");

            entity.HasOne(d => d.ReleasedByUser).WithMany(p => p.DetainedLicenseReleasedByUsers)
                .HasForeignKey(d => d.ReleasedByUserId)
                .HasConstraintName("FK_DetainedLicenses_Users1");
        });

        modelBuilder.Entity<Driver>(entity =>
        {
            entity.HasKey(e => e.DriverId).HasName("PK_Drivers_1");

            entity.Property(e => e.DriverId).HasColumnName("DriverID");
            entity.Property(e => e.CreatedByUserId).HasColumnName("CreatedByUserID");
            entity.Property(e => e.CreatedDate).HasColumnType("smalldatetime");
            entity.Property(e => e.PersonId).HasColumnName("PersonID");

            entity.HasOne(d => d.CreatedByUser).WithMany(p => p.Drivers)
                .HasForeignKey(d => d.CreatedByUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Drivers_Users");

            entity.HasOne(d => d.Person).WithMany(p => p.Drivers)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Drivers_People");
        });

        modelBuilder.Entity<DriversView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Drivers_View");

            entity.Property(e => e.CreatedDate).HasColumnType("smalldatetime");
            entity.Property(e => e.DriverId).HasColumnName("DriverID");
            entity.Property(e => e.FullName)
                .IsRequired()
                .HasMaxLength(83);
            entity.Property(e => e.NationalNo)
                .IsRequired()
                .HasMaxLength(20);
            entity.Property(e => e.PersonId).HasColumnName("PersonID");
        });

        modelBuilder.Entity<InternationalLicense>(entity =>
        {
            entity.Property(e => e.InternationalLicenseId).HasColumnName("InternationalLicenseID");
            entity.Property(e => e.ApplicationId).HasColumnName("ApplicationID");
            entity.Property(e => e.CreatedByUserId).HasColumnName("CreatedByUserID");
            entity.Property(e => e.DriverId).HasColumnName("DriverID");
            entity.Property(e => e.ExpirationDate).HasColumnType("smalldatetime");
            entity.Property(e => e.IssueDate).HasColumnType("smalldatetime");
            entity.Property(e => e.IssuedUsingLocalLicenseId).HasColumnName("IssuedUsingLocalLicenseID");

            entity.HasOne(d => d.Application).WithMany(p => p.InternationalLicenses)
                .HasForeignKey(d => d.ApplicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InternationalLicenses_Applications");

            entity.HasOne(d => d.CreatedByUser).WithMany(p => p.InternationalLicenses)
                .HasForeignKey(d => d.CreatedByUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InternationalLicenses_Users");

            entity.HasOne(d => d.Driver).WithMany(p => p.InternationalLicenses)
                .HasForeignKey(d => d.DriverId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InternationalLicenses_Drivers");

            entity.HasOne(d => d.IssuedUsingLocalLicense).WithMany(p => p.InternationalLicenses)
                .HasForeignKey(d => d.IssuedUsingLocalLicenseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InternationalLicenses_Licenses");
        });

        modelBuilder.Entity<License>(entity =>
        {
            entity.Property(e => e.LicenseId).HasColumnName("LicenseID");
            entity.Property(e => e.ApplicationId).HasColumnName("ApplicationID");
            entity.Property(e => e.CreatedByUserId).HasColumnName("CreatedByUserID");
            entity.Property(e => e.DriverId).HasColumnName("DriverID");
            entity.Property(e => e.ExpirationDate).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IssueDate).HasColumnType("datetime");
            entity.Property(e => e.IssueReason)
                .HasDefaultValue((byte)1)
                .HasComment("1-FirstTime, 2-Renew, 3-Replacement for Damaged, 4- Replacement for Lost.");
            entity.Property(e => e.Notes).HasMaxLength(500);
            entity.Property(e => e.PaidFees).HasColumnType("smallmoney");

            entity.HasOne(d => d.Application).WithMany(p => p.Licenses)
                .HasForeignKey(d => d.ApplicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Licenses_Applications");

            entity.HasOne(d => d.CreatedByUser).WithMany(p => p.Licenses)
                .HasForeignKey(d => d.CreatedByUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Licenses_Users");

            entity.HasOne(d => d.Driver).WithMany(p => p.Licenses)
                .HasForeignKey(d => d.DriverId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Licenses_Drivers");

            entity.HasOne(d => d.LicenseClassNavigation).WithMany(p => p.Licenses)
                .HasForeignKey(d => d.LicenseClass)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Licenses_LicenseClasses");
        });

        modelBuilder.Entity<LicenseClass>(entity =>
        {
            entity.Property(e => e.LicenseClassId).HasColumnName("LicenseClassID");
            entity.Property(e => e.ClassDescription)
                .IsRequired()
                .HasMaxLength(500);
            entity.Property(e => e.ClassFees).HasColumnType("smallmoney");
            entity.Property(e => e.ClassName)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.DefaultValidityLength)
                .HasDefaultValue((byte)1)
                .HasComment("How many years the licesnse will be valid.");
            entity.Property(e => e.MinimumAllowedAge)
                .HasDefaultValue((byte)18)
                .HasComment("Minmum age allowed to apply for this license");
        });

        modelBuilder.Entity<LocalDrivingLicenseApplication>(entity =>
        {
            entity.HasKey(e => e.LocalDrivingLicenseApplicationId).HasName("PK_DrivingLicsenseApplications");

            entity.Property(e => e.LocalDrivingLicenseApplicationId).HasColumnName("LocalDrivingLicenseApplicationID");
            entity.Property(e => e.ApplicationId).HasColumnName("ApplicationID");
            entity.Property(e => e.LicenseClassId).HasColumnName("LicenseClassID");

            entity.HasOne(d => d.Application).WithMany(p => p.LocalDrivingLicenseApplications)
                .HasForeignKey(d => d.ApplicationId)
                .HasConstraintName("FK_DrivingLicsenseApplications_Applications");

            entity.HasOne(d => d.LicenseClass).WithMany(p => p.LocalDrivingLicenseApplications)
                .HasForeignKey(d => d.LicenseClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DrivingLicsenseApplications_LicenseClasses");
        });

        modelBuilder.Entity<LocalDrivingLicenseApplicationsView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("LocalDrivingLicenseApplications_View");

            entity.Property(e => e.ApplicationDate).HasColumnType("datetime");
            entity.Property(e => e.ClassName)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.FullName)
                .IsRequired()
                .HasMaxLength(83);
            entity.Property(e => e.LocalDrivingLicenseApplicationId).HasColumnName("LocalDrivingLicenseApplicationID");
            entity.Property(e => e.NationalNo)
                .IsRequired()
                .HasMaxLength(20);
            entity.Property(e => e.Status)
                .HasMaxLength(9)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.Property(e => e.PersonId).HasColumnName("PersonID");
            entity.Property(e => e.Address)
                .IsRequired()
                .HasMaxLength(500);
            entity.Property(e => e.DateOfBirth).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(20);
            entity.Property(e => e.Gendor).HasComment("0 Male , 1 Femail");
            entity.Property(e => e.ImagePath).HasMaxLength(250);
            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(20);
            entity.Property(e => e.NationalNo)
                .IsRequired()
                .HasMaxLength(20);
            entity.Property(e => e.NationalityCountryId).HasColumnName("NationalityCountryID");
            entity.Property(e => e.Phone)
                .IsRequired()
                .HasMaxLength(20);
            entity.Property(e => e.SecondName)
                .IsRequired()
                .HasMaxLength(20);
            entity.Property(e => e.ThirdName).HasMaxLength(20);

            entity.HasOne(d => d.NationalityCountry).WithMany(p => p.People)
                .HasForeignKey(d => d.NationalityCountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_People_Countries1");
        });

        modelBuilder.Entity<Test>(entity =>
        {
            entity.Property(e => e.TestId).HasColumnName("TestID");
            entity.Property(e => e.CreatedByUserId).HasColumnName("CreatedByUserID");
            entity.Property(e => e.Notes).HasMaxLength(500);
            entity.Property(e => e.TestAppointmentId).HasColumnName("TestAppointmentID");
            entity.Property(e => e.TestResult).HasComment("0 - Fail 1-Pass");

            entity.HasOne(d => d.CreatedByUser).WithMany(p => p.Tests)
                .HasForeignKey(d => d.CreatedByUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tests_Users");

            entity.HasOne(d => d.TestAppointment).WithMany(p => p.Tests)
                .HasForeignKey(d => d.TestAppointmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tests_TestAppointments");
        });

        modelBuilder.Entity<TestAppointment>(entity =>
        {
            entity.Property(e => e.TestAppointmentId).HasColumnName("TestAppointmentID");
            entity.Property(e => e.AppointmentDate).HasColumnType("smalldatetime");
            entity.Property(e => e.CreatedByUserId).HasColumnName("CreatedByUserID");
            entity.Property(e => e.LocalDrivingLicenseApplicationId).HasColumnName("LocalDrivingLicenseApplicationID");
            entity.Property(e => e.PaidFees).HasColumnType("smallmoney");
            entity.Property(e => e.RetakeTestApplicationId).HasColumnName("RetakeTestApplicationID");
            entity.Property(e => e.TestTypeId).HasColumnName("TestTypeID");

            entity.HasOne(d => d.CreatedByUser).WithMany(p => p.TestAppointments)
                .HasForeignKey(d => d.CreatedByUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TestAppointments_Users");

            entity.HasOne(d => d.LocalDrivingLicenseApplication).WithMany(p => p.TestAppointments)
                .HasForeignKey(d => d.LocalDrivingLicenseApplicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TestAppointments_LocalDrivingLicenseApplications");

            entity.HasOne(d => d.TestType).WithMany(p => p.TestAppointments)
                .HasForeignKey(d => d.TestTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TestAppointments_TestTypes");
        });

        modelBuilder.Entity<TestAppointmentsView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("TestAppointments_View");

            entity.Property(e => e.AppointmentDate).HasColumnType("smalldatetime");
            entity.Property(e => e.ClassName)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.FullName)
                .IsRequired()
                .HasMaxLength(83);
            entity.Property(e => e.LocalDrivingLicenseApplicationId).HasColumnName("LocalDrivingLicenseApplicationID");
            entity.Property(e => e.PaidFees).HasColumnType("smallmoney");
            entity.Property(e => e.TestAppointmentId).HasColumnName("TestAppointmentID");
            entity.Property(e => e.TestTypeTitle)
                .IsRequired()
                .HasMaxLength(100);
        });

        modelBuilder.Entity<TestType>(entity =>
        {
            entity.Property(e => e.TestTypeId).HasColumnName("TestTypeID");
            entity.Property(e => e.TestTypeDescription)
                .IsRequired()
                .HasMaxLength(500);
            entity.Property(e => e.TestTypeFees).HasColumnType("smallmoney");
            entity.Property(e => e.TestTypeTitle)
                .IsRequired()
                .HasMaxLength(100);
        });

        modelBuilder.Entity<TestsDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("TestsDetails");

            entity.Property(e => e.CreatedByUserId).HasColumnName("CreatedByUserID");
            entity.Property(e => e.LocalDrivingLicenseApplicationId).HasColumnName("LocalDrivingLicenseApplicationID");
            entity.Property(e => e.Notes).HasMaxLength(500);
            entity.Property(e => e.TestAppointmentId).HasColumnName("TestAppointmentID");
            entity.Property(e => e.TestId).HasColumnName("TestID");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.PersonId).HasColumnName("PersonID");
            entity.Property(e => e.UserName)
                .IsRequired()
                .HasMaxLength(100);

            entity.HasOne(d => d.Person).WithMany(p => p.Users)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_People");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
