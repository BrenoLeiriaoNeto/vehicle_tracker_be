using VehicleTracker.Domain.Models;

namespace VehicleTracker.Application.Contracts.Interfaces.Query;

public interface IAuthQueryRepository
{
    Task<bool> IsEmailUnique(string email, CancellationToken ct);
    Task<User?> GetUserByEmailAsync(string email, CancellationToken ct);
}