using kitchenator.Domain.Concepts.Employees;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace kitchenator.Domain.Contracts.Readers
{
    public interface IEmployeeReader : IMustBeInitialized
    {
        Task<IEnumerable<Employee>> GetAll();
    }
}
