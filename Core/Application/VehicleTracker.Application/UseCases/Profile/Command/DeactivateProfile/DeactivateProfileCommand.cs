using MediatR;

namespace VehicleTracker.Application.UseCases.Profile.Command.DeactivateProfile;

public record DeactivateProfileCommand(string UserId) : IRequest<Unit>;