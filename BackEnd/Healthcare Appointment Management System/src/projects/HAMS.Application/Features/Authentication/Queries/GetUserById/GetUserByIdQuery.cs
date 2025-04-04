using Core.Application.Pipelines.Authorization;
using MediatR;
using VCORE.Application.Constants;

namespace HAMS.Application.Features.Authentication.Queries.GetUserById;

public class GetUserByIdQuery : IRequest<GetUserByIdQueryResponseDto>,IRoleExists
{
    public Guid? UserId { get; set; }

    public string[] Roles => [GeneralOperationClaims.Admin];
}