using MongoDB.Driver;
using VehicleTracker.Domain.Models;

namespace VehicleTracker.Application.Contracts.Interfaces.Command;

public interface IAuthCommandRepository
{
    Task CreateUserAsync(IClientSessionHandle session, User user, CancellationToken ct);
    Task CreateUserAsync(User user, CancellationToken ct);
}