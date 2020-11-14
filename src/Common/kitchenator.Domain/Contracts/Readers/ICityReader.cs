using kitchenator.Domain.Concepts.Addresses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace kitchenator.Domain.Contracts.Readers
{
    public interface ICityReader : IMustBeInitialized
    {
        Task<IEnumerable<City>> GetAllCities();
    }
}
