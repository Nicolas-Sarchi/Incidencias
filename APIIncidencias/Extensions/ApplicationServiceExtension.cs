using Dominio.Interfaces;
using Aplicacion.UnitOfWork;
using Aplicacion.Repository;
using Persistencia.Data;

namespace APIIncidencias.Extensions
{
    public static class ApplicationServiceExtension
    {
        public static void ConfigureCors(this IServiceCollection services) =>
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
            builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
        });

        public static void AddAppServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
