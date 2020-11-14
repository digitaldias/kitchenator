namespace kitchenator.Domain.Concepts.Addresses
{
    public record City
    {
        public CityName CityName { get; set; }

        public CountryCode CountryCode { get; set; }

        public string Key => $"{CountryCode.Value}_{CityName.Value}";
    }
}
