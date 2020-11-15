using Dolittle.SDK.Events;
using kitchenator.Domain.Concepts.Realestate;

namespace kitchenator.Domain.Events.Realestate
{
    [EventType("6C17CABC-F91F-4884-8581-2354A16403F1", generation: 0)]
    public record RestaurantCreated : Restaurant
    {
        public RestaurantCreated(Restaurant restaurant)
        {
            if(restaurant is { })
            {
                Id              = restaurant.Id;
                Name            = restaurant.Name;
                Address         = restaurant.Address;
                ChefCapacity    = restaurant.ChefCapacity;
                MonthlyRent     = restaurant.MonthlyRent;
                SeatingCapacity = restaurant.SeatingCapacity;
                SquareMeters    = restaurant.SquareMeters;
            }
        }
    }
}
