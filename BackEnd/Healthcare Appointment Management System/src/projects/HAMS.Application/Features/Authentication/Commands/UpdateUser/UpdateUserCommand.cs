using MediatR;

namespace HAMS.Application.Features.Authentication.Commands.UpdateUser;

public class UpdateUserCommand : IRequest<string>
{
    public Guid Id { get; set; }
    public string? UserName { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
}