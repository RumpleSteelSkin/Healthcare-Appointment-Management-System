using Core.Application.Pipelines.Authorization;
using HAMS.Application.Constants;
using MediatR;

namespace HAMS.Application.Features.Authentication.Queries.GetUserById;

public class GetUserByIdQuery : IRequest<GetUserByIdQueryResponseDto>,IRoleExists
{
    public Guid? UserId { get; set; }

    public string[] Roles => [GeneralOperationClaims.Admin];
}