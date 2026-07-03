using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using VehicleTracker.Application.Contracts.Interfaces.Command;
using VehicleTracker.Application.Contracts.Interfaces.Query;
using VehicleTracker.Application.Contracts.Interfaces.Services;
using VehicleTracker.Infrastructure.Services;
using VehicleTracker.Infrastructure.Services.Settings;
using VehicleTracker.Persistence.Command;
using VehicleTracker.Persistence.Query;
using VehicleTracker.Persistence.MongoMappers;

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

        private IServiceCollection AddPersistence(IConfiguration configuration)
        {
            MongoMappingExtensions.ConfigureUserMapping();
            MongoMappingExtensions.ConfigureInvitationMapping();
            
            var connectionString = configuration.GetConnectionString("MongoConnection");

            ArgumentException.ThrowIfNullOrWhiteSpace(connectionString,
                "A ConnectionString não foi encontrada.");
            
            var mongoClient = new MongoClient(connectionString);
            var mongoDatabase = mongoClient.GetDatabase("VehicleTrackerDb");

            services.AddSingleton(mongoDatabase);

            return services;
        }

        private IServiceCollection AddRepositories()
        {
            services.AddScoped<IAuthCommandRepository, AuthCommandRepository>();
            services.AddScoped<IAuthQueryRepository, AuthQueryRepository>();
            
            services.AddScoped<IInvitationCommandRepository, InvitationCommandRepository>();
            services.AddScoped<IInvitationQueryRepository, InvitationQueryRepository>();

            return services;
        }
    }
}