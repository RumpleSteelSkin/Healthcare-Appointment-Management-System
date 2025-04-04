using Core.Application.Pipelines.Transactional;
using HAMS.Application.Services.JwtServices;
using MediatR;

namespace HAMS.Application.Features.Authentication.Commands.Register;

public class RegisterCommand : IRequest<AccessTokenDto>, ITransactional
{
    public string? UserName { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
}