using kitchenator.Domain.Concepts.Addresses;
using kitchenator.Domain.Contracts.Readers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kitchenator.data.azure
{
    public class CityReader : AzureConnectedTable, ICityReader
    {
        const string CITY_TABLE_NAME = "cities";

        public CityReader()
            : base(CITY_TABLE_NAME)
        {
        }

        public async Task<IEnumerable<City>> GetAllCities()
        {
            var entities = await GetAllRecords();
            if (!entities.Any())
            {
                return new List<City>();
            }

            return entities.Select(e => new City
            {
                CountryCode = e.PartitionKey,
                CityName = e.RowKey
            });
        }
    }
}
