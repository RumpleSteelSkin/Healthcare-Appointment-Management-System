namespace HAMS.Application.Features.Hospitals.Queries.GetAll;

public class HospitalGetAllQueryResponseDto
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
}