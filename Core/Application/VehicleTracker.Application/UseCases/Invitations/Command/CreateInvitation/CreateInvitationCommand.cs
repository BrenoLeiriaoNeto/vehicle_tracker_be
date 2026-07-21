using MediatR;
using VehicleTracker.Application.Contracts.Models.InputModels;
using VehicleTracker.Application.Contracts.Models.ViewModels;

namespace VehicleTracker.Application.UseCases.Invitations.Command.CreateInvitation;

public record CreateInvitationCommand(CreateInvitationInputModel Input)
    : IRequest<InvitationViewModel>;