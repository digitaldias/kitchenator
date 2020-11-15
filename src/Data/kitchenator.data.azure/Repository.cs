using kitchenator.data.azure.Dto;
using kitchenator.Domain;
using kitchenator.Domain.Contracts;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace kitchenator.data.azure
{
    public class ReadOnlyRepository<TReadModel> : AzureConnectedTable, IModelReaderFor<TReadModel>
        where TReadModel : IReadModel
    {
        protected readonly IDtoResolver<TReadModel> _resolver;

        public ReadOnlyRepository(IDtoResolver<TReadModel> resolver)
            : base($"{resolver.Tablename}")
        {
            _resolver = resolver;
        }

        public async Task<IEnumerable<TReadModel>> GetAll()
        {
            var allEntities = await GetAllRecords();
            return allEntities.Select(e => _resolver.FromTableEntity(e));
        }

        public async Task<TReadModel> GetById(Guid id)
        {
            var records = await GetAll();

            return records.FirstOrDefault(record => record.Id.Equals(id));
        }
    }

    public class Repository<TReadModel> : ReadOnlyRepository<TReadModel>, IRepositoryFor<TReadModel>
        where TReadModel : IReadModel
    {
        public Repository(IDtoResolver<TReadModel> resolver)
            : base(resolver)
        {
        }

        public async Task<bool> DeleteById(Guid Id)
        {
            var readmodel   = await GetById(Id);
            var tableEntity = _resolver.ToTableEntity(readmodel);
            if(tableEntity is { })
            {
                var response = await TableClient.DeleteEntityAsync(tableEntity.PartitionKey, tableEntity.RowKey);
                return response.Status >= 200 && response.Status < 300;
            }
            return true;
        }

        public async Task<bool> Upsert(TReadModel readModel)
        {
            var tableEntity    = _resolver.ToTableEntity(readModel);
            var upsertResponse = await TableClient.UpsertEntityAsync(tableEntity);
            return upsertResponse.Status >= 200 && upsertResponse.Status < 300;
        }
    }
}
