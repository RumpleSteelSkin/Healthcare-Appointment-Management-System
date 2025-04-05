namespace HAMS.Application.Features.Hospitals.Queries.GetById;

public class HospitalGetByIdQueryResponseDto
{
    public required string Name { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
}