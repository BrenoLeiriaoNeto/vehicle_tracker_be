using Microsoft.AspNetCore.Mvc;
using VehicleTracker.Application.Contracts.Models.InputModels;
using VehicleTracker.Application.UseCases.Invitations.Command;

namespace VehicleTracker.WebApi.Controllers;

public class InvitationController : ApiControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateInvitation([FromBody] string driverEmail,
        CancellationToken ct)
    {
        var command = new CreateInvitationCommand(new CreateInvitationInputModel
        {
            DriverEmail = driverEmail,
            OwnerId = CurrentUserId
        });

        var result = await Mediator.Send(command, ct);

        return Ok(result);
    }
}