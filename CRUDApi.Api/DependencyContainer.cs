using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace CRUDApi.Api
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddApi(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CRUDApi", Version = "v1" });
            });
            return services;
        }
    }
}
