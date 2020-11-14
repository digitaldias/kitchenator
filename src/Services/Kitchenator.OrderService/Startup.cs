using Dolittle.AspNET.ConfigurationExtensions;
using Dolittle.SDK;
using Dolittle.SDK.Tenancy;
using kitchenator.Domain;
using kitchenator.Domain.Events;
using kitchenator.Domain.Events.Orders;
using kitchenator.EventManagement.Ordering;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Kitchenator.OrderService
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
            services.AddDolittleClient(TenantId.Development, () =>
            {
                var settings = MicroserviceConfiguration.Dolittle;
                return Client.ForMicroservice(settings.ServiceId)
                 .WithEventTypes(config =>
                 {
                     config.Register<OrderPlaced>();
                     config.Register<DishPrepared>();
                 })
                .WithEventHandlers(config =>
                {
                    config.RegisterEventHandler<OrderEventHandler>();
                }).Build();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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
