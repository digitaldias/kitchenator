using Dolittle.SDK.Events;
using Dolittle.SDK.Events.Handling;
using Dolittle.SDK.Events.Store;
using kitchenator.Domain;
using kitchenator.Domain.Concepts.Employees;
using kitchenator.Domain.Contracts;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using RE_Concept = kitchenator.Domain.Concepts.Realestate;
using RE_Event = kitchenator.Domain.Events.Realestate;

namespace kitchenator.EventManagement.Employment
{
    [EventHandler("1b12e37e-c3f0-4b1b-a476-6700c001d6bf", partitioned: true, inScope: null)]
    public class RestaurantEventHandler : ICanHandleEvents
    {
        readonly ILogger<RestaurantEventHandler> _logger;
        readonly IEventStore                     _eventStore;
        readonly IRepositoryFor<Restaurant>      _restaurantRepo;

        public RestaurantEventHandler(
            ILogger<RestaurantEventHandler> logger,
            IEventStore eventStore, 
            IRepositoryFor<Restaurant> restaurantRepo)
        {
            _logger         = logger;
            _eventStore     = eventStore;
            _restaurantRepo = restaurantRepo;
        }

        public async Task Handle(RE_Event.RestaurantCreated evt, EventContext eventContext)
        {
            _logger.LogInformation($"Adding new restaurant {evt.Name} in {evt.Address.City.CityName}, {evt.Address.City.CountryCode}.");

            if (evt is RE_Concept.Restaurant restaurant)
            {
                var newRestaurant = new Restaurant(restaurant);
                await _restaurantRepo.Upsert(newRestaurant);
            }
        }
    }
}