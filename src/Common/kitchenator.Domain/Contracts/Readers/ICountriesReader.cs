using kitchenator.Domain.Concepts.Addresses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace kitchenator.Domain.Contracts.Readers
{
    public interface ICountriesReader : IMustBeInitialized
    {
        Task<IEnumerable<Country>> GetAllCountries();
    }
}
