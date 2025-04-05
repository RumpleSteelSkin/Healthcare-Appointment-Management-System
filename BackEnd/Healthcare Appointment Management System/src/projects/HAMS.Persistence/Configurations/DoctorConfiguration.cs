using HAMS.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HAMS.Persistence.Configurations;

public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.ToTable("Doctors");
        builder.HasQueryFilter(c => !c.IsDeleted);
        builder.Property(c => c.IsDeleted)
            .HasDefaultValue(false);

        builder.Navigation(x => x.Hospital).AutoInclude();

        builder.HasOne(x => x.Hospital)
            .WithMany(x => x.Doctors)
            .HasForeignKey(x => x.HospitalId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasMany(x => x.Appointments)
            .WithOne(x => x.Doctor)
            .HasForeignKey(x => x.DoctorId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}