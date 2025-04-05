using HAMS.Application.Features.Authentication.Commands.Login;
using HAMS.Application.Features.Authentication.Commands.Register;
using HAMS.Application.Features.Authentication.Queries.GetAllUsers;
using HAMS.Application.Features.Authentication.Queries.GetCurrentUser;
using HAMS.Application.Features.Authentication.Queries.GetUserById;
using HAMS.Application.Features.Authentication.Queries.GetUsersByRoleId;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HAMS.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationsController(IMediator mediator) : ControllerBase
{
    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginCommand command)
    {
        return Ok(await mediator.Send(command));
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register(RegisterCommand command)
    {
        return Ok(await mediator.Send(command));
    }

    [HttpGet("GetAllUsers")]
    public async Task<IActionResult> GetAllUsers()
    {
        return Ok(await mediator.Send(new GetAllUsersQuery()));
    }

    [HttpGet("GetCurrentUser")]
    public async Task<IActionResult> GetCurrentUser()
    {
        return Ok(await mediator.Send(new GetCurrentUserQuery
            { CurrentUser = User, CurrentHttpContext = HttpContext }));
    }

    [HttpGet("GetUserById")]
    public async Task<IActionResult> GetUserById(Guid? userId = null)
    {
        return Ok(await mediator.Send(new GetUserByIdQuery { UserId = userId }));
    }

    [HttpGet("GetUsersByRoleId")]
    public async Task<IActionResult> GetUsersByRoleId(Guid? roleId = null)
    {
        return Ok(await mediator.Send(new GetUsersByRoleIdQuery { RoleId = roleId }));
    }
}