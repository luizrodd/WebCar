﻿using WebCar.Domain.Core;

namespace WebCar.Domain.Repositories
{
    public interface IRepository<TEntity, TKey> where TEntity : Entity<TKey>
    {
        void Add(TEntity obj);
        TEntity Get(TKey id);
        void Update(TEntity obj);
    }
}