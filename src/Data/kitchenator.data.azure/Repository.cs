using kitchenator.Domain;
using kitchenator.Domain.BoundedContexts;
using kitchenator.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace kitchenator.data.azure
{
    public abstract class Repository<TReadModel, TBoundedContext> : AzureConnectedTable, IRepositoryFor<TReadModel, TBoundedContext>
        where TReadModel : IReadModel
        where TBoundedContext : IBoundedContext
    {
        public Repository(string tableName)
            : base($"{typeof(TBoundedContext).Name.ToLower()}o0o{tableName.ToLower()}")
        {
        }

        public abstract Task<bool> DeleteById(Guid Id);

        public abstract Task<IEnumerable<TReadModel>> GetAll();

        public abstract Task<TReadModel> GetById(Guid id);

        public abstract Task<bool> Upsert(TReadModel readModel);
    }
}
