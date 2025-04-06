using HAMS.Application.Features.Appointment.Commands.Add;
using HAMS.Application.Features.Appointment.Commands.Delete;
using HAMS.Application.Features.Appointment.Commands.Update;
using HAMS.Application.Features.Appointment.Queries.GetAll;
using HAMS.Application.Features.Appointment.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HAMS.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AppointmentsController(IMediator mediator) : ControllerBase
{
    [HttpPost("Add")]
    public async Task<IActionResult> Add(AppointmentAddCommand command)
    {
        return Ok(await mediator.Send(command));
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(AppointmentUpdateCommand command)
    {
        return Ok(await mediator.Send(command));
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete(AppointmentDeleteCommand command)
    {
        return Ok(await mediator.Send(command));
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await mediator.Send(new AppointmentGetAllQuery()));
    }

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(Guid? appointmentId = null)
    {
        return Ok(await mediator.Send(new AppointmentGetByIdQuery { AppointmentId = appointmentId }));
    }
}