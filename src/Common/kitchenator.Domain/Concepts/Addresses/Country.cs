using System.Collections.Generic;

namespace kitchenator.Domain.Concepts.Addresses
{
    public record Country
    {
        public static readonly Country Empty = new Country
        {
            CountryCode = CountryCode.Empty,
            CountryName = CountryName.Empty,
            Cities      = new List<City>()
        };

        public CountryCode CountryCode { get; set; }
        
        public CountryName CountryName { get; set; }

        public List<City> Cities { get; set; }

        public string Key => $"{CountryCode.Value}_{CountryName.Value}";
    }
}