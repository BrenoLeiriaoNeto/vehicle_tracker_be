using MediatR;
using Microsoft.AspNetCore.Mvc;
using VehicleTracker.Application.Contracts.Models.InputModels;
using VehicleTracker.Application.Contracts.Models.ViewModels;
using VehicleTracker.Application.Handlers.Auth.Command;

namespace VehicleTracker.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(ISender mediator) : ControllerBase
{
    [HttpPost("register")]
    [ProducesResponseType(typeof(AuthViewModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register([FromBody] CreateUserInputModel input,
        CancellationToken ct)
    {
        var command = new RegisterUserCommand(input);

        var result = await mediator.Send(command, ct);

        return Ok(result);
    }
}