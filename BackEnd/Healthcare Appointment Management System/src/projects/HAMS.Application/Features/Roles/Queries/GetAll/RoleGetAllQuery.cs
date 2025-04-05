using Core.Application.Pipelines.Authorization;
using HAMS.Application.Constants;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace HAMS.Application.Features.Roles.Queries.GetAll;

public class RoleGetAllQuery : IRequest<ICollection<IdentityRole<Guid>>>, IRoleExists
{
    public string[] Roles => [GeneralOperationClaims.Admin];
}