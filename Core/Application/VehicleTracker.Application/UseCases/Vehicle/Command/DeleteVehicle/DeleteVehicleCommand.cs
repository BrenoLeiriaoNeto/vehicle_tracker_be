using MediatR;

namespace VehicleTracker.Application.UseCases.Vehicle.Command.DeleteVehicle;

public record DeleteVehicleCommand(string VehicleId) : IRequest<Unit>;