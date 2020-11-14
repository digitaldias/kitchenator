namespace kitchenator.Domain.Concepts.Addresses
{
    public record Address
    {
        public static readonly Address Empty = new Address
        {
            StreetName   = StreetName.Empty,
            StreetNumber = StreetNumber.Empty,
            PostalCode   = PostalCode.Empty,
            Country      = Country.Empty
        };

        public StreetName StreetName { get; set; }

        public StreetNumber StreetNumber { get; set; }

        public PostalCode PostalCode { get; set; }

        public Country Country { get; set; }
    }
}
