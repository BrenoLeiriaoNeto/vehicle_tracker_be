using MediatR;
using VehicleTracker.Application.Contracts.Models.UpdateModels;

namespace VehicleTracker.Application.UseCases.Profile.Command.UpdateAvatar;

public record UpdateAvatarCommand(AvatarUpdateModel Update) : IRequest<string>;