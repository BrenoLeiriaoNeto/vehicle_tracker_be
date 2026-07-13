using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using VehicleTracker.Domain.Models;

namespace VehicleTracker.Persistence.MongoConfigurations;

public static class MongoMappingExtensions
{

    public static void ConfigureVehicleMapping()
    {
        if (!BsonClassMap.IsClassMapRegistered(typeof(Vehicle)))
        {
            BsonClassMap.RegisterClassMap<Vehicle>(cm =>
            {
                cm.AutoMap();

                cm.MapIdProperty(c => c.Id)
                    .SetIdGenerator(StringObjectIdGenerator.Instance)
                    .SetSerializer(new StringSerializer(BsonType.ObjectId));
            });
        }
    }
    public static void ConfigureInvitationMapping()
    {
        if (!BsonClassMap.IsClassMapRegistered(typeof(Invitation)))
        {
            BsonClassMap.RegisterClassMap<Invitation>(cm =>
            {
                cm.AutoMap();

                cm.MapIdProperty(c => c.Id)
                    .SetIdGenerator(StringObjectIdGenerator.Instance)
                    .SetSerializer(new StringSerializer(BsonType.ObjectId));
            });
        }
    }

    public static void ConfigureUserMapping()
    {
        if (!BsonClassMap.IsClassMapRegistered(typeof(User)))
        {
            BsonClassMap.RegisterClassMap<User>(cm =>
            {
                cm.AutoMap();

                cm.MapIdProperty(c => c.Id)
                    .SetIdGenerator(StringObjectIdGenerator.Instance)
                    .SetSerializer(new StringSerializer(BsonType.ObjectId));
            });
        }
    }
}