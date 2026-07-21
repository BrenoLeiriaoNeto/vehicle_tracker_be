using MongoDB.Driver;
using VehicleTracker.Application.Contracts.Interfaces.Command;
using VehicleTracker.Domain.Enums;
using VehicleTracker.Domain.Models;

namespace VehicleTracker.Persistence.Command;

public class ProfileCommandRepository(IMongoDatabase database) : IProfileCommandRepository
{
    private readonly IMongoCollection<User> _usersCollection = database.GetCollection<User>("Users");

    private static readonly FilterDefinition<User> ActiveUsersFilter = Builders<User>.Filter.Eq(
        x => x.Auth.Status, UserStatus.Active);
    
    private static readonly FilterDefinition<User> InactiveUsersFilter = Builders<User>.Filter.Eq(
        x => x.Auth.Status, UserStatus.Inactive);
    
    public async Task<bool> UpdateProfileAsync(User user, CancellationToken ct)
    {
        var filter = Builders<User>.Filter.Eq(x => x.Id, user.Id) & ActiveUsersFilter;
        var update = Builders<User>.Update
            .Set(x => x.Name, user.Name)
            .Set(x => x.Bio, user.Bio);
        
        var result = await _usersCollection.UpdateOneAsync(filter, update, cancellationToken: ct);
        
        return result.IsAcknowledged && result.MatchedCount > 0;
    }

    public async Task UpdateProfilePictureAsync(string userId, string avatarUrl, CancellationToken ct)
    {
        var filter = Builders<User>.Filter.Eq(x => x.Id, userId) & ActiveUsersFilter;
        var update = Builders<User>.Update.Set(x => x.AvatarUrl, avatarUrl);
        
        await _usersCollection.UpdateOneAsync(filter, update, cancellationToken: ct);
    }

    public async Task<bool> DeactivateAccountAsync(string userId, CancellationToken ct)
    {
        var filter = Builders<User>.Filter.Eq(x => x.Id, userId) & ActiveUsersFilter;
        var update = Builders<User>.Update.Set(x => x.Auth.Status, UserStatus.Inactive);
        
        var result = await _usersCollection.UpdateOneAsync(filter, update, cancellationToken: ct);
        
        return result.IsAcknowledged && result.MatchedCount > 0;
    }

    public async Task<bool> ReactivateAccountAsync(string userId, CancellationToken ct)
    {
        var filter = Builders<User>.Filter.Eq(x => x.Id, userId) & InactiveUsersFilter;
        var update = Builders<User>.Update.Set(x => x.Auth.Status, UserStatus.Active);
        
        var result = await _usersCollection.UpdateOneAsync(filter, update, cancellationToken: ct);
        
        return result.IsAcknowledged && result.MatchedCount > 0;
    }

    public async Task<bool> UpdateProfileMetricsAsync(string userId, double sumKilometers,
        CancellationToken ct)
    {
        var filter = Builders<User>.Filter.Eq(x => x.Id, userId);
        var update = Builders<User>.Update
            .Inc(x => x.Metrics.SumKilometers, sumKilometers)
            .Inc(x => x.Metrics.TripsCompleted, 1)
            .Set(x => x.Metrics.LastTripDate, DateTime.UtcNow);
        
        var result = await _usersCollection.UpdateOneAsync(filter, update, cancellationToken: ct);
        
        return result.IsAcknowledged && result.MatchedCount > 0;
    }
}