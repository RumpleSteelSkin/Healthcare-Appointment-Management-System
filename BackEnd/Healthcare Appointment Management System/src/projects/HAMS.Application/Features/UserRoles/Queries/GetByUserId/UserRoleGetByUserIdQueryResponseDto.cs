namespace HAMS.Application.Features.UserRoles.Queries.GetByUserId;

public class UserRoleGetByUserIdQueryResponseDto
{
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public ICollection<string>? Roles { get; set; }
}