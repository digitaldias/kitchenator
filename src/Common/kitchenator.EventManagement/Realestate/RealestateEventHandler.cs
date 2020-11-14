using Dolittle.SDK.Events;
using Dolittle.SDK.Events.Handling;
using Dolittle.SDK.Events.Store;
using kitchenator.Domain;
using kitchenator.Domain.BoundedContexts;
using kitchenator.Domain.Concepts.Realestate;
using kitchenator.Domain.Contracts;
using kitchenator.Domain.Events.Realestate;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace kitchenator.EventManagement.Realestate
{
    [EventHandler("B31D96CD-034C-4B23-AF07-8B0E9DFC041F", partitioned: true, inScope: null)]
    public class RealestateEventHandler : ICanHandleEvents
    {
        readonly IRepositoryFor<Restaurant, IBoundedContext.RealEstate> _restaurantWriter;
        readonly IEventStore _eventStore;

        public RealestateEventHandler(IEventStore eventStore, IRepositoryFor<Restaurant, IBoundedContext.RealEstate> restaurantWriter)
        {
            _eventStore = eventStore;
            _restaurantWriter = restaurantWriter;
        }

        public async Task Handle(RestaurantCreationRequested request, EventContext eventContext)
        {
            // Assume the request passed validation, because assumption is not the mother of all...
            var restaurant = MapCreationRequestToRestaurant(request);
            var created = new RestaurantCreated(restaurant);

            var committed = await _eventStore.CommitEvent(created, eventContext.EventSourceId);
            if (committed?.Any() ?? false)
            {
                await _restaurantWriter.Upsert(restaurant);
            }
        }

        private static Restaurant MapCreationRequestToRestaurant(RestaurantCreationRequested request)
        {
            return new Restaurant
            {
                Id           = Guid.NewGuid(),
                Name         = request.Name,
                City         = request.City,
                ChefCapacity = request.ChefCapacity,
                MonthlyRent  = request.MonthlyRent
            };
        }
    }
}