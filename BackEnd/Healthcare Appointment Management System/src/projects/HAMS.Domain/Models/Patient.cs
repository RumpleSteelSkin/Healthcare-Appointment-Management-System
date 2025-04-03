using Core.Persistence.Entities;

namespace HAMS.Domain.Models;

public class Patient : Entity<Guid>
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public DateTime BirthDate { get; set; }

    //Navigation Properties
    public ICollection<Appointment>? Appointments { get; set; }
}