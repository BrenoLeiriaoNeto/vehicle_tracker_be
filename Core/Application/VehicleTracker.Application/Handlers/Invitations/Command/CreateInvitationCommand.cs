using MediatR;
using VehicleTracker.Application.Contracts.Models.InputModels;
using VehicleTracker.Application.Contracts.Models.ViewModels;

namespace VehicleTracker.Application.Handlers.Invitations.Command;

public record CreateInvitationCommand(CreateInvitationInputModel Input)
    : IRequest<InvitationViewModel>;