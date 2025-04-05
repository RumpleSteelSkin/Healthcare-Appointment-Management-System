using Core.Application.Pipelines.Authorization;
using HAMS.Application.Constants;
using MediatR;

namespace HAMS.Application.Features.Authentication.Queries.GetAllUsers;

public class GetAllUsersQuery : IRequest<ICollection<GetAllUsersQueryResponseDto>>, IRoleExists
{
    public string[] Roles => [GeneralOperationClaims.Admin];
}