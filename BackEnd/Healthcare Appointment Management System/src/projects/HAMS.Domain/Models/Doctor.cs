using Core.Persistence.Entities;

namespace HAMS.Domain.Models;

public class Doctor : Entity<Guid>
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? Specialty { get; set; }

    //Navigation Properties
    public Guid? HospitalId { get; set; }
    public Hospital? Hospital { get; set; }
    public ICollection<Appointment>? Appointments { get; set; }
}