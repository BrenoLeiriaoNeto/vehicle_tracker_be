using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using VehicleTracker.Application.Contracts.Interfaces.Command;
using VehicleTracker.Application.Contracts.Interfaces.Query;
using VehicleTracker.Application.Contracts.Interfaces.Services;
using VehicleTracker.Domain.Models;
using VehicleTracker.Infrastructure.Services;
using VehicleTracker.Infrastructure.Services.Settings;
using VehicleTracker.Persistence.Command;
using VehicleTracker.Persistence.Query;

namespace VehicleTracker.Infrastructure.DependencyInjection;

public static class InfraServiceCollectionExtensions
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddInfrastructure(IConfiguration configuration)
        {
            services.AddPersistence(configuration);
            services.AddRepositories();
            services.AddServices(configuration);

            return services;
        }

        private IServiceCollection AddServices(IConfiguration configuration)
        {
        
            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<IJwtProvider, JwtProvider>();

            return services;
        }

        private static void ConfigureMongoMapping()
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

        private IServiceCollection AddPersistence(IConfiguration configuration)
        {
            IServiceCollection.ConfigureMongoMapping();
            
            var mongoClient = new MongoClient(configuration.GetConnectionString("MongoConnection"));
            var mongoDatabase = mongoClient.GetDatabase("VehicleTrackerDb");

            services.AddSingleton(mongoDatabase);

            return services;
        }

        private IServiceCollection AddRepositories()
        {
            services.AddScoped<IAuthCommandRepository, AuthCommandRepository>();
            services.AddScoped<IAuthQueryRepository, AuthQueryRepository>();

            return services;
        }
    }
}