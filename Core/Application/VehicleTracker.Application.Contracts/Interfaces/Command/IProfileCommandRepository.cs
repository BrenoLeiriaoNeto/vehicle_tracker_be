using VehicleTracker.Domain.Models;

namespace VehicleTracker.Application.Contracts.Interfaces.Command;

public interface IProfileCommandRepository
{
    Task<bool> UpdateProfileAsync(User user, CancellationToken ct);
    Task UpdateProfilePictureAsync(string userId, string avatarUrl, CancellationToken ct);
    Task<bool> DeactivateAccountAsync(string userId, CancellationToken ct);
    Task<bool> ReactivateAccountAsync(string userId, CancellationToken ct);
    Task<bool> UpdateProfileMetricsAsync(string userId, double sumKilometers, CancellationToken ct);
}