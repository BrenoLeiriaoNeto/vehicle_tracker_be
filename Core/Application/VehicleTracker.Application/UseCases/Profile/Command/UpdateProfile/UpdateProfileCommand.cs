using MediatR;
using VehicleTracker.Application.Contracts.Models.UpdateModels;

namespace VehicleTracker.Application.UseCases.Profile.Command.UpdateProfile;

public record UpdateProfileCommand(string UserId, ProfileUpdateModel Update): IRequest<bool>;