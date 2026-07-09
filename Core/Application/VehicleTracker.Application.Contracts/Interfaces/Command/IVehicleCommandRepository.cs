using VehicleTracker.Domain.Models;

namespace VehicleTracker.Application.Contracts.Interfaces.Command;

public interface IVehicleCommandRepository
{
    Task CreateVehicleAsync(Vehicle vehicle, CancellationToken ct);
    Task UpdateVehicleAsync(Vehicle vehicle, CancellationToken ct);
    Task UpdateVehicleStatusAsync(Vehicle vehicle, CancellationToken ct);
    Task UpdateCurrentKmAsync(Vehicle vehicle, CancellationToken ct);
    Task DeleteVehicleAsync(Vehicle vehicle, CancellationToken ct);
}