using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VehicleTracker.Application.Contracts.Models.InputModels;
using VehicleTracker.Application.Contracts.Models.ViewModels;
using VehicleTracker.Application.UseCases.Auth.Command;
using VehicleTracker.Application.UseCases.Auth.Command.RegisterUser;
using VehicleTracker.Application.UseCases.Auth.Query;
using VehicleTracker.Application.UseCases.Auth.Query.LoginUser;
using VehicleTracker.Application.UseCases.Invitations.Command;
using VehicleTracker.Application.UseCases.Invitations.Command.RegisterDriverByInvite;

namespace VehicleTracker.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(ISender mediator) : ControllerBase
{
    [HttpPost("login")]
    [ProducesResponseType(typeof(AuthViewModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Login([FromBody] LoginInputModel input, CancellationToken ct)
    {
        var command = new LoginUserQuery(input);

        var result = await mediator.Send(command, ct);

        return Ok(result);
    }
    
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
    
    [AllowAnonymous]
    [HttpPost("register/driver")]
    [ProducesResponseType(typeof(AuthViewModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RegisterDriver([FromBody] CreateDriverByInviteInputModel input,
        CancellationToken ct)
    {
        var command = new RegisterDriverByInviteCommand(input);
        
        var result = await mediator.Send(command, ct);

        return Ok(result);
    }
}