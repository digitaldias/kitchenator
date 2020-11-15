using kitchenator.Domain.Concepts.Realestate;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace kitchenator.Domain.Contracts.Managers
{
    public interface IRealestateManager
    {
        Task<Restaurant> GetById(string potentiallyUnsafeId);

        Task<IEnumerable<Restaurant>> GetAll();

        Task<bool> CreateRestaurant(Restaurant restaurant, CancellationToken token);
    }
}
