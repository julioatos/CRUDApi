using CRUDApi.Api;
using CRUDApi.DTOs;
using CRUDApi.EFCore;
using CRUDApi.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddApi().AddMapper().AddPersistence(configuration).AddServices();
        }
    }
}
