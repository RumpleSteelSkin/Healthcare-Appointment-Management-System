using HAMS.Application.Features.Doctors.Commands.Add;
using HAMS.Application.Features.Doctors.Commands.Delete;
using HAMS.Application.Features.Doctors.Commands.Update;
using HAMS.Application.Features.Doctors.Queries.GetAll;
using HAMS.Application.Features.Doctors.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HAMS.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DoctorsController(IMediator mediator) : ControllerBase
{
    [HttpPost("Add")]
    public async Task<IActionResult> Add(DoctorAddCommand command)
    {
        return Ok(await mediator.Send(command));
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(DoctorUpdateCommand command)
    {
        return Ok(await mediator.Send(command));
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete(DoctorDeleteCommand command)
    {
        return Ok(await mediator.Send(command));
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await mediator.Send(new DoctorGetAllQuery()));
    }

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(Guid? doctorId = null)
    {
        return Ok(await mediator.Send(new DoctorGetByIdQuery { DoctorId = doctorId }));
    }
}