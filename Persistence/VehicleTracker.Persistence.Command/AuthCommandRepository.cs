using MongoDB.Driver;
using VehicleTracker.Application.Contracts.Interfaces.Command;
using VehicleTracker.Domain.Models;

namespace VehicleTracker.Persistence.Command;

public class AuthCommandRepository(IMongoDatabase database) : IAuthCommandRepository
{
    private readonly IMongoCollection<User> _usersCollection = database.GetCollection<User>("Users");

    public async Task CreateUserAsync(IClientSessionHandle session, User user, CancellationToken ct)
    {
        await _usersCollection.InsertOneAsync(session, user, null, ct);
    }

    public async Task CreateUserAsync(User user, CancellationToken ct)
    {
        await _usersCollection.InsertOneAsync(user, null, ct);
    }

    public async Task UpdateUserAsync(string userId, string refreshToken, CancellationToken ct)
    {
        var filter = Builders<User>.Filter.Eq(x => x.Id, userId);

        var update = Builders<User>.Update
            .Set(x => x.Auth.RefreshToken, refreshToken)
            .Set(x => x.Auth.RefreshTokenExpiresAt, DateTime.UtcNow.AddMinutes(15));

        await _usersCollection.UpdateOneAsync(filter, update, cancellationToken: ct);
    }
}