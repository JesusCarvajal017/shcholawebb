namespace Api.ServicesCollection
{
    public static class AddPermissionCors
    {

        public static IServiceCollection AddPermissionCorsApp(this IServiceCollection services, IConfiguration configuracion)
        {
            var origenesPermitidos = configuracion.GetValue<string>("OrigenesPermitidos")!.Split(",");

            services.AddCors(opciones =>
            {
                opciones.AddDefaultPolicy(optionCorst =>
                {
                    optionCorst.WithOrigins(origenesPermitidos).AllowAnyMethod().AllowAnyHeader();
                });
            });

            return services;

        }
    }
}
