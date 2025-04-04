using Core.Application.Pipelines.Authorization;
using MediatR;
using VCORE.Application.Constants;

namespace HAMS.Application.Features.Roles.Commands.Add;

public class RoleAddCommand : IRequest<string> ,IRoleExists
{
    public required string Name { get; set; }

    public string[] Roles => [GeneralOperationClaims.Admin];
}