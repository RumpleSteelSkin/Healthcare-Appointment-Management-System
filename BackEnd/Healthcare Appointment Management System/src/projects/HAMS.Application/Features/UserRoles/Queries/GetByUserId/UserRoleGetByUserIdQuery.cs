using MediatR;

namespace HAMS.Application.Features.UserRoles.Queries.GetByUserId;

public class UserRoleGetByUserIdQuery : IRequest<UserRoleGetByUserIdQueryResponseDto>
{
    public Guid? UserId { get; set; }
}