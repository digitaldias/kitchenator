using Dolittle.SDK.Events.Store;
using kitchenator.Domain.BoundedContexts;
using kitchenator.Domain.Concepts.Realestate;
using kitchenator.Domain.Contracts;
using kitchenator.Domain.Contracts.Managers;
using kitchenator.Domain.Events.Realestate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace kitchenator.business.Realestate
{
    public class RealestateManager : IRealestateManager
    {
        readonly IEventStore _eventStore;
        readonly IRepositoryFor<Restaurant, IBoundedContext.RealEstate> _restaurants;

        List<Restaurant> _cache;

        public RealestateManager(IEventStore eventStore, IRepositoryFor<Restaurant, IBoundedContext.RealEstate> restaurants)
        {
            _eventStore  = eventStore;
            _restaurants = restaurants;
            _cache = new List<Restaurant>();
        }

        public async Task<bool> CreateRestaurant(Restaurant restaurant, CancellationToken token)
        {
            // Validate Restaurant

            // Save the restaurant in the readmodel
            var readModelUpdated = await _restaurants.Upsert(restaurant);

            // Fire the event
            if (readModelUpdated)
            {
                _cache.Add(restaurant);
                var createdEvent = new RestaurantCreated(restaurant);
                var commitResult = await _eventStore.CommitEvent(createdEvent, createdEvent.Id.Value);
                if (!commitResult?.Any() ?? false)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
            return true;
        }

        public async Task<IEnumerable<Restaurant>> GetAll()
        {
            if (!_cache?.Any() ?? true)
            {
                _cache = new List<Restaurant>(await _restaurants.GetAll());
            }
            return _cache;
        }

        public async Task<Restaurant> GetById(string potentiallyUnsafeId)
        {
            if (Guid.TryParse(potentiallyUnsafeId, out Guid restaurantId))
            {
                var restaurants = await GetAll();
                if (restaurants?.Any() ?? false)
                {
                    return restaurants.FirstOrDefault(r => r.Id == restaurantId);
                }
            }
            return null;
        }
    }
}