using Core.Application.Pipelines.Authorization;
using MediatR;
using Microsoft.AspNetCore.Identity;
using VCORE.Application.Constants;

namespace HAMS.Application.Features.Roles.Queries.GetAll;

public class RoleGetAllQuery : IRequest<ICollection<IdentityRole<Guid>>>, IRoleExists
{
    public string[] Roles => [GeneralOperationClaims.Admin];
}