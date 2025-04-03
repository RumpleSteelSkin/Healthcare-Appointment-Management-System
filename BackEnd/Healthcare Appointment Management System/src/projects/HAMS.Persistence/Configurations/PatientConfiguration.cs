using HAMS.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HAMS.Persistence.Configurations;

public class PatientConfiguration : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.ToTable("Patients");
        builder.HasQueryFilter(c => !c.IsDeleted);
        builder.Property(c => c.IsDeleted)
            .HasDefaultValue(false);

        builder.HasMany(x => x.Appointments)
            .WithOne(x => x.Patient)
            .HasForeignKey(x => x.PatientId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}