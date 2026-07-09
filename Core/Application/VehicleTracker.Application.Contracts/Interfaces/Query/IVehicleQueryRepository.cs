using VehicleTracker.Domain.Enums;
using VehicleTracker.Domain.Models;

namespace VehicleTracker.Application.Contracts.Interfaces.Query;

public interface IVehicleQueryRepository
{
    Task<IEnumerable<Vehicle>> GetAllVehiclesAsync(CancellationToken ct);
    Task<Vehicle> GetVehicleByIdAsync(string id, CancellationToken ct);
    Task<IEnumerable<Vehicle>> GetVehiclesByStatusAsync(VehicleStatus status, CancellationToken ct);
    Task<IEnumerable<Vehicle>> GetVehiclesByUserIdAsync(string userId, CancellationToken ct);
    Task<bool> IsPlateUnique(string plate, CancellationToken ct);
}