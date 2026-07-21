using Microsoft.AspNetCore.Mvc;
using VehicleTracker.Application.Contracts.Models.UpdateModels;
using VehicleTracker.Application.Contracts.Models.ViewModels;
using VehicleTracker.Application.UseCases.Profile.Command.ActivateProfile;
using VehicleTracker.Application.UseCases.Profile.Command.DeactivateProfile;
using VehicleTracker.Application.UseCases.Profile.Command.UpdateAvatar;
using VehicleTracker.Application.UseCases.Profile.Command.UpdateProfile;
using VehicleTracker.Application.UseCases.Profile.Query.GetDeactivatedProfiles;
using VehicleTracker.Application.UseCases.Profile.Query.GetProfile;
using VehicleTracker.Application.UseCases.Profile.Query.GetProfileByEmail;
using VehicleTracker.Application.UseCases.Profile.Query.GetProfiles;

namespace VehicleTracker.WebApi.Controllers;

public class ProfileController : ApiControllerBase
{
    [HttpPatch]
    [ProducesResponseType(typeof(bool), StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateProfile([FromBody] ProfileUpdateModel update,
        CancellationToken ct)
    {
        var command = new UpdateProfileCommand(CurrentUserId, update);

        var res = await Mediator.Send(command, ct);

        if (res) return NoContent();
        
        return BadRequest();
    }

    [HttpPatch("reactivate/{id}")]
    [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> ReactivateAccount([FromRoute] string id, CancellationToken ct)
    {
        var command = new ActivateProfileCommand(id);

        await Mediator.Send(command, ct);

        return NoContent();
    }

    [HttpPatch("deactivate/{id}")]
    [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeactivateAccount([FromRoute] string id, CancellationToken ct)
    {
        var command = new DeactivateProfileCommand(id);

        await Mediator.Send(command, ct);

        return NoContent();
    }

    [HttpPost("avatar")]
    [ProducesResponseType(typeof(string), StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateAvatar([FromForm] IFormFile avatar, CancellationToken ct)
    {
        await using var stream = avatar.OpenReadStream();

        var command = new UpdateAvatarCommand(new AvatarUpdateModel(
            CurrentUserId,
            stream,
            avatar.FileName,
            avatar.ContentType
        ));

        var avatarUrl = await Mediator.Send(command, ct);
        
        return Ok(avatarUrl);
    }

    [HttpGet("{id?}")]
    [ProducesResponseType(typeof(ProfileViewModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetProfile([FromRoute] string? id, CancellationToken ct)
    {
        var query = new GetProfileQuery(id ?? CurrentUserId);

        var profile = await Mediator.Send(query, ct);

        return Ok(profile);
    }

    [HttpGet]
    [ProducesResponseType(typeof(ProfileViewModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetProfileByEmail([FromQuery] string email,
        CancellationToken ct)
    {
        var query = new GetProfileByEmailQuery(email);

        var profile = await Mediator.Send(query, ct);

        return Ok(profile);
    }

    [HttpGet("active")]
    [ProducesResponseType(typeof(List<ProfileViewModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetActiveProfiles(CancellationToken ct)
    {
        var query = new GetProfilesQuery();

        var profiles = await Mediator.Send(query, ct);

        return Ok(profiles);
    }
    
    [HttpGet("inactive")]
    [ProducesResponseType(typeof(List<ProfileViewModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetInactiveProfiles(CancellationToken ct)
    {
        var query = new GetDeactivatedProfilesQuery();

        var profiles = await Mediator.Send(query, ct);

        return Ok(profiles);
    }
}