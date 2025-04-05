namespace HAMS.Application.Features.Patients.Queries.GetAll;

public class PatientGetAllQueryResponseDto
{
    public required string FullName { get; set; }
    public DateTime BirthDate { get; set; }
}