using MongoDB.Driver;
using VehicleTracker.Domain.Models;

namespace VehicleTracker.Persistence.MongoConfigurations;

public class MongoDbInitializer(IMongoDatabase database)
{
    public async Task InitializeAsync()
    {
        await CreateUserIndexesAsync();
        await CreateVehicleIndexesAsync();
    }

    private async Task CreateVehicleIndexesAsync()
    {
        var collection = database.GetCollection<Vehicle>("Vehicles");

        var vehicleIndexKeys = Builders<Vehicle>.IndexKeys
            .Ascending(x => x.OwnerId)
            .Ascending(x => x.IsDeleted);

        var indexOptions = new CreateIndexOptions
        {
            Name = "IX_Vehicles_OwnerId_IsDeleted",
        };
        
        var indexModel = new CreateIndexModel<Vehicle>(vehicleIndexKeys, indexOptions);
        await collection.Indexes.CreateOneAsync(indexModel);
    }

    private async Task CreateUserIndexesAsync()
    {
        var collection = database.GetCollection<User>("Users");
        
        var emailIndexKeys = Builders<User>.IndexKeys.Ascending(x => x.Auth.Email);

        var indexOptions = new CreateIndexOptions
        {
            Name = "UX_Users_Auth_Email",
            Unique = true
        };
        
        var indexModel = new CreateIndexModel<User>(emailIndexKeys, indexOptions);
        
        await collection.Indexes.CreateOneAsync(indexModel);
    }
}