using kitchenator.Domain;
using kitchenator.Domain.Contracts;
using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace kitchenator.data.azure
{
    public class AzureConnectedTable : IMustBeInitialized
    {
        public AzureConnectedTable(string tableName)
        {
            var settings            = MicroserviceConfiguration.AzureTables;
            var cloudStorageAccount = CloudStorageAccount.Parse(settings.ConnectionString);
            var tableClient         = cloudStorageAccount.CreateCloudTableClient();

            Table         = tableClient.GetTableReference(tableName);
        }

        public bool Initialized { get; private set; }

        public CloudTable Table { get; }

        public async Task<IEnumerable<DynamicTableEntity>> GetAllRecords()
        {
            await Initialize();
            TableContinuationToken token = null;
            var entities = new List<DynamicTableEntity>();
            try
            {
                do
                {
                    var executeResult = await Table.ExecuteQuerySegmentedAsync(new TableQuery<DynamicTableEntity>(), token);
                    token = executeResult.ContinuationToken;

                    entities.AddRange(executeResult.Results);
                } while (token is { });
            }
            catch (Exception ex)
            {
                Trace.Write(ex.Message);
            }
            return entities;
        }

        public async Task Initialize()
        {
            if (Initialized)
                return;

            try
            {
                Initialized = await Table.CreateIfNotExistsAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}