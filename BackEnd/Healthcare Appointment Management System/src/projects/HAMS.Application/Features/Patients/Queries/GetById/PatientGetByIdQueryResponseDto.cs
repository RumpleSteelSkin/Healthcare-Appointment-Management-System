namespace HAMS.Application.Features.Patients.Queries.GetById;

public class PatientGetByIdQueryResponseDto
{
    public required string FullName { get; set; }
    public DateTime BirthDate { get; set; }
}