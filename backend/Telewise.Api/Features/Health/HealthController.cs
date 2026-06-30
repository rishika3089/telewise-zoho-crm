using Microsoft.AspNetCore.Mvc;

namespace Telewise.Api.Controllers;

[ApiController]
[Route("health")]
public sealed class HealthController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new
        {
            Status = "Healthy",
            TimestampUtc = DateTime.UtcNow
        });
    }
}