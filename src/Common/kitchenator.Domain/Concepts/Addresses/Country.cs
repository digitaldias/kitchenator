using System.Collections.Generic;

namespace kitchenator.Domain.Concepts.Addresses
{
    public record Country
    {
        public static readonly Country Empty = new Country
        {
            CountryCode = string.Empty,
            CountryName = string.Empty,
            Cities      = new List<City>()
        };

        public string CountryCode { get; set; }
        
        public string CountryName { get; set; }

        public List<City> Cities { get; set; }

        public string Key => $"{CountryCode}_{CountryName}";
    }
}