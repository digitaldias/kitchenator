using kitchenator.Domain.Concepts.Employees;
using kitchenator.Domain.Concepts.Realestate;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace kitchenator.Domain.Contracts.Managers
{
    public interface IEmployeeManager
    {
        Task<IEnumerable<Employee>> LoadForRestaurant(string restaurantId);
    }
}
