using Dolittle.SDK.Events;
using Dolittle.SDK.Events.Handling;
using Dolittle.SDK.Events.Store;
using kitchenator.Domain;
using kitchenator.Domain.BoundedContexts;
using kitchenator.Domain.Concepts.Employees;
using kitchenator.Domain.Contracts;
using System;
using System.Threading.Tasks;
using Realestate = kitchenator.Domain.Events.Realestate;
using RealEstate = kitchenator.Domain.Concepts.Realestate;

namespace kitchenator.EventManagement.Employment
{
    [EventHandler("1b12e37e-c3f0-4b1b-a476-6700c001d6bf", partitioned: true, inScope: null)]
    public class RestaurantEventHandler : ICanHandleEvents
    {
        readonly IEventStore _eventStore;
        readonly IRepositoryFor<Restaurant> _restaurantRepo;

        public RestaurantEventHandler(IEventStore eventStore, IRepositoryFor<Restaurant> restaurantRepo)
        {
            _eventStore     = eventStore;
            _restaurantRepo = restaurantRepo;
        }

        public async Task Handle(Realestate.RestaurantCreated evt, EventContext eventContext)
        {            
            if (evt is RealEstate.Restaurant restaurant)
            {
                var newRestaurant = new Restaurant
                {
                    Id                = restaurant.Id,
                    Name              = restaurant.Name,
                    Address           = restaurant.Address,
                    EmployeeCapacity  = restaurant.ChefCapacity,
                    CloseDate         = DateTime.MaxValue,
                    CurrentlyEmployed = 0
                };
                await _restaurantRepo.Upsert(newRestaurant);
            }
        }
    }
}