using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transactional;
using HAMS.Application.Constants;
using MediatR;

namespace HAMS.Application.Features.Roles.Commands.Add;

public class RoleAddCommand : IRequest<string>, IRoleExists, ITransactional, ILoggableRequest
{
    public required string Name { get; set; }

    public string[] Roles => [GeneralOperationClaims.Admin];
}