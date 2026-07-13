using VehicleTracker.Domain.Enums;
using VehicleTracker.Domain.Models;

namespace VehicleTracker.Application.Contracts.Interfaces.Query;

public interface IVehicleQueryRepository
{
    Task<Vehicle> GetVehicleByIdAsync(string id, CancellationToken ct);
    Task<IEnumerable<Vehicle>> GetVehicles(VehicleStatus? status, string? userId, CancellationToken ct);
    Task<bool> IsPlateUnique(string plate, CancellationToken ct);
}