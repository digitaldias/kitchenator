using Dolittle.SDK.Events;
using kitchenator.Domain.Concepts.Realestate;

namespace kitchenator.Domain.Events.Realestate
{
    [EventType("6C17CABC-F91F-4884-8581-2354A16403F1", generation: 0)]
    public record RestaurantCreated : Restaurant
    {
        public RestaurantCreated(Restaurant other)
        {
            Id           = other.Id;
            Name         = other.Name;
            City         = other.City;
            ChefCapacity = other.ChefCapacity;
            MonthlyRent  = other.MonthlyRent;
        }
    }
}
