using HAMS.Application.Features.Roles.Commands.Add;
using HAMS.Application.Features.Roles.Queries.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HAMS.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RolesController(IMediator mediator) : ControllerBase
{
    [HttpPost("Add")]
    public async Task<IActionResult> Add(RoleAddCommand command)
    {
        return Ok(await mediator.Send(command));
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await mediator.Send(new RoleGetAllQuery()));
    }
}