using Dolittle.AspNET.ConfigurationExtensions;
using Dolittle.SDK;
using Dolittle.SDK.Tenancy;
using kitchenator.data.azure;
using kitchenator.data.azure.Dto;
using kitchenator.data.azure.Dto.Employees;
using kitchenator.Domain;
using kitchenator.Domain.Concepts.Employees;
using kitchenator.Domain.Contracts;
using kitchenator.Domain.Events.Realestate;
using kitchenator.EventManagement.Employment;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Kitchenator.EmploymentService
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
            services.AddHealthChecks();
            services.AddControllers();
            // Transients
            services.AddTransient<IDtoResolver<Restaurant>, RestaurantResolver>();
            services.AddTransient(typeof(RestaurantEventHandler));

            // Singletons
            services.AddSingleton<IRepositoryFor<Restaurant>, Repository<Restaurant>>();

            // Dolittle
            services.AddDolittleClient(TenantId.Development, () =>
            {
                var settings = MicroserviceConfiguration.Dolittle;
                return Client.ForMicroservice(settings.ServiceId)
                    .WithRuntimeOn(settings.HostName, settings.HostPort)
                    .WithEventTypes(config =>
                    {                     
                        config.Register<RestaurantCreated>();
                    })
                    .WithEventHandlers(config =>
                    {
                    config.RegisterEventHandler<RestaurantEventHandler>();
                    })
                    .Build();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDolittle();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("/health");
                endpoints.MapControllers();
            });
        }
    }
}
