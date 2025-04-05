using Core.Application.Pipelines.Authorization;
using HAMS.Application.Constants;
using MediatR;

namespace HAMS.Application.Features.Authentication.Queries.GetUsersByRoleId;

public class GetUsersByRoleIdQuery : IRequest<ICollection<GetUsersByRoleIdQueryResponseDto>>,IRoleExists
{
    public Guid? RoleId { get; set; }

    public string[] Roles => [GeneralOperationClaims.Admin];
}