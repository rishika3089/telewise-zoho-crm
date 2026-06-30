using Microsoft.AspNetCore.Mvc;
using Telewise.Api.Features.Notifications.DTOs;
using Telewise.Api.Features.Notifications.Services;

namespace Telewise.Api.Features.Notifications.Controllers;

[ApiController]
[Route("notifications")]
public sealed class NotificationController : ControllerBase
{
    private readonly INotificationService _service;

    public NotificationController(
        INotificationService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<NotificationResponse>>> Get(
        CancellationToken cancellationToken)
    {
        var result =
            await _service.GetAllAsync(
                cancellationToken);

        return Ok(result);
    }
}