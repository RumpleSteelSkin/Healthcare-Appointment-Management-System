namespace HAMS.Application.Features.Doctors.Queries.GetAllByHospitalId;

public class DoctorGetAllByHospitalIdQueryResponseDto
{
    public Guid Id { get; set; }
    public required string FullName { get; set; }
    public string? Specialty { get; set; }
}