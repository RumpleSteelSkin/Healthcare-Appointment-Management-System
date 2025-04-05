namespace HAMS.Application.Features.Doctors.Queries.GetById;

public class DoctorGetByIdQueryResponseDto
{
    public required string FullName { get; set; }
    public string? Specialty { get; set; }
    public string? HospitalName { get; set; }
}