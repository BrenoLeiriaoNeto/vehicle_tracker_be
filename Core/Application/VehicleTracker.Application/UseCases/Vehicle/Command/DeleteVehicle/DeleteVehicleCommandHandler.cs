using MediatR;
using VehicleTracker.Application.Contracts.Interfaces.Command;
using VehicleTracker.Application.Contracts.Interfaces.Mappers;
using VehicleTracker.Exceptions.Vehicle;

namespace VehicleTracker.Application.UseCases.Vehicle.Command.DeleteVehicle;

public class DeleteVehicleCommandHandler(
    IVehicleCommandRepository commandRepository,
    IVehicleMapper mapper
    ) : IRequestHandler<DeleteVehicleCommand, Unit>
{
    public async Task<Unit> Handle(DeleteVehicleCommand request, CancellationToken cancellationToken)
    {
        var result =
            await commandRepository.DeleteVehicleAsync(request.VehicleId, cancellationToken);

        return !result
            ? throw new VehicleNotFoundException("Veículo não encontrado.")
            : Unit.Value;
    }
}