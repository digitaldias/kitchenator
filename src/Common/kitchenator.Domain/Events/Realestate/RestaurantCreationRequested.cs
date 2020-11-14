using Dolittle.SDK.Events;
using kitchenator.Domain.Concepts.Addresses;
using kitchenator.Domain.Concepts.Money;
using kitchenator.Domain.Concepts.Realestate;

namespace kitchenator.Domain.Events.Realestate
{
    [EventType("CB940970-785B-404C-8C78-E20E327A1AEA", generation: 0)]
    public class RestaurantCreationRequested : CommandEvent
    {
        public RestaurantId RestaurantId { get; set; }

        public RestaurantName Name { get; set; }

        public City City { get; set; }

        public EmployeeCapacity ChefCapacity { get; set; }

        public Rent MonthlyRent { get; set; }
    }
}
