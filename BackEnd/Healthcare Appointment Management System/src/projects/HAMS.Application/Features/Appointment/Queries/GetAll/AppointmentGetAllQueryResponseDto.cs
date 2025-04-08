namespace HAMS.Application.Features.Appointment.Queries.GetAll;

public class AppointmentGetAllQueryResponseDto
{
    public Guid Id { get; set; }
    public string? PatientFullName { get; set; }
    public string? DoctorFullName { get; set; }
    public string? AppointmentDate { get; set; }
    public string? AppointmentDay { get; set; }
    public string? AppointmentMonth { get; set; }
    public string? AppointmentYear { get; set; }
    public string? Notes { get; set; }
}