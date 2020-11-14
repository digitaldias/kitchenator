using System.Threading.Tasks;

namespace kitchenator.Domain.Contracts
{
    public interface IMustBeInitialized
    {
        bool Initialized { get; }
        Task Initialize();
    }
}
