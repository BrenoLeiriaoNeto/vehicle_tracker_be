using MediatR;
using VehicleTracker.Application.Contracts.Interfaces.Command;
using VehicleTracker.Application.Contracts.Interfaces.Mappers;
using VehicleTracker.Exceptions.Vehicle;

namespace VehicleTracker.Application.UseCases.Vehicle.Command.ActivateVehicle;

public class ActivateVehicleCommandHandler(
    IVehicleCommandRepository commandRepository,
    IVehicleMapper mapper
    ) : IRequestHandler<ActivateVehicleCommand, Unit>
{
    public async Task<Unit> Handle(ActivateVehicleCommand request, CancellationToken cancellationToken)
    {
        var result =
            await commandRepository.ActivateVehicleAsync(request.VehicleId, cancellationToken);

        return !result
            ? throw new VehicleNotFoundException("Veículo não encontrado.")
            : Unit.Value;
    }
}