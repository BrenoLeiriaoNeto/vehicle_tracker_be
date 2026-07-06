using MediatR;
using Microsoft.AspNetCore.Mvc;
using VehicleTracker.Application.Contracts.Models.InputModels;
using VehicleTracker.Application.UseCases.Driver.Command;

namespace VehicleTracker.WebApi.Controllers;

public class DriverController : ApiControllerBase
{
    [HttpPost("register-manual")]
    [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RegisterDriverManual([FromBody] CreateUserInputModel input,
        CancellationToken ct)
    {
        var command = new ManualRegisterDriverCommand(input with { OwnerId = CurrentUserId });

        await Mediator.Send(command, ct);

        return Ok();
    }
}