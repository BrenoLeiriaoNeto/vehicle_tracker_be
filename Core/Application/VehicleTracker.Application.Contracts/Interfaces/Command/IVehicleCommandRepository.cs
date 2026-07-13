using VehicleTracker.Domain.Models;

namespace VehicleTracker.Application.Contracts.Interfaces.Command;

public interface IVehicleCommandRepository
{
    Task CreateVehicleAsync(Vehicle vehicle, CancellationToken ct);
    Task<bool> UpdateVehicleStatusAndKmAsync(Vehicle vehicle, CancellationToken ct);
    Task<bool> UpdateVehicleStatusAsync(Vehicle vehicle, CancellationToken ct);
    Task<bool> UpdateCurrentKmAsync(Vehicle vehicle, CancellationToken ct);
    Task<bool> DeleteVehicleAsync(string vehicleId, CancellationToken ct);
    Task<bool> ActivateVehicleAsync(string vehicleId, CancellationToken ct);
}