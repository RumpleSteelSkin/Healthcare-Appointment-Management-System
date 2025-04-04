namespace HAMS.Application.Features.Authentication.Queries.GetUserById;

public class GetUserByIdQueryResponseDto
{
    public string? UserName { get; set; }
    public string? FullName { get; set; }
    public string? Email { get; set; }
}