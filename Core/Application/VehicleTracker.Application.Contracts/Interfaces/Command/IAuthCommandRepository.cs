using VehicleTracker.Domain.Models;

namespace VehicleTracker.Application.Contracts.Interfaces.Command;

public interface IAuthCommandRepository
{
    Task CreateUserAsync(User user, CancellationToken ct);
}