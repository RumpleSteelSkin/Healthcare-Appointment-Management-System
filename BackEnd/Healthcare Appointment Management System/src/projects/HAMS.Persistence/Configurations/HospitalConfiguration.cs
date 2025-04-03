using HAMS.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HAMS.Persistence.Configurations;

public class HospitalConfiguration : IEntityTypeConfiguration<Hospital>
{
    public void Configure(EntityTypeBuilder<Hospital> builder)
    {
        builder.ToTable("Hospitals");
        builder.HasQueryFilter(x => !x.IsDeleted);
        builder.Property(c => c.IsDeleted)
            .HasDefaultValue(false);

        builder.HasMany(x => x.Doctors)
            .WithOne(x => x.Hospital)
            .HasForeignKey(x => x.HospitalId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}