using MongoDB.Driver;
using VehicleTracker.Application.Contracts.Interfaces.Query;
using VehicleTracker.Application.Contracts.Models.ViewModels;
using VehicleTracker.Domain.Models;

namespace VehicleTracker.Persistence.Query;

public class AuthQueryRepository(IMongoDatabase database) : IAuthQueryRepository
{
    private readonly IMongoCollection<User> _usersCollection = database.GetCollection<User>("Users");
    
    public async Task<AuthViewModel> LoginAsync(User user)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> IsEmailUnique(string email, CancellationToken ct)
    {
        var emailExists = await _usersCollection
            .Find(x => x.Email == email.ToLower().Trim())
            .AnyAsync(ct);
        
        return !emailExists;
    }
}