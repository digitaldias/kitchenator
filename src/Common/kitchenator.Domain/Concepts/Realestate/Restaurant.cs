using kitchenator.Domain.Concepts.Addresses;
using System;

namespace kitchenator.Domain.Concepts.Realestate
{
    public record Restaurant : IReadModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public City City { get; set; }

        public Address Address { get; set; }

        public int ChefCapacity { get; set; }

        public decimal MonthlyRent { get; set; }

        public int SeatingCapacity { get; set; }

        public int SquareMeters { get; set; }
    }
}
