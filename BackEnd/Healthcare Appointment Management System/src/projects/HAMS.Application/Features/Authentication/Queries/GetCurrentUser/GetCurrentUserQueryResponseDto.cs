namespace HAMS.Application.Features.Authentication.Queries.GetCurrentUser;

public class GetCurrentUserQueryResponseDto
{
    public string? Id { get; set; }
    public ICollection<string>? Roles { get; set; }
}