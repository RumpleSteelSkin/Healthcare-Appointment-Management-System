namespace HAMS.Application.Features.Authentication.Queries.GetUserDetailById;

public class GetUserDetailByIdCommandResponseDto
{
    public string? UserName { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public DateTime? BirthDate { get; set; }
}