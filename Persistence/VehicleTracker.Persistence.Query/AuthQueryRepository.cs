using MongoDB.Driver;
using VehicleTracker.Application.Contracts.Interfaces.Query;
using VehicleTracker.Domain.Models;

namespace VehicleTracker.Persistence.Query;

public class AuthQueryRepository(IMongoDatabase database) : IAuthQueryRepository
{
    private readonly IMongoCollection<User>
        _usersCollection = database.GetCollection<User>("Users");

    public async Task<bool> IsEmailUnique(string email, CancellationToken ct)
    {
        var emailExists = await _usersCollection
            .Find(x => x.Auth.Email == email.ToLower().Trim())
            .AnyAsync(ct);
        
        return !emailExists;
    }

    public async Task<User?> GetUserByEmailAsync(string email, CancellationToken ct)
    {
        return await _usersCollection.Find(x => x.Auth.Email == email.ToLower().Trim())
            .FirstOrDefaultAsync(ct);
    }
}