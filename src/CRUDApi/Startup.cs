using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUDApi.Data;
using CRUDApi.Data.Repository;
using CRUDApi.Data.Repository.Abstractions;
using CRUDApi.Data.Repository.Implementations;
using CRUDApi.Services;
using CRUDApi.Services.Abstractions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using AutoMapper;

namespace CRUDApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddDbContext<ScrumTeamContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SQLServer")));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CRUDApi", Version = "v1" });
            });
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IDevelopmentTeamService, DevelopmentTeamService>();
            services.AddScoped<IProfileService, ProfileService>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CRUDApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
