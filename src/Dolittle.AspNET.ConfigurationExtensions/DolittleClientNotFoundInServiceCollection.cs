using System;

namespace Dolittle.AspNET.ConfigurationExtensions
{
    /// <summary>
    /// Thrown when a Dolittle Client instance is not found in the services collection
    /// </summary>
    public class DolittleClientNotFoundInServiceCollection : Exception
    {
        public DolittleClientNotFoundInServiceCollection() : base()
        {
        }

        public DolittleClientNotFoundInServiceCollection(string message) : base(message)
        {
        }

        public DolittleClientNotFoundInServiceCollection(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}