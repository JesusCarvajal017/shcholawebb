using Entity.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Api.ServicesCollection
{
    public static class ServicesDbFactory
    {
        public static IServiceCollection AddDataAccessFactory(this IServiceCollection services, string dbString, IConfiguration _configuration)
        {
            string dataBaseEngine = dbString;

            services.AddDbContext<AplicationDbContext>(options =>
                        options.UseNpgsql(_configuration.GetConnectionString(dbString)));

            //services.AddDbContext<AplicationDbContext>(options =>
            //           options.UseSqlServer(_configuration.GetConnectionString(dbString)));

            return services;

        }
    }
}
