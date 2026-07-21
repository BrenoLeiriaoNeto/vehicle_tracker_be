using MediatR;
using VehicleTracker.Application.Contracts.Interfaces.Command;
using VehicleTracker.Exceptions.Profile;

namespace VehicleTracker.Application.UseCases.Profile.Command.ActivateProfile;

public class ActivateProfileCommandHandler(
    IProfileCommandRepository commandRepository
    ) : IRequestHandler<ActivateProfileCommand, Unit>
{
    public async Task<Unit> Handle(ActivateProfileCommand request, CancellationToken cancellationToken)
    {
        var result =
            await commandRepository.ReactivateAccountAsync(request.UserId, cancellationToken);

        return !result
            ? throw new ProfileNotFoundException("Perfil de usuário inexistente.")
            : Unit.Value;
    }
}