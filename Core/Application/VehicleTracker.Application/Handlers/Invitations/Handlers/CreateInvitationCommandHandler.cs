using MediatR;
using VehicleTracker.Application.Contracts.Interfaces.Command;
using VehicleTracker.Application.Contracts.Interfaces.Mappers;
using VehicleTracker.Application.Contracts.Models.ViewModels;
using VehicleTracker.Application.Handlers.Invitations.Command;

namespace VehicleTracker.Application.Handlers.Invitations.Handlers;

public class CreateInvitationCommandHandler(
    IInvitationCommandRepository commandRepository,
    IInvitationMapper mapper
    ) : IRequestHandler<CreateInvitationCommand, InvitationViewModel>
{
    public async Task<InvitationViewModel> Handle(CreateInvitationCommand request,
        CancellationToken cancellationToken)
    {
        var invitation = mapper.MapToDomain(request.Input);

        await commandRepository.CreateInvitationAsync(invitation, cancellationToken);
        
        return mapper.MapToViewModel(invitation);
    }
}