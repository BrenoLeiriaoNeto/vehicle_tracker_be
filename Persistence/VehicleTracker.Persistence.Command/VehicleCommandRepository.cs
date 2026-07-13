using MongoDB.Driver;
using VehicleTracker.Application.Contracts.Interfaces.Command;
using VehicleTracker.Domain.Models;

namespace VehicleTracker.Persistence.Command;

public class VehicleCommandRepository(IMongoDatabase database) : IVehicleCommandRepository
{
    private readonly IMongoCollection<Vehicle> _vehiclesCollection =
        database.GetCollection<Vehicle>("Vehicles");
    
    private static readonly FilterDefinition<Vehicle> ActiveVehiclesFilter
        = Builders<Vehicle>.Filter.Eq(x => x.IsDeleted, false);
    
    private static readonly FilterDefinition<Vehicle> InactiveVehiclesFilter
        = Builders<Vehicle>.Filter.Eq(x => x.IsDeleted, true);
    
    public async Task CreateVehicleAsync(Vehicle vehicle, CancellationToken ct)
    {
        await _vehiclesCollection.InsertOneAsync(vehicle, null, ct);
    }

    public async Task<bool> UpdateVehicleStatusAndKmAsync(Vehicle vehicle, CancellationToken ct)
    {
        var filter = Builders<Vehicle>.Filter.Eq(x => x.Id, vehicle.Id)
                     & ActiveVehiclesFilter;
        var update = Builders<Vehicle>.Update
            .Set(x => x.Status, vehicle.Status)
            .Set(x => x.CurrentKm, vehicle.CurrentKm);

        var result =
            await _vehiclesCollection.UpdateOneAsync(filter, update, cancellationToken: ct);
        
        return result.IsAcknowledged && result.MatchedCount > 0;
    }

    public async Task<bool> UpdateVehicleStatusAsync(Vehicle vehicle, CancellationToken ct)
    {
        var filter = Builders<Vehicle>.Filter.Eq(x => x.Id, vehicle.Id) 
                     & ActiveVehiclesFilter;
        var update = Builders<Vehicle>.Update.Set(x => x.Status, vehicle.Status);

        var result =
            await _vehiclesCollection.UpdateOneAsync(filter, update, cancellationToken: ct);
        
        return result.IsAcknowledged && result.MatchedCount > 0;
    }

    public async Task<bool> UpdateCurrentKmAsync(Vehicle vehicle, CancellationToken ct)
    {
        var filter = Builders<Vehicle>.Filter.Eq(x => x.Id, vehicle.Id) 
                     & ActiveVehiclesFilter;
        var update = Builders<Vehicle>.Update.Set(x => x.CurrentKm, vehicle.CurrentKm);

        var result =
            await _vehiclesCollection.UpdateOneAsync(filter, update, cancellationToken: ct);
        
        return result.IsAcknowledged && result.MatchedCount > 0;
    }

    public async Task<bool> DeleteVehicleAsync(string vehicleId, CancellationToken ct)
    {
        var filter = Builders<Vehicle>.Filter.Eq(x => x.Id, vehicleId) 
                     & ActiveVehiclesFilter;
        var update = Builders<Vehicle>.Update.Set(x => x.IsDeleted, true);

        var result =
            await _vehiclesCollection.UpdateOneAsync(filter, update, cancellationToken: ct);
        
        return result.IsAcknowledged && result.MatchedCount > 0;
    }

    public async Task<bool> ActivateVehicleAsync(string vehicleId, CancellationToken ct)
    {
        var filter = Builders<Vehicle>.Filter.Eq(x => x.Id, vehicleId) 
                     & InactiveVehiclesFilter;

        var update = Builders<Vehicle>.Update.Set(x => x.IsDeleted, false);
        
        var result =
            await _vehiclesCollection.UpdateOneAsync(filter, update, cancellationToken: ct);
        
        return result.IsAcknowledged && result.MatchedCount > 0;
    }
}