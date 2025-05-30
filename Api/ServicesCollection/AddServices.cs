

using Business.global;
using Business.service;
using Data.factories;
using Utilities.Jwt;

namespace Api.ServicesCollection
{
    public static class AddServices
    {
        public static IServiceCollection AddServicesApp(this IServiceCollection services)
        {
            // Fabrica concreta de data primera base de datos 
            services.AddScoped<IDataFactoryGlobal, GlobalFactory>();
            services.AddScoped<GenerateTokenJwt>();

            services.AddScoped<PersonBussines>();
            services.AddScoped<UserBusiness>();
            services.AddScoped<UserRolBusiness>();
            services.AddScoped<RolFormPermissionBusiness>();

            services.AddScoped<AuthGlobal>();

            return services;

        }
    }
}
