using CRUDApi.Data;
using CRUDApi.Data.Repository.Abstractions;
using CRUDApi.Data.Repository.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDApi.EFCore
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ScrumTeamContext>(options => options.UseSqlServer(configuration.GetConnectionString("SQLServer"),
                    x => x.MigrationsAssembly(typeof(ScrumTeamContext).Assembly.GetName().Name)
                ));
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            return services;
        }
    }
}
