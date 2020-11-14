using kitchenator.Domain.Concepts.Addresses;
using System.Collections.Generic;

namespace kitchenator.Domain.Contracts.Managers
{
    public interface ICountriesLoader : IMustBeInitialized
    {
        IEnumerable<Country> Countries { get; }
    }
}
