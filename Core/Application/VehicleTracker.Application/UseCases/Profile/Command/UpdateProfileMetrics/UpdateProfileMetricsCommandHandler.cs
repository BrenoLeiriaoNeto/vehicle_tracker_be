using MediatR;
using VehicleTracker.Application.Contracts.Interfaces.Command;
using VehicleTracker.Exceptions.Profile;

namespace VehicleTracker.Application.UseCases.Profile.Command.UpdateProfileMetrics;

public class UpdateProfileMetricsCommandHandler(
    IProfileCommandRepository commandRepository
    ) : IRequestHandler<UpdateProfileMetricsCommand, Unit>
{
    public async Task<Unit> Handle(UpdateProfileMetricsCommand request, CancellationToken cancellationToken)
    {
        var result = await commandRepository.UpdateProfileMetricsAsync(request.UserId,
            request.SumKilometers, cancellationToken);

        return !result
            ? throw new ProfileNotFoundException("Perfil de usuário inexistente.")
            : Unit.Value;
    }
}