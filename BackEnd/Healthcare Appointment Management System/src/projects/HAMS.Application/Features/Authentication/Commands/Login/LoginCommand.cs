using Core.Application.Pipelines.Transactional;
using HAMS.Application.Services.JwtServices;
using MediatR;

namespace HAMS.Application.Features.Authentication.Commands.Login;

public class LoginCommand : IRequest<AccessTokenDto>, ITransactional
{
    public string? UserNameOrEmail { get; set; }
    public string? Password { get; set; }
}