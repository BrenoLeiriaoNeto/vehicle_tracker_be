using MongoDB.Driver;
using VehicleTracker.Application.Contracts.Interfaces.Query;
using VehicleTracker.Domain.Enums;
using VehicleTracker.Domain.Models;

namespace VehicleTracker.Persistence.Query;

public class VehicleQueryRepository(IMongoDatabase database) : IVehicleQueryRepository
{
    private readonly IMongoCollection<Vehicle> _vehiclesCollection =
        database.GetCollection<Vehicle>("Vehicles");
    
    private static readonly FilterDefinition<Vehicle> ActiveVehiclesFilter
        = Builders<Vehicle>.Filter.Eq(x => x.IsDeleted, false);

    public async Task<Vehicle> GetVehicleByIdAsync(string id, CancellationToken ct)
    {
        var filter = Builders<Vehicle>.Filter.Eq(x => x.Id, id) & ActiveVehiclesFilter;
        
        return await _vehiclesCollection.Find(filter).FirstOrDefaultAsync(ct);
    }

    public async Task<IEnumerable<Vehicle>> GetVehicles(VehicleStatus? status, string? userId,
        CancellationToken ct)
    {
        var filter = ActiveVehiclesFilter;

        if (status.HasValue)
        {
            filter &= Builders<Vehicle>.Filter.Eq(x => x.Status, status.Value);
        }

        if (!string.IsNullOrWhiteSpace(userId))
        {
            filter &= Builders<Vehicle>.Filter.Eq(x => x.OwnerId, userId);
        }
        
        return await _vehiclesCollection.Find(filter).ToListAsync(ct);
    }

    public async Task<bool> IsPlateUnique(string plate, CancellationToken ct)
    {
        var filter = Builders<Vehicle>.Filter.Eq(x => x.Plate, plate.ToUpper().Trim()) &
                     ActiveVehiclesFilter;
        
        var anyExists = await _vehiclesCollection.Find(filter).AnyAsync(ct);

        return !anyExists;
    }
}