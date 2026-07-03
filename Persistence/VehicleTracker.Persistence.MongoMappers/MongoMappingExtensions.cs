using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using VehicleTracker.Domain.Models;

namespace VehicleTracker.Persistence.MongoMappers;

public static class MongoMappingExtensions
{
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

                cm.MapConstructor(typeof(Invitation).GetConstructor(
                    System.Reflection.BindingFlags.Instance |
                    System.Reflection.BindingFlags.NonPublic,
                    null, Type.EmptyTypes, null));
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