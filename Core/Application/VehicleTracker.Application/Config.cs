using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VehicleTracker.Application.Contracts.Interfaces.Mappers;
using VehicleTracker.Application.Mappers;

namespace VehicleTracker.Application;

public static class Config
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddApplication(IConfiguration configuration)
        {
            services.AddMappers();

            return services;
        }

        private IServiceCollection AddMappers()
        {
            services.AddScoped<IUserMapper, UserMapper>();
            services.AddScoped<IInvitationMapper, InvitationMapper>();

            return services;
        }
    }
}