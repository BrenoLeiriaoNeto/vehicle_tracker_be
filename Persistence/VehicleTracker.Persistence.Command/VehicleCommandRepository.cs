using MongoDB.Driver;
using VehicleTracker.Application.Contracts.Interfaces.Command;
using VehicleTracker.Domain.Models;

namespace VehicleTracker.Persistence.Command;

public class VehicleCommandRepository(IMongoDatabase database) : IVehicleCommandRepository
{
    private readonly IMongoCollection<Vehicle> _vehiclesCollection =
        database.GetCollection<Vehicle>("Vehicles");
    
    public async Task CreateVehicleAsync(Vehicle vehicle, CancellationToken ct)
    {
        await _vehiclesCollection.InsertOneAsync(vehicle, null, ct);
    }

    public async Task UpdateVehicleAsync(Vehicle vehicle, CancellationToken ct)
    {
        var filter = Builders<Vehicle>.Filter.Eq(x => x.Id, vehicle.Id);
        await _vehiclesCollection.ReplaceOneAsync(filter, vehicle, cancellationToken: ct);
    }

    public async Task UpdateVehicleStatusAsync(Vehicle vehicle, CancellationToken ct)
    {
        var filter = Builders<Vehicle>.Filter.Eq(x => x.Id, vehicle.Id);
        var update = Builders<Vehicle>.Update.Set(x => x.Status, vehicle.Status);
        
        await _vehiclesCollection.UpdateOneAsync(filter, update, cancellationToken: ct);
    }

    public async Task UpdateCurrentKmAsync(Vehicle vehicle, CancellationToken ct)
    {
        var filter = Builders<Vehicle>.Filter.Eq(x => x.Id, vehicle.Id);
        var update = Builders<Vehicle>.Update.Set(x => x.CurrentKm, vehicle.CurrentKm);
        
        await _vehiclesCollection.UpdateOneAsync(filter, update, cancellationToken: ct);
    }

    public async Task DeleteVehicleAsync(Vehicle vehicle, CancellationToken ct)
    {
        var filter = Builders<Vehicle>.Filter.Eq(x => x.Id, vehicle.Id);
        var update = Builders<Vehicle>.Update.Set(x => x.IsDeleted, true);
        
        await _vehiclesCollection.UpdateOneAsync(filter, update, cancellationToken: ct);
    }
}