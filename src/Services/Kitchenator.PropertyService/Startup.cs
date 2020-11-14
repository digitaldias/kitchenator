using Dolittle.AspNET.ConfigurationExtensions;
using Dolittle.SDK;
using Dolittle.SDK.Tenancy;
using kitchenator.data.azure;
using kitchenator.Domain;
using kitchenator.Domain.BoundedContexts;
using kitchenator.Domain.Concepts.Realestate;
using kitchenator.Domain.Contracts;
using kitchenator.Domain.Events.Realestate;
using kitchenator.EventManagement.Realestate;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Kitchenator.PropertyService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

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

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHealthChecks();
            services.AddControllers();
            
            services.AddTransient<RealestateEventHandler>();            
            services.AddSingleton<IRepositoryFor<Restaurant, IBoundedContext.RealEstate>, RestaurantRepo<IBoundedContext.RealEstate>>();

            services.AddDolittleClient(TenantId.Development, () =>
            {
                var settings = MicroserviceConfiguration.Dolittle;
                return Client.ForMicroservice(settings.ServiceId)
                 .WithEventTypes(config =>
                 {
                     config.Register<RestaurantCreated>();
                     config.Register<RestaurantCreationRequested>();
                 })
                .WithEventHandlers(config =>
                {
                    config.RegisterEventHandler<RealestateEventHandler>();
                }).Build();
            });
        }
    }
}