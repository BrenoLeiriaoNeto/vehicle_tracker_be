using MediatR;

namespace VehicleTracker.Application.UseCases.Profile.Command.ActivateProfile;

public record ActivateProfileCommand(string UserId) : IRequest<Unit>;