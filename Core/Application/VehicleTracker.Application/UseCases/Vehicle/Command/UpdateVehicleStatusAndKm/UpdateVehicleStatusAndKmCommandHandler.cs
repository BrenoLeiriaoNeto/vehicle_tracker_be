using MediatR;
using VehicleTracker.Application.Contracts.Interfaces.Command;
using VehicleTracker.Application.Contracts.Interfaces.Mappers;
using VehicleTracker.Application.UseCases.Vehicle.Command;
using VehicleTracker.Exceptions.Vehicle;

namespace VehicleTracker.Application.UseCases.Vehicle.Handlers;

public class UpdateVehicleStatusAndKmCommandHandler(
    IVehicleCommandRepository commandRepository,
    IVehicleMapper mapper
    ) : IRequestHandler<UpdateVehicleStatusAndKmCommand, Unit>
{
    public async Task<Unit> Handle(UpdateVehicleStatusAndKmCommand request, CancellationToken cancellationToken)
    {
        var vehicle = mapper.MapToDomain(request.Update);

        var result =
            await commandRepository.UpdateVehicleStatusAndKmAsync(vehicle, cancellationToken);

        return !result
            ? throw new VehicleNotFoundException("Veículo não encontrado.")
            : Unit.Value;
    }
}