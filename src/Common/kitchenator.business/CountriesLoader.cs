using kitchenator.Domain.Concepts.Addresses;
using kitchenator.Domain.Contracts.Managers;
using kitchenator.Domain.Contracts.Readers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kitchenator.business
{
    public class CountriesLoader : ICountriesLoader
    {
        readonly ICityReader      _cityReader;
        readonly ICountriesReader _countriesReader;
        private List<Country>     _countries;

        public CountriesLoader(ICountriesReader countriesReader, ICityReader cityReader)
        {
            _countriesReader = countriesReader;
            _cityReader      = cityReader;
        }

        public IEnumerable<Country> Countries => _countries;

        public bool Initialized => _initialized;

        bool _initialized { get; set; }

        public async Task Initialize()
        {
            if (Initialized)
            {
                return;
            }
            var cities = await _cityReader.GetAllCities();
            _countries = (await _countriesReader.GetAllCountries()).ToList();

            foreach(var country in _countries)
            {
                var citiesFound = cities.Where(c =>
                    c.CountryCode.Value.Equals(country.CountryCode.Value, System.StringComparison.InvariantCultureIgnoreCase));
                country.Cities = new List<City>(citiesFound);
            }
            _initialized = true;
        }
    }
}