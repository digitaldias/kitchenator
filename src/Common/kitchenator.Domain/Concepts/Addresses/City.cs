namespace kitchenator.Domain.Concepts.Addresses
{
    public record City
    {
        public static City Empty = new City { CityName = "", CountryCode = "" };

        public string CityName { get; set; }

        public string CountryCode { get; set; }

        public string Key => $"{CountryCode}_{CityName}";
    }
}
