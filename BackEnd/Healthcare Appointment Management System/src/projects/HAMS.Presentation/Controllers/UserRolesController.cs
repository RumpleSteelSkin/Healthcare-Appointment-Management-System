using HAMS.Application.Features.UserRoles.Commands.Add;
using HAMS.Application.Features.UserRoles.Queries.GetByUserId;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HAMS.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRolesController(IMediator mediator) : ControllerBase
    {
        [HttpPost("Add")]
        public async Task<IActionResult> Add(UserRoleAddCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        [HttpGet("GetByUserId")]
        public async Task<IActionResult> GetByUserId(Guid? userId = null)
        {
            return Ok(await mediator.Send(new UserRoleGetByUserIdQuery(){UserId = userId}));
        }
    }
}