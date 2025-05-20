using Entity.Context;
using Microsoft.EntityFrameworkCore;

namespace Api.ServicesCollection
{
    public static class AddAutoMapper 
    {
        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
           services.AddAutoMapper(typeof(Helper.autoMapper.MapeoObject));

            return services;

        }
    }
}
