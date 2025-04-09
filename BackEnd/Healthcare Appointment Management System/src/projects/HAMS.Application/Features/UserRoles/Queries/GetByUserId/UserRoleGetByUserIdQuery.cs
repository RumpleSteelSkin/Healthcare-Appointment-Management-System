using Core.Application.Pipelines.Authorization;
using MediatR;

namespace HAMS.Application.Features.UserRoles.Queries.GetByUserId;

public class UserRoleGetByUserIdQuery : IRequest<UserRoleGetByUserIdQueryResponseDto>,IRoleExists
{
    public Guid? UserId { get; set; }

    public string[] Roles => ["Admin"];
}