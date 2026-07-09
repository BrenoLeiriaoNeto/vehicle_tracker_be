using MongoDB.Driver;
using VehicleTracker.Application.Contracts.Interfaces.Query;
using VehicleTracker.Domain.Enums;
using VehicleTracker.Domain.Models;

namespace VehicleTracker.Persistence.Query;

public class VehicleQueryRepository(IMongoDatabase database) : IVehicleQueryRepository
{
    private readonly IMongoCollection<Vehicle> _vehiclesCollection =
        database.GetCollection<Vehicle>("Vehicles");
    
    public async Task<IEnumerable<Vehicle>> GetAllVehiclesAsync(CancellationToken ct)
    {
        var filter = Builders<Vehicle>.Filter.Eq(x => x.IsDeleted, false);
        return await _vehiclesCollection.Find(filter).ToListAsync(ct);
    }

    public async Task<Vehicle> GetVehicleByIdAsync(string id, CancellationToken ct)
    {
        var filter = Builders<Vehicle>.Filter.And(
            Builders<Vehicle>.Filter.Eq(x => x.Id, id),
            Builders<Vehicle>.Filter.Eq(x => x.IsDeleted, false));
        
        return await _vehiclesCollection.Find(filter).FirstOrDefaultAsync(ct);
    }

    public async Task<IEnumerable<Vehicle>> GetVehiclesByStatusAsync(VehicleStatus status, CancellationToken ct)
    {
        var filter = Builders<Vehicle>.Filter.And(
            Builders<Vehicle>.Filter.Eq(x => x.Status, status),
            Builders<Vehicle>.Filter.Eq(x => x.IsDeleted, false));
        
        return await _vehiclesCollection.Find(filter).ToListAsync(ct);
    }

    public async Task<IEnumerable<Vehicle>> GetVehiclesByUserIdAsync(string userId, CancellationToken ct)
    {
        var filter = Builders<Vehicle>.Filter.And(
            Builders<Vehicle>.Filter.Eq(x => x.OwnerId, userId),
            Builders<Vehicle>.Filter.Eq(x => x.IsDeleted, false));
        
        return await _vehiclesCollection.Find(filter).ToListAsync(ct);
    }

    public async Task<bool> IsPlateUnique(string plate, CancellationToken ct)
    {
        var filter = Builders<Vehicle>.Filter.And(
            Builders<Vehicle>.Filter.Eq(x => x.Plate, plate.ToUpper().Trim()),
            Builders<Vehicle>.Filter.Eq(x => x.IsDeleted, false));
        
        var anyExists = await _vehiclesCollection.Find(filter).AnyAsync(ct);

        return !anyExists;
    }
}