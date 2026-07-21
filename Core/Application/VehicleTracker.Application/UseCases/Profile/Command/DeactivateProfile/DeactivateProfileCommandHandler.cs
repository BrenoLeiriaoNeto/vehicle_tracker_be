using MediatR;
using VehicleTracker.Application.Contracts.Interfaces.Command;
using VehicleTracker.Exceptions.Profile;

namespace VehicleTracker.Application.UseCases.Profile.Command.DeactivateProfile;

public class DeactivateProfileCommandHandler
    (IProfileCommandRepository commandRepository)
    : IRequestHandler<DeactivateProfileCommand, Unit>
{
    public async Task<Unit> Handle(DeactivateProfileCommand request, CancellationToken cancellationToken)
    {
        var result =
            await commandRepository.DeactivateAccountAsync(request.UserId, cancellationToken);

        return !result 
            ? throw new ProfileNotFoundException("Perfil de usuário inexistente.") 
            : Unit.Value;
    }
}