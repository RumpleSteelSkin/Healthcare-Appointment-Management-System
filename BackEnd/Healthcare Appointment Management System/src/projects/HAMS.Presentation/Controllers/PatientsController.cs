using HAMS.Application.Features.Patients.Commands.Add;
using HAMS.Application.Features.Patients.Commands.Delete;
using HAMS.Application.Features.Patients.Commands.Update;
using HAMS.Application.Features.Patients.Queries.GetAll;
using HAMS.Application.Features.Patients.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HAMS.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PatientsController(IMediator mediator) : ControllerBase
{
    [HttpPost("Add")]
    public async Task<IActionResult> Add(PatientAddCommand command)
    {
        return Ok(await mediator.Send(command));
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(PatientUpdateCommand command)
    {
        return Ok(await mediator.Send(command));
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete(PatientDeleteCommand command)
    {
        return Ok(await mediator.Send(command));
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await mediator.Send(new PatientGetAllQuery()));
    }

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(Guid? patientId = null)
    {
        return Ok(await mediator.Send(new PatientGetByIdQuery { PatientId = patientId }));
    }
}