using MediatR;
using VehicleTracker.Application.Contracts.Models.InputModels;
using VehicleTracker.Application.Contracts.Models.ViewModels;

namespace VehicleTracker.Application.UseCases.Invitations.Command;

public record RegisterDriverByInviteCommand(
    CreateDriverByInviteInputModel Driver
    ) : IRequest<AuthViewModel>;