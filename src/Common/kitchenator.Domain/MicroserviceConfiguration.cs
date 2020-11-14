using kitchenator.Domain.Contracts;
using Microsoft.Extensions.Configuration;

namespace kitchenator.Domain
{
    public static class MicroserviceConfiguration
    {
        static IConfigurationRoot _config;

        static MicroserviceConfiguration()
        {
            _config = new ConfigurationBuilder()
                .AddUserSecrets<IMustBeInitialized>(optional: true)
                .Build();
        }

        public static DolittleConfiguration Dolittle => _config
            .GetSection("Dolittle")
            .Get<DolittleConfiguration>();

        public static AzureTablesSettings AzureTables => _config
            .GetSection("AzureStorage")
            .Get<AzureTablesSettings>();


        public class AzureTablesSettings
        {
            public string ConnectionString { get; set; }
        }

        public class DolittleConfiguration
        {
            public string ServiceId { get; set; }
            public string HostName { get; set; }
            public ushort HostPort { get; set; }
        }
    }
}