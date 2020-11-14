using kitchenator.Domain.Concepts.Addresses;
using kitchenator.Domain.Contracts.Readers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kitchenator.data.azure
{
    public class CountriesReader : AzureConnectedTable, ICountriesReader
    {
        const string COUNTRIES_TABLE_NAME = "countries";
        

        public CountriesReader()
            : base(COUNTRIES_TABLE_NAME)
        {        
        }

        public async Task<IEnumerable<Country>> GetAllCountries()
        {
            var entities = await GetAllRecords();
            if(!entities.Any())
            {
                return new List<Country>();
            }

            return entities.Select(e => new Country
            {
                CountryCode = new CountryCode(e.PartitionKey),
                CountryName = new CountryName(e.RowKey)
            });
        }
    }
}