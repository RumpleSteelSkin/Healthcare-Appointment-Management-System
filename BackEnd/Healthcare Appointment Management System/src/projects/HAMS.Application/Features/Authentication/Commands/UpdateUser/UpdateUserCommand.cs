using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transactional;
using HAMS.Application.Constants;
using MediatR;

namespace HAMS.Application.Features.Authentication.Commands.UpdateUser;

public class UpdateUserCommand : IRequest<string>, IRoleExists, ITransactional, ILoggableRequest, ICacheRemoverRequest
{
    public Guid Id { get; set; }
    public string? UserName { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }

    public string[] Roles => [GeneralOperationClaims.Admin];

    public string? CacheKey => null;

    public string? CacheGroupKey => GeneralCacheGroupKeys.User;
}