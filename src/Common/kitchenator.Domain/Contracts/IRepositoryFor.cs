﻿using kitchenator.Domain.BoundedContexts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace kitchenator.Domain.Contracts
{
    public interface IModelReaderFor<TReadModel, TBoundedContext> : IMustBeInitialized
        where TReadModel : IReadModel
        where TBoundedContext : IBoundedContext

    {
        Task<IEnumerable<TReadModel>> GetAll();

        Task<TReadModel> GetById(Guid id);
    }

    public interface IRepositoryFor<TReadModel, TBoundedContext> : IModelReaderFor<TReadModel, TBoundedContext>
        where TReadModel      : IReadModel
        where TBoundedContext : IBoundedContext

    {
        Task<bool> DeleteById(Guid Id);


        Task<bool> Upsert(TReadModel readModel);
    }
}