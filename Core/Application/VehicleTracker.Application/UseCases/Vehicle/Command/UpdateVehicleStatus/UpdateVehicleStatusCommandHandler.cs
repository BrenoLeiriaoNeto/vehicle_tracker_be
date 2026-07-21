using MediatR;
using VehicleTracker.Application.Contracts.Interfaces.Command;
using VehicleTracker.Application.Contracts.Interfaces.Mappers;
using VehicleTracker.Exceptions.Vehicle;

namespace VehicleTracker.Application.UseCases.Vehicle.Command.UpdateVehicleStatus;

public class UpdateVehicleStatusCommandHandler(
    IVehicleCommandRepository commandRepository,
    IVehicleMapper mapper
    ) : IRequestHandler<UpdateVehicleStatusCommand, Unit>
{
    public async Task<Unit> Handle(UpdateVehicleStatusCommand request, CancellationToken cancellationToken)
    {
        var vehicle = mapper.MapToDomain(request.Update);

        var result = await commandRepository.UpdateVehicleStatusAsync(vehicle, cancellationToken);

        return !result 
            ? throw new VehicleNotFoundException("Veículo não encontrado.") 
            : Unit.Value;
    }
}