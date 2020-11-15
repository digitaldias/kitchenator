using Azure.Data.Tables;
using kitchenator.Domain;

namespace kitchenator.data.azure.Dto
{
    public interface IDtoResolver<TReadModel> where TReadModel : IReadModel
    {
        string Tablename { get; }

        TReadModel FromTableEntity(TableEntity entity);

        TableEntity ToTableEntity(TReadModel readmodel);
    }
}
