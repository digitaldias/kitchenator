using Dolittle.SDK;
using Dolittle.SDK.DependencyInversion;
using Dolittle.SDK.Events;
using Dolittle.SDK.Events.Store;
using Dolittle.SDK.Tenancy;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Runtime.CompilerServices;

namespace Dolittle.AspNET.ConfigurationExtensions
{
    /// <summary>
    /// Middleware class providing helper methods to set up and initialize the Dolittle Client
    /// </summary>
    public static class ClientBuilderExtensions
    {
        private static TaskAwaiter _runningDolittleClient;

        /// <summary>
        /// Runs the provided Dolittle client builder expression and adds it to services as a Singleton. <br />
        /// 
        /// Use this extension method to configure your Microservice, events and eventhandlers.
        /// <example><br />
        /// <b>Example:</b>
        /// <code>
        ///     services.AddDolittleClient(TenantId.Development, () => <br /> 
        ///     { <br />
        ///     return Client.ForMicroservice(myMicroserviceId) <br />
        ///     .WithEventTypes(conf => conf.Register&lt;MyEvent&gt;(); <br />
        ///     .WithEventHandlers(cont => conf.RegisterEventHandler&lt;MyEventHandler&gt;(); <br />
        ///     .Build(); <br />
        ///     } <br />
        /// </code></example>
        /// </summary>
        /// <param name="services">The IServiceCollection being extended</param>
        /// <param name="tenantId">The tenant for which the Client is catering</param>
        /// <param name="builder">An function that returns a configured Dolittle.SDK.Client instance</param>
        /// <returns>A reference to this instance after the operation has completed</returns>
        public static IServiceCollection AddDolittleClient(this IServiceCollection services, TenantId tenantId, Func<Client> builder)
        {
            var dolittleClient = builder();
            services.AddTransient<IEventStore>(_ => dolittleClient.EventStore.ForTenant(tenantId));
            services.AddSingleton(dolittleClient);

            return services;
        }

        /// <summary>
        /// Instructs the Dolittle <c>Client</c> singleton to connect to the Dolittle Runtime and start processing events.
        /// </summary>
        /// <remarks>You MUST use the extension <b>AddDolittleClient()</b> prior to using this extension method</remarks>
        /// <param name="builder">The Microsoft.AspNetCore.Builder.IApplicationBuilder to add the middleware to.</param>        
        /// <returns>A reference to this instance after the operation has completed</returns>
        public static IApplicationBuilder UseDolittle(this IApplicationBuilder builder)
        {
            // Spawning a client means it is now a singleton instance
            var client = builder.ApplicationServices.GetService<Client>();
            if (client is null)
            {
                throw new DolittleClientNotFoundInServiceCollection();
            }

            client
                .WithContainer(new DolittleAspNetContainer(builder.ApplicationServices, builder.ApplicationServices.GetService<ILogger<DolittleAspNetContainer>>()))
                .Start();

            return builder;
        }
    }
}
