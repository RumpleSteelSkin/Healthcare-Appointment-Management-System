using System.Security.Authentication;
using System.Security.Claims;
using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using MediatR;

namespace HAMS.Application.Features.Authentication.Queries.GetCurrentUser;

public class GetCurrentUserQueryHandler : IRequestHandler<GetCurrentUserQuery, GetCurrentUserQueryResponseDto>
{
    public Task<GetCurrentUserQueryResponseDto> Handle(GetCurrentUserQuery request, CancellationToken cancellationToken)
    {
        if (request.CurrentUser is null)
            throw new AuthenticationException("User context is null. Make sure the user is authenticated.");

        if (request.CurrentHttpContext is null)
            throw new NotFoundException("HTTP Context is null. Ensure the request has a valid context.");

        var userId = request.CurrentUser.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrEmpty(userId))
            throw new AuthenticationException("User ID claim is missing. Ensure the user is authenticated.");

        var response = new GetCurrentUserQueryResponseDto()
        {
            Id = userId,
            Roles = request.CurrentHttpContext.User.Claims
                .Where(x => x.Type == ClaimTypes.Role)
                .Select(x => x.Value)
                .ToList()
        };

        return Task.FromResult(response);
    }
}