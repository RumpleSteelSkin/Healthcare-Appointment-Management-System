using Core.Application.Pipelines.Authorization;
using HAMS.Application.Constants;
using MediatR;

namespace HAMS.Application.Features.Authentication.Queries.GetUserDetailById;

public class GetUserDetailByIdCommand : IRequest<GetUserDetailByIdCommandResponseDto>,IRoleExists
{
    public Guid? UserId { get; set; }

    public string[] Roles => [GeneralOperationClaims.Admin];
}