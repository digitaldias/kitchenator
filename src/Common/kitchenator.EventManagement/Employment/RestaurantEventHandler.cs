using Dolittle.SDK.Events;
using Dolittle.SDK.Events.Handling;
using Dolittle.SDK.Events.Store;
using kitchenator.Domain;
using kitchenator.Domain.BoundedContexts;
using kitchenator.Domain.Concepts.Realestate;
using kitchenator.Domain.Contracts;
using kitchenator.Domain.Events.Realestate;
using System;
using System.Threading.Tasks;

namespace kitchenator.EventManagement.Employment
{
    [EventHandler("1b12e37e-c3f0-4b1b-a476-6700c001d6bf", partitioned: true, inScope: null)]
    public class RestaurantEventHandler : ICanHandleEvents
    {
        readonly IEventStore _eventStore;
        readonly IRepositoryFor<Restaurant, IBoundedContext.Employment> _restaurantRepo;

        public RestaurantEventHandler(IEventStore eventStore, IRepositoryFor<Restaurant, IBoundedContext.Employment> restaurantRepo)
        {
            _eventStore     = eventStore;
            _restaurantRepo = restaurantRepo;
        }

        public async Task Handle(RestaurantCreated evt, EventContext eventContext)
        {
            var restaurant = evt as Restaurant;
            if (restaurant is { })
            {
                await _restaurantRepo.Upsert(restaurant);
            }
        }
    }
}