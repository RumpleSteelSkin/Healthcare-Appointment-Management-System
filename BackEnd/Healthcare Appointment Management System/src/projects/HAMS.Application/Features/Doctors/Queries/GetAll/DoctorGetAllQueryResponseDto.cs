namespace HAMS.Application.Features.Doctors.Queries.GetAll;

public class DoctorGetAllQueryResponseDto
{
    public required string FullName { get; set; }
    public string? Specialty { get; set; }
    public string? HospitalName { get; set; }
}