using Core.Persistence.Entities;

namespace HAMS.Domain.Models;

public class Hospital : Entity<Guid>
{
    public required string Name { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }

    //Navigation Properties
    public ICollection<Doctor>? Doctors { get; set; }
}