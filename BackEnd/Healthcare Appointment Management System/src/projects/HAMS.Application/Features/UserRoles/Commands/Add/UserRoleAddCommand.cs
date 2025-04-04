using MediatR;

namespace HAMS.Application.Features.UserRoles.Commands.Add;

public class UserRoleAddCommand : IRequest<string>
{
    public Guid UserId { get; set; }
    public Guid RoleId { get; set; }
}