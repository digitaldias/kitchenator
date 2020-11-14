using kitchenator.Domain.Concepts.Addresses;
using kitchenator.Domain.Concepts.Money;

namespace kitchenator.Domain.Concepts.Realestate
{
    public record Restaurant : IReadModel
    {
        public RestaurantId Id { get; set; }

        public RestaurantName Name { get; set; }

        public City City { get; set; }

        public EmployeeCapacity ChefCapacity { get; set; }

        public Rent MonthlyRent { get; set; }
    }
}
