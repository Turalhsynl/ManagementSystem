using Application.CQRS.Users.Handlers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Application.CQRS.Users.Handlers.GetByEmail;

namespace ManagementSystem.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController(ISender sender) : Controller
{
    private readonly ISender _sender = sender;

    [HttpGet]
    [Route("GetByEmail")]
    public async Task<IActionResult> GetByEmail([FromQuery] Query request)
    {
        return Ok(await _sender.Send(request));
    }

    [HttpGet]
    [Route("GetById")]
    public async Task<IActionResult> GetById([FromQuery]Application.CQRS.Users.Handlers.GetById.Query request)
    {
        return Ok(await _sender.Send(request));
    }

    [HttpPost]
    public async Task<IActionResult> RegisterAsync([FromBody] Register.Command request)
    {
        return Ok(await _sender.Send(request));
    }
}
