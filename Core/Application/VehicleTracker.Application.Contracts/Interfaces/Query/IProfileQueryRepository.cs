using VehicleTracker.Domain.Models;

namespace VehicleTracker.Application.Contracts.Interfaces.Query;

public interface IProfileQueryRepository
{
    Task<User?> GetProfileAsync(string userId, CancellationToken ct);
    Task<User?> GetProfileByEmailAsync(string email, CancellationToken ct);
    Task<IEnumerable<User>> GetProfilesAsync(CancellationToken ct);
    Task<IEnumerable<User>> GetDeactivatedProfilesAsync(CancellationToken ct);
}