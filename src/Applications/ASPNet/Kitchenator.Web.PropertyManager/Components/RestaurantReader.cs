using kitchenator.Domain.BoundedContexts;
using kitchenator.Domain.Concepts.Realestate;
using kitchenator.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kitchenator.Web.PropertyManager.Components
{
    public class RestaurantReader<TBoundedContext> : IModelReaderFor<Restaurant, TBoundedContext>
        where TBoundedContext : IBoundedContext
    {
        readonly IModelReaderFor<Restaurant, IBoundedContext> _restaurants;

        public RestaurantReader(IModelReaderFor<Restaurant, IBoundedContext> restaurants)
        {            
            _restaurants = restaurants;
        }

        public bool Initialized => _restaurants.Initialized;

        public Task<IEnumerable<Restaurant>> GetAll() => _restaurants.GetAll();

        public Task<Restaurant> GetById(Guid id) => _restaurants.GetById(id);

        public Task Initialize() => _restaurants.Initialize();
    }
}
