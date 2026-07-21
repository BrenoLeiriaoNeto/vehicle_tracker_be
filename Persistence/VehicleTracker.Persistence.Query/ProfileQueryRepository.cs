using MongoDB.Driver;
using VehicleTracker.Application.Contracts.Interfaces.Query;
using VehicleTracker.Domain.Enums;
using VehicleTracker.Domain.Models;

namespace VehicleTracker.Persistence.Query;

public class ProfileQueryRepository(IMongoDatabase database) : IProfileQueryRepository
{
    private readonly IMongoCollection<User> _usersCollection = database.GetCollection<User>("Users");
    
    private static readonly FilterDefinition<User> ActiveUsersFilter = Builders<User>.Filter.Eq(
        x => x.Auth.Status, UserStatus.Active);
    
    private static readonly FilterDefinition<User> InactiveUsersFilter = Builders<User>.Filter.Eq(
        x => x.Auth.Status, UserStatus.Inactive);

    public async Task<User?> GetProfileAsync(string userId, CancellationToken ct)
    {
        var filter = Builders<User>.Filter.Eq(x => x.Id, userId) & ActiveUsersFilter;

        return await _usersCollection.Find(filter).FirstOrDefaultAsync(ct);
    }

    public async Task<User?> GetProfileByEmailAsync(string email, CancellationToken ct)
    {
        var filter = Builders<User>.Filter.Eq(x => x.Auth.Email, email.ToLower().Trim())
                     & ActiveUsersFilter;

        return await _usersCollection.Find(filter).FirstOrDefaultAsync(ct);
    }

    public async Task<IEnumerable<User>> GetProfilesAsync(CancellationToken ct)
    {
        return await _usersCollection.Find(ActiveUsersFilter).ToListAsync(ct);
    }

    public async Task<IEnumerable<User>> GetDeactivatedProfilesAsync(CancellationToken ct)
    {
        return await _usersCollection.Find(InactiveUsersFilter).ToListAsync(ct);
    }
}