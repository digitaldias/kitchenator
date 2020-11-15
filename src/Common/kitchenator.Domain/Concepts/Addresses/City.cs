namespace kitchenator.Domain.Concepts.Addresses
{
    public record City
    {
        public string CityName { get; set; }

        public string CountryCode { get; set; }

        public string Key => $"{CountryCode}_{CityName}";
    }
}
