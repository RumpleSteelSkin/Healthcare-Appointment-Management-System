using Core.Persistence.Entities;

namespace HAMS.Domain.Models;

public class Appointment : Entity<Guid>
{
    public DateTime AppointmentDate { get; set; }
    public string? Notes { get; set; }

    //Navigation Properties
    public Guid? DoctorId { get; set; }
    public Doctor? Doctor { get; set; }
    public Guid? PatientId { get; set; }
    public Patient? Patient { get; set; }
}