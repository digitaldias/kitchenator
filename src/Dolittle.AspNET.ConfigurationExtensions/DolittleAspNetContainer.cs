using Dolittle.SDK.DependencyInversion;
using Dolittle.SDK.Execution;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace Dolittle.AspNET.ConfigurationExtensions
{
    public class DolittleAspNetContainer : IContainer
    {
        readonly IServiceProvider _serviceProvider;
        readonly ILogger<DolittleAspNetContainer> _logger;

        public DolittleAspNetContainer(IServiceProvider serviceProvider, ILogger<DolittleAspNetContainer> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }
        public object Get(Type service, ExecutionContext context)
        {
            _logger.LogInformation($"Returning service {service.Name}");
            return _serviceProvider.GetService(service);
        }

        public T Get<T>(ExecutionContext context) where T : class
        {
            _logger.LogInformation($"Returning T = '{typeof(T)}'");
            return _serviceProvider.GetService<T>();
        }
    }
}
