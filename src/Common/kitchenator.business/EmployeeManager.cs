using kitchenator.Domain.Concepts.Employees;
using kitchenator.Domain.Concepts.Realestate;
using kitchenator.Domain.Contracts.Managers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace kitchenator.business
{
    public class EmployeeManager : IEmployeeManager
    {
        public EmployeeManager()
        {
        }

        public async Task<IEnumerable<Employee>> LoadForRestaurant(RestaurantId restaurantId)
        {
            return await Task.FromResult(new List<Employee>());
        }
    }
}
