namespace kitchenator.Domain.Concepts.Addresses
{
    public record Address
    {
        public static readonly Address Empty = new Address
        {
            StreetName   = string.Empty,
            StreetNumber = string.Empty,
            PostalCode   = string.Empty,
            Country      = Country.Empty
        };

        public string StreetName { get; set; }

        public string StreetNumber { get; set; }

        public string PostalCode { get; set; }

        public Country Country { get; set; }
    }
}
