using MediatR;

namespace VehicleTracker.Application.UseCases.Vehicle.Command.ActivateVehicle;

public record ActivateVehicleCommand(string VehicleId) : IRequest<Unit>;