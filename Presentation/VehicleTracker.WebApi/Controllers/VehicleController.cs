using MediatR;
using Microsoft.AspNetCore.Mvc;
using VehicleTracker.Application.Contracts.Models.InputModels;
using VehicleTracker.Application.Contracts.Models.UpdateModels;
using VehicleTracker.Application.Contracts.Models.ViewModels;
using VehicleTracker.Application.UseCases.Vehicle.Command.ActivateVehicle;
using VehicleTracker.Application.UseCases.Vehicle.Command.CreateVehicle;
using VehicleTracker.Application.UseCases.Vehicle.Command.DeleteVehicle;
using VehicleTracker.Application.UseCases.Vehicle.Command.UpdateVehicleCurrentKm;
using VehicleTracker.Application.UseCases.Vehicle.Command.UpdateVehicleStatus;
using VehicleTracker.Application.UseCases.Vehicle.Command.UpdateVehicleStatusAndKm;
using VehicleTracker.Application.UseCases.Vehicle.Query.GetVehicleById;
using VehicleTracker.Application.UseCases.Vehicle.Query.GetVehicles;
using VehicleTracker.Domain.Enums;

namespace VehicleTracker.WebApi.Controllers;

public class VehicleController : ApiControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(Unit), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateVehicle([FromBody] CreateVehicleInputModel input,
        CancellationToken ct)
    {
        var command = new CreateVehicleCommand(input, CurrentUserName);

        await Mediator.Send(command, ct);

        return Created();
    }

    [HttpPatch("{id}/status")]
    [ProducesResponseType(typeof(Unit), StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateVehicleStatus([FromRoute] string id,
        [FromBody] VehicleUpdateModel update, CancellationToken ct)
    {
        var command = new UpdateVehicleStatusCommand(update with { Id = id });

        await Mediator.Send(command, ct);

        return NoContent();
    }

    [HttpPatch("{id}/km")]
    [ProducesResponseType(typeof(Unit), StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateVehicleKm([FromRoute] string id,
        [FromBody] VehicleUpdateModel update, CancellationToken ct)
    {
        var command = new UpdateVehicleCurrentKmCommand(update with { Id = id });

        await Mediator.Send(command, ct);

        return NoContent();
    }

    [HttpPatch("{id}/status-km")]
    [ProducesResponseType(typeof(Unit), StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateVehicleStatusAndKm([FromRoute] string id,
        [FromBody] VehicleUpdateModel update, CancellationToken ct)
    {
        var command = new UpdateVehicleStatusAndKmCommand(update with { Id = id });

        await Mediator.Send(command, ct);

        return NoContent();
    }

    [HttpPatch("{id}/activate")]
    [ProducesResponseType(typeof(Unit), StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ActivateVehicle([FromRoute] string id, CancellationToken ct)
    {
        var command = new ActivateVehicleCommand(id);

        await Mediator.Send(command, ct);

        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(Unit), StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteVehicle([FromRoute] string id, CancellationToken ct)
    {
        var command = new DeleteVehicleCommand(id);
        
        await Mediator.Send(command, ct);

        return NoContent();
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(VehicleViewModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetVehicleById([FromRoute] string id, CancellationToken ct)
    {
        var query = new GetVehicleByIdQuery(id);

        var vehicle = await Mediator.Send(query, ct);

        return Ok(vehicle);
    }

    [HttpGet("all")]
    [ProducesResponseType(typeof(List<VehicleViewModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetVehicles(
        [FromQuery] VehicleStatus? status,
        [FromQuery] bool onlyMyVehicles,
        CancellationToken ct)
    {
        var userId = onlyMyVehicles ? CurrentUserId : null;

        var query = new GetVehiclesQuery(status, userId);
        
        var vehicles = await Mediator.Send(query, ct);
        
        return Ok(vehicles);
    }
}