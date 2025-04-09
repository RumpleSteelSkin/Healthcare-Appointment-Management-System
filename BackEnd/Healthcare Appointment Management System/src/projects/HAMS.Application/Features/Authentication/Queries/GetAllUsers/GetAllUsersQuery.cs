using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using HAMS.Application.Constants;
using MediatR;

namespace HAMS.Application.Features.Authentication.Queries.GetAllUsers;

public class GetAllUsersQuery : IRequest<ICollection<GetAllUsersQueryResponseDto>>, IRoleExists,ICacheAbleRequest
{
    public string[] Roles => [GeneralOperationClaims.Admin];

    public string? CacheKey => "GetAllUsersQuery";

    public string? CacheGroupKey => GeneralCacheGroupKeys.User;

    public TimeSpan? SlidingExpiration => null;
}