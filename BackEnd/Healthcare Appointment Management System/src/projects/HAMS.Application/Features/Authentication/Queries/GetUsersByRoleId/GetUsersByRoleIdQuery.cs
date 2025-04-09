using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using HAMS.Application.Constants;
using MediatR;

namespace HAMS.Application.Features.Authentication.Queries.GetUsersByRoleId;

public class GetUsersByRoleIdQuery : IRequest<ICollection<GetUsersByRoleIdQueryResponseDto>>, IRoleExists,
    ICacheAbleRequest
{
    public Guid? RoleId { get; set; }

    public string[] Roles => [GeneralOperationClaims.Admin];

    public string? CacheKey => $"GetUsersByRoleIdQuery{RoleId}";

    public string? CacheGroupKey => GeneralCacheGroupKeys.User;

    public TimeSpan? SlidingExpiration => null;
}