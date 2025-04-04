using Core.Application.Pipelines.Authorization;
using MediatR;
using VCORE.Application.Constants;

namespace HAMS.Application.Features.Authentication.Queries.GetAllUsers;

public class GetAllUsersQuery : IRequest<ICollection<GetAllUsersQueryResponseDto>>, IRoleExists
{
    public string[] Roles => [GeneralOperationClaims.Admin];
}