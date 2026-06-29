using MongoDB.Driver;
using VehicleTracker.Application.Contracts.Interfaces.Command;
using VehicleTracker.Domain.Models;

namespace VehicleTracker.Persistence.Command;

public class AuthCommandRepository(IMongoDatabase database) : IAuthCommandRepository
{
    private readonly IMongoCollection<User> _usersCollection = database.GetCollection<User>("Users");

    public async Task CreateUserAsync(User user, CancellationToken ct)
    {
        await _usersCollection.InsertOneAsync(user, null, ct);
    }
}