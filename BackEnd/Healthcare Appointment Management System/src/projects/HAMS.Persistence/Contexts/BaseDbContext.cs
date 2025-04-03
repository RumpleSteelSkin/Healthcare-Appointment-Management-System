using System.Reflection;
using HAMS.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HAMS.Persistence.Contexts;

public class BaseDbContext(DbContextOptions options) : IdentityDbContext<User, IdentityRole<Guid>, Guid>(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    DbSet<Hospital> Hospitals { get; set; }
    DbSet<Doctor> Doctors { get; set; }
    DbSet<Appointment> Appointments { get; set; }
    DbSet<Patient> Patients { get; set; }
}