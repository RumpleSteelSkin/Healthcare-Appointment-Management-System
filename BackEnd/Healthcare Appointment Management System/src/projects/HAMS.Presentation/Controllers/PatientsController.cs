using Microsoft.AspNetCore.Mvc;

namespace HAMS.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PatientsController : ControllerBase
{
    [HttpPost("Add")]
    public async Task<IActionResult> Add()
    {
        return Ok();
    }
        
    [HttpPut("Update")]
    public async Task<IActionResult> Update()
    {
        return Ok();
    }
        
    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete()
    {
        return Ok();
    }
        
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        return Ok();
    }
        
    [HttpGet("GetById")]
    public async Task<IActionResult> GetById()
    {
        return Ok();
    }
}