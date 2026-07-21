using Amazon.S3;
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
using VehicleTracker.Persistence.MongoConfigurations;

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
            services.AddCloudflare(configuration);

            return services;
        }

        private IServiceCollection AddCloudflare(IConfiguration configuration)
        {
            var r2Config = configuration.GetSection("CloudflareR2");

            var s3Config = new AmazonS3Config
            {
                ServiceURL = r2Config["ServiceUrl"],
                ForcePathStyle = true
            };

            services.AddSingleton<IAmazonS3>(sp =>
                new AmazonS3Client(r2Config["AccessKey"],
                    r2Config["SecretKey"], s3Config));

            services.AddScoped<IStorageService, CloudflareR2StorageService>();

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
            MongoMappingExtensions.ConfigureVehicleMapping();
            
            var connectionString = configuration.GetConnectionString("MongoConnection");

            ArgumentException.ThrowIfNullOrWhiteSpace(connectionString,
                "A ConnectionString não foi encontrada.");
            
            var mongoClient = new MongoClient(connectionString);
            services.AddSingleton<IMongoClient>(mongoClient);
            
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
            
            services.AddScoped<IVehicleCommandRepository, VehicleCommandRepository>();
            services.AddScoped<IVehicleQueryRepository, VehicleQueryRepository>();

            services.AddScoped<IProfileCommandRepository, ProfileCommandRepository>();
            services.AddScoped<IProfileQueryRepository, ProfileQueryRepository>();

            return services;
        }
    }
}