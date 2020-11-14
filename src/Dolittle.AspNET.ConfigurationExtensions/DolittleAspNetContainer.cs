using Dolittle.SDK.DependencyInversion;
using Dolittle.SDK.Execution;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Dolittle.AspNET.ConfigurationExtensions
{
    public class DolittleAspNetContainer : IContainer
    {
        readonly IServiceProvider _serviceProvider;

        public DolittleAspNetContainer(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public object Get(Type service, ExecutionContext context)
        {
            return _serviceProvider.GetService(service);
        }

        public T Get<T>(ExecutionContext context) where T : class
        {
            return _serviceProvider.GetService<T>();
        }
    }
}
