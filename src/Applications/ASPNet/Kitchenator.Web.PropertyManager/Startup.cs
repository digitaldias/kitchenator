using kitchenator.business;
using kitchenator.data.azure;
using kitchenator.data.azure.Dto;
using kitchenator.data.azure.Dto.Realestate;
using kitchenator.Domain.BoundedContexts;
using kitchenator.Domain.Concepts.Realestate;
using kitchenator.Domain.Contracts;
using kitchenator.Domain.Contracts.Managers;
using kitchenator.Domain.Contracts.Readers;
using Kitchenator.Web.PropertyManager.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Kitchenator.Web.PropertyManager
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();

            
            services.AddSingleton<IDtoResolver<Restaurant>, RestaurantResolver>();
            services.AddSingleton<IModelReaderFor<Restaurant>, ReadOnlyRepository<Restaurant>>();

            services.AddSingleton<IEmployeeManager,   EmployeeManager>();
            services.AddSingleton<ICityReader,        CityReader>();
            services.AddSingleton<ICountriesReader,   CountriesReader>();
            services.AddSingleton<ICountriesLoader,   CountriesLoader>();
            services.AddHttpClient<BackendConnector>(client =>
            {
                client.BaseAddress = Configuration.GetServiceUri("kitchenator-propertyservice");
                #if DEBUG
                if(client.BaseAddress is null)
                {
                    client.BaseAddress = new System.Uri("https://localhost:44322");
                }
                #endif
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
