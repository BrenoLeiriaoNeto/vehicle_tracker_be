using MediatR;

namespace VehicleTracker.Application.UseCases.Vehicle.Command;

public record DeleteVehicleCommand(string VehicleId) : IRequest<Unit>;