using Azure;
using Azure.Data.Tables;
using kitchenator.Domain;
using kitchenator.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace kitchenator.data.azure
{
    public class AzureConnectedTable : IMustBeInitialized
    {
        string _tableName;
        TableClient _client;

        public AzureConnectedTable(string tableName)
        {
            _tableName              = tableName;
            var settings            = MicroserviceConfiguration.AzureTables;
            _client                 = new TableClient(settings.ConnectionString, tableName);
        }

        public bool Initialized { get; private set; }

        protected TableClient TableClient  => _client;

        public async Task<IEnumerable<TableEntity>> GetAllRecords()
        {
            await Initialize();
            var entities = new List<TableEntity>();

            Pageable<TableEntity> query = _client.Query<TableEntity>();
            string token = null;
            do
            {
                var pages = query.AsPages(token, 100);
                foreach (var page in pages)
                {
                    foreach (var value in page.Values)
                    {
                        entities.Add(value);
                    }
                    token = page.ContinuationToken;
                }
            } while (!string.IsNullOrEmpty(token));

            return entities;
        }

        public async Task Initialize()
        {
            if (Initialized)
                return;

            try
            {
                var response = await _client.CreateIfNotExistsAsync();                
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}