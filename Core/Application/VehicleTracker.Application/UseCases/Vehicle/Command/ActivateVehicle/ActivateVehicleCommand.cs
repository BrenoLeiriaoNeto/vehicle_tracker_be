using MediatR;

namespace VehicleTracker.Application.UseCases.Vehicle.Command;

public record ActivateVehicleCommand(string VehicleId) : IRequest<Unit>;