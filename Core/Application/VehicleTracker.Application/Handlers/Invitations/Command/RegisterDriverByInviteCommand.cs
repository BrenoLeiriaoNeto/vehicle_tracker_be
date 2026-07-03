using MediatR;
using VehicleTracker.Application.Contracts.Models.InputModels;
using VehicleTracker.Application.Contracts.Models.ViewModels;

namespace VehicleTracker.Application.Handlers.Invitations.Command;

public record RegisterDriverByInviteCommand(
    CreateDriverByInviteInputModel Driver
    ) : IRequest<AuthViewModel>;