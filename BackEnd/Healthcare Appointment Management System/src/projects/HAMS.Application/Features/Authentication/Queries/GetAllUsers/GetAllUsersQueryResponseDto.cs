namespace HAMS.Application.Features.Authentication.Queries.GetAllUsers;

public class GetAllUsersQueryResponseDto
{
    public Guid? Id { get; set; }
    public string? UserName { get; set; }
    public string? FullName { get; set; }
    public string? Email { get; set; }
}