using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace kitchenator.Domain.Contracts
{
    public interface IModelReaderFor<TReadModel> : IMustBeInitialized
        where TReadModel : IReadModel
    {
        Task<IEnumerable<TReadModel>> GetAll();

        Task<TReadModel> GetById(Guid id);
    }

    public interface IRepositoryFor<TReadModel> : IModelReaderFor<TReadModel>
        where TReadModel      : IReadModel
    {
        Task<bool> DeleteById(Guid Id);

        Task<bool> Upsert(TReadModel readModel);
    }
}