using MediatR;
using VehicleTracker.Application.Contracts.Interfaces.Command;
using VehicleTracker.Application.Contracts.Interfaces.Mappers;
using VehicleTracker.Application.UseCases.Vehicle.Command;
using VehicleTracker.Exceptions.Vehicle;

namespace VehicleTracker.Application.UseCases.Vehicle.Handlers;

public class UpdateVehicleCurrentKmCommandHandler(
    IVehicleCommandRepository commandRepository,
    IVehicleMapper mapper) : IRequestHandler<UpdateVehicleCurrentKmCommand, Unit>
{
    public async Task<Unit> Handle(UpdateVehicleCurrentKmCommand request, CancellationToken cancellationToken)
    {
        var vehicle = mapper.MapToDomain(request.Update);

        var result = await commandRepository.UpdateCurrentKmAsync(vehicle, cancellationToken);

        return !result
            ? throw new VehicleNotFoundException("Veículo não encontrado.")
            : Unit.Value;
    }
}