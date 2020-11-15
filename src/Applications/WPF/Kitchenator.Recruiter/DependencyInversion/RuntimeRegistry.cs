using kitchenator.business;
using kitchenator.data.azure;
using kitchenator.Domain.Contracts.Managers;
using kitchenator.Domain.Contracts.Readers;
using Lamar;

namespace Kitchenator.Recruiter.DependencyInversion
{
    public class RuntimeRegistry : ServiceRegistry
    {
        public RuntimeRegistry()
        {
            Scan(x =>
            {
                x.AssembliesAndExecutablesFromApplicationBaseDirectory();
                x.WithDefaultConventions();
            });

            // Singletons in the Project                        
            For<ICountriesReader>().Use<CountriesReader>().Singleton();
            For<ICountriesLoader>().Use<CountriesLoader>().Singleton();
        }
    }
}
