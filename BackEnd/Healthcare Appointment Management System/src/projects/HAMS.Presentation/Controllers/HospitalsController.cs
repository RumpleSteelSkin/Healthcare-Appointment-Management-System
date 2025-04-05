using HAMS.Application.Features.Hospitals.Commands.Add;
using HAMS.Application.Features.Hospitals.Commands.Delete;
using HAMS.Application.Features.Hospitals.Commands.Update;
using HAMS.Application.Features.Hospitals.Queries.GetAll;
using HAMS.Application.Features.Hospitals.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HAMS.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HospitalsController(IMediator mediator) : ControllerBase
{
    [HttpPost("Add")]
    public async Task<IActionResult> Add(HospitalAddCommand command)
    {
        return Ok(await mediator.Send(command));
    }
        
    [HttpPut("Update")]
    public async Task<IActionResult> Update(HospitalUpdateCommand command)
    {
        return Ok(await mediator.Send(command));
    }
        
    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete(HospitalDeleteCommand command)
    {
        return Ok(await mediator.Send(command));
    }
        
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await mediator.Send(new HospitalGetAllQuery()));
    }
        
    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(Guid? hospitalId = null)
    {
        return Ok(await mediator.Send(new HospitalGetByIdQuery {HospitalId = hospitalId}));
    }
}