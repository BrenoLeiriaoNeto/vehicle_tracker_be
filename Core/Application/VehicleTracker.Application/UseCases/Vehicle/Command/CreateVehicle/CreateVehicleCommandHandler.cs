using MediatR;
using VehicleTracker.Application.Contracts.Interfaces.Command;
using VehicleTracker.Application.Contracts.Interfaces.Mappers;

namespace VehicleTracker.Application.UseCases.Vehicle.Command.CreateVehicle;

public class CreateVehicleCommandHandler(
    IVehicleCommandRepository commandRepository,
    IVehicleMapper mapper) : IRequestHandler<CreateVehicleCommand, Unit>
{
    public async Task<Unit> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
    {
        var newVehicle = mapper.MapToDomain(request.Input);
        newVehicle.MarkCreated(request.Name, request.Input.OwnerId);

        await commandRepository.CreateVehicleAsync(newVehicle, cancellationToken);

        return Unit.Value;
    }
}