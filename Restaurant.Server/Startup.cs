using Autofac;
using FluentValidation.AspNetCore;
using Restaurant.Data.Context;
using Restaurant.Domain;
using Restaurant.Startups;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace Restaurant
{
    public sealed class Startup
    {
        #region Constants
        private const string CONNECTION_STRING_PROP_NAME = "DB_CONNECTION_STRING";
        private const string MIGRATIONS_ASSEMBLY = "Restaurant.Data";
        #endregion

        #region Properties
        private IConfiguration Configuration { get; }
        #endregion

        #region Constructors
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }
        #endregion

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Environment.GetEnvironmentVariable(CONNECTION_STRING_PROP_NAME);

            if (string.IsNullOrEmpty(connectionString))
            {
                connectionString = this.Configuration.GetConnectionString(CONNECTION_STRING_PROP_NAME);
            }

            services.AddOptions();

            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(connectionString, b => b.MigrationsAssembly(MIGRATIONS_ASSEMBLY)), ServiceLifetime.Transient);

            services.AddScoped<IDataContext>(provider => provider.GetService<DataContext>());

            services.AddSingleton(this.Configuration)
                    .AddHttpClient()
                    .AddControllers()
                    .AddControllersAsServices()
                    .AddFluentValidation(c => c.RegisterValidatorsFromAssemblyContaining<Startup>())
                    .AddNewtonsoftJson(options =>
                    {
                        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                        options.SerializerSettings.Converters.Add(new StringEnumConverter());
                    });

            services.AddControllersWithViews();

            services.AddSpaStaticFiles(configuration => configuration.RootPath = "ClientApp/dist");
            services.AddSwagger();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule<DomainModule>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Restaurant V1");
                c.RoutePrefix = "api";
            });

            app.UseRouting();

            app.UseEndpoints(endpoints => endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}"));

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
