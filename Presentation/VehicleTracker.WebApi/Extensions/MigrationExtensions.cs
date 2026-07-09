using MongoDB.Driver;
using VehicleTracker.Persistence.MongoConfigurations;

namespace VehicleTracker.WebApi.Extensions;

public static class MigrationExtensions
{
    public static async Task ApplyMongoIndexesAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        
        var database = scope.ServiceProvider.GetRequiredService<IMongoDatabase>();

        var initializer = new MongoDbInitializer(database);
        
        await initializer.InitializeAsync();
    }
}