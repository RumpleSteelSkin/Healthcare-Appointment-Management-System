using Core.Application.Pipelines.Authorization;
using HAMS.Application.Constants;
using MediatR;

namespace HAMS.Application.Features.Roles.Commands.Add;

public class RoleAddCommand : IRequest<string> ,IRoleExists
{
    public required string Name { get; set; }

    public string[] Roles => [GeneralOperationClaims.Admin];
}