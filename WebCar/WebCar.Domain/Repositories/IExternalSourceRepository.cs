﻿using System.Linq.Expressions;
using WebCar.Domain.Core;

namespace WebCar.Domain.Repositories
{
    public interface IExternalSourceRepository<TEntity, TKey> where TEntity : IExternalSource
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        TEntity Get(TKey id);
        IQueryable<TEntity> GetByExpression(Expression<Func<TEntity, bool>> predicate);
        int Save();
        Task<TEntity> GetAsync(TKey id, CancellationToken cancellationToken);
    }
}
