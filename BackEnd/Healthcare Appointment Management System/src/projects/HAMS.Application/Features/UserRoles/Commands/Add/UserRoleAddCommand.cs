using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transactional;
using HAMS.Application.Constants;
using MediatR;

namespace HAMS.Application.Features.UserRoles.Commands.Add;

public class UserRoleAddCommand : IRequest<string>, IRoleExists, ITransactional, ILoggableRequest
{
    public Guid UserId { get; set; }
    public Guid RoleId { get; set; }

    public string[] Roles => [GeneralOperationClaims.Admin];
}