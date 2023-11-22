using Microsoft.AspNetCore.DataProtection.Internal;
using Microsoft.AspNetCore.Mvc;

namespace UserTestingAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BaseController : ControllerBase
{
    [HttpGet("heatcheck")]
    public IActionResult Healthcheck()
    {
        return Ok("I'm alive");
    }
}