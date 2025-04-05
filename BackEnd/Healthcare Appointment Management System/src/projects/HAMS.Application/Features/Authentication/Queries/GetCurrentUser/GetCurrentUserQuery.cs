using System.Security.Claims;
using Core.Application.Pipelines.Authorization;
using HAMS.Application.Constants;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace HAMS.Application.Features.Authentication.Queries.GetCurrentUser;

public class GetCurrentUserQuery : IRequest<GetCurrentUserQueryResponseDto>, IRoleExists
{
    public ClaimsPrincipal? CurrentUser { get; set; }
    public HttpContext? CurrentHttpContext { get; set; }

    public string[] Roles => [GeneralOperationClaims.Admin, GeneralOperationClaims.User];
}